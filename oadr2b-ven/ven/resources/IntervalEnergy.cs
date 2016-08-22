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

using oadrlib.lib;
using oadrlib.lib.oadr2b;
using oadrlib.lib.helper;

namespace oadr2b_ven.ven.resources
{
    public class IntervalEnergy : Interval
    {        
        // private List<PowerValue> m_intervals = new List<PowerValue>();

        private List<PowerValue> m_currentInterval = new List<PowerValue>();

        private int m_maxIntervals;

        private int m_intervalMinutes;

        /**********************************************************/

        public IntervalEnergy(string rid, int intervalMinutes, int maxIntervals = 72) : 
            base(rid)
        {
            m_intervalMinutes = intervalMinutes;
            m_maxIntervals = maxIntervals;
        }

        /**********************************************************/

        public void addIntervalValue(DateTime dateTime, float value)
        {
            PowerValue iv = new PowerValue(dateTime, value);

            m_currentInterval.Insert(0, iv);

            if (dateTime.Minute % m_intervalMinutes == 0 && dateTime.Second == 0)
                captureEnergyInterval(dateTime);
        }

        /**********************************************************/

        private void captureEnergyInterval(DateTime dateTime)
        {
            float value = 0;
            PowerValue historicalInterval;

            foreach (PowerValue iv in m_currentInterval)
                value += iv.Value;

            value = value / m_currentInterval.Count;

            value = value / (60 / m_intervalMinutes);

            historicalInterval = new PowerValue(dateTime, value);

            m_intervals.Insert(0, historicalInterval);

            if (m_intervals.Count > m_maxIntervals)
                m_intervals.RemoveAt(m_intervals.Count - 1);

            m_currentInterval.Clear();
        }

        /**********************************************************/

        public void addEnergyInterval(DateTime dateTime, float value)
        {
            PowerValue historicalInterval;

            historicalInterval = new PowerValue(dateTime, value);

            m_intervals.Insert(0, historicalInterval);

            if (m_intervals.Count > m_maxIntervals)
                m_intervals.RemoveAt(m_intervals.Count - 1);
        }

        /**********************************************************/

        public override void addPayloadToReport(ReportWrapper reportWrapper, IntervalValue intervalValue)
        {
            PowerValue pv = (PowerValue)intervalValue;

            reportWrapper.addIntervalReportPayload(pv.DateTime.ToUniversalTime(), RID, pv.Confidence, pv.Accuracy, pv.Value, DataQuality.qualityGoodNonSpecific, m_intervalMinutes, DurationModifier.MINUTES);
        }

    }
}
