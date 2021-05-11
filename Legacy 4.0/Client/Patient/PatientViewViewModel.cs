using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Unity;
using System;
using Legacy.Library;
using Legacy.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using static Legacy.Library.FilterEnum;
using Legacy.WPFRegionalManager.Views;
using System.Threading.Tasks;
using Legacy.WPFRegionalManager.Client.Command;
using GalaSoft.MvvmLight.Command;

namespace Legacy.WPFRegionalManager.ViewModels.Patient
{
    public class PatientViewViewModel : BindableBase
    {
        public PatientDetailViewModel patientDetailViewModel { get; }
        public PatientNoteViewModel patientNoteViewModel { get; }
        public PatientEmailCorrespondenceViewModel patientEmailCorrespondenceViewModel { get; }
        public PatientServiceProviderViewModel patientServiceProviderViewModel { get; }
        public PatientTaskViewModel patientTaskViewModel { get; }
        public PatientAppointmentsViewModel patientAppointmentsViewModel { get; }
        public PatientBillingViewModel patientBillingViewModel { get; }
        public PatientAuditViewModel patientAuditViewModel { get; }

        public PatientViewViewModel()
        {
            patientDetailViewModel = new PatientDetailViewModel(this);
            patientNoteViewModel = new PatientNoteViewModel(this);
            patientEmailCorrespondenceViewModel = new PatientEmailCorrespondenceViewModel(this);
            patientServiceProviderViewModel = new PatientServiceProviderViewModel(this);
            patientTaskViewModel = new PatientTaskViewModel(this);
            patientBillingViewModel = new PatientBillingViewModel(this);
            patientAuditViewModel = new PatientAuditViewModel(this);
        }

        public DelegateCommand<object> PatientDetailCommand { get; set; }
        public DelegateCommand<object> PatientNoteDetailCommand { get; set; }

        private bool includedCancelled; public bool IncludedCancelled { get { return includedCancelled; } set { includedCancelled = value; RaisePropertyChanged("IncludedCancelled"); } }
        private bool includeClosed; public bool IncludeClosed { get { return includeClosed; } set { includeClosed = value; RaisePropertyChanged("IncludeClosed"); } }

        private bool includedPending; public bool IncludedPending { get { return includedPending; } set { includedPending = value; RaisePropertyChanged("IncludedPending"); } }

        private bool includedSentToAdmin; public bool IncludedSentToAdmin { get { return includedSentToAdmin; } set { includedSentToAdmin = value; RaisePropertyChanged("IncludedSentToAdmin"); } }


        private bool _isOpen;
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }

        private string _NewPatientFile;

        public string NewPatientFile
        {
            get { return _NewPatientFile; }
            set { _NewPatientFile = value; }
        }


        //private ICommand _openPopupCommand;
        //public ICommand OpenPopupCommand
        //{
        //    get
        //    {
        //        if (_openPopupCommand == null)
        //            _openPopupCommand = new RelayCommand(OpenPopupExecute());
        //        return _openPopupCommand;
        //    }
        //    set
        //    {
        //        _openPopupCommand = value;
        //    }
        //}

        private AsyncCommand _openPopupCommand;

        public IAsyncCommand OpenPopupCommand => _openPopupCommand ?? (_openPopupCommand = new AsyncCommand(OpenPopupExecute));

        public async Task OpenPopupExecute()
        {
            IsOpen = true; // Will call OnPropertyChanged in setter
        }

        private AsyncCommand _closePopupCommand;

        public IAsyncCommand ClosePopupCommand => _closePopupCommand ?? (_closePopupCommand = new AsyncCommand(ClosePopupExecute));

        public async Task ClosePopupExecute()
        {
            MessageBox.Show(NewPatientFile);
            IsOpen = false; // Will call OnPropertyChanged in setter
        }

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

        private string _PatientSurname;
        public string PatientSurname
        {
            get { return _PatientSurname; }
            set { _PatientSurname = value; RaisePropertyChanged("PatientSurname"); }
        }

        private string _PatientFileNo;
        public string PatientFileNo
        {
            get { return _PatientFileNo; }
            set { _PatientFileNo = value; RaisePropertyChanged("PatientFileNo"); }
        }

        private string _GuarantorReferenceNo;
        public string GuarantorReferenceNo
        {
            get { return _GuarantorReferenceNo; }
            set { _GuarantorReferenceNo = value; RaisePropertyChanged("GuarantorReferenceNo"); }
        }

        private FilterModel selectedFilterList;

