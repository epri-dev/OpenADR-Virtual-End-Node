using System;

namespace Oadr.Ven.Signal
{
    public class ExceptionInvalidSignal : Exception
    {
        public const string UNKNOWN_SIGNAL_NAME = "Unknown Signal Name";
        public const string INVALID_UNITS = "Invalid Units";
        public const string INVALID_TYPE = "Invalid Type";
        public const string VALUE_OUT_OF_RANGE = "Value Out of Range";
        public const string EXCEPTION_THROWN = "Exception thrown during validation";

        public Exception Exception { get; set; }

        public ExceptionInvalidSignal(string message, Exception ex = null) :
            base(message)
        {
            Exception = ex;
        }
    }
}
