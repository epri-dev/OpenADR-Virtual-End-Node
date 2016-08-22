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

using oadrlib.lib.oadr2b;

namespace oadr2b_ven.ven
{
    enum eVenEventType
    {
        EXCEPTION,
        CREATE_PARTY_REGISTRATION,
        QUERY_REGISTRATION,
        REQUEST_EVENT,
        CREATED_EVENT,
        UPDATE_STATUS,
        POLL,
        CREATE_OPT,
        UPDATE_EVENT_STATUS
    }

    class VenEventArgs : EventArgs
    {
        object m_object;
        eVenEventType m_eventType;
        bool m_threadStopped;

        public VenEventArgs(object obj, eVenEventType venEventType, bool threadStopped = false)
        {
            m_object = obj;
            m_eventType = venEventType;
            m_threadStopped = threadStopped;
        }

        /**********************************************************/

        public eVenEventType EventType
        {
            get { return m_eventType; }
        }

        /**********************************************************/

        public Exception getException()
        {
            return (Exception)m_object;
        }

        /**********************************************************/

        public RequestEvent getRequestEvent()
        {
            return (RequestEvent)m_object;
        }

        /**********************************************************/

        public CreatedEvent getCreatedEvent()
        {
            return (CreatedEvent)m_object;
        }

        /**********************************************************/

        public CreatePartyRegistration getCreatePartyRegistration()
        {
            return (CreatePartyRegistration)m_object;
        }

        /**********************************************************/

        public QueryRegistration getQueryRegistration()
        {
            return (QueryRegistration)m_object;
        }

        /**********************************************************/


        public OadrPoll getOadrPoll()
        {
            return (OadrPoll)m_object;
        }

        /**********************************************************/

        public CreateOpt getCreateOpt()
        {
            return (CreateOpt)m_object;
        }

        /**********************************************************/

        public string getStatus()
        {
            return (string)m_object;
        }

        /**********************************************************/

        public List<oadrDistributeEventTypeOadrEvent> getOadrEvents()
        {
            return (List<oadrDistributeEventTypeOadrEvent>)m_object;
        }


        /**********************************************************/

        public bool ThreadStopped
        {
            get { return m_threadStopped; }
        }


    }
}