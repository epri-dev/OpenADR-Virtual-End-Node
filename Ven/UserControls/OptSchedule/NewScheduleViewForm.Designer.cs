﻿using Oadr.Ven.UserControls;

namespace Oadr.Ven.UserControls.OptSchedule
{
    partial class NewScheduleViewForm
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
            this.tbScheduleName = new TextBoxControl();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateSchedule = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ucOptScheduleView = new OptScheduleViewControl();
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
            this.pnlBottom.Size = new System.Drawing.Size(490, 95);
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
            this.groupBox1.Size = new System.Drawing.Size(490, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbScheduleName
            // 
            this.tbScheduleName.DefaultValue = 2147483647;
            this.tbScheduleName.IsUrl = false;
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
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 60);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(111, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.toolTip1.SetToolTip(this.btnReset, "reset time entries to \'none\'");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.OnResetClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(367, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // btnCreateSchedule
            // 
            this.btnCreateSchedule.Location = new System.Drawing.Point(250, 66);
            this.btnCreateSchedule.Name = "btnCreateSchedule";
            this.btnCreateSchedule.Size = new System.Drawing.Size(111, 23);
            this.btnCreateSchedule.TabIndex = 0;
            this.btnCreateSchedule.Text = "Create Schedule";
            this.toolTip1.SetToolTip(this.btnCreateSchedule, "send opt schedule to VTN");
            this.btnCreateSchedule.UseVisualStyleBackColor = true;
            this.btnCreateSchedule.Click += new System.EventHandler(this.OnCreateScheduleClick);
            // 
            // ucOptScheduleView1
            // 
            this.ucOptScheduleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOptScheduleView.Location = new System.Drawing.Point(0, 0);
            this.ucOptScheduleView.Name = "ucOptScheduleView";
            this.ucOptScheduleView.Size = new System.Drawing.Size(490, 367);
            this.ucOptScheduleView.TabIndex = 1;
            // 
            // frmNewScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 462);
            this.Controls.Add(this.ucOptScheduleView);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmNewScheduleView";
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
        private OptScheduleViewControl ucOptScheduleView;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolTip toolTip1;
        public TextBoxControl tbScheduleName;
    }
}