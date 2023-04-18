using Oadr.Library;
using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public class OadrOptScheduleModel
    {
        public string Name { get; set; }

        public CreateOpt CreateOpt { get; set; }

        public string OptType { get; set; }

        public string OptReason { get; set; }

        public string MarketContext { get; set; }
        
        public string OptId { get; private set; }

        public string ResourceId { get; set; }

        public List<OadrAvailable> ScheduleList { get; set; }

        public bool OptInRegistered { get; set; }

        public bool OptOutRegistered { get; set; }

        public OadrOptScheduleModel()
        {
            OptId = RandomHex.Instance().GenerateRandomHex(10);
        }

        private static OptReasonEnumeratedType ConvertOptReasonString(string optReason)
        {
            if (optReason == OptReasonEnumeratedType.economic.ToString())
            {
                return OptReasonEnumeratedType.economic;
            }

            if (optReason == OptReasonEnumeratedType.emergency.ToString())
            {
                return OptReasonEnumeratedType.emergency;
            }

            if (optReason == OptReasonEnumeratedType.mustRun.ToString())
            {
                return OptReasonEnumeratedType.mustRun;
            }

            if (optReason == OptReasonEnumeratedType.notParticipating.ToString())
            {
                return OptReasonEnumeratedType.notParticipating;
            }

            if (optReason == OptReasonEnumeratedType.outageRunStatus.ToString())
            {
                return OptReasonEnumeratedType.outageRunStatus;
            }

            if (optReason == OptReasonEnumeratedType.overrideStatus.ToString())
            {
                return OptReasonEnumeratedType.overrideStatus;
            }

            if (optReason == OptReasonEnumeratedType.participating.ToString())
            {
                return OptReasonEnumeratedType.participating;
            }

            if (optReason == OptReasonEnumeratedType.xschedule.ToString())
            {
                return OptReasonEnumeratedType.xschedule;
            }

            return OptReasonEnumeratedType.economic;
        }
        
        private static OptTypeType ConvertOptTypeString(string optType)
        {
            if (optType == OptTypeType.optIn.ToString())
            {
                return OptTypeType.optIn;
            }

            if (optType == OptTypeType.optOut.ToString())
            {
                return OptTypeType.optOut;
            }

            return OptTypeType.optIn;
        }

        public Library.Profile2B.OptSchedule GetOptSchedule()
        {
            var optSchedule = new Library.Profile2B.OptSchedule
            {
                OptReason = ConvertOptReasonString(OptReason),
                OptType = ConvertOptTypeString(OptType),
                OptId = OptId,
                MarketContext = MarketContext,
                ResourceId = ResourceId
            };

            foreach (var schedule in ScheduleList)
            {
                optSchedule.AddOptSchedule(schedule.StartDate.ToUniversalTime(), schedule.Duration);
            }

            if (optSchedule.Schedule.Count == 0)
            {
                return null;
            }
            return optSchedule;
        }
    }
    
    public class OadrAvailable
    {
        public DateTime StartDate { get; set; }

        public int Duration{ get; set; }
    }
}
