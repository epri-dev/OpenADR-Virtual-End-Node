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
    public class CreateOpt : OadrRequest2b
    {
        public oadrCreateOptType request;
        public oadrCreatedOptType response;

        public CreateOpt()
            : base("oadrCreateOpt", "oadrCreatedOpt")
        {
        }

        /**********************************************************/

        private void initOpt(string requestID, string optID, OptTypeType optType, OptReasonEnumeratedType optReason, string venID, string marketContext = null)
        {
            request = new oadrCreateOptType();

            request.schemaVersion = "2.0b";
            request.requestID = requestID;
            request.optID = optID;
            request.optType = optType;
            request.optReason = (optReason == OptReasonEnumeratedType.xschedule ? "x-schedule" : optReason.ToString());

            if (marketContext != null)
                request.marketContext = marketContext;

            request.venID = venID;

            request.createdDateTime = DateTime.UtcNow;
        }

        /**********************************************************/

        public string createOptSchedule(string requestID, string venID, OptSchedule optSchedule)
        {
            initOpt(requestID, optSchedule.OptID, optSchedule.OptType, optSchedule.OptReason, venID, optSchedule.MarketContext);

            if (optSchedule.ResourceID != null && optSchedule.ResourceID != "")
            {
                request.eiTarget = new EiTargetType();
                request.eiTarget.resourceID = new string[1];
                request.eiTarget.resourceID[0] = optSchedule.ResourceID;
            }

            request.vavailability = new VavailabilityType();
            request.vavailability.components = new AvailableType[optSchedule.Count];

            int index = 0;
            foreach (AvailableType availableType in optSchedule.Schedule)
            {
                request.vavailability.components[index] = availableType;
                index++;
            }

            return serializeObject(request);
        }

        /**********************************************************/

        public string createOptEvent(string requestID, string optID, oadrDistributeEventTypeOadrEvent evt, OptTypeType optType, OptReasonEnumeratedType optReason, string venID, string resourceID = null)
        {
            initOpt(requestID, optID, optType, optReason, venID);

            request.qualifiedEventID = new QualifiedEventIDType();
            request.qualifiedEventID.eventID = evt.eiEvent.eventDescriptor.eventID;
            request.qualifiedEventID.modificationNumber = evt.eiEvent.eventDescriptor.modificationNumber;

            if (resourceID != null)
            {
                request.eiTarget = new EiTargetType();
                request.eiTarget.resourceID = new string[1];
                request.eiTarget.resourceID[0] = resourceID;
            }

            return serializeObject(request);
        }
    }
}
