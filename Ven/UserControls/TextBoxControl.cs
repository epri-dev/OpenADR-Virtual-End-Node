using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls
{
    public partial class TextBoxControl : UserControl
    {
        private EventHandler _textChanged;
        
        [ComVisible(true), Browsable(true)]
        public bool IsUrl { get; set; }
        
        [ComVisible(true), Browsable(true)]
        public bool UseLimits { get; set; }

        [ComVisible(true), Browsable(true)]
        public int MinValue { get; set; } = int.MinValue;

        [ComVisible(true), Browsable(true)]
        public int MaxValue { get; set; } = int.MaxValue;

        [ComVisible(true), Browsable(true)]
        public int DefaultValue { get; set; } = int.MaxValue;

        [ComVisible(true), Browsable(true)]
        public bool IsNumeric { get; set; }

        [ComVisible(true), Browsable(true)]
        public bool Required { get; set; }

        [ComVisible(true), Browsable(true)]
        public char PasswordChar
        {
            get => txtInput.PasswordChar;
            set => txtInput.PasswordChar = value;
        }

        [ComVisible(true), Browsable(true)]
        public string ToolTip
        {
            get => toolTip.GetToolTip(txtInput);
            set => toolTip.SetToolTip(txtInput, value);
        }

        [ComVisible(true), Browsable(true)]
        public int TextBoxWidth
        {
            get => txtInput.Width;
            set => txtInput.Width = value;
        }

        [ComVisible(true), Browsable(true)]
        public int LabelWidth
        {
            get => label.Width;
            set => label.Width = value;
        }

        [ComVisible(true), Browsable(true)]
        public string LabelText
        {
            get => label.Text;
            set => label.Text = value;
        }

        [ComVisible(true), Browsable(true)]
        public string TextBoxText
        {
            get
            {
                CheckTextValue();
                return txtInput.Text; 
            }
            set => txtInput.Text = value;
        }

        [ComVisible(true), Browsable(true)]
        public bool ReadOnly
        {
            get => txtInput.ReadOnly;
            set => txtInput.ReadOnly = value;
        }

        [ComVisible(true), Browsable(true)]
        public bool Numeric
        {
            get => txtInput.ReadOnly;
            set => txtInput.ReadOnly = value;
        }

        public TextBoxControl()
        {
            InitializeComponent();

            errorProvider.SetIconAlignment(txtInput, ErrorIconAlignment.MiddleLeft);
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.SetIconPadding(txtInput, 4);
            txtInput.TextChanged += OnTextBoxTextChanged;
        }

        public int ValueInt
        {
            get
            {
                try
                {
                    errorProvider.SetError(txtInput, string.Empty);
                    if (!IsNumeric)
                    {
                        return 0;
                    }

                    var value = Convert.ToInt32(txtInput.Text);
                    if (UseLimits && (value < MinValue || value > MaxValue))
                    {
                        errorProvider.SetError(txtInput, $"Value must be between {MinValue} and {MaxValue}");
                        return int.MaxValue;
                    }
                    return value;
                }
                catch
                {
                    errorProvider.SetError(txtInput, "Value must be numeric");
                    return int.MaxValue;
                }
            }
        }

        public double ValueDouble
        {
            get
            {
                try
                {
                    errorProvider.SetError(txtInput, string.Empty);
                    if (!IsNumeric)
                    {
                        return 0.0;
                    }

                    var value = double.Parse(txtInput.Text);
                    if (UseLimits && (value < MinValue || value > MaxValue))
                    {
                        errorProvider.SetError(txtInput, $"Value must be between {MinValue} and {MaxValue}");
                        return double.MaxValue;
                    }
                    return value;
                }
                catch
                {
                    errorProvider.SetError(txtInput, "Value must be numeric");
                    return double.MaxValue;
                }
            }
        }

        public event EventHandler TextBoxTextChanged
        {
            add => _textChanged += value;
            remove => _textChanged -= value;
        }

        public void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtInput, string.Empty);
            CheckTextValue();
            if (IsUrl)
            {
                ValidUrl();
            }
            _textChanged?.Invoke(this, e);
        }

        public void CheckTextValue()
        {
            if (Required && string.IsNullOrEmpty(txtInput.Text))
            {
                errorProvider.SetError(txtInput, "Cannot be empty");
            }
        }

        public bool ValidUrl()
        {
            var value = Uri.IsWellFormedUriString(txtInput.Text, UriKind.RelativeOrAbsolute);
            errorProvider.SetError(txtInput, string.Empty);

            if (!value)
            {
                errorProvider.SetError(txtInput, "Invalid URL");
            }
            return value;
        }
    }
}
