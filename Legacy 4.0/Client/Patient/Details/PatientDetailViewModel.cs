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

namespace Legacy.WPFRegionalManager.ViewModels.Patient
{
    public class PatientDetailViewModel : BindableBase
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


        private string _PatientFileNo;
        private string _PatientName;

        #region "Observable Collections"

        private ObservableCollection<TransportModel> transportlist;
        public ObservableCollection<TransportModel> TransportTypeList
        {
            get { return transportlist; }
            set
            {
                if (transportlist != value)
                    transportlist = value;
                RaisePropertyChanged("TransportTypeList");
            }
        }

        private ObservableCollection<EvacuationModel> evactyppeList;
        public ObservableCollection<EvacuationModel> EvacuationList
        {
            get { return evactyppeList; }
            set
            {
                if (evactyppeList != value)
                    evactyppeList = value;
                RaisePropertyChanged("EvacuationList");
            }
        }

        private ObservableCollection<RepatModel> repatlist;
        public ObservableCollection<RepatModel> RepatList
        {
            get { return repatlist; }
            set
            {
                if (repatlist != value)
                    repatlist = value;
                RaisePropertyChanged("RepatList");
            }
        }

        private ObservableCollection<AssistModel> assistyppeList;
        public ObservableCollection<AssistModel> AssistTypeList
        {
            get { return assistyppeList; }
            set
            {
                if (assistyppeList != value)
                    assistyppeList = value;
                RaisePropertyChanged("AssistTypeList");
            }
        }

        private ObservableCollection<RMRModel> rmrList;
        public ObservableCollection<RMRModel> RMRList
        {
            get { return rmrList; }
            set
            {
                if (rmrList != value)
                    rmrList = value;
                RaisePropertyChanged("RMRList");
            }
        } 
        #endregion

        public string PATIENT_NAME { get { return _PatientName; } set { _PatientName = value; RaisePropertyChanged("PATIENT_NAME"); } }
        //public string PATIENT_FILE_NO { 
        //    get { return _PatientFileNo; } 
        //    set { _PatientFileNo = value; 
        //        RaisePropertyChanged("PATIENT_FILE_NO"); } 
        //}

        public string PATIENT_FILE_NO { get => _PatientFileNo; set { if (_PatientFileNo != value) { _PatientFileNo = value; OnPropertyChanged("PATIENT_FILE_NO"); } } }

        private bool isPatientDetailEnabled; public bool IsPatientDetailsEnabled { get { return isPatientDetailEnabled; } set { isPatientDetailEnabled = value; RaisePropertyChanged("IsPatientDetailsEnabled"); } }

        private bool repatTypeChecked; public bool RepatTypeChecked { get { return repatTypeChecked; } set { repatTypeChecked = value; RaisePropertyChanged("RepatTypeChecked"); } }
        private bool assistTypeChecked; public bool AssistTypeChecked { get { return assistTypeChecked; } set { assistTypeChecked = value; RaisePropertyChanged("AssistTypeChecked"); } }
        private bool transportTypeChecked; public bool TransportTypeChecked { get { return transportTypeChecked; } set { transportTypeChecked = value; RaisePropertyChanged("TransportTypeChecked"); } }
        private bool evacuationTypeChecked; public bool EvacuationTypeChecked { get { return evacuationTypeChecked; } set { evacuationTypeChecked = value; RaisePropertyChanged("EvacuationTypeChecked"); } }
        private bool rMRTypeChecked; public bool RMRTypeChecked { get { return rMRTypeChecked; } set { rMRTypeChecked = value; RaisePropertyChanged("RMRTypeChecked"); } }

        private string _PatientFirstName;
        private string _PatientLastName;
        private string _PatientInitials;
        private decimal _PATIENT_ID;
        private string _PATIENT_FILE_NO;
        private string _PATIENT_NAME;
        private string _PATIENT_INITIALS;
        private string _PATIENT_FIRST_NAME;
        private string _PATIENT_MIDDLE_NAME;
        private string _PATIENT_LAST_NAME;
        private string _PATIENT_ID_NO;
        private decimal _COMPANY_ID;
        private decimal _TITLE_ID;
        private decimal _ADDRESS_ID;
        private string _PATIENT_HOME_TEL_NO;
        private string _PATIENT_WORK_TEL_NO;
        private string _PATIENT_FAX_NO;
        private string _PATIENT_MOBILE_NO;
        private string _PATIENT_EMAIL_ADDRESS;
        private string _GUARANTOR_NAME;
        private decimal _GUARANTOR_ID;
        private string _GUARANTOR_REF_NO;
        private string _PATIENT_FILE_ACTIVE_YN;
        private string _PATIENT_NATIONALITY;
        private string _PATIENT_GUARANTOR_AMOUNT;
        private int _SUPPLIER_ID;
        
