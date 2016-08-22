//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using oadrlib.lib.oadr2b;

using oadrlib.lib.http;

using System.Threading;

using oadrlib.lib;

using oadrlib.lib.helper;

namespace oadr2b_ven.ven
{
    public class VenWrapper : resources.ISendReport
    {
        enum eVenWrapperState
        {
            REGISTER
        }

        private const string STATUS_POLLING = "Polling...";
        private const string STATUS_IDLE = "Idle";
        private const string STATUS_SHUTDOWN = "Shutting down...";

        private const string STATUS_REGISTRATION_FAILED = "Registration failed";

        private VEN2b m_ven = null;

        private Thread m_pollThread;
        private bool m_running = false;

        eOptType m_optType = eOptType.OptIn;

        private ProcessEvents m_processEvents;
        private ProcessOptSchedules m_processOptSchedules = new ProcessOptSchedules();        
        
        private ven.resources.Resources m_resources = new ven.resources.Resources();

        TimeSpan m_timeout = new TimeSpan(0, 0, 10);

        IVenWrapper m_callbacks;

        private int m_serverOffsetSeconds = 0;

        /**********************************************************************************/

        public VenWrapper(VEN2b ven, IVenWrapper callbacks)
        {
            m_ven = ven;

            m_callbacks = callbacks;

            m_resources.setCallback(this);

            m_processEvents = new ProcessEvents(callbacks);

            m_resources.startThread();            
        }

        /**********************************************************************************/

        ~VenWrapper()
        {
            m_resources.stopThread();
        }

        /**********************************************************************************/

        public List<string> MarketContext
        {
            get { return m_processEvents.MarketContexts; }
        }

        /**********************************************************************************/

        public List<string> CustomSingals
        {
            get { return m_processEvents.CustomSignals; }
        }

        /**********************************************************************************/

        public VEN2b VEN
        {
            get { return m_ven; }
        }

        /**********************************************************************************/

        public eOptType optTpye
        {
            set { m_optType = value; }
        }

        /**********************************************************************************/

        private void updateStatus(string status, bool threadStopped = false)
        {
            m_callbacks.processUpdateStatus(status, threadStopped);
        }

        /**********************************************************************************/

        private void setPollinterval(oadrCreatedPartyRegistrationType partyRegistration)
        {
            try
            {
                int totalSeconds = (int)System.Xml.XmlConvert.ToTimeSpan(partyRegistration.oadrRequestedOadrPollFreq.duration).TotalSeconds;

                m_timeout = new TimeSpan(0, 0, totalSeconds);
            }
            catch
            {
                m_timeout = new TimeSpan(0, 0, 10);
            }
        }

        /**********************************************************************************/

        private bool doQueryPartyRegistration()
        {
            QueryRegistration queryRegisteration;

            lock (m_ven) { queryRegisteration = m_ven.queryRegistration(); }

            m_callbacks.processQueryRegistration(queryRegisteration);

            if (queryRegisteration.eiResponseCode != 200)
                return false;

            setPollinterval(queryRegisteration.response);

            return true;
        }

        /**********************************************************************************/

        private bool doRegisterReports(string reportRequestID = null)
        {
            //ReportDescription reportDescription = m_resources.ReportDescription;
            Dictionary<string, ReportWrapper> reports = m_resources.Reports;

            RegisterReport registerReport;
            CreatedReport createdReport = null;

            lock (m_ven)
            {
                registerReport = m_ven.registerReport(RandomHex.instance().generateRandomHex(10), reports, reportRequestID);

                // check for piggy backed report requests
                if (registerReport.response.oadrReportRequest != null)
                {
                    // send the createReport callback immediately to allow UI's to update
                    // if there's a one shot or history report request, these reports
                    // need to be registered before processCreatedReport() is called below
                    m_callbacks.processCreateReport(registerReport.response.oadrReportRequest);

                    m_resources.createReport(registerReport.response.oadrReportRequest);

                    // issue a createdReport message using the requestID from the registerReport message
                    createdReport = m_ven.createdReport(registerReport.request.requestID, 200, "OK", m_resources.PendingReports);
                }
            }

            m_callbacks.processRegisterReport(registerReport);

            // the registerReport response included a piggy-backed reportRequest
            if (createdReport != null)
            {
                m_callbacks.processCreatedReport(createdReport);

                // the new report might have a start date of NOW; call sendReports to force
                // the report to be sent immediately
                m_resources.sendReports(DateTime.Now);
            }


            if (registerReport.eiResponseCode != 200)
                return false;

            return true;
        }

