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
    public class LandingViewModel:BindableBase
    {
        private DateTime _loginDate = DateTime.Now;

        public LandingViewModel()
        {

        }
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

        public LandingViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;
        }
    }
}
