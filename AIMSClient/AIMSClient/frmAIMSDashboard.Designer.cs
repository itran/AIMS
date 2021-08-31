namespace AIMSClient
{
    partial class frmAIMSDashboard
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
            this.tabDashboards = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lineSep = new System.Windows.Forms.PictureBox();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.lblAllWorkbaskets = new System.Windows.Forms.Label();
            this.lblLinkAllWorkbaskets = new System.Windows.Forms.LinkLabel();
            this.lblUnallocateFiles = new System.Windows.Forms.Label();
            this.lblLinkUnallocatedFiles = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstAdminPendingFiles = new System.Windows.Forms.ListView();
            this.grpbxUrgentEmails = new System.Windows.Forms.GroupBox();
            this.lstVwUrgentEmails = new System.Windows.Forms.ListView();
            this.grpbxWorkAllocated = new System.Windows.Forms.GroupBox();
            this.lstWorkAllocated = new System.Windows.Forms.ListView();
            this.grpbxPendedFiles = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstPendedCase = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpbxAllocatedFiles = new System.Windows.Forms.GroupBox();
            this.lstAllocatedCases = new System.Windows.Forms.ListView();
            this.dashTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cntxMenuWork = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showCoOrdinatorWorkLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabDashboards.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineSep)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpbxUrgentEmails.SuspendLayout();
            this.grpbxWorkAllocated.SuspendLayout();
            this.grpbxPendedFiles.SuspendLayout();
            this.grpbxAllocatedFiles.SuspendLayout();
            this.cntxMenuWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDashboards
            // 
            this.tabDashboards.Controls.Add(this.tabPage1);
            this.tabDashboards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDashboards.Location = new System.Drawing.Point(0, 0);
            this.tabDashboards.Name = "tabDashboards";
            this.tabDashboards.SelectedIndex = 0;
            this.tabDashboards.Size = new System.Drawing.Size(1199, 510);
            this.tabDashboards.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lineSep);
            this.tabPage1.Controls.Add(this.lblCountDown);
            this.tabPage1.Controls.Add(this.lblAllWorkbaskets);
            this.tabPage1.Controls.Add(this.lblLinkAllWorkbaskets);
            this.tabPage1.Controls.Add(this.lblUnallocateFiles);
            this.tabPage1.Controls.Add(this.lblLinkUnallocatedFiles);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.grpbxUrgentEmails);
            this.tabPage1.Controls.Add(this.grpbxWorkAllocated);
            this.tabPage1.Controls.Add(this.grpbxPendedFiles);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.grpbxAllocatedFiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1191, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Operations";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lineSep
            // 
            this.lineSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineSep.Location = new System.Drawing.Point(1039, 251);
            this.lineSep.Name = "lineSep";
            this.lineSep.Size = new System.Drawing.Size(5, 30);
            this.lineSep.TabIndex = 13;
            this.lineSep.TabStop = false;
            this.lineSep.Click += new System.EventHandler(this.lineSep_Click);
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.ForeColor = System.Drawing.Color.Green;
            this.lblCountDown.Location = new System.Drawing.Point(991, 119);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(54, 20);
            this.lblCountDown.TabIndex = 5;
            this.lblCountDown.Text = "00:00";
            this.lblCountDown.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblAllWorkbaskets
            // 
            this.lblAllWorkbaskets.AutoSize = true;
            this.lblAllWorkbaskets.Location = new System.Drawing.Point(1051, 276);
            this.lblAllWorkbaskets.Name = "lblAllWorkbaskets";
            this.lblAllWorkbaskets.Size = new System.Drawing.Size(84, 13);
            this.lblAllWorkbaskets.TabIndex = 12;
            this.lblAllWorkbaskets.Text = "All Workbaskets";
            this.lblAllWorkbaskets.Click += new System.EventHandler(this.lblAllWorkbaskets_Click);
            // 
            // lblLinkAllWorkbaskets
            // 
            this.lblLinkAllWorkbaskets.AutoSize = true;
            this.lblLinkAllWorkbaskets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkAllWorkbaskets.ForeColor = System.Drawing.Color.Red;
            this.lblLinkAllWorkbaskets.LinkColor = System.Drawing.Color.Red;
            this.lblLinkAllWorkbaskets.Location = new System.Drawing.Point(1055, 294);
            this.lblLinkAllWorkbaskets.Name = "lblLinkAllWorkbaskets";
            this.lblLinkAllWorkbaskets.Size = new System.Drawing.Size(16, 16);
            this.lblLinkAllWorkbaskets.TabIndex = 11;
            this.lblLinkAllWorkbaskets.TabStop = true;
            this.lblLinkAllWorkbaskets.Text = "0";
            this.lblLinkAllWorkbaskets.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkAllWorkbaskets_LinkClicked);
            // 
            // lblUnallocateFiles
            // 
            this.lblUnallocateFiles.AutoSize = true;
            this.lblUnallocateFiles.Location = new System.Drawing.Point(895, 276);
            this.lblUnallocateFiles.Name = "lblUnallocateFiles";
            this.lblUnallocateFiles.Size = new System.Drawing.Size(140, 13);
            this.lblUnallocateFiles.TabIndex = 10;
            this.lblUnallocateFiles.Text = "Number of Unallocated Files";
            this.lblUnallocateFiles.Click += new System.EventHandler(this.lblUnallocateFiles_Click);
            // 
            // lblLinkUnallocatedFiles
            // 
            this.lblLinkUnallocatedFiles.AutoSize = true;
            this.lblLinkUnallocatedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkUnallocatedFiles.ForeColor = System.Drawing.Color.Red;
            this.lblLinkUnallocatedFiles.LinkColor = System.Drawing.Color.Red;
            this.lblLinkUnallocatedFiles.Location = new System.Drawing.Point(899, 294);
            this.lblLinkUnallocatedFiles.Name = "lblLinkUnallocatedFiles";
            this.lblLinkUnallocatedFiles.Size = new System.Drawing.Size(16, 16);
            this.lblLinkUnallocatedFiles.TabIndex = 8;
            this.lblLinkUnallocatedFiles.TabStop = true;
            this.lblLinkUnallocatedFiles.Text = "0";
            this.lblLinkUnallocatedFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkUnallocatedFiles_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstAdminPendingFiles);
            this.groupBox2.Location = new System.Drawing.Point(9, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(958, 135);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Admin Pending Files ";
            // 
            // lstAdminPendingFiles
            // 
            this.lstAdminPendingFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAdminPendingFiles.Location = new System.Drawing.Point(3, 16);
            this.lstAdminPendingFiles.Name = "lstAdminPendingFiles";
            this.lstAdminPendingFiles.Size = new System.Drawing.Size(952, 116);
            this.lstAdminPendingFiles.TabIndex = 0;
            this.lstAdminPendingFiles.UseCompatibleStateImageBehavior = false;
            // 
            // grpbxUrgentEmails
            // 
            this.grpbxUrgentEmails.Controls.Add(this.lstVwUrgentEmails);
            this.grpbxUrgentEmails.Location = new System.Drawing.Point(902, 324);
            this.grpbxUrgentEmails.Name = "grpbxUrgentEmails";
            this.grpbxUrgentEmails.Size = new System.Drawing.Size(958, 135);
            this.grpbxUrgentEmails.TabIndex = 6;
            this.grpbxUrgentEmails.TabStop = false;
            this.grpbxUrgentEmails.Text = "Urgent Pending Emails";
            this.grpbxUrgentEmails.Visible = false;
            // 
            // lstVwUrgentEmails
            // 
            this.lstVwUrgentEmails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVwUrgentEmails.Location = new System.Drawing.Point(3, 16);
            this.lstVwUrgentEmails.Name = "lstVwUrgentEmails";
            this.lstVwUrgentEmails.Size = new System.Drawing.Size(952, 116);
            this.lstVwUrgentEmails.TabIndex = 0;
            this.lstVwUrgentEmails.UseCompatibleStateImageBehavior = false;
            // 
            // grpbxWorkAllocated
            // 
            this.grpbxWorkAllocated.Controls.Add(this.lstWorkAllocated);
            this.grpbxWorkAllocated.Location = new System.Drawing.Point(504, 178);
            this.grpbxWorkAllocated.Name = "grpbxWorkAllocated";
            this.grpbxWorkAllocated.Size = new System.Drawing.Size(392, 132);
            this.grpbxWorkAllocated.TabIndex = 4;
            this.grpbxWorkAllocated.TabStop = false;
            this.grpbxWorkAllocated.Text = "Work Allocation";
            // 
            // lstWorkAllocated
            // 
            this.lstWorkAllocated.FullRowSelect = true;
            this.lstWorkAllocated.Location = new System.Drawing.Point(3, 16);
            this.lstWorkAllocated.MultiSelect = false;
            this.lstWorkAllocated.Name = "lstWorkAllocated";
            this.lstWorkAllocated.Size = new System.Drawing.Size(382, 113);
            this.lstWorkAllocated.TabIndex = 0;
            this.lstWorkAllocated.UseCompatibleStateImageBehavior = false;
            this.lstWorkAllocated.View = System.Windows.Forms.View.Details;
            this.lstWorkAllocated.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstWorkAllocated_MouseClick);
            this.lstWorkAllocated.SelectedIndexChanged += new System.EventHandler(this.lstWorkAllocated_SelectedIndexChanged);
            this.lstWorkAllocated.DoubleClick += new System.EventHandler(this.lstWorkAllocated_DoubleClick);
            this.lstWorkAllocated.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstWorkAllocated_MouseDown);
            // 
            // grpbxPendedFiles
            // 
            this.grpbxPendedFiles.Controls.Add(this.groupBox1);
            this.grpbxPendedFiles.Controls.Add(this.lstPendedCase);
            this.grpbxPendedFiles.Location = new System.Drawing.Point(9, 178);
            this.grpbxPendedFiles.Name = "grpbxPendedFiles";
            this.grpbxPendedFiles.Size = new System.Drawing.Size(489, 132);
            this.grpbxPendedFiles.TabIndex = 3;
            this.grpbxPendedFiles.TabStop = false;
            this.grpbxPendedFiles.Text = "Pended Cases";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 138);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lstPendedCase
            // 
            this.lstPendedCase.FullRowSelect = true;
            this.lstPendedCase.Location = new System.Drawing.Point(3, 16);
            this.lstPendedCase.Name = "lstPendedCase";
            this.lstPendedCase.Size = new System.Drawing.Size(479, 113);
            this.lstPendedCase.TabIndex = 0;
            this.lstPendedCase.UseCompatibleStateImageBehavior = false;
            this.lstPendedCase.View = System.Windows.Forms.View.Details;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::AIMSClient.Properties.Resources.psRefresh1;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(902, 181);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 46);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpbxAllocatedFiles
            // 
            this.grpbxAllocatedFiles.Controls.Add(this.lstAllocatedCases);
            this.grpbxAllocatedFiles.Location = new System.Drawing.Point(6, 6);
            this.grpbxAllocatedFiles.Name = "grpbxAllocatedFiles";
            this.grpbxAllocatedFiles.Size = new System.Drawing.Size(964, 169);
            this.grpbxAllocatedFiles.TabIndex = 1;
            this.grpbxAllocatedFiles.TabStop = false;
            this.grpbxAllocatedFiles.Text = "Allocated Active Cases ";
            // 
            // lstAllocatedCases
            // 
            this.lstAllocatedCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAllocatedCases.FullRowSelect = true;
            this.lstAllocatedCases.Location = new System.Drawing.Point(3, 16);
            this.lstAllocatedCases.MultiSelect = false;
            this.lstAllocatedCases.Name = "lstAllocatedCases";
            this.lstAllocatedCases.Size = new System.Drawing.Size(958, 150);
            this.lstAllocatedCases.TabIndex = 0;
            this.lstAllocatedCases.UseCompatibleStateImageBehavior = false;
            this.lstAllocatedCases.View = System.Windows.Forms.View.Details;
            this.lstAllocatedCases.SelectedIndexChanged += new System.EventHandler(this.lstAllocatedCases_SelectedIndexChanged);
            this.lstAllocatedCases.DoubleClick += new System.EventHandler(this.lstAllocatedCases_DoubleClick);
            // 
            // dashTimer
            // 
            this.dashTimer.Interval = 60000;
            this.dashTimer.Tick += new System.EventHandler(this.dashTimer_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cntxMenuWork
            // 
            this.cntxMenuWork.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCoOrdinatorWorkLoadToolStripMenuItem});
            this.cntxMenuWork.Name = "cntxMenuWork";
            this.cntxMenuWork.Size = new System.Drawing.Size(235, 26);
            // 
            // showCoOrdinatorWorkLoadToolStripMenuItem
            // 
            this.showCoOrdinatorWorkLoadToolStripMenuItem.Name = "showCoOrdinatorWorkLoadToolStripMenuItem";
            this.showCoOrdinatorWorkLoadToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.showCoOrdinatorWorkLoadToolStripMenuItem.Text = "Show Co-Ordinator WorkLoad";
            this.showCoOrdinatorWorkLoadToolStripMenuItem.Click += new System.EventHandler(this.showCoOrdinatorWorkLoadToolStripMenuItem_Click);
            // 
            // frmAIMSDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 510);
            this.Controls.Add(this.tabDashboards);
            this.Name = "frmAIMSDashboard";
            this.Text = "frmAIMSDashboard";
            this.Load += new System.EventHandler(this.frmAIMSDashboard_Load);
            this.Resize += new System.EventHandler(this.frmAIMSDashboard_Resize);
            this.tabDashboards.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineSep)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grpbxUrgentEmails.ResumeLayout(false);
            this.grpbxWorkAllocated.ResumeLayout(false);
            this.grpbxPendedFiles.ResumeLayout(false);
            this.grpbxAllocatedFiles.ResumeLayout(false);
            this.cntxMenuWork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDashboards;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpbxAllocatedFiles;
        private System.Windows.Forms.ListView lstAllocatedCases;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpbxPendedFiles;
        private System.Windows.Forms.ListView lstPendedCase;
        private System.Windows.Forms.GroupBox grpbxWorkAllocated;
        private System.Windows.Forms.ListView lstWorkAllocated;
        private System.Windows.Forms.Timer dashTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpbxUrgentEmails;
        private System.Windows.Forms.ListView lstVwUrgentEmails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstAdminPendingFiles;
        private System.Windows.Forms.LinkLabel lblLinkUnallocatedFiles;
        private System.Windows.Forms.Label lblUnallocateFiles;
        private System.Windows.Forms.ContextMenuStrip cntxMenuWork;
        private System.Windows.Forms.ToolStripMenuItem showCoOrdinatorWorkLoadToolStripMenuItem;
        private System.Windows.Forms.Label lblAllWorkbaskets;
        private System.Windows.Forms.LinkLabel lblLinkAllWorkbaskets;
        private System.Windows.Forms.PictureBox lineSep;
    }
}