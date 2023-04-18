using Oadr.Library;
using Oadr.Library.Profile2B;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public partial class ManageOptSchedulesViewControl : UserControl
    {
        private readonly Dictionary<string, OptScheduleModel> _schedulesByOptId = new Dictionary<string, OptScheduleModel>();
        private readonly Dictionary<string, ListViewItem> _scheduleItems = new Dictionary<string, ListViewItem>();

        private IManageOptSchedules _manageOptSchedules;

        [ComVisible(true), Browsable(true)]
        public SplitContainer SplitContainer => splitContainer;

        public ManageOptSchedulesViewControl()
        {
            InitializeComponent();
            ucOptScheduleView.SetReadOnly(true);
            lstSchedules.SelectedIndexChanged += OnSchedulesSelectedIndexChanged;
        }

        private void CreateOptSchedules(OptScheduleModel optScheduleModel)
        {
            Library.Profile2B.OptSchedule optSchedule;

            if ((optSchedule = optScheduleModel.GetOptInSchedule()) != null)
            {
                _manageOptSchedules.CreateOptSchedule(optSchedule);
            }

            if ((optSchedule = optScheduleModel.GetOptOutSchedule()) != null)
            {
                _manageOptSchedules.CreateOptSchedule(optSchedule);
            }
        }
        
        public void AddOptSchedule(CreateOpt createOpt)
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    var optId = createOpt.Response.optID.Split('-')[0];
                    if (!_schedulesByOptId.ContainsKey(optId))
                    {
                        return;
                    }

                    var optScheduleModel = _schedulesByOptId[optId];
                    optScheduleModel.OptInRegistered = true;
                    optScheduleModel.OptOutRegistered = true;
                    _scheduleItems[optId].SubItems[2].Text = "True";
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });

            Invoke(mi);
        }
        
        private void RemoveOptSchedule(string optId)
        {
            if (_schedulesByOptId.ContainsKey(optId))
            {
                _schedulesByOptId.Remove(optId);
                var item = _scheduleItems[optId];
                _scheduleItems.Remove(optId);
                lstSchedules.Items.Remove(item);
            }
        }
        
        public void CancelOptSchedule(CancelOpt cancelOpt)
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    var optId = cancelOpt.Response.optID.Split('-')[0];
                    RemoveOptSchedule(optId);
                    // Clear the opt view.
                    ucOptScheduleView.Reset();
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });

            Invoke(mi);
        }
        
        public void SetCreateOptScheduleCallback(IManageOptSchedules manageOptSchedule)
        {
            _manageOptSchedules = manageOptSchedule;
        }
        
        private void btnNewSchedule_Click(object sender, EventArgs e)
        {
            var newSchedule = new NewScheduleViewForm();
            var result = newSchedule.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }            

            var optScheduleModel = newSchedule.GetOptScheduleModel();
            var item = new ListViewItem(optScheduleModel.Name);
            item.SubItems.Add(optScheduleModel.OptId);
            item.SubItems.Add("False");
            lstSchedules.Items.Add(item);

            _scheduleItems.Add(optScheduleModel.OptId, item);
            _schedulesByOptId.Add(optScheduleModel.OptId, optScheduleModel);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
            {
                return;
            }

            var result = MessageBox.Show("This action will cancel the opt schedule on the VTN. Click OK to confirm.", "Cancel Opt Schedule?", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
            {
                return;
            }

            var optId = lstSchedules.SelectedItems[0].SubItems[1].Text;
            var optScheduleModel = _schedulesByOptId[optId];

            // TODO: Only send a cancel for the schedule(s) that were created.
            _manageOptSchedules.CancelOptSchedule(optScheduleModel.OptId + "-IN");
            _manageOptSchedules.CancelOptSchedule(optScheduleModel.OptId + "-OUT");
        }
        
        private void OnSchedulesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
            {
                return;
            }

            var optId = lstSchedules.SelectedItems[0].SubItems[1].Text;
            var optScheduleModel = _schedulesByOptId[optId];
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    ucOptScheduleView.ViewOptScheduleModel(optScheduleModel);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });

            Invoke(mi);
        }
        
        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
            {
                return;
            }

            var result = MessageBox.Show("This action will send the opt schedule to the VTN. Click OK to confirm.", "Resend Opt Schedule?", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
            {
                return;
            }

            var optId = lstSchedules.SelectedItems[0].SubItems[1].Text;
            var optScheduleModel = _schedulesByOptId[optId];
            CreateOptSchedules(optScheduleModel);
        }
        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
            {
                return;
            }

            var result = MessageBox.Show("This action will delete the opt schedule from the VEN without notifying the VTN. Click OK to confirm.", "Delete Opt Schedule?", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
            {
                return;
            }

            var optId = lstSchedules.SelectedItems[0].SubItems[1].Text;
            RemoveOptSchedule(optId);
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
