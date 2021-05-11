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
using System.Windows.Shapes;

namespace Legacy.WPFRegionalManager.UIControls
{
    /// <summary>
    /// Interaction logic for ReIndexFile.xaml
    /// </summary>
    public partial class ReIndexFile : Window
    {
        public ReIndexFile()
        {
            InitializeComponent();
        }

        public ReIndexFile(string question, string defaultAnswer = "")
        {
            InitializeComponent();
            lblQuestion.Content = question;
            txtAnswer.Text = defaultAnswer;
        }

        public string Answer
        {
            get { return txtAnswer.Text; }
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
