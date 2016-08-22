namespace oadr2b_ven.UserControls.OptSchedule
{
    partial class ucOptScheduleView
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
            this.pnlHours = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbOptOutReason = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOptInReason = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHours
            // 
            this.pnlHours.AutoScroll = true;
            this.pnlHours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHours.Location = new System.Drawing.Point(0, 0);
            this.pnlHours.Name = "pnlHours";
            this.pnlHours.Size = new System.Drawing.Size(541, 282);
            this.pnlHours.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cmbOptOutReason);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cmbOptInReason);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dtEnd);
            this.splitContainer1.Panel1.Controls.Add(this.dtStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlHours);
            this.splitContainer1.Size = new System.Drawing.Size(541, 397);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Opt Out Reason";
            // 
            // cmbOptOutReason
            // 
            this.cmbOptOutReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptOutReason.FormattingEnabled = true;
            this.cmbOptOutReason.Items.AddRange(new object[] {
            "economic",
            "emergency",
            "mustRun",
            "notParticipating",
            "outageRunStatus",
            "overrideStatus",
            "participating",
            "x-schedule"});
            this.cmbOptOutReason.Location = new System.Drawing.Point(437, 12);
            this.cmbOptOutReason.Name = "cmbOptOutReason";
            this.cmbOptOutReason.Size = new System.Drawing.Size(91, 21);
            this.cmbOptOutReason.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Opt In Reason";
            // 
            // cmbOptInReason
            // 
            this.cmbOptInReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptInReason.FormattingEnabled = true;
            this.cmbOptInReason.Items.AddRange(new object[] {
            "economic",
            "emergency",
            "mustRun",
            "notParticipating",
            "outageRunStatus",
            "overrideStatus",
            "participating",
            "x-schedule"});
            this.cmbOptInReason.Location = new System.Drawing.Point(147, 12);
            this.cmbOptInReason.Name = "cmbOptInReason";
            this.cmbOptInReason.Size = new System.Drawing.Size(91, 21);
            this.cmbOptInReason.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(328, 63);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 1;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(38, 63);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 0;
            // 
            // ucOptScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucOptScheduleView";
            this.Size = new System.Drawing.Size(541, 397);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHours;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbOptOutReason;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOptInReason;

    }
}
