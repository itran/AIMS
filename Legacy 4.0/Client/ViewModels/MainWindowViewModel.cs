using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using Unity;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Legacy.WPFRegionalManager.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region "Delegate Commands"
        public DelegateCommand<string> PatientNavigateCommand { get; set; }
        public DelegateCommand<string> MailNavigateCommand { get; set; }
        public DelegateCommand<string> InvoiceNavigateCommand { get; set; }
        public DelegateCommand<string> PaymentNavigateCommand { get; set; }
        public DelegateCommand<string> SupplierNavigateCommand { get; set; }
        public DelegateCommand<string> GuarantorNavigateCommand { get; set; }
        public DelegateCommand<string> DashboardNavigateCommand { get; set; }
        public DelegateCommand<string> WorkbasketNavigateCommand { get; set; }
        public DelegateCommand<string> AdminReportNavigateCommand { get; set; }
        public DelegateCommand<string> OperationReportNavigateCommand { get; set; }
        public DelegateCommand<string> FinanceReportNavigateCommand { get; set; }
        public DelegateCommand<string> UserPermissionCommand { get; set; }
        public DelegateCommand<string> UserRolesCommand { get; set; }
        public DelegateCommand<string> RolesCommand { get; set; }
        public DelegateCommand<string> UserAdminCommand { get; set; }

        public DelegateCommand<string> UserAdminNavigateCommand { get; set; }
        public DelegateCommand<string> RoleAdminNavigateCommand { get; set; }
        public DelegateCommand<string> UserRoleNavigateCommand { get; set; }

        public DelegateCommand<string> PermissionNavigateCommand { get; set; }


        public DelegateCommand ExitCommand { get; set; }
        #endregion

        #region "Public Properties"
        public DateTime LoginDate
        {
            get { return _loginDate; }
            set { SetProperty(ref _loginDate, value); }
        }

        private string _loginName;

        public string LastLogin
        {
            get { return _loginName; }
            set { SetProperty(ref _loginName, value); }
        }
        #endregion

        #region PrivateProperties
        private DateTime _loginDate = DateTime.Now;

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

        #endregion

        #region Constructors
        public MainWindowViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;
            InvoiceNavigateCommand = new DelegateCommand<string>(OpenInvoices);
            PatientNavigateCommand = new DelegateCommand<string>(OpenPatients);
            MailNavigateCommand = new DelegateCommand<string>(OpenMails);
            PaymentNavigateCommand = new DelegateCommand<string>(OpenPayments);
            SupplierNavigateCommand = new DelegateCommand<string>(OpenSuppliers);
            GuarantorNavigateCommand = new DelegateCommand<string>(OpenGuarantos);
            DashboardNavigateCommand = new DelegateCommand<string>(OpenDashboard);
            WorkbasketNavigateCommand = new DelegateCommand<string>(OpenWorkBasket);
            AdminReportNavigateCommand = new DelegateCommand<string>(OpenAdminReports);
            FinanceReportNavigateCommand = new DelegateCommand<string>(OpenFinanceReports);
            OperationReportNavigateCommand = new DelegateCommand<string>(OpenOperationReports);
            ExitCommand = new DelegateCommand(ExitApp);
            UserAdminNavigateCommand = new DelegateCommand<string>(UserAdmin);
            RoleAdminNavigateCommand = new DelegateCommand<string>(RoleAdmin);
            UserRoleNavigateCommand = new DelegateCommand<string>(UserRole);
            PermissionNavigateCommand = new DelegateCommand<string>(PermissionAdmin);
        }

        private void ExitApp()
        {
            Application.Current.MainWindow.Close();
        }
        #endregion

        #region Mavigation Methods
        private void OpenPatients(string uri){_regionManager.RequestNavigate("Login", uri); }
        private void OpenInvoices(string uri) { _regionManager.RequestNavigate("Login", uri); }
        private void OpenMails(string uri){   _regionManager.RequestNavigate("Login", uri);}
        private void OpenPayments(string uri){ _regionManager.RequestNavigate("Login", uri); }
        private void OpenSuppliers(string uri){ _regionManager.RequestNavigate("Login", uri); }
        private void OpenGuarantos(string uri){ _regionManager.RequestNavigate("Login", uri); }
        private void OpenDashboard(string uri){ _regionManager.RequestNavigate("Login", uri); }
        private void OpenWorkBasket(string uri){ _regionManager.RequestNavigate("Login", uri); }
        private void OpenAdminReports(string uri){ _regionManager.RequestNavigate("Login", uri); }
        private void OpenFinanceReports(string uri) { _regionManager.RequestNavigate("Login", uri); }
        private void OpenOperationReports(string uri) { _regionManager.RequestNavigate("Login", uri); }
        private void OpenAdmin(string uri){ _regionManager.RequestNavigate("Login", uri); }
        private void UserAdmin(string uri) { _regionManager.RequestNavigate("Login", uri); }
        private void RoleAdmin(string uri) { _regionManager.RequestNavigate("Login", uri); }
        private void UserRole(string uri) { _regionManager.RequestNavigate("Login", uri); }
        private void PermissionAdmin(string uri) { _regionManager.RequestNavigate("Login", uri); }
        #endregion
    }
}
