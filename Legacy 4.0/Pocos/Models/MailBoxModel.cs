using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class MailBoxModel
    {
        public int MAILBOX_ID { get; set; } //(decimal(18,0), not null)
        public string MAILBOX_NAME { get; set; } //(varchar(50), not null)
    }
}
