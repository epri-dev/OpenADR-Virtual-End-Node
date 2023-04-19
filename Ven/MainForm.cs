using Oadr.Library;
using Oadr.Library.Http;
using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using Oadr.Ven.Helpers;
using Oadr.Ven.Resources;
using Oadr.Ven.UserControls;
using Oadr.Ven.UserControls.Events;
using Oadr.Ven.UserControls.OptSchedule;
using Oadr.Ven.UserControls.QueryRegistration;
using Oadr.Ven.UserControls.Reports;
using Oadr.Ven.UserControls.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Oadr.Ven.Contracts;

namespace Oadr.Ven
{
    public partial class MainForm : System.Windows.Forms.Form, IVenWrapper, IQueryRegistration, IManageOptSchedules, IEvents, IManageResources, ICreateReportControl
    {
        private const string StatusShutdown = "Shutting down..."; 
        private const string VenNotRegistered = "VEN NOT Registered";
        private const string VenRegistered = "VEN IS Registered";

        private readonly VenWrapper _venWrapper;
        private readonly ClearLog _clearLog;

        public MainForm()
        {
            InitializeComponent();
            
            FormClosing += OnMainFormClosing;
            ucEvents.SetCallbackHandler(this);

            _clearLog = new ClearLog(this);
            tsVersion.Text = $"Version: {Assembly.GetExecutingAssembly().GetName().Version}";

            ucQueryRegistration.SetCallbackHandler(this);
            ucManageOptSchedulesView1.SetCreateOptScheduleCallback(this);
            oadrucManageOptSchedulesView1.SetCreateOptScheduleCallback(this);
            ucResources.SetCallback(this);
            ucReportRequests.SetCallback(this);

            var ven = new Ven2B(
                new HttpService(false, System.Net.SecurityProtocolType.Tls12),
                txtUrl.TextBoxText,
                txtVenName.TextBoxText,
                string.Empty,
                txtVenId.TextBoxText);
            _venWrapper = new VenWrapper(ven, this);
            SetVenParameters();

            ucResources.AddResource("resource1", "Load");
            ucMarketContexts.OnAddItem += OnMarketContextAddItem;
            ucMarketContexts.OnRemoveItems += OnMarketContextRemoveItems;
            ucCustomSignals.OnAddItem += OnCustomSignalAddItem;
            ucCustomSignals.OnRemoveItems += OnCustomSignalRemoveItems;
            ucMarketContexts.AddItem("http://MarketContext1");
        }

        private void OnMarketContextAddItem(object sender, EventArgs e)
        {
            _venWrapper.MarketContext.Add(ucMarketContexts.NewItem);
        }

        private void OnMarketContextRemoveItems(object sender, EventArgs e)
        {
            foreach (var marketContext in ucMarketContexts.RemovedItems)
            {
                _venWrapper.MarketContext.Remove(marketContext);
            }
        }

        private void OnCustomSignalAddItem(object sender, EventArgs e)
        {
            _venWrapper.CustomSignals.Add(ucCustomSignals.NewItem);
        }

        private void OnCustomSignalRemoveItems(object sender, EventArgs e)
        {
            foreach (var customSignal in ucCustomSignals.RemovedItems)
            {
                _venWrapper.CustomSignals.Remove(customSignal);
            }
        }

        private void UpdateStatus(string status)
        {
            var mi = new MethodInvoker(delegate
            {
                tsStatus.Text = status;
            });
            
            Invoke(mi);
        }

        private void UpdateError(OadrRequest request)
        {
            var mi = new MethodInvoker(delegate
            {
                // Use InvariantCulture instead of CurrentCulture.
                // Using CurrentCulture expects date to be in local language (but the server is serving en-us).
                try
                {
                    var dt = DateTime.ParseExact(request.ServerDate, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture).ToLocalTime().ToString(CultureInfo.InvariantCulture);
                    tsError.Text = $"{request.EiResponseCode}: {request.EiResponseDescription}";

                    var offset = (request.ServerOffset > 0 ? "+" : string.Empty) + request.ServerOffset.ToString();
                    tsServerTime.Text = $"Server time: {dt} ({offset}s)";
                }
                catch
                {
                    // ignore
                }

            });
            
            Invoke(mi);
        }