        private string _PATIENT_ADMISSION_DATE;
        private string _PATIENT_DISCHARGE_DATE;
        private string _PATIENT_DIAGNOSIS;
        private DateTime _CREATION_DTTM;
        private string _PATIENT_EMERGENCY_CONTACT_NAME;
        private string _PATIENT_EMERGENCY_CONTACT_NO;
        private string _IN_PATIENT;
        private string _OUT_PATIENT;
        private string _ASSIST;
        private DateTime _FILE_COURIER_DATE;
        private string _FLIGHT;
        private string _REPAT;
        private string _CANCELLED;
        private string _COURIER_WAYBILL_NO;
        private string _TRANSPORT;
        private string _GUARANTOR247NO;
        private string _GUARANTOR247EMAIL;
        private string _FILE_ASSIGNED_TO_USERID;
        private DateTime _COURIER_RECEIPT_DATE;
        private int _PATIENT_ASSIST_TYPE_ID;
        private int _PATIENT_TRANSPORT_TYPE_ID;
        private string _LATE_LOG_YN;
        private DateTime _LATE_LOG_DATE;
        
        private DateTime _PEND_DATE;
        private int _PATIENT_EVACUATION_TYPE_ID;
        private int _PATIENT_REPAT_TYPE_ID;
        private string _FILE_OPERATOR_TO_USERID;
        private string _RMR;
        private int _PATIENT_RMR_TYPE_ID;
        private decimal _FLIGHT_GUARANTOR_ID;
        private string _PATIENT_DATE_OF_BIRTH;
        private DateTime _LAB_LIST_DATE;

        private bool _PENDING;
        private bool _AFTER_HOURS_FILE;
        private bool _SENT_TO_ADMIN;
        private bool _HIGH_COST;
        private bool _PATIENT_FILE_COURIER_YN;

        public string PATIENT_FIRST_NAME { get { return _PatientFirstName; } set { _PatientFirstName = value; RaisePropertyChanged("PATIENT_FIRST_NAME"); } }
        public string PATIENT_LAST_NAME { get { return _PatientLastName; } set { _PatientLastName = value; RaisePropertyChanged("PATIENT_LAST_NAME"); } }
        public string PATIENT_INITIALS { get { return _PatientInitials; } set { _PatientInitials = value; RaisePropertyChanged("PATIENT_INITIALS"); } }
        public string GUARANTOR_REF_NO { get { return _GUARANTOR_REF_NO; } set { _GUARANTOR_REF_NO = value; RaisePropertyChanged("GUARANTOR_REF_NO"); } }
        public decimal PATIENT_ID { get { return _PATIENT_ID; } set { _PATIENT_ID = value; RaisePropertyChanged("PATIENT_ID"); } }

