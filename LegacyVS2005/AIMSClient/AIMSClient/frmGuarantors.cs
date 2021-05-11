using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using AIMS.BLL;
using AIMS.Client;


namespace AIMSClient
{
    public partial class frmGuarantors : Form
    {
        AIMS.Common.CommonFunctions commonFuncs;
        AIMS.BLL.Guarantor _guarantor;

        #region "Private Properties"
        string _userName = "";
        string _userID = "";
        string _userEmailAddress = "";
        #endregion
        #region "Public Properties"

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        public string UserEmailAddress
        {
            get { return _userEmailAddress; }
            set
            {
                _userEmailAddress = value;
            }
        }

        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }

        private string _restrictions = string.Empty;
        public string Restrictions
        {
            get { return _restrictions; }
            set
            {
                _restrictions = value;
            }
        }

        private int _guarantorID;

        public int GuarantorID
        {
            get { return _guarantorID; }
            set { _guarantorID = value; }
        }

        private bool _addNewGuarantor;
        public bool AddNewGuarantor
        {
            get { return _addNewGuarantor; }
            set { _addNewGuarantor = value; }
        }

        #endregion

        public frmGuarantors()
        {
            InitializeComponent();
        }

        private void frmGuarantors_Resize(object sender, EventArgs e)
        {           
            this.gpxGuarantorSearch.Left = this.Left + 2;
            this.gpxGuarantors.Left = this.Left + 2;
            this.gpxGuarantors.Width = this.ClientSize.Width - 4;
            this.gpxGuarantorSearch.Width = (this.ClientSize.Width / 2) - 4;
            this.gpxGuarantorSearch.Height = Convert.ToInt32(this.ClientSize.Height * 0.30);

            gpxGuarantorReports.Top = this.gpxGuarantorSearch.Top;
            gpxGuarantorReports.Height = this.gpxGuarantorSearch.Height;
            gpxGuarantorReports.Left = (this.ClientSize.Width / 2) + 2;
            gpxGuarantorReports.Width = (this.ClientSize.Width / 2) - 4;

            this.gpxGuarantors  .Top = gpxGuarantorSearch.Bottom + 2;
            this.gpxGuarantors.Height = Convert.ToInt32(this.ClientSize.Height * 0.62);

            this.aimsComboLookup1.Top = gpxGuarantorSearch.Top + 10;
            this.aimsComboLookup1.Width = Convert.ToInt32((((this.ClientSize.Width) - 4) * 0.35));
            this.aimsComboLookup1.Height = Convert.ToInt32(gpxGuarantorSearch.Height * 0.80);
            this.aimsComboLookup1.lstItems.Height = Convert.ToInt32(gpxGuarantorSearch.Height * 0.58);

            this.pnlButtonSearch.Top = gpxGuarantorSearch.Height - 30;
            this.pnlButtonSearch.Height = 27;
            this.pnlButtonSearch.Left = aimsComboLookup1.Left;
            this.pnlButtonSearch.Width = aimsComboLookup1.Width - 10;

            this.btnDelete.Left = (pnlButtonSearch.Right - (btnDelete.Width + 10));
            this.btnAddNew.Left = aimsComboLookup1.Right - (btnAddNew.Width + 20);//Convert.ToInt32((pnlButtonSearch.Width * 0.5) - 30);
            this.btnSelect.Left = pnlButtonSearch.Left;

            this.tabGuarantors.Width = this.gpxGuarantors.Width - 20;
            this.tabGuarantors.Height = Convert.ToInt32(this.gpxGuarantors.Height * 0.92);

            this.pnlButtons.Top = this.gpxGuarantors.Bottom;
            this.pnlButtons.Left = gpxGuarantors.Left;

            this.btnSave.Left = Convert.ToInt32(pnlButtons.Left + 1);

            this.btnViewReports.Top = this.btnSave.Top;
            this.btnPaymentsLedger.Top = this.btnSave.Top;
            this.btnForexOverShortPymt.Top = this.btnSave.Top;

            this.btnOverPymtLedger.Top = this.btnSave.Top;
            this.btnShortPymtLedger.Top = this.btnSave.Top;

            this.btnViewReports.Left = this.btnSave.Left + this.btnSave.Width + 2;
            this.btnPaymentsLedger.Left = this.btnViewReports.Left + this.btnViewReports.Width + 1;
            this.btnForexOverShortPymt.Left = this.btnPaymentsLedger.Left + this.btnPaymentsLedger.Width + 1;

            this.btnOverPymtLedger.Left = this.btnForexOverShortPymt.Left + this.btnForexOverShortPymt.Width + 1;
            this.btnShortPymtLedger.Left = this.btnOverPymtLedger.Left + this.btnOverPymtLedger.Width + 2;

            this.btnDoctorOwingLedger.Top = this.btnShortPymtLedger.Top;
            this.btnDoctorOwingLedger.Left = this.btnShortPymtLedger.Left + this.btnShortPymtLedger.Width + 1;

            this.btnLateInvOverPymt.Top = this.btnDoctorOwingLedger.Top;
            this.btnLateInvOverPymt.Left = this.btnDoctorOwingLedger.Left + this.btnDoctorOwingLedger.Width + 1;
            
            this.btnClose.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);
            
            this.btnViewReports.Height = btnSave.Height;
            this.btnPaymentsLedger.Height = btnSave.Height;

            this.pnlButtons.Width = this.gpxGuarantors.Width;
            this.Left = this.tabGuarantors.Left + 10;

