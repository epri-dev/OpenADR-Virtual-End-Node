using Oadr.Library.Profile2B.Models;
using System;

namespace Oadr.Library.Profile2B
{
    public class CreateOpt : OadrRequest2B
    {
        public oadrCreateOptType Request { get; set; }

        public oadrCreatedOptType Response { get; set; }

        public CreateOpt()
            : base("oadrCreateOpt", "oadrCreatedOpt")
        {
        }
        
        private void InitializeOpt(string requestId, string optId, OptTypeType optType, OptReasonEnumeratedType optReason, string venId, string marketContext = null)
        {
            Request = new oadrCreateOptType
            {
                schemaVersion = "2.0b",
                requestID = requestId,
                venID = venId,
                createdDateTime = DateTime.UtcNow,
                marketContext = marketContext,
                optID = optId,
                optType = optType,
                optReason = optReason == OptReasonEnumeratedType.xschedule ? "x-schedule" : optReason.ToString()
            };
        }
        
        public string CreateOptSchedule(string requestId, string venId, OptSchedule optSchedule)
        {
            InitializeOpt(requestId, optSchedule.OptId, optSchedule.OptType, optSchedule.OptReason, venId, optSchedule.MarketContext);

            if (!string.IsNullOrEmpty(optSchedule.ResourceId))
            {
                Request.eiTarget = new EiTargetType
                {
                    resourceID = new string[1]
                };
                Request.eiTarget.resourceID[0] = optSchedule.ResourceId;
            }

            Request.vavailability = new VavailabilityType
            {
                components = new AvailableType[optSchedule.Count]
            };

            var index = 0;
            foreach (AvailableType availableType in optSchedule.Schedule)
            {
                Request.vavailability.components[index] = availableType;
                index++;
            }
            return SerializeObject(Request);
        }
        
        public string CreateOptEvent(
            string requestId,
            string optId,
            oadrDistributeEventTypeOadrEvent @event,
            OptTypeType optType,
            OptReasonEnumeratedType optReason,
            string venId,
            string resourceId = null)
        {
            InitializeOpt(requestId, optId, optType, optReason, venId);

            Request.qualifiedEventID = new QualifiedEventIDType
            {
                eventID = @event.eiEvent.eventDescriptor.eventID,
                modificationNumber = @event.eiEvent.eventDescriptor.modificationNumber
            };
            if (resourceId != null)
            {
                Request.eiTarget = new EiTargetType
                {
                    resourceID = new string[1]
                };
                Request.eiTarget.resourceID[0] = resourceId;
            }
            return SerializeObject(Request);
        }
    }
}
