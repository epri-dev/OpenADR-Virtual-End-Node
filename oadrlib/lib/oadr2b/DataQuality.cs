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
    public class DataQuality
    {
        private string _qualityType;

        public DataQuality(string qualityType)
        {
            _qualityType = qualityType;
        }

        public string QualityType
        {
            get { return _qualityType; }
        }

        public static DataQuality noQuality = new DataQuality("No Quality - No Value");
        public static DataQuality noNewValue = new DataQuality("No New Value - Previous Value Used");
        public static DataQuality qualityBadNonSpecific = new DataQuality("Quality Bad - Non Specific");
        public static DataQuality qualityBadConfigurationError = new DataQuality("Quality Bad - Configuration Error");
        public static DataQuality qualityBadNotconnected = new DataQuality("Quality Bad - Not Connected");
        public static DataQuality qualityBadDeviceFailure = new DataQuality("Quality Bad - Device Failure");
        public static DataQuality qualityBadSensorFailure = new DataQuality("Quality Bad - Sensor Failure");
        public static DataQuality qualityBadLastKnownValue = new DataQuality("Quality Bad - Last Known Value");
        public static DataQuality qualityBadCommFailure = new DataQuality("Quality Bad - Comm Failure");
        public static DataQuality qualityBadOutOfService = new DataQuality("Quality Bad - Out of Service");
        public static DataQuality qualiytUncertainNonSpecific = new DataQuality("Quality Uncertain - Non Specific");
        public static DataQuality qualiytUncertainLastUsableValue = new DataQuality("Quality Uncertain - Last Usable Value");
        public static DataQuality qualiytUncertainSensorNotAccurate = new DataQuality("Quality Uncertain - Sensor Not Accurate");
        public static DataQuality qualiytUncertainEUUnitsExceeded = new DataQuality("Quality Uncertain - EU Units Exceeded");
        public static DataQuality qualiytUncertainSubNormal = new DataQuality("Quality Uncertain - Sub Normal");
        public static DataQuality qualityGoodNonSpecific = new DataQuality("Quality Good - Non Specific");
        public static DataQuality qualityGoodLocalOverride = new DataQuality("Quality Good - Local Override");
        public static DataQuality qualityLimitFieldNot = new DataQuality("Quality Limit - Field/Not");
        public static DataQuality qualityLimitFieldLow = new DataQuality("Quality Limit - Field/Low");
        public static DataQuality qualityLimitFieldHigh = new DataQuality("Quality Limit - Field/High");
        public static DataQuality qualityLimitFieldConstant = new DataQuality("Quality Limit - Field/Constant");
    }
}
