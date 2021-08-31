using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using AIMS.Common;
using AIMS.Client;
using AIMS.BLL;
using System.Data.OleDb;
using System.Collections;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;
using System.Drawing;

namespace AIMSClient
{
    public partial class frmInvoices : Form
    {
        
        #region Global Variables
            string _PatientID = string.Empty;
            frmMedicalTreatment frmMed;
            frmComments frmNotes;
            public AIMS.Common.CommonFunctions commonFuncs;
            string _fileClosed = "";
            
            AIMS.BLL.Invoice  _invoice;
        #endregion

        #region "Private Properties"
        string _userName = "";
        string _userID = "";
        bool _SupplierFirstLoad = false;        
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
            set { _userID = value; }
        }
        public bool SupplierFirstLoad
        {
            get { return _SupplierFirstLoad; }
            set { _SupplierFirstLoad = value; }

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

        UserControls.frmCalendar frmCal;
        AIMS.Client.CommonFuncs CommonFuncs = new CommonFuncs();

        public frmInvoices()
        {
            InitializeComponent();
        }

        private void frmInvoices_Resize(object sender, EventArgs e)
        {
            //------------------------
            //this.gpbxPatientSearch.Left = this.Left + 2;
            //this.gpbxPatient.Left = this.Left + 2;
            //this.gpbxPatient.Width = this.ClientSize.Width - 4;
            //this.gpbxPatientSearch.Width = this.ClientSize.Width - 4;
            //this.gpbxPatientSearch.Height = Convert.ToInt32(this.ClientSize.Height * 0.30);
            //this.gpbxPatient.Top = gpbxPatientSearch.Bottom + 2;
            //this.gpbxPatient.Height = Convert.ToInt32(this.ClientSize.Height * 0.62);

            //this.aimsComboLookup1.Top = gpbxPatientSearch.Top + 3;
            //this.aimsComboLookup1.Width = Convert.ToInt32(gpbxPatientSearch.Width * 0.35);
            //this.aimsComboLookup1.Height = Convert.ToInt32(gpbxPatientSearch.Height * 0.8);
            //this.aimsComboLookup1.lstItems.Height = Convert.ToInt32(gpbxPatientSearch.Height * 0.70);

            //this.pnlButtonSearch.Top = aimsComboLookup1.Bottom;
            //this.pnlButtonSearch.Left = aimsComboLookup1.Left;
            //this.pnlButtonSearch.Width = aimsComboLookup1.Width;
            //this.btnDelete.Left = (pnlButtonSearch.Right - (btnDelete.Width + 10));
            //this.btnAddPatient.Left = aimsComboLookup1.Right - (btnAddPatient.Width + 5);//Convert.ToInt32((pnlButtonSearch.Width * 0.5) - 30);
            //btnSelect.Left = pnlButtonSearch.Left;

            //this.tabControl1.Width = this.gpbxPatient.Width - 20;
            //this.tabControl1.Height = Convert.ToInt32(this.gpbxPatient.Height * 0.92);

            //this.pnlPatientMain.Height = Convert.ToInt32(tabPatients.Height * 0.95);
            //this.pnlPatientMain.Width = Convert.ToInt32(tabPatients.Width * 0.95);

            //this.pnlButtons.Top = this.gpbxPatient.Bottom;
            //this.btnSave.Left = Convert.ToInt32(this.ClientSize.Width * 0.35);
            //this.btnClose.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);
            //this.btnUnlockFile.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);
            //this.pnlButtons.Width = this.gpbxPatient.Width;
            //------------------------

            this.gpxInvoiceSearch.Left = this.Left + 2;
            this.gpxInvoice.Left = this.Left + 2;
            this.gpxInvoice.Width = this.ClientSize.Width - 4;
            this.gpxInvoiceSearch.Width = this.ClientSize.Width - 4;
            this.gpxInvoiceSearch.Height = Convert.ToInt32(this.ClientSize.Height * 0.30);
            this.gpxInvoice.Top = gpxInvoiceSearch.Bottom + 2;
            this.gpxInvoice.Height = Convert.ToInt32(this.ClientSize.Height * 0.62);

            ////////////this.aimsComboLookup1.Top = gpxInvoiceSearch.Top + 3;
            ////////////this.aimsComboLookup1.Width = Convert.ToInt32(gpxInvoiceSearch.Width * 0.35);
            ////////////this.aimsComboLookup1.Height = Convert.ToInt32(gpxInvoiceSearch.Height * 0.8);
            ////////////this.aimsComboLookup1.lstItems.Height = Convert.ToInt32(gpxInvoiceSearch.Height * 0.30);

            ////////////this.pnlSearchButtons.Top = aimsComboLookup1.Bottom;
            ////////////this.pnlSearchButtons.Left = aimsComboLookup1.Left;
            ////////////this.pnlSearchButtons.Width = aimsComboLookup1.Width;
            ////////////this.btnDelete.Left = (pnlSearchButtons.Right - (btnDelete.Width + 10));
            ////////////this.btnAdd.Left = aimsComboLookup1.Right - (btnAdd.Width + 5);//Convert.ToInt32((pnlButtonSearch.Width * 0.5) - 30);
            ////////////btnSelect.Left = pnlSearchButtons.Left;

            this.aimsComboLookup1.Top = gpxInvoiceSearch.Top + 10;
            this.aimsComboLookup1.Width = Convert.ToInt32(gpxInvoiceSearch.Width * 0.35);
            this.aimsComboLookup1.Height = Convert.ToInt32(gpxInvoiceSearch.Height * 0.80);
            this.aimsComboLookup1.lstItems.Height = Convert.ToInt32(gpxInvoiceSearch.Height * 0.58);

            pnlSearchButtons.Top = gpxInvoiceSearch.Height - 30;
            pnlSearchButtons.Height = 27;

            this.pnlSearchButtons.Left = aimsComboLookup1.Left;
            this.pnlSearchButtons.Width = aimsComboLookup1.Width - 10;

            this.btnDelete.Left = (pnlSearchButtons.Right - (btnDelete.Width + 10));
            this.btnAdd.Left = aimsComboLookup1.Right - (btnAdd.Width + 20);//Convert.ToInt32((pnlButtonSearch.Width * 0.5) - 30);
            this.btnSelect.Left = pnlSearchButtons.Left;

            this.tabInvoices.Width = this.gpxInvoice.Width - 20;
            this.tabInvoices.Height = Convert.ToInt32(this.gpxInvoice.Height * 0.92);

            this.pnlSearchButtons.Height = Convert.ToInt32(tabInvoices.Height * 0.95);
            this.pnlSearchButtons.Width = Convert.ToInt32(tabInvoices.Width * 0.95);

            this.pnlButtons.Top = this.gpxInvoice.Bottom;
            this.pnlButtons.Width = this.gpxInvoice.Width;
            //#BM - Removed this
            this.btnSave.Left = Convert.ToInt32(this.ClientSize.Width * 0.35);
            this.btnClose.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);
            btnUnlockInvoice.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);

