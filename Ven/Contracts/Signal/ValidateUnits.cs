using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class ValidateUnits
    {
        /// <summary>
        /// Validates currency type units.
        /// It assumes three valid signals: price and priceRelative with units of currencyType, and priceMultiplier with no units.
        /// </summary>
        public static void Validate(SignalTypeEnumeratedType signalType, ItemBaseType units, currencyItemDescriptionType currencyDescriptionType)
        {
            if (signalType == SignalTypeEnumeratedType.price || signalType == SignalTypeEnumeratedType.priceRelative)
            {
                // The class could be currencyType, or a sub class currencyPerKWh, currencyPerKW type.
                if (units.GetType().BaseType != typeof(currencyType) && units.GetType() != typeof(currencyType))
                {
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
                }

                var currency = (currencyType)units;
                if (currency.itemDescription != currencyDescriptionType)
                {
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
                }
                return;
            }

            if (signalType == SignalTypeEnumeratedType.priceMultiplier)
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
