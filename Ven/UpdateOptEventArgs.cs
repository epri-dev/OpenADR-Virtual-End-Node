using Oadr.Library.Profile2B.Models;
using System;
using System.Collections.Generic;

namespace Oadr.Ven
{
    internal class UpdateOptEventArgs : EventArgs
    {
        public List<oadrDistributeEventTypeOadrEvent> Events { get; }

        public OptTypeType OptType { get; }

        public UpdateOptEventArgs(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType)
        {
            Events = events;
            OptType = optType;
        }
    }
}
