using Oadr.Library.Profile2B;
using System;

namespace Oadr.Ven.Resources
{
    public class IntervalPower : Interval
    {
        private readonly int _maxIntervals;
        
        public IntervalPower(string rId, int maxIntervals = 360) : 
            base(rId)
        {
            _maxIntervals = maxIntervals;
        }
        
        public void AddIntervalValue(DateTime dateTime, float value)
        {
            var iv = new PowerValue(dateTime, value);
            Intervals.Insert(0, iv);
            if (Intervals.Count > _maxIntervals)
            {
                Intervals.RemoveAt(Intervals.Count - 1);
            }
        }
        
        public override void AddPayloadToReport(ReportWrapper reportWrapper, IntervalValue intervalValue)
        {
            var pv = (PowerValue)intervalValue;
            reportWrapper.AddIntervalReportPayload(pv.DateTime.ToUniversalTime(), RId, pv.Confidence, pv.Accuracy, pv.Value, DataQuality.QualityGoodNonSpecific);
        }
    }
}
