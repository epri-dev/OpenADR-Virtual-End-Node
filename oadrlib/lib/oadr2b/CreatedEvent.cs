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

using oadrlib.lib.helper;

namespace oadrlib.lib.oadr2b
{
    public class CreatedEvent : OadrRequest2b
    {
        public oadrCreatedEventType request;
        public oadrResponseType response;

        private List<oadrDistributeEventTypeOadrEvent> updatedEvents;

        public OptTypeType optType;

        /**********************************************************/

        public CreatedEvent() : base("oadrCreatedEvent", "oadrResponse")
        {
        }

        /**********************************************************/

        public string createdOadrCreatedEvent(string venID, string requestID, List<oadrDistributeEventTypeOadrEvent> evts, OptTypeType optType, int responseCode = 200, string responseDescription = "OK")
        {
            this.optType = optType;

            updatedEvents = evts;

            request = new oadrCreatedEventType();

            request.schemaVersion = "2.0b";

            request.eiCreatedEvent = new eiCreatedEvent();

            request.eiCreatedEvent.eiResponse = new EiResponseType();

            if (evts.Count != 0)
                request.eiCreatedEvent.eiResponse.requestID = "";
            else
                request.eiCreatedEvent.eiResponse.requestID = requestID;

            request.eiCreatedEvent.eiResponse.responseCode = responseCode.ToString();
            request.eiCreatedEvent.eiResponse.responseDescription = responseDescription;
            
            request.eiCreatedEvent.venID = venID;

            request.eiCreatedEvent.eventResponses = new eventResponsesEventResponse[evts.Count];

            int index = 0;

            foreach (oadrDistributeEventTypeOadrEvent evt in evts)
            {
                eventResponsesEventResponse eventResponse = new eventResponsesEventResponse();
                
                eventResponse.optType = optType;

                eventResponse.qualifiedEventID = new QualifiedEventIDType();
                eventResponse.qualifiedEventID.eventID = evt.eiEvent.eventDescriptor.eventID;
                eventResponse.qualifiedEventID.modificationNumber = evt.eiEvent.eventDescriptor.modificationNumber;

                // eventResponse.requestID = RandomHex.generateRandomHex(10);
                eventResponse.requestID = requestID;

                eventResponse.responseCode = responseCode.ToString();
                eventResponse.responseDescription = responseDescription;

                request.eiCreatedEvent.eventResponses[index] = eventResponse;
                index++;
            }

            return serializeObject((object)request);
        }

        /**********************************************************/

        public string createdOadrCreatedEvent(CreatedEventHelper createdEventHelper, string venID, int responseCode = 200, string responseDescription = "OK")
        {
            request = new oadrCreatedEventType();

            request.schemaVersion = "2.0b";

            request.eiCreatedEvent = new eiCreatedEvent();

            request.eiCreatedEvent.eiResponse = new EiResponseType();

            if (createdEventHelper.EventResponses.Count != 0)
                request.eiCreatedEvent.eiResponse.requestID = "";
            else
                request.eiCreatedEvent.eiResponse.requestID = RandomHex.instance().generateRandomHex(10); //requestID;

            request.eiCreatedEvent.eiResponse.responseCode = responseCode.ToString();
            request.eiCreatedEvent.eiResponse.responseDescription = responseDescription;

            request.eiCreatedEvent.venID = venID;

            request.eiCreatedEvent.eventResponses = new eventResponsesEventResponse[createdEventHelper.EventResponses.Count];

            int index = 0;

            foreach (eventResponsesEventResponse eventResponse in createdEventHelper.EventResponses)
            {
                request.eiCreatedEvent.eventResponses[index] = eventResponse;
                index++;
            }

            return serializeObject((object)request);

        }

       /**********************************************************/

        public string createdOadrCreatedEvent(string venID, string requestID, int responseCode = 200, string responseDescription = "OK")
        {
            request = new oadrCreatedEventType();

            request.schemaVersion = "2.0b";

            request.eiCreatedEvent = new eiCreatedEvent();

            request.eiCreatedEvent.eiResponse = new EiResponseType();

            request.eiCreatedEvent.eiResponse.requestID = requestID;

            request.eiCreatedEvent.eiResponse.responseCode = responseCode.ToString();
            request.eiCreatedEvent.eiResponse.responseDescription = responseDescription;

            request.eiCreatedEvent.venID = venID;

            return serializeObject((object)request);
        }
    }
}
