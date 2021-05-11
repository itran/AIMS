using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
 public class InvoiceModel
    {
        public decimal INVOICE_ID { get; set; } //(decimal(18,0), not null)
        public string INVOICE_NO { get; set; } //(varchar(255), null)
        public decimal PATIENT_ID { get; set; } //(decimal(18,0), null)
        public string INVOICE_DATE { get; set; } //(varchar(50), null)
        public string INVOICE_AMOUNT_RECEIVED { get; set; } //(varchar(50), null)
        public string GENERATED_YN { get; set; } //(varchar(1), null)
        public string LOCKED_YN { get; set; } //(varchar(1), null)
        public string LATE_INVOICE_YN { get; set; } //(varchar(1), null)
        public DateTime CREATION_DTTM { get; set; } //(datetime, null)
        public string CANCELLED_YN { get; set; } //(varchar(1), null)
        public string DOCTOR_OWING { get; set; } //(varchar(1), null)
        public string LATE_INVOICE_SENT { get; set; } //(varchar(1), null)
        public string LATE_INVOICE_SENT_DATE { get; set; } //(varchar(50), null)
        public string INVOICE_SENT_WAYBILL_NO { get; set; } //(varchar(50), null)
        public decimal GUARANTOR_ACCOUNT_ID { get; set; } //(decimal(18,0), null)
    }

}
