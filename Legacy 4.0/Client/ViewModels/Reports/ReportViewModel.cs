using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using Unity;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.WPFRegionalManager.ViewModels
{
    public class ReportViewModel:BindableBase
    {
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

        public ReportViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;
        }
    }
}
