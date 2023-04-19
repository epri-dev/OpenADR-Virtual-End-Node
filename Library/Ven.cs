using Oadr.Library.Http;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;

namespace Oadr.Library
{
    public class Ven
    {
        private readonly string _basicAuthenticationHeader = string.Empty;
        private readonly IHttpService _httpService;
        private X509Certificate2 _certificate;
        private X509Certificate2Collection _certificatesCollection;
        private string _venId;
        private string _venName;
        
        public string VenId { get; set; }

        public string VenName { get; set; }

        public string Url { get; set; }

        public bool UseSsl { get; set; }

        public bool SignXml { get; set; }

        public Ven(IHttpService httpService, string url, string venName, string venId = "", string password = "")
        {
            _httpService = httpService;
            Url = url;
            _venName = venName;
            _venId = venId;

            if (password != string.Empty)
            {
                _basicAuthenticationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_venId}:{password}"));
            }

            // These callbacks should be triggered when there's a server certificate validation failure.
            // We could use these callbacks to manually validate a server certificate to avoid importing the OADR Alliance CA certificates.
            // System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(this.CheckValidationResult);
            // System.Net.ServicePointManager.CertificatePolicy = new OadrCertificatePolicy();

            // Force the use of SSL 1.2.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        
        protected void SetVenId(string venId)
        {
            _venId = venId;
        }

        protected virtual object PostRequest(string requestBody, string endPoint, OadrRequest oadrRequest, Type responseType)
        {
            if (_basicAuthenticationHeader.Length != 0)
            {
                _httpService.SetAuthenticationHeader(_basicAuthenticationHeader);
            }

            if (SignXml)
            {
                requestBody = XmlSigning.Sign(requestBody, _certificate);
            }
            
            _httpService.Post($"{Url}{endPoint}", "application/xml", requestBody, UseSsl ? _certificatesCollection : null);

            oadrRequest.RequestBody = _httpService.GetRequestBody();
            oadrRequest.ResponseBody = _httpService.GetResponseBody();
            oadrRequest.HttpResponseDescription = _httpService.GetResponseMessage();
            oadrRequest.HttpResponseCode = _httpService.GetResponseCode();
            oadrRequest.ResponseTime = _httpService.GetResponseTime();
            oadrRequest.ServerDate = _httpService.GetServerDate();

            try
            {
                var now = DateTime.Now;
                var serverDate = DateTime.ParseExact(oadrRequest.ServerDate, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture).ToLocalTime();
                oadrRequest.ServerOffset = (int)((serverDate - now).TotalSeconds - oadrRequest.ResponseTime / 2);
            }
            catch
            {
                oadrRequest.ServerOffset = 0;
            }

            // Deserialize the response.
            if (oadrRequest.HttpResponseCode == 200 && oadrRequest.ResponseBody.Length > 0)
            {
                var serializer = new XmlSerializer(responseType);
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(oadrRequest.ResponseBody)))
                {
                    object responseObject;
                    try
                    {
                        responseObject = serializer.Deserialize(ms);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Serialization failed: {oadrRequest.ResponseBody}");
                        Logger.LogException(ex);
                        throw;
                    }

                    // Re-serialize the object to get pretty XML.
                    var sw = new StringWriterWithEncoding(Encoding.UTF8);
                    serializer.Serialize(sw, responseObject);
                    oadrRequest.ResponseBody = sw.ToString();
                    return responseObject;
                }
            }
            return null;
        }

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void LoadCertificateFile(string file, string password)
        {
            _certificate = new X509Certificate2(file, password);
            _certificatesCollection = new X509Certificate2Collection(_certificate);
        }

        public void SetServerCertificateValidationCallback(RemoteCertificateValidationCallback callback)
        {
            _httpService.SetServerCertificateValidationCallback(callback);
        }
    }
}
