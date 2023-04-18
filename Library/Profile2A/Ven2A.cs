using Oadr.Library;
using Oadr.Library.Http;
using Oadr.Library.Profile2A.Models;
using System.Collections.Generic;

namespace Oadr.Library.Profile2A
{
    public class Ven2A : Ven
    {
        public Ven2A(IHttpService httpService, string url, string venId, string password = "")
            : base(httpService, url, venId, venId: password)
        {
        }

        public RequestEvent RequestEvent(uint replyLimit, string requestId = "")
        {
            var request = new RequestEvent();
            var requestBody = request.CreateOadrRequestEvent(VenId, replyLimit, requestId);
            request.DistributeEvent = (oadrDistributeEvent)PostRequest(requestBody, "/EiEvent", request, typeof(oadrDistributeEvent));
            return request;
        }

        public CreatedEvent CreatedEvent(string requestId, List<oadrDistributeEventOadrEvent> events, OptTypeType optType)
        {
            var createdEvent = new CreatedEvent();
            var requestBody = createdEvent.CreatedOadrCreatedEvent(VenId, requestId, events, optType);
            createdEvent.Response = (oadrResponse)PostRequest(requestBody, "/EiEvent", createdEvent, typeof(oadrResponse));
            return createdEvent;
        }
    }
}
