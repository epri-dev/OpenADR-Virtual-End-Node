using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Ven.Resources
{
    public class Resource
    {
        private float _w = (float)0.0;

        public string ResourceId { get; }

        public IntervalPower IntervalPower { get; }

        public IntervalEnergy IntervalEnergy { get; }

        public IntervalStatus IntervalStatus { get; }

        public bool Online { get; set; } = true;

        public bool Override { get; set; }

        public float W
        {
            get => _w;
            set => _w = value;
        }

        public Resource(string resourceId, int intervalMinutes = 1)
        {
            ResourceId = resourceId;
            IntervalPower = new IntervalPower($"{resourceId}_power", 120);
            IntervalEnergy = new IntervalEnergy($"{resourceId}_energy", intervalMinutes, 120);
            IntervalStatus = new IntervalStatus($"{resourceId}_status", 120);

            var now = DateTime.Now.AddMinutes(-120);
            now = now.AddMinutes(-now.Minute);
            now = now.AddSeconds(-now.Second);
            now = now.AddMilliseconds(-now.Millisecond);
            for (var x = 1; x <= 121; x++)
            {
                IntervalEnergy.AddEnergyInterval(now, x);
                IntervalPower.AddIntervalValue(now, x);
                IntervalStatus.AddStatus(now, true, false);
                now = now.AddMinutes(1);
            }
        }
        
        public void CaptureIntervals(DateTime now)
        {
            IntervalStatus.AddStatus(now, Online, Override);
            IntervalPower.AddIntervalValue(now, _w);
            IntervalEnergy.AddIntervalValue(now, _w);
        }
        
        public virtual void AddReportDescriptions(
            Dictionary<string, ReportWrapper> reports,
            string telemetryStatusSpecifierId,
            string telemetryUsageSpecifierId,
            string historyUsageSpecifierId,
            Dictionary<string, Interval> intervals)
        {
            // Telemetry status.
            reports[telemetryStatusSpecifierId].AddDescription(IntervalStatus.RId, ResourceId, ReportEnumeratedType.xresourceStatus,
                ReadingTypeEnumeratedType.xnotApplicable, "http://MarketContext1", 1, 1, false, DurationModifier.Minutes);

            // Telemetry usage.
            reports[telemetryUsageSpecifierId].AddDescriptionEnergyItem(IntervalEnergy.RId, ResourceId, ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 1, false, DurationModifier.Minutes,
                EEnergyItemType.EnergyReal, "RealEnergy", "Wh", SiScaleCodeType.n);

            reports[telemetryUsageSpecifierId].AddDescriptionPowerItem(IntervalPower.RId, ResourceId, ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 1, false, DurationModifier.Minutes,
                EPowerItemType.PowerReal, "RealPower", "W", SiScaleCodeType.n, 60, 110, true);

            // History usage.
            reports[historyUsageSpecifierId].AddDescriptionEnergyItem(IntervalEnergy.RId, ResourceId, ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 1, false, DurationModifier.Minutes,
                EEnergyItemType.EnergyReal, "RealEnergy", "Wh", SiScaleCodeType.n);

            reports[historyUsageSpecifierId].AddDescriptionPowerItem(IntervalPower.RId, ResourceId, ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 1, false, DurationModifier.Minutes,
                EPowerItemType.PowerReal, "RealPower", "W", SiScaleCodeType.n, 60, 110, true);

            intervals.Add(IntervalStatus.RId, IntervalStatus);
            intervals.Add(IntervalPower.RId, IntervalPower);
            intervals.Add(IntervalEnergy.RId, IntervalEnergy);
        }
        
        public virtual void RemoveReportDescriptions(
            Dictionary<string, ReportWrapper> reports,
            string telemetryStatusSpecifierId,
            string telemetryUsageSpecifierId,
            string historyUsageSpecifierId,
            Dictionary<string, Interval> intervals)
        {
            intervals.Remove(IntervalStatus.RId);
            intervals.Remove(IntervalPower.RId);
            intervals.Remove(IntervalEnergy.RId);
            reports[telemetryStatusSpecifierId].RemoveDescription(IntervalStatus.RId);
            reports[telemetryUsageSpecifierId].RemoveDescription(IntervalEnergy.RId);
            reports[telemetryUsageSpecifierId].RemoveDescription(IntervalPower.RId);
            reports[historyUsageSpecifierId].RemoveDescription(IntervalEnergy.RId);
            reports[historyUsageSpecifierId].RemoveDescription(IntervalPower.RId);
        }

    }
}
