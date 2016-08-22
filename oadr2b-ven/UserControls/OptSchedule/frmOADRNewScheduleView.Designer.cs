namespace oadr2b_ven.UserControls.OptSchedule
{
    partial class frmOADRNewScheduleView
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
            this.components = new System.ComponentModel.Container();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateSchedule = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ucOptScheduleView1 = new oadr2b_ven.UserControls.OptSchedule.oadrucOptScheduleView();
            this.tbScheduleName = new oadr2b_ven.UserControls.ucTextBox();
            this.pnlBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.groupBox1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 367);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(424, 79);
            this.pnlBottom.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbScheduleName);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnCreateSchedule);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 46);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(111, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Clear Availability";
            this.toolTip1.SetToolTip(this.btnReset, "reset time entries to \'none\'");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(307, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateSchedule
            // 
            this.btnCreateSchedule.Location = new System.Drawing.Point(307, 19);
            this.btnCreateSchedule.Name = "btnCreateSchedule";
            this.btnCreateSchedule.Size = new System.Drawing.Size(111, 23);
            this.btnCreateSchedule.TabIndex = 0;
            this.btnCreateSchedule.Text = "Save Schedule";
            this.btnCreateSchedule.UseVisualStyleBackColor = true;
            this.btnCreateSchedule.Click += new System.EventHandler(this.btnCreateSchedule_Click);
            // 
            // ucOptScheduleView1
            // 
            this.ucOptScheduleView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOptScheduleView1.Location = new System.Drawing.Point(0, 0);
            this.ucOptScheduleView1.Name = "ucOptScheduleView1";
            this.ucOptScheduleView1.Size = new System.Drawing.Size(424, 367);
            this.ucOptScheduleView1.TabIndex = 1;
            this.ucOptScheduleView1.Load += new System.EventHandler(this.ucOptScheduleView1_Load);
            // 
            // tbScheduleName
            // 
            this.tbScheduleName.DefaultValue = 2147483647;
            this.tbScheduleName.IsNumeric = false;
            this.tbScheduleName.IsURL = false;
            this.tbScheduleName.LabelText = "Schedule Name";
            this.tbScheduleName.LabelWidth = 83;
            this.tbScheduleName.Location = new System.Drawing.Point(12, 19);
            this.tbScheduleName.MaxValue = 2147483647;
            this.tbScheduleName.MinValue = -2147483648;
            this.tbScheduleName.Name = "tbScheduleName";
            this.tbScheduleName.Numeric = false;
            this.tbScheduleName.PasswordChar = '\0';
            this.tbScheduleName.ReadOnly = false;
            this.tbScheduleName.Required = true;
            this.tbScheduleName.Size = new System.Drawing.Size(252, 21);
            this.tbScheduleName.TabIndex = 4;
            this.tbScheduleName.TextBoxText = "";
            this.tbScheduleName.TextBoxWidth = 121;
            this.tbScheduleName.ToolTip = "";
            this.tbScheduleName.UseLimits = false;
            // 
            // frmOADRNewScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 446);
            this.ControlBox = false;
            this.Controls.Add(this.ucOptScheduleView1);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOADRNewScheduleView";
            this.Text = "New Schedule";
            this.pnlBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreateSchedule;
        private oadrucOptScheduleView ucOptScheduleView1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolTip toolTip1;
        public ucTextBox tbScheduleName;
    }
}