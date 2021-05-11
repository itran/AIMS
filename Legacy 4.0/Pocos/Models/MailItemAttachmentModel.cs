using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class MailItemAttachmentModel
    {
        public int ATTACHMENT_ID { get; set; } //(decimal(18,0), not null)
        public int EMAIL_ID { get; set; } //(decimal(18,0), not null)
        public string ATTACHMENT_LOCATION { get; set; } //(varchar(4000), not null)
        public decimal ATTACHMENT_FILE_TYPE_ID { get; set; } //(decimal(18,0), null)
    }

}
