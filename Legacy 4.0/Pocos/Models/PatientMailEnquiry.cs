using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy
{
    public class PatientMailEnquiry
    {
        public decimal PATIENT_ENQUIRY_ID { get; set; } 
        public decimal PATIENT_ID { get; set; }
        public decimal EMAIL_ID { get; set; }
        public DateTime CREATION_DTTM { get; set; } 
        public string ACTIVE_YN { get; set; } 
        public decimal PRIORITY_ID { get; set; } 
    }
}
