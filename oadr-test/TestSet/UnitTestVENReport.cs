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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using oadrlib.lib.oadr2b;

using oadrlib.lib.http;

using oadrlib.lib;

using System.Xml.Serialization;

using oadr_test.helper;

namespace oadr_test.TestSet
{
    [TestClass]
    public class UnitTestVENReport
    {
        [TestMethod]
        public void R1_3010_TH_VTN_1()
        {
            VEN2b ven = new VEN2b(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), TestProperties.vtnURL, TestProperties.venName, "", TestProperties.venPassword);

            QueryRegistration queryRegistration = ven.queryRegistration();

            OadrPoll poll = ven.poll();

            poll.responseTypeIs(typeof(oadrCreateReportType));

            oadrCreateReportType createReport = poll.getCreateReportResponse();

            Console.Out.WriteLine(poll.responseBody);

            ReportDescription reportDescription = new ReportDescription();

            reportDescription.addReport(createReport.oadrReportRequest[0].reportSpecifier.reportSpecifierID, ReportName.TELEMETRY_STATUS, 0, DurationModifier.MINUTES);

            DateTime dtstart = DateTime.UtcNow;
            reportDescription.addIntervalResourceStatus(createReport.oadrReportRequest[0].reportSpecifier.reportSpecifierID, dtstart,
                0, DurationModifier.SECONDS, "rid", 1, (float)1.0, DataQuality.qualityGoodNonSpecific, true, false, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0);

            CreatedReport createdReport = ven.createdReport(createReport.requestID, 200, "OK");

            Assert.IsNotNull(createdReport.response);

            List<string> reportSpecifierIDs = new List<string>();

            reportSpecifierIDs.Add(createReport.oadrReportRequest[0].reportSpecifier.reportSpecifierID);

            UpdateReport updateReport = ven.updateReport(createReport.requestID, reportDescription, reportSpecifierIDs, dtstart);

            Assert.IsNotNull(updateReport.response);
        }

        /***********************************************************************************************/

        [TestMethod]
        public void R1_3020_TH_VTN_1()
        {
            VEN2b ven = new VEN2b(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), TestProperties.vtnURL, TestProperties.venName, TestProperties.venID, TestProperties.venPassword);

            OadrPoll poll = ven.poll();

            poll.responseTypeIs(typeof(oadrCreateReportType));

            oadrCreateReportType createReport = poll.getCreateReportResponse();

            Console.Out.WriteLine(poll.responseBody);

            ReportDescription reportDescription = new ReportDescription();

            reportDescription.addReport(createReport.oadrReportRequest[0].reportSpecifier.reportSpecifierID, ReportName.TELEMETRY_STATUS, 0, DurationModifier.MINUTES);


            CreatedReport createdReport = ven.createdReport(createReport.requestID, 200, "OK");

            Assert.IsNotNull(createdReport.response);

            List<string> reportSpecifierIDs = new List<string>();

            int sleepTime = (int)(createReport.oadrReportRequest[0].reportSpecifier.reportInterval.properties.dtstart.datetime - DateTime.UtcNow).TotalSeconds;

            if (sleepTime > 0)
                System.Threading.Thread.Sleep(sleepTime * 1000);

            reportSpecifierIDs.Add(createReport.oadrReportRequest[0].reportSpecifier.reportSpecifierID);

            DateTime endTime = createReport.oadrReportRequest[0].reportSpecifier.reportInterval.properties.dtstart.datetime +
                System.Xml.XmlConvert.ToTimeSpan(createReport.oadrReportRequest[0].reportSpecifier.reportInterval.properties.duration.duration);

            // convert ISO8601 duration to timespan
            // http://stackoverflow.com/questions/62804/how-to-convert-iso-8601-duration-to-timespan-in-vb-net
            // http://msdn.microsoft.com/en-us/library/system.xml.xmlconvert.totimespan.aspx
            int sleepDelay = (int)System.Xml.XmlConvert.ToTimeSpan(createReport.oadrReportRequest[0].reportSpecifier.reportBackDuration.duration).TotalSeconds;

            // the test should continue until the end time has passed, but the test set exits after it receives 2 updates
            // while (DateTime.Now < endTime)
            for (int count = 0; count < 2; count++)
            {
                DateTime dtstart = DateTime.UtcNow;

                reportDescription.addIntervalResourceStatus(createReport.oadrReportRequest[0].reportSpecifier.reportSpecifierID, dtstart,
                    0, DurationModifier.SECONDS, "rid", 1, (float)1.0, DataQuality.qualityGoodNonSpecific, true, false, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                    (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                    (float)1.0, (float)1.0);

                UpdateReport updateReport = ven.updateReport(createReport.requestID, reportDescription, reportSpecifierIDs, dtstart);

                Assert.IsNotNull(updateReport.response);

                if (count == 0)
                    System.Threading.Thread.Sleep(sleepDelay * 1000);
            }
        }
        /***********************************************************************************************/

        [TestMethod]
        public void R1_3025_TH_VTN_1()
        {
            R1_3020_TH_VTN_1();
        }

        /***********************************************************************************************/

        [TestMethod]
        public void R1_3027_TH_VTN_1()
        {
            R1_3020_TH_VTN_1();
        }
    }
}
