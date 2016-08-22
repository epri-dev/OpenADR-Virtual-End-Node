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

namespace oadrlib.lib.oadr2a
{
    public class CreatedEvent : OadrRequest
    {
        public oadrCreatedEvent createdEvent;
        public oadrResponse response;

        public List<oadrDistributeEventOadrEvent> updatedEvents;

        public OptTypeType optType;

        public CreatedEvent() : base("oadrCreatedEvent", "oadrResponse")
        {
        }

        public string createdOadrCreatedEvent(string venID, string requestID, List<oadrDistributeEventOadrEvent> evts, OptTypeType optType, int responseCode = 200, string responseDescription = "OK")
        {
            this.optType = optType;

            updatedEvents = evts;
                 
            createdEvent = new oadrCreatedEvent();

            createdEvent.eiCreatedEvent = new eiCreatedEvent();

            createdEvent.eiCreatedEvent.eiResponse = new eiResponse();

            if (evts.Count != 0)
                createdEvent.eiCreatedEvent.eiResponse.requestID = "";
            else
                createdEvent.eiCreatedEvent.eiResponse.requestID = requestID;

            createdEvent.eiCreatedEvent.eiResponse.responseCode = responseCode.ToString();
            createdEvent.eiCreatedEvent.eiResponse.responseDescription = responseDescription;
            
            createdEvent.eiCreatedEvent.venID = venID;

            createdEvent.eiCreatedEvent.eventResponses = new eventResponsesEventResponse[evts.Count];

            int index = 0;

            foreach (oadrDistributeEventOadrEvent evt in evts)
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

                createdEvent.eiCreatedEvent.eventResponses[index] = eventResponse;
                index++;
            }

            XmlSerializer serializer;

            // serialize the event
            serializer = new XmlSerializer(typeof(oadrCreatedEvent));

            // StringWriter sw = new StringWriter();
            StringWriterWithEncoding sw = new StringWriterWithEncoding(Encoding.UTF8);
            serializer.Serialize(sw, createdEvent);

            requestBody = sw.ToString();

            return requestBody;
        }
    }
}
