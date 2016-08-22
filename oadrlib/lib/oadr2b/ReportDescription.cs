//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oadrlib.lib.oadr2b
{


    public class ReportDescription
    {
        private Dictionary<string, oadrReportType> _reports = new Dictionary<string,oadrReportType>();
        private Dictionary<string, Dictionary<string, oadrReportDescriptionType>> _reportDescriptions = new Dictionary<string, Dictionary<string, oadrReportDescriptionType>>();

        private Dictionary<string, List<IntervalType>> _reportIntervals = new Dictionary<string, List<IntervalType>>();

        private Dictionary<string, Dictionary<int, List<oadrReportPayloadType>>> _reportIntervalPayloads = new Dictionary<string, Dictionary<int, List<oadrReportPayloadType>>>();

        private Dictionary<string, ReportName> _reportNames = new Dictionary<string, ReportName>();

        public void addReport(string reportSpecifierID, ReportName reportName, int duration, DurationModifier durationModifier)
        {
            oadrReportType report = new oadrReportType();

            report.reportRequestID = "0";

            report.reportSpecifierID = reportSpecifierID;
            report.reportName = reportName.Name;

            report.duration = new DurationPropType();
            report.duration.duration = "PT" + duration.ToString() + durationModifier.Value;

            _reports.Add(report.reportSpecifierID, report);

            _reportNames.Add(report.reportSpecifierID, reportName);
        }

        /**********************************************************/

        public void removeReport(string reportSpecifierID)
        {
            throw new Exception("not implemented");
        }

        /**********************************************************/

        public void removeDescription(string reportSpecifierID, string rID)
        {
            _reportDescriptions[reportSpecifierID].Remove(rID);
        }

        /**********************************************************/

        public void addDescription(string reportSpecifierID, string rID, string resourceID, ReportEnumeratedType reportType, ReadingTypeEnumeratedType readingType,
            string marketContext, int minSamplingPeriod, int maxSamplingPeriod, bool onChange, DurationModifier durationModifier, ItemBaseType measuredValue = null)
        {
            oadrReportDescriptionType reportDescription = new oadrReportDescriptionType();

            reportDescription.rID = rID;
            reportDescription.reportDataSource = new EiTargetType();
            reportDescription.reportDataSource.resourceID = new string[1];
            reportDescription.reportDataSource.resourceID[0] = resourceID;

            reportDescription.reportType = reportType;
            reportDescription.readingType = readingType;
            reportDescription.marketContext = marketContext;

            reportDescription.oadrSamplingRate = new oadrSamplingRateType();
            reportDescription.oadrSamplingRate.oadrMaxPeriod = "PT" + maxSamplingPeriod.ToString() + durationModifier.Value;
            reportDescription.oadrSamplingRate.oadrMinPeriod = "PT" + minSamplingPeriod.ToString() + durationModifier.Value;

            reportDescription.oadrSamplingRate.oadrOnChange = onChange;

            Dictionary<string, oadrReportDescriptionType> reportDescriptions = (_reportDescriptions.ContainsKey(reportSpecifierID) ? _reportDescriptions[reportSpecifierID] : null);

            if (reportDescriptions == null)
            {
                reportDescriptions = new Dictionary<string, oadrReportDescriptionType>();
                _reportDescriptions[reportSpecifierID] = reportDescriptions;
            }
            
            reportDescription.itemBase = measuredValue;            

            reportDescriptions[rID] = reportDescription;
        }

        /**********************************************************/

        public void addDescriptionEnergyItem(string reportSpecifierID, string rID, string resourceID, ReportEnumeratedType reportType, ReadingTypeEnumeratedType readingType,
                    string marketContext, int minSamplingPeriod, int maxSamplingPeriod, bool onChange, DurationModifier durationModifier,
                    eEnergyItemType energyItemType, string description, string units, SiScaleCodeType siScaleCode)
        {
            EnergyItemType energyItem = null;

            switch (energyItemType)
            {
                case eEnergyItemType.EnergyApparent:
                    energyItem = new EnergyApparentType();
                    break;

                case eEnergyItemType.EnergyReactive:
                    energyItem = new EnergyReactiveType();
                    break;

                case eEnergyItemType.EnergyReal:
                    energyItem = new EnergyRealType();
                    break;

                default:
                    energyItem = new EnergyApparentType();
                    break;
            }

            energyItem.itemDescription = description;
            energyItem.itemUnits = units;
            energyItem.siScaleCode = siScaleCode;
            
            addDescription(reportSpecifierID, rID, resourceID, reportType, readingType, marketContext, minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, energyItem);
        }

        /**********************************************************/

        public void addDescriptionPowerItem(string reportSpecifierID, string rID, string resourceID, ReportEnumeratedType reportType, ReadingTypeEnumeratedType readingType,
                    string marketContext, int minSamplingPeriod, int maxSamplingPeriod, bool onChange, DurationModifier durationModifier, 
                    ePowerItemType powerItemType, string description, string units, SiScaleCodeType siScaleCode, decimal hertz, decimal voltage, bool ac)
        {
            PowerItemType powerItem = null;

            switch (powerItemType)
            {
                case ePowerItemType.PowerApparent:
                    powerItem = new PowerApparentType();
                    break;

                case ePowerItemType.PowerReactive:
                    powerItem = new PowerReactiveType();
                    break;

                case ePowerItemType.PowerReal:
                    powerItem = new PowerRealType();
                    break;

                default:
                    powerItem = new PowerApparentType();
                    break;
            }
            
            powerItem.itemDescription = description;
            powerItem.itemUnits = units;
            powerItem.siScaleCode = siScaleCode;

            powerItem.powerAttributes = new PowerAttributesType();
            powerItem.powerAttributes.hertz = hertz;
            powerItem.powerAttributes.voltage = voltage;

            addDescription(reportSpecifierID, rID, resourceID, reportType, readingType, marketContext, minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, powerItem);
        }

        /**********************************************************/

        public oadrReportType generateReportDescription(string reportSpeciferID)
        {
            oadrReportType report = _reports[reportSpeciferID];
            ReportName reportName = _reportNames[reportSpeciferID];
            Dictionary<string, oadrReportDescriptionType> reportDescriptionsDictionary;

            report.dtstart = null;
            // report.duration = null;

            report.createdDateTime = DateTime.UtcNow;

            report.reportName = reportName.MetaDataName;

            try
            {
                reportDescriptionsDictionary = _reportDescriptions[reportSpeciferID];
            }
            catch(System.Collections.Generic.KeyNotFoundException)
            {
                // thre report does not have any descriptors
                return report;
            }

            oadrReportDescriptionType[] reportDescriptionsArray = new oadrReportDescriptionType[reportDescriptionsDictionary.Count];

            int index = 0;
            foreach (oadrReportDescriptionType reportDescription in reportDescriptionsDictionary.Values)
            {
                reportDescriptionsArray[index] = reportDescription;
                index++;
            }

            report.oadrReportDescription = reportDescriptionsArray;

            report.intervals = null;            

            return report;
        }

        /**********************************************************/

        public oadrReportType generateReport(string reportSpecifierID, DateTime dtstartUTC)
        {
            oadrReportType report = _reports[reportSpecifierID];
            ReportName reportName = _reportNames[reportSpecifierID];

            report.reportName = reportName.Name;

            // save the duration and restore after generating the report
            // the duration is only required when registering the report; it indicates
            // the max history that is recorded, and the max time frame the can be included in a report
            DurationPropType duraton = report.duration;
            report.duration = null;

            report.createdDateTime = DateTime.UtcNow;

            List<IntervalType> reportIntervals;

            try
            {
                reportIntervals = _reportIntervals[reportSpecifierID];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                // the report does not have any descriptors
                return report;
            }

            // the dtstart of the report must match the dtstart of the first interval
            report.dtstart = new dtstart();
            report.dtstart.datetime = reportIntervals[0].dtstart.datetime;

            IntervalType[] intervalsArray = new IntervalType[reportIntervals.Count];

            int intervalIndex = 0;
            foreach (IntervalType interval in reportIntervals)
            {
                intervalsArray[intervalIndex] = interval;
                
                List<oadrReportPayloadType> reportIntervalPayloads = _reportIntervalPayloads[reportSpecifierID][intervalIndex];

                interval.streamPayloadBase = new StreamPayloadBaseType[reportIntervalPayloads.Count];

                int payloadIndex = 0;
                foreach (oadrReportPayloadType reportPayload in reportIntervalPayloads)
                {                    
                    interval.streamPayloadBase[payloadIndex] = reportPayload;
                    payloadIndex++;
                }

                reportIntervalPayloads.Clear();

                intervalIndex++;
            }

            _reportIntervals.Remove(reportSpecifierID);
            _reportIntervalPayloads.Remove(reportSpecifierID);

            report.oadrReportDescription = null;
            report.intervals = intervalsArray;

            return report;
        }

        /**********************************************************/

        /// <summary>
        /// add an interval to the report, return the UID of the interval
        /// after adding an interval, ReportPayloads can be added to the interval through
        /// the returned uid
        /// </summary>
        /// <param name="reportSpecifierID"></param>
        /// <param name="startUTC"></param>
        /// <param name="durationMinutes"></param>
        /// <returns></returns>
        public int addInterval(string reportSpecifierID, DateTime startUTC, int duration, DurationModifier durationModifier)
        {
            IntervalType intervalType = new IntervalType();
            

            intervalType.dtstart = new dtstart();
            intervalType.dtstart.datetime = startUTC;

            intervalType.duration = new DurationPropType();
            intervalType.duration.duration = "PT" + duration.ToString() + durationModifier.Value;

            List<IntervalType> reportIntervals = (_reportIntervals.ContainsKey(reportSpecifierID) ? _reportIntervals[reportSpecifierID] : null);
            
            if (reportIntervals == null)
            {
                reportIntervals = new List<IntervalType>();

                _reportIntervals.Add(reportSpecifierID, reportIntervals);
            }

            int uid = reportIntervals.Count;

            IntervalTypeUidUid intervalTypeUID = new IntervalTypeUidUid();
            intervalTypeUID.text = uid.ToString();

            intervalType.Item = intervalTypeUID;

            reportIntervals.Add(intervalType);

            return uid;
        }

        /**********************************************************/

        private void addIntervalPayload(string reportSpecifierID, int uid, oadrReportPayloadType reportPayload)
        {
            Dictionary<int, List<oadrReportPayloadType>> reportIntervalPayloads = (_reportIntervalPayloads.ContainsKey(reportSpecifierID) ? _reportIntervalPayloads[reportSpecifierID] : null);

            if (reportIntervalPayloads == null)
            {
                reportIntervalPayloads = new Dictionary<int, List<oadrReportPayloadType>>();
                _reportIntervalPayloads.Add(reportSpecifierID, reportIntervalPayloads);
            }

            List<oadrReportPayloadType> payloads = (reportIntervalPayloads.ContainsKey(uid) ? reportIntervalPayloads[uid] : null);

            if (payloads == null)
            {
                payloads = new List<oadrReportPayloadType>();
                reportIntervalPayloads.Add(uid, payloads);
            }

            payloads.Add(reportPayload);
        }

        /**********************************************************/

        public void addIntervalReportPayload(string reportSpecifierID, int uid, string rID, uint confidence, float accuracy, float payload, DataQuality dataQuality)
        {
            oadrReportPayloadType reportPayload = new oadrReportPayloadType();

            reportPayload.rID = rID;
            reportPayload.confidence = confidence;
            reportPayload.accuracy = accuracy;

            reportPayload.oadrDataQuality = dataQuality.QualityType;

            PayloadFloatType payloadFloat = new PayloadFloatType();
            payloadFloat.value = payload;

            reportPayload.Item = payloadFloat;

            addIntervalPayload(reportSpecifierID, uid, reportPayload);
        }

        /**********************************************************/

        /// <summary>
        /// adds an interval and a ReportPayload to the interval
        /// calling this function is the same as calling addInterval followed by addIntervalReportPayload
        /// </summary>
        /// <param name="reportSpecifierID"></param>
        /// <param name="startUTC"></param>
        /// <param name="durationMinutes"></param>
        /// <param name="rID"></param>
        /// <param name="confidence"></param>
        /// <param name="accuracy"></param>
        /// <param name="payload"></param>
        /// <param name="dataQuality"></param>
        /// <returns></returns>
        public int addIntervalReportPayload(string reportSpecifierID, DateTime startUTC, int duration, DurationModifier durationModifier,
            string rID, uint confidence, float accuracy, float payload, DataQuality dataQuality)
        {
            int uid = addInterval(reportSpecifierID, startUTC, duration, durationModifier);

            addIntervalReportPayload(reportSpecifierID, uid, rID, confidence, accuracy, payload, dataQuality);

            return uid;
        }

        /**********************************************************/

        public void addIntervalResourceStatus(string reportSpecifierID, int uid, string rID, uint confidence, float accuracy, DataQuality dataQuality, bool online, bool manualOverride,
            float capacityMin, float capacityMax, float capacityCurrent, float capacityNormal,
            float levelOffsetMin, float levelOffsetMax, float levelOffsetCurrent, float levelOffsetNormal,
            float percentOffsetMin, float percentOffsetMax, float percentOffsetCurrent, float percentOffsetNormal,
            float setPointMin, float setPointMax, float setPointCurrent, float setPointNormal)
        {
            oadrReportPayloadType reportPayload = new oadrReportPayloadType();

            reportPayload.rID = rID;
            reportPayload.confidence = confidence;
            reportPayload.accuracy = accuracy;

            reportPayload.oadrDataQuality = dataQuality.QualityType;

            oadrPayloadResourceStatusType resourceStatus = new oadrPayloadResourceStatusType();

            resourceStatus.oadrOnline = online;
            resourceStatus.oadrManualOverride = manualOverride;

            resourceStatus.oadrLoadControlState = new oadrLoadControlStateType();
            resourceStatus.oadrLoadControlState.oadrCapacity = helper.OadrObjectFactory.createLoadControlStateType(capacityMin, capacityMax, capacityCurrent, capacityNormal);
            resourceStatus.oadrLoadControlState.oadrLevelOffset = helper.OadrObjectFactory.createLoadControlStateType(levelOffsetMin, levelOffsetMax, levelOffsetCurrent, levelOffsetNormal);
            resourceStatus.oadrLoadControlState.oadrPercentOffset = helper.OadrObjectFactory.createLoadControlStateType(percentOffsetMin, percentOffsetMax, percentOffsetCurrent, percentOffsetNormal);
            resourceStatus.oadrLoadControlState.oadrSetPoint = helper.OadrObjectFactory.createLoadControlStateType(setPointMin, setPointMax, setPointCurrent, setPointNormal);

            reportPayload.Item = resourceStatus;

            addIntervalPayload(reportSpecifierID, uid, reportPayload);
        }

        /**********************************************************/

        public int addIntervalResourceStatus(string reportSpecifierID, DateTime startUTC, int duration, DurationModifier durationModifier,
            string rID, uint confidence, float accuracy, DataQuality dataQuality, bool online, bool manualOverride,
            float capacityMin, float capacityMax, float capacityCurrent, float capacityNormal,
            float levelOffsetMin, float levelOffsetMax, float levelOffsetCurrent, float levelOffsetNormal,
            float percentOffsetMin, float percentOffsetMax, float percentOffsetCurrent, float percentOffsetNormal,
            float setPointMin, float setPointMax, float setPointCurrent, float setPointNormal)
        {
            int uid = addInterval(reportSpecifierID, startUTC, duration, durationModifier);

            addIntervalResourceStatus(reportSpecifierID, uid, rID, confidence, accuracy, dataQuality, online, manualOverride, capacityMin, capacityMax, capacityCurrent,
                capacityNormal, levelOffsetMin, levelOffsetMax, levelOffsetCurrent, levelOffsetNormal, percentOffsetMin, percentOffsetMax, percentOffsetCurrent,
                percentOffsetNormal, setPointMin, setPointMax, setPointCurrent, setPointNormal);

            return uid;
        }

        /**********************************************************/

        public int NumReports
        {
            get { return _reports.Count; }
        }

        /**********************************************************/

        public Dictionary<string, oadrReportType>.KeyCollection ReportSpecifierIDs
        {
            get { return _reports.Keys; }
        }
    }
}
