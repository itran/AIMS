using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Legacy.WPFRegionalManager.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private DateTime _loginDate = DateTime.Now;

        public MenuViewModel()
        {

        }
        public DateTime LoginDate
        {
            get { return _loginDate; }
            set { SetProperty(ref _loginDate, value); }
        }

        private string _loginName;

        public string LoginName
        {
            get { return _loginName; }
            set { SetProperty(ref _loginName, value); }
        }

        private string _loginPassword;

        public string LoginPassword
        {
            get { return _loginPassword; }
            set { SetProperty(ref _loginPassword, value); }
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

        public DelegateCommand LoginCommand { get; set; }

        public DelegateCommand CreatePasswordCommand { get; set; }

        public DelegateCommand<string> NavigateCommand { get; set; }

        public MenuViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;
            LoginCommand = new DelegateCommand(ProcessLogin, canLogin).ObservesProperty(() => LoginName).ObservesProperty(() => LoginPassword);
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private bool canLogin()
        {
            return !string.IsNullOrWhiteSpace(LoginName) && !string.IsNullOrWhiteSpace(LoginPassword);
        }

        private void ProcessLogin()
        {
            LoginDate = DateTime.Now;
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("Login", uri);
        }

    }
}
