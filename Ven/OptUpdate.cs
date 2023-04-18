using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Ven
{
    internal class OptUpdate
    {
        public List<oadrDistributeEventTypeOadrEvent> Events { get; }

        public OptTypeType OptType { get; }

        public OptUpdate(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType)
        {
            Events = events;
            OptType = optType;
        }
    }
}
