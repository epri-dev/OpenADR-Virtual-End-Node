using System;

namespace Oadr.Ven.Resources
{
    public class StatusValue : IntervalValue
    {
        public bool Override { get; set; }
        
        public bool Online { get; set; }

        public StatusValue(DateTime dateTime, bool online, bool aOverride) : base(dateTime)
        {
            Override = aOverride;
            Online = online;
        }
    }
}
