namespace AIMSClient
{
    partial class frmEmailForward
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailForward));
            this.btnSpellCheck = new System.Windows.Forms.Button();
            this.txtPatientFileNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstEmailAttachment = new System.Windows.Forms.ListView();
            this.MailImagelIst = new System.Windows.Forms.ImageList(this.components);
            this.lnkAttachFile = new System.Windows.Forms.LinkLabel();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmailToCC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCCOPS = new System.Windows.Forms.CheckBox();
            this.cboNewEmailFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewEmailSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewEmailTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.emailBody = new DevExpress.XtraRichEdit.RichEditControl();
            this.chkSpellCheck = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNewEmailBody = new System.Windows.Forms.RichTextBox();
            this.btnNewEmailSend = new System.Windows.Forms.Button();
            this.chkEmailSignatue = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSpellCheck
            // 
            this.btnSpellCheck.Location = new System.Drawing.Point(961, 506);
            this.btnSpellCheck.Name = "btnSpellCheck";
            this.btnSpellCheck.Size = new System.Drawing.Size(75, 23);
            this.btnSpellCheck.TabIndex = 21;
            this.btnSpellCheck.Text = "Spell Check";
            this.btnSpellCheck.UseVisualStyleBackColor = true;
            this.btnSpellCheck.Visible = false;
            // 
            // txtPatientFileNo
            // 
            this.txtPatientFileNo.Location = new System.Drawing.Point(49, 103);
            this.txtPatientFileNo.Name = "txtPatientFileNo";
            this.txtPatientFileNo.ReadOnly = true;
            this.txtPatientFileNo.Size = new System.Drawing.Size(88, 20);
            this.txtPatientFileNo.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstEmailAttachment);
            this.groupBox3.Location = new System.Drawing.Point(12, 527);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1027, 130);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // lstEmailAttachment
            // 
            this.lstEmailAttachment.CheckBoxes = true;
            this.lstEmailAttachment.LargeImageList = this.MailImagelIst;
            this.lstEmailAttachment.Location = new System.Drawing.Point(5, 8);
            this.lstEmailAttachment.Name = "lstEmailAttachment";
            this.lstEmailAttachment.Size = new System.Drawing.Size(1014, 105);
            this.lstEmailAttachment.SmallImageList = this.MailImagelIst;
            this.lstEmailAttachment.TabIndex = 0;
            this.lstEmailAttachment.UseCompatibleStateImageBehavior = false;
            this.lstEmailAttachment.View = System.Windows.Forms.View.Details;
            this.lstEmailAttachment.SelectedIndexChanged += new System.EventHandler(this.lstEmailAttachment_SelectedIndexChanged);
            this.lstEmailAttachment.DoubleClick += new System.EventHandler(this.lstEmailAttachment_DoubleClick);
            // 
            // MailImagelIst
            // 
            this.MailImagelIst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MailImagelIst.ImageStream")));
            this.MailImagelIst.TransparentColor = System.Drawing.Color.Transparent;
            this.MailImagelIst.Images.SetKeyName(0, "doc_view.png");
            // 
            // lnkAttachFile
            // 
            this.lnkAttachFile.AutoSize = true;
            this.lnkAttachFile.Location = new System.Drawing.Point(14, 511);
            this.lnkAttachFile.Name = "lnkAttachFile";
            this.lnkAttachFile.Size = new System.Drawing.Size(57, 13);
            this.lnkAttachFile.TabIndex = 20;
            this.lnkAttachFile.TabStop = true;
            this.lnkAttachFile.Text = "Attach File";
            this.lnkAttachFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAttachFile_LinkClicked);
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmailToCC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkCCOPS);
            this.groupBox1.Controls.Add(this.txtPatientFileNo);
            this.groupBox1.Controls.Add(this.cboNewEmailFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNewEmailSubject);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNewEmailTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(88, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 129);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // txtEmailToCC
            // 
            this.txtEmailToCC.Location = new System.Drawing.Point(50, 65);
            this.txtEmailToCC.Name = "txtEmailToCC";
            this.txtEmailToCC.Size = new System.Drawing.Size(591, 20);
            this.txtEmailToCC.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "CC. . .";
            // 
            // chkCCOPS
            // 
            this.chkCCOPS.AutoSize = true;
            this.chkCCOPS.Checked = true;
            this.chkCCOPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCCOPS.Location = new System.Drawing.Point(647, 67);
            this.chkCCOPS.Name = "chkCCOPS";
            this.chkCCOPS.Size = new System.Drawing.Size(102, 17);
            this.chkCCOPS.TabIndex = 10;
            this.chkCCOPS.Text = "CC Team-Leads";
            this.chkCCOPS.UseVisualStyleBackColor = true;
            this.chkCCOPS.CheckedChanged += new System.EventHandler(this.chkCCOPS_CheckedChanged);
            // 
            // cboNewEmailFrom
            // 
            this.cboNewEmailFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewEmailFrom.FormattingEnabled = true;
            this.cboNewEmailFrom.Location = new System.Drawing.Point(50, 13);
            this.cboNewEmailFrom.Name = "cboNewEmailFrom";
            this.cboNewEmailFrom.Size = new System.Drawing.Size(592, 21);
            this.cboNewEmailFrom.TabIndex = 6;
            this.cboNewEmailFrom.SelectedIndexChanged += new System.EventHandler(this.cboNewEmailFrom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subject";
            // 
            // txtNewEmailSubject
            // 
            this.txtNewEmailSubject.Location = new System.Drawing.Point(143, 103);
            this.txtNewEmailSubject.Name = "txtNewEmailSubject";
            this.txtNewEmailSubject.Size = new System.Drawing.Size(782, 20);
            this.txtNewEmailSubject.TabIndex = 4;
            this.txtNewEmailSubject.TextChanged += new System.EventHandler(this.txtNewEmailSubject_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // txtNewEmailTo
            // 
            this.txtNewEmailTo.Location = new System.Drawing.Point(50, 39);
            this.txtNewEmailTo.Name = "txtNewEmailTo";
            this.txtNewEmailTo.Size = new System.Drawing.Size(591, 20);
            this.txtNewEmailTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // emailBody
            // 
            this.emailBody.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.emailBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.emailBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailBody.Location = new System.Drawing.Point(3, 16);
            this.emailBody.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.emailBody.Name = "emailBody";
            this.emailBody.Options.AutoCorrect.UseSpellCheckerSuggestions = true;
            this.emailBody.Size = new System.Drawing.Size(1023, 332);
            this.emailBody.TabIndex = 2;
            // 
            // chkSpellCheck
            // 
            this.chkSpellCheck.AutoSize = true;
            this.chkSpellCheck.Location = new System.Drawing.Point(198, 138);
            this.chkSpellCheck.Name = "chkSpellCheck";
            this.chkSpellCheck.Size = new System.Drawing.Size(83, 17);
            this.chkSpellCheck.TabIndex = 22;
            this.chkSpellCheck.Text = "Spell Check";
            this.chkSpellCheck.UseVisualStyleBackColor = true;
            this.chkSpellCheck.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.emailBody);
            this.groupBox2.Controls.Add(this.txtNewEmailBody);
            this.groupBox2.Location = new System.Drawing.Point(13, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1029, 351);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // txtNewEmailBody
            // 
            this.txtNewEmailBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewEmailBody.EnableAutoDragDrop = true;
            this.txtNewEmailBody.Location = new System.Drawing.Point(3, 218);
            this.txtNewEmailBody.Name = "txtNewEmailBody";
            this.txtNewEmailBody.Size = new System.Drawing.Size(735, 146);
            this.txtNewEmailBody.TabIndex = 1;
            this.txtNewEmailBody.Text = "";
            this.txtNewEmailBody.Visible = false;
            // 
            // btnNewEmailSend
            // 
            this.btnNewEmailSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEmailSend.Image = ((System.Drawing.Image)(resources.GetObject("btnNewEmailSend.Image")));
            this.btnNewEmailSend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewEmailSend.Location = new System.Drawing.Point(12, 12);
            this.btnNewEmailSend.Name = "btnNewEmailSend";
            this.btnNewEmailSend.Size = new System.Drawing.Size(70, 88);
            this.btnNewEmailSend.TabIndex = 16;
            this.btnNewEmailSend.Text = "Send";
            this.btnNewEmailSend.UseVisualStyleBackColor = true;
            this.btnNewEmailSend.Click += new System.EventHandler(this.btnNewEmailSend_Click);
            // 
            // chkEmailSignatue
            // 
            this.chkEmailSignatue.AutoSize = true;
            this.chkEmailSignatue.Checked = true;
            this.chkEmailSignatue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmailSignatue.Location = new System.Drawing.Point(12, 138);
            this.chkEmailSignatue.Name = "chkEmailSignatue";
            this.chkEmailSignatue.Size = new System.Drawing.Size(108, 17);
            this.chkEmailSignatue.TabIndex = 23;
            this.chkEmailSignatue.Text = "Email Signature ?";
            this.chkEmailSignatue.UseVisualStyleBackColor = true;
            // 
            // frmEmailForward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 669);
            this.Controls.Add(this.chkEmailSignatue);
            this.Controls.Add(this.btnSpellCheck);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lnkAttachFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkSpellCheck);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNewEmailSend);
            this.Name = "frmEmailForward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEmailForward";
            this.Load += new System.EventHandler(this.frmEmailForward_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSpellCheck;
        private System.Windows.Forms.TextBox txtPatientFileNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstEmailAttachment;
        private System.Windows.Forms.LinkLabel lnkAttachFile;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboNewEmailFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewEmailSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewEmailTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSpellCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraRichEdit.RichEditControl emailBody;
        private System.Windows.Forms.RichTextBox txtNewEmailBody;
        private System.Windows.Forms.Button btnNewEmailSend;
        private System.Windows.Forms.ImageList MailImagelIst;
        private System.Windows.Forms.CheckBox chkCCOPS;
        private System.Windows.Forms.TextBox txtEmailToCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkEmailSignatue;
    }
}