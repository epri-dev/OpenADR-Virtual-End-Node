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
    abstract public class Interval
    {
        private string m_rid;

        protected List<IntervalValue> m_intervals = new List<IntervalValue>();

        /**********************************************************/

        public Interval(string rid)
        {
            m_rid = rid;
        }

        /**********************************************************/

        public string RID
        {
            get { return m_rid; }
        }

        /**********************************************************/

        abstract public void addPayloadToReport(ReportWrapper reportWrapper, IntervalValue intervalValue);

        /**********************************************************/

        public List<IntervalValue> Intervals
        {
            get { return m_intervals; }
        }

        /**********************************************************/

        public List<IntervalValue> queryIntervals(DateTime dtstart, int durationSeconds)
        {
            List<IntervalValue> intervalsToReport = new List<IntervalValue>();

            if (m_intervals.Count == 0)
                return intervalsToReport;

            // oneshot report; return the newest interval
            if (durationSeconds == -1)
            {
                intervalsToReport.Add(m_intervals[0]);
                return intervalsToReport;
            }

            // report all history
            if (durationSeconds == 0)
                durationSeconds = Int32.MaxValue;

            // if the oldest interval is newer than dtstart, there's no intervals to report
            if (m_intervals[m_intervals.Count - 1].DateTime > dtstart)
                return intervalsToReport;

            DateTime endTime;

            endTime = dtstart.AddSeconds(-durationSeconds);

            // if the endtime > the newest interval, there's no intervals to report
            if (endTime > m_intervals[0].DateTime)
                return intervalsToReport;

            int index = 0;

            // find the first interval with datetime <= dtstart
            while (m_intervals[index].DateTime > dtstart)
                index++;

            while (index < m_intervals.Count && m_intervals[index].DateTime <= dtstart && m_intervals[index].DateTime > endTime)
            {
                intervalsToReport.Add(m_intervals[index]);
                index++;
            }

            return intervalsToReport;
        }

        /**********************************************************/

        public void addIntervalToReport(ReportWrapper reportWrapper, DateTime dtstart, int durationSeconds)
        {
            try
            {
                List<IntervalValue> intervals = queryIntervals(dtstart, durationSeconds);

                if (intervals.Count == 0)
                    return;

                foreach (IntervalValue intervalValue in intervals)
                    addPayloadToReport(reportWrapper, intervalValue);
            }
            catch (Exception ex)
            {
                Logger.logException(ex);
            }
        }
    }
}
