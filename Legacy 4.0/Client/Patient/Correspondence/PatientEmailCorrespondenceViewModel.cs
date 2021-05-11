
using Legacy.Models;
using Microsoft.Practices.Prism.Commands;
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
    public class PatientEmailCorrespondenceViewModel: BindableBase
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

        public PatientEmailCorrespondenceViewModel(PatientModel _project)
        {

        }

        public PatientEmailCorrespondenceViewModel()
        {

        }

        private decimal _SENT_EMAIL_ID;
        private decimal _PATIENT_ID;
        private string _SENT_TO;
        private DateTime _SENT_DTTM;
        private decimal _EMAIL_FROM_ID;
        private decimal _PATIENT_ENQUIRY_ID;
        private string _SENT_EMAIL_SUBJECT;
        private string _EMAIL_SENT_BY;
        private string _SENT_TO_CC;

        public decimal SENT_EMAIL_ID { get { return _SENT_EMAIL_ID; } set { _SENT_EMAIL_ID = value; RaisePropertyChanged("SENT_EMAIL_ID"); } }
        public decimal PATIENT_ID { get { return _EMAIL_ID; } set { _EMAIL_ID = value; RaisePropertyChanged("PATIENT_ID"); } }
        public string SENT_TO { get { return _SENT_TO; } set { _SENT_TO = value; RaisePropertyChanged("SENT_TO"); } }
        public DateTime SENT_DTTM { get { return _SENT_DTTM; } set { _SENT_DTTM = value; RaisePropertyChanged("SENT_DTTM"); } }
        public decimal EMAIL_FROM_ID { get { return _EMAIL_FROM_ID; } set { _EMAIL_FROM_ID = value; RaisePropertyChanged("EMAIL_FROM_ID"); } }
        public decimal PATIENT_ENQUIRY_ID { get { return _PATIENT_ENQUIRY_ID; } set { _PATIENT_ENQUIRY_ID = value; RaisePropertyChanged("PATIENT_ENQUIRY_ID"); } }
        public string SENT_EMAIL_SUBJECT { get { return _SENT_EMAIL_SUBJECT; } set { _SENT_EMAIL_SUBJECT = value; RaisePropertyChanged("SENT_EMAIL_SUBJECT"); } }
        public string EMAIL_SENT_BY { get { return _EMAIL_SENT_BY; } set { _EMAIL_SENT_BY = value; RaisePropertyChanged("EMAIL_SENT_BY"); } }
        public string SENT_TO_CC { get { return _SENT_TO_CC; } set { _SENT_TO_CC = value; RaisePropertyChanged("SENT_TO_CC"); } }

        private decimal _EMAIL_ID;
        private string _EMAIL_UNIQUE_ID;
        private string _EMAIL_GUID;
        private string _EMAIL_SUBJECT;
        private DateTime _EMAIL_RECEIVED_DTTM;
        private string _EMAIL_SENT_FROM_NAME;
        private string _EMAIL_SENT_FROM_ADDRESS;
        private string _EMAIL_SENT_TO;
        private string _EMAIL_SENT_TO_CC;
        private string _EMAIL_SENT_TO_BCC;
        private decimal _MAILBOX_ID;
        private DateTime _PROCESSED_DTTM;
        private string _EMAIL_UNREAD_YN;
        private string _EMAIL_INDEXED_YN;
        private string _EMAIL_LOCKED_BY;
        private string _EMAIL_DELETED_YN;
        private string _EMAIL_PENDED_YN;
        private string _EMAIL_INDEXED_BY;

        public decimal EMAIL_ID { get { return _EMAIL_ID; } set { _EMAIL_ID = value; RaisePropertyChanged("EMAIL_ID"); } }
        public string EMAIL_UNIQUE_ID { get { return _EMAIL_UNIQUE_ID; } set { _EMAIL_UNIQUE_ID = value; RaisePropertyChanged("EMAIL_UNIQUE_ID"); } }
        public string EMAIL_GUID { get { return _EMAIL_GUID; } set { _EMAIL_GUID = value; RaisePropertyChanged("EMAIL_GUID"); } }
        public string EMAIL_SUBJECT { get { return _EMAIL_SUBJECT; } set { _EMAIL_SUBJECT = value; RaisePropertyChanged("EMAIL_SUBJECT"); } }
        public DateTime EMAIL_RECEIVED_DTTM { get { return _EMAIL_RECEIVED_DTTM; } set { _EMAIL_RECEIVED_DTTM = value; RaisePropertyChanged("EMAIL_RECEIVED_DTTM"); } }
        public string EMAIL_SENT_FROM_NAME { get { return _EMAIL_SENT_FROM_NAME; } set { _EMAIL_SENT_FROM_NAME = value; RaisePropertyChanged("EMAIL_SENT_FROM_NAME"); } }
        public string EMAIL_SENT_FROM_ADDRESS { get { return _EMAIL_SENT_FROM_ADDRESS; } set { _EMAIL_SENT_FROM_ADDRESS = value; RaisePropertyChanged("EMAIL_SENT_FROM_ADDRESS"); } }
        public string EMAIL_SENT_TO { get { return _EMAIL_SENT_TO; } set { _EMAIL_SENT_TO = value; RaisePropertyChanged("EMAIL_SENT_TO"); } }
        public string EMAIL_SENT_TO_CC { get { return _EMAIL_SENT_TO_CC; } set { _EMAIL_SENT_TO_CC = value; RaisePropertyChanged("EMAIL_SENT_TO_CC"); } }
        public string EMAIL_SENT_TO_BCC { get { return _EMAIL_SENT_TO_BCC; } set { _EMAIL_SENT_TO_BCC = value; RaisePropertyChanged("EMAIL_SENT_TO_BCC"); } }
        public decimal MAILBOX_ID { get { return _MAILBOX_ID; } set { _MAILBOX_ID = value; RaisePropertyChanged("MAILBOX_ID"); } }
        public DateTime PROCESSED_DTTM { get { return _PROCESSED_DTTM; } set { _PROCESSED_DTTM = value; RaisePropertyChanged("PROCESSED_DTTM"); } }
        public string EMAIL_UNREAD_YN { get { return _EMAIL_UNREAD_YN; } set { _EMAIL_UNREAD_YN = value; RaisePropertyChanged("EMAIL_UNREAD_YN"); } }
        public string EMAIL_INDEXED_YN { get { return _EMAIL_INDEXED_YN; } set { _EMAIL_INDEXED_YN = value; RaisePropertyChanged("EMAIL_INDEXED_YN"); } }
        public string EMAIL_LOCKED_BY { get { return _EMAIL_LOCKED_BY; } set { _EMAIL_LOCKED_BY = value; RaisePropertyChanged("EMAIL_LOCKED_BY"); } }
        public string EMAIL_DELETED_YN { get { return _EMAIL_DELETED_YN; } set { _EMAIL_DELETED_YN = value; RaisePropertyChanged("EMAIL_DELETED_YN"); } }
        public string EMAIL_PENDED_YN { get { return _EMAIL_PENDED_YN; } set { _EMAIL_PENDED_YN = value; RaisePropertyChanged("EMAIL_PENDED_YN"); } }
        public string EMAIL_INDEXED_BY { get { return _EMAIL_INDEXED_BY; } set { _EMAIL_INDEXED_BY = value; RaisePropertyChanged("EMAIL_INDEXED_BY"); } }


        #region "Observable Collections"
        private ObservableCollection<EmailModel> _patientEmailList;
        public ObservableCollection<EmailModel> PatientEmailList
        {
            get { return _patientEmailList; }
            set
            {
                if (_patientEmailList != value)
                    _patientEmailList = value;
                RaisePropertyChanged("PatientEmailList");
            }
        }

        private ObservableCollection<SentEmailModel> _patientSentEmailList;
        public ObservableCollection<SentEmailModel> PatientSentEmailList
        {
            get { return _patientSentEmailList; }
            set
            {
                if (_patientSentEmailList != value)
                    _patientSentEmailList = value;
                RaisePropertyChanged("PatientSentEmailList");
            }
        }

        #endregion

        public PatientEmailCorrespondenceViewModel(PatientViewViewModel patientViewViewModel)
        {
            this.parent = patientViewViewModel;
        }

        public DelegateCommand<object> PatientDetailCommand { get; set; }

        public PatientEmailCorrespondenceViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;
            
        }


        public async Task LoadAsync(string patientFileNo)
        {
            GetPatientFileEmails(patientFileNo);
            GetPatientFileSentEmails(patientFileNo);
        }

        private async Task GetPatientFileSentEmails(string patientFileNo)
        {
            var email = new Library.Email();
            var patientSentEmaillist = email.GetPatientSentEmails(patientFileNo);
            PatientSentEmailList = new ObservableCollection<SentEmailModel>(patientSentEmaillist);
        }

        private async Task GetPatientFileEmails(string patientFileNo)
        {
            var note = new Library.Email ();
            var notelist = note.GetPatientEmails(patientFileNo, "");
            PatientEmailList = new ObservableCollection<EmailModel>(notelist);
        }
    }
}
