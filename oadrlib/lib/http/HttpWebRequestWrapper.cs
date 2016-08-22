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
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using System.Net;

using System.IO;
using System.Net.Security;

namespace oadrlib.lib.http
{
    public class HttpWebRequestWrapper : IHttp 
    {
        private HttpWebRequest m_httpWebRequest;
        private string m_credentials;
        // private X509Certificate2 m_x509Certificate2;
        

        private HttpWebResponse m_webResponse;

        private string m_responseBody;
        private string m_requestBody;

        private double m_responseTime;

        private string m_serverDate;

        public HttpWebRequestWrapper(bool disableHostnameCheck, SecurityProtocolType tlsVersion)
        {

            if (disableHostnameCheck)
            {
                RemoteCertificateValidationCallback callback = delegate(
                            Object obj, X509Certificate certificate, X509Chain chain,
                            SslPolicyErrors errors)
                {
                    if (errors == SslPolicyErrors.RemoteCertificateNameMismatch)
                    {
                        return (true);
                    }

                    return true;
                };

                setServerCertificateValidationCallback(callback);
            }            

            setTLSVersion(tlsVersion);
        }

        /**********************************************************/

        public void setTLSVersion(SecurityProtocolType protocol)
        {
            System.Net.ServicePointManager.SecurityProtocol = protocol;
        }

        /**********************************************************/

        public void setServerCertificateValidationCallback(RemoteCertificateValidationCallback callback)
        {
            ServicePointManager.ServerCertificateValidationCallback = callback;
        }

        /**********************************************************/

        public void setAuthHeader(string credentials)
        {
            m_credentials = credentials;
        }

        /**********************************************************/

        public void post(string url, string contentType, string content, 
                         X509Certificate2Collection certCollection = null)
        {
            DateTime start = DateTime.Now;

            m_requestBody = content;

            System.Net.ServicePointManager.Expect100Continue = false;

            m_httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            // Adding client certificate for TLSv1.2 connections 
            /*if (certCollection != null)
            {
                m_httpWebRequest.ClientCertificates = certCollection;
                // m_httpWebRequest.ClientCertificates.Add(certCollection);
                
            }
            if (m_x509Certificate2 != null)
            {
                m_httpWebRequest.ClientCertificates.Add(m_x509Certificate2);
            }*/

            if (certCollection != null)
                m_httpWebRequest.ClientCertificates = certCollection;

            m_httpWebRequest.Proxy = null;

            m_httpWebRequest.Timeout = 60000;

            m_httpWebRequest.Method = "POST";
            m_httpWebRequest.ContentType = contentType;

            m_httpWebRequest.Headers.Add("Authorization: Basic " + m_credentials);

            Stream stream = m_httpWebRequest.GetRequestStream();

            stream.Write(Encoding.UTF8.GetBytes(content), 0, content.Length);

            try
            {
                // Using SSL/TLS, this can fail with the WebException:
                // "The underlying connection was closed: Could not establish trust relationship 
                // for the SSL/TLS secure channel." with InnerException:
                // "The remote certificate is invalid according to the validation procedure."
                // If this occurs, make sure the correct CA certificates are imported into the
                // Windows certificate stores. Make sure you are using the proper DNS name 
                // for the OpenADR VTN and NOT using the IP address.- Tom von Clef
                m_webResponse = (HttpWebResponse)m_httpWebRequest.GetResponse();
            }
            catch (WebException e)
            {
                // TODO: the caller (outside library code) should identify WebExceptions and
                // log the body of the message to aid in debugging
                throw e;

                // HTTP errors (anything but 200/ok) returned from GetResponse() will cause an exception
                // and the body of the repsonse is in e.Response
                // if no response was returned, rethrow the error
                if (e.Response == null)
                    throw e;

                // There is no real response if the SSL/TLS handshake fails.
                // if (e.Status == WebExceptionStatus.SecureChannelFailure)
                //    throw;

                m_webResponse = (HttpWebResponse)e.Response;
            }

            if (m_webResponse != null)
            {
                m_serverDate = m_webResponse.Headers[HttpResponseHeader.Date];

                stream = m_webResponse.GetResponseStream();

                StreamReader streamReader = new StreamReader(stream);

                m_responseBody = streamReader.ReadToEnd();

                DateTime stop = DateTime.Now;

                m_responseTime = (stop - start).TotalSeconds;
            }
        }

        /**********************************************************/

        public string getServerDate()
        {
            return m_serverDate;
        }

        /**********************************************************/

        public string getRequestBody()
        {
            return m_requestBody;
        }

        /**********************************************************/

        public string getResponseBody()
        {
            return m_responseBody;
        }

        /**********************************************************/

        public string getResponseMessage()
        {
            return (m_webResponse == null ? "" :  m_webResponse.StatusDescription);
        }

        /**********************************************************/

        public int getResponseCode()
        {
            return (m_webResponse == null ? 0 : (int)m_webResponse.StatusCode);
        }

        /**********************************************************/

        public double getResponseTime()
        {
            return m_responseTime;
        }
    }
}
