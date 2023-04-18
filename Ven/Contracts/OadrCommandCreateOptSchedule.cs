using Oadr.Library.Profile2B;

namespace Oadr.Ven
{
    public class OadrCommandCreateOptSchedule : OadrCommand
    {
        private OptSchedule _optSchedule;

        public OadrCommandCreateOptSchedule(OptSchedule optSchedule)
        {
            _optSchedule = optSchedule;
        }
        
        public override void ExecuteCommand(Ven2B ven)
        {
        }
    }
}
