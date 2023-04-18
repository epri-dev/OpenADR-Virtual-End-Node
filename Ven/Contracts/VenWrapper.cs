using Oadr.Library;
using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using Oadr.Ven.Resources;

namespace Oadr.Ven
{
    public class VenWrapper : ISendReport
    {
        private const string StatusPolling = "Polling...";
        private const string StatusIdle = "Idle";

        private readonly ProcessEvents _processEvents;

        private Thread _pollThread;
        private int _serverOffsetSeconds;
        private EOptType _optType = EOptType.OptIn;
        private TimeSpan _timeout = new TimeSpan(0, 0, 10);
        private readonly IVenWrapper _callbacks;

        public Ven2B Ven { get; }

        public EOptType OptType
        {
            set => _optType = value;
        }

        public bool IsRunning { get; private set; }

        public List<string> MarketContext => _processEvents.MarketContexts;

        public List<string> CustomSignals => _processEvents.CustomSignals;

        public Resources.Resources Resources { get; } = new Resources.Resources();

        public VenWrapper(Ven2B ven, IVenWrapper callbacks)
        {
            Ven = ven;
            _callbacks = callbacks;
            Resources.SetCallback(this);
            _processEvents = new ProcessEvents(callbacks);
            Resources.StartThread();            
        }
        
        ~VenWrapper()
        {
            Resources.StopThread();
        }
        
        private void UpdateStatus(string status, bool threadStopped = false)
        {
            _callbacks.ProcessUpdateStatus(status, threadStopped);
        }
        
        private void SetPollInterval(oadrCreatedPartyRegistrationType partyRegistration)
        {
            try
            {
                var totalSeconds = (int)XmlConvert.ToTimeSpan(partyRegistration.oadrRequestedOadrPollFreq.duration).TotalSeconds;
                _timeout = new TimeSpan(0, 0, totalSeconds);
            }
            catch
            {
                _timeout = new TimeSpan(0, 0, 10);
            }
        }
        
        private bool DoQueryPartyRegistration()
        {
            QueryRegistration queryRegistration;
            lock (Ven)
            {
                queryRegistration = Ven.QueryRegistration();
            }
            _callbacks.ProcessQueryRegistration(queryRegistration);

            if (queryRegistration.EiResponseCode != 200)
            {
                return false;
            }
            SetPollInterval(queryRegistration.Response);
            return true;
        }

        private bool DoRegisterReports(string reportRequestId = null)
        {
            var reports = Resources.Reports;
            RegisterReport registerReport;
            CreatedReport createdReport = null;
            lock (Ven)
            {
                registerReport = Ven.RegisterReport(RandomHex.Instance().GenerateRandomHex(10), reports, reportRequestId);

                // Check for piggy backed report requests.
                if (registerReport.Response.oadrReportRequest != null)
                {
                    // Send the createReport callback immediately to allow the UI to update if there's a one shot or history report request.
                    // These reports need to be registered before processCreatedReport() is called below.
                    _callbacks.ProcessCreateReport(registerReport.Response.oadrReportRequest);
                    Resources.CreateReport(registerReport.Response.oadrReportRequest);
                    // Issue a createdReport message using the requestID from the registerReport message.
                    createdReport = Ven.CreatedReport(registerReport.Request.requestID, 200, "OK", Resources.PendingReports);
                }
            }
            _callbacks.ProcessRegisterReport(registerReport);

            // The registerReport response included a piggy-backed reportRequest.
            if (createdReport != null)
            {
                _callbacks.ProcessCreatedReport(createdReport);

                // The new report might have a start date of NOW; call sendReports to force the report to be sent immediately.
                Resources.SendReports(DateTime.Now);
            }

            if (registerReport.EiResponseCode != 200)
            {
                return false;
            }
            return true;
        }
        
        private bool DoCreatePartyRegistration()
        {            
            // If we've previously registered, the VTN should return our VEN ID and Registration ID in the queryRegistration message.
            // We shouldn't need to call CreatePartyRegistration at this point.
            CreatePartyRegistration createPartyRegistration;
            lock (Ven)
            {
                createPartyRegistration = Ven.CreatePartyRegistration(RandomHex.Instance().GenerateRandomHex(10), oadrProfileType.Item20b, oadrTransportType.simpleHttp, "", false, false, true);
            }
            _callbacks.ProcessCreatePartyRegistration(createPartyRegistration);

            // Exit if registration failed;
            if (createPartyRegistration.EiResponseCode != 200)
            {
                return false;
            }
            SetPollInterval(createPartyRegistration.Response);
            return true;
        }
        
