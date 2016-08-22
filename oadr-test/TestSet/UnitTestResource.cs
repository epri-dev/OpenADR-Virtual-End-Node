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
    public class UnitTestResource
    {
        [TestMethod, TestCategory("UnitTestResource")]
        public void captureIntervals()
        {
            // warning this test takes 2 minutes to run
            // create 1 minute intervals
            Resource resource = new Resource("resourceid", 1);
            Resources resources = new Resources();

            resources.addResource(resource);

            float value = 1024;

            resource.Online = true;
            resource.Override = false;
            resource.W = value;

            DateTime now = DateTime.Now;

            // DateTime endTime = now.AddMinutes(10).AddMinutes(5 - (now.Minute % 5)).AddSeconds(-now.Second);
            DateTime endTime = now.AddMinutes(2);

            int numPowerIntervals = (int)(endTime - now).TotalSeconds / 10;
            int numEnergyIntervals = (int)(endTime - now).TotalMinutes / 1;

            double expectedIntervalValue = value / (60 / 1);

            int sleepTime = (int)(endTime - now).TotalSeconds;

            resources.startThread();

            System.Threading.Thread.Sleep(1000 * sleepTime);

            resources.stopThread();

            Assert.AreEqual(numPowerIntervals, resource.IntervalPower.Intervals.Count);

            Assert.AreEqual(numEnergyIntervals, resource.IntervalEnergy.Intervals.Count);

            Assert.AreEqual(expectedIntervalValue, ((PowerValue)resource.IntervalEnergy.Intervals[1]).Value);
        }

        /**********************************************************/

        private void validateReportDescription(ReportDescription reportDescription, int numStatusDescription, int numDataDescriptions)
        {
            foreach (string reportSpecifierID in reportDescription.ReportSpecifierIDs)
            {
                oadrReportType report = reportDescription.generateReportDescription(reportSpecifierID);

                if (report.reportName.Contains("STATUS"))
                {
                    // each resource should add one status description
                    Assert.AreEqual(numStatusDescription, report.oadrReportDescription.Length);
                }
                else
                {
                    // each resource should add 2 data descriptions
                    Assert.AreEqual(numDataDescriptions, report.oadrReportDescription.Length);
                }
            }
        }

        /**********************************************************/

        [TestMethod]
        public void generateReportDescription()
        {
            /*Resource resource1 = new Resource("resource1", 1);
            Resource resource2 = new Resource("resource2", 1);

            Resources resources = new Resources();

            resources.addResource(resource1);
            resources.addResource(resource2);

            ReportDescription reportDescription = resources.ReportDescription;

            // should have two reports: telemetry status and telemetry data
            Assert.AreEqual(2, reportDescription.ReportSpecifierIDs.Count);

            validateReportDescription(reportDescription, 2, 4);

            resources.removeResource(resource2.ResourceID);

            validateReportDescription(reportDescription, 1, 2);*/
        }
    }
}