        /**********************************************************************************/

        private bool doCreatePartyRegistration()
        {            
            // if we've previously registered, the VTN should return our VEN ID and
            // Registration ID in the queryRegistration message
            // We shouldn't need to call CreatePartyRegistration at this point, but the
            // test set will n1_0020 will fail if we don't send the query message
            CreatePartyRegistration createPartyRegistration;

            lock (m_ven)
            {
                createPartyRegistration = m_ven.createPartyRegistration(RandomHex.instance().generateRandomHex(10), oadrProfileType.Item20b, oadrTransportType.simpleHttp, "", false, false, true);
            }

            m_callbacks.processCreatePartyRegisteration(createPartyRegistration);

            // exit if registration failed
            if (createPartyRegistration.eiResponseCode != 200)
                return false;

            setPollinterval(createPartyRegistration.response);

            return true;
        }

        /**********************************************************************************/

        private void doSendUpdateReport(oadrReportType report, oadrReportRequestType reportRequest)
        {
            UpdateReport updateReport;

            lock (m_ven)
            {
                updateReport = m_ven.updateReport(RandomHex.instance().generateRandomHex(10), report, reportRequest.reportRequestID);
            }
            
            m_callbacks.processUpdateReport(updateReport);

            // UpdatedReports can contain a CancelReport piggybacked message; process
            // the message if it exists
            // since the VTN is not expecting a cancelledReport response so we can't call processCancelReport(...) directly
            if (updateReport.response.oadrCancelReport != null)
            {
                // cancel the report request
                List<string> pendingReports = m_resources.addCancelReport(updateReport.response.oadrCancelReport);

                // call the callback to update the UI
                m_callbacks.processCancelReport(updateReport.response.oadrCancelReport);
            }
        }

        /**********************************************************************************/

        private bool handleRegistration(bool forceReregister = false)
        {
            try
            {
                if (m_ven.IsRegistered && !forceReregister)
                    return true;

                updateStatus(STATUS_POLLING);

                // if we're not forcing reregistration, send a quer registration first to see if
                // the VTN already has us registered
                if (!forceReregister)
                {
                    if (!doQueryPartyRegistration())
                        return false;

                    // if the VEN previously registered, the queryRegistration above will return
                    // the VEN ID and Registration ID
                    if (m_ven.IsRegistered)
                    {
                        if (!queryEvents())
                            return false;

                        return true;
                    }
                }

                // registration was either forced, or the VEN isn't registered
                // initate the registration process
                if (!doCreatePartyRegistration())
                    return false;

                if (!doRegisterReports())
                    return false;

                if (!queryEvents())
                    return false;
            }
            catch (Exception ex)
            {
                // notify the exception handler that an error occured
                // VenEventArgs args = new VenEventArgs(ex, eVenEventType.EXCEPTION);

                // m_venEvent(this, args);
                m_callbacks.processException(ex);
                //m_running = false;
                return false;
            }

            return true;
        }

        /**********************************************************************************/

        private void processDistributeEvent(oadrDistributeEventType distributeEvent)
        {

            lock (m_ven)
            {
                m_processEvents.processEvents(distributeEvent, distributeEvent.requestID, m_optType, m_ven);
            }
        }

        /**********************************************************************************/

