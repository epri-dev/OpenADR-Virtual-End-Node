using Oadr.Library;
using Oadr.Library.Profile2B;
using System;
using System.Collections.Generic;

namespace Oadr.Ven.Resources
{
    public abstract class Interval
    {
        public string RId { get; }

        public List<IntervalValue> Intervals { get; } = new List<IntervalValue>();

        protected Interval(string rId)
        {
            RId = rId;
        }

        public abstract void AddPayloadToReport(ReportWrapper reportWrapper, IntervalValue intervalValue);
        
        public List<IntervalValue> QueryIntervals(DateTime dtStart, int durationSeconds)
        {
            var intervalsToReport = new List<IntervalValue>();
            if (Intervals.Count == 0)
            {
                return intervalsToReport;
            }

            // One-shot report, return the newest interval.
            if (durationSeconds == -1)
            {
                intervalsToReport.Add(Intervals[0]);
                return intervalsToReport;
            }

            // Report all history.
            if (durationSeconds == 0)
            {
                durationSeconds = int.MaxValue;
            }

            // If the oldest interval is newer than dtstart, there's no intervals to report.
            if (Intervals[Intervals.Count - 1].DateTime > dtStart)
            {
                return intervalsToReport;
            }

            var endTime = dtStart.AddSeconds(-durationSeconds);

            // If the endTime > the newest interval, there's no intervals to report.
            if (endTime > Intervals[0].DateTime)
            {
                return intervalsToReport;
            }

            var index = 0;

            // Find the first interval with datetime <= dtStart.
            while (Intervals[index].DateTime > dtStart)
            {
                index++;
            }
            while (index < Intervals.Count && Intervals[index].DateTime <= dtStart && Intervals[index].DateTime > endTime)
            {
                intervalsToReport.Add(Intervals[index]);
                index++;
            }
            return intervalsToReport;
        }

        public void AddIntervalToReport(ReportWrapper reportWrapper, DateTime dtstart, int durationSeconds)
        {
            try
            {
                var intervals = QueryIntervals(dtstart, durationSeconds);

                if (intervals.Count == 0)
                {
                    return;
                }

                foreach (var intervalValue in intervals)
                {
                    AddPayloadToReport(reportWrapper, intervalValue);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
