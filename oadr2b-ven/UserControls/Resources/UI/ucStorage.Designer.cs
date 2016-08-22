namespace oadr2b_ven.UserControls.Resources.UI
{
    partial class ucStorage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucResource1 = new oadr2b_ven.UserControls.Resources.UI.ucResource();
            this.tbChargeRate = new oadr2b_ven.UserControls.ucTextBox();
            this.tbDischargeRate = new oadr2b_ven.UserControls.ucTextBox();
            this.tbMaxCapacity = new oadr2b_ven.UserControls.ucTextBox();
            this.ucCapacity = new oadr2b_ven.UserControls.Resources.UI.ucSlider();
            this.Capacity = new System.Windows.Forms.Label();
            this.rdCharge = new System.Windows.Forms.RadioButton();
            this.rdDischarge = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ucResource1
            // 
            this.ucResource1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucResource1.Location = new System.Drawing.Point(0, 0);
            this.ucResource1.Name = "ucResource1";
            this.ucResource1.ResourceID = "";
            this.ucResource1.ResourceTypeName = "Storage";
            this.ucResource1.Size = new System.Drawing.Size(639, 282);
            this.ucResource1.TabIndex = 0;
            // 
            // tbChargeRate
            // 
            this.tbChargeRate.DefaultValue = 2147483647;
            this.tbChargeRate.IsURL = false;
            this.tbChargeRate.LabelText = "Charge Rate (W)";
            this.tbChargeRate.LabelWidth = 87;
            this.tbChargeRate.Location = new System.Drawing.Point(6, 47);
            this.tbChargeRate.MaxValue = 2147483647;
            this.tbChargeRate.MinValue = 0;
            this.tbChargeRate.Name = "tbChargeRate";
            this.tbChargeRate.PasswordChar = '\0';
            this.tbChargeRate.ReadOnly = false;
            this.tbChargeRate.Required = false;
            this.tbChargeRate.Size = new System.Drawing.Size(278, 21);
            this.tbChargeRate.TabIndex = 11;
            this.tbChargeRate.TextBoxText = "";
            this.tbChargeRate.TextBoxWidth = 141;
            this.tbChargeRate.UseLimits = true;
            // 
            // tbDischargeRate
            // 
            this.tbDischargeRate.DefaultValue = 2147483647;
            this.tbDischargeRate.IsURL = false;
            this.tbDischargeRate.LabelText = "Discharge Rate (W)";
            this.tbDischargeRate.LabelWidth = 101;
            this.tbDischargeRate.Location = new System.Drawing.Point(6, 74);
            this.tbDischargeRate.MaxValue = 2147483647;
            this.tbDischargeRate.MinValue = 0;
            this.tbDischargeRate.Name = "tbDischargeRate";
            this.tbDischargeRate.PasswordChar = '\0';
            this.tbDischargeRate.ReadOnly = false;
            this.tbDischargeRate.Required = false;
            this.tbDischargeRate.Size = new System.Drawing.Size(278, 21);
            this.tbDischargeRate.TabIndex = 12;
            this.tbDischargeRate.TextBoxText = "";
            this.tbDischargeRate.TextBoxWidth = 141;
            this.tbDischargeRate.UseLimits = true;
            // 
            // tbMaxCapacity
            // 
            this.tbMaxCapacity.DefaultValue = 2147483647;
            this.tbMaxCapacity.IsURL = false;
            this.tbMaxCapacity.LabelText = "Max Capacity (Wh)";
            this.tbMaxCapacity.LabelWidth = 97;
            this.tbMaxCapacity.Location = new System.Drawing.Point(6, 101);
            this.tbMaxCapacity.MaxValue = 2147483647;
            this.tbMaxCapacity.MinValue = 0;
            this.tbMaxCapacity.Name = "tbMaxCapacity";
            this.tbMaxCapacity.PasswordChar = '\0';
            this.tbMaxCapacity.ReadOnly = false;
            this.tbMaxCapacity.Required = false;
            this.tbMaxCapacity.Size = new System.Drawing.Size(278, 21);
            this.tbMaxCapacity.TabIndex = 13;
            this.tbMaxCapacity.TextBoxText = "";
            this.tbMaxCapacity.TextBoxWidth = 141;
            this.tbMaxCapacity.UseLimits = true;
            // 
            // ucCapacity
            // 
            this.ucCapacity.CurrentValue = 0D;
            this.ucCapacity.Location = new System.Drawing.Point(53, 158);
            this.ucCapacity.MaxValue = 100D;
            this.ucCapacity.Name = "ucCapacity";
            this.ucCapacity.Size = new System.Drawing.Size(286, 76);
            this.ucCapacity.TabIndex = 15;
            // 
            // Capacity
            // 
            this.Capacity.AutoSize = true;
            this.Capacity.Location = new System.Drawing.Point(152, 142);
            this.Capacity.Name = "Capacity";
            this.Capacity.Size = new System.Drawing.Size(65, 13);
            this.Capacity.TabIndex = 16;
            this.Capacity.Text = "Capacity (%)";
            // 
            // rdCharge
            // 
            this.rdCharge.AutoSize = true;
            this.rdCharge.Location = new System.Drawing.Point(300, 78);
            this.rdCharge.Name = "rdCharge";
            this.rdCharge.Size = new System.Drawing.Size(59, 17);
            this.rdCharge.TabIndex = 17;
            this.rdCharge.TabStop = true;
            this.rdCharge.Text = "Charge";
            this.rdCharge.UseVisualStyleBackColor = true;
            // 
            // rdDischarge
            // 
            this.rdDischarge.AutoSize = true;
            this.rdDischarge.Location = new System.Drawing.Point(300, 102);
            this.rdDischarge.Name = "rdDischarge";
            this.rdDischarge.Size = new System.Drawing.Size(73, 17);
            this.rdDischarge.TabIndex = 18;
            this.rdDischarge.TabStop = true;
            this.rdDischarge.Text = "Discharge";
            this.rdDischarge.UseVisualStyleBackColor = true;
            // 
            // ucStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdDischarge);
            this.Controls.Add(this.rdCharge);
            this.Controls.Add(this.Capacity);
            this.Controls.Add(this.ucCapacity);
            this.Controls.Add(this.tbMaxCapacity);
            this.Controls.Add(this.tbDischargeRate);
            this.Controls.Add(this.tbChargeRate);
            this.Controls.Add(this.ucResource1);
            this.Name = "ucStorage";
            this.Size = new System.Drawing.Size(639, 282);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucResource ucResource1;
        protected ucTextBox tbChargeRate;
        protected ucTextBox tbDischargeRate;
        protected ucTextBox tbMaxCapacity;
        private ucSlider ucCapacity;
        private System.Windows.Forms.Label Capacity;
        private System.Windows.Forms.RadioButton rdCharge;
        private System.Windows.Forms.RadioButton rdDischarge;
    }
}
