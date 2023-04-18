using Oadr.Library.Profile2B.Models;

namespace Oadr.Library.Profile2B
{
    public class CanceledPartyRegistration : OadrRequest2B
    {
        public oadrCanceledPartyRegistrationType Request { get; set; }
        public oadrResponseType Response { get; set; }

        public CanceledPartyRegistration()
            : base("oadrCanceledPartyRegistration", "oadrResponse")
        {
        }

        public string CreateCanceledPartyRegistration(string venId, string registrationId, string requestId, int responseCode, string responseDescription)
        {
            Request = new oadrCanceledPartyRegistrationType
            {
                schemaVersion = "2.0b",
                venID = venId,
                registrationID = registrationId,
                eiResponse = new EiResponseType
                {
                    requestID = requestId,
                    responseCode = responseCode.ToString(),
                    responseDescription = HttpResponseDescription
                }
            };
            return SerializeObject(Request);
        }
    }
}
