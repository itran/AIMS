using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy
{
    public class Notes
    {
        public string USER_FULL_NAME { get; set; } //(varchar(50), null)

        public DateTime NOTES_DTTM { get; set; } //(datetime, null)
        public string NOTES { get; set; } //(varchar(2000), null)
        public string NOTE_TYPE_DESC { get; set; } //(varchar(2000), null)
        public decimal NOTE_ID { get; set; } //(decimal(18,0), not null)        
        public decimal NOTE_TYPE_ID { get; set; } //(decimal(18,0), null)
        public decimal PATIENT_ID { get; set; } //(decimal(18,0), null)       
    }

}
