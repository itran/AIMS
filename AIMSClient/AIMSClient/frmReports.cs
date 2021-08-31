using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmReports : Form
    {
        AIMS.Common.CommonFunctions commonFuncs;
        AIMS.Common.ListItem commonLists; 

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Resize(object sender, EventArgs e)
        {
            LBLPatientCat.Left = cboAssistType.Left + cboAssistType.Width;
            LBLPatientCat.Top = cboAssistType.Top;

            this.gpxReports.Left = this.Left + 2;
            this.gpxReports.Height = this.ClientSize.Height - 20;
            //this.gpxReports.Width = Convert.ToInt32(this.ClientSize.Width * 0.50);
            this.gpxReports.Width = (this.ClientSize.Width / 3) - 230;
            gpxSelection.Left = this.gpxReports.Width + this.gpxReports.Left;
            //gpxSelection.Left = (this.ClientSize.Width / 2) - 495;
            gpxSelection.Width = gpxSelection.Left + (this.ClientSize.Width / 2) + 300;
            gpxSelection.Height = this.gpxReports.Height;

            btnInvoicesView.Top = cboInvoiceStatus.Bottom + 5;
            btnInvoicesView.Left = cboInvoiceStatus.Left;

            btnPatientsView.Top = cboPatientCategory.Bottom + 5;
            btnPatientsView.Left = cboPatientState.Left;

            btnPaymentsView.Top = cboPaymentType.Bottom + 5;
            btnPaymentsView.Left = cboPaymentType.Left;

            pnlPatientAnalysis.Left = gpxSelection.Left ;
            pnlPatientAnalysis.Height = gpxSelection.Bottom - 5;
            pnlPatientAnalysis.Width = gpxSelection.Width - 50;
            pnlPatientAnalysis.Top = gpxSelection.Top;

            pnlInvoiceAnalysis.Left = gpxSelection.Left ;
            pnlInvoiceAnalysis.Height = gpxSelection.Bottom - 5;
            pnlInvoiceAnalysis.Width = gpxSelection.Width - 50;
            pnlInvoiceAnalysis.Top = gpxSelection.Top;

            pnlPaymentsAnalysis.Left = gpxSelection.Left;
            pnlPaymentsAnalysis.Height = gpxSelection.Bottom - 5;
            pnlPaymentsAnalysis.Width = gpxSelection.Width - 50;
            pnlPaymentsAnalysis.Top = gpxSelection.Top;


            pnlUserProductivityOPS.Left = gpxSelection.Left;
            pnlUserProductivityOPS.Height = gpxSelection.Bottom - 5;
            pnlUserProductivityOPS.Width = gpxSelection.Width - 50;
            pnlUserProductivityOPS.Top = gpxSelection.Top;            
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
        private void frmReports_Load(object sender, EventArgs e)
        {
            cboTransportType.Visible = false;
            cboAssistType.Visible = false;
            LoadSuppliers();
            LoadPatients();
            LoadPaymentMethods();
            LoadAssistTypes();
            LoadTransportTypes();
            
            pnlInvoiceAnalysis.Visible = false;
            radPatientsAnalysis.Checked = true;
            pnlPatientAnalysis.Visible = true;
            
            radInvoicesAnalysis.Checked = false;
            pnlUserProductivityOPS.Visible = false;
            pnlUserProductivityOPS.Visible = false;
            
            LoadGuarantors();
            pictureBox1.Visible = false;
        }

        private void txtEndDate_TextChanged(object sender, EventArgs e)
        {            
            
        }

        private void lnkStartDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Top = txtStartDate.Top;
            frmCal.Left = txtStartDate.Left;
            frmCal.ShowDialog(this);
            frmCal.Top = txtStartDate.Top;
            frmCal.Left = txtStartDate.Left;
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtStartDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtStartDate.Focus();


        }

        private void lnkEndDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Top = txtEndDate.Top;
            frmCal.Left = txtEndDate.Left;
            frmCal.ShowDialog(this);
            frmCal.Top = txtEndDate.Top;
            frmCal.Left = txtEndDate.Left;
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtEndDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtEndDate.Focus();
        }

        private void txtEndDate_DoubleClick(object sender, EventArgs e)
        {
            lnkEndDate_LinkClicked(null,null);
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            lnkStartDate_LinkClicked(null, null);
        }

        private void frmReports_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 360);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);
            //radPatientsAnalysis.Checked = false;
            //radInvoicesAnalysis.Checked = false;

        }

        private void LoadSuppliers()
        {
            DataTable tblSuppliers = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new AIMS.BLL.LookUpTableCollections();

            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                tblSuppliers = lookupBLL.GetHospitalsLookUpValues("SUPPLIER_ID", "SUPPLIER_NAME", "AIMS_SUPPLIER", 0);
                lstHospitals.DataSource = tblSuppliers;
                lstHospitals.DisplayMember = "SUPPLIER_NAME";
                lstHospitals.ValueMember = "SUPPLIER_ID";
                lstHospitals.SelectedValue = -1;

                tblSuppliers.Dispose();

                tblSuppliers = lookupBLL.GetLookUpValues("SUPPLIER_ID", "SUPPLIER_NAME", "AIMS_SUPPLIER", 2, "SUPPLIER_NAME", " WHERE SUPPLIER_NAME NOT IN ('<Add New Supplier>', '<Add New Hospital>')");
                cboSuppliers.DataSource = tblSuppliers;
                cboSuppliers.DisplayMember = "SUPPLIER_NAME";
                cboSuppliers.ValueMember = "SUPPLIER_ID";
                cboSuppliers.SelectedValue = -1;

                cboInvoiceSuppliers.DataSource = tblSuppliers;
                cboInvoiceSuppliers.DisplayMember = "SUPPLIER_NAME";
                cboInvoiceSuppliers.ValueMember = "SUPPLIER_ID";
                cboInvoiceSuppliers.SelectedValue = -1;

                DataTable tblServices = new DataTable();
                tblServices = lookupBLL.GetLookUpValues("SUPPLIER_TYPE_ID", "SUPPLIER_TYPE_DESC", "AIMS_SUPPLIER_TYPES", 2, "SUPPLIER_TYPE_DESC", " WHERE SUPPLIER_TYPE_DESC NOT IN ('<Add New Service>')");
                cboInvoiceService.DataSource = tblServices;
                cboInvoiceService.DisplayMember = "SUPPLIER_TYPE_DESC";
                cboInvoiceService.ValueMember = "SUPPLIER_TYPE_ID";
                cboInvoiceService.SelectedValue = -1;

            }
            catch (Exception ex)
            {

                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadPatients()
        {
            DataTable tblPatients = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new AIMS.BLL.LookUpTableCollections();

            tblPatients = lookupBLL.GetLookUpValues("PATIENT_LAST_NAME + ' ' + PATIENT_INITIALS AS PATIENT_NAME", "PATIENT_FILE_NO", "AIMS_PATIENT", 0,"");
            lstPatients.DataSource = tblPatients;
            lstPatients.DisplayMember = "PATIENT_NAME";
            lstPatients.ValueMember = "PATIENT_FILE_NO";            
            lstPatients.SelectedValue = -1;
        }

        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            radGuarantorAnalysis.Checked = false;
            radPatientsAnalysis.Checked = false;
            radPaymentsAnalysis.Checked = false;
            pnlUserProductivityOPS.Visible = false;
        }

        private void radPatientsAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (radPatientsAnalysis.Checked)
            {
                pnlInvoiceAnalysis.Visible = false;
                pnlPaymentsAnalysis.Visible = false ;
                pnlPatientAnalysis.Visible = true;
                pnlUserProductivityOPS.Visible = false;
            }
        }

        private void radInvoicesAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (radInvoicesAnalysis.Checked)
            {
                pnlPatientAnalysis.Visible = false;
                pnlPaymentsAnalysis.Visible = false ;
                pnlInvoiceAnalysis.Visible = true;                
            }
        }

        private void btnInvoicesView_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportViewer frmRep = new frmReportViewer("Invoice Analysis", "Invoice Analysis");
                commonFuncs = new AIMS.Common.CommonFunctions();

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                StringBuilder sbHTML = new StringBuilder();

                try
                {
                    frmRep.ReportName = "Invoice Analysis";
                    frmRep.PatientAnalysisStartDate = txtPatientFileStartDate.Text.Trim();
                    frmRep.PatientAnalysisEndDate = txtPatientFileEndDate.Text.Trim();
                    frmRep.File_status = cboPatientFileClosedOpen.Text;

                    if (cboInvoiceSuppliers.SelectedItem != null && cboInvoiceSuppliers.Text.Trim() != "") { frmRep.Supplier = cboInvoiceSuppliers.SelectedValue.ToString(); }
                    if (cboPatientState.SelectedItem != null) { frmRep.Patient_Status_In_Out = cboPatientState.Text; }
                    if (cboPatientCategory.SelectedItem != null) { frmRep.Aims_Service = cboPatientCategory.Text; }
                    if (cboGuarantors.SelectedItem != null && cboGuarantors.Text.Trim().Length > 0) { frmRep.Guarantor = cboGuarantors.SelectedValue.ToString(); }

                    frmRep.ShowDialog();
                }
                catch (Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        private void radPaymentsAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (radPaymentsAnalysis.Checked)
            {
                pnlPatientAnalysis.Visible = false;
                pnlInvoiceAnalysis.Visible = false;
                pnlPaymentsAnalysis.Visible = true;
                pnlUserProductivityOPS.Visible = false;
            }
        }

        private void pnlPaymentsAnalysis_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPatientFileStartDate_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPatientFileStartDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtPatientFileStartDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtPatientFileStartDate.Focus();
        }

        private void txtPatientFileEndDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtPatientFileEndDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtPatientFileEndDate.Focus();
        }

        private void txtPatientFileEndDate_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method populates the Titles combo box
        /// </summary>
        private void LoadGuarantors()
        {
            try
            {
                DataTable tblGuarantors;
                tblGuarantors = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new AIMS.BLL.LookUpTableCollections();
                tblGuarantors = lookupBLL.GetLookUpValues("GUARANTOR_ID", "GUARANTOR_NAME", "aims_guarantor", 0, "GUARANTOR_NAME", " where (GUARANTOR_NAME not in ('<Add New Guarantor>') and GUARANTOR_NAME IS NOT NULL)");
                cboGuarantors.Items.Insert(0, "<ALL>");
                cboGuarantors.DataSource = tblGuarantors;
                cboGuarantors.DisplayMember = "GUARANTOR_NAME";
                cboGuarantors.ValueMember = "GUARANTOR_ID";
                cboGuarantors.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void txtPymtLoadStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPymtLoadStartDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtPymtLoadStartDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtPymtLoadStartDate.Focus();
        }

        private void txtPymtLoadEndDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPymtLoadEndDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtPymtLoadEndDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtPymtLoadEndDate.Focus();
        }

        private void txtInvStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInvStartDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtInvStartDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtInvStartDate.Focus();
        }

        private void txtInvEndDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtInvEndDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtInvEndDate.Focus();
        }

        private void txtInvEndDate_TextChanged(object sender, EventArgs e)
        {

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

        private void btnPymtPatientFileCheck_Click(object sender, EventArgs e)
        {
            DataTable dtPatientExist = new DataTable();
            AIMS.BLL.Invoice _invoice = new AIMS.BLL.Invoice();
            try
            {
                if (txtPymtPatientFileNo.Text.Trim().Length > 0)
                {
                    dtPatientExist = _invoice.PatientValidate(txtPymtPatientFileNo.Text);

                    if (dtPatientExist.Rows.Count == 0)
                    {
                        pictureBox1.Visible = false;
                        MessageBox.Show("The Patient File Number captured does not exists", "Patient File No Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //txtPymtPatientFileNo.Text = dtPatientExist.Rows[0][0].ToString();
                        pictureBox1.Visible = true;
                    }
                    dtPatientExist.Dispose();
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Please capture Patient File number", "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                pictureBox1.Visible = false;
                MessageBox.Show("Verifying Patient failed: " + ex.Message, "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _invoice = null;
            }
        }

        private void btnPatientFileNoCheck_Click(object sender, EventArgs e)
        {
            DataTable dtPatientExist = new DataTable();
            AIMS.BLL.Invoice _invoice = new AIMS.BLL.Invoice();
            pictureBox2.Visible = false;
            try
            {
                if (txtPatientFileNo.Text.Trim().Length > 0)
                {
                    dtPatientExist = _invoice.PatientValidate(txtPatientFileNo.Text.Trim());

                    if (dtPatientExist.Rows.Count == 0)
                    {
                        pictureBox2.Visible = false;
                        MessageBox.Show("The Patient File Number captured does not exists", "Patient File No Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //txtPymtPatientFileNo.Text = dtPatientExist.Rows[0][0].ToString();
                        pictureBox2.Visible = true;
                    }
                    dtPatientExist.Dispose();
                }
                else
                {
                    pictureBox2.Visible = false;
                    MessageBox.Show("Please capture Patient File number", "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                pictureBox1.Visible = false;
                MessageBox.Show("Verifying Patient failed: " + ex.Message, "Patient File No", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _invoice = null;
            }       
        }

        private void btnPatientsView_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportViewer frmRep = new frmReportViewer("Patients Analysis", "Patients Analysis");
                commonFuncs = new AIMS.Common.CommonFunctions();

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                StringBuilder sbHTML = new StringBuilder();

                try
                {
                    frmRep.ReportName = "Patient Analysis";
                    frmRep.PatientAnalysisStartDate = txtPatientFileStartDate.Text.Trim();
                    frmRep.PatientAnalysisEndDate = txtPatientFileEndDate.Text.Trim();
                    frmRep.File_status = cboPatientFileClosedOpen.Text;

                    if (cboSuppliers.SelectedItem != null && cboSuppliers.Text.Trim() != "" ) { frmRep.Supplier = cboSuppliers.SelectedValue.ToString(); }
                    if (cboPatientState.SelectedItem != null ) {frmRep.Patient_Status_In_Out = cboPatientState.Text; }
                    if (cboPatientCategory.SelectedItem != null ) { frmRep.Aims_Service = cboPatientCategory.Text; }
                    if (cboGuarantors.SelectedItem != null && cboGuarantors.Text.Trim().Length > 0 ) { frmRep.Guarantor = cboGuarantors.SelectedValue.ToString(); }
                    
                    if (cboPatientCategory.SelectedItem  != null && cboPatientCategory.Text  == "Assist") 
                    {
                        if (cboAssistType.SelectedValue != null )
                        {
                            if (cboAssistType.Text != "")
                            {
                                frmRep.Aims_Service_type = cboAssistType.SelectedValue.ToString();         
                            }                            
                        }                        
                    }
                    if (cboPatientCategory.SelectedItem != null && cboPatientCategory.Text == "Transport") 
                    {
                        if (cboTransportType.SelectedValue  != null )
                        {
                            if (cboTransportType.Text != "" )
                            {
                                frmRep.Aims_Service_type = cboTransportType.SelectedValue.ToString();     
                            }                            
                        }                        
                    }

                    frmRep.ShowDialog();
                }
                catch (Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        /// <summary>
        /// This method populates the Titles combo box
        /// </summary>
        private void LoadTransportTypes()
        {
            try
            {
                DataTable tblAssistType = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new  AIMS.BLL.LookUpTableCollections();
                tblAssistType = lookupBLL.GetLookUpValues("TRANSPORT_TYPE_ID", "TRANSPORT_TYPE_DESC", "aims_transport_type", 0, "TRANSPORT_TYPE_DESC");
                cboTransportType.DataSource = tblAssistType;
                cboTransportType.DisplayMember = "TRANSPORT_TYPE_DESC";
                cboTransportType.ValueMember = "TRANSPORT_TYPE_ID";
                cboTransportType.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// This method populates the Titles combo box
        /// </summary>
        private void LoadAssistTypes()
        {
            try
            {
                DataTable tblTransportType = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new AIMS.BLL.LookUpTableCollections();
                tblTransportType = lookupBLL.GetLookUpValues("ASSIST_TYPE_ID", "ASSIST_TYPE_DESC", "aims_assist_type", 0, "ASSIST_TYPE_DESC");
                cboAssistType.DataSource = tblTransportType;
                cboAssistType.DisplayMember = "ASSIST_TYPE_DESC";
                cboAssistType.ValueMember = "ASSIST_TYPE_ID";
                cboAssistType.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void cboPatientCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTransportType.Visible = false ;
            cboAssistType.Visible = false;
            LBLPatientCat.Text = "";
            if (cboPatientCategory.Text == "Assist")
            {
                cboAssistType.Visible = true;
                cboAssistType.SelectedIndex = -1;
                LBLPatientCat.Text = "(Assist Type)";
            }

            if (cboPatientCategory.Text == "Transport")
            {
                cboTransportType.Visible = true;
                cboTransportType.SelectedIndex =-1;
                LBLPatientCat.Text = "(Transport Type)";
            }
        }

        private void radUserProductivity_CheckedChanged(object sender, EventArgs e)
        {
            //pnlPatientAnalysis.Visible = false;
            pnlInvoiceAnalysis.Visible = false;
            pnlPaymentsAnalysis.Visible = false;
            pnlUserProductivityOPS.Visible = true;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnPaymentsView_Click(object sender, EventArgs e)
        {

        }
    }
}