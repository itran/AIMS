using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Unity;
using System;
using Legacy.Library;
using Legacy.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Prism.Commands;
using System.Collections.Generic;
using System.Linq;
          
namespace Legacy.WPFRegionalManager.ViewModels
{
    public class MailViewModel : BindableBase
    {
        public MailViewModel(MailViewModel _project)
        {

        }

        public MailViewModel()
        {

        }

        private bool urgentEmail;

        public bool UrgentEmail
        {
            get { return urgentEmail; }
            set { urgentEmail = value; }
        }

        private string searchKeyword = "";

        public string SearchKeyword
        {
            get { return searchKeyword; }
            set { searchKeyword = value; }
        }

        private string imageSource;
        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                if (imageSource != value)
                    imageSource = value;
                RaisePropertyChanged("ImageSource");
            }
        }
        public DelegateCommand<object> MailDetailCommand { get; set; }
        public DelegateCommand<object> MailAttachmentDetailCommand { get; set; }

        private IEventAggregator _eventArg;
        private IRegionManager _regionManager;
        private IUnityContainer _container;
        
        public MailViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
        {
            _eventArg = eventArg;
            _regionManager = regionManager;
            _container = container;
            MailDetailCommand = new DelegateCommand<object>(MailDetailLoad);
            MailAttachmentDetailCommand = new DelegateCommand<object>(MailAttachmentDetailLoad);
            SearchCommand = new DelegateCommand(SearchPatient, canSearch);
            PopulateLists();
        }

        bool canSearch()
        {
            return true;
            //if (!string.IsNullOrWhiteSpace(SearchKeyword))
            //{
            //    return true;
            //}
            //return false;
        }

        void SearchPatient()
        {
            if (!string.IsNullOrWhiteSpace(SearchKeyword))
            {
                Library.MailBox mail = new Library.MailBox();
                var mailList = mail.GetMailBoxEmail(SelectedMailbox.MAILBOX_ID, "BRIAN", SearchKeyword);
                MailList = new ObservableCollection<MaiBoxEmailItemModel>(mailList);
            }
        }

        private readonly MailBoxModel _blankMailBox = new MailBoxModel { MAILBOX_ID = 0, MAILBOX_NAME=""};

        private void PopulateLists()
        {
            Library.MailBox commFuncs = new Library.MailBox();
            var MailBoxes = new List<MailBoxModel> { _blankMailBox };
            var mailboxList = commFuncs.GetMailBoxes("");
            MailBoxList = new ObservableCollection<MailBoxModel>(mailboxList);

            MailBoxList.AddRange(MailBoxes);
            MailBoxList.OrderBy(p => p.MAILBOX_NAME);

        }

        private ObservableCollection<MailBoxModel> mailboxList;
        public ObservableCollection<MailBoxModel> MailBoxList
        {
            get { return mailboxList; }
            set
            {
                if (mailboxList != value)
                    mailboxList = value;
                RaisePropertyChanged("MailBoxList");
            }
        }
        
        private ObservableCollection<MailItemAttachmentModel> mailAttachmentList;
        public ObservableCollection<MailItemAttachmentModel> MailAttachmentList
        {
            get { return mailAttachmentList; }
            set
            {
                if (mailAttachmentList != value)
                    mailAttachmentList = value;
                RaisePropertyChanged("MailAttachmentList");
            }
        }

        private ObservableCollection<MaiBoxEmailItemModel> mailList;
        public ObservableCollection<MaiBoxEmailItemModel> MailList
        {
            get { return mailList; }
            set
            {
                if (mailList != value)
                    mailList = value;
                RaisePropertyChanged("MailList");
            }
        }

        private MailBoxModel selectedMailbox;

        public MailBoxModel SelectedMailbox
        {
            get { return selectedMailbox; }
            set
            {
                MailboxEmailClear();
                selectedMailbox = value;

                if (value != null & !string.IsNullOrWhiteSpace(value.MAILBOX_NAME))
                {
                    Library.MailBox mail = new Library.MailBox();
                    var mailList = mail.GetMailBoxEmail(value.MAILBOX_ID, "JADEP", SearchKeyword);
                    MailList = new ObservableCollection<MaiBoxEmailItemModel>(mailList);
                }

                RaisePropertyChanged("SelectedMailbox");
            }
        }

        private void MailboxEmailClear()
        {
            MailList = null;
            MailAttachmentList = null;
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                _searchCommand = value;
                RaisePropertyChanged("SearchCommand");
            }
        }

        void MailDetailLoad(object MailItemModel)
        {
            if (MailItemModel != null)
            {
                MaiBoxEmailItemModel mailItemDetail = (MaiBoxEmailItemModel)MailItemModel;
                if (mailItemDetail!=null)
                {
                    int mailId = mailItemDetail.EMAIL_ID;
                    if (mailId > 0)
                    {
                        Library.MailBox mail = new Library.MailBox();
                        var mailItemAttachmentList = mail.GetMailItemAttachment(mailId);
                        MailAttachmentList = new ObservableCollection<MailItemAttachmentModel>(mailItemAttachmentList);
                    }
                }
            }
        }

        void MailAttachmentDetailLoad(object MailItemModel)
        {
            if (MailItemModel != null)
            {
                MailItemAttachmentModel mailItemDetail = (MailItemAttachmentModel)MailItemModel;
                if (mailItemDetail != null)
                {
                    int emailAttachmentlId = mailItemDetail.ATTACHMENT_ID;
                    if (emailAttachmentlId > 0)
                    {
                        ImageSource = @"D:\temp\COVID19.pdf";
                    }
                }
            }
        }
    }

    public static class WebBrowserUtility
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser browser = o as WebBrowser;

            if (browser != null)
            {
                string content = e.NewValue as string;
                if (string.IsNullOrEmpty(content))
                {
                    return; //Just incase 
                }
                browser.NavigateToString(@"<html><body style='background: white; text - align:center; height: 100px; '><h1>Error Loading</h1></body></html>");
                browser.Navigate(!String.IsNullOrEmpty(content) ? content : "");
                browser.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(WebBrowser_LoadCompleted);
                browser.Focus();
            }
        }

        private static void WebBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //DocumentManagmentViewModel dmvm = new DocumentManagmentViewModel();
            if (e.Uri.AbsolutePath != (sender as WebBrowser).ToString())
            {
                return;
            }
            else
            {
                //  dmvm.OnPdfLoaded(new object());
            }
        }

        private static void PDFLoaded(object sender, System.EventArgs e)
        {

        }
    }

    public class WebBrowserExtentions
    {
        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.RegisterAttached("Document", typeof(string), typeof(WebBrowserExtentions), new UIPropertyMetadata(null, DocumentPropertyChanged));

        public static string GetDocument(DependencyObject element)
        {
            return (string)element.GetValue(DocumentProperty);
        }

        public static void SetDocument(DependencyObject element, string value)
        {
            element.SetValue(DocumentProperty, value);
        }

        public static void DocumentPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser browser = target as WebBrowser;
            if (browser != null)
            {
                string document = e.NewValue as string;
                if (string.IsNullOrWhiteSpace(document))
                {
                    browser.NavigateToString(document);
                }
            }
        }
    }
}
