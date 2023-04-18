using Oadr.Library.Profile2B.Models;

namespace Oadr.Library.Profile2B
{
    public class CancelOpt: OadrRequest2B
    {
        public oadrCancelOptType Request { get; set; }

        public oadrCanceledOptType Response { get; set; }

        public CancelOpt()
            : base("oadrCancelOpt", "oadrCanceledOpt")
        {
        }
        
        public string CreateCancelOpt(string requestId, string optId, string venId)
        {
            Request = new oadrCancelOptType
            {
                schemaVersion = "2.0b",
                requestID = requestId,
                optID = optId,
                venID = venId
            };
            return SerializeObject(Request);
        }
    }
}
