namespace AIMSClient
{
    partial class frmWorkBasketAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkBasketAdmin));
            this.gpbxOperatorMails = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabWorkbasketLoad = new System.Windows.Forms.TabPage();
            this.lstOperatorMailBox = new System.Windows.Forms.ListView();
            this.tabWorkbasketAudit = new System.Windows.Forms.TabPage();
            this.lstWorkbasketAudit = new System.Windows.Forms.ListView();
            this.btnWorkBasketView = new System.Windows.Forms.Button();
            this.btnMailsRefresh = new System.Windows.Forms.Button();
            this.btnWorkClose = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.gpbxOperatorMails.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabWorkbasketLoad.SuspendLayout();
            this.tabWorkbasketAudit.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbxOperatorMails
            // 
            this.gpbxOperatorMails.Controls.Add(this.tabControl1);
            this.gpbxOperatorMails.Controls.Add(this.btnWorkBasketView);
            this.gpbxOperatorMails.Controls.Add(this.btnMailsRefresh);
            this.gpbxOperatorMails.Controls.Add(this.btnWorkClose);
            this.gpbxOperatorMails.Location = new System.Drawing.Point(12, 12);
            this.gpbxOperatorMails.Name = "gpbxOperatorMails";
            this.gpbxOperatorMails.Size = new System.Drawing.Size(1262, 571);
            this.gpbxOperatorMails.TabIndex = 5;
            this.gpbxOperatorMails.TabStop = false;
            this.gpbxOperatorMails.Text = "The Bin";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabWorkbasketLoad);
            this.tabControl1.Controls.Add(this.tabWorkbasketAudit);
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1179, 549);
            this.tabControl1.TabIndex = 8;
            // 
            // tabWorkbasketLoad
            // 
            this.tabWorkbasketLoad.Controls.Add(this.lstOperatorMailBox);
            this.tabWorkbasketLoad.Location = new System.Drawing.Point(4, 22);
            this.tabWorkbasketLoad.Name = "tabWorkbasketLoad";
            this.tabWorkbasketLoad.Padding = new System.Windows.Forms.Padding(3);
            this.tabWorkbasketLoad.Size = new System.Drawing.Size(1171, 523);
            this.tabWorkbasketLoad.TabIndex = 0;
            this.tabWorkbasketLoad.Text = "Work Load";
            this.tabWorkbasketLoad.UseVisualStyleBackColor = true;
            // 
            // lstOperatorMailBox
            // 
            this.lstOperatorMailBox.CheckBoxes = true;
            this.lstOperatorMailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOperatorMailBox.FullRowSelect = true;
            this.lstOperatorMailBox.HideSelection = false;
            this.lstOperatorMailBox.Location = new System.Drawing.Point(3, 3);
            this.lstOperatorMailBox.MultiSelect = false;
            this.lstOperatorMailBox.Name = "lstOperatorMailBox";
            this.lstOperatorMailBox.Size = new System.Drawing.Size(1165, 517);
            this.lstOperatorMailBox.TabIndex = 4;
            this.lstOperatorMailBox.UseCompatibleStateImageBehavior = false;
            this.lstOperatorMailBox.View = System.Windows.Forms.View.Details;
            // 
            // tabWorkbasketAudit
            // 
            this.tabWorkbasketAudit.Controls.Add(this.lstWorkbasketAudit);
            this.tabWorkbasketAudit.Location = new System.Drawing.Point(4, 22);
            this.tabWorkbasketAudit.Name = "tabWorkbasketAudit";
            this.tabWorkbasketAudit.Padding = new System.Windows.Forms.Padding(3);
            this.tabWorkbasketAudit.Size = new System.Drawing.Size(1171, 523);
            this.tabWorkbasketAudit.TabIndex = 1;
            this.tabWorkbasketAudit.Text = "Work Basket Audit";
            this.tabWorkbasketAudit.UseVisualStyleBackColor = true;
            // 
            // lstWorkbasketAudit
            // 
            this.lstWorkbasketAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWorkbasketAudit.FullRowSelect = true;
            this.lstWorkbasketAudit.HideSelection = false;
            this.lstWorkbasketAudit.Location = new System.Drawing.Point(3, 3);
            this.lstWorkbasketAudit.Name = "lstWorkbasketAudit";
            this.lstWorkbasketAudit.Size = new System.Drawing.Size(1165, 517);
            this.lstWorkbasketAudit.TabIndex = 0;
            this.lstWorkbasketAudit.UseCompatibleStateImageBehavior = false;
            this.lstWorkbasketAudit.View = System.Windows.Forms.View.Details;
            // 
            // btnWorkBasketView
            // 
            this.btnWorkBasketView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkBasketView.Image = global::AIMSClient.Properties.Resources.statusbar_user;
            this.btnWorkBasketView.Location = new System.Drawing.Point(1188, 184);
            this.btnWorkBasketView.Name = "btnWorkBasketView";
            this.btnWorkBasketView.Size = new System.Drawing.Size(68, 75);
            this.btnWorkBasketView.TabIndex = 6;
            this.btnWorkBasketView.Text = "View Others";
            this.btnWorkBasketView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnWorkBasketView.UseVisualStyleBackColor = true;
            this.btnWorkBasketView.Click += new System.EventHandler(this.btnWorkBasketView_Click);
            // 
            // btnMailsRefresh
            // 
            this.btnMailsRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMailsRefresh.Image = global::AIMSClient.Properties.Resources.TL_hist1;
            this.btnMailsRefresh.Location = new System.Drawing.Point(1188, 100);
            this.btnMailsRefresh.Name = "btnMailsRefresh";
            this.btnMailsRefresh.Size = new System.Drawing.Size(68, 82);
            this.btnMailsRefresh.TabIndex = 5;
            this.btnMailsRefresh.Text = "Refresh";
            this.btnMailsRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMailsRefresh.UseVisualStyleBackColor = true;
            this.btnMailsRefresh.Click += new System.EventHandler(this.btnMailsRefresh_Click);
            // 
            // btnWorkClose
            // 
            this.btnWorkClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkClose.Image = global::AIMSClient.Properties.Resources.check_50px;
            this.btnWorkClose.Location = new System.Drawing.Point(1188, 19);
            this.btnWorkClose.Name = "btnWorkClose";
            this.btnWorkClose.Size = new System.Drawing.Size(68, 75);
            this.btnWorkClose.TabIndex = 4;
            this.btnWorkClose.Text = "Process";
            this.btnWorkClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnWorkClose.UseVisualStyleBackColor = true;
            this.btnWorkClose.Click += new System.EventHandler(this.btnWorkClose_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            // 
            // frmWorkBasketAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 595);
            this.Controls.Add(this.gpbxOperatorMails);
            this.Name = "frmWorkBasketAdmin";
            this.Text = "frmAdminWorkBasket";
            this.Load += new System.EventHandler(this.frmWorkBasketAdmin_Load);
            this.gpbxOperatorMails.ResumeLayout(false);
            this.Resize += new System.EventHandler(this.frmWorkbasketAdmin_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabWorkbasketLoad.ResumeLayout(false);
            this.tabWorkbasketAudit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbxOperatorMails;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabWorkbasketLoad;
        private System.Windows.Forms.ListView lstOperatorMailBox;
        private System.Windows.Forms.TabPage tabWorkbasketAudit;
        private System.Windows.Forms.ListView lstWorkbasketAudit;
        private System.Windows.Forms.Button btnWorkBasketView;
        private System.Windows.Forms.Button btnMailsRefresh;
        private System.Windows.Forms.Button btnWorkClose;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}