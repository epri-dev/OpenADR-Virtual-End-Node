using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class OadrSignalDemandCharge : OadrSignal
    {
        public OadrSignalDemandCharge() : base(SignalNameEnumeratedType.DEMAND_CHARGE, new RangeCheckerAny())
        {
        }
        
        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            Signal.ValidateUnits.Validate(signalType, units, currencyItemDescriptionType.currencyPerKW);
        }
    }
}