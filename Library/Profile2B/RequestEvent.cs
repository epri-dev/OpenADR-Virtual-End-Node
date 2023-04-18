using Oadr.Library;
using Oadr.Library.Profile2B.Models;

namespace Oadr.Library.Profile2B
{
    public class RequestEvent : OadrRequest2B
    {
        public oadrRequestEventType Request { get; set; }

        public oadrDistributeEventType Response { get; set; }

        public RequestEvent()
            : base("oadrRequestEvent", "oadrDistributeEvent")
        {
        }

        public string CreateOadrRequestEvent(string venId, uint replyLimit = 0, string requestId = "")
        {            
            Request = new oadrRequestEventType
            {
                schemaVersion = "2.0b",
                eiRequestEvent = new eiRequestEvent
                {
                    venID = venId,
                    requestID = string.IsNullOrWhiteSpace(requestId) ? RandomHex.Instance().GenerateRandomHex(10) : requestId
                }
            };

            if (replyLimit > 0)
            {
                Request.eiRequestEvent.replyLimit = replyLimit;
                Request.eiRequestEvent.replyLimitSpecified = true;
            }
            return SerializeObject(Request);
        }
    }
}
