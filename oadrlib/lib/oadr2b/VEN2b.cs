//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.Xml.Serialization.Configuration;
using System.IO;

using oadrlib.lib.http;

using oadrlib.lib.helper;

namespace oadrlib.lib.oadr2b
{
    public class VEN2b : VEN
    {
        private string m_registrationId = "";
        private string m_vtnID = "";

        public VEN2b(IHttp http, string url, string venName, string venID, string password = "", HttpSecuritySettings httpSecuritySettings = null) 
            : base(http, url, venName, venID: venID, password: password)
        {            
        }

        /**********************************************************/

        private void deserializeResponse()
        {
        }

        /**********************************************************/

        protected object postRequest(string requestBody, string endPoint, OadrRequest2b oadrRequest, bool expectingOadrResponse = false)            
        {
            oadrRequest.responsePayload = (oadrPayload)base.postRequest(requestBody, endPoint, oadrRequest, typeof(oadrPayload));

            if (oadrRequest.httpResponseCode == 200)
            {
                if (oadrRequest.responsePayload != null && oadrRequest.responsePayload.oadrSignedObject != null)
                {
                    // certain error conditions on the server will cause an oadrResponse to be returned
                    // return null if an oadrResponse was returned so the caller doesn't throw an error when
                    // attempting to cast the object to the incorrect type
                    if (!expectingOadrResponse && oadrRequest.responsePayload.oadrSignedObject.Item.GetType() == typeof(oadrResponseType))
                    {
                        oadrRequest.setEiResponse(((oadrResponseType)oadrRequest.responsePayload.oadrSignedObject.Item).eiResponse);
                        return null;
                    }

                    return oadrRequest.responsePayload.oadrSignedObject.Item;
                }
            }

            return null;
        }

        /**********************************************************/

        public string RegistrationID
        {
            get { return m_registrationId; }
        }

        /**********************************************************/

        public string VTNID
        {
            get { return m_vtnID; }
        }

        /**********************************************************/

        public bool IsRegistered
        {
            get {
                if (m_registrationId == null || m_registrationId == "")
                    return false;
                return true;
            }
        }

        /**********************************************************/

        public void clearRegistration()
        {
            m_registrationId = "";
            VENID = "";
        }

        /**********************************************************/

        public RequestEvent requestEvent(uint replyLimit = 0, string requestID = "")
        {
            RequestEvent request = new RequestEvent();                       
                        
            string requestBody = request.createOadrRequestEvent(VENID, replyLimit, requestID);

            try
            {
                request.response = (oadrDistributeEventType)postRequest(requestBody, "/EiEvent", request);

                request.setEiResponse(request.response.eiResponse);
            }
            catch
            {
            }

            return request;
        }


        /**********************************************************/

