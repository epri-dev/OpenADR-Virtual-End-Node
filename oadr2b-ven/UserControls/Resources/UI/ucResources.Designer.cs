namespace oadr2b_ven.UserControls.Resources.UI
{
    partial class ucResources
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegisterReports = new System.Windows.Forms.Button();
            this.btnAddResource = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbResourceType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlResources = new System.Windows.Forms.Panel();
            this.tbResourceID = new oadr2b_ven.UserControls.ucTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbResourceID);
            this.groupBox1.Controls.Add(this.btnRegisterReports);
            this.groupBox1.Controls.Add(this.btnAddResource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbResourceType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Resource";
            // 
            // btnRegisterReports
            // 
            this.btnRegisterReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegisterReports.Location = new System.Drawing.Point(395, 80);
            this.btnRegisterReports.Name = "btnRegisterReports";
            this.btnRegisterReports.Size = new System.Drawing.Size(110, 23);
            this.btnRegisterReports.TabIndex = 3;
            this.btnRegisterReports.Text = "Register Reports";
            this.btnRegisterReports.UseVisualStyleBackColor = true;
            this.btnRegisterReports.Click += new System.EventHandler(this.btnRegisterReports_Click);
            // 
            // btnAddResource
            // 
            this.btnAddResource.Location = new System.Drawing.Point(162, 80);
            this.btnAddResource.Name = "btnAddResource";
            this.btnAddResource.Size = new System.Drawing.Size(121, 23);
            this.btnAddResource.TabIndex = 2;
            this.btnAddResource.Text = "Add Resource";
            this.btnAddResource.UseVisualStyleBackColor = true;
            this.btnAddResource.Click += new System.EventHandler(this.btnAddResource_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Resource Type";
            // 
            // cmbResourceType
            // 
            this.cmbResourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResourceType.FormattingEnabled = true;
            this.cmbResourceType.Items.AddRange(new object[] {
            "Load",
            "Generator"});
            this.cmbResourceType.Location = new System.Drawing.Point(102, 26);
            this.cmbResourceType.Name = "cmbResourceType";
            this.cmbResourceType.Size = new System.Drawing.Size(181, 21);
            this.cmbResourceType.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlResources);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 302);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resources";
            // 
            // pnlResources
            // 
            this.pnlResources.AutoScroll = true;
            this.pnlResources.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResources.Location = new System.Drawing.Point(3, 16);
            this.pnlResources.Name = "pnlResources";
            this.pnlResources.Size = new System.Drawing.Size(516, 283);
            this.pnlResources.TabIndex = 0;
            // 
            // tbResourceID
            // 
            this.tbResourceID.DefaultValue = 2147483647;
            this.tbResourceID.IsURL = false;
            this.tbResourceID.LabelText = "Resource ID";
            this.tbResourceID.LabelWidth = 67;
            this.tbResourceID.Location = new System.Drawing.Point(16, 53);
            this.tbResourceID.MaxValue = 2147483647;
            this.tbResourceID.MinValue = -2147483648;
            this.tbResourceID.Name = "tbResourceID";
            this.tbResourceID.PasswordChar = '\0';
            this.tbResourceID.ReadOnly = false;
            this.tbResourceID.Required = false;
            this.tbResourceID.Size = new System.Drawing.Size(267, 21);
            this.tbResourceID.TabIndex = 10;
            this.tbResourceID.TextBoxText = "";
            this.tbResourceID.TextBoxWidth = 141;
            this.toolTip1.SetToolTip(this.tbResourceID, "Resource ID (leave blank for random ID)");
            this.tbResourceID.UseLimits = false;
            // 
            // ucResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(522, 0);
            this.Name = "ucResources";
            this.Size = new System.Drawing.Size(522, 420);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddResource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbResourceType;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Panel pnlResources;
        private System.Windows.Forms.Button btnRegisterReports;
        protected ucTextBox tbResourceID;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
