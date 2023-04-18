using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public partial class OadrOptScheduleViewControl : UserControl
    {
        public OadrOptScheduleViewControl()
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

        public OadrOptScheduleModel GetOptScheduleModel(OadrOptScheduleModel optScheduleModel = null)
        {
            if (optScheduleModel == null)
            {
                optScheduleModel = new OadrOptScheduleModel();
            }

            optScheduleModel.OptType = cmbOptType.SelectedItem.ToString();
            optScheduleModel.OptReason = cmbOptReason.SelectedItem.ToString();
            optScheduleModel.MarketContext = txtMarketContext.Text;
            optScheduleModel.ResourceId = txtResource.Text;
            optScheduleModel.ScheduleList = new List<OadrAvailable>();

            var nRow = lvAvailability.Items.Count;
            for (var i = 0; i < nRow; i++)
            {
                var item = lvAvailability.Items[i];
                var obj = new OadrAvailable
                {
                    StartDate = Convert.ToDateTime(item.SubItems[0].Text),
                    Duration = Convert.ToInt32(item.SubItems[1].Text)
                };
                optScheduleModel.ScheduleList.Add(obj);
            }

            return optScheduleModel;
        }
        
        public void ViewOptScheduleModel(OadrOptScheduleModel optScheduleModel)
        {
            txtOptID.Text = optScheduleModel.OptId;
            cmbOptType.SelectedItem = optScheduleModel.OptType;
            cmbOptReason.SelectedItem = optScheduleModel.OptReason;
            txtMarketContext.Text = optScheduleModel.MarketContext;
            txtResource.Text = optScheduleModel.ResourceId;
            lvAvailability.Items.Clear();

            foreach (var available in optScheduleModel.ScheduleList)
            {
                var item = new ListViewItem(available.StartDate.ToString("ddd MMM dd yyyy hh:mm tt"));
                item.SubItems.Add(available.Duration.ToString());
                lvAvailability.Items.Add(item);
            }
            dtStart.Value = DateTime.Now;
            numericUpDownDuration.Value = 1;
        }

        public void SetReadOnly(bool readOnly)
        {
            var enabled = !readOnly;
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
        
        public void Reset()
        {
            cmbOptType.SelectedIndex = 0;
            cmbOptReason.SelectedIndex = 0;
            lvAvailability.Items.Clear();
            dtStart.Value = DateTime.Now;
            numericUpDownDuration.Value = 1;
        }
        
        private void OnAddScheduleClick(object sender, EventArgs e)
        {
            var scheduleDateTime = new DateTime(dtStart.Value.Year, dtStart.Value.Month, dtStart.Value.Day, dtStart.Value.Hour, dtStart.Value.Minute, dtStart.Value.Second);
            var item = new ListViewItem(scheduleDateTime.ToString("ddd MMM dd yyyy hh:mm tt"));
            item.SubItems.Add(numericUpDownDuration.Value.ToString(CultureInfo.InvariantCulture));
            lvAvailability.Items.Add(item);
        }
        
        private void OnDeleteScheduleClick(object sender, EventArgs e)
        {
            if (lvAvailability.SelectedItems.Count == 0)
            {
                return;
            }

            while (lvAvailability.SelectedItems.Count > 0)
            {
                lvAvailability.Items.Remove(lvAvailability.SelectedItems[0]);
            }
        }
    }
}
