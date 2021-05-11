using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIMS.BLL;
using AIMS.DAL;

namespace AIMSClient
{
    public partial class frmPatientFileSpawn : Form
    {
        string _PatientID = string.Empty;
        
        AIMS.Common.CommonFunctions commonFuncs;
        AIMS.BLL.Patient _patient;
        AIMS.DAL.PatientDAL _PatientDAL;
        DataTable tblTitles;
        DataTable tblGuarantors;
        DataTable tblCountries;
        DataSet dsInvoices;
        DataSet dsPatientEmails;
        DataSet dsPatientSentEmails;
        DataSet dsNotes;
        DataSet dsMedicalTreatment;
        DataTable tblSuppliers;
        int _saveCount = 0;
        string _selectedPatient = string.Empty;
        public string LateLogDate = "";
        public bool LoadSupplierInfo = false;

        string PatientEmailEnquiryID = "";
        string PatientSentEmailID = "";
        string WorkBasketEmailEnquiryID = "";

        string PatientEmailSubject = "";
        string PatientEmailFrom = "";
        string PatientEmailFromCC = "";

        string PatientSentEmailTo = "";
        string PatientSentEmailSubject = "";
        string PatientSentEmailFrom = "";
        string PatientSentEmailDTTM = "";
        string PatientSentEmailUser = "";

        string PatientEmailAttachmentID = "";
        string PatientEmailAttachmentDesc = "";
        int PatientEmailListIdx;
        string EmailReadYN = "";
        public string SentOrReceivedEmails = "";

        string _PatientFileNo = "";
        public string PatientFileNo
        {
            get { return _PatientFileNo; }
            set { _PatientFileNo = value; }
        }

        public frmPatientFileSpawn()
        {
            InitializeComponent();
        }

        private void aimsComboLookup1_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (aimsComboLookup1.lstItems.SelectedIndex != -1)
            {
                LoadPatientDetails();
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select a patient from the list.");
            }
        }

        private void LoadPatientDetails()
        {
            AIMS.BLL.Patient clsPatient = new Patient();
            _saveCount = 0;
            
            try
            {
                if (aimsComboLookup1.DataField1 == "PATIENT_FILE_NO")
                {
                    _selectedPatient = aimsComboLookup1.lstItems.Text;
                }
                else
                {
                    if (aimsComboLookup1.lstItems.SelectedValue != null && !aimsComboLookup1.lstItems.SelectedValue.Equals(""))
                    {
                        _selectedPatient = aimsComboLookup1.lstItems.SelectedValue.ToString();
                    }
                }

                _patient = clsPatient.GetPatientDetails(_selectedPatient, "N","");

                if (_patient != null)
                {
                    txtSurname.Text = _patient.PatientLastName;
                    txtFirstName.Text = _patient.PatientFirstName;
                    
                    txtInitials.Text = _patient.PatientInitials;
                    cboTitle.SelectedValue = _patient.TitleID;
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient Details, Please try again.");
                commonFuncs.ErrorLogger("Loading Patient Details, Please try again: \n" + ex.ToString());
            }
            finally
            {
                clsPatient = null;
            }
        }

        private void LoadPatients()
        {
            try
            {
                aimsComboLookup1.DataField1 = "PATIENT_NAME";
                aimsComboLookup1.DataField2 = "PATIENT_FILE_NO";

                aimsComboLookup1.OrderByField = "PATIENT_NAME";
                aimsComboLookup1.TableName = "AIMS_PATIENT_VW";

                aimsComboLookup1.ItemsLoaded = 50;

                aimsComboLookup1.Initialise("");
                aimsComboLookup1.txtSearch.Focus();
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Patient list.");
            }
        }

        private void frmPatientFileSpawn_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPatients();
                LoadTitles();
            }
            catch (System.Exception ex)
            {
            }
        }

        protected void aimsComboLookup1_DblClicked()
        {
            btnSelect_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpawn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedPatient.Equals(""))
                {
                    PatientFileNo = _selectedPatient;
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void LoadTitles()
        {
            try
            {
                tblTitles = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblTitles = lookupBLL.GetLookUpValues("TITLE_ID", "TITLE_DESC", "AIMS_TITLE", 0, "Title_Desc");
                cboTitle.DataSource = tblTitles;
                cboTitle.DisplayMember = "TITLE_DESC";
                cboTitle.ValueMember = "TITLE_ID";
                cboTitle.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}