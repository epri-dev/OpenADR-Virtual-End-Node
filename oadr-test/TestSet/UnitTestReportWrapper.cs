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
using Microsoft.VisualStudio.TestTools.UnitTesting;

using oadrlib.lib.oadr2b;

using oadr_test.helper;

namespace oadr_test.TestSet
{
    [TestClass]
    public class UnitTestReportWrapper
    {
        private void addIntervalResourceStatus(ReportWrapper reportWrapper, string rid, DateTime dtstart, float capacityMin)
        {
            reportWrapper.addDescriptionStatus(rid, "resourceid", "http://MarketContext1", 10, 10, false, DurationModifier.SECONDS);

            reportWrapper.addIntervalResourceStatus(dtstart.ToUniversalTime(), rid, 1, 1, DataQuality.qualityGoodNonSpecific, true,
                false, (float)capacityMin, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0);
        }

        /************************************************************************************************************************/

        private void addIntervalEnergy(ReportWrapper reportWrapper, string rid, DateTime dtstart, float value)
        {
            reportWrapper.addDescriptionEnergyItem(rid, "resourceid", ReportEnumeratedType.usage, ReadingTypeEnumeratedType.DirectRead,
                "http://MarketContext1", 1, 1, false, DurationModifier.MINUTES, eEnergyItemType.EnergyReal, "", "kWh", SiScaleCodeType.n);            

            reportWrapper.addIntervalReportPayload(dtstart, rid, 1, 1, value, DataQuality.qualityGoodNonSpecific, 1, DurationModifier.MINUTES);            
        }

        /************************************************************************************************************************/

        /**
         * after generating a report, the intervals should be cleared
         */ 
        [TestMethod]
        public void intervalsCleared()
        {
            ReportWrapper reportWrapper = new ReportWrapper("specifier1", ReportName.TELEMETRY_USAGE, 5, DurationModifier.HOURS);

            DateTime start = DateTime.Now.ToUniversalTime();

            start = start.AddMilliseconds(-start.Millisecond);
            start = start.AddSeconds(-start.Second);

            addIntervalResourceStatus(reportWrapper, "rid1", start, (float)3.0);

            oadrReportType report = reportWrapper.generateReport("requestID");

            Assert.IsTrue(report.intervals.Length == 1, "should have 1 interval");

            report = reportWrapper.generateReport("requestID");

            Assert.IsTrue(report.intervals == null, "intervals should be null when no payloads are added to report");
        }

        /************************************************************************************************************************/

        /**
         * Ensure intervals are reported from newest to oldest
         */
        [TestMethod]
        public void properOrder()
        {
            ReportWrapper reportWrapper = new ReportWrapper("specifier1", ReportName.TELEMETRY_USAGE, 5, DurationModifier.HOURS);

            DateTime start = DateTime.Now.ToUniversalTime();

            start = start.AddMilliseconds(-start.Millisecond);
            start = start.AddSeconds(-start.Second);

            addIntervalResourceStatus(reportWrapper, "rid1", start, (float)3.0);
            addIntervalResourceStatus(reportWrapper, "rid2", start.AddSeconds(30), (float)2.0);
            addIntervalResourceStatus(reportWrapper, "rid3", start.AddSeconds(60), (float)1.0);
            addIntervalResourceStatus(reportWrapper, "rid4", start.AddSeconds(-30), (float)4.0);
            addIntervalResourceStatus(reportWrapper, "rid5", start.AddSeconds(-50), (float)5.0);
            addIntervalResourceStatus(reportWrapper, "rid6", start.AddSeconds(90), (float)0.0);

            oadrReportType report = reportWrapper.generateReport("requestID");

            Assert.IsTrue(report.dtstart.datetime == report.intervals[0].dtstart.datetime);
            
            for (int index = 0; index < report.intervals.Length - 1; index++)
            {
                oadrReportPayloadType reportPayload = (oadrReportPayloadType)report.intervals[index].streamPayloadBase[0];
                oadrPayloadResourceStatusType status = (oadrPayloadResourceStatusType)reportPayload.Item;                

                Assert.IsTrue(report.intervals[index].dtstart.datetime > report.intervals[index + 1].dtstart.datetime);
                Assert.AreEqual(index, (int)status.oadrLoadControlState.oadrCapacity.oadrMin);
            }

            string xml = SerializeOadrObject.serializeOjbect(report, report.GetType());

            Console.Out.WriteLine(xml);
        }

        /************************************************************************************************************************/

        /**
         * RID's with the same dtstart should be placed under the same interval
         */
        [TestMethod]
        public void singleInterval()
        {
            ReportWrapper reportWrapper = new ReportWrapper("specifier1", ReportName.TELEMETRY_USAGE, 5, DurationModifier.HOURS);

            DateTime start = DateTime.Now.ToUniversalTime();

            start = start.AddMilliseconds(-start.Millisecond);
            start = start.AddSeconds(-start.Second);

            addIntervalResourceStatus(reportWrapper, "rid1", start, (float)1.0);
            addIntervalResourceStatus(reportWrapper, "rid2", start, (float)2.0);
            
            oadrReportType report = reportWrapper.generateReport("requestID");

            Assert.IsTrue(report.dtstart.datetime == report.intervals[0].dtstart.datetime);

            Assert.IsTrue(report.intervals.Length == 1, "data with same dtstart should be placed in a single interval");

            string xml = SerializeOadrObject.serializeOjbect(report, report.GetType());

            Console.Out.WriteLine(xml);
        }

        /************************************************************************************************************************/

        /**
         * if point data and inteval data are contained in the same interval, duration should be present
         */
        [TestMethod]
        public void durationExists()
        {
            ReportWrapper reportWrapper = new ReportWrapper("specifier1", ReportName.TELEMETRY_USAGE, 5, DurationModifier.HOURS);

            DateTime start = DateTime.Now.ToUniversalTime();

            start = start.AddMilliseconds(-start.Millisecond);
            start = start.AddSeconds(-start.Second);

            addIntervalResourceStatus(reportWrapper, "rid1", start, (float)1.0);

            addIntervalEnergy(reportWrapper, "rid2", start, (float)1234.0);

            oadrReportType report = reportWrapper.generateReport("requestID");

            string xml = SerializeOadrObject.serializeOjbect(report, report.GetType());

            Console.Out.WriteLine(xml);

            Assert.IsTrue(report.intervals[0].duration != null, "interval with 'interva' and 'point' data must have duration");
        }
    }
}
