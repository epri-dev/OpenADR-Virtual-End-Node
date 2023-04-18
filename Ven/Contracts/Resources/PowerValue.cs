using Oadr.Library.Profile2B;
using System;

namespace Oadr.Ven.Resources
{
    public class PowerValue : IntervalValue
    {
        public float Value { get; set; }
        
        public uint Confidence { get; set; }

        public float Accuracy { get; set; }

        public DataQuality DataQuality { get; set; }

        public PowerValue(DateTime datetime, float value) : base(datetime)
        {
            Value = value;
            Confidence = 1;
            Accuracy = (float)1.0;
            DataQuality = DataQuality.QualityGoodNonSpecific;
        }
    }
}
