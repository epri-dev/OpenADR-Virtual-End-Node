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
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;

using System.Net.Http;

using oadrlib.lib;

using System.Xml.Serialization;
using System.Xml.Serialization.Configuration;
using System.IO;

using oadrlib.lib.http;

using oadrlib.lib.helper;
using System.Globalization;

namespace oadrlib.lib.helper
{
    public class VEN
    {
        private string m_url;
        private string m_venID;
        private string m_venName;
        private string m_password;
        private string m_basicAuthHeader = "";
        X509Certificate2Collection m_x509CertificateCollection = null;
        bool m_useSSL = false;

        private IHttp m_http;

        /**********************************************************/

        public VEN(IHttp http, string url, string venName, string venID = "", string password = "")
        {
            m_http = http;

            m_url = url;
            m_venName = venName;
            m_venID = venID;
            m_password = password;

            if (password != "")
                m_basicAuthHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(m_venID + ":" + password));

            // these callbacks should be triggered when there's a server cert validation failure
            // we could use these callbacks to manually validate a server cert to avoid importing the oadr
            // CA certificates
            // System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(this.CheckValidationResult);
            // System.Net.ServicePointManager.CertificatePolicy = new OadrCertificatePolicy();

            // force the use of SSL 1.2
            // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /**********************************************************/

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {

            return true;
        }

        /**********************************************************/

        public void loadCertificateFile(string file, string password)
        {
            m_x509CertificateCollection = new X509Certificate2Collection(
                                    new X509Certificate2(
                                        file,
                                        password));
        }

        /**********************************************************/

        public void setServerCertificateValidationCallback(RemoteCertificateValidationCallback callback)
        {
            m_http.setServerCertificateValidationCallback(callback);
        }

        /**********************************************************/

        public bool UseSSL 
        {
            get { return m_useSSL; }

            set { m_useSSL = value; }
        }

        /**********************************************************/

        virtual protected object postRequest(string requestBody, string endPoint, OadrRequest oadrRequest, Type responseType)
        {
            object responseObject;

            if (m_basicAuthHeader.Length != 0)
                m_http.setAuthHeader(m_basicAuthHeader);
            
            m_http.post(m_url + endPoint, "application/xml", requestBody, (m_useSSL ? m_x509CertificateCollection : null));

            oadrRequest.requestBody = m_http.getRequestBody();

            oadrRequest.responseBody = m_http.getResponseBody();

            oadrRequest.httpResponseDescription = m_http.getResponseMessage();
            oadrRequest.httpResponseCode = m_http.getResponseCode();

            oadrRequest.responseTime = m_http.getResponseTime();
            oadrRequest.serverDate = m_http.getServerDate();

            try
            {
                DateTime now = DateTime.Now;
                DateTime serverDate = DateTime.ParseExact(oadrRequest.serverDate, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture).ToLocalTime();

                oadrRequest.serverOffset = (int)((serverDate - now).TotalSeconds - (oadrRequest.responseTime / 2));
            }
            catch
            {
                oadrRequest.serverOffset = 0;
            }

            // deserialize the response
            if (oadrRequest.httpResponseCode == 200 && oadrRequest.responseBody.Length > 0)
            {
                XmlSerializer serializer;

                // serialize response into a distribute event
                serializer = new XmlSerializer(responseType);

                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(oadrRequest.responseBody));

                try
                {
                    responseObject = serializer.Deserialize(ms);
                }
                catch (Exception ex)
                {
                    Logger.logError("serialization failed : " + oadrRequest.responseBody);
                    Logger.logException(ex);

                    throw ex;
                }

                ms.Close();

                // reserialize the object to get pretty XML
                StringWriterWithEncoding sw = new StringWriterWithEncoding(Encoding.UTF8);
                serializer.Serialize(sw, responseObject);

                oadrRequest.responseBody = sw.ToString();

                return responseObject;
            }

            return null;
        }

        /**********************************************************/

        public string VENName
        {
            get { return m_venName; }
            set { m_venName = value; }
        }

        /**********************************************************/

        public string VENID
        {
            get { return m_venID; }
            set { m_venID = value; }
        }

        /**********************************************************/

        protected void setVENID(string venID)
        {
            m_venID = venID;
        }

        /**********************************************************/

        public string URL
        {
            get { return m_url; }
            set { m_url = value; }
        }

        /**********************************************************/

        public string Password
        {
            get { return m_password; }
        }

        /**********************************************************/

        public IHttp HTTP
        {
            get { return m_http; }
        }
    }
}
