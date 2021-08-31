namespace AIMSClient
{
    partial class frmOPSDashboard
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cntxMenuWork = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showCoOrdinatorWorkLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAllWorkbaskets = new System.Windows.Forms.Label();
            this.lblLinkAllWorkbaskets = new System.Windows.Forms.LinkLabel();
            this.lblUnallocateFiles = new System.Windows.Forms.Label();
            this.lblLinkUnallocatedFiles = new System.Windows.Forms.LinkLabel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lineSep = new System.Windows.Forms.PictureBox();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dashTimer = new System.Windows.Forms.Timer(this.components);
            this.cntxMenuWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineSep)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1199, 364);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 137);
            this.panel2.TabIndex = 1;
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
            // lblAllWorkbaskets
            // 
            this.lblAllWorkbaskets.AutoSize = true;
            this.lblAllWorkbaskets.Location = new System.Drawing.Point(595, 9);
            this.lblAllWorkbaskets.Name = "lblAllWorkbaskets";
            this.lblAllWorkbaskets.Size = new System.Drawing.Size(84, 13);
            this.lblAllWorkbaskets.TabIndex = 27;
            this.lblAllWorkbaskets.Text = "All Workbaskets";
            // 
            // lblLinkAllWorkbaskets
            // 
            this.lblLinkAllWorkbaskets.AutoSize = true;
            this.lblLinkAllWorkbaskets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkAllWorkbaskets.ForeColor = System.Drawing.Color.Red;
            this.lblLinkAllWorkbaskets.LinkColor = System.Drawing.Color.Red;
            this.lblLinkAllWorkbaskets.Location = new System.Drawing.Point(685, 9);
            this.lblLinkAllWorkbaskets.Name = "lblLinkAllWorkbaskets";
            this.lblLinkAllWorkbaskets.Size = new System.Drawing.Size(16, 16);
            this.lblLinkAllWorkbaskets.TabIndex = 26;
            this.lblLinkAllWorkbaskets.TabStop = true;
            this.lblLinkAllWorkbaskets.Text = "0";
            this.lblLinkAllWorkbaskets.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkAllWorkbaskets_LinkClicked_1);
            // 
            // lblUnallocateFiles
            // 
            this.lblUnallocateFiles.AutoSize = true;
            this.lblUnallocateFiles.Location = new System.Drawing.Point(707, 9);
            this.lblUnallocateFiles.Name = "lblUnallocateFiles";
            this.lblUnallocateFiles.Size = new System.Drawing.Size(140, 13);
            this.lblUnallocateFiles.TabIndex = 25;
            this.lblUnallocateFiles.Text = "Number of Unallocated Files";
            // 
            // lblLinkUnallocatedFiles
            // 
            this.lblLinkUnallocatedFiles.AutoSize = true;
            this.lblLinkUnallocatedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkUnallocatedFiles.ForeColor = System.Drawing.Color.Red;
            this.lblLinkUnallocatedFiles.LinkColor = System.Drawing.Color.Red;
            this.lblLinkUnallocatedFiles.Location = new System.Drawing.Point(853, 9);
            this.lblLinkUnallocatedFiles.Name = "lblLinkUnallocatedFiles";
            this.lblLinkUnallocatedFiles.Size = new System.Drawing.Size(16, 16);
            this.lblLinkUnallocatedFiles.TabIndex = 24;
            this.lblLinkUnallocatedFiles.TabStop = true;
            this.lblLinkUnallocatedFiles.Text = "0";
            this.lblLinkUnallocatedFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkUnallocatedFiles_LinkClicked_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::AIMSClient.Properties.Resources.psRefresh1;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(598, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 46);
            this.btnRefresh.TabIndex = 23;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // lineSep
            // 
            this.lineSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineSep.Location = new System.Drawing.Point(707, 25);
            this.lineSep.Name = "lineSep";
            this.lineSep.Size = new System.Drawing.Size(5, 30);
            this.lineSep.TabIndex = 28;
            this.lineSep.TabStop = false;
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.ForeColor = System.Drawing.Color.Green;
            this.lblCountDown.Location = new System.Drawing.Point(594, 120);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(54, 20);
            this.lblCountDown.TabIndex = 29;
            this.lblCountDown.Text = "00:00";
            this.lblCountDown.Click += new System.EventHandler(this.lblCountDown_Click);
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
            // frmOPSDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 510);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.lineSep);
            this.Controls.Add(this.lblAllWorkbaskets);
            this.Controls.Add(this.lblLinkAllWorkbaskets);
            this.Controls.Add(this.lblUnallocateFiles);
            this.Controls.Add(this.lblLinkUnallocatedFiles);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmOPSDashboard";
            this.Text = "S";
            this.Load += new System.EventHandler(this.frmOPSDashboard_Load);
            this.Resize += new System.EventHandler(this.frmOPSDashboard_Resize);
            this.cntxMenuWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lineSep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cntxMenuWork;
        private System.Windows.Forms.ToolStripMenuItem showCoOrdinatorWorkLoadToolStripMenuItem;
        private System.Windows.Forms.Label lblAllWorkbaskets;
        private System.Windows.Forms.LinkLabel lblLinkAllWorkbaskets;
        private System.Windows.Forms.Label lblUnallocateFiles;
        private System.Windows.Forms.LinkLabel lblLinkUnallocatedFiles;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox lineSep;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer dashTimer;
    }
}