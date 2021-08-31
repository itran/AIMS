namespace AIMSClient
{
    partial class frmAppointments
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
            this.txtAppointmentDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAppointmentAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AppointmentTimeHour = new System.Windows.Forms.NumericUpDown();
            this.AppointmentTimeMinute = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.grpTransport = new System.Windows.Forms.GroupBox();
            this.DropOffTime = new System.Windows.Forms.DateTimePicker();
            this.PickUpTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.DropOffTimeMinute = new System.Windows.Forms.NumericUpDown();
            this.DropOffTimeHour = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.cboTransportType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PickUpTimeMinute = new System.Windows.Forms.NumericUpDown();
            this.PickUpTimeHour = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chkTransportRequired = new System.Windows.Forms.CheckBox();
            this.lnklblAppointmentDate = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAppointmentSubject = new System.Windows.Forms.TextBox();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.cboAppointmentReminder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDiscardChanges = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkCMEmailSMSAlert = new System.Windows.Forms.CheckBox();
            this.btnCancellAppointment = new System.Windows.Forms.Button();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAppointmentNote = new System.Windows.Forms.TextBox();
            this.AppointmentTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranslator = new System.Windows.Forms.CheckBox();
            this.lblCalenderAppointmentID = new System.Windows.Forms.Label();
            this.txtPatientFile = new System.Windows.Forms.TextBox();
            this.btnCloseAppointment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentTimeHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentTimeMinute)).BeginInit();
            this.grpTransport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DropOffTimeMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DropOffTimeHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickUpTimeMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickUpTimeHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAppointmentDate
            // 
            this.txtAppointmentDate.Enabled = false;
            this.txtAppointmentDate.Location = new System.Drawing.Point(99, 77);
            this.txtAppointmentDate.Name = "txtAppointmentDate";
            this.txtAppointmentDate.ReadOnly = true;
            this.txtAppointmentDate.Size = new System.Drawing.Size(114, 20);
            this.txtAppointmentDate.TabIndex = 3;
            this.txtAppointmentDate.TextChanged += new System.EventHandler(this.txtAppointmentDate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-4, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(820, 2);
            this.label3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(-4, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(820, 2);
            this.label4.TabIndex = 7;
            // 
            // txtAppointmentAddress
            // 
            this.txtAppointmentAddress.Location = new System.Drawing.Point(99, 32);
            this.txtAppointmentAddress.MaxLength = 250;
            this.txtAppointmentAddress.Name = "txtAppointmentAddress";
            this.txtAppointmentAddress.Size = new System.Drawing.Size(406, 20);
            this.txtAppointmentAddress.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Location/Address";
            // 
            // AppointmentTimeHour
            // 
            this.AppointmentTimeHour.Location = new System.Drawing.Point(338, 178);
            this.AppointmentTimeHour.Name = "AppointmentTimeHour";
            this.AppointmentTimeHour.Size = new System.Drawing.Size(36, 20);
            this.AppointmentTimeHour.TabIndex = 4;
            this.AppointmentTimeHour.Visible = false;
            // 
            // AppointmentTimeMinute
            // 
            this.AppointmentTimeMinute.Location = new System.Drawing.Point(402, 178);
            this.AppointmentTimeMinute.Name = "AppointmentTimeMinute";
            this.AppointmentTimeMinute.Size = new System.Drawing.Size(36, 20);
            this.AppointmentTimeMinute.TabIndex = 5;
            this.AppointmentTimeMinute.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(444, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "(HH:MM)";
            this.label6.Visible = false;
            // 
            // grpTransport
            // 
            this.grpTransport.Controls.Add(this.DropOffTime);
            this.grpTransport.Controls.Add(this.PickUpTime);
            this.grpTransport.Controls.Add(this.label10);
            this.grpTransport.Controls.Add(this.DropOffTimeMinute);
            this.grpTransport.Controls.Add(this.DropOffTimeHour);
            this.grpTransport.Controls.Add(this.label11);
            this.grpTransport.Controls.Add(this.cboTransportType);
            this.grpTransport.Controls.Add(this.label9);
            this.grpTransport.Controls.Add(this.label7);
            this.grpTransport.Controls.Add(this.PickUpTimeMinute);
            this.grpTransport.Controls.Add(this.PickUpTimeHour);
            this.grpTransport.Controls.Add(this.label8);
            this.grpTransport.Enabled = false;
            this.grpTransport.Location = new System.Drawing.Point(4, 204);
            this.grpTransport.Name = "grpTransport";
            this.grpTransport.Size = new System.Drawing.Size(525, 115);
            this.grpTransport.TabIndex = 11;
            this.grpTransport.TabStop = false;
            this.grpTransport.Text = "Transport";
            // 
            // DropOffTime
            // 
            this.DropOffTime.CustomFormat = "HH:mm";
            this.DropOffTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DropOffTime.Location = new System.Drawing.Point(92, 79);
            this.DropOffTime.Name = "DropOffTime";
            this.DropOffTime.ShowUpDown = true;
            this.DropOffTime.Size = new System.Drawing.Size(91, 20);
            this.DropOffTime.TabIndex = 22;
            // 
            // PickUpTime
            // 
            this.PickUpTime.CustomFormat = "HH:mm";
            this.PickUpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PickUpTime.Location = new System.Drawing.Point(92, 53);
            this.PickUpTime.Name = "PickUpTime";
            this.PickUpTime.ShowUpDown = true;
            this.PickUpTime.Size = new System.Drawing.Size(91, 20);
            this.PickUpTime.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(501, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "(HH:MM)";
            this.label10.Visible = false;
            // 
            // DropOffTimeMinute
            // 
            this.DropOffTimeMinute.Location = new System.Drawing.Point(446, 83);
            this.DropOffTimeMinute.Name = "DropOffTimeMinute";
            this.DropOffTimeMinute.Size = new System.Drawing.Size(31, 20);
            this.DropOffTimeMinute.TabIndex = 13;
            this.DropOffTimeMinute.Visible = false;
            // 
            // DropOffTimeHour
            // 
            this.DropOffTimeHour.Location = new System.Drawing.Point(393, 83);
            this.DropOffTimeHour.Name = "DropOffTimeHour";
            this.DropOffTimeHour.Size = new System.Drawing.Size(32, 20);
            this.DropOffTimeHour.TabIndex = 12;
            this.DropOffTimeHour.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Drop-Off Time";
            // 
            // cboTransportType
            // 
            this.cboTransportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransportType.FormattingEnabled = true;
            this.cboTransportType.Location = new System.Drawing.Point(91, 26);
            this.cboTransportType.Name = "cboTransportType";
            this.cboTransportType.Size = new System.Drawing.Size(401, 21);
            this.cboTransportType.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Transport Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(483, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "(HH:MM)";
            this.label7.Visible = false;
            // 
            // PickUpTimeMinute
            // 
            this.PickUpTimeMinute.Location = new System.Drawing.Point(398, 54);
            this.PickUpTimeMinute.Name = "PickUpTimeMinute";
            this.PickUpTimeMinute.Size = new System.Drawing.Size(31, 20);
            this.PickUpTimeMinute.TabIndex = 11;
            this.PickUpTimeMinute.Visible = false;
            // 
            // PickUpTimeHour
            // 
            this.PickUpTimeHour.Location = new System.Drawing.Point(445, 54);
            this.PickUpTimeHour.Name = "PickUpTimeHour";
            this.PickUpTimeHour.Size = new System.Drawing.Size(32, 20);
            this.PickUpTimeHour.TabIndex = 10;
            this.PickUpTimeHour.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Pick-Up Time";
            // 
            // chkTransportRequired
            // 
            this.chkTransportRequired.AutoSize = true;
            this.chkTransportRequired.Location = new System.Drawing.Point(4, 181);
            this.chkTransportRequired.Name = "chkTransportRequired";
            this.chkTransportRequired.Size = new System.Drawing.Size(126, 17);
            this.chkTransportRequired.TabIndex = 8;
            this.chkTransportRequired.Text = "Transport Required ?";
            this.chkTransportRequired.UseVisualStyleBackColor = true;
            this.chkTransportRequired.CheckedChanged += new System.EventHandler(this.chkTransportRequired_CheckedChanged);
            // 
            // lnklblAppointmentDate
            // 
            this.lnklblAppointmentDate.AutoSize = true;
            this.lnklblAppointmentDate.Location = new System.Drawing.Point(1, 80);
            this.lnklblAppointmentDate.Name = "lnklblAppointmentDate";
            this.lnklblAppointmentDate.Size = new System.Drawing.Size(92, 13);
            this.lnklblAppointmentDate.TabIndex = 12;
            this.lnklblAppointmentDate.TabStop = true;
            this.lnklblAppointmentDate.Text = "Appointment Date";
            this.lnklblAppointmentDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblAppointmentDate_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Subject:";
            // 
            // txtAppointmentSubject
            // 
            this.txtAppointmentSubject.Location = new System.Drawing.Point(193, 6);
            this.txtAppointmentSubject.MaxLength = 250;
            this.txtAppointmentSubject.Name = "txtAppointmentSubject";
            this.txtAppointmentSubject.Size = new System.Drawing.Size(312, 20);
            this.txtAppointmentSubject.TabIndex = 0;
            // 
            // chkReminder
            // 
            this.chkReminder.AutoSize = true;
            this.chkReminder.Location = new System.Drawing.Point(4, 115);
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Size = new System.Drawing.Size(74, 17);
            this.chkReminder.TabIndex = 6;
            this.chkReminder.Text = "Reminder:";
            this.chkReminder.UseVisualStyleBackColor = true;
            this.chkReminder.CheckedChanged += new System.EventHandler(this.chkReminder_CheckedChanged);
            // 
            // cboAppointmentReminder
            // 
            this.cboAppointmentReminder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAppointmentReminder.Enabled = false;
            this.cboAppointmentReminder.FormattingEnabled = true;
            this.cboAppointmentReminder.Items.AddRange(new object[] {
            "5 minutes",
            "10 Minutes",
            "15 Minutes",
            "30 Minutes",
            "45 Minutes",
            "60 Minutes",
            "24 Hours",
            "48 Hours"});
            this.cboAppointmentReminder.Location = new System.Drawing.Point(99, 111);
            this.cboAppointmentReminder.Name = "cboAppointmentReminder";
            this.cboAppointmentReminder.Size = new System.Drawing.Size(114, 21);
            this.cboAppointmentReminder.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-127, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(820, 2);
            this.label1.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::AIMSClient.Properties.Resources.check_50px;
            this.btnSave.Location = new System.Drawing.Point(218, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 69);
            this.btnSave.TabIndex = 15;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDiscardChanges
            // 
            this.btnDiscardChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscardChanges.Image = global::AIMSClient.Properties.Resources.psCancel;
            this.btnDiscardChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscardChanges.Location = new System.Drawing.Point(421, 498);
            this.btnDiscardChanges.Name = "btnDiscardChanges";
            this.btnDiscardChanges.Size = new System.Drawing.Size(108, 32);
            this.btnDiscardChanges.TabIndex = 14;
            this.btnDiscardChanges.Text = "     DISCARD";
            this.btnDiscardChanges.UseVisualStyleBackColor = true;
            this.btnDiscardChanges.Click += new System.EventHandler(this.btnDiscardChanges_Click);
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(-127, 333);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(820, 2);
            this.label13.TabIndex = 25;
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // chkCMEmailSMSAlert
            // 
            this.chkCMEmailSMSAlert.AutoSize = true;
            this.chkCMEmailSMSAlert.ForeColor = System.Drawing.Color.Red;
            this.chkCMEmailSMSAlert.Location = new System.Drawing.Point(8, 437);
            this.chkCMEmailSMSAlert.Name = "chkCMEmailSMSAlert";
            this.chkCMEmailSMSAlert.Size = new System.Drawing.Size(180, 17);
            this.chkCMEmailSMSAlert.TabIndex = 26;
            this.chkCMEmailSMSAlert.Text = "Send Case Managers Email Alert";
            this.chkCMEmailSMSAlert.UseVisualStyleBackColor = true;
            // 
            // btnCancellAppointment
            // 
            this.btnCancellAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancellAppointment.Image = global::AIMSClient.Properties.Resources.delete1;
            this.btnCancellAppointment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancellAppointment.Location = new System.Drawing.Point(315, 460);
            this.btnCancellAppointment.Name = "btnCancellAppointment";
            this.btnCancellAppointment.Size = new System.Drawing.Size(100, 69);
            this.btnCancellAppointment.TabIndex = 21;
            this.btnCancellAppointment.Text = "CANCEL APPOINTMENT";
            this.btnCancellAppointment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancellAppointment.UseVisualStyleBackColor = true;
            this.btnCancellAppointment.Click += new System.EventHandler(this.btnCancellAppointment_Click);
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.Location = new System.Drawing.Point(12, 498);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(87, 13);
            this.lblAppointmentID.TabIndex = 27;
            this.lblAppointmentID.Text = "lblAppointmentID";
            this.lblAppointmentID.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 346);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(228, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Appointment Note (Maximum characters = 250)";
            // 
            // txtAppointmentNote
            // 
            this.txtAppointmentNote.Location = new System.Drawing.Point(8, 367);
            this.txtAppointmentNote.MaxLength = 250;
            this.txtAppointmentNote.Multiline = true;
            this.txtAppointmentNote.Name = "txtAppointmentNote";
            this.txtAppointmentNote.Size = new System.Drawing.Size(520, 64);
            this.txtAppointmentNote.TabIndex = 29;
            // 
            // AppointmentTime
            // 
            this.AppointmentTime.CustomFormat = "HH:mm";
            this.AppointmentTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AppointmentTime.Location = new System.Drawing.Point(279, 77);
            this.AppointmentTime.Name = "AppointmentTime";
            this.AppointmentTime.ShowUpDown = true;
            this.AppointmentTime.Size = new System.Drawing.Size(81, 20);
            this.AppointmentTime.TabIndex = 30;
            // 
            // chkTranslator
            // 
            this.chkTranslator.AutoSize = true;
            this.chkTranslator.Location = new System.Drawing.Point(4, 149);
            this.chkTranslator.Name = "chkTranslator";
            this.chkTranslator.Size = new System.Drawing.Size(128, 17);
            this.chkTranslator.TabIndex = 31;
            this.chkTranslator.Text = "Translator Required ?";
            this.chkTranslator.UseVisualStyleBackColor = true;
            // 
            // lblCalenderAppointmentID
            // 
            this.lblCalenderAppointmentID.AutoSize = true;
            this.lblCalenderAppointmentID.Location = new System.Drawing.Point(20, 506);
            this.lblCalenderAppointmentID.Name = "lblCalenderAppointmentID";
            this.lblCalenderAppointmentID.Size = new System.Drawing.Size(0, 13);
            this.lblCalenderAppointmentID.TabIndex = 32;
            this.lblCalenderAppointmentID.Visible = false;
            // 
            // txtPatientFile
            // 
            this.txtPatientFile.Location = new System.Drawing.Point(101, 6);
            this.txtPatientFile.Name = "txtPatientFile";
            this.txtPatientFile.ReadOnly = true;
            this.txtPatientFile.Size = new System.Drawing.Size(86, 20);
            this.txtPatientFile.TabIndex = 33;
            // 
            // btnCloseAppointment
            // 
            this.btnCloseAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseAppointment.Image = global::AIMSClient.Properties.Resources.psClose;
            this.btnCloseAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseAppointment.Location = new System.Drawing.Point(421, 460);
            this.btnCloseAppointment.Name = "btnCloseAppointment";
            this.btnCloseAppointment.Size = new System.Drawing.Size(107, 32);
            this.btnCloseAppointment.TabIndex = 34;
            this.btnCloseAppointment.Text = "    COMPLETE";
            this.btnCloseAppointment.UseVisualStyleBackColor = true;
            this.btnCloseAppointment.Click += new System.EventHandler(this.btnCloseAppointment_Click);
            // 
            // frmAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 541);
            this.Controls.Add(this.btnCloseAppointment);
            this.Controls.Add(this.txtPatientFile);
            this.Controls.Add(this.lblCalenderAppointmentID);
            this.Controls.Add(this.chkTranslator);
            this.Controls.Add(this.AppointmentTime);
            this.Controls.Add(this.txtAppointmentNote);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblAppointmentID);
            this.Controls.Add(this.btnCancellAppointment);
            this.Controls.Add(this.chkCMEmailSMSAlert);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnDiscardChanges);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAppointmentReminder);
            this.Controls.Add(this.chkReminder);
            this.Controls.Add(this.txtAppointmentSubject);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lnklblAppointmentDate);
            this.Controls.Add(this.chkTransportRequired);
            this.Controls.Add(this.grpTransport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AppointmentTimeMinute);
            this.Controls.Add(this.AppointmentTimeHour);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAppointmentAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAppointmentDate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppointments";
            this.Text = "Create Appointment - OUT:Patients";
            this.Load += new System.EventHandler(this.frmAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentTimeHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentTimeMinute)).EndInit();
            this.grpTransport.ResumeLayout(false);
            this.grpTransport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DropOffTimeMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DropOffTimeHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickUpTimeMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickUpTimeHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAppointmentDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAppointmentAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown AppointmentTimeHour;
        private System.Windows.Forms.NumericUpDown AppointmentTimeMinute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpTransport;
        private System.Windows.Forms.CheckBox chkTransportRequired;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown PickUpTimeMinute;
        private System.Windows.Forms.NumericUpDown PickUpTimeHour;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown DropOffTimeMinute;
        private System.Windows.Forms.NumericUpDown DropOffTimeHour;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTransportType;
        private System.Windows.Forms.LinkLabel lnklblAppointmentDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAppointmentSubject;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.ComboBox cboAppointmentReminder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDiscardChanges;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.CheckBox chkCMEmailSMSAlert;
        private System.Windows.Forms.Button btnCancellAppointment;
        private System.Windows.Forms.Label lblAppointmentID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAppointmentNote;
        private System.Windows.Forms.DateTimePicker DropOffTime;
        private System.Windows.Forms.DateTimePicker PickUpTime;
        private System.Windows.Forms.DateTimePicker AppointmentTime;
        private System.Windows.Forms.CheckBox chkTranslator;
        private System.Windows.Forms.Label lblCalenderAppointmentID;
        private System.Windows.Forms.TextBox txtPatientFile;
        private System.Windows.Forms.Button btnCloseAppointment;
    }
}