using Oadr.Library;
using Oadr.Library.Profile2A.Models;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Oadr.Library.Profile2A
{
    public class CreatedEvent : OadrRequest
    {
        public oadrCreatedEvent Event { get; set; }

        public List<oadrDistributeEventOadrEvent> UpdatedEvents { get; set; }

        public oadrResponse Response { get; set; }

        public OptTypeType OptType { get; set; }

        public CreatedEvent() : base("oadrCreatedEvent", "oadrResponse")
        {
        }

        public string CreatedOadrCreatedEvent(
            string venId,
            string requestId,
            List<oadrDistributeEventOadrEvent> events,
            OptTypeType optType,
            int responseCode = 200,
            string responseDescription = "OK")
        {
            OptType = optType;
            UpdatedEvents = events;
            Event = new oadrCreatedEvent
            {
                eiCreatedEvent = new eiCreatedEvent
                {
                    eiResponse = new eiResponse
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
                Event.eiCreatedEvent.eventResponses[index] = eventResponse;
                index++;
            }

            var serializer = new XmlSerializer(typeof(oadrCreatedEvent));
            var sw = new StringWriterWithEncoding(Encoding.UTF8);
            serializer.Serialize(sw, Event);
            RequestBody = sw.ToString();
            return RequestBody;
        }
    }
}
