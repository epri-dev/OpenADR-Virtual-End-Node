using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Oadr.Library
{
    internal class OadrCertificatePolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return true;
        }
    }
}
