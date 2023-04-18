using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Resources.UI
{
    public partial class SliderControl : UserControl
    {
        private readonly int _maxWidth;
        private readonly Color _colorHighlight = Color.FromArgb(0xff, 0xff, 192, 192);
        private readonly Color _colorNormal = Color.White;

        private double _maxValue = 100;
        private double _currentValue;
        private bool _setCurrentValue = true;

        [ComVisible(true), Browsable(true)]
        public double MaxValue
        {
            get => _maxValue;
            set { _maxValue = value; txtMax.Text = _maxValue.ToString(CultureInfo.InvariantCulture); }
        }

        [ComVisible(true), Browsable(true)]
        public double CurrentValue
        {
            get => _currentValue;
            set { _currentValue = value; txtCurrent.Text = _currentValue.ToString(CultureInfo.InvariantCulture); }
        }

        public SliderControl()
        {
            InitializeComponent();

            _maxWidth = progressBarRight.Width;
            progressBarLeft.ForeColor = Color.Red;
            trackBar.ValueChanged += OnTrackBarValueChanged;
            txtCurrent.TextChanged += OnCurrentTextBoxTextChanged;
        }

        private void OnCurrentTextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCurrent.Text.EndsWith("."))
                {
                    return;
                }
                
                var value = double.Parse(txtCurrent.Text);
                if (value > _maxValue)
                {
                    value = _maxValue;
                }

                if (value < 0)
                {
                    value = 0;
                }

                // We don't want the event OnTrackBarValueChanged to update the current value
                // because we want the user to explicitly set the value the event will set this variable back to true.
                _setCurrentValue = false;
                CurrentValue = value;
                trackBar.Value = (int)(_currentValue / _maxValue * 100);
                txtCurrent.BackColor = _colorNormal;
                toolTip.SetToolTip(txtCurrent, "Current value");
            }
            catch (Exception)
            {
                txtCurrent.BackColor = _colorHighlight;
                toolTip.SetToolTip(txtCurrent, "Invalid value");
            }
        }

        private void OnTrackBarValueChanged(object sender, EventArgs e)
        {            
            progressBarLeft.Width = (int)Math.Ceiling((trackBar.Value / 100.0) * _maxWidth);
            if (_setCurrentValue)
            {
                var value = (trackBar.Value / 100.0) * _maxValue;
                CurrentValue = value;
            }
            _setCurrentValue = true;
        }
    }
}
