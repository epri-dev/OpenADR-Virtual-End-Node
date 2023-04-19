using Oadr.Library;
using Oadr.Library.Profile2B.Models;
using System;
using System.Text;
using System.Xml.Serialization;

namespace Oadr.Library.Profile2B
{
    public class OadrRequest2B : OadrRequest
    {
        public oadrPayload RequestPayload { get; set; }

        public oadrPayload ResponsePayload { get; set; }

        public OadrRequest2B(string requestType, string responseType)
            : base(requestType, responseType)
        {
        }

        protected string SerializeObject(object obj)
        {
            RequestPayload = new oadrPayload
            {
                oadrSignedObject = new oadrSignedObject
                {
                    Id = "signedObject",
                    Item = obj
                }
            };
            
            var serializer = new XmlSerializer(typeof(oadrPayload));
            var sw = new StringWriterWithEncoding(Encoding.UTF8);
            serializer.Serialize(sw, RequestPayload);
            RequestBody = sw.ToString();
            return RequestBody;
        }

        public void SetEiResponse(EiResponseType eiResponse)
        {
            EiResponseCode = Convert.ToInt32(eiResponse.responseCode);
            EiResponseDescription = eiResponse.responseDescription;
        }
    }
}