        public FilterModel SelectedFilterList
        {
            get { return selectedFilterList; }
            set
            {
                PatientDetailsClear();
                selectedFilterList = value;
 
                if (value != null && (!string.IsNullOrWhiteSpace(value.FILTER_NAME) & value.FILTER_NAME != "<Add New Supplier>"))
                {
                    Library.Patient patient = new Library.Patient();
                    var patientList = patient.GetPatientDetails(value.FILTER_ID, selectedFilterItem.FILTER_ITEM_NAME);
                    PaginationPatientList = new ObservableCollection<PatientModel>(patientList);
                }
                IncludedSentToAdmin = false;
                IncludedCancelled = false;
                IncludedPending = false;
                IncludeClosed = false;

                RaisePropertyChanged("SelectedFilterList");
            }
        }

        private FilterItem selectedFilterItem;

        public FilterItem SelectedFilterItem
        {            
            get { return selectedFilterItem; }
            set
            {
                selectedFilterItem = value;
                if (value != null && !string.IsNullOrWhiteSpace(value.FILTER_ITEM_NAME) && value.FILTER_ITEM_NAME != "ALL" )
                {
                    Processing = true;
                    try
                    {
                        CommonFunctions commonFunctions = new CommonFunctions();
                        var filterList = commonFunctions.PatientFiltering(value.FILTER_ITEM_NAME);
                        FilterList = new ObservableCollection<FilterModel>(filterList);
                    }
                    finally
                    {
                        Processing = false;
                    }
                }
                IncludedSentToAdmin = false;
                IncludedCancelled = false;
                IncludedPending = false;
                IncludeClosed = false;
                RaisePropertyChanged("SelectedFilterItem");
            }
        }

        private ObservableCollection<FilterItem> _filterItemList;
        public ObservableCollection<FilterItem> FilterItemList
        {
            get { return _filterItemList; }
            set
            {
                if (_filterItemList != value)
                    _filterItemList = value;
                RaisePropertyChanged("FilterItemList");
            }
        }

        private ObservableCollection<PatientModel> _paginationPatientList;
        public ObservableCollection<PatientModel> PaginationPatientList
        {
            get { return _paginationPatientList; }
            set
            {
                if (_paginationPatientList != value)
                    _paginationPatientList = value;
                RaisePropertyChanged("PaginationPatientList");
            }
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


        private void ShowDialog()
        {
            throw new NotImplementedException();
        }

        void LoadFilterItem()
        {
            List<FilterItem> filterItem = new List<FilterItem>();
            filterItem.Add(new FilterItem { FILTER_ITEM_ID = 0, FILTER_ITEM_NAME = "ALL" });
            filterItem.Add(new FilterItem { FILTER_ITEM_ID = 1, FILTER_ITEM_NAME = "Guarantor" });
            filterItem.Add(new FilterItem { FILTER_ITEM_ID = 2, FILTER_ITEM_NAME = "Hospital" });
            FilterItemList = new ObservableCollection<FilterItem>(filterItem);
        }


        public PatientViewViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            Processing = true;
            try
            {
                _eventArg = eventArg;
                _regionManager = regionManager;
                _container = container;

                SearchCommand = new DelegateCommand(SearchPatient, canSearch);
                //SearchBySurnameCommand = new IAsyncCommand(SearchBySurname, canSearch);
                //SearchByPatientFileCommand = new DelegateCommand(SearchByFileNo, canSearch);

                PatientDetailCommand = new DelegateCommand<object>(PatientDetailLoad);
                PatientNoteDetailCommand = new DelegateCommand<object>(PatientNoteDetailLoad);


                patientDetailViewModel = new PatientDetailViewModel(this);
                patientNoteViewModel = new PatientNoteViewModel(this);
                patientEmailCorrespondenceViewModel = new PatientEmailCorrespondenceViewModel(this);
                patientServiceProviderViewModel = new PatientServiceProviderViewModel(this);
                patientTaskViewModel = new PatientTaskViewModel(this);
                patientBillingViewModel = new PatientBillingViewModel(this);
                patientAuditViewModel = new PatientAuditViewModel(this);
                LoadFilterItem();
            }
            finally
            {
                Processing = false;
            }
        }

        void searchPatient(bool IncludedSentToAdmin, bool IncludedPending, bool IncludedCancelled, bool IncludeClosed)
        {
            Processing = true;
            try
            {
                Library.Patient patient = new Library.Patient();

                string sentToAdmin = IncludedSentToAdmin == true ? "Y" : "N";
                string pending = IncludedPending == true ? "Y" : "N";
                string cancelled = IncludedCancelled == true ? "Y" : "N";
                string closed = IncludeClosed == true ? "Y" : "N";

                if (SelectedFilterList == null) return;

                var patientList = patient.GetPatientDetails(SelectedFilterList.FILTER_ID, SelectedFilterItem.FILTER_ITEM_NAME, cancelled, sentToAdmin, pending, closed);
                PatientDetailsClear();
                PaginationPatientList = new ObservableCollection<PatientModel>(patientList);
            }
            finally
            {
                Processing = false;
            }
        }