        private void UpdateError(Exception ex)
        {
            var mi = new MethodInvoker(delegate
            {
                tsError.Text = $"Exception: {ex.Message}";
                tsError.ToolTipText = $"Exception: {ex.Message}";
                try
                {
                    ucLog.AddSystemMessage(ex.Message, LogMessageStatus.Error);
                    Logger.LogException(ex);
                }
                catch (Exception logException)
                {
                    MessageBox.Show($"Error writing to log file: {logException.Message}");
                }
            });
            
            Invoke(mi);
        }

        private void UpdateRegistrationStatus(string message)
        {
            var mi = new MethodInvoker(delegate
            {
                tsRegistrationStatus.Text = message;
            });
            
            Invoke(mi);
        }

        private void SetVenParameters()
        {
            try
            {
                EOptType optType;
                if (rbManual.Checked)
                {
                    optType = EOptType.Manual;
                }
                else if (rbOptIn.Checked)
                {
                    optType = EOptType.OptIn;
                }
                else
                {
                    optType = EOptType.OptOut;
                }

                _venWrapper.Ven.Url = txtUrl.TextBoxText;
                _venWrapper.Ven.VenName = txtVenName.TextBoxText;

                // Set the pre-allocated VEN ID if the user set the value.
                if (txtVenId.TextBoxText.Trim() != string.Empty)
                {
                    _venWrapper.Ven.VenId = txtVenId.TextBoxText;
                }
                _venWrapper.Ven.UseSsl = chkUseSslTls.Checked;
                if (_venWrapper.Ven.UseSsl)
                {
                    if (tbClientCertificate.TextBoxText != string.Empty)
                    {
                        _venWrapper.Ven.LoadCertificateFile(tbClientCertificate.TextBoxText, tbClientCertificatePassword.TextBoxText);
                    }
                    _venWrapper.Ven.SignXml = cbSignXml.Checked;
                }
                _venWrapper.OptType = optType;
                if (chkDisableHostnameCheck.Checked)
                {
                    bool CertificateValidationCallback(object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                    {
                        return true;
                    }
                    _venWrapper.Ven.SetServerCertificateValidationCallback(CertificateValidationCallback);
                }
                else
                {
                    _venWrapper.Ven.SetServerCertificateValidationCallback(null);
                }
            }
            catch (Exception ex)
            {
                if (tbClientCertificate.TextBoxText != string.Empty &&
                    tbClientCertificatePassword.TextBoxText != string.Empty)
                {
                    MessageBox.Show($"Failed to open certificate file: {ex.Message}");
                }
                ProcessException(ex);
            }
        }

        private void OnCheckPasswordClick(object sender, EventArgs e)
        {
            try
            {
                _venWrapper.Ven.LoadCertificateFile(tbClientCertificate.TextBoxText, tbClientCertificatePassword.TextBoxText);
                MessageBox.Show("Successfully opened certificate", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {                
                MessageBox.Show($"Failed to open certificate file: {ex.Message}", "Open Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProcessException(ex);
            }
        }        

        private void HandlePollThread()
        {
            try
            {
                if (_venWrapper.IsRunning)
                {
                    _venWrapper.StopPolling();
                    btnStartStop.Text = "Start Polling";
                }
                else
                {
                    SetVenParameters();
                    if (chkUseSslTls.Checked && txtUrl.TextBoxText.StartsWith("http://"))
                    {
                        UpdateError(new Exception("SSL/TLS is enabled but 'http:' is used in URL."));
                    }
                    else if (!chkUseSslTls.Checked && txtUrl.TextBoxText.StartsWith("https://"))
                    {
                        UpdateError(new Exception("SSL/TLS is disabled but 'https:' is used in URL."));
                    }

                    _venWrapper.StartPolling();
                    btnStartStop.Text = "Stop Polling";
                }
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }

        public void ClearLog()
        {
            ucLog.ClearMessages();
        }

        private void OnMainFormClosing(object sender, EventArgs e)
        {
            if (_venWrapper.IsRunning)
            {
                UpdateStatus(StatusShutdown);
            }
            _venWrapper.Shutdown();
        }

        private void OnStartStopButtonClick(object sender, EventArgs e)
        {
            HandlePollThread();
        }

        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            var abx = new AboutBoxForm();
            abx.ShowDialog();
        }

        private void OnClearLogButtonClick(object sender, EventArgs e)
        {
            _clearLog.GetResponse("Clear Log?", "Select OK to clear all log messages.");
        }

        private void OnClearEventsButtonClick(object sender, EventArgs e)
        {
            ucEvents.RemoveAllEvents();
            _venWrapper.ClearEvents();
            txtHistory.Text = $"Events Cleared: {DateTime.Now.ToLongTimeString()}\r\n{txtHistory.Text}";
        }

        private void OnChooseClientCertificateButtonClick(object sender, EventArgs e)
        {
            var result = fdClientCertFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbClientCertificate.TextBoxText = fdClientCertFile.FileName;
            }
        }

        private void OnUseSslTlsCheckedChanged(object sender, EventArgs e)
        {
            tbClientCertificate.Enabled = chkUseSslTls.Checked;
            tbClientCertificatePassword.Enabled = chkUseSslTls.Checked;
            btnChooseClientCertificate.Enabled = chkUseSslTls.Checked;
            cbSignXml.Enabled = chkUseSslTls.Checked;
            cbSignXml.Checked = chkUseSslTls.Checked;

            // Set the URL to either be "http" or "https" depending on whether encryption is used.
            if (chkUseSslTls.Checked && txtUrl.TextBoxText.StartsWith("http://"))
            {
                txtUrl.TextBoxText = txtUrl.TextBoxText.Replace("http://", "https://");
            }
            else if(!chkUseSslTls.Checked && txtUrl.txtInput.Text.StartsWith("https://"))
            {
                txtUrl.TextBoxText = txtUrl.TextBoxText.Replace("https://", "http://");
            }
            SetVenParameters();
        }

        private void OnSignXmlCheckedChanged(object sender, EventArgs e)
        {
            SetVenParameters();
        }
        
        public void ProcessException(Exception ex)
        {
            UpdateError(ex);
        }
        
        private void SetPollInterval(oadrCreatedPartyRegistrationType createdPartyRegistration)
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    tbPollInterval.TextBoxText = createdPartyRegistration.oadrRequestedOadrPollFreq.duration;
                }
                catch
                {
                    // ignore
                }
            });
            
