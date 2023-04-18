using System.Threading;
using System.Windows.Forms;

namespace Oadr.Ven.Helpers
{
    internal abstract class GetUserResponse
    {
        private bool _isRunning;
        
        public void GetResponse(string caption, string prompt)
        {
            lock (this)
            {
                if (_isRunning)
                {
                    return;
                }
                _isRunning = true;
            }

            var thread = new Thread(delegate()
            {
                var result = MessageBox.Show(prompt, caption, MessageBoxButtons.OKCancel);
                try
                {
                    if (result == DialogResult.OK)
                    {
                        OnContinue();
                    }
                    else
                    {
                        OnCancel();
                    }
                }
                finally
                {
                    _isRunning = false;
                }
            });

            thread.Start();
        }

        public abstract void OnContinue();

        public abstract void OnCancel();
    }
}
