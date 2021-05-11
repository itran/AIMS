using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class DepartmentModel
    {
        public int DEPARTMENT_ID { get; set; } //(decimal(18,0), not null)
        public string DEPARTMENT_NAME { get; set; } //(varchar(50), null)
        public string DEPARTMENT_SUPERVISOR_USER_NAME { get; set; } //(varchar(50), null)
        public string DEPARTMENT_MANAGER_USER_NAME { get; set; } //(varchar(50), null)
        public string DEPARTMENT_EMAIL_ADDRESS { get; set; } //(varchar(150), null)
    }

}
