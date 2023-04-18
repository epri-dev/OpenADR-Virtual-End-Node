using Oadr.Library;
using Oadr.Library.Profile2B.Models;

namespace Oadr.Library.Profile2B
{
    public class CancelPartyRegistration : OadrRequest2B
    {
        public oadrCancelPartyRegistrationType Request { get; set; }

        public oadrCanceledPartyRegistrationType Response { get; set; }

        public CancelPartyRegistration()
            : base("oadrCancelPartyRegistration", "oadrCanceledPartyRegistration")
        {
        }

        public string CreatePartyRegistration(string requestId, string venId, string registrationId)
        {
            Request = new oadrCancelPartyRegistrationType
            {
                schemaVersion = "2.0b",
                requestID = !string.IsNullOrWhiteSpace(requestId) ? requestId : RandomHex.Instance().GenerateRandomHex(10),
                registrationID = registrationId,
                venID = venId
            };
            return SerializeObject(Request);
        }
    }
}
