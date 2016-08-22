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

namespace oadr_test.TestSet.ResourcesHelper
{
    public class GenerateCreateReport
    {
        static public oadrCreateReportType generateCreateReport(DateTime dtstartUTC, string reportRequestID, string telemetryStatusReportSpecifierID)
        {
            oadrCreateReportType createReport = new oadrCreateReportType();

            createReport.schemaVersion = "2.0b";
            createReport.requestID = "requestid";
            createReport.venID = "venid";

            oadrReportRequestType reportRequest = new oadrReportRequestType();

            reportRequest.reportRequestID = reportRequestID;
            reportRequest.reportSpecifier = new ReportSpecifierType();

            reportRequest.reportSpecifier.reportSpecifierID = telemetryStatusReportSpecifierID;
            reportRequest.reportSpecifier.granularity = new DurationPropType();
            reportRequest.reportSpecifier.granularity.duration = "PT10S";

            reportRequest.reportSpecifier.reportBackDuration = new DurationPropType();
            reportRequest.reportSpecifier.reportBackDuration.duration = "PT1M";

            reportRequest.reportSpecifier.reportInterval = new WsCalendarIntervalType();
            reportRequest.reportSpecifier.reportInterval.properties = new properties();
            reportRequest.reportSpecifier.reportInterval.properties.dtstart = new dtstart();
            reportRequest.reportSpecifier.reportInterval.properties.dtstart.datetime = dtstartUTC;
            reportRequest.reportSpecifier.reportInterval.properties.duration = new DurationPropType();
            reportRequest.reportSpecifier.reportInterval.properties.duration.duration = "PT5M";

            reportRequest.reportSpecifier.specifierPayload = new SpecifierPayloadType[1];
            reportRequest.reportSpecifier.specifierPayload[0] = new SpecifierPayloadType();
            reportRequest.reportSpecifier.specifierPayload[0].rID = "resource1_status";

            createReport.oadrReportRequest = new oadrReportRequestType[1];
            createReport.oadrReportRequest[0] = reportRequest;

            return createReport;
        }
    }
}