            btnRefresh.Left = btnSelect.Width + 20;
            this.btnRefresh.Top = btnSelect.Top;
            btnRefresh.Width = btnSelect.Width;

        }

        private void gpxGuarantorSearch_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LoadGuarantors()
        {            
            try
            {
                aimsComboLookup1.DataField1 = "GUARANTOR_NAME";
                aimsComboLookup1.DataField2 = "GUARANTOR_ID";
                aimsComboLookup1.OrderByField = "GUARANTOR_NAME";            
                aimsComboLookup1.TableName = "AIMS_GUARANTOR_VW";
                aimsComboLookup1.ItemsLoaded = 50;

                aimsComboLookup1.Initialise("");
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Guarantor list.", ex.Message);
            }
            
        }

        private void frmGuarantors_Load(object sender, EventArgs e)
        {
            try
            {
                ExportExcel();
                tabGuarantors.Enabled = false;
                commonFuncs = new AIMS.Common.CommonFunctions();

                LoadCountries();
                LoadAddressType();

                if (AddNewGuarantor)
                {                    
                    gpxGuarantors.Top = 0;
                    gpxGuarantors.Height = tabGuarantors.Height +30;
                    gpxGuarantorSearch.Visible = false;
                    btnAddNew.Visible = false;
                    btnRefresh.Visible = false;
                    btnSelect.Visible = false;
                    ClearControls();
                    gpxGuarantors.Enabled = true;
                    tabGuarantors.Enabled = true;
                    txtGuarantorName.Focus();                    
                    ResizeFormControls();
                    pnlButtons.Top = gpxGuarantors.Bottom;
                    btnSave.Enabled = true;
                    //this.Height = pnlButtons.Bottom;
                    //this.btnSave.Top = 0;
                }
                else
                {
                    LoadGuarantors();
                    btnSave.Enabled = UserAllowed("12");
                }

                btnViewReports.Enabled = UserAllowed("9");

                btnGuarantorLedger.Enabled = UserAllowed("10");
                btnPymtGuarantorLedger.Enabled = UserAllowed("10");
                btnAnalysisReport.Enabled = UserAllowed("39");
                btnAnalysisReportDrill.Enabled = UserAllowed("39");

                btnViewReports.Enabled = UserAllowed("9");
                btnPaymentsLedger.Enabled = UserAllowed("9");
                btnForexOverShortPymt.Enabled = UserAllowed("9");
                btnShortPymtLedger.Enabled = UserAllowed("9");
                btnOverPymtLedger.Enabled = UserAllowed("9");
                btnDoctorOwingLedger.Enabled = UserAllowed("9"); 
                
                
                btnAddNew.Enabled = UserAllowed("12");


                if (AddNewGuarantor)
                {
                    btnViewReports.Visible = false;
                    btnShortPymtLedger.Visible = false;
                    btnOverPymtLedger.Visible = false;
                    btnShortPymtLedger.Visible = false;
                    btnPymtGuarantorLedger.Visible = false;
                    btnGuarantorLedger.Visible = false;
                    btnViewReports.Visible = false;
                    btnForexOverShortPymt.Visible = false;
                    btnPaymentsLedger.Visible = false;
                    btnDoctorOwingLedger.Visible = false;
                }
                else
                {
                    btnViewReports.Visible = true;
                    btnShortPymtLedger.Visible = true;
                    btnOverPymtLedger.Visible = true;
                    btnShortPymtLedger.Visible = true;
                    btnPymtGuarantorLedger.Visible = true;
                    btnGuarantorLedger.Visible = true;
                    btnViewReports.Visible = true;
                    btnForexOverShortPymt.Visible = true;
                    btnPaymentsLedger.Visible = true;
                    btnDoctorOwingLedger.Visible = true;
                }

                
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Guarantors", ex.Message);
            }
        }

        private void LoadCountries()
        {
            try
            {
                DataTable dtCountries = new DataTable();
                dtCountries = commonFuncs.GetCountries();

                if (dtCountries.Rows.Count > 0)
                {
                    cboCountries.DataSource = dtCountries;
                    cboCountries.DisplayMember = "COUNTRY_NAME";
                    cboCountries.ValueMember = "COUNTRY_ID";
                }
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Guarantor list.");
            }
        }

        private void LoadAddressType()
        {
            try
            {
                DataTable dtAddressTypes = new DataTable();
                dtAddressTypes = commonFuncs.GetAddressTypes();

                if (dtAddressTypes.Rows.Count > 0)
                {
                    cboAddressType.DataSource = dtAddressTypes;
                    cboAddressType.DisplayMember = "ADDRESS_TYPE";
                    cboAddressType.ValueMember = "ADDR_TYPE_ID";
                }
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Guarantor list.");
            }
        }

        protected void aimsComboLookup1_DblClicked()
        {
            //Add code here to load Invoice details
            btnSelect_Click(null, null);
        }

        protected void aimsComboLookup2_DblClicked()
        {
            //Add code here to load Invoice details
            btnSelect_Click(null, null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (aimsComboLookup1.lstItems.SelectedIndex != -1)
                {
                    LoadGuarantorDetails();                
                    gpxGuarantors.Enabled = true; 
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select a guarantor from the list.");
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Guarantor Details Error, Please try again.", ex.Message);
            }

        }

        private void ClearControls()
        {
            lblGuarantorID.Text = "";
            txtGuarantorName.Text ="";
            txtGuarantorContactPerson.Text = "";
            txtAddr1.Text = "";
            txtAddr2.Text = "";
            txtAddr3.Text = "";
            txtAddr4.Text = "";
            txtAddressCity.Text = "";
            txtAddressPostalCode.Text = "";
            txtAddressProvince.Text = "";
            txtGuarantorContactPerson.Text = "";
            txtGuarantorEmailAddress.Text = "";
            txtGuarantorFaxNo.Text = "";
            txtGuarantorName.Text = "";
            txtGuarantorPhone.Text = "";
            cboCountries.SelectedIndex = 0;
            cboAddressType.SelectedIndex = 0;
            _guarantor = null;
        }

        private void LoadGuarantorDetails()
        {
            AIMS.BLL.Guarantor clsGuarantor = new  AIMS.BLL.Guarantor();
            try
            {
                ClearControls();
                _guarantor = clsGuarantor.GetGuarantorDetails(aimsComboLookup1.lstItems.SelectedValue.ToString());

                if (_guarantor != null)
                {
                    tabGuarantors.Enabled = true;
                    lblGuarantorID.Text = _guarantor.GuarantorID.ToString();
                    txtGuarantorName.Text = _guarantor.GuarantorName;
                    txtGuarantorContactPerson.Text = _guarantor.GuarantorContactPerson;
                    txtGuarantorEmailAddress.Text = _guarantor.GuarantorEmailAddress;
                    txtGuarantorFaxNo.Text = _guarantor.GuarantorFaxNo;
                    txtGuarantorPhone.Text = _guarantor.GuarantorPhoneNo;

                    Int64 GuarantorAddressID;
                    if (_guarantor.GuarantorAddressID > 0)
                    {
                        GuarantorAddressID = System.Convert.ToInt64(_guarantor.GuarantorAddressID);
                        using (DataTable dtGuarantorAddress = commonFuncs.GetAddressDetails(GuarantorAddressID))
                        {
                            txtAddr1.Text = dtGuarantorAddress.Rows[0]["Address1"].ToString();
                            txtAddr2.Text = dtGuarantorAddress.Rows[0]["ADDRESS2"].ToString();
                            txtAddr3.Text = dtGuarantorAddress.Rows[0]["ADDRESS3"].ToString();
                            txtAddr4.Text = dtGuarantorAddress.Rows[0]["ADDRESS4"].ToString();
                            txtAddressCity.Text = dtGuarantorAddress.Rows[0]["ADDRESS5"].ToString();
                            txtAddressPostalCode.Text = dtGuarantorAddress.Rows[0]["POSTAL_CODE"].ToString();
                            txtAddressProvince.Text = dtGuarantorAddress.Rows[0]["PROVINCE"].ToString();
                            if (dtGuarantorAddress.Rows[0]["COUNTRY_ID"] != null)
                            {
                                if (dtGuarantorAddress.Rows[0]["COUNTRY_ID"].ToString().Trim().Length > 0)
                                {
                                    if (System.Convert.ToInt32(dtGuarantorAddress.Rows[0]["COUNTRY_ID"]) > 0)
                                    {
                                        cboCountries.SelectedValue = dtGuarantorAddress.Rows[0]["COUNTRY_ID"];
                                    }
                                }
                                else
                                {
                                    cboCountries.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                cboCountries.SelectedIndex = 0;
                            }
                            cboAddressType.SelectedValue = dtGuarantorAddress.Rows[0]["ADDRESS_TYPE_ID"].ToString();
                        }
                    }
                }
                txtGuarantorName.Focus();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Guarantor Details");
                clsGuarantor = null;
            }
            finally
            {
                clsGuarantor = null;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                tabGuarantors.Enabled = true;
                txtGuarantorName.Focus();  
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Add new Guarantor error. Error - " + ex.Message);                                
            }          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Int64 LastPatient = 0;
            if (aimsComboLookup1.lstItems.SelectedIndex != null && aimsComboLookup1.lstItems.SelectedIndex > 0)
            {
                LastPatient = aimsComboLookup1.lstItems.SelectedIndex;
            }

            if (ValidateControls())
            {
                AIMS.BLL.Guarantor clsGuarantor = new AIMS.BLL.Guarantor();
                bool bSaved = false;
                try
                {
                    clsGuarantor.GuarantorName = txtGuarantorName.Text.Trim();
                    if (lblGuarantorID.Text.Trim().Length > 0)
                    {
                        clsGuarantor.GuarantorID = System.Convert.ToInt32(lblGuarantorID.Text);
                    }
                    else
                    {                        
                        DataTable dtGuarantorCheck = clsGuarantor.VerifyGuarantor();
                        if (dtGuarantorCheck.Rows.Count > 0 )
                        {
                            dtGuarantorCheck.Dispose();
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning , "This Guarantor already exist.");
                            return;
                        }
                    }

                    clsGuarantor.GuarantorActiveYN = "Y";
                    clsGuarantor.GuarantorAddr1 = txtAddr1.Text.Trim();
                    clsGuarantor.GuarantorAddr2 = txtAddr2.Text.Trim();
                    clsGuarantor.GuarantorAddr3 = txtAddr3.Text.Trim();
                    clsGuarantor.GuarantorAddr4 = txtAddr4.Text.Trim();
                    clsGuarantor.GuarantorAddrCity = txtAddressCity.Text.Trim();
                    clsGuarantor.GuarantorAddressTypeID = System.Convert.ToInt32(cboAddressType.SelectedValue);
                    clsGuarantor.GuarantorAddrPostalCode = txtAddressPostalCode.Text.Trim();
                    clsGuarantor.GuarantorCountryID = System.Convert.ToInt32(cboCountries.SelectedValue);
                    clsGuarantor.GuarantorEmailAddress = txtGuarantorEmailAddress.Text.Trim();
                    clsGuarantor.GuarantorFaxNo = txtGuarantorFaxNo.Text.Trim();
                    clsGuarantor.GuarantorContactPerson = txtGuarantorContactPerson.Text.Trim();

                    
                    clsGuarantor.GuarantorPhoneNo = txtGuarantorPhone.Text.Trim();
                    clsGuarantor.GuarantorProvince = txtAddressProvince.Text.Trim();

                    clsGuarantor.LoggedOnUser = UserID;

                    bSaved = clsGuarantor.SaveGuarantorDetails();

                    if (bSaved)
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Guarantor added/updated successfully.");
                        if (AddNewGuarantor)
                        {
                            this.Close();
                        }
                        LoadGuarantors();
                        if (LastPatient >0)
                        {
                            aimsComboLookup1.lstItems.SelectedIndex = (int)LastPatient;
                        }                        
                    }
                    else
                    {   
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning , "Guarantor NOT added/updated successfully.");
                    }
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Guarantor NOT added/updated successfully.");
                }
                finally
                {
                    clsGuarantor = null;
                }                
            }
        }

        public bool ValidateControls()
        {
            bool returnVal = true;

            errProv.Clear();

            if (this.txtGuarantorName.Text.Trim().Length == 0)
            {
                errProv.SetError(txtGuarantorName, "Please enter Guarantor Name");
                txtGuarantorName.Focus();
                returnVal = false;
            }

            if (txtGuarantorEmailAddress.Text.Trim().Length > 0)
            {
                if (!ValidEmailAddress(txtGuarantorEmailAddress.Text.Trim()))
                {
                    errProv.SetError(txtGuarantorEmailAddress, "Please enter valid email address");
                    txtGuarantorEmailAddress.Focus();
                    returnVal = false;
                    return returnVal;
                }
            }

            if (returnVal == true)
            {
                errProv.Clear();
            }
            return returnVal;
        }
            
        private void btnViewReports_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;
            
            GuarantorID = 0;
            frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report");
            frmRep.LedgerType = "BALANCES";
            commonFuncs = new AIMS.Common.CommonFunctions();

            frmRep.StartDate = startDt;
            frmRep.EndDate = endDt;
            frmRep.AgeAnalysisPeriod = ageAnalysis;

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.UserSignedOn = UserID;
                frmRep.Guarantor = "";
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void btnGuarantorLedger_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;

            using (frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report"))
            {
                frmRep.LedgerType = "BALANCES";
                commonFuncs = new AIMS.Common.CommonFunctions();
                if (lblGuarantorID.Text.ToString().Length > 0)
                {
                    frmRep.GuarantorID = System.Convert.ToInt32(lblGuarantorID.Text);
                }
                frmRep.StartDate = startDt;
                frmRep.EndDate = endDt;
                frmRep.AgeAnalysisPeriod = ageAnalysis;

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);
                StringBuilder sbHTML = new StringBuilder();
                DataTable tbl = new DataTable("HTMLPages");
                DataSet ds = new DataSet();
                try
                {
                    frmRep.UserSignedOn = UserID;
                    frmRep.Guarantor = txtGuarantorName.Text;
                    frmRep.ShowDialog();
                }
                catch (Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
                }
            }
        }

        private bool UserAllowed(string RestrictionID)
        {
            //RESTRICTION_ID       RESTRICTION_DESC                                   
            //-------------------- -------------------------------------------------- 
            //1                    Unlock Invoice
            //2                    Add Invoice
            //3                    Add Payment
            //5                    Add Patient File
            //6                    Close Patient File
            //7                    Unlock Patient File
            //9                    View AIMS Ledger
            //10                   View Guarantor Ledger
            //11                   Add Supplier
            //12                   Add Guarantor
            //13                   View Reports
            //17                   View Payments
            //18                   View Suppliers
            //19                   View Guarantors
            //20                   View Patients Files
            //21                   View User Maintenance
            //22                   View Invoices

            bool bAllowedFunction = false;
            if (Restrictions.Trim().Length > 0)
            {
                string[] arrPermissions = Restrictions.Split(new Char[] { ',' });

                foreach (string Permission in arrPermissions)
                {
                    if (Permission.Trim() != "" && Permission == RestrictionID)
                    {
                        bAllowedFunction = true;
                        break;
                    }
                }
            }
            return bAllowedFunction;
        }

        public static bool ValidEmailAddress(string emailAddress)
        {
            //create Regular Expression Match pattern object
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$");
            //boolean variable to hold the status
            bool isValid = false;
            if (string.IsNullOrEmpty(emailAddress.ToLower()))
            {
                isValid = false;
            }
            else
            {
                isValid = myRegex.IsMatch(emailAddress.ToLower());
            }
            //return the results
            return isValid;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                LoadGuarantors();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Refreshing AIMS Recorder Failed, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Invoices form refreshing failed, Error - " + e.ToString());
            }
        }

        private void btnPymtGuarantorLedger_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;

            frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report");
            frmRep.LedgerType = "PAYMENTS";

            commonFuncs = new AIMS.Common.CommonFunctions();

            if (lblGuarantorID.Text.ToString().Length > 0)
            {
                frmRep.GuarantorID = System.Convert.ToInt32(lblGuarantorID.Text);
            }

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);
            frmRep.StartDate = startDt;
            frmRep.EndDate = endDt;
            frmRep.AgeAnalysisPeriod = ageAnalysis;
            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.UserSignedOn = UserID;
                frmRep.Guarantor = txtGuarantorName.Text;
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void btnPaymentsLedger_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;

            GuarantorID = 0;
            frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report");
            frmRep.LedgerType = "PAYMENTS";
            commonFuncs = new AIMS.Common.CommonFunctions();

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);
            frmRep.StartDate = startDt;
            frmRep.EndDate = endDt;
            frmRep.AgeAnalysisPeriod = ageAnalysis;
            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.UserSignedOn = UserID;
                frmRep.Guarantor = "";
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void btnForexOverShortPymt_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;

            GuarantorID = 0;
            frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report");
            frmRep.LedgerType = "FOREX";
            frmRep.Forex = "Y";
            frmRep.InsuranceShortPayment  = "N";
            frmRep.InsuranceOverPayment  = "N";
            frmRep.Forex = "Y";
            frmRep.DoctorOwing = "N";
            frmRep.LateInvoiceYN = "N";
            
            frmRep.StartDate = startDt;
            frmRep.EndDate = endDt;
            frmRep.AgeAnalysisPeriod = ageAnalysis;
            
            commonFuncs = new AIMS.Common.CommonFunctions();

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.UserSignedOn = UserID;
                frmRep.Guarantor = "";
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void btnShortPymtLedger_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;

            GuarantorID = 0;
            frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report");
            frmRep.LedgerType = "FOREX";
            frmRep.Forex = "N";
            frmRep.InsuranceShortPayment = "Y";
            frmRep.InsuranceOverPayment = "N";
            frmRep.DoctorOwing = "N";
            frmRep.LateInvoiceYN = "N";
            frmRep.LateInvoiceYN = "N";
            frmRep.StartDate = startDt;
            frmRep.EndDate = endDt;
            frmRep.AgeAnalysisPeriod = ageAnalysis;
            commonFuncs = new AIMS.Common.CommonFunctions();

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.UserSignedOn = UserID;
                frmRep.Guarantor = txtGuarantorName.Text;
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }  
        }

        private void btnOverPymtLedger_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;

            GuarantorID = 0;
            frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report");
            frmRep.LedgerType = "FOREX";
            frmRep.Forex = "N";
            frmRep.InsuranceShortPayment = "N";
            frmRep.InsuranceOverPayment = "Y";
            frmRep.DoctorOwing = "N";
            frmRep.LateInvoiceYN = "N";
            frmRep.StartDate = startDt;
            frmRep.EndDate = endDt;
            frmRep.AgeAnalysisPeriod = ageAnalysis;
            commonFuncs = new AIMS.Common.CommonFunctions();

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.UserSignedOn = UserID;
                frmRep.Guarantor = "";
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void cboCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = "";
            AIMS.BLL.Invoice _invoiceNew = new AIMS.BLL.Invoice();
            try
            {
                if (cboCountries.SelectedItem != null && cboCountries.Text == "<Add New Country>")
                {
                    if (InputBox("New Country", "", ref value) == DialogResult.OK)
                    {
                        if (value.Trim().Length > 0)
                        {
                            bool bSaved = false;

                            AIMS.BLL.Invoice clsInvoice = new AIMS.BLL.Invoice();

                            DataTable dtCountryCheck = _invoiceNew.CheckIfCountryExist(value.Trim());

                            if (dtCountryCheck.Rows.Count > 0)
                            {
                                MessageBox.Show("Country already exists", "Country Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cboCountries.SelectedIndex = -1;
                            }
                            else
                            {
                                bSaved = _invoiceNew.SaveNewCountry(value.Trim(), UserID);
                                if (bSaved)
                                {
                                    DataTable dtCountries = new DataTable();
                                    dtCountries = commonFuncs.GetCountries();

                                    if (dtCountries.Rows.Count > 0)
                                    {
                                        cboCountries.DataSource = dtCountries;
                                        cboCountries.DisplayMember = "COUNTRY_NAME";
                                        cboCountries.ValueMember = "COUNTRY_ID";
                                        cboCountries.SelectedIndex = -1;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Country addition failed", "Service Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            cboCountries.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        cboCountries.SelectedIndex = -1;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                _invoiceNew = null;
            }
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            try
            {
                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label.Text = promptText;
                textBox.Text = value;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label.SetBounds(9, 20, 372, 13);
                textBox.SetBounds(12, 36, 399, 20);
                buttonOk.SetBounds(228, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label.AutoSize = true;
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(420, 107);
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value = textBox.Text;
                return dialogResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnDoctorOwingLedger_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;

            GuarantorID = 0;
            frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report");
            frmRep.LedgerType = "FOREX";
            frmRep.Forex = "N";
            frmRep.InsuranceShortPayment = "N";
            frmRep.InsuranceOverPayment = "N";
            frmRep.LateInvoiceYN = "N";
            frmRep.DoctorOwing = "Y";
            frmRep.StartDate = startDt;
            frmRep.EndDate = endDt;
            frmRep.AgeAnalysisPeriod = ageAnalysis;
            commonFuncs = new AIMS.Common.CommonFunctions();

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.UserSignedOn = UserID;
                frmRep.Guarantor = "";
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }  
        }

        private void ResizeFormControls() 
        {
            txtGuarantorName.Enabled = true;
            txtGuarantorContactPerson.Enabled = UserAllowed("12"); ;
            txtAddr1.Enabled = UserAllowed("12"); ;
            txtAddr2.Enabled = UserAllowed("12"); ;
            txtAddr3.Enabled = UserAllowed("12"); ;
            txtAddr4.Enabled = UserAllowed("12"); ;
            txtAddressCity.Enabled = UserAllowed("12"); ;
            txtAddressPostalCode.Enabled = UserAllowed("12"); ;
            txtAddressProvince.Enabled = UserAllowed("12"); ;
            txtGuarantorContactPerson.Enabled = UserAllowed("12"); ;
            txtGuarantorEmailAddress.Enabled = UserAllowed("12"); ;
            txtGuarantorFaxNo.Enabled = UserAllowed("12"); ;

            txtGuarantorPhone.Enabled = UserAllowed("12"); ;
            cboCountries.Enabled = UserAllowed("12"); ;
            cboAddressType.Enabled = UserAllowed("12"); ;        
        }

        private void btnLateInvOverPymt_Click(object sender, EventArgs e)
        {
            string startDt = "";
            string endDt = "";
            string ageAnalysis = "";
            GetLedgerSearchCriteria(ref startDt, ref endDt, ref ageAnalysis);
            if (startDt.Trim().Length == 0 || endDt.Trim().Length == 0)
                return;

            GuarantorID = 0;
            using (frmReportViewer frmRep = new frmReportViewer("AIMS Ledger Report", "AIMS Ledger Report"))
            {
                frmRep.LedgerType = "FOREX";
                frmRep.Forex = "N";
                frmRep.InsuranceShortPayment = "N";
                frmRep.InsuranceOverPayment = "Y";
                frmRep.LateInvoiceYN = "Y";
                frmRep.DoctorOwing = "N";
                frmRep.StartDate = startDt;
                frmRep.EndDate = endDt;
                frmRep.AgeAnalysisPeriod = ageAnalysis;
                commonFuncs = new AIMS.Common.CommonFunctions();
                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);
                try
                {
                    frmRep.UserSignedOn = UserID;
                    frmRep.Guarantor = "";
                    frmRep.ShowDialog();
                }
                catch (Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
                }
            }
        }

        private void btnAnalysisReport_Click(object sender, EventArgs e)
        {
            string sStartDate = "";
            string sEndDate = "";

            DateRangeInputBox("Patient Admission Date-Range", "Start Date(yyyy/mm/dd)", ref sStartDate, "End Date(yyyy/mm/dd)", ref sEndDate);

            if (!sStartDate.Trim().Equals("") && !sEndDate.Trim().Equals(""))
            {
                DateTime dtStartDate;
                DateTime dtEndDate;
                if (!DateTime.TryParse(sStartDate, out dtStartDate))
                {
                    MessageBox.Show("Patient Admission Start-Date Invalid, Please re-capture", "Start Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!DateTime.TryParse(sEndDate, out dtEndDate))
                {
                    MessageBox.Show("Patient Admission End-Date Invalid, Please re-capture", "End Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                frmReportViewer frmRep = new frmReportViewer("Guarantor Analysis", "Guarantor Analysis");
                commonFuncs = new AIMS.Common.CommonFunctions();

                if (lblGuarantorID.Text.ToString().Length > 0){
                    frmRep.GuarantorID = System.Convert.ToInt32(lblGuarantorID.Text);
                    frmRep.Guarantor = aimsComboLookup1.lstItems.Text;
                    frmRep.ReportStartDate = sStartDate;
                    frmRep.ReportEndDate = sEndDate;
                }

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                StringBuilder sbHTML = new StringBuilder();
                DataTable tbl = new DataTable("HTMLPages");
                DataSet ds = new DataSet();

                try
                {
                    frmRep.UserSignedOn = UserID;
                    frmRep.Guarantor = txtGuarantorName.Text;
                    frmRep.ShowDialog();
                }
                catch (Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
                }   
            }
        }

        public static DialogResult DateRangeInputBox(string title, string promptText1, ref string value1, string promptText2, ref string value2)
        {
            try
            {
                Form form = new Form();
                Label label1 = new Label();
                Label label2 = new Label();

                TextBox textBox1 = new TextBox();
                TextBox textBox2 = new TextBox();
                
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label1.Text = promptText1;
                label2.Text = promptText2;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label1.SetBounds(9, 20, 372, 13);
                label2.SetBounds(9, 65, 372, 13);

                textBox1.SetBounds(10, 36, 367, 20);
                textBox2.SetBounds(10, 80, 250, 20);

                buttonOk.SetBounds(200, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label1.AutoSize = true;
                label2.AutoSize = true;
                textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;

                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonOk.Top = textBox2.Bottom + 10;
                buttonCancel.Top = textBox2.Bottom + 10;

                form.ClientSize = new Size(420, 150);
                form.Controls.AddRange(new Control[] { label1, label2, textBox1, textBox2, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value1 = textBox1.Text.Trim();
                value2 = textBox2.Text.Trim();

                return dialogResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAnalysisReportDrill_Click(object sender, EventArgs e)
        {
            string sStartDate = "";
            string sEndDate = "";

            DateRangeInputBox("Patient Admission Date-Range", "Start Date(yyyy/mm/dd)", ref sStartDate, "End Date(yyyy/mm/dd)", ref sEndDate);

            if (!sStartDate.Trim().Equals("") && !sEndDate.Trim().Equals(""))
            {
                DateTime dtStartDate;
                DateTime dtEndDate;
                if (!DateTime.TryParse(sStartDate, out dtStartDate))
                {
                    MessageBox.Show("Patient Admission Start-Date Invalid, Please re-capture", "Start Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!DateTime.TryParse(sEndDate, out dtEndDate))
                {
                    MessageBox.Show("Patient Admission End-Date Invalid, Please re-capture", "End Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmReportViewer frmRep = new frmReportViewer("Analysis Drilldown - Guarantor", "Analysis Drilldown - Guarantor");
                commonFuncs = new AIMS.Common.CommonFunctions();

                if (lblGuarantorID.Text.ToString().Length > 0)
                {
                    frmRep.GuarantorID = System.Convert.ToInt32(lblGuarantorID.Text);
                    frmRep.Guarantor = aimsComboLookup1.lstItems.Text;
                    frmRep.ReportStartDate = sStartDate;
                    frmRep.ReportEndDate = sEndDate;
                }

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                StringBuilder sbHTML = new StringBuilder();
                DataTable tbl = new DataTable("HTMLPages");
                DataSet ds = new DataSet();

                try
                {
                    frmRep.UserSignedOn = UserID;
                    frmRep.Guarantor = txtGuarantorName.Text;
                    frmRep.ShowDialog();
                }
                catch (Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
                }
            }
        }

        private void btnAnnualFiles_Click(object sender, EventArgs e)
        {
            try
            {
                string sStartDate = "";
                string sEndDate = "";

                DateRangeInputBox("Guarantor Files Date-Range", "Start Date(yyyy/mm/dd)", ref sStartDate, "End Date(yyyy/mm/dd)", ref sEndDate);

                if (!sStartDate.Trim().Equals("") && !sEndDate.Trim().Equals(""))
                {
                    DateTime dtStartDate;
                    DateTime dtEndDate;
                    if (!DateTime.TryParse(sStartDate, out dtStartDate))
                    {
                        MessageBox.Show("Guarantor File Creation Start-Date Invalid, Please re-capture", "Start Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!DateTime.TryParse(sEndDate, out dtEndDate))
                    {
                        MessageBox.Show("Guarantor File Creation End-Date Invalid, Please re-capture", "End Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    GenerateFilesOpenedForGuarantor(sStartDate, sEndDate, "Y", "Y");

                    //Word.Application app = new Word.Application();

                    //app.Visible = false;

                    //Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);

                }
            }
            catch (System.Exception ex)
            {
                
            }
        }

        public void GenerateFilesOpenedForGuarantor(string sStartDate, string sEndDate, string IncludeCancelledFiles, string InOutPatientSplit)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            string SQLString = "";
            string sEmailBody = "";
            bool blResult = false;
            OleDbCommand cmdDrillReport = new OleDbCommand();
            OleDbDataAdapter oleDrillDBAdaptor;
            DataTable dtDrillReportData = new DataTable();
            Int32 FilesCount = 0;
            
            string PatientStatus = "";
            bool FirstTime = true;
            Int32 InPatientCounter = 0;
            Int32 OutPatientCounter = 0;
            Int32 OutInPatientCounter = 0;

            string DrillReportEmailSubject = "Guarantor Files: " + sStartDate + " - " + sEndDate;
            string PreviousGuarantor = "";
            OleDbConnection oleDBConnection = new OleDbConnection();
            
            try
            {
                sEmailBody = "<html> " +
                                "<head>" +
                                "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left}</style>" +
                                "</head>" +
                                "<body>" +
                                "<br>" +
                                "<br>" +
                                "<table width=100% cellpadding=2 cellspacing=1 align=center style=border-style:solid>" +
                                "<tr>" +
                                "<td bgcolor=lightgrey align=right colspan=8>" +
                                "<center><font color=5CACEE face=calibri size=4><b>Guarantor Files: " + sStartDate + " - " + sEndDate + "</b>" +
                                "</td>" +
                                "</tr>" +
                                "<tr>" +
                                "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=8>&nbsp;</td>" +
                                "</tr>";

                SQLString = "SELECT   COUNT (patient_file_no) counter, b.guarantor_name,  " +
                         " CASE a.out_patient " +
                         " WHEN 'Y' THEN 'OUT-PATIENT' " +
                         " END PATIENT_STATUS, " +
                         " '' A,'' B " +
                    " FROM aims_patient a INNER JOIN aims_guarantor b " +
                         " ON b.guarantor_id = a.guarantor_id " +
                   " WHERE a.cancelled = 'N' and out_patient = 'Y' and IN_PATIENT = 'N' " +
                     " AND convert(datetime,a.creation_dttm, 103) >= '" + sStartDate + "'  " +
                     " and convert(datetime,a.creation_dttm, 103) <= '" + sEndDate + "'  " +
                     " AND (   b.guarantor_name IS NOT NULL " +
                          " OR b.guarantor_name <> '' " +
                          " OR b.guarantor_name <> ' ' " +
                         " )         " +
                " GROUP BY a.guarantor_id, guarantor_name, a.out_patient,IN_PATIENT " +
                " UNION " +
                " SELECT   COUNT (patient_file_no) counter, b.guarantor_name,  " +
                         " case a.in_patient  " +
                         " WHEN 'Y' THEN 'IN-PATIENT' " +
                         " END PATIENT_STATUS, " +
                         " '' A,'' B " +
                    " FROM aims_patient a INNER JOIN aims_guarantor b " +
                         " ON b.guarantor_id = a.guarantor_id " +
                   " WHERE a.cancelled = 'N' and in_patient  = 'Y' and OUT_PATIENT = 'N' " +
                     " AND convert(datetime,a.creation_dttm, 103) >= '" + sStartDate + "'  " +
                     " and convert(datetime,a.creation_dttm, 103) <= '" + sEndDate + "'  " +
                     " AND (   b.guarantor_name IS NOT NULL " +
                          " OR b.guarantor_name <> '' " +
                          " OR b.guarantor_name <> ' ' " +
                         " ) " +
                " GROUP BY a.guarantor_id, guarantor_name, a.in_patient, a.OUT_PATIENT " +
                " union " +
                " SELECT   COUNT (patient_file_no) counter,  " +
                    " b.guarantor_name,  " +
                          " '' PATIENT_STATUS, " +
                         " '' A,'' B " +
                    " FROM aims_patient a INNER JOIN aims_guarantor b " +
                         " ON b.guarantor_id = a.guarantor_id " +
                   " WHERE a.cancelled = 'N' and ((in_patient  = 'N' or in_patient  = '' or in_patient = null) and ( out_patient = 'N' or out_patient = '' or out_patient = null)) " +
                     " AND convert(datetime,a.creation_dttm, 103) >= '" + sStartDate + "'  " +
                     " and convert(datetime,a.creation_dttm, 103) <= '" + sEndDate + "'  " +
                          " AND (   b.guarantor_name IS NOT NULL " +
                          " OR b.guarantor_name <> '' " +
                          " OR b.guarantor_name <> ' ' " +
                         " ) " +
                " GROUP BY a.guarantor_id, guarantor_name " +
                " ORDER BY 2,3";

                OpenDBConnection(ref oleDBConnection);
                cmdDrillReport.Connection = oleDBConnection;
                cmdDrillReport.CommandText = SQLString;
                cmdDrillReport.CommandType = CommandType.Text;
                oleDrillDBAdaptor = new OleDbDataAdapter(cmdDrillReport);
                oleDrillDBAdaptor.Fill(dtDrillReportData);

                if (dtDrillReportData.Rows.Count > 0)
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b></b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=80%><b>Guarantor</b></td>" +
                               "<td bgcolor=lightgrey valign=bottom align=center width=10%><b>Patient Status</b></td>" +
                                "</tr>";

                    for (int i = 0; i < dtDrillReportData.Rows.Count; i++)
                    {
                        PatientStatus = dtDrillReportData.Rows[i]["PATIENT_STATUS"].ToString();

                        FilesCount += System.Convert.ToInt32(dtDrillReportData.Rows[i]["COUNTER"]);
                        if (PreviousGuarantor != dtDrillReportData.Rows[i]["guarantor_name"].ToString())
                        {
                            PreviousGuarantor = dtDrillReportData.Rows[i]["guarantor_name"].ToString();
                            if (!FirstTime)
                            {
                                sEmailBody += "<tr>" +
                                           "<td bgcolor=lightgrey valign=bottom align=center colspan=8>&nbsp;</td>" +
                                            "</tr>";
                            }
                            FirstTime = false;
                        }

                        sEmailBody += "<tr>" +
                        "<td valign=bottom bgcolor=#ffffff style=TEXT-TRANSFORM: capitalize align=right width=10%>" + dtDrillReportData.Rows[i]["COUNTER"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=80%>" + dtDrillReportData.Rows[i]["guarantor_name"].ToString() + "</td>" +
                        "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=10%><b>" + dtDrillReportData.Rows[i]["PATIENT_STATUS"].ToString() + "</b></td>" +
                        "</tr>";

                        switch (PatientStatus)
                        {
                            case "IN-PATIENT":
                                InPatientCounter += System.Convert.ToInt32(dtDrillReportData.Rows[i]["COUNTER"]);
                                break;
                            case "OUT-PATIENT":
                                OutPatientCounter += System.Convert.ToInt32(dtDrillReportData.Rows[i]["COUNTER"]);
                                break;
                            case "":
                                OutInPatientCounter += System.Convert.ToInt32(dtDrillReportData.Rows[i]["COUNTER"]);
                                break;
                        }
                    }
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8>&nbsp;</td>" +
                                "</tr>";

                    sEmailBody += "<tr>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=right width=10%><b>Out-Patient</b></td>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=10%><font color=red>" + OutPatientCounter + "</font></td>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=80%></td>";

                    sEmailBody += "<tr>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=right width=10%><b>In-Patient</b></td>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=10%><font color=red>" + InPatientCounter.ToString() + "</font></td>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=80%></td>";

                    sEmailBody += "<tr>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=right width=10%><b>Day-To-Day</b></td>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=10%><font color=red>" + OutInPatientCounter.ToString() + "</font></td>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=80%></td>";

                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8>&nbsp;</td>" +
                                "</tr>";

                    sEmailBody += "<tr>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=right width=10%><b>Total</b></td>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=10%><b><font color=red>" + FilesCount.ToString() + "</font></b></td>" +
                    "<td valign=bottom bgcolor=#B0C4DE style=TEXT-TRANSFORM: capitalize align=left width=80%></td>" +
                    "</tr>";

                }
                else
                {
                    sEmailBody += "<tr>" +
                               "<td bgcolor=lightgrey valign=bottom align=center colspan=8><b>No Files Opened Between " + sStartDate + " AND " + sEndDate + "</b></td>" +
                                "</tr>";
                }
                sEmailBody += "</table>" +
                 "<br>" +
                "<br>" +
                "</body>" +
                "</html>";

                string EmailAttachFile = "";
                CreateEmailDocumentAttachment(sEmailBody, ref EmailAttachFile, sStartDate , sEndDate);
                commonFuncs = new AIMS.Common.CommonFunctions();

                blResult = commonFuncs.SendEmail(sEmailBody, "admin@aims.co.za", "AIMS Reporting Services", DrillReportEmailSubject, "debbie@aims.org.za", EmailAttachFile);
                if (!blResult)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Guarantor Reporting Email could not be sent, Please contact System Administrator.");
                }
            }
            catch (System.Exception ex)
            {
                blResult = false;
            }
            finally
            {
                CloseDBConnections(oleDBConnection);
                cmdDrillReport.Dispose();
                dtDrillReportData.Dispose();
                
            }
        }
        #region "Database Methods"
        public bool OpenDBConnection(ref OleDbConnection oleDBConnection)
        {
            bool DBConnected = false;
            try
            {
                string DBConnectString = System.Configuration.ConfigurationSettings.AppSettings["ReportsConnectString"];

                oleDBConnection = new OleDbConnection();
                oleDBConnection.ConnectionString = DBConnectString;
                oleDBConnection.Open();
                DBConnected = true;
            }
            catch (System.Exception ex)
            {
                
                if (oleDBConnection != null && oleDBConnection.State == ConnectionState.Open)
                {
                    DBConnected = true;
                }
                else
                {
                    DBConnected = false;
                }
            }
            return DBConnected;
        }

        public void CloseDBConnections(OleDbConnection oleDBConnection)
        {
            try
            {
                if (oleDBConnection != null && oleDBConnection.State == ConnectionState.Open)
                {
                    oleDBConnection.Close();
                    oleDBConnection.Dispose();
                }
            }
            catch (System.Exception ex)
            {
                
            }
        }
        #endregion

        private void CreateEmailDocumentAttachment(string DocumentContents, ref string EmailAttachmentDocument, string sStartDate, string sEndDate)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            Word.Application app = new Word.Application();
            Word._Document doc1 = null; ;

            object Obj1Format = Missing.Value;
            object Obj1Route = Missing.Value;
            object obj1SaveChanges = Missing.Value;

            try
            {
                object ContentFileName = "c:\\Guarantor_Stats_" + sStartDate.Replace("/", "-") + " - " + sEndDate.Replace("/", "-") + ".html";
                string ReportContentFile = "c:\\Guarantor_Stats_" + sStartDate.Replace("/", "-") + " - " + sEndDate.Replace("/", "-") + ".html";

                if (File.Exists(ReportContentFile))
                {
                    File.SetAttributes(ReportContentFile, FileAttributes.Normal);
                    File.Delete(ReportContentFile);
                }
                CreateEmailDocument(ReportContentFile, DocumentContents);

                if (File.Exists(ReportContentFile))
                {
                    app.Visible = false;

                    object template = Missing.Value;
                    object newTemplate = Missing.Value;
                    object docNoEncodingDialog = Missing.Value;
                    object XMLTransForm = Missing.Value;
                    object DocumentDirection = Missing.Value;
                    object OpenandRepair = Missing.Value;
                    object DocEncoding = Missing.Value;
                    object Format = Missing.Value;
                    object WritePasswordTemplate = Missing.Value;
                    object WritePasswordDocument = Missing.Value;
                    object Revert = Missing.Value;
                    object PasswordTemplate = Missing.Value;
                    object PasswordDocument = Missing.Value;
                    object AddToRecentFiles = Missing.Value;
                    object ReadOnly = true;
                    object visible = true;
                    object ConfirmConvertion = false;

                    doc1 = app.Documents.Open(ref ContentFileName, ref ConfirmConvertion, ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument,
                        ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref DocEncoding,
                        ref visible, ref OpenandRepair, ref DocumentDirection, ref docNoEncodingDialog, ref XMLTransForm);

                    object SaveFileName = "c:\\AIMS Recorder\\Guarantor_Stats_" + sStartDate.Replace("/", "-") + " - " + sEndDate.Replace("/", "-") + ".doc";
                    EmailAttachmentDocument = "c:\\AIMS Recorder\\Guarantor_Stats_" + sStartDate.Replace("/", "-") + " - " + sEndDate.Replace("/", "-") + ".doc";

                    object SaveFileFormat = Missing.Value;
                    object SaveLockComments = Missing.Value;
                    object SavePassword = Missing.Value;
                    object SaveAddToRecentFiles = Missing.Value;
                    object SaveReadOnlyRecommened = Missing.Value;
                    object SaveEmbeddedTrueTypeFonts = Missing.Value;
                    object SaveWritePassword = Missing.Value;
                    object SaveNativePictureFormat = Missing.Value;
                    object SaveFormsdata = Missing.Value;
                    object SaveAsOCELetter = Missing.Value;
                    object SaveEncoding = Missing.Value;
                    object SaveInsertLineBreaks = Missing.Value;

                    object SaveAllowSubstitution = Missing.Value;

                    object SaveLineEnding = Missing.Value;
                    object SaveBiDiMarks = Missing.Value;
                    object SaveCompatibilityMode = Missing.Value;

                    doc1.SaveAs2(ref SaveFileName, ref SaveFileFormat, ref SaveLockComments, ref SavePassword, ref SaveAddToRecentFiles, ref SaveWritePassword,
                    ref SaveReadOnlyRecommened, ref SaveEmbeddedTrueTypeFonts, ref SaveNativePictureFormat, ref SaveFormsdata, ref SaveAsOCELetter,
                    ref SaveEncoding, ref SaveInsertLineBreaks, ref SaveAllowSubstitution, ref SaveLineEnding, ref SaveBiDiMarks, ref SaveCompatibilityMode);
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error generating Report Output File, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Error generating Report Output File: " + ex.ToString());
            }
            finally 
            {
                commonFuncs = null;
                app = null;

                doc1.Close(ref obj1SaveChanges, ref Obj1Format, ref Obj1Route);
            }
        }

        private bool CreateEmailDocument(string ReportFileName, string ReportContent)
        {
            string fLogName = @ReportFileName;
            bool bSaved = false;
            try
            {
                StreamWriter sw;
                sw = File.CreateText(fLogName.Replace("/", "-"));
                sw.WriteLine(ReportContent);
                sw.Flush();
                sw.Close();
                bSaved = true;
            }
            finally
            {
            }
            return bSaved;
        }

        public static DialogResult GuarantorLegderInputBox(string title, string promptText1, string promptText2,string promptText3, ref string value1, ref string value2, ref string value3)
        {
            try
            {
                Form form = new Form();

                Label label1 = new Label();
                Label label2 = new Label();
                Label label3 = new Label();
                TextBox textBox1 = new TextBox();
                TextBox textBox2 = new TextBox();
                ComboBox cboAgeAnalysis = new ComboBox();
                
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label1.Text = promptText1;
                label2.Text = promptText2;
                label3.Text = promptText3;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label1.SetBounds(9, 20, 372, 13);
                textBox1.SetBounds(10, 36, 399, 20);

                label2.SetBounds(9, 68, 372, 13);
                textBox2.SetBounds(10, 82, 399, 20);

                label3.SetBounds(9, 112, 372, 13);
                cboAgeAnalysis.SetBounds(10, 128, 399, 20);
                
                buttonOk.SetBounds(210, 90, 75, 23);
                buttonCancel.SetBounds(319, 90, 75, 23);

                label1.AutoSize = true;
                textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;

                label2.AutoSize = true;
                textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;

                label3.AutoSize = true;
                cboAgeAnalysis.Anchor = cboAgeAnalysis.Anchor | AnchorStyles.Right;

                cboAgeAnalysis.Items.Add(" ");
                cboAgeAnalysis.Items.Add("30");
                cboAgeAnalysis.Items.Add("60");
                cboAgeAnalysis.Items.Add("90");
                cboAgeAnalysis.Items.Add("120");
                cboAgeAnalysis.DropDownStyle = ComboBoxStyle.DropDownList;

                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonOk.Top = cboAgeAnalysis.Bottom + 10;
                buttonCancel.Top = cboAgeAnalysis.Bottom + 10;

                form.ClientSize = new Size(420, 200);
                form.Controls.AddRange(new Control[] { label1, label2, label3, textBox1, textBox2, cboAgeAnalysis, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value1 = textBox1.Text;
                value2 = textBox2.Text;
                value3 = cboAgeAnalysis.Text;
                if (dialogResult == DialogResult.Cancel)
                {
                    value1 = "";
                    value2 = "";
                    value3 = "";
                }
                return dialogResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GetLedgerSearchCriteria(ref string LedgerStartDate, ref string LedgerEndDate, ref string AgeAnalysis)
        {
            try
            {
                string NewPatientFileNo = "";
                string startDate = "";
                string endDate = "";
                string ageAnalysis = "";

                DialogResult dgResult =  GuarantorLegderInputBox("Ledger Criteria", "Start-Date (dd/mm/yyyy)", "End-Date (dd/mm/yyyy)","Age Analysis (Account overdue days)", ref startDate, ref endDate, ref ageAnalysis);

                if (dgResult == DialogResult.Cancel )
                    return;

                //|| ageAnalysis.Trim().Length == 0
                if (startDate.Trim().Length == 0 || endDate.Trim().Length == 0 )
                {
                    if (startDate.Trim().Length == 0)
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture Ledger start-date.");
                        return;
                    }

                    if (endDate.Trim().Length == 0)
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture Ledger end-date.");
                        return;
                    }

                    //if (ageAnalysis.Trim().Length == 0)
                    //{
                    //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture age-analysis period.");
                    //    return;
                    //}
                }

                DateTime startdt;
                if (!DateTime.TryParse(startDate, out startdt))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture valid Ledger start-date.");
                    return;
                }

                DateTime enddt;
                if (!DateTime.TryParse(endDate, out enddt))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture valid Ledger end-date.");
                    return;
                }

                System.TimeSpan diffResult = System.Convert.ToDateTime(enddt) - System.Convert.ToDateTime(startdt);
                if (diffResult.Days < 0)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Ledger End date must be in the future.");
                    return;
                }

                LedgerStartDate = startDate;
                LedgerEndDate = endDate;
                AgeAnalysis = ageAnalysis;                             
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Ledger criteria selecttion error, Please try again.");
                commonFuncs.ErrorLogger("Ledger criteria selecttion error: /n" + ex.ToString());
            }
        }

        protected void ExportExcel()
        {
           // //excelapp.Workbooks.Open   (App.path & Progress table.xls) 
            
           // Excel.Application xlApp=new Excel.Application();
           // object missing=System.Reflection.Missing.Value; 

           // if(xlApp==null)
           // {
           // MessageBox.Show("Create Excel object failed, maybe you dont install Excel ");
           // return;
           // }
           // Excel.Workbooks workbooks=xlApp.Workbooks;
           // Excel.Workbook workbook=workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
           // Excel.Worksheet worksheet=(Excel.Worksheet)workbook.Worksheets[1];// Get sheet1
           // Excel.Range range;

           // object missing1 = Missing.Value;
           // object missing2 = Missing.Value;
           // object missing3 = Missing.Value;
           // object missing4 = Missing.Value;
           // object missing5 = Missing.Value;
           // object missing6 = Missing.Value;
           // object missing7 = Missing.Value;
           // object missing8 = Missing.Value;
           // object missing9 = Missing.Value;
           // object missing10 = Missing.Value;
           // object missing11 = Missing.Value;
           // object missing12 = Missing.Value;
           // object missing13 = Missing.Value;
           // object missing14 = Missing.Value;

           // string HTMLFileName = "c:\\Guarantor_Stats_2010-01-01 - 2010-12-01.html";
           // workbooks.Open(HTMLFileName, missing2, missing3, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel9795, missing4, missing1, missing1, missing1, missing1, missing1, missing1, missing1, missing1, missing1, missing1);
            
           // object SaveFileName = "c:\\AIMS Recorder\\Guarantor_Stats.xls";
           // xlApp.Save(SaveFileName);

           //workbook.Close(missing,missing,missing);
           //xlApp.Quit();
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            SendEmail("AIMS Ledger Report", "BALANCES");
        }

        private void SendEmail(string _reportName, string LedgerType)
        {            
            DataSet _dsHTML = new DataSet();            
            Reports reportBLL = new Reports();            
            CommonFuncs clsComm = new CommonFuncs();
            AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
            string StartDate = "";
            string EndDate = "";
            string AgeAnalysisPeriod = "";
            GetLedgerSearchCriteria(ref StartDate, ref EndDate, ref AgeAnalysisPeriod);

            if (StartDate.Trim().Length == 0 || EndDate.Trim().Length == 0)
                return;

            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (lblGuarantorID.Text.ToString().Length > 0)
                {
                    GuarantorID = System.Convert.ToInt32(lblGuarantorID.Text);
                }
                switch (_reportName.ToUpper().Substring(0, 17))
                {
                    case "AIMS LEDGER REPOR":
                        _dsHTML = reportBLL.BuildAIMSLedgerReport(GuarantorID, LedgerType, StartDate, EndDate, AgeAnalysisPeriod, UserID, txtGuarantorName.Text);
                        string html = "";
                        foreach (DataRow drrr in _dsHTML.Tables[0].Rows)
	                    {
                            html = drrr[0].ToString(); 	 
	                    }
                         
                        AIMS.BLL.User clsUser = new AIMS.BLL.User();
                        clsUser = clsUser.GetUserDetails(UserID);

                        string emailaddress = clsUser.UserEmailAddress;

                        bool emailsent = commonFuncs.SendEmail(html, "operations@aims.org.za", "AIMS - Ledger", "AIMS " + LedgerType + " Ledger - " + txtGuarantorName.Text, emailaddress, "", false, "", "", "", "", false);
                        if (emailsent)
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Ledger email sent successfully.");
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Ledger email NOT sent successfully, Please contact system administrator");
                        }
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmail("AIMS Ledger Report", "PAYMENTS");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}