        void addPatientNote(NoteType noteType)
        {
            switch (noteType)
            {

            }             
        }

        private void SearchPatient()
        {
            searchPatient(IncludedSentToAdmin, IncludedPending, IncludedCancelled , IncludeClosed );
        }

        private async Task SearchBySurname()
        {
            Processing = true;
            try
            {
                Library.Patient patient = new Library.Patient();
                var patientList = patient.GetPatientDetailsBySurname(PatientSurname);
                PatientDetailsClear();
                PaginationPatientList = new ObservableCollection<PatientModel>(patientList);

                if (patientList.Count == 1)
                {
                    string patientFileNo = patientList[0].PATIENT_FILE_NO;
                    string patientId = patientList[0].PATIENT_ID.ToString();
                    patientDetailViewModel.LoadAsync(patientFileNo);
                    patientNoteViewModel.LoadAsync(patientFileNo);
                    patientEmailCorrespondenceViewModel.LoadAsync(patientFileNo);
                    patientServiceProviderViewModel.LoadAsync(patientId);
                    patientTaskViewModel.LoadAsync(patientFileNo);
                    patientAuditViewModel.LoadAsync(patientFileNo);
                }
                else
                {
                    MessageBox.Show(" -No records found- ");
                }
            }
            finally
            {
                Processing = false;
            }
        }

        private async Task SearchByFileNo()
        {
            Processing = true;
            try
            {
                Library.Patient patient = new Library.Patient();
                var patientList = patient.GetPatientFileNo(PatientFileNo);
                PatientDetailsClear();
                PaginationPatientList = new ObservableCollection<PatientModel>(patientList);

                if (patientList.Count ==1 )
                {
                    string patientFileNo = patientList[0].PATIENT_FILE_NO;
                    string patientId = patientList[0].PATIENT_ID.ToString();
                    patientDetailViewModel.LoadAsync(patientFileNo);
                    patientNoteViewModel.LoadAsync(patientFileNo);
                    patientEmailCorrespondenceViewModel.LoadAsync(patientFileNo);
                    patientServiceProviderViewModel.LoadAsync(patientId);
                    patientTaskViewModel.LoadAsync(patientFileNo);
                    //patientAuditViewModel.LoadAsync(patientFileNo);
                }
                else
                {
                    MessageBox.Show("- Patient File No not found - ");
                }
            }
            finally
            {
                Processing = false;
            }
        }

        private void AddComment()
        {
            //Views.NewNotes objPopupwindow = new Views.NewNotes();
            //objPopupwindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //objPopupwindow.ShowDialog();
        }

        bool canSearch()
        {
            return true;
        }

        void PatientDetailLoad(object patientModel)
        {
            Processing = true;
            try
            {
                if (patientModel != null)
                {
                    PatientModel patientDetail = (PatientModel)patientModel;
                    if (patientDetail != null)
                    {
                        string patientFileNo = patientDetail.PATIENT_FILE_NO;
                        string patientId = patientDetail.PATIENT_ID.ToString();
                        patientDetailViewModel.LoadAsync(patientFileNo);
                        patientNoteViewModel.LoadAsync(patientFileNo);
                        patientEmailCorrespondenceViewModel.LoadAsync(patientFileNo);
                        patientServiceProviderViewModel.LoadAsync(patientId);
                        patientTaskViewModel.LoadAsync(patientFileNo);
                        patientAuditViewModel.LoadAsync(patientFileNo);
                    }
                }
            }
            finally
            {
                Processing = false;
            }
            Processing = false;
        }

        void PatientNoteDetailLoad(object patientNoteModel)
        {
            Processing = true;
            try
            {
                if (patientNoteModel != null)
                {
                    Notes noteDetail = (Notes)patientNoteModel;
                    if (noteDetail != null)
                    {
                        string note = noteDetail.NOTES;
                        MessageBox.Show(note);
                    }
                }
            }
            finally
            {
                Processing = false;
            }
            Processing = false;
        }

        void PatientDetailsClear()
        {
            PaginationPatientList = null;
        }

