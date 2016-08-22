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

using oadrlib.lib.oadr2b;

namespace oadrlib.lib.helper
{
    /// <summary>
    /// static helper functions for creating frequently used oadr objects
    /// </summary>
    public class OadrObjectFactory
    {
        static public oadrLoadControlStateTypeType createLoadControlStateType(float min, float max, float current, float normal)
        {
            oadrLoadControlStateTypeType loadControlStateType = new oadrLoadControlStateTypeType();

            loadControlStateType.oadrMin = min;
            loadControlStateType.oadrMax = max;
            loadControlStateType.oadrCurrent = current;
            loadControlStateType.oadrNormal = normal;

            return loadControlStateType;
        }

        /**********************************************************/

        public static IntervalType createIntervalType(DateTime startUTC, oadrReportPayloadType reportPayload, int duration = -1, DurationModifier durationModifier = null)
        {
            IntervalType interval = new IntervalType();

            interval.dtstart = new dtstart();
            interval.dtstart.datetime = startUTC;

            if (duration != -1)
            {
                interval.duration = new DurationPropType();
                interval.duration.duration = "PT" + duration.ToString() + durationModifier.Value;
            }

            interval.streamPayloadBase = new StreamPayloadBaseType[1];
            interval.streamPayloadBase[0] = reportPayload;

            return interval;
        }

        /**********************************************************/

        public static IntervalType createIntervalType(DateTime startUTC, int duration = -1, DurationModifier durationModifier = null)
        {
            IntervalType interval = new IntervalType();

            interval.dtstart = new dtstart();
            interval.dtstart.datetime = startUTC;

            if (duration != -1)
            {
                interval.duration = new DurationPropType();
                interval.duration.duration = "PT" + duration.ToString() + durationModifier.Value;
            }

            return interval;
        }
    }
}
