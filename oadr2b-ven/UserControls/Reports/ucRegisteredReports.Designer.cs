namespace oadr2b_ven.UserControls.Reports
{
    partial class ucRegisteredReports
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstRegisteredRequests = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvReportRequestPayload = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 362);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reports";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstRegisteredRequests);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tvReportRequestPayload);
            this.splitContainer1.Size = new System.Drawing.Size(510, 343);
            this.splitContainer1.SplitterDistance = 393;
            this.splitContainer1.TabIndex = 2;
            // 
            // lstRegisteredRequests
            // 
            this.lstRegisteredRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstRegisteredRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRegisteredRequests.FullRowSelect = true;
            this.lstRegisteredRequests.GridLines = true;
            this.lstRegisteredRequests.HideSelection = false;
            this.lstRegisteredRequests.Location = new System.Drawing.Point(0, 0);
            this.lstRegisteredRequests.MultiSelect = false;
            this.lstRegisteredRequests.Name = "lstRegisteredRequests";
            this.lstRegisteredRequests.Size = new System.Drawing.Size(393, 343);
            this.lstRegisteredRequests.TabIndex = 1;
            this.lstRegisteredRequests.UseCompatibleStateImageBehavior = false;
            this.lstRegisteredRequests.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Report Specifier ID";
            this.columnHeader1.Width = 138;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 154;
            // 
            // tvReportRequestPayload
            // 
            this.tvReportRequestPayload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvReportRequestPayload.Location = new System.Drawing.Point(0, 0);
            this.tvReportRequestPayload.Name = "tvReportRequestPayload";
            this.tvReportRequestPayload.Size = new System.Drawing.Size(113, 343);
            this.tvReportRequestPayload.TabIndex = 1;
            // 
            // ucRegisteredReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ucRegisteredReports";
            this.Size = new System.Drawing.Size(516, 362);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstRegisteredRequests;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TreeView tvReportRequestPayload;
    }
}