        #region Methods
        private void GetAllPatient()
        {
            Processing = true;
            try
            {
                CommonFunctions common = new CommonFunctions();
                var unfilteredList = common.GetAllPatients();
                PaginationPatientList = new ObservableCollection<PatientModel>(unfilteredList);
            }
            finally
            {
                Processing = false;
            }
        }
        #endregion

        private FilterModel _selectedFilter;
        public FilterModel SelectedFilter
        {
            get { return _selectedFilter; }
            set
            {
                _selectedFilter = value;
                if (value != null && !string.IsNullOrWhiteSpace(value.FILTER_NAME))
                {
                    CommonFunctions commonFunctions = new CommonFunctions();
                    Processing = true;
                    try
                    {
                        var patientfilter = commonFunctions.PatientFiltering(value.FILTER_NAME);

                        if (patientfilter != null)
                        {

                            //SelectedFilterId = patientfilter.FILTER_ID;
                            //SelectedDepartmentId = userInfo.DEPARTMENT_ID;
                            //_newUser = false;
                        }
                    }
                    catch (Exception)
                    {

                        Processing = false;
                    }
                }
                RaisePropertyChanged("SelectedFilter");
            }
        }

        private ObservableCollection<FilterModel> filterlist;
        public ObservableCollection<FilterModel> FilterList
        {
            get { return filterlist; }
            set
            {
                if (filterlist != value)
                    filterlist = value;
                RaisePropertyChanged("FilterList");
            }
        }

        private int selectedFilterId;
        public int SelectedFilterId
        {
            get { return selectedFilterId; }
            set
            {
                selectedFilterId = value;
                RaisePropertyChanged("SelectedFilterId");
            }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                _searchCommand = value;
                RaisePropertyChanged("SearchCommand");
            }
        }

        //private ICommand _searchBySurnameCommand;
        //public ICommand SearchBySurnameCommand
        //{
        //    get { return _searchBySurnameCommand; }
        //    set
        //    {
        //        _searchBySurnameCommand = value;
        //        RaisePropertyChanged("SearchBySurnameCommand");
        //    }
        //}

        //private AsyncCommand _searchByPatientFileCommand;
        //public AsyncCommand SearchByPatientFileCommand
        //{
        //    get { return _searchByPatientFileCommand; }
        //    set
        //    {
        //        _searchByPatientFileCommand = value;
        //        RaisePropertyChanged("SearchByPatientFileCommand");
        //    }
        //}


        private AsyncCommand _searchBySurnameCommand;

        public IAsyncCommand SearchBySurnameCommand => _searchBySurnameCommand ?? (_searchBySurnameCommand = new AsyncCommand(OnSearchByPatientSurnameCommandAsync));
        private async Task OnSearchByPatientSurnameCommandAsync()
        {
            await SearchBySurname();
        }

        private AsyncCommand _searchByFileNoCommand;

        public IAsyncCommand SearchByFileNoCommand => _searchByFileNoCommand ?? (_searchByFileNoCommand = new AsyncCommand(OnSearchByFileNoCommandAsync));
        private async Task OnSearchByFileNoCommandAsync()
        {
            Processing = true;
            await SearchByFileNo();
            Processing = false;
        }

        private AsyncCommand _searchByReferenceNoCommand;

        public IAsyncCommand SearchByReferenceNoCommand => _searchByReferenceNoCommand ?? (_searchByReferenceNoCommand = new AsyncCommand(OnSearchByReferenceNoCommandAsync));
        private async Task OnSearchByReferenceNoCommandAsync()
        {
            Processing = true;
            await SearchByReferenceNo();
            Processing = false;
        }

        private async Task SearchByReferenceNo()
        {
            Processing = true;
            try
            {
                Library.Patient patient = new Library.Patient();
                var patientList = patient.GetPatientFileByReferenceNo(GuarantorReferenceNo);
                PatientDetailsClear();
                PaginationPatientList = new ObservableCollection<PatientModel>(patientList);

                if (patientList.Count == 1)
                {
                    string patientFileNo = patientList[0].PATIENT_FILE_NO;
                    string patientId = patientList[0].PATIENT_ID.ToString();
                    patientDetailViewModel.LoadAsync(patientFileNo);
                    patientNoteViewModel.LoadAsync(patientFileNo);
                    patientEmailCorrespondenceViewModel.LoadAsync(patientFileNo);
                    patientServiceProviderViewModel.LoadAsync(patientId);
                    patientTaskViewModel.LoadAsync(patientFileNo);
                    //patientAuditViewModel.LoadAsync(patientFileNo);
                }
                else
                {
                    MessageBox.Show(" -No records found matching your search criteria- ");
                }
            }
            finally
            {
                Processing = false;
            }
        }
    }
}
