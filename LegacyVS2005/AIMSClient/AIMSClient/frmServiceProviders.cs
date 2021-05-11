using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmServiceProviders : Form
    {
        public AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
        protected string patientNo = string.Empty;
        AIMS.BLL.Supplier _supplier;
        bool ServiceTypeSelected = false;

        public frmServiceProviders()
        {
            InitializeComponent();
        }

        public frmServiceProviders(string patientFileNo)
        {
            InitializeComponent();
            patientNo = patientFileNo;
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

        private string _userID = "";

        
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        
        string _ServiceProviderEmail = "";
        public string ServiceProviderEmail
        {
            get { return _ServiceProviderEmail; }
            set { _ServiceProviderEmail = value; }
        }

        string _ServiceProviderFax = "";
        public string ServiceProviderFax
        {
            get { return _ServiceProviderFax; }
            set { _ServiceProviderFax = value; }
        }

        string _ServiceProviderName="";
        public string ServiceProviderName
        {
            get { return _ServiceProviderName; }
            set { _ServiceProviderName = value; }
        }

        string _ServiceProviderPhone = "";
        public string ServiceProviderPhone
        {
            get { return _ServiceProviderPhone; }
            set { _ServiceProviderPhone = value; }
        }
        private int _SupplierTypeID;
        public int SupplierTypeID
        {
            get { return _SupplierTypeID; }
            set { _SupplierTypeID = value; }
        }

        private Int64 _ServiceProviderID;
        public Int64 ServiceProviderID
        {
            get { return _ServiceProviderID; }
            set { _ServiceProviderID = value; }
        }

        string _ServiceProviderAdmin = "";
        public string ServiceProviderAdmin
        {
            get { return _ServiceProviderAdmin; }
            set { _ServiceProviderAdmin = value; }
        }

        string _ServiceProviderAdminTel = "";
        public string ServiceProviderAdminTel
        {
            get { return _ServiceProviderAdminTel; }
            set { _ServiceProviderAdminTel = value; }
        }

        string _ServiceProviderAdminFax = "";
        public string ServiceProviderAdminFax
        {
            get { return _ServiceProviderAdminFax; }
            set { _ServiceProviderAdminFax = value; }
        }

        string _ServiceProviderAdminEmail = "";
        public string ServiceProviderAdminEmail
        {
            get { return _ServiceProviderAdminEmail; }
            set { _ServiceProviderAdminEmail = value; }
        }

        private void frmServiceProviders_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                LoadSupplierTypes();
                if (SupplierTypeID > 0)
                {
                    cboSupplierTypes.SelectedValue = SupplierTypeID;
                }
                txtSupplierEmail.Text = ServiceProviderEmail;
                txtSupplierFax.Text = ServiceProviderFax;
                txtSupplierName.Text = ServiceProviderName;
                txtSupplierPhone.Text = ServiceProviderPhone;

                txtAdminName.Text = ServiceProviderAdmin;
                txtAdminTel.Text = ServiceProviderAdminTel;
                txtAdminFax.Text = ServiceProviderAdminFax;
                txtAdminEmail.Text = ServiceProviderAdminEmail;
                LockdownEditingForRole();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading Service Provider form, Please contact System administrator");
                commonFuncs.ErrorLogger("Error loading Service Provider form: " + ex.ToString());
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
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Supplier Type list.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveServiceProvider_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    _supplier = new AIMS.BLL.Supplier();
                    if (lblSupplier.Text.Trim().Length > 0)
                    {
                        _supplier.SupplierID = System.Convert.ToInt32(lblSupplier.Text);
                    }                    
                    _supplier.SupplierName = txtSupplierName.Text.Trim();
                    _supplier.SupplierTypeID = System.Convert.ToInt32(cboSupplierTypes.SelectedValue.ToString());
                    _supplier.SupplierPhoneNo = txtSupplierPhone.Text.Trim();
                    _supplier.SupplierFaxNo = txtSupplierFax.Text.Trim();
                    _supplier.SupplierEmailAddress = txtSupplierEmail.Text.Trim();
                    _supplier.LoggedOnUser = UserID;
                    _supplier.PatientFileNo = patientNo;
                    _supplier.ServiceProviderID =  ServiceProviderID ;

                    _supplier.SupplierAdminName = txtAdminName.Text.Trim(); 
                    _supplier.SupplierAdminTel = txtAdminTel.Text.Trim();
                    _supplier.SupplierAdminFax = txtAdminFax.Text.Trim();
                    _supplier.SupplierAdminEmail = txtAdminEmail.Text.Trim();

                    bool blSaved = _supplier.SaveServiceProvider();
                    if (blSaved)
                    {
                        MessageBox.Show("Patient Service Provider added/updated successfully", "New Service Provider", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show("Patient Service Provider update/add failed", "New Service Provider", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    
                    //TODO ADD CODE HERE TO SAVE A NEW NOTE
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        /// <summary>
        /// This method validates that all the required values have been provided.
        /// </summary>
        /// <returns></returns>
        private bool ValidateControls()
        {
            bool returnVal = true;
            try
            {
                errDesription.Clear();
                if (txtSupplierName.Text.Trim().Length == 0)
                {
                    errDesription.SetError(txtSupplierName, "Please enter Supplier Name");
                    txtSupplierName.Focus();
                    returnVal = false;
                }

                if (cboSupplierTypes.SelectedItem == null)
                {
                    errDesription.SetError(cboSupplierTypes, "Please select supplier type");
                    cboSupplierTypes.Focus();
                    returnVal = false;
                }

                if (cboSupplierTypes.SelectedItem != null)
                {
                    if (cboSupplierTypes.Text == "")
                    {
                        errDesription.SetError(cboSupplierTypes, "Please select supplier type");
                        cboSupplierTypes.Focus();
                        returnVal = false;
                    }
                }

            if (txtSupplierEmail.Text.Trim().Length > 0)
            {
                if (!ValidEmailAddress(txtSupplierEmail.Text.Trim()))
                {
                    errDesription.SetError(txtSupplierEmail, "Please enter valid email address");
                    txtSupplierEmail.Focus();
                    returnVal = false;                    
                }
            }
            }
            catch (System.Exception ex)
            {
                throw;
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

        }

        private void LoadSupplier() 
        {
            try
            {
                //cboSuppliers.Items.Clear();
                bool AllServiceProvider =  chkAllServiceProviders.Checked;

                DataTable dtServiceProviders = new DataTable();
                if (AllServiceProvider)
                {
                    dtServiceProviders = commonFuncs.GetSuppliers();
                }
                else
                {
                    if (cboSupplierTypes.SelectedIndex > 0 )
                    {
                        long ServiceTypeID = System.Convert.ToInt64(cboSupplierTypes.SelectedValue);
                        dtServiceProviders = commonFuncs.GetSuppliers(ServiceTypeID.ToString());  
                    }
                }

                cboSuppliers.DataSource = null;
                cboSuppliers.Items.Clear();
                
                if (dtServiceProviders.Rows.Count > 0)
                {
                    cboSuppliers.DataSource = dtServiceProviders;
                    cboSuppliers.DisplayMember = "SUPPLIER_NAME";
                    cboSuppliers.ValueMember = "SUPPLIER_ID";
                    cboSuppliers.SelectedIndex = -1;
                }
            }
            catch (System.Exception ex)
            {
                
                throw;
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

        private void cboSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAllServiceProviders_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveServiceProvider_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdminSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    _supplier = new AIMS.BLL.Supplier();
                    if (lblSupplier.Text.Trim().Length > 0)
                    {
                        _supplier.SupplierID = System.Convert.ToInt32(lblSupplier.Text);
                    }

                    _supplier.SupplierName = txtSupplierName.Text.Trim();
                    _supplier.SupplierTypeID = System.Convert.ToInt32(cboSupplierTypes.SelectedValue.ToString());
                    _supplier.SupplierPhoneNo = txtSupplierPhone.Text.Trim();
                    _supplier.SupplierFaxNo = txtSupplierFax.Text.Trim();
                    _supplier.SupplierEmailAddress = txtSupplierEmail.Text.Trim();

                    //Service Provider Administration
                    _supplier.SupplierAdminName = txtAdminName.Text.Trim();
                    _supplier.SupplierAdminTel = txtAdminTel.Text.Trim();
                    _supplier.SupplierAdminFax = txtAdminFax.Text.Trim();
                    _supplier.SupplierAdminEmail = txtAdminEmail.Text.Trim();

                    _supplier.LoggedOnUser = UserID;
                    _supplier.PatientFileNo = patientNo;
                    _supplier.ServiceProviderID = ServiceProviderID;

                    bool blSaved = _supplier.SaveServiceProvider();
                    if (blSaved)
                    {
                        MessageBox.Show("Patient Service Provider added/updated successfully", "New Service Provider", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Patient Service Provider update/add failed", "New Service Provider", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //TODO ADD CODE HERE TO SAVE A NEW NOTE
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (System.Exception ex)
            {
                throw;
            } 
        }

        private void btnSaveServiceProvider_Click_2(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (ValidateControls())
                {
                    _supplier = new AIMS.BLL.Supplier();
                    if (lblSupplier.Text.Trim().Length > 0)
                    {
                        _supplier.SupplierID = System.Convert.ToInt32(lblSupplier.Text);
                    }

                    _supplier.SupplierName = txtSupplierName.Text.Trim();
                    _supplier.SupplierTypeID = System.Convert.ToInt32(cboSupplierTypes.SelectedValue.ToString());
                    _supplier.SupplierPhoneNo = txtSupplierPhone.Text.Trim();
                    _supplier.SupplierFaxNo = txtSupplierFax.Text.Trim();
                    _supplier.SupplierEmailAddress = txtSupplierEmail.Text.Trim();
                    _supplier.LoggedOnUser = UserID;
                    _supplier.PatientFileNo = patientNo;
                    _supplier.ServiceProviderID = ServiceProviderID;

                    //Service Provider Administration
                    _supplier.SupplierAdminName = txtAdminName.Text.Trim();
                    _supplier.SupplierAdminTel = txtAdminTel.Text.Trim();
                    _supplier.SupplierAdminFax = txtAdminFax.Text.Trim();
                    _supplier.SupplierAdminEmail = txtAdminEmail.Text.Trim();

                    bool blSaved = _supplier.SaveServiceProvider();
                    if (blSaved)
                    {
                        MessageBox.Show("Patient Service Provider added/updated successfully", "New Service Provider", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Patient Service Provider update/add failed", "New Service Provider", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //TODO ADD CODE HERE TO SAVE A NEW NOTE
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error saving Service Provider, Please contact System Administrator");
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error saving Service Provider: " + ex.ToString());
            } 
            finally
            {
                commonFuncs = null;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSupplierTypes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string value = "";
            AIMS.BLL.Invoice _invoiceNew = new AIMS.BLL.Invoice();
            try
            {
                if (cboSupplierTypes.SelectedItem != null && cboSupplierTypes.Text == "<Add New Service>")
                {
                    if (InputBox("New Service", "Service Description (e.g. Dentist, Cardiologist, Ambulance)", ref value) == DialogResult.OK)
                    {
                        if (value.Trim().Length > 0)
                        {
                            bool bSaved = false;

                            AIMS.BLL.Invoice clsInvoice = new AIMS.BLL.Invoice();

                            DataTable dtServiceCheck = _invoiceNew.CheckIfServiceExist(value.Trim());

                            if (dtServiceCheck.Rows.Count > 0)
                            {
                                MessageBox.Show("Service already exists", "Service Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cboSupplierTypes.SelectedIndex = -1;
                            }
                            else
                            {
                                bSaved = _invoiceNew.SaveNewService(value.Trim(), UserID);
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
                else
                {
                    if (cboSupplierTypes.SelectedIndex > 0)
                    {
                        ServiceTypeSelected = true;
                        LoadSupplier();
                    }
                    txtSupplierEmail.Text = "";
                    txtSupplierFax.Text = "";
                    txtSupplierName.Text = "";
                    txtSupplierPhone.Text = "";
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

        private void chkAllServiceProviders_CheckedChanged_1(object sender, EventArgs e)
        {
            //if (cboSupplierTypes.SelectedIndex > 0)
            //{
            LoadSupplier();
            txtSupplierEmail.Text = "";
            txtSupplierFax.Text = "";
            txtSupplierName.Text = "";
            txtSupplierPhone.Text = "";
            //}
        }

        private void cboSuppliers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cboSuppliers.SelectedItem != null && cboSuppliers.SelectedIndex > 0)
                {
                    ServiceTypeSelected = false;
                    long SupplierID = System.Convert.ToInt64(cboSuppliers.SelectedValue);
                    DataTable dtSupplierDetails = new DataTable();
                    dtSupplierDetails = commonFuncs.GetSupplierDetails(SupplierID.ToString());
                    if (dtSupplierDetails.Rows.Count > 0)
                    {
                        txtSupplierEmail.Text = dtSupplierDetails.Rows[0]["supplier_email_address"].ToString();
                        txtSupplierFax.Text = dtSupplierDetails.Rows[0]["supplier_fax_no"].ToString();
                        txtSupplierName.Text = dtSupplierDetails.Rows[0]["supplier_name"].ToString();
                        txtSupplierPhone.Text = dtSupplierDetails.Rows[0]["supplier_phone_no"].ToString();
                    }
                    else
                    {
                        txtSupplierEmail.Text = "";
                        txtSupplierFax.Text = "";
                        txtSupplierName.Text = "";
                        txtSupplierPhone.Text = "";
                    }
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        private void LockdownEditingForRole()
        {
            try
            {
                cboSupplierTypes.Enabled = UserAllowed("84");
                chkAllServiceProviders.Enabled = UserAllowed("84");
                cboSuppliers.Enabled = UserAllowed("84");
                txtSupplierName.Enabled = UserAllowed("84");
                txtSupplierPhone.Enabled = UserAllowed("84");
                txtSupplierFax.Enabled = UserAllowed("84");
                txtSupplierEmail.Enabled = UserAllowed("84");

                txtAdminName.Enabled = UserAllowed("85");
                txtAdminTel.Enabled = UserAllowed("85");
                txtAdminFax.Enabled = UserAllowed("85");
                txtAdminEmail.Enabled = UserAllowed("85");
            }
            catch (System.Exception ex)
            {
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
            try
            {
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
            }
            finally
            {
                
            }
            return bAllowedFunction;
        }
    }
}