using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AIMSClient
{
    public partial class frmSuppliers : Form
    {        
        private string _newHospitalSupplier;
        public string DoctorInitials = "";
        public string DoctorSurname = "";
        public bool LoadSupplierInfo = false;

        public string  NewHospitalSupplier
        {
            get { return _newHospitalSupplier; }
            set { _newHospitalSupplier = value; }
        }
	
        private int _supplierID;

        public int SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }

        private bool _addNewSupplier;

        public bool AddNewSupplier
        {
            get { return _addNewSupplier; }
            set { _addNewSupplier = value; }
        }

        private bool _hideSupplierType;

        public bool HideSupplierType
        {
            get { return _hideSupplierType; }
            set { _hideSupplierType = value; }
        }

        public AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions ();
        
        AIMS.BLL.Supplier _supplier;

        #region "Private Properties"
        string _userName = "";
        string _userID = "";        
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
        #endregion

        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            try
            {
                txtSurname.Text = "";
                txtSurname.Enabled = false;

                LoadCountries();
                LoadSupplierTypes();
                if (AddNewSupplier)
                {
                    gpxSupplierSearch.Visible = false;

                    ClearControls();
                    gpxSuppliers.Enabled = true;
                    gpxSuppliers.Top = 0;
                    pnlButtons.Top = gpxSuppliers.Bottom;
                    txtSupplierName.Text = NewHospitalSupplier;
                    if (HideSupplierType)
                    {
                        cboSupplierTypes.SelectedValue = -1;    
                    }
                    else
                    {
                        cboSupplierTypes.SelectedValue = 1;    
                    }
                    
                    tabSuppliers.Enabled = true ;
                    txtSupplierName.Focus();
                    ResizeFormControls();
                    btnSave.Enabled = true;
                }
                else
	            {
                    btnClose.Visible = false;
                    LoadSupplier();
                    tabSuppliers.Enabled = true;
                    btnSave.Enabled = UserAllowed("11");
	            }

                btnAddNew.Enabled = UserAllowed("11");
                LockdownEditingForRole();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void frmSuppliers_Resize(object sender, EventArgs e)
        {
           
            this.gpxSupplierSearch.Left = this.Left + 2;
            this.gpxSuppliers.Left = this.Left + 2;
            this.gpxSuppliers.Width = this.ClientSize.Width - 4;
            this.gpxSupplierSearch.Width = this.ClientSize.Width - 4;
            this.gpxSupplierSearch.Height = Convert.ToInt32(this.ClientSize.Height * 0.30);
            this.gpxSuppliers.Top = gpxSupplierSearch.Bottom + 2;
            this.gpxSuppliers.Height = Convert.ToInt32(this.ClientSize.Height * 0.62);

            this.aimsComboLookup1.Top = gpxSupplierSearch.Top + 10;
            this.aimsComboLookup1.Width = Convert.ToInt32((gpxSupplierSearch.Width * 0.35));
            this.aimsComboLookup1.Height = Convert.ToInt32(gpxSupplierSearch.Height * 0.85);
            this.aimsComboLookup1.lstItems.Height = Convert.ToInt32(gpxSupplierSearch.Height * 0.65);

            pnlButtonSearch.Top = gpxSupplierSearch.Height - 30;
            pnlButtonSearch.Height = 27;

            this.pnlButtonSearch.Left = aimsComboLookup1.Left;
            this.pnlButtonSearch.Width = aimsComboLookup1.Width - 10;

            this.btnDelete.Left = (pnlButtonSearch.Right - (btnDelete.Width + 10));
            this.btnAddNew.Left = aimsComboLookup1.Right - (btnAddNew.Width + 20);//Convert.ToInt32((pnlButtonSearch.Width * 0.5) - 30);
            this.btnSelect.Left = pnlButtonSearch.Left;

            this.tabSuppliers.Width = this.gpxSuppliers.Width - 20;
            this.tabSuppliers.Height = Convert.ToInt32(this.gpxSuppliers.Height * 0.92);

            this.pnlButtons.Top = this.gpxSuppliers.Bottom;
            this.btnSave.Left = Convert.ToInt32(this.ClientSize.Width * 0.35);
            this.btnClose.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);

            this.pnlButtons.Width = this.gpxSuppliers.Width;
            this.Left = this.tabSuppliers.Left + 10;

            this.btnRefresh.Left = btnSelect.Width + 20;
            this.btnRefresh.Top = btnSelect.Top;
            this.btnRefresh.Width = btnSelect.Width;
        }

        private void frmSuppliers_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 360);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);
        }

        private void LoadSupplier()
        {
            try
            {
                aimsComboLookup1.DataField1 = "SUPPLIER_NAME";
                aimsComboLookup1.DataField2 = "SUPPLIER_ID";
                aimsComboLookup1.OrderByField = "SUPPLIER_NAME";            
                aimsComboLookup1.TableName = "AIMS_SUPPLIERS_VW";
                aimsComboLookup1.ItemsLoaded = 50;
                aimsComboLookup1.Initialise(""); 
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Patient list.");
            }
        }

        private void LoadCountries()
        {
            try
            {
                DataTable dtCountries = new DataTable();
                dtCountries = commonFuncs.GetCountries();

                if (dtCountries.Rows.Count > 0 )
                {
                    cboCountries.DataSource = dtCountries;
                    cboCountries.DisplayMember = "COUNTRY_NAME";
                    cboCountries.ValueMember = "COUNTRY_ID";                    
                }
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Patient list.");
            }
        }

        private void LoadSupplierTypes()
        {
            try
            {
                DataTable dtSupplierTypes = new DataTable();
                dtSupplierTypes = commonFuncs.GetSupplierTypes();

                if (dtSupplierTypes.Rows.Count > 0)
                {
                    cboSupplierTypes.DataSource = dtSupplierTypes;
                    cboSupplierTypes.DisplayMember = "SUPPLIER_TYPE_DESC";
                    cboSupplierTypes.ValueMember = "SUPPLIER_TYPE_ID";
                }
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Supplier list.");
            }
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (aimsComboLookup1.lstItems.SelectedIndex != -1)
            {
                errProv.Clear();
                ClearControls();
                LoadSupplierInfo = true;
                LoadSupplierDetails(0);
                LoadSupplierInfo = false;
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select a supplier from the list.");
            }
        }

        /// <summary>
        /// This method list details for a specific patient
        /// </summary>
        private void LoadSupplierDetails(Int64 supplierID)
        {
            Int64 SupplierAddressID = 0;
            int SupplierCountryID = 0;
            int SupplierTypeID = 0;

            AIMS.BLL.Supplier clsSupplier = new AIMS.BLL.Supplier();
            try
            {
                if (supplierID > 0 )
                {
                    ClearControls();
                    _supplier = clsSupplier.GetSupplierDetails(supplierID.ToString());
                }
                else
                {
                    _supplier = clsSupplier.GetSupplierDetails(aimsComboLookup1.lstItems.SelectedValue.ToString());
                }
                
                if (_supplier != null)
                {
                    tabSuppliers.Enabled = true;
                    lblSupplierID.Text  = _supplier.SupplierID.ToString();
                    txtSupplierAccNo.Text = _supplier.SupplierAccountNo;
                    txtSupplierContactName.Text = _supplier.SupplierContactName;
                    //txtSupplierEmailAddress.Text = _supplier.SupplierEmailAddress;
                    txtSupplierFaxNo.Text = _supplier.SupplierFaxNo;
                    txtSupplierName.Text = _supplier.SupplierName;
                    txtSupplierPhoneNo.Text = _supplier.SupplierPhoneNo;

                    txtSupplierContactNames.Text = _supplier.SupplierContactName;
                    txtSupplierCell.Text = _supplier.SupplierMobileNo;
                    txtSupplierEmail.Text = _supplier.SupplierEmailAddress;
                    txtSupplierFax.Text = _supplier.SupplierFaxNo;
                    txtSupplierPhone.Text = _supplier.SupplierPhoneNo;
                    //txtSupplierMobile.Text = _supplier.SupplierMobileNo;

                    txtSupplierCell.Text = _supplier.SupplierMobileNo;

                    txtAdminName.Text = _supplier.SupplierAdminName;
                    txtAdminTel.Text = _supplier.SupplierAdminTel;
                    txtAdminFax.Text = _supplier.SupplierAdminFax;
                    txtAdminEmail.Text = _supplier.SupplierAdminEmail;
                    txtAdminCell.Text = _supplier.SupplierAdminCellNo;

                    if (_supplier.SupplierTypeID > 0)
                    {
                        SupplierTypeID = System.Convert.ToInt32(_supplier.SupplierTypeID);
                        cboSupplierTypes.SelectedValue = SupplierTypeID;
                    }

                    if (_supplier.SupplierAddressID > 0)
                    {
                        SupplierAddressID = System.Convert.ToInt64(_supplier.SupplierAddressID);
                        DataTable dtSupplierAddress = commonFuncs.GetAddressDetails(SupplierAddressID);
                        if (dtSupplierAddress.Rows.Count > 0)
                        {
                            txtSupplierAddr1.Text = dtSupplierAddress.Rows[0]["Address1"].ToString();
                            txtSupplierAddr2.Text = dtSupplierAddress.Rows[0]["ADDRESS2"].ToString();
                            txtSupplierAddr3.Text = dtSupplierAddress.Rows[0]["ADDRESS3"].ToString();
                            txtSupplierAddr4.Text = dtSupplierAddress.Rows[0]["ADDRESS4"].ToString();
                            txtSupplierCity.Text = dtSupplierAddress.Rows[0]["ADDRESS5"].ToString();
                            txtSupplierPostalCode.Text = dtSupplierAddress.Rows[0]["POSTAL_CODE"].ToString();
                            txtSupplierProvince.Text = dtSupplierAddress.Rows[0]["PROVINCE"].ToString();

                            if (dtSupplierAddress.Rows[0]["COUNTRY_ID"] != null)
                            {
                                SupplierCountryID = System.Convert.ToInt32(dtSupplierAddress.Rows[0]["COUNTRY_ID"]);
                                if (SupplierCountryID > 0)
                                {
                                    cboCountries.SelectedValue = SupplierCountryID;
                                }
                            }
                        }                        
                    }
                    if (_supplier.SupplierActiveYN == "N" )
                    {
                        chkSupplierActiveYN.Checked = true;                        
                    }
                    else
                    {                        
                        chkSupplierActiveYN.Checked = false; 
                    }

                    if (_supplier.DoctorSupplierYN  == "Y")
                    {
                        chkDoctor.Checked = true ;
                        txtSupplierName.ReadOnly = true;
                    }
                    else
                    {
                        txtSupplierName.ReadOnly = false;
                        chkDoctor.Checked = false;
                    }
                }
                txtSupplierAccNo.Focus();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
            finally
            {
                clsSupplier = null;
            }
        }

        protected void aimsComboLookup1_DblClicked()
        {
            btnSelect_Click(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Int64 LastPatient = 0;
            if (aimsComboLookup1.lstItems.SelectedIndex != null && aimsComboLookup1.lstItems.SelectedIndex > 0)
            {
                LastPatient = aimsComboLookup1.lstItems.SelectedIndex;
            }

            string errorMSG = "";
            if (ValidateControls(ref errorMSG))
            {
                AIMS.BLL.Supplier clsSupplier = new AIMS.BLL.Supplier();
                bool bSaved = false;
                try
                {
                    if (lblSupplierID.Text.Trim().Length > 0)
                    {
                        clsSupplier.SupplierID = System.Convert.ToInt32(lblSupplierID.Text);
                    }

                    clsSupplier.SupplierAccountNo = txtSupplierAccNo.Text.Trim();
                    clsSupplier.SupplierAddress1 = txtSupplierAddr1.Text.Trim();
                    clsSupplier.SupplierAddress2 = txtSupplierAddr2.Text.Trim();
                    clsSupplier.SupplierAddress3 = txtSupplierAddr3.Text.Trim();
                    clsSupplier.SupplierAddress4 = txtSupplierAddr4.Text.Trim();
                    clsSupplier.SupplierCity = txtSupplierCity.Text.Trim();
                    clsSupplier.SupplierContactName = txtSupplierContactName.Text.Trim();

                    if (cboCountries.SelectedValue != null && cboCountries.Text.Trim().Length > 0)
                    {
                        clsSupplier.SupplierCountryID = System.Convert.ToInt32(cboCountries.SelectedValue);
                    }
                    else
                    {
                        clsSupplier.SupplierCountryID = 0;
                    }
                    clsSupplier.SupplierEmailAddress = txtSupplierEmailAddress.Text.Trim();
                    
                    clsSupplier.SupplierName = txtSupplierName.Text.Trim();
                    clsSupplier.SupplierAccountNo = txtSupplierAccNo.Text.Trim();
                    clsSupplier.SupplierPostalCode = txtSupplierPostalCode.Text.Trim();
                    clsSupplier.SupplierTypeID = System.Convert.ToInt32(cboSupplierTypes.SelectedValue);                    
                    clsSupplier.SupplierProvince = txtSupplierProvince.Text.Trim();

                    clsSupplier.SupplierContactName = txtSupplierContactNames.Text;
                    clsSupplier.SupplierPhoneNo = txtSupplierPhone.Text;
                    clsSupplier.SupplierFaxNo = txtSupplierFax.Text ;
                    clsSupplier.SupplierEmailAddress = txtSupplierEmail.Text;
                    clsSupplier.SupplierMobileNo = txtSupplierCell.Text;

                    clsSupplier.SupplierAdminName = txtAdminName.Text;
                    clsSupplier.SupplierAdminTel = txtAdminTel.Text;
                    clsSupplier.SupplierAdminFax = txtAdminFax.Text;
                    clsSupplier.SupplierAdminEmail = txtAdminEmail.Text;
                    clsSupplier.SupplierAdminCellNo = txtAdminCell.Text;

                    clsSupplier.LoggedOnUser = UserID;
                    if (chkSupplierActiveYN.Checked == true)
                    {
                        clsSupplier.SupplierActiveYN = "N";
                    }
                    else
                    {
                        clsSupplier.SupplierActiveYN = "Y";
                    }

                    if (chkDoctor.Checked == true  )
                    {
                        clsSupplier.DoctorSupplierYN = "Y";
                        clsSupplier.DoctorNameInitials = DoctorInitials;
                        clsSupplier.DoctorSurname = DoctorSurname;
                    }
                    else
                    {
                        clsSupplier.DoctorNameInitials = "";
                        clsSupplier.DoctorSurname = "";
                        clsSupplier.DoctorSupplierYN = "N";
                    }

                    if (lblSupplierID.Text.Trim().Length == 0)
                    {
                        DataTable dtSupplierVerify = clsSupplier.VerifySupplier(txtSupplierName.Text.Trim());
                        if (dtSupplierVerify.Rows.Count > 0)
                        {
                            MessageBox.Show("Supplier already exist.", "Duplicate Supplier", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    txtSupplierCell.Enabled = UserAllowed("84");

                    clsSupplier.SupplierAdminName = txtAdminName.Text.Trim();
                    clsSupplier.SupplierAdminTel = txtAdminTel.Text.Trim();
                    clsSupplier.SupplierAdminFax = txtAdminFax.Text.Trim();
                    clsSupplier.SupplierAdminEmail = txtAdminEmail.Text.Trim();
                    clsSupplier.SupplierAdminCellNo = txtAdminCell.Text.Trim();

                    
                    //clsSupplier.SupplierActiveYN = ""
                    bSaved = clsSupplier.SaveInvoiceDetails();
                    if (bSaved)
                    {
                        MessageBox.Show("Supplier added successfully.", "New Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSupplier();
                        if (AddNewSupplier)
                        {
                            this.Close();    
                        }
                        if (LastPatient >0)
                        {
                            aimsComboLookup1.lstItems.SelectedIndex = (int)LastPatient;
                        }                                           
                    }
                    else
                    {
                        MessageBox.Show("Supplier NOT added successfully.", "New Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    clsSupplier = null;
                }
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, errorMSG);
            }
        }

        private void aimsComboLookup1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void ClearControls()
        {
            txtSupplierPostalCode.Text = "";
            txtSupplierAccNo.Text = "";
            txtSupplierAddr1.Text = "";
            txtSupplierAddr2.Text = "";
            txtSupplierAddr3.Text = "";
            txtSupplierAddr4.Text = "";
            txtSupplierCity.Text = "";
            txtSupplierContactName.Text = "";
            txtSupplierEmailAddress.Text = "";
            txtSupplierFaxNo.Text = "";
            txtSupplierName.Text = "";
            txtSupplierPhoneNo.Text = "";
            txtSupplierPostalCode.Text = "";
            txtSupplierProvince.Text = "";
            cboCountries.SelectedIndex = -1;
            cboSupplierTypes.SelectedIndex = -1;
            lblSupplierID.Text = "";
            txtSupplierMobile.Text = "";
            chkSupplierActiveYN.Checked = false;
            LoadSupplierInfo = false;
            chkDoctor.Checked = false;

            txtSupplierContactNames.Text = "";
            txtSupplierPhone.Text = "";
            txtSupplierFax.Text = "";
            txtSupplierEmail.Text = "";
            txtSupplierCell.Text = "";

            txtAdminName.Text = "";
            txtAdminTel.Text = "";
            txtAdminFax.Text = "";
            txtAdminEmail.Text = "";
            txtAdminCell.Text = "";

            _supplier = new AIMS.BLL.Supplier();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tabSuppliers.Enabled = true;
            ClearControls();
            txtSupplierAccNo.Focus();
            LoadSupplier();
        }

        private void aimsComboLookup1_Load_1(object sender, EventArgs e)
        {

        }

        private bool UserAllowed(string RestrictionID)
        {
            //RESTRICTION_ID       RESTRICTION_DESC                                   
            //-------------------- ----------------------
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

        public bool ValidateControls(ref string ErrMsg)
        {
            bool returnVal = true;

            errProv.Clear();

            if (this.txtSupplierName.Text.Trim().Length == 0 && !chkDoctor.Checked)
            {
                errProv.SetError(txtSupplierName, "Please enter Supplier Name");
                ErrMsg = "Please enter Supplier Name";
                txtSupplierName.Focus();
                returnVal = false;
            }

            if (cboSupplierTypes.SelectedItem == null)
            {
                errProv.SetError(cboSupplierTypes, "Please select supplier type");
                ErrMsg = "Please select supplier type";
                cboSupplierTypes.Focus();
                returnVal = false;                
            }

            if (cboSupplierTypes.SelectedItem != null)
            {
                if (cboSupplierTypes.Text.Trim() == "")
                {
                    errProv.SetError(cboSupplierTypes, "Please select supplier type");
                    ErrMsg = "Please select supplier type";
                    cboSupplierTypes.Focus();
                    returnVal = false;                    
                }
            }

            if (txtSupplierEmail.Text.Trim().Length > 0)
            {
                if (!ValidEmailAddress(txtSupplierEmail.Text.Trim()))
                {
                    errProv.SetError(txtSupplierEmail, "Please enter valid email address");
                    ErrMsg = "Please enter valid SUPPLIER email address";
                    txtSupplierEmail.Focus();
                    returnVal = false;                    
                }
            }

            if (txtAdminEmail.Text.Trim().Length > 0)
            {
                if (!ValidEmailAddress(txtAdminEmail.Text.Trim()))
                {
                    errProv.SetError(txtAdminEmail, "Please enter valid email address");
                    ErrMsg = "Please enter valid ADMIN email address";
                    txtAdminEmail.Focus();
                    returnVal = false;
                }
            }

            if (chkDoctor.Checked)
            {
                if (DoctorInitials.Trim().Length == 0 | DoctorSurname.Trim().Length == 0)
                {
                    errProv.SetError(chkDoctor, "Please enter Doctor details");
                    ErrMsg = "Please enter Doctor details";
                    chkDoctor.Focus();
                    returnVal = false;                                        
                }
            }

            if (returnVal == true)
            {
                errProv.Clear();
            }
            return returnVal;
        }

        public bool ValidEmailAddress(string emailAddress)
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

        private void cboSupplierTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = "";
            AIMS.BLL.Supplier  _invoiceNew = new AIMS.BLL.Supplier();
            try
            {
                if (cboSupplierTypes.SelectedItem != null && cboSupplierTypes.Text == "<Add New Service>")
                {
                    if (InputBox("New Service", "Service Description (e.g. Dentist, Cardiologist, Ambulance)", ref value) == DialogResult.OK)
                    {
                        if (value.Trim().Length > 0)
                        {
                            bool bSaved = false;

                            AIMS.BLL.Supplier clsInvoice = new AIMS.BLL.Supplier();

                            DataTable dtServiceCheck = _invoiceNew.CheckIfServiceExist(value.Trim());

                            if (dtServiceCheck.Rows.Count > 0)
                            {
                                MessageBox.Show("Service already exists", "Service Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cboSupplierTypes.SelectedIndex = -1;
                            }
                            else
                            {
                                bSaved = _invoiceNew.SaveNewService(value.Trim(), UserID );
                                if (bSaved)
                                {
                                    DataTable dtSupplierTypes = new DataTable();
                                    dtSupplierTypes = commonFuncs.GetSupplierTypes();

                                    if (dtSupplierTypes.Rows.Count > 0)
                                    {
                                        cboSupplierTypes.DataSource = dtSupplierTypes;
                                        cboSupplierTypes.DisplayMember = "SUPPLIER_TYPE_DESC";
                                        cboSupplierTypes.ValueMember = "SUPPLIER_TYPE_ID";
                                        cboSupplierTypes.SelectedIndex = -1;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Service addition failed", "Service Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            cboSupplierTypes.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        cboSupplierTypes.SelectedIndex = -1;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                LoadSupplier();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Refreshing AIMS Recorder Failed, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Suppliers form refreshing failed, Error - " + ex.ToString());
            }
        }

        private void chkDoctor_CheckedChanged(object sender, EventArgs e)
        {
            errProv.Clear();
            if (chkDoctor.Checked == true)
            {
                if (!LoadSupplierInfo)
                {
                    DoctorInitials = "";
                    DoctorSurname = "";
                    
                    DoctorInputBox("Doctor Supplier", "Doctor Name or Initials", "Doctor Surname", ref DoctorInitials, ref DoctorSurname);
                    if (DoctorInitials.Trim().Length == 0 | DoctorSurname.Trim().Length == 0)
                    {
                        chkDoctor.Checked = false;
                        txtSupplierName.ReadOnly  = false ;
                    }
                    else
                    {
                        txtSupplierName.ReadOnly = true;                
                        txtSupplierName.Text = DoctorSurname.Trim() + " " + DoctorInitials.Trim();
                        txtSupplierContactName.Focus();
                    }                    
                }
                LoadSupplierInfo = false;
            }
            else
            {
                txtSupplierName.ReadOnly = false ;
                txtSurname.Text = "";
                txtSurname.Enabled = false;
                DoctorInitials = "";
                DoctorSurname = "";
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

        public static DialogResult DoctorInputBox(string title, string promptText1, string promptText2, ref string value1, ref string value2)
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
                //textBox.Text = value;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label1.SetBounds(9, 20, 372, 13);
                label2.SetBounds(9, 60, 744, 26);
                textBox1.SetBounds(12, 36, 399, 20);
                textBox2.SetBounds(12, 76, 399, 20);
                buttonOk.SetBounds(228, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label1.AutoSize = true;
                label2.AutoSize = true;
                textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
                textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;

                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonOk.Top = textBox2.Bottom;
                buttonCancel.Top = textBox2.Bottom;
                
                form.ClientSize = new Size(420, 120);
                form.Controls.AddRange(new Control[] { label1, label2, textBox1, textBox2, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value1 = textBox1.Text;
                value2  = textBox2.Text;

                
                return dialogResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCostLimit_Click(object sender, EventArgs e)
        {
            try
            {
                string value = "";
                if (InputBox("Service/Supplier Type Cost Limit", "If you need to setup a cost-limit on this supplier type", ref value) == DialogResult.OK)
                {
                    if (value.Trim().Length > 0)
                    {
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void ResizeFormControls()
        {
            txtSupplierPostalCode.Enabled = UserAllowed("11");
            txtSupplierAccNo.Enabled = UserAllowed("11");
            txtSupplierAddr1.Enabled = UserAllowed("11");
            txtSupplierAddr2.Enabled = UserAllowed("11");
            txtSupplierAddr3.Enabled = UserAllowed("11");
            txtSupplierAddr4.Enabled = UserAllowed("11");
            txtSupplierCity.Enabled = UserAllowed("11");
            txtSupplierContactName.Enabled = UserAllowed("11");
            txtSupplierEmailAddress.Enabled = UserAllowed("11");
            txtSupplierFaxNo.Enabled = UserAllowed("11");
            txtSupplierName.Enabled = true;
            txtSupplierPhoneNo.Enabled = UserAllowed("11");
            txtSupplierPostalCode.Enabled = UserAllowed("11");
            txtSupplierProvince.Enabled = UserAllowed("11");
            cboCountries.Enabled = UserAllowed("11");
            cboSupplierTypes.Enabled = UserAllowed("11");
            lblSupplierID.Enabled = UserAllowed("11");
            txtSupplierMobile.Enabled = UserAllowed("11");
            chkSupplierActiveYN.Enabled = UserAllowed("11");            
            chkDoctor.Enabled = UserAllowed("11");
            chkProfessor.Enabled = UserAllowed("11");
        }

        private void LockdownEditingForRole()
        {
            try
            {
                txtSupplierContactNames.Enabled = UserAllowed("84");
                txtSupplierPhone.Enabled = UserAllowed("84");
                txtSupplierFax.Enabled = UserAllowed("84");
                txtSupplierEmail.Enabled = UserAllowed("84");
                txtSupplierCell.Enabled = UserAllowed("84");

                txtAdminName.Enabled = UserAllowed("85");
                txtAdminTel.Enabled = UserAllowed("85");
                txtAdminFax.Enabled = UserAllowed("85");
                txtAdminEmail.Enabled = UserAllowed("85");
                txtAdminCell.Enabled = UserAllowed("85");
            }
            catch (System.Exception ex)
            {
            }
        }
      }
}