        public CreatedEvent createdEvent(string requestID, List<oadrDistributeEventTypeOadrEvent> evts, OptTypeType optType, int responseCode = 200, string responseDescription = "OK")
        {
            CreatedEvent request = new CreatedEvent();

            string requestBody = request.createdOadrCreatedEvent(VENID, requestID, evts, optType, responseCode, responseDescription);

            if ((request.response = (oadrResponseType)postRequest(requestBody, "/EiEvent", request, true)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public CreatedEvent createdEvent(CreatedEventHelper createdEventHelper, int responseCode = 200, string responseDescription = "OK")
        {
            CreatedEvent request = new CreatedEvent();

            string requestBody = request.createdOadrCreatedEvent(createdEventHelper, VENID, responseCode, responseDescription);

            if ((request.response = (oadrResponseType)postRequest(requestBody, "/EiEvent", request, true)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;

        }

        /**********************************************************/

        /// <summary>
        /// use to send error response to distributeEvent message when an invalid VTN ID is received
        /// </summary>
        /// <param name="requestID"></param>
        /// <param name="responseCode"></param>
        /// <param name="responseDescription"></param>
        /// <returns></returns>
        public CreatedEvent createdEvent(string requestID, int responseCode, string responseDescription)
        {
            CreatedEvent request = new CreatedEvent();

            string requestBody = request.createdOadrCreatedEvent(VENID, requestID, responseCode, responseDescription);

            if ((request.response = (oadrResponseType)postRequest(requestBody, "/EiEvent", request, true)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public CreatePartyRegistration createPartyRegistration(string requestID, oadrProfileType profileType, oadrTransportType transportType, string oadrTransportAddress, bool oadrReportOnly, bool oadrXmlSignature, bool oadrHttpPullModel)
        {
            CreatePartyRegistration request = new CreatePartyRegistration();

            string requestBody = request.createPartyRegistration(requestID, m_registrationId, VENID, profileType, transportType, oadrTransportAddress,
                oadrReportOnly, oadrXmlSignature, VENName, oadrHttpPullModel);

            if ((request.response = (oadrCreatedPartyRegistrationType)postRequest(requestBody, "/EiRegisterParty", request)) != null)
            {
                setVENID(request.response.venID);
                m_registrationId = request.response.registrationID;
                m_vtnID = request.response.vtnID;

                request.setEiResponse(request.response.eiResponse);
            }

            

            return request;
        }

        /**********************************************************/

        public QueryRegistration queryRegistration(string requestID = "")
        {
            QueryRegistration request = new QueryRegistration();

            string requestBody = request.createQueryRegistration();

            if ((request.response = (oadrCreatedPartyRegistrationType)postRequest(requestBody, "/EiRegisterParty", request)) != null)
            {
                request.setEiResponse(request.response.eiResponse);

                if (request.response.registrationID != null && request.response.registrationID != "")
                {
                    setVENID(request.response.venID);

                    m_registrationId = request.response.registrationID;
                    m_vtnID = request.response.vtnID;
                }
            }

            return request;
        }

        /**********************************************************/

        public CancelPartyRegistration cancelPartyRegistration(string requestID = "")
        {
            CancelPartyRegistration request = new CancelPartyRegistration();

            string requestBody = request.createPartyRegistration(requestID, VENID, m_registrationId);

            if ((request.response = (oadrCanceledPartyRegistrationType)postRequest(requestBody, "/EiRegisterParty", request)) != null)
            {            
                request.setEiResponse(request.response.eiResponse);

                if (request.eiResponseCode == 200 && request.response != null)
                    clearRegistration();
            }

            return request;
        }

        /**********************************************************/

        public CanceledPartyRegistration canceledPartyRegistration(string requestID,
            int responseCode, string responseDescription)
        {
            CanceledPartyRegistration request = new CanceledPartyRegistration();

            string requestBody = request.createCanceledPartyRegistration(VENID, m_registrationId, requestID, responseCode,
                responseDescription);

            if ((request.response = (oadrResponseType)postRequest(requestBody, "/EiRegisterParty", request, true)) != null)
            {
                request.setEiResponse(request.response.eiResponse);

                if (request.eiResponseCode == 200 && request.response != null && responseCode == 200)
                    clearRegistration();
            }

            return request;
        }

        /**********************************************************/

        public OadrPoll poll()
        {
            OadrPoll request = new OadrPoll();

            string requestBody = request.createOadrPoll(VENID);

            request.response = postRequest(requestBody, "/OadrPoll", request, true);
            
            try
            {
                string []values = request.response.GetType().ToString().Split('.');

                request.responseType = values[values.Length - 1].Substring(0, values[values.Length - 1].Length - 4);
            }
            catch {}

            // TODO: get eiResposne code based on type of message that was returned
            request.eiResponseCode = request.httpResponseCode;
            request.eiResponseDescription = request.httpResponseDescription;

            return request;
        }

        /**********************************************************/

        public RegisteredReport registeredReport(string requestID, string responseCode, string responseDescription, oadrReportRequestType[] reportRequests = null)
        {
            RegisteredReport request = new RegisteredReport();

            string requestBody = request.createRegisteredReport(requestID, responseCode, responseDescription, VENID, reportRequests);

            if ((request.response = (oadrResponseType)postRequest(requestBody, "/EiReport", request, true)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public RegisterReport registerReport(string requestID, ReportDescription reportDescription)
        {
            RegisterReport request = new RegisterReport();

            string requestBody = request.createRegisterReport(requestID, VENID, reportDescription);

            if ((request.response = (oadrRegisteredReportType)postRequest(requestBody, "/EiReport", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public RegisterReport registerReport(string requestID, Dictionary<string, ReportWrapper> reports, string reportRequestID = null)
        {
            RegisterReport request = new RegisterReport();

            string requestBody = request.createRegisterReport(requestID, VENID, reports, reportRequestID);

            if ((request.response = (oadrRegisteredReportType)postRequest(requestBody, "/EiReport", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public CreateOpt createOptEvent(string requestID, string optID, oadrDistributeEventTypeOadrEvent evt, OptTypeType optType, OptReasonEnumeratedType optReason, string resourceID = null)
        {
            CreateOpt request = new CreateOpt();

            string requestBody = request.createOptEvent(requestID, optID, evt, optType, optReason, VENID, resourceID);

            if ((request.response = (oadrCreatedOptType)postRequest(requestBody, "/EiOpt", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public CreateOpt createOptSchedule(string requestID, OptSchedule optSchedule)
        {
            CreateOpt request = new CreateOpt();

            string requestBody = request.createOptSchedule(requestID, VENID, optSchedule);

            if ((request.response = (oadrCreatedOptType)postRequest(requestBody, "/EiOpt", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public CancelOpt createCancelOpt(string requestID, string optID)
        {
            CancelOpt request = new CancelOpt();

            string requestBody = request.createCancelOpt(requestID, optID, VENID);

            if ((request.response = (oadrCanceledOptType)postRequest(requestBody, "/EiOpt", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public CreatedReport createdReport(string requestID, int responseCode, string resposneDescripton, List<string> pendingReportRequestDs = null)
        {
            CreatedReport request = new CreatedReport();

            string requestBody = request.createCreatedReport(VENID, requestID, responseCode, resposneDescripton, pendingReportRequestDs);

            if ((request.response = (oadrResponseType)postRequest(requestBody, "/EiReport", request, true)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        /// <summary>
        /// deprecated
        /// </summary>
        /// <param name="requestID"></param>
        /// <param name="reportDescription"></param>
        /// <param name="reportSpecifierIDs"></param>
        /// <param name="dtstartUTC"></param>
        /// <returns></returns>
        public UpdateReport updateReport(string requestID, ReportDescription reportDescription, List<string> reportSpecifierIDs, DateTime dtstartUTC)
        {
            UpdateReport request = new UpdateReport();

            string requestBody = request.createUpdateReport(VENID, requestID, reportDescription, reportSpecifierIDs, dtstartUTC);

            if ((request.response = (oadrUpdatedReportType)postRequest(requestBody, "/EiReport", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        /// <summary>
        /// deprecated
        /// </summary>
        /// <param name="requestID"></param>
        /// <param name="reports"></param>
        /// <param name="dtstartUTC"></param>
        /// <param name="reportRequestID"></param>
        /// <returns></returns>
        public UpdateReport updateReport(string requestID, Dictionary<string, ReportWrapper> reports, string reportRequestID)
        {
            UpdateReport request = new UpdateReport();

            string requestBody = request.createUpdateReport(VENID, requestID, reports, reportRequestID);

            if ((request.response = (oadrUpdatedReportType)postRequest(requestBody, "/EiReport", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public UpdateReport updateReport(string requestID, oadrReportType report, string reportRequestID)
        {
            UpdateReport request = new UpdateReport();

            string requestBody = request.createUpdateReport(VENID, requestID, report, reportRequestID);

            if ((request.response = (oadrUpdatedReportType)postRequest(requestBody, "/EiReport", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }

        /**********************************************************/

        public CanceledReport canceledReport(string requestID,
            int responseCode, string resposneDescripton, List<string> pendingReportRequestIDs = null)
        {
            CanceledReport request = new CanceledReport();

            string requestBody = request.createCanceledReport(VENID, requestID, responseCode, resposneDescripton, pendingReportRequestIDs);

            if ((request.response = (oadrResponseType)postRequest(requestBody, "/EiReport", request)) != null)
                request.setEiResponse(request.response.eiResponse);

            return request;
        }
    }
}
