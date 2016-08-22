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
using System.Threading.Tasks;
using System.Windows.Forms;

using oadrlib.lib;

namespace oadr2b_ven.UserControls.Resources.UI
{
    public partial class ucLoad : UserControl, IucResource
    {
        private ven.resources.ResourceLoad m_resource;

        public ucLoad()
        {
            InitializeComponent();

            initResource(RandomHex.instance().generateRandomHex(10));
        }

        /********************************************************************************/

        public ucLoad(string resourceID)
        {
            InitializeComponent();

            if (resourceID == null || resourceID == "")
                resourceID = RandomHex.instance().generateRandomHex(10);

            initResource(resourceID);
        }

        /********************************************************************************/

        private void initResource(string resourceID)
        {
            ucResource1.setCallbacks(this);

            m_resource = new ven.resources.ResourceLoad(resourceID);

            ucResource1.ResourceID = m_resource.ResourceID;

            setControls(false);
        }

        /********************************************************************************/

        private void setControls(bool enableEdit)
        {
            tbUsage.ReadOnly = !enableEdit;
        }

        /********************************************************************************/

        public void edit()
        {
            setControls(true);            
        }

        /********************************************************************************/

        public bool save()
        {
            double value = tbUsage.ValueDouble;

            if (value == Double.MaxValue)
                return false;

            m_resource.Online = ucResource1.chkOnline.Checked;
            m_resource.Override = ucResource1.chkOverride.Checked;
            m_resource.W = (float)tbUsage.ValueDouble;

            setControls(false);

            return true;
        }

        /********************************************************************************/

        public void cancel()
        {
            ucResource1.chkOnline.Checked = m_resource.Online;
            ucResource1.chkOverride.Checked = m_resource.Override;
            tbUsage.TextBoxText = m_resource.W.ToString();

            setControls(false);
        }

        /********************************************************************************/

        public void remove()
        {
        }

        /********************************************************************************/

        public ucResource getucResource()
        {
            return ucResource1;
        }

        /********************************************************************************/

        public ven.resources.Resource getResource()
        {
            return m_resource;
        }

        /********************************************************************************/

        public UserControl getUserControl()
        {
            return this;
        }

    }
}
