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

namespace oadr_test.CSharpLib
{
    [TestClass]
    public class UnitTestSerializeDeserialize
    {
        /***********************************************************************************************/

        [TestMethod]
        public void createRegisterReport()
        {
            oadrPayload payload = new oadrPayload();

            oadrSignedObject signedObject = new oadrSignedObject();
            payload.oadrSignedObject = signedObject;

            oadrRegisterReportType registerReport = new oadrRegisterReportType();

            signedObject.Item = registerReport;

            registerReport.reportRequestID = "ReportRequestID_123";
            registerReport.requestID = "RequestID_123";
            registerReport.schemaVersion = "2.0b";
            registerReport.venID = "TH_VEN";

            registerReport.oadrReport = new oadrReportType[1];

            registerReport.oadrReport[0] = new oadrReportType();

            registerReport.oadrReport[0].reportName = "ReportName_123";

            registerReport.oadrReport[0].intervals = new IntervalType[1];
            registerReport.oadrReport[0].intervals[0] = new IntervalType();

            // refID ???
            IntervalTypeUidUid uid = new IntervalTypeUidUid();
            uid.text = "UID";
            registerReport.oadrReport[0].intervals[0].Item = uid;

            oadrReportPayloadType reportPayload = new oadrReportPayloadType();

            reportPayload.rID = "rID";
            reportPayload.accuracy = 1.0F;
            reportPayload.accuracySpecified = true;

            registerReport.oadrReport[0].intervals[0].streamPayloadBase = new StreamPayloadBaseType[1];

            registerReport.oadrReport[0].intervals[0].streamPayloadBase[0] = reportPayload;

            Assert.IsTrue(registerReport.oadrReport[0].intervals[0].streamPayloadBase[0].GetType() == typeof(oadrReportPayloadType));

            XmlSerializer serializer = new XmlSerializer(typeof(oadrPayload));

            serializer.Serialize(Console.Out, payload);
        }

        /***********************************************************************************************/

        [TestMethod]
        public void reportGeneration()
        {
            ReportDescription reportDescription = ReportHelper.generateReportDescription();

            RegisterReport registerReport = new RegisterReport();

            string output = registerReport.createRegisterReport(RandomHex.instance().generateRandomHex(10),
                "TH_VEN", reportDescription);

            Console.Out.WriteLine(output);

            Assert.IsTrue(output.Contains("x-notApplicable"));
            Assert.IsTrue(output.Contains("x-resourceStatus"));

            object oadrObject = SerializeOadrObject.deserializeObject(output, typeof(oadrPayload));
        }

        /***********************************************************************************************/

        [TestMethod]
        public void serializeItemBaseType()
        {
            EnergyApparentType energyApparent = new EnergyApparentType();

            energyApparent.itemDescription = "description";
            energyApparent.itemUnits = "units";
            energyApparent.siScaleCode = SiScaleCodeType.n;

            string output = SerializeOadrObject.serializeOjbect(energyApparent, typeof(EnergyApparentType));

            oadrReportDescriptionType reportDescription = new oadrReportDescriptionType();

            reportDescription.itemBase = energyApparent;
            
            output = SerializeOadrObject.serializeOjbect(reportDescription, typeof(oadrReportDescriptionType));

            // energy real
            EnergyRealType energyReal = new EnergyRealType();
            energyReal.itemDescription = "description";
            energyReal.itemUnits = "units";
            energyReal.siScaleCode = SiScaleCodeType.n;

            reportDescription.itemBase = energyReal;

            output = SerializeOadrObject.serializeOjbect(reportDescription, typeof(oadrReportDescriptionType));

            // power real
            PowerRealType powerReal = new PowerRealType();
            powerReal.itemDescription = "description";
            powerReal.itemUnits = "units";
            powerReal.siScaleCode = SiScaleCodeType.n;
            powerReal.powerAttributes = new PowerAttributesType();
            powerReal.powerAttributes.ac = true;
            powerReal.powerAttributes.hertz = 60;
            powerReal.powerAttributes.voltage = 110;

            reportDescription.itemBase = powerReal;

            output = SerializeOadrObject.serializeOjbect(reportDescription, typeof(oadrReportDescriptionType));

            Assert.IsTrue(output.Contains("powerReal"));
        }


        /***********************************************************************************************/

        [TestMethod]
        public void serializeInterval()
        {
            IntervalType intervalType = new IntervalType();

            IntervalTypeUidUid intervalTypeUID = new IntervalTypeUidUid();
            intervalTypeUID.text = "0";

            intervalType.Item = intervalTypeUID;

            string output = SerializeOadrObject.serializeOjbect(intervalType, typeof(IntervalType));

            Assert.IsTrue(output.Contains("<text>0</text>"));
            Assert.IsTrue(output.Contains("uid"));
        }

        /***********************************************************************************************/

        [TestMethod]
        public void serializeReportIntervalsTelemetryUsage()
        {
            ReportDescription reportDescription = new ReportDescription();

            reportDescription.addReport("specifierID", ReportName.TELEMETRY_USAGE, 0, DurationModifier.MINUTES);

            int uid = reportDescription.addInterval("specifierID", DateTime.UtcNow, 0, DurationModifier.SECONDS);

            reportDescription.addIntervalReportPayload("specifierID", uid, "rid", 1, (float)1.0, (float)22.3, DataQuality.qualityGoodNonSpecific);
            reportDescription.addIntervalReportPayload("specifierID", uid, "rid2", 1, (float)1.0, (float)41.3, DataQuality.qualityGoodNonSpecific);

            reportDescription.addIntervalReportPayload("specifierID", DateTime.UtcNow.AddMinutes(5), 0, DurationModifier.SECONDS, "rid3", 1, (float)1.0, (float)57.6, DataQuality.qualityGoodNonSpecific);

            oadrReportType report = reportDescription.generateReport("specifierID", DateTime.UtcNow);

            // check that the createdDateTime is properly set to the current time
            Console.Out.WriteLine(DateTime.UtcNow - report.createdDateTime);
            Assert.IsTrue((DateTime.UtcNow - report.createdDateTime).Seconds < 5);

            string output = SerializeOadrObject.serializeOjbect(report, typeof(oadrReportType));

            Assert.IsTrue(output.Contains("<oadrReportPayload"));
            Assert.IsTrue(output.Contains("<payloadFloat"));
        }

        /***********************************************************************************************/

        [TestMethod]
        public void serializeReportIntervalsTelemetryStatus()
        {
            ReportDescription reportDescription = new ReportDescription();

            reportDescription.addReport("specifierID", ReportName.TELEMETRY_STATUS, 0, DurationModifier.MINUTES);

            reportDescription.addIntervalResourceStatus("specifierID", DateTime.UtcNow, 0, DurationModifier.SECONDS, "rid", 1, (float)1.0, DataQuality.qualityGoodNonSpecific,
                true, false, (float)1.0, (float)2.0, (float)3.0, (float)4.0, (float)5.0, (float)6.0, (float)7.0, (float)8.0, (float)9.0,
                (float)10.0, (float)11.0, (float)12.0, (float)13.0, (float)14.0, (float)15.0, (float)16.0);

            oadrReportType report = reportDescription.generateReport("specifierID", DateTime.UtcNow);

            string output = SerializeOadrObject.serializeOjbect(report, typeof(oadrReportType));
            
            Assert.IsTrue(output.Contains("<oadrReportPayload"));
            Assert.IsTrue(output.Contains("<oadrPayloadResourceStatus"));
        }
    }
}
