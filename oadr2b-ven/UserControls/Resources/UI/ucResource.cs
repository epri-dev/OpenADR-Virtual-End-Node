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
    public partial class ucResource : UserControl
    {
        private EventHandler m_handler;
        private IucResource m_callbacks;

        public ucResource()
        {
            InitializeComponent();

            setButtons(false);
        }

        /********************************************************************************/

        public void setCallbacks(IucResource callbacks)
        {
            m_callbacks = callbacks;
        }

        /********************************************************************************/

        public ven.resources.Resource getResource()
        {
            if (m_callbacks != null)
                return m_callbacks.getResource();

            return null;
        }

        /********************************************************************************/

        public UserControl getUserControl()
        {
            if (m_callbacks != null)
                return m_callbacks.getUserControl();

            return null;
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public string ResourceTypeName
        {
            get { return grpMain.Text; }
            set { grpMain.Text = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public string ResourceID
        {
            get { return tbResourceID.TextBoxText; }
            set { tbResourceID.TextBoxText = value; }
        }

        /********************************************************************************/

        public event EventHandler OnRemoveResource
        {
            add { m_handler += value; }
            remove { m_handler -= value; }
        }

        /********************************************************************************/

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (m_handler != null)            
                m_handler(this, e);           
        }

        /********************************************************************************/

        private void setButtons(bool editEnabled)
        {
            btnEdit.Enabled = !editEnabled;

            btnSave.Enabled = editEnabled;
            btnCancel.Enabled = editEnabled;

            chkOnline.Enabled = editEnabled;
            chkOverride.Enabled = editEnabled;
        }

        /********************************************************************************/

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setButtons(true);

            if (m_callbacks != null)
                m_callbacks.edit();
        }

        /********************************************************************************/

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (m_callbacks != null)
            {
                if (m_callbacks.save())
                    setButtons(false);
                else
                    MessageBox.Show("Please fix the indicated errors and save again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /********************************************************************************/

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButtons(false);

            if (m_callbacks != null)
            {
                m_callbacks.cancel();
            }
        }
    }
}
