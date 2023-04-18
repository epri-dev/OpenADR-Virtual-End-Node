namespace Oadr.Ven.Helpers
{
    internal class ClearLog : GetUserResponse
    {
        private readonly MainForm _form;

        public ClearLog(MainForm form)
        {
            _form = form;
        }

        public override void OnCancel()
        {
        }

        public override void OnContinue()
        {
            _form.ClearLog();
        }
    }
}
