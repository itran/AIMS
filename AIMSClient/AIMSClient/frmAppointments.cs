using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace AIMSClient
{
    public partial class frmAppointments : Form
    {
        AIMS.Common.CommonFunctions commonFuncs;
        public frmAppointments()
        {
            InitializeComponent();
        }

        Int32 _PatientFileTaskID;
        public Int32 PatientFileTaskID
        {
            get { return _PatientFileTaskID; }
            set
            {
                _PatientFileTaskID = value;
            }
        }

        string _PatientFileNo = "";
        public string PatientFileNo
        {
            get { return _PatientFileNo; }
            set { _PatientFileNo = value; }
        }

        string _PatientName = "";
        public string PatientName
        {
            get { return _PatientName; }
            set { _PatientName = value; }
        }

        string _Guarantor = "";
        public string Guarantor
        {
            get { return _Guarantor; }
            set { _Guarantor = value; }
        }

        string _PatientSubFileID = "";
        public string PatientSubFileID
        {
            get { return _PatientSubFileID; }
            set { _PatientSubFileID = value; }
        }

        string _Restrictions = "";
        public string Restrictions
        {
            get { return _Restrictions; }
            set { _Restrictions = value; }
        }

        string _userID = "";
        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }

        Int32 _AppointmentID;
        public Int32 AppointmentID
        {
            get { return _AppointmentID; }
            set
            {
                _AppointmentID = value;
            }
        }

        Int32 _CalenderAppointmentID;
        public Int32 CalenderAppointmentID
        {
            get { return _CalenderAppointmentID; }
            set
            {
                _CalenderAppointmentID = value;
            }
        }
        
        private void frmAppointments_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            txtPatientFile.Text = "[-" + PatientFileNo + "-]"; 
            LoadTransportTypes();

            if (!AppointmentID.Equals(""))
            {
                lblAppointmentID.Text = AppointmentID.ToString();
                if (lblAppointmentID.Text.Equals("0"))
                {
                    lblAppointmentID.Text = "";
                    return;
                }

                lblCalenderAppointmentID.Text = CalenderAppointmentID.ToString();
                if (lblCalenderAppointmentID.Text.Equals("0"))
                {
                    lblCalenderAppointmentID.Text = "";    
                }

                LoadAppointments();
            }
            else
            {
                DiscardAppointment();
            }
        }

        private void chkTransportRequired_CheckedChanged(object sender, EventArgs e)
        {
            grpTransport.Enabled = chkTransportRequired.Checked?true:false;
            TransportCase();
        }

        void TransportCase()
        {
            if (!chkTransportRequired.Checked)
            {
                cboTransportType.SelectedIndex = -1;
                PickUpTimeHour.Value = 0;
                PickUpTimeMinute.Value = 0;
                DropOffTimeHour.Value = 0;
                DropOffTimeMinute.Value = 0; 
            }
        }

        private void btnDiscardChanges_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Discard appointment ?", "Appointment Information Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DiscardAppointment();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continue saving appointment ?","Appointment Creation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!ValidateControl())
                return;

                string ReminderYN = "N";
                if (chkReminder.Checked)
                ReminderYN = "Y";

                string TransportYN = "N";
                if (chkTransportRequired.Checked)
                    TransportYN = "Y";

                string appointmentReminder = "";
                if (chkReminder.Checked)
                {
                    if (cboAppointmentReminder.SelectedItem == null && (cboAppointmentReminder.Text == ""))
                    { appointmentReminder = ""; }
                    else
                    {
                        appointmentReminder = cboAppointmentReminder.Text.ToString();
                    }
                }

                string appointmentTransport = "";
                if (chkTransportRequired.Checked)
                {
                    if (cboTransportType.SelectedItem == null && (cboTransportType.Text == ""))
                    { appointmentTransport = ""; }
                    else
                    {
                        appointmentTransport = cboTransportType.SelectedValue.ToString();
                    }
                }

                string TranslatorYN = "N";
                string TranslatorReqNote = "";
                string AppointmentNotes ="";
                if (chkTranslator.Checked)
                {
                    AppointmentNotes = txtAppointmentNote.Text.Replace("[- PLEASE NOTE TRANSLATOR REQUIRED - ]", "");
                    TranslatorReqNote = "[- PLEASE NOTE TRANSLATOR REQUIRED - ] \r\n";
                    TranslatorYN = "Y";
                    AppointmentNotes = TranslatorReqNote + AppointmentNotes;
                }
                else
                {
                    AppointmentNotes = txtAppointmentNote.Text.Replace("[- PLEASE NOTE TRANSLATOR REQUIRED - ] ", "");
                }

                txtPatientFile.Text = "[-" + PatientFileNo + "-]";

                txtAppointmentSubject.Text = txtAppointmentSubject.Text.Replace("[-" + PatientFileNo + "-]", "");
                txtAppointmentSubject.Text = "[-" + PatientFileNo + "-]" + " " + txtAppointmentSubject.Text.Trim();

                bool bSaved = SaveAppointment(txtAppointmentSubject.Text,
                                                txtAppointmentAddress.Text,
                                                 txtAppointmentDate.Text,
                                                  AppointmentTimeHour.Value.ToString(),
                                                   AppointmentTimeMinute.Value.ToString(),
                                                    ReminderYN,
                                                     appointmentReminder,
                                                     TransportYN,
                                                       appointmentTransport,
                                                        PickUpTimeHour.Value.ToString(),
                                                         PickUpTimeMinute.Value.ToString(),
                                                          DropOffTimeHour.Value.ToString(),
                                                           DropOffTimeMinute.Value.ToString(),
                                                           UserID, AppointmentNotes, TranslatorYN);
                if (bSaved)
                {
                    string SMSMsg = "";

                    string AppointmentEmailRecipient = "";

                    if (chkCMEmailSMSAlert.Checked)
                    {
                        DataTable dtCodeValue = commonFuncs.GetLimitationCodeValue("CASE_MANAGERS");
                        string SendTo = "";
                        if (dtCodeValue.Rows.Count >0 )
                        {
                            SendTo = dtCodeValue.Rows[0]["LIMITATION_VALUE"].ToString();
                        }
                        else
                        {
                            SendTo = "jade@aims.org.za";
                        }
                        bSaved = SendNotification(txtAppointmentSubject.Text, txtAppointmentAddress.Text, txtAppointmentDate.Text, ref SMSMsg, SendTo);
                    }

                    if (bSaved)
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Appointment Created Successfully." + SMSMsg);
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Appointment Created Successfully.\n\n" + SMSMsg);
                    }
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error occured while creating Appointment. Please contact system Administrator");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();            
            }
        }

        private void txtAppointmentDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAppointmentDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtAppointmentDate.Text = frmCal.StartDate.ToShortDateString();
            }
            txtAppointmentDate.Focus();
        }

        private void lnklblAppointmentDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtAppointmentDate_DoubleClick(null, null);
        }

        void DiscardAppointment()
        {
            txtAppointmentSubject.Text = "";
            txtAppointmentAddress.Text = "";
            txtAppointmentDate.Text = "";
            AppointmentTimeHour.Value=0;
            AppointmentTimeMinute.Value=0;
            chkReminder.Checked = false;
            cboAppointmentReminder.SelectedIndex = -1;
            cboAppointmentReminder.Text = "";
            chkTransportRequired.Checked = false;
            cboTransportType.SelectedIndex = -1;
            cboTransportType.Text = "";
            PickUpTimeHour.Value=0;
            PickUpTimeMinute.Value=0;
            DropOffTimeHour.Value=0;
            DropOffTimeMinute.Value=0;
        }

        bool SaveCalenderAppointment(string AppointmentSubject,
                                            string AppointmentAddress,
                                             string AppointmentDate,
                                               string AppointmentTimeHour,
                                                string AppointmentTimeMinute,
                                                string AppointmentReminderYN,
                                                string AppointmentReminderPeriod,
                                                string AppointmentTransportRequiredYN,
                                                string AppointmentNote,
                                                DateTime AppointmentTime)
        {
            try
            {
                string CalenderAppointmentLoadId = "";
                if (!lblCalenderAppointmentID.Text.Equals(""))
                {
                    CalenderAppointmentLoadId = lblCalenderAppointmentID.Text.ToString();
                }

                bool bSaved = commonFuncs.SaveCalenderAppointment(
                                ref CalenderAppointmentLoadId,
                               AppointmentSubject,
                               AppointmentAddress,
                               AppointmentDate,
                               AppointmentTimeHour,
                               AppointmentTimeMinute,
                               AppointmentReminderYN,
                               AppointmentReminderPeriod,
                               AppointmentTransportRequiredYN,
                               AppointmentNote,
                               AppointmentTime);
                lblCalenderAppointmentID.Text = CalenderAppointmentLoadId.ToString();
                

                return true;
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Saving Calender Appointment Exception: " + ex.ToString());
                return false;
            }
        }
        bool SaveAppointment(string AppointmentSubject, 
                string AppointmentAddress, 
                 string AppointmentDate, 
                   string AppointmentTimeHour,
                    string AppointmentTimeMinute,
                    string AppointmentReminderYN,
                    string AppointmentReminderPeriod,
                    string AppointmentTransportRequiredYN,
                    string AppointmentTransportType,
                    string AppointmentPickUpTimeHour,
                    string AppointmentPickUpTimeMinute,
                    string AppointmentDropOffTimeHour,
                    string AppointmentDropOffTimeMinute,
                    string CreatedBy, string AppointmentNote, string TranslatorYN)
        {
            try
            {
                string AppointmentLoadId = "";
                if (!lblAppointmentID.Text.Equals(""))
                {
                    AppointmentLoadId = lblAppointmentID.Text.ToString();
                }
                
                string CalenderAppointmentLoadId = "";
                if (!lblCalenderAppointmentID.Text.Equals(""))
                {
                    CalenderAppointmentLoadId = lblCalenderAppointmentID.Text.ToString();
                }
                bool bSaved = true;

                string sAppointDate = AppointmentDate +  " " + AppointmentTime.Text;
                DateTime dtAppointDate = System.Convert.ToDateTime(sAppointDate);
                bSaved = commonFuncs.SaveCalenderAppointment(ref CalenderAppointmentLoadId,
                                                   AppointmentSubject,
                               AppointmentAddress,
                               AppointmentDate + "" + AppointmentTime.Text,
                               AppointmentTimeHour,
                               AppointmentTimeMinute,
                               AppointmentReminderYN,
                               AppointmentReminderPeriod,
                               AppointmentTransportRequiredYN,
                               AppointmentNote,
                                dtAppointDate);
                if (bSaved)
                {
                    bSaved = commonFuncs.SaveAppointment(
                                   ref AppointmentLoadId,
                                   AppointmentSubject,
                                   AppointmentAddress,
                                   AppointmentDate,
                                   AppointmentTimeHour,
                                   AppointmentTimeMinute,
                                   AppointmentReminderYN,
                                   AppointmentReminderPeriod,
                                   AppointmentTransportRequiredYN,
                                   AppointmentTransportType,
                                   AppointmentPickUpTimeHour,
                                   AppointmentPickUpTimeMinute,
                                   AppointmentDropOffTimeHour,
                                   AppointmentDropOffTimeMinute,
                                   PatientFileNo,
                                   CreatedBy,
                                   AppointmentNote,
                                   AppointmentTime.Value,
                                   PickUpTime.Value,
                                   DropOffTime.Value, TranslatorYN, CalenderAppointmentLoadId);
                    lblAppointmentID.Text = AppointmentLoadId.ToString();
                }
                return bSaved;
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Saving Appointment Exception: " + ex.ToString());
                return false;
            }
            return true;
        }

        bool SendNotification(string AppointmentSubject, string AppointmentAddress, string AppointmentDate, ref string Notification, string SentTo)
        {
            try
            {
                bool bReturn = SendAppointmentEmailNotification(SentTo);

                if (!bReturn)
                {
                    Notification = ("\n Email Notification NOT Sent.");
                    bool bSendSMS = false;
                    if (bSendSMS)
                    {
                        string SMSMsg = "NEW APPOINTMENT[PATIENT:" + PatientName + "|DATE:" + AppointmentDate + "|LOCATION:" + AppointmentAddress + "]";

                        string DBSMSRecipients = System.Configuration.ConfigurationSettings.AppSettings["CaseManagersSMSCellList"];

                        if (DBSMSRecipients == null)
                        {
                            DBSMSRecipients = "27836415911";
                        }
                        if (DBSMSRecipients.Trim().Equals(""))
                        {
                            DBSMSRecipients = "27836415911";
                        }

                        string[] arrCellNo = DBSMSRecipients.Split(new Char[1] { ',' });

                        foreach (string smsCellNo in arrCellNo)
                        {
                            if (!smsCellNo.Trim().Equals(""))
                            {
                                SMSME.NET.Service SMSService = new SMSME.NET.Service();
                                bReturn = SMSService.Send_SMS(smsCellNo, SMSMsg, false, "", "", "", 0, "");
                                SMSService.Dispose();
                                if (bReturn)
                                {
                                    Notification = ("\n SMS Notification Sent Successfully");
                                }
                                else
                                {
                                    Notification = ("\n SMS Notification NOT Sent Successfully");
                                }
                            }
                        }
                        return bReturn;
                    }
                }
                else
                {
                    Notification = ("\n Email notification sent successfully.");
                }
                return bReturn;
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Saving Appointment Exception: " + ex.ToString());
                return false;
            }
            return true;
        }

        private bool ValidateControl()
        {
            bool ReturnValue = true;
            try
            {
                errProvider.Clear();

                if (txtAppointmentSubject.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtAppointmentSubject.Focus();
                    errProvider.SetError(txtAppointmentSubject, "Appointment Subject Missing.");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtAppointmentAddress.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtAppointmentAddress.Focus();
                    errProvider.SetError(txtAppointmentAddress, "Appointment Address Missing");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtAppointmentDate.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtAppointmentDate, "Appointment Date Missing.");
                    txtAppointmentDate.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                System.TimeSpan diffResult = System.Convert.ToDateTime(txtAppointmentDate.Text) - DateTime.Today.Date;
                if (diffResult.Days < 0)
                {
                    ReturnValue = false;
                    txtAppointmentDate.Focus();
                    errProvider.SetError(txtAppointmentDate, "Appointment Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                //if (AppointmentTimeHour.Value == 0 || AppointmentTimeHour.Value.ToString() == "")
                //{
                //    errProvider.SetError(AppointmentTimeHour, "Appointment Time (Hour) Missing.");
                //    AppointmentTimeHour.Focus();
                //    ReturnValue = false;
                //    return ReturnValue;
                //}

                //if (AppointmentTimeMinute.Value == 0 || AppointmentTimeMinute.Value.ToString() == "")
                //{
                //    errProvider.SetError(AppointmentTimeMinute, "Appointment Time (Minute) Missing.");
                //    AppointmentTimeMinute.Focus();
                //    ReturnValue = false;
                //    return ReturnValue;
                //}

                if (chkReminder.Checked)
                {
                    if (cboAppointmentReminder.SelectedItem != null && (cboAppointmentReminder.Text == ""))
                    {
                        errProvider.SetError(cboAppointmentReminder, "Please select Appointment Reminder period");
                        cboAppointmentReminder.Focus();
                        ReturnValue = false;
                        return ReturnValue;
                    }                    
                }

                if (chkTransportRequired.Checked)
                {
                    if (cboTransportType.SelectedItem == null)
                    {
                        errProvider.SetError(cboTransportType, "Please select Transport Type");
                        cboTransportType.Focus();
                        ReturnValue = false;
                        return ReturnValue;
                    }

                    if (cboTransportType.SelectedItem != null && (cboTransportType.Text == ""))
                    {
                        errProvider.SetError(cboTransportType, "Please select Transport Type");
                        cboTransportType.Focus();
                        ReturnValue = false;
                        return ReturnValue;
                    }

                    string spickUpTime = PickUpTime.Value.TimeOfDay.Hours.ToString() + PickUpTime.Value.TimeOfDay.Minutes.ToString();
                    string sdropUpTime = DropOffTime.Value.TimeOfDay.Hours.ToString() + DropOffTime.Value.TimeOfDay.Minutes.ToString();

                    if (spickUpTime == sdropUpTime)
                    {
                        errProvider.SetError(DropOffTime, "Drop Off Time Cannot be equal Pick Up Time");
                        DropOffTime.Focus();
                        ReturnValue = false;
                        return ReturnValue;
                    }
                    //if (PickUpTimeHour.Value == 0 || PickUpTimeHour.Value.ToString() == "")
                    //{
                    //    errProvider.SetError(PickUpTimeHour, "Appointment Pick-Up Time (Hour) Missing.");
                    //    PickUpTimeHour.Focus();
                    //    ReturnValue = false;
                    //    return ReturnValue;
                    //}

                    //if (PickUpTimeMinute.Value == 0 || PickUpTimeMinute.Value.ToString() == "")
                    //{
                    //    errProvider.SetError(PickUpTimeMinute, "Appointment Pick-Up Time (Minute) Missing.");
                    //    PickUpTimeMinute.Focus();
                    //    ReturnValue = false;
                    //    return ReturnValue;
                    //}

                    //if (DropOffTimeHour.Value == 0 || DropOffTimeHour.Value.ToString() == "")
                    //{
                    //    errProvider.SetError(DropOffTimeHour, "Appointment Drop-Off Time (Hour) Missing.");
                    //    DropOffTimeHour.Focus();
                    //    ReturnValue = false;
                    //    return ReturnValue;
                    //}

                    //if (DropOffTimeMinute.Value == 0 || DropOffTimeMinute.Value.ToString() == "")
                    //{
                    //    errProvider.SetError(DropOffTimeMinute, "Appointment Drop-Off Time (Minute) Missing.");
                    //    DropOffTimeMinute.Focus();
                    //    ReturnValue = false;
                    //    return ReturnValue;
                    //}
                }
            }
            finally
            {

            }
            return ReturnValue;
        }

        private void LoadTransportTypes()
        {
            try
            {
                DataTable tblAssistType = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new AIMS.BLL.LookUpTableCollections();
                tblAssistType = lookupBLL.GetLookUpValues("TRANSPORT_TYPE_ID", "TRANSPORT_TYPE_DESC", "aims_transport_type", 0, "TRANSPORT_TYPE_DESC");
                cboTransportType.DataSource = tblAssistType;
                cboTransportType.DisplayMember = "TRANSPORT_TYPE_DESC";
                cboTransportType.ValueMember = "TRANSPORT_TYPE_ID";
                cboTransportType.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void LoadAppointments()
        {
            DataTable dtAppointmentDetails = commonFuncs.GetAppointmentDetails(lblAppointmentID.Text);
            try
            {
                if (dtAppointmentDetails.Rows.Count > 0)
                {
                    txtAppointmentSubject.Text = dtAppointmentDetails.Rows[0]["APPOINTMENT_SUBJECT"].ToString();
                    txtPatientFile.Text = "[-" + PatientFileNo + "-]";

                    txtAppointmentSubject.Text = txtAppointmentSubject.Text.Replace("[-" + PatientFileNo + "-]", "");
                    
                    txtAppointmentAddress.Text = dtAppointmentDetails.Rows[0]["APPOINTMENT_ADDRESS"].ToString();
                    txtAppointmentDate.Text = dtAppointmentDetails.Rows[0]["APPOINTMENT_DATE"].ToString();

                    if (dtAppointmentDetails.Rows[0]["REMINDER_YN"].ToString().Equals("Y"))
                    {
                        chkReminder.Checked = true;
                        cboAppointmentReminder.Text = dtAppointmentDetails.Rows[0]["REMINDER_PERIOD"].ToString();
                    }
                    else
                    {
                        chkReminder.Checked = false;
                    }

                    if (dtAppointmentDetails.Rows[0]["TRANSPORT_YN"].ToString().Equals("Y"))
                    {
                        chkTransportRequired.Checked = true;
                        if (!dtAppointmentDetails.Rows[0]["TRANSPORT_TYPE_ID"].ToString().Equals(""))
                        {
                            cboTransportType.SelectedValue = Convert.ToInt32(dtAppointmentDetails.Rows[0]["TRANSPORT_TYPE_ID"]);
                        }
                    }
                    else
                    {
                        chkTransportRequired.Checked = false;
                    }

                    if (dtAppointmentDetails.Rows[0]["APPOINTMENT_TIME"] != System.DBNull.Value)
                    {
                        AppointmentTime.Value = Convert.ToDateTime(dtAppointmentDetails.Rows[0]["APPOINTMENT_TIME"]);
                    }

                    if (dtAppointmentDetails.Rows[0]["PICK_UP_TIME"] != System.DBNull.Value)
                    {
                        PickUpTime.Value = Convert.ToDateTime(dtAppointmentDetails.Rows[0]["PICK_UP_TIME"]);
                    }

                    if (dtAppointmentDetails.Rows[0]["DROP_OFF_TIME"] != System.DBNull.Value)
                    {
                        DropOffTime.Value = Convert.ToDateTime(dtAppointmentDetails.Rows[0]["DROP_OFF_TIME"]);
                    }

                    
                    txtAppointmentNote.Text = dtAppointmentDetails.Rows[0]["APPOINTMENT_NOTE"].ToString();

                    if (!txtAppointmentNote.Text.Trim().Equals(""))
	                {
                        txtAppointmentNote.Text = txtAppointmentNote.Text.Replace("[- PLEASE NOTE TRANSLATOR REQUIRED - ] \r\n", "");
	                }
                    
                    if (dtAppointmentDetails.Rows[0]["CANCELLED_YN"].ToString().Equals("Y"))
                    {
                        this.Text = "CANCELLED APPOINTMENT";
                        LockControls();
                    }

                    if (dtAppointmentDetails.Rows[0]["APPOINTMENT_STATUS"].ToString().Equals("COMPLETED"))
                    {
                        this.Text = "COMPLETED APPOINTMENT";
                        LockControls();
                    }

                    if (dtAppointmentDetails.Rows[0]["TRANSLATOR_YN"].ToString().Equals("Y"))
                    {
                        chkTranslator.Checked = true;
                    }
                    else
                    {
                        chkTranslator.Checked = false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Error loading Appointment Information: " + ex.ToString());
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading appointment details, Please contact System Administrator.");
            }
        }

        private void btnCancellAppointment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continue cancelling appointment ?","Appointment Cancellation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool bSaved = CancelAppointment(lblAppointmentID.Text ,UserID);
                if (bSaved)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Appointment cancelled Successfully.");
                    LoadAppointments();
                    this.DialogResult = DialogResult.OK;
                    this.Close();            
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error occured while cancelling Appointment. Please contact system Administrator");
                }
            }
        }

        void LockControls()
        {
            txtAppointmentSubject.ReadOnly = true;
            txtAppointmentAddress.ReadOnly = true;
            txtAppointmentDate.ReadOnly = true;
            chkReminder.Enabled = false;
            cboAppointmentReminder.Enabled  = false ;
            chkTransportRequired.Enabled = false;
            cboTransportType.Enabled = false;
            AppointmentTime.Enabled = false;
            PickUpTime.Enabled = false;
            DropOffTime.Enabled = false ;
            txtAppointmentNote.ReadOnly = true;
            btnSave.Enabled = false;
            btnCancellAppointment.Enabled = false;
            btnDiscardChanges.Enabled = false;
            lnklblAppointmentDate.Enabled = false;
            chkCMEmailSMSAlert.Enabled = false;
            btnCloseAppointment.Enabled = false;
        }
        bool CancelAppointment(string AppointmentID, string userName)
        {
            try
            {
                string AppointmentLoadId = "";
                if (!lblAppointmentID.Text.Equals(""))
                {
                    AppointmentLoadId = lblAppointmentID.Text.ToString();
                }
                bool bSaved = commonFuncs.CancelAppointment(AppointmentLoadId, userName);
                return true;
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Cancelling Appointment Exception: " + ex.ToString());
                return false;
            }
            return true;
        }

        bool CompleteAppointment(string AppointmentID, string userName)
        {
            try
            {
                string AppointmentLoadId = "";
                if (!lblAppointmentID.Text.Equals(""))
                {
                    AppointmentLoadId = lblAppointmentID.Text.ToString();
                }
                bool bSaved = commonFuncs.CompleteAppointment(AppointmentLoadId, userName);
                return true;
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Cancelling Appointment Exception: " + ex.ToString());
                return false;
            }
            return true;
        }

        private void chkReminder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReminder.Checked)
            {
                cboAppointmentReminder.Enabled = true;
            }
            else
            {
                cboAppointmentReminder.Enabled = false;
            }
        }

        public bool SendAppointmentEmailNotification(string SentTo)
        {
            bool bReturn = false;
            string EmailBody = "";
            
            EmailBody = @"<html>
               <head>
               <style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left}</style>
               </head>
               <body>
                  <br>    <br>    <br>    <br>    
                  <table width=100% cellpadding=2 cellspacing=1 align=center>
                     <tr>
                        <td colspan=4 align=left bgcolor=lightgrey>
                           <center><font color=green size=4 >New Appointment</font></center>
                        </td>
                     </tr>
                     <tr>
                        <td bgcolor=lightgrey valign=bottom colspan=4><b>Patient File Details</b></td>
                     </tr>
                     <tr>
                        <td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>File No</td>
                        <td colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>"+ PatientFileNo +@"</b></font></td>
                     </tr>
                     <tr>
                        <td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient Name</td>
                        <td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>"+ PatientName +@"</b></font></td>
                     </tr>
                     <tr>
                        <td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient Guarantor</td>
                        <td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>"+ Guarantor +@"</b></font></td>
                     </tr>

                     <tr>
                        <td bgcolor=lightgrey valign=bottom colspan=4><b>Appointment Details</b></td>
                     </tr>
                     <tr>
                        <td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Location Address</td>
                        <td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>"+txtAppointmentAddress.Text +@"</b></font></td>
                     </tr>
                     <tr>
                        <td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Date</td>
                        <td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>"+ txtAppointmentDate.Text+@"</b></font></td>
                     </tr>
                     <tr>
                        <td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Time</td>
                        <td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>" + AppointmentTime.Text + @"</b></font></td>
                     </tr>
                     <tr>
                        <td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Additional Notes</td>
                        <td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>" + txtAppointmentNote.Text  +@"</b></font></td>
                     </tr>
                     <tr>
                        <td bgcolor=lightgrey valign=bottom colspan=4><b>Case</b></td>
                     </tr>
                     <tr>
                        <td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Appointment Captured By</td>
                        <td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>" + UserID  + @"</td>
                     </tr>
                     <tr>
                        <td bgcolor=#ffffff colspan=4>&nbsp; </td>
                     </tr>
                  </table>
               </body>
            </html>";
            //bReturn = SendMailWithAttachment("martitian@gmail.com", "", "", "TESTING", "TREST", "Operations@AIMS.org.co.za", "");
            bReturn = commonFuncs.SendEmail(EmailBody, "Operations@AIMS.org.za", "Operations", txtAppointmentSubject.Text , SentTo, "");

            return bReturn;
        }

        private void btnCloseAppointment_Click(object sender, EventArgs e)
        {
            if (!lblAppointmentID.Text.Trim().Equals("") && MessageBox.Show("Close appointment ?", "Appointment Information Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool bSaved = CompleteAppointment(lblAppointmentID.Text, UserID);
                if (bSaved)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Appointment completed Successfully.");
                    LoadAppointments();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error occured while cancelling Appointment. Please contact system Administrator");
                }
            }
        }
    }
}