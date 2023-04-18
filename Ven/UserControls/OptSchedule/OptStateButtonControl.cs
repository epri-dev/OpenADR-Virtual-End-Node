using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.OptSchedule
{
    public partial class OptStateButtonControl : UserControl
    {
        private static readonly OptStateButtonState[] _buttonStates = { OptStateButtonState.OptNone, OptStateButtonState.OptIn, OptStateButtonState.OptOut };
        private static readonly Color[] _buttonColor = { Color.Beige, Color.FromArgb(0x8a, 0xca, 0x9c), Color.FromArgb(0xff, 0xff, 192, 192) };
        private static readonly string[] _buttonText = { "none", "opt in", "opt out" };

        private int _buttonStateIndex;

        public OptStateButtonState ButtonState
        {
            get => _buttonStates[_buttonStateIndex % 3];
            set
            {
                _buttonStateIndex = (int)value;
                SetAttributes();
            }
        }
        
        [ComVisible(true), Browsable(true)]
        public string HourText
        {
            get => lblHour.Text;
            set => lblHour.Text = value;
        }
        
        [ComVisible(true), Browsable(true)]
        public int ButtonWidth => pnlborder.Width;

        public OptStateButtonControl()
        {
            InitializeComponent();

            lblState.Click += CycleState;
            lblState.DoubleClick += CycleState;
            SetAttributes();
        }

        private void SetAttributes()
        {
            lblState.BackColor = _buttonColor[(int)ButtonState];
            lblState.Text = _buttonText[(int)ButtonState];
        }
        
        private void CycleState(object sender, EventArgs e)
        {
            _buttonStateIndex++;
            SetAttributes();
        }
        
        public void Reset()
        {
            _buttonStateIndex = 0;
            SetAttributes();
        }
    }
}
