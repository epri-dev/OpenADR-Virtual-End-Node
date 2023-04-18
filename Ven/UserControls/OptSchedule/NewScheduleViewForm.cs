using System;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public partial class NewScheduleViewForm : System.Windows.Forms.Form
    {
        public NewScheduleViewForm()
        {
            InitializeComponent();
            tbScheduleName.CheckTextValue();
        }
        
        public OptScheduleModel GetOptScheduleModel()
        {
            var optScheduleModel = ucOptScheduleView.GetOptScheduleModel();
            optScheduleModel.Name = tbScheduleName.TextBoxText;
            return optScheduleModel;
        }

        private void OnCreateScheduleClick(object sender, EventArgs e)
        {
            if (tbScheduleName.TextBoxText == string.Empty)
            {
                MessageBox.Show("Schedule name is required.");
                return;
            }

            var result = MessageBox.Show("Once this schedule is saved, it cannot be modified. Click Cancel to continue editing, OK to save.", "Create the Schedule?", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
            }
        }
        
        private void OnResetClick(object sender, EventArgs e)
        {
            ucOptScheduleView.Reset();
        }
        
        private void OnCancelClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("All changes will be lost. Are you sure you wish to continue? Click yes to lose changes. Click NO to continue editing.", "Cancel?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
