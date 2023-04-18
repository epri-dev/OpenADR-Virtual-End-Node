using Oadr.Library.Profile2B.Models;

namespace Oadr.Ven.Signal
{
    public class OadrSignalLoadControl : OadrSignal
    {
        public OadrSignalLoadControl() : base(SignalNameEnumeratedType.LOAD_CONTROL, new RangeCheckerAny())
        {
        }

        public override void ValidateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units)
        {
            if (signalType == SignalTypeEnumeratedType.xloadControlCapacity ||
                signalType == SignalTypeEnumeratedType.xloadControlLevelOffset ||
                signalType == SignalTypeEnumeratedType.xloadControlPercentOffset ||
                signalType == SignalTypeEnumeratedType.xloadControlSetpoint)
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
