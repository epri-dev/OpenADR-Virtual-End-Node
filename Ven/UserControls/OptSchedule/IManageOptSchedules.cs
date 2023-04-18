namespace Oadr.Ven.UserControls.OptSchedule
{
    public interface IManageOptSchedules
    {
        void CreateOptSchedule(Library.Profile2B.OptSchedule optSchedule);

        void CancelOptSchedule(string optId);
    }
}
