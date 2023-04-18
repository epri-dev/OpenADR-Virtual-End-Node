using System;

namespace Oadr.Ven.Resources
{
    public class IntervalValue
    {
        public DateTime DateTime { get; set; }

        public IntervalValue(DateTime datetime)
        {
            // Construct a new datetime (instead of copying) to clear the MS.
            DateTime = new DateTime(datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Kind);
        }
    }
}
