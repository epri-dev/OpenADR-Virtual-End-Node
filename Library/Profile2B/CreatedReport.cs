using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class CreatedReport : OadrRequest2B
    {
        public oadrCreatedReportType Request { get; set; }

        public oadrResponseType Response { get; set; }

        public CreatedReport()
            : base("oadrCreatedReport", "oadrResponse")
        {
        }

        public string CreateCreatedReport(string venId, string requestId, int responseCode, string responseDescription, List<string> pendingReportRequestIds)
        {
            Request = new oadrCreatedReportType
            {
                eiResponse = new EiResponseType
                {
                    requestID = requestId,
                    responseCode = responseCode.ToString(),
                    responseDescription = HttpResponseDescription
                },
                schemaVersion = "2.0b",
                venID = venId
            };

            if (pendingReportRequestIds != null)
            {
                Request.oadrPendingReports = new string[pendingReportRequestIds.Count];
                var index = 0;
                foreach (var specifierId in pendingReportRequestIds)
                {
                    Request.oadrPendingReports[index++] = specifierId;
                }
            }
            else
            {
                Request.oadrPendingReports = new string[1];
            }
            return SerializeObject(Request);
        }
    }
}
