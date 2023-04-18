using System.Reflection;

namespace Oadr.Ven
{
    public partial class SplashForm : System.Windows.Forms.Form
    {
        public SplashForm()
        {
            InitializeComponent();

            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersion.Text = version;
        }
    }
}
