//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using oadrlib.lib.oadr2b;

using oadrlib.lib.helper;

using System.Threading;

using oadr2b_ven.UserControls;

namespace oadr2b_ven.UserControls.QueryRegistration
{
    public partial class ucQueryRegistration : UserControl
    {
        IQueryRegistration m_callbacks;

        public ucQueryRegistration()
        {
            InitializeComponent();
        }

        /******************************************************************************/

        private void clear()
        {
            tvOadrProfiles.Nodes.Clear();
            tvExtensions.Nodes.Clear();
            tvServiceSpecificInfo.Nodes.Clear();
        }

        /******************************************************************************/

        public void setCallbackHandler(IQueryRegistration callbackHandler)
        {
            m_callbacks = callbackHandler;
        }

        /**********************************************************/

        /// <summary>
        /// deprecated: the form no longer needs to enable/disable the buttons
        /// previous versions could not let the user press the buttons while the VEN was polling
        /// locks have been added so this should be OK now
        /// </summary>
        public void disableQuery()
        {

            return;

            MethodInvoker mi = new MethodInvoker(delegate
            {
                btnQueryRegistration.Enabled = false;
                btnCancelRegistration.Enabled = false;
                btnRegister.Enabled = false;
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        public void enableQuery()
        {
            return;

            MethodInvoker mi = new MethodInvoker(delegate
            {
                btnQueryRegistration.Enabled = true;
                btnCancelRegistration.Enabled = true;
                btnRegister.Enabled = true;
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        public void updateRegistrationInfo(oadrCreatedPartyRegistrationType registration)
        {
            if (registration == null)
                return;

            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    clear();
                    ucRegistrationID.TextBoxText = registration.registrationID;
                    ucVENID.TextBoxText = registration.venID;
                    ucVTNID.TextBoxText = registration.vtnID;

                    ucPollFrequency.TextBoxText = registration.oadrRequestedOadrPollFreq.duration;


                    foreach (oadrProfilesOadrProfile profile in registration.oadrProfiles)
                    {
                        TreeNode treeNode = new TreeNode("Profile: " + profile.oadrProfileName.ToString().Substring(4));
                        tvOadrProfiles.Nodes.Add(treeNode);

                        foreach (oadrTransportsOadrTransport transport in profile.oadrTransports)
                        {
                            treeNode.Nodes.Add("Transport: " + transport.oadrTransportName.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.logException(ex);
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        public void cancelRegistration()
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    clear();
                    ucRegistrationID.TextBoxText = "";
                    ucVENID.TextBoxText = "";
                    ucVTNID.TextBoxText = "";
                }
                catch (Exception ex)
                {
                    Logger.logException(ex);
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /**********************************************************/

        private void btnQueryRegistration_Click(object sender, EventArgs e)
        {
            if (m_callbacks != null)
                m_callbacks.processQueryRegistration();
        }

        /**********************************************************/

        private void btnCancelRegistration_Click(object sender, EventArgs e)
        {
            if (m_callbacks != null)
                m_callbacks.processCancelRegistration();
        }

        /**********************************************************/

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (m_callbacks != null)
                m_callbacks.processRegister();
        }

        /**********************************************************/

        private void btnClearRegistration_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action will clear the VEN registration information locally.  No message is sent to the VTN.  Press OK to clear registration information.", "Clear reigstration information?", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            ucRegistrationID.TextBoxText = "";
            ucVENID.TextBoxText = "";

            if (m_callbacks != null)
                m_callbacks.processClearRegistration();
        }
    }
}
