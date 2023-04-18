using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;

namespace Oadr.Ven.UserControls.Events
{
    public interface IEvents
    {
        void ProcessEventOpt(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType, string requestId, int responseCode, string responseDescription);

        void ProcessCreateEventOpt(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType, OptReasonEnumeratedType optReason, string resourceId);

        void PopulateLists(List<string> marketContexts, List<string> resources);
    }
}
