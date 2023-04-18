using Oadr.Library;
using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;

namespace Oadr.Ven.Resources
{
    public class Resources
    {
        private readonly Dictionary<string, Resource> _idToResource = new Dictionary<string, Resource>();
        private readonly ReportHandler _reportHandler = new ReportHandler();

        private Thread _thread;
        private bool _running;
        private ISendReport _callbacks;

        public Dictionary<string, Resource> ResourceDictionary => _idToResource;

        public List<string> PendingReports => _reportHandler.PendingReports;

        public Dictionary<string, Interval> Intervals { get; } = new Dictionary<string, Interval>();

        public string TelemetryStatusReportSpecifierId { get; }

        public string TelemetryUsageReportSpecifierId { get; }

        public string HistoryUsageReportSpecifierId { get; }

        [XmlIgnore]
        public Dictionary<string, ReportWrapper> Reports { get; } = new Dictionary<string, ReportWrapper>();

        public Resources()
        {
            TelemetryStatusReportSpecifierId = "789ed6cd4e_telemetry_status";
            TelemetryUsageReportSpecifierId = "789ed6cd4e_telemetry_usage";
            HistoryUsageReportSpecifierId = "789ed6cd4e_history_usage";

            Reports.Add(TelemetryStatusReportSpecifierId, new ReportWrapper(TelemetryStatusReportSpecifierId, ReportName.TelemetryStatus, 2, DurationModifier.Hours));
            Reports.Add(TelemetryUsageReportSpecifierId, new ReportWrapper(TelemetryUsageReportSpecifierId, ReportName.TelemetryUsage, 2, DurationModifier.Hours));
            Reports.Add(HistoryUsageReportSpecifierId, new ReportWrapper(HistoryUsageReportSpecifierId, ReportName.HistoryUsage, 2, DurationModifier.Hours));
        }

        public void AddResource(Resource resource)
        {
            lock (this)
            {
                _idToResource.Add(resource.ResourceId, resource);
                resource.AddReportDescriptions(Reports, TelemetryStatusReportSpecifierId, TelemetryUsageReportSpecifierId, HistoryUsageReportSpecifierId, Intervals);
            }
        }

        public void RemoveResource(string resourceId)
        {
            lock (this)
            {
                var resource = _idToResource[resourceId];
                _idToResource.Remove(resourceId);
                resource.RemoveReportDescriptions(Reports, TelemetryStatusReportSpecifierId, TelemetryUsageReportSpecifierId, HistoryUsageReportSpecifierId, Intervals);
            }
        }

        public void SetCallback(ISendReport sendReport)
        {
            _callbacks = sendReport;
        }

        public bool CreateReport(oadrCreateReportType createReport)
        {
            return _reportHandler.CreateReport(createReport.oadrReportRequest, Reports, Intervals);
        }

        public void CreateReport(oadrReportRequestType[] reportRequests)
        {
            _reportHandler.CreateReport(reportRequests, Reports, Intervals);
        }

        public void CancelReport(oadrCancelReportType cancelReport)
        {
            lock (this)
            {
                _reportHandler.CancelReport(cancelReport);
            }
        }
        
        private void CaptureIntervals(DateTime now)
        {
            foreach (var resource in _idToResource.Values)
            {
                resource.CaptureIntervals(now);
            }
        }
        
        public void SendReports(DateTime now)
        {
            lock (this)
            {
                _reportHandler.GenerateUpdateReport(Intervals, Reports, _callbacks);
            }
        }
        
        public void HandleMetadataReportReceived()
        {
            lock (this)
            {
                _reportHandler.HandleMetadataReportReceived(_callbacks);
            }
        }
        
        private void Execute()
        {
            var now = DateTime.Now;
            while (_running)
            {
                try
                {
                    var sleepTime = 10 - now.Second % 10;
                    Thread.Sleep(sleepTime * 1000);

                    now = DateTime.Now;
                    // Capture intervals every minute.
                    if (now.Second == 0)
                    {
                        CaptureIntervals(now);
                    }

                    // Check if reports need to be sent every 10 seconds.
                    SendReports(now);
                }
                catch (ThreadInterruptedException)
                {
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }
        
        public void AddCreateReport(oadrCreateReportType createReport)
        {
            lock (this)
            {
                _reportHandler.CreateReport(createReport.oadrReportRequest, Reports, Intervals);
            }
        }

        /// <summary>
        /// Clear all active reports. Cancels all reports without sending additional reports to the VTN.
        /// </summary>
        public void ClearReports()
        {
            _reportHandler.ClearReports();
        }
        
        /// <summary>
        /// Cancel the incoming report. Return a list of pending reports (reportRequestIds).
        /// </summary>
        public List<string> AddCancelReport(oadrCancelReportType cancelReport)
        {
            List<string> pendingReports;
            lock (this)
            {
                pendingReports = _reportHandler.CancelReport(cancelReport);
            }
            return pendingReports;
        }
        
        public void StartThread()
        {
            if (_running)
            {
                return;
            }
            _running = true;
            _thread = new Thread(Execute);
            _thread.Start();
        }
        
        public void StopThread()
        {
            if (!_running)
            {
                return;
            }

            _running = false;
            _thread.Interrupt();
            _thread.Join();
        }
    }
}
