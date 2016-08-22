namespace oadr2b_ven.UserControls.Resources.UI
{
    partial class ucLoad
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
            this.tbUsage = new oadr2b_ven.UserControls.ucTextBox();
            this.ucResource1 = new oadr2b_ven.UserControls.Resources.UI.ucResource();
            this.SuspendLayout();
            // 
            // tbUsage
            // 
            this.tbUsage.DefaultValue = 2147483647;
            this.tbUsage.IsNumeric = true;
            this.tbUsage.IsURL = false;
            this.tbUsage.LabelText = "Realtime Usage (W)";
            this.tbUsage.LabelWidth = 135;
            this.tbUsage.Location = new System.Drawing.Point(8, 63);
            this.tbUsage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tbUsage.MaxValue = 2147483647;
            this.tbUsage.MinValue = 0;
            this.tbUsage.Name = "tbUsage";
            this.tbUsage.Numeric = false;
            this.tbUsage.PasswordChar = '\0';
            this.tbUsage.ReadOnly = false;
            this.tbUsage.Required = false;
            this.tbUsage.Size = new System.Drawing.Size(371, 26);
            this.tbUsage.TabIndex = 10;
            this.tbUsage.TextBoxText = "";
            this.tbUsage.TextBoxWidth = 141;
            this.tbUsage.ToolTip = "";
            this.tbUsage.UseLimits = true;
            // 
            // ucResource1
            // 
            this.ucResource1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucResource1.Location = new System.Drawing.Point(0, 0);
            this.ucResource1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucResource1.Name = "ucResource1";
            this.ucResource1.ResourceID = "";
            this.ucResource1.ResourceTypeName = "Load";
            this.ucResource1.Size = new System.Drawing.Size(740, 134);
            this.ucResource1.TabIndex = 0;
            // 
            // ucLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbUsage);
            this.Controls.Add(this.ucResource1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucLoad";
            this.Size = new System.Drawing.Size(740, 134);
            this.ResumeLayout(false);

        }

        #endregion

        private ucResource ucResource1;
        protected ucTextBox tbUsage;
    }
}
