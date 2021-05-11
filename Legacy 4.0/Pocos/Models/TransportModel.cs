using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class TransportModel
    {
        public int TRANSPORT_TYPE_ID { get; set; } //(decimal(18,0), not null)
        public string TRANSPORT_TYPE_DESC { get; set; } //(varchar(1000), null)
    }
}
