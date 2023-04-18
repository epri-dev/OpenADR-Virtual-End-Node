using Oadr.Library.Profile2B;
using System;
using System.Collections.Generic;

namespace Oadr.Ven.Resources
{
    public class IntervalEnergy : Interval
    {
        private readonly List<PowerValue> _currentInterval = new List<PowerValue>();
        private readonly int _maxIntervals;
        private readonly int _intervalMinutes;

        public IntervalEnergy(string rId, int intervalMinutes, int maxIntervals = 72) : base(rId)
        {
            _intervalMinutes = intervalMinutes;
            _maxIntervals = maxIntervals;
        }
        
        public void AddIntervalValue(DateTime dateTime, float value)
        {
            var iv = new PowerValue(dateTime, value);
            _currentInterval.Insert(0, iv);
            if (dateTime.Minute % _intervalMinutes == 0 && dateTime.Second == 0)
            {
                CaptureEnergyInterval(dateTime);
            }
        }

        private void CaptureEnergyInterval(DateTime dateTime)
        {
            float value = 0;
            foreach (var iv in _currentInterval)
            {
                value += iv.Value;
            }
            value /= _currentInterval.Count;
            value /= 60 / _intervalMinutes;

            var historicalInterval = new PowerValue(dateTime, value);
            Intervals.Insert(0, historicalInterval);
            if (Intervals.Count > _maxIntervals)
            {
                Intervals.RemoveAt(Intervals.Count - 1);
            }
            _currentInterval.Clear();
        }
        
        public void AddEnergyInterval(DateTime dateTime, float value)
        {
            var historicalInterval = new PowerValue(dateTime, value);
            Intervals.Insert(0, historicalInterval);
            if (Intervals.Count > _maxIntervals)
            {
                Intervals.RemoveAt(Intervals.Count - 1);
            }
        }
        
        public override void AddPayloadToReport(ReportWrapper reportWrapper, IntervalValue intervalValue)
        {
            var pv = (PowerValue)intervalValue;
            reportWrapper.AddIntervalReportPayload(pv.DateTime.ToUniversalTime(), RId, pv.Confidence, pv.Accuracy, pv.Value, DataQuality.QualityGoodNonSpecific, _intervalMinutes, DurationModifier.Minutes);
        }
    }
}
