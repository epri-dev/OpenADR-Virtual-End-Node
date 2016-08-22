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
    public class ReportName
    {
        private string _name;

        public ReportName(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public string MetaDataName
        {
            get { return "METADATA_" + _name; }
        }

        public static ReportName HISTORY_USAGE = new ReportName("HISTORY_USAGE");
        public static ReportName HISTORY_GREENBUTTON = new ReportName("HISTORY_GREENBUTTON");
        public static ReportName TELEMETRY_USAGE = new ReportName("TELEMETRY_USAGE");
        public static ReportName TELEMETRY_STATUS = new ReportName("TELEMETRY_STATUS");
    }
/*
    public class MetaDataReportName : ReportName
    {
        public MetaDataReportName(string name) : base(name) { }

        public static MetaDataReportName METADATA_HISTORY_USAGE = new MetaDataReportName("METADATA_HISTORY_USAGE");
        public static MetaDataReportName METADATA_HISTORY_GREENBUTTON = new MetaDataReportName("METADATA_HISTORY_GREENBUTTON");
        public static MetaDataReportName METADATA_TELEMETRY_USAGE = new MetaDataReportName("METADATA_TELEMETRY_USAGE");
        public static MetaDataReportName METADATA_TELEMETRY_STATUS = new MetaDataReportName("METADATA_TELEMETRY_STATUS");

    }

    public class DataReportName : ReportName
    {
        public DataReportName(string name) : base(name) { }

        public static DataReportName HISTORY_USAGE = new DataReportName("HISTORY_USAGE");
        public static DataReportName HISTORY_GREENBUTTON = new DataReportName("HISTORY_GREENBUTTON");
        public static DataReportName TELEMETRY_USAGE = new DataReportName("TELEMETRY_USAGE");
        public static DataReportName TELEMETRY_STATUS = new DataReportName("TELEMETRY_STATUS");
    }
 */ 
}