        private void DoSendUpdateReport(oadrReportType report, oadrReportRequestType reportRequest)
        {
            UpdateReport updateReport;
            lock (Ven)
            {
                updateReport = Ven.UpdateReport(RandomHex.Instance().GenerateRandomHex(10), report, reportRequest.reportRequestID);
            }
            _callbacks.ProcessUpdateReport(updateReport);

            // UpdatedReports can contain a CancelReport piggybacked message.
            // Process the message if it exists since the VTN is not expecting a cancelledReport response so we can't call processCancelReport(...) directly.
            if (updateReport.Response.oadrCancelReport != null)
            {
                // Cancel the report request.
                Resources.AddCancelReport(updateReport.Response.oadrCancelReport);
                // Call the callback to update the UI.
                _callbacks.ProcessCancelReport(updateReport.Response.oadrCancelReport);
            }
        }
        
        private bool HandleRegistration(bool forceReRegister = false)
        {
            try
            {
                if (Ven.IsRegistered && !forceReRegister)
                {
                    return true;
                }
                UpdateStatus(StatusPolling);

                // If we're not forcing reregistration, send a query registration first to see if the VTN already has us registered.
                if (!forceReRegister)
                {
                    if (!DoQueryPartyRegistration())
                    {
                        return false;
                    }

                    // If the VEN previously registered, the queryRegistration above will return the VEN ID and Registration ID.
                    if (Ven.IsRegistered)
                    {
                        if (!QueryEvents())
                        {
                            return false;
                        }
                        return true;
                    }
                }

                // Registration was either forced, or the VEN isn't registered; initiate the registration process.
                if (!DoCreatePartyRegistration())
                {
                    return false;
                }

                if (!DoRegisterReports())
                {
                    return false;
                }

                if (!QueryEvents())
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _callbacks.ProcessException(ex);
                return false;
            }
            return true;
        }
        
        private void ProcessDistributeEvent(oadrDistributeEventType distributeEvent)
        {
            lock (Ven)
            {
                _processEvents.Process(distributeEvent, distributeEvent.requestID, _optType, Ven);
            }
        }

        private bool QueryEvents()
        {
            RequestEvent requestEvent;
            lock (Ven)
            {
                requestEvent = Ven.RequestEvent();
            }

            _callbacks.ProcessRequestEvent(requestEvent);
            ProcessDistributeEvent(requestEvent.Response);
            return true;
        }

