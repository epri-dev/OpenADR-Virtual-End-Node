namespace oadr2b_ven.UserControls.Events
{
    partial class ucEvents
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
            this.splitContainerEvents = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.optInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.customCreateOptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbCreatedDate = new oadr2b_ven.UserControls.ucTextBox();
            this.tbVtnComment = new oadr2b_ven.UserControls.ucTextBox();
            this.tbEventStatus = new oadr2b_ven.UserControls.ucTextBox();
            this.tbEventID = new oadr2b_ven.UserControls.ucTextBox();
            this.tbMarketContext = new oadr2b_ven.UserControls.ucTextBox();
            this.tbTestEvent = new oadr2b_ven.UserControls.ucTextBox();
            this.tbPriority = new oadr2b_ven.UserControls.ucTextBox();
            this.tbModificationNumber = new oadr2b_ven.UserControls.ucTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbRecovery = new oadr2b_ven.UserControls.ucTextBox();
            this.tbRampup = new oadr2b_ven.UserControls.ucTextBox();
            this.tbNotification = new oadr2b_ven.UserControls.ucTextBox();
            this.tbTolerance = new oadr2b_ven.UserControls.ucTextBox();
            this.tbDuration = new oadr2b_ven.UserControls.ucTextBox();
            this.tbDTStart = new oadr2b_ven.UserControls.ucTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lstIntervals = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lstSignals = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lstParty = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstVENs = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstResources = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.txtGroups = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEvents)).BeginInit();
            this.splitContainerEvents.Panel1.SuspendLayout();
            this.splitContainerEvents.Panel2.SuspendLayout();
            this.splitContainerEvents.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerEvents
            // 
            this.splitContainerEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEvents.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEvents.Name = "splitContainerEvents";
            this.splitContainerEvents.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEvents.Panel1
            // 
            this.splitContainerEvents.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainerEvents.Panel2
            // 
            this.splitContainerEvents.Panel2.Controls.Add(this.groupBox7);
            this.splitContainerEvents.Size = new System.Drawing.Size(850, 579);
            this.splitContainerEvents.SplitterDistance = 246;
            this.splitContainerEvents.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(850, 246);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Events";
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(844, 227);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optInToolStripMenuItem,
            this.optOutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.customCreateOptToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 76);
            // 
            // optInToolStripMenuItem
            // 
            this.optInToolStripMenuItem.Name = "optInToolStripMenuItem";
            this.optInToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.optInToolStripMenuItem.Text = "Opt In";
            this.optInToolStripMenuItem.Click += new System.EventHandler(this.optInToolStripMenuItem_Click);
            // 
            // optOutToolStripMenuItem
            // 
            this.optOutToolStripMenuItem.Name = "optOutToolStripMenuItem";
            this.optOutToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.optOutToolStripMenuItem.Text = "Opt Out";
            this.optOutToolStripMenuItem.Click += new System.EventHandler(this.optOutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // customCreateOptToolStripMenuItem
            // 
            this.customCreateOptToolStripMenuItem.Name = "customCreateOptToolStripMenuItem";
            this.customCreateOptToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.customCreateOptToolStripMenuItem.Text = "Create Opt ...";
            this.customCreateOptToolStripMenuItem.Click += new System.EventHandler(this.customCreateOptToolStripMenuItem_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tabControl1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(850, 329);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Event Details";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(844, 310);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tbCreatedDate);
            this.tabPage1.Controls.Add(this.tbVtnComment);
            this.tabPage1.Controls.Add(this.tbEventStatus);
            this.tabPage1.Controls.Add(this.tbEventID);
            this.tabPage1.Controls.Add(this.tbMarketContext);
            this.tabPage1.Controls.Add(this.tbTestEvent);
            this.tabPage1.Controls.Add(this.tbPriority);
            this.tabPage1.Controls.Add(this.tbModificationNumber);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(836, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Event Descriptor";
            // 
            // tbCreatedDate
            // 
            this.tbCreatedDate.DefaultValue = 2147483647;
            this.tbCreatedDate.IsURL = false;
            this.tbCreatedDate.LabelText = "Created Date/Time";
            this.tbCreatedDate.LabelWidth = 98;
            this.tbCreatedDate.Location = new System.Drawing.Point(18, 127);
            this.tbCreatedDate.MaxValue = 2147483647;
            this.tbCreatedDate.MinValue = -2147483648;
            this.tbCreatedDate.Name = "tbCreatedDate";
            this.tbCreatedDate.Numeric = true;
            this.tbCreatedDate.PasswordChar = '\0';
            this.tbCreatedDate.ReadOnly = true;
            this.tbCreatedDate.Required = false;
            this.tbCreatedDate.Size = new System.Drawing.Size(301, 21);
            this.tbCreatedDate.TabIndex = 4;
            this.tbCreatedDate.TextBoxText = "";
            this.tbCreatedDate.TextBoxWidth = 170;
            this.tbCreatedDate.ToolTip = "";
            this.tbCreatedDate.UseLimits = false;
            // 
            // tbVtnComment
            // 
            this.tbVtnComment.DefaultValue = 2147483647;
            this.tbVtnComment.IsURL = false;
            this.tbVtnComment.LabelText = "VTN Comment";
            this.tbVtnComment.LabelWidth = 76;
            this.tbVtnComment.Location = new System.Drawing.Point(18, 208);
            this.tbVtnComment.MaxValue = 2147483647;
            this.tbVtnComment.MinValue = -2147483648;
            this.tbVtnComment.Name = "tbVtnComment";
            this.tbVtnComment.Numeric = true;
            this.tbVtnComment.PasswordChar = '\0';
            this.tbVtnComment.ReadOnly = true;
            this.tbVtnComment.Required = false;
            this.tbVtnComment.Size = new System.Drawing.Size(301, 21);
            this.tbVtnComment.TabIndex = 7;
            this.tbVtnComment.TextBoxText = "";
            this.tbVtnComment.TextBoxWidth = 170;
            this.tbVtnComment.ToolTip = "";
            this.tbVtnComment.UseLimits = false;
            // 
            // tbEventStatus
            // 
            this.tbEventStatus.DefaultValue = 2147483647;
            this.tbEventStatus.IsURL = false;
            this.tbEventStatus.LabelText = "Event Status";
            this.tbEventStatus.LabelWidth = 68;
            this.tbEventStatus.Location = new System.Drawing.Point(18, 154);
            this.tbEventStatus.MaxValue = 2147483647;
            this.tbEventStatus.MinValue = -2147483648;
            this.tbEventStatus.Name = "tbEventStatus";
            this.tbEventStatus.Numeric = true;
            this.tbEventStatus.PasswordChar = '\0';
            this.tbEventStatus.ReadOnly = true;
            this.tbEventStatus.Required = false;
            this.tbEventStatus.Size = new System.Drawing.Size(301, 21);
            this.tbEventStatus.TabIndex = 5;
            this.tbEventStatus.TextBoxText = "";
            this.tbEventStatus.TextBoxWidth = 170;
            this.tbEventStatus.ToolTip = "";
            this.tbEventStatus.UseLimits = false;
            // 
            // tbEventID
            // 
            this.tbEventID.DefaultValue = 2147483647;
            this.tbEventID.IsURL = false;
            this.tbEventID.LabelText = "Event ID";
            this.tbEventID.LabelWidth = 49;
            this.tbEventID.Location = new System.Drawing.Point(18, 19);
            this.tbEventID.MaxValue = 2147483647;
            this.tbEventID.MinValue = -2147483648;
            this.tbEventID.Name = "tbEventID";
            this.tbEventID.Numeric = true;
            this.tbEventID.PasswordChar = '\0';
            this.tbEventID.ReadOnly = true;
            this.tbEventID.Required = false;
            this.tbEventID.Size = new System.Drawing.Size(301, 21);
            this.tbEventID.TabIndex = 0;
            this.tbEventID.TextBoxText = "";
            this.tbEventID.TextBoxWidth = 170;
            this.tbEventID.ToolTip = "";
            this.tbEventID.UseLimits = false;
            // 
            // tbMarketContext
            // 
            this.tbMarketContext.DefaultValue = 2147483647;
            this.tbMarketContext.IsURL = false;
            this.tbMarketContext.LabelText = "Market Context";
            this.tbMarketContext.LabelWidth = 79;
            this.tbMarketContext.Location = new System.Drawing.Point(18, 100);
            this.tbMarketContext.MaxValue = 2147483647;
            this.tbMarketContext.MinValue = -2147483648;
            this.tbMarketContext.Name = "tbMarketContext";
            this.tbMarketContext.Numeric = true;
            this.tbMarketContext.PasswordChar = '\0';
            this.tbMarketContext.ReadOnly = true;
            this.tbMarketContext.Required = false;
            this.tbMarketContext.Size = new System.Drawing.Size(301, 21);
            this.tbMarketContext.TabIndex = 3;
            this.tbMarketContext.TextBoxText = "";
            this.tbMarketContext.TextBoxWidth = 170;
            this.tbMarketContext.ToolTip = "";
            this.tbMarketContext.UseLimits = false;
            // 
            // tbTestEvent
            // 
            this.tbTestEvent.DefaultValue = 2147483647;
            this.tbTestEvent.IsURL = false;
            this.tbTestEvent.LabelText = "Test Event";
            this.tbTestEvent.LabelWidth = 59;
            this.tbTestEvent.Location = new System.Drawing.Point(18, 181);
            this.tbTestEvent.MaxValue = 2147483647;
            this.tbTestEvent.MinValue = -2147483648;
            this.tbTestEvent.Name = "tbTestEvent";
            this.tbTestEvent.Numeric = true;
            this.tbTestEvent.PasswordChar = '\0';
            this.tbTestEvent.ReadOnly = true;
            this.tbTestEvent.Required = false;
            this.tbTestEvent.Size = new System.Drawing.Size(301, 21);
            this.tbTestEvent.TabIndex = 6;
            this.tbTestEvent.TextBoxText = "";
            this.tbTestEvent.TextBoxWidth = 170;
            this.tbTestEvent.ToolTip = "";
            this.tbTestEvent.UseLimits = false;
            // 
            // tbPriority
            // 
            this.tbPriority.DefaultValue = 2147483647;
            this.tbPriority.IsURL = false;
            this.tbPriority.LabelText = "Priority";
            this.tbPriority.LabelWidth = 38;
            this.tbPriority.Location = new System.Drawing.Point(18, 73);
            this.tbPriority.MaxValue = 2147483647;
            this.tbPriority.MinValue = -2147483648;
            this.tbPriority.Name = "tbPriority";
            this.tbPriority.Numeric = true;
            this.tbPriority.PasswordChar = '\0';
            this.tbPriority.ReadOnly = true;
            this.tbPriority.Required = false;
            this.tbPriority.Size = new System.Drawing.Size(301, 21);
            this.tbPriority.TabIndex = 2;
            this.tbPriority.TextBoxText = "";
            this.tbPriority.TextBoxWidth = 170;
            this.tbPriority.ToolTip = "";
            this.tbPriority.UseLimits = false;
            // 
            // tbModificationNumber
            // 
            this.tbModificationNumber.DefaultValue = 2147483647;
            this.tbModificationNumber.IsURL = false;
            this.tbModificationNumber.LabelText = "Modification Number";
            this.tbModificationNumber.LabelWidth = 104;
            this.tbModificationNumber.Location = new System.Drawing.Point(18, 46);
            this.tbModificationNumber.MaxValue = 2147483647;
            this.tbModificationNumber.MinValue = -2147483648;
            this.tbModificationNumber.Name = "tbModificationNumber";
            this.tbModificationNumber.Numeric = true;
            this.tbModificationNumber.PasswordChar = '\0';
            this.tbModificationNumber.ReadOnly = true;
            this.tbModificationNumber.Required = false;
            this.tbModificationNumber.Size = new System.Drawing.Size(301, 21);
            this.tbModificationNumber.TabIndex = 1;
            this.tbModificationNumber.TextBoxText = "";
            this.tbModificationNumber.TextBoxWidth = 170;
            this.tbModificationNumber.ToolTip = "";
            this.tbModificationNumber.UseLimits = false;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tbRecovery);
            this.tabPage2.Controls.Add(this.tbRampup);
            this.tabPage2.Controls.Add(this.tbNotification);
            this.tabPage2.Controls.Add(this.tbTolerance);
            this.tabPage2.Controls.Add(this.tbDuration);
            this.tabPage2.Controls.Add(this.tbDTStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(836, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Active Period";
            // 
            // tbRecovery
            // 
            this.tbRecovery.DefaultValue = 2147483647;
            this.tbRecovery.IsURL = false;
            this.tbRecovery.LabelText = "eiRecovery";
            this.tbRecovery.LabelWidth = 61;
            this.tbRecovery.Location = new System.Drawing.Point(22, 156);
            this.tbRecovery.MaxValue = 2147483647;
            this.tbRecovery.MinValue = -2147483648;
            this.tbRecovery.Name = "tbRecovery";
            this.tbRecovery.Numeric = true;
            this.tbRecovery.PasswordChar = '\0';
            this.tbRecovery.ReadOnly = true;
            this.tbRecovery.Required = false;
            this.tbRecovery.Size = new System.Drawing.Size(255, 21);
            this.tbRecovery.TabIndex = 12;
            this.tbRecovery.TextBoxText = "";
            this.tbRecovery.TextBoxWidth = 121;
            this.tbRecovery.ToolTip = "";
            this.tbRecovery.UseLimits = false;
            // 
            // tbRampup
            // 
            this.tbRampup.DefaultValue = 2147483647;
            this.tbRampup.IsURL = false;
            this.tbRampup.LabelText = "eiRampUp";
            this.tbRampup.LabelWidth = 57;
            this.tbRampup.Location = new System.Drawing.Point(22, 129);
            this.tbRampup.MaxValue = 2147483647;
            this.tbRampup.MinValue = -2147483648;
            this.tbRampup.Name = "tbRampup";
            this.tbRampup.Numeric = true;
            this.tbRampup.PasswordChar = '\0';
            this.tbRampup.ReadOnly = true;
            this.tbRampup.Required = false;
            this.tbRampup.Size = new System.Drawing.Size(255, 21);
            this.tbRampup.TabIndex = 11;
            this.tbRampup.TextBoxText = "";
            this.tbRampup.TextBoxWidth = 121;
            this.tbRampup.ToolTip = "";
            this.tbRampup.UseLimits = false;
            // 
            // tbNotification
            // 
            this.tbNotification.DefaultValue = 2147483647;
            this.tbNotification.IsURL = false;
            this.tbNotification.LabelText = "eiNotification";
            this.tbNotification.LabelWidth = 68;
            this.tbNotification.Location = new System.Drawing.Point(22, 102);
            this.tbNotification.MaxValue = 2147483647;
            this.tbNotification.MinValue = -2147483648;
            this.tbNotification.Name = "tbNotification";
            this.tbNotification.Numeric = true;
            this.tbNotification.PasswordChar = '\0';
            this.tbNotification.ReadOnly = true;
            this.tbNotification.Required = false;
            this.tbNotification.Size = new System.Drawing.Size(255, 21);
            this.tbNotification.TabIndex = 10;
            this.tbNotification.TextBoxText = "";
            this.tbNotification.TextBoxWidth = 121;
            this.tbNotification.ToolTip = "";
            this.tbNotification.UseLimits = false;
            // 
            // tbTolerance
            // 
            this.tbTolerance.DefaultValue = 2147483647;
            this.tbTolerance.IsURL = false;
            this.tbTolerance.LabelText = "Start After";
            this.tbTolerance.LabelWidth = 54;
            this.tbTolerance.Location = new System.Drawing.Point(22, 75);
            this.tbTolerance.MaxValue = 2147483647;
            this.tbTolerance.MinValue = -2147483648;
            this.tbTolerance.Name = "tbTolerance";
            this.tbTolerance.Numeric = true;
            this.tbTolerance.PasswordChar = '\0';
            this.tbTolerance.ReadOnly = true;
            this.tbTolerance.Required = false;
            this.tbTolerance.Size = new System.Drawing.Size(255, 21);
            this.tbTolerance.TabIndex = 9;
            this.tbTolerance.TextBoxText = "";
            this.tbTolerance.TextBoxWidth = 121;
            this.tbTolerance.ToolTip = "";
            this.tbTolerance.UseLimits = false;
            // 
            // tbDuration
            // 
            this.tbDuration.DefaultValue = 2147483647;
            this.tbDuration.IsURL = false;
            this.tbDuration.LabelText = "Duration";
            this.tbDuration.LabelWidth = 47;
            this.tbDuration.Location = new System.Drawing.Point(22, 48);
            this.tbDuration.MaxValue = 2147483647;
            this.tbDuration.MinValue = -2147483648;
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Numeric = true;
            this.tbDuration.PasswordChar = '\0';
            this.tbDuration.ReadOnly = true;
            this.tbDuration.Required = false;
            this.tbDuration.Size = new System.Drawing.Size(255, 21);
            this.tbDuration.TabIndex = 8;
            this.tbDuration.TextBoxText = "";
            this.tbDuration.TextBoxWidth = 121;
            this.tbDuration.ToolTip = "";
            this.tbDuration.UseLimits = false;
            // 
            // tbDTStart
            // 
            this.tbDTStart.DefaultValue = 2147483647;
            this.tbDTStart.IsURL = false;
            this.tbDTStart.LabelText = "DT Start";
            this.tbDTStart.LabelWidth = 47;
            this.tbDTStart.Location = new System.Drawing.Point(22, 21);
            this.tbDTStart.MaxValue = 2147483647;
            this.tbDTStart.MinValue = -2147483648;
            this.tbDTStart.Name = "tbDTStart";
            this.tbDTStart.Numeric = true;
            this.tbDTStart.PasswordChar = '\0';
            this.tbDTStart.ReadOnly = true;
            this.tbDTStart.Required = false;
            this.tbDTStart.Size = new System.Drawing.Size(255, 21);
            this.tbDTStart.TabIndex = 7;
            this.tbDTStart.TextBoxText = "";
            this.tbDTStart.TextBoxWidth = 121;
            this.tbDTStart.ToolTip = "";
            this.tbDTStart.UseLimits = false;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(836, 284);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Event Signals";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox8.Controls.Add(this.lstIntervals);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 125);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(836, 159);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Intervals";
            // 
            // lstIntervals
            // 
            this.lstIntervals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.lstIntervals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstIntervals.GridLines = true;
            this.lstIntervals.Location = new System.Drawing.Point(3, 16);
            this.lstIntervals.Name = "lstIntervals";
            this.lstIntervals.Size = new System.Drawing.Size(830, 140);
            this.lstIntervals.TabIndex = 0;
            this.lstIntervals.UseCompatibleStateImageBehavior = false;
            this.lstIntervals.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Duration";
            this.columnHeader15.Width = 75;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "UID";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Payload Type";
            this.columnHeader17.Width = 98;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox6.Controls.Add(this.lstSignals);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(836, 125);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Signals";
            // 
            // lstSignals
            // 
            this.lstSignals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.lstSignals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSignals.GridLines = true;
            this.lstSignals.Location = new System.Drawing.Point(3, 16);
            this.lstSignals.Name = "lstSignals";
            this.lstSignals.Size = new System.Drawing.Size(830, 106);
            this.lstSignals.TabIndex = 0;
            this.lstSignals.UseCompatibleStateImageBehavior = false;
            this.lstSignals.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Name";
            this.columnHeader11.Width = 89;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Type";
            this.columnHeader12.Width = 126;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "ID";
            this.columnHeader13.Width = 111;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Current Value";
            this.columnHeader14.Width = 144;
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(836, 284);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Targets";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Controls.Add(this.lstParty);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(600, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(233, 284);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Party IDs";
            // 
            // lstParty
            // 
            this.lstParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstParty.FormattingEnabled = true;
            this.lstParty.Location = new System.Drawing.Point(3, 16);
            this.lstParty.Name = "lstParty";
            this.lstParty.Size = new System.Drawing.Size(227, 265);
            this.lstParty.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.lstVENs);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(400, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 284);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "VEN IDs";
            // 
            // lstVENs
            // 
            this.lstVENs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVENs.FormattingEnabled = true;
            this.lstVENs.Location = new System.Drawing.Point(3, 16);
            this.lstVENs.Name = "lstVENs";
            this.lstVENs.Size = new System.Drawing.Size(194, 265);
            this.lstVENs.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.lstResources);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(200, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 284);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resource IDs";
            // 
            // lstResources
            // 
            this.lstResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResources.FormattingEnabled = true;
            this.lstResources.Location = new System.Drawing.Point(3, 16);
            this.lstResources.Name = "lstResources";
            this.lstResources.Size = new System.Drawing.Size(194, 265);
            this.lstResources.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lstGroups);
            this.groupBox1.Controls.Add(this.txtGroups);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 284);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group IDs";
            // 
            // lstGroups
            // 
            this.lstGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.Location = new System.Drawing.Point(3, 16);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(194, 265);
            this.lstGroups.TabIndex = 1;
            // 
            // txtGroups
            // 
            this.txtGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGroups.Location = new System.Drawing.Point(3, 16);
            this.txtGroups.Multiline = true;
            this.txtGroups.Name = "txtGroups";
            this.txtGroups.Size = new System.Drawing.Size(194, 265);
            this.txtGroups.TabIndex = 0;
            // 
            // ucEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerEvents);
            this.Name = "ucEvents";
            this.Size = new System.Drawing.Size(850, 579);
            this.splitContainerEvents.Panel1.ResumeLayout(false);
            this.splitContainerEvents.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEvents)).EndInit();
            this.splitContainerEvents.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainerEvents;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private ucTextBox tbMarketContext;
        private ucTextBox tbPriority;
        private ucTextBox tbModificationNumber;
        private ucTextBox tbEventID;
        private ucTextBox tbVtnComment;
        private ucTextBox tbTestEvent;
        private ucTextBox tbEventStatus;
        private ucTextBox tbCreatedDate;
        private ucTextBox tbRecovery;
        private ucTextBox tbRampup;
        private ucTextBox tbNotification;
        private ucTextBox tbTolerance;
        private ucTextBox tbDuration;
        private ucTextBox tbDTStart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optOutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGroups;
        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.ListBox lstParty;
        private System.Windows.Forms.ListBox lstVENs;
        private System.Windows.Forms.ListBox lstResources;
        private System.Windows.Forms.ListView lstSignals;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListView lstIntervals;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customCreateOptToolStripMenuItem;
    }
}
