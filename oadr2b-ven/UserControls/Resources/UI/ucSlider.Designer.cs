namespace oadr2b_ven.UserControls.Resources.UI
{
    partial class ucSlider
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
            this.components = new System.ComponentModel.Container();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.progressBarLeft = new System.Windows.Forms.ProgressBar();
            this.progressBarRight = new System.Windows.Forms.ProgressBar();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(50, 3);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(183, 45);
            this.trackBar.TabIndex = 13;
            this.trackBar.TickFrequency = 10;
            this.toolTip1.SetToolTip(this.trackBar, "Slide to adjust");
            // 
            // progressBarLeft
            // 
            this.progressBarLeft.Location = new System.Drawing.Point(62, 35);
            this.progressBarLeft.MarqueeAnimationSpeed = 1000000;
            this.progressBarLeft.Name = "progressBarLeft";
            this.progressBarLeft.Size = new System.Drawing.Size(0, 10);
            this.progressBarLeft.Step = 1;
            this.progressBarLeft.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarLeft.TabIndex = 14;
            this.progressBarLeft.Value = 100;
            // 
            // progressBarRight
            // 
            this.progressBarRight.Location = new System.Drawing.Point(62, 35);
            this.progressBarRight.MarqueeAnimationSpeed = 1000000;
            this.progressBarRight.Name = "progressBarRight";
            this.progressBarRight.RightToLeftLayout = true;
            this.progressBarRight.Size = new System.Drawing.Size(160, 10);
            this.progressBarRight.Step = 1;
            this.progressBarRight.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarRight.TabIndex = 15;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(3, 15);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(53, 20);
            this.txtMin.TabIndex = 16;
            this.txtMin.Text = "0";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(228, 15);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(53, 20);
            this.txtMax.TabIndex = 17;
            this.txtMax.Text = "100";
            this.toolTip1.SetToolTip(this.txtMax, "Max Value");
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(104, 51);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(53, 20);
            this.txtCurrent.TabIndex = 18;
            this.txtCurrent.Text = "0";
            this.toolTip1.SetToolTip(this.txtCurrent, "Current Value");
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 250;
            this.toolTip1.ReshowDelay = 100;
            // 
            // ucSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.progressBarLeft);
            this.Controls.Add(this.progressBarRight);
            this.Controls.Add(this.trackBar);
            this.Name = "ucSlider";
            this.Size = new System.Drawing.Size(286, 76);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.ProgressBar progressBarLeft;
        private System.Windows.Forms.ProgressBar progressBarRight;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtCurrent;


    }
}
