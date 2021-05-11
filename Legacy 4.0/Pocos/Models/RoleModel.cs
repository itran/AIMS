using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class RoleModel
    {
        public int ROLE_ID { get; set; } //(decimal(18,0), not null)
        public string ROLE_CD { get; set; } //(varchar(50), null)
        public string ROLE_CD_ACTIVE_YN { get; set; } //(varchar(50), null)

    }
}
