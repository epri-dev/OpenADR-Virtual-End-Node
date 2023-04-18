using Oadr.Library;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Oadr.Library.Profile2B
{
    public class ReportWrapper
    {
        private readonly DurationPropType _reportDuration;
        private readonly ReportName _reportName;
        private readonly Dictionary<string, oadrReportDescriptionType> _reportDescriptions = new Dictionary<string, oadrReportDescriptionType>();
        private readonly Dictionary<string, IntervalType> _reportIntervals = new Dictionary<string, IntervalType>(); // Intervals for a given date.
        private readonly Dictionary<string, List<StreamPayloadBaseType>> _reportIntervalPayloads = new Dictionary<string, List<StreamPayloadBaseType>>();  // Payloads for an interval for a date.
        
        public string ReportSpecifierId { get; }

        public ReportWrapper(string reportSpecifierId, ReportName reportName, int duration, DurationModifier durationModifier)
        {
            ReportSpecifierId = reportSpecifierId;
            _reportName = reportName;
            _reportDuration = new DurationPropType
            {
                duration = $"PT{duration}{durationModifier.Value}"
            };
        }

        public void AddDescription(
            string rId,
            string resourceId,
            ReportEnumeratedType reportType,
            ReadingTypeEnumeratedType readingType,
            string marketContext,
            int minSamplingPeriod,
            int maxSamplingPeriod,
            bool onChange,
            DurationModifier durationModifier,
            ItemBaseType measuredValue = null)
        {
            var reportDescription = new oadrReportDescriptionType
            {
                rID = rId,
                reportDataSource = new EiTargetType
                {
                    resourceID = new string[1]
                },
                reportType = reportType,
                readingType = readingType,
                marketContext = marketContext,
                oadrSamplingRate = new oadrSamplingRateType
                {
                    oadrMaxPeriod = $"PT{maxSamplingPeriod}{durationModifier.Value}",
                    oadrMinPeriod = $"PT{minSamplingPeriod}{durationModifier.Value}",
                    oadrOnChange = onChange
                },
                itemBase = measuredValue
            };
            reportDescription.reportDataSource.resourceID[0] = resourceId;
            _reportDescriptions.Add(rId, reportDescription);
        }

        public void RemoveDescription(string rId)
        {
            _reportDescriptions.Remove(rId);
        }
        
        public void AddDescriptionStatus(
            string rId,
            string resourceId,
            string marketContext,
            int minSamplingPeriod,
            int maxSamplingPeriod,
            bool onChange,
            DurationModifier durationModifier)

        {
            AddDescription(rId, resourceId, ReportEnumeratedType.xresourceStatus, ReadingTypeEnumeratedType.DirectRead, marketContext,
                minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier);
        }
        
        public void AddDescriptionEnergyItem(
            string rId,
            string resourceId,
            ReportEnumeratedType reportType,
            ReadingTypeEnumeratedType readingType,
            string marketContext,
            int minSamplingPeriod,
            int maxSamplingPeriod,
            bool onChange,
            DurationModifier durationModifier,
            EEnergyItemType energyItemType,
            string description,
            string units,
            SiScaleCodeType siScaleCode)
        {
            EnergyItemType energyItem;
            switch (energyItemType)
            {
                case EEnergyItemType.EnergyApparent:
                    energyItem = new EnergyApparentType();
                    break;
                case EEnergyItemType.EnergyReactive:
                    energyItem = new EnergyReactiveType();
                    break;
                case EEnergyItemType.EnergyReal:
                    energyItem = new EnergyRealType();
                    break;
                default:
                    energyItem = new EnergyApparentType();
                    break;
            }
            energyItem.itemDescription = description;
            energyItem.itemUnits = units;
            energyItem.siScaleCode = siScaleCode;
            AddDescription(rId, resourceId, reportType, readingType, marketContext, minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, energyItem);
        }
        
        public void AddDescriptionPowerItem(
            string rId,
            string resourceId,
            ReportEnumeratedType reportType,
            ReadingTypeEnumeratedType readingType,
            string marketContext,
            int minSamplingPeriod,
            int maxSamplingPeriod,
            bool onChange,
            DurationModifier durationModifier,
            EPowerItemType powerItemType,
            string description,
            string units,
            SiScaleCodeType siScaleCode,
            decimal hertz,
            decimal voltage,
            bool ac)
        {
            PowerItemType powerItem;
            switch (powerItemType)
            {
                case EPowerItemType.PowerApparent:
                    powerItem = new PowerApparentType();
                    break;
                case EPowerItemType.PowerReactive:
                    powerItem = new PowerReactiveType();
                    break;
                case EPowerItemType.PowerReal:
                    powerItem = new PowerRealType();
                    break;
                default:
                    powerItem = new PowerApparentType();
                    break;
            }
            powerItem.itemDescription = description;
            powerItem.itemUnits = units;
            powerItem.siScaleCode = siScaleCode;
            powerItem.powerAttributes = new PowerAttributesType
            {
                hertz = hertz,
                voltage = voltage
            };
            AddDescription(rId, resourceId, reportType, readingType, marketContext, minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, powerItem);
        }

        public oadrReportType GenerateReportDescription(string reportRequestId = null)
        {
            var report = new oadrReportType
            {
                dtstart = null,
                duration = _reportDuration,
                createdDateTime = DateTime.UtcNow,
                reportName = _reportName.MetaDataName,
                reportSpecifierID = ReportSpecifierId,
                // Conformance rule 311 says reportRequestID should be populated with the reportRequestID from the request if the report
                // is generated from a reportRequest (and not through the registration process).
                reportRequestID = reportRequestId ?? "0"
            };

            var reportDescriptionsArray = new oadrReportDescriptionType[_reportDescriptions.Count];
            var index = 0;
            foreach (var reportDescription in _reportDescriptions.Values)
            {
                reportDescriptionsArray[index] = reportDescription;
                index++;
            }
            report.oadrReportDescription = reportDescriptionsArray;
            report.intervals = null;
            return report;
        }
        
        public oadrReportType GenerateReport(string reportRequestId)
        {
            var report = new oadrReportType
            {
                createdDateTime = DateTime.UtcNow,
                reportName = _reportName.Name,
                reportRequestID = reportRequestId,
                reportSpecifierID = ReportSpecifierId
            };

            // The report does not have any descriptors.
            if (_reportIntervals.Count == 0)
            {
                return report;
            }

            var reportIntervals = _reportIntervals.Values.ToList().OrderBy(o => o.dtstart.datetime).ToList();
            reportIntervals.Reverse();

            // The dtstart of the report must match the dtstart of the first interval.
            report.dtstart = new dtstart
            {
                datetime = reportIntervals[0].dtstart.datetime
            };

            var intervalsArray = new IntervalType[_reportIntervals.Count];
            var intervalIndex = 0;
            foreach (var interval in reportIntervals)
            {
                intervalsArray[intervalIndex] = interval;
                var key = interval.dtstart.datetime.ToString(CultureInfo.InvariantCulture);

                var intervalPayloads = _reportIntervalPayloads[key];
                interval.streamPayloadBase = new StreamPayloadBaseType[intervalPayloads.Count];
                var intervalPayloadIndex = 0;
                foreach (var intervalPayload in intervalPayloads)
                {
                    interval.streamPayloadBase[intervalPayloadIndex] = intervalPayload;
                    intervalPayloadIndex++;
                }
                intervalIndex++;
            }

            _reportIntervals.Clear();
            _reportIntervalPayloads.Clear();

            report.oadrReportDescription = null;
            report.intervals = intervalsArray;
            return report;
        }
        
        private void AddIntervalPayload(DateTime startUtc, string rId, oadrReportPayloadType reportPayload, int duration = -1, DurationModifier durationModifier = null)
        {
            var key = startUtc.ToString(CultureInfo.InvariantCulture);
            IntervalType interval;
            if (!_reportIntervals.ContainsKey(key))
            {
                interval = OadrObjectFactory.CreateIntervalType(startUtc, duration, durationModifier);
                _reportIntervals.Add(key, interval);
                _reportIntervalPayloads.Add(key, new List<StreamPayloadBaseType>());
            }

            // If an interval contains an 'interval' and 'point data', duration must be present.
            // Conformance rule 342 provides rules for when dtstart and duration must be present, but fails
            // to specify what should be done when both 'interval' and 'point data' are present.
            // The OADR alliance said dtstart and duration should be present if both types of data are present.
            interval = _reportIntervals[key];
            if (interval.duration == null && duration != -1)
            {
                _reportIntervals[key] = OadrObjectFactory.CreateIntervalType(startUtc, duration, durationModifier);
            }
            var intervalPayloads = _reportIntervalPayloads[key];
            intervalPayloads.Add(reportPayload);
        }
        
        public void AddIntervalReportPayload(
            DateTime startUtc,
            string rId,
            uint confidence,
            float accuracy,
            float payload,
            DataQuality dataQuality,
            int duration = -1,
            DurationModifier durationModifier = null)
        {
            var reportPayload = new oadrReportPayloadType
            {
                rID = rId,
                confidence = confidence,
                accuracy = accuracy,
                oadrDataQuality = dataQuality.QualityType,
                Item = new PayloadFloatType
                {
                    value = payload
                }
            };
            AddIntervalPayload(startUtc, rId, reportPayload, duration, durationModifier);
        }
        
        public void AddIntervalResourceStatus(
            DateTime startUtc,
            string rId,
            uint confidence,
            float accuracy,
            DataQuality dataQuality,
            bool online,
            bool manualOverride,
            float capacityMin,
            float capacityMax,
            float capacityCurrent,
            float capacityNormal,
            float levelOffsetMin,
            float levelOffsetMax,
            float levelOffsetCurrent,
            float levelOffsetNormal,
            float percentOffsetMin,
            float percentOffsetMax,
            float percentOffsetCurrent,
            float percentOffsetNormal,
            float setPointMin,
            float setPointMax,
            float setPointCurrent,
            float setPointNormal,
            int duration = -1,
            DurationModifier durationModifier = null)
        {
            var reportPayload = new oadrReportPayloadType
            {
                rID = rId,
                confidence = confidence,
                accuracy = accuracy,
                oadrDataQuality = dataQuality.QualityType,
                Item = new oadrPayloadResourceStatusType
                {
                    oadrOnline = online,
                    oadrManualOverride = manualOverride,
                    oadrLoadControlState = new oadrLoadControlStateType
                    {
                        oadrCapacity = OadrObjectFactory.CreateLoadControlStateType(capacityMin, capacityMax, capacityCurrent, capacityNormal),
                        oadrLevelOffset = OadrObjectFactory.CreateLoadControlStateType(levelOffsetMin, levelOffsetMax, levelOffsetCurrent, levelOffsetNormal),
                        oadrPercentOffset = OadrObjectFactory.CreateLoadControlStateType(percentOffsetMin, percentOffsetMax, percentOffsetCurrent, percentOffsetNormal),
                        oadrSetPoint = OadrObjectFactory.CreateLoadControlStateType(setPointMin, setPointMax, setPointCurrent, setPointNormal)
                    }
                }
            };
            AddIntervalPayload(startUtc, rId, reportPayload, duration, durationModifier);
        }
    }

    public enum EEnergyItemType
    {
        EnergyApparent,

        EnergyReactive,

        EnergyReal
    }

    public enum EPowerItemType
    {
        PowerApparent,

        PowerReactive,

        PowerReal
    }
}
