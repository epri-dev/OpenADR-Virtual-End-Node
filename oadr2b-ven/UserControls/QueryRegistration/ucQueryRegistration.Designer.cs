namespace oadr2b_ven.UserControls.QueryRegistration
{
    partial class ucQueryRegistration
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tvExtensions = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tvServiceSpecificInfo = new System.Windows.Forms.TreeView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tvOadrProfiles = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancelRegistration = new System.Windows.Forms.Button();
            this.btnQueryRegistration = new System.Windows.Forms.Button();
            this.ucRegistrationID = new oadr2b_ven.UserControls.ucTextBox();
            this.ucVENID = new oadr2b_ven.UserControls.ucTextBox();
            this.ucVTNID = new oadr2b_ven.UserControls.ucTextBox();
            this.ucPollFrequency = new oadr2b_ven.UserControls.ucTextBox();
            this.btnClearRegistration = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.panel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(537, 537);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Registration";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tvExtensions);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 400);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(531, 134);
            this.groupBox7.TabIndex = 27;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Oadr Extensions";
            // 
            // tvExtensions
            // 
            this.tvExtensions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvExtensions.Location = new System.Drawing.Point(3, 16);
            this.tvExtensions.Name = "tvExtensions";
            this.tvExtensions.Size = new System.Drawing.Size(525, 115);
            this.tvExtensions.TabIndex = 20;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tvServiceSpecificInfo);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 286);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(531, 114);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Service Specific Info";
            // 
            // tvServiceSpecificInfo
            // 
            this.tvServiceSpecificInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvServiceSpecificInfo.Location = new System.Drawing.Point(3, 16);
            this.tvServiceSpecificInfo.Name = "tvServiceSpecificInfo";
            this.tvServiceSpecificInfo.Size = new System.Drawing.Size(525, 95);
            this.tvServiceSpecificInfo.TabIndex = 20;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tvOadrProfiles);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 162);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(531, 124);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Oadr Profiles";
            // 
            // tvOadrProfiles
            // 
            this.tvOadrProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOadrProfiles.Location = new System.Drawing.Point(3, 16);
            this.tvOadrProfiles.Name = "tvOadrProfiles";
            this.tvOadrProfiles.Size = new System.Drawing.Size(525, 105);
            this.tvOadrProfiles.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearRegistration);
            this.panel3.Controls.Add(this.btnRegister);
            this.panel3.Controls.Add(this.btnCancelRegistration);
            this.panel3.Controls.Add(this.btnQueryRegistration);
            this.panel3.Controls.Add(this.ucRegistrationID);
            this.panel3.Controls.Add(this.ucVENID);
            this.panel3.Controls.Add(this.ucVTNID);
            this.panel3.Controls.Add(this.ucPollFrequency);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(531, 146);
            this.panel3.TabIndex = 24;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(12, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 20;
            this.btnRegister.Text = "Register";
            this.toolTip1.SetToolTip(this.btnRegister, "Register with the VTN");
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancelRegistration
            // 
            this.btnCancelRegistration.Location = new System.Drawing.Point(221, 3);
            this.btnCancelRegistration.Name = "btnCancelRegistration";
            this.btnCancelRegistration.Size = new System.Drawing.Size(112, 23);
            this.btnCancelRegistration.TabIndex = 19;
            this.btnCancelRegistration.Text = "Cancel Registration";
            this.toolTip1.SetToolTip(this.btnCancelRegistration, "Cancel registration with the VTN");
            this.btnCancelRegistration.UseVisualStyleBackColor = true;
            this.btnCancelRegistration.Click += new System.EventHandler(this.btnCancelRegistration_Click);
            // 
            // btnQueryRegistration
            // 
            this.btnQueryRegistration.Location = new System.Drawing.Point(93, 3);
            this.btnQueryRegistration.Name = "btnQueryRegistration";
            this.btnQueryRegistration.Size = new System.Drawing.Size(122, 23);
            this.btnQueryRegistration.TabIndex = 18;
            this.btnQueryRegistration.Text = "Query Registration";
            this.toolTip1.SetToolTip(this.btnQueryRegistration, "Query the VTN for registration information");
            this.btnQueryRegistration.UseVisualStyleBackColor = true;
            this.btnQueryRegistration.Click += new System.EventHandler(this.btnQueryRegistration_Click);
            // 
            // ucRegistrationID
            // 
            this.ucRegistrationID.DefaultValue = 2147483647;
            this.ucRegistrationID.IsURL = false;
            this.ucRegistrationID.LabelText = "Registration ID";
            this.ucRegistrationID.LabelWidth = 77;
            this.ucRegistrationID.Location = new System.Drawing.Point(12, 32);
            this.ucRegistrationID.MaxValue = 2147483647;
            this.ucRegistrationID.MinValue = -2147483648;
            this.ucRegistrationID.Name = "ucRegistrationID";
            this.ucRegistrationID.PasswordChar = '\0';
            this.ucRegistrationID.ReadOnly = true;
            this.ucRegistrationID.Required = false;
            this.ucRegistrationID.Size = new System.Drawing.Size(383, 21);
            this.ucRegistrationID.TabIndex = 8;
            this.ucRegistrationID.TextBoxText = "";
            this.ucRegistrationID.TextBoxWidth = 200;
            this.ucRegistrationID.UseLimits = false;
            // 
            // ucVENID
            // 
            this.ucVENID.DefaultValue = 2147483647;
            this.ucVENID.IsURL = false;
            this.ucVENID.LabelText = "VEN ID";
            this.ucVENID.LabelWidth = 43;
            this.ucVENID.Location = new System.Drawing.Point(12, 59);
            this.ucVENID.MaxValue = 2147483647;
            this.ucVENID.MinValue = -2147483648;
            this.ucVENID.Name = "ucVENID";
            this.ucVENID.PasswordChar = '\0';
            this.ucVENID.ReadOnly = true;
            this.ucVENID.Required = false;
            this.ucVENID.Size = new System.Drawing.Size(383, 21);
            this.ucVENID.TabIndex = 14;
            this.ucVENID.TextBoxText = "";
            this.ucVENID.TextBoxWidth = 200;
            this.ucVENID.UseLimits = false;
            // 
            // ucVTNID
            // 
            this.ucVTNID.DefaultValue = 2147483647;
            this.ucVTNID.IsURL = false;
            this.ucVTNID.LabelText = "VTN ID";
            this.ucVTNID.LabelWidth = 43;
            this.ucVTNID.Location = new System.Drawing.Point(12, 86);
            this.ucVTNID.MaxValue = 2147483647;
            this.ucVTNID.MinValue = -2147483648;
            this.ucVTNID.Name = "ucVTNID";
            this.ucVTNID.PasswordChar = '\0';
            this.ucVTNID.ReadOnly = true;
            this.ucVTNID.Required = false;
            this.ucVTNID.Size = new System.Drawing.Size(383, 21);
            this.ucVTNID.TabIndex = 15;
            this.ucVTNID.TextBoxText = "";
            this.ucVTNID.TextBoxWidth = 200;
            this.ucVTNID.UseLimits = false;
            // 
            // ucPollFrequency
            // 
            this.ucPollFrequency.DefaultValue = 2147483647;
            this.ucPollFrequency.IsURL = false;
            this.ucPollFrequency.LabelText = "Min Poll Frequency";
            this.ucPollFrequency.LabelWidth = 97;
            this.ucPollFrequency.Location = new System.Drawing.Point(12, 109);
            this.ucPollFrequency.MaxValue = 2147483647;
            this.ucPollFrequency.MinValue = -2147483648;
            this.ucPollFrequency.Name = "ucPollFrequency";
            this.ucPollFrequency.PasswordChar = '\0';
            this.ucPollFrequency.ReadOnly = true;
            this.ucPollFrequency.Required = false;
            this.ucPollFrequency.Size = new System.Drawing.Size(383, 21);
            this.ucPollFrequency.TabIndex = 17;
            this.ucPollFrequency.TextBoxText = "";
            this.ucPollFrequency.TextBoxWidth = 200;
            this.ucPollFrequency.UseLimits = false;
            // 
            // btnClearRegistration
            // 
            this.btnClearRegistration.Location = new System.Drawing.Point(401, 3);
            this.btnClearRegistration.Name = "btnClearRegistration";
            this.btnClearRegistration.Size = new System.Drawing.Size(117, 23);
            this.btnClearRegistration.TabIndex = 21;
            this.btnClearRegistration.Text = "Clear Registration";
            this.toolTip1.SetToolTip(this.btnClearRegistration, "Clear registration information without sending a message to the VTN");
            this.btnClearRegistration.UseVisualStyleBackColor = true;
            this.btnClearRegistration.Click += new System.EventHandler(this.btnClearRegistration_Click);
            // 
            // ucQueryRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "ucQueryRegistration";
            this.Size = new System.Drawing.Size(537, 537);
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TreeView tvExtensions;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TreeView tvServiceSpecificInfo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TreeView tvOadrProfiles;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnQueryRegistration;
        private UserControls.ucTextBox ucRegistrationID;
        private UserControls.ucTextBox ucVENID;
        private UserControls.ucTextBox ucVTNID;
        private UserControls.ucTextBox ucPollFrequency;
        private System.Windows.Forms.Button btnCancelRegistration;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClearRegistration;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
