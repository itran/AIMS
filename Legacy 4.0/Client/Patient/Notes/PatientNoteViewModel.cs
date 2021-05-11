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
using System.Windows.Input;
using Unity;
using System.Windows;
using static Legacy.Library.FilterEnum;

namespace Legacy.WPFRegionalManager.ViewModels.Patient
{
    public class PatientNoteViewModel: BindableBase
    {
        private readonly PatientViewViewModel parent;

        public PatientNoteViewModel(PatientModel _project)
        {

        }

        public PatientNoteViewModel()
        {

        }

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


        private bool processing;

        public bool Processing
        {
            get { return processing; }
            set
            {
                if (processing != value)
                {
                    processing = value;
                    OnPropertyChanged();
                }
            }
        }

        public PatientNoteViewModel(PatientViewViewModel patientViewViewModel)
        {
            this.parent = patientViewViewModel;
        }


        #region "Patient-Notes Commands"
        private ICommand _addoperationNoteCommand;
        public ICommand AddOperationNoteCommand
        {
            get { return _addoperationNoteCommand; }
            set
            {
                _addoperationNoteCommand = value;
                RaisePropertyChanged("AddOperationNoteCommand");
            }
        }

        private ICommand _addmedicalNoteCommand;
        public ICommand AddMedicalNoteCommand
        {
            get { return _addmedicalNoteCommand; }
            set
            {
                _addmedicalNoteCommand = value;
                RaisePropertyChanged("AddMedicalNoteCommand");
            }
        }

        private ICommand _addAdminNoteCommand;
        public ICommand AddAminNoteCommand
        {
            get { return _addAdminNoteCommand; }
            set
            {
                _addAdminNoteCommand = value;
                RaisePropertyChanged("AddAminNoteCommand");
            }
        }

        private ICommand _addFinanceNoteCommand;
        public ICommand AddFinanceNoteCommand
        {
            get { return _addFinanceNoteCommand; }
            set
            {
                _addFinanceNoteCommand = value;
                RaisePropertyChanged("AddAminNoteCommand");
            }
        }

        private ICommand _addInterimNoteCommand;
        public ICommand AddInterimNoteCommand
        {
            get { return _addInterimNoteCommand; }
            set
            {
                _addInterimNoteCommand = value;
                RaisePropertyChanged("AddInterimNoteCommand");
            }
        }

        private ICommand _addGeneralNoteCommand;
        public ICommand AddGeneralNoteCommand
        {
            get { return _addGeneralNoteCommand; }
            set
            {
                _addGeneralNoteCommand = value;
                RaisePropertyChanged("AddGeneralNoteCommand");
            }
        }
        #endregion

        #region "Observable Collections"

        private ObservableCollection<Notes> _patienNoteList;
        public ObservableCollection<Notes> PatientNoteList
        {
            get { return _patienNoteList; }
            set
            {
                if (_patienNoteList != value)
                    _patienNoteList = value;
                RaisePropertyChanged("PatientNoteList");
            }
        }

        private ObservableCollection<Notes> _patientMedicalNotesList;
        public ObservableCollection<Notes> PatientMedicalNotesList
        {
            get { return _patientMedicalNotesList; }
            set
            {
                if (_patientMedicalNotesList != value)
                    _patientMedicalNotesList = value;
                RaisePropertyChanged("PatientMedicalNotesList");
            }
        }

        private ObservableCollection<Notes> _patientAdminNotesList;
        public ObservableCollection<Notes> PatientAdminNotesList
        {
            get { return _patientAdminNotesList; }
            set
            {
                if (_patientAdminNotesList != value)
                    _patientAdminNotesList = value;
                RaisePropertyChanged("PatientAdminNotesList");
            }
        }

        private ObservableCollection<Notes> _patientFinanceNotesList;
        public ObservableCollection<Notes> PatientFinanceNotesList
        {
            get { return _patientFinanceNotesList; }
            set
            {
                if (_patientFinanceNotesList != value)
                    _patientFinanceNotesList = value;
                RaisePropertyChanged("PatientFinanceNotesList");
            }
        }

        private ObservableCollection<Notes> _patientInterimNotesList;
        public ObservableCollection<Notes> PatientInterimNotesList
        {
            get { return _patientInterimNotesList; }
            set
            {
                if (_patientInterimNotesList != value)
                    _patientInterimNotesList = value;
                RaisePropertyChanged("PatientInterimNotesList");
            }
        }

        private ObservableCollection<Notes> _patientGeneralNotesList;
        public ObservableCollection<Notes> PatientGeneralNotesList
        {
            get { return _patientGeneralNotesList; }
            set
            {
                if (_patientGeneralNotesList != value)
                    _patientGeneralNotesList = value;
                RaisePropertyChanged("PatientGeneralNotesList");
            }
        }
        #endregion

        public async Task LoadAsync(string patientFileNo)
        {
            await GetPatientFileNotes(patientFileNo);
        }

        private async Task GetPatientFileNotes(string patientFileNo)
        {
            Processing = true;
            try
            {
                var note = new Library.Patient();

                var notelist = note.GetPatientNotes(patientFileNo, NoteType.PATIENTCOMMENT);
                PatientNoteList = new ObservableCollection<Notes>(notelist);

                notelist = note.GetPatientNotes(patientFileNo, NoteType.PATIENTADMINNOTES);
                PatientAdminNotesList = new ObservableCollection<Notes>(notelist);

                notelist = note.GetPatientNotes(patientFileNo, NoteType.PATIENTFINANCENOTES);
                PatientFinanceNotesList = new ObservableCollection<Notes>(notelist);

                notelist = note.GetPatientNotes(patientFileNo, NoteType.PATIENTINTERIMNOTES);
                PatientInterimNotesList = new ObservableCollection<Notes>(notelist);

                notelist = note.GetPatientNotes(patientFileNo, NoteType.PATIENTMEDICALHISTORY);
                PatientMedicalNotesList = new ObservableCollection<Notes>(notelist);

                notelist = note.GetPatientNotes(patientFileNo, NoteType.PATIENTFILEENQUIRY);
                PatientGeneralNotesList = new ObservableCollection<Notes>(notelist);

            }
            finally
            {
                Processing = false;
            }
        }

        public PatientNoteViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            Processing = true;
            try
            {
                _eventArg = eventArg;
                _regionManager = regionManager;
                _container = container;

            }
            finally
            {
                Processing = false;
            }
        }
    }
}
