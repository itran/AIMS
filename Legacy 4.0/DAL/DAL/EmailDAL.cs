using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Legacy.Models;

namespace Legacy.DAL
{
    public class EmailDAL
    {
        public List<EmailModel> GetPatientEmails(string patientFileNo, string emailKeyword)
        {
            EmailModel allPatients = new EmailModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "[AIMS_PATIENT_EMAILS_GET]";
                var values = new { @PATIENT_FILE_NO = patientFileNo, @EMAIL_KEYWORD = emailKeyword };
                return db.Query<EmailModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();

                //string sqlString = @"SELECT  DISTINCT              
                //                        B.EMAIL_SUBJECT,                       
                //                        B.EMAIL_RECEIVED_DTTM,                       
                //                        B.EMAIL_SENT_FROM_NAME,                    
                //                        B.EMAIL_SENT_FROM_ADDRESS,                       
                //                        A.CREATION_DTTM,               
                //                        A.PATIENT_ENQUIRY_ID,              
                //                        A.PRIORITY_ID,                    
                //                        C.MAIL_READ_YN,               
                //                        B.EMAIL_SENT_TO_CC,               
                //                        B.EMAIL_INDEXED_BY,               
                //                        D.USER_FULL_NAME,                
                //                        B.EMAIL_SENT_TO
                //                     FROM
                //                        AIMS_EWS_PATIENT_ENQUIRY A
                //                        INNER JOIN AIMS_EWS_EMAILS B on B.EMAIL_ID = A.EMAIL_ID
                //                        LEFT OUTER JOIN AIMS_EWS_OPERATOR_MAILS C on C.PATIENT_ENQUIRY_ID = a.PATIENT_ENQUIRY_ID
                //                        LEFT OUTER JOIN AIMS_USERS D on D.USER_NAME = b.EMAIL_INDEXED_BY
                //                        WHERE A.PATIENT_ID = (select PATIENT_ID from AIMS_PATIENT where PATIENT_FILE_NO = @PATIENT_FILE_NO) "; //and a.CREATION_DTTM >=GETDATE() - 90 

                //if (!string.IsNullOrWhiteSpace(emailKeyword))
                //{
                //    sqlString += $"  AND B.EMAIL_SUBJECT LIKE '%{emailKeyword}%'";
                //}
                //var procedure = sqlString;
                //var values = new { @PATIENT_FILE_NO = patientFileNo};
                //return db.Query<EmailModel>(procedure, values, commandType: CommandType.Text).ToList();
            }
        }

        public List<SentEmailModel> GetPatientSentEmails(string patientFileNo)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "[AIMS_EWS_GET_PATIENT_SENT_EMAIL]";
                var values = new { @PatientFileNo = patientFileNo };
                return db.Query<SentEmailModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
