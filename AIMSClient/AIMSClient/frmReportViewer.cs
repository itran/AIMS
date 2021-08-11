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
        private string _ledgertype = string.Empty;
        private string _LateInvoiceYN = "";

        string _Forex = "";
        string _InsuranceOverPayment = "";
        string _InsuranceShortPayment = "";
        
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
        
        string _ReportStartDate;
        string _ReportEndDate;

        public string ReportStartDate
        {
            get { return _ReportStartDate; }
            set { _ReportStartDate = value; }
        }

        public string ReportEndDate
        {
            get { return _ReportEndDate; }
            set { _ReportEndDate = value; }
        }

        private string _patientFileNo;

        public string  PatientFileNo
        {
            get { return _patientFileNo; }
            set { _patientFileNo = value; }
        }

        public string LateInvoiceYN
        {
            get { return _LateInvoiceYN; }
            set { _LateInvoiceYN = value; }
        }
        
        string _PatientAnalysisStartDate = "";
        public string PatientAnalysisStartDate
        {
            get { return _PatientAnalysisStartDate; }
            set { _PatientAnalysisStartDate = value; }
        }

        string _PatientAnalysisEndDate = "";
        public string PatientAnalysisEndDate
        {
            get { return _PatientAnalysisEndDate; }
            set { _PatientAnalysisEndDate = value; }
        }

        string _File_status = "";
        public string File_status
        {
            get { return _File_status; }
            set { _File_status = value; }
        }

        string _Guarantor = "";
        public string Guarantor
        {
            get { return _Guarantor; }
            set { _Guarantor = value; }
        }

        public string Supplier
        {
            get { return _LateInvoiceYN; }
            set { _LateInvoiceYN = value; }
        }

        string _ServiceProviderID = "";
        public string ServiceProviderID
        {
            get { return _ServiceProviderID; }
            set { _ServiceProviderID = value; }
        }

        string _AdmissionDate = "";
        public string AdmissionDate
        {
            get { return _AdmissionDate; }
            set { _AdmissionDate = value; }
        }

        string _Diagnosis = "";
        public string Diagnosis
        {
            get { return _Diagnosis; }
            set { _Diagnosis = value; }
        }

        string _Procedure = "";
        public string Procedure
        {
            get { return _Procedure; }
            set { _Procedure = value; }
        }
        string _AdmissionCode = "";
        public string AdmissionCode
        {
            get { return _AdmissionCode; }
            set { _AdmissionCode = value; }
        }
        
        string _Attention = "";
        public string Attention
        {
            get { return _Attention; }
            set { _Attention = value; }
        }
        string _Exclusions = "";
        public string Exclusions
        {
            get { return _Exclusions; }
            set { _Exclusions = value; }
        }

        string _Comments = "";
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        string _PatientName = "";
        public string PatientName
        {
            get { return _PatientName; }
            set { _PatientName = value; }
        }

        string _GuaranteAmount = "";
        public string GuaranteAmount
        {
            get { return _GuaranteAmount; }
            set { _GuaranteAmount = value; }
        }

        string _UserSignedOn = "";
        public string UserSignedOn
        {
            get { return _UserSignedOn; }
            set { _UserSignedOn = value; }
        }
        
        string _Patient_Status_In_Out = "";
        public string Patient_Status_In_Out
        {
            get { return _Patient_Status_In_Out; }
            set { _Patient_Status_In_Out = value; }
        }

        string _Aims_Service = "";
        public string Aims_Service
        {
            get { return _Aims_Service; }
            set { _Aims_Service = value; }
        }

        string _Aims_Service_type = "";
        public string Aims_Service_type
        {
            get { return _Aims_Service_type; }
            set { _Aims_Service_type = value; }
        }

        string _AssistType = "";
        public string AssistType
        {
            get { return _AssistType; }
            set { _AssistType = value; }
        }

        string _TransportType = "";
        public string TransportType
        {
            get { return _TransportType; }
            set { _TransportType = value; }
        }

        string _LateInvoiceSentYN = "";

        public string LateInvoiceSentYN
        {
            get { return _LateInvoiceSentYN; }
            set { _LateInvoiceSentYN = value; }
        }

        string _CaseCoOrdinator = "";
        public string CaseCoOrdinator
        {
            get { return _CaseCoOrdinator; }
            set { _CaseCoOrdinator = value; }
        }

        string _CoOrdinatorName = "";
        public string CoOrdinatorName
        {
            get { return _CoOrdinatorName; }
            set { _CoOrdinatorName = value; }
        }

        string _startDate = "";
        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        string _endDate = "";
        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        string _ageAnalysisPeriod = "";
        public string AgeAnalysisPeriod
        {
            get { return _ageAnalysisPeriod; }
            set { _ageAnalysisPeriod = value; }
        }

        public frmReportViewer(string reportID,string reportName)
        {
            try
            {
                InitializeComponent();
                _reportID = reportID;
                _reportName = reportName;
                _patientFileNo = reportID;
            }
            catch (System.Exception ex)
            {             
            }
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
        public string LedgerType
        {
            get { return _ledgertype; }
            set { _ledgertype = value; }
        }

        /// <summary>
        /// This is the caption of the report form
        /// </summary>
        public string Forex
        {
            get { return _Forex; }
            set { _Forex = value; }
        }

        public string InsuranceOverPayment
        {
            get { return _InsuranceOverPayment; }
            set { _InsuranceOverPayment = value; }
        }

        public string InsuranceShortPayment
        {
            get { return _InsuranceShortPayment; }
            set { _InsuranceShortPayment = value; }
        }

        string _DoctorOwing = "";
        public string DoctorOwing
        {
            get { return _DoctorOwing; }
            set { _DoctorOwing = value; }
        }        
        
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
            //StringBuilder sbHTML = new StringBuilder();
            //DataTable tbl = new DataTable("HTMLPages");
            _dsHTML = new DataSet();
            //DataRow dr;
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
                switch (_reportName.ToUpper().Substring(0, 17))
                {
                    case "AIMS LEDGER REPOR":
                        if (LedgerType.ToUpper() == "FOREX")
                        {
                            this.Text = _reportName;
                            _dsHTML = reportBLL.BuildAIMSForexLedgerReport(GuarantorID, LedgerType, Forex, InsuranceOverPayment, InsuranceShortPayment, DoctorOwing, LateInvoiceYN, StartDate, EndDate, AgeAnalysisPeriod,  UserSignedOn, Guarantor);
                            htmlReporter1.HTMLDataset = _dsHTML;                            
                        }
                        else
                        {
                            this.Text = _reportName;
                            _dsHTML = reportBLL.BuildAIMSLedgerReport(GuarantorID, LedgerType, StartDate, EndDate, AgeAnalysisPeriod, UserSignedOn, Guarantor);
                            htmlReporter1.HTMLDataset = _dsHTML;
                        }
                        break;
                    case "CONSOLIDATION REP":
                        this.Text = _reportName;
                        string InvoiceStatementFiles = "";
                        _dsHTML = reportBLL.BuildConsolidationCoverReport(_reportID, LateInvoiceYN, DoctorOwing, LateInvoiceSentYN, false, ref InvoiceStatementFiles);
                        
                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice ;
                        break;
                    case "PATIENT ANALYSISS":
                        this.Text = _reportName;
                        _dsHTML = reportBLL.BuildPatientAnalysisReport(PatientAnalysisStartDate, PatientAnalysisEndDate, File_status, Guarantor , Supplier, Patient_Status_In_Out, Aims_Service , Aims_Service_type, TransportType , AssistType  );

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "GUARANTOR ANALYSI":
                        this.Text = _reportName;
                        _dsHTML = reportBLL.BuildAIMSGuarantorAnalysisReport(GuarantorID, Guarantor, ReportStartDate, ReportEndDate);

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "ANALYSIS DRILLDOW":
                        this.Text = _reportName;
                        _dsHTML = reportBLL.BuildAIMSGuarantorAnalysisReportDrilldown(GuarantorID, Guarantor, ReportStartDate, ReportEndDate);

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "COORDINATOR CASES":
                        this.Text = "Co-Ordinator Cases: " + CaseCoOrdinator;
                        _dsHTML = reportBLL.CoOrdinatorCase(CaseCoOrdinator, CoOrdinatorName);

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "COORDINATOR SNAPS":
                        this.Text = "Co-Ordinator Workload Snap: " + CaseCoOrdinator;
                        _dsHTML = reportBLL.CoOrdinatorWorkloadSnap(CaseCoOrdinator, CoOrdinatorName);

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "GUARANTEE OF PAYMENT":
                        this.Text = "Co-Ordinator Cases: " + CaseCoOrdinator;
                        _dsHTML = reportBLL.BuildPatientGuarantee(PatientFileNo, Supplier ,ServiceProviderID,AdmissionDate,Diagnosis,Procedure,AdmissionCode,Attention,Exclusions,Comments,UserSignedOn, PatientName, GuaranteAmount);

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "APPOINTMENTSAUDIT":
                        this.Text = "Appointments Audit";
                        _dsHTML = reportBLL.BuildPatientAppointmentsAudit(PatientFileNo);

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "UNALLOCATED FILES":
                        this.Text = "Operations - Unallocated Files";
                        _dsHTML = reportBLL.BuildUnallocatedFiles();

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "UNALLOCATED ADMIN":
                        this.Text = "Administration - Unallocated Files";
                        _dsHTML = reportBLL.BuildUnassignedFiles();

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "UNASSIGNED FILESS":
                        this.Text = "Administration - Unassigned Files";
                        _dsHTML = reportBLL.BuildUnassignedFiles();

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "ADMINISTRATOR CAS":
                        this.Text = "Administrator Cases: " + CaseCoOrdinator;
                        _dsHTML = reportBLL.AdministratorCase(CaseCoOrdinator, CoOrdinatorName);

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "ADMINISTRATOR SNA":
                        this.Text = "Administrator Workload Snap: " + CaseCoOrdinator;
                        _dsHTML = reportBLL.AdministratorWorkloadSnap(CaseCoOrdinator, CoOrdinatorName);

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "HIGH COST FILESSS":
                        this.Text = "- High Cost Files -";
                        _dsHTML = reportBLL.HighCostFiles();

                        htmlReporter1.HTMLDataset = _dsHTML;
                        htmlReporter1.HTMLReportType = UserControls.HTMLControl.HtmlReportTypes.htmInvoice;
                        break;
                    case "":


                        break;
                }
            }
            catch (Exception ex)
            {
                clsComm.DisplayMessage("Consolidated Invoice failed to load, Please contact System Administrator.", AIMS.Common.CommonTypes.MessagType.Error);
                clsComm.ErrorLogger("Consolidation Invoice failed to load, Error:- " + ex.ToString());
            }
            finally 
            {
                clsComm = null;
                _dsHTML.Dispose();
                reportBLL = null;
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

        private void htmlReporter1_Load(object sender, EventArgs e)
        {

        }
    }
}