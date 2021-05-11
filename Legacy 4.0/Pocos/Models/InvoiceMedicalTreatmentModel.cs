using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models
{
    public class InvoiceMedicalTreatmentModel
    {
        public decimal INVOICE_TREATMENT_ID { get; set; } //(decimal(18,0), not null)
        public decimal INVOICE_ID { get; set; } //(decimal(18,0), null)
        public decimal MEDICAL_TREATMENT_ID { get; set; } //(decimal(18,0), null)
        public decimal SERVICE_ID { get; set; } //(decimal(18,0), null)
    }

}
