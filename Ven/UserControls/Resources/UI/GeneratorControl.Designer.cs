using Oadr.Ven.UserControls;

namespace Oadr.Ven.UserControls.Resources.UI
{
    partial class GeneratorControl
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
            this.ucResource = new ResourceControl();
            this.tbOutput = new TextBoxControl();
            this.SuspendLayout();
            // 
            // ucResource1
            // 
            this.ucResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucResource.Location = new System.Drawing.Point(0, 0);
            this.ucResource.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucResource.Name = "ucResource";
            this.ucResource.ResourceId = "";
            this.ucResource.ResourceTypeName = "Generator";
            this.ucResource.Size = new System.Drawing.Size(740, 134);
            this.ucResource.TabIndex = 1;
            // 
            // tbOutput
            // 
            this.tbOutput.DefaultValue = 2147483647;
            this.tbOutput.IsNumeric = true;
            this.tbOutput.IsUrl = false;
            this.tbOutput.LabelText = "Generator Output (W)";
            this.tbOutput.LabelWidth = 147;
            this.tbOutput.Location = new System.Drawing.Point(7, 60);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tbOutput.MaxValue = 2147483647;
            this.tbOutput.MinValue = 0;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Numeric = false;
            this.tbOutput.PasswordChar = '\0';
            this.tbOutput.ReadOnly = false;
            this.tbOutput.Required = false;
            this.tbOutput.Size = new System.Drawing.Size(371, 26);
            this.tbOutput.TabIndex = 11;
            this.tbOutput.TextBoxText = "";
            this.tbOutput.TextBoxWidth = 141;
            this.tbOutput.ToolTip = "";
            this.tbOutput.UseLimits = true;
            // 
            // ucGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.ucResource);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucGenerator";
            this.Size = new System.Drawing.Size(740, 134);
            this.ResumeLayout(false);

        }

        #endregion

        private ResourceControl ucResource;
        protected TextBoxControl tbOutput;
    }
}
