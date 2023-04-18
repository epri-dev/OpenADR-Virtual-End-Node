using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Ven.Signal
{
    public class OadrSignals
    {
        private static OadrSignals _instance;

        private readonly Dictionary<string, OadrSignal> _signals;

        private OadrSignals()
        {
            _signals = new Dictionary<string, OadrSignal>();

            new OadrSignalSimple().AddToDictionary(_signals);
            new OadrSignalElectricityPrice().AddToDictionary(_signals);
            new OadrSignalEnergyPrice().AddToDictionary(_signals);
            new OadrSignalDemandCharge().AddToDictionary(_signals);
            new OadrSignalBidPrice().AddToDictionary(_signals);
            new OadrSignalBidLoad().AddToDictionary(_signals);
            new OadrSignalBidEnergy().AddToDictionary(_signals);
            new OadrSignalChargeState().AddToDictionary(_signals);
            new OadrSignalLoadDispatch().AddToDictionary(_signals);
            new OadrSignalLoadControl().AddToDictionary(_signals);
        }
        
        public static OadrSignals Instance => _instance ?? (_instance = new OadrSignals());

        public void ValidateSignal(eiEventSignalType signal)
        {
            if (!_signals.ContainsKey(signal.signalName))
            {
                throw new ExceptionInvalidSignal($"{ExceptionInvalidSignal.UNKNOWN_SIGNAL_NAME}: {signal.signalName}");
            }
            var oadrSignal = _signals[signal.signalName];

            try
            {
                oadrSignal.ValidateUnits(signal.signalType, signal.itemBase);
            }
            catch (ExceptionInvalidSignal)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ExceptionInvalidSignal($"{ExceptionInvalidSignal.EXCEPTION_THROWN}: {signal.signalName}", ex);
            }
        }
    }
}
