using Oadr.Library;
using Oadr.Ven.Resources;
using System.Globalization;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Resources.UI
{
    public partial class LoadControl : UserControl, IResourceControl
    {
        private ResourceLoad _resource;

        public LoadControl()
        {
            InitializeComponent();

            InitResource(RandomHex.Instance().GenerateRandomHex(10));
        }
        
        public LoadControl(string resourceId)
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
            _resource = new ResourceLoad(resourceId);
            ucResource.ResourceId = _resource.ResourceId;
            SetControls(false);
        }

        private void SetControls(bool enableEdit)
        {
            tbUsage.ReadOnly = !enableEdit;
        }

        public void Edit()
        {
            SetControls(true);            
        }

        public bool Save()
        {
            var value = tbUsage.ValueDouble;
            if (value == double.MaxValue)
            {
                return false;
            }

            _resource.Online = ucResource.chkOnline.Checked;
            _resource.Override = ucResource.chkOverride.Checked;
            _resource.W = (float)tbUsage.ValueDouble;
            SetControls(false);
            return true;
        }

        public void Cancel()
        {
            ucResource.chkOnline.Checked = _resource.Online;
            ucResource.chkOverride.Checked = _resource.Override;
            tbUsage.TextBoxText = _resource.W.ToString(CultureInfo.InvariantCulture);
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
