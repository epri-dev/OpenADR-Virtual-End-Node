using Oadr.Library.Profile2B.Models;

namespace Oadr.Library.Profile2B
{
    public class RegisteredReport : OadrRequest2B
    {
        public oadrRegisteredReportType Request { get; set; }

        public oadrResponseType Response { get; set; }

        public RegisteredReport()
            : base("oadrRegisteredReport", "oadrResponse")
        {
        }

        public string CreateRegisteredReport(string requestId, string responseCode, string responseDescription, string venId, oadrReportRequestType[] reportRequests = null)
        {
            Request = new oadrRegisteredReportType
            {
                schemaVersion = "2.0b",
                eiResponse = new EiResponseType
                {
                    requestID = requestId,
                    responseCode = responseCode,
                    responseDescription = responseDescription
                },
                venID = venId,
                oadrReportRequest = reportRequests
            };
            return SerializeObject(Request);
        }
    }
}
