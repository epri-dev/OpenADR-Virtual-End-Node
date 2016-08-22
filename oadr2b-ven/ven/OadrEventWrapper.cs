//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using oadrlib.lib.oadr2b;

namespace oadr2b_ven.ven
{
    public class OadrEventWrapper
    {
        private oadrDistributeEventTypeOadrEvent m_oadrEvent;
        private int m_startAfterMinutes = 0;

        private DateTime m_delayCancelEndTime;

        public OadrEventWrapper(oadrDistributeEventTypeOadrEvent oadrEvent, OptTypeType optType)
        {
            m_oadrEvent = oadrEvent;
            OptType = optType;

            RandomizedMinutes = 0;

            DelayCancel = false;

            setStartAfter();
        }

        /**********************************************************************************/

        public OptTypeType OptType
        {
            get;
            set;
        }

        /**********************************************************************************/

        private void setStartAfter()
        {
            int startAfterMinutes;

            try
            {
                startAfterMinutes = (int)XmlConvert.ToTimeSpan(m_oadrEvent.eiEvent.eiActivePeriod.properties.tolerance.tolerate.startafter).TotalMinutes;                
            }
            catch
            {
                // any exceptions related to converting the Start After duration parmater to TotalMinutes
                // will result in treating the parameter as a 0
                startAfterMinutes = 0;
            }

            if (startAfterMinutes !=  m_startAfterMinutes)
            {
                Random random = new Random();

                m_startAfterMinutes = startAfterMinutes;

                RandomizedMinutes = random.Next(m_startAfterMinutes) + 1; // add one to ensure at least one minute delay

                m_oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime = m_oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.AddMinutes(RandomizedMinutes);
            }
            else
                m_oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime = m_oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.AddMinutes(RandomizedMinutes);
        }

        /**********************************************************************************/

        public int RandomizedMinutes
        {
            get;
            set;
        }

        /**********************************************************************************/

        public oadrDistributeEventTypeOadrEvent OadrEvent
        {
            get { return m_oadrEvent; }

            set 
            { 
                m_oadrEvent = value;
                setStartAfter();
            }
        }
        
        /**********************************************************************************/

        public void initiateDelayCancel()
        {
            m_delayCancelEndTime = DateTime.Now.AddMinutes(RandomizedMinutes);
            DelayCancel = true;
        }

        /**********************************************************************************/

        public DateTime DelayCanceledEndTime
        {
            get { return m_delayCancelEndTime; }
        }

        /**********************************************************************************/

        public bool DelayCancel
        {
            get;
            set;
        }
    }
}
