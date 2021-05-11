using Legacy.Models;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Legacy.WPFRegionalManager.ViewModels.Patient
{
    public class PatientTaskViewModel : BindableBase
    {
        
        private readonly PatientViewViewModel parent;

        /// <summary>
        /// The _container
        /// </summary>
        private IUnityContainer _container;
        /// <summary>
        /// The _region manager
        /// </summary>
        private IRegionManager _regionManager;
        /// <summary>
        /// The _event argument
        /// </summary>
        private IEventAggregator _eventArg;

        public PatientTaskViewModel(PatientModel _project)
        {

        }

        public PatientTaskViewModel()
        {

        }

        private decimal _PATIENT_FILE_TASK_ID;//(decimal(18,0), not null)
        private decimal _TASK_ID;//(decimal(18,0), not null)
        private decimal _PATIENT_ID;//(decimal(18,0), not null)
        private string _USER_ID;//(varchar(50), not null)
        private DateTime _DUE_DATE;//(datetime, not null)
        private DateTime _COMPLETION_DATE;//(datetime, null)
        private string _DETAILS;//(varchar(2000), not null)
        private string _ACTIVE_YN;//(varchar(1), not null)
        private string _LOADED_BY;//(varchar(50), null)
        private DateTime _CREATION_DATE;//(datetime, null)
        private decimal _PRIORITY_ID;//(decimal(18,0), null)
        private decimal _TASK_STATUS_ID;//(decimal(18,0), null)

        public decimal PATIENT_FILE_TASK_ID { get { return _PATIENT_FILE_TASK_ID; } set { _PATIENT_FILE_TASK_ID = value; RaisePropertyChanged("PATIENT_FILE_TASK_ID"); } }

        public decimal TASK_ID { get { return _TASK_ID; } set { _TASK_ID = value; RaisePropertyChanged("TASK_ID"); } }
        public decimal PATIENT_ID { get { return _PATIENT_ID; } set { _PATIENT_ID = value; RaisePropertyChanged("PATIENT_ID"); } }
        public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; RaisePropertyChanged("USER_ID"); } }
        public DateTime DUE_DATE { get { return _DUE_DATE; } set { _DUE_DATE = value; RaisePropertyChanged("DUE_DATE"); } }
        public DateTime COMPLETION_DATE { get { return _COMPLETION_DATE; } set { _COMPLETION_DATE = value; RaisePropertyChanged("COMPLETION_DATE"); } }
        public string DETAILS { get { return _DETAILS; } set { _DETAILS = value; RaisePropertyChanged("DETAILS"); } }
        public string ACTIVE_YN { get { return _ACTIVE_YN; } set { _ACTIVE_YN = value; RaisePropertyChanged("ACTIVE_YN"); } }
        public string LOADED_BY { get { return _LOADED_BY; } set { _LOADED_BY = value; RaisePropertyChanged("LOADED_BY"); } }
        public DateTime CREATION_DATE { get { return _CREATION_DATE; } set { _CREATION_DATE = value; RaisePropertyChanged("CREATION_DATE"); } }
        public decimal PRIORITY_ID { get { return _PRIORITY_ID; } set { _PRIORITY_ID = value; RaisePropertyChanged("PRIORITY_ID"); } }
        public decimal TASK_STATUS_ID { get { return _TASK_STATUS_ID; } set { _TASK_STATUS_ID = value; RaisePropertyChanged("TASK_STATUS_ID"); } }

        #region "Observable Collections"
        private ObservableCollection<TaskModel> _PatientTasksList;
        public ObservableCollection<TaskModel> PatientTasksList
        {
            get { return _PatientTasksList; }
            set
            {
                if (_PatientTasksList != value)
                    _PatientTasksList = value;
                RaisePropertyChanged("PatientTasksList");
            }
        }
        #endregion

        public PatientTaskViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;
            //AddOperationNoteCommand = new DelegateCommand(AddComment, canSearch);
        }

        public PatientTaskViewModel(PatientViewViewModel patientViewViewModel)
        {
            this.parent = patientViewViewModel;
        }

        public async Task LoadAsync(string patientId)
        {
            await GetPatientTasks(patientId);
        }

        private async Task GetPatientTasks(string patientFileNo)
        {
            var provider = new Library.Tasks();
            var providerlist = provider.GetPatientTasks(patientFileNo);
            PatientTasksList = new ObservableCollection<TaskModel>(providerlist);
        }
    }
}
