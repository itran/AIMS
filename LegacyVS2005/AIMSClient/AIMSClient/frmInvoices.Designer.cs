namespace AIMSClient
{
    partial class frmInvoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoices));
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.txtWaybillNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lnkLateInvSentDate = new System.Windows.Forms.LinkLabel();
            this.txtLateInvoiceSentDate = new System.Windows.Forms.TextBox();
            this.chkLateInvoiceSent = new System.Windows.Forms.CheckBox();
            this.chkDoctorOwing = new System.Windows.Forms.CheckBox();
            this.txtInfoText = new System.Windows.Forms.TextBox();
            this.chkCancel = new System.Windows.Forms.CheckBox();
            this.lblInvAmountReceived = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboPatientFileNo = new System.Windows.Forms.ComboBox();
            this.txtInvoiceAmountold = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.txtInvoiceAmount = new System.Windows.Forms.TextBox();
            this.picValidate1 = new System.Windows.Forms.PictureBox();
            this.lnklblInvDate = new System.Windows.Forms.LinkLabel();
            this.txtInvoiceDate = new System.Windows.Forms.TextBox();
            this.infoText = new System.Windows.Forms.TextBox();
            this.infoText1 = new UserControls.InfoTextBox();
            this.chkLockInvoice = new System.Windows.Forms.CheckBox();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnRemoveMedicalTreatment = new System.Windows.Forms.Button();
            this.lstVwMedicalTreatments = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.InvoiceTreatmentID = new System.Windows.Forms.ColumnHeader();
            this.btnAddNewTreatment = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.chkLateInvoice = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInvoiceAmount1 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPatientFileNoCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtPatientFileNo = new System.Windows.Forms.TextBox();
            this.txtSupplierInvNo = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dtInvoiceDispatchDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cboMedicalTreatment = new System.Windows.Forms.ComboBox();
            this.chkInvoiceDispatch = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDateDischarged = new System.Windows.Forms.DateTimePicker();
            this.dtDateAdmitted = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.gpxInvoiceSearch = new System.Windows.Forms.GroupBox();
            this.pnlSearchButtons = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.gpxInvoice = new System.Windows.Forms.GroupBox();
            this.tabInvoices = new System.Windows.Forms.TabControl();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnUnlockInvoice = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.aimsComboLookup1 = new AIMSUserControls.aimsComboLookup();
            this.tabDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picValidate1)).BeginInit();
            this.gpxInvoiceSearch.SuspendLayout();
            this.pnlSearchButtons.SuspendLayout();
            this.gpxInvoice.SuspendLayout();
            this.tabInvoices.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(131, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.txtWaybillNo);
            this.tabDetails.Controls.Add(this.label14);
            this.tabDetails.Controls.Add(this.lnkLateInvSentDate);
            this.tabDetails.Controls.Add(this.txtLateInvoiceSentDate);
            this.tabDetails.Controls.Add(this.chkLateInvoiceSent);
            this.tabDetails.Controls.Add(this.chkDoctorOwing);
            this.tabDetails.Controls.Add(this.txtInfoText);
            this.tabDetails.Controls.Add(this.chkCancel);
            this.tabDetails.Controls.Add(this.lblInvAmountReceived);
            this.tabDetails.Controls.Add(this.label13);
            this.tabDetails.Controls.Add(this.cboPatientFileNo);
            this.tabDetails.Controls.Add(this.txtInvoiceAmountold);
            this.tabDetails.Controls.Add(this.label8);
            this.tabDetails.Controls.Add(this.cboService);
            this.tabDetails.Controls.Add(this.txtInvoiceAmount);
            this.tabDetails.Controls.Add(this.picValidate1);
            this.tabDetails.Controls.Add(this.lnklblInvDate);
            this.tabDetails.Controls.Add(this.txtInvoiceDate);
            this.tabDetails.Controls.Add(this.infoText);
            this.tabDetails.Controls.Add(this.infoText1);
            this.tabDetails.Controls.Add(this.chkLockInvoice);
            this.tabDetails.Controls.Add(this.lblInvoiceID);
            this.tabDetails.Controls.Add(this.txtStatus);
            this.tabDetails.Controls.Add(this.btnRemoveMedicalTreatment);
            this.tabDetails.Controls.Add(this.lstVwMedicalTreatments);
            this.tabDetails.Controls.Add(this.btnAddNewTreatment);
            this.tabDetails.Controls.Add(this.label12);
            this.tabDetails.Controls.Add(this.chkLateInvoice);
            this.tabDetails.Controls.Add(this.label10);
            this.tabDetails.Controls.Add(this.txtInvoiceAmount1);
            this.tabDetails.Controls.Add(this.label9);
            this.tabDetails.Controls.Add(this.label6);
            this.tabDetails.Controls.Add(this.cboSupplier);
            this.tabDetails.Controls.Add(this.txtPatientName);
            this.tabDetails.Controls.Add(this.label5);
            this.tabDetails.Controls.Add(this.btnPatientFileNoCheck);
            this.tabDetails.Controls.Add(this.label2);
            this.tabDetails.Controls.Add(this.label1);
            this.tabDetails.Controls.Add(this.label4);
            this.tabDetails.Controls.Add(this.txtInvoiceNo);
            this.tabDetails.Controls.Add(this.txtPatientFileNo);
            this.tabDetails.Controls.Add(this.txtSupplierInvNo);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(898, 414);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // txtWaybillNo
            // 
            this.txtWaybillNo.ForeColor = System.Drawing.Color.Black;
            this.txtWaybillNo.Location = new System.Drawing.Point(342, 280);
            this.txtWaybillNo.MaxLength = 50;
            this.txtWaybillNo.Name = "txtWaybillNo";
            this.txtWaybillNo.Size = new System.Drawing.Size(266, 20);
            this.txtWaybillNo.TabIndex = 148;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(278, 283);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 112;
            this.label14.Text = "Waybill No";
            // 
            // lnkLateInvSentDate
            // 
            this.lnkLateInvSentDate.AutoSize = true;
            this.lnkLateInvSentDate.Location = new System.Drawing.Point(6, 283);
            this.lnkLateInvSentDate.Name = "lnkLateInvSentDate";
            this.lnkLateInvSentDate.Size = new System.Drawing.Size(115, 13);
            this.lnkLateInvSentDate.TabIndex = 147;
            this.lnkLateInvSentDate.TabStop = true;
            this.lnkLateInvSentDate.Text = "Late Invoice Sent date";
            this.lnkLateInvSentDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLateInvSentDate_LinkClicked);
            // 
            // txtLateInvoiceSentDate
            // 
            this.txtLateInvoiceSentDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtLateInvoiceSentDate.Location = new System.Drawing.Point(144, 280);
            this.txtLateInvoiceSentDate.Name = "txtLateInvoiceSentDate";
            this.txtLateInvoiceSentDate.ReadOnly = true;
            this.txtLateInvoiceSentDate.Size = new System.Drawing.Size(128, 20);
            this.txtLateInvoiceSentDate.TabIndex = 146;
            this.txtLateInvoiceSentDate.DoubleClick += new System.EventHandler(this.txtLateInvoiceSentDate_DoubleClick);
            this.txtLateInvoiceSentDate.TextChanged += new System.EventHandler(this.txtLateInvoiceSentDate_TextChanged);
            // 
            // chkLateInvoiceSent
            // 
            this.chkLateInvoiceSent.AutoSize = true;
            this.chkLateInvoiceSent.BackColor = System.Drawing.Color.Transparent;
            this.chkLateInvoiceSent.Location = new System.Drawing.Point(144, 257);
            this.chkLateInvoiceSent.Name = "chkLateInvoiceSent";
            this.chkLateInvoiceSent.Size = new System.Drawing.Size(110, 17);
            this.chkLateInvoiceSent.TabIndex = 145;
            this.chkLateInvoiceSent.Text = "Late Invoice Sent";
            this.chkLateInvoiceSent.UseVisualStyleBackColor = false;
            this.chkLateInvoiceSent.CheckedChanged += new System.EventHandler(this.chkLateInvoiceSent_CheckedChanged);
            // 
            // chkDoctorOwing
            // 
            this.chkDoctorOwing.AutoSize = true;
            this.chkDoctorOwing.Location = new System.Drawing.Point(377, 234);
            this.chkDoctorOwing.Name = "chkDoctorOwing";
            this.chkDoctorOwing.Size = new System.Drawing.Size(91, 17);
            this.chkDoctorOwing.TabIndex = 144;
            this.chkDoctorOwing.Text = "Doctor Owing";
            this.chkDoctorOwing.UseVisualStyleBackColor = true;
            this.chkDoctorOwing.CheckedChanged += new System.EventHandler(this.chkDoctorOwing_CheckedChanged);
            // 
            // txtInfoText
            // 
            this.txtInfoText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtInfoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoText.Location = new System.Drawing.Point(132, 308);
            this.txtInfoText.Name = "txtInfoText";
            this.txtInfoText.Size = new System.Drawing.Size(462, 22);
            this.txtInfoText.TabIndex = 137;
            this.txtInfoText.Text = " ";
            this.txtInfoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInfoText.Visible = false;
            // 
            // chkCancel
            // 
            this.chkCancel.AutoSize = true;
            this.chkCancel.Location = new System.Drawing.Point(260, 234);
            this.chkCancel.Name = "chkCancel";
            this.chkCancel.Size = new System.Drawing.Size(111, 17);
            this.chkCancel.TabIndex = 136;
            this.chkCancel.Text = "Invoice Cancelled";
            this.chkCancel.UseVisualStyleBackColor = true;
            // 
            // lblInvAmountReceived
            // 
            this.lblInvAmountReceived.AutoSize = true;
            this.lblInvAmountReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvAmountReceived.ForeColor = System.Drawing.Color.Red;
            this.lblInvAmountReceived.Location = new System.Drawing.Point(278, 157);
            this.lblInvAmountReceived.Name = "lblInvAmountReceived";
            this.lblInvAmountReceived.Size = new System.Drawing.Size(0, 13);
            this.lblInvAmountReceived.TabIndex = 135;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(278, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 129;
            // 
            // cboPatientFileNo
            // 
            this.cboPatientFileNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatientFileNo.FormattingEnabled = true;
            this.cboPatientFileNo.Location = new System.Drawing.Point(144, 13);
            this.cboPatientFileNo.Name = "cboPatientFileNo";
            this.cboPatientFileNo.Size = new System.Drawing.Size(227, 21);
            this.cboPatientFileNo.Sorted = true;
            this.cboPatientFileNo.TabIndex = 128;
            this.cboPatientFileNo.SelectedIndexChanged += new System.EventHandler(this.cboPatientFileNo_SelectedIndexChanged);
            this.cboPatientFileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPatientFileNo_KeyDown);
            // 
            // txtInvoiceAmountold
            // 
            this.txtInvoiceAmountold.Location = new System.Drawing.Point(684, 124);
            this.txtInvoiceAmountold.Mask = "00000000";
            this.txtInvoiceAmountold.Name = "txtInvoiceAmountold";
            this.txtInvoiceAmountold.Size = new System.Drawing.Size(124, 20);
            this.txtInvoiceAmountold.TabIndex = 127;
            this.txtInvoiceAmountold.Visible = false;
            this.txtInvoiceAmountold.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtInvoiceAmountold_MaskInputRejected);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 126;
            this.label8.Text = "Service";
            // 
            // cboService
            // 
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(144, 207);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(464, 21);
            this.cboService.Sorted = true;
            this.cboService.TabIndex = 134;
            this.cboService.SelectedIndexChanged += new System.EventHandler(this.cboService_SelectedIndexChanged);
            this.cboService.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboService_KeyDown);
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.Location = new System.Drawing.Point(144, 154);
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Size = new System.Drawing.Size(128, 20);
            this.txtInvoiceAmount.TabIndex = 132;
            this.txtInvoiceAmount.TextChanged += new System.EventHandler(this.txtInvoiceAmount_TextChanged);
            this.txtInvoiceAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceAmount_KeyDown);
            this.txtInvoiceAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CurrencyTextBox_KeyPress);
            // 
            // picValidate1
            // 
            this.picValidate1.Image = ((System.Drawing.Image)(resources.GetObject("picValidate1.Image")));
            this.picValidate1.Location = new System.Drawing.Point(377, 12);
            this.picValidate1.Name = "picValidate1";
            this.picValidate1.Size = new System.Drawing.Size(23, 24);
            this.picValidate1.TabIndex = 122;
            this.picValidate1.TabStop = false;
            this.picValidate1.Visible = false;
            // 
            // lnklblInvDate
            // 
            this.lnklblInvDate.AutoSize = true;
            this.lnklblInvDate.Location = new System.Drawing.Point(6, 131);
            this.lnklblInvDate.Name = "lnklblInvDate";
            this.lnklblInvDate.Size = new System.Drawing.Size(68, 13);
            this.lnklblInvDate.TabIndex = 121;
            this.lnklblInvDate.TabStop = true;
            this.lnklblInvDate.Text = "Invoice Date";
            this.lnklblInvDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblInvDate_LinkClicked);
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.Location = new System.Drawing.Point(144, 128);
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.ReadOnly = true;
            this.txtInvoiceDate.Size = new System.Drawing.Size(128, 20);
            this.txtInvoiceDate.TabIndex = 131;
            this.txtInvoiceDate.DoubleClick += new System.EventHandler(this.txtInvoiceDate_DoubleClick);
            this.txtInvoiceDate.TextChanged += new System.EventHandler(this.txtInvoiceDate_TextChanged);
            this.txtInvoiceDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceDate_KeyDown);
            // 
            // infoText
            // 
            this.infoText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.infoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoText.Enabled = false;
            this.infoText.ForeColor = System.Drawing.Color.MediumBlue;
            this.infoText.Location = new System.Drawing.Point(682, 153);
            this.infoText.Name = "infoText";
            this.infoText.ReadOnly = true;
            this.infoText.Size = new System.Drawing.Size(172, 20);
            this.infoText.TabIndex = 116;
            this.infoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.infoText.Visible = false;
            this.infoText.WordWrap = false;
            // 
            // infoText1
            // 
            this.infoText1.InfoBoxLineCount = 0;
            this.infoText1.Location = new System.Drawing.Point(635, 238);
            this.infoText1.Name = "infoText1";
            this.infoText1.Size = new System.Drawing.Size(219, 23);
            this.infoText1.TabIndex = 115;
            this.infoText1.Text = "Invoice Status: ";
            this.infoText1.Visible = false;
            // 
            // chkLockInvoice
            // 
            this.chkLockInvoice.AutoSize = true;
            this.chkLockInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkLockInvoice.Location = new System.Drawing.Point(555, 336);
            this.chkLockInvoice.Name = "chkLockInvoice";
            this.chkLockInvoice.Size = new System.Drawing.Size(88, 17);
            this.chkLockInvoice.TabIndex = 10;
            this.chkLockInvoice.Text = "Lock Invoice";
            this.chkLockInvoice.UseVisualStyleBackColor = true;
            this.chkLockInvoice.Visible = false;
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Location = new System.Drawing.Point(751, 355);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(53, 13);
            this.lblInvoiceID.TabIndex = 113;
            this.lblInvoiceID.Text = "InvoiceID";
            this.lblInvoiceID.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(800, 305);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(33, 20);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.Visible = false;
            // 
            // btnRemoveMedicalTreatment
            // 
            this.btnRemoveMedicalTreatment.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveMedicalTreatment.Image")));
            this.btnRemoveMedicalTreatment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveMedicalTreatment.Location = new System.Drawing.Point(417, 374);
            this.btnRemoveMedicalTreatment.Name = "btnRemoveMedicalTreatment";
            this.btnRemoveMedicalTreatment.Size = new System.Drawing.Size(195, 23);
            this.btnRemoveMedicalTreatment.TabIndex = 8;
            this.btnRemoveMedicalTreatment.Text = "Remove Medical Treatment";
            this.btnRemoveMedicalTreatment.UseVisualStyleBackColor = true;
            this.btnRemoveMedicalTreatment.Visible = false;
            this.btnRemoveMedicalTreatment.Click += new System.EventHandler(this.btnRemoveMedicalTreatment_Click);
            // 
            // lstVwMedicalTreatments
            // 
            this.lstVwMedicalTreatments.CheckBoxes = true;
            this.lstVwMedicalTreatments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.InvoiceTreatmentID});
            this.lstVwMedicalTreatments.FullRowSelect = true;
            this.lstVwMedicalTreatments.GridLines = true;
            this.lstVwMedicalTreatments.HoverSelection = true;
            this.lstVwMedicalTreatments.Location = new System.Drawing.Point(166, 347);
            this.lstVwMedicalTreatments.MultiSelect = false;
            this.lstVwMedicalTreatments.Name = "lstVwMedicalTreatments";
            this.lstVwMedicalTreatments.Size = new System.Drawing.Size(462, 21);
            this.lstVwMedicalTreatments.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstVwMedicalTreatments.TabIndex = 111;
            this.lstVwMedicalTreatments.UseCompatibleStateImageBehavior = false;
            this.lstVwMedicalTreatments.View = System.Windows.Forms.View.Details;
            this.lstVwMedicalTreatments.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 2;
            this.columnHeader1.Text = "Supplier";
            this.columnHeader1.Width = 148;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Service Rendered";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "Medical Treatment";
            this.columnHeader2.Width = 200;
            // 
            // btnAddNewTreatment
            // 
            this.btnAddNewTreatment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewTreatment.ImageKey = "(none)";
            this.btnAddNewTreatment.Location = new System.Drawing.Point(243, 374);
            this.btnAddNewTreatment.Name = "btnAddNewTreatment";
            this.btnAddNewTreatment.Size = new System.Drawing.Size(184, 23);
            this.btnAddNewTreatment.TabIndex = 7;
            this.btnAddNewTreatment.Text = "Add Medical Treatment";
            this.btnAddNewTreatment.UseVisualStyleBackColor = true;
            this.btnAddNewTreatment.Visible = false;
            this.btnAddNewTreatment.Click += new System.EventHandler(this.btnAddNewTreatment_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Patient File No";
            // 
            // chkLateInvoice
            // 
            this.chkLateInvoice.AutoSize = true;
            this.chkLateInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkLateInvoice.Location = new System.Drawing.Point(144, 234);
            this.chkLateInvoice.Name = "chkLateInvoice";
            this.chkLateInvoice.Size = new System.Drawing.Size(85, 17);
            this.chkLateInvoice.TabIndex = 9;
            this.chkLateInvoice.Text = "Late Invoice";
            this.chkLateInvoice.UseVisualStyleBackColor = true;
            this.chkLateInvoice.CheckedChanged += new System.EventHandler(this.chkLateInvoice_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 100;
            this.label10.Text = "Supplier";
            // 
            // txtInvoiceAmount1
            // 
            this.txtInvoiceAmount1.Location = new System.Drawing.Point(682, 206);
            this.txtInvoiceAmount1.Name = "txtInvoiceAmount1";
            this.txtInvoiceAmount1.Size = new System.Drawing.Size(172, 20);
            this.txtInvoiceAmount1.TabIndex = 6;
            this.txtInvoiceAmount1.Visible = false;
            this.txtInvoiceAmount1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtInvoiceAmount1_MaskInputRejected);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 98;
            this.label9.Text = "Invoice Amount Received";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(703, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 91;
            this.label6.Text = "Supplier";
            this.label6.Visible = false;
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(144, 180);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(464, 21);
            this.cboSupplier.Sorted = true;
            this.cboSupplier.TabIndex = 133;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
            this.cboSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSupplier_KeyDown);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.Location = new System.Drawing.Point(144, 71);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(464, 22);
            this.txtPatientName.TabIndex = 129;
            this.txtPatientName.TextChanged += new System.EventHandler(this.txtPatientName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Patient Name";
            // 
            // btnPatientFileNoCheck
            // 
            this.btnPatientFileNoCheck.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPatientFileNoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientFileNoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientFileNoCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnPatientFileNoCheck.Image")));
            this.btnPatientFileNoCheck.Location = new System.Drawing.Point(294, 43);
            this.btnPatientFileNoCheck.Name = "btnPatientFileNoCheck";
            this.btnPatientFileNoCheck.Size = new System.Drawing.Size(42, 23);
            this.btnPatientFileNoCheck.TabIndex = 4;
            this.btnPatientFileNoCheck.UseVisualStyleBackColor = true;
            this.btnPatientFileNoCheck.Click += new System.EventHandler(this.btnPatientFileNoCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, -13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Patient File No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Invoice Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Invoice No";
            this.label4.Visible = false;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(144, 103);
            this.txtInvoiceNo.MaxLength = 50;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(464, 20);
            this.txtInvoiceNo.TabIndex = 130;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            this.txtInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNo_KeyDown);
            this.txtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceNo_KeyPress);
            // 
            // txtPatientFileNo
            // 
            this.txtPatientFileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientFileNo.Location = new System.Drawing.Point(144, 43);
            this.txtPatientFileNo.Name = "txtPatientFileNo";
            this.txtPatientFileNo.Size = new System.Drawing.Size(144, 22);
            this.txtPatientFileNo.TabIndex = 3;
            this.txtPatientFileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientFileNo_KeyDown);
            // 
            // txtSupplierInvNo
            // 
            this.txtSupplierInvNo.Location = new System.Drawing.Point(144, 372);
            this.txtSupplierInvNo.Name = "txtSupplierInvNo";
            this.txtSupplierInvNo.Size = new System.Drawing.Size(462, 20);
            this.txtSupplierInvNo.TabIndex = 82;
            this.txtSupplierInvNo.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search.jpg");
            // 
            // dtInvoiceDispatchDate
            // 
            this.dtInvoiceDispatchDate.Location = new System.Drawing.Point(658, 878);
            this.dtInvoiceDispatchDate.Name = "dtInvoiceDispatchDate";
            this.dtInvoiceDispatchDate.Size = new System.Drawing.Size(288, 20);
            this.dtInvoiceDispatchDate.TabIndex = 105;
            this.dtInvoiceDispatchDate.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(684, 862);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 104;
            this.label11.Text = "Invoice Dispatch Date";
            this.label11.Visible = false;
            // 
            // cboMedicalTreatment
            // 
            this.cboMedicalTreatment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicalTreatment.FormattingEnabled = true;
            this.cboMedicalTreatment.Location = new System.Drawing.Point(886, 853);
            this.cboMedicalTreatment.Name = "cboMedicalTreatment";
            this.cboMedicalTreatment.Size = new System.Drawing.Size(125, 21);
            this.cboMedicalTreatment.TabIndex = 101;
            this.cboMedicalTreatment.Visible = false;
            // 
            // chkInvoiceDispatch
            // 
            this.chkInvoiceDispatch.AutoSize = true;
            this.chkInvoiceDispatch.Location = new System.Drawing.Point(777, 855);
            this.chkInvoiceDispatch.Name = "chkInvoiceDispatch";
            this.chkInvoiceDispatch.Size = new System.Drawing.Size(124, 17);
            this.chkInvoiceDispatch.TabIndex = 103;
            this.chkInvoiceDispatch.Text = "Invoice Dispatched?";
            this.chkInvoiceDispatch.UseVisualStyleBackColor = true;
            this.chkInvoiceDispatch.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(324, 751);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "Date Discharged";
            this.label7.Visible = false;
            // 
            // dtDateDischarged
            // 
            this.dtDateDischarged.Location = new System.Drawing.Point(509, 747);
            this.dtDateDischarged.Name = "dtDateDischarged";
            this.dtDateDischarged.Size = new System.Drawing.Size(288, 20);
            this.dtDateDischarged.TabIndex = 94;
            this.dtDateDischarged.Visible = false;
            // 
            // dtDateAdmitted
            // 
            this.dtDateAdmitted.Location = new System.Drawing.Point(509, 721);
            this.dtDateAdmitted.Name = "dtDateAdmitted";
            this.dtDateAdmitted.Size = new System.Drawing.Size(288, 20);
            this.dtDateAdmitted.TabIndex = 93;
            this.dtDateAdmitted.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 724);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Date Admitted";
            this.label3.Visible = false;
            // 
            // gpxInvoiceSearch
            // 
            this.gpxInvoiceSearch.BackColor = System.Drawing.Color.Transparent;
            this.gpxInvoiceSearch.Controls.Add(this.pnlSearchButtons);
            this.gpxInvoiceSearch.Controls.Add(this.aimsComboLookup1);
            this.gpxInvoiceSearch.Location = new System.Drawing.Point(6, 3);
            this.gpxInvoiceSearch.Name = "gpxInvoiceSearch";
            this.gpxInvoiceSearch.Size = new System.Drawing.Size(975, 176);
            this.gpxInvoiceSearch.TabIndex = 2;
            this.gpxInvoiceSearch.TabStop = false;
            this.gpxInvoiceSearch.Text = "Invoice Search";
            this.gpxInvoiceSearch.Enter += new System.EventHandler(this.gpxInvoiceSearch_Enter);
            // 
            // pnlSearchButtons
            // 
            this.pnlSearchButtons.Controls.Add(this.btnRefresh);
            this.pnlSearchButtons.Controls.Add(this.btnDelete);
            this.pnlSearchButtons.Controls.Add(this.btnSelect);
            this.pnlSearchButtons.Controls.Add(this.btnAdd);
            this.pnlSearchButtons.Location = new System.Drawing.Point(544, 127);
            this.pnlSearchButtons.Name = "pnlSearchButtons";
            this.pnlSearchButtons.Size = new System.Drawing.Size(369, 28);
            this.pnlSearchButtons.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(131, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(294, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(0, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(110, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // gpxInvoice
            // 
            this.gpxInvoice.BackColor = System.Drawing.Color.Transparent;
            this.gpxInvoice.Controls.Add(this.tabInvoices);
            this.gpxInvoice.Location = new System.Drawing.Point(6, 180);
            this.gpxInvoice.Name = "gpxInvoice";
            this.gpxInvoice.Size = new System.Drawing.Size(1182, 420);
            this.gpxInvoice.TabIndex = 3;
            this.gpxInvoice.TabStop = false;
            this.gpxInvoice.Text = "Invoice";
            this.gpxInvoice.Enter += new System.EventHandler(this.gpxInvoice_Enter);
            // 
            // tabInvoices
            // 
            this.tabInvoices.Controls.Add(this.tabDetails);
            this.tabInvoices.Location = new System.Drawing.Point(7, 19);
            this.tabInvoices.Name = "tabInvoices";
            this.tabInvoices.SelectedIndex = 0;
            this.tabInvoices.Size = new System.Drawing.Size(906, 440);
            this.tabInvoices.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Controls.Add(this.btnUnlockInvoice);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Location = new System.Drawing.Point(29, 737);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(980, 30);
            this.pnlButtons.TabIndex = 111;
            // 
            // btnUnlockInvoice
            // 
            this.btnUnlockInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlockInvoice.Image")));
            this.btnUnlockInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnlockInvoice.Location = new System.Drawing.Point(589, 3);
            this.btnUnlockInvoice.Name = "btnUnlockInvoice";
            this.btnUnlockInvoice.Size = new System.Drawing.Size(123, 23);
            this.btnUnlockInvoice.TabIndex = 137;
            this.btnUnlockInvoice.Text = "Unlock Invoice";
            this.btnUnlockInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlockInvoice.UseVisualStyleBackColor = true;
            this.btnUnlockInvoice.Visible = false;
            this.btnUnlockInvoice.Click += new System.EventHandler(this.btnUnlockInvoice_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(479, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 23);
            this.btnClose.TabIndex = 136;
            this.btnClose.Text = "Close Invoice";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(284, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 135;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errProv
            // 
            this.errProv.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProv.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // aimsComboLookup1
            // 
            this.aimsComboLookup1.AIMSDataTbl = null;
            this.aimsComboLookup1.DataField1 = null;
            this.aimsComboLookup1.DataField2 = null;
            this.aimsComboLookup1.Field1Value = "Invoice Number";
            this.aimsComboLookup1.Field2Value = "";
            this.aimsComboLookup1.ItemsLoaded = 0;
            this.aimsComboLookup1.Location = new System.Drawing.Point(6, 13);
            this.aimsComboLookup1.Name = "aimsComboLookup1";
            this.aimsComboLookup1.OrderByField = null;
            this.aimsComboLookup1.ShowButtons = true;
            this.aimsComboLookup1.ShowButtonTwo = false;
            this.aimsComboLookup1.Size = new System.Drawing.Size(277, 157);
            this.aimsComboLookup1.TabIndex = 0;
            this.aimsComboLookup1.TableName = null;
            this.aimsComboLookup1.Load += new System.EventHandler(this.aimsComboLookup1_Load);
            this.aimsComboLookup1.DblClicked += new AIMSUserControls.aimsComboLookup.DblClickHandler(this.aimsComboLookup1_DblClicked);
            // 
            // frmInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 742);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.chkInvoiceDispatch);
            this.Controls.Add(this.gpxInvoiceSearch);
            this.Controls.Add(this.dtInvoiceDispatchDate);
            this.Controls.Add(this.gpxInvoice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtDateAdmitted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMedicalTreatment);
            this.Controls.Add(this.dtDateDischarged);
            this.Controls.Add(this.label7);
            this.KeyPreview = true;
            this.Name = "frmInvoices";
            this.Text = "Invoices Received";
            this.Load += new System.EventHandler(this.frmInvoices_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmInvoices_Paint);
            this.Resize += new System.EventHandler(this.frmInvoices_Resize);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picValidate1)).EndInit();
            this.gpxInvoiceSearch.ResumeLayout(false);
            this.pnlSearchButtons.ResumeLayout(false);
            this.gpxInvoice.ResumeLayout(false);
            this.tabInvoices.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private AIMSUserControls.aimsComboLookup aimsComboLookup1;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.GroupBox gpxInvoiceSearch;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.GroupBox gpxInvoice;
        private System.Windows.Forms.TabControl tabInvoices;
        private System.Windows.Forms.Panel pnlSearchButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DateTimePicker dtInvoiceDispatchDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkInvoiceDispatch;
        private System.Windows.Forms.CheckBox chkLateInvoice;
        private System.Windows.Forms.ComboBox cboMedicalTreatment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtInvoiceAmount1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDateDischarged;
        private System.Windows.Forms.DateTimePicker dtDateAdmitted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.TextBox txtPatientFileNo;
        private System.Windows.Forms.TextBox txtSupplierInvNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnPatientFileNoCheck;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddNewTreatment;
        private System.Windows.Forms.ListView lstVwMedicalTreatments;
        private System.Windows.Forms.Button btnRemoveMedicalTreatment;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.CheckBox chkLockInvoice;
        private UserControls.InfoTextBox infoText1;
        private System.Windows.Forms.TextBox infoText;
        private System.Windows.Forms.ColumnHeader InvoiceTreatmentID;
        private System.Windows.Forms.TextBox txtInvoiceDate;
        private System.Windows.Forms.LinkLabel lnklblInvDate;
        private System.Windows.Forms.Button btnUnlockInvoice;
        private System.Windows.Forms.PictureBox picValidate1;
        private System.Windows.Forms.TextBox txtInvoiceAmount;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MaskedTextBox txtInvoiceAmountold;
        private System.Windows.Forms.ComboBox cboPatientFileNo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label13;

        //private CurrencyTextBox.CurrencyTextBox currencyTextBox1;
        //private CurrencyTextBox.CurrencyTextBox currencyTextBox2;
        //private CurrencyTextBox.CurrencyTextBox currencyTextBox3;
        private System.Windows.Forms.Label lblInvAmountReceived;
        private System.Windows.Forms.TextBox txtInfoText;
        private System.Windows.Forms.CheckBox chkCancel;
        private System.Windows.Forms.CheckBox chkDoctorOwing;
        private System.Windows.Forms.CheckBox chkLateInvoiceSent;
        private System.Windows.Forms.TextBox txtLateInvoiceSentDate;
        private System.Windows.Forms.LinkLabel lnkLateInvSentDate;
        private System.Windows.Forms.TextBox txtWaybillNo;
        private System.Windows.Forms.Label label14;

    }
}