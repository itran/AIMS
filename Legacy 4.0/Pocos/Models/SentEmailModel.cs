using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class SentEmailModel
    {
        public decimal SENT_EMAIL_ID { get; set; } //(decimal(18,0), not null)
        public decimal PATIENT_ID { get; set; } //(decimal(18,0), not null)
        public string SENT_TO { get; set; } //(varchar(255), not null)
        public DateTime SENT_DTTM { get; set; } //(datetime, not null)
        public decimal EMAIL_FROM_ID { get; set; } //(decimal(18,0), not null)
        public decimal PATIENT_ENQUIRY_ID { get; set; } //(decimal(18,0), null)
        public string EMAIL_SUBJECT { get; set; } //(varchar(1000), null)
        public string EMAIL_SENT_BY { get; set; } //(varchar(50), not null)
        public string SENT_TO_CC { get; set; } //(varchar(255), null)
    }

}
