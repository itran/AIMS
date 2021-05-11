using Legacy;
using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Legacy.Library.FilterEnum;

namespace Legacy.Library
{
    public class Email
    {
        public List<EmailModel> GetPatientEmails(string patientFileNo, string emailKeyword)
        {
            EmailDAL dapper = new EmailDAL();
            List<EmailModel> patientEmail = dapper.GetPatientEmails(patientFileNo, emailKeyword);
            return patientEmail;
        }

        public List<SentEmailModel> GetPatientSentEmails(string patientFileNo)
        {
            EmailDAL dapper = new EmailDAL();
            List<SentEmailModel> patientEmail = dapper.GetPatientSentEmails(patientFileNo);
            return patientEmail;
        }
    }
}
