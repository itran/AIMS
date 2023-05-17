
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.IO; 
using System.Collections;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Drawing;
using System.Net.Mail;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Exchange.WebServices.Autodiscover;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
//using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
using System.Net;
//using System.IdentityModel;
//using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using AIMReports.Properties;
using System.Net.Sockets;

namespace AIMS.EWS
{
    public partial class Form1 : Form
    {
        string rptYear = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void ProcessManual()
        {

            //GenerateInPatient("Bernadette@aims.org.za;Stanley@aims.org.za;Hendrikj@aims.org.za;dominicb@aims.org.za;interim@aims.org.za;operations@aims.org.za;eric@aims.org.za;annick@aims.org.za");
            //GenerateOutPatient("Bernadette@aims.org.za;Stanley@aims.org.za;Hendrikj@aims.org.za;dominicb@aims.org.za;interim@aims.org.za;operations@aims.org.za;eric@aims.org.za;annick@aims.org.za");
            //GenerateFilesCancelled7DaysAgo();
            //GenerateFilesCourierAfterDischarge();
            //GenerateFilesForPatientsDischargedInLast24Hours();
            //DailyWorkbaskedActivity();

            //GenerateAfterHoursFiles();
            //GenerateWorkBaskets();
            //GenerateWorkBasketsAdmin();
            //GenerateFilesNotAssignedToAdmin();
            //ProcessPendedCase();

            //Generate6677Providers();
            //GenerateNotSentToAdminAfter48HrsDischarge();
            GenerateHighCost("eric@aims.org.za;racheal@aims.org.za;jade@aims.org.za");


            //GenerateAfterHoursFiles();
            //GenerateWorkBaskets();
            //GenerateWorkBasketsAdmin();
            //GenerateFilesNotAssignedToAdmin();
            //ProcessPendedCase();
            //GenerateFilesForPatientsDischargedInLast24Hours();
            //GenerateNotSentToAdminAfter48HrsDischarge();
            //DischargeFileSummary();
            //GenerateOverDueTasks("stanley@aims.org.za;;;DanielM@aims.org.za");
            //GenerateFilesForPatientsDischargedInLast24Hours();
            //DailyWorkbaskedActivity();
            //GenerateFilesWithoutCommentsinLast24HoursPerGuarantor();
            ////GenerateFilesPendedForTenDays();
            //GenerateFilesWithoutMedicalCommentsinLast24Hours();
            //GenerateDailyUPSFiles();
            //GenerateDailySentLateSubmission();

            //GenerateFilesCancelled7DaysAgo();
            //GenerateFilesCourierAfterDischarge();
            ////GenerateFilesCourierAfterDischargeLateLog();
            ////GenerateFilesPendedWithFutureAdmissionDate();

            ////GenerateGuarantorFiles();
            ////OpsGuarantorCancelledSentToAdminFiles();
            ////GenerateMonthlyOpsKPI();
            ////GenerateMonthlyAdminKPI();


            ////GenerateAdminDischargeList();
            ////MessageBox.Show("Start Sending Report");
            ////AdminActiveFiles();
            ////Generate6677Providers();

            ////GenerateFilesCancelled7DaysAgo(); 

            ////OpsGuarantorCancelledSentToAdminFiles();
            ////TimeSpan tpsn = new TimeSpan(
            ////DateTime.Now.Subtract(DateTime.Now-1)

            ////GenerateGuarantorFiles();

            ////GenerateMonthlyAdminKPI();
            ////GenerateMonthlyOpsKPI();
            ////DailyWorkbaskedActivity();
            ////GenerateGuarantorFiles();
            ////GenerateAdminDischargeList();
            ////GenerateDailyUPSFiles();
            ////GenerateNotSentToAdminAfter48HrsDischarge();

            ////MessageBox.Show("DONE Sending Report");
            //// Application.ExitThread();

            ////AdminActiveFiles(); 
            //// DailyWorkbaskedActivity();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //EWSSendEmailNowGIPF("TEST Email", "ihorizon@gipf.com.na", "From-Name", "Test","brian.maswanganye@itq.co.za","",false,"","");
            //string clientId = "2efcf754-471e-4a9a-85fd-f3dd08b62c35";
            ////string secret = "67ded17d-5d85-4368-825e-6449f029773a";
            ////string secret = "uE08Q~BgmekX41aZOWUmtI0D~KcPNASSRfUOQb6X";
            //string secret = "Vm18Q~OCxKXyH86soQDlJKx2xHAIJ9X7jeulCbfs";
            //string tenantId = "9d40314f-1d37-457d-b900-21bc738c85bd";

            ////MainAsync().GetAwaiter().GetResult();

            //string MailboxBeingAccessed = ""; 
            //string AccountAccessingMailbox = "";
            //string sAuthority = "";
            //string sAppId = "2efcf754-471e-4a9a-85fd-f3dd08b62c35";
            //string sRedirectURL = "";
            //string sServername = "";
            //string sBearerToken = "";
            //PromptBehavior oPromptBehavior = PromptBehavior.Auto;
            ////SendEmail();

            //EWSSendEmailNow("FINAL TESTING ", "Operations@AIMS.org.za", "Operations@AIMS.org.za", "DrillReportEmailSubject", "martitian@Gmail.com;i.tran@yahoo.co.uk", "", false, "", "martitian@gmail.com");

            //Do_OAuth(ref MailboxBeingAccessed, ref AccountAccessingMailbox,
            //             sAuthority, sAppId, sRedirectURL, sServername, ref sBearerToken, oPromptBehavior);

            //            AccessEmails();
            //GenerateOAuth2AccessToken(clientId, secret, tenantId);


            //ProcessMailAsync("", "", "");

            OpenDBConnection();
            CaseLastCommentSLA = System.Configuration.ConfigurationSettings.AppSettings["CaseLastCommentSLA"];

            //// ****************************************************MANUAL PROCESSING**
            //MessageBox.Show(" Sending Report");
            //ProcessManual();
            //////DailyWorkbaskedActivity();
            //////GenerateAdminDischargeList();
            //////EWSSendEmailNow("TEST EMAIL", "Operations@AIMS.org.za", "Operations@AIMS.org.za", "TEST", "martitian@gmail.com", "", false, "", "martitian@gmail.com");
            //////GenerateGuarantorFiles();
            //////OpsGuarantorCancelledSentToAdminFiles();
            //////GenerateMonthlyOpsKPI();
            //////GenerateMonthlyAdminKPI();
            ////GenerateInPatient("Bernadette@aims.org.za;Stanley@aims.org.za;Hendrikj@aims.org.za;dominicb@aims.org.za;interim@aims.org.za;operations@aims.org.za;eric@aims.org.za;annick@aims.org.za");
            ////GenerateOutPatient("Bernadette@aims.org.za;Stanley@aims.org.za;Hendrikj@aims.org.za;dominicb@aims.org.za;interim@aims.org.za;operations@aims.org.za;eric@aims.org.za;annick@aims.org.za");
            //CloseDBConnections();
            //MessageBox.Show("DONE Sending Report");
            //Application.ExitThread();
            //return;
            ////****************************************************

            try
            {
                if ((DateTime.Now.DayOfWeek > DayOfWeek.Sunday | DateTime.Now.DayOfWeek < DayOfWeek.Saturday) & (DateTime.Now.Hour == 18 && DateTime.Now.ToString("tt") == "PM")){
                    //GenerateFilesCourierGreaterThan100K();
                    //GenerateFilesNOTCourierGreaterThan100K();
                    GenerateFilesWithoutCommentsinLast24HoursPerGuarantor();
                    //GenerateFilesPendedForTenDays();
                    GenerateFilesWithoutMedicalCommentsinLast24Hours();
                }

                if ((DateTime.Now.DayOfWeek > DayOfWeek.Sunday | DateTime.Now.DayOfWeek < DayOfWeek.Saturday) & (DateTime.Now.Hour == 16 && DateTime.Now.ToString("tt") == "PM")){
                    //GenerateFilesNotTaggedToOperators();
                    //GenerateInPatient("Stanley@aims.org.za;dominicb@aims.org.za;operations@aims.org.za;eric@aims.org.za;annick@aims.org.za");
                    //GenerateOutPatient("Stanley@aims.org.za;dominicb@aims.org.za;operations@aims.org.za;eric@aims.org.za;annick@aims.org.za");
                    //GenerateFilesNotAssignedToAdmin();
                }

                if ((DateTime.Now.DayOfWeek > DayOfWeek.Sunday | DateTime.Now.DayOfWeek < DayOfWeek.Saturday) & (DateTime.Now.Hour == 17 && DateTime.Now.ToString("tt") == "PM"))
                {
                    GenerateDailyUPSFiles();
                    GenerateDailySentLateSubmission();
                }

                int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
                if ((DateTime.Now.Hour == 23 && DateTime.Now.ToString("tt") == "PM") && (lastDay == DateTime.Now.Day))
                {
                    GenerateGuarantorFiles();
                    OpsGuarantorCancelledSentToAdminFiles();
                    GenerateMonthlyOpsKPI();
                    GenerateMonthlyAdminKPI();
                }

                if ((DateTime.Now.DayOfWeek > DayOfWeek.Sunday | DateTime.Now.DayOfWeek < DayOfWeek.Saturday) & (DateTime.Now.Hour == 15 && DateTime.Now.ToString("tt") == "PM"))
                {
                    GenerateAdminDischargeList();
                }

                if ((DateTime.Now.DayOfWeek > DayOfWeek.Sunday | DateTime.Now.DayOfWeek < DayOfWeek.Saturday) & (DateTime.Now.Hour == 7 && DateTime.Now.ToString("tt") == "AM"))
                {
                    //GenerateAfterHoursFiles();
                    GenerateWorkBaskets();
                    GenerateWorkBasketsAdmin();
                    //GenerateFilesNotAssignedToAdmin();
                    ProcessPendedCase();
                }

                if (DateTime.Now.Hour == 7 && DateTime.Now.ToString("tt") == "AM")
                {
                    //Generate6677Providers();
                    //GenerateFilesForPatientsDischargedInLast24Hours();
                    //GenerateNotSentToAdminAfter48HrsDischarge();
                    GenerateHighCost("eric@aims.org.za;racheal@aims.org.za;jade@aims.org.za");
                }

                // Administration Productivity
                if ((DateTime.Now.DayOfWeek == DayOfWeek.Monday) & (DateTime.Now.Hour == 7 && DateTime.Now.ToString("tt") == "AM"))
                {
                    //GenerateAdminProductivity( );
                    //GenerateFilesAdmittedNOTDischargedAfter14Days();
                    GenerateFilesCancelled7DaysAgo();
                    GenerateFilesCourierAfterDischarge();
                    //GenerateFilesCourierAfterDischargeLateLog();
                    //GenerateFilesPendedWithFutureAdmissionDate();
                }

                // Administration Discharge Summary
                if ((DateTime.Now.DayOfWeek == DayOfWeek.Monday ||
                    DateTime.Now.DayOfWeek == DayOfWeek.Tuesday || 
                    DateTime.Now.DayOfWeek == DayOfWeek.Wednesday ||
                    DateTime.Now.DayOfWeek == DayOfWeek.Thursday  ||
                    DateTime.Now.DayOfWeek == DayOfWeek.Friday) & (DateTime.Now.Hour == 8 && DateTime.Now.ToString("tt") == "AM"))
                {
                    DischargeFileSummary();
                    //GenerateOverDueTasks("stanley@aims.org.za;;;DanielM@aims.org.za");
                }
                if ((DateTime.Now.DayOfWeek == DayOfWeek.Monday) & (DateTime.Now.Hour == 8 && DateTime.Now.ToString("tt") == "AM"))
                {
                    //GenerateOverDueTasks("stanley@aims.org.za;");
                }
                
                if (DateTime.Now.Hour == 6 && DateTime.Now.ToString("tt") == "AM")
                {
                    //GenerateFilesForPatientsDischargedInLast24Hours();
                    //GenerateInPatient("Bernadette@aims.org.za;Stanley@aims.org.za;Hendrikj@aims.org.za;dominicb@aims.org.za;interim@aims.org.za;operations@aims.org.za;eric@aims.org.za;annick@aims.org.za");
                    //GenerateOutPatient("Bernadette@aims.org.za;Stanley@aims.org.za;Hendrikj@aims.org.za;dominicb@aims.org.za;interim@aims.org.za;operations@aims.org.za;eric@aims.org.za;annick@aims.org.za");
                    //AdminActiveFiles();
                    //DailyWorkbaskedActivity();
                }
                
                //GenerateFilesTaggedToOperators();
                //GenerateFilesTaggedToOperatorsWithoutMedicalComments();
                //GenerateFilesWithoutCommentsinLast24Hours();
                
               CloseDBConnections();
            }
            catch (System.Exception ex)
            {
                LogMessages(ex.ToString(), "Running Reporter Error: " + ex.ToString() , true);
            }
            finally
            {
                Application.ExitThread();
            }
        }
        #region "Local Declarations"
        public OleDbConnection oleDBConnection;
        public OleDbCommand oleDBCmd;
        string CaseLastCommentSLA = "2";
        #endregion

        #region "Database Methods"
        public bool OpenDBConnection()
        {
            bool DBConnected = false;
            try
            {
                string DBConnectString = System.Configuration.ConfigurationSettings.AppSettings["ConnectString"];
                //DBConnectString = @"Provider=SQLOLEDB;Server=LAPTOP-VM3C2I5J\WIGANPIER;Database=AIMS;Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Integrated Security=SSPI";
                //DBConnectString = @"Provider=SQLOLEDB;Database=AIMS_UPDATES;Data Source=ITQ-BRIAN-L\BRIAN;Integrated Security=SSPI";
                oleDBConnection = new OleDbConnection();
                LogMessages(DBConnectString, "AIMS Utility Progress - Connection String", true);
                oleDBConnection.ConnectionString = DBConnectString;
                oleDBConnection.Open();
                DBConnected = true;
            }
            catch (System.Exception ex)
            {
                LogMessages(ex.ToString(), "AIMS Utility Stop Error", true);
                if (oleDBConnection != null && oleDBConnection.State == ConnectionState.Open)
                {
                    DBConnected = true;
                }
                else
                {
                    DBConnected = false;
                }
            }
            return DBConnected;
        }

        public void CloseDBConnections()
        {
            try
            {
                if (oleDBConnection != null && oleDBConnection.State == ConnectionState.Open)
                {
                    oleDBConnection.Close();
                    oleDBConnection.Dispose();
                }
            }
            catch (System.Exception ex)
            {
                LogMessages(ex.ToString(), "Closing Database Connections", true);
            }
        }
        #endregion

