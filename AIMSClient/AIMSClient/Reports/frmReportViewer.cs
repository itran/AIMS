using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIMS.Client;
using AIMS.BLL;


namespace AIMSClient
{
    public partial class frmReportViewer : Form
    {
        private string _reportName = string.Empty;
        private DataSet _dsHTML;
        private bool _showPageNumbers;
        private string _reportID;
        CommonFuncs clsComm;

        private int _GuarantorID;

        public int GuarantorID
        {
            get { return _GuarantorID; }
            set { _GuarantorID = value; }
        }

        private string _patientFileNo;

        public string  PatientFileNo
        {
            get { return _patientFileNo; }
            set { _patientFileNo = value; }
        }
	
        public frmReportViewer(string reportID,string reportName)
        {
            InitializeComponent();
            _reportID = reportID;
            _reportName = reportName;
        }

        public frmReportViewer(string reportName,DataSet htmlDataset)
        {
            InitializeComponent();
            _reportName = reportName;
            _dsHTML = htmlDataset;
        }


        #region Public Properties
        
        /// <summary>
        /// This is the caption of the report form
        /// </summary>
        public string ReportName
        {
            get { return _reportName; }
            set { _reportName = value; }
        }

        /// <summary>
        /// This is the HTML dataset used to populate the report
        /// </summary>
        public DataSet HTMLDataset
        {
            get { return _dsHTML; }
            set { _dsHTML = value; }
        }

        /// <summary>
        /// This property determines whether pages numbers should be displayed on the report
        /// </summary>
        public bool ShowPageNumbers
        {
            get { return _showPageNumbers; }
            set { _showPageNumbers = value; }
        }

        
        #endregion

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this report","AIMS Report",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmReportViewer_Resize(object sender, EventArgs e)
        {
            this.htmlReporter1.Height = Convert.ToInt32(this.Height * 0.99);
            this.htmlReporter1.Width = Convert.ToInt32(this.Width * 0.99);
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            //Sets the caption of the form
            this.Text = ReportName;
            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            _dsHTML = new DataSet();
            DataRow dr;
            Reports reportBLL = new Reports();
            clsComm = new CommonFuncs();
             
            htmlReporter1.HTMLShowFaxButton = false;
            htmlReporter1.HTMLShowPageNo = false;
            htmlReporter1.HTMLShowEmailButton = false;
            htmlReporter1.HTMLShowPrintPrevButton = false;
            htmlReporter1.HTMLShowRefreshButton = false;
            htmlReporter1.HTMLShowEmptyButton = false;
            htmlReporter1.HTMLShowCopyButton = false;

            try
            {
                switch (_reportName.ToUpper().Substring(0,17))
                {
                    case "AIMS LEDGER REPOR":
                        this.Text = _reportName;
                        _dsHTML = reportBLL.BuildAIMSLedgerReport(GuarantorID);
                        htmlReporter1.HTMLDataset = _dsHTML;
                        break;
                    case "CONSOLIDATION REP":
                        this.Text = _reportName;
                        _dsHTML = reportBLL.BuildConsolidationCoverReport(_reportID, "");
                        htmlReporter1.HTMLDataset = _dsHTML;
                        break;
                }
            }
            catch (Exception ex)
            {
                clsComm.DisplayMessage(ex.Message, AIMS.Common.CommonTypes.MessagType.Error);
            }
            SetUpReport();
        }

        /// <summary>
        /// This method loads the actual report
        /// </summary>
        private void SetUpReport()
        {
            clsComm = new CommonFuncs();
            
            try
            {

            }
            catch (Exception ex)
            {
                clsComm.DisplayMessage(ex.Message, AIMS.Common.CommonTypes.MessagType.Error);
            }
        }
    }
}