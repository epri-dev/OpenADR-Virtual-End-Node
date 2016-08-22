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

using oadrlib.lib.http;

using oadrlib.lib;

namespace oadr_test.helper
{
    class ReportHelper
    {

        public static ReportDescription generateReportDescription()
        {
            ReportDescription reportDescription = new ReportDescription();
            string reportSpecifierID = RandomHex.instance().generateRandomHex(10);

            // add a status report
            reportDescription.addReport(reportSpecifierID, ReportName.TELEMETRY_STATUS, 10, DurationModifier.MINUTES);

            reportDescription.addDescription(reportSpecifierID, RandomHex.instance().generateRandomHex(10), "resource1", ReportEnumeratedType.xresourceStatus,
                ReadingTypeEnumeratedType.xnotApplicable, "http://MarketContext1", 1, 1, false, DurationModifier.MINUTES);

            
            // history usage report
            reportSpecifierID = RandomHex.instance().generateRandomHex(10);

            reportDescription.addReport(reportSpecifierID, ReportName.HISTORY_USAGE, 10, DurationModifier.MINUTES);

            reportDescription.addDescriptionEnergyItem(reportSpecifierID, RandomHex.instance().generateRandomHex(10), "resource1", ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 10, false, DurationModifier.MINUTES, eEnergyItemType.EnergyReal,
                "RealEnergy", "Wh", SiScaleCodeType.n);

            reportDescription.addDescriptionPowerItem(reportSpecifierID, RandomHex.instance().generateRandomHex(10), "resource1", ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 10, false, DurationModifier.MINUTES, ePowerItemType.PowerReal,
                "RealPower", "W", SiScaleCodeType.n, 60, 110, true);

            // the test set will fail if reactive or appparent power/energy are telemetry or history reports
            /*reportDescription.addDescriptionPowerItem(reportSpecifierID, RandomHex.instance().generateRandomHex(10), "resource1", ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 10, false, ePowerItemType.PowerApparent,
                "ApparentPower", "VA", SiScaleCodeType.n, 60, 110, true);

            reportDescription.addDescriptionPowerItem(reportSpecifierID, RandomHex.instance().generateRandomHex(10), "resource1", ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 10, false, ePowerItemType.PowerReactive,
                "ReactivePower", "VAR", SiScaleCodeType.n, 60, 110, true);*/

            // telemetry usage
            reportSpecifierID = RandomHex.instance().generateRandomHex(10);

            reportDescription.addReport(reportSpecifierID, ReportName.TELEMETRY_USAGE, 10, DurationModifier.MINUTES);

            reportDescription.addDescriptionPowerItem(reportSpecifierID, RandomHex.instance().generateRandomHex(10), "resource1", ReportEnumeratedType.usage,
                ReadingTypeEnumeratedType.DirectRead, "http://MarketContext1", 1, 10, false, DurationModifier.MINUTES, ePowerItemType.PowerReal,
                "RealPower", "W", SiScaleCodeType.n, 60, 110, true);



            return reportDescription;
        }
    }
}
