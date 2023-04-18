using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    internal class OadrSignalBidEnergy : OadrSignal
    {
        public OadrSignalBidEnergy() : base(SignalNameEnumeratedType.BID_ENERGY, new RangeCheckerAny())
        {
        }

        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            if (signalType == SignalTypeEnumeratedType.setpoint)
            {
                if (units.GetType().BaseType != typeof(EnergyItemType))
                {
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
                }
                return;
            }
            throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_TYPE);
        }
    }
}
