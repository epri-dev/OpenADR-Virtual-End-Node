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

namespace oadr2b_ven.UserControls
{
    public partial class ucTextBox : UserControl
    {
        private int m_minValue = Int32.MinValue;
        private int m_maxValue = Int32.MaxValue;
        private int m_defaultValue = Int32.MaxValue;
        private bool m_useLimits = false;
        private bool m_isURL = false;

        private bool m_required = false;

        private bool m_isNumeric = false;

        private EventHandler m_textChanged;

        public ucTextBox()
        {
            InitializeComponent();

            errorProvider1.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleLeft);
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.SetIconPadding(textBox1, 4);

            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }

        /********************************************************************************/

        public event EventHandler TextboxTextChanged
        {
            add { m_textChanged += value; }
            remove { m_textChanged -= value; }
        }

        /********************************************************************************/

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
            
            if (m_useLimits && textBox1.Text.CompareTo("") != 0)
            {
                int val = ValueInt;
            }

            checkTextValue();

            if (m_isURL)
                validURL();

            if (m_textChanged != null)
                m_textChanged(this, e);
        }

        /********************************************************************************/

        public void checkTextValue()
        {
            if (m_required && (textBox1.Text == null || textBox1.Text == ""))
                errorProvider1.SetError(textBox1, "cannot be empty");
        }

        /********************************************************************************/

        public bool validURL()
        {
            bool value = Uri.IsWellFormedUriString(textBox1.Text, UriKind.RelativeOrAbsolute);

            errorProvider1.SetError(textBox1, "");

            if (!value)
                errorProvider1.SetError(textBox1, "invalid url");

            return value;
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public char PasswordChar
        {
            get { return textBox1.PasswordChar; }
            set { textBox1.PasswordChar = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public bool IsURL
        {
            get { return m_isURL; }
            set { m_isURL = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public string ToolTip
        {
            get { return toolTip1.GetToolTip(textBox1); }
            set { toolTip1.SetToolTip(textBox1, value); }
        }
        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public bool UseLimits
        {
            get { return m_useLimits; }
            set { m_useLimits = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public int MinValue
        {
            get { return m_minValue; }
            set { m_minValue = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public int MaxValue
        {
            get { return m_maxValue; }
            set { m_maxValue = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public int DefaultValue
        {
            get { return m_defaultValue; }
            set { m_defaultValue = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public int TextBoxWidth
        {
            get { return textBox1.Width; }

            set { textBox1.Width = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public int LabelWidth
        {
            get { return label1.Width; }

            set { label1.Width = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public string LabelText
        {
            get { return label1.Text; }

            set { label1.Text = value; }
        }


        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public bool IsNumeric
        {
            get { return m_isNumeric; }

            set { m_isNumeric = value; }
        }
        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public Boolean Required
        {
            get { return m_required; }

            set { m_required = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public string TextBoxText
        {
            get {
                checkTextValue();

                return textBox1.Text; 
            }

            set { textBox1.Text = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public bool ReadOnly
        {
            get { return textBox1.ReadOnly; }

            set { textBox1.ReadOnly = value; }
        }

        /********************************************************************************/

        [System.Runtime.InteropServices.ComVisible(true), Browsable(true)]
        public bool Numeric
        {
            get { return textBox1.ReadOnly; }

            set { textBox1.ReadOnly = value; }
        }

        /********************************************************************************/

        public int ValueInt
        {
            get
            {
                try
                {

                    errorProvider1.SetError(textBox1, "");

                    if (!m_isNumeric)
                        return 0;

                    int value = Convert.ToInt32(textBox1.Text);
                    
                    if (m_useLimits && (value < m_minValue || value > m_maxValue))
                    {
                        errorProvider1.SetError(textBox1, "value must be between " + m_minValue.ToString() + " and " + m_maxValue.ToString());
                        return Int32.MaxValue;
                    }

                    return value;
                }
                catch
                {
                    errorProvider1.SetError(textBox1, "value must be numeric");
                    return Int32.MaxValue;
                }
            }
        }

        /********************************************************************************/

        public double ValueDouble
        {
            get
            {
                try
                {
                    errorProvider1.SetError(textBox1, "");

                    if (!m_isNumeric)
                        return 0.0;

                    double value = Double.Parse(textBox1.Text);

                    if (m_useLimits && (value < m_minValue || value > m_maxValue))
                    {
                        errorProvider1.SetError(textBox1, "value must be between " + m_minValue.ToString() + " and " + m_maxValue.ToString());
                        return Double.MaxValue;
                    }

                    return value;
                }
                catch
                {
                    errorProvider1.SetError(textBox1, "value must be numeric");
                    return Double.MaxValue;
                }
            }
        }
    }
}
