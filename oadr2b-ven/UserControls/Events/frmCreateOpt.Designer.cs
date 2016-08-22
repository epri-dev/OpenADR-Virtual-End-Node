namespace oadr2b_ven.UserControls.Events
{
    partial class frmCreateOpt
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOptReason = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOptType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbResource = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(44, 163);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(125, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Resource";
            // 
            // cmbOptReason
            // 
            this.cmbOptReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptReason.FormattingEnabled = true;
            this.cmbOptReason.Items.AddRange(new object[] {
            "economic",
            "emergency",
            "mustRun",
            "notParticipating",
            "outageRunStatus",
            "overrideStatus",
            "participating",
            "x-schedule"});
            this.cmbOptReason.Location = new System.Drawing.Point(21, 73);
            this.cmbOptReason.Name = "cmbOptReason";
            this.cmbOptReason.Size = new System.Drawing.Size(179, 21);
            this.cmbOptReason.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Opt Reason";
            // 
            // cmbOptType
            // 
            this.cmbOptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptType.FormattingEnabled = true;
            this.cmbOptType.Items.AddRange(new object[] {
            "optIn",
            "optOut"});
            this.cmbOptType.Location = new System.Drawing.Point(21, 23);
            this.cmbOptType.Name = "cmbOptType";
            this.cmbOptType.Size = new System.Drawing.Size(179, 21);
            this.cmbOptType.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Opt Type";
            // 
            // cmbResource
            // 
            this.cmbResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResource.FormattingEnabled = true;
            this.cmbResource.Location = new System.Drawing.Point(21, 120);
            this.cmbResource.Name = "cmbResource";
            this.cmbResource.Size = new System.Drawing.Size(179, 21);
            this.cmbResource.TabIndex = 30;
            // 
            // frmCreateOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 196);
            this.ControlBox = false;
            this.Controls.Add(this.cmbResource);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbOptReason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOptType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCreateOpt";
            this.Text = "Create Opt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbOptReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOptType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbResource;
    }
}