            this.pnlButtons.Width = this.gpxInvoice.Width;

            btnRefresh.Left = btnSelect.Width + 20;
            btnRefresh.Top = btnSelect.Top;
            btnRefresh.Width = btnSelect.Width;
        }

        private void frmInvoices_Load(object sender, EventArgs e)
        {
            try
            {
                chkCancel.Enabled = false;
                btnAddNewTreatment.Enabled = false;
                dtDateAdmitted.Text = "";
                commonFuncs = new AIMS.Common.CommonFunctions();
                
                //cboSupplier.Items.Clear();
                //cboSupplier.DataSource = commonFuncs.GetSuppliers();
                LoadSuppliers();

                SupplierFirstLoad = true;
                //cboSupplier.DisplayMember = "SUPPLIER_NAME";
                //cboSupplier.ValueMember = "SUPPLIER_ID";
                //cboSupplier.SelectedIndex = -1;
                cboService.Items.Insert(0, " ");
                SupplierFirstLoad = false;
    
                DataTable dtSupplierTypes = new DataTable();
                dtSupplierTypes = commonFuncs.GetSupplierTypes();

                if (dtSupplierTypes.Rows.Count > 0)
                {
                    cboService.DataSource = dtSupplierTypes;
                    cboService.DisplayMember = "SUPPLIER_TYPE_DESC";
                    cboService.ValueMember = "SUPPLIER_TYPE_ID";
                    cboService.SelectedIndex = -1;
                }

                cboPatientFileNo.Items.Insert(0, " ");

                DataTable dsPatientFiles = CommonFuncs.LoadPatientFiles();
                cboPatientFileNo.Items.Insert(0, "");
                cboPatientFileNo.DataSource = dsPatientFiles;
                cboPatientFileNo.DisplayMember = "PATIENT_FILE_NO";
                cboPatientFileNo.ValueMember = "PATIENT_ID";
                cboPatientFileNo.SelectedIndex = -1;

                LoadInvoices();
                MedicalTreatmentSetup();

                tabInvoices.Enabled = false;

                btnSave.Enabled = false;
                btnUnlockInvoice.Enabled = false;
                btnAdd.Enabled  = false;

                if (UserAllowed("2")) { btnAdd.Enabled = true ;}                             
        }
            catch (System.Exception ex)
            {                
                throw;
            }
        }

        private void frmInvoices_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 360);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);

           // System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 180);
           //5 e.Graphics.FillRectangle(lb, this.ClientRectangle);
        }

        private void gpxInvoiceSearch_Enter(object sender, EventArgs e)
        {
        }

        protected void aimsComboLookup1_DblClicked()
        {
            //Add code here to load Invoice details
            btnSelect_Click(null, null);
        }

        /// <summary>
        /// This method resets all the controls
        /// </summary>
        private void ClearControls()
        {
            txtInvoiceAmount.Text = "";
            txtInvoiceNo.Text = "";
            txtPatientFileNo.Text = "";
            txtPatientName.Text = "";
            txtStatus.Text = "";
            txtSupplierInvNo.Text = "";
            btnPatientFileNoCheck.Enabled = true;
            txtStatus.BackColor = System.Drawing.Color.White;
            lblInvoiceID.Text = "";
            lstVwMedicalTreatments.Columns.Clear(); 
            lstVwMedicalTreatments.Items.Clear();
            infoText.Text = "";
            txtInvoiceDate.Text = "";
            //dtInvoiceDate.CustomFormat = " ";
            //dtInvoiceDate.Format = DateTimePickerFormat.Custom;
            cboService.SelectedIndex  = -1;
            cboSupplier.SelectedIndex  = -1;
            picValidate1.Visible = false;
            if (cboPatientFileNo.SelectedItem != null  )
            {
                cboPatientFileNo.SelectedIndex = -1;
            }
            lblInvAmountReceived.Text = "";
            chkCancel.Checked = false;
            chkLateInvoice.Checked = false;
            txtLateInvoiceSentDate.Text = "";
            txtWaybillNo.Text = "";
            _invoice = new Invoice();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (aimsComboLookup1.lstItems.SelectedIndex != -1)
            {
                _fileClosed = "N";
                errProv.Clear();
                LoadInvoiceDetails();
                //LoadInvoiceMedicalTreatments(lblInvoiceID.Text.ToString());
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select an invoice from the list.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tabInvoices.Enabled         = true;
                btnAddNewTreatment.Enabled  = false;
                ClearControls();
                EnableControls();
                btnAddNewTreatment.Enabled = false;
                btnRemoveMedicalTreatment.Enabled = false;
                txtPatientFileNo.Focus();
                lblInvoiceID.Text = "";
                cboPatientFileNo.Focus();
            }
            catch (System.Exception ex)
            {                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //Application.ExitThread();
            }
            catch (System.Exception ex)
            {
                CommonFuncs.ErrorLogger("Closing AIMS Records Maintainer - " + ex.Message);
            }
        }

        /// <summary>
        /// This function loads the dropdown with patient information
        /// </summary>
        private void LoadInvoices()
        {
            try
            {
                aimsComboLookup1.DataField1 = "INVOICE_NO";
                aimsComboLookup1.DataField2 = "INVOICE_ID";
                aimsComboLookup1.OrderByField = "INVOICE_NO";            
                aimsComboLookup1.TableName = "AIMS_INVOICES_VW";
                
                aimsComboLookup1.ItemsLoaded = 50;
                aimsComboLookup1.Initialise("");
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Invoice list. " + ex.Message);
            }
        }

        public void LoadInvoiceMedicalTreatments(string InvoiceID)
        {
            AIMS.BLL.Invoice clsInvoice = new Invoice();
            try
            {
                DataTable dtInvoiceMedicalTreatment = clsInvoice.GetInvoiceMedicalTreatment(InvoiceID);
                if (dtInvoiceMedicalTreatment.Rows.Count > 0 )
                {
                    MedicalTreatmentSetup();
                    for (int i = 0; i < dtInvoiceMedicalTreatment.Rows.Count; i++)
			        {
                        ListViewItem lvwItem = new ListViewItem(dtInvoiceMedicalTreatment.Rows[i]["supplier_name"].ToString());
                        lvwItem.SubItems.Add(dtInvoiceMedicalTreatment.Rows[i]["treatment_notes"].ToString());
                        lvwItem.SubItems.Add(dtInvoiceMedicalTreatment.Rows[i]["service_description"].ToString());
                        lvwItem.SubItems.Add(dtInvoiceMedicalTreatment.Rows[i]["invoice_treatment_id"].ToString());
                        lstVwMedicalTreatments.Items.Add(lvwItem);
			        }
                    
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.ErrorLogger("");
            }
            finally
            {
                clsInvoice = null;
            }
        }

        /// <summary>
        /// This method list details for a specific Invoice
        /// </summary>
        private void LoadInvoiceDetails()
        {
            AIMS.BLL.Invoice clsInvoice = new Invoice();
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {                
                ClearControls();
                cboPatientFileNo.Focus();
                _invoice = clsInvoice.GetInvoiceDetails(aimsComboLookup1.lstItems.SelectedValue.ToString());
                
                if (_invoice != null)
                {
                    if (UserAllowed("2"))
                    {
                        btnAddNewTreatment.Enabled = true;
                    }

                    tabInvoices.Enabled = true;
                    lblInvoiceID.Text = _invoice.InvoiceID.ToString();
                    txtInvoiceAmount.Text = _invoice.InvoiceAmoutReceived;
                    txtInvoiceNo.Text = _invoice.InvoiceNumber;
                    txtPatientFileNo.Text = _invoice.PatientFileNo;
                    txtPatientName.Text = _invoice.PatientFullName;
                    //txtSupplierInvNo.Text = _invoice.InvoiceNumber;
                    txtPatientFileNo.Text = _invoice.PatientFileNo;
                    txtInvoiceAmount.Text = _invoice.InvoiceAmoutReceived;

                    if (txtInvoiceAmount.Text.Trim().Length > 0)
                    {
                        decimal txtInvAmount = System.Convert.ToDecimal(txtInvoiceAmount.Text);
                        lblInvAmountReceived.Text = "(" + txtInvAmount.ToString("C") + ")";
                    }

                    txtInvoiceDate.Text = _invoice.InvoiceDate;

                    if (_invoice.InvoiceCancelledYN.ToString() == "Y")
                    {
                        chkCancel.Checked = true;
                        //DisableControls();
                        if (UserAllowed("27"))
                        {
                            chkCancel.Enabled = true;
                            btnSave.Enabled = UserAllowed("2");
                        }
                    }
                    else
                    {
                        chkCancel.Checked = false;
                        EnableControls();
                    }

                    cboPatientFileNo.Text = _invoice.PatientFileNo;
                    //cboPatientFileNo.SelectedValue  = _invoice.PatientID;

                    if (_fileClosed == "Y")
                    {
                        return;
                    }

                    if (_invoice == null)
                    {
                        _invoice = clsInvoice.GetInvoiceDetails(aimsComboLookup1.lstItems.SelectedValue.ToString());
                    }

                    if (_invoice != null )
                    {

                        if (_invoice.InvoiceLateYN.ToString() == "Y" )
                        {
                            chkLateInvoice.Checked = true;
                        }
                        else
                        {
                            chkLateInvoice.Checked = false;
                        }

                        if (_invoice.LateInvoiceSent.ToString() == "Y")
                        {
                            chkLateInvoiceSent.Checked = true;
                            txtLateInvoiceSentDate.Text = _invoice.LateInvoiceSentDate;
                            txtWaybillNo.Text = _invoice.InvoiceSentWaybillNo;
                        }
                        else
                        {
                            chkLateInvoiceSent.Checked = false;
                            txtLateInvoiceSentDate.Text = "";
                            txtWaybillNo.Text = "";
                        }

                        if (_invoice.DoctorOwingYN.ToString() == "Y")
                        {
                            chkDoctorOwing.Checked = true;
                        }
                        else
                        {
                            chkDoctorOwing.Checked = false;
                        }

                        //if (_invoice.PatientActiveYN == "N")
                        //{
                        //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "This invoice is linked to a closed file, please contact your supervisor.");
                        //    tabInvoices.Enabled = false;
                        //    lstVwMedicalTreatments.Enabled = true;
                        //    btnSave.Enabled = false;
                        //    infoText.Text = "Patient File: LOCKED";
                        //    btnUnlockInvoice.Enabled = false;
                        //}
                        //else
                        //{
                        //    tabInvoices.Enabled = true;
                        //}                        
                    }
                    else
                    {
                        if (UserAllowed("2"))
                        {
                            btnSave.Enabled = true;
                        }
                    }                    
                }
                cboPatientFileNo.Focus();
                if (UserAllowed("27"))
                {
                    chkCancel.Enabled = true;
                }

                cboSupplier.SelectedItem = -1;
                cboSupplier.Text = "";
                cboService.SelectedValue = _invoice.ServiceID;
                cboSupplier.SelectedValue = _invoice.SupplierID;
                cboSupplier.Text = _invoice.SupplierName;

            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
                CommonFuncs.ErrorLogger(""  );
                clsInvoice = null;
            }
        }


        /// <summary>
        /// This method list details for a specific Invoice
        /// </summary>
        private void LoadInvoiceDetails(string InvoiceID)
        {
            AIMS.BLL.Invoice clsInvoice = new Invoice();
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                ClearControls();
                cboPatientFileNo.Focus();
                _invoice = clsInvoice.GetInvoiceDetails(InvoiceID.ToString());

                if (_invoice != null)
                {
                    if (UserAllowed("2"))
                    {
                        btnAddNewTreatment.Enabled = true;
                    }

                    tabInvoices.Enabled = true;
                    lblInvoiceID.Text = _invoice.InvoiceID.ToString();
                    txtInvoiceAmount.Text = _invoice.InvoiceAmoutReceived;
                    txtInvoiceNo.Text = _invoice.InvoiceNumber;
                    txtPatientFileNo.Text = _invoice.PatientFileNo;
                    txtPatientName.Text = _invoice.PatientFullName;
                    //txtSupplierInvNo.Text = _invoice.InvoiceNumber;
                    txtPatientFileNo.Text = _invoice.PatientFileNo;
                    txtInvoiceAmount.Text = _invoice.InvoiceAmoutReceived;

                    if (txtInvoiceAmount.Text.Trim().Length > 0)
                    {
                        decimal txtInvAmount = System.Convert.ToDecimal(txtInvoiceAmount.Text);
                        lblInvAmountReceived.Text = "(" + txtInvAmount.ToString("C") + ")";
                    }

                    txtInvoiceDate.Text = _invoice.InvoiceDate;
                    cboPatientFileNo.Text = _invoice.PatientFileNo;
                    //cboPatientFileNo.SelectedValue  = _invoice.PatientID;

                    _invoice = clsInvoice.GetInvoiceDetails(InvoiceID);
                    cboSupplier.SelectedValue = _invoice.SupplierID;
                    cboSupplier.Text = _invoice.SupplierName;
                    cboService.SelectedValue = _invoice.ServiceID;

                    if (_invoice.InvoiceLateYN.ToString() == "Y")
                    {
                        chkLateInvoice.Checked = true;
                    }
                    else
                    {
                        chkLateInvoice.Checked = false;
                    }

                    if (_invoice.InvoiceCancelledYN.ToString() == "Y")
                    {
                        chkCancel.Checked = true;
                        //DisableControls();
                    }
                    else
                    {
                        EnableControls();
                        chkCancel.Checked = false;
                    }

                    if (_invoice.LateInvoiceSent.ToString() == "Y")
                    {
                        chkLateInvoiceSent.Checked = true;
                        txtLateInvoiceSentDate.Text = _invoice.LateInvoiceSentDate;
                        txtWaybillNo.Text = _invoice.InvoiceSentWaybillNo;
                    }
                    else
                    {
                        chkLateInvoiceSent.Checked = false;
                        txtLateInvoiceSentDate.Text = "";
                        txtWaybillNo.Text = "";
                    }

                    //if (_invoice.PatientActiveYN == "N")
                    //{
                    //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "This invoice is linked to a closed file, please contact your supervisor.");
                    //    tabInvoices.Enabled = false;
                    //    lstVwMedicalTreatments.Enabled = true;
                    //    btnSave.Enabled = false;
                    //    infoText.Text = "Patient File: LOCKED";
                    //    btnUnlockInvoice.Enabled = false;
                    //}
                    //else
                    //{
                    //    tabInvoices.Enabled = true;
                    //}
                }
                cboPatientFileNo.Focus();

                chkCancel.Enabled = false;
                if (UserAllowed("27"))
                {
                    chkCancel.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
                CommonFuncs.ErrorLogger("");
                clsInvoice = null;
            }
        }

        private bool SaveInvoiceDetails()
        {
            bool bSaved = false;
            _fileClosed = "N";
            AIMS.BLL.Invoice clsInvoice = new Invoice();
            string savePatientFileNo = "";
            string saveSupplierName = "";

            _invoice  = new Invoice();
            if (cboPatientFileNo.SelectedIndex == -1 )
            {
                savePatientFileNo = txtPatientFileNo.Text;
            }
            else
            {
                savePatientFileNo = cboPatientFileNo.SelectedValue.ToString();
            }

            DataTable dtPatientInvoiceExist = _invoice.PatientInvoiceNoVerify( savePatientFileNo,txtInvoiceNo.Text.Trim() );

            if (dtPatientInvoiceExist.Rows.Count > 0 && lblInvoiceID.Text.Length == 0)
            {
                picValidate1.Visible = false;
                //errProv.SetError(txtInvoiceNo, "Patient File already contains this invoice-no, Please do a look up for this invoice");
                errProv.SetError(txtInvoiceNo, "Invoice Number already used on another file, Please re-capture.");
                return false;
            }

            if (lblInvoiceID.Text.Trim().Length > 0 )
	        {
                _invoice.InvoiceID = System.Convert.ToInt32(lblInvoiceID.Text);
	        }
            else
            {
                _invoice.InvoiceID = 0;
            }

            _invoice.InvoiceNumber = txtInvoiceNo.Text.Trim().ToUpper();

            _invoice.InvoiceAmoutReceived = txtInvoiceAmount.Text.Trim().ToUpper();

            if (txtInvoiceAmount.Text.Replace(" ", "").Length > 5)
            {
                _invoice.InvoiceAmoutReceived = txtInvoiceAmount.Text.Trim();
            }

            _invoice.InvoiceDate = txtInvoiceDate.Text;

            _invoice.PatientFileNo = txtPatientFileNo.Text.Trim();

            if (chkLockInvoice.Checked)
            {
                _invoice.InvoiceLockedYN = "Y";
            }
            else
            {
                _invoice.InvoiceLockedYN = "N";
            }

            if (chkLateInvoice.Checked)
            {
                _invoice.InvoiceLateYN = "Y";
            }
            else
            {
                _invoice.InvoiceLateYN = "N";
            }

            if (chkCancel.Checked)
            {
                _invoice.InvoiceCancelledYN = "Y";
            }
            else
            {
                _invoice.InvoiceCancelledYN = "N";
            }

            if (chkDoctorOwing.Checked)
            {
                _invoice.DoctorOwingYN  = "Y";
            }
            else
            {
                _invoice.DoctorOwingYN = "N";
            }

            if (chkLateInvoiceSent.Checked )
            {
                _invoice.LateInvoiceSent = "Y";
            }
            else
            {
                _invoice.LateInvoiceSent = "N";
            }

            _invoice.LateInvoiceSentDate = txtLateInvoiceSentDate.Text.Trim();
            _invoice.InvoiceSentWaybillNo = txtWaybillNo.Text.Trim();

            _invoice.SupplierID = System.Convert.ToInt64(cboSupplier.SelectedValue);
            saveSupplierName = cboSupplier.Text;

            DataTable dtSupplierVerify = _invoice.GetSupplierDetails(saveSupplierName);
            _invoice.SupplierID = System.Convert.ToInt64(dtSupplierVerify.Rows[0]["SUPPLIER_ID"]);
            
            _invoice.ServiceID = System.Convert.ToInt64(cboService.SelectedValue);
 
            _invoice.InvoiceGeneratedYN = "Y";
            _invoice.LoggedOnUser = UserID;
            bSaved = _invoice.SaveInvoiceDetails(clsInvoice);

            if (bSaved)
            {
                MessageBox.Show("Invoice added successfully", "Invoice Load",MessageBoxButtons.OK , MessageBoxIcon.Information);

                lblInvoiceID.Text = _invoice.InvoiceID.ToString();
                LoadInvoices();

                LoadInvoiceDetails(lblInvoiceID.Text);

                if (chkCancel.Checked)
                {
                    infoText.Text = "Invoice Status: CANCELLED";
                    //DisableControls();
                    chkCancel.Enabled = UserAllowed("27");
                    chkCancel.Checked = true;
                }
                else
                {
                    chkCancel.Checked = false;
                    infoText.Text = "Invoice Status: ACTIVE";
                    EnableControls();
                }
                bSaved = true;
            }
            else
            {
                MessageBox.Show("Invoice NOT added successfully", "Invoice Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (UserAllowed("2"))
                {
                    btnAddNewTreatment.Enabled = true;
                }
                bSaved = false;      
            }
            return bSaved;
        }

        private void aimsComboLookup1_Load(object sender, EventArgs e)
        {

        }

        private void btnPatientFileNoCheck_Click(object sender, EventArgs e)
        {
            DataTable dtPatientExist = new DataTable();
            Int64 SelectedPatientID = 0;
            try
            {
                cboPatientFileNo.SelectedValue = -1;
                AIMS.BLL.Invoice clsInvoice = new Invoice();
                _invoice = new Invoice();
                CommonFuncs = new CommonFuncs();
                if (txtPatientFileNo.Text.Trim().Length > 0 )
                {
                    dtPatientExist = _invoice.PatientValidate(txtPatientFileNo.Text);
                    
                    if (dtPatientExist.Rows.Count == 0)
                    {
                        MessageBox.Show("The Patient File Number captured does not exists", "Patient File No Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        picValidate1.Visible = false;
                    }
                    else
                    {
                        //if (dtPatientExist.Rows[0]["PATIENT_FILE_ACTIVE_YN"].ToString() == "N")
                        //{
                        //    CommonFuncs.DisplayMessage("This patient file has been closed, please check with your supervisor", AIMS.Common.CommonTypes.MessagType.Warning);
                        //    tabInvoices.Enabled = false;
                        //    picValidate1.Visible = false;
                        //}
                        //else
                        //{
                            errProv.SetError(txtPatientFileNo, "");
                            txtPatientName.Text = dtPatientExist.Rows[0][0].ToString();
                            picValidate1.Visible = true;
                            txtInvoiceNo.Focus();                            
                        //}
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

        private void btnAddNewTreatment_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblInvoiceID.Text.Trim().Length > 0  )
                {
                    AddMedicalNote frmNewMedical = new AddMedicalNote();
                    frmNewMedical.InvoiceID = System.Convert.ToInt64(lblInvoiceID.Text);
                    frmNewMedical.ShowDialog();
                    lstVwMedicalTreatments.Columns.Clear();
                    lstVwMedicalTreatments.Items.Clear();
                    LoadInvoiceMedicalTreatments(lblInvoiceID.Text);
                }
                else
                {
                    MessageBox.Show("Please load this invoice first", "Invoice Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
                
        private void btnRemoveMedicalTreatment_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstVwMedicalTreatments.Items.Count >  0 )
                {
                    for (int i = 0; i < lstVwMedicalTreatments.Items.Count; i++)
                    {
                        if (lstVwMedicalTreatments.Items[i].Checked)
                        {
                            AIMS.BLL.Invoice clsInvoice = new Invoice();
                            string SelectedInvoiceTreatment = lstVwMedicalTreatments.Items[i].SubItems[3].Text;
                            if (clsInvoice.DelInvoiceMedicalTreatment(SelectedInvoiceTreatment,lblInvoiceID.Text))
	                        {
                                errProv.Clear();
                                lstVwMedicalTreatments.Items[i].Remove();
	                        }
                            else
	                        {
                                errProv.SetError(lstVwMedicalTreatments, "Unable to remove selected treatment from List");
	                        }
                        }                        
                    }
                }
                else
                {

                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void MedicalTreatmentSetup()
        {
            lstVwMedicalTreatments.Columns.Clear();
            lstVwMedicalTreatments.Items.Clear();
            lstVwMedicalTreatments.Columns.Add("Supplier Name", 150, HorizontalAlignment.Center);
            lstVwMedicalTreatments.Columns.Add("Medical Treatment", 150, HorizontalAlignment.Center);
            lstVwMedicalTreatments.Columns.Add("Service Rendered", 150, HorizontalAlignment.Center);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            //this.Close();
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
                    if (SaveInvoiceDetails())
                    {
                        // If we are cancelling, dont check cost limits
                        if (!chkCancel.Checked)
                        {
                            // after creating the invoice, check to see if the invoice amount does not exceed the cost limit for the supplier type
                            ServiceCostLimitCheck(System.Convert.ToInt64(cboService.SelectedValue), System.Convert.ToDecimal(txtInvoiceAmount.Text.Trim()));                            
                        }
                        if (LastPatient >0)
                        {
                            aimsComboLookup1.lstItems.SelectedIndex = (int)LastPatient;
                        }                        
                    }
                }
            }
            catch (System.Exception ex )
            {
                CommonFuncs.ErrorLogger("Saving Invoice Details Failed, Please contact system administrator. " + ex.Message);
                CommonFuncs.DisplayMessage("Saving Invoice Details Failed - " + ex.Message, AIMS.Common.CommonTypes.MessagType.Error);
            }
        }

        public bool ValidateControls()
        {
            bool returnVal = true;
            EnableControls();
            errProv.Clear();

            if (this.txtPatientFileNo.Text.Trim().Length == 0)
            {
                errProv.SetError(txtPatientFileNo, "Please enter Patient File No");
                txtPatientFileNo.Focus();
                returnVal = false;
            }
            else
            {
                _invoice = new Invoice();
                CommonFuncs = new CommonFuncs();
                DataTable dtPatientExist = new DataTable();
                if (txtPatientFileNo.Text.Trim().Length > 0)
                {
                    dtPatientExist = _invoice.PatientValidate(txtPatientFileNo.Text);

                    if (dtPatientExist.Rows.Count == 0)
                    {
                        CommonFuncs.DisplayMessage("The Patient File No captured does not exists", AIMS.Common.CommonTypes.MessagType.Error);
                        errProv.SetError(txtPatientFileNo, "Patient File No does not exist, Please verify and try again.");
                        picValidate1.Visible = false;
                        returnVal = false;
                    }
                    else
                    {
                        //if (dtPatientExist.Rows[0]["PATIENT_FILE_ACTIVE_YN"].ToString() == "N")
                        //{
                        //    CommonFuncs.DisplayMessage("This patient file has been closed, please contact supervisor", AIMS.Common.CommonTypes.MessagType.Warning);
                        //    errProv.SetError(txtPatientFileNo, "Patient file closed, Contact supervisor");
                        //    picValidate1.Visible = false;
                        //    returnVal = false;
                        //}
                        //else
                        //{
                            errProv.SetError(txtPatientFileNo, "");
                            txtPatientName.Text = dtPatientExist.Rows[0][0].ToString();
                            picValidate1.Visible = true;
                            txtInvoiceNo.Focus();                            
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("Please capture Patient File number", "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.txtInvoiceNo.Text.Trim().Length == 0)
            {
                errProv.SetError(txtInvoiceNo, "Please enter Invoice Number");
                txtInvoiceNo.Focus();
                returnVal = false;
            }

            if (this.txtInvoiceAmount.Text.Trim().Length == 0)
            {
                errProv.SetError(txtInvoiceAmount, "Please enter Invoice Amount");
                txtInvoiceAmount.Focus();
                returnVal = false;
            }
            else
            {
                Int32 tmp1;
                string strLoop = "";
                for (int i = 0; i < this.txtInvoiceAmount.Text.Trim().Length ; i++)
                {
                    strLoop = this.txtInvoiceAmount.Text.Trim().Substring(i, 1).Trim();
                    if (strLoop.Length > 0 )
                    {
                        if (!Int32.TryParse(strLoop, out tmp1) & strLoop != ".")
                        {
                            errProv.SetError(txtInvoiceAmount, "Invoice Amount not valid, This field can only contain numbers");
                            txtInvoiceAmount.Focus();
                            returnVal = false;                                                                		 
                        }                        
                    }
                }
            }

            double tmp3;
            if (!double.TryParse(txtInvoiceAmount.Text.Trim(), out tmp3))
            {
                errProv.SetError(txtInvoiceAmount, "Invoice Amount is not valid currency value.");
                txtInvoiceAmount.Focus();
                returnVal = false;
            }

            if (this.txtInvoiceDate.Text.Trim().Length == 0)
            {
                errProv.SetError(txtInvoiceDate, "Please enter Invoice Date");
                txtInvoiceDate.Focus();
                returnVal = false;
            }
          
            if (this.cboSupplier.SelectedItem != null)
            {
                if (this.cboSupplier.Text == "")
                {
                    errProv.SetError(cboSupplier , "Please select a supplier");
                    cboSupplier.Focus();
                    returnVal = false;                  
                }
            }
            else
            {
                errProv.SetError(cboSupplier, "Please select a supplier");
                cboSupplier.Focus();
                returnVal = false;
            }

            if (this.cboService.SelectedItem != null)
            {
                if (this.cboService.Text == "")
                {
                    errProv.SetError(cboService, "Please select a service rendered");
                    cboService.Focus();
                    returnVal = false;
                }
            }
            else
            {
                errProv.SetError(cboService, "Please select a service rendered");
                cboService.Focus();
                returnVal = false;
            }

            if (this.cboPatientFileNo.SelectedItem != null)
            {
                if (this.cboPatientFileNo.SelectedValue.ToString() == "" && txtPatientFileNo.Text.Trim().Length == 0)
                {
                    errProv.SetError(cboPatientFileNo, "Please select Patient File No");
                    cboPatientFileNo.Focus();
                    returnVal = false;
                }
            }
            
            if (chkLateInvoiceSent.Checked & txtLateInvoiceSentDate.Text.Trim() == "")
            {
                errProv.SetError(txtLateInvoiceSentDate, "Please Enter Late Invoice Sent Date");
                txtLateInvoiceSentDate.Focus();
                returnVal = false;                    
            }

            if (chkLateInvoiceSent.Checked & txtWaybillNo.Text.Trim() == "")
            {
                errProv.SetError(txtWaybillNo, "Please Enter Waybill No ");
                txtWaybillNo.Focus();
                returnVal = false;                    
            }
            

            if (returnVal == true)
            {
                errProv.Clear();
            }

            return returnVal;
        }

        private void EnableControls()
        {
            txtInvoiceAmount.Enabled = true;
            txtInvoiceNo.Enabled = true;
            txtPatientFileNo.Enabled = true;
            txtPatientName.Enabled = true;
            txtStatus.Enabled = true;
            txtSupplierInvNo.Enabled = true;
            btnPatientFileNoCheck.Enabled = true;
            lblInvoiceID.Enabled = true;
            txtInvoiceAmount.Enabled = true;
            chkLateInvoice.Enabled = true;
            //txtInvoiceDate.Enabled = true;
            lnklblInvDate.Enabled = true;
                      
            btnRemoveMedicalTreatment.Enabled = true;
            if (UserAllowed("2"))
            {
                btnSave.Enabled = true;
            }                        
            txtPatientFileNo.ReadOnly = false;
            lnklblInvDate.Enabled = true;
            txtInvoiceDate.Enabled = true;
            cboSupplier.Enabled = true;
            cboService.Enabled = true;
            cboPatientFileNo.Enabled = true;
        }

        private void DisableControls()
        {
            txtInvoiceDate.Enabled = false;
            cboSupplier.Enabled = false;
            cboService.Enabled = false;
            txtInvoiceAmount.Enabled = false;
            txtInvoiceNo.Enabled = false;
            txtPatientFileNo.Enabled = false;
            txtPatientName.Enabled = false;
            txtStatus.Enabled = false;
            txtSupplierInvNo.Enabled = false;
            btnPatientFileNoCheck.Enabled = false;
            lblInvoiceID.Enabled = false;
            btnAddNewTreatment.Enabled = false;
            btnRemoveMedicalTreatment.Enabled = false;
            btnAddNewTreatment.Enabled = false;
            btnRemoveMedicalTreatment.Enabled = false;
            txtInvoiceAmount.Enabled = false;
            //txtInvoiceDate.Enabled = false;
            chkLateInvoice.Enabled = false;
            btnSave.Enabled = false;
            lnklblInvDate.Enabled = false;
            //txtPatientFileNo.ReadOnly = true;
            chkCancel.Enabled = false;
            cboPatientFileNo.Enabled = false;
        }

        private void btnUnlockInvoice_Click(object sender, EventArgs e)
        {
            bool bSaved = false;
            AIMS.BLL.Invoice clsInvoice = new Invoice();

            _invoice = new Invoice();

            if (lblInvoiceID.Text.Trim().Length > 0)
            {
                _invoice.InvoiceID = System.Convert.ToInt32(lblInvoiceID.Text);
            }

            _invoice.LoggedOnUser = UserID;
            bSaved = _invoice.UnlockInvoice();

            if (bSaved)
            {
                CommonFuncs.DisplayMessage("Invoice Unlocked successfully", AIMS.Common.CommonTypes.MessagType.Success);              
                btnAddNewTreatment.Enabled = false;
                chkLockInvoice.Checked = false;
                lblInvoiceID.Text = _invoice.InvoiceID.ToString();
                tabInvoices.Enabled = true;
                EnableControls();
                infoText.Text = "Patient File: OPEN";
                btnUnlockInvoice.Enabled = false;
            }
            else
            {
                CommonFuncs.DisplayMessage("Invoice could not be unlocked.", AIMS.Common.CommonTypes.MessagType.Error);
                if (UserAllowed("1"))
                {
                    btnUnlockInvoice.Enabled = true;
                }
            }            
        }

        private void txtInvoiceDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtInvoiceDate.Text = frmCal.StartDate.ToShortDateString();
            }
            
            txtInvoiceDate.Focus();
            txtInvoiceAmount.Focus();
        }

        private void lnklblInvDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtInvoiceDate_DoubleClick(null, null);
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtInvoiceNo_KeyPress(object sender, System.EventArgs e)
        {       
            
        }

        private void txtInvoiceAmount_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;
            string NewInvoiceAmt = "";
            
            if (txtInvoiceAmount.Text.Trim().Length > 0)
            {
                if (!double.TryParse(txtInvoiceAmount.Text, out tmp))
                {
                    if (txtInvoiceAmount.Text.Substring(txtInvoiceAmount.Text.Trim().Length - 1, 1) != ".")
                    {
                        if (!double.TryParse(txtInvoiceAmount.Text.Trim(), out tmp1))
                        {
                        }
                    }
                } 
            }
        }

        private void txtPatientFileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInvoiceNo.Focus();    
            }           
        }

        private void txtInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInvoiceAmount.Focus();    
            }           
        }
        

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInvoiceAmount.Focus();
            }    
        }

        private void cboPatientFileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPatientFileNo.Focus();
            }            
        }

        private void txtInvoiceAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if ((System.Convert.ToInt32(e.KeyCode) < 48 | System.Convert.ToInt32(e.KeyCode) > 57) && e.KeyCode.ToString() != "NumPad0" && e.KeyCode.ToString() != "NumPad1" && e.KeyCode.ToString() != "NumPad2" && e.KeyCode.ToString() != "NumPad3" && e.KeyCode.ToString() != "NumPad4" && e.KeyCode.ToString() != "NumPad5" && e.KeyCode.ToString() != "NumPad6" && e.KeyCode.ToString() != "NumPad8" && e.KeyCode.ToString() != "NumPad9" && e.KeyCode.ToString() != "NumPad10" && e.KeyCode.ToString() != "NumPad7" && e.KeyCode.ToString() != "NumLock" && e.KeyCode.ToString() != "Decimal")
            {
                if (System.Convert.ToInt32(e.KeyCode) != 190 & System.Convert.ToInt32(e.KeyCode) != 8 & System.Convert.ToInt32(e.KeyValue) != 36 & System.Convert.ToInt32(e.KeyValue) != 35 & System.Convert.ToInt32(e.KeyValue) != 39 & System.Convert.ToInt32(e.KeyValue) != 37 & System.Convert.ToInt32(e.KeyValue) != 18 & e.KeyCode != Keys.Enter)
                {
                    MessageBox.Show("This field can contain only numbers.", "Numbers Only", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            if (e.KeyCode == Keys.Enter)
            {
                cboSupplier.Focus();
            }    		
        }

        private void CurrencyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only numbers, decimals and control characters
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && this.Text.Contains("."))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && this.Text.Length < 1)
            {
                e.Handled = true;
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
            //21                   View User Maintenance

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

        private void btnSave_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void cboSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboService.Focus();
            }
        }

        private void cboService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmSuppliers frmSupp = new frmSuppliers();
            frmSupp.Text = "New Supplier";

            if (cboSupplier.SelectedItem != null && cboSupplier.Text == "<Add New Supplier>" && SupplierFirstLoad == false)
            {
                if (MessageBox.Show("Continue with adding a new supplier?", "New Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cboSupplier.SelectedIndex > 0)
                    {
                        if (cboSupplier.SelectedValue != null)
                        {
                            frmSupp.AddNewSupplier = true;
                            frmSupp.SupplierID = System.Convert.ToInt32(cboSupplier.SelectedValue);
                            frmSupp.HideSupplierType = true;
                        }
                    }
                    else
                    {
                        frmSupp.AddNewSupplier = true;
                        frmSupp.NewHospitalSupplier = "";
                        frmSupp.SupplierID = 0;
                    }
                    frmSupp.Restrictions = Restrictions;
                    frmSupp.ShowDialog();

                    cboSupplier.DataSource = commonFuncs.GetSuppliers();
                    cboSupplier.DisplayMember = "SUPPLIER_NAME";
                    cboSupplier.ValueMember = "SUPPLIER_ID";
                    cboSupplier.SelectedIndex = -1;
                }
                else
                {
                    cboSupplier.SelectedIndex = -1;
                }
            }
        }

        private void gpxInvoice_Enter(object sender, EventArgs e)
        {

        }

        private void cboPatientFileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
              
            if (cboPatientFileNo.SelectedItem != null)
            {
                if (cboPatientFileNo.SelectedIndex >= 0 && (cboPatientFileNo.SelectedValue.ToString() != "System.Data.DataRowView" & cboPatientFileNo.Text != "System.Data.DataRowView"))
                {                    
                    DataTable dtPatientExist = new DataTable();
                    try
                    {
                        AIMS.BLL.Invoice _invoice1 = new Invoice();
                        _invoice1 = new Invoice();                            
                        
                        CommonFuncs = new CommonFuncs();
                        txtPatientFileNo.Text = cboPatientFileNo.Text.ToString();
                        if (txtPatientFileNo.Text.Trim().Length > 0 )
                        {
                            dtPatientExist = _invoice1.PatientValidate(txtPatientFileNo.Text);                            
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
                                    tabInvoices.Enabled = false;
                                    picValidate1.Visible = false;
                                    DisableControls();
                                    _fileClosed = "Y";
                                }
                                else
                                {
                                    errProv.SetError(txtPatientFileNo, "");
                                    txtPatientName.Text = dtPatientExist.Rows[0][0].ToString().Trim();
                                    picValidate1.Visible = true;
                                    txtInvoiceNo.Focus();                                    
                                }                               
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please capture Patient File number", "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        _invoice1 = null;
                    }
                    catch (System.Exception ex)
                    {
                        CommonFuncs.ErrorLogger("Verifying Patient failed: " + ex.Message);
                        throw;
                    }                    
                }
                else
                {
                    txtPatientFileNo.Text = "";
                    txtPatientName.Text = ""; 
                    picValidate1.Visible = false;
                }
            }
            else
            { 
                txtPatientFileNo.Text = "";
                txtPatientName.Text = "";
                picValidate1.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                LoadInvoices();
               
                commonFuncs = new AIMS.Common.CommonFunctions();
                cboSupplier.DataSource = null;
                cboSupplier.Items.Clear();

                LoadSuppliers();
                //cboSupplier.SelectedIndex = -1;
                //cboSupplier.DataSource = commonFuncs.GetSuppliers();
                SupplierFirstLoad = true;
                //cboSupplier.DisplayMember = "SUPPLIER_NAME";
                //cboSupplier.ValueMember = "SUPPLIER_ID";
                //cboSupplier.SelectedIndex = -1;

                //DataTable dsServices = CommonFuncs.LoadServices();
                DataTable dsServices = commonFuncs.GetSupplierTypes();

                cboService.DataSource = dsServices;
                cboService.DisplayMember = "SUPPLIER_TYPE_DESC";
                cboService.ValueMember = "SUPPLIER_TYPE_ID";
                SupplierFirstLoad = false;
                //cboService.DisplayMember = "SERVICE_DESCRIPTION";
                //cboService.ValueMember = "SERVICE_ID";

                cboService.SelectedIndex = -1;

                DataTable dsPatientFiles = CommonFuncs.LoadPatientFiles();
                //cboPatientFileNo.Items.Insert(0, "");
                cboPatientFileNo.DataSource = dsPatientFiles;
                cboPatientFileNo.DisplayMember = "PATIENT_FILE_NO";
                cboPatientFileNo.ValueMember = "PATIENT_ID";
                cboPatientFileNo.SelectedIndex = -1;

                //cboPatientFileNo.Items.Insert(0, " ");
                cboPatientFileNo.Focus();

            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Refreshing AIMS Recorder Failed, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Invoices form refreshing failed, Error - " + e.ToString());
            }
        }

        private void txtInvoiceAmount1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtInvoiceAmountold_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = "";
            AIMS.BLL.Invoice _invoiceNew = new Invoice();
            try
            {
                if (cboService.SelectedItem != null && cboService.Text == "<Add New Service>")
                {
                    if (InputBox("New Service", "Service Description (e.g. Dentist, Cardiologist, Ambulance)", ref value) == DialogResult.OK)
                    {
                        if (value.Trim().Length > 0)
                        {
                            bool bSaved = false;
                            
                            AIMS.BLL.Invoice clsInvoice = new Invoice();

                            DataTable dtServiceCheck = _invoiceNew.CheckIfServiceExist(value.Trim());

                            if (dtServiceCheck.Rows.Count > 0  )
                            {
                                MessageBox.Show("Service already exists", "Service Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cboService.SelectedIndex = -1;
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
                                        cboService.DataSource = dtSupplierTypes;
                                        cboService.DisplayMember = "SUPPLIER_TYPE_DESC";
                                        cboService.ValueMember = "SUPPLIER_TYPE_ID";
                                        cboService.SelectedIndex = -1;
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
                            cboService.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        cboService.SelectedIndex = -1;
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

        private void txtInvoiceDate_TextChanged(object sender, EventArgs e)
        {

        }

  

        private void LoadSuppliers()
        {
            DataTable tblSuppliers = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                tblSuppliers = lookupBLL.GetLookUpValues("SUPPLIER_ID", "SUPPLIER_NAME", "AIMS_SUPPLIER", 0, "SUPPLIER_NAME", "");
                cboSupplier.DataSource = tblSuppliers;
                cboSupplier.DisplayMember = "SUPPLIER_NAME";
                cboSupplier.ValueMember = "SUPPLIER_ID";
                cboSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
            finally
            {
                //tblSuppliers.Dispose();
                lookupBLL = null;
            }
        }

        private void chkDoctorOwing_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ServiceCostLimitCheck(Int64 SupplierTypeID, decimal InvoiceAmount)
        {
            try
            {
                AIMS.BLL.Invoice clsInvoice = new Invoice();
                DataTable dtSupplierCostLimit = clsInvoice.GetSupplierCostLimit(SupplierTypeID);
                decimal  SupplierTypeCostLimit = 0;
                if (dtSupplierCostLimit.Rows.Count > 0)
                {
                    SupplierTypeCostLimit = System.Convert.ToDecimal(dtSupplierCostLimit.Rows[0]["COST_LIMIT"]);
                    if (SupplierTypeCostLimit > 0 )
                    {
                        if (InvoiceAmount > SupplierTypeCostLimit)
                        {
                            bool blEmailSent = commonFuncs.SendNotifyEmail(txtPatientFileNo.Text, lblInvoiceID.Text, UserID);
                            if (!blEmailSent)
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Invoice amount captured exceed the limited amount for this supplier type, Please contact Debbie or Bernadette.");
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

        private void txtLateInvoiceSentDate_DoubleClick(object sender, EventArgs e)
        {
            if (chkLateInvoiceSent.Checked)
            {
                UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
                frmCal.Width = 250;
                frmCal.ShowDialog(this);
                if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
                {
                    txtLateInvoiceSentDate.Text = frmCal.StartDate.ToShortDateString();
                }

                txtLateInvoiceSentDate.Focus();
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Invoice not marked as a SENT.");
            }  
        }

        private void lnkLateInvSentDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (chkLateInvoiceSent.Checked)
            {
                txtLateInvoiceSentDate_DoubleClick(null, null);    
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Invoice not marked as a SENT.");
            }           
        }

        private void txtLateInvoiceSentDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkLateInvoiceSent_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkLateInvoiceSent.Checked )
            {
                txtLateInvoiceSentDate.Text = "";
                txtWaybillNo.Text = "";
            }
        }

        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkLateInvoice_CheckedChanged(object sender, EventArgs e)
        {

        }    
    }
}