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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using oadrlib.lib.oadr2b;

using oadrlib.lib.helper;

namespace oadr2b_ven.UserControls.Reports
{
    public partial class ucCreateReports : UserControl
    {
        /**********************************************************/

        private int IND_REPORT_REQUEST_ID = 0;
        private int IND_REPORT_SPECIFIER_ID = 1;
        private int IND_GRANULARITY = 2;
        private int IND_REPORTBACK_DURATION = 3;
        private int IND_DTSTART = 4;
        private int IND_DURATION = 5;
        private int IND_STATUS = 6;

        private static string REPORT_STATUS_ACTIVE = "Active";
        private static string REPORT_STATUS_CANCELLED = "Cancelled";
        private static string REPORT_STATUS_COMPLETE = "Complete";

        private Dictionary<string, oadrReportRequestType> m_reportRequests = new Dictionary<string, oadrReportRequestType>();
        private Dictionary<string, ListViewItem> m_listViewItems = new Dictionary<string, ListViewItem>();

        IucCreateReport m_callbacks;

        /**********************************************************/

        public ucCreateReports()
        {
            InitializeComponent();

            lstReportRequests.SelectedIndexChanged += lstReportRequests_SelectedIndexChanged;
        }

        /******************************************************************************/

        public void setCallback(IucCreateReport createReport)
        {
            m_callbacks = createReport;
        }

        /******************************************************************************/

        // must hold the lock before calling this function
        private void displayReportRequest(oadrReportRequestType reportRequest)
        {
            tvReportRequestPayload.Nodes.Clear();

            foreach (SpecifierPayloadType specifierPayload in reportRequest.reportSpecifier.specifierPayload)
            {
                TreeNode treeNode = new TreeNode("RID: " + specifierPayload.rID);
                tvReportRequestPayload.Nodes.Add(treeNode);

                treeNode.Nodes.Add("Reading Type: " + specifierPayload.readingType);
            }
        }

        /**********************************************************/

        private void lstReportRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    try
                    {
                        if (lstReportRequests.SelectedItems.Count == 0)
                            return;

                        ListViewItem lvi = lstReportRequests.SelectedItems[0];

                        oadrReportRequestType reportRequest = m_reportRequests[lvi.SubItems[IND_REPORT_REQUEST_ID].Text];

                        displayReportRequest(reportRequest);
                    }
                    catch (Exception ex)
                    {
                        Logger.logException(ex);
                    }
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

        public void handleCreateReport(oadrReportRequestType[] reportRequests)
        {

            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    int index = 0;

                    lock (this)
                    {
                        foreach (oadrReportRequestType reportRequest in reportRequests)
                        {
                            try
                            {
                                m_reportRequests.Add(reportRequest.reportRequestID, reportRequest);
                            }
                            catch { }

                            ListViewItem lvi = new ListViewItem(reportRequest.reportRequestID);

                            for (int x = 0; x < lstReportRequests.Columns.Count - 1; x++)
                                lvi.SubItems.Add("");

                            lvi.SubItems[IND_REPORT_SPECIFIER_ID].Text = reportRequest.reportSpecifier.reportSpecifierID;
                            lvi.SubItems[IND_GRANULARITY].Text = reportRequest.reportSpecifier.granularity.duration;
                            lvi.SubItems[IND_REPORTBACK_DURATION].Text = reportRequest.reportSpecifier.reportBackDuration.duration;

                            lvi.SubItems[IND_STATUS].Text = REPORT_STATUS_ACTIVE;

                            if (reportRequest.reportSpecifier.reportInterval != null)
                            {
                                lvi.SubItems[IND_DTSTART].Text = reportRequest.reportSpecifier.reportInterval.properties.dtstart.datetime.ToLocalTime().ToString();
                                lvi.SubItems[IND_DURATION].Text = reportRequest.reportSpecifier.reportInterval.properties.duration.duration;
                            }

                            m_listViewItems.Add(reportRequest.reportRequestID, lvi);

                            lstReportRequests.Items.Insert(index, lvi);

                            index++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.logException(ex);
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

        private void setReportComplete(string reportRequestID, string status)
        {
            try
            {
                ListViewItem lvi = m_listViewItems[reportRequestID];

                // TODO: add column to display status of report
                lvi.SubItems[IND_STATUS].Text = status;
            }
            catch (Exception ex)
            {
                Logger.logException(ex);
            }
        }

        /**********************************************************/

        public void processCreateReportComplete(string reportRequestID)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    lock (this)
                    {
                        setReportComplete(reportRequestID, REPORT_STATUS_COMPLETE);
                    }
                }
                catch (Exception ex)
                {
                    Logger.logException(ex);
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

        public void processCancelReport(oadrCancelReportType cancelReport)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    lock (this)
                    {
                        foreach (string reportRequestID in cancelReport.reportRequestID)
                            setReportComplete(reportRequestID, REPORT_STATUS_CANCELLED);
                    }
                }
                catch (Exception ex)
                {
                    Logger.logException(ex);
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

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action will clear all reports without notifying the VTN.  Press OK to continue.  Press cancel to cancel this operation.", "Clear all reports?", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            lock (this)
            {
                lstReportRequests.Items.Clear();

                m_reportRequests.Clear();
                m_listViewItems.Clear();

                tvReportRequestPayload.Nodes.Clear();
            }

            if (m_callbacks != null)
                m_callbacks.clearAllReports();
        }
    }
}
