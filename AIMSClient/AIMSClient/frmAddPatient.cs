using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIMS.Common;
using AIMS.BLL;
using AIMS.DAL;

namespace AIMSClient
{
    public partial class frmAddPatient : Form
    {
        public frmAddPatient()
        {
            InitializeComponent();
        }

        AIMS.Common.CommonFunctions CommonFuncs;
        AIMS.BLL.Patient _patient;
        AIMS.DAL.PatientDAL _PatientDAL;

        string _PatientFileNo = "";
        public string PatientFileNo
        {
            get { return _PatientFileNo; }
            set { _PatientFileNo = value; }
        }

        string _Restrictions = "";
        public string Restrictions
        {
            get { return _Restrictions; }
            set { _Restrictions = value; }
        }

        string _userID = "";
        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }

        private bool ValidateControls()
        {
            bool returnVal = true;
            errPatients.Clear();

            if (txtSurname.Text.Length == 0)
            {
                errPatients.SetError(txtSurname, "Please enter the patient's surname");
                txtSurname.Focus();
                btnAddPatient.Enabled = true;
                returnVal = false;
                
            }

            if (txtEmailAddr.Text.Trim().Length > 0)
            {
                if (!CommonFuncs.ValidEmailAddress(txtEmailAddr.Text.Trim()))
                {
                    errPatients.SetError(txtEmailAddr, "Please enter valid email address");
                    txtEmailAddr.Focus();
                    btnAddPatient.Enabled = true;
                    returnVal = false;
                    
                }
            }
            return returnVal;
        }

        private void frmAddPatient_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                LoadCombos();
                if (!PatientFileNo.Equals(""))
                {
                    txtPatientFileNo.Text = PatientFileNo;
                    LoadPatientDetails(PatientFileNo, "N");
                }

                btnPatientSearch.Enabled = Enabled;