        #region "Error Logging Methods"
        protected void LogMessages(string ErrorLog, string ErrorSource, bool ErrorNote)
        {
            try
            {
                
                
                string LogFileName = @"C:\AIMS Recorder\AIMSUtility - " + System.DateTime.Now.ToString("ddMMMyyyy") + ".log";
                StreamWriter strWriter = File.AppendText(LogFileName);

                if (ErrorNote)
                {
                    strWriter.WriteLine(System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm:sss") + "------" + "AIMS Utility Error Report");
                    strWriter.WriteLine(System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm:sss") + "------" + "AIMS Utility Error Source: " + ErrorSource);
                    strWriter.WriteLine(System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm:sss") + "------" + "AIMS Utility Error : " + ErrorLog);
                }
                else
                {
                    strWriter.WriteLine(System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm:sss") + "------" + "AIMS Utility Progress Report");
                    strWriter.WriteLine(System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm:sss") + "------" + "AIMS Utility Status : " + ErrorLog);
                }

                strWriter.Flush();
                strWriter.Close();
                strWriter.Dispose();
            }
            finally
            {
            }
        }
        #endregion

        #region "Polling Timer"
        private void AIMSTimer_Tick(object sender, EventArgs e)
        {

        }

        private void AIMSTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.LogMessages("Service Running", "", false);
        }
        #endregion

        #region "Processing Functions"
        public void AIMSReports()
        {
            try
            {
                bool DBConnect = OpenDBConnection();
                if (DBConnect)
                {
                    string SQLString = "";

                }
                else
                {
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public void ProcessPendedCase() 
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string PatientID = "";
            string CoOrdinator = "";
            string SQLString = "";

            try
            {
                SQLString = "select a.PEND_DATE, b.MODIFIED_USER, a.FILE_OPERATOR_TO_USERID ," +
                   " datediff (d,CONVERT (smalldatetime, a.pend_date, 103), getdate ()),a.PATIENT_ID, a.PATIENT_FILE_NO  from AIMS_PATIENT a, AIMS_A_PATIENT b " +
                   " where a.PEND_DATE is not null and a.PEND_DATE <> '' and " +
                   " datediff (d,CONVERT (smalldatetime, a.pend_date, 103), getdate ()) > 10 and " +
                   " b.PATIENT_ID = a.PATIENT_ID and " +
                   " b.AUDIT_ID = (Select MAX(AUDIT_ID) from AIMS_A_PATIENT c " +
                   " where c.PATIENT_ID = b.PATIENT_ID and  " +
                   " c.PEND_DATE is not null and c.PEND_DATE <> '') "+
                   " order by 2";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientID = dtDrillReportData.Rows[i]["PATIENT_ID"].ToString();

                        CoOrdinator = dtDrillReportData.Rows[i]["FILE_OPERATOR_TO_USERID"].ToString();
                        if (CoOrdinator == "")
                        {
                            CoOrdinator = dtDrillReportData.Rows[i]["MODIFIED_USER"].ToString();
                        }
                        
                        SQLString = "Update AIMS_PATIENT SET PEND_DATE = NULL, FILE_OPERATOR_TO_USERID = '" + CoOrdinator  + "' where PATIENT_ID = " + PatientID;

                        cmdDrillReport.CommandText = SQLString;
                        cmdDrillReport.CommandType = CommandType.Text;
                        cmdDrillReport.ExecuteNonQuery();

                        SQLString = "insert into AIMS_EWS_INSTANT_MESSAGING " +
                        " values (GETDATE(),'Pend-Date Expired on your Pended Case', '" + CoOrdinator + "','SYSTEM'," + PatientID + ",null,null) ";

                        cmdDrillReport.CommandText = SQLString;
                        cmdDrillReport.CommandType = CommandType.Text;
                        cmdDrillReport.ExecuteNonQuery();

                        SQLString = "insert into AIMS_NOTES " +
                        " values ('SYSTEM', 'Case automatically unpended - Pend Date Expired.', getdate(), " + PatientID  + ", 7) ";

                        cmdDrillReport.CommandText = SQLString;
                        cmdDrillReport.CommandType = CommandType.Text;
                        cmdDrillReport.ExecuteNonQuery();   
                    }
                }
            }
            catch (System.Exception ex)
            {
                LogMessages("ProcessPendedCases Report Error", ex.ToString(), true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
            }
        }
        
        public bool GenerateAndEmailReport()
        {
            bool ReportGenerated = false;
            bool blResult = false;
            string sEmailBody = "";
            string SQLString = "";
            string ReportDesc = "";
            string ReportStoredProc = "";
            DateTime ReportLastExecDate;
            string ReportsFields = "";
            OleDbCommand cmdReports = new OleDbCommand();
            OleDbDataReader rdrReports;
            string ReportProcType = "";
            DataTable dtReportsData = new DataTable();
            OleDbDataAdapter oleDBAdaptor;

            OleDbCommand cmdReportExec = new OleDbCommand();
            try
            {
                AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();
                SQLString = "Select * from AIMS_REPORTS";

                cmdReportExec.Connection = oleDBConnection;
                cmdReports.Connection = oleDBConnection;
                cmdReports.CommandText = SQLString;
                rdrReports = cmdReports.ExecuteReader();
                while (rdrReports.Read())
                {
                    ReportDesc = rdrReports["REPORT_DESC"].ToString();
                    ReportStoredProc = rdrReports["REPORT_PROC_NAME"].ToString();
                    ReportLastExecDate = System.Convert.ToDateTime(rdrReports["REPORT_LAST_RUN_DTTM"]);
                    ReportsFields = rdrReports["REPORT_FIELDS_DEFINITION"].ToString();
                    ReportProcType = rdrReports["REPORT_PROC_TYPE"].ToString();

                    if (ReportStoredProc.Trim() != "")
                    {
                        cmdReportExec.CommandText = ReportStoredProc;
                        switch (ReportProcType)
                        {
                            case "SQL":
                                cmdReportExec.CommandType = CommandType.Text;
                                break;
                            case "PROC":
                                cmdReportExec.CommandType = CommandType.StoredProcedure;
                                break;
                        }
                        cmdReportExec.ExecuteReader();
                        oleDBAdaptor = new OleDbDataAdapter(cmdReportExec);
                        oleDBAdaptor.Fill(dtReportsData);
                        if (dtReportsData.Rows.Count > 0)
                        {
                            Int32 iDtRowCnt = 0;
                            bool AddReportHeader = true;
                            for (int i = 0; i < dtReportsData.Rows.Count; i++)
                            {
                                foreach (DataRow dtRow in dtReportsData.Rows)
                                {
                                    if (ReportsFields.Contains(dtRow[iDtRowCnt].ToString()))
                                    {
                                        if (AddReportHeader)
                                        {
                                            AddReportHeader = false;
                                        }
                                    }
                                    iDtRowCnt++;
                                }
                            }
                        }
                    }

                }

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody);
                if (blResult)
                {

                }
                else
                {
                    LogMessages("Report Emailing Problem", "AIMS Emailing Utility", true);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ReportGenerated;
        }
        
        public bool GenerateBUReports()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sMainReportEmailBody = "";
            string sEmailBody = "";
            bool blResult = false;

            // Main Report Variables
            OleDbCommand cmdReport = new OleDbCommand();
            DataTable dtReportData = new DataTable();
            OleDbDataAdapter oleDBAdaptor;
            string GuarantorID = "";
            string FileConsolidationTotal = "";
            decimal AllGuarantorsTotal = 0;
            string GuarantorName = "";
            string MainReportEmailSubject = "Guarantors Consolidations Total Summary Report";

            // Drill down report variables
            OleDbCommand cmdDrillReport = new OleDbCommand();
            DataTable dtDrillReportData = new DataTable();
            OleDbDataAdapter oleDrillDBAdaptor;
            string PatientFileNo = "";
            string PatientLastName = "";
            string PatientCreationDTTM = "";
            string PatientConsolidationTotal = "";
            string DrillReportEmailSubject = "Guarantors Patients Consolidations Total Summary Report";

            try
            {
                sMainReportEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=4>" +
                                "<center><font color=5CACEE face=calibri size=4><b>AIMS Guarantor Consolidations Summary</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>" +
                                "<td bgcolor=lightgrey valign=bottom colspan=4><b>Guarantors Consolidations Total</b></td>" +
                                "</tr>";

                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=4>" +
                                "<center><font color=5CACEE face=calibri size=4><b>AIMS Guarantors Consolidations</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT guarantor_name Guarantor_Name, " +
                                     " COUNT (aims_patient.patient_id) Active_Patient_Files, " +
                                     " SUM(CAST (ai1.invoice_amount_received AS money)) INVOICE_AMOUNT_RECEIVED, aims_guarantor.guarantor_id " +
                                " FROM aims_guarantor LEFT OUTER JOIN aims_patient " +
                                     " ON aims_patient.guarantor_id = aims_guarantor.guarantor_id " +
                                     " LEFT OUTER JOIN aims_invoice ai1 " +
                                     " ON aims_patient.patient_id = ai1.patient_id " +
                               " WHERE aims_guarantor.guarantor_id NOT IN (58, 57) " +
                            " GROUP BY guarantor_name, aims_guarantor.guarantor_id " +
                              " HAVING COUNT (INVOICE_AMOUNT_RECEIVED) > 0 " +
                            " ORDER BY 1 ";

                cmdReport.Connection = oleDBConnection;
                cmdReport.CommandText = SQLString;
                oleDBAdaptor = new OleDbDataAdapter(cmdReport);
                oleDBAdaptor.Fill(dtReportData);
                if (dtReportData.Rows.Count > 0)
                {
                    for (int i = 0; i < dtReportData.Rows.Count; i++)
                    {
                        GuarantorID = dtReportData.Rows[i]["guarantor_id"].ToString();
                        FileConsolidationTotal = dtReportData.Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString();
                        AllGuarantorsTotal += System.Convert.ToDecimal(FileConsolidationTotal);
                        GuarantorName = dtReportData.Rows[i]["Guarantor_Name"].ToString();

                        sEmailBody += "<tr>" +
                                        "<td align=left bgcolor=lightgrey colspan=2><center><b><font color=green size=2 >" + GuarantorName + "</font></b></center></td>" +
                                        "<td align=right bgcolor=lightgrey colspan=4>" +
                                        "<b><font color=red size=2><b>" + FileConsolidationTotal + "</b></font></b>" +
                                        "</td>" +
                                        "</tr>";

                        sMainReportEmailBody += "<tr>" +
                                                "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>" + GuarantorName + "</td>" +
                                                "<td colspan=2 bgcolor=#efefef width=50% align=left><font size=2 color=green><b>" + System.Convert.ToDecimal(FileConsolidationTotal).ToString("C") + "</b></font></td> " +
                                                "</tr>" +
                                                "<tr>" +
                                                "<td colspan=4 align=left bgcolor=lightgrey>" +
                                                "<center><b><font color=green size=2 >&nbsp;</font></b></center>" +
                                                "</td>" +
                                                "</tr>";


                        SQLString = "SELECT  top 30 aims_patient.CREATION_DTTM, aims_patient.patient_file_no, aims_patient.patient_last_name, " +
                                             " SUM(CAST (ai1.invoice_amount_received AS money)) invoice_amount_received " +
                                        " FROM aims_guarantor LEFT OUTER JOIN aims_patient " +
                                             " ON aims_patient.guarantor_id = aims_guarantor.guarantor_id " +
                                             " LEFT OUTER JOIN aims_invoice ai1 " +
                                             " ON aims_patient.patient_id = ai1.patient_id " +
                                      " WHERE aims_guarantor.guarantor_id = " + GuarantorID + "" +
                                    " GROUP BY aims_patient.patient_file_no, " +
                                             " patient_last_name, " +
                                             " aims_guarantor.guarantor_name, " +
                                             " aims_patient.CREATION_DTTM " +
                                      " HAVING COUNT (ai1.invoice_amount_received) > 0 " +
                                    " ORDER BY 2 DESC ";

                        cmdDrillReport.Connection = oleDBConnection;
                        cmdDrillReport.CommandText = SQLString;
                        cmdDrillReport.CommandType = CommandType.Text;
                        oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                        oleDrillDBAdaptor.Fill(dtDrillReportData);
                        if (dtDrillReportData.Rows.Count > 0)
                        {
                            sEmailBody += "<tr>" +
                                       "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                                       "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Last name</b></td>" +
                                       "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File Creation Date</b></td>" +
                                       "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Consolidations Total</b></td>" +
                                        "</tr>";
                            for (int j = 0; j < dtDrillReportData.Rows.Count; j++)
                            {
                                PatientFileNo = dtDrillReportData.Rows[j]["PATIENT_FILE_NO"].ToString();
                                PatientLastName = dtDrillReportData.Rows[j]["PATIENT_LAST_NAME"].ToString();
                                PatientCreationDTTM = System.Convert.ToDateTime(dtDrillReportData.Rows[j]["CREATION_DTTM"]).ToShortDateString().ToString();
                                PatientConsolidationTotal = dtDrillReportData.Rows[j]["INVOICE_AMOUNT_RECEIVED"].ToString();
                                sEmailBody += "<tr>" +
                               "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                               "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientLastName + "</td>" +
                               "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientCreationDTTM + "</td>" +
                               "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + System.Convert.ToDecimal(PatientConsolidationTotal).ToString("C") + "</td>" +
                               "</tr>";
                            }

                            sEmailBody += "<tr>" +
                            "<td colspan=4 align=left bgcolor=lightgrey>" +
                            "<center><b><font color=green size=2 >&nbsp;</font></b></center>" +
                            "</td>" +
                            "</tr>";
                        }
                    }
                }

                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                string LogFileName = @"C:\AIMS Guarantors Report.html";
                StreamWriter strWriter = new StreamWriter(LogFileName);
                strWriter.WriteLine(sEmailBody);
                strWriter.Flush();
                strWriter.Close();
                strWriter.Dispose();

                sMainReportEmailBody += "<tr>" +
                    "<td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize align=right><b>TOTAL</b></td>" +
                    "<td colspan=2 bgcolor=#efefef width=50% align=left><font size=2 color=green><b>" + AllGuarantorsTotal.ToString("C") + "</b></font></td>" +
                    "</tr>" +
                    "</table>" +
                    "<br>" +
                    "<br>" +
                    "</body>" +
                    "</html>";

                string ReportRecipient = "danielm@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");

                //blResult = aimsEmailer.SendEmailNotify(sMainReportEmailBody, MainReportEmailSubject, "");

                if (blResult)
                {
                    LogMessages("AIMS Guarantors Summary Report Email sent successfully", "Email Successful", false);
                    blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "");
                    if (!blResult)
                    {
                        LogMessages("AIMS Guarantors Full Report Email NOT sent successfully", "Email UnSuccessful", true);
                    }
                    else
                    {
                        LogMessages("AIMS Guarantors Full Report Email sent successfully", "Email Successful", false);
                    }
                }
                else
                {
                    LogMessages("AIMS Guarantors Summary Report Email NOT sent successfully", "Email UnSuccessful", true);
                }
            }
            catch (System.Exception ex)
            {
                LogMessages(ex.ToString(), "Generate Guarantors Summary Report", true);
            }
            finally
            {
                aimsEmailer = null;
                cmdDrillReport.Dispose();
            }
            return true;
        }

        public void GenerateFilesCourierAfterDischargeLateLog()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string PatientName = "";
            string AdmissionDate = "";
            string Discharge_Date = "";
            string SLAViolationDays = "";
            string LateLogYN = "";
            string LateLogDTTm = "";
            string Hospital = "";

            string DrillReportEmailSubject = "Files Not Couriered After 10 Days Of Patient Discharge Date - Late Log Cases";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=5>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Files Not Couriered After 10 Days Of Patient Discharge Date - Late Log Cases</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT patient_file_no Patient_File_No, " +
                                       " patient_admission_date Admission_Date, " +
                                       " patient_discharge_date Discharge_Date, " +
                                       " a.LATE_LOG_YN, a.LATE_LOG_DATE ," +
                                       " datediff (D, CONVERT (smalldatetime, patient_discharge_date, 103), getdate()) File_Not_Couriered, " +
                                       " LTRIM(dbo.initcap(b.TITLE_DESC) + ' ' + dbo.initcap(PATIENT_FIRST_NAME ) +' ' + dbo.initcap(patient_last_name)) patient_name," +
                                       " d.guarantor_name SUPPLIER_NAME " +
                                  " FROM aims_patient a, AIMS_TITLE b, aims_supplier c, aims_guarantor d " +
                                 " WHERE  a.patient_file_no not like '10%' and a.CANCELLED = 'N' and a.patient_discharge_date IS NOT NULL and a.patient_discharge_date <> '' " +
                                   " AND (a.file_courier_date IS NULL OR a.file_courier_date = '')" +
                                   " AND datediff (D, CONVERT (smalldatetime, patient_discharge_date, 103), getdate()) > 10 " +
                                   " AND b.TITLE_ID = a.TITLE_ID and c.supplier_id = a.supplier_id and d.guarantor_id = a.guarantor_id AND LATE_LOG_YN = 'Y' ORDER BY cast(substring(a.PATIENT_FILE_NO,1,2) as numeric)";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Full Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Discharge Date</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center><b>Guarantor</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center><b>Late Log Y/N</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Late Log Date</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom aligns=center><b>SLA Violation Days</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["Patient_File_No"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["Admission_Date"].ToString();
                        Discharge_Date = dtDrillReportData.Rows[i]["Discharge_Date"].ToString();
                        SLAViolationDays = dtDrillReportData.Rows[i]["File_Not_Couriered"].ToString();
                        Hospital = dtDrillReportData.Rows[i]["SUPPLIER_NAME"].ToString();
                        LateLogYN = dtDrillReportData.Rows[i]["LATE_LOG_YN"].ToString();
                        LateLogDTTm = dtDrillReportData.Rows[i]["LATE_LOG_DATE"].ToString();

                        if (!LateLogDTTm.Equals(""))
                        {
                            LateLogDTTm = System.Convert.ToDateTime(LateLogDTTm).ToShortDateString();
                        }
                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Discharge_Date + "</td>" +
                        //"<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Hospital + "</td>" +
                        //"<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogYN + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogDTTm + "</td>" +
                        //"<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + SLAViolationDays + "</td>" +
                        "</tr>";
                    }

                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><b>" + DrillReportEmailSubject + "</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;DominicB@aims.org.za;operations@aims.org.za");

                string ReportRecipient = "stanley@aims.org.za;DominicB@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), DrillReportEmailSubject , true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesCourierAfterDischarge()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string PatientName = "";
            string AdmissionDate = "";
            string Discharge_Date = "";
            string SLAViolationDays = "";
            string LateLogYN = "";
            string LateLogDTTm = "";
            string Hospital = "";

            string DrillReportEmailSubject = "Files Not Couriered After 10 Days Of Patient Discharge Date";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Files Not Couriered After 10 Days Of Patient Discharge Date</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=8>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT patient_file_no Patient_File_No, " +
                                       " patient_admission_date Admission_Date, " +
                                       " patient_discharge_date Discharge_Date, " +
                                       " a.LATE_LOG_YN, a.LATE_LOG_DATE ," +
                                       " datediff (D, CONVERT (smalldatetime, patient_discharge_date, 103), getdate()) File_Not_Couriered, " +
                                       " LTRIM(dbo.initcap(b.TITLE_DESC) + ' ' + dbo.initcap(PATIENT_FIRST_NAME ) +' ' + dbo.initcap(patient_last_name)) patient_name," +
                                       " d.guarantor_name SUPPLIER_NAME " +
                                  " FROM aims_patient a, AIMS_TITLE b, aims_supplier c, aims_guarantor d " +
                                 " WHERE  a.patient_file_no not like '10%' and a.CANCELLED = 'N' and a.patient_discharge_date IS NOT NULL and a.patient_discharge_date <> '' " +
                                   " AND (a.file_courier_date IS NULL OR a.file_courier_date = '')" +
                                   " AND datediff (D, CONVERT (smalldatetime, patient_discharge_date, 103), getdate()) > 10 " +
                                   " AND b.TITLE_ID = a.TITLE_ID and c.supplier_id = a.supplier_id and d.guarantor_id = a.guarantor_id and LATE_LOG_YN = 'N' ORDER BY d.guarantor_name, cast(substring(a.PATIENT_FILE_NO,1,2) as numeric)";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Full Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Guarantor</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center><b>Late Log Y/N</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center><b>Late Log Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom aligns=center><b>SLA Violation Days</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["Patient_File_No"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["Admission_Date"].ToString();
                        Discharge_Date = dtDrillReportData.Rows[i]["Discharge_Date"].ToString();
                        SLAViolationDays = dtDrillReportData.Rows[i]["File_Not_Couriered"].ToString();
                        Hospital = dtDrillReportData.Rows[i]["SUPPLIER_NAME"].ToString();
                        //LateLogYN = dtDrillReportData.Rows[i]["LATE_LOG_YN"].ToString();
                        //LateLogDTTm = dtDrillReportData.Rows[i]["LATE_LOG_DATE"].ToString();
                        
                        //if (!LateLogDTTm.Equals(""))
                        //{
                        //    LateLogDTTm = System.Convert.ToDateTime(LateLogDTTm).ToShortDateString();
                        //}
                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Discharge_Date + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Hospital + "</td>" +
                        //"<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogYN + "</td>" +
                        //"<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogDTTm + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + SLAViolationDays + "</td>" +
                        "</tr>";
                    }

                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>All Files For Patients Discharged In The Last 10 days have been couried.</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;DominicB@aims.org.za;admin@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;DominicB@aims.org.za;admin@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");

                if (blResult)
                {
                    LogMessages("Files Not Couriered Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages("Files Not Couriered Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Files Not Couried after 10 days of Discharge Date", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesCancelled7DaysAgo()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string Guarantor = "";
            string Datecancelled = "";
            string CancelledBy = "";

            string DrillReportEmailSubject = "Patients Files cancelled in the last 7 days";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=5>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Patients Files cancelled in the last 7 days</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT   " +
                            " a.patient_file_no, " +
                            " LTRIM (  dbo.INITCAP (e.title_desc) " +
                            " + ' ' " +
                            " + dbo.INITCAP (a.patient_first_name) " +
                            " + ' ' " +
                            " + dbo.INITCAP (a.patient_last_name) " +
                            " ) patient_name, " +
                            " c.guarantor_name, d.MODIFIED_DATE DATE_CANCELLED, f.User_Full_Name " +
                            " FROM aims_patient a, aims_title e, aims_guarantor c, aims_a_patient d, AIMS_USERS f " +
                            " WHERE a.cancelled = 'Y' " +
                            " AND e.title_id = a.title_id " +
                            " AND c.guarantor_id = a.guarantor_id " +
                            " AND d.patient_id = a.patient_id " +
                            " AND d.audit_id = " +
                            " (SELECT MIN (e.audit_id) " +
                            " FROM aims_a_patient e " +
                            " WHERE e.patient_id = a.patient_id AND e.cancelled = 'Y') " +
                            " and f.User_Name = d.MODIFIED_USER " +
                            " and  datediff (D,  d.MODIFIED_DATE, getdate()) <= 7 " +
                            " ORDER BY 1,CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC), " +
                            " CAST (RTRIM (substring (a.patient_file_no, 4, 5)) AS NUMERIC) ";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Full Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Date Cancelled</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>File Cancelled By</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        Guarantor = dtDrillReportData.Rows[i]["guarantor_name"].ToString();
                        Datecancelled = dtDrillReportData.Rows[i]["DATE_CANCELLED"].ToString();
                        CancelledBy = dtDrillReportData.Rows[i]["User_Full_Name"].ToString();

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Guarantor + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Datecancelled + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + CancelledBy + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><b>NO PATIENT FILES CANCELLED IN THE LAST 7 DAYS</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za;DanielM@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;Lerato@aims.org.za;DanielM@aims.org.za");
                if (blResult)
                {
                    LogMessages("Patients Files cancelled in the last 7 days", "Email Successful", false);
                }
                else
                {
                    LogMessages("Patients Files cancelled in the last 7 days", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesForPatientsDischargedInLast24Hours()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string DrillReportEmailSubject = "Patient File Discharged - Last 24 Hours [" + DateTime.Now.AddDays(-1).ToShortDateString() + "]";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=5>" +
                                "<center><font color=5CACEE face=calibri size=4><b>"+ DrillReportEmailSubject +"</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                //SQLString = "SELECT patient_file_no, patient_last_name, b.user_full_name, " +
                //             " a.patient_discharge_date, c.GUARANTOR_NAME " +
                //             " FROM aims_patient a, aims_users b, AIMS_GUARANTOR c " +
                //             " WHERE patient_discharge_date IS NOT NULL and patient_discharge_date <> '' and a.CANCELLED = 'N' " +
                //             " AND datediff (d,CONVERT (datetime, patient_discharge_date, 103), getdate ()) = 1 " +
                //             " AND b.user_name = a.file_operator_to_userid " +
                //             " and c.GUARANTOR_ID = a.GUARANTOR_ID " +
                //             " order by user_full_name, PATIENT_FILE_NO ";

                SQLString = @"select patient_file_no, patient_last_name, b.user_full_name,
                         a.patient_discharge_date, c.guarantor_name,
                         CASE d.SUPPLIER_NAME WHEN '' THEN 'O/P' WHEN NULL THEN 'O/P' ELSE d.SUPPLIER_NAME END 'Hospital'
                         FROM aims_patient a 
                         left outer join aims_users b on  b.user_name = a.file_operator_to_userid
                         left outer join aims_guarantor c on c.guarantor_id = a.guarantor_id 
                         left outer join aims_supplier d on d.SUPPLIER_ID = a.SUPPLIER_ID
                         where patient_discharge_date IS NOT NULL
                     AND patient_discharge_date <> ''
                     AND a.cancelled = 'N'
                     AND datediff (d,CONVERT (datetime, patient_discharge_date, 103),getdate ()) = 1
                order by user_full_name, PATIENT_FILE_NO";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Last Name</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Hospital</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Date Discharged</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["user_full_name"].ToString() +"</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["patient_file_no"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["patient_last_name"].ToString() + "</td>" +
                        //"<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["Hospital"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["patient_discharge_date"].ToString() + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><b>NO PATIENT FILES DISCHARGED IN LAST 24 HOURS</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";
                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za;admin@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za;admin@aims.org.za");

                if (blResult)
                {
                    LogMessages("Patients Files Discharged in 24 Hours", "Email Successful", false);
                }
                else
                {
                    LogMessages("Patients Files Discharged in 24 Hours", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Patients Files Discharged in 24 Hours ERROR", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesPendedWithFutureAdmissionDate()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string SLAViolationDays = "";
            string LateLogDTTm = "";
            string LateLogYN = "";
            string InOutPatient = "";
            string GuarantorName = "";

            string DrillReportEmailSubject = "Patient Cases - Impending Status";
              
            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=5>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT patient_file_no, " +
                            " LTRIM (  dbo.INITCAP (c.title_desc) "+
                            " + ' ' "+
                            " + dbo.INITCAP (patient_first_name) "+
                            " + ' ' "+
                            " + dbo.INITCAP (patient_last_name) "+
                            " ) patient_name, "+
                            " patient_admission_date, b.guarantor_name, a.in_patient, a.out_patient "+
                            " FROM aims_patient a, aims_guarantor b, aims_title c "+
                            " WHERE a.CANCELLED = 'N' AND a.pending = 'Y' " +
                            " AND a.patient_admission_date IS NOT NULL "+
                            " AND CONVERT (smalldatetime, a.patient_admission_date, 103) > getdate () "+
                            " AND b.guarantor_id = a.guarantor_id "+
                            " AND c.title_id = a.title_id";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=30%><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=25%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Type Of Case</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_NAME"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["patient_admission_date"].ToString();
                        GuarantorName = dtDrillReportData.Rows[i]["guarantor_name"].ToString();
                        
                        InOutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();

                        if (InOutPatient.Equals("Y"))
                        {
                            InOutPatient = "<b>OUT-Patient</b>";
                        }
                        else
                        {
                            InOutPatient = "<b>IN-Patient</b>";
                        }

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + GuarantorName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + InOutPatient + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><b>" + DrillReportEmailSubject + " - Records Up-to-date</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating " +DrillReportEmailSubject, true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesAdmittedNOTDischargedAfter14Days()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string SLAViolationDays = "";
            string LateLogDTTm = "";
            string LateLogYN = "";
            string InOutPatient = "";
            string InPatient = "";

            string DrillReportEmailSubject = "Patients Admitted NOT discharged after 14 Days";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=6>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Patients Admitted NOT discharged after 14 days</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=6>&nbsp;</td>" +
                                "</tr>";

                SQLString = "select  a.PATIENT_FILE_NO, a.PATIENT_ADMISSION_DATE, " +
                                " LTRIM( dbo.initcap(e.TITLE_DESC) + ' ' + dbo.initcap(PATIENT_FIRST_NAME ) +' ' + dbo.initcap(patient_last_name)) patient_name, " +
                                " a.LATE_LOG_YN, a.LATE_LOG_DATE, a.OUT_PATIENT, a.IN_PATIENT  " +
                                " from AIMS_PATIENT a, AIMS_TITLE e " +
                                " where " +
                                "  a.CANCELLED = 'N' and (a.pending = 'N' or a.pending is null) and " +
                                " (a.PATIENT_ADMISSION_DATE IS NOT NULL or PATIENT_ADMISSION_DATE <> '') " +
                                " and" +
                                " datediff (D, CONVERT (smalldatetime, a.PATIENT_ADMISSION_DATE, 103), getdate()) > 14 and " +
                                " (a.PATIENT_DISCHARGE_DATE is null or a.PATIENT_DISCHARGE_DATE = '') and " +
                                " e.TITLE_ID = a.TITLE_ID " +
                                " order by cast(substring(a.PATIENT_FILE_NO,1,2) as numeric) ";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=40%><b>Patient Full Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Late Log(Y/N)</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Late Log Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Patient Status</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        LateLogYN = dtDrillReportData.Rows[i]["LATE_LOG_YN"].ToString();
                        LateLogDTTm = dtDrillReportData.Rows[i]["LATE_LOG_DATE"].ToString();
                        InOutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();
                        InPatient = dtDrillReportData.Rows[i]["IN_PATIENT"].ToString();

                        if (!LateLogDTTm.Equals(""))
                        {
                            LateLogDTTm = System.Convert.ToDateTime(LateLogDTTm).ToShortDateString();
                        }
                        if (InOutPatient.Equals("Y"))
                        {
                            InOutPatient = "<b>OUT-Patient</b>";
                        }
                        else if (InPatient.Equals("Y"))
                        {
                            InOutPatient = "<b>IN-Patient</b>";
                        }
                        else
                        {
                            InOutPatient = "";
                        }

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogYN + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogDTTm + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + InOutPatient + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=6><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=6><b>Patients Admitted NOT discharged after 14 Days NOT FOUND - Records Up-to-date</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                if (blResult)
                {
                    LogMessages("Patients Admitted NOT discharged after 14 Days Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages("Patients Admitted NOT discharged after 14 Days Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesCourierGreaterThan100K()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string PatientName = "";
            string AdmissionDate = "";

            string DischargeDate = "";
            string Supplier_Name = "";
            string FileConsolidationAmt = "";
            string FileCourierDate = "";
            decimal totalConsolidation = 0;

            string DrillReportEmailSubject = "Consolidation File Greater Than 100K Couriered (Last 10 Days)";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Consolidation File Greater Than 100K Couriered (Last 10 Days)</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=7>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT patient_file_no patient_file_no, " +
                                    " a.PATIENT_ADMISSION_DATE, " +
                                    " a.PATIENT_DISCHARGE_DATE, " +
                                    " (a.PATIENT_LAST_NAME + ' ' + a.PATIENT_FIRST_NAME) PATIENT_NAME, " +
                                     " dbo.INITCAP (c.supplier_name) supplier_name, " +
                                     " sum(cast(d.INVOICE_AMOUNT_RECEIVED as money)) CONSOLIDATION_AMOUNT, " +
                                     " a.FILE_COURIER_DATE " +
                                " FROM aims_patient a, aims_title b, aims_supplier c, AIMS_INVOICE d " +
                               " WHERE a.CANCELLED = 'N' and a.patient_discharge_date IS NOT NULL " +
                                 " AND (a.file_courier_date IS NOT NULL ) " +
                                 " AND b.title_id = a.title_id " +
                                 " AND c.supplier_id = a.supplier_id " +
                                 " AND d.PATIENT_ID = a.PATIENT_ID " +
                                 " AND datediff (D, CONVERT (smalldatetime, a.FILE_COURIER_DATE, 103), getdate()) <= 10 " +
                                 " group by patient_file_no,  a.PATIENT_LAST_NAME, a.PATIENT_FIRST_NAME, supplier_name, FILE_COURIER_DATE, PATIENT_ADMISSION_DATE, PATIENT_DISCHARGE_DATE " +
                                  " having  sum(cast(d.INVOICE_AMOUNT_RECEIVED as money )) > CAST('100000' as money ) " +
                            " ORDER BY cast(substring(a.PATIENT_FILE_NO,1,2) as numeric) ";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Supplier/Hospital</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom aligns=center><b>File Courier Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Consolidation Amount</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["patient_file_no"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        DischargeDate = dtDrillReportData.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString();
                        Supplier_Name = dtDrillReportData.Rows[i]["supplier_name"].ToString();
                        FileConsolidationAmt = System.Convert.ToDecimal(dtDrillReportData.Rows[i]["CONSOLIDATION_AMOUNT"].ToString()).ToString("C");
                        totalConsolidation += System.Convert.ToDecimal(dtDrillReportData.Rows[i]["CONSOLIDATION_AMOUNT"].ToString());
                        FileCourierDate = System.Convert.ToDateTime(dtDrillReportData.Rows[i]["FILE_COURIER_DATE"].ToString()).ToShortDateString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_NAME"].ToString();

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + DischargeDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Supplier_Name + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + FileCourierDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + FileConsolidationAmt + "</td>" +
                        "</tr>";
                    }

                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=right colspan=7><font color=red><b>Total Amount : " + totalConsolidation.ToString("C") + "</b></font></td>" +
                                "</tr>";
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>Consolidation Files Count: " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><b>NO Consolidation File Greater Than 100K Couried.</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");

                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages("Files Not Couriered Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages("Files Not Couriered Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Files Not Couried after 10 days of Discharge Date", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesNOTCourierGreaterThan100K()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string PatientName = "";
            string AdmissionDate = "";
            string DischargeDate = "";
            string Supplier_Name = "";
            string FileConsolidationAmt = "";
            decimal totalConsolidation = 0;

            string DrillReportEmailSubject = "Consolidation File Greater Than 100K NOT Couriered";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=6>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Consolidation File Greater Than 100K NOT Couriered</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=6>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT patient_file_no patient_file_no,   " +
                                    " a.PATIENT_ADMISSION_DATE, " +
                                    " a.PATIENT_DISCHARGE_DATE, " +
                                     " (a.PATIENT_LAST_NAME + ' ' + a.PATIENT_FIRST_NAME) PATIENT_NAME, " +
                                     " dbo.INITCAP (c.supplier_name) supplier_name, " +
                                     " sum(cast(d.INVOICE_AMOUNT_RECEIVED as money)) CONSOLIDATION_AMOUNT " +
                                " FROM aims_patient a, aims_title b, aims_supplier c, AIMS_INVOICE d " +
                               " WHERE a.CANCELLED = 'N' and a.patient_discharge_date IS NOT NULL " +
                                 " AND (a.file_courier_date IS NULL or a.file_courier_date = '') " +
                                 " AND b.title_id = a.title_id " +
                                 " AND c.supplier_id = a.supplier_id " +
                                 " AND d.PATIENT_ID = a.PATIENT_ID " +
                                 " group by patient_file_no, supplier_name,PATIENT_LAST_NAME, PATIENT_FIRST_NAME ,PATIENT_ADMISSION_DATE, PATIENT_DISCHARGE_DATE " +
                                  " having  sum(cast(d.INVOICE_AMOUNT_RECEIVED as money )) > CAST('100000' as money ) " +
                            " ORDER BY cast(substring(a.PATIENT_FILE_NO,1,2) as numeric) ";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Supplier/Hospital</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Consolidation Amount</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["patient_file_no"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_NAME"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        DischargeDate = dtDrillReportData.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString();
                        Supplier_Name = dtDrillReportData.Rows[i]["supplier_name"].ToString();
                        FileConsolidationAmt = System.Convert.ToDecimal(dtDrillReportData.Rows[i]["CONSOLIDATION_AMOUNT"].ToString()).ToString("C");
                        totalConsolidation += System.Convert.ToDecimal(dtDrillReportData.Rows[i]["CONSOLIDATION_AMOUNT"].ToString());


                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + DischargeDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Supplier_Name + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + FileConsolidationAmt + "</td>" +
                        "</tr>";
                    }

                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=right colspan=6><font color=red><b>Total Amount : " + totalConsolidation.ToString("C") + "</b></font></td>" +
                                "</tr>";
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=6><font color=red><b>Consolidation Files Count: " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=6><b>NO Consolidation File Greater Than 100K NOT Couried.</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");

                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages("Files Not Couriered Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages("Files Not Couriered Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Files Not Couried after 10 days of Discharge Date", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesPendedForTenDays()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string PatientFilePendDate = "";
            string SLAViolationDays = "";
            string DrillReportEmailSubject = "Patient File Pended For Over 2 Days";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=4>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Patient File Pended For Over 2 Days</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT a.patient_file_no, a.patient_admission_date, " +
                " LTRIM (  dbo.INITCAP (e.title_desc) " +
                " + ' ' " +
                " + dbo.INITCAP (patient_first_name) " +
                " + ' ' " +
                " + dbo.INITCAP (patient_last_name) " +
                " ) patient_name, " +
                " pend_date " +
                " FROM aims_patient a, aims_title e " +
                " WHERE a.cancelled = 'N' " +
                " AND a.pend_date IS NOT NULL " +
                " AND datediff (d, CONVERT (smalldatetime, a.pend_date, 103), getdate ()) >= 2 " +
                " AND e.title_id = a.title_id order by cast(substring(a.PATIENT_FILE_NO,1,2) as numeric)";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Full Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File Pend Date</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        PatientFilePendDate = dtDrillReportData.Rows[i]["pend_date"].ToString();

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFilePendDate + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=4><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=4><b>Patients Files Pended For Days Over 2 NOT FOUND - Records Up-to-date</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");

                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages("Patients Files Pended For Days Over 2 Days Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages("Patients Files Pended For Days Over 2 Days Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Patients Files Pended For Days Over 2 Days ", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesTaggedToOperators()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string FileAllocatedTo = "";
            string DischargeDate = "";
            string LastNoteCaptured = "";
            string NotesDateTime = "";
            string GuarantorName = "";
            

            string DrillReportEmailSubject = "Files Tagged to Operations Team - With Last Comment";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table  cellpadding=1 cellspacing=1 border=1 bordercolor=black width=100% align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Files Tagged to Operations Team - With Last Comment</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=8>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT " +
                           " d.User_Full_Name FILE_ALLOCATED_TO, " +
                            " a.patient_file_no, " +
                            " dbo.INITCAP (a.patient_last_name + ' ' + a.patient_first_name) patient_name, " +
                            " c.guarantor_name,  " +
                            " a.patient_admission_date, " +
                            " a.patient_discharge_date, " +
                            " RTRIM (LTRIM (b.notes)) LAST_NOTE_CAPTURED,  " +
                            " b.notes_dttm " +
                            " FROM aims_patient a, aims_notes b, aims_guarantor c, AIMS_USERS d " +
                            " WHERE a.CANCELLED = 'N'  and (a.pending = 'N' or a.pending is null) AND file_operator_to_userid IS NOT NULL " +
                            " AND (A.PATIENT_DISCHARGE_DATE IS null OR A.PATIENT_DISCHARGE_DATE = '') " +
                            " AND b.patient_id = a.patient_id " +
                            " AND b.note_id = (SELECT MAX (note_id) FROM aims_notes WHERE aims_notes.patient_id = a.patient_id) " +
                            " AND c.guarantor_id = a.guarantor_id " +
                            " and d.User_Name = file_operator_to_userid " +
                            " ORDER BY file_operator_to_userid, CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC)";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Admission Date</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=left nowrap><b>Last Note/Comment Captured</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Note/Comment Date Time</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        FileAllocatedTo = dtDrillReportData.Rows[i]["FILE_ALLOCATED_TO"].ToString();
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_NAME"].ToString();
                        GuarantorName = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        DischargeDate = dtDrillReportData.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString();
                        LastNoteCaptured = dtDrillReportData.Rows[i]["LAST_NOTE_CAPTURED"].ToString();
                        NotesDateTime = dtDrillReportData.Rows[i]["NOTES_DTTM"].ToString();

                        if (DischargeDate == "") { DischargeDate = "<font color=white>-</font>"; }
                        if (LastNoteCaptured == "") { LastNoteCaptured = "<font color=white>-</font>"; }
                        if (AdmissionDate == "") { AdmissionDate = "<font color=white>-</font>"; }
                        if (PatientName == "") { PatientName = "<font color=white>-</font>"; }

                        sEmailBody += "<tr style=border-style:thick>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + FileAllocatedTo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + GuarantorName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + AdmissionDate + "</td>" +
                        //"<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + DischargeDate + "</td>" +
                        "<td valign=top bgcolor=#ffffff align=center><b>" + LastNoteCaptured.Replace("\r\n", "<br>") + "</b></td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + NotesDateTime + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>Files Tagged to Operations Team - With Last Comment - Records Up-to-date</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages("Patients Admitted NOT discharged after 14 Days Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages("Patients Admitted NOT discharged after 14 Days Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesWithoutCommentsinLast24Hours()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor; 
            DataTable dtDrillReportData = new DataTable();

            string AdmissionDate = "";
            string PatientName = "";
            string Guarantor = "";

            string caseManager ="";
            string PatientFile ="";
            string NotesDTTM ="";
            string CommentSLAViolation = "";

            string DrillReportEmailSubject = "Patient Files Without Updated Notes/Comment in "+ System.Convert.ToInt64(CaseLastCommentSLA)*24 +" Hours";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject  + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=7>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT   d.user_full_name file_allocated_to, a.patient_file_no, " +        
                                             " dbo.INITCAP (a.patient_last_name + ' ' + a.patient_first_name " +        
                                                         " ) patient_name, " +        
                                             " c.guarantor_name, a.patient_admission_date, " +    
                                             " RTRIM (LTRIM (b.notes)) last_note_captured, b.notes_dttm, " +  
                                             " datediff (D, CONVERT (smalldatetime, b.notes_dttm, 103), getdate()) COMMENT_SLA " +         
                                        " FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d " +        
                                       " WHERE " +
                                       " CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and (PATIENT_DISCHARGE_DATE is null or PATIENT_DISCHARGE_DATE = '') " +     
                                       " AND file_operator_to_userid IS NOT NULL " +        
                                         " AND b.patient_id = a.patient_id " +        
                                         " AND b.note_id = (SELECT MAX (note_id) " +        
                                                            " FROM aims_notes " +        
                                                           " WHERE aims_notes.patient_id = a.patient_id) " +        
                                         " AND c.guarantor_id = a.guarantor_id " +        
                                         " AND d.user_name = file_operator_to_userid " +
                                         " and datediff (D, CONVERT (smalldatetime, b.notes_dttm, 103), getdate()) > " + CaseLastCommentSLA  + " " +
                                    " ORDER BY file_operator_to_userid, " +
                                             " CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC)";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Last Updated Date Time</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>SLA Violation(days)</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        caseManager = dtDrillReportData.Rows[i]["file_allocated_to"].ToString();
                        PatientFile = dtDrillReportData.Rows[i]["patient_file_no"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        Guarantor = dtDrillReportData.Rows[i]["guarantor_name"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["patient_admission_date"].ToString();
                        NotesDTTM = dtDrillReportData.Rows[i]["notes_dttm"].ToString();
                        CommentSLAViolation = dtDrillReportData.Rows[i]["COMMENT_SLA"].ToString();

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + caseManager + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFile + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Guarantor + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + NotesDTTM + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + CommentSLAViolation + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><b>ALL FILES ARE UPDATED</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages("Patient Files Without Updated Notes/Comment in 2+ Days", "Email Successful", false);
                }
                else
                {
                    LogMessages("Patient Files Without Updated Notes/Comment in 2+ Days", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesWithoutMedicalCommentsinLast24Hours()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string AdmissionDate = "";
            string PatientName = "";
            string Guarantor = "";
            string caseManager ="";
            string PatientFile ="";
            string NotesDTTM ="";
            string CommentSLAViolation = "";

            string DrillReportEmailSubject = "Patient Files Without Medical Update Notes/Comments in " + System.Convert.ToInt64(CaseLastCommentSLA)*24 + " Hours";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject  + "<br/>(Including Files without Medical Notes after 2 days of Admission)</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=7>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT   d.user_full_name file_allocated_to, a.patient_file_no, " +        
                                             " dbo.INITCAP (a.patient_last_name + ' ' + a.patient_first_name " +        
                                                         " ) patient_name, " +        
                                             " c.guarantor_name, a.patient_admission_date, " +    
                                             " RTRIM (LTRIM (b.notes)) last_note_captured, b.notes_dttm, " +
                                             " datediff (D, CONVERT (smalldatetime, b.notes_dttm, 103), getdate()) COMMENT_SLA, PATIENT_DISCHARGE_DATE " +         
                                        " FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d " +        
                                       " WHERE " +
                                       " CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y'  " +
                                      " and (PATIENT_DISCHARGE_DATE is null or PATIENT_DISCHARGE_DATE = '') " +
                                        " AND (patient_admission_date is not null or patient_admission_date != '') " +
                                        " AND CONVERT (smalldatetime, patient_admission_date, 103) < GETDATE() " +
                                        " and (a.IN_PATIENT = 'Y') " + //or a.OUT_PATIENT = 'Y'
                                       " AND file_operator_to_userid IS NOT NULL " +
                                         " AND b.patient_id = a.patient_id AND b.NOTE_TYPE_ID = 8 " +        
                                         " AND b.note_id = (SELECT MAX (note_id) " +        
                                                            " FROM aims_notes " +        
                                                           " WHERE aims_notes.patient_id = a.patient_id) " +
                                         //" AND (b.NOTE_TYPE_ID = 8 or (SELECT COUNT(*) FROM AIMS_NOTES e WHERE e.PATIENT_ID = a.PATIENT_ID and e.NOTE_TYPE_ID=8) = 0) " +
                                         " AND c.guarantor_id = a.guarantor_id " +        
                                         " AND d.user_name = file_operator_to_userid " +
                                         " and datediff (D, CONVERT (smalldatetime, b.notes_dttm, 103), getdate()) > " + CaseLastCommentSLA  + " " +
                                    " union" +
                                    " SELECT  " +
                                    " d.user_full_name file_allocated_to, a.patient_file_no," +
                                             " dbo.INITCAP (a.patient_last_name + ' ' + a.patient_first_name) patient_name," +
                                             " c.guarantor_name, a.patient_admission_date," +
                                             " NULL last_note_captured,  NULL notes_dttm," +
                                             " 0 comment_sla," +
                                             " patient_discharge_date" +
                                        " FROM aims_patient a,aims_guarantor c, aims_users d" +
                                       " WHERE cancelled = 'N'" +
                                         " AND a.patient_file_active_yn = 'Y'" +
                                         " AND (patient_discharge_date IS NULL OR patient_discharge_date = '')" +
                                         " AND (patient_admission_date IS NOT NULL OR patient_admission_date != '')" +
                                         " AND CONVERT (smalldatetime, patient_admission_date, 103) <= getdate ()-2" +
                                         " AND (a.in_patient = 'Y')" + //OR a.out_patient = 'Y'
                                         " AND file_operator_to_userid IS NOT NULL" +
                                         " AND PATIENT_ID NOT IN (SELECT PATIENT_ID FROM AIMS_NOTES XX WHERE XX.PATIENT_ID = A.PATIENT_ID AND NOTE_TYPE_ID = 8)" +
                                         " AND C.GUARANTOR_ID = a.GUARANTOR_ID " +
                                         " AND d.user_name = file_operator_to_userid" +
                                         " ORDER BY 1,3 ";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandTimeout = 0;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Admission Date</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>Last Updated Date Time</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center><b>SLA Violation(days)</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        caseManager = dtDrillReportData.Rows[i]["file_allocated_to"].ToString();
                        PatientFile = dtDrillReportData.Rows[i]["patient_file_no"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        Guarantor = dtDrillReportData.Rows[i]["guarantor_name"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["patient_admission_date"].ToString();
                        //DischargeDate = dtDrillReportData.Rows[i]["patient_discharge_date"].ToString();
                        NotesDTTM = dtDrillReportData.Rows[i]["notes_dttm"].ToString();
                        CommentSLAViolation = dtDrillReportData.Rows[i]["COMMENT_SLA"].ToString();

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + caseManager + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFile + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Guarantor + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        //"<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + DischargeDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + NotesDTTM + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + CommentSLAViolation + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><b>ALL FILES ARE UPDATED</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "casemanager@aims.org.za;operations@aims.org.za");
                string ReportRecipient = "casemanager@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages("Patient Files Without Medical Update Notes/Comments in " + CaseLastCommentSLA + "+ Days", "Email Successful", false);
                }
                else
                {
                    LogMessages("Patient Files Without Medical Update Notes/Comments in " + CaseLastCommentSLA + "+ Days", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Patient Files Without Medical Update Notes/Comments in " + CaseLastCommentSLA + "+ Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesTaggedToOperatorsWithoutMedicalComments()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            
            string MedicalOfficer ="";
            
            string LastNoteCaptured = "";
            string NotesDateTime = "";
            string GuarantorName = "";
            

            string DrillReportEmailSubject = "Patient Case Without Medical Comments/Notes - Last " + System.Convert.ToInt64(CaseLastCommentSLA)*24 + " Hours";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table  cellpadding=1 cellspacing=1 border=1 bordercolor=black width=100% align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=9>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject  + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=9>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT  f.User_Full_Name Medical_Officer,  "+
                                //d.user_full_name file_allocated_to, "+ 
                            " a.patient_file_no," +
                            " dbo.INITCAP (a.patient_last_name + ' ' + a.patient_first_name) patient_name," +
                         " c.guarantor_name, a.patient_admission_date," +
                         " RTRIM (LTRIM (b.notes)) last_note_captured, b.notes_dttm," +
                         " datediff (d,CONVERT (smalldatetime, b.notes_dttm, 103),getdate ()) comment_sla, " +
                        " b.USER_NAME, patient_discharge_date" +
                    " FROM aims_patient a, aims_notes b, aims_guarantor c,  "+
                    //aims_users d, 
                    " AIMS_USERS f " +
                   " WHERE cancelled = 'N'" +
                     " AND a.patient_file_active_yn = 'Y'" +
                     " AND (patient_discharge_date IS NULL OR patient_discharge_date = '') " +
                     " AND (patient_admission_date IS NOT NULL OR patient_admission_date != '') " +
                     " AND CONVERT (smalldatetime, patient_admission_date, 103) < getdate () " +
                     " AND (a.in_patient = 'Y' OR a.out_patient = 'Y') " +
                     //" AND file_operator_to_userid IS NOT NULL " +
                     " AND b.patient_id = a.patient_id " +
                     " AND b.note_id = " +
                            " (SELECT MAX (note_id) " +
                               " FROM aims_notes " +
                              " WHERE     aims_notes.patient_id = a.patient_id " +
                                    " AND aims_notes.note_type_id = 8 " +
                                 " OR (SELECT COUNT (*) " +
                                 " FROM aims_notes e " +
                                      " WHERE e.patient_id = a.patient_id AND e.note_type_id = 8) = 0) " +
                     " AND c.guarantor_id = a.guarantor_id " +
                     //" AND d.user_name = file_operator_to_userid " +
                     " AND datediff (d, CONVERT (smalldatetime, b.notes_dttm, 103), getdate ()) > " + CaseLastCommentSLA + " " +
	                " and f.User_Name = b.USER_NAME " +
                " ORDER BY f.User_Full_Name, " +
                         " CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC) ";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Medical Officer</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Admission Date</b></td>" +
                                //"<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Last Note/Comment Captured</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center nowrap><b>Note/Comment Date Time</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        //FileAllocatedTo = dtDrillReportData.Rows[i]["FILE_ALLOCATED_TO"].ToString();
                        MedicalOfficer = dtDrillReportData.Rows[i]["Medical_Officer"].ToString();
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_NAME"].ToString();
                        GuarantorName = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        //DischargeDate = dtDrillReportData.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString();
                        LastNoteCaptured = dtDrillReportData.Rows[i]["LAST_NOTE_CAPTURED"].ToString();
                        NotesDateTime = dtDrillReportData.Rows[i]["NOTES_DTTM"].ToString();

                        //if (DischargeDate == "") { DischargeDate = "<font color=white>-</font>"; }
                        if (LastNoteCaptured == "") { LastNoteCaptured = "<font color=white>-</font>"; }
                        if (AdmissionDate == "") { AdmissionDate = "<font color=white>-</font>"; }
                        if (PatientName == "") { PatientName = "<font color=white>-</font>"; }

                        sEmailBody += "<tr style=border-style:thick>" +
                        //"<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + FileAllocatedTo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + MedicalOfficer + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + GuarantorName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + AdmissionDate + "</td>" +
                            //"<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + DischargeDate + "</td>" +
                        "<td valign=top bgcolor=#ffffff align=center><b>" + LastNoteCaptured.Replace("\r\n","<br>") + "</b></td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center nowrap>" + NotesDateTime + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=9><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=9><b>" + DrillReportEmailSubject + " :Records Up-to-date</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;HendrikJ@aims.org.za;operations@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;HendrikJ@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " - Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " - Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesNotTaggedToOperators()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string GuarantorName = "";
            string PatientName = "";

            string LateLogDTTm = "";
            string LateLogYN = "";
            string InOutPatient = "";

            string DrillReportEmailSubject = "Patient Case(s) Not Allocated To a Co-Ordinator";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=7>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT a.patient_id, a.patient_file_no, a.patient_admission_date, " +
                            " LTRIM (  dbo.INITCAP (e.title_desc)+ ' '+  " +
                            " dbo.INITCAP (patient_first_name) + ' '+ dbo.INITCAP (patient_last_name)) patient_name, " +
                            " B.GUARANTOR_NAME, " +
                            " a.late_log_yn, a.late_log_date, a.out_patient, a.in_patient " +
                            " FROM aims_patient a, aims_title e, aims_guarantor b " +
                            " WHERE a.cancelled = 'N' " +
                            " AND (a.pending = 'N' OR a.pending IS NULL) " +
                            " AND (a.patient_admission_date IS NOT NULL OR patient_admission_date <> '') " +
                            " AND (a.patient_discharge_date IS NULL OR a.patient_discharge_date = '') " +
                            " and (a.file_operator_to_userid is null or a.file_operator_to_userid ='') " +
                            " AND e.title_id = a.title_id " +
                            " and b.GUARANTOR_ID = a.GUARANTOR_ID " +
                            " ORDER BY 1 desc";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=25%><b>Patient Full Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=30%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Late Log(Y/N)</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Late Log Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient Status</b></td>" +
                                "</tr>"; 

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        GuarantorName = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        LateLogYN = dtDrillReportData.Rows[i]["LATE_LOG_YN"].ToString();
                        LateLogDTTm = dtDrillReportData.Rows[i]["LATE_LOG_DATE"].ToString();
                        InOutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();

                        if (!LateLogDTTm.Equals(""))
                        {
                            LateLogDTTm = System.Convert.ToDateTime(LateLogDTTm).ToShortDateString();
                        }
                        if (InOutPatient.Equals("Y"))
                        {
                            InOutPatient = "<b>OUT-Patient</b>";
                        }
                        else
                        {
                            InOutPatient = "<b>IN-Patient</b>";
                        }

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + GuarantorName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogYN + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogDTTm + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + InOutPatient + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><b>All Patient Cases Allocated.</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject+  " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesWithoutCommentsinLast24HoursPerGuarantor()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string AdmissionDate = "";
            string PatientName = "";
            string Guarantor = "";
            string LastGuarantor = "";
            string FileCoOrdinator = "";
            string PatientFile = "";
            string NotesDTTM = "";
            string sEmailColumnHeaders = "";
            bool bFirstTime = false;

            //string DrillReportEmailSubject = "Patient Files(Per Guarantor) Without Updated Notes/Comment in " + System.Convert.ToInt64(CaseLastCommentSLA) * 24 + " Hours";
            string DrillReportEmailSubject = "Active Patient Files(Per Guarantor) Not Discharged";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 border=1 style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=5>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                                //SQLString = " SELECT   c.guarantor_name,  " +
                                //                 " CAST (substring (a.patient_file_no, 4, 5) AS NUMERIC), " +
                                //                 " a.patient_file_no, " +
                                //                 " dbo.INITCAP (a.patient_last_name + ' ' + a.patient_first_name ) patient_name, " +
                                //                 " c.guarantor_name, a.patient_admission_date, " +
                                //                 " RTRIM (LTRIM (b.notes)) last_note_captured, b.notes_dttm, " +
                                //                 " datediff (d, CONVERT (smalldatetime, b.notes_dttm, 103), getdate () ) comment_sla, " +
                                //                 " d.User_Full_Name " +
                                //            " FROM aims_patient a, aims_notes b, aims_guarantor c , AIMS_USERS d " +
                                //           " WHERE cancelled = 'N' " +
                                //             " AND a.patient_file_active_yn = 'Y' " +
                                //             " AND (patient_discharge_date IS NULL OR patient_discharge_date = '') " +
                                //             " AND b.patient_id = a.patient_id " +
                                //             " AND b.note_id = (SELECT MAX (note_id) FROM aims_notes WHERE aims_notes.patient_id = a.patient_id) " +
                                //             " AND c.guarantor_id = a.guarantor_id " +
                                //             " AND datediff (d, CONVERT (smalldatetime, b.notes_dttm, 103), getdate ()) > " + CaseLastCommentSLA +
                                //             " and d.User_Name =+ a.FILE_OPERATOR_TO_USERID " +
                                //        " ORDER BY 1, CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC) ";

                         //   SQLString = " SELECT   c.guarantor_name,    " +
                         //         " CAST (substring (a.patient_file_no, 4, 5) AS NUMERIC),   " +
                         //         " a.patient_file_no,   " +
                         //         " dbo.INITCAP (a.patient_last_name + ' ' + a.patient_first_name ) patient_name,   " +
                         //         " c.guarantor_name, a.patient_admission_date,   " +
                         //         " RTRIM (LTRIM (b.notes)) last_note_captured, b.notes_dttm,   " +
                         //         " datediff (d, CONVERT (smalldatetime, b.notes_dttm, 103), getdate () ) comment_sla ,  " +
                         //         " d.User_Full_Name,  " +
                         //         " b.NOTES  " +                                
                         //    " FROM aims_patient a  " +
                         //    " inner join aims_notes b on b.patient_id = a.patient_id  " + 
                         //    " inner join aims_guarantor c on c.guarantor_id = a.guarantor_id  " + 
                         //    " left outer join  AIMS_USERS d on d.User_Name = a.FILE_OPERATOR_TO_USERID  " +
                         //   " WHERE cancelled = 'N'  " + 
                         //     " AND a.patient_file_active_yn = 'Y'  " + 
                         //     " AND (patient_discharge_date IS NULL OR patient_discharge_date = '')  " + 
                         //     " AND b.note_id = (SELECT MAX (note_id) FROM aims_notes WHERE aims_notes.patient_id = a.patient_id)  " + 
                         //     " AND datediff (d, CONVERT (smalldatetime, b.notes_dttm, 103), getdate ()) >"  + CaseLastCommentSLA +
                         //" ORDER BY 1, CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC)  ";


                SQLString = " SELECT   c.guarantor_name,  " +
                            " CAST (substring (a.patient_file_no, 4, 5) AS NUMERIC),  " +
                            " a.patient_file_no,  " +
                            " dbo.INITCAP (a.patient_last_name + ' ' + a.patient_first_name) patient_name,  " +
                            " c.guarantor_name, a.patient_admission_date,  " +
                            " c.guarantor_name, a.patient_admission_date,  " +
                            " d.user_full_name  " +
                            " FROM aims_patient a  " +
                            " INNER JOIN aims_guarantor c ON c.guarantor_id = a.guarantor_id  " +
                            " LEFT OUTER JOIN aims_users d ON d.user_name =  a.file_operator_to_userid  " +
                            " WHERE cancelled = 'N'  " +
                            " AND a.patient_file_active_yn = 'Y' AND a.pending = 'N' " +
                            " AND (patient_discharge_date IS NULL OR patient_discharge_date = '')  " +
                            " and PATIENT_ADMISSION_DATE is not null and CONVERT (smalldatetime, PATIENT_ADMISSION_DATE, 103) < GETDATE() "+
                            " AND (c.GUARANTOR_NAME != '' or c.GUARANTOR_NAME != ' ')  " +
                            " ORDER BY 1, CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC) ";


                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailColumnHeaders += "<tr>" +
                               "<td nowrap bgcolor=lightgrey valign=bottom align=center width=10%><b>Co-Ordinator</b></td>" +
                               "<td nowrap bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient File No</b></td>" +
                               "<td nowrap bgcolor=lightgrey valign=bottom align=center width=35%><b>Patient Name</b></td>" +
                               "<td nowrap bgcolor=lightgrey valign=bottom align=center width=30%><b>Guarantor</b></td>" +
                               "<td nowrap bgcolor=lightgrey valign=bottom align=center width=15%><b>Admission Date</b></td>" +
                               //"<td nowrap bgcolor=lightgrey valign=bottom align=center width=10%><b>Last Updated Date Time</b></td>" +
                               //"<td nowrap bgcolor=lightgrey valign=bottom align=center width=50%><b>Last Note/Comment Captured</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        FileCoOrdinator = dtDrillReportData.Rows[i]["User_Full_Name"].ToString();
                        if (FileCoOrdinator.Equals(""))
                        {
                            FileCoOrdinator = "-";
                        }
                        Guarantor = dtDrillReportData.Rows[i]["guarantor_name"].ToString();
                        PatientFile = dtDrillReportData.Rows[i]["patient_file_no"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        Guarantor = dtDrillReportData.Rows[i]["guarantor_name"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["patient_admission_date"].ToString();
                        //NotesDTTM = dtDrillReportData.Rows[i]["notes_dttm"].ToString();
                        //LastNoteCaptured = dtDrillReportData.Rows[i]["last_note_captured"].ToString();

                        if (!LastGuarantor.Equals(Guarantor))
                        {
                            LastGuarantor = Guarantor;
                            if (bFirstTime)
                            {
                                sEmailBody += "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";
                            }
                            bFirstTime = true;
                            sEmailBody += "<tr><td colspan=5 bgcolor=lightgrey><b>" + Guarantor + "</b></td></tr>";
                            sEmailBody += sEmailColumnHeaders;
                        }

                        if (AdmissionDate.Trim().Equals(""))
                        {
                            AdmissionDate = "&nbsp;";
                        }
                        sEmailBody += "<tr  style=border-style:thick>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + FileCoOrdinator + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFile + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + Guarantor + "</td>" +
                        "<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        //"<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + NotesDTTM + "</td>" +
                        //"<td valign=top bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=left>" + LastNoteCaptured.Replace("\r\n", "<br>") + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><b>ALL FILES ARE UPDATED</b></td>" +
                                "</tr>";
                }

                sEmailBody += "<tr>" +
                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                "</tr>";

                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");

                if (blResult)
                {
                    LogMessages("Patient Files Without Updated Notes/Comment in 2+ Days", "Email Successful", false);
                }
                else
                {
                    LogMessages("Patient Files Without Updated Notes/Comment in 2+ Days", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patient Files Without Updated Notes/Comment", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateAfterHoursFiles()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string GuarantorName = "";
            string PatientName = "";
            
            string LateLogDTTm = "";
            
            string InOutPatient = "";

            string DrillReportEmailSubject = "After-Hours Files Not Allocated";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=5>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT   a.patient_id, a.patient_file_no, a.patient_admission_date, " +
                            " LTRIM (  dbo.INITCAP (e.title_desc) "+
                            " + ' ' "+
                            " + dbo.INITCAP (patient_first_name) "+
                            " + ' ' "+
                            " + dbo.INITCAP (patient_last_name) "+
                            " ) patient_name, "+
                            " b.guarantor_name, a.out_patient, a.in_patient "+
                            " FROM aims_patient a, aims_title e, aims_guarantor b "+
                            " WHERE a.cancelled = 'N' "+
                            " AND a.after_hours_file = 'Y' "+
                            " AND (a.FILE_OPERATOR_TO_USERID = '' OR a.FILE_OPERATOR_TO_USERID IS NULL " +
                            " ) "+
                            " AND e.title_id = a.title_id "+
                            " AND b.guarantor_id = a.guarantor_id and sent_to_admin = 'N' "+
                            " ORDER BY 1 DESC";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=30%><b>Patient Full Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=40%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient Status</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        GuarantorName = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        InOutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();

                        if (!LateLogDTTm.Equals(""))
                        {
                            LateLogDTTm = System.Convert.ToDateTime(LateLogDTTm).ToShortDateString();
                        }
                        if (InOutPatient.Equals("Y"))
                        {
                            InOutPatient = "<b>OUT-Patient</b>";
                        }
                        else
                        {
                            InOutPatient = "<b>IN-Patient</b>";
                        }

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + GuarantorName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + InOutPatient + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=5><b>No After-Hours Files Found</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za", "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za", "", false, "", "martitian@gmail.com");

                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateWorkBaskets()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string DrillReportEmailSubject = "Co-Ordinator Work Basket SLA Report - Emails not processed";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=2>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=2>&nbsp;</td>" +
                                "</tr>";

                SQLString = "select c.user_full_name, " +
                        " COUNT(c.User_Name) ITEMS from AIMS_EWS_OPERATOR_MAILS a, " +
                        " AIMS_EWS_OPERATOR_MAILBOX b, AIMS_USERS c " +
                         " where WORK_ITEM_PROCESSED_YN = 'N' " +
                         " and b.OPERATOR_MAILBOX_ID = a.OPERATOR_MAILBOX_ID " +
                         " and c.User_Name = b.OPERATOR_MAILBOX_USER_NAME " +
                         " group by c.user_full_name " +
                         " order by 2";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=80%><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=20%><b>Work Basket Items</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["user_full_name"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["ITEMS"].ToString() + "</td>" +
                        "</tr>";
                    }
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=2><b>ALL WORKBASKETS UP-TO-DATE</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za", "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za", "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateAdminProductivity()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string DrillReportEmailSubject = "Admin Team Productivity - Weekly [" + DateTime.Now.AddDays(-1).ToShortDateString() + "]";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=2>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=2>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT b.USER_FULL_NAME, COUNT (a.modified_user) ITEMS" +
                            " FROM aims_a_invoice a, aims_users b "+
                            " WHERE CONVERT (datetime, a.modified_date, 103) >= GETDATE() - 8 "+
                            " AND a.modified_user IN (SELECT user_name "+
                            " FROM aims_user_role "+
                            " WHERE role_cd = 'Admin') and b.user_name = a.modified_user " +
                            " GROUP BY b.USER_FULL_NAME " +
                            " HAVING COUNT (a.modified_user) > 0 " +
                            " ORDER BY 2";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=80%><b>Administrator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=20%><b>Work Effort</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["USER_FULL_NAME"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["ITEMS"].ToString() + "</td>" +
                        "</tr>";
                    }
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=2><b>Not Records for Administrators Productivity</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Admin Productivity Report", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateInPatient(string ReportRecipient)
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string Hospital = "";
            string Insurance = "";
            string Diagnosis = "";
            string LatestGOP = "";
            string CaseHandler = "";

            string DrillReportEmailSubject = "In-Patient Cases";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"SELECT a.patient_file_no ""Case"",convert(smalldatetime,PATIENT_ADMISSION_DATE,103) Admission, " +
                        " UPPER(A.Patient_Last_Name)+ ' ' + UPPER(PATIENT_FIRST_NAME) +  ' (' + UPPER(A.PATIENT_INITIALS) + ') (' +  UPPER(ATT.Title_desc) + ')' AS Patient, "+
                        " asup.supplier_name Hospital, "+
	                      "    b.guarantor_name Insurance,  "+
                        " a.patient_diagnosis Diagnosis, "+
                        @"a.patient_guarantor_amount ""Latest GOP"", "+
                        @" User_Full_Name ""Case Handler"" "+
		                  "       FROM aims_patient a "+
		                    "     left outer join aims_guarantor b on b.guarantor_id = a.guarantor_id "+
		                      "   LEFT OUTER JOIN AIMS_TITLE  AS att ON  att.title_id  = a.title_id    "+
		                        " left outer join aims_supplier as asup on asup.supplier_id = a.supplier_id          "+                
		                        " left outer join AIMS_USERS as aum on  aum.user_name = a.FILE_OPERATOR_TO_USERID "+
	                           " WHERE cancelled = 'N' "+
		                         " AND a.patient_file_active_yn = 'Y' "+
		                         " AND (patient_discharge_date IS NULL OR patient_discharge_date = '') "+
		                         " AND (PATIENT_ADMISSION_DATE IS not NULL OR PATIENT_ADMISSION_DATE != '') "+
		                        " and a.IN_PATIENT = 'Y' and PENDING = 'N'	  "+
	                        " ORDER BY convert(smalldatetime,PATIENT_ADMISSION_DATE , 103) desc,  "+
	                        " CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC) desc, "+
	                        " CAST (substring (a.patient_file_no, 4, 4) AS NUMERIC) desc";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Case</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Admission</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=35%><b>Patient</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=20%><b>Hospital</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=25%><b>Insurance</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Diagnosis</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Latest GOP</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Handler</b></td>" +
                                "</tr>";

                    DateTime dtCommit;
                    bool reportPageBreak = true;
                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["Case"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["Admission"].ToString();
                        PatientName  = dtDrillReportData.Rows[i]["Patient"].ToString();
                        Hospital = dtDrillReportData.Rows[i]["Hospital"].ToString();
                        if (Hospital.Trim().Equals(""))
                        {
                            Hospital = "-";
                        }
                        Insurance = dtDrillReportData.Rows[i]["Insurance"].ToString();
                        if (Insurance.Trim().Equals(""))
                        {
                            Insurance = "-";
                        }
                        Diagnosis = dtDrillReportData.Rows[i]["Diagnosis"].ToString();
                        if (Diagnosis.Trim().Equals(""))
                        {
                            Diagnosis = "-";
                        }
                        LatestGOP = dtDrillReportData.Rows[i]["Latest GOP"].ToString();
                        if (LatestGOP.Trim().Equals(""))
                        {
                            LatestGOP = "-";
                        }
                        CaseHandler = dtDrillReportData.Rows[i]["Case Handler"].ToString();
                        if (CaseHandler.Trim().Equals(""))
                        {
                            CaseHandler = "-";
                        }
                        dtCommit = Convert.ToDateTime(AdmissionDate);
                        System.TimeSpan diffResult = dtCommit.Subtract(DateTime.Now);

                        if (diffResult.Days < 0 && reportPageBreak)
                        {
                            sEmailBody += "<tr>" +
                                "<td bgcolor=YELLOW valign=bottom align=center colspan=8><span style='Font-color:red;font-family:tahoma;font-size:20px'>Active In-Patients</span></td>" +
                                        "</tr>";
                            reportPageBreak = false;
                        }
                        sEmailBody += "<tr>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dtCommit.ToString("dd-MMM-yyyy") + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Hospital + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Insurance + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Diagnosis + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + LatestGOP + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + CaseHandler + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>No After-Hours Files Found</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "martitian@gmail.com");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (!blResult)
	            {
            	    blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ReportRecipient);	 
	            }
                
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateWorkBasketsAdmin()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string DrillReportEmailSubject = "Administration Work Basket SLA Report - Emails not processed";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=2>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=2>&nbsp;</td>" +
                                "</tr>";

                SQLString = "select c.user_full_name, " +
                        " COUNT(c.User_Name) ITEMS from AIMS_EWS_ADMIN_MAILS a, " +
                        " AIMS_EWS_ADMIN_MAILBOX b, AIMS_USERS c " +
                         " where WORK_ITEM_PROCESSED_YN = 'N' " +
                         " and b.OPERATOR_MAILBOX_ID = a.OPERATOR_MAILBOX_ID " +
                         " and c.User_Name = b.OPERATOR_MAILBOX_USER_NAME " +
                         " group by c.user_full_name " +
                         " order by 2";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=80%><b>Administrator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=20%><b>Work Basket Items</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["user_full_name"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["ITEMS"].ToString() + "</td>" +
                        "</tr>";
                    }
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=2><b>Workbasket(s) Up-to-date</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ";douglas@aims.org.za;admin@aims.org.za");
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ";douglas@aims.org.za;admin@aims.org.za", "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, "douglas@aims.org.za;admin@aims.org.za", "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Administration Workbaskets", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateFilesNotAssignedToAdmin()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string GuarantorName = "";
            string PatientName = "";

            string LateLogDTTm = "";
            string LateLogYN = "";
            string InOutPatient = "";

            string DrillReportEmailSubject = "Admin Case(s) Not Assigned To a Administrator";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=7>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"SELECT a.patient_id, a.patient_file_no, a.patient_admission_date,a.patient_discharge_date,
                            LTRIM (  
                            dbo.INITCAP (e.title_desc)+ ' '+  
                            dbo.INITCAP (patient_first_name) + ' '+ 
                            dbo.INITCAP (patient_last_name) ) patient_name,B.GUARANTOR_NAME,
                            a.late_log_yn, a.late_log_date, a.out_patient, a.in_patient  
                            from AIMS_PATIENT a 
                            left outer join aims_title e on e.TITLE_ID = a.TITLE_ID
                            left outer join aims_guarantor b on b.guarantor_id = a.guarantor_id
                            where cancelled = 'N' and SENT_TO_ADMIN = 'Y' and 
                            (FILE_ASSIGNED_TO_USERID is null or FILE_ASSIGNED_TO_USERID = '') and 
                            (PATIENT_DISCHARGE_DATE is not  null or PATIENT_DISCHARGE_DATE  <> '') 
                            AND (a.pending = 'N' OR a.pending IS NULL)   and a.PATIENT_FILE_COURIER_YN = 'N' 
                            ORDER BY 1 desc";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=25%><b>Patient Full Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=30%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Late Log(Y/N)</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Late Log Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient Status</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString();
                        GuarantorName = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["patient_name"].ToString();
                        LateLogYN = dtDrillReportData.Rows[i]["LATE_LOG_YN"].ToString();
                        LateLogDTTm = dtDrillReportData.Rows[i]["LATE_LOG_DATE"].ToString();
                        InOutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();

                        if (!LateLogDTTm.Equals(""))
                        {
                            LateLogDTTm = System.Convert.ToDateTime(LateLogDTTm).ToShortDateString();
                        }
                        if (InOutPatient.Equals("Y"))
                        {
                            InOutPatient = "<b>OUT-Patient</b>";
                        }
                        else
                        {
                            InOutPatient = "<b>IN-Patient</b>";
                        }

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + GuarantorName + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogYN + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + LateLogDTTm + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + InOutPatient + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><b>All Admin Cases are Allocated.</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ";douglas@aims.org.za;admin@aims.org.za;danielm@aims.org.za");
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ";douglas@aims.org.za;admin@aims.org.za;danielm@aims.org.za", "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, "douglas@aims.org.za;admin@aims.org.za;danielm@aims.org.za", "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateDailySentLateSubmission()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string DischargeDate = "";
            string GuarantorName = "";
            string PatientName = "";
            string WaybillNo = "";
            string DueDate = "";

            string LateLogDTTm = "";
            string LateLogYN = "";
            string InOutPatient = "";

            string DrillReportEmailSubject = "Daily SENT Late-Submissions Courier Files - " + "[" + DateTime.Now.ToShortDateString() + "]";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"select 
                                PATIENT_FILE_NO, a.INVOICE_SENT_WAYBILL_NO, COURIER_WAYBILL_NO ,a.INVOICE_DATE ,
                                c.FILE_COURIER_DATE, a.INVOICE_NO , b.GUARANTOR_NAME, c.PATIENT_ADMISSION_DATE, c.PATIENT_DISCHARGE_DATE, a.INVOICE_SENT_WAYBILL_NO, a.invoice_no
                                from AIMS_INVOICE a 
                                inner join aims_patient c on c.PATIENT_ID =  a.PATIENT_ID 
                                inner join aims_guarantor b on b.GUARANTOR_ID = c.GUARANTOR_ID 
                                where 
                                CONVERT (smalldatetime, a.CREATION_DTTM, 103) >= getdate()-1 and 
                                CONVERT (smalldatetime, a.CREATION_DTTM, 103) <= getdate ()";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=15%><b>Late Invoice Waybill No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=15%><b>File Waybill Number</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Invoice No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Invoice Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=30%><b>Guarantor Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Discharge Date</b></td>" +
                               "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        GuarantorName = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        WaybillNo = dtDrillReportData.Rows[i]["COURIER_WAYBILL_NO"].ToString();
                        DischargeDate = dtDrillReportData.Rows[i]["patient_discharge_date"].ToString();

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["INVOICE_SENT_WAYBILL_NO"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + WaybillNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["INVOICE_NO"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["INVOICE_DATE"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + GuarantorName  + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + DischargeDate  + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><b>NO DAILY FILES FOUND FOR UPS/SCANNING.</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ";douglas@aims.org.za;admin@aims.org.za");
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ";douglas@aims.org.za;admin@aims.org.za", "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, "douglas@aims.org.za;admin@aims.org.za;danielm@aims.org.za", "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateDailyUPSFiles()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string DischargeDate = "";
            string GuarantorName = "";
            string PatientName = "";
            string WaybillNo = "";
            string DueDate = "";

            string LateLogDTTm = "";
            string LateLogYN = "";
            string InOutPatient = "";

            string DrillReportEmailSubject = "Daily Sent UPS/SCANNING Files - " + "[" + DateTime.Now.ToShortDateString() + "]";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"select PATIENT_FILE_NO, FILE_COURIER_DATE, COURIER_WAYBILL_NO, b.GUARANTOR_NAME, a.PATIENT_ADMISSION_DATE, a.PATIENT_DISCHARGE_DATE
                                 from AIMS_PATIENT a 
                                 inner join aims_guarantor b on b.GUARANTOR_ID = a.GUARANTOR_ID 
                                where (a.FILE_COURIER_DATE is not null and a.FILE_COURIER_DATE !='') and 
                                a.creation_dttm >= getdate() - 360 and 
                                CONVERT (smalldatetime, a.FILE_COURIER_DATE, 103) >= getdate()-1 and 
                                CONVERT (smalldatetime, a.FILE_COURIER_DATE, 103) <= getdate ()";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=25%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=30%><b>Waybill Number</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center width=30%><b>Due Date</b></td>" +
                               //"<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Discharge Date</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        GuarantorName = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        WaybillNo = dtDrillReportData.Rows[i]["COURIER_WAYBILL_NO"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["patient_admission_date"].ToString();
                        DischargeDate = dtDrillReportData.Rows[i]["patient_discharge_date"].ToString();

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + PatientFileNo + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + GuarantorName  + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + WaybillNo  + "</td>" +
                        //"<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + AdmissionDate + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + DischargeDate  + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><b>NO DAILY FILES FOUND FOR UPS/SCANNING.</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ";douglas@aims.org.za;admin@aims.org.za");
                string ReportRecipient = ";douglas@aims.org.za;admin@aims.org.za";
                blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Error generating Daily Sent UPS/SCANNING Report:", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }


        private DataTable dtDischargeLabList()
        {
            DataTable dtFileList = new DataTable();
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            try
            {
                SQLString = @"SELECT  (A.PATIENT_LAST_NAME + ' ' + A.PATIENT_FIRST_NAME) 'PATIENT NAME',
                        PATIENT_FILE_NO 'AIMS FILE No.',
                        PATIENT_DATE_OF_BIRTH 'PT DOB', 
                        PATIENT_ADMISSION_DATE 'ADMIT DATE',
                        PATIENT_DISCHARGE_DATE 'DISCHARGE DATE' , 
                        CASE B.SUPPLIER_NAME WHEN '' THEN 'O/P' WHEN NULL THEN 'O/P' ELSE B.SUPPLIER_NAME END 'MAIN SUPPLIER',
                        '' COMMENT
                    FROM AIMS_PATIENT A 
                            LEFT OUTER JOIN AIMS_SUPPLIER B ON B.SUPPLIER_ID = A.SUPPLIER_ID
                    where (a.LAB_LIST_DATE is not null and a.LAB_LIST_DATE !='') and 
                    CONVERT (smalldatetime, a.LAB_LIST_DATE, 103) >= getdate()-1 and 
                    CONVERT (smalldatetime, a.LAB_LIST_DATE, 103) <= getdate ()+1 AND SENT_TO_ADMIN = 'Y' and 
                    (FILE_ASSIGNED_TO_USERID is not null or FILE_ASSIGNED_TO_USERID !='')";
                LogMessages(SQLString , "Generating Discharge List SQL", false );
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                dtFileList = dtDrillReportData;
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Discharge List Report ERROR", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
            return dtFileList;
        }

        public void GenerateAdminDischargeList()
        {
            try
            {
                DataTable dtdata = dtDischargeLabList();
                string DailyListFile = "";
                if (dtdata.Rows.Count > 0)
                {
                    DailyListFile = @"c:\AIMS Recorder\AIMS - Discharge List[" + DateTime.Now.ToString("dd-MMMM-yyyy") + "].xlsx";
                    FileInfo existingFile = new FileInfo(DailyListFile);
                    if (existingFile.Exists)
                        existingFile.Delete();

                    using (ExcelPackage package = new ExcelPackage(existingFile))
                    {
                        OfficeOpenXml.ExcelWorksheet ws = package.Workbook.Worksheets.Add("AIMS - Discharge List");

                        System.Drawing.Image myImage = System.Drawing.Image.FromFile(@"C:\AIMS Recorder\AIMSLOGO.png");

                        ws.Drawings.AddPicture("AIMSLOGO", myImage);

                        ws.Cells["A7"].Value = "Alliance International Services";
                        ws.Cells[7, 1, 7, 4].Merge = true;
                        ws.Cells[7, 1, 7, 4].Style.Font.Bold = true;

                        ws.Cells["A8"].Value = "3 West Street";
                        ws.Cells[8, 1, 8, 4].Merge = true;
                        ws.Cells[8, 1, 8, 4].Style.Font.Bold = true;

                        ws.Cells["A9"].Value = "Bryanston";
                        ws.Cells[9, 1, 9, 4].Merge = true;
                        ws.Cells[9, 1, 9, 4].Style.Font.Bold = true;

                        ws.Cells["A10"].Value = "2191";
                        ws.Cells[10, 1, 10, 4].Merge = true;
                        ws.Cells[10, 1, 10, 4].Style.Font.Bold = true;

                        ws.Cells["A11"].Value = "tel. 011 783 0135";
                        ws.Cells[11, 1, 11, 4].Merge = true;
                        ws.Cells[11, 1, 11, 4].Style.Font.Bold = true;

                        ws.Cells["A12"].Value = "fax. 011 463 3583";
                        ws.Cells[12, 1, 12, 4].Merge = true;
                        ws.Cells[12, 1, 12, 4].Style.Font.Bold = true;

                        ws.Cells[15, 1, 15, 7].Style.Font.Bold = true;

                        ws.Cells[15, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        ws.Cells[15, 1].LoadFromDataTable(dtdata, true);

                        ws.Cells[15, 1, 15, 12].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        ws.Cells[15, 1, 15, 7].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        ws.Cells[15, 1, 15, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Cyan);
                        ws.Cells[15, 7, 15, 12].Merge = true;
                        ws.Cells[15, 7, 15, 12].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        ws.Column(1).Width = 45;
                        ws.Column(2).Width = 13;
                        ws.Column(3).Width = 13;
                        ws.Column(4).Width = 13;
                        ws.Column(5).Width = 16;
                        ws.Column(6).Width = 16;
                        ws.Column(7).Width = 30;

                        for (int i = 0; i < dtdata.Rows.Count + 1; i++)
                        {
                            ws.Cells[15 + i, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            ws.Cells[15 + i, 1, 15 + i, 12].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            ws.Cells[15 + i, 7, 15 + i, 12].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[15 + i, 7, 15 + i, 12].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[15 + i, 7, 15 + i, 12].Merge = true;
                            for (int j = 1; j < 7; j++)
                            {
                                ws.Cells[15 + i, j].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            }
                        }
                        package.Save();
                        ws.Dispose();
                        dtdata.Dispose();
                        myImage.Dispose();
                    }
                }

                AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();
                bool blResult = false;
                string sEmailBody = "";
                string DrillReportEmailSubject = "AIMS DISCHARGE LIST - " + "[" + DateTime.Now.ToShortDateString() + "]";

                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>";

                if (dtdata.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>TOTAL - " + dtdata.Rows.Count + "</b></font></td>" +
                                "</tr>";
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>NO DAILY DISCHARGE LIST GENERATED.</b></font></td>" +
                                "</tr>";
                    DailyListFile = "";
                }

                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";
                 
                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ";douglas@aims.org.za;admin@aims.org.za", DailyListFile);
                string ReportRecipient = "douglas@aims.org.za;admin@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, DailyListFile, "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, DailyListFile, false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                    LogMessages(DrillReportEmailSubject + " Email Report Body: " + sEmailBody , "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                LogMessages(ex.ToString(), "Discharge List Report could not be generated.", true);
            }
            finally
            {
            }
        }

        public void GenerateOverDueTasks(string ReportRecipient)
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string Hospital = "";
            string Insurance = "";
            string Diagnosis = "";
            string LatestGOP = "";
            string CaseHandler = "";

            string DrillReportEmailSubject = "Overdue Tasks " + "[" + DateTime.Now.ToShortDateString() + "]";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"select b.TASK_DESC,c.PRIORITY, a.*,d.PATIENT_FILE_NO, d.PATIENT_LAST_NAME  from AIMS_PATIENT_FILE_TASKS a, AIMS_TASKS b, AIMS_PRIORITY c , AIMS_PATIENT d   
                              where DUE_DATE < GETDATE()-1 and TASK_STATUS_ID in (2, 8) and USER_ID in (
                                select USER_NAME from AIMS_USER_ROLE) and b.TASK_ID = a.TASK_ID and c.PRIORITY_ID = a.PRIORITY_ID   
                              and d.PATIENT_ID = a.PATIENT_ID order by USER_ID  , PATIENT_FILE_NO";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Patient Last Name</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=30%><b>Task Description</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=25%><b>Task Details</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=15%><b>Task Creation Date</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        CaseHandler = dtDrillReportData.Rows[i]["User_id"].ToString();
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_LAST_NAME"].ToString();
                        Hospital = dtDrillReportData.Rows[i]["Task_Desc"].ToString();
                        Insurance = dtDrillReportData.Rows[i]["DETAILS"].ToString();
                        Diagnosis = dtDrillReportData.Rows[i]["Creation_date"].ToString();
                        
                        
                        sEmailBody += "<tr>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + CaseHandler + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Hospital + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Insurance + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Diagnosis + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>No Overdue Tasks Found</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ReportRecipient);
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void DischargeFileSummary()
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string PatientID = "";
            string CoOrdinator = "";
            string SQLString = "";
            string sEmailBody = "";

            string AdmissionDate = "";
            string PatientName = "";
            string Hospital = "";
            string Insurance = "";
            string Diagnosis = "";
            string LatestGOP = "";
            string CaseHandler = "";
            
            string DrillReportEmailSubject = "AIMS DISCHARGE FILE SUMMARY - " + "[" + DateTime.Now.ToShortDateString() + "] - WEEKLY";
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"SELECT  (A.PATIENT_LAST_NAME + ' ' + A.PATIENT_FIRST_NAME) 'PATIENT_NAME',
                            PATIENT_FILE_NO,
                            PATIENT_DISCHARGE_DATE 'DISCHARGE_DATE' , 
                            COURIER_RECEIPT_DATE 'RECEIVED_DATE',
                            GUARANTOR_NAME ,
                            IN_PATIENT ,
                            OUT_PATIENT,
                            REPAT ,
                            ASSIST,
                            RMR  ,
                            TRANSPORT,
                            d.User_Full_Name
                            FROM AIMS_PATIENT A 
                            LEFT OUTER JOIN AIMS_SUPPLIER B ON B.SUPPLIER_ID = A.SUPPLIER_ID
                            inner join AIMS_GUARANTOR c on c.GUARANTOR_ID = A.GUARANTOR_ID
                            left outer join AIMS_USERS d on d.User_Name = A.FILE_ASSIGNED_TO_USERID
                            where (a.LAB_LIST_DATE is not null and a.LAB_LIST_DATE !='') and 
                            CONVERT (smalldatetime, a.COURIER_RECEIPT_DATE, 103) >= getdate()-900 and 
                            CONVERT (smalldatetime, a.COURIER_RECEIPT_DATE, 103) <= getdate () 
                            AND SENT_TO_ADMIN = 'Y'
                            and (FILE_ASSIGNED_TO_USERID is not null or FILE_ASSIGNED_TO_USERID !='')
                            and PATIENT_FILE_ACTIVE_YN = 'Y' and CANCELLED = 'N'";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                                "<td bgcolor=lightgrey valign=top align=center width=15%><b>Admin Handler</b></td>" +       
                                "<td bgcolor=lightgrey valign=top align=center width=10%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=25%><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Received Date</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Due Date</b></td>" +
                               "<td bgcolor=red valign=top align=center width=5%><b>Description</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=15%><b>Guarantor</b></td>" +
                                "</tr>";

                    string AdminHandler = "";
                    string DischargeDt = "";
                    string ReceivedDt = "";
                    string InPatient = "";
                    string OutPatient = "";
                    string DueDt = "";
                    string Descript = "";
                    string Guarantor = "";

                    DateTime dtReceiptDttm;
                    DateTime dtDueDate;
                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_NAME"].ToString();
                        DischargeDt = dtDrillReportData.Rows[i]["DISCHARGE_DATE"].ToString();
                        ReceivedDt = dtDrillReportData.Rows[i]["RECEIVED_DATE"].ToString();
                        InPatient = dtDrillReportData.Rows[i]["IN_PATIENT"].ToString();
                        OutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();
                        Guarantor = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        AdminHandler = dtDrillReportData.Rows[i]["User_Full_Name"].ToString();

                        if (OutPatient =="Y")
                        {
                            Descript = "O/PAX";
                        }else if(InPatient == "Y")
                        {
                            Descript = "I/PAX";
                        }

                        dtReceiptDttm = System.Convert.ToDateTime(ReceivedDt);
                        
                        DueDt = GetDueDate(dtReceiptDttm);
                        dtDueDate = System.Convert.ToDateTime(DueDt);
                        string dueColor = "#ffffff";
                        DateTime dtdueDate;
                        if (DateTime.TryParse(DueDt, out dtdueDate))
                        {
                            System.TimeSpan diffResult = System.Convert.ToDateTime(DueDt) - DateTime.Today.Date;
                            if (diffResult.Days >= 0)
                            {
                                dueColor = "#ffffff";
                            }
                            else
                            {
                                dueColor = Color.Red.ToKnownColor().ToString();
                            }
                        }

                        sEmailBody += "<tr>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + AdminHandler + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + DischargeDt + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dtReceiptDttm.ToString("dd-MMM-yyyy") + "</td>" +
                        "<td valign=top bgcolor='" + dueColor + "' style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dtDueDate.ToString("dd-MMM-yyyy") + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Descript + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Guarantor + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>No Active Discharged Files</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                string ReportRecipient = "";
                //bool blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ReportRecipient);
                //bool blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                bool blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }

            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
            }
        }

        private string GetDueDate(DateTime fileReceivedDttm)
        {
            DateTime dueDate = DateTime.Now;
            DateTime dtDueDate = DateTime.Today;
            string returnValue = "";
            try
            {
                string SQLString = "AIMS_GET_DUE_DATE";
                
                OleDbCommand cmdDrillReport = new OleDbCommand();
                OleDbParameter oleDbParam = new OleDbParameter("@FileReceivedDate", fileReceivedDttm);
                OleDbParameter oleDbParam1 = new OleDbParameter();

                oleDbParam1.Value = dtDueDate;
                oleDbParam1.Direction = ParameterDirection.InputOutput;
                oleDbParam1.DbType = DbType.Date;
                oleDbParam1.ParameterName = "@dueDateCheck";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.StoredProcedure;
                cmdDrillReport.Parameters.Add(oleDbParam);
                cmdDrillReport.Parameters.Add(oleDbParam1);
                cmdDrillReport.ExecuteNonQuery();
                if (cmdDrillReport.Parameters["@dueDateCheck"].Value != null )
                {
                    dueDate = Convert.ToDateTime(cmdDrillReport.Parameters["@dueDateCheck"].Value);
                    if (dueDate != null)
                    {
                        returnValue = dueDate.ToString("dd-MMM-yyyy");
                    }   
                }
            }
            catch (System.Exception ex)
            {
                return "";
            }
            return returnValue;
        }

        public void DailyWorkbaskedActivity()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string DrillReportEmailSubject = "Operations - Workbasket Daily Processed Work  [" + DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "]";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=2>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b>" +
                                "</td>" +
                                "</tr>";

                SQLString = "SELECT   b.User_Full_Name, count(a.WORK_ITEM_PROCESSED_DTTM) Processed_Work, " +
                                 " Min(a.WORK_ITEM_PROCESSED_DTTM) FIRST_ITEM_PROCESSED_DTTM, " +
                                " max(a.WORK_ITEM_PROCESSED_DTTM) LAST_ITEM_PROCESSED_DTTM " +
                                    " FROM aims_ews_operator_mails a, AIMS_USERS b , AIMS_EWS_OPERATOR_MAILBOX c " +
                                   " WHERE a.work_item_processed_dttm >= GETDATE() -1 " +
                                   " and c.OPERATOR_MAILBOX_ID = a.OPERATOR_MAILBOX_ID  " +
                                   " and b.User_Name = a.WORK_ITEM_PROCESSED_BY " +
                                   " group by b.User_Full_Name " +
                                " ORDER BY 2";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=25%><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=25%><b>Workbasket Processed Work</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center width=25%>" + dtDrillReportData.Rows[i]["User_Full_Name"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center width=5%>" + dtDrillReportData.Rows[i]["Processed_Work"].ToString() + "</td>" +
                        "</tr>";
                    }
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=10><b>Workbasket Items Not Found</b></td>" +
                                "</tr>";
                }

                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;operations@aims.org.za");

                string ReportRecipient = "stanley@aims.org.za;danielm@aims.org.za;operations@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages("WorkBasket Processed Cases successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages("WorkBasket Processed NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "WorkBasket Processed error: " + ex.ToString(), true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateOutPatient(string ReportRecipient)
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string Hospital = "";
            string Insurance = "";
            string Diagnosis = "";
            string LatestGOP = "";
            string CaseHandler = "";

            string DrillReportEmailSubject = "Out-Patient Cases";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"SELECT a.patient_file_no ""Case"",convert(smalldatetime,PATIENT_ADMISSION_DATE,103) Admission, " +
                        " UPPER(A.Patient_Last_Name)+ ' ' + UPPER(PATIENT_FIRST_NAME) +  ' (' + UPPER(A.PATIENT_INITIALS) + ') (' +  UPPER(ATT.Title_desc) + ')' AS Patient, " +
                        " asup.supplier_name Hospital, " +
                          "    b.guarantor_name Insurance,  " +
                        " a.patient_diagnosis Diagnosis, " +
                        @"a.patient_guarantor_amount ""Latest GOP"", " +
                        @" User_Full_Name ""Case Handler"" " +
                          "       FROM aims_patient a " +
                            "     left outer join aims_guarantor b on b.guarantor_id = a.guarantor_id " +
                              "   LEFT OUTER JOIN AIMS_TITLE  AS att ON  att.title_id  = a.title_id    " +
                                " left outer join aims_supplier as asup on asup.supplier_id = a.supplier_id          " +
                                " left outer join AIMS_USERS as aum on  aum.user_name = a.FILE_OPERATOR_TO_USERID " +
                               " WHERE cancelled = 'N' " +
                                 " AND a.patient_file_active_yn = 'Y' " +
                                 " AND (patient_discharge_date IS NULL OR patient_discharge_date = '') " +
                                 " AND (PATIENT_ADMISSION_DATE IS not NULL OR PATIENT_ADMISSION_DATE != '') " +
                                " and a.OUT_PATIENT = 'Y' and PENDING = 'N'	  " +
                            " ORDER BY convert(smalldatetime,PATIENT_ADMISSION_DATE , 103) desc,  " +
                            " CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC) desc, " +
                            " CAST (substring (a.patient_file_no, 4, 4) AS NUMERIC) desc";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Case</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Admission</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=35%><b>Patient</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=20%><b>Hospital</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=25%><b>Insurance</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Diagnosis</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Latest GOP</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Handler</b></td>" +
                                "</tr>";

                    DateTime dtCommit;
                    bool reportPageBreak = true;
                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["Case"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["Admission"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["Patient"].ToString();
                        Hospital = dtDrillReportData.Rows[i]["Hospital"].ToString();
                        if (Hospital.Trim().Equals(""))
                        {
                            Hospital = "-";
                        }
                        Insurance = dtDrillReportData.Rows[i]["Insurance"].ToString();
                        if (Insurance.Trim().Equals(""))
                        {
                            Insurance = "-";
                        }
                        Diagnosis = dtDrillReportData.Rows[i]["Diagnosis"].ToString();
                        if (Diagnosis.Trim().Equals(""))
                        {
                            Diagnosis = "-";
                        }
                        LatestGOP = dtDrillReportData.Rows[i]["Latest GOP"].ToString();
                        if (LatestGOP.Trim().Equals(""))
                        {
                            LatestGOP = "-";
                        }
                        CaseHandler = dtDrillReportData.Rows[i]["Case Handler"].ToString();
                        if (CaseHandler.Trim().Equals(""))
                        {
                            CaseHandler = "-";
                        }
                        dtCommit = Convert.ToDateTime(AdmissionDate);
                        System.TimeSpan diffResult = dtCommit.Subtract(DateTime.Now);

                        if (diffResult.Days < 0 && reportPageBreak)
                        {
                            sEmailBody += "<tr>" +
                                "<td bgcolor=YELLOW valign=bottom align=center colspan=8><span style='Font-color:red;font-family:tahoma;font-size:20px'>Active Out-Patients</span></td>" +
                                        "</tr>";
                            reportPageBreak = false;
                        }
                        sEmailBody += "<tr>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dtCommit.ToString("dd-MMM-yyyy") + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Hospital + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Insurance + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Diagnosis + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + LatestGOP + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + CaseHandler + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>No After-Hours Files Found</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "martitian@gmail.com");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (!blResult)
                {
                    blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ReportRecipient);
                }

                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateGuarantorFiles()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string DrillReportEmailSubject = "ER24 FILES (ordered-by-CoOrdinator) - Last 30 Days";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=10>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=10>&nbsp;</td>" +
                                "</tr>";

                SQLString = "select  distinct  "+
                            " b.GUARANTOR_NAME "+
                            " ,PATIENT_FILE_NO	, "+
                            " PATIENT_FIRST_NAME, "+	
                            " PATIENT_LAST_NAME,	 "+
                            " GUARANTOR_REF_NO,	 "+
                            " PATIENT_ADMISSION_DATE	, "+
                            " PATIENT_DISCHARGE_DATE	, "+
                            " PATIENT_DIAGNOSIS	, "+
                            " a.CREATION_DTTM	, "+
                            " FILE_OPERATOR_TO_USERID COORDINATOR, "+
                            " SENT_TO_ADMIN "+
                            " from aims_patient a, AIMS_GUARANTOR b  "+
                            " where CANCELLED = 'N' and PATIENT_FILE_ACTIVE_YN = 'Y' and b.GUARANTOR_ID = a.GUARANTOR_ID "+
                            " and a.GUARANTOR_ID = 350 and a.CREATION_DTTM >= GETDATE()-31 order by FILE_OPERATOR_TO_USERID desc";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=15%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient Last Name</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Guarantor Ref No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=15%><b>Diagnosis</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Creation Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Sent To Admin</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString() +"</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString() +"</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["PATIENT_LAST_NAME"].ToString() +"</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["GUARANTOR_REF_NO"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString() +"</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString() +"</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["PATIENT_DIAGNOSIS"].ToString() +"</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["CREATION_DTTM"].ToString() +"</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["COORDINATOR"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["SENT_TO_ADMIN"].ToString() +"</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=10><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=10><b>NO ACTIVE CASES FOUND</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;danielm@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;danielm@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "martitian@gmail.com");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");


                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating " + DrillReportEmailSubject, true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void CourieredSummary()
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string PatientID = "";
            string CoOrdinator = "";
            string SQLString = "";
            string sEmailBody = "";

            string AdmissionDate = "";
            string PatientName = "";
            string Hospital = "";
            string Insurance = "";
            string Diagnosis = "";
            string LatestGOP = "";
            string CaseHandler = "";

            string DrillReportEmailSubject = "AIMS COURIERED FILE SUMMARY - " + "[" + DateTime.Now.ToShortDateString() + "]";
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"SELECT  (A.PATIENT_LAST_NAME + ' ' + A.PATIENT_FIRST_NAME) 'PATIENT_NAME',
                            PATIENT_FILE_NO,
                            PATIENT_DISCHARGE_DATE 'DISCHARGE_DATE' , 
                            COURIER_RECEIPT_DATE 'RECEIVED_DATE',
                            GUARANTOR_NAME ,
                            IN_PATIENT ,
                            OUT_PATIENT,
                            REPAT ,
                            ASSIST,
                            RMR  ,
                            TRANSPORT,
                            d.User_Full_Name
                            FROM AIMS_PATIENT A 
                            LEFT OUTER JOIN AIMS_SUPPLIER B ON B.SUPPLIER_ID = A.SUPPLIER_ID
                            inner join AIMS_GUARANTOR c on c.GUARANTOR_ID = A.GUARANTOR_ID
                            left outer join AIMS_USERS d on d.User_Name = A.FILE_ASSIGNED_TO_USERID
                            where (a.LAB_LIST_DATE is not null and a.LAB_LIST_DATE !='') and 
                            CONVERT (smalldatetime, a.COURIER_RECEIPT_DATE, 103) >= getdate()-900 and 
                            CONVERT (smalldatetime, a.COURIER_RECEIPT_DATE, 103) <= getdate () 
                            AND SENT_TO_ADMIN = 'Y'
                            and (FILE_ASSIGNED_TO_USERID is not null or FILE_ASSIGNED_TO_USERID !='')
                            and PATIENT_FILE_ACTIVE_YN = 'Y' and CANCELLED = 'N'";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                                "<td bgcolor=lightgrey valign=top align=center width=15%><b>Admin Handler</b></td>" +
                                "<td bgcolor=lightgrey valign=top align=center width=10%><b>Patient File No</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=25%><b>Patient Name</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Received Date</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Received Date</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=10%><b>Due Date</b></td>" +
                               "<td bgcolor=red valign=top align=center width=5%><b>Description</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=15%><b>Guarantor</b></td>" +
                                "</tr>";

                    string AdminHandler = "";
                    string DischargeDt = "";
                    string ReceivedDt = "";
                    string InPatient = "";
                    string OutPatient = "";
                    string DueDt = "";
                    string Descript = "";
                    string Guarantor = "";
                    string CourierDt = "";

                    DateTime dtReceiptDttm;
                    DateTime dtDueDate;
                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_NAME"].ToString();
                        DischargeDt = dtDrillReportData.Rows[i]["DISCHARGE_DATE"].ToString();
                        ReceivedDt = dtDrillReportData.Rows[i]["RECEIVED_DATE"].ToString();
                        InPatient = dtDrillReportData.Rows[i]["IN_PATIENT"].ToString();
                        OutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();
                        Guarantor = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        AdminHandler = dtDrillReportData.Rows[i]["User_Full_Name"].ToString();
                        CourierDt = dtDrillReportData.Rows[i]["User_Full_Name"].ToString();

                        if (OutPatient == "Y")
                        {
                            Descript = "O/PAX";
                        }
                        else if (InPatient == "Y")
                        {
                            Descript = "I/PAX";
                        }

                        dtReceiptDttm = System.Convert.ToDateTime(ReceivedDt);

                        DueDt = GetDueDate(dtReceiptDttm);
                        dtDueDate = System.Convert.ToDateTime(DueDt);
                        string dueColor = "#ffffff";
                        DateTime dtdueDate;
                        if (DateTime.TryParse(DueDt, out dtdueDate))
                        {
                            System.TimeSpan diffResult = System.Convert.ToDateTime(DueDt) - DateTime.Today.Date;
                            if (diffResult.Days >= 0)
                            {
                                dueColor = "#ffffff";
                            }
                            else
                            {
                                dueColor = Color.Red.ToKnownColor().ToString();
                            }
                        }

                        sEmailBody += "<tr>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + AdminHandler + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + DischargeDt + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dtReceiptDttm.ToString("dd-MMM-yyyy") + "</td>" +
                        "<td valign=top bgcolor='" + dueColor + "' style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dtDueDate.ToString("dd-MMM-yyyy") + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Descript + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Guarantor + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>No Active Discharged Files</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                string ReportRecipient = "";
                //bool blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ReportRecipient);
                //string ReportRecipient = "stanley@aims.org.za;danielm@aims.org.za";
                //bool blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                bool blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }

            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
            }
        }

        public void GenerateNotSentToAdminAfter48HrsDischarge()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string DrillReportEmailSubject = "OPS Files Discharged after 48 Hours And Not Sent-To-Admin";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=10>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=10>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT   a.file_operator_to_userid, a.patient_file_no ,b.guarantor_name, patient_discharge_date, "+
                                         " patient_admission_date, out_patient, in_patient, a.creation_dttm "+
                                    " FROM aims_patient a, aims_guarantor b "+
                                   " WHERE (patient_discharge_date IS NOT NULL OR patient_discharge_date != '' "+
                                        "  ) "+
                                     " AND CONVERT (datetime, patient_discharge_date, 103) <= getdate () - 2 "+
                                     " AND sent_to_admin = 'N' "+
                                     " AND cancelled = 'N' "+
                                     " AND b.guarantor_id = a.guarantor_id "+
                                     " AND a.creation_dttm >= '31 december 2017' "+
                                " ORDER BY 1, 2, 3, 4 DESC"; 

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=15%><b>Co-Ordinator</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>File No</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Admission Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=5%><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=15%><b>Out/In Patient</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>File-Creation-Date</b></td>" +
                                "</tr>";

                    string OutInPatient = "";
                    string InPatient = "";
                    string OutPatient = "";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        OutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();
                        InPatient = dtDrillReportData.Rows[i]["IN_PATIENT"].ToString();

                        if (OutPatient.Equals("Y"))
                        {
                            OutInPatient = "<b>OUT-Patient</b>";
                        }

                        if (InPatient.Equals("Y"))
                        {
                            OutInPatient = "<b>In-Patient</b>";
                        }

                        sEmailBody += "<tr>" +
                            "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["file_operator_to_userid"].ToString() + "</td>" +
                            "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString() + "</td>" +
                            "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString() + "</td>" +
                            "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["PATIENT_ADMISSION_DATE"].ToString() + "</td>" +
                            "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString() + "</td>" +
                            "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + OutInPatient + "</td>" +
                            "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=center>" + dtDrillReportData.Rows[i]["CREATION_DTTM"].ToString() + "</td>" +
                            "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=10><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=10><b>NO ACTIVE CASES FOUND</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";
                string ReportRecipient = "danielm@aims.org.za;stanley@aims.org.za";
                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "danielm@aims.org.za;Matthewb@aims.org.za");
                 //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating " + DrillReportEmailSubject, true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void OpsGuarantorCancelledSentToAdminFiles()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string KPIMonth = DateTime.Now.ToString("MMMM");
            KPIMonth = "September";
            int lastDay = DateTime.Now.Day;
            //lastDay = 30;

            string DrillReportEmailSubject = "Operations - Guarantors - [SENT-TO-ADMIN and CANCELLED] Files - " + KPIMonth;
            
            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=10>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>";

                SQLString = " 	SELECT   SUM (x.cancelled) AS cancelled,	 " +
                                " 	SUM (x.sent_to_admin) AS sent_to_admin, x.guarantor_name,	 " +
                                " 	x.file_type	 " +
                                " 	FROM (SELECT   '' sent_to_admin, COUNT (cancelled) cancelled,	 " +
                                " 	c.guarantor_name, 'FLIGHT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
                                " 	CONVERT (datetime, '01 " + KPIMonth + " " + DateTime.Now.Year + " 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '" + lastDay + " " + KPIMonth + " " + DateTime.Now.Year + " 23:59:59', 103)	 " +
                                " 	AND (a.cancelled = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.flight = 'Y'	 " +
                                " 	GROUP BY cancelled, guarantor_name, flight	 " +
                                " 	UNION	 " +
                                " 	SELECT   COUNT (a.sent_to_admin) sent_to_admin, '' cancelled,	 " +
                                " 	c.guarantor_name, 'FLIGHT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth + " "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.sent_to_admin = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.flight = 'Y'	 " +
                                " 	GROUP BY sent_to_admin, guarantor_name) x	 " +
                                " 	GROUP BY guarantor_name, file_type	 " +
                                " 	UNION	 " +
                                " 	SELECT   SUM (x.cancelled) AS cancelled,	 " +
                                " 	SUM (x.sent_to_admin) AS sent_to_admin, x.guarantor_name,	 " +
                                " 	x.file_type	 " +
                                " 	FROM (SELECT   '' sent_to_admin, COUNT (cancelled) cancelled,	 " +
                                " 	c.guarantor_name, 'IN_PATIENT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN 	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.cancelled = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.in_patient = 'Y'	 " +
                                " 	GROUP BY cancelled, guarantor_name, flight	 " +
                                " 	UNION	 " +
                                " 	SELECT   COUNT (a.sent_to_admin) sent_to_admin, '' cancelled,	 " +
                                " 	c.guarantor_name, 'IN_PATIENT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.sent_to_admin = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.in_patient = 'Y'	 " +
                                " 	GROUP BY sent_to_admin, guarantor_name) x	 " +
                                " 	GROUP BY guarantor_name, file_type	 " +
                                " 	UNION	 " +
                                " 	SELECT   SUM (x.cancelled) AS cancelled,	 " +
                                " 	SUM (x.sent_to_admin) AS sent_to_admin, x.guarantor_name,	 " +
                                " 	x.file_type	 " +
                                " 	FROM (SELECT   '' sent_to_admin, COUNT (cancelled) cancelled,	 " +
                                " 	c.guarantor_name, 'OUT_PATIENT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN 	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.cancelled = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.OUT_PATIENT = 'Y'	 " +
                                " 	GROUP BY cancelled, guarantor_name, flight	 " +
                                " 	UNION	 " +
                                " 	SELECT   COUNT (a.sent_to_admin) sent_to_admin, '' cancelled,	 " +
                                " 	c.guarantor_name, 'OUT_PATIENT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.sent_to_admin = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.OUT_PATIENT = 'Y'	 " +
                                " 	GROUP BY sent_to_admin, guarantor_name) x	 " +
                                " 	GROUP BY guarantor_name, file_type	 " +
                                " 	UNION	 " +
                                " 	SELECT   SUM (x.cancelled) AS cancelled,	 " +
                                " 	SUM (x.sent_to_admin) AS sent_to_admin, x.guarantor_name,	 " +
                                " 	x.file_type	 " +
                                " 	FROM (SELECT   '' sent_to_admin, COUNT (cancelled) cancelled,	 " +
                                " 	c.guarantor_name, 'REPAT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN 	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.cancelled = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.REPAT = 'Y'	 " +
                                " 	GROUP BY cancelled, guarantor_name, flight	 " +
                                " 	UNION	 " +
                                " 	SELECT   COUNT (a.sent_to_admin) sent_to_admin, '' cancelled,	 " +
                                " 	c.guarantor_name, 'REPAT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.sent_to_admin = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.REPAT = 'Y'	 " +
                                " 	GROUP BY sent_to_admin, guarantor_name) x	 " +
                                " 	GROUP BY guarantor_name, file_type	 " +
                                " 	UNION	 " +
                                " 	SELECT   SUM (x.cancelled) AS cancelled,	 " +
                                " 	SUM (x.sent_to_admin) AS sent_to_admin, x.guarantor_name,	 " +
                                " 	x.file_type	 " +
                                " 	FROM (SELECT   '' sent_to_admin, COUNT (cancelled) cancelled,	 " +
                                " 	c.guarantor_name, 'RMR' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN 	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.cancelled = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.RMR  = 'Y'	 " +
                                " 	GROUP BY cancelled, guarantor_name, flight	 " +
                                " 	UNION	 " +
                                " 	SELECT   COUNT (a.sent_to_admin) sent_to_admin, '' cancelled,	 " +
                                " 	c.guarantor_name, 'RMR' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.sent_to_admin = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.RMR  = 'Y'	 " +
                                " 	GROUP BY sent_to_admin, guarantor_name) x	 " +
                                " 	GROUP BY guarantor_name, file_type	 " +
                                " 	UNION	 " +
                                " 	SELECT   SUM (x.cancelled) AS cancelled,	 " +
                                " 	SUM (x.sent_to_admin) AS sent_to_admin, x.guarantor_name,	 " +
                                " 	x.file_type	 " +
                                " 	FROM (SELECT   '' sent_to_admin, COUNT (cancelled) cancelled,	 " +
                                " 	c.guarantor_name, 'TRANSPORT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN 	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.cancelled = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.TRANSPORT  = 'Y'	 " +
                                " 	GROUP BY cancelled, guarantor_name, flight	 " +
                                " 	UNION	 " +
                                " 	SELECT   COUNT (a.sent_to_admin) sent_to_admin, '' cancelled,	 " +
                                " 	c.guarantor_name, 'TRANSPORT' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.sent_to_admin = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.TRANSPORT  = 'Y'	 " +
                                " 	GROUP BY sent_to_admin, guarantor_name) x	 " +
                                " 	GROUP BY guarantor_name, file_type	 " +
                                " 	UNION	 " +
                                " 	SELECT   SUM (x.cancelled) AS cancelled,	 " +
                                " 	SUM (x.sent_to_admin) AS sent_to_admin, x.guarantor_name,	 " +
                                " 	x.file_type	 " +
                                " 	FROM (SELECT   '' sent_to_admin, COUNT (cancelled) cancelled,	 " +
                                " 	c.guarantor_name, 'ASSIST' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN 	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.cancelled = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.ASSIST   = 'Y'	 " +
                                " 	GROUP BY cancelled, guarantor_name, flight	 " +
                                " 	UNION	 " +
                                " 	SELECT   COUNT (a.sent_to_admin) sent_to_admin, '' cancelled,	 " +
                                " 	c.guarantor_name, 'ASSIST' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.sent_to_admin = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND c.guarantor_id = a.guarantor_id	 " +
                                " 	AND a.ASSIST  = 'Y'	 " +
                                " 	GROUP BY sent_to_admin, guarantor_name) x	 " +
                                " 	GROUP BY guarantor_name, file_type	 " +
                                " 	union	 " +
                                " 	SELECT   SUM (x.cancelled) AS cancelled,	 " +
                                " 	SUM (x.sent_to_admin) AS sent_to_admin, x.guarantor_name,	 " +
                                " 	x.file_type	 " +
                                " 	FROM (SELECT   '' sent_to_admin, COUNT (cancelled) cancelled,	 " +
                                " 	c.guarantor_name, 'FLIGHT GUARANTOR' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN 	 " +
                                " 	CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)	 " +
                                " 	AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)	 " +
                                " 	AND (a.cancelled = 'Y')	 " +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " 	AND a.FLIGHT   = 'Y'	 " +
                                " 	AND c.guarantor_id = a.FLIGHT_GUARANTOR_ID	 " +
                                " 	GROUP BY cancelled, guarantor_name, flight	 " +
                                " 	UNION	 " +
                                " 	SELECT   COUNT (a.sent_to_admin) sent_to_admin, '' cancelled,	 " +
                                " 	c.guarantor_name, 'FLIGHT GUARANTOR' file_type	 " +
                                " 	FROM aims_patient a, aims_guarantor c	 " +
                                " 	WHERE a.creation_dttm BETWEEN	 " +
 	                                " CONVERT (datetime, '01 "+ KPIMonth +" "+ DateTime.Now.Year +" 00:00:00', 103)" +
                                " AND CONVERT (datetime, '"+ lastDay +" "+ KPIMonth +" "+ DateTime.Now.Year +" 23:59:59', 103)" +
                                " AND (a.sent_to_admin = 'Y')" +
                                "   and a.guarantor_id in (";
 SQLString = SQLString + @"SELECT guarantor_id
  FROM aims_guarantor
 WHERE guarantor_name IN
          ('ALLIANZ GLOBAL ASSIST - CHINA',
           'ALLIANZ GLOBAL ASSIST - NETHERLANDS(MONDIAL)',
           'ALLIANZ GLOBAL ASSIST- AUSTRIA',
           'ALLIANZ GLOBAL ASSIST- CANADA (MONDIAL )',
           'ALLIANZ GLOBAL ASSIST- ESPANA (MONDIAL) -INS ""E""',
           'ALLIANZ GLOBAL ASSIST- UK (MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE (MONDIAL USA)',
           'ALLIANZ GLOBAL ASSISTANCE - PORTUGAL',
           'Allianz Global Assistance - Turkey',
           'ALLIANZ GLOBAL ASSISTANCE- AUSTRALIA(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-GERMANY(MONDIAL)',
           'ALLIANZ GLOBAL ASSISTANCE-SWITZERLAND',
           'Allianz Global Corporate & Specialty SE Singapore ',
           'ALLIANZ GLOBAL ITALY',
           'ALLIANZ HAUTEVILLE',
           'ALLIANZ PWC (ZAMBIA)',
           'ALLIANZ VALE (MOZAMBIQUE)',
           'AGA INTERNACIONAL SA SUCURSAL EM - PORTUGAL',
           'AGA INTERNATIONAL SA BELGIAN BRANCH(SIG CODE 9987)',
           'AGA INTERNATIONAL SA RAPPR. GENERALE PER L''ITALIA ',
           'AGA SERVICE ITALIA SCARL (X11../W21..)',
           'AGA SERVICES INDIA',
           'AGA SERVICES THAILAND',
           'AWP FRANCE',
           'AWP P&C S.A.',
           'AWP RUS LLC(USE TO BE MONDIAL ASSISTANCE RUSSIA SA',
           'Mondial Assist Italy',
           'MONDIAL ASSISTANCE BRAZIL',
           'MONDIAL ASSISTANCE CHINA',
           'MONDIAL ASSISTANCE CZECH REPUBLIC(AWP SOLUTIONS)',
           'MONDIAL ASSISTANCE DEUTSCHLAND',
           'MONDIAL ASSISTANCE ESPANA( INS ""S"")',
           'MONDIAL ASSISTANCE EUROPE',
           'MONDIAL ASSISTANCE FRANCE',
           'MONDIAL ASSISTANCE POLAND(NOW AWP POLSKA SP.Z.O.O',
           'MONDIAL ASSISTANCE PORTUGAL',
           'MONDIAL ASSISTANCE SPAIN',
           'MONDIAL ASSISTANCE THAILAND',
           'MONDIAL AUSTRIA',
           'MONDIAL SERVICE BELGIUM NV (SIG CODE 9947)',
           'SOS INTERNATIONAL',
           'SOS INTERNATIONAL( AMSTERDAM)',
           'MSH - BOLLORE',
           'MSH CHINA',
           'MSH INTERNATIONAL ( ICVL)',
           'MSH INTERNATIONAL ( WEBCOR )',
           'MSH INTERNATIONAL (DUBAI)',
           'MSH INTERNATIONAL (VALE)',
           'MSH INTERNATIONAL CANADA-(CALGARY)',
           'MSH INTERNATIONAL PARIS',
           'MSH INTERNATIONAL(CHC HELICOPTERS) NIGERIA',
           'ALLIANZ PARTNERS(USE TO BE ALLIANZ WORLDWIDE CARE)',
           'ALLIANZ WORLDWIDE PARTNERS INDIA',
           'CHP ASSIST(CROSSBORDER HEALTH PARTNERS)',
           'ANWB',
           'EUROCROSS ASSISTANCE BULGARIA',
           'EUROCROSS ASSISTANCE CZECH REPUBLIC',
           'EUROCROSS INTERNATIONAL NETHERLANDS',
           'MAPFRE -COLOMBIA (ANDIASISTENCIA)',
           'MAPFRE ASISTENCIA URUGUAY',
           'MAPFRE ASSISTANCE (AUSTRALIA)',
           'MAPFRE ASSISTANCE (FRANCE)',
           'MAPFRE ASSISTANCE (IRELAND)',
           'MAPFRE ASSISTANCE (MADRID) IGNORE',
           'MAPFRE ASSISTANCE (PORTUGAL)',
           'MAPFRE ASSISTANCE (SPAIN)',
           'MAPFRE BRAZIL',
           'MAPFRE PHILIPPINES',
           'MAPFRE UK',
           'TMA (DIRECT LINE GROUP)',
           'NatWest',
           'AXA  JAPAN (ALL GOPS MUST COME VIA AXA PARIS)',
           'AXA ASSISTANCE  GULF',
           'AXA ASSISTANCE ARGENTINA( DO NOT ACCEPT GOP)',
           'AXA ASSISTANCE BARCELONA (SPAIN)',
           'AXA ASSISTANCE BRAZIL',
           'AXA ASSISTANCE CANADA(NOT TO USE AIMS IN WEST AFRI',
           'AXA ASSISTANCE CHICAGO',
           'AXA ASSISTANCE CHINA(ALL GOPS MUST COME VIA PARIS',
           'AXA Assistance Colombia & Región Andina',
           'AXA ASSISTANCE CZECH',
           'AXA ASSISTANCE FRANCE',
           'AXA ASSISTANCE FRANCE ASSURANCES',
           'AXA ASSISTANCE GERMANY',
           'AXA ASSISTANCE GREECE',
           'AXA ASSISTANCE MAURITIUS',
           'AXA ASSISTANCE MEXICO',
           'AXA ASSISTANCE UK',
           'AXA ASSISTANCE USA( COLONIAL)',
           'AXA ASSISTANCE USA(MIAMI FLORIDA)',
           'AXA EGYPT ( PARTNER OF AXA PPP )',
           'AXA GLOBAL PROTECT',
           'AXA Insurance Gulf B.S.C(DUBAI)',
           'AXA INSURANCE GULF(MSO is their partner and not AI',
           'AXA Kranken( AXA PPP INTERNATIONAL)',
           'AXA MANSARD',
           'AXA MOROCCO',
           'AXA MOROCCO ( CARE OF AXA ASSISTANCE PARIS)',
           'AXA PPP INTERNATIONAL',
           'AXA PPP MOROCCO',
           'AXA PPP MOROCO',
           'AXA TRAVEL INSURANCE',
           'INTER PARTNER ASSISTANCE AUSTRIA',
           'INTER PARTNER ASSISTANCE BRAZIL',
           'INTER PARTNER ASSISTANCE BRUXELLES (BELGIUM)',
           'INTER PARTNER ASSISTANCE ESPANA',
           'INTER PARTNER ASSISTANCE GENEVA',
           'INTER PARTNER ASSISTANCE GERMANY',
           'INTER PARTNER ASSISTANCE POLAND',
           'INTER PARTNER ASSISTANCE PORTUGAL',
           'INTER PARTNER ASSISTANCE ROME',
           'INTERAMERICAN ASSISTANCE GREECE',
           'The Exeter(Cases are managed through AXA PPP)',
           'Optimum Global( AXA PPP INTERNATIONAL)',
           'ROLAND ASSISTANCE GmbH',
           'Aetna International( Used to be Interglobal)',
           'AETNA GLOBAL BENEFITS(MIDDLE EAST)LLC',
           'INTERGLOBAL',
           'INTERGLOBAL ( WBHO ) INSURED MEMBERS',
           'WILSON BAYLY HOLMES (WBHO)UN INSURED MEMBERS',
           'WILSON BAYLY HOMES (WBHO) INTERGLOBAL INSURED'))" +
                                " AND a.FLIGHT   = 'Y'" +
                                " AND c.guarantor_id = a.FLIGHT_GUARANTOR_ID" +
                                " GROUP BY sent_to_admin, guarantor_name) x" +
                                " GROUP BY guarantor_name, file_type order by 4,3";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>CANCELLED</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>SENT-TO-ADMIN</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=70%><b>GUARANTOR</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>FILE-TYPE</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=center width=10%>" + dtDrillReportData.Rows[i]["cancelled"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=center width=10%>" + dtDrillReportData.Rows[i]["sent_to_admin"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=left width=60%>" + dtDrillReportData.Rows[i]["guarantor_name"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=left width=20%>" + dtDrillReportData.Rows[i]["file_type"].ToString() + "</td>" +
                        "</tr>";
                    }
                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=10><b>No Active Files Found</b></td>" +
                                "</tr>";
                }

                sEmailBody += "<tr>" +
                           "<td bgcolor=#B0C4DE valign=bottom align=center colspan=4></td>" +
                            "</tr>";
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "stanley@aims.org.za;danielm@aims.org.za");
                string ReportRecipient = "stanley@aims.org.za;danielm@aims.org.za";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "martitian@gmail.com");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages("OPS Cancelled and Sent-To-Admin Files Cases Sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages("OPS Cancelled and Sent-To-Admin Files NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "OPS Cancelled and Sent-To-Admin Files error: " + ex.ToString(), true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void GenerateMonthlyOpsKPI()
        {
            LogMessages("Started Processing OPS Monthly KPI", "OPS Monthly KPI", true);
            string KPIMonth = DateTime.Now.ToString("MMMM");
            ////KPIMonth = "November";
             
            rptYear = DateTime.Now.Year.ToString();
            string DrillReportEmailSubject = "AIMS OPERATIONS KPI - " + "[ "+ rptYear  + " - " + KPIMonth + " -]";
            try
            {
                DataTable dtCasesAllocated = dtOpsKPIEmailAllocated(KPIMonth);
                DataTable dtCasesCreated = dtOpsKPICreatedCases(KPIMonth);
                DataTable dtCasesWorkbaskedProcessed = dtOpsKPIWorkBasketEmailsProcessed(KPIMonth);
                DataTable dtCasesTasksCreated = dtOpsKPITasksCreated(KPIMonth);
                DataTable dtCasesTasksCompleted = dtOpsKPITasksCompleted(KPIMonth);
                DataTable dtCasesFilesAllocated = dtOpsKPIFilesAllocated(KPIMonth);
                DataTable dtCasesCancelledFiles = dtOpsKPICancelledFiles(KPIMonth);
                DataTable dtCasesSentToAdmin = dtOpsKPISentToAdminFiles(KPIMonth);
                DataTable dtCasesSentEmail = dtOpsKPISentEmails(KPIMonth);
                
                string DailyListFile = "";
               
                //DailyListFile = @"c:\AIMS Recorder\AIMS - Operations - KPI - [" + KPIMonth + "].xlsx";
                DailyListFile = @"c:\AIMS Recorder\AIMS - Operations - KPI - [ " + KPIMonth + " ].xlsx";
                FileInfo existingFile = new FileInfo(DailyListFile);
                if (existingFile.Exists)
                    existingFile.Delete();

                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    OfficeOpenXml.ExcelWorksheet wsAllocatedEmails = package.Workbook.Worksheets.Add("Emails-Allocated");
                    wsAllocatedEmails.Cells[1, 1].LoadFromDataTable(dtCasesAllocated, true);

                    OfficeOpenXml.ExcelWorksheet wsCasesOpened = package.Workbook.Worksheets.Add("Cases-Opened-Created");
                    wsCasesOpened.Cells[1, 1].LoadFromDataTable(dtCasesCreated, true);

                    OfficeOpenXml.ExcelWorksheet wsWorkbaskerEmailsProcessed = package.Workbook.Worksheets.Add("Workbasket-Emails-Processed");
                    wsWorkbaskerEmailsProcessed.Cells[1, 1].LoadFromDataTable(dtCasesWorkbaskedProcessed, true);

                    OfficeOpenXml.ExcelWorksheet wsTaskCreated = package.Workbook.Worksheets.Add("Tasks-Created");
                    wsTaskCreated.Cells[1, 1].LoadFromDataTable(dtCasesTasksCreated, true);

                    OfficeOpenXml.ExcelWorksheet wsTaskCompleted = package.Workbook.Worksheets.Add("Tasks-Completed");
                    wsTaskCompleted.Cells[1, 1].LoadFromDataTable(dtCasesTasksCompleted, true);

                    OfficeOpenXml.ExcelWorksheet wsFilesAllocated = package.Workbook.Worksheets.Add("Files-Allocated");
                    wsFilesAllocated.Cells[1, 1].LoadFromDataTable(dtCasesFilesAllocated, true);

                    OfficeOpenXml.ExcelWorksheet wsCasesCancelled = package.Workbook.Worksheets.Add("No-Of-Cases-Cancelled");
                    wsCasesCancelled.Cells[1, 1].LoadFromDataTable(dtCasesCancelledFiles, true);

                    OfficeOpenXml.ExcelWorksheet wsCasesSentToAdmin = package.Workbook.Worksheets.Add("No-Of-Cases-Sent-To-Admin");
                    wsCasesSentToAdmin.Cells[1, 1].LoadFromDataTable(dtCasesSentToAdmin, true);

                    OfficeOpenXml.ExcelWorksheet wsCasesSentEmails = package.Workbook.Worksheets.Add("No-Of-Sent-Emails");
                    wsCasesSentEmails.Cells[1, 1].LoadFromDataTable(dtCasesSentEmail, true);
                    
                    package.Save();

                    wsAllocatedEmails.Dispose();
                    dtCasesCreated.Dispose();                    
                }
           

                AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();
                bool blResult = false;
                string sEmailBody = "";
                
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>";

                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                string ReportRecipient = "danielm@aims.org.za;stanley@aims.org.za;";
                //string ReportRecipient = "martitian@gmail.com";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, DailyListFile, "", "martitian@gmail.com");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, DailyListFile, false, "", "martitian@gmail.com");

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "danielm@aims.org.za;stanley@aims.org.za;lerato@aims.org.za", DailyListFile);
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, "danielm@aims.org.za;stanley@aims.org.za;lerato@aims.org.za", "", "", "");
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, "martitian@gmail.com", DailyListFile, "", "");
                //blResult = true;

                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                    LogMessages(DrillReportEmailSubject + " Email Report Body: " + sEmailBody, "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                LogMessages(ex.ToString(), DrillReportEmailSubject + " Report could not be generated.", true);
            }
            finally
            {
            }
        }

        public void GenerateMonthlyAdminKPI()
        {
            LogMessages("Started Processing ADMIN Monthly KPI", "ADMIN Monthly KPI", true);
            //string KPIMonth = KPIMonth;
            rptYear = DateTime.Now.Year.ToString();
            string KPIMonth = DateTime.Now.ToString("MMMM");
            //string KPIMonth = "November";
            //KPIMonth = "March";
            //rptYear = "2019";

            string DrillReportEmailSubject = "AIMS ADMIN KPI - " + "[- " + KPIMonth + " -]";
            try
            {
                DataTable dtCasesAllocated = dtAdminKPIEmailAllocated(KPIMonth);

                DataTable dtCasesWorkbaskedProcessed = dtAdminKPIWorkBasketEmailsProcessed(KPIMonth);

                DataTable dtCasesTasksCreated = dtAdminKPITasksCreated(KPIMonth);
                DataTable dtCasesTasksCompleted = dtAdminKPITasksCompleted(KPIMonth);

                DataTable dtCasesFilesAllocated = dtAdminKPIFilesAllocated(KPIMonth);

                DataTable dtCasesClosedAfterDueDateFiles = dtAdminKPIClosedAfterDueDateFiles(KPIMonth);
                DataTable dtCasesClosedBeforeDueDateFiles = dtAdminKPIClosedBeforeDueDateFiles(KPIMonth);

                DataTable dtCouriered2DaysBeforeClosure = dtAdminKPICourieried2DaysBeforeClosure(KPIMonth);

                DataTable dtCouriered2DaysAfterClosure = dtAdminKPICourieried2DaysAfterClosure(KPIMonth);

                string DailyListFile = "";

                DailyListFile = @"c:\AIMS Recorder\AIMS - ADMIN - KPI - [" + KPIMonth + "].xlsx";

                FileInfo existingFile = new FileInfo(DailyListFile);
                if (existingFile.Exists)
                    existingFile.Delete();

                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    OfficeOpenXml.ExcelWorksheet wsFilesAllocated = package.Workbook.Worksheets.Add("Files-Allocated");
                    wsFilesAllocated.Cells[1, 1].LoadFromDataTable(dtCasesFilesAllocated, true);

                    OfficeOpenXml.ExcelWorksheet wsCasesClosedBeforeDueDateFiles = package.Workbook.Worksheets.Add("Cases-Closed-Before-Due-Date");
                    wsCasesClosedBeforeDueDateFiles.Cells[1, 1].LoadFromDataTable(dtCasesClosedBeforeDueDateFiles, true);

                    OfficeOpenXml.ExcelWorksheet wsCasesClosedAfterDueDateFiles = package.Workbook.Worksheets.Add("Cases-Closed-After-Due-Date");
                    wsCasesClosedAfterDueDateFiles.Cells[1, 1].LoadFromDataTable(dtCasesClosedAfterDueDateFiles, true);


                    OfficeOpenXml.ExcelWorksheet wsTaskCreated = package.Workbook.Worksheets.Add("Tasks-Created");
                    wsTaskCreated.Cells[1, 1].LoadFromDataTable(dtCasesTasksCreated, true);

                    OfficeOpenXml.ExcelWorksheet wsTaskCompleted = package.Workbook.Worksheets.Add("Tasks-Completed");
                    wsTaskCompleted.Cells[1, 1].LoadFromDataTable(dtCasesTasksCompleted, true);

                    OfficeOpenXml.ExcelWorksheet wsWorkbaskerEmailsProcessed = package.Workbook.Worksheets.Add("Workbasket-Emails-Processed");
                    wsWorkbaskerEmailsProcessed.Cells[1, 1].LoadFromDataTable(dtCasesWorkbaskedProcessed, true);

                    OfficeOpenXml.ExcelWorksheet wsAllocatedEmails = package.Workbook.Worksheets.Add("Emails-Allocated");
                    wsAllocatedEmails.Cells[1, 1].LoadFromDataTable(dtCasesAllocated, true);

                    OfficeOpenXml.ExcelWorksheet wsCasesCourieried2DaysBeforeClosure = package.Workbook.Worksheets.Add("Courieried 2Days Before Closure");
                    wsCasesCourieried2DaysBeforeClosure.Cells[1, 1].LoadFromDataTable(dtCouriered2DaysBeforeClosure, true);

                    OfficeOpenXml.ExcelWorksheet wsCasesCourieried2DaysAfterClosure = package.Workbook.Worksheets.Add("Courieried 2Days After Closure");
                    wsCasesCourieried2DaysAfterClosure.Cells[1, 1].LoadFromDataTable(dtCouriered2DaysAfterClosure, true);

                    package.Save();

                    wsAllocatedEmails.Dispose();
                }

                AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();
                bool blResult = false;
                string sEmailBody = "";

                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=7>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                                "</tr>";

                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "danielm@aims.org.za;", DailyListFile);
                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "danielm@aims.org.za;", DailyListFile);
                 
                string ReportRecipient = "danielm@aims.org.za;";
                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, DailyListFile, "", "martitian@gmail.com");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, DailyListFile, false, "", "martitian@gmail.com");

                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                    LogMessages(DrillReportEmailSubject + " Email Report Body: " + sEmailBody, "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                LogMessages(ex.ToString(), DrillReportEmailSubject + " Report could not be generated.", true);
            }
            finally
            {
            }
        }

        private DataTable dtOpsKPICreatedCases(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string reportmonth = rptMonth;
            
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            string SQLString = "";
            try
            {
                SQLString = @"select 
                        count(b.MODIFIED_USER) count, b.MODIFIED_USER COORDINATOR 
                         from aims_patient a, AIMS_A_PATIENT b where 
                        a.CREATION_DTTM  between ";
                            SQLString =  SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                            SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) ";
                            SQLString = SQLString + @" and  b.PATIENT_ID = a.PATIENT_ID and MODIFIED_ACTION = 'ADD' ";
                        SQLString = SQLString + @" group by b.MODIFIED_USER order by 1 desc";

                        LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();
                
            }
            return dtDrillReportData;
        }

        private DataTable dtOpsKPIEmailAllocated(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(EMAIL_INDEXED_BY) count, EMAIL_INDEXED_BY COORDINATOR  from AIMS_EWS_EMAILS where PROCESSED_DTTM between ";
                            SQLString =  SQLString + @" convert(datetime,'01 "+ reportmonth + " " + rptYear + " 00:00:00',103) and ";
                            SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) ";
                            SQLString = SQLString + @" and EMAIL_INDEXED_BY in ( ";
                            SQLString = SQLString + @" select OPERATOR_MAILBOX_USER_NAME from AIMS_EWS_OPERATOR_MAILBOX) ";
                        SQLString =  SQLString + @" group by EMAIL_INDEXED_BY order by 1 desc";

                        LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, true );
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();
                
            }
            return dtDrillReportData;
        }

        private DataTable dtOpsKPIWorkBasketEmailsProcessed(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(WORK_ITEM_PROCESSED_BY) count, WORK_ITEM_PROCESSED_BY COORDINATOR from AIMS_EWS_OPERATOR_MAILS 
                    where WORK_ITEM_PROCESSED_DTTM between ";
                            SQLString =  SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                            SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) ";
                            SQLString = SQLString + @" group by WORK_ITEM_PROCESSED_BY order by 1 desc";

                            LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();
                
            }
            return dtDrillReportData;
        }

        private DataTable dtOpsKPITasksCreated(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(loaded_by) count, LOADED_BY COORDINATOR from AIMS_PATIENT_FILE_TASKS 
                    where CREATION_DATE between ";
                            SQLString =  SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                            SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) ";
                            SQLString = SQLString + @" and LOADED_BY in (  ";
                            SQLString = SQLString + @" select OPERATOR_MAILBOX_USER_NAME from AIMS_EWS_OPERATOR_MAILBOX) ";
                    SQLString = SQLString + @" group by LOADED_BY order by 1 desc";

                    LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();
                
            }
            return dtDrillReportData;
        }

        private DataTable dtOpsKPITasksCompleted(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select  COUNT(USER_ID) count, USER_ID COORDINATOR from AIMS_PATIENT_FILE_TASKS 
                    where CREATION_DATE between ";
                            SQLString =  SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                            SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) ";
                SQLString = SQLString + @" and USER_ID in ( ";
                    SQLString = SQLString + @" select OPERATOR_MAILBOX_USER_NAME from AIMS_EWS_OPERATOR_MAILBOX) ";
                    SQLString = SQLString + @" and TASK_STATUS_ID = 3 ";
                    SQLString = SQLString + @" group by USER_ID order by 1 desc";

                    LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();
                
            }
            return dtDrillReportData;
        }

