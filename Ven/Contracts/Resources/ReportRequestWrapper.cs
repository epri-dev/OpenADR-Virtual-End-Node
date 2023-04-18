using Oadr.Library;
using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Oadr.Ven.Resources
{
    public class ReportRequestWrapper
    {
        private readonly oadrReportRequestType _reportRequest;
        private bool _reportToFollow;
        private DateTime _lastReported = DateTime.MinValue;

        public string ReportRequestId => _reportRequest.reportRequestID;

        public oadrReportRequestType ReportRequest => _reportRequest;

        /// <summary>
        /// Set to true when the final UpdateReport has been generated.
        /// </summary>
        public bool ReportComplete { get; private set; }

        public ReportRequestWrapper(oadrReportRequestType reportRequest)
        {
            _reportRequest = reportRequest;
        }

        /// <summary>
        /// Called when VTN cancels the report but wants the next report to be sent.
        /// </summary>
        public void SetReportToFollow()
        {
            _reportToFollow = true;
        }

        private void DoGenerateUpdateReport(
            Dictionary<string, Interval> intervals,
            DateTime dtstart,
            int durationSeconds,
            ReportWrapper reportWrapper,
            ISendReport sendReport)
        {
            try
            {
                // Make sure only one thread is generating for this report.
                lock (reportWrapper)
                {
                    foreach (var specifierPayload in _reportRequest.reportSpecifier.specifierPayload)
                    {
                        try
                        {
                            var rid = specifierPayload.rID;
                            var interval = intervals[rid];
                            interval.AddIntervalToReport(reportWrapper, dtstart, durationSeconds);
                        }
                        catch (KeyNotFoundException ex)
                        {
                            // There's a situation where a resource has been removed and the new report hasn't
                            // yet been registered with the VTN which will cause a key not found error when we
                            // try to generate the report.
                            // This is expected behaviour.
                            Logger.LogException(ex);
                        }
                        catch (Exception ex)
                        {
                            ReportComplete = true;
                            Logger.LogException(ex);
                        }
                    }
                    var report = reportWrapper.GenerateReport(_reportRequest.reportRequestID);
                    sendReport.SendUpdateReport(report, _reportRequest);
                }
            }
            catch (Exception ex)
            {
                // An exception here indicates a problem with the XML.
                ReportComplete = true;
                Logger.LogException(ex);
            }
        }
        
        /// <summary>
        /// Generate the report if the next report is due.
        /// Set _reportComplete to true if the last report was generated.
        /// </summary>
        public void GenerateUpdateReport(Dictionary<string, Interval> intervals, Dictionary<string, ReportWrapper> reports, ISendReport sendReport)
        {
            // This function is called from a thread.
            // The lock ensures only invocation is active at a time (helps when debugging).
            lock (this)
            {
                try
                {
                    if (ReportComplete)
                    {
                        return;
                    }

                    // Specifies how often to send the report, and the duration of the report.
                    var reportBackDurationSeconds = (int)XmlConvert.ToTimeSpan(_reportRequest.reportSpecifier.reportBackDuration.duration).TotalSeconds;

                    var now = DateTime.Now;
                    DateTime dtStart;
                    int durationSeconds;

                    if (_reportRequest.reportSpecifier.reportInterval == null)
                    {
                        // One-shot report; -1 tells the interval to report the most recent value.
                        dtStart = now;
                        durationSeconds = -1;
                        ReportComplete = true;
                    }
                    else if (reportBackDurationSeconds == 0)
                    {
                        // History report.
                        dtStart = _reportRequest.reportSpecifier.reportInterval.properties.dtstart.datetime.ToLocalTime();
                        durationSeconds = (int)XmlConvert.ToTimeSpan(_reportRequest.reportSpecifier.reportInterval.properties.duration.duration).TotalSeconds;
                        ReportComplete = true;
                    }
                    else
                    {
                        // Periodic report.
                        dtStart = _reportRequest.reportSpecifier.reportInterval.properties.dtstart.datetime.ToLocalTime();
                        durationSeconds = (int)XmlConvert.ToTimeSpan(_reportRequest.reportSpecifier.reportInterval.properties.duration.duration).TotalSeconds;
                        // The report end time has passed.
                        if (now > dtStart.AddSeconds(durationSeconds + 30) && durationSeconds != 0)
                        {
                            ReportComplete = true;
                            return;
                        }

                        if (now >= dtStart && (now <= dtStart.AddSeconds(durationSeconds + 30) || durationSeconds == 0))
                        {
                            if (now >= _lastReported.AddSeconds(reportBackDurationSeconds))
                            {
                                // TODO: This function is crap and needs to be unit tested and cleaned up.
                                // If true, the report has been cancelled but a final report should be sent.
                                if (_reportToFollow)
                                {
                                    ReportComplete = true;
                                }

                                _lastReported = now;
                                // Set dtStart to the value of the newest interval.
                                // All reported intervals should have a date <= dtStart.
                                dtStart = _lastReported;

                                // The duration of a periodic report is equal to reportBackDurationSeconds.
                                durationSeconds = reportBackDurationSeconds;
                            }
                            else
                            {
                                // Not time to send the next report yet.
                                return;
                            }
                        }
                        else
                        {
                            // Report dtStart hasn't passed yet.
                            return;
                        }
                    }

                    // Time to generate a report: dtStart is the report start time and durationSeconds is the length of the report.
                    // If it's a metadata report, it's handled below (outside of the lock).

                    if (_reportRequest.reportSpecifier.reportSpecifierID != "METADATA")
                    {
                        var reportWrapper = reports[_reportRequest.reportSpecifier.reportSpecifierID];
                        DoGenerateUpdateReport(intervals, dtStart, durationSeconds, reportWrapper, sendReport);
                    }
                }
                catch (Exception ex)
                {
                    ReportComplete = true;
                    Logger.LogMessage("Exception caught handling reportRequest. Cancelling report.");
                    Logger.LogException(ex);
                }
            }

            if (_reportRequest.reportSpecifier.reportSpecifierID == "METADATA")
            {
                sendReport.SendMetadataReport(_reportRequest.reportRequestID);
            }
        }
    }
}