                if (txtPatientFileNo.Text.Trim().Equals(""))
                {
                    chkArchiveFile.Checked = false;
                    chkArchiveFile.Enabled = false;
                }
                else
                {
                    btnPatientSearch.Enabled = false;
                }
                btnAddPatient.Enabled = UserAllowed("5");
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Patient Details Form load error, Please contact System Administrator");
                CommonFuncs.ErrorLogger("Patient Details Form load error, Please contact System Administrator\n" + ex.ToString());
            }
            finally {
                Cursor.Current = Cursors.Default;
            }
        }

        private void LoadCombos()
        {
                CommonFuncs = new AIMS.Common.CommonFunctions();
                DataTable dtCountries = CommonFuncs.GetCountries();
                cboCountry.DataSource = dtCountries;
                cboCountry.DisplayMember = "COUNTRY_NAME";
                cboCountry.ValueMember = "COUNTRY_ID";
                cboCountry.SelectedValue = -1;

                DataTable dtTitles = CommonFuncs.GetTitles();
                cboTitle.DataSource = dtTitles;
                cboTitle.DisplayMember = "TITLE_DESC";
                cboTitle.ValueMember = "TITLE_ID";
                cboTitle.SelectedValue = -1;

                DataTable dtReligion = CommonFuncs.GetReligion();
                cboReligion.DataSource = dtReligion;
                cboReligion.DisplayMember = "RELIGION";
                cboReligion.ValueMember = "RELIGION_ID";
                cboReligion.SelectedValue = -1;
                
                LoadFlightGuarantors();
                LoadGuarantors();
        }

        /// <summary>
        /// This method populates the Guarantor combo box
        /// </summary>
        private void LoadFlightGuarantors()
        {
            DataTable tblGuarantors = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
            //commonFuncs = new AIMS.Common.CommonFunctions();

            try
            {
                tblGuarantors = lookupBLL.GetLookUpValues("GUARANTOR_ID", "GUARANTOR_NAME", "AIMS_GUARANTOR", 0, "GUARANTOR_NAME");
                cboFlightGuarantors.DataSource = tblGuarantors;
                cboFlightGuarantors.DisplayMember = "GUARANTOR_NAME";
                cboFlightGuarantors.ValueMember = "GUARANTOR_ID";
                cboFlightGuarantors.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }


        /// <summary>
        /// This method populates the Guarantor combo box
        /// </summary>
        private void LoadGuarantors()
        {
            DataTable tblGuarantors = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
            //commonFuncs = new AIMS.Common.CommonFunctions();

            try
            {
                tblGuarantors = lookupBLL.GetLookUpValues("GUARANTOR_ID", "GUARANTOR_NAME", "AIMS_GUARANTOR", 0, "GUARANTOR_NAME");
                cboGuarantors.DataSource = tblGuarantors;
                cboGuarantors.DisplayMember = "GUARANTOR_NAME";
                cboGuarantors.ValueMember = "GUARANTOR_ID";
                cboGuarantors.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
            finally
            {
                //tblGuarantors.Dispose();
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                if (SavePatientDetails())
                {
                    CommonFuncs.DisplayMessage(CommonTypes.MessagType.Success, "Patient Header details saved succesfully.");
                    PatientFileNo = txtPatientFileNo.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "(3)Saving Patient Portfolio failed, Please contact System Administrator.");
                    CommonFuncs.ErrorLogger("Saving Patient Header Details failed, Please contact System Administrator");
                }
            }
        }

        private bool SavePatientDetails()
        {
            Patient clsPatient = new Patient();
            string patientFileNo = string.Empty;
            bool returnValue = false;
            _PatientDAL = new PatientDAL();

            try
            {
                _PatientDAL.PatientFirstName = txtFirstName.Text.Trim();
                _PatientDAL.PatientLastName = txtSurname.Text.Trim();
                _PatientDAL.PatientInitials = txtInitials.Text.Trim();
                
                _PatientDAL.PatientFaxNo = txtFaxNum.Text;
                _PatientDAL.MobileNumber = txtMobileNumber.Text;
                _PatientDAL.WorkTelNumber = txtWorkTelNum.Text;
                _PatientDAL.PatientFileNo = txtPatientFileNo.Text;
                _PatientDAL.PatientEmailAddr = txtEmailAddr.Text;
                _PatientDAL.Nationality = txtNationality.Text;
                
                _PatientDAL.DateOfBirth = txtDateOfBirth.Text;

                _PatientDAL.AddressLine1 = txtAddr1.Text;
                _PatientDAL.AddressLine2 = txtAddr2.Text;
                _PatientDAL.AddressLine3 = txtAddr3.Text;
                _PatientDAL.AddressLine4 = txtAddr4.Text;
                _PatientDAL.AddressLine5 = txtAddr5.Text;
                //_PatientDAL.VisaExpiryDate = txtVisaExipryDate.Text;
                _PatientDAL.IDNumber = txtPassport.Text;
                _PatientDAL.Guarantor247Email = txtGuarantee247Email.Text;
                _PatientDAL.Guarantor247No = txtGuarantee247No.Text;
                //if (cboReligion.SelectedItem != null)
                //{
                //    _PatientDAL.Religion = Convert.ToInt32(cboReligion.SelectedValue.ToString());
                //}

                if (cboGuarantors.SelectedItem != null)
                {
                    _PatientDAL.GuaranteeID = Convert.ToInt32(cboGuarantors.SelectedValue.ToString());
                }

                if (cboFlightGuarantors.SelectedItem != null)
                {
                    _PatientDAL.FlightGuarantorID = Convert.ToInt32(cboFlightGuarantors.SelectedValue.ToString());
                }

                //if (chkArchiveFile.Checked)
                //{
                //    _PatientDAL.FileArchived = "Y";
                //}
                //else
                //{
                //    _PatientDAL.FileArchived = "";
                //}

                _PatientDAL.HomeTelNumber = txtHomePhone.Text;
                
                _PatientDAL.PatientFaxNo = txtFaxNum.Text;
                _PatientDAL.PatientFileNo = txtPatientFileNo.Text;

                if (cboTitle.SelectedIndex != 1)
                {
                    if (cboTitle.SelectedValue != null)
                    {
                        _PatientDAL.TitleID = Convert.ToInt32(cboTitle.SelectedValue.ToString());
                    }
                }

                if (cboCountry.SelectedIndex != -1)
                {
                    if (cboCountry.SelectedValue != null)
                    {
                        _PatientDAL.CountryID = Convert.ToInt32(cboCountry.SelectedValue.ToString());
                    }
                }
           
                if (txtPatientFileNo.Text.Length == 0)
                {
                    patientFileNo = clsPatient.SavePatientHeaderDetails(_PatientDAL, UserID);
                    CommonFuncs.ErrorLogger("Saving Patient Header Details Patient File : " + patientFileNo);
                    if (patientFileNo.Length > 0)
                    {
                        txtPatientFileNo.Text = patientFileNo;
                        PatientFileNo = txtPatientFileNo.Text;
                        returnValue = true;
                    }
                    else
                    {
                        CommonFuncs.ErrorLogger("Saving Patient Proc Problem");
                        returnValue = false;
                    }
                }
                else
                {
                    patientFileNo = clsPatient.SavePatientHeaderDetails(_PatientDAL, UserID);

                    if (patientFileNo.Length > 0)
                    {
                        txtPatientFileNo.Text = patientFileNo;
                        PatientFileNo = txtPatientFileNo.Text;
                        returnValue = true;
                    }
                    else
                    {
                        CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "(1)Saving Patient Portfolio failed, Please contact System Administrator.");
                        CommonFuncs.ErrorLogger("1. Saving Patient Header Details failed, Please contact System Administrator");
                        returnValue = false;
                    } 
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "(2)Saving Patient Portfolio failed, Please contact System Administrator, Error: " + ex.Message);
                CommonFuncs.ErrorLogger("1. Saving Patient Portfolio failed: \n" + ex.Message);
            }
            finally
            {
                clsPatient = null;
                _PatientDAL = null;
            }
            return returnValue;
        }

        private void btnPatientSearch_Click(object sender, EventArgs e)
        {
            frmPatientFileSpawn frmPatientSpawn;
            frmPatientSpawn = new frmPatientFileSpawn();
            frmPatientSpawn.ShowInTaskbar = false;
            frmPatientSpawn.StartPosition = FormStartPosition.CenterScreen;
            frmPatientSpawn.Text = "Spawn Patient File Details ";
            frmPatientSpawn.PatientFileNo = "";
            frmPatientSpawn.ShowDialog();

            if (!frmPatientSpawn.PatientFileNo.Equals(""))
            {
                LoadPatientDetails(frmPatientSpawn.PatientFileNo, "N");
            }
        }

        private void LoadPatientDetails(string PatientFileNo, string EnquiryYN)
        {
            AIMS.BLL.Patient clsPatient = new Patient();
            
            errPatients.Clear();
            try
            {
                _patient = clsPatient.GetPatientHeaderDetails(PatientFileNo, EnquiryYN, UserID);

                if (_patient != null)
                {
                    txtSurname.Text = _patient.PatientLastName;
                    txtFirstName.Text = _patient.PatientFirstName;
                    txtFaxNum.Text = _patient.PatientFaxNo;
                    txtDateOfBirth.Text = _patient.DateOfBirth;
                    txtPassport.Text = _patient.IDNumber;
                    txtAddr1.Text = _patient.AddressLine1;
                    txtAddr2.Text = _patient.AddressLine2;
                    txtAddr3.Text = _patient.AddressLine3;
                    txtAddr4.Text = _patient.AddressLine4;
                    txtAddr5.Text = _patient.AddressLine5;
                    
                    cboTitle.SelectedValue = _patient.TitleID;
                    txtEmailAddr.Text = _patient.PatientEmailAddr;
                    txtMobileNumber.Text = _patient.MobileNumber;
                    txtHomePhone.Text = _patient.HomeTelNumber;
                    txtWorkTelNum.Text = _patient.WorkTelNumber;
                    txtNationality.Text = _patient.Nationality;
                    txtInitials.Text = _patient.PatientInitials;
                    cboCountry.SelectedValue = _patient.CountryID;
                    //cboReligion.SelectedValue = _patient.Religion;

                    cboFlightGuarantors.SelectedValue = _patient.FlightGuarantorID;
                    cboGuarantors.SelectedValue = _patient.GuarantorID;
                    
                    //if (_patient.FileArchived =="Y")
                    //{
                    //    chkArchiveFile.Checked = true;
                    //}
                    //else
                    //{
                    //    chkArchiveFile.Checked = false;
                    //}

                    //txtVisaExipryDate.Text = _patient.VisaExpiryDate;
                    txtGuarantee247No.Text = _patient.Guarantor247No;
                    txtGuarantee247Email.Text = _patient.Guarantor247Email;
                    LoadGuarantorDetails(_patient.GuarantorID.ToString());
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient Details, Please try again.");
                CommonFuncs.ErrorLogger("Loading Patient Details, Please try again: \n" + ex.ToString());
            }
            finally
            {
                clsPatient = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSurname.Text = "";
            txtFirstName.Text = "";
            txtFaxNum.Text = "";
            txtDateOfBirth.Text = "";

            txtAddr1.Text = "";
            txtAddr2.Text = "";
            txtAddr3.Text = "";
            txtAddr4.Text = "";
            txtAddr5.Text = "";

            cboTitle.SelectedValue = -1;
            txtEmailAddr.Text = "";
            txtMobileNumber.Text = "";
            txtHomePhone.Text = "";
            txtWorkTelNum.Text = "";

            txtInitials.Text = "";
            cboCountry.SelectedValue = -1;

            txtGuarantee247Email.Text = "";
            txtGuarantee247No.Text= "";
            cboGuarantors.SelectedValue = -1;
            txtVisaExipryDate.Text = "";
            txtPassport.Text = "";
            txtNationality.Text = "";
        }

        private void txtPatientFileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpbxPatientDetails_Enter(object sender, EventArgs e)
        {

        }

        private void lnklblVisaExpiryDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtVisaExipryDate_DoubleClick(null, null);
        }

        private void txtVisaExipryDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtVisaExipryDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtVisaExipryDate.Focus();
        }

        private void cboGuarantors_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmGuarantors frmGuarantors = new frmGuarantors();
            frmGuarantors.Text = "Add Guarantor";

            try
            {
                if (cboGuarantors.SelectedItem != null && cboGuarantors.Text == "<Add New Guarantor>")
                {
                    if (MessageBox.Show("Continue with adding a new guarantor?", "New Guarantor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (cboGuarantors.SelectedIndex > 0)
                        {
                            if (cboGuarantors.SelectedValue != null)
                            {
                                frmGuarantors.AddNewGuarantor = true;
                                frmGuarantors.GuarantorID = System.Convert.ToInt32(cboGuarantors.SelectedValue);
                            }
                        }
                        else
                        {
                            frmGuarantors.AddNewGuarantor = true;
                            frmGuarantors.GuarantorID = 0;
                        }
                        frmGuarantors.Restrictions = Restrictions;
                        
                        //frmGuarantors.Height = frmGuarantors.Height - 150;
                        frmGuarantors.FormBorderStyle = FormBorderStyle.FixedSingle;
                        frmGuarantors.StartPosition = FormStartPosition.CenterScreen;
                        frmGuarantors.MaximizeBox = false;
                        frmGuarantors.MinimizeBox = false;
                        frmGuarantors.ShowDialog();
                        LoadGuarantors();
                    }
                    else
                    {
                        cboGuarantors.SelectedValue = -1;
                    }
                }
                else if (cboGuarantors.SelectedItem != null && cboGuarantors.Text == "FLIGHTS")
                {
                    cboFlightGuarantors.Enabled = true;
                }
                else
                {
                    cboFlightGuarantors.Enabled = false;
                    cboFlightGuarantors.SelectedValue = -1;
                    if (cboGuarantors.SelectedIndex > 0)
                    {
                        LoadGuarantorDetails(cboGuarantors.SelectedValue.ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Guarantor selection error: " + ex.ToString());
            }
            finally
            {
                frmGuarantors = null;
            }
        }

        private void cboFlightGuarantors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkArchiveFile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoadGuarantorDetails(string GuarantorID)
        {
            AIMS.BLL.Guarantor clsGuarantor = new AIMS.BLL.Guarantor();
            AIMS.BLL.Guarantor _guarantor;
            try
            {
                _guarantor = clsGuarantor.GetGuarantorDetails(GuarantorID);

                if (_guarantor != null)
                {
                    txtGuarantee247Email.Text = _guarantor.GuarantorEmailAddress.Trim();
                    txtGuarantee247No.Text = _guarantor.GuarantorPhoneNo.Trim();
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Guarantor Details");
                clsGuarantor = null;
            }
            finally
            {
                clsGuarantor = null;
            }
        }

        private void txtDateOfBirth_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDateOfBirth_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtDateOfBirth.Text = frmCal.StartDate.ToShortDateString();
            }

            txtDateOfBirth.Focus();
        }

        private void lnklblPatientDOB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDateOfBirth_DoubleClick(null, null);
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

    }
}