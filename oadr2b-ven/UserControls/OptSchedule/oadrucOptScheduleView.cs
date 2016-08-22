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

namespace oadr2b_ven.UserControls.OptSchedule
{
    public partial class oadrucOptScheduleView : UserControl
    {

        public oadrucOptScheduleView()
        {
            InitializeComponent();
            
            txtOptID.Text = string.Empty;
           
            cmbOptType.SelectedIndex = 0;
            cmbOptReason.SelectedIndex = 0;
            txtMarketContext.Text = string.Empty;

            lvAvailability.Items.Clear();

            dtStart.Value = DateTime.Now;

            numericUpDownDuration.Value = 1;
        }

        /********************************************************************************/

        public oadrOptScheduleModel getOptScheduleModel(oadrOptScheduleModel optScheduleModel = null)
        {
            if (optScheduleModel == null)
                optScheduleModel = new oadrOptScheduleModel();

            optScheduleModel.OptType = cmbOptType.SelectedItem.ToString();
            optScheduleModel.OptReason = cmbOptReason.SelectedItem.ToString();

            optScheduleModel.MarketContext = txtMarketContext.Text;

            optScheduleModel.ResourceID = txtResource.Text;

            optScheduleModel.ScheduleList = new List<OadrAvailable>();

            int nRow = lvAvailability.Items.Count;

            for (int i = 0; i < nRow; i++)
            {
                OadrAvailable obj = new OadrAvailable();
                
                ListViewItem lvi = lvAvailability.Items[i];

                obj.StartDate = Convert.ToDateTime(lvi.SubItems[0].Text);
                obj.Duration = Convert.ToInt32(lvi.SubItems[1].Text);

                optScheduleModel.ScheduleList.Add(obj);
            }

            return optScheduleModel;
        }

        /********************************************************************************/

        public void viewOptScheduleModel(oadrOptScheduleModel optScheduleModel)
        {
            txtOptID.Text = optScheduleModel.OptID;
            
            cmbOptType.SelectedItem = optScheduleModel.OptType;
            cmbOptReason.SelectedItem = optScheduleModel.OptReason;
            txtMarketContext.Text = optScheduleModel.MarketContext;
            txtResource.Text = optScheduleModel.ResourceID;

            // dataGridViewSchedule.DataSource = optScheduleModel.ScheduleList;

            lvAvailability.Items.Clear();

            foreach (OadrAvailable available in optScheduleModel.ScheduleList)
            {
                ListViewItem lvi = new ListViewItem(available.StartDate.ToString("ddd MMM dd yyyy hh:mm tt"));

                lvi.SubItems.Add(available.Duration.ToString());

                lvAvailability.Items.Add(lvi);
            }

            dtStart.Value = DateTime.Now;

            numericUpDownDuration.Value = 1;
        }

        /********************************************************************************/

        public void setReadOnly(bool readOnly)
        {
            bool enabled = !readOnly;

            dtStart.Visible = enabled;
            btnAddSchedule.Visible = enabled;
            numericUpDownDuration.Visible = enabled;
            label3.Visible = enabled;
            label4.Visible = enabled;

            btnDeleteSchedule.Visible = enabled;

            cmbOptReason.Enabled = enabled;
            cmbOptType.Enabled = enabled;
            txtMarketContext.Enabled = enabled;

            txtResource.Enabled = enabled;
        }

        /********************************************************************************/

        public void reset()
        { 
            // txtOptID.Text = string.Empty;
           
            cmbOptType.SelectedIndex = 0;
            cmbOptReason.SelectedIndex = 0;
            // txtMarketContext.Text = string.Empty;
            
            lvAvailability.Items.Clear();

            dtStart.Value = DateTime.Now;

            numericUpDownDuration.Value = 1;
        }

        /********************************************************************************/

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            DateTime scheduleDateTime = new DateTime(dtStart.Value.Year, dtStart.Value.Month, dtStart.Value.Day, dtStart.Value.Hour, dtStart.Value.Minute, dtStart.Value.Second);

            ListViewItem lvi = new ListViewItem(scheduleDateTime.ToString("ddd MMM dd yyyy hh:mm tt"));

            lvi.SubItems.Add(numericUpDownDuration.Value.ToString());
            
            lvAvailability.Items.Add(lvi);

        }

        /********************************************************************************/

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (lvAvailability.SelectedItems.Count == 0)
                return;

            while (lvAvailability.SelectedItems.Count > 0)
                lvAvailability.Items.Remove(lvAvailability.SelectedItems[0]);
        }
   
    }
}