        private void HandleEventStatusChanges()
        {
            lock (_processEvents)
            {
                try
                {
                    var eventsStatusChanged = _processEvents.CheckEventStatusChanges(_serverOffsetSeconds);
                    if (eventsStatusChanged != null && eventsStatusChanged.Count > 0)
                    {
                        _callbacks.UpdateEventStatus(eventsStatusChanged);
                    }
                }
                catch(Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            }
        }

        private void ProcessRegisterReport(oadrRegisterReportType registerReport)
        {
            RegisteredReport registeredReport;
            lock (Ven)
            {
                registeredReport = Ven.RegisteredReport(registerReport.requestID, "200", "OK");
            }
            _callbacks.ProcessRegisteredReport(registeredReport);
        }
        
        private void ProcessCreateReport(oadrCreateReportType createReport)
        {
            CreatedReport createdReport;

            // Send the createReport callback immediately to allow the UI to update if there's a one shot or history report request.
            // These reports need to be registered before processCreatedReport() is called below.
            _callbacks.ProcessCreateReport(createReport.oadrReportRequest);

            lock (Ven)
            {
                var valid = Resources.CreateReport(createReport);
                createdReport = valid ?
                    Ven.CreatedReport(createReport.requestID, 200, "OK", Resources.PendingReports) :
                    Ven.CreatedReport(createReport.requestID, 452, "INVALID ID", Resources.PendingReports);

                // The new report might have a start date of NOW; call sendReports to force the report to be sent immediately.
                Resources.SendReports(DateTime.Now);
            }
            _callbacks.ProcessCreatedReport(createdReport);
        }
        
        private void ProcessCancelReport(oadrCancelReportType cancelReport)
        {
            CanceledReport canceledReport;
            lock (Ven)
            {
                var pendingReports = Resources.AddCancelReport(cancelReport);
                canceledReport = Ven.CanceledReport(cancelReport.requestID, 200, "OK", pendingReports);
            }
            _callbacks.ProcessCanceledReport(canceledReport, cancelReport);
        }
        
        private void ProcessCancelRegistration(oadrCancelPartyRegistrationType cancelRegistration)
        {
            CanceledPartyRegistration canceledRegistration;
            lock (Ven)
            {
                if (cancelRegistration.venID == Ven.VenId && cancelRegistration.registrationID == Ven.RegistrationId)
                {
                    canceledRegistration = Ven.CanceledPartyRegistration(cancelRegistration.requestID, 200, "OK");
                }
                else
                {
                    canceledRegistration = Ven.CanceledPartyRegistration(cancelRegistration.requestID, 452, "Invalid ID");
                }
            }
            _callbacks.ProcessCanceledRegistration(canceledRegistration);
        }
        
        private OadrPoll DoPoll()
        {
            OadrPoll oadrPoll;
            lock (Ven)
            {
                oadrPoll = Ven.Poll();
            }
            _callbacks.ProcessPoll(oadrPoll);

            if (oadrPoll == null)
            {
                return null;
            }

            _serverOffsetSeconds = oadrPoll.ServerOffset;
            if (oadrPoll.IsResponseTypeOfType(typeof(oadrDistributeEventType)))
            {
                ProcessDistributeEvent(oadrPoll.GetDistributeEventResponse());
            }
            else if (oadrPoll.IsResponseTypeOfType(typeof(oadrRegisterReportType)))
            {
                ProcessRegisterReport(oadrPoll.GetRegisterReportResponse());
            }
            else if (oadrPoll.IsResponseTypeOfType(typeof(oadrCreateReportType)))
            {
                ProcessCreateReport(oadrPoll.GetCreateReportResponse());
            }
            else if (oadrPoll.IsResponseTypeOfType(typeof(oadrCancelReportType)))
            {
                ProcessCancelReport(oadrPoll.GetCancelReportResponse());
            }
            else if (oadrPoll.IsResponseTypeOfType(typeof(oadrCancelPartyRegistrationType)))
            {
                ProcessCancelRegistration(oadrPoll.GetCancelPartyRegistrationResponse());
            }
            else if (oadrPoll.IsResponseTypeOfType(typeof(oadrRequestReregistrationType)))
            {
                HandleRegistration(true);
            }
            return oadrPoll;
        }

        private void Execute()
        {
            OadrPoll oadrPoll = null;
            while (IsRunning)
            {
                try
                {
                    UpdateStatus(StatusPolling);
                    if (HandleRegistration())
                    {
                        oadrPoll = DoPoll();
                    }               
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }

                try
                {
                    HandleEventStatusChanges();
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }

                try
                {
                    // Only sleep if the last oadrPoll was an OadrResponse or an error occurred.
                    if (oadrPoll?.Response == null || oadrPoll.IsResponseTypeOfType(typeof(oadrResponseType)) || oadrPoll.EiResponseCode != 200)
                    {
                        UpdateStatus(StatusIdle);
                        Thread.Sleep(_timeout);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
                catch (ThreadInterruptedException)
                {
                    // ignore
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            }
        }
        
        public void StartPolling()
        {
            if (IsRunning)
            {
                return;
            }
            IsRunning = true;
            _pollThread = new Thread(Execute);
            _pollThread.Start();
        }

        public void Shutdown()
        {
            StopPolling();
            Resources.StopThread();
        }
        
        public void StopPolling()
        {
            if (!IsRunning)
            {
                return;
            }
            IsRunning = false;
            _pollThread.Interrupt();
            _pollThread.Join();
        }
        
        public void UpdateEventOpt(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType, OptReasonEnumeratedType optReason, string resourceId)
        {
            var thread = new Thread(delegate()
            {
                try
                {
                    foreach (var @event in events)
                    {
                        CreateOpt createOpt;
                        lock (Ven)
                        {

                            createOpt = Ven.CreateOptEvent(RandomHex.Instance().GenerateRandomHex(10), RandomHex.Instance().GenerateRandomHex(10),
                                @event, optType, optReason, resourceId);
                        }
                        _callbacks.ProcessCreateOpt(createOpt);
                    }
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            });
            thread.Start();
        }

        public void UpdateEventOpt(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType, string requestId, int responseCode, string responseDescription)
        {
            var thread = new Thread(delegate()
            {
                try
                {
                    CreatedEvent createdEvent;
                    lock (Ven)
                    {
                        createdEvent = Ven.CreatedEvent(requestId, events, optType, responseCode, responseDescription);
                    }
                    _callbacks.ProcessCreatedEvent(createdEvent, _processEvents.ActiveEvents, requestId);
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            });
            thread.Start();
        }
        
        public void CreateOptSchedule(OptSchedule optSchedule)
        {
            var thread = new Thread(delegate()
            {
                try
                {
                    CreateOpt createOpt;
                    lock (Ven)
                    {
                        createOpt = Ven.CreateOptSchedule(RandomHex.Instance().GenerateRandomHex(10), optSchedule);
                    }
                    _callbacks.ProcessCreateOptSchedule(createOpt);
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            });
            thread.Start();
        }
        
        public void CancelOptSchedule(string optId)
        {
            var thread = new Thread(delegate()
            {
                try
                {
                    CancelOpt cancelOpt;
                    lock (Ven)
                    {
                        cancelOpt = Ven.CreateCancelOpt(RandomHex.Instance().GenerateRandomHex(10), optId);
                    }
                    _callbacks.ProcessCancelOpt(cancelOpt);
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            });
            thread.Start();
        }
        
        public void ClearEvents()
        {
            _processEvents.ClearEvents();
        }
        
        public void QueryRegistration()
        {
            var thread = new Thread(delegate()
            {
                try
                {
                    DoQueryPartyRegistration();
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }                
            });
            thread.Start();
        }
        
        public void CancelRegistration()
        {
            var thread = new Thread(delegate()
            {
                try
                {                                        
                    CancelPartyRegistration cancelRegistration;
                    lock (Ven)
                    {
                        cancelRegistration = Ven.CancelPartyRegistration();
                    }
                    _callbacks.ProcessCancelRegistration(cancelRegistration);                    
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            });
            thread.Start();
        }

        /// <summary>
        /// Force the VEN to re-register.
        /// </summary>
        public void Register()
        {            
            var thread = new Thread(delegate()
            {
                try
                {
                    lock (Ven)
                    {
                        if (!HandleRegistration(true))
                        {
                            return;
                        }

                        var poll = DoPoll();
                        // Continually process messages in the remote queue until the queue is empty.
                        while (!poll.IsResponseTypeOfType(typeof(oadrResponseType)))
                        {
                            poll = DoPoll();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
                finally
                {
                    UpdateStatus(StatusIdle);
                }
            });
            thread.Start();
        }

        public void ClearRegistration(string preAllocatedVenId = "")
        {
            lock (Ven)
            {
                Ven.ClearRegistration();
                if (preAllocatedVenId != string.Empty)
                {
                    Ven.VenId = preAllocatedVenId;
                }
            }
        }

        private void UpdateReportList()
        {
            var reports = Resources.Reports;

            // HACK: This was a simple way to update the list of registered reports.
            // Note that the reports are not actually registered until the user clicks register reports or registers with the VTN.
            var request = new RegisterReport();
            request.CreateRegisterReport("requestID", "venID", reports);
            _callbacks.ProcessUpdateReportList(request.Request);
        }
        
        public void AddResource(Resource resource)
        {
            Resources.AddResource(resource);
            UpdateReportList();
        }

        public void RemoveResource(Resource resource)
        {
            Resources.RemoveResource(resource.ResourceId);
            UpdateReportList();
        }
        
        public void RegisterReports()
        {
            var thread = new Thread(delegate()
            {
                try
                {
                    DoRegisterReports();
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            });
            thread.Start();
        }
        
        public void SendMetadataReport(string reportRequestId)
        {
            var thread = new Thread(delegate()
            {
                try
                {
                    Resources.HandleMetadataReportReceived();
                    DoRegisterReports(reportRequestId);
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            });
            thread.Start();
        }
        
        public void SendUpdateReport(oadrReportType report, oadrReportRequestType reportRequest)
        {
            var thread = new Thread(delegate()
            {
                try
                {
                    DoSendUpdateReport(report, reportRequest);                    
                }
                catch (Exception ex)
                {
                    _callbacks.ProcessException(ex);
                }
            });
            thread.Start();
        }

        public void ProcessCreateReportComplete(string reportRequestId)
        {
            _callbacks.ProcessCreateReportComplete(reportRequestId);
        }

        public void ClearAllReports()
        {
            Resources.ClearReports();
        }
    }
}
