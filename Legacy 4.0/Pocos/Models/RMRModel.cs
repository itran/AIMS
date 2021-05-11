using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class RMRModel
    {
        public decimal RMR_TYPE_ID { get; set; } //(decimal(18,0), not null)
        public string RMR_TYPE_DESC { get; set; } //(varchar(1000), null)
    }
}
