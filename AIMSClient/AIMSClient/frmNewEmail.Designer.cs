namespace AIMSClient
{
    partial class frmNewEmail
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
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewEmail));
            this.spelling = new NetSpell.SpellChecker.Spelling(this.components);
            this.wordDictionary = new NetSpell.SpellChecker.Dictionary.WordDictionary(this.components);
            this.txtNewEmailTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkAttachFile = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.demoRichText = new System.Windows.Forms.RichTextBox();
            this.emailBody = new DevExpress.XtraRichEdit.RichEditControl();
            this.txtNewEmailBody = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstEmailAttachment = new System.Windows.Forms.ListView();
            this.btnNewEmailSend = new System.Windows.Forms.Button();
            this.txtNewEmailSubject = new System.Windows.Forms.TextBox();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboNewEmailFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtEmailToCC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCCOPS = new System.Windows.Forms.CheckBox();
            this.txtPatientFileNo = new System.Windows.Forms.TextBox();
            this.btnAddressBookLookUp = new System.Windows.Forms.Button();
            this.chkSpellCheck = new System.Windows.Forms.CheckBox();
            this.chkEmailSignatue = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spelling
            // 
            this.spelling.Dictionary = this.wordDictionary;
            this.spelling.EndOfText += new NetSpell.SpellChecker.Spelling.EndOfTextEventHandler(this.spelling_EndOfText);
            this.spelling.DeletedWord += new NetSpell.SpellChecker.Spelling.DeletedWordEventHandler(this.spelling_DeletedWord);
            this.spelling.ReplacedWord += new NetSpell.SpellChecker.Spelling.ReplacedWordEventHandler(this.spelling_ReplacedWord);
            this.spelling.MisspelledWord += new NetSpell.SpellChecker.Spelling.MisspelledWordEventHandler(this.SpellChecker_MisspelledWord);
            // 
            // wordDictionary
            // 
            this.wordDictionary.DictionaryFolder = ((string)(configurationAppSettings.GetValue("wordDictionary.DictionaryFolder", typeof(string))));
            // 
            // txtNewEmailTo
            // 
            this.txtNewEmailTo.Location = new System.Drawing.Point(50, 39);
            this.txtNewEmailTo.Name = "txtNewEmailTo";
            this.txtNewEmailTo.Size = new System.Drawing.Size(592, 20);
            this.txtNewEmailTo.TabIndex = 2;
            this.txtNewEmailTo.TextChanged += new System.EventHandler(this.txtNewEmailTo_TextChanged_1);
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
            // lnkAttachFile
            // 
            this.lnkAttachFile.AutoSize = true;
            this.lnkAttachFile.Location = new System.Drawing.Point(6, 601);
            this.lnkAttachFile.Name = "lnkAttachFile";
            this.lnkAttachFile.Size = new System.Drawing.Size(57, 13);
            this.lnkAttachFile.TabIndex = 18;
            this.lnkAttachFile.TabStop = true;
            this.lnkAttachFile.Text = "Attach File";
            this.lnkAttachFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAttachFile_LinkClicked);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.demoRichText);
            this.groupBox2.Controls.Add(this.emailBody);
            this.groupBox2.Controls.Add(this.txtNewEmailBody);
            this.groupBox2.Location = new System.Drawing.Point(9, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1049, 433);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // demoRichText
            // 
            this.demoRichText.Location = new System.Drawing.Point(246, -33);
            this.demoRichText.Name = "demoRichText";
            this.demoRichText.Size = new System.Drawing.Size(100, 96);
            this.demoRichText.TabIndex = 20;
            this.demoRichText.Text = "";
            this.demoRichText.Visible = false;
            // 
            // emailBody
            // 
            this.emailBody.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.emailBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.emailBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailBody.Location = new System.Drawing.Point(3, 16);
            this.emailBody.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.emailBody.Name = "emailBody";
            this.emailBody.Options.AutoCorrect.UseSpellCheckerSuggestions = true;
            this.emailBody.Options.DocumentCapabilities.Numbering.Bulleted = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.emailBody.Options.DocumentSaveOptions.DefaultFormat = DevExpress.XtraRichEdit.DocumentFormat.Html;
            this.emailBody.Size = new System.Drawing.Size(1043, 414);
            this.emailBody.TabIndex = 2;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstEmailAttachment);
            this.groupBox3.Location = new System.Drawing.Point(4, 617);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1054, 107);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // lstEmailAttachment
            // 
            this.lstEmailAttachment.CheckBoxes = true;
            this.lstEmailAttachment.Location = new System.Drawing.Point(7, 19);
            this.lstEmailAttachment.Name = "lstEmailAttachment";
            this.lstEmailAttachment.Size = new System.Drawing.Size(1038, 82);
            this.lstEmailAttachment.TabIndex = 0;
            this.lstEmailAttachment.UseCompatibleStateImageBehavior = false;
            this.lstEmailAttachment.View = System.Windows.Forms.View.Details;
            this.lstEmailAttachment.SelectedIndexChanged += new System.EventHandler(this.lstEmailAttachment_SelectedIndexChanged);
            this.lstEmailAttachment.DoubleClick += new System.EventHandler(this.lstEmailAttachment_DoubleClick);
            // 
            // btnNewEmailSend
            // 
            this.btnNewEmailSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEmailSend.Image = ((System.Drawing.Image)(resources.GetObject("btnNewEmailSend.Image")));
            this.btnNewEmailSend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewEmailSend.Location = new System.Drawing.Point(12, 12);
            this.btnNewEmailSend.Name = "btnNewEmailSend";
            this.btnNewEmailSend.Size = new System.Drawing.Size(70, 88);
            this.btnNewEmailSend.TabIndex = 14;
            this.btnNewEmailSend.Text = "Send";
            this.btnNewEmailSend.UseVisualStyleBackColor = true;
            this.btnNewEmailSend.Click += new System.EventHandler(this.btnNewEmailSend_Click);
            // 
            // txtNewEmailSubject
            // 
            this.txtNewEmailSubject.Location = new System.Drawing.Point(144, 103);
            this.txtNewEmailSubject.Name = "txtNewEmailSubject";
            this.txtNewEmailSubject.Size = new System.Drawing.Size(796, 20);
            this.txtNewEmailSubject.TabIndex = 4;
            this.txtNewEmailSubject.TextChanged += new System.EventHandler(this.txtNewEmailSubject_TextChanged);
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
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
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subject";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
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
            this.groupBox1.Size = new System.Drawing.Size(970, 135);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(775, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
            // 
            // txtEmailToCC
            // 
            this.txtEmailToCC.Location = new System.Drawing.Point(50, 65);
            this.txtEmailToCC.Name = "txtEmailToCC";
            this.txtEmailToCC.Size = new System.Drawing.Size(592, 20);
            this.txtEmailToCC.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "CC. . .";
            // 
            // chkCCOPS
            // 
            this.chkCCOPS.AutoSize = true;
            this.chkCCOPS.Checked = true;
            this.chkCCOPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCCOPS.Location = new System.Drawing.Point(648, 67);
            this.chkCCOPS.Name = "chkCCOPS";
            this.chkCCOPS.Size = new System.Drawing.Size(102, 17);
            this.chkCCOPS.TabIndex = 11;
            this.chkCCOPS.Text = "CC Team-Leads";
            this.chkCCOPS.UseVisualStyleBackColor = true;
            this.chkCCOPS.CheckedChanged += new System.EventHandler(this.chkCCOPS_CheckedChanged);
            // 
            // txtPatientFileNo
            // 
            this.txtPatientFileNo.Location = new System.Drawing.Point(50, 103);
            this.txtPatientFileNo.Name = "txtPatientFileNo";
            this.txtPatientFileNo.ReadOnly = true;
            this.txtPatientFileNo.Size = new System.Drawing.Size(88, 20);
            this.txtPatientFileNo.TabIndex = 8;
            // 
            // btnAddressBookLookUp
            // 
            this.btnAddressBookLookUp.Location = new System.Drawing.Point(705, 144);
            this.btnAddressBookLookUp.Name = "btnAddressBookLookUp";
            this.btnAddressBookLookUp.Size = new System.Drawing.Size(25, 20);
            this.btnAddressBookLookUp.TabIndex = 12;
            this.btnAddressBookLookUp.Text = "...";
            this.btnAddressBookLookUp.UseVisualStyleBackColor = true;
            this.btnAddressBookLookUp.Visible = false;
            this.btnAddressBookLookUp.Click += new System.EventHandler(this.btnAddressBookLookUp_Click);
            // 
            // chkSpellCheck
            // 
            this.chkSpellCheck.AutoSize = true;
            this.chkSpellCheck.Location = new System.Drawing.Point(246, 147);
            this.chkSpellCheck.Name = "chkSpellCheck";
            this.chkSpellCheck.Size = new System.Drawing.Size(83, 17);
            this.chkSpellCheck.TabIndex = 19;
            this.chkSpellCheck.Text = "Spell Check";
            this.chkSpellCheck.UseVisualStyleBackColor = true;
            this.chkSpellCheck.Visible = false;
            this.chkSpellCheck.CheckedChanged += new System.EventHandler(this.chkSpellCheck_CheckedChanged);
            // 
            // chkEmailSignatue
            // 
            this.chkEmailSignatue.AutoSize = true;
            this.chkEmailSignatue.Checked = true;
            this.chkEmailSignatue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmailSignatue.Location = new System.Drawing.Point(11, 147);
            this.chkEmailSignatue.Name = "chkEmailSignatue";
            this.chkEmailSignatue.Size = new System.Drawing.Size(108, 17);
            this.chkEmailSignatue.TabIndex = 20;
            this.chkEmailSignatue.Text = "Email Signature ?";
            this.chkEmailSignatue.UseVisualStyleBackColor = true;
            this.chkEmailSignatue.CheckedChanged += new System.EventHandler(this.chkEmailSignatue_CheckedChanged);
            // 
            // frmNewEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 736);
            this.Controls.Add(this.chkEmailSignatue);
            this.Controls.Add(this.chkSpellCheck);
            this.Controls.Add(this.lnkAttachFile);
            this.Controls.Add(this.btnAddressBookLookUp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnNewEmailSend);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmNewEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Mail";
            this.Load += new System.EventHandler(this.frmNewEmail_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewEmailTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkAttachFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraRichEdit.RichEditControl emailBody;
        private System.Windows.Forms.RichTextBox txtNewEmailBody;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstEmailAttachment;
        private System.Windows.Forms.Button btnNewEmailSend;
        private System.Windows.Forms.TextBox txtNewEmailSubject;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboNewEmailFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPatientFileNo;
        private System.Windows.Forms.CheckBox chkSpellCheck;
        private System.Windows.Forms.CheckBox chkCCOPS;
        private System.Windows.Forms.Button btnAddressBookLookUp;
        private System.Windows.Forms.RichTextBox demoRichText;
        private System.Windows.Forms.TextBox txtEmailToCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkEmailSignatue;


    }
}