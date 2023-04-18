using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Resources
{
    public interface ISendReport
    {
        void SendUpdateReport(oadrReportType report, oadrReportRequestType reportRequest);

        void ProcessCreateReportComplete(string reportRequestId);

        void SendMetadataReport(string reportRequestId);
    }
}
