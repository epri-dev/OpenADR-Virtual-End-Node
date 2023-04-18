using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public partial class OptScheduleViewControl : UserControl
    {
        private readonly Dictionary<string, List<OptStateButtonControl>> _buttons = new Dictionary<string,List<OptStateButtonControl>>();
        private readonly string[] _weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public OptScheduleViewControl()
        {
            InitializeComponent();

            string[] hourText =
            {
                "12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am",
                "9am", "10am", "11am", "12am", "1pm", "2pm", "3pm", "4pm", "5pm",
                "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"
            };

            var topLeft = new Point(3, 3);
            var button = new OptStateButtonControl();
            var buttonWidth = button.ButtonWidth;
            var buttonHeight = button.Height;

            foreach (var weekday in _weekDays)
            {
                _buttons.Add(weekday, new List<OptStateButtonControl>());
            }

            for (var index = 0; index < 24; index++)
            {
                button = new OptStateButtonControl();
                button.HourText = hourText[index];
                button.Location = new Point(topLeft.X, topLeft.Y + (index * (buttonHeight - 1)));
                pnlHours.Controls.Add(button);
                button.BringToFront();
                _buttons[_weekDays[0]].Add(button);

                for (var weekday = 1; weekday < 7; weekday++)
                {
                    button = new OptStateButtonControl();
                    button.Location = new Point(topLeft.X + weekday * (buttonWidth - 1), topLeft.Y + index * (buttonHeight - 1));
                    button.HourText = string.Empty;
                    pnlHours.Controls.Add(button);
                    button.SendToBack();
                    _buttons[_weekDays[weekday]].Add(button);
                }
            }

            topLeft = new Point(35, 95);
            // For measuring the length of a string.
            var g = CreateGraphics();
            for (var index = 0; index < 7; index++)
            {
                var label = new Label();
                label.Text = _weekDays[index];
                label.AutoSize = true;
                var textLength = (int)g.MeasureString(label.Text, label.Font).Width;
                var center = ((buttonWidth - textLength) / 2);
                label.Location = new Point(topLeft.X + index * (buttonWidth - 1) + center, topLeft.Y);
                splitContainer1.Panel1.Controls.Add(label);
            }

            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            dtStart.ValueChanged += OnDtStartValueChanged;
            dtEnd.ValueChanged += OnDtEndValueChanged;
            cmbOptInReason.SelectedIndex = 0;
            cmbOptOutReason.SelectedIndex = 0;
        }

        public void OnDtStartValueChanged(object sender, EventArgs args)
        {
            if (dtStart.Value > dtEnd.Value)
            {
                dtEnd.Value = dtStart.Value;
            }
        }
        
        public void OnDtEndValueChanged(object sender, EventArgs args)
        {
            if (dtEnd.Value < dtStart.Value)
            {
                dtStart.Value = dtEnd.Value;
            }
        }
        
        public OptScheduleModel GetOptScheduleModel()
        {
            var optScheduleModel = new OptScheduleModel
            {
                StartDate = dtStart.Value,
                EndDate = dtEnd.Value,
                OptInReason = cmbOptInReason.SelectedItem.ToString(),
                OptOutReason = cmbOptOutReason.SelectedItem.ToString()
            };

            foreach (var weekday in _weekDays)
            {
                for (var hour = 0; hour < 24; hour++)
                {
                    optScheduleModel.SetButtonState(weekday, hour, _buttons[weekday][hour].ButtonState);
                }
            }
            return optScheduleModel;
        }
        
        public void ViewOptScheduleModel(OptScheduleModel optScheduleModel)
        {
            dtStart.Value = optScheduleModel.StartDate;
            dtEnd.Value = optScheduleModel.EndDate;
            cmbOptInReason.SelectedItem = optScheduleModel.OptInReason;
            cmbOptOutReason.SelectedItem = optScheduleModel.OptOutReason;

            foreach (var weekday in _weekDays)
            {
                for (var hour = 0; hour < 24; hour++)
                {
                    _buttons[weekday][hour].ButtonState = optScheduleModel.GetButtonState(weekday, hour);
                }
            }
        }
        
        public void SetReadOnly(bool readOnly)
        {
            var enabled = !readOnly;

            dtStart.Enabled = enabled;
            dtEnd.Enabled = enabled;

            foreach (var weekday in _weekDays)
            {
                for (var hour = 0; hour < 24; hour++)
                {
                    _buttons[weekday][hour].Enabled = enabled;
                }
            }

            cmbOptOutReason.Enabled = enabled;
            cmbOptInReason.Enabled = enabled;
        }
        
        public void Reset()
        {
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;

            foreach (var weekday in _weekDays)
            {
                var buttons = _buttons[weekday];
                for (var hour = 0; hour < 24; hour++)
                {
                    buttons[hour].Reset();
                }
            }
        }
    }
}
