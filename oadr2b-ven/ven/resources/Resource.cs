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

using System.Threading;

using oadrlib.lib.oadr2b;

namespace oadr2b_ven.ven.resources
{
    public class Resource
    {
        private string m_resourceID;

        private IntervalPower m_intervalPower;
        private IntervalEnergy m_intervalEnergy;
        private IntervalStatus m_intervalStatus;
     
        private bool m_online = true;
        private bool m_override = false;

        private float m_w = (float)0.0;        

        /**********************************************************/

        public Resource(string resourceID, int intervalMinutes = 1)
        {
            m_resourceID = resourceID;

            m_intervalPower = new IntervalPower(resourceID + "_power", 120);
            m_intervalEnergy = new IntervalEnergy(resourceID + "_energy", intervalMinutes, 120);
            m_intervalStatus = new IntervalStatus(resourceID + "_status", 120);

            /*DateTime now = DateTime.Now.AddSeconds(-300);

            // add default intervals for reporting
            for (int x = 1; x <= 31; x++)
            {
                m_intervalPower.addIntervalValue(now, (float)x);
                m_intervalStatus.addStatus(now, true, false);

                now = now.AddSeconds(10);
            }
            */

            DateTime now = DateTime.Now.AddMinutes(-120);

            now = now.AddMinutes(-now.Minute);
            now = now.AddSeconds(-now.Second);
            now = now.AddMilliseconds(-now.Millisecond);

            for (int x = 1; x <= 121; x++)
            {
                m_intervalEnergy.addEnergyInterval(now, (float)x);
                m_intervalPower.addIntervalValue(now, (float)x);
                m_intervalStatus.addStatus(now, true, false);

                now = now.AddMinutes(1);
            }
        }

        /**********************************************************/

        public string ResourceID
        {
            get { return m_resourceID; }
        }

        /**********************************************************/

        public IntervalPower IntervalPower
        {
            get { return m_intervalPower; }
        }

        /**********************************************************/

        public IntervalEnergy IntervalEnergy
        {
            get { return m_intervalEnergy; }
        }

        /**********************************************************/

        public IntervalStatus IntervalStatus
        {
            get { return m_intervalStatus; }
        }

        /**********************************************************/

        public bool Online
        {
            get { return m_online; }
            set { m_online = value; }
        }

        /**********************************************************/

        public bool Override
        {
            get { return m_override; }
            set { m_override = value; }
        }

        /**********************************************************/

        public float W
        {
            get { return m_w; }
            set { m_w = value; }            
        }

        /**********************************************************/

        public void captureIntervals(DateTime now)
        {
            m_intervalStatus.addStatus(now, Online, Override);
            m_intervalPower.addIntervalValue(now, m_w);
            m_intervalEnergy.addIntervalValue(now, m_w);
        }

        /**********************************************************/

        public virtual void addReportDescriptions(Dictionary<string, ReportWrapper> reports, string telemetryStatusSpecifierID, string telemetryUsageSpecifierID, string historyUsageSpecifierID, Dictionary<string, Interval> intervals)
        {
            // telemetry status
            reports[telemetryStatusSpecifierID].addDescription(IntervalStatus.RID, ResourceID, ReportEnumeratedType.xresourceStatus,
                ReadingTypeEnumeratedType.xnotApplicable, "http://MarketContext1", 1, 1, false, DurationModifier.MINUTES);


            // telemetry usage
            reports[telemetryUsageSpecifierID].addDescriptionEnergyItem(IntervalEnergy.RID, ResourceID, ReportEnumeratedType.usage,
                            ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 1, false, DurationModifier.MINUTES, eEnergyItemType.EnergyReal,
                            "RealEnergy", "Wh", SiScaleCodeType.n);

            reports[telemetryUsageSpecifierID].addDescriptionPowerItem(IntervalPower.RID, ResourceID, ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 1, false, DurationModifier.MINUTES, ePowerItemType.PowerReal,
                "RealPower", "W", SiScaleCodeType.n, 60, 110, true);

            // history usage
            reports[historyUsageSpecifierID].addDescriptionEnergyItem(IntervalEnergy.RID, ResourceID, ReportEnumeratedType.usage,
                            ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 1, false, DurationModifier.MINUTES, eEnergyItemType.EnergyReal,
                            "RealEnergy", "Wh", SiScaleCodeType.n);

            reports[historyUsageSpecifierID].addDescriptionPowerItem(IntervalPower.RID, ResourceID, ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 1, false, DurationModifier.MINUTES, ePowerItemType.PowerReal,
                "RealPower", "W", SiScaleCodeType.n, 60, 110, true);

            intervals.Add(IntervalStatus.RID, IntervalStatus);
            intervals.Add(IntervalPower.RID, IntervalPower);
            intervals.Add(IntervalEnergy.RID, IntervalEnergy);
        }

        /**********************************************************/

        public virtual void removeReportDescriptions(Dictionary<string, ReportWrapper> reports, string telemetryStatusSpecifierID, string telemetryUsageSpecifierID, string historyUsageSpecifierID, Dictionary<string, Interval> intervals)
        {
            intervals.Remove(IntervalStatus.RID);
            intervals.Remove(IntervalPower.RID);
            intervals.Remove(IntervalEnergy.RID);

            reports[telemetryStatusSpecifierID].removeDescription(IntervalStatus.RID);

            reports[telemetryUsageSpecifierID].removeDescription(IntervalEnergy.RID);
            reports[telemetryUsageSpecifierID].removeDescription(IntervalPower.RID);

            reports[historyUsageSpecifierID].removeDescription(IntervalEnergy.RID);
            reports[historyUsageSpecifierID].removeDescription(IntervalPower.RID);
        }

    }
}
