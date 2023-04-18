using System;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public partial class OadrNewScheduleViewForm : System.Windows.Forms.Form
    {
        public OadrNewScheduleViewForm()
        {
            InitializeComponent();
            tbScheduleName.CheckTextValue();
        }
        
        private void OnCreateScheduleClick(object sender, EventArgs e)
        {
            if (tbScheduleName.TextBoxText == string.Empty)
            {
                MessageBox.Show("Schedule name is required");

                return;
            }
            DialogResult = DialogResult.OK;
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
        
        public OadrOptScheduleModel GetOptScheduleModel(OadrOptScheduleModel model = null)
        {
            model = ucOptScheduleView.GetOptScheduleModel(model);
            model.Name = tbScheduleName.TextBoxText;
            return model;
        }
        
        public void LoadOadrOptScheduleModel(OadrOptScheduleModel model)
        {
            ucOptScheduleView.ViewOptScheduleModel(model);
            tbScheduleName.TextBoxText = model.Name;
        }
    }
}
