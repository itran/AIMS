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
    public partial class AddMedicalNote : Form
    {
        AIMS.Client.CommonFuncs CommonFuncs = new AIMS.Client.CommonFuncs();
        
        public AddMedicalNote()
        {
            InitializeComponent();
        }

        public AddMedicalNote(AIMS.BLL.Invoice clsIncoice)
        { 
        }

        private Int64  _supplierID;

        public Int64  SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }

        private Int64 _invoiceID;

        public Int64 InvoiceID
        {
            get { return _invoiceID; }
            set { _invoiceID = value; }
        }
	
        private void btnAddMedicalTreatment_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                AIMS.BLL.Invoice clsInvoice = new AIMS.BLL.Invoice();
                bool bSaved = false;
                try
                {
                    string ErrMsg = "";
                    if (!CapturedFields(ref ErrMsg))
                    {
                        MessageBox.Show(ErrMsg.ToString(), "Data Capture", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        clsInvoice.InvoiceID = System.Convert.ToInt32(InvoiceID);
                        clsInvoice.SupplierID = System.Convert.ToInt64(cboSuppliers.SelectedValue);
                        clsInvoice.MedicalTreatmentNotes = txtMedicalTreatment.Text;
                        clsInvoice.MedicalTreatmentDate = txtDateofTreatment.Text;

                        clsInvoice.ServiceRendered = cboServices.Text;

                        bSaved = clsInvoice.Medical_Treatment_Save();

                        if (bSaved)
                        {
                            MessageBox.Show("Medical Treatment Added successfully","New Treatment Save",MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();
                        }
                        else
                        {
                            MessageBox.Show("Medical Treatment NOT Added","New Treatment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw;
                }
                finally
                {
                    clsInvoice = null;
                }                
            }
        }

        private void AddMedicalNote_Load(object sender, EventArgs e)
        {
            DataTable dsSuppliers = CommonFuncs.LoadSuppliers();
            cboSuppliers.DataSource = dsSuppliers;

            cboSuppliers.DisplayMember = "SUPPLIER_NAME";
            cboSuppliers.ValueMember = "SUPPLIER_ID";
            cboSuppliers.SelectedIndex = -1;

            cboServices.Items.Insert(0, "");

            DataTable dsServices = CommonFuncs.LoadServices();
            cboServices.DataSource = dsServices;
            cboServices.DisplayMember = "SERVICE_DESCRIPTION";
            cboServices.ValueMember = "SERVICE_ID";
            cboServices.SelectedIndex = -1;
        }

        private bool CapturedFields(ref string ErrorMsg)
        {
            try
            {
                if (cboSuppliers.SelectedIndex <= 0 )
                {
                    ErrorMsg = "Supplier not Captured";
                    return false;
                }

                if (txtMedicalTreatment.Text.Trim().Length == 0)
                {
                    ErrorMsg = "Medical Treatment not Captured";
                    return false;                    
                }
                return true;
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// This method resets all the controls
        /// </summary>
        private void ClearControls()
        {
            txtMedicalTreatment.Text = "";
            cboServices.SelectedIndex = -1;
            cboSuppliers.SelectedIndex = -1;
            txtDateofTreatment.Text = "";
        }

        public bool ValidateControls()
        {
            
            bool returnVal = true;

            errProv.Clear();

            if (this.cboSuppliers.SelectedIndex == -1)
            {
                errProv.SetError(cboSuppliers, "Please select Supplier Rendered");
                cboSuppliers.Focus();
                returnVal = false;
            }

            if (this.txtMedicalTreatment.Text.Trim().Length == 0)
            {
                errProv.SetError(txtMedicalTreatment, "Please enter Medical Treatment");
                txtMedicalTreatment.Focus();
                returnVal = false;
            }

            if (this.cboServices.SelectedIndex == 0)
            {
                errProv.SetError(cboServices, "Please select Service Rendered");
                cboServices.Focus();
                returnVal = false;
            }

            if (returnVal == true)
            {
                errProv.Clear();
            }

            return returnVal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddMedicalNote_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 180);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);
        }

        private void txtDateofTreatment_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            txtDateofTreatment.Text = frmCal.StartDate.ToShortDateString();
            txtDateofTreatment.Focus();
        }

        private void lnklblDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDateofTreatment_DoubleClick(null,null);
        }

       

        
    }
}