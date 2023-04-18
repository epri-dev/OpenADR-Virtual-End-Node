using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Oadr.Library.Http
{
    public class HttpService : IHttpService
    {
        private HttpWebRequest _httpRequest;
        private HttpWebResponse _httpResponse;
        private string _credentials;
        private string _responseBody;
        private string _requestBody;
        private double _responseTime;
        private string _serverDate;

        public HttpService(bool disableHostnameCheck, SecurityProtocolType tlsVersion)
        {
            if (disableHostnameCheck)
            {
                SetServerCertificateValidationCallback(CertificateValidationCallback);

                bool CertificateValidationCallback(object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                {
                    return true;
                }
            }
            SetTlsVersion(tlsVersion);
        }

        public void SetAuthenticationHeader(string credentials)
        {
            _credentials = credentials;
        }

        public string GetRequestBody()
        {
            return _requestBody;
        }

        public string GetResponseBody()
        {
            return _responseBody;
        }

        public string GetResponseMessage()
        {
            return _httpResponse == null ? string.Empty :  _httpResponse.StatusDescription;
        }

        public int GetResponseCode()
        {
            return _httpResponse == null ? 0 : (int)_httpResponse.StatusCode;
        }

        public double GetResponseTime()
        {
            return _responseTime;
        }

        public string GetServerDate()
        {
            return _serverDate;
        }

        public void SetTlsVersion(SecurityProtocolType protocol)
        {
            ServicePointManager.SecurityProtocol = protocol;
        }

        public void SetServerCertificateValidationCallback(RemoteCertificateValidationCallback callback)
        {
            ServicePointManager.ServerCertificateValidationCallback = callback;
        }
        
        public void Post(string url, string contentType, string content, X509Certificate2Collection certificatesCollection = null)
        {
            var start = DateTime.Now;

            _requestBody = content;
            ServicePointManager.Expect100Continue = false;

            _httpRequest = (HttpWebRequest)WebRequest.Create(url);

            // Adding client certificate for TLSv1.2 connections 
            if (certificatesCollection != null)
            {
                _httpRequest.ClientCertificates = certificatesCollection;
            }

            _httpRequest.Timeout = 60000;
            _httpRequest.Method = "POST";
            _httpRequest.ContentType = contentType;
            _httpRequest.Headers.Add("Authorization: Basic " + _credentials);

            var stream = _httpRequest.GetRequestStream();
            stream.Write(Encoding.UTF8.GetBytes(content), 0, content.Length);
            // Using SSL/TLS, this can fail with the WebException:
            // "The underlying connection was closed: Could not establish trust relationship 
            // for the SSL/TLS secure channel." with InnerException:
            // "The remote certificate is invalid according to the validation procedure."
            // If this occurs, make sure the correct CA certificates are imported into the
            // Windows certificate stores. Make sure you are using the proper DNS name 
            // for the OpenADR VTN and NOT using the IP address.- Tom von Clef
            _httpResponse = (HttpWebResponse)_httpRequest.GetResponse();

            if (_httpResponse == null)
            {
                return;
            }

            _serverDate = _httpResponse.Headers[HttpResponseHeader.Date];
            stream = _httpResponse.GetResponseStream();
            if (stream != null)
            {
                var streamReader = new StreamReader(stream);
                _responseBody = streamReader.ReadToEnd();
            }

            var stop = DateTime.Now;
            _responseTime = (stop - start).TotalSeconds;
        }
    }
}
