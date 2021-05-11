using Legacy.WPFRegionalManager.Views;
using Prism.Unity;
using System.Windows;
using Unity;

namespace Legacy.WPFRegionalManager
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType(typeof(object), typeof(PatientView), "PatientView");
            Container.RegisterType(typeof(object), typeof(Invoice), "Invoice");
            Container.RegisterType(typeof(object), typeof(Login), "Login");
            Container.RegisterType(typeof(object), typeof(Menu), "Menu");
            Container.RegisterType(typeof(object), typeof(Landing), "Landing");
            Container.RegisterType(typeof(object), typeof(Dashbooard), "Dashboard");
            Container.RegisterType(typeof(object), typeof(Admin), "Admin");
            Container.RegisterType(typeof(object), typeof(Payment), "Payment");
            Container.RegisterType(typeof(object), typeof(Report), "Report");
            Container.RegisterType(typeof(object), typeof(Supplier), "Supplier");
            Container.RegisterType(typeof(object), typeof(Workbasket), "Workbasket");
            Container.RegisterType(typeof(object), typeof(Mail), "Mail");
            Container.RegisterType(typeof(object), typeof(Guarantor), "Guarantor");
            Container.RegisterType(typeof(object), typeof(AdminReport), "AdminReport");
            Container.RegisterType(typeof(object), typeof(UserMaintainer), "UserMaintainer");
            Container.RegisterType(typeof(object), typeof(UserPermissions), "UserPermissions");
            Container.RegisterType(typeof(object), typeof(RoleMaintainer), "RoleMaintainer");
        }
    }
}
