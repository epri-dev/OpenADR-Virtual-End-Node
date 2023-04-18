using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class CreatedEventHelper
    {
        public List<eventResponsesEventResponse> EventResponses { get; }

        public CreatedEventHelper()
        {
            EventResponses = new List<eventResponsesEventResponse>();
        }

        public void AddEvent(oadrDistributeEventTypeOadrEvent oadrEvent, string requestId, OptTypeType optType, int responseCode = 200, string responseDescription = "OK")
        {
            var eventResponse = new eventResponsesEventResponse
            {
                optType = optType,
                qualifiedEventID = new QualifiedEventIDType
                {
                    eventID = oadrEvent.eiEvent.eventDescriptor.eventID,
                    modificationNumber = oadrEvent.eiEvent.eventDescriptor.modificationNumber
                },
                requestID = requestId,
                responseCode = responseCode.ToString(),
                responseDescription = responseDescription
            };
            EventResponses.Add(eventResponse);
        }
    }
}
