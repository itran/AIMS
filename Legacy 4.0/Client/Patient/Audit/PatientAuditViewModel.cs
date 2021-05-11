using Legacy.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.WPFRegionalManager.ViewModels.Patient
{
    public class PatientAuditViewModel : BindableBase
    {
        private readonly PatientViewViewModel parent;
        public PatientAuditViewModel(PatientModel _project)
        {

        }

        public PatientAuditViewModel()
        {

        }

        public PatientAuditViewModel(PatientViewViewModel patientViewViewModel)
        {
            this.parent = patientViewViewModel;
        }


        private ObservableCollection<PatientFileAudit> _patientAuditList;
        public ObservableCollection<PatientFileAudit> PatientAuditList
        {
            get { return _patientAuditList; }
            set
            {
                if (_patientAuditList != value)
                    _patientAuditList = value;
                RaisePropertyChanged("PatientAuditList");
            }
        }

        public async Task LoadAsync(string patientId)
        {
            await GetPatientFileAudit(patientId);
        }

        private async Task GetPatientFileAudit(string patientFileNo)
        {
            var audit = new Library.Patient();
            var auditlist = audit.GetPatientDetailsAudit(patientFileNo);
            PatientAuditList = new ObservableCollection<PatientFileAudit>(auditlist);
        }
    }
}
