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
    public class UnitTestVENRegisterParty
    {
        /***********************************************************************************************/

        [TestMethod]
        public void N1_0010_TH_VTN_1()
        {
            VEN2b ven = new VEN2b(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), TestProperties.vtnURL, TestProperties.venName, TestProperties.venID, TestProperties.venPassword);

            QueryRegistration queryRegistration = ven.queryRegistration();

            Assert.IsTrue(queryRegistration.response != null);

            CreatePartyRegistration createPartyRegistration = ven.createPartyRegistration(RandomHex.instance().generateRandomHex(10), oadrProfileType.Item20b, oadrTransportType.simpleHttp, "", false, false, true);

            Assert.IsTrue(createPartyRegistration.response != null);
        }

        /***********************************************************************************************/
        
        [TestMethod]
        public void N1_0020_TH_VTN_1()
        {
            VEN2b ven = new VEN2b(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), TestProperties.vtnURL, TestProperties.venName, TestProperties.venID, TestProperties.venPassword);

            // register
            CreatePartyRegistration createPartyRegistration = ven.createPartyRegistration(RandomHex.instance().generateRandomHex(10), oadrProfileType.Item20b, oadrTransportType.simpleHttp, "", false, false, true);

            Assert.IsTrue(createPartyRegistration.response != null);

            Console.Out.WriteLine(createPartyRegistration.responseBody);

            // POLL
            OadrPoll oadrPoll = ven.poll();

            Assert.IsNotNull(oadrPoll.response);

            Console.Out.WriteLine(oadrPoll.responseBody);

            // First request is registerReport
            Assert.IsTrue(oadrPoll.responseTypeIs(typeof(oadrRegisterReportType)));

            oadrRegisterReportType registerReportType = oadrPoll.getRegisterReportResponse();

            RegisteredReport registeredReport = ven.registeredReport(registerReportType.requestID, "200", "OK");

            Assert.IsNotNull(registeredReport.response);
            Assert.AreEqual(registeredReport.response.eiResponse.responseCode, "200");

            // register our own report
            ReportDescription reportDescription = ReportHelper.generateReportDescription();

            RegisterReport registerReport = ven.registerReport(RandomHex.instance().generateRandomHex(10), reportDescription);

            Assert.IsNotNull(registerReport.response);

            Assert.AreEqual("200", registerReport.response.eiResponse.responseCode);

            Assert.AreEqual(registerReport.request.requestID, registerReport.response.eiResponse.requestID);

        }
    }
}