        private DataTable dtOpsKPIFilesAllocated(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(FILE_OPERATOR_TO_USERID) count, FILE_OPERATOR_TO_USERID COORDINATOR  from AIMS_PATIENT where CREATION_DTTM 
                    between ";
                            SQLString =  SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                            SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) and ";
                            SQLString = SQLString + @" FILE_OPERATOR_TO_USERID is not null ";
                    SQLString = SQLString + @" group by FILE_OPERATOR_TO_USERID order by 1 desc";

                    LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();
                
            }
            return dtDrillReportData;
        }

        private DataTable dtOpsKPICancelledFiles(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(FILE_OPERATOR_TO_USERID) count, FILE_OPERATOR_TO_USERID  COORDINATOR
                    from AIMS_PATIENT a
                    where a.CREATION_DTTM  between ";
                            SQLString =  SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                            SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) and ";
                            SQLString = SQLString + @" CANCELLED = 'Y' and FILE_OPERATOR_TO_USERID is not null ";
                    SQLString = SQLString + @" group by FILE_OPERATOR_TO_USERID order by 1 desc ";

                    LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();
                
            }
            return dtDrillReportData;
        }

        private DataTable dtOpsKPISentToAdminFiles(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {

                SQLString = @"select COUNT(FILE_OPERATOR_TO_USERID) count, FILE_OPERATOR_TO_USERID  COORDINATOR
                            from AIMS_PATIENT a
                            where a.CREATION_DTTM  between ";
                            SQLString =  SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                            SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) and ";
                            SQLString = SQLString + @" SENT_TO_ADMIN = 'Y' and FILE_OPERATOR_TO_USERID is not null ";
                            SQLString =  SQLString + @" group by FILE_OPERATOR_TO_USERID order by 1 desc";

                            LogMessages(SQLString, " Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();
                
            }
            return dtDrillReportData;
        }

        private DataTable dtOpsKPISentEmails(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); ;
            //lastDay = 30;
            try
            {
                SQLString = @" select COUNT(email_sent_by) count, email_sent_by COORDINATOR ";
                SQLString = SQLString + @" from AIMS_PATIENT a, AIMS_EWS_PATIENT_SENT_EMAILS b, AIMS_USER_ROLE c ";
                SQLString = SQLString + @" where a.CREATION_DTTM between ";
                SQLString = SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) and ";
                SQLString = SQLString + @" FILE_OPERATOR_TO_USERID is not null ";
                SQLString = SQLString + @" and b.PATIENT_ID = a.PATIENT_ID ";
                SQLString = SQLString + @" and c.ROLE_CD = 'Operations' and c.USER_NAME = b.EMAIL_SENT_BY ";
                SQLString = SQLString + @" group by email_sent_by order by 1 desc ";

                LogMessages(SQLString, " Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPIClosedBeforeDueDateFiles(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {

                SQLString = @"select 
                COUNT(x.FILE_ASSIGNED_TO_USERID) count,
                x.FILE_ASSIGNED_TO_USERID COORDINATOR
                 from (
                select a.FILE_ASSIGNED_TO_USERID, b.MODIFIED_USER, dbo.getduedate(a.COURIER_RECEIPT_DATE) DUE_DATE, a.COURIER_RECEIPT_DATE,
                b.MODIFIED_DATE, 
                DATEDIFF(""D"",  dbo.getduedate(a.COURIER_RECEIPT_DATE), MODIFIED_DATE) DATE_DIFF 
                                    from AIMS_PATIENT a, AIMS_A_PATIENT b
                                    where a.CREATION_DTTM  between ";
                SQLString = SQLString + " convert(datetime,'01  " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                SQLString = SQLString + " convert(datetime,'" + lastDay + "  " + reportmonth  + " " + rptYear + " 23:59:00',103) and ";
                SQLString = SQLString + " a.PATIENT_FILE_ACTIVE_YN = 'N' and a.CANCELLED = 'N' and ";
                SQLString = SQLString + " a.SENT_TO_ADMIN = 'Y' ";
                SQLString = SQLString + " and b.PATIENT_ID  = a.PATIENT_ID ";
                SQLString = SQLString + " and b.AUDIT_ID = (select min(xx.audit_id) from AIMS_A_PATIENT xx ";
                SQLString = SQLString + " where xx.patient_id = a.patient_id and xx.PATIENT_FILE_ACTIVE_YN = 'N' ) ) x ";
                SQLString = SQLString + " where x.DATE_DIFF<0 ";
                SQLString = SQLString + " group by x.FILE_ASSIGNED_TO_USERID ";
                SQLString = SQLString + " order by 1";

                LogMessages(SQLString, " Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPIClosedAfterDueDateFiles(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {

                SQLString = @"select 
                    COUNT(x.FILE_ASSIGNED_TO_USERID) count,
                    x.FILE_ASSIGNED_TO_USERID COORDINATOR
                     from (
                    select a.FILE_ASSIGNED_TO_USERID, b.MODIFIED_USER, dbo.getduedate(a.COURIER_RECEIPT_DATE) DUE_DATE, a.COURIER_RECEIPT_DATE,
                    b.MODIFIED_DATE, 
                    DATEDIFF(""D"",  dbo.getduedate(a.COURIER_RECEIPT_DATE), MODIFIED_DATE) DATE_DIFF
                                        from AIMS_PATIENT a, AIMS_A_PATIENT b
                                        where a.CREATION_DTTM  between  ";
                    SQLString = SQLString + " convert(datetime,'01  "+reportmonth  +" " + rptYear + " 00:00:00',103) and   ";
                    SQLString = SQLString + " convert(datetime,'"+ lastDay +"  "+ reportmonth +" " + rptYear + " 23:59:00',103) and  ";
                    SQLString = SQLString + " a.PATIENT_FILE_ACTIVE_YN = 'N' and a.CANCELLED = 'N' and ";
                    SQLString = SQLString + " a.SENT_TO_ADMIN = 'Y' ";
                    SQLString = SQLString + " and b.PATIENT_ID  = a.PATIENT_ID ";
                    SQLString = SQLString + " and b.AUDIT_ID = (select min(xx.audit_id) from AIMS_A_PATIENT xx  ";
                    SQLString = SQLString + " where xx.patient_id = a.patient_id and xx.PATIENT_FILE_ACTIVE_YN = 'N' ) ) x  ";
                    SQLString = SQLString + " where x.DATE_DIFF>0 ";
                    SQLString = SQLString + " group by x.FILE_ASSIGNED_TO_USERID  ";
                    SQLString = SQLString + " order by 1";

                LogMessages(SQLString, " Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPICourieried2DaysAfterClosure(string rptMonth)
        {   
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {

                SQLString = @"select 
                        COUNT(x.FILE_ASSIGNED_TO_USERID) count,
                        x.FILE_ASSIGNED_TO_USERID COORDINATOR
                         from ( 
                         select  a.FILE_ASSIGNED_TO_USERID, b.MODIFIED_USER, 
                        a.FILE_COURIER_DATE,
                        b.MODIFIED_DATE, 
                        DATEDIFF(""D"",  MODIFIED_DATE, a.FILE_COURIER_DATE) DATE_DIFF";
                SQLString = SQLString + " from AIMS_PATIENT a, AIMS_A_PATIENT b ";
                SQLString = SQLString + " where a.CREATION_DTTM  between   ";
                SQLString = SQLString + " convert(datetime,'01  "+ reportmonth +" " + rptYear + " 00:00:00',103) and   ";
                SQLString = SQLString + " convert(datetime,'"+ lastDay +"  "+ reportmonth +" " + rptYear + " 23:59:00',103) and  ";
                SQLString = SQLString + " a.PATIENT_FILE_ACTIVE_YN = 'N' and a.CANCELLED = 'N' and ";
                SQLString = SQLString + " a.SENT_TO_ADMIN = 'Y' ";
                SQLString = SQLString + " and b.PATIENT_ID  = a.PATIENT_ID ";
                SQLString = SQLString + " and b.AUDIT_ID = (select min(xx.audit_id) from AIMS_A_PATIENT xx  ";
                SQLString = SQLString + " where xx.patient_id = a.patient_id and xx.PATIENT_FILE_ACTIVE_YN = 'N' )  ";
                SQLString = SQLString + " ) x  ";
                SQLString = SQLString + " where x.DATE_DIFF>2 ";
                SQLString = SQLString + " group by x.FILE_ASSIGNED_TO_USERID ";
                SQLString = SQLString + " order by 1"; 

                LogMessages(SQLString, " Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPICourieried2DaysBeforeClosure(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;
            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {

                SQLString = @"select 
                        COUNT(x.FILE_ASSIGNED_TO_USERID) count,
                        x.FILE_ASSIGNED_TO_USERID COORDINATOR
                         from ( 
                         select  a.FILE_ASSIGNED_TO_USERID, b.MODIFIED_USER, 
                        a.FILE_COURIER_DATE,
                        b.MODIFIED_DATE, 
                        DATEDIFF(""D"",  MODIFIED_DATE, a.FILE_COURIER_DATE) DATE_DIFF";
                SQLString =SQLString + " from AIMS_PATIENT a, AIMS_A_PATIENT b ";
                SQLString =SQLString + " where a.CREATION_DTTM  between   ";
                SQLString =SQLString + " convert(datetime,'01  "+ reportmonth +" " + rptYear + " 00:00:00',103) and   ";
                SQLString =SQLString + " convert(datetime,'"+ lastDay +"  "+ reportmonth +" " + rptYear + " 23:59:00',103) and  ";
                SQLString =SQLString + " a.PATIENT_FILE_ACTIVE_YN = 'N' and a.CANCELLED = 'N' and ";
                SQLString =SQLString + " a.SENT_TO_ADMIN = 'Y' ";
                SQLString =SQLString + " and b.PATIENT_ID  = a.PATIENT_ID ";
                SQLString =SQLString + " and b.AUDIT_ID = (select min(xx.audit_id) from AIMS_A_PATIENT xx  ";
                SQLString =SQLString + " where xx.patient_id = a.patient_id and xx.PATIENT_FILE_ACTIVE_YN = 'N' )  ";
                SQLString =SQLString + " ) x  ";
                SQLString =SQLString + " where x.DATE_DIFF<2 ";
                SQLString = SQLString + " group by x.FILE_ASSIGNED_TO_USERID ";
                SQLString =SQLString + " order by 1"; 

                LogMessages(SQLString, " Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPIEmailAllocated(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;

            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(EMAIL_INDEXED_BY) count, EMAIL_INDEXED_BY COORDINATOR  from AIMS_EWS_EMAILS where PROCESSED_DTTM between ";
                    SQLString = SQLString  + " convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and  ";
                    SQLString = SQLString  + " convert(datetime,'"+ lastDay +" "+ reportmonth +" " + rptYear + " 23:59:00',103) and EMAIL_INDEXED_BY in ( ";
                    SQLString = SQLString  + " select OPERATOR_MAILBOX_USER_NAME from AIMS_EWS_admin_MAILBOX) ";
                    SQLString = SQLString + " group by EMAIL_INDEXED_BY order by 1 desc ";

                LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, true);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPIWorkBasketEmailsProcessed(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;

            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(WORK_ITEM_PROCESSED_BY) count, WORK_ITEM_PROCESSED_BY COORDINATOR from AIMS_EWS_admin_MAILS 
                    where WORK_ITEM_PROCESSED_DTTM between ";
                SQLString = SQLString + @" convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                SQLString = SQLString + @" convert(datetime,'" + lastDay + " " + reportmonth + " " + rptYear + " 23:59:00',103) ";
                SQLString = SQLString + @" group by WORK_ITEM_PROCESSED_BY order by 1 desc";

                LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPITasksCreated(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;

            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(loaded_by) count, LOADED_BY COORDINATOR from AIMS_PATIENT_FILE_TASKS 
                where CREATION_DATE between ";
                SQLString = SQLString + " convert(datetime,'01 " + reportmonth + " " + rptYear + " 00:00:00',103) and ";
                SQLString  = SQLString  + " convert(datetime,'"+ lastDay +" "+ reportmonth +" " + rptYear + " 23:59:00',103) and LOADED_BY in (";
                SQLString  = SQLString  + " select OPERATOR_MAILBOX_USER_NAME from AIMS_EWS_admin_MAILBOX)";
                SQLString  = SQLString  + " group by LOADED_BY order by 1 desc";

                LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPITasksCompleted(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;

            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select  COUNT(USER_ID) count, USER_ID COORDINATOR from AIMS_PATIENT_FILE_TASKS 
                where CREATION_DATE between "; 
                SQLString  = SQLString  + " convert(datetime,'01 "+ reportmonth +" " + rptYear + " 00:00:00',103) and ";
                SQLString  = SQLString  + " convert(datetime,'"+ lastDay +" "+ reportmonth +" " + rptYear + " 23:59:00',103) and USER_ID in ( ";
                SQLString  = SQLString  + " select OPERATOR_MAILBOX_USER_NAME from AIMS_EWS_admin_MAILBOX) ";
                SQLString = SQLString + " and TASK_STATUS_ID = 3 ";
                SQLString  = SQLString  + " group by USER_ID order by 1 desc";

                LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        private DataTable dtAdminKPIFilesAllocated(string rptMonth)
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            string SQLString = "";
            string reportmonth = rptMonth;

            int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);;
            //lastDay = 30;
            try
            {
                SQLString = @"select COUNT(FILE_ASSIGNED_TO_USERID) count, FILE_ASSIGNED_TO_USERID COORDINATOR from AIMS_PATIENT where CREATION_DTTM 
                between ";
                SQLString  = SQLString  + " convert(datetime,'01 "+ reportmonth +" " +rptYear + " 00:00:00',103) and ";
                SQLString  = SQLString  + " convert(datetime,'"+ lastDay +" "+ reportmonth +" " + rptYear + " 23:59:00',103) and  ";
                SQLString = SQLString + " FILE_ASSIGNED_TO_USERID is not null ";
                SQLString  = SQLString  + " group by FILE_ASSIGNED_TO_USERID order by 1 desc";

                LogMessages(SQLString, "Generating Discharge List SQL: " + SQLString, false);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                cmdDrillReport.Dispose();

            }
            return dtDrillReportData;
        }

        public void Generate6677Providers()
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string DrillReportEmailSubject = "Operations - 66/77 Future Cases - Service Providers";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=10>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=10>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"select distinct 
                            b.patient_file_no,
                                a.SERVICE_PROVIDER_NAME , 
                                a.SERVICE_PROVIDER_PHONE, 
                                a.SERVICE_PROVIDER_FAX_NO, 
                                a.SERVICE_PROVIDER_EMAIL,
                                a.USER_NAME Loaded_by
                                from AIMS_PATIENT_SERVICE_PROVIDERS a, AIMS_PATIENT b ,
                                AIMS_A_PATIENT_SERVICE_PROVIDERS c
                                 where b.PATIENT_ID in (44860, 44859) and 
                                 a.PATIENT_ID = b.PATIENT_ID and 
                                 c.PATIENT_ID = a.PATIENT_ID and 
                                 c.AUDIT_ID = (select min(audit_id) from AIMS_A_PATIENT_SERVICE_PROVIDERS xx where xx.PATIENT_ID = b.PATIENT_ID)  
                                  order by 1 asc,6 desc";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor='lightgrey' valign='bottom' align='center' width='5%'><b>File No</b></td>" +
                               "<td bgcolor='lightgrey' valign='bottom' align='center' width='40%'><b>Provider name</b></td>" +
                               "<td bgcolor='lightgrey' valign='bottom' align='center' width='10%'><b>Provider Tel No</b></td>" +
                               "<td bgcolor='lightgrey' valign='bottom' align='center' width='10%'><b>Provider Email</b></td>" +
                               "<td bgcolor='lightgrey' valign='bottom' align='center' width='10%'><b>Provider Fax No</b></td>" +
                               "<td bgcolor='lightgrey' valign='bottom' align='center' width='20%'><b>Loaded By</b></td>" +
                                "</tr>";

                    string OutInPatient = "";
                    string InPatient = "";
                    string OutPatient = "";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        sEmailBody += "<tr>" +
                            "<td valign='bottom' bgcolor='#ffffff' style='border-bottom-style:solid;border-bottom-width:1px' align='center'>" + dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString() + "</td>" +
                            "<td valign='bottom' bgcolor='#ffffff' style='border-bottom-style:solid;border-bottom-width:1px' align='center'>" + dtDrillReportData.Rows[i]["SERVICE_PROVIDER_NAME"].ToString() + "</td>" +
                            "<td valign='bottom' bgcolor='#ffffff' style='border-bottom-style:solid;border-bottom-width:1px' align='center'>" + dtDrillReportData.Rows[i]["SERVICE_PROVIDER_PHONE"].ToString() + "</td>" +
                            "<td valign='bottom' bgcolor='#ffffff' style='border-bottom-style:solid;border-bottom-width:1px' align='center'>" + dtDrillReportData.Rows[i]["SERVICE_PROVIDER_EMAIL"].ToString() + "</td>" +
                            "<td valign='bottom' bgcolor='#ffffff' style='border-bottom-style:solid;border-bottom-width:1px' align='center'>" + dtDrillReportData.Rows[i]["SERVICE_PROVIDER_FAX_NO"].ToString() + "</td>" +
                            "<td valign='bottom' bgcolor='#ffffff' style='border-bottom-style:solid;border-bottom-width:1px' align='center'>" + dtDrillReportData.Rows[i]["Loaded_by"].ToString() + "</td>" +
                            "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=7><b>NO SERVICE PROVIDERS FOR FUTURE CASES</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, "operations@aims.org.za"); //""
                blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, "operations@aims.org.za", "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, "operations@aims.org.za", "", false, "", "martitian@gmail.com");
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating " + DrillReportEmailSubject, true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        public void AdminActiveFiles()
        {
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            bool blResult = false;
            string PatientFileNo = "";
            string PatientID = "";
            string CoOrdinator = "";
            string SQLString = "";
            string sEmailBody = "";

            string AdmissionDate = "";
            string PatientName = "";
            string Hospital = "";
            string Insurance = "";
            string Diagnosis = "";
            string LatestGOP = "";
            string CaseHandler = "";
            
            string filedueDate = "";

            string DrillReportEmailSubject = "Administration - Active Files";
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"SELECT (A.PATIENT_LAST_NAME + ' ' + A.PATIENT_FIRST_NAME) 'PATIENT_NAME',
                            PATIENT_FILE_NO,
                            PATIENT_DISCHARGE_DATE 'DISCHARGE_DATE' , 
                            COURIER_RECEIPT_DATE 'RECEIVED_DATE',
                            GUARANTOR_NAME ,
                            IN_PATIENT ,
                            OUT_PATIENT ,
                            REPAT,
                            ASSIST,
                            RMR  ,
                            TRANSPORT,
                            FLIGHT,
                            d.User_Full_Name,
                            a.FILE_OPERATOR_TO_USERID
                            FROM AIMS_PATIENT A 
                            LEFT OUTER JOIN AIMS_SUPPLIER B ON B.SUPPLIER_ID = A.SUPPLIER_ID
                            inner join AIMS_GUARANTOR c on c.GUARANTOR_ID = A.GUARANTOR_ID
                            left outer join AIMS_USERS d on d.User_Name = A.FILE_ASSIGNED_TO_USERID
                            AND SENT_TO_ADMIN = 'Y'
                            and PATIENT_FILE_ACTIVE_YN = 'Y' and CANCELLED = 'N' and a.creation_dttm >= '01 January 2018' ";

                
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);
                
                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                                "<td bgcolor=lightgrey valign=top align=center width=12.5%><b>Case No</b></td>" +
                                "<td bgcolor=lightgrey valign=top align=center width=12.5%><b>Category</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=12.5%><b>Discharge Date</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=12.5%><b>Received Date</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=12.5%><b>Due Date</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=12.5%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=12.5%><b>Administrator</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=12.5%><b>OPS Co-Ordinator</b></td>" +
                                "</tr>";

                    string AdminHandler = "";
                    string DischargeDt = "";
                    string ReceivedDt = "";
                    string InPatient = "";
                    string OutPatient = "";
                    
                    string IN_PATIENT  = "";
                    string OUT_PATIENT  = "";
                    string REPAT  = "";
                    string ASSIST = "";
                    string RMR   = "";
                    string TRANSPORT = "";
                    string FLIGHT = ""; 

                    string DueDt = "";
                    string Descript = "";
                    string Guarantor = "";
                    string OpsCoOrdinator = "";

                    DateTime dtReceiptDttm;
                    DateTime dtDueDate;
                    string fileDueDate;
                    string dueColor = "#ffffff";
                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["PATIENT_NAME"].ToString();
                        DischargeDt = dtDrillReportData.Rows[i]["DISCHARGE_DATE"].ToString();
                        ReceivedDt = dtDrillReportData.Rows[i]["RECEIVED_DATE"].ToString();
                        InPatient = dtDrillReportData.Rows[i]["IN_PATIENT"].ToString();
                        OutPatient = dtDrillReportData.Rows[i]["OUT_PATIENT"].ToString();
                        Guarantor = dtDrillReportData.Rows[i]["GUARANTOR_NAME"].ToString();
                        AdminHandler = dtDrillReportData.Rows[i]["User_Full_Name"].ToString();
                        OpsCoOrdinator = dtDrillReportData.Rows[i]["FILE_OPERATOR_TO_USERID"].ToString();

                        if (AdminHandler.Equals(""))
                        {
                            AdminHandler = " - ";
                        }
                        if (OpsCoOrdinator.Equals(""))
                        {
                            OpsCoOrdinator = " - ";
                        }

                        REPAT = dtDrillReportData.Rows[i]["REPAT"].ToString();
                        ASSIST = dtDrillReportData.Rows[i]["ASSIST"].ToString();
                        RMR = dtDrillReportData.Rows[i]["RMR"].ToString();
                        TRANSPORT = dtDrillReportData.Rows[i]["TRANSPORT"].ToString();
                        FLIGHT = dtDrillReportData.Rows[i]["FLIGHT"].ToString();
                        Descript = "";
 
                        if (OutPatient =="Y") { Descript = "OutPatient";
                        }else if(InPatient == "Y"){Descript = "InPatient";
                        }else if(REPAT  == "Y"){Descript = "Repat";
                        }else if (ASSIST == "Y"){Descript = "Assist";
                        }else if (RMR == "Y"){Descript = "RMR";
                        }else if (TRANSPORT == "Y"){Descript = "Transport";
                        }else if (FLIGHT == "Y"){Descript = "Flight/Evacuation ";}

                        if (Descript.Equals(""))
                            Descript = " - ";

                        if (!ReceivedDt.Trim().Equals(""))
                        {
                            dtReceiptDttm = System.Convert.ToDateTime(ReceivedDt);
                            DueDt = GetDueDate(dtReceiptDttm);

                            dtDueDate = System.Convert.ToDateTime(DueDt);
                            
                            DateTime dtdueDate;
                            if (DateTime.TryParse(DueDt, out dtdueDate))
                            {
                                System.TimeSpan diffResult = System.Convert.ToDateTime(DueDt) - DateTime.Today.Date;
                                if (diffResult.Days >= 0)
                                {
                                    dueColor = "#ffffff";
                                }
                                else
                                {
                                    dueColor = Color.Red.ToKnownColor().ToString();
                                }
                            }
                            fileDueDate = dtdueDate.ToString("dd-MMM-yyyy");
                            ReceivedDt = dtReceiptDttm.ToString("dd-MMM-yyyy");
                        }
                        else
                        {
                            fileDueDate = " - ";
                            ReceivedDt = " - ";
                            dueColor = "#ffffff";
                        }

                        sEmailBody += "<tr style='border-bottom-style:solid;border-bottom-width:1px'>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Descript + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + DischargeDt + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + ReceivedDt  + "</td>" +
                        "<td valign=top bgcolor='" + dueColor + "' style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + fileDueDate + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Guarantor + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + AdminHandler  + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + OpsCoOrdinator  + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>No Active Discharged Files</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                
                string ReportRecipient = "danielm@aims.org.za;";
                
                blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");

                LogMessages("Testing Suzzssful: " + blResult, "Email Successful", false);

                if (!blResult)
                {
                    blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ReportRecipient);
                }

                
                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
                
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
            }
        }

        ExchangeService GetBindingOffice365(string MailBoxUserName, string MailBoxUserPassword, string MailBoxDomain, string MailEWSURL)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            try
            {
                WebCredentials webCred = new WebCredentials(MailBoxUserName, MailBoxUserPassword, MailBoxDomain);
                service.Credentials = webCred;
                service.Url = new Uri(MailEWSURL);
            }
            catch (Microsoft.Exchange.WebServices.Data.ServiceLocalException ex)
            {

            }
            return service;
        }

        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            bool result = false;
            //if (cert.Subject.ToUpper().Contains("DC1"))     {         
            result = true;
            //}      
            return result;
        }

        private static void AssignCertificatesOffice365()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            object obj1 = new object();

            System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
        }

        private bool EWSSendEmailNow(string EmailBody,
                                    string EmailFrom,
                                    string EmailFromName,
                                    string EmailSubject,
                                    string EmailTo,
                                    string EmailAttachments,
                                    bool KillFiles,
                                    string EmailCC,
                                    string EmailBcc)
        {
            AIMReports.CommonFunctions cmmnFuncs = new AIMReports.CommonFunctions();
            cmmnFuncs.ErrorLogger("Start Sending Using EWS Office - New Way of send emails");

            string sAppId = "2efcf754-471e-4a9a-85fd-f3dd08b62c35"; // appclient-id
            string sRedirectURL = "";
            string sServername = "";
            string sBearerToken = "";

            string secret = "Vm18Q~OCxKXyH86soQDlJKx2xHAIJ9X7jeulCbfs";
            ExchangeCredentials oExchangeCredentials = null;
            try
            {
                //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                AssignCertificatesOffice365();

                // See // https://msdn.microsoft.com/en-us/library/office/dn903761(v=exchg.150).aspx
                // get authentication token
                string authority = "https://login.microsoftonline.com/9d40314f-1d37-457d-b900-21bc738c85bd"; // Tenantid 
                string clientID = sAppId;
                Uri clientAppUri = new Uri("https://login.microsoftonline.com/common/oauth2/nativeclient");
                string serverName = "https://outlook.office365.com";

                AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);
                
                AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync(serverName, new ClientCredential(clientID, secret)).Result;

                sBearerToken = authenticationResult.AccessToken;
                oExchangeCredentials = new OAuthCredentials(authenticationResult.AccessToken);

                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
                service.Credentials = new OAuthCredentials(authenticationResult.AccessToken);
                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;
                service.Url = new Uri(serverName + "/EWS/Exchange.asmx");

                if (EmailFrom.Equals("admin@aims.org.za", StringComparison.OrdinalIgnoreCase))
                {
                    service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "Admin@aims.org.za");
                }
                else
                {
                    service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "operations@aims.org.za");
                }

                EmailMessage email = new EmailMessage(service);

                string[] globalTeamEmails = EmailTo.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        email.ToRecipients.Add(globalEmail.Trim());
                    }
                }

                globalTeamEmails = EmailCC.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        email.CcRecipients.Add(globalEmail.Trim());
                    }
                }

                globalTeamEmails = EmailBcc.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        email.BccRecipients.Add(globalEmail.Trim());
                    }
                }

                globalTeamEmails = EmailAttachments.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        email.Attachments.AddFileAttachment(globalEmail);
                    }
                }

                email.Subject = EmailSubject;
                email.Body = EmailBody;
                email.Body.BodyType = BodyType.HTML;
                email.Send();
                cmmnFuncs.ErrorLogger("Email Transmission Successfully sent to: " + EmailTo);
                return true;               
            }
            catch (SmtpException exception)
            {
                cmmnFuncs.ErrorLogger("Email Transmission SmtpException Exception/ERROR: " + exception.ToString());
                return false;
            }
            catch (AutodiscoverRemoteException exception)
            {
                cmmnFuncs.ErrorLogger("Email Transmission AutodiscoverRemoteException Exception/ERROR: " + exception.ToString());
                return false;
            }
            catch (Exception exception)
            {
                cmmnFuncs.ErrorLogger("Email Transmission SmtpException Exception/ERROR: " + exception.ToString());
                return false;
            }
        }

        private bool EWSSendEmailNowOld(string EmailBody,
                                    string EmailFrom,
                                    string EmailFromName,
                                    string EmailSubject,
                                    string EmailTo,
                                    string EmailAttachments,
                                    bool KillFiles,
                                    string EmailCC,
                                    string EmailBcc)
        {
            AIMReports.CommonFunctions cmmnFuncs = new AIMReports.CommonFunctions();
            ExchangeService myservice = null;
            cmmnFuncs.ErrorLogger("Start Sending Using EWS Office");
            if (EmailFrom.Equals("admin@aims.org.za", StringComparison.OrdinalIgnoreCase))
            {
                myservice = GetBindingOffice365("Admin@AIMS.org.za", "@im5Bill2023", "Admin", "https://outlook.office365.com/EWS/Exchange.asmx");
            }
            else
            {
                //myservice = GetBindingOffice365("operation@aims.org.za", "Tra2As+u", "operation", "https://outlook.office365.com/EWS/Exchange.asmx");
                myservice = GetBindingOffice365("operations@aims.org.za", "#FutuR3!5B", "operations", "https://outlook.office365.com/EWS/Exchange.asmx");
            }

            AssignCertificatesOffice365();
            try
            {
                EmailMessage emailMessage = new EmailMessage(myservice);
                emailMessage.Subject = EmailSubject;
                emailMessage.Body = EmailBody;
                emailMessage.Body.BodyType = BodyType.HTML;
                

                string[] globalTeamEmails = EmailTo.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        emailMessage.ToRecipients.Add(globalEmail.Trim());
                    }
                }

                globalTeamEmails = EmailCC.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        emailMessage.CcRecipients.Add(globalEmail.Trim());
                    }
                }

                globalTeamEmails = EmailBcc.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        emailMessage.BccRecipients.Add(globalEmail.Trim());
                    }
                }

                globalTeamEmails = EmailAttachments.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        emailMessage.Attachments.AddFileAttachment(globalEmail);
                    }
                }
                cmmnFuncs.ErrorLogger("Start Email Transmission");
                emailMessage.Send();
                cmmnFuncs.ErrorLogger("Email Transmission Successful sent to: " + EmailTo);
            }
            catch (SmtpException exception)
            {
                cmmnFuncs.ErrorLogger("Email Transmission SmtpException Exception/ERROR: " + exception.ToString());
                return false;
            }
            catch (AutodiscoverRemoteException exception)
            {
                cmmnFuncs.ErrorLogger("Email Transmission AutodiscoverRemoteException Exception/ERROR: " + exception.ToString());
                return false;
            }
            catch (Exception exception)
            {
                cmmnFuncs.ErrorLogger("Email Transmission SmtpException Exception/ERROR: " + exception.ToString());
                return false;
            }
            return true;
        }

        private bool EWSSendEmailNowGIPF(string EmailBody,
                                    string EmailFrom,
                                    string EmailFromName,
                                    string EmailSubject,
                                    string EmailTo,
                                    string EmailAttachments,
                                    bool KillFiles,
                                    string EmailCC,
                                    string EmailBcc)
        {
            try
            {
                AIMReports.CommonFunctions cmmnFuncs = new AIMReports.CommonFunctions();
                cmmnFuncs.ErrorLogger("Start Sending Using EWS Office - New Way of send emails");

                //string sAppId = "f20a8fa9-4682-4b7c-956e-422c8f57cc5f";
                string sAppId = "a14270da-8187-4391-86b8-7f4d04cef61e";
                string sBearerToken = "";

                //string secret = "cf03e72e-ef05-4f76-b650-42de2d8683b7";
                string secret = "v7s8Q~A8.OcftBP9ElkUtQsQX4uh0_gzkoQbPaXA";
                ExchangeCredentials oExchangeCredentials = null;
                try
                {
                    //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    AssignCertificatesOffice365();

                    // See // https://msdn.microsoft.com/en-us/library/office/dn903761(v=exchg.150).aspx
                    // get authentication token
                    string authority = "https://login.microsoftonline.com/9427e700-b087-4326-aad3-5616b32a5068";
                    string clientID = sAppId;
                    Uri clientAppUri = new Uri("https://login.microsoftonline.com/common/oauth2/nativeclient");
                    string serverName = "https://outlook.office365.com";

                    AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);

                    AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync(serverName, new ClientCredential(clientID, secret)).Result;

                    sBearerToken = authenticationResult.AccessToken;
                    oExchangeCredentials = new OAuthCredentials(authenticationResult.AccessToken);

                    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
                    service.Credentials = new OAuthCredentials(authenticationResult.AccessToken);
                    service.TraceEnabled = true;
                    service.TraceFlags = TraceFlags.All;
                    service.Url = new Uri(serverName + "/EWS/Exchange.asmx");

                    if (EmailFrom.Equals("ihorizon@gipf.com.na", StringComparison.OrdinalIgnoreCase))
                    {
                        service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "ihorizon@gipf.com.na");
                    }
                    else
                    {
                        service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "operations@aims.org.za");
                    }

                    EmailMessage email = new EmailMessage(service);

                    string[] globalTeamEmails = EmailTo.Split(new Char[] { ';' });
                    foreach (string globalEmail in globalTeamEmails)
                    {
                        if (!globalEmail.Trim().Equals(""))
                        {
                            email.ToRecipients.Add(globalEmail.Trim());
                        }
                    }

                    globalTeamEmails = EmailCC.Split(new Char[] { ';' });
                    foreach (string globalEmail in globalTeamEmails)
                    {
                        if (!globalEmail.Trim().Equals(""))
                        {
                            email.CcRecipients.Add(globalEmail.Trim());
                        }
                    }

                    globalTeamEmails = EmailBcc.Split(new Char[] { ';' });
                    foreach (string globalEmail in globalTeamEmails)
                    {
                        if (!globalEmail.Trim().Equals(""))
                        {
                            email.BccRecipients.Add(globalEmail.Trim());
                        }
                    }

                    globalTeamEmails = EmailAttachments.Split(new Char[] { ';' });
                    foreach (string globalEmail in globalTeamEmails)
                    {
                        if (!globalEmail.Trim().Equals(""))
                        {
                            email.Attachments.AddFileAttachment(globalEmail);
                        }
                    }

                    email.Subject = EmailSubject;
                    email.Body = EmailBody;
                    email.Body.BodyType = BodyType.HTML;
                    email.Send();
                    cmmnFuncs.ErrorLogger("Email Transmission Successfully sent to: " + EmailTo);
                    return true;
                }
                catch (SmtpException exception)
                {
                    cmmnFuncs.ErrorLogger("Email Transmission SmtpException Exception/ERROR: " + exception.ToString());
                    return false;
                }
                catch (AutodiscoverRemoteException exception)
                {
                    cmmnFuncs.ErrorLogger("Email Transmission AutodiscoverRemoteException Exception/ERROR: " + exception.ToString());
                    return false;
                }
                catch (Exception exception)
                {
                    cmmnFuncs.ErrorLogger("Email Transmission SmtpException Exception/ERROR: " + exception.ToString());
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void GenerateHighCost(string ReportRecipient)
        {
            AIMSEmailer.AIMS.Utility.eMailer aimsEmailer = new AIMSEmailer.AIMS.Utility.eMailer();

            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();

            string PatientFileNo = "";
            string AdmissionDate = "";
            string PatientName = "";
            string Hospital = "";
            string Insurance = "";
            string Diagnosis = "";
            string LatestGOP = "";
            string CaseHandler = "";

            string DrillReportEmailSubject = "High Cost Cases";

            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>" + DrillReportEmailSubject + "</b></font></center>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=5>&nbsp;</td>" +
                                "</tr>";

                SQLString = @"SELECT a.patient_file_no ""Case"",convert(smalldatetime,PATIENT_ADMISSION_DATE,103) Admission, " +
                        " UPPER(A.Patient_Last_Name)+ ' ' + UPPER(PATIENT_FIRST_NAME) +  ' (' + UPPER(A.PATIENT_INITIALS) + ') (' +  UPPER(ATT.Title_desc) + ')' AS Patient, " +
                        " asup.supplier_name Hospital, " +
                          "    b.guarantor_name Insurance,  " +
                        " a.patient_diagnosis Diagnosis, " +
                        @"a.patient_guarantor_amount ""Latest GOP"", " +
                        @" User_Full_Name ""Case Handler"" " +
                          "       FROM aims_patient a " +
                            "     left outer join aims_guarantor b on b.guarantor_id = a.guarantor_id " +
                              "   LEFT OUTER JOIN AIMS_TITLE  AS att ON  att.title_id  = a.title_id    " +
                                " left outer join aims_supplier as asup on asup.supplier_id = a.supplier_id          " +
                                " left outer join AIMS_USERS as aum on  aum.user_name = a.FILE_OPERATOR_TO_USERID " +
                               " WHERE cancelled = 'N' " +
                                 " AND a.patient_file_active_yn = 'Y' " +
                                 " AND a.sent_to_admin = 'N' " +
                                " and a.HIGH_COST = 'Y' " +
                                " and (patient_discharge_date IS NULL or patient_discharge_date = '') " +
                            " ORDER BY convert(smalldatetime,PATIENT_ADMISSION_DATE , 103) desc,  " +
                            " CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC) desc, " +
                            " CAST (substring (a.patient_file_no, 4, 4) AS NUMERIC) desc";

                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Case</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Admission</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=35%><b>Patient</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=20%><b>Hospital</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=25%><b>Insurance</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Diagnosis</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Latest GOP</b></td>" +
                               "<td bgcolor=lightgrey valign=top align=center width=5%><b>Handler</b></td>" +
                                "</tr>";

                    DateTime dtCommit;
                    bool reportPageBreak = true;
                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientFileNo = dtDrillReportData.Rows[i]["Case"].ToString();
                        AdmissionDate = dtDrillReportData.Rows[i]["Admission"].ToString();
                        PatientName = dtDrillReportData.Rows[i]["Patient"].ToString();
                        Hospital = dtDrillReportData.Rows[i]["Hospital"].ToString();
                        if (Hospital.Trim().Equals(""))
                        {
                            Hospital = "-";
                        }
                        Insurance = dtDrillReportData.Rows[i]["Insurance"].ToString();
                        if (Insurance.Trim().Equals(""))
                        {
                            Insurance = "-";
                        }
                        Diagnosis = dtDrillReportData.Rows[i]["Diagnosis"].ToString();
                        if (Diagnosis.Trim().Equals(""))
                        {
                            Diagnosis = "-";
                        }
                        LatestGOP = dtDrillReportData.Rows[i]["Latest GOP"].ToString();
                        if (LatestGOP.Trim().Equals(""))
                        {
                            LatestGOP = "-";
                        }
                        CaseHandler = dtDrillReportData.Rows[i]["Case Handler"].ToString();
                        if (CaseHandler.Trim().Equals(""))
                        {
                            CaseHandler = "-";
                        }
                        if (string.IsNullOrWhiteSpace(AdmissionDate))
                        {
                            dtCommit = DateTime.Now;
                        }
                        else
                        {
                            dtCommit = Convert.ToDateTime(AdmissionDate);
                        }
                        
                        System.TimeSpan diffResult = dtCommit.Subtract(DateTime.Now);

                        if (diffResult.Days < 0 && reportPageBreak)
                        {
                            sEmailBody += "<tr>" +
                                "<td bgcolor=YELLOW valign=bottom align=center colspan=8><span style='Font-color:red;font-family:tahoma;font-size:20px'>Active High Cost Files</span></td>" +
                                        "</tr>";
                            reportPageBreak = false;
                        }
                        sEmailBody += "<tr>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientFileNo + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dtCommit.ToString("dd-MMM-yyyy") + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + PatientName + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Hospital + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Insurance + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + Diagnosis + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + LatestGOP + "</td>" +
                        "<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + CaseHandler + "</td>" +
                        "</tr>";
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><font color=red><b>TOTAL - " + dtDrillReportData.Rows.Count + "</b></font></td>" +
                                "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>No After-Hours Files Found</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                //blResult = aimsEmailer.TestEmail(sEmailBody, "No.Reply@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", "", "martitian@gmail.com");
                blResult = EWSSendEmailNow(sEmailBody, "Operations@AIMS.org.za", "Operations@AIMS.org.za", DrillReportEmailSubject, ReportRecipient, "", false, "", "martitian@gmail.com");
                if (!blResult)
                {
                    blResult = aimsEmailer.SendEmailNotify(sEmailBody, DrillReportEmailSubject, ReportRecipient);
                }

                if (blResult)
                {
                    LogMessages(DrillReportEmailSubject + " Report Email sent successfully", "Email Successful", false);
                }
                else
                {
                    LogMessages(DrillReportEmailSubject + " Report Email NOT sent successfully", "Email UnSuccessful", false);
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
                LogMessages(ex.ToString(), "Generating Patients Admitted NOT discharged after 14 Days", true);
            }
            finally
            {
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                aimsEmailer = null;
            }
        }

        // Generate OAuth 2.0 Access Token for EWS API 
        
        private static void ProcessMailAsync(string clientId, string clientSecret, string tenantId)
        {
            AssignCertificatesOffice365();
            //var cca = ConfidentialClientApplicationBuilder
            //    .Create(ConfigurationManager.AppSettings["appId"])
            //    .WithClientSecret(ConfigurationManager.AppSettings["clientSecret"])
            //    .WithTenantId(ConfigurationManager.AppSettings["tenantId"])
            //    .Build();

            //var ewsScopes = new string[] { "https://outlook.office365.com/.default" };
            //var ewsScopes = new string[] { "https://outlook.office365.com/EWS.AccessAsUser.All" };
            try
            {
                //var authResult = await cca.AcquireTokenForClient(ewsScopes).ExecuteAsync();
                var ewsClient = new ExchangeService();
                ewsClient.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
                
                //ewsClient.Credentials = new OAuthCredentials(authResult.AccessToken);
                //ewsClient.Credentials = new OAuthCredentials(new NetworkCredential("opstest@aims.org.za", "opst35t!2023"));
                ewsClient.Credentials = new OAuthCredentials(new NetworkCredential("billings@aims.org.za", "Ab1ll@!2023"));

                //ewsClient.ImpersonatedUserId =
                //    new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "Administration@aims.org.za");

                //ewsClient.HttpHeaders.Add("X-AnchorMailbox", "Administration@aims.org.za");
                //ewsClient.HttpHeaders.Add("X-PreferServerAffinity", "true");

                var folders = ewsClient.FindFolders(WellKnownFolderName.Inbox, new FolderView(10));
                FindItemsResults<Item> findResults = ewsClient.FindItems(WellKnownFolderName.Inbox, new ItemView(10));
                //LogMessages("O-Auth OK", "findResults.Items: " + findResults.Items.Count.ToString(), true);

                //foreach (Item item in findResults.Items)
                //{
                //    Console.WriteLine(item.Subject);
                //}

                //foreach (var folder in folders)
                //{
                //    Console.WriteLine($"Folder: {folder.DisplayName}");
                //}

            }
            //catch (MsalException ex)
            //{
            //    //LogMessages(ex.ToString(), "1 - Generating OAuth 2.0 Access Token", true);
            //    //Console.WriteLine($"Error acquiring access token: {ex}");
            //}
            catch (Exception ex)
            {
               // LogMessages(ex.ToString(), "2 - Generating OAuth 2.0 Access Token", true);
                //Console.WriteLine($"Error: {ex}");
            }
            
            void AssignCertificatesOffice365()
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                object obj1 = new object();

                System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
            }
        }

        //static async System.Threading.Tasks.Task MainAsync()
        //{
        //    // Using Microsoft.Identity.Client 4.22.0
        //    //var cca = ConfidentialClientApplicationBuilder
        //    //    .Create(ConfigurationManager.AppSettings["appId"])
        //    //    .WithClientSecret(ConfigurationManager.AppSettings["clientSecret"])
        //    //    .WithTenantId(ConfigurationManager.AppSettings["tenantId"])
        //    //    .Build();

        //    // The permission scope required for EWS access
        //    //var ewsScopes = new string[] { "https://outlook.office365.com/.default" };

        //    //Make the token request
        //    var authResult = await cca.AcquireTokenForClient(ewsScopes).ExecuteAsync();
            
        //    try
        //    {
        //        // Configure the ExchangeService with the access token
        //        var ewsClient = new ExchangeService();
        //        ewsClient.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
        //        ewsClient.Credentials = new OAuthCredentials(authResult.AccessToken);
                
        //        //Impersonate the mailbox you'd like to access.
        //        ewsClient.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "opstest@aims.org.za");

        //        //Include x-anchormailbox header
        //        ewsClient.HttpHeaders.Add("X-AnchorMailbox", "opstest@aims.org.za");

        //        // Make an EWS call
        //        var folders = ewsClient.FindFolders(WellKnownFolderName.MsgFolderRoot, new FolderView(10));
        //        foreach (var folder in folders)
        //        {
        //            Console.WriteLine($"Folder: {folder.DisplayName}");
        //        }
        //    }
        //    //catch (MsalException ex)
        //    //{
        //    //    Console.WriteLine($"Error acquiring access token: {ex.ToString()}");
        //    //}
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.ToString()}");
        //    }
        //}

        //static async System.Threading.Tasks.Task ProcessMail()
        //{
        //    // Using Microsoft.Identity.Client 4.22.0

        //    // Configure the MSAL client to get tokens
        //    var pcaOptions = new PublicClientApplicationOptions
        //    {
        //        ClientId = ConfigurationManager.AppSettings["appId"],
        //        TenantId = ConfigurationManager.AppSettings["tenantId"]
        //    };

        //    var pca = PublicClientApplicationBuilder
        //        .CreateWithApplicationOptions(pcaOptions).Build();

        //    // The permission scope required for EWS access
        //    var ewsScopes = new string[] { "https://outlook.office365.com/EWS.AccessAsUser.All" };
        //    try
        //    {
        //        // Make the interactive token request
        //        //var authResult = await pca.AcquireTokenByUsernamePassword(ewsScopes, "Operations", "A1m5@october2022").ExecuteAsync();
        //        var authResult = await pca.AcquireTokenByUsernamePassword(ewsScopes, "billings@aims.org.za", "Ab1ll@!2023").ExecuteAsync();

        //        // Configure the ExchangeService with the access token
        //        var ewsClient = new ExchangeService();
        //        ewsClient.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
        //        ewsClient.Credentials = new OAuthCredentials(authResult.AccessToken);

        //        // Make an EWS call
        //        var folders = ewsClient.FindFolders(WellKnownFolderName.MsgFolderRoot, new FolderView(10));
        //        foreach (var folder in folders)
        //        {
        //            Console.WriteLine($"Folder: {folder.DisplayName}");
        //        }
        //    }
        //    catch (MsalException ex)
        //    {
        //        Console.WriteLine($"Error acquiring access token: {ex}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex}");
        //    }

        //    if (System.Diagnostics.Debugger.IsAttached)
        //    {
        //        Console.WriteLine("Hit any key to exit...");
        //        Console.ReadKey();
        //    }
        //}

        public void EWSConnectOauth()
        {

        } 

        // Generate OAuth 2.0 Access Token for EWS API 
        public string GenerateOAuth2AccessToken(string clientId, string clientSecret, string tenantId)
        {
            string token = string.Empty;
            AssignCertificatesOffice365();
            //var tokener = GetToken(clientId, clientSecret, tenantId);
            //ProcessMailAsync(clientId, clientSecret, tenantId);
            //return "";
            try
            {
                string url = "https://login.microsoftonline.com/" + tenantId + "/oauth2/token";
                //url = @"https://login.microsoftonline.com/9d40314f-1d37-457d-b900-21bc738c85bd/oauth2/token";
                string body = "grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret + "&resource=";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                HttpContent httpContent = new FormUrlEncodedContent(
                        new[]
                        {
                                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                                        new KeyValuePair<string, string>("client_id", "2efcf754-471e-4a9a-85fd-f3dd08b62c35"),
                                        new KeyValuePair<string, string>("client_secret", "uE08Q~BgmekX41aZOWUmtI0D~KcPNASSRfUOQb6X"),
                                        new KeyValuePair<string, string>("resource", "https://outlook.office365.com/EWS/Exchange.asmx"),
                        });

                //request.KeepAlive = true;
                //request.ContentLength = httpContent.ReadAsStringAsync().Result.Length;
                //request.Credentials = new NetworkCredential("operation@aims.org.za", "Tra2As+u");

                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(body);
                }

                //request.ContentLength = body.Length;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = reader.ReadToEnd();
                    JObject jObject = JObject.Parse(responseText);
                    token = jObject["access_token"].ToString();
                }

                var ewsClient = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
                ewsClient.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
                //ewsClient.Url = new Uri("https://outlook.office365.com");
                OAuthCredentials oUath = new OAuthCredentials(token);
                ewsClient.Credentials = oUath;
                //ewsClient.Credentials = new OAuthCredentials(token);
                ewsClient.ImpersonatedUserId =
                    new ImpersonatedUserId(ConnectingIdType.PrincipalName, "opstest");

                //Include x-anchormailbox header
                ewsClient.HttpHeaders.Add("X-AnchorMailbox", "opstest@aims.org.za");

                // Make an EWS call
                var folders = ewsClient.FindFolders(WellKnownFolderName.Inbox, new FolderView(10));
            }
            catch (Exception ex)
            {
                LogMessages(ex.ToString(), "Generating OAuth 2.0 Access Token", true);
            }
            return token;
        }

        public static string GenerateOAuth2Token(string clientId, string clientSecret, string tenantId)
        {
            string token = string.Empty;
            AssignCertificatesOffice365();
            //var tokener = GetToken(clientId, clientSecret, tenantId);
            //ProcessMailAsync(clientId, clientSecret, tenantId);
            //return "";
            try
            {
                string url = "https://login.microsoftonline.com/" + tenantId + "/oauth2/token";
                //url = @"https://login.microsoftonline.com/9d40314f-1d37-457d-b900-21bc738c85bd/oauth2/token";
                string body = "grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret + "&resource=";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                HttpContent httpContent = new FormUrlEncodedContent(
                        new[]
                        {
                                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                                        new KeyValuePair<string, string>("client_id", clientId),
                                        new KeyValuePair<string, string>("client_secret", clientSecret),
                                        new KeyValuePair<string, string>("resource", "https://outlook.office365.com/EWS/Exchange.asmx"),
                        });

                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(body);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = reader.ReadToEnd();
                    JObject jObject = JObject.Parse(responseText);
                    token = jObject["access_token"].ToString();
                }
                return token;
            }
            catch (Exception ex)
            {
                //LogMessages(ex.ToString(), "Generating OAuth 2.0 Access Token", true);
            }
            return token;
        }
        

        private static void AccessEmails()
        {
            try
            {




                // Make the interactive token request
                //var authResult = await pca.AcquireTokenInteractive(ewsScopes).ExecuteAsync();

                // Configure the ExchangeService with the access token
                var ewsClient = new ExchangeService();
                ewsClient.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");

                string clientId = "2efcf754-471e-4a9a-85fd-f3dd08b62c35";
                //string secret = "67ded17d-5d85-4368-825e-6449f029773a";
                //string secret = "uE08Q~BgmekX41aZOWUmtI0D~KcPNASSRfUOQb6X";
                string secret = "Vm18Q~OCxKXyH86soQDlJKx2xHAIJ9X7jeulCbfs";
                string tenantId = "9d40314f-1d37-457d-b900-21bc738c85bd";
                string token = GenerateOAuth2Token(clientId,secret, tenantId);
                ewsClient.Credentials = new OAuthCredentials(token);
                
                ewsClient.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.PrincipalName, "opstest");
                ewsClient.HttpHeaders.Add("X-AnchorMailbox", "opstest@aims.org.za");

                // Make an EWS call
                var folders = ewsClient.FindFolders(WellKnownFolderName.Inbox, new FolderView(10));
                foreach (var folder in folders)
                {
                    Console.WriteLine($"Folder: {folder.DisplayName}");
                }
            }
            //catch (MsalException ex)
            //{
            //    Console.WriteLine($"Error acquiring access token: {ex}");
            //}
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }

        }

        public ExchangeCredentials Do_OAuth(ref string MailboxBeingAccessed, ref string AccountAccessingMailbox,
            string sAuthority, string sAppId, string sRedirectURL, string sServername, ref string sBearerToken, PromptBehavior oPromptBehavior)
        {
            string secret = "Vm18Q~OCxKXyH86soQDlJKx2xHAIJ9X7jeulCbfs";
            ExchangeCredentials oExchangeCredentials = null;
            try
            {
                //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                AssignCertificatesOffice365();

                // See // https://msdn.microsoft.com/en-us/library/office/dn903761(v=exchg.150).aspx
                // get authentication token
                string authority = "https://login.microsoftonline.com/9d40314f-1d37-457d-b900-21bc738c85bd";
                string clientID = sAppId;
                Uri clientAppUri = new Uri("https://login.microsoftonline.com/common/oauth2/nativeclient");
                string serverName = "https://outlook.office365.com";

                AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);
                PlatformParameters oPlatformParameters = new PlatformParameters(oPromptBehavior);

                //AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync(serverName, clientID, clientAppUri, oPlatformParameters).Result;
                AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync(serverName, new ClientCredential(clientID, secret)).Result;

                sBearerToken = authenticationResult.AccessToken;

                // Add authenticaiton token to requests
                oExchangeCredentials = new OAuthCredentials(authenticationResult.AccessToken);

                MailboxBeingAccessed = authenticationResult.UserInfo.DisplayableId;
                AccountAccessingMailbox = authenticationResult.UserInfo.DisplayableId;  // oAuth at this time does not support delegate or impersonation access - may need to change this in the future.

                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
                service.Credentials = new OAuthCredentials(authenticationResult.AccessToken);
                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;
                service.Url = new Uri(serverName + "/EWS/Exchange.asmx");
                service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "billings@aims.org.za");
                FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(2));
                string EmailUniqueID = "";
                foreach (var item in findResults)
                {
                    EmailUniqueID = item.Id.UniqueId;
                    Item mess = Item.Bind(service, EmailUniqueID);
                }

                /// Send an email 
                EmailMessage email = new EmailMessage(service);
                email.ToRecipients.Add("martitian@gmail.com");
                email.Subject = "HelloWorld from EWS";
                email.Body = new MessageBody("Test from EWS");
                email.Send();
                
                return oExchangeCredentials;
            }
            catch (Exception ex)
            {
                throw;
            }           
        }

        private void SendEmail()
        {

            string clientId = "2efcf754-471e-4a9a-85fd-f3dd08b62c35";
            string clientSecret = "Vm18Q~OCxKXyH86soQDlJKx2xHAIJ9X7jeulCbfs";
            string tenant = "9d40314f-1d37-457d-b900-21bc738c85bd";

            string authority = "https://login.microsoftonline.com/" + tenant;            
            string resource = "https://outlook.office365.com";
            string username = "opstest@aims.org.za";
            string password = "opst35t!2023";

            AuthenticationResult authenticationResult = null;
            AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);

            var userCred = new UserPasswordCredential(username, password);
            ClientCredential clientCred = new ClientCredential(clientId, clientSecret);

            string errorMessage = null;
            try
            {
                Console.WriteLine("Trying to acquire token");
                authenticationResult = authenticationContext.AcquireTokenAsync(resource, clientId, userCred).Result;
            }
            catch (AdalException ex)
            {
                errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\nInnerException : " + ex.InnerException.Message;
                }
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine("Failed: {0}" + errorMessage);
                return;
            }
            Console.WriteLine("\nMaking the protocol call\n");
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            service.Credentials = new OAuthCredentials(authenticationResult.AccessToken);
            service.TraceEnabled = true;
            service.TraceFlags = TraceFlags.All;
            service.Url = new Uri(resource + "/EWS/Exchange.asmx");
            EmailMessage email = new EmailMessage(service);
            email.ToRecipients.Add("martitian@Gmail.com");
            email.Subject = "Hello World from EWS - Brian";
            email.Body = new MessageBody("Hello World from EWS - Brian");
            email.Send();
        }
        #endregion
    }
}