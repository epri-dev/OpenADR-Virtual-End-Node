using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class CanceledReport : OadrRequest2B
    {
        public oadrCanceledReportType Request { get; set; }

        public oadrResponseType Response { get; set; }

        public CanceledReport()
            : base("oadrCanceledReport", "oadrResponse")
        {
        }

        public string CreateCanceledReport(string venId, string requestId, int responseCode, string responseDescription, List<string> pendingReportRequestIds = null)
        {
            Request = new oadrCanceledReportType
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
                var index = 0;
                Request.oadrPendingReports = new string[pendingReportRequestIds.Count];
                foreach (var reportRequestId in pendingReportRequestIds)
                {
                    Request.oadrPendingReports[index] = reportRequestId;
                    index++;
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
