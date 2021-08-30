using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EWS.AIMS.DAL
{
    public class EWSDAL:DataServiceBase
    {
        #region "Private and Public Declarations"
        private string _connectionstring = "";
        public string Connectionstring { get { return _connectionstring; } set { _connectionstring = value; } }
        #endregion

        #region "Public Methods"

        #region "Datatable GET Methods"
        public DataTable Get_AIMS_Mailboxes()
        {
            DataTable dtMailboxes = new DataTable();

            using (dtMailboxes)
            {
                dtMailboxes = ExecuteDataTable("AIMS_EWS_GET_MAILBOXES");
                return dtMailboxes;
            }
        } 
        public DataTable Get_AIMS_Param(string ParamCode)
        {
            DataTable dtPara = new DataTable();

            return dtPara;
        }



        public bool AIMS_EWS_Delete_EmailInfo(string EMAIL_ID)
        {
            bool ReturnValue = false;
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_EWS_DELATE_EMAIL_INFO", CreateParameter("@EMAIL_ID", SqlDbType.VarChar, EMAIL_ID));

            cmd.Dispose();
            ReturnValue = true;
            return ReturnValue;
        }

        public bool AddPatientFileEmail(string PatientFileNo, string Email_ID, ref string PatientEnquiryID, string UrgentEmail, string File13Query, string MailBoxName)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_EWS_PATIENT_EMAIL_SAVE",
                CreateParameter("@PatientEnquiryID", SqlDbType.VarChar, PatientEnquiryID, 50, ParameterDirection.InputOutput),
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                CreateParameter("@EMAIL_ID", SqlDbType.VarChar, Email_ID),
                CreateParameter("@URGENT_EMAIL", SqlDbType.VarChar, UrgentEmail),
                CreateParameter("@QUERY_EMAIL", SqlDbType.VarChar, File13Query),
                CreateParameter("@INDEXED_BY", SqlDbType.VarChar, ""),
                CreateParameter("@MAILBOX_NAME", SqlDbType.VarChar, MailBoxName));

            PatientEnquiryID = cmd.Parameters["@PatientEnquiryID"].Value.ToString();

            ReturnValue = true;
            return ReturnValue;
        }

        public bool AddPatientFileTask(string PatientFileNo, string Email_ID, ref string PatientEnquiryID, string UrgentEmail, string File13Query, string MailBoxName)
        {
            bool ReturnValue = false;
            DateTime dtTaskDueDate = new DateTime();

            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_PATIENT_FILE_TASK_ADD",
                CreateParameter("@PatientFileTaskID", SqlDbType.VarChar, PatientEnquiryID, 50, ParameterDirection.InputOutput),
                CreateParameter("@TaskID", SqlDbType.VarChar, "30"),
                CreateParameter("@PatientSubFileID", SqlDbType.VarChar, PatientFileNo),
                CreateParameter("@TaskUser", SqlDbType.VarChar, "SYSTEM"),
                CreateParameter("@TaskDueDate", SqlDbType.VarChar, null),
                CreateParameter("@TaskCompletionDate", SqlDbType.VarChar, ""),
                CreateParameter("@TaskDetails", SqlDbType.VarChar, "Follow-Up Request: New Email Received on a closed Patient File."),
                CreateParameter("@TaskActiveYN", SqlDbType.VarChar, "Y"),
                CreateParameter("@LoadedBy", SqlDbType.VarChar, MailBoxName),
                CreateParameter("@PRIORITY_ID", SqlDbType.VarChar, "1"),
                CreateParameter("@TASK_STATUS_ID", SqlDbType.VarChar, "2"));

            PatientEnquiryID = cmd.Parameters["@PatientEnquiryID"].Value.ToString();

            ReturnValue = true;
            return ReturnValue;
        }

        public DataTable ValidPatientFileNo(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_VERIFY", CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }

        public DataTable GetPODData(string EmailID)
        {
            return ExecuteDataTable("AIMS_EWS_MAILBOX_POD_INFO",
                                    CreateParameter("@EMAIL_ID", SqlDbType.VarChar, EmailID.ToString()));
        }

        public bool AIMS_EWS_Save_EmailInfo(ref Int64 EMAIL_ID, string EMAIL_UNIQUE_ID, string EMAIL_SUBJECT, string EMAIL_RECEIVED_DTTM, string EMAIL_SENT_FROM_NAME, string EMAIL_SENT_FROM_ADDRESS, string EMAIL_SENT_TO, int MailBoxID, string EMAIL_GUID, string EMAIL_TO_CC)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            
            ExecuteNonQuery(out cmd, "AIMS_EWS_ADD_EMAIL_INFO",
               CreateParameter("@EMAIL_ID", SqlDbType.Int, 0, 50, ParameterDirection.InputOutput),
               CreateParameter("@EMAIL_UNIQUE_ID", SqlDbType.VarChar, EMAIL_UNIQUE_ID),
               CreateParameter("@EMAIL_SUBJECT", SqlDbType.VarChar, EMAIL_SUBJECT),
               CreateParameter("@EMAIL_RECEIVED_DTTM", SqlDbType.VarChar, EMAIL_RECEIVED_DTTM),
               CreateParameter("@EMAIL_SENT_FROM_NAME", SqlDbType.VarChar, EMAIL_SENT_FROM_NAME),
               CreateParameter("@EMAIL_SENT_FROM_ADDRESS", SqlDbType.VarChar, EMAIL_SENT_FROM_ADDRESS),
               CreateParameter("@EMAIL_SENT_TO", SqlDbType.VarChar, EMAIL_SENT_TO),
               CreateParameter("@MAILBOX_ID", SqlDbType.Int, MailBoxID),
               CreateParameter("@EMAIL_GUID", SqlDbType.VarChar, EMAIL_GUID),
               CreateParameter("@EMAIL_SENT_TO_CC", SqlDbType.VarChar, EMAIL_TO_CC));

            EMAIL_ID = System.Convert.ToInt64(cmd.Parameters["@EMAIL_ID"].Value);

            cmd.Dispose();
            ReturnValue = true;
            return ReturnValue;
        }

        public DataTable Get_Patient_File_Operator(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_EWS_GET_PATIENT_FILE_OPERATOR",
                                    CreateParameter("@PATIENT_FILE_NO", SqlDbType.VarChar, PatientFileNo.ToString()));
        }

        public DataTable GetLimitationCodeValue(string LimitationCode)
        {
            return ExecuteDataTable("AIMS_GET_LIMITATION_CODE_VALUE",
                                    CreateParameter("@LIMITATION_CODE", SqlDbType.VarChar, LimitationCode.ToString()));
        }

        public bool AIMS_EWS_Save_EmailAttachments(Int64 EMAIL_ID, string Email_Attachment, ref Int64 EmailAttachmentID)
        {
            bool ReturnValue = false;
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_EWS_ADD_EMAIL_ATTACHMENT",
               CreateParameter("@EMAIL_ID", SqlDbType.VarChar, EMAIL_ID.ToString()),
               CreateParameter("@ATTACHMENT_LOCATION", SqlDbType.VarChar, Email_Attachment),
               CreateParameter("@EmailAttachmentID", SqlDbType.Int, 0, 50, ParameterDirection.InputOutput));

            EmailAttachmentID = System.Convert.ToInt64(cmd.Parameters["@EmailAttachmentID"].Value);

            cmd.Dispose();
            ReturnValue = true;
            return ReturnValue;
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

        #endregion

        public bool SaveEmailInfo(string strMessage) 
        {
            SqlCommand cmd = null;
            try
            {
                bool bReturnValue = false;
                ExecuteNonQuery(out cmd, "EWS_AIMS_Save", CreateParameter("MailMessage", SqlDbType.VarChar, strMessage));
                return bReturnValue;
            }
            finally 
            {
                cmd.Dispose(); 
            }
        }

        public bool EmailIndexedFlag(string Email_ID)
        {
            bool ReturnValue = false;
            SqlCommand cmd;
            ExecuteNonQuery("AIMS_EWS_PATIENT_EMAIL_INDEXED", CreateParameter("@EMAIL_ID", SqlDbType.VarChar, Email_ID));

            ReturnValue = true;
            return ReturnValue;
        }

        #endregion
    }
}
