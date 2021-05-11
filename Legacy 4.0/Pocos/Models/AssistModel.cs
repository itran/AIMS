using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class AssistModel
    {
        public int ASSIST_TYPE_ID { get; set; } //(decimal(18,0), not null)
        public string ASSIST_TYPE_DESC { get; set; } //(varchar(1000), null)
    }
}
