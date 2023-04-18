using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Ven.Signal
{
    public class OadrSignalSimple : OadrSignal
    {
        public OadrSignalSimple() : base (SignalNameEnumeratedType.SIMPLE, new RangeCheckerList(new[] { 0, 1, 2, 3 }))
        {
        }

        public override void AddToDictionary(Dictionary<string, OadrSignal> signals)
        {
            signals.Add(SignalName.ToString(), this);
            signals.Add(SignalNameEnumeratedType.simple.ToString(), this);
        }

        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            if (signalType != SignalTypeEnumeratedType.level)
            {
                throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_TYPE);
            }

            if (units != null)
            {
                throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);
            }
        }
    }
}
