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

using oadrlib.lib.oadr2a;
using oadrlib.lib.http;

using System.Xml.Serialization;

namespace oadr_test
{
    [TestClass]
    public class UnitTestOadrLib
    {
        private String m_url = "http://192.168.2.117:8080/oadr2a-vtn/OpenADR2/Simple";

        [TestMethod]
        public void createOadrRequestEvent()
        {
            oadrRequestEvent requestEvent = new oadrRequestEvent();

            requestEvent.eiRequestEvent = new eiRequestEvent();

            requestEvent.eiRequestEvent.replyLimit = 10;
            requestEvent.eiRequestEvent.replyLimitSpecified = true;
            requestEvent.eiRequestEvent.requestID = "123";
            requestEvent.eiRequestEvent.venID = "MYVEN";

            XmlSerializer serializer = new XmlSerializer(typeof(oadrRequestEvent));

            serializer.Serialize(Console.Out, requestEvent);
        }

        /***********************************************************************************************/

        [TestMethod]
        // [ExpectedException(typeof(System.Net.Http.HttpRequestException), "invalid ven id was allowed")]
        public void getEventsInvalidVen()
        {
            VEN2a ven = null;
            RequestEvent requestEvent = null;

            try
            {

                // 'invalid ven' must not be configured
                ven = new VEN2a(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), m_url, "invalidven", "password");

                requestEvent = ven.requestEvent();

                Assert.IsTrue(requestEvent.distributeEvent.eiResponse.requestID == requestEvent.requestEvent.eiRequestEvent.requestID);
                Assert.IsTrue(requestEvent.distributeEvent.eiResponse.responseCode == "404");
                Assert.IsTrue(requestEvent.distributeEvent.eiResponse.responseDescription == "Not Found");
            }
            finally
            {
                Console.Out.WriteLine(requestEvent.requestBody);
                Console.Out.WriteLine(requestEvent.responseBody);

                Console.Out.WriteLine(requestEvent.httpResponseDescription);
            }
        }

        /***********************************************************************************************/

        [TestMethod]
        // [ExpectedException(typeof(System.Net.Http.HttpRequestException), "invalid ven id was allowed")]
        public void getEventsInvalidVenWSpace()
        {
            VEN2a ven = null;
            RequestEvent requestEvent = null;

            try
            {

                // 'invalid ven' must not be configured
                ven = new VEN2a(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), m_url, "invalid ven");

                requestEvent = ven.requestEvent();

                Assert.IsTrue(requestEvent.distributeEvent.eiResponse.requestID == requestEvent.requestEvent.eiRequestEvent.requestID);
                Assert.IsTrue(requestEvent.distributeEvent.eiResponse.responseCode == "404");
                Assert.IsTrue(requestEvent.distributeEvent.eiResponse.responseDescription == "Not Found");
            }
            finally
            {
                Console.Out.WriteLine(requestEvent.requestBody);
                Console.Out.WriteLine(requestEvent.responseBody);

                Console.Out.WriteLine(requestEvent.httpResponseDescription);
            }
        }

        /***********************************************************************************************/

        [TestMethod]
        public void getEventsValidVen()
        {
            VEN2a ven = null;
            RequestEvent requestEvent = null;

            // 'TH_VEN' MUST be configured
            try
            {
                ven = new VEN2a(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), m_url, "TH_VEN");

                requestEvent = ven.requestEvent(10, "12345");

                Assert.IsTrue(requestEvent.distributeEvent.eiResponse.requestID == "12345");
            }
            catch (Exception)
            {
                Console.Out.WriteLine(requestEvent.responseBody);
                Assert.Fail();
            }
        }
    }
}
