namespace Oadr.Ven.UserControls.QueryRegistration
{
    public interface IQueryRegistration
    {
        void ProcessQueryRegistration();

        void ProcessCancelRegistration();

        void ProcessRegister();

        /// <summary>
        /// Clear registration info w/o sending message to the VTN.
        /// </summary>
        void ProcessClearRegistration();
    }
}
