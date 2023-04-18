using Oadr.Library.Profile2B.Models;
using System;

namespace Oadr.Library.Profile2B
{
    public class OadrPoll : OadrRequest2B
    {
        public oadrPollType Request { get; set; }

        public object Response { get; set; }

        public OadrPoll()
            : base("oadrPoll", "?")
        {
        }

        public oadrResponseType GetOadrResponse()
        {
            return (oadrResponseType)Response;
        }

        public oadrDistributeEventType GetDistributeEventResponse()
        {
            return (oadrDistributeEventType)Response;
        }

        public oadrCreateReportType GetCreateReportResponse()
        {
            return (oadrCreateReportType)Response;
        }

        public oadrRegisterReportType GetRegisterReportResponse()
        {
            return (oadrRegisterReportType)Response;
        }

        public oadrCancelReportType GetCancelReportResponse()
        {
            return (oadrCancelReportType)Response;
        }

        public oadrUpdateReportType GetUpdateReportResponse()
        {
            return (oadrUpdateReportType)Response;
        }

        public oadrCancelPartyRegistrationType GetCancelPartyRegistrationResponse()
        {
            return (oadrCancelPartyRegistrationType)Response;
        }

        public oadrRequestReregistrationType GetRequestReregistrationResponse()
        {
            return (oadrRequestReregistrationType)Response;
        }

        public string CreateOadrPoll(string venId)
        {
            Request = new oadrPollType
            {
                venID = venId,
                schemaVersion = "2.0b"
            };
            return SerializeObject(Request);
        }

        public bool IsResponseTypeOfType(Type type)
        {
            return Response.GetType() == type;
        }
    }
}
