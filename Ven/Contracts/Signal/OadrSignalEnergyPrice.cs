using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class OadrSignalEnergyPrice : OadrSignal
    {
        public OadrSignalEnergyPrice() : base(SignalNameEnumeratedType.ENERGY_PRICE, new RangeCheckerAny())
        {
        }
        
        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            Signal.ValidateUnits.Validate(signalType, units, currencyItemDescriptionType.currencyPerKWh);
        }
    }
}