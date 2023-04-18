using Oadr.Library;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class ReportDescription
    {
        private readonly Dictionary<string, oadrReportType> _reports = new Dictionary<string, oadrReportType>();
        private readonly Dictionary<string, Dictionary<string, oadrReportDescriptionType>> _reportDescriptions = new Dictionary<string, Dictionary<string, oadrReportDescriptionType>>();
        private readonly Dictionary<string, List<IntervalType>> _reportIntervals = new Dictionary<string, List<IntervalType>>();
        private readonly Dictionary<string, Dictionary<int, List<oadrReportPayloadType>>> _reportIntervalPayloads = new Dictionary<string, Dictionary<int, List<oadrReportPayloadType>>>();
        private readonly Dictionary<string, ReportName> _reportNames = new Dictionary<string, ReportName>();

        public int NumReports => _reports.Count;

        public Dictionary<string, oadrReportType>.KeyCollection ReportSpecifierIDs => _reports.Keys;

        public void AddReport(string reportSpecifierId, ReportName reportName, int duration, DurationModifier durationModifier)
        {
            var report = new oadrReportType
            {
                reportRequestID = "0",
                reportSpecifierID = reportSpecifierId,
                reportName = reportName.Name,
                duration = new DurationPropType
                {
                    duration = $"PT{duration}{durationModifier.Value}"
                }
            };

            _reports.Add(report.reportSpecifierID, report);
            _reportNames.Add(report.reportSpecifierID, reportName);
        }

        public void RemoveReport(string reportSpecifierId)
        {
            throw new NotImplementedException();
        }

        public void AddDescription(
            string reportSpecifierId,
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
                reportType = reportType,
                readingType = readingType,
                marketContext = marketContext,
                reportDataSource = new EiTargetType
                {
                    resourceID = new string[1]
                },
                oadrSamplingRate = new oadrSamplingRateType
                {
                    oadrMaxPeriod = $"PT{maxSamplingPeriod}{durationModifier.Value}",
                    oadrMinPeriod = $"PT{minSamplingPeriod}{durationModifier.Value}",
                    oadrOnChange = onChange
                }
            };
            reportDescription.reportDataSource.resourceID[0] = resourceId;

            var reportDescriptions = _reportDescriptions.ContainsKey(reportSpecifierId) ? _reportDescriptions[reportSpecifierId] : null;
            if (reportDescriptions == null)
            {
                reportDescriptions = new Dictionary<string, oadrReportDescriptionType>();
                _reportDescriptions[reportSpecifierId] = reportDescriptions;
            }
            reportDescription.itemBase = measuredValue;
            reportDescriptions[rId] = reportDescription;
        }

        public void RemoveDescription(string reportSpecifierId, string rId)
        {
            _reportDescriptions[reportSpecifierId].Remove(rId);
        }

        public void AddDescriptionEnergyItem(
            string reportSpecifierId,
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

            AddDescription(reportSpecifierId, rId, resourceId, reportType, readingType, marketContext, minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, energyItem);
        }

        public void AddDescriptionPowerItem(
            string reportSpecifierId,
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

            AddDescription(reportSpecifierId, rId, resourceId, reportType, readingType, marketContext, minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, powerItem);
        }

        public oadrReportType GenerateReportDescription(string reportSpecifierId)
        {
            var report = _reports[reportSpecifierId];
            report.dtstart = null;
            report.createdDateTime = DateTime.UtcNow;
            report.reportName = _reportNames[reportSpecifierId].MetaDataName;

            if (!_reportDescriptions.ContainsKey(reportSpecifierId))
            {
                // The report does not have any descriptors.
                return report;
            }
            var reportDescriptionsDictionary = _reportDescriptions[reportSpecifierId];

            var reportDescriptionsArray = new oadrReportDescriptionType[reportDescriptionsDictionary.Count];
            var index = 0;
            foreach (var reportDescription in reportDescriptionsDictionary.Values)
            {
                reportDescriptionsArray[index] = reportDescription;
                index++;
            }
            report.oadrReportDescription = reportDescriptionsArray;
            report.intervals = null;
            return report;
        }

        public oadrReportType GenerateReport(string reportSpecifierId, DateTime dtStartUtc)
        {
            var report = _reports[reportSpecifierId];
            report.reportName = _reportNames[reportSpecifierId].Name;

            // Save the duration and restore after generating the report.
            // The duration is only required when registering the report; it indicates the max history that is recorded
            // and the max time frame the can be included in a report.
            //DurationPropType duration = report.duration;
            
            report.duration = null;
            report.createdDateTime = DateTime.UtcNow;

            if (!_reportIntervals.ContainsKey(reportSpecifierId))
            {
                // The report does not have any descriptors
                return report;
            }
            var reportIntervals = _reportIntervals[reportSpecifierId];

            // The dtstart of the report must match the dtstart of the first interval.
            report.dtstart = new dtstart
            {
                datetime = reportIntervals[0].dtstart.datetime
            };

            var intervalsArray = new IntervalType[reportIntervals.Count];
            var intervalIndex = 0;
            foreach (var interval in reportIntervals)
            {
                intervalsArray[intervalIndex] = interval;
                var reportIntervalPayloads = _reportIntervalPayloads[reportSpecifierId][intervalIndex];
                interval.streamPayloadBase = new StreamPayloadBaseType[reportIntervalPayloads.Count];
                var payloadIndex = 0;
                foreach (var reportPayload in reportIntervalPayloads)
                {
                    interval.streamPayloadBase[payloadIndex] = reportPayload;
                    payloadIndex++;
                }
                reportIntervalPayloads.Clear();
                intervalIndex++;
            }

            _reportIntervals.Remove(reportSpecifierId);
            _reportIntervalPayloads.Remove(reportSpecifierId);

            report.oadrReportDescription = null;
            report.intervals = intervalsArray;
            return report;
        }

        /// <summary>
        /// Add an interval to the report and return the UID of the interval.
        /// After adding an interval, ReportPayloads can be added to the interval through the returned UID.
        /// </summary>
        public int AddInterval(string reportSpecifierId, DateTime startUtc, int duration, DurationModifier durationModifier)
        {
            var intervalType = new IntervalType
            {
                dtstart = new dtstart
                {
                    datetime = startUtc
                },
                duration = new DurationPropType
                {
                    duration = $"PT{duration}{durationModifier.Value}"
                }
            };

            var reportIntervals = _reportIntervals.ContainsKey(reportSpecifierId) ? _reportIntervals[reportSpecifierId] : null;
            if (reportIntervals == null)
            {
                reportIntervals = new List<IntervalType>();
                _reportIntervals.Add(reportSpecifierId, reportIntervals);
            }

            var uid = reportIntervals.Count;
            intervalType.Item = new IntervalTypeUidUid
            {
                text = uid.ToString()
            };
            reportIntervals.Add(intervalType);
            return uid;
        }
        
        private void AddIntervalPayload(string reportSpecifierId, int uid, oadrReportPayloadType reportPayload)
        {
            var reportIntervalPayloads = _reportIntervalPayloads.ContainsKey(reportSpecifierId) ? _reportIntervalPayloads[reportSpecifierId] : null;
            if (reportIntervalPayloads == null)
            {
                reportIntervalPayloads = new Dictionary<int, List<oadrReportPayloadType>>();
                _reportIntervalPayloads.Add(reportSpecifierId, reportIntervalPayloads);
            }

            var payloads = (reportIntervalPayloads.ContainsKey(uid) ? reportIntervalPayloads[uid] : null);
            if (payloads == null)
            {
                payloads = new List<oadrReportPayloadType>();
                reportIntervalPayloads.Add(uid, payloads);
            }
            payloads.Add(reportPayload);
        }
        
        public void AddIntervalReportPayload(string reportSpecifierId, int uid, string rId, uint confidence, float accuracy, float payload, DataQuality dataQuality)
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
            AddIntervalPayload(reportSpecifierId, uid, reportPayload);
        }
        
        /// <summary>
        /// Adds an interval and a ReportPayload to the interval.
        /// Calling this function is the same as calling AddInterval followed by AddIntervalReportPayload.
        /// </summary>
        public int AddIntervalReportPayload(
            string reportSpecifierId,
            DateTime startUtc,
            int duration,
            DurationModifier durationModifier,
            string rId,
            uint confidence,
            float accuracy,
            float payload,
            DataQuality dataQuality)
        {
            var uid = AddInterval(reportSpecifierId, startUtc, duration, durationModifier);
            AddIntervalReportPayload(reportSpecifierId, uid, rId, confidence, accuracy, payload, dataQuality);
            return uid;
        }
        
        public void AddIntervalResourceStatus(
            string reportSpecifierId,
            int uid,
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
            float setPointNormal)
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
            AddIntervalPayload(reportSpecifierId, uid, reportPayload);
        }

        public int AddIntervalResourceStatus(
            string reportSpecifierId,
            DateTime startUtc,
            int duration,
            DurationModifier durationModifier,
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
            float setPointNormal)
        {
            var uid = AddInterval(reportSpecifierId, startUtc, duration, durationModifier);
            AddIntervalResourceStatus(reportSpecifierId, uid, rId, confidence, accuracy, dataQuality, online, manualOverride, capacityMin, capacityMax, capacityCurrent,
                capacityNormal, levelOffsetMin, levelOffsetMax, levelOffsetCurrent, levelOffsetNormal, percentOffsetMin, percentOffsetMax, percentOffsetCurrent,
                percentOffsetNormal, setPointMin, setPointMax, setPointCurrent, setPointNormal);
            return uid;
        }
    }
}
