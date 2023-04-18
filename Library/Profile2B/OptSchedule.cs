using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Library.Profile2B
{
    public class OptSchedule
    {
        public string OptId { get; set; }

        public OptTypeType OptType { get; set; } = OptTypeType.optIn;

        public OptReasonEnumeratedType OptReason { get; set; } = OptReasonEnumeratedType.economic;

        public List<AvailableType> Schedule { get; } = new List<AvailableType>();

        public int Count => Schedule.Count;

        public string MarketContext { get; set; }

        public string ResourceId { get; set; }

        public void AddOptSchedule(DateTime startTimeUtc, int durationHours)
        {
            var availableType = new AvailableType
            {
                properties = new properties
                {
                    dtstart = new dtstart
                    {
                        datetime = startTimeUtc
                    },
                    duration = new DurationPropType
                    {
                        duration = $"PT{durationHours}H"
                    }
                }
            };
            Schedule.Add(availableType);
        }

        public void ClearOptSchedule()
        {
            Schedule.Clear();
        }
    }
}
