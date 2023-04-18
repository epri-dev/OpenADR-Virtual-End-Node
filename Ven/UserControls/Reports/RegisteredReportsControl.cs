using Oadr.Library;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Reports
{
    public partial class RegisteredReportsControl : UserControl
    {
        private const int ReportSpecifierIdIndex = 0;
        private const int ReportNameIndex = 1;

        private readonly Dictionary<string, oadrReportType> _registeredReports = new Dictionary<string, oadrReportType>();

        public RegisteredReportsControl()
        {
            InitializeComponent();
            lstRegisteredRequests.SelectedIndexChanged += OnRegisteredRequestsSelectedIndexChanged;
        }

        // Must hold the lock before calling this function.
        private void DisplayRegisteredReport(oadrReportType reportType)
        {
            tvReportRequestPayload.Nodes.Clear();
            foreach (var reportDescription in reportType.oadrReportDescription)
            {
                var treeNode = new TreeNode($"RID: {reportDescription.rID}");
                tvReportRequestPayload.Nodes.Add(treeNode);

                if (reportDescription.marketContext != null)
                {
                    treeNode.Nodes.Add($"Market Context: {reportDescription.marketContext}");
                }
                if (reportDescription.itemBase != null)
                {
                    treeNode.Nodes.Add($"Type: {reportDescription.itemBase}");
                }
                treeNode.Nodes.Add($"Reading Type: {reportDescription.readingType}");
                treeNode.Nodes.Add($"Report Type: {reportDescription.reportType}");
                if (reportDescription.oadrSamplingRate != null)
                {
                    var samplingNode = new TreeNode("Sampling rate");
                    treeNode.Nodes.Add(samplingNode);
                    samplingNode.Nodes.Add($"Min Period: {reportDescription.oadrSamplingRate.oadrMinPeriod}");
                    samplingNode.Nodes.Add($"Max Period: {reportDescription.oadrSamplingRate.oadrMaxPeriod}");
                    samplingNode.Nodes.Add($"On Change: {reportDescription.oadrSamplingRate.oadrOnChange}");
                }
            }
        }
        
        private void OnRegisteredRequestsSelectedIndexChanged(object sender, EventArgs e)
        {
            var mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    try
                    {
                        if (lstRegisteredRequests.SelectedItems.Count == 0)
                        {
                            return;
                        }

                        var item = lstRegisteredRequests.SelectedItems[0];
                        var reportType = _registeredReports[item.SubItems[ReportSpecifierIdIndex].Text];
                        DisplayRegisteredReport(reportType);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException(ex);
                    }

                }
            });

            Invoke(mi);
        }

        public void HandleRegisterReports(oadrRegisterReportType registerReport)
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    _registeredReports.Clear();
                    lstRegisteredRequests.Items.Clear();

                    var index = 0;
                    foreach (var oadrReport in registerReport.oadrReport)
                    {
                        _registeredReports.Add(oadrReport.reportSpecifierID, oadrReport);

                        var item = new ListViewItem(oadrReport.reportSpecifierID);
                        for (var x = 0; x < lstRegisteredRequests.Columns.Count - 1; x++)
                        {
                            item.SubItems.Add(string.Empty);
                        }
                        item.SubItems[ReportNameIndex].Text = oadrReport.reportName;
                        lstRegisteredRequests.Items.Insert(index, item);
                        index++;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });

            Invoke(mi);
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
