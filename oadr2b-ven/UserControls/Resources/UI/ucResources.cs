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

using oadrlib.lib;

namespace oadr2b_ven.UserControls.Resources.UI
{
    public partial class ucResources : UserControl
    {
        private IManageResources m_callbacks;

        Dictionary<string, ven.resources.Resource> m_resources = new Dictionary<string, ven.resources.Resource>();

        public ucResources()
        {
            InitializeComponent();
            cmbResourceType.SelectedIndex = 0;
        }

        /**********************************************************/

        public void setCallback(IManageResources callback)
        {
            m_callbacks = callback;
        }

        /**********************************************************/

        private void btnRegisterReports_Click(object sender, EventArgs e)
        {
            if (m_callbacks != null)
                m_callbacks.processRegisterReports();
        }

        /**********************************************************/

        private void resource_OnRemoveResource(object sender, EventArgs e)
        {
            ucResource ucresource = (ucResource)sender;

            if (m_callbacks != null)
                m_callbacks.removeResource(ucresource.getResource());

            m_resources.Remove(ucresource.getResource().ResourceID);

            ucresource.OnRemoveResource -= resource_OnRemoveResource;

            pnlResources.Controls.Remove(ucresource.getUserControl());
        }

        /**********************************************************/

        public void addResource(string resourceID, string resourceType)
        {
            IucResource ucresource = null;

            if (resourceType == "Load")
            {
                ucresource = new ucLoad(resourceID);
            }
            else if (resourceType == "Generator")
            {
                ucresource = new ucGenerator(resourceID);
            }
            else if (resourceType == "Storage")
            {
                //ucresource = new ucStorage();
            }
            else
            {
                ucresource = new ucLoad(resourceID);
            }

            m_resources.Add(ucresource.getResource().ResourceID, ucresource.getResource());

            ucresource.getUserControl().Dock = DockStyle.Top;

            pnlResources.Controls.Add(ucresource.getUserControl());

            ucresource.getucResource().OnRemoveResource += resource_OnRemoveResource;

            if (m_callbacks != null)
                m_callbacks.addResource(ucresource.getResource());
        }

        /**********************************************************/

        private void btnAddResource_Click(object sender, EventArgs e)
        {
            string resourceID = tbResourceID.TextBoxText;

            if (resourceID != "")
            {
                // check that resourceID is unique
                if (m_resources.ContainsKey(resourceID))
                {
                    MessageBox.Show("The selected Resource ID is not unique.  Please select a new Resource ID.", "Resource ID is not unique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                resourceID = RandomHex.instance().generateRandomHex(10);
            }

            addResource(resourceID, cmbResourceType.SelectedItem.ToString());
        }
    }
}
