using System;
using System.Collections.Generic;
using System.Text;
using AIMS.DAL;
////using AIMS.Common;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL.CommonFunctions
{
    public class CommonFunctionsDAL : DataServiceBase 
    {
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public CommonFunctionsDAL() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public CommonFunctionsDAL(IDbTransaction txn) : base(txn) { }

        public DataTable GetCountries()
        {
            return ExecuteDataTable("AIMS_COUNTRIES_GET");
        }

        public DataTable GetSubFileTypes()
        {
            return ExecuteDataTable("AIMS_SUB_FILE_TYPES_GET");
        }

        public DataTable GetPatientSubFiles(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_SUB_FILE_TYPES_GET", CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }
        
        public DataTable GetTitles()
        {
            return ExecuteDataTable("AIMS_TITLES_GET");
        }

        public DataSet LoadTitles()
        {
            return ExecuteDataSet("AIMS_TITLES_GET");
        }

        public DataTable GetAddressTypes()
        {
            return ExecuteDataTable("AIMS_ADDRESS_TYPE_GET");
        }

        public DataTable GetFileAdministrators()
        {
            return ExecuteDataTable("[AIMS_GET_FILE_ADMINISTRATORS]");
        }

        public DataTable GetEmailSenders(string loggedOnUser)
        {
            return ExecuteDataTable("[AIMS_GET_EMAIL_SENDERS]", CreateParameter("@CoOrdinator", SqlDbType.VarChar, loggedOnUser));
        }

        public DataTable GetFileOperators()
        {
            return ExecuteDataTable("AIMS_GET_FILE_OPERATORS");
        }

        public DataTable GetWorkbasketAdministrators()
        {
            return ExecuteDataTable("AIMS_GET_WORKBASKET_ADMINISTRATORS");
        }

        public DataTable GetWorkbasketOperators()
        {
            return ExecuteDataTable("AIMS_GET_WORKBASKET_OPERATORS");
        } 

        public DataTable GetSupplierTypes()
        {
            return ExecuteDataTable("AIMS_SUPPLIER_TYPE_GET");
        }

        public DataTable GetPaymentMethods()
        {
            return ExecuteDataTable("AIMS_PAYMENT_METHODS_GET");
        }

        public DataTable GetActiveFiles()
        {
            return ExecuteDataTable("AIMS_PATIENTS_ACTIVE_FILES");
        }
        public DataTable GetAllocatedFiles()
        {
            return ExecuteDataTable("AIMS_PATIENTS_FILES_ALLOCATED");
        }

        //**** START ADMIN CALLS **\\
        public DataTable GetAdminAllocatedFiles(string adminStaff)
        {
            return ExecuteDataTable("AIMS_PATIENTS_ADMIN_FILES_ALLOCATED", CreateParameter("@AdminStaff", SqlDbType.VarChar, adminStaff));
        }

        public DataTable GetAdminClosedFiles()
        {
            return ExecuteDataTable("AIMS_PATIENTS_ADMIN_CLOSED_FILES");
        }
        
        public DataTable GetAdminWorkloadSnap(string adminStaff)
        {
            return ExecuteDataTable("AIMS_admin_workload_snapshot", CreateParameter("@AdminStaff", SqlDbType.VarChar, adminStaff));
        }

        public DataTable GetAdminWorkAllocations()
        {
            return ExecuteDataTable("AIMS_ADMIN_WORK_ALLOCATED");
        }


        public DataTable GetAdminUnassignedFiles()
        {
            return ExecuteDataTable("AIMS_PATIENTS_ADMIN_UNAssigned_FILES");
        }

        //**** END ADMIN CALLS **\\
        
        
        public DataTable GetSentFromAddressList()
        {
            return ExecuteDataTable("AIMS_EMAIL_FROM_ADDRESSES");
        }

        public DataTable GetAllocatedFiles(string CoOrdinator)
        {
            return ExecuteDataTable("AIMS_PATIENTS_FILES_ALLOCATED", CreateParameter("@CoOrdinator", SqlDbType.VarChar, CoOrdinator));
        }

        public DataTable GetAllocatedFilesOpsDashboard(string CoOrdinator)
        {
            return ExecuteDataTable("AIMS_PATIENTS_FILES_ALLOCATED_FOR_OPSDASHBOARD", CreateParameter("@CoOrdinator", SqlDbType.VarChar, CoOrdinator));
        }

        public DataTable GetCoOrdinatorWorkloadSnap(string CoOrdinator)
        {
            return ExecuteDataTable("AIMS_workload_snapshot", CreateParameter("@CoOrdinator", SqlDbType.VarChar, CoOrdinator));
        }

        public DataTable GetWorkAllocations()
        {
            return ExecuteDataTable("AIMS_PATIENTS_WORK_ALLOCATED");
        }

        public DataTable GetUrgentEmails()
        {
            return ExecuteDataTable("AIMS_EWS_GET_URGENT_EMAILS");
        }

        public DataTable GetPendedFiles()
        {
            return ExecuteDataTable("AIMS_PATIENTS_FILES_PENDED");
        }

        public DataTable GetHighCostFiles()
        {
            return ExecuteDataTable("AIMS_PATIENTS_HIGH_COST_FILES");
        }

        public DataTable GetUnallocatedFiles()
        {
            return ExecuteDataTable("AIMS_PATIENTS_UNALLOCATED_FILES");
        }

        public DataTable GetAdminUnallocatedFiles()
        {
            return ExecuteDataTable("AIMS_ADMIN_UNALLOCATED_FILES");
        }

        public DataTable GetSuppliers()
        {
            return ExecuteDataTable("AIMS_SUPPLIER_GET_ALL");
        }

        public DataTable GetSuppliers(string SupplierTypeID)
        {
            return ExecuteDataTable("AIMS_SUPPLIER_GET_ALL_TYPE", CreateParameter("@SUPPLIER_TYPE_ID", SqlDbType.VarChar, SupplierTypeID));
        }

        public DataTable GetSupplierDetails(string SupplierID)
        {
            return ExecuteDataTable("AIMS_SUPPLIER_GET", CreateParameter("@SupplierID", SqlDbType.VarChar, SupplierID));
        }

        public DataTable GetReligion()
        {
            return ExecuteDataTable("AIMS_GET_RELIGION");
        }

        public DataTable GetAddressDetails(Int64 AddressID)
        {
            return ExecuteDataTable("AIMS_ADDRESS_GET", CreateParameter("@AddressID", SqlDbType.VarChar , AddressID.ToString()));
        }

        public DataTable GetBankingDetails()
        {
            return ExecuteDataTable("aims_banking_details_get");
        }

        public DataTable GetDoctorOwingName(string PatientFileNo, string InvoiceNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_DOCTOR_OWING_NAME", CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo), CreateParameter("@InvoiceID", SqlDbType.VarChar, InvoiceNo));
        }

        public DataSet GetAIMSLedger(Int32 GuarantorID, string LedgerType, string startDate, string endDate, string AgeAnalysisPeriod)
        {
            if (AgeAnalysisPeriod == "")
                AgeAnalysisPeriod = " ";

            return ExecuteDataSet("AIMS_LEDGER_NEW", CreateParameter("@GuarantorID", SqlDbType.Int, GuarantorID),
                                                 CreateParameter("@LedgerType", SqlDbType.VarChar , LedgerType),
                                                 CreateParameter("@startdate", SqlDbType.VarChar, startDate),
                                                 CreateParameter("@enddate", SqlDbType.VarChar, endDate),
                                                 CreateParameter("@AgeAnalysisPeriod", SqlDbType.VarChar, AgeAnalysisPeriod));
        }

        public DataSet GetGuarantorAnalysis(Int32 GuarantorID, string sStartDate, string sEndDate)
        {
            return ExecuteDataSet("AIMS_GUARANTOR_ANALYSIS", CreateParameter("@GuarantorID", SqlDbType.Int, GuarantorID),
                CreateParameter("@StartDate", SqlDbType.VarChar, sStartDate), CreateParameter("@EndDate", SqlDbType.VarChar, sEndDate));
        }

        public DataSet GetGuarantorAnalysisdDrillDown(Int32 GuarantorID, string sStartDate, string sEndDate)
        {
            return ExecuteDataSet("AIMS_GUARANTOR_ANALYSIS_DRILL", CreateParameter("@GuarantorID", SqlDbType.Int, GuarantorID),
                CreateParameter("@StartDate", SqlDbType.VarChar, sStartDate), CreateParameter("@EndDate", SqlDbType.VarChar, sEndDate));
        }
        
        public DataSet GetPatientsAnalysisReport(string StartDate, string EndDate, string FileCancelled, string FileActiveYN, string Guarantor, string Supplier, string InPatient, string OutPatient, string Assist, string Transport, string Flight, string Repat, string TransportType , string AssistType)
        {
            return ExecuteDataSet("AIMS_PATIENT_ANALYSIS_REPORT",
                CreateParameter("@StartDate", SqlDbType.VarChar , StartDate + " 00:00:00"),
                 CreateParameter("@EndDate", SqlDbType.VarChar, EndDate + " 23:59:59"),
                   CreateParameter("@Guarantor", SqlDbType.VarChar,Guarantor),
                    CreateParameter("@Supplier", SqlDbType.VarChar,Supplier),
                     CreateParameter("@Patient_In", SqlDbType.VarChar, InPatient),
                      CreateParameter("@Patient_Out", SqlDbType.VarChar, OutPatient),
                       CreateParameter("@Assist", SqlDbType.VarChar,Assist),
                        CreateParameter("@AssistType", SqlDbType.VarChar, AssistType),
                         CreateParameter("@Transport", SqlDbType.VarChar, Transport),
                          CreateParameter("@TransportType", SqlDbType.VarChar, TransportType),
                           CreateParameter("@Repat", SqlDbType.VarChar, Repat),
                            CreateParameter("@Flight", SqlDbType.VarChar, Flight), 
                             CreateParameter("@FileCancelled", SqlDbType.VarChar, FileCancelled), 
                              CreateParameter("@FileActive", SqlDbType.VarChar, FileActiveYN));
        }

        public DataSet GetAIMSForexLedger(string ForexPymt, string InsuranceOverPymt, string InsuranceShortPymt, string doctorOwing, string LateInvoiceOverPymt, string LedgerStartDate, string LedgerEndDate, string AgeAnalysisPeriod)
        {
            if (AgeAnalysisPeriod == "")
                AgeAnalysisPeriod = " ";
            return ExecuteDataSet("AIMS_FOREX_LEDGER", CreateParameter("@Forex", SqlDbType.VarChar, ForexPymt),
                                                 CreateParameter("@OverPymt", SqlDbType.VarChar, InsuranceOverPymt),
                                                 CreateParameter("@ShortPymt", SqlDbType.VarChar, InsuranceShortPymt),
                                                 CreateParameter("@DoctorOwing", SqlDbType.VarChar, doctorOwing),
                                                 CreateParameter("@OverPymtLateInvoice", SqlDbType.VarChar, LateInvoiceOverPymt),
                                                 CreateParameter("@StartDate", SqlDbType.VarChar, LedgerStartDate),
                                                 CreateParameter("@EndDate", SqlDbType.VarChar, LedgerEndDate),
                                                 CreateParameter("@AgeAnalysisPeriod", SqlDbType.VarChar, AgeAnalysisPeriod));
        }

        public DataSet GetAIMSDoctorOwingLedger(string ForexPymt, string InsuranceOverPymt, string InsuranceShortPymt, string doctorOwing, string LedgerStartDate, string LedgerEndDate, string AgeAnalysisPeriod)
        {
            return ExecuteDataSet("AIMS_FOREX_LEDGER", CreateParameter("@Forex", SqlDbType.VarChar, ForexPymt),
                                                 CreateParameter("@OverPymt", SqlDbType.VarChar, InsuranceOverPymt),
                                                 CreateParameter("@ShortPymt", SqlDbType.VarChar, InsuranceShortPymt),
                                                 CreateParameter("@ShortPymt", SqlDbType.VarChar, doctorOwing),
                                                 CreateParameter("@StartDate", SqlDbType.VarChar, LedgerStartDate),
                                                 CreateParameter("@EndDate", SqlDbType.VarChar, LedgerEndDate),
                                                 CreateParameter("@AgeAnalysisPeriod", SqlDbType.VarChar, AgeAnalysisPeriod));
        }

        public DataTable GetSPExceedCostInfo(string PatientFileNo, string InvoiceID, string Username)
        {
            return ExecuteDataTable("AIMS_SP_COST_LIMIT_INFO", 
                                    CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                                    CreateParameter("@InvoiceID", SqlDbType.VarChar, InvoiceID),
                                    CreateParameter("@UserName", SqlDbType.VarChar, Username ));
        }

        public DataTable GetDocumentationEmailInfo(string PatientFileNo, string InvoiceID, string Username)
        {
            return ExecuteDataTable("AIMS_SP_COST_LIMIT_INFO",
                                    CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                                    CreateParameter("@InvoiceID", SqlDbType.VarChar, InvoiceID),
                                    CreateParameter("@UserName", SqlDbType.VarChar, Username));
        }

        public DataTable Get_AIMS_Mailboxes(string LoggedInUser)
        {
            return ExecuteDataTable("AIMS_EWS_GET_MAILBOXES",
                CreateParameter("@LoggedInUser", SqlDbType.VarChar, LoggedInUser));    
        }

        public DataTable Get_AIMS_Mailbox_Emails(Int32 MailBoxID, string LoggedInUser, string MailSearchKeyword)
        {
            return ExecuteDataTable("AIMS_EWS_GET_UNREAD_MAILS",
                                    CreateParameter("@MailBoxID", SqlDbType.VarChar, MailBoxID.ToString()),
                                    CreateParameter("@UserCurrentlyLoggedOn", SqlDbType.VarChar, LoggedInUser.ToString()),
                                    CreateParameter("@MailSearchKeyword", SqlDbType.VarChar, MailSearchKeyword.ToString()));
        }

        public DataTable Get_AIMS_Email_DocTypes(string MailBoxName)
        {
            return ExecuteDataTable("AIMS_EWS_GET_DOCTYPES", 
                CreateParameter("@MailBoxName", SqlDbType.VarChar, MailBoxName.ToString()));
        }

        public DataTable Get_AIMS_Email_Attachment_Mailbox(string EmailAttachmentId)
        {
            return ExecuteDataTable("AIMS_EWS_GET_ATTACHMENT_MAILBOX",
                CreateParameter("@AttachmentId", SqlDbType.VarChar, EmailAttachmentId.ToString()));
        }

        public DataTable Get_AIMS_Reasons(string ReasonTypeCD)
        {
            return ExecuteDataTable("AIMS_GET_REASONS",
                CreateParameter("@REASON_CODE", SqlDbType.VarChar, ReasonTypeCD.ToString()));
        }
        
        public DataTable UpdateMailBoxPODCounter(string MailboxID, string  PODCounter)
        {
            return ExecuteDataTable("AIMS_EWS_MAILBOX_UPDATE_POD_COUNTER",
                                    CreateParameter("@MailboxID", SqlDbType.VarChar, MailboxID.ToString()),
                                    CreateParameter("@Counter", SqlDbType.VarChar, PODCounter));
        }

        public bool SaveSentEmail(ref string PatientSentEmailID, string PatientFileNo, string EmailSentTo, string EmailFromID, string PatientEnquiryID, string EmailSubject, string LoggedOnUser, string EmailToCC)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_EWS_SAVE_SENT_EMAIL",
                                    CreateParameter("@PatientSentEmailID", SqlDbType.VarChar, PatientSentEmailID, 50, ParameterDirection.InputOutput),
                                    CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                                    CreateParameter("@SentTo", SqlDbType.VarChar, EmailSentTo),
                                    CreateParameter("@EmailFromID", SqlDbType.VarChar, EmailFromID),
                                    CreateParameter("@PatientEnquiryID", SqlDbType.VarChar, PatientEnquiryID),
                                    CreateParameter("@EmailSubject", SqlDbType.VarChar, EmailSubject),
                                    CreateParameter("@EmailSentBy", SqlDbType.VarChar, LoggedOnUser),
                                    CreateParameter("@SentToCC", SqlDbType.VarChar, EmailToCC));

            PatientSentEmailID = cmd.Parameters["@PatientSentEmailID"].Value.ToString();
            ReturnValue = true;
            return ReturnValue;
        }

        public DataSet GetPatientSentEmails(string PatientFileNo)
        {
            return ExecuteDataSet("AIMS_EWS_GET_PATIENT_SENT_EMAIL",
                                    CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo.ToString()));
        }

        public DataTable GetPatientEmailDocumentsAttached(string PatientEmailEnquiryID)
        {
            return ExecuteDataTable("AIMS_EWS_GET_PATIENT_EMAIL_DOCS_ATTACHED",
                                    CreateParameter("@PatientEmailEnquiryID", SqlDbType.VarChar, PatientEmailEnquiryID.ToString()));
        }

        public DataTable GetPatientSentEmailDocumentsAttached(string PatientSentEmailID)
        {
            return ExecuteDataTable("AIMS_EWS_GET_PATIENT_SENT_EMAIL_DOCS_ATTACHED",
                                    CreateParameter("@PatientSentEmailID", SqlDbType.VarChar, PatientSentEmailID.ToString()));
        }
        

        public DataTable PatientFileNoVerify(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_VERIFY", CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }

        public DataTable GetServiceProvider(string ServiceProviderID)
        {
            return ExecuteDataTable("AIMS_PATIENT_SERVICE_PROVIDER_GET",
                CreateParameter("@ServiceProviderID", SqlDbType.VarChar, ServiceProviderID));
        }

        public DataTable GetPatientFilesDocs(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_GET_PATIENT_DOCS",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }

        public DataTable GetPatientFilesAppointments(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_GET_PATIENT_APPOINTMENTS",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }

        public DataTable GetPatientFileLetterOfGuarantees(string PatientID)
        {
            return ExecuteDataTable("AIMS_GET_PATIENT_LOG",
                CreateParameter("@Patient_ID", SqlDbType.VarChar, PatientID));
        }

        public DataTable GetPatientFilesTasks(string PatientSubFileID)
        {
            return ExecuteDataTable("AIMS_GET_PATIENT_FILE_TASKS",
                CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientSubFileID));
        }

        public DataTable GetPatientFilesTaskAudit(string PatientSubFileID)
        {
            return ExecuteDataTable("GET_PATIENT_FILE_TASKS_AUDIT",
                CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientSubFileID));
        }

        public DataTable GetPatientFileAppointmentsAudit(string PatientSubFileID)
        {
            return ExecuteDataTable("GET_PATIENT_APPOINTMENTS_AUDIT",
                CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientSubFileID));
        }

        public DataTable GetPatientFilesTasks(string PatientSubFileID, string TaskStatus)
        {
            return ExecuteDataTable("AIMS_GET_PATIENT_FILE_TASKS",
                CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientSubFileID),
                CreateParameter("@TaskStatus", SqlDbType.VarChar, TaskStatus));
        }

        public DataTable GetPatientFilesEmailsProcessed(string PatientSubFileID)
        {
            return ExecuteDataTable("aims_ews_emails_processed",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientSubFileID));
        }
        public DataTable GetPatientFileChemo(string PatientSubFileID)
        {
            return ExecuteDataTable("AIMS_GET_PATIENT_FILE_CHEMO",
                CreateParameter("@PatientFileSubID", SqlDbType.VarChar, PatientSubFileID));
        }

        public DataTable GetPatientFileCycleDates(string PatientSubFileID)
        {
            return ExecuteDataTable("AIMS_GET_PATIENT_FILE_CYCLE_DATES",
                CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientSubFileID));
        }

        public DataTable GetCycleDatesDetails(string CycleDateID)
        {
            return ExecuteDataTable("AIMS_GET_CYCLE_DATE_DETAILS",
                CreateParameter("@CHEMO_CYCLE_ID", SqlDbType.VarChar, CycleDateID));
        }
        public bool SavePatientChemoCycles(ref string ChemoCycleID, string PatientSubFileID, string CycleStartDate, string CycleEndDate, string CyclePlannedYN, string CycleRadioTherapy, string CycleActiveYN, string LoadedBy)
        {
            bool ReturnValue = false;
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_GET_PATIENT_FILE_CYCLE_ADD",
                                    CreateParameter("@CHEMO_CYCLE_ID", SqlDbType.VarChar, ChemoCycleID, 50, ParameterDirection.InputOutput),
                                    CreateParameter("@CHEMO_CYCLE_START_DTTM", SqlDbType.VarChar, CycleStartDate),
                                    CreateParameter("@CHEMO_CYCLE_END_DTTM", SqlDbType.VarChar, CycleEndDate),
                                    CreateParameter("@CHEMO_CYCLE_ACTIVE_YN", SqlDbType.VarChar, CycleActiveYN),
                                    CreateParameter("@CHEMO_CYCLE_PLANNED_YN", SqlDbType.VarChar, CyclePlannedYN),
                                    CreateParameter("@CHEMO_CYCLE_RADIO_THERAPY_YN", SqlDbType.VarChar, CycleRadioTherapy),
                                    CreateParameter("@PATIENT_SUB_FILE_ID", SqlDbType.VarChar, PatientSubFileID));

            ChemoCycleID = cmd.Parameters["@CHEMO_CYCLE_ID"].Value.ToString();

            cmd.Dispose();

            ReturnValue = true;
            return ReturnValue;
        }

        public bool SavePatientFileTask(ref string PatientFileTaskID, string TaskID, string PatientSubFileID, string TaskUser, string TaskDueDate, string TaskCompletionDate, string TaskDetails, string TaskActiveYN, string PriorityID, string LoadedBy, string TaskStatusID)
        {
            bool ReturnValue = false;
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_PATIENT_FILE_TASK_ADD",
                                    CreateParameter("@PatientFileTaskID", SqlDbType.VarChar, PatientFileTaskID, 50, ParameterDirection.InputOutput),
                                    CreateParameter("@TaskID", SqlDbType.VarChar, TaskID),
                                    CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientSubFileID),
                                    CreateParameter("@TaskUser", SqlDbType.VarChar, TaskUser),
                                    CreateParameter("@TaskDueDate", SqlDbType.VarChar, TaskDueDate),
                                    CreateParameter("@TaskCompletionDate", SqlDbType.VarChar, TaskCompletionDate),
                                    CreateParameter("@TaskDetails", SqlDbType.VarChar, TaskDetails),
                                    CreateParameter("@TaskActiveYN", SqlDbType.VarChar, TaskActiveYN),
                                    CreateParameter("@LoadedBy", SqlDbType.VarChar, LoadedBy),
                                    CreateParameter("@PRIORITY_ID", SqlDbType.VarChar, PriorityID),
                                    CreateParameter("@TASK_STATUS_ID", SqlDbType.VarChar, TaskStatusID));

            PatientFileTaskID = cmd.Parameters["@PatientFileTaskID"].Value.ToString();

            cmd.Dispose();

            ReturnValue = true;
            return ReturnValue;
        }

        public bool  RemovePatientSubFileType(string PatientSubFileID)
        {
            bool ReturnValue = false;

            ExecuteNonQuery("AIMS_PATIENT_PATIENT_SUB_FILE_REMOVE",
                                    CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientSubFileID));

            ReturnValue = true;
            return ReturnValue;
        }

        public bool RemovePatientCycleDetail(string CycleDateID)
        {
            bool ReturnValue = false;

            ExecuteNonQuery("AIMS_REMOVE_CYCLE_DATE_DETAIL",
                                    CreateParameter("@CHEMO_CYCLE_ID", SqlDbType.VarChar, CycleDateID));

            ReturnValue = true;
            return ReturnValue;
        }
        
        public DataTable GetPODData(string EmailID)
        {
            return ExecuteDataTable("AIMS_EWS_MAILBOX_POD_INFO",
                                    CreateParameter("@EMAIL_ID", SqlDbType.VarChar, EmailID.ToString()));
        }

        public DataTable GetLimitationCodeValue(string LimitationCode)
        {
            return ExecuteDataTable("AIMS_GET_LIMITATION_CODE_VALUE",
                                    CreateParameter("@LIMITATION_CODE", SqlDbType.VarChar, LimitationCode.ToString()));
        }

        public DataTable GetEmailIndexFileLocation(string EmailAttachmentID)
        {
            return ExecuteDataTable("AIMS_EWS_EMAIL_ATTACHMENT_INFO",
                                    CreateParameter("@EMAIL_ATTACHMENT_ID", SqlDbType.VarChar, EmailAttachmentID.ToString()));
        }

        public bool EmailAttachmentPODDelivery(string EmailAttachFileName, string DocTypeId, string PatientEnquiryID)
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_EWS_EMAIL_POD_DELIVERY",
                                    CreateParameter("@FILE_NAME", SqlDbType.VarChar, EmailAttachFileName.ToString()),
                                    CreateParameter("@DOC_TYPE_ID", SqlDbType.VarChar, DocTypeId.ToString()),
                                    CreateParameter("@PATIENT_ENQUIRY_ID", SqlDbType.VarChar, PatientEnquiryID.ToString()));
            ReturnValue = true;
            return ReturnValue;
        }

        public bool EmailAttachmentReclassify(string NewDocTypeId, string EmailAttachmentID)
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_EWS_EMAIL_ATTACHMENT_RECLASSIFY",
                                    CreateParameter("@NEW_DOC_TYPE_ID", SqlDbType.VarChar, NewDocTypeId.ToString()),
                                    CreateParameter("@EMAIL_ATTACHMENT_ID", SqlDbType.VarChar, EmailAttachmentID.ToString()));
            ReturnValue = true;
            return ReturnValue;
        }

        public bool EmailAttachmentDelete(string EmailAttachmentID)
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_EWS_EMAIL_ATTACHMENT_DELETE",
                                    CreateParameter("@EMAIL_ATTACHMENT_ID", SqlDbType.VarChar, EmailAttachmentID.ToString()));
            ReturnValue = true;
            return ReturnValue;
        }

        public bool EmailSentAttachmentPODDelivery(string EmailAttachFileName, string PatientSentEmailID)
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_EWS_SENT_EMAIL_POD_DELIVERY",
                                    CreateParameter("@FILE_NAME", SqlDbType.VarChar, EmailAttachFileName.ToString()),
                                    CreateParameter("@PATIENT_SENT_EMAIL_ID", SqlDbType.VarChar, PatientSentEmailID.ToString()));
            ReturnValue = true;
            return ReturnValue;
        }

        public DataTable Get_AIMS_Email_Attachments(string EmailID)
        {
            return ExecuteDataTable("AIMS_EWS_GET_EMAIL_ATTACHMENT",
                                    CreateParameter("@EMAIL_ID", SqlDbType.VarChar, EmailID.ToString()));
        }

        public DataTable Get_AIMS_Operator_Work(string CurrentUserLoggedIn)
        {
            return ExecuteDataTable("AIMS_EWS_GET_OPERATOR_WORK",
                                    CreateParameter("@USER_ID", SqlDbType.VarChar, CurrentUserLoggedIn.ToString()));
        }

        

        public DataTable Get_AIMS_Administrator_Work(string CurrentUserLoggedIn)
        {
            return ExecuteDataTable("AIMS_EWS_GET_ADMINISTRATOR_WORK",
                                    CreateParameter("@USER_ID", SqlDbType.VarChar, CurrentUserLoggedIn.ToString()));
        }

        public DataTable Get_AIMS_Workbasket_Audit(string CurrentUserLoggedIn)
        {
            return ExecuteDataTable("AIMS_EWS_GET_WORKBASKET_AUDIT",
                                    CreateParameter("@USER_ID", SqlDbType.VarChar, CurrentUserLoggedIn.ToString()));
        }

        public DataTable Get_AIMS_Admin_Workbasket_Audit(string CurrentUserLoggedIn)
        {
            return ExecuteDataTable("AIMS_EWS_GET_ADMIN_WORKBASKET_AUDIT",
                                    CreateParameter("@USER_ID", SqlDbType.VarChar, CurrentUserLoggedIn.ToString()));
        }
        

        public DataTable Get_AIMS_TransportCases()
        {
            return ExecuteDataTable("AIMS_GET_TRANSPORT_CASES");
        }

        public DataTable Get_AIMS_OverdueTasks()
        {
            return ExecuteDataTable("AIMS_GET_OVERDUE_TASKS");
        }

        public DataTable Get_My_Instant_Messages_Audit(string CurrentUserLoggedIn)
        {
            return ExecuteDataTable("AIMS_EWS_MY_INSTANT_MESSAGES_AUDIT",
                                    CreateParameter("@IM_USER", SqlDbType.VarChar, CurrentUserLoggedIn.ToString()));
        }
        public DataTable Get_My_Instant_Messages(string CurrentUserLoggedIn)
        {
            return ExecuteDataTable("AIMS_EWS_MY_INSTANT_MESSAGES",
                                    CreateParameter("@IM_USER", SqlDbType.VarChar, CurrentUserLoggedIn.ToString()));
        }

        public DataTable Get_My_Tasks(string CurrentUserLoggedIn)
        {
            return ExecuteDataTable("AIMS_EWS_MY_TASKS",
                                    CreateParameter("@IM_USER", SqlDbType.VarChar, CurrentUserLoggedIn.ToString()));
        }

        public bool Clear_My_Instant_Messages(string UserID)
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_EWS_CLEAR_IM",
                            CreateParameter("@IM_USER", SqlDbType.VarChar, UserID));
            ReturnValue = true;
            return ReturnValue;
        }
        
        public DataTable Get_Patient_File_Operator(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_EWS_GET_PATIENT_FILE_OPERATOR",
                                    CreateParameter("@PATIENT_FILE_NO", SqlDbType.VarChar, PatientFileNo.ToString()));
        }

        public DataTable Get_AIMS_Active_Users()
        {
            return ExecuteDataTable("AIMS_GET_ALL_ACTIVE_USERS");
        }
        
        public DataTable Get_AIMS_Patient_Email_Docs(string PatientEmailEnquiryID)
        {
            return ExecuteDataTable("AIMS_EWS_GET_PATIENT_EMAIL_DOCS",
                                    CreateParameter("@PATIENT_EMAIL_ENQUIRY_ID", SqlDbType.VarChar, PatientEmailEnquiryID.ToString()));
        }

        public DataTable Get_AIMS_Patient_Sent_Email_Docs(string PatientSentEmailID)
        {
            return ExecuteDataTable("AIMS_EWS_GET_PATIENT_SENT_EMAIL_DOCS",
                                    CreateParameter("@PATIENT_SENT_EMAIL_ID", SqlDbType.VarChar, PatientSentEmailID.ToString()));
        }
        
        public DataTable Get_AIMS_Email_Info(string EmailID)
        {
            return ExecuteDataTable("AIMS_EWS_GET_EMAIL_INFO",
                                    CreateParameter("@EMAIL_ID", SqlDbType.VarChar, EmailID.ToString()));
        }

        public bool AIMS_Email_Delete(string EmailID)
        {
            bool ReturnValue = false; ;
            ExecuteNonQuery("AIMS_EWS_EMAIL_DELETE",
                                    CreateParameter("@EMAIL_ID", SqlDbType.VarChar, EmailID.ToString()));
            ReturnValue = true;
            return ReturnValue;
        }

        public bool AIMS_Lock_Email(string EmailID, string UserLoggedOn, string LockEmail, string EmailReadYN)
        {
            bool ReturnValue = false; ;
            ExecuteNonQuery("AIMS_EWS_LOCK_EMAIL",
                                    CreateParameter("@EMAIL_ID", SqlDbType.VarChar, EmailID.ToString()),
                                    CreateParameter("@UserLoggedOn", SqlDbType.VarChar, UserLoggedOn.ToString()),
                                    CreateParameter("@LockEmailYN", SqlDbType.VarChar, LockEmail.ToString()),
                                    CreateParameter("@EmailReadYN", SqlDbType.VarChar, EmailReadYN.ToString()));
            ReturnValue = true;
            return ReturnValue;
        }

        public bool AIMS_Email_Read(string PatientEmailEnquiryID)
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_EWS_EMAIL_READ",
                                    CreateParameter("@PatientEmailEnquiryID", SqlDbType.VarChar, PatientEmailEnquiryID.ToString()));
            ReturnValue = true;
            return ReturnValue;
        }

        public bool AIMS_Email_Processed(string PatientEmailEnquiryID, string LoggedInUser)
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_EWS_EMAIL_PROCESSED",
                                    CreateParameter("@PatientEmailEnquiryID", SqlDbType.VarChar, PatientEmailEnquiryID.ToString()),
                                    CreateParameter("@LoggedInUser", SqlDbType.VarChar, LoggedInUser.ToString()));
            ReturnValue = true;
            return ReturnValue;
        }

        
        public DataTable ValidPatientFileNo(string PatientFileNo)
        {
            DataTable dtPatientFileNoCheck = new DataTable();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            dtPatientFileNoCheck = invoiceDAL.PatientFileNoVerify(PatientFileNo);
            return dtPatientFileNoCheck;
        }

        public bool AddPatientFileEmail(string PatientFileNo, string Email_ID, ref string PatientEnquiryID, string UrgentEmail, string File13Query, string IndexedBy, string MailBoxName)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_EWS_PATIENT_EMAIL_SAVE",
                CreateParameter("@PatientEnquiryID", SqlDbType.VarChar, PatientEnquiryID, 50, ParameterDirection.InputOutput),
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                CreateParameter("@EMAIL_ID", SqlDbType.VarChar, Email_ID),
                CreateParameter("@URGENT_EMAIL", SqlDbType.VarChar, UrgentEmail),
                CreateParameter("@QUERY_EMAIL", SqlDbType.VarChar, File13Query),
                CreateParameter("@INDEXED_BY", SqlDbType.VarChar, IndexedBy),
                CreateParameter("@MAILBOX_NAME", SqlDbType.VarChar, MailBoxName.ToUpper())
                );

            PatientEnquiryID = cmd.Parameters["@PatientEnquiryID"].Value.ToString();

            ReturnValue = true;
            return ReturnValue;
        }

        public DataTable CheckGuaranteeAuth(string UserID, string GuaranteeAmount, string GuarantorID)
        {   
            return ExecuteDataTable("AIMS_USER_AUTH_CHECK",
                CreateParameter("@UserID", SqlDbType.VarChar, UserID),
                CreateParameter("@GuaranteeAmount", SqlDbType.VarChar, GuaranteeAmount),
                CreateParameter("@GuarantorID", SqlDbType.VarChar, GuarantorID));
        }

        public DataTable GetPatientTypeOfFiles(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_FILE_TYPES_GET", 
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }
        

        public bool CreatePendedNewFile(ref string PatientFileNo, string LoggedOnUser, string PendDate)
        {
            bool retValue = false;
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_PATIENT_ADD_SINGLE",
               CreateParameter("@PatientFileNo", SqlDbType.VarChar, "", 50, ParameterDirection.InputOutput),
               CreateParameter("@UserLoggedOn", SqlDbType.VarChar, LoggedOnUser),
               CreateParameter("@PendDate", SqlDbType.VarChar, PendDate));

            PatientFileNo = cmd.Parameters["@PatientFileNo"].Value.ToString();

            cmd.Dispose();

            retValue = true;
            return retValue;
        }

        public bool SaveVisaLetterPOD(String VisaLetterID, string VisaLetterFileName, string VisaLetterPOD) 
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_PATIENT_ATTACH_VISA_LETTER",
                                    CreateParameter("@VisaLetterID", SqlDbType.VarChar, VisaLetterID),
                                    CreateParameter("@VisaLetterFileName", SqlDbType.VarChar, VisaLetterPOD));
            ReturnValue = true;
            return ReturnValue;
        }

        public bool UpdatePatientFileType(string PatientSubFileID, string FileTypeID, string FileTypeCategoryID) 
        {
            bool ReturnValue = false;
            ExecuteNonQuery("AIMS_PATIENT_FILE_TYPE",
                            CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientSubFileID),
                            CreateParameter("@SubFileTypeID", SqlDbType.VarChar, FileTypeID),
                            CreateParameter("@SubFileTypeCategoryID", SqlDbType.VarChar, FileTypeCategoryID));
            ReturnValue = true;
            return ReturnValue;
        }

        public bool SaveVisaLetter(ref string VISALetterID, string LoggedOnUser, string VISALetterFile, string EmbassyName, string EmbassyAdd1, 
                            string EmbassyAdd2, string EmbassyAdd3, string EmbassyAdd4, string EmbassyAdd5, string Country,
                            string PatientName, string PatientPassportNo, string PatientPassportIssueDt, string PatientPassportExpiryDt,
                            string EscortName, string EscortRelationToPatient, string EscortPassportNo, string EscortPassportIssueDt, 
                            string EscortPassportExpiryDt, string EscortHisHer, string CountryOfTreatment, string TreatingDoctor, 
                            string TreatingDoctorProfession,string TreatingHospital, string AimsCoOrdinator, string TreatmentDate,
                            string PatientResidingAddress, string AddressType, string PatientFileNo, string EmbassyID, string userID)
        {
            bool retValue = false;
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_PATIENT_ADD_VISA_LETTER",
                CreateParameter("@VisaLetterID",            SqlDbType.VarChar, "", 50, ParameterDirection.InputOutput),
                CreateParameter("@LoggedOnUser",            SqlDbType.VarChar, LoggedOnUser),
                CreateParameter("@VISALetterFile",          SqlDbType.VarChar, VISALetterFile),
                CreateParameter("@EmbassyName",             SqlDbType.VarChar, EmbassyName),
                CreateParameter("@EmbassyAdd1",             SqlDbType.VarChar, EmbassyAdd1),
                CreateParameter("@EmbassyAdd2",             SqlDbType.VarChar, EmbassyAdd2),
                CreateParameter("@EmbassyAdd3",             SqlDbType.VarChar, EmbassyAdd3),
                CreateParameter("@EmbassyAdd4",             SqlDbType.VarChar, EmbassyAdd4),
                CreateParameter("@EmbassyAdd5",             SqlDbType.VarChar, EmbassyAdd5),
                CreateParameter("@Country",                 SqlDbType.VarChar, Country),
                CreateParameter("@PatientName",             SqlDbType.VarChar, PatientName),
                CreateParameter("@PatientPassportNo",       SqlDbType.VarChar, PatientPassportNo),
                CreateParameter("@PatientPassportIssueDt",  SqlDbType.VarChar, PatientPassportIssueDt),
                CreateParameter("@PatientPassportExpiryDt", SqlDbType.VarChar, PatientPassportExpiryDt),
                CreateParameter("@EscortName",              SqlDbType.VarChar, EscortName),
                CreateParameter("@EscortRelationToPatient", SqlDbType.VarChar, EscortRelationToPatient),
                CreateParameter("@EscortPassportNo",        SqlDbType.VarChar, EscortPassportNo),
                CreateParameter("@EscortPassportIssueDt",   SqlDbType.VarChar, EscortPassportIssueDt),
                CreateParameter("@EscortPassportExpiryDt",  SqlDbType.VarChar, EscortPassportExpiryDt),
                CreateParameter("@EscortHisHer",            SqlDbType.VarChar, EscortHisHer),
                CreateParameter("@CountryOfTreatment",      SqlDbType.VarChar, CountryOfTreatment),
                CreateParameter("@TreatingDoctor",          SqlDbType.VarChar, TreatingDoctor),
                CreateParameter("@TreatingDoctorProfession",SqlDbType.VarChar, TreatingDoctorProfession),
                CreateParameter("@TreatingHospital",        SqlDbType.VarChar, TreatingHospital),
                CreateParameter("@AimsCoOrdinator",         SqlDbType.VarChar, AimsCoOrdinator),
                CreateParameter("@TreatmentDate",           SqlDbType.VarChar, TreatmentDate),
                CreateParameter("@PatientResidingAddress",  SqlDbType.VarChar, PatientResidingAddress),
                CreateParameter("@AddressType",             SqlDbType.VarChar, AddressType),
                CreateParameter("@PatientFileNo",           SqlDbType.VarChar, PatientFileNo),
                CreateParameter("@EmbassyID", SqlDbType.VarChar, EmbassyID),
                CreateParameter("@LoadedBy", SqlDbType.VarChar, userID));

            VISALetterID = cmd.Parameters["@VisaLetterID"].Value.ToString();

            cmd.Dispose();

            retValue = true;
            return retValue;
        }

        public bool SendInstantMessage(string PatientFileNo, string FromUserID, string ToUserID, string strMessage)
        {
            bool retValue = false;

            ExecuteNonQuery("AIMS_EWS_ADD_IM",
               CreateParameter("@IM_TEXT", SqlDbType.VarChar, strMessage),
               CreateParameter("@IM_FROM", SqlDbType.VarChar, FromUserID),
               CreateParameter("@IM_TO", SqlDbType.VarChar, ToUserID),
               CreateParameter("@IM_PATIENT_FILE_NO", SqlDbType.VarChar, PatientFileNo));

            retValue = true;
            return retValue;
        }

        public bool ReIndexPatientFile(string PatientEmaiEnquirylID, string PatientFileNo, string LoggedOnUser)
        {
            bool ReturnValue = false;
       
            ExecuteNonQuery("AIMS_EWS_PATIENT_EMAIL_REINDEX",
                                    CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                                    CreateParameter("@PatientFileEmailEnquiryID", SqlDbType.VarChar, PatientEmaiEnquirylID),
                                    CreateParameter("@UserLoggedOn", SqlDbType.VarChar, LoggedOnUser));

            ReturnValue = true;
            return ReturnValue;
        }

        public bool RemovePatientFileEmail(string PatientEmaiEnquirylID)
        {
            bool ReturnValue = false;

            ExecuteNonQuery("AIMS_EWS_PATIENT_EMAIL_REMOVE",
                                    CreateParameter("@PatientFileEmailEnquiryID", SqlDbType.VarChar, PatientEmaiEnquirylID));

            ReturnValue = true;
            return ReturnValue;
        }

        public bool RemovePatientFileDoc(string PatientFileNo, string DocumentID, string DocumentName)
        {
            bool ReturnValue = false;

            ExecuteNonQuery("AIMS_PATIENT_DEL_PATIENT_DOCS",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                CreateParameter("@DocumentID", SqlDbType.VarChar, DocumentID),
                CreateParameter("@DocumentType", SqlDbType.VarChar, DocumentName));

            ReturnValue = true;
            return ReturnValue;
        }

        public bool EmailIndexedFlag(string Email_ID)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            ExecuteNonQuery( "AIMS_EWS_PATIENT_EMAIL_INDEXED", CreateParameter("@EMAIL_ID", SqlDbType.VarChar, Email_ID));

            ReturnValue = true;
            return ReturnValue;
        }

        public bool PatientSubFileAdd(string PatientFileNo, string SubFileTypeID, string SubFileTypeCategoryID, ref string PatientSubFileID)
        {
            bool ReturnValue = false;
            SqlCommand cmd; 
            ExecuteNonQuery(out cmd, "AIMS_EWS_PATIENT_SUB_FILE_ADD",
                                    CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                                    CreateParameter("@SubFileTypeID", SqlDbType.VarChar, SubFileTypeID),
                                    CreateParameter("@SubFileTypeCategoryID", SqlDbType.VarChar, SubFileTypeCategoryID),
                                    CreateParameter("@PatientSubFileID", SqlDbType.VarChar, "", 50, ParameterDirection.InputOutput));

            PatientSubFileID = cmd.Parameters["@PatientSubFileID"].Value.ToString();

            ReturnValue = true;
            return ReturnValue;
        }

        public bool PatuientSubFileRemove(string PatientFileNo, string SubFileTypeID)
        {
            bool ReturnValue = false;

            ExecuteNonQuery("AIMS_EWS_PATIENT_SUB_FILE_REMOVE",
                                    CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                                    CreateParameter("@SubFileTypeID", SqlDbType.VarChar, SubFileTypeID));

            ReturnValue = true;
            return ReturnValue;
        }

        public bool SaveEmbassy(ref string EmbassyID, string EmbassyName, string EmbassyTelNo, string EmbassyFaxNo, string EmbassyAddress1, string EmbassyAddress2, string EmbassyAddress3, string EmbassyAddress4, string EmbassyAddress5, string EmbassyCountry, string EmbassyContactPerson, string EmbassyActiveYN)
        {
            bool ReturnValue = false;

            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_EMBASSY_ADD",
                            CreateParameter("@EmbassyID", SqlDbType.VarChar, EmbassyID, 50, ParameterDirection.InputOutput),
                            CreateParameter("@EmbassyName", SqlDbType.VarChar, EmbassyName),
                            CreateParameter("@EmbassyTelNo", SqlDbType.VarChar, EmbassyTelNo),
                            CreateParameter("@EmbassyFaxNo", SqlDbType.VarChar, EmbassyFaxNo),
                            CreateParameter("@EmbassyAdd1", SqlDbType.VarChar, EmbassyAddress1),
                            CreateParameter("@EmbassyAdd2", SqlDbType.VarChar, EmbassyAddress2),
                            CreateParameter("@EmbassyAdd3", SqlDbType.VarChar, EmbassyAddress3),
                            CreateParameter("@EmbassyAdd4", SqlDbType.VarChar, EmbassyAddress4),
                            CreateParameter("@EmbassyAdd5", SqlDbType.VarChar, EmbassyAddress5),
                            CreateParameter("@EmbassyAddressCountry", SqlDbType.VarChar, EmbassyCountry),
                            CreateParameter("@EmbassyContactPerson", SqlDbType.VarChar, EmbassyContactPerson),
                            CreateParameter("@EMBASSY_ACTIVE_YN", SqlDbType.VarChar, EmbassyActiveYN));

            EmbassyID = cmd.Parameters["@EmbassyID"].Value.ToString();

            cmd.Dispose();

            ReturnValue = true;
            return ReturnValue;
        }

        public bool SaveCalenderAppointment(ref string CalenderAppointmentId, 
                                            string AppointmentSubject,
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
            bool ReturnValue = false;

            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_CALENDER_APPOINTMENT_ADD",
                            CreateParameter("@CalenderAppointmentId", SqlDbType.VarChar, CalenderAppointmentId, 50, ParameterDirection.InputOutput),
                            CreateParameter("@AppointmentSubject", SqlDbType.VarChar, AppointmentSubject),
                            CreateParameter("@AppointmentAddress", SqlDbType.VarChar, AppointmentAddress),
                            CreateParameter("@AppointmentDate", SqlDbType.VarChar, AppointmentDate),
                            CreateParameter("@AppointmentTimeHour", SqlDbType.VarChar, AppointmentTimeHour),
                            CreateParameter("@AppointmentTimeMinute", SqlDbType.VarChar, AppointmentTimeMinute),
                            CreateParameter("@AppointmentReminderYN", SqlDbType.VarChar, AppointmentReminderYN),
                            CreateParameter("@AppointmentReminderPeriod", SqlDbType.VarChar, AppointmentReminderPeriod),
                            CreateParameter("@AppointmentTransportRequiredYN", SqlDbType.VarChar, AppointmentTransportRequiredYN),
                            CreateParameter("@AppointmentNote", SqlDbType.VarChar, AppointmentNote),
                            CreateParameter("@AppointmentTime", SqlDbType.DateTime, AppointmentTime));

            CalenderAppointmentId = cmd.Parameters["@CalenderAppointmentId"].Value.ToString();

            cmd.Dispose();

            ReturnValue = true;
            return ReturnValue;
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
            bool ReturnValue = false;

            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_APPOINTMENT_ADD",
                            CreateParameter("@AppointmentID", SqlDbType.VarChar, AppointmentId, 50, ParameterDirection.InputOutput),
                            CreateParameter("@AppointmentSubject", SqlDbType.VarChar, AppointmentSubject),
                            CreateParameter("@AppointmentAddress", SqlDbType.VarChar, AppointmentAddress),
                            CreateParameter("@AppointmentDate", SqlDbType.VarChar, AppointmentDate),
                            CreateParameter("@AppointmentTimeHour", SqlDbType.VarChar, AppointmentTimeHour),
                            CreateParameter("@AppointmentTimeMinute", SqlDbType.VarChar, AppointmentTimeMinute),
                            CreateParameter("@AppointmentReminderYN", SqlDbType.VarChar, AppointmentReminderYN),
                            CreateParameter("@AppointmentReminderPeriod", SqlDbType.VarChar, AppointmentReminderPeriod),
                            CreateParameter("@AppointmentTransportRequiredYN", SqlDbType.VarChar, AppointmentTransportRequiredYN),
                            CreateParameter("@AppointmentTransportType", SqlDbType.VarChar, AppointmentTransportType),
                            CreateParameter("@AppointmentPickUpTimeHour", SqlDbType.VarChar, AppointmentPickUpTimeHour),
                            CreateParameter("@AppointmentPickUpTimeMinute", SqlDbType.VarChar, AppointmentPickUpTimeMinute),
                            CreateParameter("@AppointmentDropOffTimeHour", SqlDbType.VarChar, AppointmentDropOffTimeHour),
                            CreateParameter("@AppointmentDropOffTimeMinute", SqlDbType.VarChar, AppointmentDropOffTimeMinute),
                            CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientID),
                            CreateParameter("@CreatedBy", SqlDbType.VarChar, CreatedBy),
                            CreateParameter("@AppointmentNote", SqlDbType.VarChar, AppointmentNote),
                            CreateParameter("@AppointmentTime", SqlDbType.DateTime, AppointmentTime),
                            CreateParameter("@PickUpTime", SqlDbType.DateTime, PickUpTime),
                            CreateParameter("@DropOffTime", SqlDbType.DateTime, DropOffTime),
                            CreateParameter("@TranslatorYN", SqlDbType.VarChar, TranslatorYN),
                            CreateParameter("@CalenderAppointmentLoadId", SqlDbType.VarChar, CalenderAppointmentLoadId));

            AppointmentId = cmd.Parameters["@AppointmentID"].Value.ToString();

            cmd.Dispose();

            ReturnValue = true;
            return ReturnValue;
        }

        public bool SaveAAOption(ref string AAOptionId, string AAAirCraft,
                                            string AAAvailibity,
                                             string AACost,
                                               string AALevelOfCare,
                                                string AARouting, string CreatedBy, string PatientID,
                                                string AdminFee,
                                                string AmbulanceReferrring,
                                                string AmbulanceReceiving,
                                                string AirportOperatingHours)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_AAOPTION_ADD",
                            CreateParameter("@AAOptionId", SqlDbType.VarChar, AAOptionId, 50, ParameterDirection.InputOutput),
                            CreateParameter("@AAAirCraft", SqlDbType.VarChar, AAAirCraft),
                            CreateParameter("@AAAvailibity", SqlDbType.VarChar, AAAvailibity),
                            CreateParameter("@AACost", SqlDbType.VarChar, AACost),
                            CreateParameter("@AALevelOfCare", SqlDbType.VarChar, AALevelOfCare),
                            CreateParameter("@AARouting", SqlDbType.VarChar, AARouting),
                            CreateParameter("@CreatedBy", SqlDbType.VarChar, CreatedBy),
                            CreateParameter("@PatientId", SqlDbType.VarChar, PatientID),
                            CreateParameter("@ADMIN_FEE", SqlDbType.VarChar, AdminFee),
                            CreateParameter("@AMBULANCE_REFERRING", SqlDbType.VarChar, AmbulanceReferrring),
                            CreateParameter("@AMBULANCE_RECEIVING", SqlDbType.VarChar, AmbulanceReceiving),
                            CreateParameter("@AIRPORT_OPERATING_HOURS", SqlDbType.VarChar, AirportOperatingHours));

            AAOptionId = cmd.Parameters["@AAOptionId"].Value.ToString();
            cmd.Dispose();
            ReturnValue = true;
            return ReturnValue;
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
                                    string UserId, string AirAmbulanceCELetter,
                                    string PatientPassportNo,
                                    string AAAddressToName
        )
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_AADETAILS_ADD",
                            CreateParameter("@PatientID", SqlDbType.VarChar, PatientID),
                            CreateParameter("@PatientYellowFeverCert", SqlDbType.VarChar, PatientYellowFeverCert),
                            CreateParameter("@PatientWeightHeight", SqlDbType.VarChar, PatientWeightHeight),
                            CreateParameter("@RefHosNameLocation", SqlDbType.VarChar, RefHosNameLocation),
                            CreateParameter("@RefHosTel", SqlDbType.VarChar, RefHosTelNo),
                            CreateParameter("@RefHosEmail", SqlDbType.VarChar, RefHosEmail),
                            CreateParameter("@RefHosDrName", SqlDbType.VarChar, RefHosDrName),
                            CreateParameter("@RefHosDrNameTel", SqlDbType.VarChar, RefHosDrNameTel),
                            CreateParameter("@RefHosDrNameEmail", SqlDbType.VarChar, RefHosDrNameEmail),
                            CreateParameter("@AccomMemNameSur", SqlDbType.VarChar, AccomMemNameSur),
                            CreateParameter("@AccomMemNationality", SqlDbType.VarChar, AccomMemNationality),
                            CreateParameter("@AccomMemPassportNo", SqlDbType.VarChar, AccomMemPassportNo),
                            CreateParameter("@AccomMemYelFeverCert", SqlDbType.VarChar, AccomMemYelFeverCert),
                            CreateParameter("@AccomMemWeightHeight", SqlDbType.VarChar, AccomMemWeightHeight),
                            CreateParameter("@VHFFormRequiredYN", SqlDbType.VarChar, VhfFormRequiredYN),
                            CreateParameter("@UserId", SqlDbType.VarChar, UserId),
                            CreateParameter("@AirAmbulanceCELetter", SqlDbType.VarChar, AirAmbulanceCELetter),
                            CreateParameter("@PatientPassportNo", SqlDbType.VarChar, PatientPassportNo),
                            CreateParameter("@AAAddressToName", SqlDbType.VarChar, AAAddressToName));
            cmd.Dispose();
            ReturnValue = true;
            return ReturnValue;
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
                                            string Currency)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_ACCOMODATION_ADD",
                            CreateParameter("@Accomodation", SqlDbType.VarChar, Accomodation),
                            CreateParameter("@GuestName", SqlDbType.VarChar, GuestName),
                            CreateParameter("@GuestRefNo", SqlDbType.VarChar, GuestRefNo),
                            CreateParameter("@GuestNoOfRooms", SqlDbType.VarChar, GuestNoOfRooms),
                            CreateParameter("@GuestArrivalDate", SqlDbType.VarChar, GuestArrivalDate),
                            CreateParameter("@GuestFlightArrivalTime", SqlDbType.VarChar, GuestFlightArrivalTime),
                            CreateParameter("@GuestDepartDate", SqlDbType.VarChar, GuestDepartDate),
                            CreateParameter("@GuestAimsSettle", SqlDbType.VarChar, GuestAimsSettle),
                            CreateParameter("@GuestCountryOfRegion", SqlDbType.VarChar, GuestCountryOfRegion),
                            CreateParameter("@Religion", SqlDbType.VarChar, Religion),
                            CreateParameter("@DiabeticMeals", SqlDbType.VarChar, DiabeticMeals),
                            CreateParameter("@BedAndBreakFast", SqlDbType.VarChar, BedAndBreakFast),
                            CreateParameter("@Meals", SqlDbType.VarChar, Meals),
                            CreateParameter("@Laundry", SqlDbType.VarChar, Laundry),
							CreateParameter("@Telephone", SqlDbType.VarChar, Telephone),
							CreateParameter("@MiniBar", SqlDbType.VarChar, MiniBar),
							CreateParameter("@SpecialRequest", SqlDbType.VarChar, SpecialRequest),
                            CreateParameter("@PatientID", SqlDbType.VarChar, PatientID),
                            CreateParameter("@UserID", SqlDbType.VarChar, UserID),
                            CreateParameter("@AccomodationLetter", SqlDbType.VarChar, AccomodationLetter),
                            CreateParameter("@ContactTelMobileNo", SqlDbType.VarChar, ContactTelMobileNo),
                            CreateParameter("@ContactEmailAddress", SqlDbType.VarChar, ContactEmailAddress),
                            CreateParameter("@DOB", SqlDbType.VarChar, DOB),
                            CreateParameter("@NoOfGuests", SqlDbType.VarChar, NoOfGuests),
                            CreateParameter("@RoomRatePerNight", SqlDbType.VarChar, RoomRatePerNight),
                            CreateParameter("@RoomType", SqlDbType.VarChar, RoomType),
                            CreateParameter("@MealBreakFast", SqlDbType.VarChar, MealBreakFast),
                            CreateParameter("@MealBreakLunch", SqlDbType.VarChar, MealBreakLunch),
                            CreateParameter("@MealBreakDinner", SqlDbType.VarChar, MealBreakDinner),
                            CreateParameter("@MealBreakFullBoard", SqlDbType.VarChar, MealBreakFullBoard),
                            CreateParameter("@SocialTransport", SqlDbType.VarChar, SocialTransport),
                            CreateParameter("@AdditionalNotes", SqlDbType.VarChar, AdditionalNotes),
                            CreateParameter("@Currency", SqlDbType.VarChar, Currency));
            cmd.Dispose();
            ReturnValue = true;
            return ReturnValue;
        }

        public bool CancelAppointment(string AppointmentID, string userName)
        {
            bool ReturnValue = false;

            ExecuteNonQuery("AIMS_PATIENT_CANCEL_APPOINTMENTS",
                                    CreateParameter("@AppointmentID", SqlDbType.VarChar, AppointmentID),
                                    CreateParameter("@UserName", SqlDbType.VarChar, userName));

            ReturnValue = true;
            return ReturnValue;
        }

        public bool CompleteAppointment(string AppointmentID, string userName)
        {
            bool ReturnValue = false;

            ExecuteNonQuery("AIMS_PATIENT_COMPLETE_APPOINTMENTS",
                                    CreateParameter("@AppointmentID", SqlDbType.VarChar, AppointmentID),
                                    CreateParameter("@UserName", SqlDbType.VarChar, userName));

            ReturnValue = true;
            return ReturnValue;
        }

        

        public bool GOPRunningTotalLimit(string PatientId, string GOP_Amount)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            string strOverLimit = "";
            ExecuteNonQuery(out cmd, "AIMS_PATIENT_GUARANTEE_CALC",
                                    CreateParameter("@PatientId", SqlDbType.VarChar, PatientId),
                                    CreateParameter("@GOP_AMOUNT", SqlDbType.VarChar, GOP_Amount),
                                    CreateParameter("@GOP_OVER_LIMIT", SqlDbType.VarChar, strOverLimit, 50, ParameterDirection.InputOutput));

            strOverLimit = cmd.Parameters["@GOP_OVER_LIMIT"].Value.ToString();
            if (strOverLimit.Equals("Y"))
            {
                ReturnValue = true;
            }
            return ReturnValue;
        }

        public bool UserGOPOverLimit(string GOPAmount, string UserId, string PatientID)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            string strOverLimit = "";
            ExecuteNonQuery(out cmd, "AIMS_USER_GOP_LIMIT_CHECK",
                                    CreateParameter("@UserID", SqlDbType.VarChar, UserId),
                                    CreateParameter("@PatientId", SqlDbType.VarChar, PatientID),
                                    CreateParameter("@GOP_AMOUNT", SqlDbType.VarChar, GOPAmount),
                                    CreateParameter("@GOP_OVER_LIMIT", SqlDbType.VarChar, strOverLimit, 50, ParameterDirection.InputOutput));

            strOverLimit = cmd.Parameters["@GOP_OVER_LIMIT"].Value.ToString();
            if (strOverLimit.Equals("Y"))
            {
                ReturnValue = true;
            }
            return ReturnValue;
        }

        public bool GOPApproved(string GOPId)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            string strOverLimit = "";
            ExecuteNonQuery(out cmd, "AIMS_PATIENT_GUARANTEE_APPROVE",
                                    CreateParameter("@GOP_ID", SqlDbType.VarChar, GOPId));

            ReturnValue = true;
            return ReturnValue;
        }

        public bool IsGOPApproved(string GOPId)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            string strGOPApprovedYN= "";
            ExecuteNonQuery(out cmd, "AIMS_PATIENT_GUARANTEE_APPROVED_YN",
                                    CreateParameter("@GOP_ID", SqlDbType.VarChar, GOPId),
                                    CreateParameter("@GOP_APPROVED_YN", SqlDbType.VarChar, strGOPApprovedYN, 50, ParameterDirection.InputOutput));

            strGOPApprovedYN = cmd.Parameters["@GOP_APPROVED_YN"].Value.ToString();
            if (strGOPApprovedYN.Equals("Y"))
            {
                ReturnValue = true;
            }
      
            return ReturnValue;
        }

        public DataTable GetEmbassyDetails(string EmbassyID)
        {
            return ExecuteDataTable("AIMS_EMBASSY_GET", CreateParameter("@EmbassyID", SqlDbType.VarChar, EmbassyID));
        }

        public DataTable GetTaskDetails(string PatientFileTaskID)
        {
            return ExecuteDataTable("AIMS_TASK_GET", CreateParameter("@PatientFileTaskID", SqlDbType.VarChar, PatientFileTaskID));
        }

        public DataTable GetAppointmentDetails(string AppointmentID)
        {
            return ExecuteDataTable("AIMS_APPOINTMENT_GET", CreateParameter("@AppointmentID", SqlDbType.VarChar, AppointmentID));
        }

        public DataTable GetAAOptions(string PatientID)
        {
            return ExecuteDataTable("AIMS_GET_AAOPTIONS", CreateParameter("@Patient_ID", SqlDbType.VarChar, PatientID));
        }

        public DataTable GetEmbassies()
        {
            return ExecuteDataTable("AIMS_EMBASSIES_GET");
        }

        public string GetDueDate(DateTime fileReceivedDttm)
        {
            SqlCommand cmd;
            string returnValue = "";
            DateTime dueDate = DateTime.Now;
            ExecuteNonQuery(out cmd, "AIMS_GET_DUE_DATE",
                                    CreateParameter("@FileReceivedDate", SqlDbType.Date, fileReceivedDttm),
                                    CreateParameter("@dueDateCheck", SqlDbType.Date, dueDate, 50, ParameterDirection.InputOutput));

            dueDate = Convert.ToDateTime(cmd.Parameters["@dueDateCheck"].Value);
            if (dueDate!=null )
            {
                returnValue = dueDate.ToString("dd/MM/yyyy");    
            }
            
            return returnValue;
        }
    }
}