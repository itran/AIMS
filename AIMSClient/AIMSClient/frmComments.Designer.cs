namespace AIMSClient
{
    partial class frmComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComments));
            this.txtCommentText = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errDesription = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNoteType = new System.Windows.Forms.ComboBox();
            this.chkSpellCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errDesription)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCommentText
            // 
            this.txtCommentText.Location = new System.Drawing.Point(12, 77);
            this.txtCommentText.Multiline = true;
            this.txtCommentText.Name = "txtCommentText";
            this.txtCommentText.Size = new System.Drawing.Size(329, 93);
            this.txtCommentText.TabIndex = 0;
            this.txtCommentText.TextChanged += new System.EventHandler(this.txtCommentText_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::AIMSClient.Properties.Resources.psSave;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(92, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::AIMSClient.Properties.Resources.psClose;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(173, 199);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close Invoice";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(160, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // errDesription
            // 
            this.errDesription.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(77, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Please add your note/comment here";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Comment/Note Type";
            // 
            // cboNoteType
            // 
            this.cboNoteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNoteType.FormattingEnabled = true;
            this.cboNoteType.Location = new System.Drawing.Point(12, 25);
            this.cboNoteType.Name = "cboNoteType";
            this.cboNoteType.Size = new System.Drawing.Size(329, 21);
            this.cboNoteType.TabIndex = 6;
            // 
            // chkSpellCheck
            // 
            this.chkSpellCheck.AutoSize = true;
            this.chkSpellCheck.Location = new System.Drawing.Point(12, 175);
            this.chkSpellCheck.Name = "chkSpellCheck";
            this.chkSpellCheck.Size = new System.Drawing.Size(92, 17);
            this.chkSpellCheck.TabIndex = 7;
            this.chkSpellCheck.Text = "Spell Check ?";
            this.chkSpellCheck.UseVisualStyleBackColor = true;
            this.chkSpellCheck.CheckedChanged += new System.EventHandler(this.chkSpellCheck_CheckedChanged);
            // 
            // frmComments
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 244);
            this.Controls.Add(this.chkSpellCheck);
            this.Controls.Add(this.cboNoteType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCommentText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmComments";
            this.Text = "Comments/Notes";
            this.Load += new System.EventHandler(this.frmComments_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmComments_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.errDesription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCommentText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errDesription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNoteType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSpellCheck;
    }
}