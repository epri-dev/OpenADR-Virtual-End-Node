using Oadr.Library;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Reports
{
    public partial class CreateReportsControl : UserControl
    {
        private const int ReportRequestIdIndex = 0;
        private const int ReportSpecifierIdIndex = 1;
        private const int GranularityIndex = 2;
        private const int ReportBackDurationIndex = 3;
        private const int DtStartIndex = 4;
        private const int DurationIndex = 5;
        private const int StatusIndex = 6;
        private const string ReportStatusActive = "Active";
        private const string ReportStatusCancelled = "Cancelled";
        private const string ReportStatusComplete = "Complete";

        private readonly Dictionary<string, oadrReportRequestType> _reportRequests = new Dictionary<string, oadrReportRequestType>();
        private readonly Dictionary<string, ListViewItem> _listViewItems = new Dictionary<string, ListViewItem>();

        private ICreateReportControl _callbacks;

        public CreateReportsControl()
        {
            InitializeComponent();
            lstReportRequests.SelectedIndexChanged += OnReportRequestsSelectedIndexChanged;
        }
        
        public void SetCallback(ICreateReportControl createReportControl)
        {
            _callbacks = createReportControl;
        }
        
        // Must hold the lock before calling this method.
        private void DisplayReportRequest(oadrReportRequestType reportRequest)
        {
            tvReportRequestPayload.Nodes.Clear();
            foreach (var specifierPayload in reportRequest.reportSpecifier.specifierPayload)
            {
                var treeNode = new TreeNode($"RID: {specifierPayload.rID}");
                tvReportRequestPayload.Nodes.Add(treeNode);
                treeNode.Nodes.Add($"Reading Type: {specifierPayload.readingType}");
            }
        }
        
        private void OnReportRequestsSelectedIndexChanged(object sender, EventArgs e)
        {
            var mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    try
                    {
                        if (lstReportRequests.SelectedItems.Count == 0)
                        {
                            return;
                        }

                        var item = lstReportRequests.SelectedItems[0];
                        var reportRequest = _reportRequests[item.SubItems[ReportRequestIdIndex].Text];
                        DisplayReportRequest(reportRequest);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException(ex);
                    }
                }
            });
            
            Invoke(mi);
        }

        public void HandleCreateReport(oadrReportRequestType[] reportRequests)
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    var index = 0;
                    lock (this)
                    {
                        foreach (var reportRequest in reportRequests)
                        {
                            try
                            {
                                _reportRequests.Add(reportRequest.reportRequestID, reportRequest);
                            }
                            catch
                            {
                                // ignore
                            }

                            var item = new ListViewItem(reportRequest.reportRequestID);
                            for (var x = 0; x < lstReportRequests.Columns.Count - 1; x++)
                            {
                                item.SubItems.Add(string.Empty);
                            }
                            item.SubItems[ReportSpecifierIdIndex].Text = reportRequest.reportSpecifier.reportSpecifierID;
                            item.SubItems[GranularityIndex].Text = reportRequest.reportSpecifier.granularity.duration;
                            item.SubItems[ReportBackDurationIndex].Text = reportRequest.reportSpecifier.reportBackDuration.duration;
                            item.SubItems[StatusIndex].Text = ReportStatusActive;
                            if (reportRequest.reportSpecifier.reportInterval != null)
                            {
                                item.SubItems[DtStartIndex].Text = reportRequest.reportSpecifier.reportInterval.properties.dtstart.datetime.ToLocalTime().ToString(CultureInfo.InvariantCulture);
                                item.SubItems[DurationIndex].Text = reportRequest.reportSpecifier.reportInterval.properties.duration.duration;
                            }

                            _listViewItems.Add(reportRequest.reportRequestID, item);
                            lstReportRequests.Items.Insert(index, item);
                            index++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });
            
            Invoke(mi);
        }
        
        private void SetReportComplete(string reportRequestId, string status)
        {
            try
            {
                var item = _listViewItems[reportRequestId];
                // TODO: Add column to display status of report.
                item.SubItems[StatusIndex].Text = status;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
        
        public void ProcessCreateReportComplete(string reportRequestId)
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    lock (this)
                    {
                        SetReportComplete(reportRequestId, ReportStatusComplete);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });
            
            Invoke(mi);
        }
        
        public void ProcessCancelReport(oadrCancelReportType cancelReport)
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    lock (this)
                    {
                        foreach (var reportRequestId in cancelReport.reportRequestID)
                        {
                            SetReportComplete(reportRequestId, ReportStatusCancelled);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });
            
            Invoke(mi);
        }
        
        private void OnClearAllClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This action will clear all reports without notifying the VTN. Press OK to continue. Press cancel to cancel this operation.", "Clear all reports?", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
            {
                return;
            }

            lock (this)
            {
                lstReportRequests.Items.Clear();
                _reportRequests.Clear();
                _listViewItems.Clear();
                tvReportRequestPayload.Nodes.Clear();
            }
            _callbacks?.ClearAllReports();
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
