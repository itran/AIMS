using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Legacy.WPFRegionalManager.ViewModels;

namespace Legacy.WPFRegionalManager.Views
{
    /// <summary>
    /// Interaction logic for Mail.xaml
    /// </summary>
    public partial class Mail : UserControl
    {
        public Mail()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((MailViewModel)DataContext)
                .MailDetailCommand.Execute(((ListViewItem)sender).Content);
        }

        private void ListViewItemEmail_Selected(object sender, EventArgs e)
        {
            ((MailViewModel)DataContext)
                .MailDetailCommand.Execute(((ListViewItem)sender).Content);
        }

        private void ListViewItemEmailAttachment_Selected(object sender, EventArgs e)
        {
            ((MailViewModel)DataContext)
                .MailAttachmentDetailCommand.Execute(((ListViewItem)sender).Content);
        }

        
        public MailViewModel _vm;
        public Mail(MailViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            _vm = vm;
        }
    }
}
