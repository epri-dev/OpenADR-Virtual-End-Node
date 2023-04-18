using Oadr.Ven.Resources;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Resources.UI
{
    public partial class ResourceControl : UserControl
    {
        private EventHandler _handler;
        private IResourceControl _callbacks;

        [ComVisible(true), Browsable(true)]
        public string ResourceTypeName
        {
            get => grpMain.Text;
            set => grpMain.Text = value;
        }

        [ComVisible(true), Browsable(true)]
        public string ResourceId
        {
            get => tbResourceID.TextBoxText;
            set => tbResourceID.TextBoxText = value;
        }

        public event EventHandler OnRemoveResource
        {
            add => _handler += value;
            remove => _handler -= value;
        }

        public ResourceControl()
        {
            InitializeComponent();

            SetButtons(false);
        }

        public void SetCallbacks(IResourceControl callbacks)
        {
            _callbacks = callbacks;
        }

        public Resource GetResource()
        {
            return _callbacks?.GetResource();
        }

        public UserControl GetUserControl()
        {
            return _callbacks?.GetUserControl();
        }

        private void OnRemoveButtonClick(object sender, EventArgs e)
        {
            _handler?.Invoke(this, e);
        }

        private void SetButtons(bool editEnabled)
        {
            btnEdit.Enabled = !editEnabled;
            btnSave.Enabled = editEnabled;
            btnCancel.Enabled = editEnabled;
            chkOnline.Enabled = editEnabled;
            chkOverride.Enabled = editEnabled;
        }

        private void OnEditButtonClick(object sender, EventArgs e)
        {
            SetButtons(true);
            _callbacks?.Edit();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (_callbacks != null)
            {
                if (_callbacks.Save())
                {
                    SetButtons(false);
                }
                else
                {
                    MessageBox.Show("Please fix the indicated errors and save again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            SetButtons(false);
            _callbacks?.Cancel();
        }
    }
}