        public string PATIENT_ID_NO { get { return _PATIENT_ID_NO; } set { _PATIENT_ID_NO = value; RaisePropertyChanged("PATIENT_ID_NO"); } }
        public decimal COMPANY_ID { get { return _COMPANY_ID; } set { _COMPANY_ID = value; RaisePropertyChanged("COMPANY_ID"); } }
        public decimal TITLE_ID { get { return _TITLE_ID; } set { _TITLE_ID = value; RaisePropertyChanged("TITLE_ID"); } }
        public decimal ADDRESS_ID { get { return _ADDRESS_ID; } set { _ADDRESS_ID = value; RaisePropertyChanged("ADDRESS_ID"); } }
        public string PATIENT_HOME_TEL_NO { get { return _PATIENT_HOME_TEL_NO; } set { _PATIENT_HOME_TEL_NO = value; RaisePropertyChanged("PATIENT_HOME_TEL_NO"); } }
        public string PATIENT_WORK_TEL_NO { get { return _PATIENT_WORK_TEL_NO; } set { _PATIENT_WORK_TEL_NO = value; RaisePropertyChanged("PATIENT_WORK_TEL_NO"); } }
        public string PATIENT_FAX_NO { get { return _PATIENT_FAX_NO; } set { _PATIENT_FAX_NO = value; RaisePropertyChanged("PATIENT_FAX_NO"); } }
        public string PATIENT_MOBILE_NO { get { return _PATIENT_MOBILE_NO; } set { _PATIENT_MOBILE_NO = value; RaisePropertyChanged("PATIENT_MOBILE_NO"); } }
        public string PATIENT_EMAIL_ADDRESS { get { return _PATIENT_EMAIL_ADDRESS; } set { _PATIENT_EMAIL_ADDRESS = value; RaisePropertyChanged("PATIENT_EMAIL_ADDRESS"); } }
        public string GUARANTOR_NAME { get { return _GUARANTOR_NAME; } set { _GUARANTOR_NAME = value; RaisePropertyChanged("GUARANTOR_NAME"); } }
        public decimal GUARANTOR_ID { get { return _GUARANTOR_ID; } set { _GUARANTOR_ID = value; RaisePropertyChanged("GUARANTOR_ID"); } }
        public string PATIENT_FILE_ACTIVE_YN { get { return _PATIENT_FILE_ACTIVE_YN; } set { _PATIENT_FILE_ACTIVE_YN = value; RaisePropertyChanged("PATIENT_FILE_ACTIVE_YN"); } }
        public string PATIENT_NATIONALITY { get { return _PATIENT_NATIONALITY; } set { _PATIENT_NATIONALITY = value; RaisePropertyChanged("PATIENT_NATIONALITY"); } }
        public string PATIENT_GUARANTOR_AMOUNT { get { return _PATIENT_GUARANTOR_AMOUNT; } set { _PATIENT_GUARANTOR_AMOUNT = value; RaisePropertyChanged("PATIENT_GUARANTOR_AMOUNT"); } }
        public int SUPPLIER_ID { get { return _SUPPLIER_ID; } set { _SUPPLIER_ID = value; RaisePropertyChanged("SUPPLIER_ID"); } }
        
        public string PATIENT_ADMISSION_DATE { get { return _PATIENT_ADMISSION_DATE; } set { _PATIENT_ADMISSION_DATE = value; RaisePropertyChanged("PATIENT_ADMISSION_DATE"); } }
        public string PATIENT_DISCHARGE_DATE { get { return _PATIENT_DISCHARGE_DATE; } set { _PATIENT_DISCHARGE_DATE = value; RaisePropertyChanged("PATIENT_DISCHARGE_DATE"); } }
        public string PATIENT_DIAGNOSIS { get { return _PATIENT_DIAGNOSIS; } set { _PATIENT_DIAGNOSIS = value; RaisePropertyChanged("PATIENT_DIAGNOSIS"); } }
        public DateTime CREATION_DTTM { get { return _CREATION_DTTM; } set { _CREATION_DTTM = value; RaisePropertyChanged("CREATION_DTTM"); } }
        public string PATIENT_EMERGENCY_CONTACT_NAME { get { return _PATIENT_EMERGENCY_CONTACT_NAME; } set { _PATIENT_EMERGENCY_CONTACT_NAME = value; RaisePropertyChanged("PATIENT_EMERGENCY_CONTACT_NAME"); } }
        public string PATIENT_EMERGENCY_CONTACT_NO { get { return _PATIENT_EMERGENCY_CONTACT_NO; } set { _PATIENT_EMERGENCY_CONTACT_NO = value; RaisePropertyChanged("PATIENT_EMERGENCY_CONTACT_NO"); } }
        public string IN_PATIENT { get { return _IN_PATIENT; } set { _IN_PATIENT = value; RaisePropertyChanged("IN_PATIENT"); } }
        public string OUT_PATIENT { get { return _OUT_PATIENT; } set { _OUT_PATIENT = value; RaisePropertyChanged("OUT_PATIENT"); } }
        public string ASSIST { get { return _ASSIST; } set { _ASSIST = value; RaisePropertyChanged("ASSIST"); } }
        public DateTime FILE_COURIER_DATE { get { return _FILE_COURIER_DATE; } set { _FILE_COURIER_DATE = value; RaisePropertyChanged("FILE_COURIER_DATE"); } }
        public string FLIGHT { get { return _FLIGHT; } set { _FLIGHT = value; RaisePropertyChanged("FLIGHT"); } }
        public string REPAT { get { return _REPAT; } set { _REPAT = value; RaisePropertyChanged("REPAT"); } }
        public string CANCELLED { get { return _CANCELLED; } set { _CANCELLED = value; RaisePropertyChanged("CANCELLED"); } }
        public string COURIER_WAYBILL_NO { get { return _COURIER_WAYBILL_NO; } set { _COURIER_WAYBILL_NO = value; RaisePropertyChanged("COURIER_WAYBILL_NO"); } }
        public string TRANSPORT { get { return _TRANSPORT; } set { _TRANSPORT = value; RaisePropertyChanged("TRANSPORT"); } }
        public string GUARANTOR247NO { get { return _GUARANTOR247NO; } set { _GUARANTOR247NO = value; RaisePropertyChanged("GUARANTOR247NO"); } }
        public string GUARANTOR247EMAIL { get { return _GUARANTOR247EMAIL; } set { _GUARANTOR247EMAIL = value; RaisePropertyChanged("GUARANTOR247EMAIL"); } }
        public string FILE_ASSIGNED_TO_USERID { get { return _FILE_ASSIGNED_TO_USERID; } set { _FILE_ASSIGNED_TO_USERID = value; RaisePropertyChanged("FILE_ASSIGNED_TO_USERID"); } }
        public DateTime COURIER_RECEIPT_DATE { get { return _COURIER_RECEIPT_DATE; } set { _COURIER_RECEIPT_DATE = value; RaisePropertyChanged("COURIER_RECEIPT_DATE"); } }
        public int PATIENT_ASSIST_TYPE_ID { get { return _PATIENT_ASSIST_TYPE_ID; } set { _PATIENT_ASSIST_TYPE_ID = value; RaisePropertyChanged("PATIENT_ASSIST_TYPE_ID"); } }
        public int PATIENT_TRANSPORT_TYPE_ID { get { return _PATIENT_TRANSPORT_TYPE_ID; } set { _PATIENT_TRANSPORT_TYPE_ID = value; RaisePropertyChanged("PATIENT_TRANSPORT_TYPE_ID"); } }
        public string LATE_LOG_YN { get { return _LATE_LOG_YN; } set { _LATE_LOG_YN = value; RaisePropertyChanged("LATE_LOG_YN"); } }
        public DateTime LATE_LOG_DATE { get { return _LATE_LOG_DATE; } set { _LATE_LOG_DATE = value; RaisePropertyChanged("LATE_LOG_DATE"); } }
        
