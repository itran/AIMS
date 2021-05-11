using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Legacy.WPFRegionalManager.ViewModels;
using Legacy.WPFRegionalManager.ViewModels.Patient;

namespace Legacy.WPFRegionalManager.Views
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : UserControl
    {
        public PatientView()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((PatientViewViewModel)DataContext)
                .PatientDetailCommand.Execute(((ListViewItem)sender).Content);
        }

        public PatientViewViewModel _vm;
        public PatientView(PatientViewViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            _vm = vm;
        }
    }
}
