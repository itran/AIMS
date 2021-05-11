using Legacy.WPFRegionalManager.Views.Patient;
using Prism.Regions;
using System;
using System.Windows;

namespace Legacy.WPFRegionalManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            if (regionManager == null)
            {
                throw new ArgumentNullException(nameof(regionManager)); 
            }
            regionManager.RegisterViewWithRegion("Login", typeof(Login));
            regionManager.RegisterViewWithRegion("Menu", typeof(Menu));
            regionManager.RegisterViewWithRegion("WorkRegion", typeof(UserMaintenance.WorkRegion));
            regionManager.RegisterViewWithRegion("UserPermissions", typeof(UserPermissions));
            regionManager.RegisterViewWithRegion("Landing", typeof(Landing));
            regionManager.RegisterViewWithRegion("PatientView", typeof(PatientView));
            regionManager.RegisterViewWithRegion("PatientDetailView", typeof(PatientDetailView));
            regionManager.RegisterViewWithRegion("PatientNoteView", typeof(PatientNoteView));
            regionManager.RegisterViewWithRegion("PatientServiceProviderView", typeof(PatientServiceProviderView));
            regionManager.RegisterViewWithRegion("PatientEmailCorrespondenceView", typeof(PatientEmailCorrespondenceView));
            regionManager.RegisterViewWithRegion("Invoice", typeof(Invoice));
            
        }
    }
}
