using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Skins.Info;
using DevExpress.Skins.XtraForm;
using DevExpress.XtraScheduler;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AIMSClient
{
    public partial class Calender : Form
    {
        AIMS.Common.CommonFunctions cmmnFuncs;
        string _userName = "";
        string _userID = "";
        string _restrictions = "";

        #region "Public Properties"
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }
        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }

        public string Restrictions
        {
            get { return _restrictions; }
            set
            {
                _restrictions = value;
            }
        }
        #endregion
        public Calender()
        {
            InitializeComponent();
            InitSkinHelper();
            AIMSScheduler.Start = System.DateTime.Now;
            this.schedulerStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            this.schedulerStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            this.schedulerStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;
        }

        void InitSkinHelper()
        {
            SkinHelperBase ss = new SkinHelperBase(SkinProductId.Bars);
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            OverdueTasksSetup();
            LoadOverDueTasks();
            LoadCalender();
            cmmnFuncs.ErrorLogger("INSTRUMENTATION - Loading Calender Control Started");
            AIMSScheduler.ActiveViewType = SchedulerViewType.Month;
            AIMSScheduler.Views.MonthView.ShowWeekend = true;
            //AIMSScheduler.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            AIMSScheduler.OptionsView.FirstDayOfWeek = FirstDayOfWeek.Monday;
            AIMSScheduler.MonthView.CompressWeekend = false;
            dateNavigator1.Visible = false;
            cmmnFuncs.ErrorLogger("INSTRUMENTATION - Loading Calender Control Completed");
        }

        void LoadCalender()
        {
            cmmnFuncs = new AIMS.Common.CommonFunctions();
            cmmnFuncs.ErrorLogger("INSTRUMENTATION - Loading Calender Started");
            //this.resourcesTableAdapter.Fill(this.dsResources.Resources);
            this.appointmentsTableAdapter.Fill(this.dsAppointments.Appointments);
            cmmnFuncs.ErrorLogger("INSTRUMENTATION - Loading Calender Completed");
            OverdueTasksSetup();
            LoadOverDueTasks();
        }
        private bool CreatePatientFilAppointment(string subject, string location, DateTime appointmentdate, DateTime appointmenttime, string reminderYN, string reminderPeriod, string PatientFileNo, string AppointmentNote, string SubjectPatientFileNo)
        {
            string AppointmentLoadId = "";
            DateTime dt1 = new DateTime();
            bool bSaved = cmmnFuncs.SaveAppointment(
                           ref AppointmentLoadId,
                           subject,
                           location ,
                           appointmentdate.ToString() ,
                           "",
                           "",
                           reminderYN,
                           reminderPeriod,
                           "N",
                           "",
                           "",
                           "",
                           "",
                           "",
                           SubjectPatientFileNo,
                           UserID,
                           AppointmentNote,
                           appointmentdate,
                           dt1,
                           dt1,
                           "N", "");
            return true;
        }
        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
            try
            {
                cmmnFuncs = new AIMS.Common.CommonFunctions();

                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please create or edit this appointment from patient-file");
                return;

                string emailSubjectLine = "";

                AppointmentBaseCollection apts = (AppointmentBaseCollection)e.Objects;
                
                string appSubject = "";
                string appLocation = ""; 
                DateTime appStart = System.DateTime.Today;
                DateTime appEnd = System.DateTime.Today;
                string appDescription = "";
                string appreminderYN = "N";
                string appreminderPeriod = "";
                DataRow row = null;
                bool bDeleting = false;

                foreach (Appointment apt in apts)
                {
                    row = GetAppointmentRow(apt);
                    if (row == null )
                    {
                        bDeleting = true;
                        break;
                    }
                    emailSubjectLine = apt.Subject.Trim();

                    if (apt.Reminder != null )
                    {
                        appreminderYN = "Y";
                        appreminderPeriod = apt.Reminder.TimeBeforeStart.ToString();
                    }
                     
                    appSubject = apt.Subject;
                    appLocation = apt.Location;
                    appStart = apt.Start;
                    appEnd = apt.End;
                    appDescription = apt.Description;
                    appreminderYN = "N";
                    appreminderPeriod = "";
                }

                if (!bDeleting)
                {
                    if (emailSubjectLine.Equals(""))
                    {
                        cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Appointment Subject Missing");
                        row.Delete();
                        row.CancelEdit();
                        appointmentsTableAdapter.Update(dsAppointments);
                        dsAppointments.AcceptChanges();
                    }
                    else
                    {
                        string PatientFiles = GetAppointmentPatientFiles(emailSubjectLine);
                        if (!PatientFiles.Trim().Equals(""))
                        {
                            bool caseFileNoFound = CheckPatientFileNo(PatientFiles, appSubject, appLocation, appStart, appEnd, appDescription, appreminderYN, appreminderPeriod);
                            if (caseFileNoFound)
                            {
                                appointmentsTableAdapter.Update(dsAppointments);
                                dsAppointments.AcceptChanges();
                                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Appointment created successfully and linked to the following Patient File Numbers: \n\n " + PatientFiles);
                            }
                            else
                            {
                                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Appointment Subject contains INVALID Patient File Number. \n\n Saving Error to the database");
                                row.Delete();
                            }
                        }
                        else
                        {
                            cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Appointment Subject Missing Patient File Number. \n\n Saving Error to the database");
                        }
                    }
                }
                else
                {
                    appointmentsTableAdapter.Update(dsAppointments);
                    dsAppointments.AcceptChanges();
                    cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Appointment deleted successfully");
                }
            }
            catch (System.Exception EX)
            {
                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error while saving the Appointment Details");
                cmmnFuncs.ErrorLogger("Error while saving the Appointment Details: Exception: " + EX.ToString());
            }
        }

        private bool CheckPatientFileNo(string PatientFiles, string appSubject, string appLocation, DateTime appStart, DateTime appEnd, string appDescription, string appreminderYN, string appreminderPeriod)
        {
            PatientFiles = PatientFiles.Replace("|", ";");
            string[] arrPatientFiles = PatientFiles.Split(new Char[] { ';' });
            string CheckPatientFile = "";
            bool bFileFound = false;
            foreach (string PatientFile in arrPatientFiles)
            {
                if (!PatientFile.Trim().Equals(""))
                {
                    CheckPatientFile = PatientFile;
                    bool ValidFile = ValidPatientFileNo(CheckPatientFile);
                    if (ValidFile)
                    {
                        bFileFound = true;
                        CreatePatientFilAppointment(appSubject, appLocation, appStart, appEnd, appreminderYN, appreminderPeriod, "", appDescription, CheckPatientFile);
                    }
                }
            }
            return bFileFound;
        }

        public bool ValidPatientFileNo(string PatientFileNo)
        {
            bool Returnvalue = false;
            try
            {
                Returnvalue = cmmnFuncs.ValidPatientFileNo(PatientFileNo);
            }
            catch (System.Exception ex)
            {
                Returnvalue = false;
            }
            return Returnvalue;
        }


        private DataRow GetAppointmentRow(Appointment apt)
        {
            try
            {
                return ((DataRowView)schedulerStorage1.GetObjectRow(apt)).Row;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        private string GetAppointmentPatientFiles(string AppointmentSubjects)
        {
            string PatientFiles = "";
            try
            {
                AppointmentSubjects = AppointmentSubjects.Replace(@"[-", " ");
                AppointmentSubjects = AppointmentSubjects.Replace(@"-]", " ");

                //Append spaces at the beginning and the end of the string
                AppointmentSubjects = " " + AppointmentSubjects + " ";

                string input4 = @AppointmentSubjects;
                Regex word4 = new Regex(@"\b\d{1,2}\/\d{1,4}\b");

                Match m4 = word4.Match(input4);
                while (!m4.ToString().Trim().Equals(""))
                {
                    if (!m4.ToString().Trim().Equals(""))
                    {
                        PatientFiles += m4.ToString() + "|";
                    }
                    input4 = input4.Replace(m4.ToString(), "");
                    word4 = new Regex(@"\b\d{1,2}\/\d{1,4}\b");
                    m4 = word4.Match(input4);
                }

                word4 = new Regex(@"\b\d{1,2}\\\d{1,4}\b");

                m4 = word4.Match(input4);
                while (!m4.ToString().Trim().Equals(""))
                {
                    if (!m4.ToString().Trim().Equals(""))
                    {
                        PatientFiles += m4.ToString().Replace(@"\", @"/") + "|";
                    }
                    input4 = input4.Replace(m4.ToString(), "");
                    word4 = new Regex(@"\b\d{1,2}\\\d{1,4}\b");
                    m4 = word4.Match(input4);
                }

                if (!PatientFiles.Equals("") && PatientFiles.EndsWith("|"))
                {
                    PatientFiles = PatientFiles.Substring(0, PatientFiles.Length - 1);
                }
            }
            catch (System.Exception)
            {
            }
            return PatientFiles;
        }

        private void AIMSScheduler_Click(object sender, EventArgs e)
        {

        }

        private void OverdueTasksSetup()
        {
            lstlvOverdueTasks.Columns.Clear();
            lstlvOverdueTasks.Items.Clear();
            lstlvOverdueTasks.Columns.Add("Co-Ordinator", Convert.ToInt32(lstlvOverdueTasks.Width * 0.15), HorizontalAlignment.Left);
            lstlvOverdueTasks.Columns.Add("Patient File No", Convert.ToInt32(lstlvOverdueTasks.Width * 0.15), HorizontalAlignment.Left);
            lstlvOverdueTasks.Columns.Add("Task Description", Convert.ToInt32(lstlvOverdueTasks.Width * 0.66), HorizontalAlignment.Left);
            lstlvOverdueTasks.Columns.Add("Due Date", Convert.ToInt32(lstlvOverdueTasks.Width * 0.2), HorizontalAlignment.Left);
            lstlvOverdueTasks.Columns.Add("Priority", Convert.ToInt32(lstlvOverdueTasks.Width * 0.2), HorizontalAlignment.Left);
            lstlvOverdueTasks.Columns.Add("Status", Convert.ToInt32(lstlvOverdueTasks.Width * 0.2), HorizontalAlignment.Left);
            lstlvOverdueTasks.Columns.Add("Created/Changed By", Convert.ToInt32(lstlvOverdueTasks.Width * 0.2), HorizontalAlignment.Left);
            lstlvOverdueTasks.Columns.Add("Created Date", Convert.ToInt32(lstlvOverdueTasks.Width * 0.2), HorizontalAlignment.Left);
            lstlvOverdueTasks.View = View.Details;
        }

        private void LoadOverDueTasks()
        {
            AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItem;
            DataTable dtMyMails = new DataTable();
            bool RecordsFound = false;

            lstlvOverdueTasks.Items.Clear();
            lstlvOverdueTasks.View = View.Details;

            try
            {
                dtMyMails = commonFuncs.Get_AIMS_OverdueTasks();
                if (dtMyMails.Rows.Count > 0)
                {
                    RecordsFound = true;
                    for (int i = 0; i < dtMyMails.Rows.Count; i++)
                    {
                        Application.DoEvents();
                        lvwItem = new ListViewItem(dtMyMails.Rows[i]["USER_ID"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["TASK_DESC"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["DUE_DATE"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["PRIORITY"].ToString());
                        lvwItem.SubItems.Add("ACTIVE");
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["LOADED_BY"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["CREATION_DATE"].ToString());

                        if (dtMyMails.Rows[i]["PRIORITY"].ToString().ToUpper() == "HIGH")
                        {
                            lstlvOverdueTasks.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else
                        {
                            lstlvOverdueTasks.Items.Add(lvwItem);
                        }
                       
                        foreach (ColumnHeader lstCols in lstlvOverdueTasks.Columns)
                        {
                            lstCols.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                        Application.DoEvents();
                    }
                }
                if (RecordsFound)
                {
                    foreach (ColumnHeader colHead1 in lstlvOverdueTasks.Columns)
                    {
                        colHead1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
                else
                {
                    foreach (ColumnHeader colHead1 in lstlvOverdueTasks.Columns)
                    {
                        colHead1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }

                dtMyMails.Dispose();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Loading your Work Basket Audit, Please contact System Administror");
                commonFuncs.ErrorLogger("Error Loading your Work Basket Audit: \n" + ex.ToString());
            }
            finally
            {
                lvwItem = null;
            }
        }

        private void tmrCalender_Tick(object sender, EventArgs e)
        {
            
        }

        private void AIMSScheduler_Click_1(object sender, EventArgs e)
        {

        }

        private void AIMSScheduler_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("My New Appointment click");
        }

        void AIMSScheduler_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            //if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            //{
                e.Menu.Items.Clear();
            //}
        }

        private void btnApplySetting_Click(object sender, EventArgs e)
        {
            //switch (cboCalenderViewType.SelectedIndex)
            //{
            //    case 0:
            //        AIMSScheduler.ActiveViewType = SchedulerViewType.Day;
            //        break;
            //    case 1:
            //        AIMSScheduler.ActiveViewType = SchedulerViewType.Week;
            //        AIMSScheduler.MonthView.CompressWeekend = false;
            //        AIMSScheduler.WeekView.ViewInfo.ShowWeekend = true;
            //        AIMSScheduler.WeekView.ViewInfo.CompressWeekend = false;
            //        break;
            //    case 2:
            //        AIMSScheduler.ActiveViewType = SchedulerViewType.Month;
            //        AIMSScheduler.Views.MonthView.ShowWeekend = true;
            //        //AIMSScheduler.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //        AIMSScheduler.OptionsView.FirstDayOfWeek = FirstDayOfWeek.Monday;
            //        AIMSScheduler.MonthView.CompressWeekend = false;
            //        break;
            //    case 3:
            //        AIMSScheduler.ActiveViewType = SchedulerViewType.WorkWeek;
            //        break;
            //    case 4:
            //        AIMSScheduler.ActiveViewType = SchedulerViewType.Timeline;
            //        break;
            //}           
        }

        private void btnRefreshCalender_Click(object sender, EventArgs e)
        {
            //LoadCalender();
        }

        private void btnDateNavigator_Click(object sender, EventArgs e)
        {
            //dateNavigator1.Visible = true;
            
        }

        private void mnuShowDtNavigator_Click(object sender, EventArgs e)
        {
            dateNavigator1.Visible = true;
        }

        private void mnuHideDtNavigator_Click(object sender, EventArgs e)
        {
            dateNavigator1.Visible = false;
        }

        private void calRefresh_Click(object sender, EventArgs e)
        {
            LoadCalender();
        }

        private void calMonthView_Click(object sender, EventArgs e)
        {
            AIMSScheduler.ActiveViewType = SchedulerViewType.Month;
            AIMSScheduler.Views.MonthView.ShowWeekend = true;
            //AIMSScheduler.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            AIMSScheduler.OptionsView.FirstDayOfWeek = FirstDayOfWeek.Monday;
            AIMSScheduler.MonthView.CompressWeekend = false;

        }

        private void calWeekView_Click(object sender, EventArgs e)
        {
            AIMSScheduler.ActiveViewType = SchedulerViewType.Week;
            AIMSScheduler.MonthView.CompressWeekend = false;
            AIMSScheduler.WeekView.ViewInfo.ShowWeekend = true;
            AIMSScheduler.WeekView.ViewInfo.CompressWeekend = false;
        }

        private void calDayView_Click(object sender, EventArgs e)
        {
            AIMSScheduler.ActiveViewType = SchedulerViewType.Day;
        }

        private void cboCalenderViewType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}