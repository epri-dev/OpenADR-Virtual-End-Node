using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class OadrSignalChargeState : OadrSignal
    {
        public OadrSignalChargeState() : base(SignalNameEnumeratedType.CHARGE_STATE, new RangeCheckerAny())
        {
        }

        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            if (signalType == SignalTypeEnumeratedType.setpoint || signalType == SignalTypeEnumeratedType.delta)
            {
                if (units.GetType().BaseType != typeof(EnergyItemType))
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
