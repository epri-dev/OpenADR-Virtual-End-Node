using System;
using System.Windows.Forms;

namespace Oadr.Ven
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if (!DEBUG)
            var splash = new frmSplash();
            var result = splash.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
#endif
            Application.Run(new MainForm());
        }
    }
}
