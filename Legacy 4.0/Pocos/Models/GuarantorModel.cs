using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class GuarantorModel
    {
        public decimal GUARANTOR_ID { get; set; } //(decimal(18,0), not null)
        public string GUARANTOR_NAME { get; set; } //(varchar(1000), null)
        public string GUARANTOR_PHONE_NO { get; set; } //(varchar(50), null)
        public string GUARANTOR_FAX_NO { get; set; } //(varchar(50), null)
        public decimal ADDRESS_ID { get; set; } //(decimal(18,0), null)
        public string GUARANTOR_EMAIL_ADDRESS { get; set; } //(char(50), null)
        public string GUARANTOR_ACTIVE_YN { get; set; } //(varchar(1), null)
        public string GUARANTOR_CONTACT_PERSON { get; set; } //(varchar(50), null)
        public DateTime CREATION_DTTM { get; set; } //(datetime, null)
    }

}
