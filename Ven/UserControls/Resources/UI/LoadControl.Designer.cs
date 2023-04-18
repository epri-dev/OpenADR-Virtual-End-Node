using Oadr.Ven.UserControls;

namespace Oadr.Ven.UserControls.Resources.UI
{
    partial class LoadControl
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
            this.tbUsage = new TextBoxControl();
            this.ucResource = new ResourceControl();
            this.SuspendLayout();
            // 
            // tbUsage
            // 
            this.tbUsage.DefaultValue = 2147483647;
            this.tbUsage.IsNumeric = true;
            this.tbUsage.IsUrl = false;
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
            this.ucResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucResource.Location = new System.Drawing.Point(0, 0);
            this.ucResource.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucResource.Name = "ucResource";
            this.ucResource.ResourceId = "";
            this.ucResource.ResourceTypeName = "Load";
            this.ucResource.Size = new System.Drawing.Size(740, 134);
            this.ucResource.TabIndex = 0;
            // 
            // ucLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbUsage);
            this.Controls.Add(this.ucResource);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucLoad";
            this.Size = new System.Drawing.Size(740, 134);
            this.ResumeLayout(false);

        }

        #endregion

        private ResourceControl ucResource;
        protected TextBoxControl tbUsage;
    }
}
