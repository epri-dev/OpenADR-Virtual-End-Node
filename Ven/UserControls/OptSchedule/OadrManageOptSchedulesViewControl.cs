using Oadr.Library;
using Oadr.Library.Profile2B;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public partial class OadrManageOptSchedulesViewControl : UserControl
    {
        private readonly Dictionary<string, OadrOptScheduleModel> _schedulesByOptId = new Dictionary<string, OadrOptScheduleModel>();
        private readonly Dictionary<string, ListViewItem> _scheduleItems = new Dictionary<string, ListViewItem>();

        private IManageOptSchedules _manageOptSchedules;

        [ComVisible(true), Browsable(true)]
        public SplitContainer SplitContainer => splitContainer;

        public OadrManageOptSchedulesViewControl()
        {
            InitializeComponent();
            ucOptScheduleView.SetReadOnly(true);
            lstSchedules.SelectedIndexChanged += OnSchedulesSelectedIndexChanged;
        }
        
        private void CreateOptSchedules(OadrOptScheduleModel optScheduleModel)
        {
            Library.Profile2B.OptSchedule optSchedule;
            if ((optSchedule = optScheduleModel.GetOptSchedule()) != null)
            {
                _manageOptSchedules.CreateOptSchedule(optSchedule);
            }
        }
        
        private void OnNewScheduleClick(object sender, EventArgs e)
        {
            var newSchedule = new OadrNewScheduleViewForm();

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
        
        public void AddOptSchedule(CreateOpt createOpt)
        {
            var mi = new MethodInvoker(delegate
            {
                try
                {
                    var optId = createOpt.Response.optID;
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
        
        private void OnCancelToolStripMenuItemClick(object sender, EventArgs e)
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
            _manageOptSchedules.CancelOptSchedule(optScheduleModel.OptId);
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
        
        private void OnSendToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
            {
                return;
            }

            var result = MessageBox.Show("This action will resend the opt schedule to the VTN. Click OK to confirm.", "Resend Opt Schedule?", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
            {
                return;
            }

            var optId = lstSchedules.SelectedItems[0].SubItems[1].Text;
            var optScheduleModel = _schedulesByOptId[optId];
            CreateOptSchedules(optScheduleModel);
        }
        
        private void OnDeleteToolStripMenuItemClick(object sender, EventArgs e)
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

        private void OnEditToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItems.Count == 0)
            {
                return;
            }

            var optId = lstSchedules.SelectedItems[0].SubItems[1].Text;
            var optScheduleModel = _schedulesByOptId[optId];
            var newSchedule = new OadrNewScheduleViewForm();
            newSchedule.LoadOadrOptScheduleModel(optScheduleModel);

            var result = newSchedule.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            
            optScheduleModel = newSchedule.GetOptScheduleModel(optScheduleModel);
            _schedulesByOptId[optId] = optScheduleModel;
            var item = _scheduleItems[optId];
            item.SubItems[0].Text = optScheduleModel.Name;
        }
    }
}
