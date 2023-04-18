using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Oadr.Library.Http
{
    public interface IHttpService
    {
        void SetAuthenticationHeader(string credentials);

        string GetRequestBody();

        string GetResponseBody();

        string GetResponseMessage();

        int GetResponseCode();

        double GetResponseTime();

        string GetServerDate();

        void SetTlsVersion(SecurityProtocolType protocol);

        void SetServerCertificateValidationCallback(RemoteCertificateValidationCallback callback);

        void Post(string url, string contentType, string content, X509Certificate2Collection certificatesCollection);
    }
}