            Invoke(mi);
        }

        public void ProcessCreatePartyRegistration(CreatePartyRegistration createPartyRegistration)
        {
            ucLog.AddOadrMessage(createPartyRegistration);
            UpdateError(createPartyRegistration);

            ucQueryRegistration.UpdateRegistrationInfo(createPartyRegistration.Response);
            if (_venWrapper.Ven.IsRegistered)
            {
                UpdateRegistrationStatus(VenRegistered);
            }
            SetPollInterval(createPartyRegistration.Response);
        }

        public void ProcessQueryRegistration(QueryRegistration queryRegistration)
        {
            ucLog.AddOadrMessage(queryRegistration);
            UpdateError(queryRegistration);

            ucQueryRegistration.UpdateRegistrationInfo(queryRegistration.Response);
            if (_venWrapper.Ven.IsRegistered)
            {
                UpdateRegistrationStatus(VenRegistered);
            }
            SetPollInterval(queryRegistration.Response);
        }

        public void ProcessCancelRegistration(CancelPartyRegistration cancelRegistration)
        {
            ucLog.AddOadrMessage(cancelRegistration);
            UpdateError(cancelRegistration);

            // Didn't receive an oadrCanceledPartyRegistration response so an error must have occurred and the cancel registration failed.
            if (cancelRegistration.Response == null)
            {
                return;
            }
            ucQueryRegistration.CancelRegistration();
            if (!_venWrapper.Ven.IsRegistered)
            {
                UpdateRegistrationStatus(VenNotRegistered);
            }
        }

