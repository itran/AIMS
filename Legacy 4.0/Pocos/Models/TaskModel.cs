using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class TaskModel
    {
        public decimal PATIENT_FILE_TASK_ID { get; set; } //(decimal(18,0), not null)
        public decimal TASK_ID { get; set; } //(decimal(18,0), not null)
        public decimal PATIENT_ID { get; set; } //(decimal(18,0), not null)
        public string USER_ID { get; set; } //(varchar(50), not null)
        public DateTime DUE_DATE { get; set; } //(datetime, not null)
        public DateTime COMPLETION_DATE { get; set; } //(datetime, null)
        public string DETAILS { get; set; } //(varchar(2000), not null)
        public string ACTIVE_YN { get; set; } //(varchar(1), not null)
        public string LOADED_BY { get; set; } //(varchar(50), null)
        public DateTime CREATION_DATE { get; set; } //(datetime, null)
        public decimal PRIORITY_ID { get; set; } //(decimal(18,0), null)
        public decimal TASK_STATUS_ID { get; set; } //(decimal(18,0), null)
    }
}
