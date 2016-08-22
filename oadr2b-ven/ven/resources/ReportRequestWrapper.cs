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

namespace oadr2b_ven.ven.resources
{
    public class ReportRequestWrapper
    {
        private oadrReportRequestType m_reportRequest;
        private bool m_reportComplete = false;
        private bool m_reportToFollow = false;

        private DateTime m_lastReported = DateTime.MinValue;

        /**********************************************************/

        public ReportRequestWrapper(oadrReportRequestType reportRequest)
        {
            m_reportRequest = reportRequest;
        }

        /**********************************************************/

        public string ReportRequestID
        {
            get { return m_reportRequest.reportRequestID; }
        }

        /**********************************************************/

        public oadrReportRequestType ReportRequest
        {
            get { return m_reportRequest; }
        }

        /**********************************************************/

        /// <summary>
        /// called when VTN cancels the report but wants the next report to be sent
        /// </summary>
        public void setReportToFollow()
        {
            m_reportToFollow = true;
        }

        /// <summary>
        /// set to true when the final UpdateReport has been generated
        /// </summary>
        public bool ReportComplete
        {
            get { return m_reportComplete; }
        }

        /**********************************************************/

        private void doGenerateUpdateReport(Dictionary<string, Interval> intervals, DateTime dtstart, int durationSeconds, ReportWrapper reportWrapper, ISendReport sendReport)
        {
            try
            {         
                // make sure only one thread is generating for this report
                lock (reportWrapper)
                {
       
                    // int reportBackDurationSeconds = (int)System.Xml.XmlConvert.ToTimeSpan(m_reportRequest.reportSpecifier.reportBackDuration.duration).TotalSeconds;

                    // these two parameters indicate when to start reporting (dtstart) and for how long to continue reporting (duration)
                    // they're not needed by the interval
                    // DateTime dtstartUTC = (m_reportRequest.reportSpecifier.reportInterval == null ? DateTime.Now : m_reportRequest.reportSpecifier.reportInterval.properties.dtstart.datetime);
                    // int durationSeconds = (m_reportRequest.reportSpecifier.reportInterval == null ? 0 : (int)System.Xml.XmlConvert.ToTimeSpan(m_reportRequest.reportSpecifier.reportInterval.properties.duration.duration).TotalSeconds);

                    // ReportWrapper reportWrapper = reports[reportSpecifierID];

                    foreach (SpecifierPayloadType specifierPaylod in m_reportRequest.reportSpecifier.specifierPayload)
                    {
                        try
                        {
                            string rid = specifierPaylod.rID;

                            Interval interval = intervals[rid];

                            interval.addIntervalToReport(reportWrapper, dtstart, durationSeconds);
                        }
                        catch (KeyNotFoundException ex)
                        {
                            // there's a situation where a resource has been removed and the new report hasn't
                            // yet been registered with the VTN which will cause a key not found error when we
                            // try to generate the report.  this is expected behaviour
                            oadrlib.lib.helper.Logger.logException(ex);
                        }
                        catch (Exception ex)
                        {
                            m_reportComplete = true;
                            oadrlib.lib.helper.Logger.logException(ex);
                        }
                    }

                    oadrReportType report = reportWrapper.generateReport(m_reportRequest.reportRequestID);

                    sendReport.sendUpdateReport(report, m_reportRequest);
                }
            }
            catch (Exception ex)
            {
                // an exception here indicates a problem with the xml
                m_reportComplete = true;
                oadrlib.lib.helper.Logger.logException(ex);
            }
        }

        /**********************************************************/

        /// <summary>
        /// generate the report if the next report is due
        /// set m_reportComplete to true if the last report was generated
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="reports"></param>
        /// <param name="sendReport"></param>
        public void generateUpdateReport(Dictionary<string, Interval> intervals, Dictionary<string, ReportWrapper> reports, ISendReport sendReport)
        {
            // this function is called from a thread
            // the lock ensures only invocation is active at a time (helps when debugging)
            lock (this)
            {
                try
                {
                    if (m_reportComplete)
                        return;

                    // specifies how often to send the report, and the duration of the report
                    int reportBackDurationSeconds = (int)System.Xml.XmlConvert.ToTimeSpan(m_reportRequest.reportSpecifier.reportBackDuration.duration).TotalSeconds;

                    DateTime now = DateTime.Now;

                    DateTime dtstart = now;
                    int durationSeconds = 0;

                    
                    if (m_reportRequest.reportSpecifier.reportInterval == null)
                    {
                        // oneshot report; -1 tells the interval to report the most recent value
                        dtstart = now;
                        durationSeconds = -1;

                        m_reportComplete = true;
                    }                    
                    else if (reportBackDurationSeconds == 0)
                    {
                        // history report
                        dtstart = m_reportRequest.reportSpecifier.reportInterval.properties.dtstart.datetime.ToLocalTime();
                        durationSeconds = (int)System.Xml.XmlConvert.ToTimeSpan(m_reportRequest.reportSpecifier.reportInterval.properties.duration.duration).TotalSeconds;

                        m_reportComplete = true;
                    }
                    else
                    {
                        // periodic report
                        dtstart = m_reportRequest.reportSpecifier.reportInterval.properties.dtstart.datetime.ToLocalTime();
                        durationSeconds = (int)System.Xml.XmlConvert.ToTimeSpan(m_reportRequest.reportSpecifier.reportInterval.properties.duration.duration).TotalSeconds;
                        
                        // the report end time has passed
                        if (now > dtstart.AddSeconds(durationSeconds + 30) && durationSeconds != 0)
                        {
                            m_reportComplete = true;
                            return;
                        }

                        if (now >= dtstart && (now <= dtstart.AddSeconds(durationSeconds + 30) || durationSeconds == 0))
                        {
                            if (now >= m_lastReported.AddSeconds(reportBackDurationSeconds))
                            {
                                //
                                // TODO: this function is crap and needs to be unit tested and cleaned up
                                //

                                // doGenerateUpdateReport(intervals, now, reportBackDurationSeconds, reportWrapper, sendReport);

                                // if true, the report has been cancelled but a final report should be sent
                                if (m_reportToFollow)
                                    m_reportComplete = true;

                                m_lastReported = now;

                                // set dtstart to the value of the newest interval
                                // all reported intervals should have a date <= dtstart
                                dtstart = m_lastReported;

                                // the duration of a periodic report is equal to reportBackDurationSeconds
                                durationSeconds = reportBackDurationSeconds;
                            }
                            else
                                return; // not time to send the next report yet
                        }
                        else
                            return; // report dtstart hasn't passed yet
                    }

                    //
                    // time to generate a report: dtstart is the report start time and durationSeconds is the length of the report
                    // if it's a metadata report, it's handled below (outside of the lock)
                    //

                    if (m_reportRequest.reportSpecifier.reportSpecifierID != "METADATA")
                    {
                        ReportWrapper reportWrapper = reports[m_reportRequest.reportSpecifier.reportSpecifierID];

                        doGenerateUpdateReport(intervals, dtstart, durationSeconds, reportWrapper, sendReport);
                    }
                }
                catch (Exception ex)
                {
                    m_reportComplete = true;

                    oadrlib.lib.helper.Logger.logMessage("Exception caught handling reportRequest.  Cancelling report.");
                    oadrlib.lib.helper.Logger.logException(ex);
                }            
            }

            if (m_reportRequest.reportSpecifier.reportSpecifierID == "METADATA")
                sendReport.sendMetadataReport(m_reportRequest.reportRequestID);
        }
    }
}
