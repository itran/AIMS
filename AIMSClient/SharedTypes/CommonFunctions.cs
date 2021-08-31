using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using AIMS.Common;
using System.Data;
using System.IO;
using Ionic.Zip;
using System.Xml;
using System.Diagnostics;
using Microsoft.Office.Interop;
using OfficeOpenXml;
using OfficeOpenXml.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Forms;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.Exchange.WebServices.Data;
using System.Configuration;
using System.Net.Mail;
using Microsoft.Exchange.WebServices.Autodiscover;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mime;

namespace AIMS.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonFunctions
    {
        #region "private declarations"
        private string _LoggedInUser = "";
        #endregion

        #region "public declarations / properties"
            public string  LoggedInUser
            {
                get { return _LoggedInUser = ""; }
                set { _LoggedInUser  = value; }
            }        
        #endregion
    
        public void DisplayMessage(CommonTypes.MessagType MsgType, string Msg)
        {
            switch (MsgType)
            {
                case CommonTypes.MessagType.Warning:
                     MessageBox.Show(Msg, "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case CommonTypes.MessagType.Success:
                    MessageBox.Show(Msg, "AIMS", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    break;
                case CommonTypes.MessagType.Error:
                    MessageBox.Show(Msg, "AIMS Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }

        public void DisplayMessage(CommonTypes.MessagType MsgType, string Msg, string ErrorMsg)
        {
            switch (MsgType)
            {
                case CommonTypes.MessagType.Warning:
                    MessageBox.Show(Msg, "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case CommonTypes.MessagType.Success:
                    MessageBox.Show(Msg, "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case CommonTypes.MessagType.Error:
                    MessageBox.Show(Msg, "AIMS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger(ErrorMsg);
                    break;
                default:
                    break;
            }
        }

        public void ServerError(System.Exception ex)
        {
            throw new System.Exception(ex.Message);
        }
      
        public DataTable GetCountries()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALCountries = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtCountries = new DataTable();
            try
            {
                dtCountries = DALCountries.GetCountries(); 
            }
            finally
            {
                DALCountries = null;
            }
            return dtCountries;
        }

        public DataTable GetSubFileTypes()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALSubFileTypes = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtSubFileTypes = new DataTable();
            try
            {
                dtSubFileTypes = DALSubFileTypes.GetSubFileTypes();
            }
            finally
            {
                DALSubFileTypes = null;
            }
            return dtSubFileTypes;
        }


        public DataTable GetPatientSubFiles(string PatientFileNo)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPatientSubFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPatientSubFile = new DataTable();
            try
            {
                dtPatientSubFile = DALPatientSubFiles.GetPatientSubFiles(PatientFileNo);
            }
            finally
            {
                DALPatientSubFiles = null;
            }
            return dtPatientSubFile;
        }

        public DataTable GetTitles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALTitles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtTitles = new DataTable();
            try
            {
                dtTitles = DALTitles.GetTitles(); 
            }
            finally
            {
                DALTitles = null;
            }
            return dtTitles;
        }

        public DataTable GetAddressTypes()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALAddressTypes = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAddressTypes = new DataTable();
            try
            {
                dtAddressTypes = DALAddressTypes.GetAddressTypes();
            }
            finally
            {
                DALAddressTypes = null;
            }
            return dtAddressTypes;
        }

        public DataTable GetFileAdministrators()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALFileAdministrators = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtFileAdministrators = new DataTable();
            try
            {
                dtFileAdministrators = DALFileAdministrators.GetFileAdministrators();
            }
            finally
            {
                DALFileAdministrators = null;
            }
            return dtFileAdministrators;
        }

        public DataTable GetPatientTypeOfFiles(string PatientFileNo)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPatientTypeOfFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPatientTypeOfFiles = new DataTable();
            try
            {
                dtPatientTypeOfFiles = DALPatientTypeOfFiles.GetPatientTypeOfFiles(PatientFileNo);
            }
            finally
            {
                DALPatientTypeOfFiles = null;
            }
            return dtPatientTypeOfFiles;
        }

        public DataTable GetEmailSenders(string loggedOnUser)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALEmailSenders = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtEmailSenders= new DataTable();
            try
            {
                dtEmailSenders = DALEmailSenders.GetEmailSenders(loggedOnUser);
            }
            finally
            {
                DALEmailSenders = null;
            }
            return dtEmailSenders;
        }

        public DataTable GetWorkbasketOperators()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALFileOperators = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtFileOperators = new DataTable();
            try
            {
                dtFileOperators = DALFileOperators.GetFileOperators();
            }
            finally
            {
                DALFileOperators = null;
            }
            return dtFileOperators;
        }

        
        public DataTable GetWorkbasketAdministrators()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALFileOperators = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtFileOperators = new DataTable();
            try
            {
                dtFileOperators = DALFileOperators.GetWorkbasketAdministrators();
            }
            finally
            {
                DALFileOperators = null;
            }
            return dtFileOperators;
        }


        public DataTable GetFileOperators()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALFileOperators = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtFileOperators = new DataTable();
            try
            {
                dtFileOperators = DALFileOperators.GetFileOperators();
            }
            finally
            {
                DALFileOperators = null;
            }
            return dtFileOperators;
        }

        public DataTable GetSupplierTypes()
        {
            DataTable dtSupplierTypes = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALSupplierTypes = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            
            try
            {
                dtSupplierTypes = DALSupplierTypes.GetSupplierTypes();
            }
            finally
            {
                DALSupplierTypes = null;
            }
            return dtSupplierTypes;
        }

        public DataTable GetSuppliers()
        {
            DataTable dtSupplier = new DataTable();
            DataTable dtSuppliers = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALSupplier = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            
            try
            {
                dtSupplier = DALSupplier.GetSuppliers();
                dtSuppliers = dtSupplier;
            }
            finally
            {
                //dtSupplier = null;
            }
            return dtSuppliers;
        }

        public DataTable GetSuppliers(string SupplierTypes)
        {
            DataTable dtSupplier = new DataTable();
            DataTable dtSuppliers = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALSupplier = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            try
            {
                dtSupplier = DALSupplier.GetSuppliers(SupplierTypes);
                dtSuppliers = dtSupplier;
            }
            finally
            {
                //dtSupplier = null;
            }
            return dtSuppliers;
        }


        public DataTable GetEmbassyDetails(string EmbassyID)
        {
            DataTable dtEmbassy = new DataTable();
            
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALEmbassy = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            try
            {
                dtEmbassy = DALEmbassy.GetEmbassyDetails(EmbassyID);
                
            }
            finally
            {
                //dtSupplier = null;
            }
            return dtEmbassy;
        }

        public DataTable GetTaskDetails(string PatientFileTaskID)
        {
            DataTable dtTask = new DataTable();

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALTask = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            try
            {
                dtTask = DALTask.GetTaskDetails(PatientFileTaskID);

            }
            finally
            {
                //dtSupplier = null;
            }
            return dtTask;
        }

        public DataTable GetAppointmentDetails(string AppointmentID)
        {
            DataTable dtTask = new DataTable();

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALTask = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            try
            {
                dtTask = DALTask.GetAppointmentDetails(AppointmentID);

            }
            finally
            {
                //dtSupplier = null;
            }
            return dtTask;
        }

        public DataTable GetAAOptions(string PatientID)
        {
            DataTable dtTask = new DataTable();

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALTask = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                dtTask = DALTask.GetAAOptions(PatientID);
            }
            finally
            {
                //dtSupplier = null;
            }
            return dtTask;
        }

        public DataTable GetSupplierDetails(string SupplierID)
        {
            DataTable dtSupplier = new DataTable();
            DataTable dtSuppliers = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALSupplier = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            try
            {
                dtSupplier = DALSupplier.GetSupplierDetails(SupplierID);
                dtSuppliers = dtSupplier;
            }
            finally
            {
                //dtSupplier = null;
            }
            return dtSuppliers;
        }

        public DataTable GetAddressDetails(Int64 AddressID)
        {
            DataTable dtAddressDetails = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALAddress = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            try
            {
                DALAddress.GetCountries();
                dtAddressDetails = DALAddress.GetAddressDetails(AddressID);
            }
            finally
            {
                DALAddress = null;
            }
            return dtAddressDetails;
        }

        public DataTable GetPaymentMethods()
        {
            DataTable dtPaymentMethods= new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALCommon = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            try
            {
                dtPaymentMethods = DALCommon.GetPaymentMethods();
            }
            finally
            {
                DALCommon = null;
            }
            return dtPaymentMethods;
        }


        public DataTable GetActiveFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALAllocatedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAllocatedFiles = new DataTable();
            try
            {
                dtAllocatedFiles = DALAllocatedFiles.GetActiveFiles();
            }
            finally
            {
                DALAllocatedFiles = null;
            }
            return dtAllocatedFiles; 
        }

        public DataTable GetAllocatedFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALAllocatedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAllocatedFiles = new DataTable();
            try
            {
                dtAllocatedFiles = DALAllocatedFiles.GetAllocatedFiles();
            }
            finally
            {
                DALAllocatedFiles = null;
            }
            return dtAllocatedFiles;
        }

        public DataTable GetAdminAllocatedFiles(string adminStaff)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALAllocatedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAllocatedFiles = new DataTable();
            try
            {
                dtAllocatedFiles = DALAllocatedFiles.GetAdminAllocatedFiles(adminStaff);
            }
            finally
            {
                DALAllocatedFiles = null;
            }
            return dtAllocatedFiles;
        }

        public DataTable GetAdminClosedFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALAllocatedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAllocatedFiles = new DataTable();
            try
            {
                dtAllocatedFiles = DALAllocatedFiles.GetAdminClosedFiles();
            }
            finally
            {
                DALAllocatedFiles = null;
            }
            return dtAllocatedFiles;
        }

        public DataTable GetSentFromAddressList()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALAllocatedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAllocatedFiles = new DataTable();
            try
            {
                dtAllocatedFiles = DALAllocatedFiles.GetSentFromAddressList();
            }
            finally
            {
                DALAllocatedFiles = null;
            }
            return dtAllocatedFiles;
        }

        public DataTable GetPendedFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPendedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPendedFiles = new DataTable();
            try
            {
                dtPendedFiles = DALPendedFiles.GetPendedFiles();
            }
            finally
            {
                DALPendedFiles = null;
            }
            return dtPendedFiles;
        }

        public DataTable GetHighCostFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPendedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPendedFiles = new DataTable();
            try
            {
                dtPendedFiles = DALPendedFiles.GetHighCostFiles();
            }
            finally
            {
                DALPendedFiles = null;
            }
            return dtPendedFiles;
        }

        public DataTable GetUnallocatedFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPendedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPendedFiles = new DataTable();
            try
            {
                dtPendedFiles = DALPendedFiles.GetUnallocatedFiles();
            }
            finally
            {
                DALPendedFiles = null;
            }
            return dtPendedFiles;
        }

        public DataTable GetAdminUnallocatedFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPendedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPendedFiles = new DataTable();
            try
            {
                dtPendedFiles = DALPendedFiles.GetAdminUnassignedFiles();
            }
            finally
            {
                DALPendedFiles = null;
            }
            return dtPendedFiles;
        }

        /// <summary>
        /// Method to resolve cyclic email cc'ed issues
        /// </summary>
        /// <param name="emailTo"></param>
        /// <param name="emailCC"></param>
        /// <param name="globalTeam"></param>
        /// <returns></returns>
        public string cleanEmailRecipient(ref string emailTo, ref string emailCC, string globalTeam)
        {
            if (!globalTeam.Trim().Equals(""))
            {
                string[] globalTeamEmails = globalTeam.Split(new Char[] { ';' });
                foreach (string globalEmail in globalTeamEmails)
                {
                    if (!globalEmail.Trim().Equals(""))
                    {
                        emailTo = emailTo.ToLower().Replace(globalEmail.ToLower(), "");
                        emailCC = emailCC.ToLower().Replace(globalEmail.ToLower(), "");
                    }
                }

            }
            return "";
        }
        public DataTable GetAllWorkbasketFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPendedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPendedFiles = new DataTable();
            try
            {
                dtPendedFiles = DALPendedFiles.Get_AIMS_Operator_Work("<All Workbaskets>");
            }
            finally
            {
                DALPendedFiles = null;
            }
            return dtPendedFiles;
        }

        public DataTable GetAllAdminWorkbasketFiles()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPendedFiles = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPendedFiles = new DataTable();
            try
            {
                dtPendedFiles = DALPendedFiles.Get_AIMS_Administrator_Work("<All Workbaskets>");
            }
            finally
            {
                DALPendedFiles = null;
            }
            return dtPendedFiles;
        }

        public DataTable GetWorkAllocations()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtWorkAllocated = new DataTable();
            try
            {
                dtWorkAllocated = DALWorkAllocated.GetWorkAllocations();
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtWorkAllocated;
        }

        public DataTable GetAdminWorkAllocations()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtWorkAllocated = new DataTable();
            try
            {
                dtWorkAllocated = DALWorkAllocated.GetAdminWorkAllocations();
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtWorkAllocated;
        }

        public DataTable GetUrgentEmails()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtUrgentEmails = new DataTable();
            try
            {
                dtUrgentEmails = DALWorkAllocated.GetUrgentEmails();
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtUrgentEmails;
        }

        public DataTable Get_AIMS_Mailboxes(string LoggedInUser)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Mailboxes(LoggedInUser);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }

        public DataTable Get_AIMS_Mailbox_Emails(Int32 MailboxID, string LoggedInUser, string MailSearchKeyword)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Mailbox_Emails(MailboxID, LoggedInUser,MailSearchKeyword);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }

        public DataTable Get_AIMS_Email_Attachments(string  EmailID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Email_Attachments(EmailID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }

        public DataTable Get_AIMS_Operator_Work(string UserLoggedUserID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Operator_Work(UserLoggedUserID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }

        public DataTable Get_AIMS_Administrator_Work(string UserLoggedUserID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Administrator_Work(UserLoggedUserID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }

        public DataTable Get_AIMS_Workbasket_Audit(string UserLoggedUserID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Workbasket_Audit(UserLoggedUserID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }

        public DataTable Get_AIMS_Admin_Workbasket_Audit(string UserLoggedUserID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Admin_Workbasket_Audit(UserLoggedUserID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }
        public DataTable Get_AIMS_TransportCases()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALTransportCases = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSTransportCases = new DataTable();
            try
            {
                dtAIMSTransportCases = DALTransportCases.Get_AIMS_TransportCases();
            }
            finally
            {
                DALTransportCases = null;
            }
            return dtAIMSTransportCases;
        }

        public DataTable Get_AIMS_OverdueTasks()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALTransportCases = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSTransportCases = new DataTable();
            try
            {
                dtAIMSTransportCases = DALTransportCases.Get_AIMS_OverdueTasks();
            }
            finally
            {
                DALTransportCases = null;
            }
            return dtAIMSTransportCases;
        }

        public DataTable Get_My_Instant_Messages(string UserLoggedUserID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALMyInstantMessages = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSInstantMessages = new DataTable();
            try
            {
                dtAIMSInstantMessages = DALMyInstantMessages.Get_My_Instant_Messages(UserLoggedUserID);
            }
            finally
            {
                DALMyInstantMessages = null;
            }
            return dtAIMSInstantMessages;
        }

        public DataTable Get_My_Instant_Messages_Audit(string UserLoggedUserID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALMyInstantMessages = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSInstantMessages = new DataTable();
            try
            {
                dtAIMSInstantMessages = DALMyInstantMessages.Get_My_Instant_Messages_Audit(UserLoggedUserID);
            }
            finally
            {
                DALMyInstantMessages = null;
            }
            return dtAIMSInstantMessages;
        }

        public DataTable Get_My_Tasks(string UserLoggedUserID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALTasks = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtTasks = new DataTable();
            try
            {
                dtTasks = DALTasks.Get_My_Tasks(UserLoggedUserID);
            }
            finally
            {
                DALTasks = null;
            }
            return dtTasks;
        }

        public DataTable Get_Patient_File_Operator(string PatientFileNo)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALPatientFileOperator = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtPatientFileOperator = new DataTable();
            try
            {
                dtPatientFileOperator = DALPatientFileOperator.Get_Patient_File_Operator(PatientFileNo);
            }
            finally
            {
                DALPatientFileOperator = null;
            }
            return dtPatientFileOperator;
        }

        public DataTable Get_AIMS_Active_Users()
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALAimsActiveUsers = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAimsActiveUsers = new DataTable();
            try
            {
                dtAimsActiveUsers = DALAimsActiveUsers.Get_AIMS_Active_Users();
            }
            finally
            {
                DALAimsActiveUsers = null;
            }
            return dtAimsActiveUsers;
        }


        public DataTable Get_AIMS_Patient_Email_Docs(string PatientEmailEnquiryID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Patient_Email_Docs(PatientEmailEnquiryID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }

        public DataTable Get_AIMS_Patient_Sent_Email_Docs(string PatientSentEmailID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Patient_Sent_Email_Docs(PatientSentEmailID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }


        public bool AIMS_Email_Delete(string EmailID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            bool bEmailDelete = false;
            try
            {
                bEmailDelete = DALWorkAllocated.AIMS_Email_Delete(EmailID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return bEmailDelete;
        }

        public DataTable Get_AIMS_Email_Info(string EmailID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                dtAIMSMailboxes = DALWorkAllocated.Get_AIMS_Email_Info(EmailID);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtAIMSMailboxes;
        }

        public bool AIMS_Lock_Email(string EmailID, string UserLoggedOn, string LockEmail, string EmailReadYN)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            bool bEmailDelete = false;
            try
            {
                bEmailDelete = DALWorkAllocated.AIMS_Lock_Email(EmailID, UserLoggedOn, LockEmail, EmailReadYN);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return bEmailDelete;
        }

        public bool AIMS_Email_Read(string PatientEmailEnquiryID)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALEmailRead = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            bool bEmailRead = false;
            try
            {
                bEmailRead = DALEmailRead.AIMS_Email_Read(PatientEmailEnquiryID);
            }
            finally
            {
                DALEmailRead = null;
            }
            return bEmailRead;
        }

        public bool AIMS_Email_Processed(string PatientEmailEnquiryID, string LoggedInUser)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALEmailRead = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            bool bEmailRead = false;
            try
            {
                bEmailRead = DALEmailRead.AIMS_Email_Processed(PatientEmailEnquiryID, LoggedInUser);
            }
            finally
            {
                DALEmailRead = null;
            }
            return bEmailRead;
        }

        public DataTable Get_AIMS_Email_DocTypes(string MailBoxName)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtEmailDocTypes = new DataTable();
            try
            {
                dtEmailDocTypes = DALWorkAllocated.Get_AIMS_Email_DocTypes(MailBoxName);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtEmailDocTypes;
        }

        public DataTable Get_AIMS_Email_Attachment_Mailbox(string EmailAttachmentId)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALWorkAllocated = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtEmailDocTypes = new DataTable();
            try
            {
                dtEmailDocTypes = DALWorkAllocated.Get_AIMS_Email_Attachment_Mailbox(EmailAttachmentId);
            }
            finally
            {
                DALWorkAllocated = null;
            }
            return dtEmailDocTypes;
        }



        public DataTable Get_AIMS_Reasons(string ReasonTypeCD)
        {
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALReasons = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtReasons = new DataTable();
            try
            {
                dtReasons = DALReasons.Get_AIMS_Reasons(ReasonTypeCD);
            }
            finally
            {
                DALReasons = null;
            }
            return dtReasons;
        }

        public void ErrorLogger(string ErrorMessage)
        {
            string fLogName = "";
            try
            {
                if(!Directory.Exists(@"C:\AIMS Recorder"))
                {
                    Directory.CreateDirectory(@"C:\AIMS Recorder");
                }

                fLogName = @"C:\AIMS Recorder\AIMS Recorder - " + System.DateTime.Today.ToString("dd-MMM-yyyy") + ".log";
                
                StreamWriter sw;
                sw = File.AppendText(fLogName);
                sw.WriteLine("AIMS Recorder Error Time    - " + System.DateTime.Now.TimeOfDay);
                sw.WriteLine("AIMS Recorder Error Message - " + ErrorMessage);
                sw.WriteLine("---------------------------------------");
                sw.Flush();
                sw.Close();
            }
            finally
            {
            }
        }
        
        public bool SendNotifyEmail(string PatientFileNo , string InvoiceID, string userName )
        {
            bool bResults = false;
            AIMSUtility.AIMS.Utility.eMailer oEmailer = new AIMSUtility.AIMS.Utility.eMailer();

            string sEmailBody = SPCostExceededEmailBody(PatientFileNo, InvoiceID, userName);
            try
            {
                if (sEmailBody !="")
                {
                    oEmailer.Connectionstring = " Provider = SQLOLEDB; Data Source = DC1; Initial Catalog = AIMS; User ID = aims; Password = aims1**";
                    bResults = oEmailer.SendEmailNotify(sEmailBody);    
                }                
            }
            catch (System.Exception ex)
            {
                bResults = false;
            }
            return bResults;
        }

        public bool SendEmail(string EmailBody, string EmailFrom,  string EmailFromName, string EmailSubject, string EmailTo, string EmailAttachments)
        {
            bool bResults = false;
            AIMSUtility.AIMS.Utility.eMailer oEmailer = new AIMSUtility.AIMS.Utility.eMailer();
            string sEmailBody = EmailBody;
            try
            {
                ErrorLogger("Inside SendEmail Function Start ");

                bResults = oEmailer.SendEmail(sEmailBody, EmailFrom, EmailFromName, EmailSubject, EmailTo, EmailAttachments, true,"", "");
                ErrorLogger("Inside SendEmail Function Complete");
                
            }
            catch (System.Exception ex)
            {
                ErrorLogger("Inside SendEmail - Error - " + ex.ToString());
                bResults = false;
            }
            return bResults;
        }

        private string GetWhiteListedEmailList(ref string emailTo, string whiteListedEmails)
        {
            string[] emailwhiterecipients = whiteListedEmails.Split(new Char[] { ';' });
            foreach (string emailaddress in emailwhiterecipients)
            {
                if (!string.IsNullOrEmpty(emailaddress) && emailTo.Trim().ToUpper().Contains(emailaddress.Trim().ToUpper().ToString()))
                {
                    return "whitelisted-email-address";
                }
            }
            return "";

            //// #BM - 28 February 2021 - Sunday 10:55PM
            ////emailTo = emailTo.Trim();
            ////string[] emailrecipients = emailTo.Split(new Char[] { ';' });
            ////string whiteListEmails = "";
            ////foreach (string emailaddress in emailrecipients)
            ////{
            ////    if (!emailaddress.Trim().Equals("") && whiteListedEmails.Trim().ToUpper().Contains(emailaddress.Trim().ToUpper().ToString()))
            ////    {
            ////        whiteListEmails += emailaddress + ";";
            ////        emailTo = emailTo.Replace(emailaddress, "");
            ////    }
            ////}

            ////if (whiteListEmails.EndsWith(";"))
            ////{
            ////    whiteListEmails = whiteListEmails.Trim().Substring(0, whiteListEmails.Trim().Length - 1);
            ////    emailTo = emailTo.Replace(whiteListEmails, "");
            ////}

            ////return whiteListEmails;
        }

        public bool SendEmail(string EmailBody, string EmailFrom, string EmailFromName, string EmailSubject, string EmailTo, string EmailAttachments, bool KillFiles, string EmailCC, string EmailBcc, string patientFileNo, string patientDateOfBirth, bool protectAttachment)
        {
            bool bResults = false;
            AIMSUtility.AIMS.Utility.eMailer oEmailer = new AIMSUtility.AIMS.Utility.eMailer();
            string sEmailBody = EmailBody;
            try
            {
                DataTable dtEmailAtt = GetLimitationCodeValue("PASSWORD_PROTECT_ATTACHMENT");
                string protectedAttachments = "";
                string zipFile = "";
                bool bContinue = true;
                if (dtEmailAtt.Rows.Count > 0)
                {
                    protectedAttachments = dtEmailAtt.Rows[0]["LIMITATION_VALUE"].ToString();
                }

                dtEmailAtt = GetLimitationCodeValue("EMAIL_ATTACHMENT_PROTECTION_WHITE_LIST");
                string whiteListEmailBypass = "";
                string whiteListedMails = "";
                bool emailWhiteListedtoBypassPasswordProtection = false;
                if (dtEmailAtt.Rows.Count > 0)
                {
                    EmailTo = EmailTo.Trim();
                    whiteListEmailBypass = dtEmailAtt.Rows[0]["LIMITATION_VALUE"].ToString();
                    
                    if (!string.IsNullOrEmpty(whiteListEmailBypass))
                    {
                        whiteListedMails = "";
                        whiteListedMails = GetWhiteListedEmailList(ref EmailTo, whiteListEmailBypass);

                        if (!string.IsNullOrEmpty(whiteListedMails))
                        {
                            protectAttachment = false;
                            protectedAttachments = "N";
                        }
                    }
                }

                if (protectAttachment && (protectedAttachments.Equals("Y") | protectedAttachments.Equals("YES")))
                {
                    if (!EmailAttachments.Trim().Equals(""))
                    {
                        dtEmailAtt = GetLimitationCodeValue("PASSWORD_PROTECT_FILE_BYPASS");
                        string passwordProtectedFileBypass = "";
                        if (dtEmailAtt.Rows.Count > 0)
                        {
                            passwordProtectedFileBypass = dtEmailAtt.Rows[0]["LIMITATION_VALUE"].ToString();
                        }

                        //if (!patientFileNo.Equals("99/9999") && !patientFileNo.Equals("88/8888") && !patientFileNo.Equals("77/7777") && !patientFileNo.Equals("66/6666"))
                        if (!passwordProtectedFileBypass.Contains(patientFileNo) || emailWhiteListedtoBypassPasswordProtection)
                        {
                            bContinue = PasswordProtectEmailAttachments(EmailAttachments, patientFileNo, patientDateOfBirth, ref zipFile);
                            //if (File.Exists(zipFile))
                            //{
                                EmailAttachments = zipFile;
                            //}   
                        }
                    }                    
                }

                if (bContinue)
                {
                    //bResults = oEmailer.SendEmail(sEmailBody.Replace("5.4pt", "0pt"), EmailFrom, EmailFromName, EmailSubject, EmailTo, EmailAttachments, KillFiles, EmailCC, EmailBcc);
                    bResults =    EWSSendEmailNow(sEmailBody.Replace("5.4pt", "0pt"), EmailFrom, EmailFromName, EmailSubject, EmailTo, EmailAttachments, KillFiles, EmailCC, EmailBcc);
                    //if (true)
                    //{
                    //    bResults = oEmailer.SendEmail(sEmailBody.Replace("5.4pt", "0pt"), EmailFrom, EmailFromName, EmailSubject, EmailTo, EmailAttachments, KillFiles, EmailCC, EmailBcc);

                    //}
                }
                else
                {
                    bResults = false;
                }
                
                killProtectedFiles(zipFile);

                //if (File.Exists(zipFile))
                //{
                //    try
                //    {
                //        File.SetAttributes(zipFile, FileAttributes.Normal);
                //        File.Delete(zipFile);
                //    }
                //    catch (System.Exception ex)
                //    {
                //        ErrorLogger("DELETING ZIP FILE ERROR - " + ex.ToString());
                //    }
                //}
            }
            catch (System.Exception ex)
            {
                ErrorLogger("Inside SendEmail - Error - " + ex.ToString());
                bResults = false;
            }
            return bResults;
        }

        protected bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void killProtectedFiles(string attachedFiled)
        {
            string[] emailAttachments = attachedFiled.Split(new Char[] { ';' });
            foreach (string attachment in emailAttachments)
            {
                if (!attachment.Trim().Equals(""))
                {
                    if (attachment.Contains("_protected"))
                    {
                        try
                        {
                            System.GC.Collect();
                            System.GC.WaitForPendingFinalizers(); 
                            File.SetAttributes(attachment, FileAttributes.Normal);
                            File.Delete(attachment);
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                }
            }
        }

        public void killProtectedFiles(string folderPath, bool allFiles)
        {
            string[] emailAttachments = Directory.GetFiles(folderPath, "*_protected_*", SearchOption.TopDirectoryOnly);
            foreach (string attachment in emailAttachments)
            {
                try
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.SetAttributes(attachment, FileAttributes.Normal);
                    File.Delete(attachment);
                }
                catch (System.Exception ex)
                {
                }            
            }
        }

        //private void killProtectedFiles()
        //{
        //    string[] emailAttachments = attachedFiled.Split(new Char[] { ';' });
        //    foreach (string attachment in emailAttachments)
        //    {
        //        if (!attachment.Trim().Equals(""))
        //        {
        //            if (attachment.Contains("_protected"))
        //            {
        //                try
        //                {
        //                    File.SetAttributes(attachment, FileAttributes.Normal);
        //                    File.Delete(attachment);
        //                }
        //                catch (System.Exception ex)
        //                {
        //                }
        //            }
        //        }
        //    }
        //}

        public bool PasswordProtectEmailAttachments(string emailAttachments, string patientFileNo, string patientDateOfBirth, ref string passwordprotectedFile)
        {
            try
            {
                passwordprotectedFile = lockzipFile(emailAttachments, patientDateOfBirth, patientFileNo);
                if (!passwordprotectedFile.Equals(""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                ErrorLogger("File - Locking ERROR: " + ex.ToString());
                return false;
            }
        }

        private string lockzipFile(string attachmentList, string password, string patientFileNo)
        {
            string Emailattachments = "";
            ProcessEmailAttachments(attachmentList,ref  Emailattachments, password);
            return Emailattachments;

            /*
            string path = Application.StartupPath;
            string ZipFileName = "AIMS - " + System.DateTime.Now.ToString("dd-MMM-yyyy HH.mm.ss") + ".zip";
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = password;

                string[] emailAttachments = attachmentList.Split(new Char[] { ';' });
                foreach (string attachment in emailAttachments)
                {
                    if (!attachment.Trim().Equals(""))
                    {
                        if (File.Exists(attachment))
                        {
                            zip.AddFile(attachment, @"AIMS");
                        }
                    }
                }
                zip.Comment = "AIMS-REFERENCE [" + patientFileNo + "] - File Created at " + System.DateTime.Now.ToString("G");
                zip.Save(Path.Combine(path, ZipFileName ));                
            }
            return (Path.Combine(path, ZipFileName));
            */
        }

        public string EmailSignature(string loggedInUser, bool includePasswordNote)
        {
            string emailSignature = "";
            AIMS.DAL.UserDAL DALCommon = new AIMS.DAL.UserDAL();
            DataTable dtUserDetails = DALCommon.GetUserDetail(loggedInUser);
            if (dtUserDetails.Rows.Count> 0)
	        {
                string fullName = dtUserDetails.Rows[0]["USER_FULL_NAME"].ToString();
                string department = dtUserDetails.Rows[0]["DEPARTMENT"].ToString();
                string jobtitle = dtUserDetails.Rows[0]["JOB_TITLe"].ToString();
                string email = dtUserDetails.Rows[0]["USER_EMAIL"].ToString();
                string email_disclaimer = "";
                string password_note = "";

                switch (department)
                {
                    case "Operations":
                        email = "operations@aims.org.za";
                        break;
                    case "Administration":
                        email = "admin@aims.org.za";
                        break;
                    case "Finance":
                        email = "Finance@aims.org.za";
                        break;
                    case "Finance Department":
                        email = "douglas@aims.org.za";
                        break;
                    default:
                        email = "operations@aims.org.za";
                        break;
                }

                DataTable dtLimitationVal = GetLimitationCodeValue("EMAIL_DISCLAIMER");
                if (dtLimitationVal.Rows.Count>0)
                {
                    email_disclaimer = dtLimitationVal.Rows[0]["LIMITATION_VALUE"].ToString();
                }
                dtLimitationVal.Dispose();

                if (includePasswordNote)
                {
                    dtLimitationVal = GetLimitationCodeValue("PASSWORD_NOTE");
                    if (dtLimitationVal.Rows.Count > 0)
                    {
                        password_note = dtLimitationVal.Rows[0]["LIMITATION_VALUE"].ToString();
                    }
                    dtLimitationVal.Dispose();   
                }

                emailSignature = EmailSignature(fullName, jobtitle, department, email, email_disclaimer, password_note, includePasswordNote);
	        }
            dtUserDetails.Dispose();

            return emailSignature;
        }

        private string EmailSignature(string fullname, string jobtitle, string department, string emailaddress, string emaildisclaimer, string passwordnote, bool includePasswordNote)
        {
            string passwordNote = "<p><table width='100%' style='font-family:Calibri;font-size:16px'><tr><td><b>" + passwordnote + "</b></td></tr></table></p>";
            if (!includePasswordNote)
                passwordNote = "";

            passwordNote += "<p><table width='50%' style='font-family:Calibri;font-size:16px'>" +
                            "<tr><td>Kind Regards,</td></tr><tr><td>" + fullname + "</td></tr>" +
                            "<tr><td>" + jobtitle + "</td></tr>" +
                            "<tr><td><b>" + department + " - Department</b></td></tr>" +
                            "<tr><td><b>E-mail:</b></td><td>" + emailaddress + "</td></tr>" +
                            "<tr><td><b>Website:</b></td><td>www.aims.org.za</td></tr>" +
                            "<tr><td><b>Tel:</b></td><td>+27 (0) 11 783 0135</td></tr>" +
                            "<tr><td><b>Fax:</b></td><td>+27 (0) 11 463 3583</td></tr>" +
                            "<tr><td><b>Fax to Mail:</b></td><td>+27 (0) 86 457 0764</td></tr>" +
                            "</table></p>" +
                            "<p><table align='left'><tr><td>##SIGNATURE_LOGO##</td></tr></table></p>" +  emaildisclaimer;

            return passwordNote;
        }
        public bool EmailInvoice(string PatientFileNo, string InvoiceID, string userName)
        {
            bool bResults = false;
            AIMSUtility.AIMS.Utility.eMailer oEmailer = new AIMSUtility.AIMS.Utility.eMailer();
            string sEmailBody = "";
            try
            {
                if (sEmailBody != "")
                {
                    bResults = oEmailer.SendEmailNotify(sEmailBody);
                }
            }
            catch (System.Exception ex)
            {
                bResults = false;
            }
            return bResults;
        }

        public string SPCostExceededEmailBody(string PatientFileNo, string InvoiceID, String UserName)
        {            
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL DALCommon = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            DataTable dtSPCostExceededData = DALCommon.GetSPExceedCostInfo(PatientFileNo, InvoiceID, UserName);
            string EmailBody = "";
            
            if (dtSPCostExceededData.Rows.Count> 0)
            {
                EmailBody = "<html>" +
                            "<head>" +
                            "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left}</style>" +
                            "</head>" +
                            "<body>" +
                            "    <br>" +
                            "    <br>" +
                            "    <br>" +
                            "    <br>" +
                            "    <table width=50% cellpadding=2 cellspacing=1 align=center>" +
                            "       <tr>" +
                            "<td bgcolor=#ffffff colspan=4 align=center>###LOGO###</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td colspan=4 align=left bgcolor=lightgrey>" +
                            "<center><b><font color=green size=2 >Service Provider Cost Limit Exceeded</font></b></center>" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=lightgrey valign=bottom colspan=4><b>Patient File Details</b></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient File No</td>" +
                            "<td colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + dtSPCostExceededData .Rows[0]["PATIENT_FILE_NO"].ToString() + "</b></font></td> " +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient Name</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + dtSPCostExceededData.Rows[0]["PATIENT_NAME"].ToString() + "</b></font></td> " +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=lightgrey valign=bottom colspan=4><b>Guarantor Details</b></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient Guarantor Name</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + dtSPCostExceededData.Rows[0]["guarantor_name"].ToString() + "</b></font></td> " +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient Guarantor Amount</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>" + dtSPCostExceededData.Rows[0]["patient_guarantor_amount"].ToString() + "</b></font></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=lightgrey valign=bottom colspan=4><b>Service Provider Details</b></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Service Provider Procedure(Supplier Type)</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + dtSPCostExceededData.Rows[0]["supplier_type_desc"].ToString() + "</b></font></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Service Provider Invoice No</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + dtSPCostExceededData.Rows[0]["invoice_no"].ToString() + "</b></font></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Service Provider Invoice Date</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + dtSPCostExceededData.Rows[0]["invoice_date"].ToString() + "</b></font></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Procedure (Supplier Type) Cost Limit</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=green size=2.5><b>" + dtSPCostExceededData.Rows[0]["cost_limit"].ToString() + "</b></font></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Service Provider Invoice Amount</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>" + dtSPCostExceededData.Rows[0]["invoice_amount_received"].ToString() + "</b></font></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=lightgrey valign=bottom colspan=4><b>Date and User Information</b></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Invoice Captured By</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=green size=2><b>" + dtSPCostExceededData.Rows[0]["CAPTURE_USER"].ToString() + "</b></font></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Invoice Capture Date</td>" +
                            "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=green size=2><b>" + System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss") + "</b></font></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td bgcolor=#ffffff colspan=4>&nbsp; </td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td colspan=4 align=left bgcolor=lightgrey>" +
                            "<center><b><font color=green size=2 >&nbsp;</font></b></center>" +
                            "</td>" +
                            "</tr>" +
                            "</table>" +
                            "<br>" +
                            "<br>" +
                            "</body>" +
                            "</html>";                
            }            
            return EmailBody;
        }


        public bool ValidPatientFileNo(string PatientFileNo) 
        {
            DataTable dtPatientExist = new DataTable();
            Int64 SelectedPatientID = 0;
            bool Returnvalue = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                
                if (PatientFileNo.Trim().Length > 0)
                {
                    dtPatientExist = commonFuncsDAL.ValidPatientFileNo(PatientFileNo);
                    Returnvalue = dtPatientExist.Rows.Count > 0 ? true : false;
                }
                else
                {
                    Returnvalue = false;
                }
            }
            catch (System.Exception ex)
            {
                Returnvalue = false;
            }
            return Returnvalue;
        }

        public bool AddPatientFileEmail(string PatientFileNo, string Email_ID, ref string PatientEmailEnquiryID, string UrgentEmail, string File13Query, string IndexedBy, string MailBoxName)
        {
            bool Returnvalue = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                Returnvalue = commonFuncsDAL.AddPatientFileEmail(PatientFileNo, Email_ID, ref PatientEmailEnquiryID, UrgentEmail, File13Query, IndexedBy, MailBoxName);
            }
            catch (System.Exception ex)
            {
                Returnvalue = false;
            }
            return Returnvalue;
        }

        public DataTable CheckGuaranteeAuth(string UserID, string GuaranteeAmount, string GuarantorID)
        {
            DataTable dtUserAuth = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dtUserAuth = commonFuncsDAL.CheckGuaranteeAuth(UserID, GuaranteeAmount, GuarantorID);
            }
            finally
            {
                
            }
            return dtUserAuth;
        }

        public bool EmailIndexedFlag(string Email_ID)
        {
            bool Returnvalue = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                Returnvalue = commonFuncsDAL.EmailIndexedFlag( Email_ID);
            }
            catch (System.Exception ex)
            {
                Returnvalue = false;
            }
            return Returnvalue;
        }

        public double GetPODDirectorySize(string rootdir, ref string DirCheckError) 
        {
            double DirectorySize = 0;
            long DirSize = 0;
            try
            {
                DirectoryInfo[] DI = new DirectoryInfo(rootdir).GetDirectories("*.*", SearchOption.AllDirectories);
                FileInfo[] FI = new DirectoryInfo(rootdir).GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo F1 in FI)
                {
                    DirSize += F1.Length;
                }
                Console.WriteLine("Total Size of {0} is {1} bytes", rootdir, DirSize);
                DirectorySize = DirSize;
            }
            catch (DirectoryNotFoundException dEX)
            {
                DirSize = 0;
                DirCheckError = dEX.Message;
            }
            return DirectorySize;
        }

        /// <summary>
        ///     Returns POD Details 
        ///         1. Current POD Folders Counter(Sequencial)
        ///         2. Current Disk Drive Letter
        /// </summary>
        /// <returns></returns>
        public DataTable GetPODData(string emailID)
        {
            DataTable dtPODDetails = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dtPODDetails = commonFuncsDAL.GetPODData(emailID);
            }
            finally
            { 
            }
            return dtPODDetails;
        }



        public DataTable GetEmbassies()
        {
            DataTable dtEmbassies = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dtEmbassies = commonFuncsDAL.GetEmbassies();
            }
            finally
            { 
            }
            return dtEmbassies;
        }

        public DataTable GetLimitationCodeValue(string LimitationCode) 
        {
            DataTable dtPODDetails = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dtPODDetails = commonFuncsDAL.GetLimitationCodeValue(LimitationCode);
            }
            finally
            {
            }
            return dtPODDetails;
        }

        public DataTable GetEmailIndexFileLocation(string EmailAttachmentID)
        {
            DataTable dtPODDetails = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dtPODDetails = commonFuncsDAL.GetEmailIndexFileLocation(EmailAttachmentID);
            }
            finally
            {
            }
            return dtPODDetails;
        }

        public DataTable GetReligion()
        {
            DataTable dtReligion = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dtReligion = commonFuncsDAL.GetReligion();
            }
            finally
            {
            }
            return dtReligion;
        }

        public bool EmailAttachmentPODDelivery(string EmailAttachmentFile, string DocTypeID, string PatientEnquiryID) {
            bool returnVal = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            returnVal = commonFuncsDAL.EmailAttachmentPODDelivery(EmailAttachmentFile, DocTypeID, PatientEnquiryID);
            returnVal = true;
            return returnVal;
        }

        public bool EmailAttachmentReclassify(string NewDocTypeID, string EmailAttachmentID)
        {
            bool returnVal = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            returnVal = commonFuncsDAL.EmailAttachmentReclassify(NewDocTypeID, EmailAttachmentID);
            returnVal = true;
            return returnVal;
        }

        public bool EmailAttachmentDelete(string EmailAttachmentID)
        {
            bool returnVal = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            returnVal = commonFuncsDAL.EmailAttachmentDelete(EmailAttachmentID);
            returnVal = true;
            return returnVal;
        }

        public bool EmailSentAttachmentPODDelivery(string EmailAttachmentFile,  string PatientSentEmailID)
        {
            bool returnVal = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            returnVal = commonFuncsDAL.EmailSentAttachmentPODDelivery(EmailAttachmentFile, PatientSentEmailID);
            returnVal = true;
            return returnVal;
        }

        public bool Clear_My_Instant_Messages(string UserID)
        {
            bool returnVal = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            returnVal = commonFuncsDAL.Clear_My_Instant_Messages(UserID);
            returnVal = true;
            return returnVal;
        }

        public void UpdateMailBoxPODCounter(string MailBoxID, string PODCounter)
        {
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                commonFuncsDAL.UpdateMailBoxPODCounter(MailBoxID, PODCounter);
            }
            finally
            {
            }
        }

        public bool SaveSentEmail(ref string PatientSentEmailID, string PatientFileNo, string EmailSentTo, string EmailFromID, string PatientEnquiryID, string EmailSubject, string LoggedOnUser, string EmailToCC)
        {
            bool bReturn = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                commonFuncsDAL.SaveSentEmail(ref PatientSentEmailID, PatientFileNo, EmailSentTo, EmailFromID, PatientEnquiryID, EmailSubject, LoggedOnUser, EmailToCC);
                bReturn = true;
            }
            finally
            {
            }
            return bReturn;
        }

        public bool ReIndexPatientFile(string PatientEmaiEnquirylID, string PatientFileNo)
        {
            bool bReturn = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                commonFuncsDAL.ReIndexPatientFile(PatientEmaiEnquirylID, PatientFileNo, "");
                bReturn = true;
            }
            finally
            {
            }
            return bReturn;
        }

        public bool RemovePatientFileEmail(string PatientEmaiEnquirylID)
        {
            bool bReturn = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                commonFuncsDAL.RemovePatientFileEmail(PatientEmaiEnquirylID);
                bReturn = true;
            }
            finally
            {
            }
            return bReturn;
        }

        public bool RemovePatientFileDoc(string PatientFileNo, string DocumentID, string DocumentName)
        {
            bool bReturn = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                commonFuncsDAL.RemovePatientFileDoc(PatientFileNo, DocumentID, DocumentName);
                bReturn = true;
            }
            finally
            {
            }
            return bReturn;
        }

        public DataSet GetPatientSentEmails(string PatientFileNo)
        {
            bool bReturn = false;
            DataSet dsSet = new DataSet();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dsSet =  commonFuncsDAL.GetPatientSentEmails(PatientFileNo);
            }
            finally
            {
            }
            return dsSet;
        }


        public bool ValidEmailAddress(string emailAddress)
        {
            //create Regular Expression Match pattern object
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$");
            //boolean variable to hold the status
            bool isValid = false;
            if (string.IsNullOrEmpty(emailAddress.ToLower()))
            {
                isValid = false;
                if (emailAddress.ToLower().EndsWith(".info"))
                {
                    isValid = true;    
                }

                if (emailAddress.ToLower().EndsWith(".solutions"))
                {
                    isValid = true;
                }
            }
            else
            {
                isValid = myRegex.IsMatch(emailAddress.ToLower());
                if (emailAddress.ToLower().EndsWith(".info"))
                {
                    isValid = true;
                }

                if (emailAddress.ToLower().EndsWith(".solutions"))
                {
                    isValid = true;
                }
            }

            if (emailAddress.ToLower().EndsWith(".surgery"))
            {
                isValid = true;
            }

            if (emailAddress.ToLower().EndsWith(".info"))
            {
                isValid = true;
            }

            if (emailAddress.ToLower().EndsWith(".solutions"))
            {
                isValid = true;
            }

            if (!isValid)
            {
                string emailEndsWith = emailAddress.ToLower().Substring(emailAddress.LastIndexOf("."));
                DataTable dtemailTables = GetLimitationCodeValue("VALID_EMAIL_DOMAIN");
                if (dtemailTables.Rows.Count >0)
                {
                    string validEmailDomains = "";
                    validEmailDomains = dtemailTables.Rows[0]["LIMITATION_VALUE"].ToString();
                    if (!string.IsNullOrEmpty(validEmailDomains))
                    {
                        isValid = validEmailDomains.ToLower().Contains(emailEndsWith.ToLower());
                    }
                }
            }

            //return the results
            return isValid;
        }

        public bool CreatePendedNewFile(ref string PatientFileNo, string LoggedOnUser, string PendDate)
        {
            bool Returnvalue = false;
            try
            
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                Returnvalue = commonFuncsDAL.CreatePendedNewFile(ref PatientFileNo, LoggedOnUser, PendDate);
            }
            catch (System.Exception ex)
            {
                Returnvalue = false;
            }
            return Returnvalue;
        }

        public bool SendInstantMessage(string PatientFileNo, string FromUserID, string ToUserID, string strMessage)
        {
            bool Returnvalue = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                Returnvalue = commonFuncsDAL.SendInstantMessage(PatientFileNo, FromUserID, ToUserID, strMessage);
            }
            catch (System.Exception ex)
            {
                Returnvalue = false;
            }
            return Returnvalue;
        }


        public bool AIMSEWSPODConstruct(ref string EmailStorageFolder, string EmailID)
        {
            DataTable dtPODData = GetPODData(EmailID);
            
            bool ReturnValue = false;
            try
            {
                string PODSizeCheckError = "";
                string PodDiskLetter = "";
                string PodEmailGUID = "";
                long PodCounter = 0;
                string PODFolder = "";
                string EmailMailBoxID = "";

                PodCounter = System.Convert.ToInt64(dtPODData.Rows[0]["MAILBOX_POD_COUNTER"]);
                PodDiskLetter = dtPODData.Rows[0]["MAILBOX_POD_DISK_LETTER"].ToString().ToUpper();
                PodEmailGUID = dtPODData.Rows[0]["EMAIL_GUID"].ToString().ToUpper();
                EmailMailBoxID = dtPODData.Rows[0]["MAILBOX_ID"].ToString();

                PODFolder = PodDiskLetter + @":\POD" + PodCounter.ToString() + @"\";

                //create the POD Directory 
                if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                //double PodByteSize = GetPODDirectorySize(PODFolder, ref PODSizeCheckError);
                double PodByteSize = 0;

                if (!PODSizeCheckError.Equals(""))
                {
                    ErrorLogger("AIMSEWSPODConstruct - Calculating POD Size Structure ERROR: \n" + PODSizeCheckError);
                    return false;
                }
                //POD Folder must be greater than 4 Gigs, 
                if (PodByteSize >= 3999999999)
                {
                    PodCounter++;
                    UpdateMailBoxPODCounter(EmailMailBoxID, PodCounter.ToString());
                    PODFolder = PodDiskLetter + @":\POD" + PodCounter.ToString() + @"\";

                    //create the POD Directory 
                    if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                }

                string sDir1 = PodEmailGUID.Substring(0, 1);
                string sDir2 = PodEmailGUID.Substring(1, 1);
                if (!System.IO.Directory.Exists(PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID))
                {
                    System.IO.Directory.CreateDirectory(PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID);
                }
                EmailStorageFolder = PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID;
                ReturnValue = true;
            }
            catch (System.Exception ex)
            {
                ErrorLogger("AIMSEWSPODConstruct Function Error: \n" + ex.ToString());
                ReturnValue = false;
            }
            finally
            {
                dtPODData.Dispose();
            }
            return ReturnValue;
        }

        public bool AIMSEWSPODConstructSentEmails(ref string EmailStorageFolder, string EmailID)
        {
            DataTable dtPODData = GetPODData(EmailID);

            bool ReturnValue = false;
            try
            {
                string PODSizeCheckError = "";
                string PodDiskLetter = "";
                string PodEmailGUID = "";
                long PodCounter = 0;
                string PODFolder = "";
                string EmailMailBoxID = "";

                PodCounter = System.Convert.ToInt64(dtPODData.Rows[0]["MAILBOX_POD_COUNTER"]);
                PodDiskLetter = dtPODData.Rows[0]["MAILBOX_POD_DISK_LETTER"].ToString().ToUpper();
                PodEmailGUID = dtPODData.Rows[0]["EMAIL_GUID"].ToString().ToUpper();
                EmailMailBoxID = dtPODData.Rows[0]["MAILBOX_ID"].ToString();

                PODFolder = PodDiskLetter + @":\POD" + PodCounter.ToString() + @"\";

                //create the POD Directory 
                if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                double PodByteSize = GetPODDirectorySize(PODFolder, ref PODSizeCheckError);

                PODFolder = PodDiskLetter + @":\POD" + PodCounter.ToString() + @"\AIMS_SENT_EMAILS\";
                //create the POD Directory 
                if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                
                if (!PODSizeCheckError.Equals(""))
                {
                    ErrorLogger("AIMSEWSPODConstruct - Calculating POD Size Structure ERROR: \n" + PODSizeCheckError);
                    return false;
                }
                //POD Folder must be greater than 4 Gigs, 
                if (PodByteSize >= 3999999999)
                {
                    PodCounter++;
                    UpdateMailBoxPODCounter(EmailMailBoxID, PodCounter.ToString());
                    PODFolder = PodDiskLetter + @":\POD" + PodCounter.ToString() + @"\";

                    //create the POD Directory 
                    if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }

                    PODFolder = PodDiskLetter + @":\POD" + PodCounter.ToString() + @"\AIMS_SENT_EMAILS\";

                    //create the POD Directory 
                    if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                }

                string sDir1 = PodEmailGUID.Substring(0, 1);
                string sDir2 = PodEmailGUID.Substring(1, 1);
                if (!System.IO.Directory.Exists(PODFolder + "AIMS_SENT_EMAILS" + @"\" + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID))
                {
                    System.IO.Directory.CreateDirectory(PODFolder + "AIMS_SENT_EMAILS" + @"\" + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID);
                }
                EmailStorageFolder = PODFolder + "AIMS_SENT_EMAILS" + @"\" + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID;
                ReturnValue = true;
            }
            catch (System.Exception ex)
            {
                ErrorLogger("AIMSEWSPODConstruct Function Error: \n" + ex.ToString());
                ReturnValue = false;
            }
            finally
            {
                dtPODData.Dispose();
            }
            return ReturnValue;
        }

        public void CreateEmailCorrespondence(ref string strFileName, string EmailBodyContent, string PODFolder, string FileName)
        {
            string fLogName = @strFileName;
            
            StreamWriter sw;
            try
            {
                sw = File.AppendText(fLogName);
                sw.WriteLine(EmailBodyContent);
                sw.Flush();
                sw.Close();
            }
            catch (System.Exception ex){
                if (ex.Message == "Illegal characters in path.")
                {
                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    {
                        FileName = FileName.Replace(c.ToString(), "");
                    }

                    fLogName = PODFolder + FileName;
                    sw = File.AppendText(fLogName);
                    sw.WriteLine(EmailBodyContent);
                    sw.Flush();
                    sw.Close();
                    strFileName = fLogName;
                }
            }
            finally
            {
            }
        }

        public string ReplaceMultiple(string OrigString, string ReplaceString, params string[] FindChars)
        {
            //Dont add the same character twice in the array as this causes the function to work incorrectly
            //and if you do, then what the hell are you doing as a software developer.


            long lLBound = 0;
            long lUBound = 0;
            long lCtr = 0;
            string sAns = string.Empty;

            lLBound = FindChars.GetLowerBound(0);
            lUBound = FindChars.GetUpperBound(0);

            sAns = OrigString;

            for (lCtr = lLBound; lCtr <= lUBound; lCtr++)
            {
                sAns = sAns.Replace(FindChars[lCtr].ToString(), ReplaceString);
            }

            return sAns;
        }

        public DataTable  GetPatientEmailDocumentsAttached(string PatientEmailEnquiryID)
        {
            bool bReturn = false;
            DataTable dsSet = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dsSet = commonFuncsDAL.GetPatientEmailDocumentsAttached(PatientEmailEnquiryID);
            }
            finally
            {
            }
            return dsSet;
        }

        public DataTable GetPatientSentEmailDocumentsAttached(string SentEmailID)
        {
            bool bReturn = false;
            DataTable dsSet = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dsSet = commonFuncsDAL.GetPatientSentEmailDocumentsAttached(SentEmailID);
            }
            finally
            {
            }
            return dsSet;
        }

        public DataTable PatientValidate(string PatientFileNo)
        {
            DataTable dtPatientFileNoCheck = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileNoCheck = commonFuncsDAL.PatientFileNoVerify(PatientFileNo);
            return dtPatientFileNoCheck;
        }

        public DataTable GetServiceProvider(string ServiceProviderID)
        {
            DataTable dtServiceProviderDetails = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtServiceProviderDetails = commonFuncsDAL.GetServiceProvider(ServiceProviderID);
            return dtServiceProviderDetails;
        }

        public bool SaveVisaLetterPOD(String VisaLetterID, string VisaLetterFileName, string VisaLetterPOD) 
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.SaveVisaLetterPOD(VisaLetterID, VisaLetterFileName, VisaLetterPOD);
            }
            finally 
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool PatientSubFileAdd(string PatientFileNo, string SubFileTypeID, string SubFileTypeCategoryID, ref string PatientSubFileID) 
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.PatientSubFileAdd(PatientFileNo, SubFileTypeID, SubFileTypeCategoryID, ref PatientSubFileID);
            }
            finally 
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }


        public bool PatuientSubFileRemove(string PatientFileNo, string SubFileTypeID, string SubFileTypeCategoryID) 
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.PatuientSubFileRemove(PatientFileNo, SubFileTypeID);
            }
            finally 
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool SaveVisaLetter(ref string VISALetterID, string LoggedOnUser, string VISALetterFile, 
                        string EmbassyName, string EmbassyAdd1, string EmbassyAdd2, string EmbassyAdd3, string EmbassyAdd4, string EmbassyAdd5, string Country,
                        string PatientName, string PatientPassportNo, string PatientPassportIssueDt, string PatientPassportExpiryDt,
                        string EscortName, string EscortRelationToPatient, string EscortPassportNo, string EscortPassportIssueDt, string EscortPassportExpiryDt,
                        string EscortHisHer, string CountryOfTreatment, string TreatingDoctor, string TreatingDoctorProfession, string TreatingHospital,
                        string AimsCoOrdinator, string TreatmentDate, string PatientResidingAddress, string AddressType, string PatientFileNo,string EmbassyID, string userID)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
               
                Returnvalue = commonFuncsDAL.SaveVisaLetter(ref VISALetterID, LoggedOnUser, VISALetterFile, EmbassyName, EmbassyAdd1, EmbassyAdd2, EmbassyAdd3, EmbassyAdd4, EmbassyAdd5, Country,
                           PatientName, PatientPassportNo, PatientPassportIssueDt, PatientPassportExpiryDt,
                           EscortName, EscortRelationToPatient, EscortPassportNo, EscortPassportIssueDt, EscortPassportExpiryDt,
                           EscortHisHer, CountryOfTreatment, TreatingDoctor, TreatingDoctorProfession,TreatingHospital,
                           AimsCoOrdinator, TreatmentDate, PatientResidingAddress, AddressType, PatientFileNo, EmbassyID, userID);
                Returnvalue = true;
            }
            finally 
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool SaveEmbassy(ref string EmbassyID, string EmbassyName, string EmbassyTelNo, string EmbassyFaxNo, string EmbassyAddress1, string EmbassyAddress2, string EmbassyAddress3, string EmbassyAddress4, string EmbassyAddress5, string EmbassyCountry, string EmbassyContactPerson, string EmbassyActiveYN)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.SaveEmbassy(ref EmbassyID, EmbassyName, EmbassyTelNo, EmbassyFaxNo, EmbassyAddress1, EmbassyAddress2, EmbassyAddress3, EmbassyAddress4, EmbassyAddress5, EmbassyCountry, EmbassyContactPerson, EmbassyActiveYN);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool SaveCalenderAppointment(ref string CalenderAppointmentId, string AppointmentSubject,
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
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.SaveCalenderAppointment(ref CalenderAppointmentId, AppointmentSubject,
                                                                AppointmentAddress,
                                                                AppointmentDate,
                                                                AppointmentTimeHour,
                                                                AppointmentTimeMinute,
                                                                AppointmentReminderYN,
                                                                AppointmentReminderPeriod,
                                                                AppointmentTransportRequiredYN,
                                                                AppointmentNote, AppointmentTime);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }


        public bool SaveAppointment(ref string AppointmentId, string AppointmentSubject,
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
                                                string PatientID,
                                                string CreatedBy,
                                                string AppointmentNote,
                                                DateTime AppointmentTime,
                                                DateTime PickUpTime,
                                                DateTime DropOffTime,
                                                string TranslatorYN,
                                                string CalenderAppointmentLoadId)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.SaveAppointment(ref AppointmentId, AppointmentSubject,
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
                                                                PatientID,
                                                                CreatedBy,
                                                                AppointmentNote, AppointmentTime, PickUpTime, DropOffTime, TranslatorYN, CalenderAppointmentLoadId);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool SaveAAOption(ref string AAOptionId, 
                                        string AAAirCraft,
                                            string AAAvailibity,
                                             string AACost,
                                               string AALevelOfCare,
                                                string AARouting, 
                                                string CreatedBy, 
                                                string PatientId, 
                                                string AdminFee,
                                                string AmbulanceReferrring,
                                                string AmbulanceReceiving,
                                                string AirportOperatingHours)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.SaveAAOption(ref AAOptionId, AAAirCraft,
                                                                AAAvailibity,
                                                                AACost,
                                                                AALevelOfCare,
                                                                AARouting,
                                                                CreatedBy, 
                                                                PatientId,
                                                                AdminFee,
                                                                AmbulanceReferrring,
                                                                AmbulanceReceiving,
                                                                AirportOperatingHours);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool SaveAADetails(string PatientID, 
                                    string PatientYellowFeverCert,
                                    string PatientWeightHeight,
                                    string RefHosNameLocation,
                                    string RefHosTelNo,
                                    string RefHosEmail,
                                    string RefHosDrName,
                                    string RefHosDrNameTel,
                                    string RefHosDrNameEmail,
                                    string AccomMemNameSur,
                                    string AccomMemNationality,
                                    string AccomMemPassportNo,
                                    string AccomMemYelFeverCert,
                                    string AccomMemWeightHeight,
                                    string VhfFormRequiredYN,
                                    string UserId,
                                    string AirAmbulanceCELetter,
                                    string PatientPassportNo,
                                    string AAAddressToName)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.SaveAADetails(PatientID, 
                                    PatientYellowFeverCert,
                                    PatientWeightHeight,
                                    RefHosNameLocation,
                                    RefHosTelNo,
                                    RefHosEmail,
                                    RefHosDrName,
                                    RefHosDrNameTel,
                                    RefHosDrNameEmail,
                                    AccomMemNameSur,
                                    AccomMemNationality,
                                    AccomMemPassportNo,
                                    AccomMemYelFeverCert,
                                    AccomMemWeightHeight,
                                    VhfFormRequiredYN,
                                    UserId,
                                    AirAmbulanceCELetter, PatientPassportNo, AAAddressToName);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool SaveAccomodationDoc(string Accomodation,
                                            string GuestName,
                                            string GuestRefNo,
                                            string GuestNoOfRooms,
                                            string GuestArrivalDate,
                                            string GuestFlightArrivalTime,
                                            string GuestDepartDate,
                                            string GuestAimsSettle,
                                            string GuestCountryOfRegion,
                                            string Religion,
                                            string DiabeticMeals,
                                            string BedAndBreakFast,
                                            string Meals,
                                            string Laundry,
                                            string Telephone,
                                            string MiniBar,
                                            string SpecialRequest,
                                            string PatientID,
                                            string UserID,
                                            string AccomodationLetter,
                                            string ContactTelMobileNo,
                                            string ContactEmailAddress,
                                            string DOB,
                                            string NoOfGuests,
                                            string RoomRatePerNight,
                                            string RoomType,
                                            string MealBreakFast,
                                            string MealBreakLunch,
                                            string MealBreakDinner,
                                            string MealBreakFullBoard,
                                            string SocialTransport,
                                            string AdditionalNotes,
                                            string Currency
            )
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            
                return commonFuncsDAL.SaveAccomodationDoc(Accomodation,
                                            GuestName,
                                            GuestRefNo,
                                            GuestNoOfRooms,
                                            GuestArrivalDate,
                                            GuestFlightArrivalTime,
                                            GuestDepartDate,
                                            GuestAimsSettle,
                                            GuestCountryOfRegion,
                                            Religion,
                                            DiabeticMeals,
                                            BedAndBreakFast,
                                            Meals,
                                            Laundry,
                                            Telephone,
                                            MiniBar,
                                            SpecialRequest,
                                            PatientID,
                                            UserID,
                                            AccomodationLetter,
                                            ContactTelMobileNo,
                                            ContactEmailAddress,
                                            DOB,
                                            NoOfGuests,
                                            RoomRatePerNight,
                                            RoomType,
                                            MealBreakFast,
                                            MealBreakLunch,
                                            MealBreakDinner,
                                            MealBreakFullBoard,
                                            SocialTransport,
                                            AdditionalNotes,
                                            Currency);
            
        }

        public bool CancelAppointment(string AppointmentId, string userName)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.CancelAppointment(AppointmentId, userName);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }


        public bool CompleteAppointment(string AppointmentId, string userName)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.CompleteAppointment(AppointmentId, userName);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }
        public bool GOPRunningTotalLimit(string PatientId, string GOP_Amount)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.GOPRunningTotalLimit(PatientId, GOP_Amount);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool GOPApproved(string GOPID)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.GOPApproved(GOPID);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }


        public bool IsGOPApproved(string GOPID)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.IsGOPApproved(GOPID);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public string GetDueDate(DateTime fileReceivedDttm)
        {
            string Returnvalue = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.GetDueDate(fileReceivedDttm);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool UserGOPOverLimit(string GOPAmount, string UserId, string PatientID)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.UserGOPOverLimit(GOPAmount, UserId, PatientID);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool SavePatientChemoCycles(ref string ChemoCycleID, string PatientSubFileID, string CycleStartDate, string CycleEndDate, string CyclePlannedYN, string CycleRadioTherapy, string CycleActiveYN, string LoadedBy)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.SavePatientChemoCycles(ref ChemoCycleID, PatientSubFileID, CycleStartDate, CycleEndDate, CyclePlannedYN, CycleRadioTherapy, CycleActiveYN, LoadedBy);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public bool SavePatientFileTask(ref string PatientTaskID, string TaskID, string PatientSubFileID, string TaskUser, string TaskDueDate, string TaskCompletionDate, string TaskDetails, string TaskActiveYN, string PriorityID, string LoadedBy, string TaskStatusID)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.SavePatientFileTask(ref PatientTaskID, TaskID, PatientSubFileID, TaskUser, TaskDueDate, TaskCompletionDate, TaskDetails, TaskActiveYN, PriorityID, LoadedBy, TaskStatusID);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        public DataTable GetPatientFilesDocs(string PatientFileNo)
        {
            DataTable dtPatientFileDocs= new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileDocs = commonFuncsDAL.GetPatientFilesDocs(PatientFileNo);
            return dtPatientFileDocs;
        }

        public DataTable GetPatientFilesAppointments(string PatientFileNo)
        {
            DataTable dtPatientFileDocs = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileDocs = commonFuncsDAL.GetPatientFilesAppointments(PatientFileNo);
            return dtPatientFileDocs;
        }

        public DataTable GetPatientFileLetterOfGuarantees(string PatientID)
        {
            DataTable dtPatientFileDocs = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileDocs = commonFuncsDAL.GetPatientFileLetterOfGuarantees(PatientID);
            return dtPatientFileDocs;
        }

        public DataTable GetPatientFilesTasks(string PatientSubFileID, string TaskStatus)
        {
            DataTable dtPatientFileTask = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileTask = commonFuncsDAL.GetPatientFilesTasks(PatientSubFileID, TaskStatus);
            return dtPatientFileTask;
        }

        public DataTable GetPatientFilesTaskAudit(string PatientSubFileID)
        {
            DataTable dtPatientFileTask = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileTask = commonFuncsDAL.GetPatientFilesTaskAudit(PatientSubFileID);
            return dtPatientFileTask;
        }

        public DataTable GetPatientFileAppointmentsAudit(string PatientSubFileID)
        {
            DataTable dtPatientFileTask = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileTask = commonFuncsDAL.GetPatientFileAppointmentsAudit(PatientSubFileID);
            return dtPatientFileTask;
        }


        public DataTable GetPatientFilesTasks(string PatientSubFileID)
        {
            DataTable dtPatientFileTask = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileTask = commonFuncsDAL.GetPatientFilesTasks(PatientSubFileID);
            return dtPatientFileTask;
        }

        public DataTable GetPatientFilesEmailsProcessed(string PatientSubFileID)
        {
            DataTable dtPatientFileTask = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileTask = commonFuncsDAL.GetPatientFilesEmailsProcessed(PatientSubFileID);
            return dtPatientFileTask;
        }

        public DataTable GetPatientFileChemo(string PatientSubFileID)
        {
            DataTable dtPatientFileChemo = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileChemo = commonFuncsDAL.GetPatientFileChemo(PatientSubFileID);
            return dtPatientFileChemo;
        }

        public DataTable GetPatientFileCycleDates(string PatientSubFileID)
        {
            DataTable dtPatientFileCycles = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileCycles = commonFuncsDAL.GetPatientFileCycleDates(PatientSubFileID);
            return dtPatientFileCycles;
        }

        public DataTable GetCycleDatesDetails(string CycleDateID)
        {
            DataTable dtPatientFileCycles = new DataTable();
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            dtPatientFileCycles = commonFuncsDAL.GetCycleDatesDetails(CycleDateID);
            return dtPatientFileCycles;
        }

        public bool RemovePatientCycleDetail(string CycleDateID)
        {
            bool bReturn = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                commonFuncsDAL.RemovePatientCycleDetail(CycleDateID);
                bReturn = true;
            }
            finally
            {
            }
            return bReturn;
        }
        
        public bool RemovePatientSubFileType(string PatientSubFileID)
        {
            bool bReturn = false;
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                commonFuncsDAL.RemovePatientSubFileType(PatientSubFileID);
                bReturn = true;
            }
            finally
            {
            }
            return bReturn;
        }

        public string AIMSDocumentationEmailBody(string PatientFileNo, string PatientName, String UserName, string DocumentName)
        {
            string EmailBody = "";

                EmailBody = "<div align=center>"+
                    " <table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=600 style='width:6.25in;mso-cellspacing:0in;mso-yfti-tbllook:1184;mso-padding-alt:0in 0in 0in 0in'>"+
                    " <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:60.0pt'>"+
                    " <td style='border-top:none;border-left:solid black 1.0pt;border-bottom:none; border-right:solid black 1.0pt;mso-border-left-alt:solid black .75pt; mso-border-right-alt:solid black .75pt;background:#00559D;padding:0in 22.5pt 0in 22.5pt; height:60.0pt'  align='center'>"+
                    " <p></p>"+
                    " </td>"+
                    " </tr>"+
                    " <tr style='mso-yfti-irow:1'>"+
                    " <td style='border-top:none;border-left:solid black 1.0pt;border-bottom:none; border-right:solid black 1.0pt;mso-border-left-alt:solid black .75pt; mso-border-right-alt:solid black .75pt;padding:0in 22.5pt 0in 22.5pt'></td>"+
                    " </tr>"+
                    " <tr style='mso-yfti-irow:2'>"+
                    " <td style='border-top:none;border-left:solid black 1.0pt;border-bottom:none; border-right:solid black 1.0pt;mso-border-left-alt:solid black .75pt; mso-border-right-alt:solid black .75pt;padding:15.0pt 22.5pt 0in 22.5pt'>"+
                    " <p><span style='font-family:Arial,sans-serif'>Dear Valued AIMS Client </span></p>"+
                    " <p><span style='font-family:Arial,sans-serif'><b>Please find attached "+ DocumentName +" for "+ PatientName +"</b></span></p>"+
                    " <p><span style='font-family:Arial,sans-serif'><b>AIMS Reference number: " + PatientFileNo + "</b></span></p>" +
                    " <p><span style='font-family:Arial,sans-serif'>This is a system generated e-mail / fax, therefore please do not respond to it. However, should you have any queries please contact us on +27 11 783 0135</span></p>"+
                    " <p><span style='font-family:Arial,sans-serif'>Should you wish to e-mail us, please address to <a href=mailto:operations@aims.org.za>operations@aims.org.za</a>. </span></p>"+
                    " <p><span style='font-family:Arial,sans-serif'>Kind regards </span></p>"+
                    @"<br/><br/>#EMAIL_SIGNATURE#" +
                    " </td>"+
                    " </tr>"+
                    " <tr style='mso-yfti-irow:3'>"+
                    " <td style='border-top:none;border-left:solid black 1.0pt;border-bottom:none; border-right:solid black 1.0pt;mso-border-left-alt:solid black .75pt; mso-border-right-alt:solid black .75pt;padding:0in 0in 0in 0in'>"+
                    " <p class=MsoNormal><strong><span style='font-family:Arial,sans-serif; mso-fareast-font-family:Times New Roman'>&nbsp;</span></strong><span style='mso-fareast-font-family:Times New Roman'><o:p></o:p></span></p>"+
                    " </td>"+
                    " </tr>"+
                    " <tr style='mso-yfti-irow:4;mso-yfti-lastrow:yes'>"+
                    " <td style='border:solid black 1.0pt;border-top:none;mso-border-left-alt:solid black .75pt; mso-border-bottom-alt:solid black .75pt;mso-border-right-alt:solid black .75pt; background:#00559D;padding:6.0pt 22.5pt 6.0pt 22.5pt' align='center'>"+
                    " <p><span style='font-size:7.5pt;font-family:Arial,sans-serif;color:white'>Alliance International Medical Services</span><span style='font-size: 7.5pt;color:white'><o:p></o:p></span></p>"+
                    " </td>"+
                    " </tr>"+
                    " </table>"+
                    " </div>"+
                    " <p>&nbsp;</p>"+
                    " <p>&nbsp;</p>"+
                    " <p>&nbsp;</p>"+
                    " <p>&nbsp;</p>";
            
            return EmailBody;
        }

        public void ClearListView(ListView lstViewObject, bool ClearListColumns)
        {
            lstViewObject.Items.Clear();
            if (ClearListColumns)
            {
                lstViewObject.Columns.Clear();
            }
        }

        public bool UpdatePatientFileType (string PatientSubFileID, string FileTypeID, string FileTypeCategoryID)
        {
            bool Returnvalue = false;
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            try
            {
                Returnvalue = commonFuncsDAL.UpdatePatientFileType(PatientSubFileID, FileTypeID, FileTypeCategoryID);
            }
            finally
            {
                commonFuncsDAL = null;
            }
            return Returnvalue;
        }

        private bool LockPDFFile(string inputFile, ref string outputFile, string password)
        {
            string WorkingFolder = Path.GetDirectoryName(inputFile);
            string outputPDFFName = Path.GetFileNameWithoutExtension(inputFile) + "_protected_" + System.Guid.NewGuid() + ".pdf";
            outputFile = Path.Combine(WorkingFolder, outputPDFFName);

            killExistingOutputFile(outputFile);
            using (Stream input = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Stream output = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true, password, "", PdfWriter.ALLOW_SCREENREADERS | PdfWriter.ALLOW_COPY | PdfWriter.ALLOW_FILL_IN | PdfWriter.ALLOW_PRINTING | PdfWriter.ALLOW_MODIFY_CONTENTS);
                }
            }
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            return true;
        }

        private bool LockWordFile(string inputFile, ref string outputFile, string password)
        {
            string WorkingFolder = Path.GetDirectoryName(inputFile);
            string fileext = Path.GetExtension(inputFile);
            string outputDocFName = Path.Combine(WorkingFolder, Path.GetFileNameWithoutExtension(inputFile) + "_protected_" + System.Guid.NewGuid() +fileext);

            Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            Microsoft.Office.Interop.Word.Document doc = null;
            object missing = System.Reflection.Missing.Value;
            try
            {

                object readOnly = false;
                object visible = true;
                object docpassword = password;
                object fileToOpen = inputFile;
                object fileToSave = outputDocFName;

                killExistingOutputFile(outputDocFName);

                doc = wordApp.Documents.Open(ref fileToOpen, ref missing, ref readOnly, ref missing, ref missing,
                                                ref missing, ref missing, ref docpassword, ref missing, ref missing, ref missing,
                                                ref visible, ref visible, ref missing, ref missing, ref missing);
                doc.Activate();

                doc.SaveAs(ref fileToSave, ref missing, ref missing, ref docpassword, ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                outputFile = fileToSave.ToString();
            }
            catch (Exception ex)
            {
                CommonFunctions cmmnFuncs = new CommonFunctions();
                cmmnFuncs.ErrorLogger("Locking Word File Failed: \n\n" + ex.ToString());
                throw new Exception("Locking of Word File Failed, Please contact system administrator.");
            }
            finally
            {
                doc.Close(ref missing, ref missing, ref missing);
                wordApp.Quit(ref missing, ref missing, ref missing);
                doc = null;
                wordApp = null;
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
            return true;
        }

        //private bool LockExcelFile(string inputFile, ref string outputFile, string password)
        //{
        //    try
        //    {
        //        string WorkingFolder = Path.GetDirectoryName(inputFile);
        //        string fileext = Path.GetExtension(inputFile);
        //        string outputDocFName = Path.Combine(WorkingFolder, Path.GetFileNameWithoutExtension(inputFile) + "_protected_" + System.Guid.NewGuid() + fileext);
        //        if (File.Exists(outputDocFName))
        //        {
        //            File.Delete(outputDocFName);
        //        }
        //        File.Copy(inputFile, outputDocFName);
        //        FileInfo newFile = new FileInfo(@outputDocFName);
        //        ExcelPackage package = new ExcelPackage(newFile, password); ///"12/08/1919"
        //        package.Save();
        //        package.Dispose();
        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        CommonFunctions cmmnFuncs = new CommonFunctions();
        //        cmmnFuncs.ErrorLogger("Locking Excel File Failed: \n\n" + ex.ToString() );
        //        throw new Exception("Locking of Excel File Failed, Please contact System Administrator");
        //    }
        //}


        private bool LockExcelFile(string inputFile, ref string outputFile, string password)
        {
            Excel.Workbook MyBook = null;
            Excel.Application MyApp = null;
            object docpassword = password;

            try
            {
                string WorkingFolder = Path.GetDirectoryName(inputFile);
                string fileext = Path.GetExtension(inputFile);
                string outputDocFName = Path.Combine(WorkingFolder, Path.GetFileNameWithoutExtension(inputFile) + "_protected_" + System.Guid.NewGuid() + fileext);
                //outputDocFName = Path.Combine(WorkingFolder, Path.GetFileNameWithoutExtension(inputFile) + "_protected_" + System.Guid.NewGuid() + ".pdf");

                killExistingOutputFile(outputDocFName);

                object missing = System.Reflection.Missing.Value;
                string DB_PATH = inputFile;

                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(DB_PATH, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                MyBook.Password = password;

                Excel.XlFixedFormatType paramExportFormat = Excel.XlFixedFormatType.xlTypePDF;
                Excel.XlFixedFormatQuality paramExportQuality = Excel.XlFixedFormatQuality.xlQualityStandard;
                bool paramOpenAfterPublish = false;
                bool paramIncludeDocProps = true;
                bool paramIgnorePrintAreas = true;

                //MyBook.ExportAsFixedFormat(paramExportFormat, outputDocFName, paramExportQuality, missing, paramIgnorePrintAreas, missing, missing, paramOpenAfterPublish, missing);

                MyBook.SaveAs(outputDocFName, missing, docpassword, docpassword, missing, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                MyBook.Close(missing, outputDocFName, missing);
                outputFile = outputDocFName;
                return true;
            }
            catch (System.Exception ex)
            {
                CommonFunctions cmmnFuncs = new CommonFunctions();
                cmmnFuncs.ErrorLogger("Locking Excel File Failed: \n\n" + ex.ToString());
                throw new Exception("Locking of Excel File Failed, Please contact System Administrator");
            }
            finally {
                MyBook = null;
                MyApp = null;
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
        }

        public bool ProcessEmailAttachments(string EmailAttachment, ref string EmailAttachmentOutput, string password)
        {
            string attachmentExt = "";
            string[] Emailsattachments = EmailAttachment.Split(new Char[] { ';' });
            string lockedfile = "";
             
            foreach (string attachment in Emailsattachments)
            {
                if (!attachment.Trim().Equals(""))
                {
                    attachmentExt = Path.GetExtension(attachment);

                    switch (attachmentExt.ToUpper().Replace(".",""))
                    {
                        case "XLS":
                            LockExcelFile(attachment, ref lockedfile, password);
                            break;
                        case "XLSX":
                            LockExcelFile(attachment, ref lockedfile, password);
                            break;
                        case "DOC":
                            LockWordFile(attachment, ref lockedfile, password);
                            break;
                        case "DOCX":
                            LockWordFile(attachment, ref lockedfile, password);
                            break;
                        case "PDF":
                            LockPDFFile(attachment, ref lockedfile, password);
                            break;
                        default:
                            lockedfile = attachment;
                            break;
                    }
                    EmailAttachmentOutput += lockedfile + ";";
                }
            }
            return true;
        }

        private void killExistingOutputFile(string outputFile)
        {
            try
            {
                if (File.Exists(outputFile))
                {
                    System.GC.Collect(); 
                    System.GC.WaitForPendingFinalizers(); 
                    File.SetAttributes(outputFile, FileAttributes.Normal);
                    File.Delete(outputFile);
                }
            }
            catch (System.Exception ex)
            {

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

        private  bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            bool result = false;
            //if (cert.Subject.ToUpper().Contains("DC1"))     {         
            result = true;
            //}      
            return result;
        }


        private void AssignCertificatesOffice365()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            object obj1 = new object();

            System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
        }

        public static void CreateMessageWithMultipleViews(string server, string recipients)
        {
            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
                "jane@contoso.com",
                recipients,
                "This email message has multiple views.",
                "This is some plain text.");

            // Construct the alternate body as HTML.
            string body = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
            body += "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">";
            body += "</HEAD><BODY><DIV><FONT face=Arial color=#ff0000 size=2>this is some HTML text";
            body += "</FONT></DIV></BODY></HTML>";

            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            // Add the alternate body to the message.

            AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
            message.AlternateViews.Add(alternate);

            // Send the message.
            SmtpClient client = new SmtpClient(server);
            

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithMultipleViews(): {0}",
                    ex.ToString());
            }
            // Display the values in the ContentType for the attachment.
            ContentType c = alternate.ContentType;
            Console.WriteLine("Content type");
            Console.WriteLine(c.ToString());
            Console.WriteLine("Boundary {0}", c.Boundary);
            Console.WriteLine("CharSet {0}", c.CharSet);
            Console.WriteLine("MediaType {0}", c.MediaType);
            Console.WriteLine("Name {0}", c.Name);
            Console.WriteLine("Parameters: {0}", c.Parameters.Count);

            Console.WriteLine();
            alternate.Dispose();
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
            CommonFunctions cmmnFuncs = new CommonFunctions();
            ExchangeService myservice = null;
            cmmnFuncs.ErrorLogger("Start Sending Using EWS Office");
            if (EmailFrom.Equals("admin@aims.org.za",StringComparison.OrdinalIgnoreCase))
            {
                myservice = GetBindingOffice365("Admin@AIMS.org.za", "s@eCahU5", "Admin", "https://outlook.office365.com/EWS/Exchange.asmx");
            }
            else
            {
                myservice = GetBindingOffice365("operation@aims.org.za", "Tra2As+u", "operation", "https://outlook.office365.com/EWS/Exchange.asmx");
            }
            
            AssignCertificatesOffice365();
            try
            {
                EmailMessage emailMessage = new EmailMessage(myservice);
                string contentID = Guid.NewGuid().ToString();
                string htmlBody = EmailBody.Replace("##SIGNATURE_LOGO##", @"<img border=0 width=318 height=123 src='cid:" + contentID + "'/>");

                FileAttachment attachment = emailMessage.Attachments.AddFileAttachment(@"C:\AIMS Recorder\image001.jpg");
                attachment.ContentId = contentID;
                attachment.IsInline = true;
                attachment.ContentType = "Jpeg";
                
                emailMessage.Subject = EmailSubject;
                emailMessage.Body = htmlBody;
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
                        emailMessage.ToRecipients.Add(globalEmail.Trim());
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
                cmmnFuncs.ErrorLogger("Email Transmission Successful sent to: ");
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
            return true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListItem
    {
        private string _Text;
        private string _Value;

        public ListItem(string text, string value)
        {
            _Text  =  text;
            _Value = value;
        }

        public string Text
        {
            get { return _Text; }
        }

        public string Value
        {
            get { return _Value; }
        }

        public override string ToString()
        {
            return Text;
        }
    }

    

}
