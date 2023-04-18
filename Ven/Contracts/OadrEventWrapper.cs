using Oadr.Library.Profile2B.Models;
using System;
using System.Xml;

namespace Oadr.Ven
{
    public class OadrEventWrapper
    {
        private oadrDistributeEventTypeOadrEvent _oadrEvent;
        private int _startAfterMinutes;

        public OptTypeType OptType { get; set; }
        
        public int RandomizedMinutes { get; set; }

        public DateTime DelayCanceledEndTime { get; private set; }

        public bool DelayCancel { get; set; }
        
        public oadrDistributeEventTypeOadrEvent OadrEvent
        {
            get => _oadrEvent;
            set 
            { 
                _oadrEvent = value;
                SetStartAfter();
            }
        }

        public OadrEventWrapper(oadrDistributeEventTypeOadrEvent oadrEvent, OptTypeType optType)
        {
            _oadrEvent = oadrEvent;
            OptType = optType;
            RandomizedMinutes = 0;
            DelayCancel = false;
            SetStartAfter();
        }
        
        private void SetStartAfter()
        {
            int startAfterMinutes;
            try
            {
                startAfterMinutes = (int)XmlConvert.ToTimeSpan(_oadrEvent.eiEvent.eiActivePeriod.properties.tolerance.tolerate.startafter).TotalMinutes;                
            }
            catch
            {
                // Any exceptions related to converting the Start After duration parameter to TotalMinutes will result in treating the parameter as a 0.
                startAfterMinutes = 0;
            }

            if (startAfterMinutes !=  _startAfterMinutes)
            {
                var random = new Random();
                _startAfterMinutes = startAfterMinutes;
                RandomizedMinutes = random.Next(_startAfterMinutes) + 1; // Add one to ensure at least one minute delay.
                _oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime = _oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.AddMinutes(RandomizedMinutes);
            }
            else
            {
                _oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime = _oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.AddMinutes(RandomizedMinutes);
            }
        }
        
        public void InitiateDelayCancel()
        {
            DelayCanceledEndTime = DateTime.Now.AddMinutes(RandomizedMinutes);
            DelayCancel = true;
        }
    }
}
