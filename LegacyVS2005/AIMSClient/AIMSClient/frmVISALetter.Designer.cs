namespace AIMSClient
{
    partial class frmVISALetter
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
            this.btnAddEmbassy = new System.Windows.Forms.Button();
            this.btnEmbassyEdit = new System.Windows.Forms.Button();
            this.cboEmbassies = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEmbassyCountry = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmbassyAddress5 = new System.Windows.Forms.TextBox();
            this.txtEmbassyAddress4 = new System.Windows.Forms.TextBox();
            this.txtEmbassyAddress3 = new System.Windows.Forms.TextBox();
            this.txtEmbassyAddress2 = new System.Windows.Forms.TextBox();
            this.txtEmbassyAddress1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmbassyName = new System.Windows.Forms.TextBox();
            this.cboAddressType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVisaExipryDate = new System.Windows.Forms.TextBox();
            this.lnklblVisaExpiryDate = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.cboCountryOfTreatment = new System.Windows.Forms.ComboBox();
            this.txtAppointmentDate = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtPatientResidingAdd3 = new System.Windows.Forms.TextBox();
            this.txtPatientResidingAdd2 = new System.Windows.Forms.TextBox();
            this.txtPatientResidingAdd1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTreatingDrProfession = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboTreatingDoctor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTreatingHospital = new System.Windows.Forms.ComboBox();
            this.txtPatientPassportExpiryDt = new System.Windows.Forms.TextBox();
            this.lnklblPatientPassportExpiryDt = new System.Windows.Forms.LinkLabel();
            this.txtPatientPassportIssueDt = new System.Windows.Forms.TextBox();
            this.lnklblPatientPassportIssueDt = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPatientPassportNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboHisHer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboEscortRelation = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEscortName = new System.Windows.Forms.TextBox();
            this.txtEscortPassportExpiryDt = new System.Windows.Forms.TextBox();
            this.lnklblEscortPassportExpiryDt = new System.Windows.Forms.LinkLabel();
            this.txtEscortPassportIssueDt = new System.Windows.Forms.TextBox();
            this.lnklblEscortPassportIssueDt = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEscortPassportNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGuaranteeCreate = new System.Windows.Forms.Button();
            this.btnGuaranteePreview = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddEmbassy);
            this.groupBox1.Controls.Add(this.btnEmbassyEdit);
            this.groupBox1.Controls.Add(this.cboEmbassies);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Embassies";
            // 
            // btnAddEmbassy
            // 
            this.btnAddEmbassy.Image = global::AIMSClient.Properties.Resources.add;
            this.btnAddEmbassy.Location = new System.Drawing.Point(433, 22);
            this.btnAddEmbassy.Name = "btnAddEmbassy";
            this.btnAddEmbassy.Size = new System.Drawing.Size(32, 30);
            this.btnAddEmbassy.TabIndex = 25;
            this.btnAddEmbassy.UseVisualStyleBackColor = true;
            this.btnAddEmbassy.Click += new System.EventHandler(this.btnAddEmbassy_Click);
            // 
            // btnEmbassyEdit
            // 
            this.btnEmbassyEdit.Image = global::AIMSClient.Properties.Resources.psSelect;
            this.btnEmbassyEdit.Location = new System.Drawing.Point(396, 23);
            this.btnEmbassyEdit.Name = "btnEmbassyEdit";
            this.btnEmbassyEdit.Size = new System.Drawing.Size(32, 29);
            this.btnEmbassyEdit.TabIndex = 24;
            this.btnEmbassyEdit.UseVisualStyleBackColor = true;
            this.btnEmbassyEdit.Click += new System.EventHandler(this.btnEmbassyEdit_Click);
            // 
            // cboEmbassies
            // 
            this.cboEmbassies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEmbassies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmbassies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmbassies.FormattingEnabled = true;
            this.cboEmbassies.Location = new System.Drawing.Point(12, 25);
            this.cboEmbassies.Name = "cboEmbassies";
            this.cboEmbassies.Size = new System.Drawing.Size(364, 21);
            this.cboEmbassies.TabIndex = 23;
            this.cboEmbassies.SelectedIndexChanged += new System.EventHandler(this.cboEmbassies_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // cboEmbassyCountry
            // 
            this.cboEmbassyCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmbassyCountry.FormattingEnabled = true;
            this.cboEmbassyCountry.Location = new System.Drawing.Point(271, 597);
            this.cboEmbassyCountry.Name = "cboEmbassyCountry";
            this.cboEmbassyCountry.Size = new System.Drawing.Size(337, 21);
            this.cboEmbassyCountry.TabIndex = 21;
            this.cboEmbassyCountry.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 600);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Country";
            this.label3.Visible = false;
            // 
            // txtEmbassyAddress5
            // 
            this.txtEmbassyAddress5.Location = new System.Drawing.Point(271, 571);
            this.txtEmbassyAddress5.Name = "txtEmbassyAddress5";
            this.txtEmbassyAddress5.Size = new System.Drawing.Size(337, 20);
            this.txtEmbassyAddress5.TabIndex = 7;
            this.txtEmbassyAddress5.Visible = false;
            // 
            // txtEmbassyAddress4
            // 
            this.txtEmbassyAddress4.Location = new System.Drawing.Point(271, 545);
            this.txtEmbassyAddress4.Name = "txtEmbassyAddress4";
            this.txtEmbassyAddress4.Size = new System.Drawing.Size(337, 20);
            this.txtEmbassyAddress4.TabIndex = 6;
            this.txtEmbassyAddress4.Visible = false;
            // 
            // txtEmbassyAddress3
            // 
            this.txtEmbassyAddress3.Location = new System.Drawing.Point(271, 519);
            this.txtEmbassyAddress3.Name = "txtEmbassyAddress3";
            this.txtEmbassyAddress3.Size = new System.Drawing.Size(337, 20);
            this.txtEmbassyAddress3.TabIndex = 5;
            this.txtEmbassyAddress3.Visible = false;
            // 
            // txtEmbassyAddress2
            // 
            this.txtEmbassyAddress2.Location = new System.Drawing.Point(271, 493);
            this.txtEmbassyAddress2.Name = "txtEmbassyAddress2";
            this.txtEmbassyAddress2.Size = new System.Drawing.Size(337, 20);
            this.txtEmbassyAddress2.TabIndex = 4;
            this.txtEmbassyAddress2.Visible = false;
            // 
            // txtEmbassyAddress1
            // 
            this.txtEmbassyAddress1.Location = new System.Drawing.Point(271, 467);
            this.txtEmbassyAddress1.Name = "txtEmbassyAddress1";
            this.txtEmbassyAddress1.Size = new System.Drawing.Size(337, 20);
            this.txtEmbassyAddress1.TabIndex = 3;
            this.txtEmbassyAddress1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Embassy Address";
            this.label2.Visible = false;
            // 
            // txtEmbassyName
            // 
            this.txtEmbassyName.Location = new System.Drawing.Point(271, 441);
            this.txtEmbassyName.Name = "txtEmbassyName";
            this.txtEmbassyName.Size = new System.Drawing.Size(337, 20);
            this.txtEmbassyName.TabIndex = 0;
            this.txtEmbassyName.Visible = false;
            // 
            // cboAddressType
            // 
            this.cboAddressType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAddressType.FormattingEnabled = true;
            this.cboAddressType.Location = new System.Drawing.Point(117, 390);
            this.cboAddressType.Name = "cboAddressType";
            this.cboAddressType.Size = new System.Drawing.Size(337, 21);
            this.cboAddressType.TabIndex = 23;
            this.cboAddressType.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 393);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Address Type";
            this.label13.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtVisaExipryDate);
            this.groupBox2.Controls.Add(this.lnklblVisaExpiryDate);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cboCountryOfTreatment);
            this.groupBox2.Controls.Add(this.cboAddressType);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtAppointmentDate);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.txtPatientResidingAdd3);
            this.groupBox2.Controls.Add(this.txtPatientResidingAdd2);
            this.groupBox2.Controls.Add(this.txtPatientResidingAdd1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtTreatingDrProfession);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboTreatingDoctor);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboTreatingHospital);
            this.groupBox2.Controls.Add(this.txtPatientPassportExpiryDt);
            this.groupBox2.Controls.Add(this.lnklblPatientPassportExpiryDt);
            this.groupBox2.Controls.Add(this.txtPatientPassportIssueDt);
            this.groupBox2.Controls.Add(this.lnklblPatientPassportIssueDt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPatientPassportNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPatientName);
            this.groupBox2.Location = new System.Drawing.Point(489, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 417);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patient Details";
            // 
            // txtVisaExipryDate
            // 
            this.txtVisaExipryDate.Location = new System.Drawing.Point(125, 107);
            this.txtVisaExipryDate.Name = "txtVisaExipryDate";
            this.txtVisaExipryDate.ReadOnly = true;
            this.txtVisaExipryDate.Size = new System.Drawing.Size(317, 20);
            this.txtVisaExipryDate.TabIndex = 29;
            this.txtVisaExipryDate.TextChanged += new System.EventHandler(this.txtVisaExipryDate_TextChanged);
            // 
            // lnklblVisaExpiryDate
            // 
            this.lnklblVisaExpiryDate.AutoSize = true;
            this.lnklblVisaExpiryDate.Location = new System.Drawing.Point(6, 110);
            this.lnklblVisaExpiryDate.Name = "lnklblVisaExpiryDate";
            this.lnklblVisaExpiryDate.Size = new System.Drawing.Size(84, 13);
            this.lnklblVisaExpiryDate.TabIndex = 28;
            this.lnklblVisaExpiryDate.TabStop = true;
            this.lnklblVisaExpiryDate.Text = "Visa Expiry Date";
            this.lnklblVisaExpiryDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblVisaExpiryDate_LinkClicked);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Country Of Treatment";
            // 
            // cboCountryOfTreatment
            // 
            this.cboCountryOfTreatment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCountryOfTreatment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCountryOfTreatment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountryOfTreatment.FormattingEnabled = true;
            this.cboCountryOfTreatment.Location = new System.Drawing.Point(125, 80);
            this.cboCountryOfTreatment.Name = "cboCountryOfTreatment";
            this.cboCountryOfTreatment.Size = new System.Drawing.Size(317, 21);
            this.cboCountryOfTreatment.TabIndex = 26;
            // 
            // txtAppointmentDate
            // 
            this.txtAppointmentDate.Location = new System.Drawing.Point(125, 360);
            this.txtAppointmentDate.Name = "txtAppointmentDate";
            this.txtAppointmentDate.ReadOnly = true;
            this.txtAppointmentDate.Size = new System.Drawing.Size(317, 20);
            this.txtAppointmentDate.TabIndex = 25;
            this.txtAppointmentDate.DoubleClick += new System.EventHandler(this.txtAppointmentDate_DoubleClick);
            this.txtAppointmentDate.TextChanged += new System.EventHandler(this.txtAppointmentDate_TextChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 363);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 13);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Appointment Date";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtPatientResidingAdd3
            // 
            this.txtPatientResidingAdd3.Location = new System.Drawing.Point(125, 254);
            this.txtPatientResidingAdd3.Name = "txtPatientResidingAdd3";
            this.txtPatientResidingAdd3.Size = new System.Drawing.Size(317, 20);
            this.txtPatientResidingAdd3.TabIndex = 19;
            // 
            // txtPatientResidingAdd2
            // 
            this.txtPatientResidingAdd2.Location = new System.Drawing.Point(125, 228);
            this.txtPatientResidingAdd2.Name = "txtPatientResidingAdd2";
            this.txtPatientResidingAdd2.Size = new System.Drawing.Size(317, 20);
            this.txtPatientResidingAdd2.TabIndex = 18;
            // 
            // txtPatientResidingAdd1
            // 
            this.txtPatientResidingAdd1.Location = new System.Drawing.Point(125, 202);
            this.txtPatientResidingAdd1.Name = "txtPatientResidingAdd1";
            this.txtPatientResidingAdd1.Size = new System.Drawing.Size(317, 20);
            this.txtPatientResidingAdd1.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 43);
            this.label14.TabIndex = 16;
            this.label14.Text = "Patient/Escort Residing Address";
            // 
            // txtTreatingDrProfession
            // 
            this.txtTreatingDrProfession.Location = new System.Drawing.Point(125, 334);
            this.txtTreatingDrProfession.Name = "txtTreatingDrProfession";
            this.txtTreatingDrProfession.Size = new System.Drawing.Size(317, 20);
            this.txtTreatingDrProfession.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 337);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Doctor Profession";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Treating Doctor";
            // 
            // cboTreatingDoctor
            // 
            this.cboTreatingDoctor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTreatingDoctor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTreatingDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTreatingDoctor.FormattingEnabled = true;
            this.cboTreatingDoctor.Location = new System.Drawing.Point(125, 307);
            this.cboTreatingDoctor.Name = "cboTreatingDoctor";
            this.cboTreatingDoctor.Size = new System.Drawing.Size(317, 21);
            this.cboTreatingDoctor.TabIndex = 11;
            this.cboTreatingDoctor.SelectedIndexChanged += new System.EventHandler(this.cboTreatingDoctor_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Treating Hospital";
            // 
            // cboTreatingHospital
            // 
            this.cboTreatingHospital.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTreatingHospital.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTreatingHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTreatingHospital.FormattingEnabled = true;
            this.cboTreatingHospital.Location = new System.Drawing.Point(125, 280);
            this.cboTreatingHospital.Name = "cboTreatingHospital";
            this.cboTreatingHospital.Size = new System.Drawing.Size(317, 21);
            this.cboTreatingHospital.TabIndex = 9;
            // 
            // txtPatientPassportExpiryDt
            // 
            this.txtPatientPassportExpiryDt.Location = new System.Drawing.Point(125, 176);
            this.txtPatientPassportExpiryDt.Name = "txtPatientPassportExpiryDt";
            this.txtPatientPassportExpiryDt.ReadOnly = true;
            this.txtPatientPassportExpiryDt.Size = new System.Drawing.Size(317, 20);
            this.txtPatientPassportExpiryDt.TabIndex = 8;
            this.txtPatientPassportExpiryDt.DoubleClick += new System.EventHandler(this.txtPatientPassportExpiryDt_DoubleClick);
            // 
            // lnklblPatientPassportExpiryDt
            // 
            this.lnklblPatientPassportExpiryDt.AutoSize = true;
            this.lnklblPatientPassportExpiryDt.Location = new System.Drawing.Point(6, 179);
            this.lnklblPatientPassportExpiryDt.Name = "lnklblPatientPassportExpiryDt";
            this.lnklblPatientPassportExpiryDt.Size = new System.Drawing.Size(105, 13);
            this.lnklblPatientPassportExpiryDt.TabIndex = 7;
            this.lnklblPatientPassportExpiryDt.TabStop = true;
            this.lnklblPatientPassportExpiryDt.Text = "Passport Expiry-Date";
            this.lnklblPatientPassportExpiryDt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblPatientPassportExpiryDt_LinkClicked);
            // 
            // txtPatientPassportIssueDt
            // 
            this.txtPatientPassportIssueDt.Location = new System.Drawing.Point(125, 150);
            this.txtPatientPassportIssueDt.Name = "txtPatientPassportIssueDt";
            this.txtPatientPassportIssueDt.ReadOnly = true;
            this.txtPatientPassportIssueDt.Size = new System.Drawing.Size(317, 20);
            this.txtPatientPassportIssueDt.TabIndex = 6;
            this.txtPatientPassportIssueDt.DoubleClick += new System.EventHandler(this.txtPatientPassportIssueDt_DoubleClick);
            this.txtPatientPassportIssueDt.TextChanged += new System.EventHandler(this.txtPatientPassportIssueDt_TextChanged);
            // 
            // lnklblPatientPassportIssueDt
            // 
            this.lnklblPatientPassportIssueDt.AutoSize = true;
            this.lnklblPatientPassportIssueDt.Location = new System.Drawing.Point(6, 153);
            this.lnklblPatientPassportIssueDt.Name = "lnklblPatientPassportIssueDt";
            this.lnklblPatientPassportIssueDt.Size = new System.Drawing.Size(116, 13);
            this.lnklblPatientPassportIssueDt.TabIndex = 5;
            this.lnklblPatientPassportIssueDt.TabStop = true;
            this.lnklblPatientPassportIssueDt.Text = "Passport Date-Of-Issue";
            this.lnklblPatientPassportIssueDt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblPatientPassportIssueDt_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Passport Number";
            // 
            // txtPatientPassportNo
            // 
            this.txtPatientPassportNo.Location = new System.Drawing.Point(125, 54);
            this.txtPatientPassportNo.Name = "txtPatientPassportNo";
            this.txtPatientPassportNo.ReadOnly = true;
            this.txtPatientPassportNo.Size = new System.Drawing.Size(317, 20);
            this.txtPatientPassportNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Patient Name";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(125, 28);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(317, 20);
            this.txtPatientName.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboHisHer);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboEscortRelation);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtEscortName);
            this.groupBox3.Controls.Add(this.txtEscortPassportExpiryDt);
            this.groupBox3.Controls.Add(this.lnklblEscortPassportExpiryDt);
            this.groupBox3.Controls.Add(this.txtEscortPassportIssueDt);
            this.groupBox3.Controls.Add(this.lnklblEscortPassportIssueDt);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtEscortPassportNo);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 175);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Patient Escort";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // cboHisHer
            // 
            this.cboHisHer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboHisHer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboHisHer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHisHer.FormattingEnabled = true;
            this.cboHisHer.Items.AddRange(new object[] {
            "",
            "His",
            "Her"});
            this.cboHisHer.Location = new System.Drawing.Point(172, 57);
            this.cboHisHer.Name = "cboHisHer";
            this.cboHisHer.Size = new System.Drawing.Size(58, 21);
            this.cboHisHer.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(122, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "His/Her";
            // 
            // cboEscortRelation
            // 
            this.cboEscortRelation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEscortRelation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEscortRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEscortRelation.FormattingEnabled = true;
            this.cboEscortRelation.Location = new System.Drawing.Point(248, 57);
            this.cboEscortRelation.Name = "cboEscortRelation";
            this.cboEscortRelation.Size = new System.Drawing.Size(194, 21);
            this.cboEscortRelation.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Relation to Patient";
            // 
            // txtEscortName
            // 
            this.txtEscortName.Location = new System.Drawing.Point(125, 28);
            this.txtEscortName.Name = "txtEscortName";
            this.txtEscortName.Size = new System.Drawing.Size(317, 20);
            this.txtEscortName.TabIndex = 16;
            // 
            // txtEscortPassportExpiryDt
            // 
            this.txtEscortPassportExpiryDt.Location = new System.Drawing.Point(125, 142);
            this.txtEscortPassportExpiryDt.Name = "txtEscortPassportExpiryDt";
            this.txtEscortPassportExpiryDt.ReadOnly = true;
            this.txtEscortPassportExpiryDt.Size = new System.Drawing.Size(317, 20);
            this.txtEscortPassportExpiryDt.TabIndex = 15;
            this.txtEscortPassportExpiryDt.DoubleClick += new System.EventHandler(this.txtEscortPassportExpiryDt_DoubleClick);
            this.txtEscortPassportExpiryDt.TextChanged += new System.EventHandler(this.txtEscortPassportExpiryDt_TextChanged);
            // 
            // lnklblEscortPassportExpiryDt
            // 
            this.lnklblEscortPassportExpiryDt.AutoSize = true;
            this.lnklblEscortPassportExpiryDt.Location = new System.Drawing.Point(6, 145);
            this.lnklblEscortPassportExpiryDt.Name = "lnklblEscortPassportExpiryDt";
            this.lnklblEscortPassportExpiryDt.Size = new System.Drawing.Size(105, 13);
            this.lnklblEscortPassportExpiryDt.TabIndex = 14;
            this.lnklblEscortPassportExpiryDt.TabStop = true;
            this.lnklblEscortPassportExpiryDt.Text = "Passport Expiry-Date";
            this.lnklblEscortPassportExpiryDt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblEscortPassportExpiryDt_LinkClicked);
            // 
            // txtEscortPassportIssueDt
            // 
            this.txtEscortPassportIssueDt.Location = new System.Drawing.Point(125, 116);
            this.txtEscortPassportIssueDt.Name = "txtEscortPassportIssueDt";
            this.txtEscortPassportIssueDt.ReadOnly = true;
            this.txtEscortPassportIssueDt.Size = new System.Drawing.Size(317, 20);
            this.txtEscortPassportIssueDt.TabIndex = 13;
            this.txtEscortPassportIssueDt.DoubleClick += new System.EventHandler(this.txtEscortPassportIssueDt_DoubleClick);
            this.txtEscortPassportIssueDt.TextChanged += new System.EventHandler(this.txtEscortPassportIssueDt_TextChanged);
            // 
            // lnklblEscortPassportIssueDt
            // 
            this.lnklblEscortPassportIssueDt.AutoSize = true;
            this.lnklblEscortPassportIssueDt.Location = new System.Drawing.Point(6, 119);
            this.lnklblEscortPassportIssueDt.Name = "lnklblEscortPassportIssueDt";
            this.lnklblEscortPassportIssueDt.Size = new System.Drawing.Size(116, 13);
            this.lnklblEscortPassportIssueDt.TabIndex = 12;
            this.lnklblEscortPassportIssueDt.TabStop = true;
            this.lnklblEscortPassportIssueDt.Text = "Passport Date-Of-Issue";
            this.lnklblEscortPassportIssueDt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblEscortPassportIssueDt_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Passport Number";
            // 
            // txtEscortPassportNo
            // 
            this.txtEscortPassportNo.Location = new System.Drawing.Point(125, 90);
            this.txtEscortPassportNo.Name = "txtEscortPassportNo";
            this.txtEscortPassportNo.Size = new System.Drawing.Size(317, 20);
            this.txtEscortPassportNo.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Name";
            // 
            // btnGuaranteeCreate
            // 
            this.btnGuaranteeCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuaranteeCreate.Image = global::AIMSClient.Properties.Resources.medicine;
            this.btnGuaranteeCreate.Location = new System.Drawing.Point(890, 432);
            this.btnGuaranteeCreate.Name = "btnGuaranteeCreate";
            this.btnGuaranteeCreate.Size = new System.Drawing.Size(59, 72);
            this.btnGuaranteeCreate.TabIndex = 23;
            this.btnGuaranteeCreate.Text = "Save";
            this.btnGuaranteeCreate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuaranteeCreate.UseVisualStyleBackColor = true;
            this.btnGuaranteeCreate.Click += new System.EventHandler(this.btnGuaranteeCreate_Click);
            // 
            // btnGuaranteePreview
            // 
            this.btnGuaranteePreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuaranteePreview.Image = global::AIMSClient.Properties.Resources.medical_record;
            this.btnGuaranteePreview.Location = new System.Drawing.Point(825, 432);
            this.btnGuaranteePreview.Name = "btnGuaranteePreview";
            this.btnGuaranteePreview.Size = new System.Drawing.Size(59, 72);
            this.btnGuaranteePreview.TabIndex = 22;
            this.btnGuaranteePreview.Text = "Preview";
            this.btnGuaranteePreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuaranteePreview.UseVisualStyleBackColor = true;
            this.btnGuaranteePreview.Click += new System.EventHandler(this.btnGuaranteePreview_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // frmVISALetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 512);
            this.Controls.Add(this.btnGuaranteeCreate);
            this.Controls.Add(this.cboEmbassyCountry);
            this.Controls.Add(this.btnGuaranteePreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtEmbassyAddress5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtEmbassyAddress4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtEmbassyAddress3);
            this.Controls.Add(this.txtEmbassyName);
            this.Controls.Add(this.txtEmbassyAddress2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmbassyAddress1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVISALetter";
            this.Text = "frmVISALetter";
            this.Load += new System.EventHandler(this.frmVISALetter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmbassyAddress5;
        private System.Windows.Forms.TextBox txtEmbassyAddress4;
        private System.Windows.Forms.TextBox txtEmbassyAddress3;
        private System.Windows.Forms.TextBox txtEmbassyAddress2;
        private System.Windows.Forms.TextBox txtEmbassyAddress1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmbassyName;
        private System.Windows.Forms.ComboBox cboEmbassyCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtPatientPassportNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTreatingHospital;
        private System.Windows.Forms.TextBox txtPatientPassportExpiryDt;
        private System.Windows.Forms.LinkLabel lnklblPatientPassportExpiryDt;
        private System.Windows.Forms.TextBox txtPatientPassportIssueDt;
        private System.Windows.Forms.LinkLabel lnklblPatientPassportIssueDt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboEscortRelation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEscortName;
        private System.Windows.Forms.TextBox txtEscortPassportExpiryDt;
        private System.Windows.Forms.LinkLabel lnklblEscortPassportExpiryDt;
        private System.Windows.Forms.TextBox txtEscortPassportIssueDt;
        private System.Windows.Forms.LinkLabel lnklblEscortPassportIssueDt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEscortPassportNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboHisHer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTreatingDoctor;
        private System.Windows.Forms.TextBox txtTreatingDrProfession;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGuaranteeCreate;
        private System.Windows.Forms.Button btnGuaranteePreview;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.ComboBox cboAddressType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPatientResidingAdd3;
        private System.Windows.Forms.TextBox txtPatientResidingAdd2;
        private System.Windows.Forms.TextBox txtPatientResidingAdd1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAppointmentDate;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnEmbassyEdit;
        private System.Windows.Forms.ComboBox cboEmbassies;
        private System.Windows.Forms.Button btnAddEmbassy;
        private System.Windows.Forms.TextBox txtVisaExipryDate;
        private System.Windows.Forms.LinkLabel lnklblVisaExpiryDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboCountryOfTreatment;
    }
}