namespace AIMSClient
{
    partial class frmIncidents
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
            commonFuncs = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIncidents));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgViewer = new System.Windows.Forms.WebBrowser();
            this.btnDoc = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstEmailAttachments = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEmailSearch = new System.Windows.Forms.Button();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.lstMailboxEmails = new System.Windows.Forms.ListView();
            this.MailImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnEmailsRefresh = new System.Windows.Forms.Button();
            this.btnDeleteMail = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMailboxLatestEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMailboxOldestEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMailboxEmailCnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMailBoxes = new System.Windows.Forms.ComboBox();
            this.btnEmailStats = new System.Windows.Forms.Button();
            this.MailTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnEmailSave = new System.Windows.Forms.Button();
            this.dgEmailAttachments = new System.Windows.Forms.DataGridView();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnPendEmail = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmailAttachments)).BeginInit();
            this.SuspendLayout();
            // 
            // imgViewer
            // 
            this.imgViewer.Location = new System.Drawing.Point(28, 182);
            this.imgViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.imgViewer.Name = "imgViewer";
            this.imgViewer.Size = new System.Drawing.Size(1224, 269);
            this.imgViewer.TabIndex = 0;
            // 
            // btnDoc
            // 
            this.btnDoc.Location = new System.Drawing.Point(1258, 483);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(57, 24);
            this.btnDoc.TabIndex = 2;
            this.btnDoc.Text = "Word Doc";
            this.btnDoc.UseVisualStyleBackColor = true;
            this.btnDoc.Visible = false;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(1258, 447);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(56, 30);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(1237, 562);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(32, 24);
            this.btnPDF.TabIndex = 4;
            this.btnPDF.Text = "PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Visible = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnText
            // 
            this.btnText.Location = new System.Drawing.Point(1238, 592);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(34, 24);
            this.btnText.TabIndex = 5;
            this.btnText.Text = "Text/HTML/RTF";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Visible = false;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstEmailAttachments);
            this.groupBox1.Location = new System.Drawing.Point(878, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 125);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Email Attachments";
            // 
            // LstEmailAttachments
            // 
            this.LstEmailAttachments.CheckBoxes = true;
            this.LstEmailAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstEmailAttachments.FullRowSelect = true;
            this.LstEmailAttachments.HideSelection = false;
            this.LstEmailAttachments.Location = new System.Drawing.Point(3, 16);
            this.LstEmailAttachments.Name = "LstEmailAttachments";
            this.LstEmailAttachments.Size = new System.Drawing.Size(366, 106);
            this.LstEmailAttachments.TabIndex = 0;
            this.LstEmailAttachments.UseCompatibleStateImageBehavior = false;
            this.LstEmailAttachments.View = System.Windows.Forms.View.Details;
            this.LstEmailAttachments.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LstEmailAttachments_ItemChecked);
            this.LstEmailAttachments.SelectedIndexChanged += new System.EventHandler(this.LstEmailAttachments_SelectedIndexChanged_1);
            this.LstEmailAttachments.DoubleClick += new System.EventHandler(this.LstEmailAttachments_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEmailSearch);
            this.groupBox2.Controls.Add(this.lblCountDown);
            this.groupBox2.Controls.Add(this.lstMailboxEmails);
            this.groupBox2.Controls.Add(this.btnEmailsRefresh);
            this.groupBox2.Location = new System.Drawing.Point(215, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(657, 176);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mailbox Emails";
            // 
            // btnEmailSearch
            // 
            this.btnEmailSearch.Enabled = false;
            this.btnEmailSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmailSearch.Image = global::AIMSClient.Properties.Resources.Search_2_icon_3;
            this.btnEmailSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmailSearch.Location = new System.Drawing.Point(595, 19);
            this.btnEmailSearch.Name = "btnEmailSearch";
            this.btnEmailSearch.Size = new System.Drawing.Size(56, 65);
            this.btnEmailSearch.TabIndex = 13;
            this.btnEmailSearch.Text = "Search";
            this.btnEmailSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmailSearch.UseVisualStyleBackColor = true;
            this.btnEmailSearch.Click += new System.EventHandler(this.btnEmailSearch_Click);
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.ForeColor = System.Drawing.Color.Green;
            this.lblCountDown.Location = new System.Drawing.Point(592, 157);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(44, 16);
            this.lblCountDown.TabIndex = 11;
            this.lblCountDown.Text = "00:00";
            this.lblCountDown.Visible = false;
            this.lblCountDown.Click += new System.EventHandler(this.lblCountDown_Click);
            // 
            // lstMailboxEmails
            // 
            this.lstMailboxEmails.FullRowSelect = true;
            this.lstMailboxEmails.HideSelection = false;
            this.lstMailboxEmails.LargeImageList = this.MailImageList;
            this.lstMailboxEmails.Location = new System.Drawing.Point(6, 19);
            this.lstMailboxEmails.MultiSelect = false;
            this.lstMailboxEmails.Name = "lstMailboxEmails";
            this.lstMailboxEmails.Size = new System.Drawing.Size(583, 157);
            this.lstMailboxEmails.SmallImageList = this.MailImageList;
            this.lstMailboxEmails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstMailboxEmails.TabIndex = 2;
            this.lstMailboxEmails.UseCompatibleStateImageBehavior = false;
            this.lstMailboxEmails.View = System.Windows.Forms.View.Details;
            this.lstMailboxEmails.SelectedIndexChanged += new System.EventHandler(this.lstMailboxEmails_SelectedIndexChanged);
            // 
            // MailImageList
            // 
            this.MailImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MailImageList.ImageStream")));
            this.MailImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MailImageList.Images.SetKeyName(0, "Outlook_unread.gif");
            this.MailImageList.Images.SetKeyName(1, "Outlook_read.gif");
            // 
            // btnEmailsRefresh
            // 
            this.btnEmailsRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmailsRefresh.Image = global::AIMSClient.Properties.Resources.refresh;
            this.btnEmailsRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmailsRefresh.Location = new System.Drawing.Point(595, 90);
            this.btnEmailsRefresh.Name = "btnEmailsRefresh";
            this.btnEmailsRefresh.Size = new System.Drawing.Size(56, 49);
            this.btnEmailsRefresh.TabIndex = 12;
            this.btnEmailsRefresh.Text = "Refresh";
            this.btnEmailsRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmailsRefresh.UseVisualStyleBackColor = true;
            this.btnEmailsRefresh.Click += new System.EventHandler(this.btnEmailsRefresh_Click);
            // 
            // btnDeleteMail
            // 
            this.btnDeleteMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMail.Image = global::AIMSClient.Properties.Resources.no;
            this.btnDeleteMail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteMail.Location = new System.Drawing.Point(1006, 131);
            this.btnDeleteMail.Name = "btnDeleteMail";
            this.btnDeleteMail.Size = new System.Drawing.Size(56, 45);
            this.btnDeleteMail.TabIndex = 3;
            this.btnDeleteMail.Text = "Delete";
            this.btnDeleteMail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteMail.UseVisualStyleBackColor = true;
            this.btnDeleteMail.Click += new System.EventHandler(this.btnDeleteMail_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.cboMailBoxes);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 176);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AIMS Mailbox";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtMailboxLatestEmail);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtMailboxOldestEmail);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtMailboxEmailCnt);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 50);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 122);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mailbox Stats";
            // 
            // txtMailboxLatestEmail
            // 
            this.txtMailboxLatestEmail.Location = new System.Drawing.Point(88, 73);
            this.txtMailboxLatestEmail.Name = "txtMailboxLatestEmail";
            this.txtMailboxLatestEmail.ReadOnly = true;
            this.txtMailboxLatestEmail.Size = new System.Drawing.Size(103, 20);
            this.txtMailboxLatestEmail.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Latest Email Date";
            // 
            // txtMailboxOldestEmail
            // 
            this.txtMailboxOldestEmail.Location = new System.Drawing.Point(88, 47);
            this.txtMailboxOldestEmail.Name = "txtMailboxOldestEmail";
            this.txtMailboxOldestEmail.ReadOnly = true;
            this.txtMailboxOldestEmail.Size = new System.Drawing.Size(103, 20);
            this.txtMailboxOldestEmail.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Oldest Email Date";
            // 
            // txtMailboxEmailCnt
            // 
            this.txtMailboxEmailCnt.Location = new System.Drawing.Point(88, 21);
            this.txtMailboxEmailCnt.Name = "txtMailboxEmailCnt";
            this.txtMailboxEmailCnt.ReadOnly = true;
            this.txtMailboxEmailCnt.Size = new System.Drawing.Size(103, 20);
            this.txtMailboxEmailCnt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Of Emails";
            // 
            // cboMailBoxes
            // 
            this.cboMailBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMailBoxes.FormattingEnabled = true;
            this.cboMailBoxes.Location = new System.Drawing.Point(6, 23);
            this.cboMailBoxes.Name = "cboMailBoxes";
            this.cboMailBoxes.Size = new System.Drawing.Size(197, 21);
            this.cboMailBoxes.TabIndex = 0;
            this.cboMailBoxes.SelectedIndexChanged += new System.EventHandler(this.cboMailBoxes_SelectedIndexChanged);
            // 
            // btnEmailStats
            // 
            this.btnEmailStats.AutoEllipsis = true;
            this.btnEmailStats.Image = global::AIMSClient.Properties.Resources.bar_chart;
            this.btnEmailStats.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmailStats.Location = new System.Drawing.Point(528, 407);
            this.btnEmailStats.Name = "btnEmailStats";
            this.btnEmailStats.Size = new System.Drawing.Size(72, 64);
            this.btnEmailStats.TabIndex = 13;
            this.btnEmailStats.Text = "Email Stats";
            this.btnEmailStats.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmailStats.UseVisualStyleBackColor = true;
            this.btnEmailStats.Visible = false;
            this.btnEmailStats.Click += new System.EventHandler(this.btnEmailStats_Click);
            // 
            // MailTimer
            // 
            this.MailTimer.Interval = 180000;
            this.MailTimer.Tick += new System.EventHandler(this.MailTimer_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnEmailSave
            // 
            this.btnEmailSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmailSave.Image = global::AIMSClient.Properties.Resources.add;
            this.btnEmailSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmailSave.Location = new System.Drawing.Point(881, 131);
            this.btnEmailSave.Name = "btnEmailSave";
            this.btnEmailSave.Size = new System.Drawing.Size(58, 45);
            this.btnEmailSave.TabIndex = 11;
            this.btnEmailSave.Text = "Save";
            this.btnEmailSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmailSave.UseVisualStyleBackColor = true;
            this.btnEmailSave.Click += new System.EventHandler(this.btnEmailSave_Click);
            // 
            // dgEmailAttachments
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEmailAttachments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgEmailAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmailAttachments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSelect});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgEmailAttachments.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgEmailAttachments.Location = new System.Drawing.Point(1266, 220);
            this.dgEmailAttachments.Name = "dgEmailAttachments";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEmailAttachments.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgEmailAttachments.Size = new System.Drawing.Size(360, 120);
            this.dgEmailAttachments.TabIndex = 1;
            this.dgEmailAttachments.Visible = false;
            // 
            // chkSelect
            // 
            this.chkSelect.HeaderText = "";
            this.chkSelect.Name = "chkSelect";
            // 
            // btnPendEmail
            // 
            this.btnPendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendEmail.Image = global::AIMSClient.Properties.Resources.calendar1;
            this.btnPendEmail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPendEmail.Location = new System.Drawing.Point(944, 131);
            this.btnPendEmail.Name = "btnPendEmail";
            this.btnPendEmail.Size = new System.Drawing.Size(56, 45);
            this.btnPendEmail.TabIndex = 14;
            this.btnPendEmail.Text = "Pend";
            this.btnPendEmail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPendEmail.UseVisualStyleBackColor = true;
            this.btnPendEmail.Click += new System.EventHandler(this.btnPendEmail_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(28, 182);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1224, 269);
            this.webBrowser1.TabIndex = 15;
            // 
            // frmIncidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 519);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnPendEmail);
            this.Controls.Add(this.dgEmailAttachments);
            this.Controls.Add(this.btnDeleteMail);
            this.Controls.Add(this.btnEmailStats);
            this.Controls.Add(this.btnEmailSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnText);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnDoc);
            this.Controls.Add(this.imgViewer);
            this.Name = "frmIncidents";
            this.Text = "Incidents";
            this.Load += new System.EventHandler(this.Incidents_Load);
            this.Resize += new System.EventHandler(this.Incidents_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmailAttachments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser imgViewer;
        private System.Windows.Forms.Button btnDoc;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstMailboxEmails;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboMailBoxes;
        private System.Windows.Forms.ListView LstEmailAttachments;
        private System.Windows.Forms.Button btnDeleteMail;
        private System.Windows.Forms.Timer MailTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Button btnEmailStats;
        private System.Windows.Forms.Button btnEmailSave;
        private System.Windows.Forms.Button btnEmailsRefresh;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMailboxEmailCnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMailboxLatestEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMailboxOldestEmail;
        private System.Windows.Forms.DataGridView dgEmailAttachments;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.Button btnPendEmail;
        private System.Windows.Forms.Button btnEmailSearch;
        private System.Windows.Forms.ImageList MailImageList;
        private System.Windows.Forms.WebBrowser webBrowser1;

    }
}