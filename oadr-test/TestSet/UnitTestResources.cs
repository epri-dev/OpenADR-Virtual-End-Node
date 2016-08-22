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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oadr2b_ven.ven.resources;
using oadrlib.lib.oadr2b;

namespace oadr_test.TestSet
{
    [TestClass]
    public class UnitTestResources
    {        

        /// <summary>
        /// bug: requesting the same report and intervals sometimes results in the second report having
        /// no intevals
        /// </summary>
        [TestMethod]
        public void sendMultReports()
        {
            DateTime dtstartUTC = DateTime.UtcNow.AddSeconds(-6);

            Resource resource = new ResourceLoad("resource1");
            ResourcesHelper.SendReportTester sendReportTester = new ResourcesHelper.SendReportTester();

            Resources resources = new Resources();

            resources.addResource(resource);

            // this object will check that the reports have multiple intervals
            resources.setCallback(sendReportTester);

            resources.startThread();

            // sleep for 11 seconds to allow at least one interval to be captured
            System.Threading.Thread.Sleep(10000);

            // add two report requests that request the same rid
            resources.addCreateReport(ResourcesHelper.GenerateCreateReport.generateCreateReport(dtstartUTC, "reportRequestID_1", resources.TelemetryStatusReportSpecifierID));

            System.Threading.Thread.Sleep(1000);

            resources.addCreateReport(ResourcesHelper.GenerateCreateReport.generateCreateReport(dtstartUTC.AddSeconds(1), "reportRequestID_2", resources.TelemetryStatusReportSpecifierID));
            

            // System.Threading.Thread.Sleep(40000);
            System.Threading.Thread.Sleep(120000);

            resources.stopThread();
        }
    }
}
