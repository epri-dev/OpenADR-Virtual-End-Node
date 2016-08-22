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
    public class OadrPoll : OadrRequest2b
    {
        public oadrPollType request;

        public object response;

        public OadrPoll()
            : base("oadrPoll", "?")
        {
        }


        /**********************************************************/

        public string createOadrPoll(string venID)
        {
            request = new oadrPollType();

            request.venID = venID;

            request.schemaVersion = "2.0b";

            return serializeObject((object)request);
        }

        /**********************************************************/

        public oadrResponseType getOadrResponse()
        {
            return (oadrResponseType)response;
        }

        /**********************************************************/

        public oadrDistributeEventType getDistributeEventResponse()
        {
            return (oadrDistributeEventType)response;
        }

        /**********************************************************/

        public oadrCreateReportType getCreateReportResponse()
        {
            return (oadrCreateReportType)response;
        }

        /**********************************************************/

        public oadrRegisterReportType getRegisterReportResponse()
        {
            return (oadrRegisterReportType)response;
        }

        /**********************************************************/

        public oadrCancelReportType getCancelReportResponse()
        {
            return (oadrCancelReportType)response;
        }

        /**********************************************************/

        public oadrUpdateReportType getUpdateReportResponse()
        {
            return (oadrUpdateReportType)response;
        }

        /**********************************************************/

        public oadrCancelPartyRegistrationType getCancelPartyRegistrationResponse()
        {
            return (oadrCancelPartyRegistrationType)response;
        }

        /**********************************************************/

        public oadrRequestReregistrationType getRequestReregistrationResponse()
        {
            return (oadrRequestReregistrationType)response;
        }

        /**********************************************************/

        public bool responseTypeIs(Type type)
        {
            return response.GetType() == type;
        }
    }
}
