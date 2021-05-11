using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.WPFRegionalManager.ViewModels.Patient
{
    public class PatientBillingViewModel
    {
        private readonly PatientViewViewModel parent;
        public PatientBillingViewModel(PatientModel _project)
        {

        }

        public PatientBillingViewModel()
        {

        }

        public PatientBillingViewModel(PatientViewViewModel patientViewViewModel)
        {
            this.parent = patientViewViewModel;
        }
    }
}
