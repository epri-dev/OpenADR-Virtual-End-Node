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
    public partial class ucRegisteredReports : UserControl
    {
        private Dictionary<string, oadrReportType> m_registeredReports = new Dictionary<string,oadrReportType>();

        private int IND_REPORT_SPECIFIER_ID = 0;
        private int IND_REPORT_NAME = 1;

        /**********************************************************/

        public ucRegisteredReports()
        {
            InitializeComponent();

            lstRegisteredRequests.SelectedIndexChanged += lstRegisteredRequests_SelectedIndexChanged;
        }

        /******************************************************************************/

        // must hold the lock before calling this function
        private void displayRegisterdReport(oadrReportType reportType)
        {
                tvReportRequestPayload.Nodes.Clear();

                foreach (oadrReportDescriptionType reportDescription in reportType.oadrReportDescription)
                {
                    TreeNode treeNode = new TreeNode("RID: " + reportDescription.rID);
                    tvReportRequestPayload.Nodes.Add(treeNode);

                    if (reportDescription.marketContext != null)
                        treeNode.Nodes.Add("Market Context: " + reportDescription.marketContext);

                    if (reportDescription.itemBase != null)
                        treeNode.Nodes.Add("Type: " + reportDescription.itemBase.ToString());

                    treeNode.Nodes.Add("Reading Type: " + reportDescription.readingType.ToString());

                    treeNode.Nodes.Add("Report Type: " + reportDescription.reportType.ToString());

                    if (reportDescription.oadrSamplingRate != null)
                    {
                        TreeNode samplingNode = new TreeNode("Sampling rate");
                        treeNode.Nodes.Add(samplingNode);

                        samplingNode.Nodes.Add("Min Period: " + reportDescription.oadrSamplingRate.oadrMinPeriod);
                        samplingNode.Nodes.Add("Max Period: " + reportDescription.oadrSamplingRate.oadrMaxPeriod);
                        samplingNode.Nodes.Add("On Change: " + reportDescription.oadrSamplingRate.oadrOnChange.ToString());
                    }
                }

                /*foreach (SpecifierPayloadType specifierPayload in reportRequest.reportSpecifier.specifierPayload)
                {
                    TreeNode treeNode = new TreeNode("RID: " + specifierPayload.rID);
                    tvReportRequestPayload.Nodes.Add(treeNode);

                    treeNode.Nodes.Add("Reading Type: " + specifierPayload.readingType);
                }*/
        }

        /**********************************************************/

        private void lstRegisteredRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {

                lock (this)
                {
                    try
                    {
                        if (lstRegisteredRequests.SelectedItems.Count == 0)
                            return;

                        ListViewItem lvi = lstRegisteredRequests.SelectedItems[0];

                        oadrReportType reportType = m_registeredReports[lvi.SubItems[IND_REPORT_SPECIFIER_ID].Text];

                        displayRegisterdReport(reportType);
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

        public void handleRegisterReports(oadrRegisterReportType registerReport)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    m_registeredReports.Clear();

                    lstRegisteredRequests.Items.Clear();
                    int index = 0;
                   
                    foreach (oadrReportType oadrReport in registerReport.oadrReport)
                    {
                        m_registeredReports.Add(oadrReport.reportSpecifierID, oadrReport);


                        ListViewItem lvi = new ListViewItem(oadrReport.reportSpecifierID);

                        for (int x = 0; x < lstRegisteredRequests.Columns.Count - 1; x++)
                            lvi.SubItems.Add("");

                        lvi.SubItems[IND_REPORT_NAME].Text = oadrReport.reportName;
                        
                        lstRegisteredRequests.Items.Insert(index, lvi);

                        index++;
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
    }
}
