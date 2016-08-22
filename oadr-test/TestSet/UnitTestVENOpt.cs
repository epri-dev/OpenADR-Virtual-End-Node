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

namespace oadr_test
{
    [TestClass]
    public class UnitTestVENOpt
    {

        [TestMethod]
        public void P1_2010_VTN_1()
        {
            VEN2b ven = new VEN2b(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), TestProperties.vtnURL, TestProperties.venID, TestProperties.venPassword);

            OptSchedule optSchedule = new OptSchedule();

            optSchedule.addOptSchedule(DateTime.UtcNow.AddDays(1), 4);
            optSchedule.addOptSchedule(DateTime.UtcNow.AddDays(3), 8);

            optSchedule.OptType = OptTypeType.optIn;
            optSchedule.OptReason = OptReasonEnumeratedType.notParticipating;
            optSchedule.MarketContext = "http://marketcontext1";
            optSchedule.ResourceID = "resource1";
            optSchedule.OptID = RandomHex.instance().generateRandomHex(10);

            CreateOpt createOpt = ven.createOptSchedule(RandomHex.instance().generateRandomHex(10), optSchedule);

            Assert.IsNotNull(createOpt.response);

            Assert.AreEqual(createOpt.request.optID, createOpt.response.optID);

        }

        /**********************************************************/

        // TODO: this test is buggy in the test harness
        // it expects a duration of 0 but crashes if 0 is sent, and succeeds if a druation other than 0 is sent
        [TestMethod]
        public void P1_2015_VTN_1()
        {
            VEN2b ven = new VEN2b(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), TestProperties.vtnURL, TestProperties.venID, TestProperties.venPassword);

            OptSchedule optSchedule = new OptSchedule();

            optSchedule.addOptSchedule(DateTime.UtcNow.AddDays(1), 0);

            optSchedule.OptType = OptTypeType.optIn;
            optSchedule.OptReason = OptReasonEnumeratedType.notParticipating;
            optSchedule.MarketContext = "http://marketcontext1";
            optSchedule.ResourceID = "resource1";

            CreateOpt createOpt = ven.createOptSchedule(RandomHex.instance().generateRandomHex(10), optSchedule);

            Console.Out.WriteLine(createOpt.responseBody);

            Assert.IsNotNull(createOpt.response);

            Assert.AreEqual(createOpt.request.optID, createOpt.response.optID);
        }

    }
}
