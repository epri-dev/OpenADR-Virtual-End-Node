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

namespace oadrlib.lib.oadr2b
{
    public class RegisterReport : OadrRequest2b
    {
        public oadrRegisterReportType request;
        public oadrRegisteredReportType response;

        public RegisterReport()
            : base("oadrRegisterReport", "oadrRegisteredReport")
        {
        }

        /**********************************************************/

        public string createRegisterReport(string requestID, string venID, ReportDescription reportDescription)
        {
            request = new oadrRegisterReportType();

            request.schemaVersion = "2.0b";

            request.requestID = requestID;
            request.venID = venID;
            
            request.oadrReport = new oadrReportType[reportDescription.NumReports];

            int index = 0;
            foreach (string reportSpecifierID in reportDescription.ReportSpecifierIDs)
            {
                oadrReportType report = reportDescription.generateReportDescription(reportSpecifierID);
                request.oadrReport[index] = report;

                index++;
            }

            return serializeObject(request);
        }        

        /**********************************************************/

        public string createRegisterReport(string requestID, string venID, Dictionary<string, ReportWrapper> reports, string reportRequestID = null)
        {
            request = new oadrRegisterReportType();

            request.schemaVersion = "2.0b";
            
            request.requestID = requestID;
            request.venID = venID;

            request.oadrReport = new oadrReportType[reports.Count];

            int index = 0;
            foreach (ReportWrapper reportWrapper in reports.Values)
            {
                oadrReportType report = reportWrapper.generateReportDescription(reportRequestID);
                request.oadrReport[index] = report;

                index++;
            }

            return serializeObject(request);
        }
    }
}
