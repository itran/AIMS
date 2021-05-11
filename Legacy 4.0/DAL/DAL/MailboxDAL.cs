using Dapper;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.DAL
{
    public class MailboxDAL
    {
        public List<MailBoxModel> GetMailBoxes(string LoggedInUser)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "[AIMS_EWS_GET_MAILBOXES]";
                var values = new { @LoggedInUser = LoggedInUser };
                return db.Query<MailBoxModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<MaiBoxEmailItemModel> GetMailBoxEmail(Int32 MailBoxID, string LoggedInUser, string MailSearchKeyword)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "[AIMS_EWS_GET_UNREAD_MAILS]";
                var values = new { MailBoxID, @UserCurrentlyLoggedOn = LoggedInUser, MailSearchKeyword };
                return db.Query<MaiBoxEmailItemModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<MailItemAttachmentModel> GetMailItemAttachment(int emailId)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "[AIMS_EWS_GET_EMAIL_ATTACHMENT]";
                var values = new { @EMAIL_ID = emailId };
                return db.Query<MailItemAttachmentModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
