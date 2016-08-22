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

using System.Net.Http;

using oadrlib.lib;

using System.Xml.Serialization;
using System.Xml.Serialization.Configuration;
using System.IO;

using oadrlib.lib.http;

using oadrlib.lib.helper;

namespace oadrlib.lib.oadr2a
{
    public class VEN2a : VEN
    {
        public VEN2a(IHttp http, string url, string venID, string password = "", HttpSecuritySettings httpSecuritySettings = null)
            : base(http, url, venID, venID: password)
        {
        }

        /**********************************************************/

        public RequestEvent requestEvent(uint replyLimit = 0, string requestID = "")
        {
            RequestEvent request = new RequestEvent();                       
            
            string requestBody = request.createOadrRequestEvent(VENID, replyLimit, requestID);

            request.distributeEvent = (oadrDistributeEvent)postRequest(requestBody, "/EiEvent", request, typeof(oadrDistributeEvent));

            return request;
        }

        /**********************************************************/

        public CreatedEvent createdEvent(string requestID, List<oadrDistributeEventOadrEvent> evts, OptTypeType optType)
        {
            CreatedEvent createdEvent = new CreatedEvent();

            string requestBody = createdEvent.createdOadrCreatedEvent(VENID, requestID, evts, optType);

            createdEvent.response = (oadrResponse)postRequest(requestBody, "/EiEvent", createdEvent, typeof(oadrResponse));

            return createdEvent;
        }
    }
}
