using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy
{   public class EmailModel
    {
        public decimal EMAIL_ID { get; set; } //(decimal(18,0), not null)
        public string EMAIL_UNIQUE_ID { get; set; } //(varchar(500), null)
        public string EMAIL_GUID { get; set; } //(varchar(100), null)
        public string EMAIL_SUBJECT { get; set; } //(varchar(4000), null)
        public DateTime EMAIL_RECEIVED_DTTM { get; set; } //(datetime, null)
        public string EMAIL_SENT_FROM_NAME { get; set; } //(varchar(500), null)
        public string EMAIL_SENT_FROM_ADDRESS { get; set; } //(varchar(500), null)
        public string EMAIL_SENT_TO { get; set; } //(varchar(4000), null)
        public string EMAIL_SENT_TO_CC { get; set; } //(varchar(500), null)
        public string EMAIL_SENT_TO_BCC { get; set; } //(varchar(500), null)
        public decimal MAILBOX_ID { get; set; } //(decimal(18,0), null)
        public DateTime PROCESSED_DTTM { get; set; } //(datetime, null)
        public string EMAIL_UNREAD_YN { get; set; } //(varchar(1), null)
        public string EMAIL_INDEXED_YN { get; set; } //(varchar(1), not null)
        public string EMAIL_LOCKED_BY { get; set; } //(varchar(50), null)
        public string EMAIL_DELETED_YN { get; set; } //(varchar(1), not null)
        public string EMAIL_PENDED_YN { get; set; } //(varchar(1), not null)
        public string EMAIL_INDEXED_BY { get; set; } //(varchar(50), null)
        public string WORK_ITEM_PROCESSED_DTTM { get; set; } //(varchar(50), null)
    }

}
