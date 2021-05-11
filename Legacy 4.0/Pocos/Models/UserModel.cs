using System;

namespace Legacy.Models
{
    public class UserModel
    {
        public string User_Name { get; set; } //(varchar(50), not null)
        public string User_Full_Name { get; set; } //(varchar(50), not null)
        public string User_Password { get; set; } //(varchar(50), not null)
        public string User_Email { get; set; } //(varchar(50), null)
        public string User_Phone { get; set; } //(varchar(50), null)
        public string User_Fax { get; set; } //(varchar(50), null)
        public string User_Active_YN { get; set; } //(varchar(50), not null)
        public string SIGNATURE_PATH { get; set; } //(varchar(500), null)
        public int JOB_TITLE_ID { get; set; } //(decimal(18,0), null)
        public int DEPARTMENT_ID { get; set; } //(decimal(18,0), null)
        public DateTime DATE_OF_BIRTH { get; set; } //(date, null)
    }

}
