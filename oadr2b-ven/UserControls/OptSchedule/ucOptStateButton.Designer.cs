namespace oadr2b_ven.UserControls.OptSchedule
{
    partial class ucOptStateButton
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
            this.lblState = new System.Windows.Forms.Label();
            this.pnlborder = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.pnlborder.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(72, 23);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "none";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlborder
            // 
            this.pnlborder.BackColor = System.Drawing.Color.Transparent;
            this.pnlborder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlborder.Controls.Add(this.lblState);
            this.pnlborder.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlborder.ForeColor = System.Drawing.Color.Black;
            this.pnlborder.Location = new System.Drawing.Point(30, 0);
            this.pnlborder.Name = "pnlborder";
            this.pnlborder.Size = new System.Drawing.Size(74, 25);
            this.pnlborder.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 2);
            this.label1.TabIndex = 4;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHour.Location = new System.Drawing.Point(-3, 2);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(33, 13);
            this.lblHour.TabIndex = 5;
            this.lblHour.Text = "12am";
            // 
            // ucOptStateButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlborder);
            this.Name = "ucOptStateButton";
            this.Size = new System.Drawing.Size(104, 25);
            this.pnlborder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Panel pnlborder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHour;

    }
}
