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
    public partial class frmPayment : Form
    {
        public string DoctorOwingInvoiceNo = "";
        public string LateSubmissionInvoiceNo = "";
        public bool LoadSupplierInfo = false;
        public bool UpdateLateInvoiceOverPymt = false;
        
        public AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
        AIMS.Client.CommonFuncs CommonFuncs = new CommonFuncs();

        AIMS.BLL.Payment _payment;


        public frmPayment()
        {
            InitializeComponent();
        }

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

        private void frmPayment_Resize(object sender, EventArgs e)
        {
           

            this.gpxPaymentSearch.Left = this.Left + 2;
            this.gpxPayment.Left = this.Left + 2;
            this.gpxPayment.Width = this.ClientSize.Width - 4;
            this.gpxPaymentSearch.Width = this.ClientSize.Width - 4;
            this.gpxPaymentSearch.Height = Convert.ToInt32(this.ClientSize.Height * 0.30);
            this.gpxPayment.Top = gpxPaymentSearch.Bottom + 2;
            this.gpxPayment.Height = Convert.ToInt32(this.ClientSize.Height * 0.62);

            this.aimsComboLookup1.Top = gpxPaymentSearch.Top + 10;
            this.aimsComboLookup1.Width = Convert.ToInt32((gpxPaymentSearch.Width * 0.35));
            this.aimsComboLookup1.Height = Convert.ToInt32(gpxPaymentSearch.Height * 0.80);
            this.aimsComboLookup1.lstItems.Height = Convert.ToInt32(gpxPaymentSearch.Height * 0.58);

            pnlButtonSearch.Top = gpxPaymentSearch.Height - 30;
            pnlButtonSearch.Height = 27;

            this.pnlButtonSearch.Left = aimsComboLookup1.Left;
            this.pnlButtonSearch.Width = aimsComboLookup1.Width - 10;

            this.btnDelete.Left = (pnlButtonSearch.Right - (btnDelete.Width + 10));
            this.btnAdd.Left = aimsComboLookup1.Right - (btnAdd.Width + 20);//Convert.ToInt32((pnlButtonSearch.Width * 0.5) - 30);
            this.btnSelect.Left = pnlButtonSearch.Left;

            this.tabPayment.Width = this.gpxPayment.Width - 20;
            this.tabPayment.Height = Convert.ToInt32(this.gpxPayment.Height * 0.92);

            this.pnlButtons.Top = this.gpxPayment.Bottom;
            this.btnSave.Left = Convert.ToInt32(this.ClientSize.Width * 0.35);
            this.btnClose.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);
            
            this.pnlButtons.Width = this.gpxPayment.Width;
            this.Left = this.tabPayment.Left + 10;
        }

        private void frmPayment_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 360);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);
        }

        private void btnPatientFileNoCheck_Click(object sender, EventArgs e)
        {
            DataTable dtPatientExist = new DataTable();
            Int64 SelectedPatientID = 0;
            try
            {
                cboPatientFileNo.SelectedValue = -1;
                AIMS.BLL.Invoice clsInvoice = new Invoice();
                
                CommonFuncs = new CommonFuncs();
                if (txtPatientFileNo.Text.Trim().Length > 0)
                {
                    dtPatientExist = clsInvoice.PatientValidate(txtPatientFileNo.Text);

                    if (dtPatientExist.Rows.Count == 0)
                    {
                        MessageBox.Show("The Patient File Number captured does not exists", "Patient File No Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        picValidate1.Visible = false;
                    }
                    else
                    {
                        if (dtPatientExist.Rows[0]["PATIENT_FILE_ACTIVE_YN"].ToString() == "N")
                        {
                            CommonFuncs.DisplayMessage("This patient file has been closed, please check with your supervisor", AIMS.Common.CommonTypes.MessagType.Warning);
                            tabPayment.Enabled = false;
                            //picValidate1.Visible = false;
                        }
                        else
                        {
                            errProv.SetError(txtPatientFileNo, "");
                            txtPatientGuarantor.Text = dtPatientExist.Rows[0][1].ToString(); 
                            //picValidate1.Visible = true;
                            txtAmountPaid.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please capture Patient File number", "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.ErrorLogger("Verifying Patient failed: " + ex.Message);
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Int64 LastPatient = 0;
            if (aimsComboLookup1.lstItems.SelectedIndex != null && aimsComboLookup1.lstItems.SelectedIndex > 0)
            {
                LastPatient = aimsComboLookup1.lstItems.SelectedIndex;
            }
            try
            {
                if (ValidateControls())
                {
                    SavePaymentDetails();
                    if (LastPatient >0 )
                    {
                        aimsComboLookup1.lstItems.SelectedIndex = (int)LastPatient;
                    }                    
                }
            }
            catch (System.Exception ex)
            {
                //CommonFuncs.ErrorLogger("Saving Payment Details Failed, Please contact system administrator. " + ex.Message);
            }
        }

        public bool ValidateControls()
        {
            bool returnVal = true;

            errProv.Clear();

            if (this.cboPatientFileNo.SelectedItem != null)
            {
                if (this.cboPatientFileNo.SelectedValue.ToString() == "")
                {
                    errProv.SetError(cboPatientFileNo, "Please select Patient File No");
                    cboPatientFileNo.Focus();
                    returnVal = false;
                }
            }

            if (this.txtAmountPaid.Text.Trim().Length == 0)
            {
                errProv.SetError(txtAmountPaid, "Please enter Amount Paid");
                txtAmountPaid.Focus();
                returnVal = false;
            }

            if (this.txtReceiptNo.Text.Trim().Length == 0)
            {
                errProv.SetError(txtReceiptNo, "Please enter Receipt No");
                txtReceiptNo.Focus();
                returnVal = false;
            }

            if (this.txtDateofReceipt.Text.Trim().Length == 0)
            {
                errProv.SetError(txtDateofReceipt, "Please enter Date Of Receipt");
                txtDateofReceipt.Focus();
                returnVal = false;
            }

            if (this.cboPaymentMethod.SelectedItem == null )
            {                
                errProv.SetError(cboPaymentMethod, "Please enter Method Of Payment");
                cboPaymentMethod.Focus();
                returnVal = false;                                
            }

            if (this.cboPaymentMethod.SelectedItem != null)
            {
                if (this.cboPaymentMethod.Text == "")
                {
                    errProv.SetError(cboPaymentMethod, "Please enter Method Of Payment");
                    cboPaymentMethod.Focus();
                    returnVal = false;
                }
                else
                {
                    if (this.cboPaymentMethod.Text.ToUpper() == "CHEQUE" && txtChequeNo.Text.Trim().Length == 0)
                    {
                        errProv.SetError(txtChequeNo, "Please enter Cheque No");
                        txtChequeNo.Focus();
                        returnVal = false;                        
                    }
                }
            }

            double tmp3;
            if (!double.TryParse(txtAmountPaid.Text.Trim(), out tmp3))
            {
                errProv.SetError(txtAmountPaid, "Amount Paid is not valid currency value.");
                txtAmountPaid.Focus();
                returnVal = false;                        
            }

            DataTable dtPatientExist = new DataTable();
            AIMS.BLL.Invoice clsInvoice = new Invoice();

            if (txtPatientFileNo.Text.Trim().Length > 0)
            {
                dtPatientExist = clsInvoice.PatientValidate(txtPatientFileNo.Text);

                if (dtPatientExist.Rows.Count == 0)
                {
                    errProv.SetError(btnPatientFileNoCheck, "Please capture a valid patient file");
                    returnVal = false;
                }
                else
                {
                    txtPatientGuarantor.Text = dtPatientExist.Rows[0][1].ToString();
                }
            }
            if (returnVal == true)
            {
                errProv.Clear();
            }

            return returnVal;
        }

        private void EnableControls()
        {
            this.txtAmountPaid.Enabled = true;
            txtBankTransRefNo.Enabled = true;
            txtChequeNo.Enabled = true;
            txtCreditCard.Enabled = true;
            txtInvoiceNo.Enabled = true;
            txtPatientFileNo.Enabled = true;
            txtPatientGuarantor.Enabled = true;
            txtPaymentNotice.Enabled = true;
            txtReceiptNo.Enabled = true;
            cboPaymentMethod.Enabled = true;
            btnSave.Enabled = UserAllowed("3");
            txtDateofReceipt.Enabled = true;
            txtRenderDate.Enabled = true;

            btnSave.Enabled = UserAllowed("3");
        }

        private void DisableControls()
        {
            this.txtAmountPaid.Enabled = false;
            txtBankTransRefNo.Enabled = false;
            txtChequeNo.Enabled = false;
            txtCreditCard.Enabled = false;
            txtInvoiceNo.Enabled = false;
            txtPatientFileNo.Enabled = false;
            txtPatientGuarantor.Enabled = false;
            txtPaymentNotice.Enabled = false;
            txtReceiptNo.Enabled = false;
            cboPaymentMethod.Enabled = false;
            btnSave.Enabled = UserAllowed("3");
            txtDateofReceipt.Enabled = false;
            txtRenderDate.Enabled = false;
            btnSave.Enabled = UserAllowed("3");
        }

        private bool SavePaymentDetails()
        {
            
            bool bSaved = false;
            AIMS.BLL.Payment clsPayment = new Payment();
            string savePatientFileNo = "";
            try
            {
                _payment = new Payment();

                if (cboPatientFileNo.SelectedIndex == -1)
                {
                    savePatientFileNo = txtPatientFileNo.Text;
                }
                else
                {
                    savePatientFileNo = cboPatientFileNo.SelectedValue.ToString();
                }

                if (lblPaymentID.Text.Trim().Length > 0)
                {
                    _payment.PaymentID = System.Convert.ToInt32(lblPaymentID.Text);
                }

                if (chkLockPayment.Checked)
                {
                    _payment.PaymentLockedYN = "Y";
                }
                else
                { 
                    _payment.PaymentLockedYN = "N";
                }
                _payment.PaymentMethodID = System.Convert.ToInt32(cboPaymentMethod.SelectedValue);
                _payment.PaymentProcessedYN = "Y";
                _payment.ReceiptNo = txtReceiptNo.Text.Trim();
                _payment.RenderDate = txtRenderDate.Text;
                _payment.GuarantorName = txtPatientGuarantor.Text;
                _payment.InvoiceNo = txtInvoiceNo.Text.Trim();
                _payment.LoggedOnUser = UserID;
                _payment.Notices = txtPaymentNotice.Text.Trim();
                _payment.PatientFileNo = txtPatientFileNo.Text;
                _payment.ChequeNo = txtChequeNo.Text.Trim();
                _payment.CreditCardNo = txtCreditCard.Text.Trim();
                _payment.DateOfReceipt = txtDateofReceipt.Text;
                _payment.BankTransferRefNo = txtBankTransRefNo.Text.Trim();
                _payment.AmountPaid = txtAmountPaid.Text;
                
                if (chkForex.Checked) { _payment.ForexPayment = "Y"; } else { _payment.ForexPayment = "N"; }
                if (chkInsuranceOverPymt.Checked) { _payment.InsuranceOverPayment = "Y"; } else { _payment.InsuranceOverPayment = "N"; }
                if (chkInsuranceShortPymt.Checked) { _payment.InsuranceShortPayment = "Y"; } else { _payment.InsuranceShortPayment = "N"; }

                if (chkDoctorOwing.Checked)
                { 
                    _payment.DoctorOwing = "Y";
                    _payment.DoctorOwingInvoice = DoctorOwingInvoiceNo.Trim();
                    Invoice _invoice = new Invoice();
                    DataTable dtPatientInvoiceExist = _invoice.PatientInvoiceNoVerify(txtPatientFileNo.Text.Trim(), txtDoctorInvoiceNo.Text);

                    if (dtPatientInvoiceExist.Rows.Count > 0)
                    {
                        _payment.DoctorOwingInvoice = dtPatientInvoiceExist.Rows[0]["INVOICE_ID"].ToString();
                    }
                    dtPatientInvoiceExist.Dispose();
                    _invoice = null;
                } 
                else 
                { 
                    _payment.DoctorOwing = "N"; 
                    _payment.DoctorOwingInvoice = ""; 
                }

                if (chkLateSubmissionPymt.Checked) 
                { 
                    _payment.LateSubmissionPayment = "Y";
                    _payment.LateSubmissionInvoice = txtLateSubmissionInvNo.Text.Trim();
                    if (txtLateSubmissionInvNo.Text.Trim().Length != 0)
                    {
                        Invoice _invoice = new Invoice();
                        DataTable dtPatientInvoiceExist = _invoice.PatientInvoiceNoVerify(txtPatientFileNo.Text.Trim(),txtLateSubmissionInvNo.Text,"Y");

                        if (dtPatientInvoiceExist.Rows.Count > 0)
                        {
                            _payment.LateSubmissionInvoice = dtPatientInvoiceExist.Rows[0]["INVOICE_ID"].ToString();
                            dtPatientInvoiceExist.Dispose();
                            _invoice = null;
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error , "Late Submission Invoice-No incorrect or not linked to Patient File, Please re-capture and try again.");
                            //MessageBox.Show(, "Late Submission Load Fault", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dtPatientInvoiceExist.Dispose();
                            txtLateSubmissionInvNo.Focus();
                            _invoice = null;
                            LoadSupplierInfo = false;
                            bSaved = false;
                            return bSaved;
                        }                          
                    }                                     
                } 
                else 
                { 
                    _payment.LateSubmissionPayment = "N"; 
                }
 
                _payment.LoggedOnUser = UserID;

                bSaved = _payment.SavePaymentDetails();

                if (bSaved)
                {
                    MessageBox.Show("Payment added successfully", "Payment Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (chkLateSubmissionPymt.Checked && chkInsuranceOverPymt.Checked)
                    {
                        UpdateLateInvoiceOverPymt = true;
                    }
                    else
                    {
                        UpdateLateInvoiceOverPymt = false;
                    }                    
                    LoadSupplierInfo = true;
                    lblPaymentID.Text = _payment.PaymentID.ToString();
                    LoadPayments();
                    
                    LoadPaymentDetails(lblPaymentID.Text);
                    LoadSupplierInfo = false;

                }
                else
                {
                    MessageBox.Show("Payment NOT added successfully", "Payment Load Fault", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Payment Details not safed successfully. Error : " + ex.Message);
            }
            finally
            {
                clsPayment = null;
            }
            return bSaved;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            try
            {
                tabPayment.Enabled = false;
                LoadPayments();
                LoadPaymentMethods();
                DataTable dsPatientFiles = CommonFuncs.LoadPatientFiles();
                cboPatientFileNo.Items.Insert(0, "");
                cboPatientFileNo.DataSource = dsPatientFiles;
                cboPatientFileNo.DisplayMember = "PATIENT_FILE_NO";
                cboPatientFileNo.ValueMember = "PATIENT_ID";
                cboPatientFileNo.SelectedIndex = -1;
                
                //dsPatientFiles.Dispose();
                btnAdd.Enabled = UserAllowed("3");
                btnSave.Enabled = UserAllowed("3");
            }
            finally 
            {
                
            }
        }

        /// <summary>
        /// This function loads the dropdown with patient information
        /// </summary>
        private void LoadPayments()
        {
            try
            {
                aimsComboLookup1.DataField1 = "RECEIPT_NO";
                aimsComboLookup1.DataField2 = "PAYMENT_ID";
                aimsComboLookup1.OrderByField = "RECEIPT_NO";            
                aimsComboLookup1.TableName = "AIMS_PAYMENTS_VW";
                aimsComboLookup1.ItemsLoaded = 50;

                aimsComboLookup1.Initialise("");
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void btnInvoiceNoCheck_Click(object sender, EventArgs e)
        {
            DataTable dtInvoiceExist = new DataTable();
            AIMS.BLL.Payment clsPayment = new Payment();
            try
            {
                _payment = new Payment();
                if ((txtInvoiceNo.Text.Trim().Length > 0) && (txtPatientFileNo.Text.Trim().Length > 0))
                {
                    dtInvoiceExist = _payment.InvoiceNoValidate(txtInvoiceNo.Text.Trim(),txtPatientFileNo.Text.Trim());
                    if (dtInvoiceExist.Rows.Count == 0)
                    {
                        picValidate2.Visible = false;
                        MessageBox.Show("Invoice No captured does not exists or not linked to this patient file", "Invoice No Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        errProv.SetError(txtInvoiceNo, "");
                        //txtInvoiceNo.Text = dtInvoiceExist.Rows[0][0].ToString();
                        //picValidate2.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please capture Patient-File-No and Invoice-No", "Invoice No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                //CommonFuncs.ErrorLogger("Verifying Invoice No failed: " + ex.Message);
                throw;
            }
            finally
            {
                clsPayment  = null;
                dtInvoiceExist.Dispose();
            }
        }

        private void LoadPaymentMethods()
        {
            try
            {
                DataTable dtPaymentMethods = new DataTable();
                dtPaymentMethods = commonFuncs.GetPaymentMethods();

                if (dtPaymentMethods.Rows.Count > 0)
                {
                    cboPaymentMethod.DataSource = dtPaymentMethods;
                    cboPaymentMethod.DisplayMember = "PAYMENT_METHOD";
                    cboPaymentMethod.ValueMember = "PAYMENT_METHOD_ID";
                }
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Patient list.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblPaymentID.Text = "";
            ClearControls();
            EnableControls();
            tabPayment.Enabled = true;
            txtPatientFileNo.Focus();            
        }

        private void ClearControls()
        {
            lblPaymentID.Text = "";
            this.txtAmountPaid.Text = "";
            txtBankTransRefNo.Text = "";
            txtChequeNo.Text = "";
            txtCreditCard.Text = "";
            txtInvoiceNo.Text = "";
            txtPatientFileNo.Text = "";
            txtPatientGuarantor.Text = "";
            txtPaymentNotice.Text = "";
            txtReceiptNo.Text = "";
            cboPaymentMethod.SelectedIndex = 0;
            btnSave.Enabled = UserAllowed("3");
            txtDateofReceipt.Enabled = true;
            txtRenderDate.Enabled = true;
            btnSave.Enabled = UserAllowed("3");
            picValidate1.Visible = false;
            picValidate2.Visible = false;
            txtDateofReceipt.Text = "";
            infoText.Text = "";
            txtRenderDate.Text = "";
            cboPaymentMethod.SelectedIndex = -1;
            picValidate1.Visible = false ;
            picValidate2.Visible = false ;
            if (cboPatientFileNo.SelectedItem != null)
            {
                cboPatientFileNo.SelectedIndex = -1;
            }
            lblAmountPaid.Text = "";
            LoadSupplierInfo = false;
            chkInsuranceOverPymt.Checked = false;
            chkForex.Checked = false;
            chkInsuranceShortPymt.Checked = false;
            chkDoctorOwing.Checked = false;
            chkLateSubmissionPymt.Checked = false;
            txtDoctorInvoiceNo.Text = "";
            txtLateSubmissionInvNo.Text = "";            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (aimsComboLookup1.lstItems.SelectedIndex != -1)
            {
                LoadSupplierInfo = true;
                LoadPaymentDetails();
                LoadSupplierInfo = false;
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select a payment receipt from the list");
            }
        }

        private void LoadPaymentDetails()
        {
            AIMS.BLL.Payment clsPayment = new Payment();
            try
            {
                ClearControls();
                LoadSupplierInfo = true;
                cboPatientFileNo.Focus();
                _payment = clsPayment.GetPaymentDetails(aimsComboLookup1.lstItems.SelectedValue.ToString());

                if (_payment != null)
                {
                    LoadSupplierInfo = true;
                    //picValidate1.Visible = true;
                    //picValidate2.Visible = true;
                    tabPayment.Enabled = true;
                    lblPaymentID.Text = _payment.PaymentID.ToString();

                    txtAmountPaid.Text = _payment.AmountPaid;

                    if (txtAmountPaid.Text.Trim().Length > 0 )
                    {
                        decimal txtAmtPaid = System.Convert.ToDecimal(txtAmountPaid.Text);
                        lblAmountPaid.Text = "(" + txtAmtPaid.ToString("C") + ")";
                    }
                    txtDoctorInvoiceNo.Text = _payment.DoctorOwingInvoice;
                    txtBankTransRefNo.Text = _payment.BankTransferRefNo;
                    txtChequeNo.Text = _payment.ChequeNo;
                    txtCreditCard.Text = _payment.CreditCardNo;
                    txtInvoiceNo.Text = _payment.InvoiceNo;
                    txtPatientFileNo.Text = _payment.PatientFileNo;
                    cboPatientFileNo.Text = _payment.PatientFileNo;
                    txtPatientGuarantor.Text = _payment.GuarantorName;
                    txtPaymentNotice.Text = _payment.Notices;
                    txtReceiptNo.Text = _payment.ReceiptNo;
                    if (_payment.PaymentMethodID > 0)
                    {
                        cboPaymentMethod.SelectedValue = _payment.PaymentMethodID;
                    }

                    txtRenderDate.Text = _payment.RenderDate;
                    txtDateofReceipt.Text = _payment.DateOfReceipt;

                    btnSave.Enabled = UserAllowed("3");

                    if (_payment.PaymentLockedYN.ToString() == "Y")
                    {
                        DisableControls();
                        chkLockPayment.Checked = true;
                        infoText.Text = "Payment Status: LOCKED";
                    }
                    else
                    {
                        EnableControls();
                        chkLockPayment.Checked = false;
                        infoText.Text = "Payment Status: OPEN";                        
                    }

                    if (_payment.ForexPayment == "Y") { chkForex.Checked = true; } else { chkForex.Checked = false; }
                    if (_payment.InsuranceOverPayment == "Y") { chkInsuranceOverPymt.Checked = true; } else { chkInsuranceOverPymt.Checked = false; }
                    if (_payment.InsuranceShortPayment == "Y") { chkInsuranceShortPymt.Checked = true; } else { chkInsuranceShortPymt.Checked = false; }
                    if (_payment.DoctorOwing == "Y") 
                    { 
                        chkDoctorOwing.Checked = true; 
                        txtDoctorInvoiceNo.Text = _payment.DoctorOwingInvoice; 
                    } 
                    else 
                    { 
                        chkDoctorOwing.Checked = false; 
                        txtDoctorInvoiceNo.Text = ""; 
                    }
                    if (_payment.LateSubmissionPayment == "Y") 
                    { 
                        chkLateSubmissionPymt.Checked = true; 
                        txtLateSubmissionInvNo.Text = _payment.LateSubmissionInvoice; 
                    } 
                    else 
                    { 
                        chkLateSubmissionPymt.Checked = false; 
                        txtLateSubmissionInvNo.Text = ""; 
                    }                    
                }
                cboPatientFileNo.Focus();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading payment details, Please try again");
                //CommonFuncs.ErrorLogger("");
                clsPayment = null;
            }
        }

        private void LoadPaymentDetails(string PaymentID)
        {
            AIMS.BLL.Payment clsPayment = new Payment();
            try
            {
                ClearControls();
                
                cboPatientFileNo.Focus();
                _payment = clsPayment.GetPaymentDetails(PaymentID);

                if (_payment != null)
                {
                    LoadSupplierInfo = true;
                    //picValidate1.Visible = true;
                    //picValidate2.Visible = true;
                    tabPayment.Enabled = true;
                    lblPaymentID.Text = _payment.PaymentID.ToString();
                    txtDoctorInvoiceNo.Text = _payment.DoctorOwingInvoice;
                    txtAmountPaid.Text = _payment.AmountPaid;

                    if (txtAmountPaid.Text.Trim().Length > 0)
                    {
                        decimal txtAmtPaid = System.Convert.ToDecimal(txtAmountPaid.Text);
                        lblAmountPaid.Text = "(" + txtAmtPaid.ToString("C") + ")";
                    }

                    txtBankTransRefNo.Text = _payment.BankTransferRefNo;
                    txtChequeNo.Text = _payment.ChequeNo;
                    txtCreditCard.Text = _payment.CreditCardNo;
                    txtInvoiceNo.Text = _payment.InvoiceNo;
                    txtPatientFileNo.Text = _payment.PatientFileNo;
                    cboPatientFileNo.Text = _payment.PatientFileNo;
                    txtPatientGuarantor.Text = _payment.GuarantorName;
                    txtPaymentNotice.Text = _payment.Notices;
                    txtReceiptNo.Text = _payment.ReceiptNo;
                    if (_payment.PaymentMethodID > 0)
                    {
                        cboPaymentMethod.SelectedValue = _payment.PaymentMethodID;
                    }

                    txtRenderDate.Text = _payment.RenderDate;
                    txtDateofReceipt.Text = _payment.DateOfReceipt;

                    btnSave.Enabled = UserAllowed("3");

                    if (_payment.ForexPayment == "Y")           { chkForex.Checked = true ;}                else { chkForex.Checked = false ; }
                    if (_payment.InsuranceOverPayment == "Y")   { chkInsuranceOverPymt.Checked = true; }    else { chkInsuranceOverPymt.Checked = false; }
                    if (_payment.InsuranceShortPayment == "Y")  { chkInsuranceShortPymt.Checked = true; }   else { chkInsuranceShortPymt.Checked = false; }
                    if (_payment.DoctorOwing == "Y") { chkDoctorOwing.Checked = true; } else { chkDoctorOwing.Checked = false; }
                    if (_payment.LateSubmissionPayment == "Y") { chkLateSubmissionPymt.Checked = true; } else { chkLateSubmissionPymt.Checked = false; }
                    
                    if (_payment.PaymentLockedYN.ToString() == "Y")
                    {
                        DisableControls();
                        chkLockPayment.Checked = true;
                        infoText.Text = "Payment Status: LOCKED";
                    }
                    else
                    {
                        EnableControls();
                        chkLockPayment.Checked = false;
                        infoText.Text = "Payment Status: OPEN";
                    }
                }
                cboPatientFileNo.Focus();
            }
            catch (System.Exception ex)
            {
                //CommonFuncs.ErrorLogger("");
                clsPayment = null;
            }
        }

        protected void aimsComboLookup1_DblClicked()
        {
            //Add code here to load Invoice details
            btnSelect_Click(null, null);
        }

        private void txtPatientFileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatientFileNo_LostFocus(object sender, System.EventArgs e)
        {
            //DataTable dtPatientExist = new DataTable();
            //AIMS.BLL.Payment clsInvoice = new Payment();
            //try
            //{
            //    _payment = new Payment();
            //    if (txtPatientFileNo.Text.Trim().Length > 0)
            //    {
            //        dtPatientExist = _payment.PatientValidate(txtPatientFileNo.Text);
            //        if (dtPatientExist.Rows.Count == 0)
            //        {
            //            picValidate1.Visible = false;
            //            errProv.SetError(txtPatientFileNo, "");
            //            MessageBox.Show("Patient File Number captured does not exists", "Patient File No Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        else
            //        {
            //            errProv.SetError(txtPatientFileNo, "");
            //            txtPatientGuarantor.Text = dtPatientExist.Rows[0][1].ToString();
            //            picValidate1.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please capture Patient File number", "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    //CommonFuncs.ErrorLogger("Verifying Patient failed: " + ex.Message);
            //    throw;
            //}
            //finally
            //{
            //    clsInvoice = null;
            //}          
        }

        private void txtInvoiceNo_LostFocus(object sender, System.EventArgs e)
        {
            //DataTable dtInvoiceExist = new DataTable();
            //AIMS.BLL.Payment clsPayment = new Payment();
            //try
            //{
            //    _payment = new Payment();
            //    if ((txtInvoiceNo.Text.Trim().Length > 0) && (txtPatientFileNo.Text.Trim().Length > 0))
            //    {
            //        dtInvoiceExist = _payment.InvoiceNoValidate(txtInvoiceNo.Text.Trim(), txtPatientFileNo.Text.Trim());
            //        if (dtInvoiceExist.Rows.Count == 0)
            //        {
            //            picValidate2.Visible = false;
            //            MessageBox.Show("Invoice No captured does not exists or not linked to this patient file", "Invoice No Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        else
            //        {
            //            errProv.SetError(txtInvoiceNo, "");
            //            //txtInvoiceNo.Text = dtInvoiceExist.Rows[0][0].ToString();
            //            picValidate2.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please capture Patient-File-No and Invoice-No", "Invoice No", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    //CommonFuncs.ErrorLogger("Verifying Invoice No failed: " + ex.Message);
            //    throw;
            //}
            //finally
            //{
            //    clsPayment = null;
            //    dtInvoiceExist.Dispose();
            //}
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRenderDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();

            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtRenderDate.Text = frmCal.StartDate.ToShortDateString();
            }
            
            txtRenderDate.Focus();
        }

        private void txtDateofReceipt_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtDateofReceipt.Text = frmCal.StartDate.ToShortDateString();
            }
            
            txtDateofReceipt.Focus();

        }

        private void lnklblReceiptDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDateofReceipt_DoubleClick(null, null);
        }

        private void lnklblRenderDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtRenderDate_DoubleClick(null, null);
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;
            string NewInvoiceAmt = "";

            try
            {
                if (txtAmountPaid.Text.Trim().Length > 0)
                {
                    if (!double.TryParse(txtAmountPaid.Text, out tmp))
                    {
                        if (txtAmountPaid.Text.Substring(txtAmountPaid.Text.Trim().Length - 1, 1) != ".")
                        {
                            if (!double.TryParse(txtAmountPaid.Text.Trim(), out tmp1))
                            {
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            } 
        }

        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // allows only numbers, decimals and control characters
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && this.Text.Contains("."))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '-' && this.Text.Contains("-"))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && this.Text.Length < 1)
                {
                    e.Handled = true;
                }
            }
            catch (System.Exception)
            {
                throw;
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

        private void cboPatientFileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AIMS.BLL.Payment _payment;
            AIMS.Client.CommonFuncs CommonFuncs = new CommonFuncs();
            
            if (cboPatientFileNo.SelectedItem != null)
            {
                if (cboPatientFileNo.SelectedIndex >= 0 && (cboPatientFileNo.SelectedValue.ToString() != "System.Data.DataRowView" & cboPatientFileNo.Text != "System.Data.DataRowView"))
                {
                    DataTable dtPatientExist = new DataTable();
                    try
                    {
                        _payment = new Payment();
                        CommonFuncs = new CommonFuncs();
                        txtPatientFileNo.Text = cboPatientFileNo.Text.ToString();
                        if (txtPatientFileNo.Text.Trim().Length > 0)
                        {
                            dtPatientExist = _payment.PatientValidate(txtPatientFileNo.Text);
                            
                            if (dtPatientExist.Rows.Count == 0)
                            {
                                MessageBox.Show("The Patient File Number captured does not exists", "Patient File No Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                picValidate1.Visible = false;
                            }
                            else
                            {
                                if (dtPatientExist.Rows[0]["PATIENT_FILE_ACTIVE_YN"].ToString() == "N")
                                {
                                    CommonFuncs.DisplayMessage("This patient file has been closed, please check with your supervisor", AIMS.Common.CommonTypes.MessagType.Warning);
                                    tabPayment.Enabled = false;
                                    //picValidate1.Visible = false;
                                }
                                else
                                {
                                    errProv.SetError(txtPatientFileNo, "");
                                    txtPatientGuarantor.Text = dtPatientExist.Rows[0][1].ToString();
                                    //picValidate1.Visible = true;
                                    txtAmountPaid.Focus();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please capture Patient File number", "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        CommonFuncs.ErrorLogger("Verifying Patient failed: " + ex.Message);
                        throw;
                    }
                }
                else
                {
                    //txtPatientFileNo.Text = "";
                    txtPatientGuarantor.Text = "";
                    //txtPatientName.Text = "";
                    //picValidate1.Visible = false;
                }
            }
            else
            {
                //txtPatientFileNo.Text = "";
                txtPatientGuarantor.Text = "";
                //txtPatientName.Text = "";
                picValidate1.Visible = false;
            }
            picValidate1.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearControls();
          
            DataTable dsPatientFiles = CommonFuncs.LoadPatientFiles();
            
            cboPatientFileNo.DataSource = dsPatientFiles;
            cboPatientFileNo.DisplayMember = "PATIENT_FILE_NO";
            cboPatientFileNo.ValueMember = "PATIENT_ID";
            cboPatientFileNo.SelectedIndex = -1;
        }

        private void txtDateofReceipt_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkForex_CheckedChanged(object sender, EventArgs e)
        {
            if (chkForex.Checked )
            {
                chkInsuranceShortPymt.Checked = false;
                chkInsuranceOverPymt.Checked = false;
                chkDoctorOwing.Checked = false;
                txtDoctorInvoiceNo.Text = "";
                chkLateSubmissionPymt.Checked = false;
                txtLateSubmissionInvNo.Enabled = false;
                txtLateSubmissionInvNo.Text = "";
                btnLateSubmissionInvCheck.Enabled = false;
            }
        }

        private void chkInsuranceOverPymt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInsuranceOverPymt.Checked)
            {
                chkInsuranceShortPymt.Checked = false;
                chkForex.Checked = false;
                chkDoctorOwing.Checked = false;
                txtDoctorInvoiceNo.Text = "";
                //chkLateSubmissionPymt.Checked = false;
                if (!chkLateSubmissionPymt.Checked && !UpdateLateInvoiceOverPymt)
                {
                    txtLateSubmissionInvNo.Enabled = false;
                    txtLateSubmissionInvNo.Text = "";
                }

                btnLateSubmissionInvCheck.Enabled = false;
            }
        }

        private void chkInsuranceShortPymt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInsuranceShortPymt.Checked)
            {
                chkInsuranceOverPymt.Checked = false;
                chkForex.Checked = false;
                chkDoctorOwing.Checked = false;
                txtDoctorInvoiceNo.Text = "";
                chkLateSubmissionPymt.Checked = false;
                txtLateSubmissionInvNo.Enabled = false;
                txtLateSubmissionInvNo.Text = "";
                btnLateSubmissionInvCheck.Enabled = false;
            }
        }

        private void gpxPaymentSearch_Enter(object sender, EventArgs e)
        {

        }

        private void chkDoctorOwing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDoctorOwing.Checked)
            {
                if (!LoadSupplierInfo)
                {
                    chkInsuranceOverPymt.Checked = false;
                    chkForex.Checked = false;
                    chkInsuranceShortPymt.Checked = false;
                    chkLateSubmissionPymt.Checked = false;
                    txtLateSubmissionInvNo.Enabled = false;
                    txtLateSubmissionInvNo.Text = "";
                    btnLateSubmissionInvCheck.Enabled = false;

                    DoctorOwingInvoiceNo = "";

                    InvoiceNoInputBox("Invoice No", "Doctor-Owing Invoice No", ref DoctorOwingInvoiceNo);
                    if (DoctorOwingInvoiceNo.Trim().Length == 0)
                    {
                        chkDoctorOwing.Checked = false;
                        txtDoctorInvoiceNo.Text = "";
                    }
                    else
                    {
                        txtDoctorInvoiceNo.Text = DoctorOwingInvoiceNo;
                        if (txtPatientFileNo.Text.Trim().Length == 0 )
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please select/capture Doctor-Owing File No.");
                        }
                        else
                        {
                            Invoice _invoice = new Invoice();
                            DataTable dtPatientInvoiceExist = _invoice.PatientInvoiceNoVerify(txtPatientFileNo.Text.Trim() , DoctorOwingInvoiceNo.Trim());

                            if (dtPatientInvoiceExist.Rows.Count == 0)
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error ,"Invoice-No does not exist or not linked to this file, Please capture again.");
                                chkDoctorOwing.Checked = false;
                                txtDoctorInvoiceNo.Text = "";
                                chkDoctorOwing.Focus();
                            }
                            else
                            {
                                txtAmountPaid.Focus();
                                DoctorOwingInvoiceNo = dtPatientInvoiceExist.Rows[0]["INVOICE_ID"].ToString();
                            }
                            dtPatientInvoiceExist.Dispose();
                            _invoice = null;
                        }
                    }                    
                }
                LoadSupplierInfo = false;
            }
            else
            {
                DoctorOwingInvoiceNo = "";
            }
        }

        private void chkLateSubmissionPymt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLateSubmissionPymt.Checked)
            {
                if (!LoadSupplierInfo)
                {
                    //chkInsuranceOverPymt.Checked = false;
                    
                    chkForex.Checked = false;
                    chkInsuranceShortPymt.Checked = false;
                    
                    chkDoctorOwing.Checked = false;
                    txtDoctorInvoiceNo.Text = "";
                    txtLateSubmissionInvNo.Enabled = true;

                    LateSubmissionInvoiceNo  = "";

                    InvoiceNoInputBox("Invoice No", "Late Submission Invoice No", ref LateSubmissionInvoiceNo);
                    if (LateSubmissionInvoiceNo.Trim().Length == 0)
                    {
                        chkLateSubmissionPymt.Checked = false;
                        txtLateSubmissionInvNo.Text = "";
                    }
                    else
                    {
                        txtLateSubmissionInvNo.Text = LateSubmissionInvoiceNo;
                        if (txtPatientFileNo.Text.Trim().Length == 0)
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please select/capture Late-Submission File No.");
                        }
                        else
                        {
                            Invoice _invoice = new Invoice();
                            DataTable dtPatientInvoiceExist = _invoice.PatientInvoiceNoVerify(txtPatientFileNo.Text.Trim(), LateSubmissionInvoiceNo.Trim(),"Y");

                            if (dtPatientInvoiceExist.Rows.Count == 0)
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Late Submission Invoice-No does not exist or not linked to this file, Please capture again.");
                                chkLateSubmissionPymt.Checked = false;
                                txtLateSubmissionInvNo.Text = "";
                                chkLateSubmissionPymt.Focus();
                            }
                            else
                            {
                                txtAmountPaid.Focus();
                                LateSubmissionInvoiceNo = dtPatientInvoiceExist.Rows[0]["INVOICE_ID"].ToString();
                            }
                            dtPatientInvoiceExist.Dispose();
                            _invoice = null;
                        }
                    }
                }
                LoadSupplierInfo = false;
            }
            else
            {
                LateSubmissionInvoiceNo = "";
                txtLateSubmissionInvNo.Text = "";
            }
        }

        public static DialogResult InvoiceNoInputBox(string title, string promptText1, ref string value1)
        {
            try
            {
                Form form = new Form();
                Label label1 = new Label();
                TextBox textBox1 = new TextBox();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label1.Text = promptText1;
                
                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label1.SetBounds(9, 20, 372, 13);
                textBox1.SetBounds(10, 36, 399, 20);
                buttonOk.SetBounds(200, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label1.AutoSize = true;
                textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
                
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonOk.Top = textBox1.Bottom +10 ;
                buttonCancel.Top = textBox1.Bottom + 10;

                form.ClientSize = new Size(420, 120);
                form.Controls.AddRange(new Control[] { label1,  textBox1,  buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value1 = textBox1.Text;
                
                return dialogResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
