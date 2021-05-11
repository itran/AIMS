using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class MailBoxMailsModel
    {
        public decimal OPERATOR_MAIL_ID { get; set; } //(decimal(18,0), not null)
        public decimal OPERATOR_MAILBOX_ID { get; set; } //(decimal(18,0), null)
        public decimal PATIENT_ENQUIRY_ID { get; set; } //(decimal(18,0), not null)
        public string MAIL_READ_YN { get; set; } //(varchar(1), not null)
        public DateTime MAIL_READ_DTTM { get; set; } //(datetime, null)
        public string WORK_ITEM_PROCESSED_YN { get; set; } //(varchar(1), null)
        public DateTime WORK_ITEM_PROCESSED_DTTM { get; set; } //(datetime, null)
        public string WORK_ITEM_PROCESSED_BY { get; set; } //(varchar(50), null)
    }

}
