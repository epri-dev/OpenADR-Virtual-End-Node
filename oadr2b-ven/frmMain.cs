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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using oadrlib.lib.oadr2b;
using oadrlib.lib.http;
using oadrlib.lib.helper;

using System.Threading;

using System.Globalization;

using oadr2b_ven.GetUserOK;

using System.Reflection;

using oadr2b_ven.ven;

using oadr2b_ven.UserControls;
using oadr2b_ven.UserControls.QueryRegistration;
using oadr2b_ven.UserControls.OptSchedule;
using oadr2b_ven.UserControls.Events;
using oadr2b_ven.UserControls.Resources;
using oadr2b_ven.UserControls.Reports;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace oadr2b_ven
{
    public partial class frmMain : Form, IVenWrapper, IQueryRegistration, IManageOptSchedules, IEvents, IManageResources, IucCreateReport
    {
        private const string STATUS_SHUTDOWN = "Shutting down..."; 
        private const string VEN_NOT_REGISTERED = "VEN NOT Registered";
        private const string VEN_REGISTERED = "VEN IS Registered";
        
        private bool m_running = false;        

        private VenWrapper m_venWrapper;

        private ClearLog m_clearLog;

        /**********************************************************/

        public frmMain()
        {
            InitializeComponent();

            frmSplash splash = new frmSplash();

            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);

            ucEvents1.setCallbackHandler(this);

            m_clearLog = new ClearLog(this);

            tsVersion.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            ucQueryRegistration1.setCallbackHandler(this);

            ucManageOptSchedulesView1.setCreateOptScheduleCallback(this);
            oadrucManageOptSchedulesView1.setCreateOptScheduleCallback(this);

            ucResources1.setCallback(this);

            ucReportRequests.setCallback(this);

            VEN2b ven = new VEN2b(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), tbURL.TextBoxText, tbVENName.TextBoxText, 
                                  "", tbVENID.TextBoxText, new HttpSecuritySettings());

            m_venWrapper = new VenWrapper(ven, this);
            setVENParameters();

            ucResources1.addResource("resource1", "Load");
          
            ucMarketContexts.OnAddItem += new EventHandler(ucMarketContext_addItem);
            ucMarketContexts.OnRemoveItems += new EventHandler(ucMarketContext_removeItems);

            ucCustomSignals.OnAddItem += new EventHandler(ucCustomSignal_addItem);
            ucCustomSignals.OnRemoveItems += new EventHandler(ucCustomSignal_removeItems);

            ucMarketContexts.addItem("http://MarketContext1");
        }

        /**********************************************************/

        private void ucMarketContext_addItem(object sender, EventArgs e)
        {
            m_venWrapper.MarketContext.Add(ucMarketContexts.NewItem);
        }

        /**********************************************************/

        private void ucMarketContext_removeItems(object sender, EventArgs e)
        {
            foreach (string marketContext in ucMarketContexts.RemovedItems)
                m_venWrapper.MarketContext.Remove(marketContext);
        }

        /**********************************************************/

        private void ucCustomSignal_addItem(object sender, EventArgs e)
        {
            m_venWrapper.CustomSingals.Add(ucCustomSignals.NewItem);
        }

        /**********************************************************/

        private void ucCustomSignal_removeItems(object sender, EventArgs e)
        {
            foreach (string customSignal in ucCustomSignals.RemovedItems)
                m_venWrapper.CustomSingals.Remove(customSignal);
        }

        /**********************************************************/

        private void updateStatus(string status)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                tsStatus.Text = status;
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        private void updateError(OadrRequest request)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                // Date: Wed, 12 Jun 2013 20:13:51 GMT
                // DateTime t = DateTime.ParseExact(request.serverDate, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.CurrentCulture).ToLocalTime().ToString();

                // use InvariantCulture instead of CurrentCulture.  using CurrentCulture expects date to
                // be in local language (but the server is serving en-us)
                try
                {
                    string dt = DateTime.ParseExact(request.serverDate, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture).ToLocalTime().ToString();

                    tsError.Text = request.eiResponseCode.ToString() + ": " + request.eiResponseDescription;

                    string offset = (request.serverOffset > 0 ? "+" : "") + request.serverOffset.ToString();

                    tsServerTime.Text = "Server time: " + dt + " (" + offset + "s)";
                }
                catch
                {
                }

            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        private void updateError(Exception ex)
        {
            // TODO: add logging here

            MethodInvoker mi = new MethodInvoker(delegate
            {
                tsError.Text = "Exception: " + ex.Message;
                tsError.ToolTipText = "Exception: " + ex.Message;

                try
                {
                    ucLog1.addSystemMessage(ex.Message, UserControls.Log.WebLogView.eWebLogMessageStatus.ERROR);
                    oadrlib.lib.helper.Logger.logException(ex);
                }
                catch (Exception logException)
                {
                    MessageBox.Show("Error writing to log file: " + logException.Message);
                }

            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        private void updateRegistrationStatus(string message)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                tsRegistrationStatus.Text = message;
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        private void setVENParameters()
        {
            TimeSpan timeout = new TimeSpan(0, 0, tbPollInterval.ValueInt);

            eOptType optType;

            try
            {
                if (rbManual.Checked == true)
                    optType = eOptType.Manual;
                else if (rbOptIn.Checked == true)
                    optType = eOptType.OptIn;
                else
                    optType = eOptType.OptOut;

                m_venWrapper.VEN.URL = tbURL.TextBoxText;
                m_venWrapper.VEN.VENName = tbVENName.TextBoxText;

                // set the preallocated VEN ID IF the user set the value
                if (tbVENID.TextBoxText.Trim() != "")
                    m_venWrapper.VEN.VENID = tbVENID.TextBoxText;

                // m_venWrapper.VEN.SecuritySettings.UseHttps = chkUseSslTls.Checked;
                m_venWrapper.VEN.UseSSL = chkUseSslTls.Checked;

                if (m_venWrapper.VEN.UseSSL)
                {
                    if (tbClientCertificate.TextBoxText != "")
                        m_venWrapper.VEN.loadCertificateFile(tbClientCertificate.TextBoxText, tbClientCertificatePassword.TextBoxText);
                }

                m_venWrapper.optTpye = optType;

                if (chkDisableHostnameCheck.Checked)
                {
                    RemoteCertificateValidationCallback callback = delegate(
                                System.Object obj, X509Certificate certificate, X509Chain chain,
                                SslPolicyErrors errors)
                    {
                        if (errors == SslPolicyErrors.RemoteCertificateNameMismatch)
                        {
                            return (true);
                        }

                        return true;
                    };

                    m_venWrapper.VEN.setServerCertificateValidationCallback(callback);
                }
                else
                {
                    m_venWrapper.VEN.setServerCertificateValidationCallback(null);
                }
            }
            catch (Exception ex)
            {
                if (tbClientCertificate.TextBoxText != "" && tbClientCertificatePassword.TextBoxText != "")
                    MessageBox.Show("Failed to open certificate file: " + ex.Message);

                processException(ex);
            }
        }

        /**********************************************************/

        private void btnCheckPassword_Click(object sender, EventArgs e)
        {
            try
            {
                m_venWrapper.VEN.loadCertificateFile(tbClientCertificate.TextBoxText, tbClientCertificatePassword.TextBoxText);
                MessageBox.Show("Successfully opened certificate", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Failed to open certificate file: " + ex.Message, "Open Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                processException(ex);
            }
        }        

        /**********************************************************/

        private void handlePollThread()
        {
            try
            {
                if (m_venWrapper.IsRunning)
                {
                    m_venWrapper.stopPolling();

                    btnStartStop.Text = "Start Polling";

                    ucQueryRegistration1.enableQuery();

                    // updateRegistrationStatus(VEN_NOT_REGISTERED);
                }
                else
                {
                    setVENParameters();

                    if (chkUseSslTls.Checked && tbURL.TextBoxText.StartsWith("http://"))
                        updateError(new Exception("SSL/TLS is enabled but 'http:' is used in URL."));
                    else if (!chkUseSslTls.Checked && tbURL.TextBoxText.StartsWith("https://"))
                        updateError(new Exception("SSL/TLS is disabled but 'https:' is used in URL."));

                    m_venWrapper.startPolling();
                    btnStartStop.Text = "Stop Polling";

                    ucQueryRegistration1.disableQuery();
                    
                }
            }
            catch (Exception ex)
            {
                updateError(ex);
            }

        }

        /**********************************************************/

        private void frmMain_FormClosing(object sender, EventArgs e)
        {
            if (m_venWrapper.IsRunning)
            {
                updateStatus(STATUS_SHUTDOWN);
            }

            m_venWrapper.shutdown();
        }

        /**********************************************************/

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            handlePollThread();
        }

        /**********************************************************/

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abx = new AboutBox1();

            abx.ShowDialog();
        }

        /**********************************************************/
        
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            m_clearLog.getUserOK("Clear Log?", "Select OK to clear all log messages.");
        }

        /**********************************************************/

        public void clearLog()
        {
            ucLog1.clearMessages();
        }

        /**********************************************************/

        private void btnClearEvents_Click(object sender, EventArgs e)
        {
            ucEvents1.removeAllEvents();

            m_venWrapper.clearEvents();

            txtHistory.Text = "Events Cleared: " + DateTime.Now.ToLongTimeString() + "\r\n" + txtHistory.Text;
        }

        /**********************************************************/

        private void btnChooseClientCertificate_Click(object sender, EventArgs e)
        {
            DialogResult diagResult = fdClientCertFile.ShowDialog();
            if(diagResult == DialogResult.OK)
            {
                tbClientCertificate.TextBoxText = fdClientCertFile.FileName;
            }
        }

        /**********************************************************/

        private void chkUseSslTls_CheckedChanged(object sender, EventArgs e)
        {
            tbClientCertificate.Enabled = chkUseSslTls.Checked;
            tbClientCertificatePassword.Enabled = chkUseSslTls.Checked;
            btnChooseClientCertificate.Enabled = chkUseSslTls.Checked;

            // Set the URL to either be "http" or "https" depending on whether encryption is used.
            if (chkUseSslTls.Checked && tbURL.TextBoxText.StartsWith("http://"))
            {
                tbURL.TextBoxText = tbURL.TextBoxText.Replace("http://", "https://");
            }
            else if(!chkUseSslTls.Checked && tbURL.textBox1.Text.StartsWith("https://"))
            {
                tbURL.TextBoxText = tbURL.TextBoxText.Replace("https://", "http://");
            }

            setVENParameters();
        }

        /**********************************************************/
        // ven wrapper callbacks
        /**********************************************************/

        public void processException(Exception ex)
        {
            updateError(ex);
        }

        /**********************************************************/

        private void setPollInterval(oadrCreatedPartyRegistrationType createdPartyRegistration)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    tbPollInterval.TextBoxText = createdPartyRegistration.oadrRequestedOadrPollFreq.duration;
                }
                catch
                {
                }

            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        public void processCreatePartyRegisteration(CreatePartyRegistration createPartyRegistration)
        {

            ucLog1.addOadrMessage(createPartyRegistration);
            updateError(createPartyRegistration);

            ucQueryRegistration1.updateRegistrationInfo(createPartyRegistration.response);

            if (m_venWrapper.VEN.IsRegistered)
                updateRegistrationStatus(VEN_REGISTERED);

            setPollInterval(createPartyRegistration.response);
        }

        /**********************************************************/

        public void processQueryRegistration(QueryRegistration queryRegistration)
        {
            ucLog1.addOadrMessage(queryRegistration);
            updateError(queryRegistration);

            ucQueryRegistration1.updateRegistrationInfo(queryRegistration.response);

            if (m_venWrapper.VEN.IsRegistered)
                updateRegistrationStatus(VEN_REGISTERED);

            setPollInterval(queryRegistration.response);
        }

        /**********************************************************/

        public void processCancelRegistration(CancelPartyRegistration cancelRegistration)
        {
            ucLog1.addOadrMessage(cancelRegistration);
            updateError(cancelRegistration);

            // didn't receive an oadrCancledPartyRegistration response so an error must have occurred
            // and the cancel registration failed
            if (cancelRegistration.response == null)
                return;

            ucQueryRegistration1.cancelRegistration();

            if (!m_venWrapper.VEN.IsRegistered)
                updateRegistrationStatus(VEN_NOT_REGISTERED);

        }

        /**********************************************************/

        public void processCanceledRegistration(CanceledPartyRegistration canceledRegistration)
        {
            ucLog1.addOadrMessage(canceledRegistration);
            updateError(canceledRegistration);

            // didn't receive an oadrCancledPartyRegistration response so an error must have occurred
            // and the cancel registration failed
            if (canceledRegistration.response == null)
                return;

            ucQueryRegistration1.cancelRegistration();

            if (!m_venWrapper.VEN.IsRegistered)
                updateRegistrationStatus(VEN_NOT_REGISTERED);
        }

        /**********************************************************/

        public void processRequestEvent(RequestEvent requestEvent)
        {
            updateError(requestEvent);
            // ucEvents1.updateEvents(requestEvent.response);
            ucLog1.addOadrMessage(requestEvent, chkAutoScroll.Checked);
        }

        /**********************************************************/

        public void processCreatedEvent(CreatedEvent createdEvent, Dictionary<string, OadrEventWrapper> activeEvents, string requestID)
        {
            // update list of active events
            // this must be called before ucEvents1.updateOptType(createdEvent.request);
            // updateOptType will lookup event by ID and, well, update the optType
            // new events won't be in the list of updateEvents isn't called first
            ucEvents1.updateEvents(activeEvents, requestID);

            // createdEvent will be null if the VTN sent an empty distributeEvent message,
            // clearing all events for this ven
            // createdEvent is NULL because there's no response to send when distributeEvent
            // is empty
            // it can also be NULL if the message contained only updates to event status
            if (createdEvent != null)
            {
                ucLog1.addOadrMessage(createdEvent);
               
                ucEvents1.updateOptType(createdEvent.request);

                updateError(createdEvent);
            }                       
        }

        /**********************************************************/

        public void processUpdateStatus(string status, bool threadStopped)
        {
            updateStatus(status);

            MethodInvoker mi = new MethodInvoker(delegate
            {
                if (threadStopped)
                {
                    btnStartStop.Text = "Start Polling";
                    ucQueryRegistration1.enableQuery();
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        public void processPoll(OadrPoll oadrPoll)
        {
            updateError(oadrPoll);
            ucLog1.addOadrMessage(oadrPoll, chkAutoScroll.Checked);

            /*if (oadrPoll.responseTypeIs(typeof(oadrDistributeEventType)))
            {
                ucEvents1.updateEvents(oadrPoll.getDistributeEventResponse());
            }*/            
        }

        /**********************************************************/

        public void processCreateOptSchedule(CreateOpt createOpt)
        {
            updateError(createOpt);
            ucLog1.addOadrMessage(createOpt, chkAutoScroll.Checked);

            ucManageOptSchedulesView1.addOptSchedule(createOpt);
            oadrucManageOptSchedulesView1.addOptSchedule(createOpt);
        }

        /**********************************************************/

        public void processCancelOpt(CancelOpt cancelOpt)
        {
            updateError(cancelOpt);
            ucLog1.addOadrMessage(cancelOpt, chkAutoScroll.Checked);

            ucManageOptSchedulesView1.cancelOptSchedule(cancelOpt);
            oadrucManageOptSchedulesView1.cancelOptSchedule(cancelOpt);
        }

        /**********************************************************/

        public void processCreateOpt(CreateOpt createOpt)
        {
            ucLog1.addOadrMessage(createOpt);

            updateError(createOpt);

            if (createOpt.eiResponseCode == 200)
            {
                ucEvents1.updateOptType(createOpt.request);
            }
        }

        /**********************************************************/

        public void processRegisteredReport(RegisteredReport registeredReport)
        {
            updateError(registeredReport);
            ucLog1.addOadrMessage(registeredReport, chkAutoScroll.Checked);
        }

        /**********************************************************/

        public void processRegisterReport(RegisterReport registerReport)
        {
            updateError(registerReport);
            ucLog1.addOadrMessage(registerReport, chkAutoScroll.Checked);

            ucRegisteredReports1.handleRegisterReports(registerReport.request);
        }

        /**********************************************************/

        public void processUpdateReportList(oadrRegisterReportType registerReport)
        {
            ucRegisteredReports1.handleRegisterReports(registerReport);
        }

        /**********************************************************/

        public void processCreateReport(oadrReportRequestType[] reportRequests)
        {
            ucReportRequests.handleCreateReport(reportRequests);
        }

        /**********************************************************/

        public void processCreatedReport(CreatedReport createdReport)
        {
            updateError(createdReport);
            ucLog1.addOadrMessage(createdReport, chkAutoScroll.Checked);            
        }

        /**********************************************************/

        public void processUpdateReport(UpdateReport updateReport)
        {
            updateError(updateReport);
            ucLog1.addOadrMessage(updateReport, chkAutoScroll.Checked);
        }

        /**********************************************************************************/

        public void processCanceledReport(CanceledReport canceledReport, oadrCancelReportType cancelReport)
        {
            updateError(canceledReport);
            ucLog1.addOadrMessage(canceledReport, chkAutoScroll.Checked);

            ucReportRequests.processCancelReport(cancelReport);
        }

        /**********************************************************************************/

        /// <summary>
        /// called when a cancel report is piggy backed in an updated report response
        /// </summary>
        /// <param name="cancelReport"></param>
        public void processCancelReport(oadrCancelReportType cancelReport)
        {
            ucReportRequests.processCancelReport(cancelReport);
        }

        /**********************************************************************************/

        public void processCreateReportComplete(string reportRequestID)
        {
            ucReportRequests.processCreateReportComplete(reportRequestID);
        }

        /**********************************************************/

        public void updateEventStatus(List<oadrDistributeEventTypeOadrEvent> oadrEvents)
        {

            if (oadrEvents != null && oadrEvents.Count > 0)
                ucEvents1.updateEventsTimeTriggered(oadrEvents);
        }

        /**********************************************************/

        public void logSystemMessage(string message, oadr2b_ven.UserControls.Log.WebLogView.eWebLogMessageStatus status)
        {
            ucLog1.addSystemMessage(message, status);
        }

        /**********************************************************/
        // ucQueryRegistration callbacks
        /**********************************************************/

        public void processQueryRegistration()
        {
            try
            {
                setVENParameters();

                m_venWrapper.queryRegistration();
            }
            catch (Exception ex)
            {
                updateError(ex);
            }
        }

        /**********************************************************/

        public void processCancelRegistration()
        {
            try
            {
                setVENParameters();

                m_venWrapper.cancelRegistration();
            }
            catch (Exception ex)
            {
                updateError(ex);
            }
        }

        /**********************************************************/

        public void processRegister()
        {
            try
            {
                setVENParameters();

                m_venWrapper.register();
            }
            catch (Exception ex)
            {
                updateError(ex);
            }
        }

        /**********************************************************/

        public void processClearRegistration()
        {
            try
            {
                setVENParameters();

                m_venWrapper.clearRegistration(tbVENID.TextBoxText.Trim());

                updateRegistrationStatus(VEN_NOT_REGISTERED);
            }
            catch (Exception ex)
            {
                updateError(ex);
            }
        }

        /**********************************************************/
        // ucManageOptSchedules callbacks
        /**********************************************************/

        public void createOptSchedule(oadrlib.lib.oadr2b.OptSchedule optSchedule)
        {
            try
            {
                setVENParameters();

                m_venWrapper.createOptSchedule(optSchedule);
            }
            catch (Exception ex)
            {
                updateError(ex);
            }

        }

        /**********************************************************/

        public void cancelOptSchedule(string optID)
        {
            try
            {
                setVENParameters();

                m_venWrapper.cancelOptSchedule(optID);
            }
            catch (Exception ex)
            {
                updateError(ex);
            }
        }

        /**********************************************************/
        // ucManageOptSchedules callbacks
        /**********************************************************/

        public void processEventOpt(List<oadrDistributeEventTypeOadrEvent> evts, OptTypeType optType, string requestID, int responseCode, string responseDescription)
        {
            try
            {
                setVENParameters();


                m_venWrapper.updateEventOpt(evts, optType, requestID, responseCode, responseDescription);
            }
            catch (Exception ex)
            {
                updateError(ex);
            }

        }

        /**********************************************************/

        public void processCreateEventOpt(List<oadrDistributeEventTypeOadrEvent> evts, OptTypeType optType, OptReasonEnumeratedType optReason, string resourceID)
        {
            try
            {
                setVENParameters();

                m_venWrapper.updateEventOpt(evts, optType, optReason, resourceID);
            }
            catch (Exception ex)
            {
                updateError(ex);
            }
        }

        /**********************************************************/

        public void populateLists(List<string> marketContexts, List<string> resources)
        {
            foreach (string mc in m_venWrapper.MarketContext)
                marketContexts.Add(mc);

            foreach (ven.resources.Resource resource in m_venWrapper.Resources.ResourceDictionary.Values)
                resources.Add(resource.ResourceID);
        }

        /**********************************************************/
        // ucResources callbacks
        /**********************************************************/

        public void processRegisterReports()
        {
            m_venWrapper.registerReports();
        }

        /**********************************************************/

        public void addResource(ven.resources.Resource resource)
        {
            m_venWrapper.addResource(resource);
        }

        /**********************************************************/

        public void removeResource(ven.resources.Resource resource)
        {
            m_venWrapper.removeResource(resource);
        }

        /**********************************************************/
        // ucCreateReport callbacks
        /**********************************************************/

        public void clearAllReports()
        {
            m_venWrapper.clearAllReports();
        }

        private void ucLog1_Load(object sender, EventArgs e)
        {

        }
    }
}
