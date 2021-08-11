
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace AIMSClient
{
    public partial class frmImageViewer : Form
    {
        private WebBrowser imgViewer1 = new WebBrowser();
        private WebBrowser imgViewer2 = new WebBrowser();

        public frmImageViewer()
        {
            InitializeComponent();
        }
        AIMS.Common.CommonFunctions commonFuncs;

        string _PatientEnquiryID = "";
        public string PatientEnquiryID
        {
            get { return _PatientEnquiryID; }
            set
            {
                _PatientEnquiryID = value;
            }
        }

        string _EmailDocument = "";
        public string EmailDocument
        {
            get { return _EmailDocument; }
            set
            {
                _EmailDocument = value;
            }
        }
        
        public int DocCount = 0;

        private void frmImageViewer_Closing(object sender, CancelEventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                this.imgViewer1.Dispose();
                this.imgViewer1 = null;
                this.imgViewer2.Dispose();
                this.imgViewer2 = null;
                GC.Collect();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error closing email document, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error closing email document \n" + ex.ToString());
            }
            finally
            {
                commonFuncs = null;
            }
        }

        private void frmImageViewer_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                imgViewer1.Visible = false;
                imgViewer2.Visible = false;
                if (!EmailDocument.Equals(""))
                {
                    if (EmailDocument.ToUpper().Contains(".PDF"))
                    {
                        imgViewer1.Visible = true;
                        this.imgViewer1.BackColor = Color.Black;
                        this.imgViewer1.Location = new System.Drawing.Point(0, 0);
                        this.imgViewer1.Size = new System.Drawing.Size(1139, 580);
                        this.imgViewer1.Navigate(new Uri(EmailDocument+"?rnd=" + System.DateTime.Now.Millisecond ));
                        this.Controls.Add(imgViewer1);
                        this.imgViewer1.Refresh(WebBrowserRefreshOption.Completely);
                    }
                    else
                    {
                        imgViewer2.Visible = true;
                        this.imgViewer2.BackColor = Color.Black;
                        this.imgViewer2.Location = new System.Drawing.Point(0, 0);
                        this.imgViewer2.Size = new System.Drawing.Size(1139, 580);
                        this.imgViewer2.Navigate(new Uri(EmailDocument + "?rnd=" + System.DateTime.Now.Millisecond));
                        this.Controls.Add(imgViewer2);
                        this.imgViewer2.Refresh(WebBrowserRefreshOption.Completely);
                    }
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