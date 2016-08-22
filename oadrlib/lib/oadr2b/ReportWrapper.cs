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
using System.Threading.Tasks;

namespace oadrlib.lib.oadr2b
{
    public enum eEnergyItemType
    {
        EnergyApparent,
        EnergyReactive,
        EnergyReal
    }

    public enum ePowerItemType
    {
        PowerApparent,
        PowerReactive,
        PowerReal
    }


    public class ReportWrapper
    {
        private DurationPropType m_reportDuration;

        private ReportName m_reportName;

        private Dictionary<string, oadrReportDescriptionType> m_reportDescriptions = new Dictionary<string, oadrReportDescriptionType>();

        // these are parallel structures
        private Dictionary<string, IntervalType> m_reportIntervals = new Dictionary<string, IntervalType>(); // intervals for a given date
        private Dictionary<string, List<StreamPayloadBaseType>> m_reportIntervalPayloads = new Dictionary<string, List<StreamPayloadBaseType>>();  // payloads for an interval for a date

        public ReportWrapper(string reportSpecifierID, ReportName reportName, int duration, DurationModifier durationModifier)
        {
            ReportSpecifierID = reportSpecifierID;
            m_reportName = reportName;

            m_reportDuration = new DurationPropType();
            m_reportDuration.duration = "PT" + duration.ToString() + durationModifier.Value;
        }

        /**********************************************************/

        public string ReportSpecifierID
        {
            get;

            private set;
        }

        /**********************************************************/

        public void removeDescription(string rID)
        {
            m_reportDescriptions.Remove(rID);
        }

        /**********************************************************/

        public void addDescription(string rID, string resourceID, ReportEnumeratedType reportType, ReadingTypeEnumeratedType readingType,
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

            reportDescription.itemBase = measuredValue;

            m_reportDescriptions.Add(rID, reportDescription);
        }

        /**********************************************************/

        public void addDescriptionStatus(string rID, string resourceID, string marketContext, int minSamplingPeriod, int maxSamplingPeriod, 
            bool onChange, DurationModifier durationModifier)
                    
        {
            addDescription(rID, resourceID, ReportEnumeratedType.xresourceStatus, ReadingTypeEnumeratedType.DirectRead, marketContext,
                minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, null);
        }

        /**********************************************************/

        public void addDescriptionEnergyItem(string rID, string resourceID, ReportEnumeratedType reportType, ReadingTypeEnumeratedType readingType,
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

            addDescription(rID, resourceID, reportType, readingType, marketContext, minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, energyItem);
        }

        /**********************************************************/

        public void addDescriptionPowerItem(string rID, string resourceID, ReportEnumeratedType reportType, ReadingTypeEnumeratedType readingType,
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

            addDescription(rID, resourceID, reportType, readingType, marketContext, minSamplingPeriod, maxSamplingPeriod, onChange, durationModifier, powerItem);
        }

        /**********************************************************/

        public oadrReportType generateReportDescription(string reportRequestID = null)
        {
            oadrReportType report = new oadrReportType();                       

            report.dtstart = null;
            report.duration = m_reportDuration;

            report.createdDateTime = DateTime.UtcNow;

            report.reportName = m_reportName.MetaDataName;

            // test harness bug: conformance rule 311 says reportRequestID should
            // be populated with the reportRequestID from the request if the report
            // is generated from a reportRequest (and not through the registration process)
            // the test harness will fail the VEN if the reportRequestID is anything but 0
            //if (reportRequestID != null)
            //    report.reportRequestID = reportRequestID;
            //else
                
            report.reportRequestID = "0";

            report.reportSpecifierID = ReportSpecifierID;

            oadrReportDescriptionType[] reportDescriptionsArray = new oadrReportDescriptionType[m_reportDescriptions.Count];

            int index = 0;
            foreach (oadrReportDescriptionType reportDescription in m_reportDescriptions.Values)
            {
                reportDescriptionsArray[index] = reportDescription;
                index++;
            }

            report.oadrReportDescription = reportDescriptionsArray;

            report.intervals = null;

            return report;
        }

        /**********************************************************/

