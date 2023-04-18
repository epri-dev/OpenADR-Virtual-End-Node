using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class OadrSignalBidLoad : OadrSignal
    {
        public OadrSignalBidLoad() :
            base(SignalNameEnumeratedType.BID_LOAD, new RangeCheckerAny())
        {
        }

        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            if (signalType == SignalTypeEnumeratedType.setpoint)
            {
                if (units.GetType().BaseType != typeof(PowerItemType))
                {
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
                }
                return;
            }
            throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_TYPE);
        }
    }
}
