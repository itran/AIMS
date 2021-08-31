using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmSentImageViewer : Form
    {
        public frmSentImageViewer()
        {
            InitializeComponent();
        }

        AIMS.Common.CommonFunctions commonFuncs;

        string _EmailDocument = "";
        public string EmailDocument
        {
            get { return _EmailDocument; }
            set
            {
                _EmailDocument = value;
            }
        }

        string _EmailSentFrom = "";
        public string EmailFrom
        {
            get { return _EmailSentFrom; }
            set
            {
                _EmailSentFrom = value;
            }
        }

        string _EmailSentTo = "";
        public string EmailTo
        {
            get { return _EmailSentTo; }
            set
            {
                _EmailSentTo = value;
            }
        }

        string _EmailSentToCC = "";
        public string EmailToCC
        {
            get { return _EmailSentToCC; }
            set
            {
                _EmailSentToCC = value;
            }
        }

        string _EmailSubject = "";
        public string EmailSubject
        {
            get { return _EmailSubject; }
            set
            {
                _EmailSubject = value;
            }
        }

        string _EmailSentDTTM = "";
        public string EmailSentDTTM
        {
            get { return _EmailSentDTTM; }
            set
            {
                _EmailSentDTTM = value;
            }
        }

        private void frmSentImageViewer_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                txtSentEmailCC.Text = EmailToCC;
                txtSentEmailTo.Text = EmailTo;
                txtSentEmailFrom.Text = EmailFrom;
                txtSentEmailSubject.Text = EmailSubject;
                txtSentDttm.Text = EmailSentDTTM;

                if (!EmailDocument.Equals(""))
                {
                    imgViewer.Navigate(EmailDocument);
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Problem opening email document, Please contact System Administrator");
                commonFuncs.ErrorLogger("Problem opening email document \n" + ex.ToString());
            }
            finally
            {
                commonFuncs = null;
            }
        }
    }
}