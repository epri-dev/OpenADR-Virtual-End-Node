using Oadr.Library;
using Oadr.Library.Profile2A.Models;
using System.Text;
using System.Xml.Serialization;

namespace Oadr.Library.Profile2A
{
    public class RequestEvent : OadrRequest
    {
        public oadrRequestEvent Event { get; set; }

        public oadrDistributeEvent DistributeEvent { get; set; }

        public RequestEvent() : base("oadrRequestEvent", "oadrDistributeEvent")
        {
        }

        public string CreateOadrRequestEvent(string venId, uint replyLimit = 0, string requestId = "")
        {
            Event = new oadrRequestEvent
            {
                eiRequestEvent = new eiRequestEvent
                {
                    venID = venId,
                    requestID = (string.IsNullOrWhiteSpace(requestId) ? RandomHex.Instance().GenerateRandomHex(10) : requestId)
                }
            };

            if (replyLimit > 0)
            {
                Event.eiRequestEvent.replyLimit = replyLimit;
                Event.eiRequestEvent.replyLimitSpecified = true;
            }

            var serializer = new XmlSerializer(typeof(oadrRequestEvent));
            var sw = new StringWriterWithEncoding(Encoding.UTF8);
            serializer.Serialize(sw, Event);
            RequestBody = sw.ToString();
            return RequestBody;
        }
    }
}