        private bool queryEvents()
        {
            RequestEvent requestEvent;

            lock (m_ven) { requestEvent = m_ven.requestEvent(); }

            m_callbacks.processRequestEvent(requestEvent);

            processDistributeEvent(requestEvent.response);

            return true;
        }

        /**********************************************************************************/

        private void handleEventStatusChanges()
        {
            lock (m_processEvents)
            {
                try
                {
                    List<oadrDistributeEventTypeOadrEvent> eventsStatusChanged = m_processEvents.checkEventStatusChanges(m_serverOffsetSeconds);

                    if (eventsStatusChanged != null && eventsStatusChanged.Count > 0)
                    {
                        m_callbacks.updateEventStatus(eventsStatusChanged);
                    }
                }
                catch(Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            }
        }

        /**********************************************************************************/

        private void processRegisterReport(oadrRegisterReportType registerReport)
        {
            RegisteredReport registeredReport;

            lock (m_ven)
            {
                registeredReport = m_ven.registeredReport(registerReport.requestID, "200", "OK");
            }

            m_callbacks.processRegisteredReport(registeredReport);
        }

        /**********************************************************************************/

        private void processCreateReport(oadrCreateReportType createReport)
        {
            CreatedReport createdReport;

            // send the createReport callback immediately to allow UI's to update
            // if there's a one shot or history report request, these reports
            // need to be registered before processCreatedReport() is called below
            m_callbacks.processCreateReport(createReport.oadrReportRequest);

            lock (m_ven)
            {
                bool valid = m_resources.createReport(createReport);

                if (valid)
                    createdReport = m_ven.createdReport(createReport.requestID, 200, "OK", m_resources.PendingReports);
                else
                    createdReport = m_ven.createdReport(createReport.requestID, 452, "INVALID ID", m_resources.PendingReports);

                // the new report might have a start date of NOW; call sendReports to force
                // the report to be sent immediately
                m_resources.sendReports(DateTime.Now);
            }

            m_callbacks.processCreatedReport(createdReport);
        }

        /**********************************************************************************/

        private void processCancelReport(oadrCancelReportType cancelReport)
        {
            CanceledReport canceledReport;

            lock (m_ven)
            {
                List<string> pendingReports = m_resources.addCancelReport(cancelReport);

                canceledReport = m_ven.canceledReport(cancelReport.requestID, 200, "OK", pendingReports);
            }

            m_callbacks.processCanceledReport(canceledReport, cancelReport);
        }

        /**********************************************************************************/

        private void processCancelRegistration(oadrCancelPartyRegistrationType cancelRegistration)
        {
            CanceledPartyRegistration canceledRegistration;

            lock (m_ven)
            {
                if (cancelRegistration.venID == m_ven.VENID && cancelRegistration.registrationID == m_ven.RegistrationID)
                    canceledRegistration = m_ven.canceledPartyRegistration(cancelRegistration.requestID, 200, "OK");
                else
                    canceledRegistration = m_ven.canceledPartyRegistration(cancelRegistration.requestID, 452, "Invalid ID");
            }

            m_callbacks.processCanceledRegistration(canceledRegistration);
        }

        /**********************************************************************************/

        private OadrPoll doPoll()
        {
            OadrPoll oadrPoll = null;

            lock (m_ven) { oadrPoll = m_ven.poll(); }

            m_callbacks.processPoll(oadrPoll);

            if (oadrPoll == null)
                return null;

            m_serverOffsetSeconds = oadrPoll.serverOffset;

            if (oadrPoll.responseTypeIs(typeof(oadrDistributeEventType)))
                processDistributeEvent(oadrPoll.getDistributeEventResponse());

            else if (oadrPoll.responseTypeIs(typeof(oadrRegisterReportType)))
                processRegisterReport(oadrPoll.getRegisterReportResponse());

            else if (oadrPoll.responseTypeIs(typeof(oadrCreateReportType)))
                processCreateReport(oadrPoll.getCreateReportResponse());

            else if (oadrPoll.responseTypeIs(typeof(oadrCancelReportType)))
                processCancelReport(oadrPoll.getCancelReportResponse());

            else if (oadrPoll.responseTypeIs(typeof(oadrCancelPartyRegistrationType)))
                processCancelRegistration(oadrPoll.getCancelPartyRegistrationResponse());

            else if (oadrPoll.responseTypeIs(typeof(oadrRequestReregistrationType)))
                handleRegistration(true);

            return oadrPoll;
        }

        /**********************************************************************************/


        private void execute()
        {
            OadrPoll oadrPoll = null;            

            while (m_running)
            {
                try
                {
                    updateStatus(STATUS_POLLING);

                    if (handleRegistration())
                    {
                        oadrPoll = doPoll();
                    }               
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }

                try
                {
                    handleEventStatusChanges();
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }

                try
                {
                    // only sleep if the last oadrpoll was an OadrResponse or an error occured
                    if (oadrPoll == null || oadrPoll.response == null || oadrPoll.responseTypeIs(typeof(oadrResponseType)) || oadrPoll.eiResponseCode != 200)
                    {
                        updateStatus(STATUS_IDLE);

                        Thread.Sleep(m_timeout);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }

                }
                catch (ThreadInterruptedException)
                {
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            }

        }

        /**********************************************************************************/

        public void startPolling()
        {
            if (m_running)
                return;

            m_running = true;

            m_pollThread = new Thread(delegate()
            {
                execute();
            });

            m_pollThread.Start();

        }

        /**********************************************************************************/

        public void shutdown()
        {
            stopPolling();
            m_resources.stopThread();
        }

        /**********************************************************************************/

        public void stopPolling()
        {
            if (!m_running)
                return;

            m_running = false;
            m_pollThread.Interrupt();
            m_pollThread.Join();
        }

        /**********************************************************************************/

        public void updateEventOpt(List<oadrDistributeEventTypeOadrEvent> evts, OptTypeType optType, OptReasonEnumeratedType optReason, string resourceID)
        {
            Thread thread = new Thread(delegate()
            {
                try
                {
                    CreateOpt createOpt;

                    foreach (oadrDistributeEventTypeOadrEvent evt in evts)
                    {
                        lock (m_ven)
                        {

                            createOpt = m_ven.createOptEvent(RandomHex.instance().generateRandomHex(10), RandomHex.instance().generateRandomHex(10),
                                evt, optType, optReason, resourceID);
                        }

                        m_callbacks.processCreateOpt(createOpt);
                    }
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            });

            thread.Start();
        }

        /**********************************************************************************/

        public void updateEventOpt(List<oadrDistributeEventTypeOadrEvent> evts, OptTypeType optType, string requestID, int responseCode, string responseDescription)
        {
            Thread thread = new Thread(delegate()
            {
                try
                {
                    CreatedEvent createdEvent;

                    lock (m_ven)
                    {
                        createdEvent = m_ven.createdEvent(requestID, evts, optType, responseCode, responseDescription);
                    }

                    m_callbacks.processCreatedEvent(createdEvent, m_processEvents.ActiveEvents, requestID);
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            });

            thread.Start();
        }

        /**********************************************************************************/

        public void createOptSchedule(OptSchedule optSchedule)
        {
            Thread thread = new Thread(delegate()
            {
                try
                {
                    CreateOpt createOpt;

                    lock (m_ven)
                    {
                        createOpt = m_ven.createOptSchedule(RandomHex.instance().generateRandomHex(10), optSchedule);
                    }

                    m_callbacks.processCreateOptSchedule(createOpt);
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            });

            thread.Start();
        }

        /**********************************************************************************/

        public void cancelOptSchedule(string optID)
        {
            Thread thread = new Thread(delegate()
            {
                try
                {
                    CancelOpt cancelOpt;

                    lock (m_ven)
                    {
                        cancelOpt = m_ven.createCancelOpt(RandomHex.instance().generateRandomHex(10), optID);
                    }

                    m_callbacks.processCancelOpt(cancelOpt);
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            });

            thread.Start();
        }

        /**********************************************************************************/

        public bool IsRunning
        {
            get { return m_running; }
        }

        /**********************************************************/

        public void clearEvents()
        {
            m_processEvents.clearEvents();
        }

        /**********************************************************/

        public void queryRegistration()
        {
            Thread thread = new Thread(delegate()
            {                

                try
                {
                    doQueryPartyRegistration();
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }                
            });

            thread.Start();
        }

        /**********************************************************/

        public void cancelRegistration()
        {
            Thread thread = new Thread(delegate()
            {
                try
                {                                        
                    CancelPartyRegistration cancelRegistration;

                    lock (m_ven)
                    {
                        cancelRegistration = m_ven.cancelPartyRegistration();
                    }

                    m_callbacks.processCancelRegistration(cancelRegistration);                    
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            });

            thread.Start();
        }

        /**********************************************************/

        /// <summary>
        /// force the VEN to reregister
        /// </summary>
        public void register()
        {            
            Thread thread = new Thread(delegate()
            {
                try
                {
                    lock (m_ven)
                    {
                        if (!handleRegistration(true))
                            return;

                        OadrPoll poll = doPoll();

                        // continually process messages in the remote queue until the queue
                        // is empty
                        while (!poll.responseTypeIs(typeof(oadrResponseType)))
                            poll = doPoll();
                    }
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
                finally
                {
                    updateStatus(STATUS_IDLE);
                }
            });

            thread.Start();
        }

        /**********************************************************/

        public void clearRegistration(string preallocatedVenID = "")
        {
            lock (m_ven)
            {
                m_ven.clearRegistration();

                if (preallocatedVenID != "")
                    m_ven.VENID = preallocatedVenID;
            }
        }

        /**********************************************************************************/

        private void updateReportList()
        {
            Dictionary<string, ReportWrapper> reports = m_resources.Reports;

            // HACK: this was a simple way to update the list of registered reports
            // note that the reports are not actually registered until the user clicks register reports
            // or regiters with the VTN
            RegisterReport request = new RegisterReport();

            request.createRegisterReport("requestID", "venID", reports);

            m_callbacks.processUpdateReportList(request.request);
        }

        /**********************************************************************************/

        public void addResource(resources.Resource resource)
        {
            m_resources.addResource(resource);

            updateReportList();
        }

        /**********************************************************************************/

        public void removeResource(resources.Resource resource)
        {
            m_resources.removeResource(resource.ResourceID);

            updateReportList();
        }


        /**********************************************************************************/

        public ven.resources.Resources Resources
        {
            get { return m_resources; }
        }

        /**********************************************************************************/

        public void registerReports()
        {
            Thread thread = new Thread(delegate()
            {
                try
                {
                    doRegisterReports();
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            });

            thread.Start();
        }

        /**********************************************************************************/

        public void sendMetadataReport(string reportRequestID)
        {
            Thread thread = new Thread(delegate()
            {
                try
                {
                    m_resources.handleMetadataReportReceived();

                    doRegisterReports(reportRequestID);
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            });

            thread.Start();
        }

        /**********************************************************************************/

        public void sendUpdateReport(oadrReportType report, oadrReportRequestType reportRequest)
        {
            Thread thread = new Thread(delegate()
            {
                try
                {
                    doSendUpdateReport(report, reportRequest);                    
                }
                catch (Exception ex)
                {
                    m_callbacks.processException(ex);
                }
            });

            thread.Start();
        }

        /**********************************************************************************/

        public void processCreateReportComplete(string reportRequestID)
        {
            m_callbacks.processCreateReportComplete(reportRequestID);
        }

        /**********************************************************************************/

        public void clearAllReports()
        {
            m_resources.clearReports();
        }
    }
}
