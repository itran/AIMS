namespace AIMSClient
{
    partial class frmAIMSDashboardAdmin
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
            this.grpbxLeighAnne = new System.Windows.Forms.GroupBox();
            this.lstLeighAnnAllocatedCases = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpbxMbali = new System.Windows.Forms.GroupBox();
            this.lstMbaliAllocatedCases = new System.Windows.Forms.ListView();
            this.grpbxMardia = new System.Windows.Forms.GroupBox();
            this.lstMardiaAllocatedCases = new System.Windows.Forms.ListView();
            this.grpbxCharlaine = new System.Windows.Forms.GroupBox();
            this.lstCharlaineAllocatedCases = new System.Windows.Forms.ListView();
            this.grpbxNokuthula = new System.Windows.Forms.GroupBox();
            this.lstNokuthulaAllocatedCases = new System.Windows.Forms.ListView();
            this.grpbxClosedCouried = new System.Windows.Forms.GroupBox();
            this.lstFilesClosed = new System.Windows.Forms.ListView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lstWorkAllocated = new System.Windows.Forms.ListView();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.lblAllWorkbaskets = new System.Windows.Forms.Label();
            this.lblLinkAllWorkbaskets = new System.Windows.Forms.LinkLabel();
            this.lblUnallocateFiles = new System.Windows.Forms.Label();
            this.lblLinkUnallocatedFiles = new System.Windows.Forms.LinkLabel();
            this.grpbCarmelle = new System.Windows.Forms.GroupBox();
            this.lstCarmelleAllocatedCases = new System.Windows.Forms.ListView();
            this.cntxMenuWork = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showCoOrdinatorWorkLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpbxLeighAnne.SuspendLayout();
            this.grpbxMbali.SuspendLayout();
            this.grpbxMardia.SuspendLayout();
            this.grpbxCharlaine.SuspendLayout();
            this.grpbxNokuthula.SuspendLayout();
            this.grpbxClosedCouried.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.grpbCarmelle.SuspendLayout();
            this.cntxMenuWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxLeighAnne
            // 
            this.grpbxLeighAnne.Controls.Add(this.lstLeighAnnAllocatedCases);
            this.grpbxLeighAnne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxLeighAnne.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbxLeighAnne.Location = new System.Drawing.Point(2, 4);
            this.grpbxLeighAnne.Name = "grpbxLeighAnne";
            this.grpbxLeighAnne.Size = new System.Drawing.Size(217, 408);
            this.grpbxLeighAnne.TabIndex = 2;
            this.grpbxLeighAnne.TabStop = false;
            this.grpbxLeighAnne.Text = "Leigh-Anne";
            this.grpbxLeighAnne.Enter += new System.EventHandler(this.grpbxAllocatedFiles_Enter);
            // 
            // lstLeighAnnAllocatedCases
            // 
            this.lstLeighAnnAllocatedCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLeighAnnAllocatedCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLeighAnnAllocatedCases.FullRowSelect = true;
            this.lstLeighAnnAllocatedCases.Location = new System.Drawing.Point(3, 18);
            this.lstLeighAnnAllocatedCases.MultiSelect = false;
            this.lstLeighAnnAllocatedCases.Name = "lstLeighAnnAllocatedCases";
            this.lstLeighAnnAllocatedCases.Size = new System.Drawing.Size(211, 387);
            this.lstLeighAnnAllocatedCases.TabIndex = 0;
            this.lstLeighAnnAllocatedCases.UseCompatibleStateImageBehavior = false;
            this.lstLeighAnnAllocatedCases.View = System.Windows.Forms.View.Details;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::AIMSClient.Properties.Resources.psRefresh1;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(1157, 539);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 46);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpbxMbali
            // 
            this.grpbxMbali.Controls.Add(this.lstMbaliAllocatedCases);
            this.grpbxMbali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxMbali.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbxMbali.Location = new System.Drawing.Point(225, 4);
            this.grpbxMbali.Name = "grpbxMbali";
            this.grpbxMbali.Size = new System.Drawing.Size(217, 408);
            this.grpbxMbali.TabIndex = 4;
            this.grpbxMbali.TabStop = false;
            this.grpbxMbali.Text = "Mbali";
            this.grpbxMbali.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lstMbaliAllocatedCases
            // 
            this.lstMbaliAllocatedCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMbaliAllocatedCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMbaliAllocatedCases.FullRowSelect = true;
            this.lstMbaliAllocatedCases.Location = new System.Drawing.Point(3, 18);
            this.lstMbaliAllocatedCases.MultiSelect = false;
            this.lstMbaliAllocatedCases.Name = "lstMbaliAllocatedCases";
            this.lstMbaliAllocatedCases.Size = new System.Drawing.Size(211, 387);
            this.lstMbaliAllocatedCases.TabIndex = 0;
            this.lstMbaliAllocatedCases.UseCompatibleStateImageBehavior = false;
            this.lstMbaliAllocatedCases.View = System.Windows.Forms.View.Details;
            this.lstMbaliAllocatedCases.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // grpbxMardia
            // 
            this.grpbxMardia.Controls.Add(this.lstMardiaAllocatedCases);
            this.grpbxMardia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxMardia.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbxMardia.Location = new System.Drawing.Point(445, 4);
            this.grpbxMardia.Name = "grpbxMardia";
            this.grpbxMardia.Size = new System.Drawing.Size(217, 408);
            this.grpbxMardia.TabIndex = 5;
            this.grpbxMardia.TabStop = false;
            this.grpbxMardia.Text = "Mardia";
            // 
            // lstMardiaAllocatedCases
            // 
            this.lstMardiaAllocatedCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMardiaAllocatedCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMardiaAllocatedCases.FullRowSelect = true;
            this.lstMardiaAllocatedCases.Location = new System.Drawing.Point(3, 18);
            this.lstMardiaAllocatedCases.MultiSelect = false;
            this.lstMardiaAllocatedCases.Name = "lstMardiaAllocatedCases";
            this.lstMardiaAllocatedCases.Size = new System.Drawing.Size(211, 387);
            this.lstMardiaAllocatedCases.TabIndex = 0;
            this.lstMardiaAllocatedCases.UseCompatibleStateImageBehavior = false;
            this.lstMardiaAllocatedCases.View = System.Windows.Forms.View.Details;
            // 
            // grpbxCharlaine
            // 
            this.grpbxCharlaine.Controls.Add(this.lstCharlaineAllocatedCases);
            this.grpbxCharlaine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxCharlaine.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbxCharlaine.Location = new System.Drawing.Point(668, 4);
            this.grpbxCharlaine.Name = "grpbxCharlaine";
            this.grpbxCharlaine.Size = new System.Drawing.Size(217, 408);
            this.grpbxCharlaine.TabIndex = 6;
            this.grpbxCharlaine.TabStop = false;
            this.grpbxCharlaine.Text = "Jessica";
            // 
            // lstCharlaineAllocatedCases
            // 
            this.lstCharlaineAllocatedCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCharlaineAllocatedCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCharlaineAllocatedCases.FullRowSelect = true;
            this.lstCharlaineAllocatedCases.Location = new System.Drawing.Point(3, 18);
            this.lstCharlaineAllocatedCases.MultiSelect = false;
            this.lstCharlaineAllocatedCases.Name = "lstCharlaineAllocatedCases";
            this.lstCharlaineAllocatedCases.Size = new System.Drawing.Size(211, 387);
            this.lstCharlaineAllocatedCases.TabIndex = 0;
            this.lstCharlaineAllocatedCases.UseCompatibleStateImageBehavior = false;
            this.lstCharlaineAllocatedCases.View = System.Windows.Forms.View.Details;
            // 
            // grpbxNokuthula
            // 
            this.grpbxNokuthula.Controls.Add(this.lstNokuthulaAllocatedCases);
            this.grpbxNokuthula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxNokuthula.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbxNokuthula.Location = new System.Drawing.Point(891, 4);
            this.grpbxNokuthula.Name = "grpbxNokuthula";
            this.grpbxNokuthula.Size = new System.Drawing.Size(217, 408);
            this.grpbxNokuthula.TabIndex = 7;
            this.grpbxNokuthula.TabStop = false;
            this.grpbxNokuthula.Text = "Nokuthula";
            this.grpbxNokuthula.Visible = false;
            // 
            // lstNokuthulaAllocatedCases
            // 
            this.lstNokuthulaAllocatedCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNokuthulaAllocatedCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstNokuthulaAllocatedCases.FullRowSelect = true;
            this.lstNokuthulaAllocatedCases.Location = new System.Drawing.Point(3, 18);
            this.lstNokuthulaAllocatedCases.MultiSelect = false;
            this.lstNokuthulaAllocatedCases.Name = "lstNokuthulaAllocatedCases";
            this.lstNokuthulaAllocatedCases.Size = new System.Drawing.Size(211, 387);
            this.lstNokuthulaAllocatedCases.TabIndex = 0;
            this.lstNokuthulaAllocatedCases.UseCompatibleStateImageBehavior = false;
            this.lstNokuthulaAllocatedCases.View = System.Windows.Forms.View.Details;
            // 
            // grpbxClosedCouried
            // 
            this.grpbxClosedCouried.Controls.Add(this.lstFilesClosed);
            this.grpbxClosedCouried.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxClosedCouried.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbxClosedCouried.Location = new System.Drawing.Point(5, 418);
            this.grpbxClosedCouried.Name = "grpbxClosedCouried";
            this.grpbxClosedCouried.Size = new System.Drawing.Size(437, 181);
            this.grpbxClosedCouried.TabIndex = 8;
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
            this.lstFilesClosed.Size = new System.Drawing.Size(431, 160);
            this.lstFilesClosed.TabIndex = 0;
            this.lstFilesClosed.UseCompatibleStateImageBehavior = false;
            this.lstFilesClosed.View = System.Windows.Forms.View.Details;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lstWorkAllocated);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.CadetBlue;
            this.groupBox6.Location = new System.Drawing.Point(445, 418);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(663, 181);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Total Files Assigned";
            // 
            // lstWorkAllocated
            // 
            this.lstWorkAllocated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWorkAllocated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWorkAllocated.FullRowSelect = true;
            this.lstWorkAllocated.Location = new System.Drawing.Point(3, 18);
            this.lstWorkAllocated.MultiSelect = false;
            this.lstWorkAllocated.Name = "lstWorkAllocated";
            this.lstWorkAllocated.Size = new System.Drawing.Size(657, 160);
            this.lstWorkAllocated.TabIndex = 0;
            this.lstWorkAllocated.UseCompatibleStateImageBehavior = false;
            this.lstWorkAllocated.View = System.Windows.Forms.View.Details;
            this.lstWorkAllocated.SelectedIndexChanged += new System.EventHandler(this.lstWorkAllocated_SelectedIndexChanged);
            this.lstWorkAllocated.DoubleClick += new System.EventHandler(this.lstWorkAllocated_DoubleClick);
            this.lstWorkAllocated.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstWorkAllocated_MouseDown);
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.ForeColor = System.Drawing.Color.Green;
            this.lblCountDown.Location = new System.Drawing.Point(1180, 603);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(54, 20);
            this.lblCountDown.TabIndex = 10;
            this.lblCountDown.Text = "00:00";
            // 
            // lblAllWorkbaskets
            // 
            this.lblAllWorkbaskets.AutoSize = true;
            this.lblAllWorkbaskets.Location = new System.Drawing.Point(1166, 485);
            this.lblAllWorkbaskets.Name = "lblAllWorkbaskets";
            this.lblAllWorkbaskets.Size = new System.Drawing.Size(84, 13);
            this.lblAllWorkbaskets.TabIndex = 16;
            this.lblAllWorkbaskets.Text = "All Workbaskets";
            // 
            // lblLinkAllWorkbaskets
            // 
            this.lblLinkAllWorkbaskets.AutoSize = true;
            this.lblLinkAllWorkbaskets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkAllWorkbaskets.ForeColor = System.Drawing.Color.Red;
            this.lblLinkAllWorkbaskets.LinkColor = System.Drawing.Color.Red;
            this.lblLinkAllWorkbaskets.Location = new System.Drawing.Point(1192, 502);
            this.lblLinkAllWorkbaskets.Name = "lblLinkAllWorkbaskets";
            this.lblLinkAllWorkbaskets.Size = new System.Drawing.Size(25, 25);
            this.lblLinkAllWorkbaskets.TabIndex = 15;
            this.lblLinkAllWorkbaskets.TabStop = true;
            this.lblLinkAllWorkbaskets.Text = "0";
            this.lblLinkAllWorkbaskets.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkAllWorkbaskets_LinkClicked);
            // 
            // lblUnallocateFiles
            // 
            this.lblUnallocateFiles.AutoSize = true;
            this.lblUnallocateFiles.Location = new System.Drawing.Point(1142, 436);
            this.lblUnallocateFiles.Name = "lblUnallocateFiles";
            this.lblUnallocateFiles.Size = new System.Drawing.Size(140, 13);
            this.lblUnallocateFiles.TabIndex = 14;
            this.lblUnallocateFiles.Text = "Number of Unallocated Files";
            // 
            // lblLinkUnallocatedFiles
            // 
            this.lblLinkUnallocatedFiles.AutoSize = true;
            this.lblLinkUnallocatedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkUnallocatedFiles.ForeColor = System.Drawing.Color.Red;
            this.lblLinkUnallocatedFiles.LinkColor = System.Drawing.Color.Red;
            this.lblLinkUnallocatedFiles.Location = new System.Drawing.Point(1192, 449);
            this.lblLinkUnallocatedFiles.Name = "lblLinkUnallocatedFiles";
            this.lblLinkUnallocatedFiles.Size = new System.Drawing.Size(25, 25);
            this.lblLinkUnallocatedFiles.TabIndex = 13;
            this.lblLinkUnallocatedFiles.TabStop = true;
            this.lblLinkUnallocatedFiles.Text = "0";
            this.lblLinkUnallocatedFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkUnallocatedFiles_LinkClicked);
            // 
            // grpbCarmelle
            // 
            this.grpbCarmelle.Controls.Add(this.lstCarmelleAllocatedCases);
            this.grpbCarmelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbCarmelle.ForeColor = System.Drawing.Color.CadetBlue;
            this.grpbCarmelle.Location = new System.Drawing.Point(1114, 4);
            this.grpbCarmelle.Name = "grpbCarmelle";
            this.grpbCarmelle.Size = new System.Drawing.Size(217, 408);
            this.grpbCarmelle.TabIndex = 17;
            this.grpbCarmelle.TabStop = false;
            this.grpbCarmelle.Text = "Carmelle";
            this.grpbCarmelle.Visible = false;
            // 
            // lstCarmelleAllocatedCases
            // 
            this.lstCarmelleAllocatedCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCarmelleAllocatedCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCarmelleAllocatedCases.FullRowSelect = true;
            this.lstCarmelleAllocatedCases.Location = new System.Drawing.Point(3, 18);
            this.lstCarmelleAllocatedCases.MultiSelect = false;
            this.lstCarmelleAllocatedCases.Name = "lstCarmelleAllocatedCases";
            this.lstCarmelleAllocatedCases.Size = new System.Drawing.Size(211, 387);
            this.lstCarmelleAllocatedCases.TabIndex = 0;
            this.lstCarmelleAllocatedCases.UseCompatibleStateImageBehavior = false;
            this.lstCarmelleAllocatedCases.View = System.Windows.Forms.View.Details;
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
            // frmAIMSDashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 632);
            this.Controls.Add(this.grpbCarmelle);
            this.Controls.Add(this.lblAllWorkbaskets);
            this.Controls.Add(this.lblLinkAllWorkbaskets);
            this.Controls.Add(this.lblUnallocateFiles);
            this.Controls.Add(this.lblLinkUnallocatedFiles);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.grpbxClosedCouried);
            this.Controls.Add(this.grpbxNokuthula);
            this.Controls.Add(this.grpbxCharlaine);
            this.Controls.Add(this.grpbxMardia);
            this.Controls.Add(this.grpbxMbali);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpbxLeighAnne);
            this.Name = "frmAIMSDashboardAdmin";
            this.Text = "frmAIMSDashboardAdmin";
            this.Load += new System.EventHandler(this.frmAIMSDashboardAdmin_Load);
            this.grpbxLeighAnne.ResumeLayout(false);
            this.grpbxMbali.ResumeLayout(false);
            this.grpbxMardia.ResumeLayout(false);
            this.grpbxCharlaine.ResumeLayout(false);
            this.grpbxNokuthula.ResumeLayout(false);
            this.grpbxClosedCouried.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.grpbCarmelle.ResumeLayout(false);
            this.cntxMenuWork.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxLeighAnne;
        private System.Windows.Forms.ListView lstLeighAnnAllocatedCases;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpbxMbali;
        private System.Windows.Forms.ListView lstMbaliAllocatedCases;
        private System.Windows.Forms.GroupBox grpbxMardia;
        private System.Windows.Forms.ListView lstMardiaAllocatedCases;
        private System.Windows.Forms.GroupBox grpbxCharlaine;
        private System.Windows.Forms.ListView lstCharlaineAllocatedCases;
        private System.Windows.Forms.GroupBox grpbxNokuthula;
        private System.Windows.Forms.ListView lstNokuthulaAllocatedCases;
        private System.Windows.Forms.GroupBox grpbxClosedCouried;
        private System.Windows.Forms.ListView lstFilesClosed;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView lstWorkAllocated;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Label lblAllWorkbaskets;
        private System.Windows.Forms.LinkLabel lblLinkAllWorkbaskets;
        private System.Windows.Forms.Label lblUnallocateFiles;
        private System.Windows.Forms.LinkLabel lblLinkUnallocatedFiles;
        private System.Windows.Forms.GroupBox grpbCarmelle;
        private System.Windows.Forms.ListView lstCarmelleAllocatedCases;
        private System.Windows.Forms.ContextMenuStrip cntxMenuWork;
        private System.Windows.Forms.ToolStripMenuItem showCoOrdinatorWorkLoadToolStripMenuItem;
        private System.Windows.Forms.Timer dashTimer;
        private System.Windows.Forms.Timer timer1;
    }
}