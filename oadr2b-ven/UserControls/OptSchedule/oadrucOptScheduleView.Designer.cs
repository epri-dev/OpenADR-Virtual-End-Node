namespace oadr2b_ven.UserControls.OptSchedule
{
    partial class oadrucOptScheduleView
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
            this.pnlOptSchedule = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvAvailability = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtResource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.txtMarketContext = new System.Windows.Forms.TextBox();
            this.txtOptID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOptReason = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOptType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlOptSchedule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOptSchedule
            // 
            this.pnlOptSchedule.Controls.Add(this.groupBox1);
            this.pnlOptSchedule.Controls.Add(this.txtResource);
            this.pnlOptSchedule.Controls.Add(this.label5);
            this.pnlOptSchedule.Controls.Add(this.btnDeleteSchedule);
            this.pnlOptSchedule.Controls.Add(this.btnAddSchedule);
            this.pnlOptSchedule.Controls.Add(this.txtMarketContext);
            this.pnlOptSchedule.Controls.Add(this.txtOptID);
            this.pnlOptSchedule.Controls.Add(this.label7);
            this.pnlOptSchedule.Controls.Add(this.label6);
            this.pnlOptSchedule.Controls.Add(this.numericUpDownDuration);
            this.pnlOptSchedule.Controls.Add(this.label4);
            this.pnlOptSchedule.Controls.Add(this.dtStart);
            this.pnlOptSchedule.Controls.Add(this.label3);
            this.pnlOptSchedule.Controls.Add(this.cmbOptReason);
            this.pnlOptSchedule.Controls.Add(this.label2);
            this.pnlOptSchedule.Controls.Add(this.cmbOptType);
            this.pnlOptSchedule.Controls.Add(this.label1);
            this.pnlOptSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptSchedule.Location = new System.Drawing.Point(0, 0);
            this.pnlOptSchedule.Name = "pnlOptSchedule";
            this.pnlOptSchedule.Size = new System.Drawing.Size(425, 415);
            this.pnlOptSchedule.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvAvailability);
            this.groupBox1.Location = new System.Drawing.Point(19, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 200);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Availability";
            // 
            // lvAvailability
            // 
            this.lvAvailability.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvAvailability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAvailability.FullRowSelect = true;
            this.lvAvailability.GridLines = true;
            this.lvAvailability.Location = new System.Drawing.Point(3, 16);
            this.lvAvailability.Name = "lvAvailability";
            this.lvAvailability.Size = new System.Drawing.Size(377, 181);
            this.lvAvailability.TabIndex = 16;
            this.lvAvailability.UseCompatibleStateImageBehavior = false;
            this.lvAvailability.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Start Date/Time";
            this.columnHeader1.Width = 131;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Duration";
            this.columnHeader2.Width = 86;
            // 
            // txtResource
            // 
            this.txtResource.Location = new System.Drawing.Point(228, 81);
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(171, 20);
            this.txtResource.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Resource";
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.Location = new System.Drawing.Point(249, 369);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(150, 23);
            this.btnDeleteSchedule.TabIndex = 15;
            this.btnDeleteSchedule.TabStop = false;
            this.btnDeleteSchedule.Text = "Remove Selected Rows";
            this.btnDeleteSchedule.UseVisualStyleBackColor = true;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(300, 134);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(99, 23);
            this.btnAddSchedule.TabIndex = 8;
            this.btnAddSchedule.Text = "Add Availability";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // txtMarketContext
            // 
            this.txtMarketContext.Location = new System.Drawing.Point(18, 81);
            this.txtMarketContext.Name = "txtMarketContext";
            this.txtMarketContext.Size = new System.Drawing.Size(171, 20);
            this.txtMarketContext.TabIndex = 4;
            // 
            // txtOptID
            // 
            this.txtOptID.Enabled = false;
            this.txtOptID.Location = new System.Drawing.Point(18, 29);
            this.txtOptID.Name = "txtOptID";
            this.txtOptID.Size = new System.Drawing.Size(121, 20);
            this.txtOptID.TabIndex = 1;
            this.txtOptID.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Market Context";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Opt ID";
            // 
            // numericUpDownDuration
            // 
            this.numericUpDownDuration.Location = new System.Drawing.Point(221, 137);
            this.numericUpDownDuration.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDuration.Name = "numericUpDownDuration";
            this.numericUpDownDuration.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownDuration.TabIndex = 7;
            this.numericUpDownDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Duration (Hour)";
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "ddd MMM dd yyyy hh:mm tt";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(22, 137);
            this.dtStart.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(180, 20);
            this.dtStart.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start Date";
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
            this.cmbOptReason.Location = new System.Drawing.Point(278, 28);
            this.cmbOptReason.Name = "cmbOptReason";
            this.cmbOptReason.Size = new System.Drawing.Size(121, 21);
            this.cmbOptReason.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Opt Reason";
            // 
            // cmbOptType
            // 
            this.cmbOptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptType.FormattingEnabled = true;
            this.cmbOptType.Items.AddRange(new object[] {
            "optIn",
            "optOut"});
            this.cmbOptType.Location = new System.Drawing.Point(145, 28);
            this.cmbOptType.Name = "cmbOptType";
            this.cmbOptType.Size = new System.Drawing.Size(121, 21);
            this.cmbOptType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Opt Type";
            // 
            // oadrucOptScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOptSchedule);
            this.Name = "oadrucOptScheduleView";
            this.Size = new System.Drawing.Size(425, 415);
            this.pnlOptSchedule.ResumeLayout(false);
            this.pnlOptSchedule.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOptSchedule;
        private System.Windows.Forms.NumericUpDown numericUpDownDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOptReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOptType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarketContext;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOptID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.ListView lvAvailability;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtResource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;


    }
}
