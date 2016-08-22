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

namespace oadr2b_ven.UserControls.Resources.UI
{
    public partial class ucSlider : UserControl
    {
        private int m_maxWidth;

        private double m_maxValue = 100;
        private double m_currentValue = 0;

        private bool m_setCurrentValue = true;

        private Color m_colorHighlight = Color.FromArgb(0xff, 0xff, 192, 192);
        private Color m_colorNormal = Color.White;

        /********************************************************************************/

        public ucSlider()
        {
            InitializeComponent();

            /*Win32Helper.SendMessage(progressBarLeft.Handle,
                0x400 + 16, //WM_USER + PBM_SETSTATE
                0x0004, //PBST_PAUSED
                0);*/

            m_maxWidth = progressBarRight.Width;

            progressBarLeft.ForeColor = Color.Red;
            trackBar.ValueChanged += new EventHandler(trackBar_ValueChanged);

            txtCurrent.TextChanged += new EventHandler(txtCurrent_TextChanged);
        }

        /********************************************************************************/

        private void txtCurrent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCurrent.Text.EndsWith("."))
                    return;

                double value = Double.Parse(txtCurrent.Text);

                if (value > m_maxValue)
                    value = m_maxValue;

                if (value < 0)
                    value = 0;

                // we don't want the event trackBar_ValueChanged to update the current value
                // because we want the user to explicitly set the value
                // the event will set this variable back to true
                m_setCurrentValue = false;

                CurrentValue = value;

                trackBar.Value = (int)(m_currentValue / m_maxValue * 100);

                txtCurrent.BackColor = m_colorNormal;
                toolTip1.SetToolTip(txtCurrent, "current value");
            }
            catch (Exception)
            {
                txtCurrent.BackColor = m_colorHighlight;

                toolTip1.SetToolTip(txtCurrent, "invalid value");
            }
        }

        /********************************************************************************/

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {            
            progressBarLeft.Width = (int)Math.Ceiling((trackBar.Value / 100.0) * m_maxWidth);

            if (m_setCurrentValue)
            {
                double value = (trackBar.Value / 100.0) * m_maxValue;
                CurrentValue = value;
            }

            m_setCurrentValue = true;
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public double MaxValue
        {
            get { return m_maxValue; }
            set { m_maxValue = value; txtMax.Text = m_maxValue.ToString(); }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public double CurrentValue
        {
            get { return m_currentValue; }
            set { m_currentValue = value; txtCurrent.Text = m_currentValue.ToString(); }
        }
    }
}
