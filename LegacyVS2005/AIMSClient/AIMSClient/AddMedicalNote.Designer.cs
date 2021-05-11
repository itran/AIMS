namespace AIMSClient
{
    partial class AddMedicalNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMedicalNote));
            this.btnAddMedicalTreatment = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDateofTreatment = new System.Windows.Forms.TextBox();
            this.lnklblDate = new System.Windows.Forms.LinkLabel();
            this.cboSuppliers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboServices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMedicalTreatment = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddMedicalTreatment
            // 
            this.btnAddMedicalTreatment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMedicalTreatment.Image")));
            this.btnAddMedicalTreatment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMedicalTreatment.Location = new System.Drawing.Point(189, 169);
            this.btnAddMedicalTreatment.Name = "btnAddMedicalTreatment";
            this.btnAddMedicalTreatment.Size = new System.Drawing.Size(137, 23);
            this.btnAddMedicalTreatment.TabIndex = 0;
            this.btnAddMedicalTreatment.Text = "Add";
            this.btnAddMedicalTreatment.UseVisualStyleBackColor = true;
            this.btnAddMedicalTreatment.Click += new System.EventHandler(this.btnAddMedicalTreatment_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtDateofTreatment);
            this.panel1.Controls.Add(this.lnklblDate);
            this.panel1.Controls.Add(this.cboSuppliers);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboServices);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMedicalTreatment);
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 160);
            this.panel1.TabIndex = 1;
           
            // 
            // txtDateofTreatment
            // 
            this.txtDateofTreatment.Location = new System.Drawing.Point(163, 132);
            this.txtDateofTreatment.Name = "txtDateofTreatment";
            this.txtDateofTreatment.ReadOnly = true;
            this.txtDateofTreatment.Size = new System.Drawing.Size(273, 20);
            this.txtDateofTreatment.TabIndex = 9;
            this.txtDateofTreatment.DoubleClick += new System.EventHandler(this.txtDateofTreatment_DoubleClick);
            // 
            // lnklblDate
            // 
            this.lnklblDate.AutoSize = true;
            this.lnklblDate.Location = new System.Drawing.Point(9, 139);
            this.lnklblDate.Name = "lnklblDate";
            this.lnklblDate.Size = new System.Drawing.Size(93, 13);
            this.lnklblDate.TabIndex = 8;
            this.lnklblDate.TabStop = true;
            this.lnklblDate.Text = "Date of Treatment";
            this.lnklblDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblDate_LinkClicked);
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(163, 9);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(273, 21);
            this.cboSuppliers.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Supplier";
            // 
            // cboServices
            // 
            this.cboServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServices.FormattingEnabled = true;
            this.cboServices.Location = new System.Drawing.Point(163, 106);
            this.cboServices.Name = "cboServices";
            this.cboServices.Size = new System.Drawing.Size(273, 21);
            this.cboServices.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Medical Treatment Description";
            // 
            // txtMedicalTreatment
            // 
            this.txtMedicalTreatment.Location = new System.Drawing.Point(163, 36);
            this.txtMedicalTreatment.Multiline = true;
            this.txtMedicalTreatment.Name = "txtMedicalTreatment";
            this.txtMedicalTreatment.Size = new System.Drawing.Size(273, 64);
            this.txtMedicalTreatment.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::AIMSClient.Properties.Resources.psClose;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(332, 169);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errProv
            // 
            this.errProv.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProv.ContainerControl = this;
            // 
            // AddMedicalNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 197);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddMedicalTreatment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMedicalNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Medical Treatment";
            this.Load += new System.EventHandler(this.AddMedicalNote_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AddMedicalNote_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddMedicalTreatment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMedicalTreatment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSuppliers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboServices;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.LinkLabel lnklblDate;
        private System.Windows.Forms.TextBox txtDateofTreatment;
    }
}