        public DateTime PEND_DATE { get { return _PEND_DATE; } set { _PEND_DATE = value; RaisePropertyChanged("PEND_DATE"); } }
        public int PATIENT_EVACUATION_TYPE_ID { get { return _PATIENT_EVACUATION_TYPE_ID; } set { _PATIENT_EVACUATION_TYPE_ID = value; RaisePropertyChanged("PATIENT_EVACUATION_TYPE_ID"); } }
        public int PATIENT_REPAT_TYPE_ID { get { return _PATIENT_REPAT_TYPE_ID; } set { _PATIENT_REPAT_TYPE_ID = value; RaisePropertyChanged("PATIENT_REPAT_TYPE_ID"); } }
        public string FILE_OPERATOR_TO_USERID { get { return _FILE_OPERATOR_TO_USERID; } set { _FILE_OPERATOR_TO_USERID = value; RaisePropertyChanged("FILE_OPERATOR_TO_USERID"); } }
        public string RMR { get { return _RMR; } set { _RMR = value; RaisePropertyChanged("RMR"); } }
        public int PATIENT_RMR_TYPE_ID { get { return _PATIENT_RMR_TYPE_ID; } set { _PATIENT_RMR_TYPE_ID = value; RaisePropertyChanged("PATIENT_RMR_TYPE_ID"); } }
        public decimal FLIGHT_GUARANTOR_ID { get { return _FLIGHT_GUARANTOR_ID; } set { _FLIGHT_GUARANTOR_ID = value; RaisePropertyChanged("FLIGHT_GUARANTOR_ID"); } }
        public string PATIENT_DATE_OF_BIRTH { get { return _PATIENT_DATE_OF_BIRTH; } set { _PATIENT_DATE_OF_BIRTH = value; RaisePropertyChanged("PATIENT_DATE_OF_BIRTH"); } }
        public DateTime LAB_LIST_DATE { get { return _LAB_LIST_DATE; } set { _LAB_LIST_DATE = value; RaisePropertyChanged("LAB_LIST_DATE"); } }
        public bool AFTER_HOURS_FILE { get { return _AFTER_HOURS_FILE; } set { _AFTER_HOURS_FILE = value; RaisePropertyChanged("AFTER_HOURS_FILE"); } }
        public bool SENT_TO_ADMIN { get { return _SENT_TO_ADMIN; } set { _SENT_TO_ADMIN = value; RaisePropertyChanged("SENT_TO_ADMIN"); } }
        public bool HIGH_COST { get { return _HIGH_COST; } set { _HIGH_COST = value; RaisePropertyChanged("HIGH_COST"); } }
        public bool PENDING { get { return _PENDING; } set { _PENDING = value; RaisePropertyChanged("PENDING"); } }
        public bool PATIENT_FILE_COURIER_YN { get { return _PATIENT_FILE_COURIER_YN; } set { _PATIENT_FILE_COURIER_YN = value; RaisePropertyChanged("PATIENT_FILE_COURIER_YN"); } }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged("Name"); }
        }

        public DelegateCommand<string> PatientDetailCommand { get; set; }
        public PatientDetailViewModel(PatientModel _project)
        {

        }

        public PatientDetailViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;
            PopulateLists();
        }

        public PatientDetailViewModel(PatientViewViewModel patientViewViewModel)
        {
            this.parent = patientViewViewModel;            
        }

        #region "Patient Details Loading....."
        public async Task LoadAsync(string patientFileNo)
        {
            await GetPatientFileDetails(patientFileNo);
            
        }

        private async Task GetPatientFileDetails(string patientFileNo)
        {
            if (!string.IsNullOrWhiteSpace(patientFileNo))
            {
                var patientinfo = GetPatientDetails(patientFileNo);
                if (patientinfo != null)
                {
                    PATIENT_ID = patientinfo.PATIENT_ID;
                    PATIENT_FILE_NO = patientinfo.PATIENT_FILE_NO;
                    PATIENT_NAME = patientinfo.PATIENT_NAME;
                    PATIENT_INITIALS = patientinfo.PATIENT_INITIALS;
                    PATIENT_FIRST_NAME = patientinfo.PATIENT_FIRST_NAME;
                    PATIENT_LAST_NAME = patientinfo.PATIENT_LAST_NAME;
                    PATIENT_ID_NO = patientinfo.PATIENT_ID_NO;
                    COMPANY_ID = patientinfo.COMPANY_ID;
                    TITLE_ID = patientinfo.TITLE_ID;
                    ADDRESS_ID = patientinfo.ADDRESS_ID;
                    PATIENT_HOME_TEL_NO = patientinfo.PATIENT_HOME_TEL_NO;
                    PATIENT_WORK_TEL_NO = patientinfo.PATIENT_WORK_TEL_NO;
                    PATIENT_FAX_NO = patientinfo.PATIENT_FAX_NO;
                    PATIENT_MOBILE_NO = patientinfo.PATIENT_MOBILE_NO;
                    PATIENT_EMAIL_ADDRESS = patientinfo.PATIENT_EMAIL_ADDRESS;
                    GUARANTOR_ID = patientinfo.GUARANTOR_ID;
                    GUARANTOR_REF_NO = patientinfo.GUARANTOR_REF_NO;
                    PATIENT_FILE_ACTIVE_YN = patientinfo.PATIENT_FILE_ACTIVE_YN;
                    PATIENT_NATIONALITY = patientinfo.PATIENT_NATIONALITY;
                    PATIENT_GUARANTOR_AMOUNT = patientinfo.PATIENT_GUARANTOR_AMOUNT;
                    SUPPLIER_ID = patientinfo.SUPPLIER_ID;
                    GUARANTOR_NAME = patientinfo.GUARANTOR_NAME;
                    PATIENT_ADMISSION_DATE = patientinfo.PATIENT_ADMISSION_DATE;
                    PATIENT_DISCHARGE_DATE = patientinfo.PATIENT_DISCHARGE_DATE;
                    PATIENT_DIAGNOSIS = patientinfo.PATIENT_DIAGNOSIS;
                    CREATION_DTTM = patientinfo.CREATION_DTTM;
                    PATIENT_EMERGENCY_CONTACT_NAME = patientinfo.PATIENT_EMERGENCY_CONTACT_NAME;
                    PATIENT_EMERGENCY_CONTACT_NO = patientinfo.PATIENT_EMERGENCY_CONTACT_NO;
                    IN_PATIENT = patientinfo.IN_PATIENT;
                    OUT_PATIENT = patientinfo.OUT_PATIENT;
                    ASSIST = patientinfo.ASSIST;
                    FILE_COURIER_DATE = patientinfo.FILE_COURIER_DATE;
                    FLIGHT = patientinfo.FLIGHT;
                    REPAT = patientinfo.REPAT;
                    CANCELLED = patientinfo.CANCELLED;
                    COURIER_WAYBILL_NO = patientinfo.COURIER_WAYBILL_NO;
                    TRANSPORT = patientinfo.TRANSPORT;
                    GUARANTOR247NO = patientinfo.GUARANTOR247NO;
                    GUARANTOR247EMAIL = patientinfo.GUARANTOR247EMAIL;
                    FILE_ASSIGNED_TO_USERID = patientinfo.FILE_ASSIGNED_TO_USERID;
                    COURIER_RECEIPT_DATE = patientinfo.COURIER_RECEIPT_DATE;
                    PATIENT_ASSIST_TYPE_ID = patientinfo.PATIENT_ASSIST_TYPE_ID;
                    PATIENT_TRANSPORT_TYPE_ID = patientinfo.PATIENT_TRANSPORT_TYPE_ID;
                    LATE_LOG_YN = patientinfo.LATE_LOG_YN;
                    LATE_LOG_DATE = patientinfo.LATE_LOG_DATE;

                    PEND_DATE = patientinfo.PEND_DATE;
                    PATIENT_EVACUATION_TYPE_ID = patientinfo.PATIENT_EVACUATION_TYPE_ID;
                    PATIENT_REPAT_TYPE_ID = patientinfo.PATIENT_REPAT_TYPE_ID;
                    FILE_OPERATOR_TO_USERID = patientinfo.FILE_OPERATOR_TO_USERID;
                    RMR = patientinfo.RMR;
                    PATIENT_RMR_TYPE_ID = patientinfo.PATIENT_RMR_TYPE_ID;
                    FLIGHT_GUARANTOR_ID = patientinfo.FLIGHT_GUARANTOR_ID;
                    PATIENT_DATE_OF_BIRTH = patientinfo.PATIENT_DATE_OF_BIRTH;
                    LAB_LIST_DATE = patientinfo.LAB_LIST_DATE;

                    AFTER_HOURS_FILE = patientinfo.AFTER_HOURS_FILE == "Y" ? true : false;
                    SENT_TO_ADMIN = patientinfo.SENT_TO_ADMIN == "Y" ? true : false;
                    HIGH_COST = patientinfo.HIGH_COST == "Y" ? true : false;
                    PATIENT_FILE_COURIER_YN = patientinfo.PATIENT_FILE_COURIER_YN == "Y" ? true : false;
                    PENDING = patientinfo.PENDING == "Y" ? true : false;
                }

                IsPatientDetailsEnabled = true;
            }
        }

        private PatientModel GetPatientDetails(string patientFileNo)
        {
            clearFields();
            Library.Patient patient = new Library.Patient();
            return patient.GetPatientDetails(patientFileNo);
        }

        void clearFields()
        {
            RepatTypeChecked = false;
            AssistTypeChecked = false;
            TransportTypeChecked = false;
            EvacuationTypeChecked = false;
            RMRTypeChecked = false;
        }

        void PatientDetailsClear()
        {
            
            PATIENT_FIRST_NAME = "";
            PATIENT_LAST_NAME = "";
        }
        #endregion

        private void PopulateLists()
        {
            Library.Transport commFuncs = new Transport();
            var transportList = commFuncs.GetTransports();
            TransportTypeList = new ObservableCollection<TransportModel>(transportList);

            var assistFunc = new Assist();
            var assistTyList = assistFunc.GetAssistTypes();
            AssistTypeList = new ObservableCollection<AssistModel>(assistTyList);

            var evacFunc = new Evacuation();
            var evaclist = evacFunc.GetEvacuations();
            EvacuationList = new ObservableCollection<EvacuationModel>(evaclist);

            var repat = new Repat();
            var repatList = repat.GetRepats();
            RepatList = new ObservableCollection<RepatModel>(repatList);

            var rmr = new RMR();
            var rmrlist = rmr.GetRMRs();
            RMRList = new ObservableCollection<RMRModel>(rmrlist);

            //Library.Transport commFuncs = new Transport();
            //var transportList = commFuncs.GetTransports();
            //TransportTypeList = new ObservableCollection<TransportModel>(transportList);
            //var departments = commFuncs.GetAllDepartments();
            //DepartmentList = new ObservableCollection<DepartmentModel>(departments);

            //var jobtitles = commFuncs.GetAllJobTitles();
            //JobTitleList = new ObservableCollection<JobTitleModel>(jobtitles);

            //var roleslist = commFuncs.GetAllRoles();
            //RoleList = new ObservableCollection<RoleModel>(roleslist);
            //
        }
    }
}




























































































































































































    