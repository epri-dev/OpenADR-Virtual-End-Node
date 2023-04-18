using Oadr.Library.Profile2B.Models;

namespace Oadr.Library.Profile2B
{
    public class CreatePartyRegistration : OadrRequest2B
    {
        public oadrCreatePartyRegistrationType Request { get; set; }

        public oadrCreatedPartyRegistrationType Response { get; set; }

        public CreatePartyRegistration()
            : base("oadrCreatePartyRegistration", "oadrCreatedPartyRegistration")
        {
        }

        public string CreateCreatePartyRegistration(
            string requestId,
            string registrationId,
            string venId,
            oadrProfileType profileType, 
            oadrTransportType transportType,
            string oadrTransportAddress,
            bool oadrReportOnly,
            bool oadrXmlSignature,
            string oadrVenName,
            bool oadrHttpPullModel)

        {
            Request = new oadrCreatePartyRegistrationType
            {
                schemaVersion = "2.0b",
                requestID = requestId,
                oadrProfileName = profileType,
                oadrTransportName = transportType,
                oadrTransportAddress = oadrTransportAddress,
                oadrReportOnly = oadrReportOnly,
                oadrXmlSignature = oadrXmlSignature,
                oadrVenName = oadrVenName,
                oadrHttpPullModel = oadrHttpPullModel,
                oadrHttpPullModelSpecified = true
            };

            if (!string.IsNullOrEmpty(registrationId))
            {
                Request.registrationID = registrationId;
            }
            if (!string.IsNullOrEmpty(venId))
            {
                Request.venID = venId;
            }

            return SerializeObject(Request);
        }
    }
}