        public void ProcessCanceledRegistration(CanceledPartyRegistration canceledRegistration)
        {
            ucLog.AddOadrMessage(canceledRegistration);
            UpdateError(canceledRegistration);

            // Didn't receive an oadrCanceledPartyRegistration response so an error must have occurred and the cancel registration failed.
            if (canceledRegistration.Response == null)
            {
                return;
            }
            ucQueryRegistration.CancelRegistration();
            if (!_venWrapper.Ven.IsRegistered)
            {
                UpdateRegistrationStatus(VenNotRegistered);
            }
        }

        public void ProcessRequestEvent(RequestEvent requestEvent)
        {
            UpdateError(requestEvent);
            ucLog.AddOadrMessage(requestEvent, chkAutoScroll.Checked);
        }

        public void ProcessCreatedEvent(CreatedEvent createdEvent, Dictionary<string, OadrEventWrapper> activeEvents, string requestId)
        {
            // Update list of active events.
            // This must be called before ucEvents.UpdateOptType(createdEvent.request);
            // updateOptType will lookup event by ID and, well, update the optType.
            // New events won't be in the list of updateEvents if it isn't called first.
            ucEvents.UpdateEvents(activeEvents, requestId);

            // createdEvent will be null if the VTN sent an empty distributeEvent message,
            // Clearing all events for this ven.
            // createdEvent is NULL because there's no response to send when distributeEvent is empty.
            // It can also be NULL if the message contained only updates to event status.
            if (createdEvent != null)
            {
                ucLog.AddOadrMessage(createdEvent);
                ucEvents.UpdateOptType(createdEvent.Request);
                UpdateError(createdEvent);
            }                       
        }

        public void ProcessUpdateStatus(string status, bool threadStopped)
        {
            UpdateStatus(status);
            var mi = new MethodInvoker(delegate
            {
                if (threadStopped)
                {
                    btnStartStop.Text = "Start Polling";
                }
            });
            
            Invoke(mi);
        }

        public void ProcessPoll(OadrPoll oadrPoll)
        {
            UpdateError(oadrPoll);
            ucLog.AddOadrMessage(oadrPoll, chkAutoScroll.Checked);
        }

        public void ProcessCreateOptSchedule(CreateOpt createOpt)
        {
            UpdateError(createOpt);
            ucLog.AddOadrMessage(createOpt, chkAutoScroll.Checked);

            ucManageOptSchedulesView1.AddOptSchedule(createOpt);
            oadrucManageOptSchedulesView1.AddOptSchedule(createOpt);
        }

        public void ProcessCancelOpt(CancelOpt cancelOpt)
        {
            UpdateError(cancelOpt);
            ucLog.AddOadrMessage(cancelOpt, chkAutoScroll.Checked);

            ucManageOptSchedulesView1.CancelOptSchedule(cancelOpt);
            oadrucManageOptSchedulesView1.CancelOptSchedule(cancelOpt);
        }

        public void ProcessCreateOpt(CreateOpt createOpt)
        {
            ucLog.AddOadrMessage(createOpt);
            UpdateError(createOpt);

            if (createOpt.EiResponseCode == 200)
            {
                ucEvents.UpdateOptType(createOpt.Request);
            }
        }

        public void ProcessRegisteredReport(RegisteredReport registeredReport)
        {
            UpdateError(registeredReport);
            ucLog.AddOadrMessage(registeredReport, chkAutoScroll.Checked);
        }

        public void ProcessRegisterReport(RegisterReport registerReport)
        {
            UpdateError(registerReport);
            ucLog.AddOadrMessage(registerReport, chkAutoScroll.Checked);

            ucRegisteredReports.HandleRegisterReports(registerReport.Request);
        }

        public void ProcessUpdateReportList(oadrRegisterReportType registerReport)
        {
            ucRegisteredReports.HandleRegisterReports(registerReport);
        }

        public void ProcessCreateReport(oadrReportRequestType[] reportRequests)
        {
            ucReportRequests.HandleCreateReport(reportRequests);
        }

