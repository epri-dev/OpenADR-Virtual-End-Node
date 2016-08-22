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
    public class oadrOptScheduleModel
    {
        private bool m_optInRegistered = false;
        private bool m_optOutRegistered = false;

        public string Name { get; set; }

        public CreateOpt CreateOpt { get; set; }

        /********************************************************************************/

        public string OptType { get; set; }
        public string OptReason { get; set; }
        public string MarketContext { get; set; }
        public string OptID { get; private set; }

        public string ResourceID { get; set; }

        public List<OadrAvailable> ScheduleList { get; set; }

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

        public oadrOptScheduleModel()
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

        private OptTypeType convertOptTypeString(string optType)
        {
            if (optType == OptTypeType.optIn.ToString())
                return OptTypeType.optIn;
            else if (optType == OptTypeType.optOut.ToString())
                return OptTypeType.optOut;

            return OptTypeType.optIn;
        }

        /********************************************************************************/

        public oadrlib.lib.oadr2b.OptSchedule getOptSchedule()
        {
            oadrlib.lib.oadr2b.OptSchedule optSchedule = new oadrlib.lib.oadr2b.OptSchedule();

            optSchedule.OptReason = convertOptReasonString(OptReason);

            optSchedule.OptType = convertOptTypeString(OptType);
            optSchedule.OptID = OptID;

            optSchedule.MarketContext = MarketContext;
            optSchedule.ResourceID = ResourceID;

            for (int i = 0; i < ScheduleList.Count; i++)
            {
                optSchedule.addOptSchedule(ScheduleList[i].StartDate.ToUniversalTime(), ScheduleList[i].Duration);
            }

            // optSchedule
            if (optSchedule.Schedule.Count == 0)
                return null;

            
            return optSchedule;
        }
    }

    /********************************************************************************/

    public class OadrAvailable
    {
        public DateTime StartDate { get; set; }
        public int Duration{ get; set; }
    }
}
