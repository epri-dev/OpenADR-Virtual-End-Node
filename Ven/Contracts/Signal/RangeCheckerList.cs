namespace Oadr.Ven.Signal
{
    public class RangeCheckerList : RangeChecker
    {
        private int[] _values;

        public RangeCheckerList(int[] values)
        {
            _values = values;
        }
    }
}
