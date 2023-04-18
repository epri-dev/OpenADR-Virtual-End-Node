using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class UpdateReport : OadrRequest2B
    {
        public oadrUpdateReportType Request { get; set; }

        public oadrUpdatedReportType Response { get; set; }
        
        public UpdateReport()
            : base("oadrUpdateReport", "oadrUpdatedReport")
        {
        }

        public string CreateUpdateReport(string venId, string requestId, ReportDescription reportDescription, List<string> reportSpecifierIds, DateTime dtStartUtc)
        {
            Request = new oadrUpdateReportType
            {
                requestID = requestId,
                schemaVersion = "2.0b",
                venID = venId,
                oadrReport = new oadrReportType[reportSpecifierIds.Count]
            };

            var index = 0;
            foreach (var reportSpecifierId in reportSpecifierIds)
            {
                var report = reportDescription.GenerateReport(reportSpecifierId, dtStartUtc);
                Request.oadrReport[index++] = report;
            }
            return SerializeObject(Request);
        }
        
        public string CreateUpdateReport(string venId, string requestId, Dictionary<string, ReportWrapper> reports, string reportRequestId)
        {
            Request = new oadrUpdateReportType
            {
                requestID = requestId,
                schemaVersion = "2.0b",
                venID = venId,
                oadrReport = new oadrReportType[reports.Count]
            };

            var index = 0;
            foreach (var reportWrapper in reports.Values)
            {
                var report = reportWrapper.GenerateReport(reportRequestId);
                Request.oadrReport[index++] = report;
            }
            return SerializeObject(Request);
        }
        
        public string CreateUpdateReport(string venId, string requestId, oadrReportType report, string reportRequestId)
        {
            Request = new oadrUpdateReportType
            {
                requestID = requestId,
                schemaVersion = "2.0b",
                venID = venId,
                oadrReport = new oadrReportType[1]
            };
            Request.oadrReport[0] = report;
            return SerializeObject(Request);
        }
    }
}
