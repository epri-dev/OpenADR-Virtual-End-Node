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

using oadrlib.lib.oadr2b;

using oadrlib.lib.helper;

namespace oadr2b_ven.UserControls.OptSchedule
{
    public partial class oadrucManageOptSchedulesView : UserControl
    {
        private Dictionary<string, oadrOptScheduleModel> m_schedulesByOptId = new Dictionary<string, oadrOptScheduleModel>();
        private Dictionary<string, ListViewItem> m_scheduleLvi = new Dictionary<string, ListViewItem>();

        IManageOptSchedules m_manageOptSchedules;

        /**********************************************************/

        public oadrucManageOptSchedulesView()
        {
            InitializeComponent();

            ucOptScheduleView1.setReadOnly(true);

            lstSchedules.SelectedIndexChanged += lstSchedules_SelectedIndexChanged;
        }

        /**********************************************************/

        private void createOptSchedules(oadrOptScheduleModel optScheduleModel)
        {
            oadrlib.lib.oadr2b.OptSchedule optSchedule;

            if ((optSchedule = optScheduleModel.getOptSchedule()) != null)
            {
                m_manageOptSchedules.createOptSchedule(optSchedule);
            }
        }

        /**********************************************************/

        private void btnNewSchedule_Click(object sender, EventArgs e)
        {
            frmOADRNewScheduleView newSchedule = new frmOADRNewScheduleView();

            DialogResult result = newSchedule.ShowDialog();

            if (result != DialogResult.OK)
                return;            

            oadrOptScheduleModel optScheduleModel = newSchedule.getOptScheduleModel();

            ListViewItem lvi = new ListViewItem(optScheduleModel.Name);
            lvi.SubItems.Add(optScheduleModel.OptID);
            lvi.SubItems.Add("False");
            lstSchedules.Items.Add(lvi);

            m_scheduleLvi.Add(optScheduleModel.OptID, lvi);

            m_schedulesByOptId.Add(optScheduleModel.OptID, optScheduleModel);

            // createOptSchedules(optScheduleModel);
        } 

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public SplitContainer SplitContainer
        {
            get { return splitContainer1; }
        }

        /********************************************************************************/

        public void addOptSchedule(CreateOpt createOpt)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    string optId = createOpt.response.optID;

                    if (!m_schedulesByOptId.ContainsKey(optId))
                        return;

                    oadrOptScheduleModel optScheduleModel = m_schedulesByOptId[optId];

                    optScheduleModel.OptInRegistered = true;
                    optScheduleModel.OptOutRegistered = true;

                    m_scheduleLvi[optId].SubItems[2].Text = "True";
                }
                catch (Exception ex)
                {
                    Logger.logException(ex);
                }

                // lstSchedules.Items.Add(createOpt.response.optID);
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();            
        }

        /********************************************************************************/

        private void removeOptSchedule(string optID)
        {
            if (m_schedulesByOptId.ContainsKey(optID))
            {
                m_schedulesByOptId.Remove(optID);
                ListViewItem lvi = m_scheduleLvi[optID];

                m_scheduleLvi.Remove(optID);

                lstSchedules.Items.Remove(lvi);
            }
        }

        /********************************************************************************/

        public void cancelOptSchedule(CancelOpt cancelOpt)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    string optID = cancelOpt.response.optID.Split('-')[0];

                    removeOptSchedule(optID);

                    // clear the opt view
                    ucOptScheduleView1.reset();
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

        /********************************************************************************/

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
                return;

            DialogResult result = MessageBox.Show("This action will cancel the opt schedule on the VTN.  Click OK to confirm.", "Cancel Opt Schedule?", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            string optID = lstSchedules.SelectedItems[0].SubItems[1].Text;

            oadrOptScheduleModel optScheduleModel = m_schedulesByOptId[optID];

            m_manageOptSchedules.cancelOptSchedule(optScheduleModel.OptID);
        }

        /********************************************************************************/

        private void lstSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
                return;

            string optID = lstSchedules.SelectedItems[0].SubItems[1].Text;

            oadrOptScheduleModel optScheduleModel = m_schedulesByOptId[optID];

            MethodInvoker mi = new MethodInvoker(delegate
            {
                try
                {
                    ucOptScheduleView1.viewOptScheduleModel(optScheduleModel);
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

        /********************************************************************************/

        public void setCreateOptScheduleCallback(IManageOptSchedules manageOptSchedule)
        {
            m_manageOptSchedules = manageOptSchedule;
        }

        /********************************************************************************/

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
                return;

            DialogResult result = MessageBox.Show("This action will resend the opt schedule to the VTN.  Click OK to confirm.", "Resend Opt Schedule?", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            string optID = lstSchedules.SelectedItems[0].SubItems[1].Text;

            oadrOptScheduleModel optScheduleModel = m_schedulesByOptId[optID];

            createOptSchedules(optScheduleModel);
        }

        /********************************************************************************/

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
                return;

            DialogResult result = MessageBox.Show("This action will delete the opt schedule from the VEN without notifying the VTN.  Click OK to confirm.", "Delete Opt Schedule?", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            string optID = lstSchedules.SelectedItems[0].SubItems[1].Text;

            removeOptSchedule(optID);
        }

        /********************************************************************************/

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lstSchedules.SelectedItems.Count == 0)
                return;

            string optID = lstSchedules.SelectedItems[0].SubItems[1].Text;

            oadrOptScheduleModel optScheduleModel = m_schedulesByOptId[optID];

            frmOADRNewScheduleView newSchedule = new frmOADRNewScheduleView();

            newSchedule.loadOadrOptScheduleModel(optScheduleModel);

            DialogResult result = newSchedule.ShowDialog();

            if (result != DialogResult.OK)
                return;

            // update the model
            optScheduleModel = newSchedule.getOptScheduleModel(optScheduleModel);

            m_schedulesByOptId[optID] = optScheduleModel;

            ListViewItem lvi = m_scheduleLvi[optID];
            lvi.SubItems[0].Text = optScheduleModel.Name;

            // m_schedulesByOptId.Add(optScheduleModel.OptID, optScheduleModel);

        }
    }
}
