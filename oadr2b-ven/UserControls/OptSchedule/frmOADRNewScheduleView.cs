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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oadr2b_ven.UserControls.OptSchedule
{
    public partial class frmOADRNewScheduleView : Form
    {
        public frmOADRNewScheduleView()
        {
            InitializeComponent();

            tbScheduleName.checkTextValue();
        }

        /**********************************************************/

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            if (tbScheduleName.TextBoxText == "")
            {
                MessageBox.Show("Schedule name is reuqired.");

                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /**********************************************************/

        private void btnReset_Click(object sender, EventArgs e)
        {
            ucOptScheduleView1.reset();
        }

        /**********************************************************/

        private void btnCancel_Click(object sender, EventArgs e)
        {
        
            DialogResult result = MessageBox.Show("All changes will be lost.  Are you sure you wish to continue?  Click yes to lose changes.  Click NO to continue editing.", "Cancel?", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /**********************************************************/

        public oadrOptScheduleModel getOptScheduleModel(oadrOptScheduleModel model = null)
        {
            model = ucOptScheduleView1.getOptScheduleModel(model);

            model.Name = tbScheduleName.TextBoxText;

            return model;
        }

        /**********************************************************/

        public void loadOadrOptScheduleModel(oadrOptScheduleModel model)
        {
            ucOptScheduleView1.viewOptScheduleModel(model);

            tbScheduleName.TextBoxText = model.Name;
        }

        private void ucOptScheduleView1_Load(object sender, EventArgs e)
        {

        }

        /**********************************************************/
    }
}
