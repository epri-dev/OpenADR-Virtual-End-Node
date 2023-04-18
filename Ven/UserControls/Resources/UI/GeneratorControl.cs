using Oadr.Library;
using Oadr.Ven.Resources;
using System.Globalization;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Resources.UI
{
    public partial class GeneratorControl : UserControl, IResourceControl
    {
        private ResourceGenerator _resource;

        public GeneratorControl()
        {
            InitializeComponent();

            InitResource(RandomHex.Instance().GenerateRandomHex(10));
        }

        public GeneratorControl(string resourceId)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(resourceId))
            {
                resourceId = RandomHex.Instance().GenerateRandomHex(10);
            }
            InitResource(resourceId);
        }

        private void InitResource(string resourceId)
        {
            ucResource.SetCallbacks(this);
            _resource = new ResourceGenerator(resourceId);
            ucResource.ResourceId = _resource.ResourceId;
            SetControls(false);
        }

        private void SetControls(bool enableEdit)
        {
            tbOutput.ReadOnly = !enableEdit;
        }

        public void Edit()
        {
            SetControls(true);
        }

        public bool Save()
        {
            var value = tbOutput.ValueDouble;
            if (value == double.MaxValue)
            {
                return false;
            }

            _resource.Online = ucResource.chkOnline.Checked;
            _resource.Override = ucResource.chkOverride.Checked;
            _resource.W = (float)tbOutput.ValueDouble;
            SetControls(false);
            return true;
        }

        public void Cancel()
        {
            ucResource.chkOnline.Checked = _resource.Online;
            ucResource.chkOverride.Checked = _resource.Override;
            tbOutput.TextBoxText = _resource.W.ToString(CultureInfo.InvariantCulture);
            SetControls(false);
        }

        public void Remove()
        {
        }

        public ResourceControl GetUserControlResource()
        {
            return ucResource;
        }
        
        public Resource GetResource()
        {
            return _resource;
        }
        
        public UserControl GetUserControl()
        {
            return this;
        }
    }
}
