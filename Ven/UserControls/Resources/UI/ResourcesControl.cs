using Oadr.Library;
using Oadr.Ven.Resources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Resources.UI
{
    public partial class ResourcesControl : UserControl
    {
        private readonly Dictionary<string, Resource> _resources = new Dictionary<string, Resource>();

        private IManageResources _callbacks;

        public ResourcesControl()
        {
            InitializeComponent();
            cmbResourceType.SelectedIndex = 0;
        }
        
        public void SetCallback(IManageResources callback)
        {
            _callbacks = callback;
        }
        
        private void btnRegisterReports_Click(object sender, EventArgs e)
        {
            _callbacks?.ProcessRegisterReports();
        }
        
        private void resource_OnRemoveResource(object sender, EventArgs e)
        {
            var resourceControl = (ResourceControl)sender;

            _callbacks?.RemoveResource(resourceControl.GetResource());
            _resources.Remove(resourceControl.GetResource().ResourceId);

            resourceControl.OnRemoveResource -= resource_OnRemoveResource;
            pnlResources.Controls.Remove(resourceControl.GetUserControl());
        }
        
        public void AddResource(string resourceId, string resourceType)
        {
            IResourceControl resourceControl = null;

            if (resourceType == "Load")
            {
                resourceControl = new LoadControl(resourceId);
            }
            else if (resourceType == "Generator")
            {
                resourceControl = new GeneratorControl(resourceId);
            }
            else if (resourceType == "Storage")
            {
                // ?
            }
            else
            {
                resourceControl = new LoadControl(resourceId);
            }

            _resources.Add(resourceControl.GetResource().ResourceId, resourceControl.GetResource());
            resourceControl.GetUserControl().Dock = DockStyle.Top;
            pnlResources.Controls.Add(resourceControl.GetUserControl());
            resourceControl.GetUserControlResource().OnRemoveResource += resource_OnRemoveResource;
            _callbacks?.AddResource(resourceControl.GetResource());
        }
        
        private void btnAddResource_Click(object sender, EventArgs e)
        {
            var resourceId = tbResourceID.TextBoxText;

            if (resourceId != string.Empty)
            {
                // Check that resourceID is unique.
                if (_resources.ContainsKey(resourceId))
                {
                    MessageBox.Show("The selected Resource ID is not unique. Please select a new Resource ID.", "Resource ID is not unique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                resourceId = RandomHex.Instance().GenerateRandomHex(10);
            }
            AddResource(resourceId, cmbResourceType.SelectedItem.ToString());
        }
    }
}
