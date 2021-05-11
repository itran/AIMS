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
    /// Interaction logic for NoteView.xaml
    /// </summary>
    public partial class PatientNoteView : UserControl
    {
        public PatientNoteView()
        {
            InitializeComponent();
        }

        public PatientNoteViewModel _vm;

        
        public PatientNoteView(PatientNoteViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            _vm = vm;
        }

        private void NoteViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((PatientViewViewModel)DataContext)
                .PatientNoteDetailCommand.Execute(((ListViewItem)sender).Content);
        }
    }
}
