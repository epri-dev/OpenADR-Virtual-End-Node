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
using oadrlib.lib.helper;

namespace oadr2b_ven.ven.resources
{
    public class IntervalStatus : Interval
    {
        // private List<StatusValue> m_intervals = new List<StatusValue>();
        private int m_maxIntervals;

        /**********************************************************/

        public IntervalStatus(string rid, int maxIntervals) :
            base(rid)
        {
            m_maxIntervals = maxIntervals;
        }

        /**********************************************************/

        public void addStatus(DateTime dateTime, bool online, bool aOverride)
        {
            StatusValue sv = new StatusValue(dateTime, online, aOverride);
            
            m_intervals.Insert(0, sv);

            if (m_intervals.Count > m_maxIntervals)
                m_intervals.RemoveAt(m_intervals.Count - 1);
        }

        /**********************************************************/

        public override void addPayloadToReport(ReportWrapper reportWrapper, IntervalValue intervalValue)
        {
            StatusValue sv = (StatusValue)intervalValue;

            // TODO: point in time values should not include a duration, but the test set will fail
            // certain test cases duration is not included.  once the test set is fixed, change to not inlcude
            // the duration
            reportWrapper.addIntervalResourceStatus(sv.DateTime.ToUniversalTime(), RID, 1, (float)1.0, DataQuality.qualityGoodNonSpecific, sv.Online, sv.Override, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0, 10, DurationModifier.SECONDS);

            /*reportWrapper.addIntervalResourceStatus(sv.DateTime.ToUniversalTime(), RID, 1, (float)1.0, DataQuality.qualityGoodNonSpecific, sv.Online, sv.Override, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0, (float)1.0,
                (float)1.0, (float)1.0);*/

        }
    }
}
