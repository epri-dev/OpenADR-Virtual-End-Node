using Oadr.Library;
using Oadr.Library.Profile2B.Models;

namespace Oadr.Library.Profile2B
{
    public class QueryRegistration : OadrRequest2B
    {
        public oadrQueryRegistrationType Request { get; set; }

        public oadrCreatedPartyRegistrationType Response { get; set; }

        public QueryRegistration()
            : base("oadrQueryRegistration", "oadrCreatedPartyRegistration")
        {
        }

        public string CreateQueryRegistration(string requestId = default)
        {
            Request = new oadrQueryRegistrationType
            {
                schemaVersion = "2.0b",
                requestID = !string.IsNullOrWhiteSpace(requestId) ? requestId : RandomHex.Instance().GenerateRandomHex(10)
            };
            return SerializeObject(Request);
        }
    }
}
