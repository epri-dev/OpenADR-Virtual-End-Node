using Oadr.Library.Http;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class Ven2B : Ven
    {
        public string RegistrationId { get; set; } = string.Empty;

        public string VtnId { get; set; } = string.Empty;

        public bool IsRegistered
        {
            get
            {
                if (string.IsNullOrEmpty(RegistrationId))
                {
                    return false;
                }
                return true;
            }
        }

        public Ven2B(IHttpService httpService, string url, string venName, string venId, string password = "") 
            : base(httpService, url, venName, venId: venId, password: password)
        {            
        }

        protected object PostRequest(string requestBody, string endPoint, OadrRequest2B oadrRequest, bool expectingOadrResponse = false)            
        {
            oadrRequest.ResponsePayload = (oadrPayload)base.PostRequest(requestBody, endPoint, oadrRequest, typeof(oadrPayload));
            if (oadrRequest.HttpResponseCode == 200)
            {
                if (oadrRequest.ResponsePayload?.oadrSignedObject != null)
                {
                    // Certain error conditions on the server will cause an oadrResponse to be returned.
                    // Return null if an oadrResponse was returned so the caller doesn't throw an error when
                    // attempting to cast the object to the incorrect type.
                    if (!expectingOadrResponse && oadrRequest.ResponsePayload.oadrSignedObject.Item.GetType() == typeof(oadrResponseType))
                    {
                        oadrRequest.SetEiResponse(((oadrResponseType)oadrRequest.ResponsePayload.oadrSignedObject.Item).eiResponse);
                        return null;
                    }
                    return oadrRequest.ResponsePayload.oadrSignedObject.Item;
                }
            }
            return null;
        }
        
        public void ClearRegistration()
        {
            RegistrationId = string.Empty;
            VenId = string.Empty;
        }

        public RequestEvent RequestEvent(uint replyLimit = 0, string requestId = "")
        {
            var request = new RequestEvent();
            var requestBody = request.CreateOadrRequestEvent(VenId, replyLimit, requestId);

            try
            {
                request.Response = (oadrDistributeEventType)PostRequest(requestBody, "/EiEvent", request);
                request.SetEiResponse(request.Response.eiResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            return request;
        }
        
        public CreatedEvent CreatedEvent(string requestId, List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType, int responseCode = 200, string responseDescription = "OK")
        {
            var request = new CreatedEvent();
            var requestBody = request.CreatedOadrCreatedEvent(VenId, requestId, events, optType, responseCode, responseDescription);

            if ((request.Response = (oadrResponseType)PostRequest(requestBody, "/EiEvent", request, true)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
        
        public CreatedEvent CreatedEvent(CreatedEventHelper createdEventHelper, int responseCode = 200, string responseDescription = "OK")
        {
            var request = new CreatedEvent();
            var requestBody = request.CreatedOadrCreatedEvent(createdEventHelper, VenId, responseCode, responseDescription);

            if ((request.Response = (oadrResponseType)PostRequest(requestBody, "/EiEvent", request, true)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
        
        /// <summary>
        /// Use to send error response to oadrDistributeEvent message when an invalid VTN ID is received.
        /// </summary>
        public CreatedEvent CreatedEvent(string requestId, int responseCode, string responseDescription)
        {
            var request = new CreatedEvent();
            var requestBody = request.CreatedOadrCreatedEvent(VenId, requestId, responseCode, responseDescription);

            if ((request.Response = (oadrResponseType)PostRequest(requestBody, "/EiEvent", request, true)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
        
        public CreatePartyRegistration CreatePartyRegistration(
            string requestId,
            oadrProfileType profileType,
            oadrTransportType transportType,
            string oadrTransportAddress,
            bool oadrReportOnly,
            bool oadrXmlSignature,
            bool oadrHttpPullModel)
        {
            var request = new CreatePartyRegistration();
            var requestBody = request.CreateCreatePartyRegistration(requestId, RegistrationId, VenId, profileType, transportType, oadrTransportAddress,
                oadrReportOnly, oadrXmlSignature, VenName, oadrHttpPullModel);

            if ((request.Response = (oadrCreatedPartyRegistrationType)PostRequest(requestBody, "/EiRegisterParty", request)) != null)
            {
                SetVenId(request.Response.venID);
                RegistrationId = request.Response.registrationID;
                VtnId = request.Response.vtnID;
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }

        public QueryRegistration QueryRegistration()
        {
            var request = new QueryRegistration();
            var requestBody = request.CreateQueryRegistration();

            if ((request.Response = (oadrCreatedPartyRegistrationType)PostRequest(requestBody, "/EiRegisterParty", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
                if (!string.IsNullOrEmpty(request.Response.registrationID))
                {
                    SetVenId(request.Response.venID);
                    RegistrationId = request.Response.registrationID;
                    VtnId = request.Response.vtnID;
                }
            }
            return request;
        }
        
        public CancelPartyRegistration CancelPartyRegistration(string requestId = "")
        {
            var request = new CancelPartyRegistration();
            var requestBody = request.CreatePartyRegistration(requestId, VenId, RegistrationId);
            if ((request.Response = (oadrCanceledPartyRegistrationType)PostRequest(requestBody, "/EiRegisterParty", request)) != null)
            {            
                request.SetEiResponse(request.Response.eiResponse);
                if (request.EiResponseCode == 200 && request.Response != null)
                {
                    ClearRegistration();
                }
            }
            return request;
        }
        
        public CanceledPartyRegistration CanceledPartyRegistration(string requestId, int responseCode, string responseDescription)
        {
            var request = new CanceledPartyRegistration();
            var requestBody = request.CreateCanceledPartyRegistration(VenId, RegistrationId, requestId, responseCode, responseDescription);
            if ((request.Response = (oadrResponseType)PostRequest(requestBody, "/EiRegisterParty", request, true)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
                if (request.EiResponseCode == 200 && request.Response != null && responseCode == 200)
                {
                    ClearRegistration();
                }
            }
            return request;
        }

        public OadrPoll Poll()
        {
            var request = new OadrPoll();
            var requestBody = request.CreateOadrPoll(VenId);
            request.Response = PostRequest(requestBody, "/OadrPoll", request, true);
            try
            {
                var values = request.Response.GetType().ToString().Split('.');
                request.ResponseType = values[values.Length - 1].Substring(0, values[values.Length - 1].Length - 4);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }

            // TODO: Get eiResponse code based on type of message that was returned.
            request.EiResponseCode = request.HttpResponseCode;
            request.EiResponseDescription = request.HttpResponseDescription;
            return request;
        }
        
        public RegisteredReport RegisteredReport(string requestId, string responseCode, string responseDescription, oadrReportRequestType[] reportRequests = null)
        {
            var request = new RegisteredReport();
            var requestBody = request.CreateRegisteredReport(requestId, responseCode, responseDescription, VenId, reportRequests);

            if ((request.Response = (oadrResponseType)PostRequest(requestBody, "/EiReport", request, true)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }

        public RegisterReport RegisterReport(string requestId, ReportDescription reportDescription)
        {
            var request = new RegisterReport();
            var requestBody = request.CreateRegisterReport(requestId, VenId, reportDescription);

            if ((request.Response = (oadrRegisteredReportType)PostRequest(requestBody, "/EiReport", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }

        public RegisterReport RegisterReport(string requestId, Dictionary<string, ReportWrapper> reports, string reportRequestId = null)
        {
            var request = new RegisterReport();
            var requestBody = request.CreateRegisterReport(requestId, VenId, reports, reportRequestId);

            if ((request.Response = (oadrRegisteredReportType)PostRequest(requestBody, "/EiReport", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }

        public CreateOpt CreateOptEvent(string requestId, string optId, oadrDistributeEventTypeOadrEvent @event, OptTypeType optType, OptReasonEnumeratedType optReason, string resourceId = null)
        {
            var request = new CreateOpt();
            var requestBody = request.CreateOptEvent(requestId, optId, @event, optType, optReason, VenId, resourceId);

            if ((request.Response = (oadrCreatedOptType)PostRequest(requestBody, "/EiOpt", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }

        public CreateOpt CreateOptSchedule(string requestId, OptSchedule optSchedule)
        {
            var request = new CreateOpt();
            var requestBody = request.CreateOptSchedule(requestId, VenId, optSchedule);

            if ((request.Response = (oadrCreatedOptType)PostRequest(requestBody, "/EiOpt", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
        
        public CancelOpt CreateCancelOpt(string requestId, string optId)
        {
            var request = new CancelOpt();
            var requestBody = request.CreateCancelOpt(requestId, optId, VenId);

            if ((request.Response = (oadrCanceledOptType)PostRequest(requestBody, "/EiOpt", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
        
        public CreatedReport CreatedReport(string requestId, int responseCode, string responseDescription, List<string> pendingReportRequestIds = null)
        {
            var request = new CreatedReport();
            var requestBody = request.CreateCreatedReport(VenId, requestId, responseCode, responseDescription, pendingReportRequestIds);

            if ((request.Response = (oadrResponseType)PostRequest(requestBody, "/EiReport", request, true)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }

        public UpdateReport UpdateReport(string requestId, oadrReportType report, string reportRequestId)
        {
            var request = new UpdateReport();
            var requestBody = request.CreateUpdateReport(VenId, requestId, report, reportRequestId);

            if ((request.Response = (oadrUpdatedReportType)PostRequest(requestBody, "/EiReport", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
        
        [Obsolete]
        public UpdateReport UpdateReport(string requestId, ReportDescription reportDescription, List<string> reportSpecifierIds, DateTime dtStartUtc)
        {
            var request = new UpdateReport();
            var requestBody = request.CreateUpdateReport(VenId, requestId, reportDescription, reportSpecifierIds, dtStartUtc);

            if ((request.Response = (oadrUpdatedReportType)PostRequest(requestBody, "/EiReport", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
        
        [Obsolete]
        public UpdateReport UpdateReport(string requestId, Dictionary<string, ReportWrapper> reports, string reportRequestId)
        {
            var request = new UpdateReport();
            var requestBody = request.CreateUpdateReport(VenId, requestId, reports, reportRequestId);

            if ((request.Response = (oadrUpdatedReportType)PostRequest(requestBody, "/EiReport", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
        
        public CanceledReport CanceledReport(string requestId, int responseCode, string responseDescription, List<string> pendingReportRequestIds = null)
        {
            var request = new CanceledReport();
            var requestBody = request.CreateCanceledReport(VenId, requestId, responseCode, responseDescription, pendingReportRequestIds);

            if ((request.Response = (oadrResponseType)PostRequest(requestBody, "/EiReport", request)) != null)
            {
                request.SetEiResponse(request.Response.eiResponse);
            }
            return request;
        }
    }
}
