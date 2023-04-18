using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Ven.Signal
{
    public abstract class OadrSignal
    {
        private RangeChecker _rangeChecker;

        public SignalNameEnumeratedType SignalName { get; }

        protected OadrSignal(SignalNameEnumeratedType signalName, RangeChecker rangeChecker)
        {
            SignalName = signalName;
            _rangeChecker = rangeChecker;
        }

        public abstract void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units);

        public bool ValueInRange(string value)
        {
            return true;
        }

        public virtual void AddToDictionary(Dictionary<string, OadrSignal> signals)
        {
            signals.Add(SignalName.ToString(), this);
        }
    }
}
