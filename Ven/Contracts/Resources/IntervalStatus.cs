using Oadr.Library.Profile2B;
using System;

namespace Oadr.Ven.Resources
{
    public class IntervalStatus : Interval
    {
        private readonly int _maxIntervals;

        public IntervalStatus(string rId, int maxIntervals) :
            base(rId)
        {
            _maxIntervals = maxIntervals;
        }
        
        public void AddStatus(DateTime dateTime, bool online, bool aOverride)
        {
            var sv = new StatusValue(dateTime, online, aOverride);
            Intervals.Insert(0, sv);
            if (Intervals.Count > _maxIntervals)
            {
                Intervals.RemoveAt(Intervals.Count - 1);
            }
        }
        
        public override void AddPayloadToReport(ReportWrapper reportWrapper, IntervalValue intervalValue)
        {
            var sv = (StatusValue)intervalValue;
            reportWrapper.AddIntervalResourceStatus(sv.DateTime.ToUniversalTime(), RId, 1, (float)1.0, DataQuality.QualityGoodNonSpecific, sv.Online, sv.Override, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0);
        }
    }
}
