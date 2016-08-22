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

using oadrlib.lib;

namespace oadr2b_ven.ven.resources
{
    public class ReportHandler
    {
        private Dictionary<string, ReportRequestWrapper> m_reportRequests = new Dictionary<string, ReportRequestWrapper>();

        /**********************************************************/

        public bool createReport(oadrReportRequestType[] reportRequests, Dictionary<string, ReportWrapper> reports, Dictionary<string, Interval> intervals)
        {
            lock (this)
            {                
                foreach (oadrReportRequestType reportRequest in reportRequests)
                {
                    try
                    {
                        if (reportRequest.reportSpecifier.reportSpecifierID != "METADATA")
                        {
                            // check that we have a report with hte given reportSpecifierID
                            if (!reports.ContainsKey(reportRequest.reportSpecifier.reportSpecifierID))
                                return false;

                            foreach (SpecifierPayloadType payload in reportRequest.reportSpecifier.specifierPayload)
                            {
                                if (!intervals.ContainsKey(payload.rID))
                                    return false;
                            }
                        }

                        m_reportRequests.Add(reportRequest.reportRequestID, new ReportRequestWrapper(reportRequest));
                    }
                    catch (Exception ex)
                    {
                        oadrlib.lib.helper.Logger.logException(ex);

                        return false;
                    }
                }
            }

            return true;
        }

        /**********************************************************/

        public List<String> PendingReports
        {
            get
            {
                List<String> pendingReports = new List<string>();

                foreach (ReportRequestWrapper reportRequestWrapper in m_reportRequests.Values)
                {
                    if (!reportRequestWrapper.ReportComplete)
                        pendingReports.Add(reportRequestWrapper.ReportRequestID);
                }

                return pendingReports;
            }
        }

        /**********************************************************/

        public List<string> cancelReport(oadrCancelReportType cancelReport)
        {
            List<string> pendingReports = null;

            lock (this)
            {
                foreach (string reportRequestID in cancelReport.reportRequestID)
                {
                    try
                    {
                        if (cancelReport.reportToFollow)
                        {
                            m_reportRequests[reportRequestID].setReportToFollow();
                        }
                        else
                            m_reportRequests.Remove(reportRequestID);
                    }
                    catch (Exception ex)
                    {
                        // TODO: throw key not found exceptions so the caller can report an invalid
                        // key error
                        oadrlib.lib.helper.Logger.logException(ex);
                    }
                }

                if (m_reportRequests.Count > 0)
                {
                    pendingReports = new List<string>();

                    foreach (ReportRequestWrapper reportRequestWrapper in m_reportRequests.Values)
                    {
                        if (!reportRequestWrapper.ReportComplete)
                            pendingReports.Add(reportRequestWrapper.ReportRequestID);
                    }
                }
            }

            return pendingReports;
        }

        /**********************************************************/

        public void generateUpdateReport(Dictionary<string, Interval> intervals, Dictionary<string, ReportWrapper> reports, ISendReport sendReport)
        {
            List<string> completedReports = new List<string>();

            lock (this)
            {
                foreach (ReportRequestWrapper reportRequestWrapper in m_reportRequests.Values)
                {
                    reportRequestWrapper.generateUpdateReport(intervals, reports, sendReport);

                    if (reportRequestWrapper.ReportComplete)                    
                        completedReports.Add(reportRequestWrapper.ReportRequestID);
                }

                foreach (string reportRequestID in completedReports)
                {
                    m_reportRequests.Remove(reportRequestID);
                    sendReport.processCreateReportComplete(reportRequestID);
                }
            }
        }

        /**********************************************************/

        /// <summary>
        /// When a METADATA report is received, all reports must be implicitly cancelled
        /// Send a message to the UI to set all reports to complete
        /// </summary>
        public void handleMetadataReportReceived(ISendReport sendReport)
        {
            lock (this)
            {
                List<string> completedReports = new List<string>();

                foreach (ReportRequestWrapper reportRequestWrapper in m_reportRequests.Values)
                {
                    if (reportRequestWrapper.ReportRequest.reportSpecifier.reportSpecifierID != "METADATA")
                    {
                        sendReport.processCreateReportComplete(reportRequestWrapper.ReportRequestID);
                        completedReports.Add(reportRequestWrapper.ReportRequestID);
                    }
                }

                foreach (string reportRequestID in completedReports)
                {
                    m_reportRequests.Remove(reportRequestID);
                }
            }
        }

        /**********************************************************/

        public void clearReports()
        {
            m_reportRequests.Clear();
        }
    }
}
