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
    public enum eButtonState
    {
        OPT_NONE = 0,
        OPT_IN = 1,
        OPT_OUT = 2
    }

    public partial class ucOptStateButton : UserControl
    {        
        /**********************************************************/

        int m_buttonStateIndex = 0;
        static eButtonState[] m_buttonStates = { eButtonState.OPT_NONE, eButtonState.OPT_IN, eButtonState.OPT_OUT };

        // beige, green, red
        static Color[] m_buttonColor = { Color.Beige, Color.FromArgb(0x8a, 0xca, 0x9c), Color.FromArgb(0xff, 0xff, 192, 192) };

        static string[] m_buttonText = { "none", "opt in", "opt out" };

        /**********************************************************/

        public ucOptStateButton()
        {
            InitializeComponent();

            lblState.Click += new EventHandler(cycleState);
            lblState.DoubleClick += new EventHandler(cycleState);

            //lblState.Click += new EventHandler(cycleState);
            //lblState.DoubleClick += new EventHandler(cycleState);
            
            setAttributes();
        }

        /**********************************************************/

        private void setAttributes()
        {
            lblState.BackColor = m_buttonColor[(int)ButtonState];

            lblState.Text = m_buttonText[(int)ButtonState];

        }

        /**********************************************************/

        private void cycleState(object sender, EventArgs e)
        {
            m_buttonStateIndex++;

            setAttributes();
        }

        /**********************************************************/

        public eButtonState ButtonState
        {
            get { return m_buttonStates[m_buttonStateIndex % 3]; }

            set
            {
                m_buttonStateIndex = (int)value;
                setAttributes();
            }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public string HourText
        {
            get { return lblHour.Text; }

            set { lblHour.Text = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public int ButtonWidth
        {
            get { return pnlborder.Width; }
        }

        /********************************************************************************/

        // reset the button state to NONE
        public void reset()
        {
            m_buttonStateIndex = 0;
            setAttributes();
        }
    }
}
