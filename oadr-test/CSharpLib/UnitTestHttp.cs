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

using System.Net.Http;

using System.Threading.Tasks;

using System.IO;

using oadrlib.lib.oadr2a;
using oadrlib.lib.http;

namespace oadr_test.CSharpLib
{
    [TestClass]
    public class UnitTestHttp
    {
        private String m_url = "http://192.168.2.117:8080/oadr2a-vtn/OpenADR2/Simple";

        [TestMethod]
        public void httpClientGet()
        {
            
            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = client.GetAsync("http://www.slashdot.org/").Result;
            response.EnsureSuccessStatusCode();

            string responseBody = response.Content.ReadAsStringAsync().Result;
        }

        // http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx
        // DOES NOT WORK! won't post
        // also having an issue with both httpclient and httpwebrequest hanging on occasion
        [TestMethod]
        public void webRequest()
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            RequestEvent requestEvent = new RequestEvent();

            string message = requestEvent.createOadrRequestEvent("TH_VEN");

            System.Net.HttpWebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(m_url + "/EiEvent");

            wr.Method = "POST";
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential("admin", "password");

            wr.ContentType = "application/xml";
            Stream s = wr.GetRequestStream();

            s.Write(Encoding.UTF8.GetBytes(message), 0, message.Length);

            wr.Credentials = nc.GetCredential(wr.RequestUri, "Basic");            

            System.Net.WebResponse response = wr.GetResponse();

            Stream stream = response.GetResponseStream();

            StreamReader streamReader = new StreamReader(stream);

            string responseBody = streamReader.ReadToEnd();

            System.Console.WriteLine(responseBody);
        }

        /***********************************************************************/

        [TestMethod]
        public void venWebRequest()
        {
            VEN2a ven = new VEN2a(new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12), m_url, "TH_VEN", "password");

            RequestEvent requestEvent = ven.requestEvent();
        }

        /***********************************************************************/

        [TestMethod]
        public void invalidBody()
        {
            // VEN2a ven = new VEN2a(new HttpWebRequestWrapper(), m_url, "TH_VEN", "password");

            HttpWebRequestWrapper wr = new HttpWebRequestWrapper(false, System.Net.SecurityProtocolType.Tls12);

            wr.setAuthHeader("asdf");

            wr.post(m_url + "/EiEvent", "application/xml", "");
        }         
    }
}
