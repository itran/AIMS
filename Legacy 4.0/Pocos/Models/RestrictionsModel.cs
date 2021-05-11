using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class Restrictions
    {
        public decimal RESTRICTION_ID { get; set; } //(decimal(18,0), not null)
        public string RESTRICTION_DESC { get; set; } //(varchar(50), null)
    }

}