        public void ProcessCreatedReport(CreatedReport createdReport)
        {
            UpdateError(createdReport);
            ucLog.AddOadrMessage(createdReport, chkAutoScroll.Checked);            
        }

        public void ProcessUpdateReport(UpdateReport updateReport)
        {
            UpdateError(updateReport);
            ucLog.AddOadrMessage(updateReport, chkAutoScroll.Checked);
        }

        public void ProcessCanceledReport(CanceledReport canceledReport, oadrCancelReportType cancelReport)
        {
            UpdateError(canceledReport);
            ucLog.AddOadrMessage(canceledReport, chkAutoScroll.Checked);

            ucReportRequests.ProcessCancelReport(cancelReport);
        }

        /// <summary>
        /// Called when a cancel report is piggy backed in an updated report response.
        /// </summary>
        public void ProcessCancelReport(oadrCancelReportType cancelReport)
        {
            ucReportRequests.ProcessCancelReport(cancelReport);
        }

        public void ProcessCreateReportComplete(string reportRequestId)
        {
            ucReportRequests.ProcessCreateReportComplete(reportRequestId);
        }

        public void UpdateEventStatus(List<oadrDistributeEventTypeOadrEvent> oadrEvents)
        {
            if (oadrEvents != null && oadrEvents.Count > 0)
            {
                ucEvents.UpdateEventsTimeTriggered(oadrEvents);
            }
        }

        public void LogSystemMessage(string message, LogMessageStatus status)
        {
            ucLog.AddSystemMessage(message, status);
        }

        public void ProcessQueryRegistration()
        {
            try
            {
                SetVenParameters();
                _venWrapper.QueryRegistration();
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }

        public void ProcessCancelRegistration()
        {
            try
            {
                SetVenParameters();
                _venWrapper.CancelRegistration();
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }

        public void ProcessRegister()
        {
            try
            {
                SetVenParameters();
                _venWrapper.Register();
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }

        public void ProcessClearRegistration()
        {
            try
            {
                SetVenParameters();
                _venWrapper.ClearRegistration(txtVenId.TextBoxText.Trim());
                UpdateRegistrationStatus(VenNotRegistered);
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }
        
        public void CreateOptSchedule(OptSchedule optSchedule)
        {
            try
            {
                SetVenParameters();
                _venWrapper.CreateOptSchedule(optSchedule);
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }

        public void CancelOptSchedule(string optId)
        {
            try
            {
                SetVenParameters();
                _venWrapper.CancelOptSchedule(optId);
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }
        
        public void ProcessEventOpt(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType, string requestId, int responseCode, string responseDescription)
        {
            try
            {
                SetVenParameters();
                _venWrapper.UpdateEventOpt(events, optType, requestId, responseCode, responseDescription);
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }

        public void ProcessCreateEventOpt(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType, OptReasonEnumeratedType optReason, string resourceId)
        {
            try
            {
                SetVenParameters();
                _venWrapper.UpdateEventOpt(events, optType, optReason, resourceId);
            }
            catch (Exception ex)
            {
                UpdateError(ex);
            }
        }

        public void PopulateLists(List<string> marketContexts, List<string> resources)
        {
            foreach (var mc in _venWrapper.MarketContext)
            {
                marketContexts.Add(mc);
            }

            foreach (var resource in _venWrapper.Resources.ResourceDictionary.Values)
            {
                resources.Add(resource.ResourceId);
            }
        }

        public void ProcessRegisterReports()
        {
            _venWrapper.RegisterReports();
        }

        public void AddResource(Resource resource)
        {
            _venWrapper.AddResource(resource);
        }

        public void RemoveResource(Resource resource)
        {
            _venWrapper.RemoveResource(resource);
        }
        
        public void ClearAllReports()
        {
            _venWrapper.ClearAllReports();
        }

        private void Invoke(MethodInvoker mi)
        {
            // BeginInvoke only needs to be called if we're trying to update the UI from a thread that did not create it.
            if (InvokeRequired)
            {
                BeginInvoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }
    }
}
