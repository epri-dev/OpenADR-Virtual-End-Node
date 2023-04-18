using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class OadrSignalLoadDispatch : OadrSignal
    {
        public OadrSignalLoadDispatch() : base(SignalNameEnumeratedType.LOAD_DISPATCH, new RangeCheckerAny())
        {
        }
        
        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            if (signalType == SignalTypeEnumeratedType.setpoint ||
                signalType == SignalTypeEnumeratedType.delta ||
                signalType == SignalTypeEnumeratedType.level)
            {
                if (units.GetType().BaseType != typeof(PowerItemType))
                {
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
                }
                return;
            }

            if (signalType == SignalTypeEnumeratedType.multiplier)
            {
                if (units != null)
                {
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
                }
                return;
            }

            throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_TYPE);
        }
    }
}
