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
    public class PatientServiceProviderViewModel : BindableBase
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

        public PatientServiceProviderViewModel(PatientModel _project)
        {

        }

        public PatientServiceProviderViewModel()
        {

        }


        private int _SERVICE_PROVIDER_ID;
        private int _PATIENT_ID;
        private int _SUPPLIER_TYPE_ID;
        private string _SERVICE_PROVIDER_NAME;
        private string _SERVICE_PROVIDER_PHONE;
        private string _SERVICE_PROVIDER_FAX_NO;
        private string _SERVICE_PROVIDER_EMAIL;
        private string _USER_NAME;
        private string _ADMIN_NAME;
        private string _ADMIN_TEL_PHONE;
        private string _ADMIN_FAX_NO;
        private string _ADMIN_EMAIL;


        public int SERVICE_PROVIDER_ID { get { return _SERVICE_PROVIDER_ID; } set { _SERVICE_PROVIDER_ID = value; RaisePropertyChanged("SERVICE_PROVIDER_ID"); } }
        public int PATIENT_ID { get { return _PATIENT_ID; } set { _PATIENT_ID = value; RaisePropertyChanged("PATIENT_ID"); } }
        public int SUPPLIER_TYPE_ID { get { return _SUPPLIER_TYPE_ID; } set { _SUPPLIER_TYPE_ID = value; RaisePropertyChanged("SUPPLIER_TYPE_ID"); } }
        public string SERVICE_PROVIDER_NAME { get { return _SERVICE_PROVIDER_NAME; } set { _SERVICE_PROVIDER_NAME = value; RaisePropertyChanged("SERVICE_PROVIDER_NAME"); } }
        public string SERVICE_PROVIDER_PHONE { get { return _SERVICE_PROVIDER_PHONE; } set { _SERVICE_PROVIDER_PHONE = value; RaisePropertyChanged("SERVICE_PROVIDER_PHONE"); } }
        public string SERVICE_PROVIDER_FAX_NO { get { return _SERVICE_PROVIDER_FAX_NO; } set { _SERVICE_PROVIDER_FAX_NO = value; RaisePropertyChanged("SERVICE_PROVIDER_FAX_NO"); } }
        public string SERVICE_PROVIDER_EMAIL { get { return _SERVICE_PROVIDER_EMAIL; } set { _SERVICE_PROVIDER_EMAIL = value; RaisePropertyChanged("SERVICE_PROVIDER_EMAIL"); } }
        public string USER_NAME { get { return _USER_NAME; } set { _USER_NAME = value; RaisePropertyChanged("USER_NAME"); } }
        public string ADMIN_NAME { get { return _ADMIN_NAME; } set { _ADMIN_NAME = value; RaisePropertyChanged("ADMIN_NAME"); } }
        public string ADMIN_TEL_PHONE { get { return _ADMIN_TEL_PHONE; } set { _ADMIN_TEL_PHONE = value; RaisePropertyChanged("ADMIN_TEL_PHONE"); } }
        public string ADMIN_FAX_NO { get { return _ADMIN_FAX_NO; } set { _ADMIN_FAX_NO = value; RaisePropertyChanged("ADMIN_FAX_NO"); } }
        public string ADMIN_EMAIL { get { return _ADMIN_EMAIL; } set { _ADMIN_EMAIL = value; RaisePropertyChanged("ADMIN_EMAIL"); } }

        #region "Observable Collections"
        private ObservableCollection<ServiceProviderModel> _PatientServiceProviderList;
        public ObservableCollection<ServiceProviderModel> PatientServiceProviderList
        {
            get { return _PatientServiceProviderList; }
            set
            {
                if (_PatientServiceProviderList != value)
                    _PatientServiceProviderList = value;
                RaisePropertyChanged("PatientServiceProviderList");
            }
        }
        #endregion

        public DelegateCommand<string> PatientDetailCommand { get; set; }


        public PatientServiceProviderViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;            
        }

        public PatientServiceProviderViewModel(PatientViewViewModel patientViewViewModel)
        {
            this.parent = patientViewViewModel;
        }

        public async Task LoadAsync(string patientId)
        {
            await GetPatientFileServiceProviders(patientId);
        }

        private async Task GetPatientFileServiceProviders(string patientId)
        {
            var provider = new Library.ServiceProvider();
            var providerlist = provider.GetPatientServiceProviders(patientId);
            PatientServiceProviderList = new ObservableCollection<ServiceProviderModel>(providerlist);
        }
    }
}
