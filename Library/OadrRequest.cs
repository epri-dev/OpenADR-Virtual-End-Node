namespace Oadr.Library
{
    public class OadrRequest
    {
        public string ResponseBody { get; set; }

        public string RequestBody { get; set; }

        public int HttpResponseCode { get; set; }

        public string HttpResponseDescription { get; set; }

        public int EiResponseCode { get; set; }

        public string EiResponseDescription { get; set; }

        public double ResponseTime { get; set; }

        public string RequestType { get; set; }

        public string ResponseType { get; set; }

        public string ServerDate { get; set; }

        public int ServerOffset { get; set; }

        public OadrRequest(string requestType, string responseType)
        {
            RequestType = requestType;
            ResponseType = responseType;
        }
    }
}
