using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class OadrSignalBidPrice : OadrSignal
    {
        public OadrSignalBidPrice() : base(SignalNameEnumeratedType.BID_PRICE, new RangeCheckerAny())
        {
        }

        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            if (signalType == SignalTypeEnumeratedType.price)
            {
                if (units.GetType() != typeof(currencyType))
                {
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
                }
                var currency = (currencyType)units;
                if (currency.itemDescription != currencyItemDescriptionType.currency)
                {
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
                }
                return;
            }
            throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_TYPE);
        }
    }
}
