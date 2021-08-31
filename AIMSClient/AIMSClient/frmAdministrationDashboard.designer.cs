namespace AIMSClient
{
    partial class frmAdministrationDashboard
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
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cntxMenuWork = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showCoOrdinatorWorkLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dashTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpbxAssignedFiles = new System.Windows.Forms.GroupBox();
            this.lstWorkAllocated = new System.Windows.Forms.ListView();
            this.grpbxClosedCouried = new System.Windows.Forms.GroupBox();
            this.lstFilesClosed = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblUnallocateFiles = new System.Windows.Forms.Label();
            this.lblAllWorkbaskets = new System.Windows.Forms.Label();
            this.lineSep = new System.Windows.Forms.PictureBox();
            this.lblLinkAllWorkbaskets = new System.Windows.Forms.LinkLabel();
            this.lblLinkUnallocatedFiles = new System.Windows.Forms.LinkLabel();
            this.cntxMenuWork.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpbxAssignedFiles.SuspendLayout();
            this.grpbxClosedCouried.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineSep)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(2, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 260);
            this.panel1.TabIndex = 0;
            // 
            // cntxMenuWork
            // 
            this.cntxMenuWork.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCoOrdinatorWorkLoadToolStripMenuItem});
            this.cntxMenuWork.Name = "cntxMenuWork";
            this.cntxMenuWork.Size = new System.Drawing.Size(237, 26);
            this.cntxMenuWork.Opening += new System.ComponentModel.CancelEventHandler(this.cntxMenuWork_Opening);
            // 
            // showCoOrdinatorWorkLoadToolStripMenuItem
            // 
            this.showCoOrdinatorWorkLoadToolStripMenuItem.Name = "showCoOrdinatorWorkLoadToolStripMenuItem";
            this.showCoOrdinatorWorkLoadToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.showCoOrdinatorWorkLoadToolStripMenuItem.Text = "Show Administrator WorkLoad";
            this.showCoOrdinatorWorkLoadToolStripMenuItem.Click += new System.EventHandler(this.showCoOrdinatorWorkLoadToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dashTimer
            // 
            this.dashTimer.Interval = 300000;
            this.dashTimer.Tick += new System.EventHandler(this.dashTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblCountDown);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.lblUnallocateFiles);
            this.panel2.Controls.Add(this.lblAllWorkbaskets);
            this.panel2.Controls.Add(this.lineSep);
            this.panel2.Controls.Add(this.lblLinkAllWorkbaskets);
            this.panel2.Controls.Add(this.lblLinkUnallocatedFiles);
            this.panel2.Location = new System.Drawing.Point(2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1211, 233);
            this.panel2.TabIndex = 30;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.ForeColor = System.Drawing.Color.Green;
            this.lblCountDown.Location = new System.Drawing.Point(1148, 159);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(54, 20);
            this.lblCountDown.TabIndex = 36;
            this.lblCountDown.Text = "00:00";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grpbxAssignedFiles);
            this.panel3.Controls.Add(this.grpbxClosedCouried);
            this.panel3.Location = new System.Drawing.Point(9, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(893, 190);
            this.panel3.TabIndex = 35;
            // 
            // grpbxAssignedFiles
            // 
            this.grpbxAssignedFiles.Controls.Add(this.lstWorkAllocated);
            this.grpbxAssignedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxAssignedFiles.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbxAssignedFiles.Location = new System.Drawing.Point(481, 3);
            this.grpbxAssignedFiles.Name = "grpbxAssignedFiles";
            this.grpbxAssignedFiles.Size = new System.Drawing.Size(395, 181);
            this.grpbxAssignedFiles.TabIndex = 11;
            this.grpbxAssignedFiles.TabStop = false;
            this.grpbxAssignedFiles.Text = "Total Files Assigned";
            this.grpbxAssignedFiles.Visible = false;
            // 
            // lstWorkAllocated
            // 
            this.lstWorkAllocated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWorkAllocated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWorkAllocated.FullRowSelect = true;
            this.lstWorkAllocated.Location = new System.Drawing.Point(3, 18);
            this.lstWorkAllocated.MultiSelect = false;
            this.lstWorkAllocated.Name = "lstWorkAllocated";
            this.lstWorkAllocated.Size = new System.Drawing.Size(389, 160);
            this.lstWorkAllocated.TabIndex = 0;
            this.lstWorkAllocated.UseCompatibleStateImageBehavior = false;
            this.lstWorkAllocated.View = System.Windows.Forms.View.Details;
            this.lstWorkAllocated.SelectedIndexChanged += new System.EventHandler(this.lstWorkAllocated_SelectedIndexChanged);
            this.lstWorkAllocated.DoubleClick += new System.EventHandler(this.lstWorkAllocated_DoubleClick);
            this.lstWorkAllocated.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstWorkAllocated_MouseDown);
            // 
            // grpbxClosedCouried
            // 
            this.grpbxClosedCouried.Controls.Add(this.lstFilesClosed);
            this.grpbxClosedCouried.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxClosedCouried.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbxClosedCouried.Location = new System.Drawing.Point(6, 3);
            this.grpbxClosedCouried.Name = "grpbxClosedCouried";
            this.grpbxClosedCouried.Size = new System.Drawing.Size(887, 181);
            this.grpbxClosedCouried.TabIndex = 10;
            this.grpbxClosedCouried.TabStop = false;
            this.grpbxClosedCouried.Text = "Files Closed and Not Couriered";
            // 
            // lstFilesClosed
            // 
            this.lstFilesClosed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFilesClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFilesClosed.FullRowSelect = true;
            this.lstFilesClosed.Location = new System.Drawing.Point(3, 18);
            this.lstFilesClosed.MultiSelect = false;
            this.lstFilesClosed.Name = "lstFilesClosed";
            this.lstFilesClosed.Size = new System.Drawing.Size(881, 160);
            this.lstFilesClosed.TabIndex = 0;
            this.lstFilesClosed.UseCompatibleStateImageBehavior = false;
            this.lstFilesClosed.View = System.Windows.Forms.View.Details;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::AIMSClient.Properties.Resources.psRefresh1;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(1141, 182);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 46);
            this.btnRefresh.TabIndex = 34;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_2);
            // 
            // lblUnallocateFiles
            // 
            this.lblUnallocateFiles.AutoSize = true;
            this.lblUnallocateFiles.Location = new System.Drawing.Point(1049, 10);
            this.lblUnallocateFiles.Name = "lblUnallocateFiles";
            this.lblUnallocateFiles.Size = new System.Drawing.Size(140, 13);
            this.lblUnallocateFiles.TabIndex = 30;
            this.lblUnallocateFiles.Text = "Number of Unallocated Files";
            // 
            // lblAllWorkbaskets
            // 
            this.lblAllWorkbaskets.AutoSize = true;
            this.lblAllWorkbaskets.Location = new System.Drawing.Point(927, 10);
            this.lblAllWorkbaskets.Name = "lblAllWorkbaskets";
            this.lblAllWorkbaskets.Size = new System.Drawing.Size(84, 13);
            this.lblAllWorkbaskets.TabIndex = 32;
            this.lblAllWorkbaskets.Text = "All Workbaskets";
            // 
            // lineSep
            // 
            this.lineSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineSep.Location = new System.Drawing.Point(1210, 23);
            this.lineSep.Name = "lineSep";
            this.lineSep.Size = new System.Drawing.Size(5, 30);
            this.lineSep.TabIndex = 33;
            this.lineSep.TabStop = false;
            this.lineSep.Visible = false;
            // 
            // lblLinkAllWorkbaskets
            // 
            this.lblLinkAllWorkbaskets.AutoSize = true;
            this.lblLinkAllWorkbaskets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkAllWorkbaskets.ForeColor = System.Drawing.Color.Red;
            this.lblLinkAllWorkbaskets.LinkColor = System.Drawing.Color.Red;
            this.lblLinkAllWorkbaskets.Location = new System.Drawing.Point(961, 28);
            this.lblLinkAllWorkbaskets.Name = "lblLinkAllWorkbaskets";
            this.lblLinkAllWorkbaskets.Size = new System.Drawing.Size(16, 16);
            this.lblLinkAllWorkbaskets.TabIndex = 31;
            this.lblLinkAllWorkbaskets.TabStop = true;
            this.lblLinkAllWorkbaskets.Text = "0";
            this.lblLinkAllWorkbaskets.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkAllWorkbaskets_LinkClicked_1);
            // 
            // lblLinkUnallocatedFiles
            // 
            this.lblLinkUnallocatedFiles.AutoSize = true;
            this.lblLinkUnallocatedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkUnallocatedFiles.ForeColor = System.Drawing.Color.Red;
            this.lblLinkUnallocatedFiles.LinkColor = System.Drawing.Color.Red;
            this.lblLinkUnallocatedFiles.Location = new System.Drawing.Point(1108, 28);
            this.lblLinkUnallocatedFiles.Name = "lblLinkUnallocatedFiles";
            this.lblLinkUnallocatedFiles.Size = new System.Drawing.Size(16, 16);
            this.lblLinkUnallocatedFiles.TabIndex = 29;
            this.lblLinkUnallocatedFiles.TabStop = true;
            this.lblLinkUnallocatedFiles.Text = "0";
            this.lblLinkUnallocatedFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkUnallocatedFiles_LinkClicked_2);
            // 
            // frmAdministrationDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 510);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdministrationDashboard";
            this.Text = "S";
            this.Load += new System.EventHandler(this.frmAdministrationDashboard_Load);
            this.Resize += new System.EventHandler(this.frmAdministrationDashboard_Resize);
            this.cntxMenuWork.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.grpbxAssignedFiles.ResumeLayout(false);
            this.grpbxClosedCouried.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lineSep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.ContextMenuStrip cntxMenuWork;
        private System.Windows.Forms.ToolStripMenuItem showCoOrdinatorWorkLoadToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer dashTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblUnallocateFiles;
        private System.Windows.Forms.Label lblAllWorkbaskets;
        private System.Windows.Forms.PictureBox lineSep;
        private System.Windows.Forms.LinkLabel lblLinkAllWorkbaskets;
        private System.Windows.Forms.LinkLabel lblLinkUnallocatedFiles;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grpbxAssignedFiles;
        private System.Windows.Forms.ListView lstWorkAllocated;
        private System.Windows.Forms.GroupBox grpbxClosedCouried;
        private System.Windows.Forms.ListView lstFilesClosed;
        private System.Windows.Forms.Label lblCountDown;
    }
}