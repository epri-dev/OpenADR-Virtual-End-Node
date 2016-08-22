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
    public partial class ucOptScheduleView : UserControl
    {
        private Dictionary<string, List<ucOptStateButton>> m_buttons = new Dictionary<string,List<ucOptStateButton>>();
        private string[] m_weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public ucOptScheduleView()
        {
            InitializeComponent();

            string[] hourText = { "12am", "1am", "2am", "3am", "4am", "5am", "6am", 
                                "7am", "8am", "9am", "10am", "11am", "12am",
                                "1pm", "2pm", "3pm", "4pm", "5pm", "6pm",
                                "7pm", "8pm", "9pm", "10pm", "11pm"};

            Point topLeft = new Point(3, 3);

            ucOptStateButton button = new ucOptStateButton();

            int buttonWidth = button.ButtonWidth;
            int buttonHeight = button.Height;

            foreach (string s in m_weekDays)
            {
                m_buttons.Add(s, new List<ucOptStateButton>());
            }

            for (int index = 0; index < 24; index++)
            {
                button = new ucOptStateButton();

                button.HourText = hourText[index];

                button.Location = new Point(topLeft.X, topLeft.Y + (index * (buttonHeight - 1)));

                pnlHours.Controls.Add(button);
                button.BringToFront();

                m_buttons[m_weekDays[0]].Add(button);

                for (int weekday = 1; weekday < 7; weekday++)
                {
                    button = new ucOptStateButton();

                    button.Location = new Point(topLeft.X + (weekday * (buttonWidth - 1)), topLeft.Y + (index * (buttonHeight - 1)));

                    button.HourText = "";
                    pnlHours.Controls.Add(button);
                    button.SendToBack();

                    m_buttons[m_weekDays[weekday]].Add(button);
                }

            }

            topLeft = new Point(35, 95);

            // for measuing the length of a string
            Graphics g = CreateGraphics();

            for (int index = 0; index < 7; index++)
            {
                Label label = new Label();
                label.Text = m_weekDays[index];
                label.AutoSize = true;

                int textLength = (int)g.MeasureString(label.Text, label.Font).Width;

                int center = ((buttonWidth - textLength) / 2);// +10;

                label.Location = new Point(topLeft.X + (index * (buttonWidth - 1)) + center, topLeft.Y);

                splitContainer1.Panel1.Controls.Add(label);
            }

            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;

            dtStart.ValueChanged += dtStart_ValueChanged;
            dtEnd.ValueChanged += dtEnd_ValueChanged;

            cmbOptInReason.SelectedIndex = 0;
            cmbOptOutReason.SelectedIndex = 0;
        }

        /********************************************************************************/

        public void dtStart_ValueChanged(object sender, EventArgs args)
        {
            if (dtStart.Value > dtEnd.Value)
                dtEnd.Value = dtStart.Value;
        }

        /********************************************************************************/

        public void dtEnd_ValueChanged(object sender, EventArgs args)
        {
            if (dtEnd.Value < dtStart.Value)
                dtStart.Value = dtEnd.Value;
        }

        /********************************************************************************/

        public OptScheduleModel getOptScheduleModel()
        {
            OptScheduleModel optScheduleModel = new OptScheduleModel();

            optScheduleModel.StartDate = dtStart.Value;
            optScheduleModel.EndDate = dtEnd.Value;

            optScheduleModel.OptInReason = cmbOptInReason.SelectedItem.ToString();
            optScheduleModel.OptOutReason = cmbOptOutReason.SelectedItem.ToString();

            foreach (string weekDay in m_weekDays)
            {
                for (int hour = 0; hour < 24; hour++)
                    optScheduleModel.setButtonState(weekDay, hour, m_buttons[weekDay][hour].ButtonState);
            }

            return optScheduleModel;
        }

        /********************************************************************************/

        public void viewOptScheduleModel(OptScheduleModel optScheduleModel)
        {
            dtStart.Value = optScheduleModel.StartDate;
            dtEnd.Value = optScheduleModel.EndDate;

            cmbOptInReason.SelectedItem = optScheduleModel.OptInReason;
            cmbOptOutReason.SelectedItem = optScheduleModel.OptOutReason;

            foreach (string weekDay in m_weekDays)
            {
                for (int hour = 0; hour < 24; hour++)
                    m_buttons[weekDay][hour].ButtonState = optScheduleModel.getButtonState(weekDay, hour);
            }
        }

        /********************************************************************************/

        public void setReadOnly(bool readOnly)
        {
            bool enabled = !readOnly;

            dtStart.Enabled = enabled;
            dtEnd.Enabled = enabled;

            foreach (string weekDay in m_weekDays)
            {
                for (int hour = 0; hour < 24; hour++)
                    m_buttons[weekDay][hour].Enabled = enabled;
            }

            cmbOptOutReason.Enabled = enabled;
            cmbOptInReason.Enabled = enabled;
        }

        /********************************************************************************/

        public void reset()
        {
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;

            foreach (string weekday in m_weekDays)
            {
                List<ucOptStateButton> buttons = m_buttons[weekday];

                for (int hour = 0; hour < 24; hour++)
                    buttons[hour].reset();
            }
        }
    }
}
