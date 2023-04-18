using Oadr.Library;
using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Ven.Resources
{
    public class ReportHandler
    {
        private readonly Dictionary<string, ReportRequestWrapper> _reportRequests = new Dictionary<string, ReportRequestWrapper>();
        
        public List<string> PendingReports
        {
            get
            {
                var pendingReports = new List<string>();
                lock (this)
                {
                    foreach (var reportRequestWrapper in _reportRequests.Values)
                    {
                        if (!reportRequestWrapper.ReportComplete)
                        {
                            pendingReports.Add(reportRequestWrapper.ReportRequestId);
                        }
                    }
                }
                return pendingReports;
            }
        }

        public bool CreateReport(oadrReportRequestType[] reportRequests, Dictionary<string, ReportWrapper> reports, Dictionary<string, Interval> intervals)
        {
            lock (this)
            {                
                foreach (var reportRequest in reportRequests)
                {
                    try
                    {
                        if (reportRequest.reportSpecifier.reportSpecifierID != "METADATA")
                        {
                            // Check that we have a report with the given reportSpecifierID.
                            if (!reports.ContainsKey(reportRequest.reportSpecifier.reportSpecifierID))
                            {
                                return false;
                            }
                            foreach (var payload in reportRequest.reportSpecifier.specifierPayload)
                            {
                                if (!intervals.ContainsKey(payload.rID))
                                {
                                    return false;
                                }
                            }
                        }
                        _reportRequests.Add(reportRequest.reportRequestID, new ReportRequestWrapper(reportRequest));
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException(ex);
                        return false;
                    }
                }
            }
            return true;
        }

        public List<string> CancelReport(oadrCancelReportType cancelReport)
        {
            List<string> pendingReports = null;
            lock (this)
            {
                foreach (var reportRequestId in cancelReport.reportRequestID)
                {
                    try
                    {
                        if (cancelReport.reportToFollow)
                        {
                            _reportRequests[reportRequestId].SetReportToFollow();
                        }
                        else
                        {
                            _reportRequests.Remove(reportRequestId);
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO: Throw key not found exceptions so the caller can report an invalid key error.
                        Logger.LogException(ex);
                    }
                }

                if (_reportRequests.Count > 0)
                {
                    pendingReports = new List<string>();
                    foreach (var reportRequestWrapper in _reportRequests.Values)
                    {
                        if (!reportRequestWrapper.ReportComplete)
                        {
                            pendingReports.Add(reportRequestWrapper.ReportRequestId);
                        }
                    }
                }
            }
            return pendingReports;
        }
        
        public void GenerateUpdateReport(Dictionary<string, Interval> intervals, Dictionary<string, ReportWrapper> reports, ISendReport sendReport)
        {
            var completedReports = new List<string>();
            lock (this)
            {
                foreach (var reportRequestWrapper in _reportRequests.Values)
                {
                    reportRequestWrapper.GenerateUpdateReport(intervals, reports, sendReport);
                    if (reportRequestWrapper.ReportComplete)
                    {
                        completedReports.Add(reportRequestWrapper.ReportRequestId);
                    }
                }
                foreach (var reportRequestId in completedReports)
                {
                    _reportRequests.Remove(reportRequestId);
                    sendReport.ProcessCreateReportComplete(reportRequestId);
                }
            }
        }

        /// <summary>
        /// When a METADATA report is received, all reports must be implicitly cancelled.
        /// Send a message to the UI to set all reports to complete.
        /// </summary>
        public void HandleMetadataReportReceived(ISendReport sendReport)
        {
            lock (this)
            {
                var completedReports = new List<string>();
                foreach (var reportRequestWrapper in _reportRequests.Values)
                {
                    if (reportRequestWrapper.ReportRequest.reportSpecifier.reportSpecifierID != "METADATA")
                    {
                        sendReport.ProcessCreateReportComplete(reportRequestWrapper.ReportRequestId);
                        completedReports.Add(reportRequestWrapper.ReportRequestId);
                    }
                }

                foreach (var reportRequestId in completedReports)
                {
                    _reportRequests.Remove(reportRequestId);
                }
            }
        }
        
        public void ClearReports()
        {
            lock (this)
            {
                _reportRequests.Clear();
            }
        }
    }
}
