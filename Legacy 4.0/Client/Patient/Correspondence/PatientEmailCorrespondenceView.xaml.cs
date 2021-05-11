using Legacy.WPFRegionalManager.ViewModels.Patient;
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

namespace Legacy.WPFRegionalManager.Views.Patient
{
    /// <summary>
    /// Interaction logic for PatientEmailCorrespondenceView.xaml
    /// </summary>
    public partial class PatientEmailCorrespondenceView : UserControl
    {
        public PatientEmailCorrespondenceView()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((PatientEmailCorrespondenceViewModel)DataContext)
                .PatientDetailCommand.Execute(((ListViewItem)sender).Content);
        }

        public PatientEmailCorrespondenceViewModel _vm;
        public PatientEmailCorrespondenceView(PatientEmailCorrespondenceViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            _vm = vm;
        }
    }
}
