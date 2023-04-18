using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using Oadr.Ven.UserControls;
using System;
using System.Collections.Generic;

namespace Oadr.Ven
{
    public interface IVenWrapper
    {
        void ProcessException(Exception ex);

        void ProcessCreatePartyRegistration(CreatePartyRegistration createPartyRegistration);
        
        void ProcessQueryRegistration(QueryRegistration queryRegistration);
        
        void ProcessCancelRegistration(CancelPartyRegistration cancelRegistration);
        
        void ProcessCanceledRegistration(CanceledPartyRegistration cancelRegistration);

        void ProcessCreatedEvent(CreatedEvent createdEvent, Dictionary<string, OadrEventWrapper> activeEvents, string requestId);
        
        void ProcessRequestEvent(RequestEvent requestEvent);

        void ProcessUpdateStatus(string status, bool threadStopped);

        void ProcessPoll(OadrPoll oadrPoll);

        void ProcessCreateOptSchedule(CreateOpt createOpt);
        
        void ProcessCreateOpt(CreateOpt createOpt);
        
        void ProcessCancelOpt(CancelOpt cancelOpt);

        void ProcessRegisteredReport(RegisteredReport registeredReport);
        
        void ProcessRegisterReport(RegisterReport registerReport);
        
        void ProcessUpdateReportList(oadrRegisterReportType registerReport);
        
        void ProcessCreateReport(oadrReportRequestType[] reportRequests);
        
        void ProcessCreatedReport(CreatedReport createdReport);
        
        void ProcessUpdateReport(UpdateReport updateReport);        
        
        void ProcessCreateReportComplete(string reportRequestId);

        void ProcessCanceledReport(CanceledReport canceledReport, oadrCancelReportType cancelReport);
        
        void ProcessCancelReport(oadrCancelReportType cancelReport);

        void UpdateEventStatus(List<oadrDistributeEventTypeOadrEvent> oadrEvents);

        void LogSystemMessage(string message, LogMessageStatus status);
    }
}
