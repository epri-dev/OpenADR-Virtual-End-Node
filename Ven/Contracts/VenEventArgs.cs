using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Ven
{
    internal class VenEventArgs : EventArgs
    {
        private readonly object _object;

        public EVenEventType EventType { get; }
        
        public bool ThreadStopped { get; }

        public VenEventArgs(object obj, EVenEventType venEventType, bool threadStopped = false)
        {
            _object = obj;
            EventType = venEventType;
            ThreadStopped = threadStopped;
        }

        public Exception GetException()
        {
            return (Exception)_object;
        }
        
        public RequestEvent GetRequestEvent()
        {
            return (RequestEvent)_object;
        }
        
        public CreatedEvent GetCreatedEvent()
        {
            return (CreatedEvent)_object;
        }
        
        public CreatePartyRegistration GetCreatePartyRegistration()
        {
            return (CreatePartyRegistration)_object;
        }
        
        public QueryRegistration GetQueryRegistration()
        {
            return (QueryRegistration)_object;
        }
        
        public OadrPoll GetOadrPoll()
        {
            return (OadrPoll)_object;
        }
        
        public CreateOpt GetCreateOpt()
        {
            return (CreateOpt)_object;
        }
        
        public string GetStatus()
        {
            return (string)_object;
        }
        
        public List<oadrDistributeEventTypeOadrEvent> GetOadrEvents()
        {
            return (List<oadrDistributeEventTypeOadrEvent>)_object;
        }
    }

    internal enum EVenEventType
    {
        Exception,
        
        CreatePartyRegistration,
        
        QueryRegistration,
        
        RequestEvent,
        
        CreatedEvent,
        
        UpdateStatus,
        
        Poll,
        
        CreateOpt,
        
        UpdateEventStatus
    }
}