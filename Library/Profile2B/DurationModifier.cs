namespace Oadr.Library.Profile2B
{
    public class DurationModifier
    {
        public static DurationModifier Seconds = new DurationModifier("S");

        public static DurationModifier Minutes = new DurationModifier("M");

        public static DurationModifier Hours = new DurationModifier("H");

        public string Value { get; }

        public DurationModifier(string value)
        {
            Value = value;
        }
    }
}
