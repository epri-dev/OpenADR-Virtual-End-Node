using Oadr.Library;
using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class CreatedEvent : OadrRequest2B
    {
        public oadrCreatedEventType Request { get; set; }

        public oadrResponseType Response { get; set; }

        public OptTypeType OptType { get; set; }
        
        public CreatedEvent() :
            base("oadrCreatedEvent", "oadrResponse")
        {
        }
        
        public string CreatedOadrCreatedEvent(
            string venId,
            string requestId,
            List<oadrDistributeEventTypeOadrEvent> events,
            OptTypeType optType,
            int responseCode = 200,
            string responseDescription = "OK")
        {
            OptType = optType;

            Request = new oadrCreatedEventType
            {
                schemaVersion = "2.0b",
                eiCreatedEvent = new eiCreatedEvent
                {
                    eiResponse = new EiResponseType
                    {
                        requestID = events.Count != 0 ? string.Empty : requestId,
                        responseCode = responseCode.ToString(),
                        responseDescription = responseDescription
                    },
                    venID = venId,
                    eventResponses = new eventResponsesEventResponse[events.Count]
                }
            };

            var index = 0;
            foreach (var evt in events)
            {
                var eventResponse = new eventResponsesEventResponse
                {
                    optType = optType,
                    qualifiedEventID = new QualifiedEventIDType
                    {
                        eventID = evt.eiEvent.eventDescriptor.eventID,
                        modificationNumber = evt.eiEvent.eventDescriptor.modificationNumber
                    },
                    requestID = requestId,
                    responseCode = responseCode.ToString(),
                    responseDescription = responseDescription
                };
                Request.eiCreatedEvent.eventResponses[index] = eventResponse;
                index++;
            }

            return SerializeObject(Request);
        }

        public string CreatedOadrCreatedEvent(CreatedEventHelper createdEventHelper, string venId, int responseCode = 200, string responseDescription = "OK")
        {
            Request = new oadrCreatedEventType
            {
                schemaVersion = "2.0b",
                eiCreatedEvent = new eiCreatedEvent
                {
                    eiResponse = new EiResponseType
                    {
                        requestID = createdEventHelper.EventResponses.Count != 0 ? "" : RandomHex.Instance().GenerateRandomHex(10),
                        responseCode = responseCode.ToString(),
                        responseDescription = responseDescription
                    },
                    venID = venId,
                    eventResponses = new eventResponsesEventResponse[createdEventHelper.EventResponses.Count]
                }
            };

            var index = 0;
            foreach (var eventResponse in createdEventHelper.EventResponses)
            {
                Request.eiCreatedEvent.eventResponses[index] = eventResponse;
                index++;
            }
            return SerializeObject(Request);
        }

        public string CreatedOadrCreatedEvent(string venId, string requestId, int responseCode = 200, string responseDescription = "OK")
        {
            Request = new oadrCreatedEventType
            {
                schemaVersion = "2.0b",
                eiCreatedEvent = new eiCreatedEvent
                {
                    eiResponse = new EiResponseType
                    {
                        requestID = requestId,
                        responseCode = responseCode.ToString(),
                        responseDescription = responseDescription
                    },
                    venID = venId
                }
            };
            return SerializeObject(Request);
        }
    }
}
