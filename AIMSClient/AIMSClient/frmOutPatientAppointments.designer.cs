namespace AIMSClient
{
    partial class frmOutpatientAppointments
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblChemoCycleID = new System.Windows.Forms.Label();
            this.chkRadioTherapy = new System.Windows.Forms.CheckBox();
            this.chkChemoPlanned = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.txtCycleEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCycleStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstChemoTreatment = new System.Windows.Forms.ListView();
            this.errPatients = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.lblChemoCycleID);
            this.groupBox1.Controls.Add(this.chkRadioTherapy);
            this.groupBox1.Controls.Add(this.chkChemoPlanned);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAddFile);
            this.groupBox1.Controls.Add(this.txtCycleEndDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCycleStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstChemoTreatment);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Image = global::AIMSClient.Properties.Resources.refresh;
            this.btnReset.Location = new System.Drawing.Point(88, 88);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(35, 32);
            this.btnReset.TabIndex = 14;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblChemoCycleID
            // 
            this.lblChemoCycleID.AutoSize = true;
            this.lblChemoCycleID.Location = new System.Drawing.Point(300, 60);
            this.lblChemoCycleID.Name = "lblChemoCycleID";
            this.lblChemoCycleID.Size = new System.Drawing.Size(0, 13);
            this.lblChemoCycleID.TabIndex = 13;
            this.lblChemoCycleID.Visible = false;
            // 
            // chkRadioTherapy
            // 
            this.chkRadioTherapy.AutoSize = true;
            this.chkRadioTherapy.Location = new System.Drawing.Point(119, 56);
            this.chkRadioTherapy.Name = "chkRadioTherapy";
            this.chkRadioTherapy.Size = new System.Drawing.Size(96, 17);
            this.chkRadioTherapy.TabIndex = 12;
            this.chkRadioTherapy.Text = "Radio Therapy";
            this.chkRadioTherapy.UseVisualStyleBackColor = true;
            this.chkRadioTherapy.CheckedChanged += new System.EventHandler(this.chkRadioTherapy_CheckedChanged);
            // 
            // chkChemoPlanned
            // 
            this.chkChemoPlanned.AutoSize = true;
            this.chkChemoPlanned.Location = new System.Drawing.Point(12, 56);
            this.chkChemoPlanned.Name = "chkChemoPlanned";
            this.chkChemoPlanned.Size = new System.Drawing.Size(101, 17);
            this.chkChemoPlanned.TabIndex = 11;
            this.chkChemoPlanned.Text = "Chemo Planned";
            this.chkChemoPlanned.UseVisualStyleBackColor = true;
            this.chkChemoPlanned.CheckedChanged += new System.EventHandler(this.chkChemoPlanned_CheckedChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::AIMSClient.Properties.Resources.delete2;
            this.btnRemove.Location = new System.Drawing.Point(50, 88);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(35, 32);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFile.Image = global::AIMSClient.Properties.Resources.add_nexttoinput;
            this.btnAddFile.Location = new System.Drawing.Point(12, 88);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(35, 32);
            this.btnAddFile.TabIndex = 9;
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // txtCycleEndDate
            // 
            this.txtCycleEndDate.Location = new System.Drawing.Point(149, 30);
            this.txtCycleEndDate.Name = "txtCycleEndDate";
            this.txtCycleEndDate.ReadOnly = true;
            this.txtCycleEndDate.Size = new System.Drawing.Size(112, 20);
            this.txtCycleEndDate.TabIndex = 6;
            this.txtCycleEndDate.DoubleClick += new System.EventHandler(this.txtCycleEndDate_DoubleClick);
            this.txtCycleEndDate.TextChanged += new System.EventHandler(this.txtCycleEndDate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cycle End Date";
            // 
            // txtCycleStartDate
            // 
            this.txtCycleStartDate.Location = new System.Drawing.Point(12, 30);
            this.txtCycleStartDate.Name = "txtCycleStartDate";
            this.txtCycleStartDate.ReadOnly = true;
            this.txtCycleStartDate.Size = new System.Drawing.Size(112, 20);
            this.txtCycleStartDate.TabIndex = 4;
            this.txtCycleStartDate.DoubleClick += new System.EventHandler(this.txtCycleStartDate_DoubleClick);
            this.txtCycleStartDate.TextChanged += new System.EventHandler(this.txtCycleStartDate_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cycle Start Date";
            // 
            // lstChemoTreatment
            // 
            this.lstChemoTreatment.FullRowSelect = true;
            this.lstChemoTreatment.Location = new System.Drawing.Point(12, 126);
            this.lstChemoTreatment.MultiSelect = false;
            this.lstChemoTreatment.Name = "lstChemoTreatment";
            this.lstChemoTreatment.Size = new System.Drawing.Size(382, 170);
            this.lstChemoTreatment.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstChemoTreatment.TabIndex = 0;
            this.lstChemoTreatment.UseCompatibleStateImageBehavior = false;
            this.lstChemoTreatment.View = System.Windows.Forms.View.Details;
            this.lstChemoTreatment.SelectedIndexChanged += new System.EventHandler(this.lstChemoTreatment_SelectedIndexChanged);
            this.lstChemoTreatment.DoubleClick += new System.EventHandler(this.lstChemoTreatment_DoubleClick);
            // 
            // errPatients
            // 
            this.errPatients.ContainerControl = this;
            // 
            // frmOutpatientAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 314);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOutpatientAppointments";
            this.Text = "Chemo Schedule";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstChemoTreatment;
        private System.Windows.Forms.TextBox txtCycleEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCycleStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.CheckBox chkRadioTherapy;
        private System.Windows.Forms.CheckBox chkChemoPlanned;
        private System.Windows.Forms.ErrorProvider errPatients;
        private System.Windows.Forms.Label lblChemoCycleID;
        private System.Windows.Forms.Button btnReset;
    }
}