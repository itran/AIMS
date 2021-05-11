using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.Library
{
    public class MailBox
    {
        public List<MailBoxModel> GetMailBoxes(string loggedUserId)
        {
            DAL.MailboxDAL dapper = new MailboxDAL();
            return dapper.GetMailBoxes(loggedUserId);
        }

        public List<MaiBoxEmailItemModel> GetMailBoxEmail(Int32 MailBoxID, string LoggedInUser, string MailSearchKeyword)
        {
            DAL.MailboxDAL dapper = new MailboxDAL();
            return dapper.GetMailBoxEmail(MailBoxID, LoggedInUser, MailSearchKeyword);
        }

        public List<MailItemAttachmentModel> GetMailItemAttachment(int emailId)
        {
            DAL.MailboxDAL dapper = new MailboxDAL();
            return dapper.GetMailItemAttachment(emailId);
        }
    }
}
