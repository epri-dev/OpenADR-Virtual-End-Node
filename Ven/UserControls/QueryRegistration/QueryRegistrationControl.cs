using Oadr.Library;
using Oadr.Library.Profile2B.Models;
using System;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.QueryRegistration
{
    public partial class QueryRegistrationControl : UserControl
    {
        private IQueryRegistration _callbacks;

        public QueryRegistrationControl()
        {
            InitializeComponent();
        }
        
        private void Clear()
        {
            tvOadrProfiles.Nodes.Clear();
            tvExtensions.Nodes.Clear();
            tvServiceSpecificInfo.Nodes.Clear();
        }
        
        public void SetCallbackHandler(IQueryRegistration callbackHandler)
        {
            _callbacks = callbackHandler;
        }

        public void UpdateRegistrationInfo(oadrCreatedPartyRegistrationType registration)
        {
            if (registration == null)
            {
                return;
            }

            var mi = new MethodInvoker(delegate
            {
                try
                {
                    Clear();
                    _registrationId.TextBoxText = registration.registrationID;
                    _venId.TextBoxText = registration.venID;
                    _vtnId.TextBoxText = registration.vtnID;
                    _pollFrequency.TextBoxText = registration.oadrRequestedOadrPollFreq.duration;

                    foreach (var profile in registration.oadrProfiles)
                    {
                        var treeNode = new TreeNode("Profile: " + profile.oadrProfileName.ToString().Substring(4));
                        tvOadrProfiles.Nodes.Add(treeNode);
                        foreach (var transport in profile.oadrTransports)
                        {
                            treeNode.Nodes.Add($"Transport: {transport.oadrTransportName}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });

            Invoke(mi);
        }
        
        public void CancelRegistration()
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    Clear();
                    _registrationId.TextBoxText = string.Empty;
                    _venId.TextBoxText = string.Empty;
                    _vtnId.TextBoxText = string.Empty;
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });

            Invoke(mi);
        }
        
        private void OnQueryRegistrationClick(object sender, EventArgs e)
        {
            _callbacks?.ProcessQueryRegistration();
        }
        
        private void OnCancelRegistrationClick(object sender, EventArgs e)
        {
            _callbacks?.ProcessCancelRegistration();
        }
        
        private void OnRegisterClick(object sender, EventArgs e)
        {
            _callbacks?.ProcessRegister();
        }
        
        private void OnClearRegistrationClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This action will clear the VEN registration information locally. No message is sent to the VTN. Press OK to clear registration information.", "Clear registration information?", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
            {
                return;
            }

            _registrationId.TextBoxText = string.Empty;
            _venId.TextBoxText = string.Empty;
            _callbacks?.ProcessClearRegistration();
        }

        private void Invoke(MethodInvoker mi)
        {
            // BeginInvoke only needs to be called if we're trying to update the UI from a thread that did not create it.
            if (InvokeRequired)
            {
                BeginInvoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }
    }
}
