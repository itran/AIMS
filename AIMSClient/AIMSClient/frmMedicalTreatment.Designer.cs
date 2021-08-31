namespace AIMSClient
{
    partial class frmMedicalTreatment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicalTreatment));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkDateOfTreatment = new System.Windows.Forms.LinkLabel();
            this.lnkProfession = new System.Windows.Forms.LinkLabel();
            this.lnkDoctor = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtProfession = new System.Windows.Forms.TextBox();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.txtTreatmentDate = new System.Windows.Forms.TextBox();
            this.txtTreatment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.patientDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lnkDateOfTreatment);
            this.groupBox1.Controls.Add(this.lnkProfession);
            this.groupBox1.Controls.Add(this.lnkDoctor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtProfession);
            this.groupBox1.Controls.Add(this.txtDoctor);
            this.groupBox1.Controls.Add(this.txtTreatmentDate);
            this.groupBox1.Controls.Add(this.txtTreatment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Medical Treatment Received";
            // 
            // lnkDateOfTreatment
            // 
            this.lnkDateOfTreatment.AutoSize = true;
            this.lnkDateOfTreatment.Location = new System.Drawing.Point(6, 114);
            this.lnkDateOfTreatment.Name = "lnkDateOfTreatment";
            this.lnkDateOfTreatment.Size = new System.Drawing.Size(93, 13);
            this.lnkDateOfTreatment.TabIndex = 16;
            this.lnkDateOfTreatment.TabStop = true;
            this.lnkDateOfTreatment.Text = "Date of Treatment";
            this.lnkDateOfTreatment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDateOfTreatment_LinkClicked);
            // 
            // lnkProfession
            // 
            this.lnkProfession.AutoSize = true;
            this.lnkProfession.Location = new System.Drawing.Point(6, 88);
            this.lnkProfession.Name = "lnkProfession";
            this.lnkProfession.Size = new System.Drawing.Size(56, 13);
            this.lnkProfession.TabIndex = 15;
            this.lnkProfession.TabStop = true;
            this.lnkProfession.Text = "Profession";
            // 
            // lnkDoctor
            // 
            this.lnkDoctor.AutoSize = true;
            this.lnkDoctor.Location = new System.Drawing.Point(6, 58);
            this.lnkDoctor.Name = "lnkDoctor";
            this.lnkDoctor.Size = new System.Drawing.Size(39, 13);
            this.lnkDoctor.TabIndex = 14;
            this.lnkDoctor.TabStop = true;
            this.lnkDoctor.Text = "Doctor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Hospital/Clinic Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 20);
            this.textBox1.TabIndex = 0;
            // 
            // txtProfession
            // 
            this.txtProfession.Location = new System.Drawing.Point(118, 81);
            this.txtProfession.Name = "txtProfession";
            this.txtProfession.Size = new System.Drawing.Size(280, 20);
            this.txtProfession.TabIndex = 2;
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(118, 55);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(280, 20);
            this.txtDoctor.TabIndex = 1;
            // 
            // txtTreatmentDate
            // 
            this.txtTreatmentDate.Location = new System.Drawing.Point(118, 107);
            this.txtTreatmentDate.Name = "txtTreatmentDate";
            this.txtTreatmentDate.Size = new System.Drawing.Size(280, 20);
            this.txtTreatmentDate.TabIndex = 3;
            // 
            // txtTreatment
            // 
            this.txtTreatment.Location = new System.Drawing.Point(118, 136);
            this.txtTreatment.Multiline = true;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.Size = new System.Drawing.Size(280, 92);
            this.txtTreatment.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Treatment ";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::AIMSClient.Properties.Resources.psSave;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(145, 268);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::AIMSClient.Properties.Resources.psClose;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(256, 268);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(244, 17);
            this.toolStripStatusLabel1.Text = "Patient No: 32432/4234/34534 - Mr. John Doe";
            // 
            // patientDetails
            // 
            this.patientDetails.Name = "patientDetails";
            this.patientDetails.Size = new System.Drawing.Size(182, 17);
            this.patientDetails.Text = "Patient No:786/343/43 John Terry";
            // 
            // frmMedicalTreatment
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 299);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMedicalTreatment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medical Treatment";
            this.Load += new System.EventHandler(this.frmMedicalTreatment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMedicalTreatment_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTreatment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTreatmentDate;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.TextBox txtProfession;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkDateOfTreatment;
        private System.Windows.Forms.LinkLabel lnkProfession;
        private System.Windows.Forms.LinkLabel lnkDoctor;
        private System.Windows.Forms.ToolStripStatusLabel patientDetails;
    }
}