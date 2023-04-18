using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class RegisterReport : OadrRequest2B
    {
        public oadrRegisterReportType Request { get; set; }

        public oadrRegisteredReportType Response { get; set; }

        public RegisterReport()
            : base("oadrRegisterReport", "oadrRegisteredReport")
        {
        }

        public string CreateRegisterReport(string requestId, string venId, ReportDescription reportDescription)
        {
            Request = new oadrRegisterReportType
            {
                schemaVersion = "2.0b",
                requestID = requestId,
                venID = venId,
                oadrReport = new oadrReportType[reportDescription.NumReports]
            };

            var index = 0;
            foreach (var reportSpecifierId in reportDescription.ReportSpecifierIDs)
            {
                var report = reportDescription.GenerateReportDescription(reportSpecifierId);
                Request.oadrReport[index] = report;
                index++;
            }
            return SerializeObject(Request);
        }        
        
        public string CreateRegisterReport(string requestId, string venId, Dictionary<string, ReportWrapper> reports, string reportRequestId = null)
        {
            Request = new oadrRegisterReportType
            {
                schemaVersion = "2.0b",
                requestID = requestId,
                venID = venId,
                oadrReport = new oadrReportType[reports.Count]
            };

            var index = 0;
            foreach (var reportWrapper in reports.Values)
            {
                var report = reportWrapper.GenerateReportDescription(reportRequestId);
                Request.oadrReport[index] = report;
                index++;
            }
            return SerializeObject(Request);
        }
    }
}
