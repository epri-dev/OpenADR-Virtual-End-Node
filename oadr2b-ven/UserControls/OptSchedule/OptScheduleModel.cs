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

using oadrlib.lib.oadr2b;
using oadrlib.lib;

namespace oadr2b_ven.UserControls.OptSchedule
{
    public class OptScheduleModel
    {
        private Dictionary<string, List<eButtonState>> m_buttonStates = new Dictionary<string, List<eButtonState>>();

        private bool m_optInRegistered = false;
        private bool m_optOutRegistered = false;

        public string Name { get; set; }

        public CreateOpt CreateOpt { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        /********************************************************************************/

        public string OptInReason { get; set; }
        public string OptOutReason { get; set; }
        public string OptID { get; private set; }

        public string OptInID { get { return OptID + "-IN"; } }

        public string OptOutID { get { return OptID + "-OUT"; } }

        /********************************************************************************/

        public bool OptInRegistered
        {
            get { return m_optInRegistered; }
            set { m_optInRegistered = value; }
        }

        /********************************************************************************/

        public bool OptOutRegistered
        {
            get { return m_optOutRegistered; }
            set { m_optOutRegistered = value; }
        }

        /********************************************************************************/

        public OptScheduleModel()
        {
            OptID = RandomHex.instance().generateRandomHex(10);
        }

        /********************************************************************************/

        private OptReasonEnumeratedType convertOptReasonString(string optReason)
        {
            if (optReason == OptReasonEnumeratedType.economic.ToString())
                return OptReasonEnumeratedType.economic;
            else if (optReason == OptReasonEnumeratedType.emergency.ToString())
                return OptReasonEnumeratedType.emergency;
            else if (optReason == OptReasonEnumeratedType.mustRun.ToString())
                return OptReasonEnumeratedType.mustRun;
            else if (optReason == OptReasonEnumeratedType.notParticipating.ToString())
                return OptReasonEnumeratedType.notParticipating;
            else if (optReason == OptReasonEnumeratedType.outageRunStatus.ToString())
                return OptReasonEnumeratedType.outageRunStatus;
            else if (optReason == OptReasonEnumeratedType.overrideStatus.ToString())
                return OptReasonEnumeratedType.overrideStatus;
            else if (optReason == OptReasonEnumeratedType.participating.ToString())
                return OptReasonEnumeratedType.participating;
            else if (optReason == OptReasonEnumeratedType.xschedule.ToString())
                return OptReasonEnumeratedType.xschedule;

            return OptReasonEnumeratedType.economic;
        }

        /********************************************************************************/

        public OptReasonEnumeratedType getOptInReasonEnum()
        {
            return convertOptReasonString(OptInReason);
        }

        /********************************************************************************/

        public OptReasonEnumeratedType getOptOutReasonEnum()
        {
            return convertOptReasonString(OptOutReason);
        }

        /********************************************************************************/

        public void setButtonState(string weekday, int hour, eButtonState buttonState)
        {
            if (!m_buttonStates.ContainsKey(weekday))
                m_buttonStates.Add(weekday, new List<eButtonState>());

            if (m_buttonStates[weekday].Count() <= hour)
                m_buttonStates[weekday].Add(buttonState);
            else
                m_buttonStates[weekday][hour] = buttonState;
        }

        /********************************************************************************/

        public eButtonState getButtonState(string weekday, int hour)
        {
            return m_buttonStates[weekday][hour];
        }

        /********************************************************************************/

        public oadrlib.lib.oadr2b.OptSchedule getOptSchedule(oadrlib.lib.oadr2b.OptSchedule optSchedule, eButtonState buttonState)
        {
            DateTime current = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day);
            DateTime end = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day);
            
            int scheduleDuration = 0;
            DateTime scheduleStartTime = DateTime.Now;

            while (current <= end)
            {
                List<eButtonState> hourButtonState = m_buttonStates[current.DayOfWeek.ToString()];

                for (int hour = 0; hour < 24; hour++)
                {
                    if (hourButtonState[hour] == buttonState)
                    {
                        scheduleDuration++;

                        if (scheduleDuration == 1)
                            scheduleStartTime = current.AddHours(hour);
                    }
                    else
                    {
                        if (scheduleDuration > 0)
                        {
                            optSchedule.addOptSchedule(scheduleStartTime.ToUniversalTime(), scheduleDuration);
                            scheduleDuration = 0;
                        }
                    }                    
                }

                current = current.AddDays(1);
            }

            if (optSchedule.Schedule.Count == 0)
                return null;

            return optSchedule;
        }

        /********************************************************************************/

        public oadrlib.lib.oadr2b.OptSchedule getOptInSchedule()
        {
            oadrlib.lib.oadr2b.OptSchedule optSchedule = new oadrlib.lib.oadr2b.OptSchedule();

            optSchedule.OptReason = convertOptReasonString(OptInReason);
            optSchedule.OptType = OptTypeType.optIn;
            optSchedule.OptID = OptInID;

            return getOptSchedule(optSchedule, eButtonState.OPT_IN);
        }

        /********************************************************************************/

        public oadrlib.lib.oadr2b.OptSchedule getOptOutSchedule()
        {
            oadrlib.lib.oadr2b.OptSchedule optSchedule = new oadrlib.lib.oadr2b.OptSchedule();

            optSchedule.OptReason = convertOptReasonString(OptOutReason);
            optSchedule.OptType = OptTypeType.optOut;
            optSchedule.OptID = OptOutID;
            
            return getOptSchedule(optSchedule, eButtonState.OPT_OUT);
        }
    }
}
