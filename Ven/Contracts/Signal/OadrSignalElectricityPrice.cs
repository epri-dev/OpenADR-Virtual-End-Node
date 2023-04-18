using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class OadrSignalElectricityPrice : OadrSignal
    {
        public OadrSignalElectricityPrice() : base(SignalNameEnumeratedType.ELECTRICITY_PRICE, new RangeCheckerAny())
        {
        }
        
        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            Signal.ValidateUnits.Validate(signalType, units, currencyItemDescriptionType.currencyPerKWh);
        }
    }
}
