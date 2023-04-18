using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Oadr.Ven
{
    partial class AboutBoxForm : System.Windows.Forms.Form
    {
        public AboutBoxForm()
        {
            InitializeComponent();
            Text = $"About {AssemblyTitle}";
            lblSoftware.Text = $"{AssemblyProduct} Version {AssemblyVersion}";
            lblCopyRight.Text = AssemblyCopyright;
            lblDevelopedFor.Text = AssemblyCompany;
            txtDisclaimer.Text = AssemblyDescription;
            lblSupport.Text = "EPRI Customer Assistance Center\r\nPhone: 800-313-3774\r\nEmail: askepri@epri.com";
            lblDevelopedBy.Text = "nebland software, LLC\r\n859 Richborough Rd\r\nGreen Bay, WI 54313\r\nhttp://www.nebland.com";
            lblOrderingInfo.Text = "The embodiments of this Program and supporting materials may be ordered from\r\n" +
                "Electric Power Software Center (EPSC)\r\n" +
                "9625 Research Drive\r\n" +
                "Charlotte, NC 28262\r\n" +
                "Phone  	1-800-313-3774\r\n" +
                "Email      askepri@epri.com\r\n";
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != string.Empty)
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string AssemblyDescription
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion // Assembly Attribute Accessors
    }
}
