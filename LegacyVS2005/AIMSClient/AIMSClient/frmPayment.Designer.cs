namespace AIMSClient
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.tabPayment = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.btnLateSubmissionInvCheck = new System.Windows.Forms.Button();
            this.txtLateSubmissionInvNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDoctorInvoiceNo = new System.Windows.Forms.TextBox();
            this.chkLateSubmissionPymt = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPatientFileNo2 = new System.Windows.Forms.TextBox();
            this.chkDoctorOwing = new System.Windows.Forms.CheckBox();
            this.chkInsuranceShortPymt = new System.Windows.Forms.CheckBox();
            this.chkInsuranceOverPymt = new System.Windows.Forms.CheckBox();
            this.chkForex = new System.Windows.Forms.CheckBox();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.cboPatientFileNo = new System.Windows.Forms.ComboBox();
            this.lnklblReceiptDate = new System.Windows.Forms.LinkLabel();
            this.lnklblRenderDate = new System.Windows.Forms.LinkLabel();
            this.txtRenderDate = new System.Windows.Forms.TextBox();
            this.txtDateofReceipt = new System.Windows.Forms.TextBox();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.picValidate2 = new System.Windows.Forms.PictureBox();
            this.picValidate1 = new System.Windows.Forms.PictureBox();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.chkLockPayment = new System.Windows.Forms.CheckBox();
            this.infoText = new System.Windows.Forms.TextBox();
            this.btnInvoiceNoCheck = new System.Windows.Forms.Button();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPatientFileNoCheck = new System.Windows.Forms.Button();
            this.txtPatientFileNo = new System.Windows.Forms.TextBox();
            this.txtPaymentNotice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBankTransRefNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCreditCard = new System.Windows.Forms.TextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.txtPatientGuarantor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpxPaymentSearch = new System.Windows.Forms.GroupBox();
            this.pnlButtonSearch = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.gpxPayment = new System.Windows.Forms.GroupBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.aimsComboLookup1 = new AIMSUserControls.aimsComboLookup();
            this.tabPayment.SuspendLayout();
            this.tabDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picValidate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picValidate1)).BeginInit();
            this.gpxPaymentSearch.SuspendLayout();
            this.pnlButtonSearch.SuspendLayout();
            this.gpxPayment.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPayment
            // 
            this.tabPayment.Controls.Add(this.tabDetails);
            this.tabPayment.Location = new System.Drawing.Point(7, 19);
            this.tabPayment.Name = "tabPayment";
            this.tabPayment.SelectedIndex = 0;
            this.tabPayment.Size = new System.Drawing.Size(1069, 335);
            this.tabPayment.TabIndex = 0;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.btnLateSubmissionInvCheck);
            this.tabDetails.Controls.Add(this.txtLateSubmissionInvNo);
            this.tabDetails.Controls.Add(this.label13);
            this.tabDetails.Controls.Add(this.label10);
            this.tabDetails.Controls.Add(this.txtDoctorInvoiceNo);
            this.tabDetails.Controls.Add(this.chkLateSubmissionPymt);
            this.tabDetails.Controls.Add(this.button1);
            this.tabDetails.Controls.Add(this.txtPatientFileNo2);
            this.tabDetails.Controls.Add(this.chkDoctorOwing);
            this.tabDetails.Controls.Add(this.chkInsuranceShortPymt);
            this.tabDetails.Controls.Add(this.chkInsuranceOverPymt);
            this.tabDetails.Controls.Add(this.chkForex);
            this.tabDetails.Controls.Add(this.lblAmountPaid);
            this.tabDetails.Controls.Add(this.cboPatientFileNo);
            this.tabDetails.Controls.Add(this.lnklblReceiptDate);
            this.tabDetails.Controls.Add(this.lnklblRenderDate);
            this.tabDetails.Controls.Add(this.txtRenderDate);
            this.tabDetails.Controls.Add(this.txtDateofReceipt);
            this.tabDetails.Controls.Add(this.txtAmountPaid);
            this.tabDetails.Controls.Add(this.picValidate2);
            this.tabDetails.Controls.Add(this.picValidate1);
            this.tabDetails.Controls.Add(this.lblPaymentID);
            this.tabDetails.Controls.Add(this.chkLockPayment);
            this.tabDetails.Controls.Add(this.infoText);
            this.tabDetails.Controls.Add(this.btnInvoiceNoCheck);
            this.tabDetails.Controls.Add(this.txtInvoiceNo);
            this.tabDetails.Controls.Add(this.label12);
            this.tabDetails.Controls.Add(this.label5);
            this.tabDetails.Controls.Add(this.txtChequeNo);
            this.tabDetails.Controls.Add(this.label11);
            this.tabDetails.Controls.Add(this.label3);
            this.tabDetails.Controls.Add(this.cboPaymentMethod);
            this.tabDetails.Controls.Add(this.label9);
            this.tabDetails.Controls.Add(this.btnPatientFileNoCheck);
            this.tabDetails.Controls.Add(this.txtPatientFileNo);
            this.tabDetails.Controls.Add(this.txtPaymentNotice);
            this.tabDetails.Controls.Add(this.label8);
            this.tabDetails.Controls.Add(this.label7);
            this.tabDetails.Controls.Add(this.txtBankTransRefNo);
            this.tabDetails.Controls.Add(this.label6);
            this.tabDetails.Controls.Add(this.label2);
            this.tabDetails.Controls.Add(this.txtCreditCard);
            this.tabDetails.Controls.Add(this.txtReceiptNo);
            this.tabDetails.Controls.Add(this.txtPatientGuarantor);
            this.tabDetails.Controls.Add(this.label4);
            this.tabDetails.Controls.Add(this.label1);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(1061, 309);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Payment Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // btnLateSubmissionInvCheck
            // 
            this.btnLateSubmissionInvCheck.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLateSubmissionInvCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLateSubmissionInvCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLateSubmissionInvCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnLateSubmissionInvCheck.Image")));
            this.btnLateSubmissionInvCheck.Location = new System.Drawing.Point(815, 153);
            this.btnLateSubmissionInvCheck.Name = "btnLateSubmissionInvCheck";
            this.btnLateSubmissionInvCheck.Size = new System.Drawing.Size(32, 20);
            this.btnLateSubmissionInvCheck.TabIndex = 151;
            this.btnLateSubmissionInvCheck.UseVisualStyleBackColor = true;
            this.btnLateSubmissionInvCheck.Visible = false;
            // 
            // txtLateSubmissionInvNo
            // 
            this.txtLateSubmissionInvNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtLateSubmissionInvNo.Location = new System.Drawing.Point(668, 153);
            this.txtLateSubmissionInvNo.Name = "txtLateSubmissionInvNo";
            this.txtLateSubmissionInvNo.Size = new System.Drawing.Size(141, 20);
            this.txtLateSubmissionInvNo.TabIndex = 150;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(537, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 13);
            this.label13.TabIndex = 149;
            this.label13.Text = "Late Submission Inv. No.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(549, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 148;
            this.label10.Text = "Doctor Owing Inv. No.";
            // 
            // txtDoctorInvoiceNo
            // 
            this.txtDoctorInvoiceNo.Location = new System.Drawing.Point(668, 179);
            this.txtDoctorInvoiceNo.Name = "txtDoctorInvoiceNo";
            this.txtDoctorInvoiceNo.ReadOnly = true;
            this.txtDoctorInvoiceNo.Size = new System.Drawing.Size(141, 20);
            this.txtDoctorInvoiceNo.TabIndex = 147;
            // 
            // chkLateSubmissionPymt
            // 
            this.chkLateSubmissionPymt.AutoSize = true;
            this.chkLateSubmissionPymt.Location = new System.Drawing.Point(343, 100);
            this.chkLateSubmissionPymt.Name = "chkLateSubmissionPymt";
            this.chkLateSubmissionPymt.Size = new System.Drawing.Size(147, 17);
            this.chkLateSubmissionPymt.TabIndex = 146;
            this.chkLateSubmissionPymt.Text = "Late Submission Payment";
            this.chkLateSubmissionPymt.UseVisualStyleBackColor = true;
            this.chkLateSubmissionPymt.CheckedChanged += new System.EventHandler(this.chkLateSubmissionPymt_CheckedChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(959, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 145;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // txtPatientFileNo2
            // 
            this.txtPatientFileNo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientFileNo2.Location = new System.Drawing.Point(870, 72);
            this.txtPatientFileNo2.Name = "txtPatientFileNo2";
            this.txtPatientFileNo2.Size = new System.Drawing.Size(144, 22);
            this.txtPatientFileNo2.TabIndex = 144;
            this.txtPatientFileNo2.Visible = false;
            // 
            // chkDoctorOwing
            // 
            this.chkDoctorOwing.AutoSize = true;
            this.chkDoctorOwing.Location = new System.Drawing.Point(496, 100);
            this.chkDoctorOwing.Name = "chkDoctorOwing";
            this.chkDoctorOwing.Size = new System.Drawing.Size(135, 17);
            this.chkDoctorOwing.TabIndex = 143;
            this.chkDoctorOwing.Text = "Doctor Owing Payment";
            this.chkDoctorOwing.UseVisualStyleBackColor = true;
            this.chkDoctorOwing.CheckedChanged += new System.EventHandler(this.chkDoctorOwing_CheckedChanged);
            // 
            // chkInsuranceShortPymt
            // 
            this.chkInsuranceShortPymt.AutoSize = true;
            this.chkInsuranceShortPymt.Location = new System.Drawing.Point(637, 100);
            this.chkInsuranceShortPymt.Name = "chkInsuranceShortPymt";
            this.chkInsuranceShortPymt.Size = new System.Drawing.Size(95, 17);
            this.chkInsuranceShortPymt.TabIndex = 142;
            this.chkInsuranceShortPymt.Text = "Short Payment";
            this.chkInsuranceShortPymt.UseVisualStyleBackColor = true;
            this.chkInsuranceShortPymt.CheckedChanged += new System.EventHandler(this.chkInsuranceShortPymt_CheckedChanged);
            // 
            // chkInsuranceOverPymt
            // 
            this.chkInsuranceOverPymt.AutoSize = true;
            this.chkInsuranceOverPymt.Location = new System.Drawing.Point(244, 100);
            this.chkInsuranceOverPymt.Name = "chkInsuranceOverPymt";
            this.chkInsuranceOverPymt.Size = new System.Drawing.Size(93, 17);
            this.chkInsuranceOverPymt.TabIndex = 141;
            this.chkInsuranceOverPymt.Text = "Over Payment";
            this.chkInsuranceOverPymt.UseVisualStyleBackColor = true;
            this.chkInsuranceOverPymt.CheckedChanged += new System.EventHandler(this.chkInsuranceOverPymt_CheckedChanged);
            // 
            // chkForex
            // 
            this.chkForex.AutoSize = true;
            this.chkForex.Location = new System.Drawing.Point(143, 100);
            this.chkForex.Name = "chkForex";
            this.chkForex.Size = new System.Drawing.Size(95, 17);
            this.chkForex.TabIndex = 140;
            this.chkForex.Text = "Forex payment";
            this.chkForex.UseVisualStyleBackColor = true;
            this.chkForex.CheckedChanged += new System.EventHandler(this.chkForex_CheckedChanged);
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaid.ForeColor = System.Drawing.Color.Red;
            this.lblAmountPaid.Location = new System.Drawing.Point(308, 130);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(0, 13);
            this.lblAmountPaid.TabIndex = 139;
            // 
            // cboPatientFileNo
            // 
            this.cboPatientFileNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatientFileNo.FormattingEnabled = true;
            this.cboPatientFileNo.Location = new System.Drawing.Point(143, 14);
            this.cboPatientFileNo.Name = "cboPatientFileNo";
            this.cboPatientFileNo.Size = new System.Drawing.Size(387, 21);
            this.cboPatientFileNo.Sorted = true;
            this.cboPatientFileNo.TabIndex = 129;
            this.cboPatientFileNo.SelectedIndexChanged += new System.EventHandler(this.cboPatientFileNo_SelectedIndexChanged);
            // 
            // lnklblReceiptDate
            // 
            this.lnklblReceiptDate.AutoSize = true;
            this.lnklblReceiptDate.Location = new System.Drawing.Point(15, 182);
            this.lnklblReceiptDate.Name = "lnklblReceiptDate";
            this.lnklblReceiptDate.Size = new System.Drawing.Size(82, 13);
            this.lnklblReceiptDate.TabIndex = 128;
            this.lnklblReceiptDate.TabStop = true;
            this.lnklblReceiptDate.Text = "Date of Receipt";
            this.lnklblReceiptDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblReceiptDate_LinkClicked);
            // 
            // lnklblRenderDate
            // 
            this.lnklblRenderDate.AutoSize = true;
            this.lnklblRenderDate.Location = new System.Drawing.Point(580, 243);
            this.lnklblRenderDate.Name = "lnklblRenderDate";
            this.lnklblRenderDate.Size = new System.Drawing.Size(68, 13);
            this.lnklblRenderDate.TabIndex = 127;
            this.lnklblRenderDate.TabStop = true;
            this.lnklblRenderDate.Text = "Render Date";
            this.lnklblRenderDate.Visible = false;
            this.lnklblRenderDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblRenderDate_LinkClicked);
            // 
            // txtRenderDate
            // 
            this.txtRenderDate.Location = new System.Drawing.Point(708, 236);
            this.txtRenderDate.Name = "txtRenderDate";
            this.txtRenderDate.Size = new System.Drawing.Size(139, 20);
            this.txtRenderDate.TabIndex = 126;
            this.txtRenderDate.Visible = false;
            this.txtRenderDate.DoubleClick += new System.EventHandler(this.txtRenderDate_DoubleClick);
            // 
            // txtDateofReceipt
            // 
            this.txtDateofReceipt.Enabled = false;
            this.txtDateofReceipt.Location = new System.Drawing.Point(143, 179);
            this.txtDateofReceipt.Name = "txtDateofReceipt";
            this.txtDateofReceipt.ReadOnly = true;
            this.txtDateofReceipt.Size = new System.Drawing.Size(159, 20);
            this.txtDateofReceipt.TabIndex = 133;
            this.txtDateofReceipt.DoubleClick += new System.EventHandler(this.txtDateofReceipt_DoubleClick);
            this.txtDateofReceipt.TextChanged += new System.EventHandler(this.txtDateofReceipt_TextChanged);
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Location = new System.Drawing.Point(143, 127);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(159, 20);
            this.txtAmountPaid.TabIndex = 131;
            this.txtAmountPaid.TextChanged += new System.EventHandler(this.txtAmountPaid_TextChanged);
            this.txtAmountPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmountPaid_KeyPress);
            // 
            // picValidate2
            // 
            this.picValidate2.Image = ((System.Drawing.Image)(resources.GetObject("picValidate2.Image")));
            this.picValidate2.Location = new System.Drawing.Point(616, 280);
            this.picValidate2.Name = "picValidate2";
            this.picValidate2.Size = new System.Drawing.Size(23, 23);
            this.picValidate2.TabIndex = 121;
            this.picValidate2.TabStop = false;
            this.picValidate2.Visible = false;
            // 
            // picValidate1
            // 
            this.picValidate1.Image = ((System.Drawing.Image)(resources.GetObject("picValidate1.Image")));
            this.picValidate1.Location = new System.Drawing.Point(870, 217);
            this.picValidate1.Name = "picValidate1";
            this.picValidate1.Size = new System.Drawing.Size(23, 25);
            this.picValidate1.TabIndex = 120;
            this.picValidate1.TabStop = false;
            this.picValidate1.Visible = false;
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.AutoSize = true;
            this.lblPaymentID.Location = new System.Drawing.Point(717, 197);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Size = new System.Drawing.Size(0, 13);
            this.lblPaymentID.TabIndex = 119;
            this.lblPaymentID.Visible = false;
            // 
            // chkLockPayment
            // 
            this.chkLockPayment.AutoSize = true;
            this.chkLockPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkLockPayment.Location = new System.Drawing.Point(870, 46);
            this.chkLockPayment.Name = "chkLockPayment";
            this.chkLockPayment.Size = new System.Drawing.Size(94, 17);
            this.chkLockPayment.TabIndex = 14;
            this.chkLockPayment.Text = "Lock Payment";
            this.chkLockPayment.UseVisualStyleBackColor = true;
            this.chkLockPayment.Visible = false;
            // 
            // infoText
            // 
            this.infoText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.infoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoText.ForeColor = System.Drawing.Color.MediumBlue;
            this.infoText.Location = new System.Drawing.Point(568, 224);
            this.infoText.Name = "infoText";
            this.infoText.ReadOnly = true;
            this.infoText.Size = new System.Drawing.Size(279, 20);
            this.infoText.TabIndex = 117;
            this.infoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.infoText.Visible = false;
            // 
            // btnInvoiceNoCheck
            // 
            this.btnInvoiceNoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoiceNoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInvoiceNoCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnInvoiceNoCheck.Image")));
            this.btnInvoiceNoCheck.Location = new System.Drawing.Point(645, 280);
            this.btnInvoiceNoCheck.Name = "btnInvoiceNoCheck";
            this.btnInvoiceNoCheck.Size = new System.Drawing.Size(41, 23);
            this.btnInvoiceNoCheck.TabIndex = 6;
            this.btnInvoiceNoCheck.UseVisualStyleBackColor = true;
            this.btnInvoiceNoCheck.Visible = false;
            this.btnInvoiceNoCheck.Click += new System.EventHandler(this.btnInvoiceNoCheck_Click);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(708, 262);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(293, 20);
            this.txtInvoiceNo.TabIndex = 5;
            this.txtInvoiceNo.Visible = false;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            this.txtInvoiceNo.LostFocus += new System.EventHandler(this.txtInvoiceNo_LostFocus);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(580, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 100;
            this.label12.Text = "Invoice No";
            this.label12.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Cheque No";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(143, 232);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(387, 20);
            this.txtChequeNo.TabIndex = 135;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 96;
            this.label11.Text = "Guarantor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "Payment Method";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(143, 205);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(387, 21);
            this.cboPaymentMethod.TabIndex = 134;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "Patient File No";
            // 
            // btnPatientFileNoCheck
            // 
            this.btnPatientFileNoCheck.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPatientFileNoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientFileNoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientFileNoCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnPatientFileNoCheck.Image")));
            this.btnPatientFileNoCheck.Location = new System.Drawing.Point(301, 40);
            this.btnPatientFileNoCheck.Name = "btnPatientFileNoCheck";
            this.btnPatientFileNoCheck.Size = new System.Drawing.Size(41, 23);
            this.btnPatientFileNoCheck.TabIndex = 4;
            this.btnPatientFileNoCheck.UseVisualStyleBackColor = true;
            this.btnPatientFileNoCheck.Click += new System.EventHandler(this.btnPatientFileNoCheck_Click);
            // 
            // txtPatientFileNo
            // 
            this.txtPatientFileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientFileNo.Location = new System.Drawing.Point(143, 41);
            this.txtPatientFileNo.Name = "txtPatientFileNo";
            this.txtPatientFileNo.Size = new System.Drawing.Size(152, 22);
            this.txtPatientFileNo.TabIndex = 3;
            this.txtPatientFileNo.TextChanged += new System.EventHandler(this.txtPatientFileNo_TextChanged);
            this.txtPatientFileNo.LostFocus += new System.EventHandler(this.txtPatientFileNo_LostFocus);
            // 
            // txtPaymentNotice
            // 
            this.txtPaymentNotice.Location = new System.Drawing.Point(668, 205);
            this.txtPaymentNotice.Multiline = true;
            this.txtPaymentNotice.Name = "txtPaymentNotice";
            this.txtPaymentNotice.Size = new System.Drawing.Size(253, 99);
            this.txtPaymentNotice.TabIndex = 138;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(580, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Payment Notice";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Bank Transfer Reference";
            // 
            // txtBankTransRefNo
            // 
            this.txtBankTransRefNo.Location = new System.Drawing.Point(143, 284);
            this.txtBankTransRefNo.Name = "txtBankTransRefNo";
            this.txtBankTransRefNo.Size = new System.Drawing.Size(387, 20);
            this.txtBankTransRefNo.TabIndex = 137;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Credit Card No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Amount Paid";
            // 
            // txtCreditCard
            // 
            this.txtCreditCard.Location = new System.Drawing.Point(143, 258);
            this.txtCreditCard.Name = "txtCreditCard";
            this.txtCreditCard.Size = new System.Drawing.Size(387, 20);
            this.txtCreditCard.TabIndex = 136;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(143, 153);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(159, 20);
            this.txtReceiptNo.TabIndex = 132;
            // 
            // txtPatientGuarantor
            // 
            this.txtPatientGuarantor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientGuarantor.Location = new System.Drawing.Point(143, 73);
            this.txtPatientGuarantor.Name = "txtPatientGuarantor";
            this.txtPatientGuarantor.ReadOnly = true;
            this.txtPatientGuarantor.Size = new System.Drawing.Size(387, 21);
            this.txtPatientGuarantor.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receipt Number";
            // 
            // gpxPaymentSearch
            // 
            this.gpxPaymentSearch.BackColor = System.Drawing.Color.Transparent;
            this.gpxPaymentSearch.Controls.Add(this.pnlButtonSearch);
            this.gpxPaymentSearch.Controls.Add(this.aimsComboLookup1);
            this.gpxPaymentSearch.Location = new System.Drawing.Point(6, 3);
            this.gpxPaymentSearch.Name = "gpxPaymentSearch";
            this.gpxPaymentSearch.Size = new System.Drawing.Size(1078, 213);
            this.gpxPaymentSearch.TabIndex = 4;
            this.gpxPaymentSearch.TabStop = false;
            this.gpxPaymentSearch.Text = "Payment Search";
            this.gpxPaymentSearch.Enter += new System.EventHandler(this.gpxPaymentSearch_Enter);
            // 
            // pnlButtonSearch
            // 
            this.pnlButtonSearch.Controls.Add(this.btnRefresh);
            this.pnlButtonSearch.Controls.Add(this.btnDelete);
            this.pnlButtonSearch.Controls.Add(this.btnAdd);
            this.pnlButtonSearch.Controls.Add(this.btnSelect);
            this.pnlButtonSearch.Location = new System.Drawing.Point(15, 157);
            this.pnlButtonSearch.Name = "pnlButtonSearch";
            this.pnlButtonSearch.Size = new System.Drawing.Size(364, 27);
            this.pnlButtonSearch.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(212, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 23);
            this.btnRefresh.TabIndex = 142;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::AIMSClient.Properties.Resources.psCancel;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(261, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(131, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 23);
            this.btnAdd.TabIndex = 141;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(0, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(110, 23);
            this.btnSelect.TabIndex = 140;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // gpxPayment
            // 
            this.gpxPayment.BackColor = System.Drawing.Color.Transparent;
            this.gpxPayment.Controls.Add(this.tabPayment);
            this.gpxPayment.Location = new System.Drawing.Point(2, 225);
            this.gpxPayment.Name = "gpxPayment";
            this.gpxPayment.Size = new System.Drawing.Size(1082, 358);
            this.gpxPayment.TabIndex = 5;
            this.gpxPayment.TabStop = false;
            this.gpxPayment.Text = "Payment";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Location = new System.Drawing.Point(12, 599);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(884, 28);
            this.pnlButtons.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::AIMSClient.Properties.Resources.psClose;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(463, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::AIMSClient.Properties.Resources.psSave;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(298, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 139;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errProv
            // 
            this.errProv.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProv.ContainerControl = this;
            // 
            // aimsComboLookup1
            // 
            this.aimsComboLookup1.AIMSDataTbl = null;
            this.aimsComboLookup1.DataField1 = null;
            this.aimsComboLookup1.DataField2 = null;
            this.aimsComboLookup1.Field1Value = "Receipt No";
            this.aimsComboLookup1.Field2Value = null;
            this.aimsComboLookup1.ItemsLoaded = 0;
            this.aimsComboLookup1.Location = new System.Drawing.Point(7, 9);
            this.aimsComboLookup1.Name = "aimsComboLookup1";
            this.aimsComboLookup1.OrderByField = null;
            this.aimsComboLookup1.ShowButtons = true;
            this.aimsComboLookup1.ShowButtonTwo = false;
            this.aimsComboLookup1.Size = new System.Drawing.Size(277, 157);
            this.aimsComboLookup1.TabIndex = 128;
            this.aimsComboLookup1.TableName = null;
            this.aimsComboLookup1.DblClicked += new AIMSUserControls.aimsComboLookup.DblClickHandler(this.aimsComboLookup1_DblClicked);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 659);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.gpxPaymentSearch);
            this.Controls.Add(this.gpxPayment);
            this.Name = "frmPayment";
            this.Text = "Payments Received";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPayment_Paint);
            this.Resize += new System.EventHandler(this.frmPayment_Resize);
            this.tabPayment.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picValidate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picValidate1)).EndInit();
            this.gpxPaymentSearch.ResumeLayout(false);
            this.pnlButtonSearch.ResumeLayout(false);
            this.gpxPayment.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPayment;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TextBox txtCreditCard;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.TextBox txtPatientGuarantor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpxPaymentSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSelect;
        private AIMSUserControls.aimsComboLookup aimsComboLookup1;
        private System.Windows.Forms.GroupBox gpxPayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBankTransRefNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPaymentNotice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlButtonSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPatientFileNoCheck;
        private System.Windows.Forms.TextBox txtPatientFileNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Button btnInvoiceNoCheck;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox infoText;
        private System.Windows.Forms.CheckBox chkLockPayment;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.PictureBox picValidate1;
        private System.Windows.Forms.PictureBox picValidate2;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.TextBox txtRenderDate;
        private System.Windows.Forms.TextBox txtDateofReceipt;
        private System.Windows.Forms.LinkLabel lnklblReceiptDate;
        private System.Windows.Forms.LinkLabel lnklblRenderDate;
        private System.Windows.Forms.ComboBox cboPatientFileNo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.CheckBox chkInsuranceShortPymt;
        private System.Windows.Forms.CheckBox chkInsuranceOverPymt;
        private System.Windows.Forms.CheckBox chkForex;
        private System.Windows.Forms.CheckBox chkDoctorOwing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPatientFileNo2;
        private System.Windows.Forms.CheckBox chkLateSubmissionPymt;
        private System.Windows.Forms.TextBox txtDoctorInvoiceNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLateSubmissionInvNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLateSubmissionInvCheck;
    }
}