using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{   public class ServiceProviderModel
    {
        public int SERVICE_PROVIDER_ID { get; set; } //(int, not null)
        public int PATIENT_ID { get; set; } //(int, null)
        public int SUPPLIER_TYPE_ID { get; set; } //(int, null)
        public string SERVICE_PROVIDER_NAME { get; set; } //(varchar(500), null)
        public string SERVICE_PROVIDER_PHONE { get; set; } //(varchar(500), null)
        public string SERVICE_PROVIDER_FAX_NO { get; set; } //(varchar(500), null)
        public string SERVICE_PROVIDER_EMAIL { get; set; } //(varchar(500), null)
        public string USER_NAME { get; set; } //(varchar(50), null)
        public string ADMIN_NAME { get; set; } //(varchar(255), null)
        public string ADMIN_TEL_PHONE { get; set; } //(varchar(255), null)
        public string ADMIN_FAX_NO { get; set; } //(varchar(255), null)
        public string ADMIN_EMAIL { get; set; } //(varchar(255), null)
    }
}
