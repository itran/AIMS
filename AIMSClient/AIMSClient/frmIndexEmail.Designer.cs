namespace AIMSClient
{
    partial class frmIndexEmail
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
                this.commonFuncs = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndexEmail));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientFileNo = new System.Windows.Forms.TextBox();
            this.lstIndexFile = new System.Windows.Forms.ListBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnIndexCancel = new System.Windows.Forms.Button();
            this.chkQueryFile = new System.Windows.Forms.CheckBox();
            this.chkUrgentEmail = new System.Windows.Forms.CheckBox();
            this.chkAcknowledgeEmail = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient File No";
            // 
            // txtPatientFileNo
            // 
            this.txtPatientFileNo.Location = new System.Drawing.Point(7, 24);
            this.txtPatientFileNo.Name = "txtPatientFileNo";
            this.txtPatientFileNo.Size = new System.Drawing.Size(159, 20);
            this.txtPatientFileNo.TabIndex = 1;
            this.txtPatientFileNo.TextChanged += new System.EventHandler(this.txtPatientFileNo_TextChanged);
            this.txtPatientFileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientFileNo_KeyDown);
            // 
            // lstIndexFile
            // 
            this.lstIndexFile.FormattingEnabled = true;
            this.lstIndexFile.Location = new System.Drawing.Point(6, 50);
            this.lstIndexFile.Name = "lstIndexFile";
            this.lstIndexFile.Size = new System.Drawing.Size(159, 160);
            this.lstIndexFile.TabIndex = 2;
            this.lstIndexFile.SelectedIndexChanged += new System.EventHandler(this.lstIndexFile_SelectedIndexChanged);
            // 
            // btnAddFile
            // 
            this.btnAddFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFile.Image = global::AIMSClient.Properties.Resources.add_nexttoinput;
            this.btnAddFile.Location = new System.Drawing.Point(172, 24);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(27, 20);
            this.btnAddFile.TabIndex = 3;
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::AIMSClient.Properties.Resources.delete2;
            this.btnRemove.Location = new System.Drawing.Point(172, 50);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(27, 29);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Image = global::AIMSClient.Properties.Resources.check_50px;
            this.btnConfirm.Location = new System.Drawing.Point(6, 286);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(70, 79);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnIndexCancel
            // 
            this.btnIndexCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndexCancel.Image = global::AIMSClient.Properties.Resources.error_50px;
            this.btnIndexCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIndexCancel.Location = new System.Drawing.Point(82, 286);
            this.btnIndexCancel.Name = "btnIndexCancel";
            this.btnIndexCancel.Size = new System.Drawing.Size(70, 79);
            this.btnIndexCancel.TabIndex = 6;
            this.btnIndexCancel.Text = "Cancel";
            this.btnIndexCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIndexCancel.UseVisualStyleBackColor = true;
            this.btnIndexCancel.Click += new System.EventHandler(this.btnIndexCancel_Click);
            // 
            // chkQueryFile
            // 
            this.chkQueryFile.AutoSize = true;
            this.chkQueryFile.Location = new System.Drawing.Point(7, 216);
            this.chkQueryFile.Name = "chkQueryFile";
            this.chkQueryFile.Size = new System.Drawing.Size(82, 17);
            this.chkQueryFile.TabIndex = 12;
            this.chkQueryFile.Text = "Query Email";
            this.chkQueryFile.UseVisualStyleBackColor = true;
            this.chkQueryFile.CheckedChanged += new System.EventHandler(this.chkQueryFile_CheckedChanged);
            // 
            // chkUrgentEmail
            // 
            this.chkUrgentEmail.AutoSize = true;
            this.chkUrgentEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUrgentEmail.ForeColor = System.Drawing.Color.Red;
            this.chkUrgentEmail.Location = new System.Drawing.Point(7, 239);
            this.chkUrgentEmail.Name = "chkUrgentEmail";
            this.chkUrgentEmail.Size = new System.Drawing.Size(116, 20);
            this.chkUrgentEmail.TabIndex = 11;
            this.chkUrgentEmail.Text = "Urgent Email";
            this.chkUrgentEmail.UseVisualStyleBackColor = true;
            this.chkUrgentEmail.CheckedChanged += new System.EventHandler(this.chkUrgentEmail_CheckedChanged);
            // 
            // chkAcknowledgeEmail
            // 
            this.chkAcknowledgeEmail.AutoSize = true;
            this.chkAcknowledgeEmail.Enabled = false;
            this.chkAcknowledgeEmail.Location = new System.Drawing.Point(7, 263);
            this.chkAcknowledgeEmail.Name = "chkAcknowledgeEmail";
            this.chkAcknowledgeEmail.Size = new System.Drawing.Size(213, 17);
            this.chkAcknowledgeEmail.TabIndex = 14;
            this.chkAcknowledgeEmail.Text = "Acknowledge Email with Correspondent";
            this.chkAcknowledgeEmail.UseVisualStyleBackColor = true;
            this.chkAcknowledgeEmail.CheckedChanged += new System.EventHandler(this.chkAcknowledgeEmail_CheckedChanged);
            // 
            // frmIndexEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 371);
            this.ControlBox = false;
            this.Controls.Add(this.chkAcknowledgeEmail);
            this.Controls.Add(this.chkQueryFile);
            this.Controls.Add(this.chkUrgentEmail);
            this.Controls.Add(this.btnIndexCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.lstIndexFile);
            this.Controls.Add(this.txtPatientFileNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIndexEmail";
            this.Text = "Email Indexing Criteria";
            this.Load += new System.EventHandler(this.frmIndexEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatientFileNo;
        private System.Windows.Forms.ListBox lstIndexFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnIndexCancel;
        private System.Windows.Forms.CheckBox chkQueryFile;
        private System.Windows.Forms.CheckBox chkUrgentEmail;
        private System.Windows.Forms.CheckBox chkAcknowledgeEmail;
    }
}