        public oadrReportType generateReport(string reportRequestID)
        {
            oadrReportType report = new oadrReportType();

            report.createdDateTime = DateTime.UtcNow;

            report.reportName = m_reportName.Name;

            report.reportRequestID = reportRequestID;

            report.reportSpecifierID = ReportSpecifierID;

            report.createdDateTime = DateTime.UtcNow;

            // the report does not have any descriptors
            if (m_reportIntervals.Count == 0)
                return report;

            List<IntervalType> reportIntervals = m_reportIntervals.Values.ToList().OrderBy(o => o.dtstart.datetime).ToList();
            reportIntervals.Reverse();

            // the dtstart of the report must match the dtstart of the first interval
            report.dtstart = new dtstart();
            report.dtstart.datetime = reportIntervals[0].dtstart.datetime;

            IntervalType[] intervalsArray = new IntervalType[m_reportIntervals.Count];

            int intervalIndex = 0;

            foreach (IntervalType interval in reportIntervals)
            {                               
                intervalsArray[intervalIndex] = interval;
                string key = interval.dtstart.datetime.ToString();

                List<StreamPayloadBaseType> intervalPayloads = m_reportIntervalPayloads[key];

                interval.streamPayloadBase = new StreamPayloadBaseType[intervalPayloads.Count];

                int intervalPayloadIndex = 0;
                foreach (StreamPayloadBaseType intervalPayload in intervalPayloads)
                {
                    interval.streamPayloadBase[intervalPayloadIndex] = intervalPayload;
                    intervalPayloadIndex++;
                }

                intervalIndex++;
            }

            m_reportIntervals.Clear();
            m_reportIntervalPayloads.Clear();

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
        /*public void addInterval(string rid, DateTime startUTC, int duration, DurationModifier durationModifier)
        {
            IntervalType intervalType = new IntervalType();

            intervalType.dtstart = new dtstart();
            intervalType.dtstart.datetime = startUTC;

            intervalType.duration = new DurationPropType();
            intervalType.duration.duration = "PT" + duration.ToString() + durationModifier.Value;

            IntervalTypeWrapper wrapper = new IntervalTypeWrapper();
            // wrapper.interval = intervalType;
            wrapper.rid = rid;

            m_reportIntervals.Add(wrapper);
        }*/

        /**********************************************************/

        private void addIntervalPayload(DateTime startUTC, string rid, oadrReportPayloadType reportPayload, int duration = -1, DurationModifier durationModifier = null)
        {

            List<StreamPayloadBaseType> intervalPayloads;

            string key = startUTC.ToString();

            IntervalType interval;

            if (!m_reportIntervals.ContainsKey(key))
            {             
                interval = helper.OadrObjectFactory.createIntervalType(startUTC, duration, durationModifier);

                m_reportIntervals.Add(key, interval);

                m_reportIntervalPayloads.Add(key, new List<StreamPayloadBaseType>());
            }

            // if an interval contains an 'interval' and 'point data', duration must be present
            // conformance rule 342 provides rules for when dtstart and duration must be present, but fails
            // to specify what should be done when both 'interval' and 'point data' are present
            // the OADR alliance said dtstart and duration should be present if both types of data are present
            interval = m_reportIntervals[key];

            if (interval.duration == null && duration != -1)
                m_reportIntervals[key] = helper.OadrObjectFactory.createIntervalType(startUTC, duration, durationModifier); ;

            intervalPayloads = m_reportIntervalPayloads[key];
            intervalPayloads.Add(reportPayload);
        }

        /**********************************************************/

        public void addIntervalReportPayload(DateTime startUTC, string rID, uint confidence, float accuracy, float payload, DataQuality dataQuality, int duration = -1, DurationModifier durationModifier = null)
        {
            oadrReportPayloadType reportPayload = new oadrReportPayloadType();

            reportPayload.rID = rID;
            reportPayload.confidence = confidence;
            reportPayload.accuracy = accuracy;

            reportPayload.oadrDataQuality = dataQuality.QualityType;

            PayloadFloatType payloadFloat = new PayloadFloatType();
            payloadFloat.value = payload;

            reportPayload.Item = payloadFloat;

            addIntervalPayload(startUTC, rID, reportPayload, duration, durationModifier);
        }

        /**********************************************************/

        public void addIntervalResourceStatus(DateTime startUTC, string rID, uint confidence, float accuracy, DataQuality dataQuality, bool online, bool manualOverride,
            float capacityMin, float capacityMax, float capacityCurrent, float capacityNormal,
            float levelOffsetMin, float levelOffsetMax, float levelOffsetCurrent, float levelOffsetNormal,
            float percentOffsetMin, float percentOffsetMax, float percentOffsetCurrent, float percentOffsetNormal,
            float setPointMin, float setPointMax, float setPointCurrent, float setPointNormal, int duration = -1, DurationModifier durationModifier = null)
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

            addIntervalPayload(startUTC, rID, reportPayload, duration, durationModifier);
        }
    }
}
