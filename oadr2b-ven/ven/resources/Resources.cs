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

using System.Threading;
using System.Xml.Serialization;

namespace oadr2b_ven.ven.resources
{
    public class Resources
    {
        private Dictionary<string, Resource> m_idToResource = new Dictionary<string, Resource>();
        
        private Dictionary<string, ReportWrapper> m_reports = new Dictionary<string, ReportWrapper>();
        
        private Dictionary<string, Interval> m_ridToInterval = new Dictionary<string, Interval>();

        private ReportHandler m_reportHandler = new ReportHandler();
        
        private string m_telemetryStatusReportSpecifierID;
        private string m_telemetryUsageReportSepcifierID;
        private string m_historyUsageReportSpecifierID;        

        private Thread m_thread;
        private bool m_running;

        ISendReport m_callbacks;

        /**********************************************************/

        public Resources()
        {
            m_telemetryStatusReportSpecifierID = "789ed6cd4e_telemetry_status";
            m_telemetryUsageReportSepcifierID = "789ed6cd4e_telemetry_usage";
            m_historyUsageReportSpecifierID = "789ed6cd4e_history_usage";

            m_reports.Add(m_telemetryStatusReportSpecifierID, new ReportWrapper(m_telemetryStatusReportSpecifierID, ReportName.TELEMETRY_STATUS, 2, DurationModifier.HOURS));
            m_reports.Add(m_telemetryUsageReportSepcifierID, new ReportWrapper(m_telemetryUsageReportSepcifierID, ReportName.TELEMETRY_USAGE, 2, DurationModifier.HOURS));
            m_reports.Add(m_historyUsageReportSpecifierID, new ReportWrapper(m_historyUsageReportSpecifierID, ReportName.HISTORY_USAGE, 2, DurationModifier.HOURS));
        }

        /**********************************************************/

        public Dictionary<string, Resource> ResourceDictionary
        {
            get { return m_idToResource; }
        }

        /**********************************************************/

        public List<String> PendingReports        
        {
            get
            {
                return m_reportHandler.PendingReports;
            }
        }

        /**********************************************************/

        public Dictionary<string, Interval> Intervals
        {
            get { return m_ridToInterval; }
        }

        /**********************************************************/

        public string TelemetryStatusReportSpecifierID
        {
            get { return m_telemetryStatusReportSpecifierID; }
        }

        /**********************************************************/

        public string TelemetryUsageReportSepcifierID
        {
            get { return m_telemetryUsageReportSepcifierID; }
        }

        /**********************************************************/

        public string HistoryUsageReportSpecifierID
        {
            get { return m_historyUsageReportSpecifierID; }
        }

        /**********************************************************/

        public void addResource(Resource resource)
        {
            lock (this)
            {
                m_idToResource.Add(resource.ResourceID, resource);

                resource.addReportDescriptions(m_reports, m_telemetryStatusReportSpecifierID, m_telemetryUsageReportSepcifierID, m_historyUsageReportSpecifierID, m_ridToInterval);
            }
        }

        /**********************************************************/

        public void removeResource(string resourceID)
        {
            lock (this)
            {
                Resource resource = m_idToResource[resourceID];

                m_idToResource.Remove(resourceID);

                resource.removeReportDescriptions(m_reports, m_telemetryStatusReportSpecifierID, m_telemetryUsageReportSepcifierID, m_historyUsageReportSpecifierID, m_ridToInterval);
            }
        }

        /**********************************************************/

        public void setCallback(ISendReport sendReport)
        {
            m_callbacks = sendReport;
        }

        /**********************************************************/

        [XmlIgnore]
        public Dictionary<string, ReportWrapper> Reports
        {            
            get { return m_reports; }
        }

        /**********************************************************/

        public bool createReport(oadrCreateReportType createReport)
        {
            return m_reportHandler.createReport(createReport.oadrReportRequest, m_reports, m_ridToInterval);
        }

        /**********************************************************/

        public void createReport(oadrReportRequestType[] reportRequests)
        {
            m_reportHandler.createReport(reportRequests, m_reports, m_ridToInterval);
        }

        /**********************************************************/

        public void cancelReport(oadrCancelReportType cancelReport)
        {
            lock (this)
            {
                m_reportHandler.cancelReport(cancelReport);
            }
        }

        /**********************************************************************************/

        private void captureIntervals(DateTime now)
        {
            foreach (Resource resource in m_idToResource.Values)
            {
                resource.captureIntervals(now);
            }
        }
        
        /**********************************************************************************/

        public void sendReports(DateTime now)
        {
            lock (this)
            {
                m_reportHandler.generateUpdateReport(m_ridToInterval, m_reports, m_callbacks);
            }
        }

        /**********************************************************************************/

        public void handleMetadataReportReceived()
        {
            lock (this)
            {
                m_reportHandler.handleMetadataReportReceived(m_callbacks);
            }
        }

        /**********************************************************************************/

        private void execute()
        {
            DateTime now = DateTime.Now;

            while (m_running)
            {
                try
                {                    
                    int sleepTime = 10 - (now.Second % 10);
                    // int sleepTime = 60 - now.Second;

                    System.Threading.Thread.Sleep(sleepTime * 1000);

                    now = DateTime.Now;

                    // capture intervals every minute
                    if (now.Second == 0)
                        captureIntervals(now);

                    // check if reports need to be sent every 10 seconds
                    sendReports(now);
                }
                catch (ThreadInterruptedException)
                {
                }
                catch (Exception ex)
                {
                    oadrlib.lib.helper.Logger.logException(ex);
                }
            }
        }

        /**********************************************************************************/

        public void addCreateReport(oadrCreateReportType createReport)
        {
            lock (this)
            {
                m_reportHandler.createReport(createReport.oadrReportRequest, m_reports, m_ridToInterval);
            }
        }

        /**********************************************************************************/

        /// <summary>
        /// Clear all active reports.  Cancels all reports without sending additional reports 
        /// to the VTN
        /// </summary>
        public void clearReports()
        {
            m_reportHandler.clearReports();
        }

        /**********************************************************************************/

        /// <summary>
        /// Cancel the incoming report.  Return a list of pending reports (reportRequestIds)
        /// </summary>
        /// <param name="cancelReport"></param>
        /// <returns></returns>
        public List<string> addCancelReport(oadrCancelReportType cancelReport)
        {
            List<string> pendingReports;

            lock (this)
            {
                pendingReports = m_reportHandler.cancelReport(cancelReport);
            }

            return pendingReports;
        }

        /**********************************************************************************/

        public void startThread()
        {
            if (m_running)
                return;

            m_running = true;

            m_thread = new Thread(delegate()
            {
                execute();
            });

            m_thread.Start();
        }

        /**********************************************************************************/

        public void stopThread()
        {
            if (!m_running)
                return;

            m_running = false;

            m_thread.Interrupt();
            m_thread.Join();
        }
    }
}
