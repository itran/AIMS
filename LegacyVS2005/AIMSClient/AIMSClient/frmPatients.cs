using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIMS.BLL;
using AIMS.DAL;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Forms;
using System.Reflection; 

namespace AIMSClient
{
    public partial class frmPatients : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        #region Global Variables
        string PatientSearch = "";
        string _PatientID = string.Empty;
        frmMedicalTreatment frmMed;
        frmComments frmNotes;

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
        string PatientEmailTo = "";

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
        #endregion

        #region Constructor

        public frmPatients()
        {
            InitializeComponent();

        }
        #endregion

        #region "Private Properties"
        string _userName = Constants.NullString;
        string _userEmailAddress = Constants.NullString;
        string _userID = Constants.NullString;
        string BccEmailAddress = Constants.NullString;
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
        string _signaturePath = "";
        public string SignaturePath
        {
            get { return _signaturePath; }
            set
            {
                _signaturePath = value;
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


        #endregion

        #region Control Events

        
        private void tabPatientEmail_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                string selectedTab = e.TabPage.Text;
                switch (selectedTab)
                {
                    case "Received Emails":
                        break;
                    case "Sent Emails":
                        break;
                    case "Patient Email Audit":
                        break;
                    default:
                        break;
                }

                if (e.TabPage.Text == "Received Emails")
                {
                    if (lstPatientFileEmails.SelectedItems[0].Index >0)
                    {
                        PatientEmailTo = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[7].Text.ToString(); ;
                        SentOrReceivedEmails = "RECEIVED_MAILS";
                        PatientEmailEnquiryID = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[5].Text.ToString();
                        PatientEmailSubject = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[0].Text.ToString();
                        PatientEmailFrom = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[2].Text.ToString();
                        PatientEmailFromCC = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[4].Text.ToString();
                        PatientEmailListIdx = lstPatientFileEmails.SelectedItems[0].Index;  
                    }
                }
                else
                {
                    if (lstPatientSentEmails.SelectedItems[0].Index >0)
                    {
                        PatientSentEmailID = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[6].Text.ToString();
                        PatientEmailTo = "";
                        if (!PatientSentEmailID.Equals(""))
                        {
                            SentOrReceivedEmails = "SENT_MAILS";


                            PatientEmailSubject = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[3].Text.ToString();
                            PatientEmailFrom = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[2].Text.ToString();
                            PatientEmailFromCC = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[1].Text.ToString();
                            PatientEmailTo = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[0].Text.ToString();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                //commonFuncs.ErrorLogger("Error loading the Patient Form: \n" + ex.ToString());
            }
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                ServiceProvidersSetup();
                cboFileAssignedTo.Enabled = false;
                cboOPSFileOwner.Enabled = false;
                chkCancelled.Enabled = false;
                LoadPatients();
                LoadGuarantorSearch();
                txtPatientFileNo.ReadOnly = true;
                LoadTitles();
                LoadAssistTypes();
                LoadTransportTypes();
                LoadRepatriationTypes();
                LoadEvacuationTypes();
                LoadRMRTypes();
                LoadGuarantors();
                LoadFlightGuarantors();
                LoadCountries();
                InvoiceSetup();
                LoadAddressTypes();
                MedicalTreatmentSetup();
                PatientSentEmailsListSetup();
                PatientAppointmentListSetup();
                
                NotesSetup("PATIENTCOMMENT");
                NotesSetup("PATIENTLATESTUPDATE");
                NotesSetup("PATIENTMEDICALHISTORY");
                NotesSetup("PATIENTADMINNOTES");
                NotesSetup("PATIENTFINANCENOTES");
                NotesSetup("PATIENTINTERIMNOTES");
                TasksSetup();
                ProcessedEmailsSetup();

                LoadSuppliers();
                AuditSetup();
                LoadFileAdministrators();
                LoadFileOperators();
                btnDelete.Visible = false;

                gpbxPatient.Enabled = false;
                infoText.Text = "";

                btnUnlockFile.Enabled = false;
                btnSave.Enabled = false;
                chkFileClosed.Enabled = UserAllowed("7");
                chkCancelled.Enabled = UserAllowed("25");
                btnAddNew.Enabled = false;
                btnAddPatient.Enabled = false;
                btnAddNew.Enabled = UserAllowed("5");
                btnAddPatient.Enabled = UserAllowed("5");
                btnAddMedicalNote.Enabled = UserAllowed("35");

                btnAddInterimNote.Enabled = UserAllowed("89");
                btnAddFinanceNote.Enabled = UserAllowed("88");
                btnAddAdminNote.Enabled = UserAllowed("87");
                
                btnEmailReIndex.Enabled = UserAllowed("74");
                btnEmailDelete.Enabled = UserAllowed("75");

                btnWorkBasketView.Enabled = UserAllowed("83");
                
                if (UserAllowed("25"))
                {
                    chkCancelled.Enabled = true;
                }

                PatientEmailsSetup();
                LoadMyMailbox();
                //GetBccEmailAddress();
                LoadTemplates("");

            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading the Patient Form");
                commonFuncs.ErrorLogger("Error loading the Patient Form: \n" + ex.ToString());
            }

        }

        private void panel1_Resize(object sender, EventArgs e)
        {
        }

        private void frmPatients_Resize(object sender, EventArgs e)
        {
            this.gpbxPatientSearch.Left = this.Left + 2;
            this.gpbxPatientSearch.Height = Convert.ToInt32(this.ClientSize.Height * 0.30);
            this.gpbxPatient.Top = gpbxPatientSearch.Bottom + 2;

            this.gpbxPatient.Left = this.Left + 2;
            this.gpbxPatient.Width = this.ClientSize.Width - 4;

            this.gpbxPatientSearch.Width = this.ClientSize.Width - 4;
            
            this.gpbxGaurantorSearch.Left = this.ClientSize.Width / 2;
            this.gpbxGaurantorSearch.Height = Convert.ToInt32(this.ClientSize.Height * 0.30);

            this.gpbxPatient.Height = Convert.ToInt32(this.ClientSize.Height * 0.62);

            this.aimsComboLookup1.Top = gpbxPatientSearch.Top + 10;
            this.aimsComboLookup1.Width = Convert.ToInt32(gpbxPatientSearch.Width * 0.35);
            this.aimsComboLookup1.Height = Convert.ToInt32(gpbxPatientSearch.Height * 0.80);
            this.aimsComboLookup1.lstItems.Height = Convert.ToInt32(gpbxPatientSearch.Height * 0.55);

            this.aimsComboLookup2.Top = gpbxPatientSearch.Top + 10;
            this.aimsComboLookup2.Width = Convert.ToInt32(gpbxPatientSearch.Width * 0.35);
            this.aimsComboLookup2.Height = Convert.ToInt32(gpbxPatientSearch.Height * 0.80);
            this.aimsComboLookup2.lstItems.Height = Convert.ToInt32(gpbxPatientSearch.Height * 0.55);
            

            this.gpbxOperatorMails.Top = gpbxPatientSearch.Top + 10;
            this.gpbxOperatorMails.Left = (aimsComboLookup1.Left + aimsComboLookup1.Width) + 10;
            this.gpbxOperatorMails.Height = this.aimsComboLookup1.Height + 1;

            this.pnlButtonSearch.Top = gpbxPatientSearch.Height - 30;
            this.pnlButtonSearch.Height = 27;

            this.pnlButtonSearch.Left = aimsComboLookup1.Left;
            this.pnlButtonSearch.Width = aimsComboLookup1.Width - 10;

            this.btnDelete.Left = (pnlButtonSearch.Right - (btnDelete.Width + 10));
            this.btnAddPatient.Left = aimsComboLookup1.Right - (btnAddPatient.Width + 20);//Convert.ToInt32((pnlButtonSearch.Width * 0.5) - 30);
            this.btnSelect.Left = pnlButtonSearch.Left;

            this.tabControl1.Width = this.gpbxPatient.Width - 10;
            this.tabControl1.Height = Convert.ToInt32(this.gpbxPatient.Height * 0.92);

            this.pnlPatientMain.Height = Convert.ToInt32(tabPatients.Height * 0.95);
            this.pnlPatientMain.Width = Convert.ToInt32(tabPatients.Width * 1.2);

            this.pnlButtons.Top = this.gpbxPatient.Bottom;
            this.btnSave.Left = Convert.ToInt32(this.ClientSize.Width * 0.35);
            this.btnClose.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);
            this.btnUnlockFile.Left = Convert.ToInt32(this.ClientSize.Width * 0.6);
            this.pnlButtons.Width = this.gpbxPatient.Width;
            this.btnPatientTranscript.Left = this.btnSave.Left + this.btnSave.Width;
            this.btnPatientTranscript.Top = this.btnSave.Top;

            this.lstvwInvoices.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwInvoices.Height = Convert.ToInt32(tabPatients.Height * 0.90);
            this.Left = this.tabPatients.Left + 10;

            this.lstvwMedicalTreatment.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwMedicalTreatment.Height = Convert.ToInt32(tabPatients.Height * 0.97);
            this.Left = this.tabPatients.Left + 10;

            this.lstvwAuditing.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwAuditing.Height = Convert.ToInt32(tabPatients.Height * 0.97);
            this.Left = this.tabPatients.Left + 10;

            this.lstvwLateInvoice.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwLateInvoice.Height = Convert.ToInt32(tabPatients.Height * 0.90);

            this.lstvwTasks.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwTasks.Height = Convert.ToInt32(tabPatients.Height * 0.90);

            this.lstvwTasksCompleted.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwTasksCompleted.Height = Convert.ToInt32(tabPatients.Height * 0.90);

            this.lstvwTasksCancelled.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwTasksCancelled.Height = Convert.ToInt32(tabPatients.Height * 0.90);
            
            this.lstvwDoctorOwing.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwDoctorOwing.Height = Convert.ToInt32(tabPatients.Height * 0.90);

            this.Left = this.tabPatients.Left + 10;

            this.lstlvwNotes.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            //this.lstlvwNotes.Height = Convert.ToInt32(tabPatients.Height * 0.85);

            this.lstvwServiceProviders.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwServiceProviders.Height = Convert.ToInt32(tabPatients.Height * 0.90);

            this.lstlvwMedNotes.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstlvwMedNotes.Height = Convert.ToInt32(tabPatients.Height * 0.85);


            btnEditPatientNote.Top = this.btnAddComment.Top;
            btnEditPatientNote.Left = this.btnAddComment.Left + this.btnAddComment.Width;

            btnNotesIM.Top = this.btnEditPatientNote.Top;
            btnNotesIM.Left = this.btnEditPatientNote.Left + this.btnEditPatientNote.Width;

            btnEmailCaseSummary.Top = this.btnAddComment.Top;
            btnEmailCaseSummary.Left = this.btnEditPatientNote.Left + this.btnEditPatientNote.Width;
            
            this.lstvwMedicalTreatment.Width = Convert.ToInt32(tabPatients.Width * 0.99);
            this.lstvwMedicalTreatment.Height = Convert.ToInt32(tabPatients.Height * 0.90);
            
            this.btnAddMedicalNote.Top = this.lstlvwMedNotes.Bottom + 2;
            this.btnAddMedicalNote.Left = this.lstlvwMedNotes.Left;

            //btnViewMedicalReport.Top = this.lstlvwMedNotes.Bottom + 2;
            //btnViewMedicalReport.Left = this.btnAddMedicalNote.Left + this.btnAddMedicalNote.Width + 2;
            btnEditMedPatientNote.Top = this.lstlvwMedNotes.Bottom + 2;
            btnEditMedPatientNote.Left = this.btnAddMedicalNote.Left + this.btnAddMedicalNote.Width + 2;

            btnEmailMedicalSummary.Top = this.lstlvwMedNotes.Bottom + 2;
            btnEmailMedicalSummary.Left = this.btnEditMedPatientNote.Left + this.btnAddMedicalNote.Width + 2;

            this.btnAddAdminNote.Top = tabPage3.ClientSize.Height - this.btnAddAdminNote.Height;
            this.btnAddAdminNote.Left = this.lstlvwNotes.Left;

            this.lstlvwAdminNotes.Width = this.lstlvwNotes.Width;
            this.lstlvwAdminNotes.Height = (this.btnAddAdminNote.Bottom - this.btnAddAdminNote.Height) - 5;
            this.lstlvwAdminNotes.Left = lstlvwNotes.Left;

            btnEditAdminNote.Top = this.btnAddAdminNote.Top;
            btnEditAdminNote.Left = this.btnAddAdminNote.Left + this.btnAddAdminNote.Width;

            this.btnAddFinanceNote.Top = tabPage3.ClientSize.Height - this.btnAddFinanceNote.Height;
            this.btnAddFinanceNote.Left = this.lstlvwNotes.Left;

            this.lstlvwFinanceNotes.Width = this.lstlvwNotes.Width;
            this.lstlvwFinanceNotes.Height = (this.btnAddFinanceNote.Bottom - this.btnAddFinanceNote.Height) - 5;
            this.lstlvwFinanceNotes.Left = lstlvwNotes.Left;

            btnEditFinanceNote.Top = this.btnAddFinanceNote.Top;
            btnEditFinanceNote.Left = this.btnAddAdminNote.Left + this.btnAddAdminNote.Width;

            this.btnServiceProvider.Top = this.lstvwServiceProviders.Bottom + 2;
            this.btnServiceProvider.Left = this.lstvwServiceProviders.Left;

            this.btnRemoveServiceProvider.Top = this.lstvwServiceProviders.Bottom + 2;

            this.btnViewReports.Top = this.lstvwInvoices.Bottom + 2;
            this.btnViewReports.Left = this.lstvwServiceProviders.Bottom + 2;
            btnEmailInvoices.Top = btnViewReports.Top;
            btnEmailInvoices.Height = btnViewReports.Height;
            btnEmailInvoices.Left = lstvwInvoices.Width - btnEmailLateInvoices.Width;

            //btnAddTask.Top = this.lstvwTasks.Bottom + 2;
            btnAddTask.Top = this.tabTasks.Bottom - btnAddTask.Height ;
            btnAddTask.Left = this.lstvwTasks.Left;

            tabTask.Height = btnAddTask.Top-2;
            tabTask.Width = this.tabTasks.ClientSize.Width;

            tabAppointment.Height = btnAddNewAppointment.Top - 2;
            tabAppointment.Width = this.tabAppointments.ClientSize.Width;

            this.btnViewDoctorOwingReport.Top = this.lstvwDoctorOwing.Bottom + 2;
            this.btnViewDoctorOwingReport.Left = this.lstvwDoctorOwing.Left;

            this.btnViewLateInvoices.Top = this.lstvwInvoices.Bottom + 2;
            this.btnViewLateInvoices.Left = this.lstvwInvoices.Left;
            btnEmailLateInvoices.Top = btnViewLateInvoices.Top;
            btnEmailLateInvoices.Height = btnViewLateInvoices.Height;
            btnEmailLateInvoices.Left = lstvwInvoices.Width - btnEmailLateInvoices.Width;

            this.chkIncludeSentLateInv.Top = this.btnViewLateInvoices.Top + 10;
            this.chkIncludeSentLateInv.Left = this.btnViewLateInvoices.Left + this.btnViewLateInvoices.Width + 10;

            this.Left = this.tabPatients.Left + 10;

            this.btnRefresh.Left = btnSelect.Width + 20;
            this.btnRefresh.Top = btnSelect.Top;
            this.btnRefresh.Width = btnSelect.Width;
            this.btnViewReports.Left = this.lstvwInvoices.Left;

            this.btnAddInterimNote.Top = tabPage3.ClientSize.Height - this.btnAddFinanceNote.Height;
            this.btnAddInterimNote.Left = this.lstlvwNotes.Left;

            this.lstlvwInterimNotes.Width = this.lstlvwNotes.Width;
            this.lstlvwInterimNotes.Height = (this.btnAddInterimNote.Bottom - this.btnAddInterimNote.Height) - 5;
            this.lstlvwInterimNotes.Left = lstlvwNotes.Left;

            btnEditInterimNote.Top = this.btnAddFinanceNote.Top;
            btnEditInterimNote.Left = this.btnAddInterimNote.Left + this.btnAddInterimNote.Width;

            btnAddTask.Top = this.tabTasks.Bottom - btnAddTask.Height;
            btnAddTask.Left = this.lstvwTasks.Left;

            btnAddNewAppointment.Top = this.tabAppointments.Bottom - btnAddNewAppointment.Height;
            btnAddNewAppointment.Left = this.lstvwAppointments.Left;

            tabAppointment.Height = btnAddNewAppointment.Top - 2;
            tabAppointment.Width = this.tabAppointments.ClientSize.Width;
            btnAppointmentsAudit.Top = btnAddNewAppointment.Top;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew.Enabled = false;
            frmMed = new frmMedicalTreatment("");
            frmMed.ShowInTaskbar = false;
            frmMed.ShowDialog();
        }

        private void frmPatients_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 360);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);

        }

        private void gpbxPatient_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            try
            {
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteID = 0;
                frmNotes.NoteTypeCode = "PATIENTCOMMENT";
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    LoadPatientNotes();

                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (PatientSearch =="")
            {
                PatientSearch = "PATIENT";
            }
            //PatientSearch = "PATIENT";
            if ((PatientSearch == "PATIENT" && aimsComboLookup1.lstItems.SelectedIndex != -1) || (PatientSearch == "GUARANTOR" && aimsComboLookup2.lstItems.SelectedIndex != -1))
            {
                LoadSupplierInfo = true;
                LoadPatientDetails();
                gpbxPatient.Enabled = true;
                LoadSupplierInfo = false;
                LoadInvoices();
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select a patient from the list.");
            }
        }

        /// <summary>
        /// This method saves patient details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            ClearControls();
            lblPatientFileNumber.Text = "";
            DisableControls(false);
            gpbxPatient.Enabled = true;
            txtFirstName.Focus();
            btnSave.Enabled = UserAllowed("5");

            try
            {
                frmPatientFileSpawn  frmPatientSpawn;
                frmPatientSpawn = new frmPatientFileSpawn();
                frmPatientSpawn.ShowInTaskbar = false;
                frmPatientSpawn.StartPosition = FormStartPosition.CenterScreen;
                frmPatientSpawn.Text = "Patient File Details ";
                frmPatientSpawn.PatientFileNo = "";
                frmPatientSpawn.ShowDialog();
               
                if (!frmPatientSpawn.PatientFileNo.Equals(""))
                {
                    LoadPatientDetails(frmPatientSpawn.PatientFileNo, "N");   
                } 
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Service Provider could not load, Error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            try
            {
                //createPDFReport("INTIMATED");
                _saveCount = 0;
                Int64 LastPatient = 0;
                if ((PatientSearch == "PATIENT" && aimsComboLookup1.lstItems.SelectedIndex != null && aimsComboLookup1.lstItems.SelectedIndex > 0) || (PatientSearch == "GUARANTOR" && aimsComboLookup2.lstItems.SelectedIndex != null && aimsComboLookup2.lstItems.SelectedIndex > 0))
                {
                    if (PatientSearch == "PATIENT")
                    {
                        LastPatient = aimsComboLookup1.lstItems.SelectedIndex;
                    }
                    else if (PatientSearch == "GUARANTOR")
                    {
                        LastPatient = aimsComboLookup2.lstItems.SelectedIndex;
                    }
                }

                if (_saveCount == 0)
                {
                    btnSave.Enabled = false;
                    if (MessageBox.Show("You are about to save patient details, please make sure that all information captured is correct.\n\nAre you sure you want to continue?", "AIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        _saveCount += 1;
                        return;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        if (ValidateControls())
                        {
                            btnSave.Enabled = false;
                            if (SavePatientDetails())
                            {
                                btnSave.Enabled = false;
                                LoadSupplierInfo = true;
                                MessageBox.Show("Patient details saved succesfully", "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                aimsComboLookup1.lstItems.DataSource = null;
                                aimsComboLookup1.Clear();
                                aimsComboLookup1.CheckDescription();

                                aimsComboLookup2.lstItems.DataSource = null;
                                aimsComboLookup2.Clear();
                                aimsComboLookup2.CheckDescription();

                                LoadPatients();
                                LoadGuarantorSearch();
                                LoadSupplierInfo = false;

                                if (LastPatient > 0)
                                {
                                    if (PatientSearch == "PATIENT")
                                    {
                                        aimsComboLookup1.lstItems.SelectedIndex = (int)LastPatient;
                                    }
                                    else if (PatientSearch == "GUARANTOR")
                                    {
                                        aimsComboLookup2.lstItems.SelectedIndex = (int)LastPatient;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Patient details save failed, Please contact system administrator", "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            finally 
            {
                btnSave.Enabled = true;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            //if ((txtFirstName.Text.Length > 0) && (Equals(errPatients., txtFirstName)))
            //{
            //    errPatients.Clear();
            //}
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportViewer frmRep = new frmReportViewer(txtPatientFileNo.Text, "Consolidation Report - Patient No: " + txtPatientFileNo.Text);
                //commonFuncs = new AIMS.Common.CommonFunctions();

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                StringBuilder sbHTML = new StringBuilder();

                try
                {
                    frmRep.LateInvoiceYN = "N";
                    frmRep.DoctorOwing = "N";
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
        #endregion

        #region "Helper Methods"

        /// <summary>
        /// This function loads the dropdown with patient information
        /// </summary>
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

        /// <summary>
        /// This function loads the dropdown with patient information
        /// </summary>
        private void LoadGuarantorSearch()
        {
            try
            {
                aimsComboLookup2.DataField1 = "GUARANTOR_REF_NO";
                aimsComboLookup2.DataField2 = "PATIENT_FILE_NO";

                aimsComboLookup2.OrderByField = "GUARANTOR_REF_NO";
                aimsComboLookup2.TableName = "AIMS_GUARANTOR_REFS_VW";

                aimsComboLookup2.ItemsLoaded = 50;

                aimsComboLookup2.Initialise("");
                aimsComboLookup2.txtSearch.Focus();
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Patient list.");
            }
        }

        private void ResizeForm()
        {
            tabPatientNotes.Width = tabNotes.ClientSize.Width;
            tabPatientNotes.Height = tabNotes.ClientSize.Height;
            // NOTES
            this.lstlvwNotes.Height = (tabPatientNotes.Bottom - this.btnAddComment.ClientSize.Height) -30;
            this.btnAddComment.Top = lstlvwNotes.Bottom;

            btnEditPatientNote.Top = this.btnAddComment.Top;
            btnEditPatientNote.Left = this.btnAddComment.Left + this.btnAddComment.Width;

            btnNotesIM.Top = this.btnEditPatientNote.Top;
            btnNotesIM.Left = this.btnEditPatientNote.Left + this.btnEditPatientNote.Width;

            btnEmailCaseSummary.Top = this.btnAddComment.Top;
            btnEmailCaseSummary.Left = this.btnEditPatientNote.Left + this.btnEditPatientNote.Width;

            // MED - NOTES
            this.lstlvwMedNotes.Height = (tabPatientNotes.Bottom - this.btnAddMedicalNote.ClientSize.Height) - 30;
            this.btnAddMedicalNote.Top = lstlvwMedNotes.Bottom;

            btnEditMedPatientNote.Top = this.btnAddMedicalNote.Top;
            btnEditMedPatientNote.Left = this.btnAddMedicalNote.Left + this.btnAddMedicalNote.Width;

            // Admin - NOTES
            this.lstlvwAdminNotes.Height = (tabPatientNotes.Bottom - this.btnAddAdminNote.ClientSize.Height) - 30;
            this.btnAddAdminNote.Top = lstlvwAdminNotes.Bottom;

            btnEditAdminNote.Top = this.btnAddAdminNote.Top;
            btnEditAdminNote.Left = this.btnAddAdminNote.Left + this.btnAddAdminNote.Width;

            // FINANCE - NOTES
            this.lstlvwFinanceNotes.Height = (tabPatientNotes.Bottom - this.btnAddFinanceNote.ClientSize.Height) - 30;
            this.btnAddFinanceNote.Top = lstlvwFinanceNotes.Bottom;

            btnEditFinanceNote.Top = this.btnAddFinanceNote.Top;
            btnEditFinanceNote.Left = this.btnAddFinanceNote.Left + this.btnAddFinanceNote.Width;

            // interim - NOTES
            this.lstlvwInterimNotes.Height = (tabPatientNotes.Bottom - this.btnAddInterimNote.ClientSize.Height) - 30;
            this.btnAddInterimNote.Top = lstlvwInterimNotes.Bottom;

            btnEditInterimNote.Top = this.btnAddInterimNote.Top;
            btnEditInterimNote.Left = this.btnAddInterimNote.Left + this.btnAddInterimNote.Width;

            //Tasks
            tabTask.Width = tabTasks.ClientSize.Width;
            tabTask.Height = tabTasks.ClientSize.Height - 30;
            
            this.lstvwTasks.Height = tabTasks.Bottom - this.btnAddTask.Height;
            this.btnAddTask.Top = tabTask.Bottom;
            this.btnPatientFIleTaskAudit.Top = this.btnAddTask.Top;
            this.btnPatientFIleTaskAudit.Left = this.btnAddTask.Left + this.btnAddTask.Width;

            //Tasks
            tabAppointment.Width = tabAppointments.ClientSize.Width;
            tabAppointment.Height = tabAppointments.ClientSize.Height - 30;

            this.lstvwAppointments.Height = tabAppointment.Bottom - this.btnAddNewAppointment.Height;
            this.btnAddNewAppointment.Top = tabAppointment.Bottom;
            this.btnAppointmentsAudit.Top = this.btnAddNewAppointment.Top;
            this.btnAppointmentsAudit.Left = this.btnAddNewAppointment.Left + this.btnAddNewAppointment.Width;
        }
        /// <summary>
        /// This method list details for a specific patient
        /// </summary>
        private void LoadPatientDetails()
        {
            AIMS.BLL.Patient clsPatient = new Patient();
            _saveCount = 0;
            errPatients.Clear();
            ResizeForm();
            try
            {
                //tabControl1.SelectTab(0);
                if ((PatientSearch == "PATIENT" && aimsComboLookup1.DataField1 == "PATIENT_FILE_NO") || (PatientSearch == "GUARANTOR" && aimsComboLookup2.DataField1 == "PATIENT_FILE_NO"))
                {
                    if (PatientSearch == "PATIENT")
                    {
                        _selectedPatient = aimsComboLookup1.lstItems.Text;
                    }
                    else if (PatientSearch == "GUARANTOR")
                    {
                        _selectedPatient = aimsComboLookup2.lstItems.Text;
                    }
                }
                else
                {
                    if (PatientSearch == "PATIENT")
                    {
                        if (aimsComboLookup1.lstItems.SelectedValue != null && !aimsComboLookup1.lstItems.SelectedValue.Equals(""))
                        {
                            _selectedPatient = aimsComboLookup1.lstItems.SelectedValue.ToString();
                        }
                    }
                    else if (PatientSearch == "GUARANTOR")
                    {
                        if (aimsComboLookup2.lstItems.SelectedValue != null && !aimsComboLookup2.lstItems.SelectedValue.Equals(""))
                        {
                            _selectedPatient = aimsComboLookup2.lstItems.SelectedValue.ToString();
                        }
                    }
                }

                _patient = clsPatient.GetPatientDetails(_selectedPatient, "Y",UserID);

                if (_patient != null)
                {
                    tmrEmailsPoll.Enabled = true;
                    txtPatientFileCreationDTTM.Text = _patient.PatientFileLoadDate;
                    btnPatientTranscript.Enabled = true;
                    lblPatientID.Text = _patient.PatientID.ToString();
                    ServiceProvidersSetup();
                    LoadPatientServiceProviders();
                    txtPatientFileNo.Text = _patient.PatientFileNo;
                    lblPatientFileNumber.Text = _patient.PatientFileNo;
                    txtSurname.Text = _patient.PatientLastName;
                    txtFirstName.Text = _patient.PatientFirstName;
                    txtFaxNum.Text = _patient.PatientFaxNo;
                    txtDateOfBirth.Text = _patient.DateOfBirth;
                    // txtGuarantor.Text = _patient.GuarantorName;
                    txtAddr1.Text = _patient.AddressLine1;
                    txtAddr2.Text = _patient.AddressLine2;
                    txtAddr3.Text = _patient.AddressLine3;
                    txtAddr4.Text = _patient.AddressLine4;
                    txtAddr5.Text = _patient.AddressLine5;
                    txtPostalCode.Text = _patient.PostalCode;
                    txtGuarantorRefNum.Text = _patient.GuarantorRefNo;
                    cboGuarantors.SelectedValue = _patient.GuarantorID;
                    cboFlightGuarantors.SelectedValue = _patient.FlightGuarantorID;

                    if (cboGuarantors.SelectedItem != null && cboGuarantors.Text == "FLIGHTS")
                    {
                        cboFlightGuarantors.Enabled = true;
                    }
                    else
                    {
                        cboFlightGuarantors.Enabled = false;
                    }

                    cboTitle.SelectedValue = _patient.TitleID;

                    if (_patient.FileAssignedUser == "")
                    {
                        cboFileAssignedTo.SelectedValue = -1;
                    }
                    else
                    {
                        cboFileAssignedTo.SelectedValue = _patient.FileAssignedUser;
                    }

                    if (_patient.FileOperator == "")
                    {
                        cboOPSFileOwner.SelectedValue = -1;
                    }
                    else
                    {
                        cboOPSFileOwner.SelectedValue = _patient.FileOperator;
                    }

                    if (_patient.AssistType == "")
                    {
                        cboAssistType.SelectedValue = -1;
                        rdAssist.Checked = false;
                    }
                    else
                    {
                        cboAssistType.SelectedValue = System.Convert.ToInt32(_patient.AssistType);
                        rdAssist.Checked = true;
                    }

                    if (_patient.TransportType == "")
                    {
                        cboTransportType.SelectedValue = -1;
                        rdTransport.Checked = false;
                    }
                    else
                    {
                        rdTransport.Checked = true;
                        cboTransportType.SelectedValue = System.Convert.ToInt32(_patient.TransportType);
                    }

                    if (_patient.EvacuationType == "")
                    {
                        cboEvacuationType.SelectedValue = -1;
                        rdFlight.Checked = false;
                    }
                    else
                    {
                        cboEvacuationType.SelectedValue = System.Convert.ToInt32(_patient.EvacuationType);
                        rdFlight.Checked = true;
                    }

                    if (_patient.RMRType == "")
                    {
                        cboRMRType.SelectedValue = -1;
                        rdRMR.Checked = false;
                    }
                    else
                    {
                        cboRMRType.SelectedValue = System.Convert.ToInt32(_patient.RMRType);
                        rdRMR.Checked = true;
                    }

                    if (_patient.RepatType == "")
                    {
                        cboRepatType.SelectedValue = -1;
                        rdRepat.Checked = false;
                    }
                    else
                    {
                        cboRepatType.SelectedValue = System.Convert.ToInt32(_patient.RepatType);
                        rdRepat.Checked = true;
                    }

                    cboAddressType.SelectedValue = _patient.AddressTypeID;
                    txtCompanyName.Text = _patient.CompanyName;
                    txtEmailAddr.Text = _patient.PatientEmailAddr;
                    txtPassport.Text = _patient.IDNumber;
                    txtDateOfBirth.Text = _patient.DateOfBirth;
                    txtNationality.Text = _patient.Nationality;
                    txtMobileNumber.Text = _patient.MobileNumber;
                    txtHomePhone.Text = _patient.HomeTelNumber;
                    txtWorkTelNum.Text = _patient.WorkTelNumber;
                    txtDiagnosis.Text = _patient.Diagnosis;
                    txtDateAdmitted.Text = _patient.DateAdmitted;
                    txtDateDischarged.Text = _patient.DateDischarged;
                    txtGuaranteeAmount.Text = _patient.GuaranteeAmt;

                    if (txtGuaranteeAmount.Text.Trim().Length > 0)
                    {
                        decimal txtGuarantAmount = System.Convert.ToDecimal(txtGuaranteeAmount.Text.Replace(" ", ""));
                        lblGuarantoredAmount.Text = "(" + txtGuarantAmount.ToString("C") + ")";
                        //txtGuaranteedAmount.Text = lblGuarantoredAmount.Text;
                    }
                    else
                    {
                        lblGuarantoredAmount.Text = "";
                    }

                    txtWayBillNo.Text = _patient.CourierWaybillNo;
                    cboHospitals.SelectedValue = _patient.SupplierID;
                    txtInitials.Text = _patient.PatientInitials;

                    txtEmergencyContact.Text = _patient.EmergencyContactName;
                    txtEmergencyContactNo.Text = _patient.EmergencyContactNo;

                    if (_patient.FileCourierDate.Trim().Length > 0)
                    {
                        txtFileCourierDate.Text = _patient.FileCourierDate.Substring(0, 10);
                    }
                    else
                    {
                        txtFileCourierDate.Text = "";
                    }

                    cboCountry.SelectedValue = _patient.CountryID;
                    txtGuarantee247Email.Text = _patient.Guarantor247Email;
                    txtGuarantee247No.Text = _patient.Guarantor247No;
                    if (_patient.CourierReceiptDate.Trim().Length > 0)
                    {
                        txtCourierReceitDate.Text = _patient.CourierReceiptDate.Substring(0, 10);
                        DateTime dtCourierDt = new DateTime();
                        if (DateTime.TryParse(txtCourierReceitDate.Text,out dtCourierDt))
                        {
                            DateTime dtFileDueDate = Convert.ToDateTime(txtCourierReceitDate.Text);
                            FileDueDate(dtFileDueDate);
                        }
                        else
                        {
                            //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient-File-Received-Date Format Incorrect");
                            errPatients.SetError(txtCourierReceitDate, "Patient-File-Received-Date Format Incorrect");
                        }
                    }
                    else
                    {
                        txtCourierReceitDate.Text = "";
                        txtFileDueDate.Text = "";
                    }

                    if (_patient.Couriered == "Y")
                    {
                        chkCouried.Checked = true;
                    }
                    else
                    {
                        chkCouried.Checked = false;
                    }

                    if (_patient.SentToAdmin == "Y")
                    {
                        chkSentToAdmin.Checked = true;
                    }
                    else
                    {
                        chkSentToAdmin.Checked = false;
                    }

                    if (_patient.HighCost == "Y")
                    {
                        chkHighCostFile.Checked = true;
                    }
                    else
                    {
                        chkHighCostFile.Checked = false;
                    }

                    if (_patient.INPatient == "Y")
                    {
                        rdInPatient.Checked = true;
                    }
                    else
                    {
                        rdInPatient.Checked = false;
                    }

                    if (_patient.OUTPatient == "Y")
                    {
                        rdOutPatient.Checked = true;
                    }
                    else
                    {
                        rdOutPatient.Checked = false;
                    }

                    if (_patient.Assist == "Y")
                    {
                        rdAssist.Checked = true;
                    }
                    else
                    {
                        rdAssist.Checked = false;
                    }

                    if (_patient.Repat == "Y")
                    {
                        rdRepat.Checked = true;
                    }
                    else
                    {
                        rdRepat.Checked = false;
                    }

                    if (_patient.Flight == "Y")
                    {
                        rdFlight.Checked = true;
                    }
                    else
                    {
                        rdFlight.Checked = false;
                    }

                    if (_patient.Cancelled == "Y")
                    {
                        chkCancelled.Checked = true;
                        infoText.Text = "FILE CANCELLED";
                        DisableControls(true);
                        chkCancelled.Enabled = UserAllowed("25");
                    }
                    else
                    {
                        DisableControls(false );
                        chkCancelled.Checked = false;
                        if (UserAllowed("25"))
                        {
                            chkCancelled.Enabled = true;
                        }
                    }

                    btnEditPatientNote.Enabled = UserAllowed("40");
                    btnEditMedPatientNote.Enabled = UserAllowed("41");
                    txtDateDischarged.Enabled = UserAllowed("42");
                    lnklblDischarged.Enabled = UserAllowed("42");

                    btnEditAdminNote.Enabled = UserAllowed("90");
                    btnEditFinanceNote.Enabled = UserAllowed("91");
                    btnEditInterimNote.Enabled = UserAllowed("92");

                    btnNotesIM.Enabled = UserAllowed("76");
                    
                    if (_patient.PatientFileActiveYN == "N")
                    {
                        btnUnlockFile.Enabled = false;
                        chkFileClosed.Checked = true;
                        //DisableControls(true);
                    }
                    else
                    {
                        btnUnlockFile.Enabled = true;
                        infoText.Text = "File Status: CLOSED";
                        //DisableControls(false);
                        chkFileClosed.Checked = false;
                    }
                    
                    chkFileClosed.Enabled = UserAllowed("7");
                    btnSave.Enabled = UserAllowed("5");

                    if (_patient.Cancelled == "Y")
                    {
                        chkCancelled.Checked = true;
                    }
                    else
                    {
                        chkCancelled.Checked = false;
                    }

                    if (_patient.LateLogYN == "Y")
                    {
                        chkLateLog.Checked = true;
                        LateLogDate = _patient.LateLogDate;
                        txtLateLogdate.Text = LateLogDate;
                    }
                    else
                    {
                        chkLateLog.Checked = false;
                        LateLogDate = "";
                        txtLateLogdate.Text = "";
                    }

                    if (_patient.Pending == "Y")
                    {
                        chkFilePending.Checked = true;
                    }
                    else
                    {
                        chkFilePending.Checked = false;
                    }

                    if (UserAllowed("25"))
                    {
                        chkCancelled.Enabled = true;
                        btnSave.Enabled = UserAllowed("5");
                    }

                    txtFileLoadDate.Text = _patient.PatientFileLoadDate;

                    if (_patient.LabListDate.Trim().Length > 0)
                    {
                        txtLabListDate.Text = _patient.LabListDate.Substring(0, 10);
                    }
                    else
                    {
                        txtLabListDate.Text = "";
                    }

                    txtCourierReceitDate.Enabled = UserAllowed("93");
                    lnklblCourierReceiptDate.Enabled = UserAllowed("93");

                    LoadPatientFileFinances();
                    LoadPatientNotes();

                    LoadPatientFileEmails("");
                    LoadPatientSentEmails();
                    LoadAudit();
                    tmrPatientFileEmails.Enabled = true;
                    btnAddNew.Enabled = UserAllowed("5");
                    LoadPatientFileTasks(txtPatientFileNo.Text);
                    LoadPatientFileCompletedTasks(txtPatientFileNo.Text);
                    LoadPatientFileCancelledTasks(txtPatientFileNo.Text);
                    LoadPatientFileDocs(txtPatientFileNo.Text);
                    LoadPatientFileAppointments(txtPatientFileNo.Text);
                    lstPatientFileEmailAudit.Items.Clear();
                    
                }
                if (UserAllowed("25"))
                {
                    chkCancelled.Enabled = true;
                }

                //TODO: - Check the correct restriction ID value

                if (UserAllowed("28"))
                {
                    cboFileAssignedTo.Enabled = true;
                }
                else
                {
                    cboFileAssignedTo.Enabled = false;
                }

                if (UserAllowed("37"))
                {
                    cboOPSFileOwner.Enabled = true;
                }
                else
                {
                    cboOPSFileOwner.Enabled = false;
                }

                txtFileCourierDate.Enabled = UserAllowed("36");
                txtCourierReceitDate.Enabled = UserAllowed("93");

                lnklblCourierReceiptDate.Enabled = UserAllowed("93");
                lnklblCourierDate.Enabled = UserAllowed("36");

                chkSentToAdmin.Enabled = UserAllowed("86");

                if (UserAllowed("36"))
                {
                    txtWayBillNo.ReadOnly = false;
                }
                else
                {
                    txtWayBillNo.ReadOnly = true;
                } 
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Loading Patient Details, Please contact system administrator");
                commonFuncs.ErrorLogger("Loading Patient Details, Please try again: " + ex.ToString());
            }
            finally
            {
                clsPatient = null;
            }
        }

        private void LoadPatientFileFinances()
        {
            LoadInvoices();
            LoadLateInvoices();
            LoadDoctorOwingInvoices();
            LoadMedicalTreatment();
        }
        
        private void LoadPatientNotes()
        {
            NotesSetup("PATIENTCOMMENT");
            NotesSetup("PATIENTMEDICALHISTORY");
            NotesSetup("PATIENTADMINNOTES");
            NotesSetup("PATIENTFINANCENOTES");
            NotesSetup("PATIENTINTERIMNOTES");

            LoadNotes("'PATIENTCOMMENT'");
            LoadNotes("'PATIENTMEDICALHISTORY'");
            LoadNotes("'PATIENTADMINNOTES'");
            LoadNotes("'PATIENTFINANCENOTES'");
            LoadNotes("'PATIENTINTERIMNOTES'");
        }

        private void LoadPatientDetails(string PatientFileNo, string EnquiryYN)
        {
            AIMS.BLL.Patient clsPatient = new Patient();
            _saveCount = 0;
            errPatients.Clear();
            try
            {
                _patient = clsPatient.GetPatientDetails(PatientFileNo, EnquiryYN, UserID);

                if (_patient != null)
                {
                    
                    txtSurname.Text = _patient.PatientLastName;
                    txtFirstName.Text = _patient.PatientFirstName;
                    txtFaxNum.Text = _patient.PatientFaxNo;
                    txtDateOfBirth.Text = _patient.DateOfBirth;
                    // txtGuarantor.Text = _patient.GuarantorName;
                    txtAddr1.Text = _patient.AddressLine1;
                    txtAddr2.Text = _patient.AddressLine2;
                    txtAddr3.Text = _patient.AddressLine3;
                    txtAddr4.Text = _patient.AddressLine4;
                    txtAddr5.Text = _patient.AddressLine5;
                    txtPostalCode.Text = _patient.PostalCode;
                    
                    cboTitle.SelectedValue = _patient.TitleID;

                    cboAddressType.SelectedValue = _patient.AddressTypeID;
                    txtCompanyName.Text = _patient.CompanyName;
                    txtEmailAddr.Text = _patient.PatientEmailAddr;
                    txtPassport.Text = _patient.IDNumber;
                    txtDateOfBirth.Text = _patient.DateOfBirth;
                    txtNationality.Text = _patient.Nationality;
                    txtMobileNumber.Text = _patient.MobileNumber;
                    txtHomePhone.Text = _patient.HomeTelNumber;
                    txtWorkTelNum.Text = _patient.WorkTelNumber;
                    
                    txtInitials.Text = _patient.PatientInitials;

                    txtEmergencyContact.Text = _patient.EmergencyContactName;
                    txtEmergencyContactNo.Text = _patient.EmergencyContactNo;

                    cboCountry.SelectedValue = _patient.CountryID;
                    txtGuarantee247Email.Text = _patient.Guarantor247Email;
                    txtGuarantee247No.Text = _patient.Guarantor247No;
                    LoadAudit();
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient Details, Please try again." + ex.ToString());
                commonFuncs.ErrorLogger("Loading Patient Details, Please try again: " + ex.ToString());
            }
            finally
            {
                clsPatient = null;
            }
        }

        /// <summary>
        /// This method populates the Titles combo box
        /// </summary>
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

        /// <summary>
        /// This method populates the Titles combo box
        /// </summary>
        private void LoadTransportTypes()
        {
            try
            {
                DataTable tblAssistType = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
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
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
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

        private void LoadRepatriationTypes()
        {
            try
            {
                DataTable tblRepatType = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblRepatType = lookupBLL.GetLookUpValues("REPAT_TYPE_ID", "REPAT_TYPE_DESC", "AIMS_REPAT_TYPE", 0, "REPAT_TYPE_DESC");
                cboRepatType.DataSource = tblRepatType;
                cboRepatType.DisplayMember = "REPAT_TYPE_DESC";
                cboRepatType.ValueMember = "REPAT_TYPE_ID";
                cboRepatType.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void LoadEvacuationTypes()
        {
            try
            {
                DataTable tblEvacuationType = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblEvacuationType = lookupBLL.GetLookUpValues("EVACUATION_TYPE_ID", "EVACUATION_TYPE_DESC", "AIMS_EVACUATION_TYPES", 0, "EVACUATION_TYPE_DESC");
                cboEvacuationType.DataSource = tblEvacuationType;
                cboEvacuationType.DisplayMember = "EVACUATION_TYPE_DESC";
                cboEvacuationType.ValueMember = "EVACUATION_TYPE_ID";
                cboEvacuationType.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void LoadRMRTypes()
        {
            try
            {
                DataTable tblRMRType = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblRMRType = lookupBLL.GetLookUpValues("RMR_TYPE_ID", "RMR_TYPE_DESC", "AIMS_RMR_TYPES", 0, "RMR_TYPE_DESC");
                cboRMRType.DataSource = tblRMRType;
                cboRMRType.DisplayMember = "RMR_TYPE_DESC";
                cboRMRType.ValueMember = "RMR_TYPE_ID";
                cboRMRType.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void LoadAddressTypes()
        {
            tblTitles = new DataTable();
            try
            {
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblTitles = lookupBLL.GetLookUpValues("ADDR_TYPE_ID", "ADDRESS_TYPE", "AIMS_ADDRESS_TYPE", 0, "ADDRESS_TYPE");
                cboAddressType.DataSource = tblTitles;
                cboAddressType.DisplayMember = "ADDRESS_TYPE";
                cboAddressType.ValueMember = "ADDR_TYPE_ID";
                cboAddressType.SelectedValue = -1;
            }
            finally
            {
                //tblTitles.Dispose();
            }
        }

        /// <summary>
        /// This method populates the Guarantor combo box
        /// </summary>
        private void LoadGuarantors()
        {
            tblGuarantors = new DataTable();
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
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
            finally 
            {
                //tblGuarantors.Dispose();
            }
        }

        /// <summary>
        /// This method populates the Guarantor combo box
        /// </summary>
        private void LoadFlightGuarantors()
        {
            tblGuarantors = new DataTable();
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
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        /// <summary>
        /// This method populates the Countries combo
        /// </summary>
        private void LoadCountries()
        {
            tblCountries = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                tblCountries = lookupBLL.GetLookUpValues("COUNTRY_ID", "COUNTRY_NAME", "AIMS_COUNTRY", 0, "COUNTRY_NAME");
                cboCountry.DataSource = tblCountries;
                cboCountry.DisplayMember = "COUNTRY_NAME";
                cboCountry.ValueMember = "COUNTRY_ID";
                cboCountry.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadSuppliers()
        {
            tblSuppliers = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                tblSuppliers = lookupBLL.GetHospitalsLookUpValues("SUPPLIER_ID", "SUPPLIER_NAME", "AIMS_SUPPLIER", 0);
                cboHospitals.DataSource = tblSuppliers;
                cboHospitals.DisplayMember = "SUPPLIER_NAME";
                cboHospitals.ValueMember = "SUPPLIER_ID";
                cboHospitals.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        /// <summary>
        /// This method retrieves all the invoices for the selected patient
        /// </summary>
        private void LoadInvoices()
        {
            dsInvoices = new DataSet(); ;
            ListViewItem lvwItem;
            AIMS.BLL.Invoice invoiceBLL = new Invoice();
            dsInvoices = invoiceBLL.GetPatientInvoices(txtPatientFileNo.Text, "N", "N", "Y");

            InvoiceSetup();

            if (dsInvoices.Tables.Count > 0)
            {

                for (int i = 0; i < dsInvoices.Tables[0].Rows.Count; i++)
                {
                    lvwItem = new ListViewItem(dsInvoices.Tables[0].Rows[i]["INVOICE_NO"].ToString());

                    lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString());
                    lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["SERVICE_DESCRIPTION"].ToString());
                    //lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["DATE_ADMITTED"].ToString());
                    //lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["DATE_DISCHARGED"].ToString());
                    //lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["INVOICE_DATE"].ToString());

                    if (dsInvoices.Tables[0].Rows[i]["INVOICE_DATE"].ToString().Trim().Length > 0)
                    {
                        lvwItem.SubItems.Add(System.Convert.ToDateTime(dsInvoices.Tables[0].Rows[i]["INVOICE_DATE"]).ToShortDateString().ToString());
                    }

                    if (dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString().Trim().Length > 0)
                    {
                        lvwItem.SubItems.Add(System.Convert.ToDecimal(dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString()).ToString("C"));
                    }

                    lstvwInvoices.Items.Add(lvwItem);
                }
            }
        }

        /// <summary>
        /// This method retrieves all the invoices for the selected patient
        /// </summary>
        private void LoadLateInvoices()
        {
            dsInvoices = new DataSet(); ;
            ListViewItem lvwItem;
            AIMS.BLL.Invoice invoiceBLL = new Invoice();
            string LateInvoiceSentdate = "";
            try
            {
                dsInvoices = invoiceBLL.GetPatientInvoices(txtPatientFileNo.Text, "Y", "N", "");

                if (dsInvoices.Tables.Count > 0)
                {
                    for (int i = 0; i < dsInvoices.Tables[0].Rows.Count; i++)
                    {
                        LateInvoiceSentdate = dsInvoices.Tables[0].Rows[i]["late_invoice_sent_DATE"].ToString();
                        lvwItem = new ListViewItem(dsInvoices.Tables[0].Rows[i]["INVOICE_NO"].ToString());

                        lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString());
                        lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["SERVICE_DESCRIPTION"].ToString());
                        lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["INVOICE_DATE"].ToString());
                        lvwItem.SubItems.Add(System.Convert.ToDecimal(dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString()).ToString("C"));
                        if (dsInvoices.Tables[0].Rows[i]["LATE_INVOICE_SENT"].ToString() == "Y")
                        {
                            lvwItem.SubItems.Add("SENT");
                            lvwItem.SubItems.Add(LateInvoiceSentdate);
                        }
                        else
                        {
                            lvwItem.SubItems.Add("Not SENT");
                            lvwItem.SubItems.Add("");
                        }
                        lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["INVOICE_SENT_WAYBILL_NO"].ToString());
                        lstvwLateInvoice.Items.Add(lvwItem);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                invoiceBLL = null;
                lvwItem = null;
                dsInvoices.Dispose();
            }
        }

        /// <summary>
        /// This method retrieves all the invoices for the selected patient
        /// </summary>
        private void LoadDoctorOwingInvoices()
        {
            dsInvoices = new DataSet(); ;
            ListViewItem lvwItem;
            AIMS.BLL.Invoice invoiceBLL = new Invoice();
            try
            {
                dsInvoices = invoiceBLL.GetPatientInvoices(txtPatientFileNo.Text, "N", "Y", "Y");

                if (dsInvoices.Tables.Count > 0)
                {
                    for (int i = 0; i < dsInvoices.Tables[0].Rows.Count; i++)
                    {
                        lvwItem = new ListViewItem(dsInvoices.Tables[0].Rows[i]["INVOICE_NO"].ToString());

                        lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString());
                        lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["SERVICE_DESCRIPTION"].ToString());
                        //lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["DATE_ADMITTED"].ToString());
                        //lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["DATE_DISCHARGED"].ToString());
                        lvwItem.SubItems.Add(dsInvoices.Tables[0].Rows[i]["INVOICE_DATE"].ToString());
                        lvwItem.SubItems.Add(System.Convert.ToDecimal(dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString()).ToString("C"));
                        lstvwDoctorOwing.Items.Add(lvwItem);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                invoiceBLL = null;
                lvwItem = null;
                dsInvoices.Dispose();
            }
        }
        /// <summary>
        /// This method retrieves all the invoices for the selected patient
        /// </summary>
        private void LoadAudit()
        {
            DataSet dsAudit = new DataSet();
            ListViewItem lvwItem;
            AIMS.BLL.Patient patientBLL = new Patient();
            bool buildColumns = true;

            try
            {
                dsAudit = patientBLL.GetPatientFileAudit(txtPatientFileNo.Text);
                lstvwAuditing.Items.Clear();
                lstvwAuditing.Columns.Clear();
                lstvwAuditing.Scrollable = true; 
                if (dsAudit.Tables.Count > 0)
                {
                    for (int k = 0; k < dsAudit.Tables[0].Columns.Count; k++)
                    {
                        ColumnHeader colHeader = new ColumnHeader();
                        colHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        colHeader.Text = dsAudit.Tables[0].Columns[k].ColumnName;
                        lstvwAuditing.Columns.Add(colHeader.Text, 180);
                    }
   
                    for (int i = 0; i < dsAudit.Tables[0].Rows.Count; i++)
                    {
                        lvwItem = new ListViewItem(dsAudit.Tables[0].Rows[i][dsAudit.Tables[0].Columns[0].ColumnName].ToString());
                        for (int k = 1; k < dsAudit.Tables[0].Columns.Count; k++)
                        {
                            lvwItem.SubItems.Add(dsAudit.Tables[0].Rows[i][dsAudit.Tables[0].Columns[k].ColumnName].ToString());
                        }
                        lstvwAuditing.Items.Add(lvwItem);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                patientBLL = null;
                lvwItem = null;
                dsAudit.Dispose();
            }
        }


        private void LoadMedicalTreatment()
        {
            MedicalTreatmentSetup();
            dsMedicalTreatment = new DataSet(); ;
            ListViewItem lvwItem;
            AIMS.BLL.MedicalTreatment invoiceBLL = new MedicalTreatment();
            dsMedicalTreatment = invoiceBLL.GetPatientMedicalTreatment(txtPatientFileNo.Text);

            try
            {

                for (int i = 0; i < dsMedicalTreatment.Tables[0].Rows.Count; i++)
                {
                    lvwItem = new ListViewItem(dsMedicalTreatment.Tables[0].Rows[i]["INVOICE_NO"].ToString());
                    lvwItem.SubItems.Add(dsMedicalTreatment.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString());
                    lvwItem.SubItems.Add(dsMedicalTreatment.Tables[0].Rows[i]["TREATMENT_NOTES"].ToString());
                    lvwItem.SubItems.Add(dsMedicalTreatment.Tables[0].Rows[i]["DATE_OF_TREATMENT"].ToString());
                    lstvwMedicalTreatment.Items.Add(lvwItem);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void LoadNotes(string NotesType)
        {
            dsNotes = new DataSet(); ;
            ListViewItem lvwItem;
            AIMS.BLL.Notes notesBLL = new Notes();
            dsNotes.Clear();

            if (!txtPatientFileNo.Text.Trim().Equals(""))
            {
                dsNotes = notesBLL.GetPatientNotes(txtPatientFileNo.Text, NotesType);
            }
            
            try
            {
                if (dsNotes.Tables.Count > 0)
                {
                    switch (NotesType.ToUpper())
                    {
                        case "'PATIENTCOMMENT'":
                            for (int i = 0; i < dsNotes.Tables[0].Rows.Count; i++)
                            {
                                lvwItem = new ListViewItem(dsNotes.Tables[0].Rows[i]["NOTES_DTTM"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTES"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["USER_FULL_NAME"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_DESC"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_ID"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_ID"].ToString());
                                lstlvwNotes.Items.Add(lvwItem);
                            }
                            break;
                        case "'PATIENTMEDICALHISTORY'":
                            for (int i = 0; i < dsNotes.Tables[0].Rows.Count; i++)
                            {
                                lvwItem = new ListViewItem(dsNotes.Tables[0].Rows[i]["NOTES_DTTM"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTES"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["USER_FULL_NAME"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_DESC"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_ID"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_ID"].ToString());
                                lstlvwMedNotes.Items.Add(lvwItem);
                            }
                            break;
                        case "'PATIENTINTERIMNOTES'":
                            for (int i = 0; i < dsNotes.Tables[0].Rows.Count; i++)
                            {
                                lvwItem = new ListViewItem(dsNotes.Tables[0].Rows[i]["NOTES_DTTM"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTES"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["USER_FULL_NAME"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_DESC"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_ID"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_ID"].ToString());
                                lstlvwInterimNotes.Items.Add(lvwItem);
                            }
                            break;
                        case "'PATIENTADMINNOTES'":
                            
                            for (int i = 0; i < dsNotes.Tables[0].Rows.Count; i++)
                            {
                                lvwItem = new ListViewItem(dsNotes.Tables[0].Rows[i]["NOTES_DTTM"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTES"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["USER_FULL_NAME"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_DESC"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_ID"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_ID"].ToString());
                                lstlvwAdminNotes.Items.Add(lvwItem);
                            }
                            break;
                        case "'PATIENTFINANCENOTES'":

                            for (int i = 0; i < dsNotes.Tables[0].Rows.Count; i++)
                            {
                                lvwItem = new ListViewItem(dsNotes.Tables[0].Rows[i]["NOTES_DTTM"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTES"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["USER_FULL_NAME"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_DESC"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_ID"].ToString());
                                lvwItem.SubItems.Add(dsNotes.Tables[0].Rows[i]["NOTE_TYPE_ID"].ToString());
                                lstlvwFinanceNotes.Items.Add(lvwItem);
                            }
                            break;
                    }
                }
                else
                {
                    commonFuncs.ErrorLogger("NO PATIENT NOTES");
                }
                ListViewsResize();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Notes Failed : Error - " + ex.Message);
                throw;
            }
            finally
            {
                lvwItem = null;
                notesBLL = null;
                dsNotes.Dispose();
            }
        }

        /// <summary>
        /// This method adds all the columns being displayed in the Invoices listview control
        /// </summary>
        private void InvoiceSetup()
        {
            lstvwInvoices.Columns.Clear();
            lstvwInvoices.Items.Clear();
            lstvwInvoices.Columns.Add("Invoice No.", Convert.ToInt32(lstvwInvoices.Width * 0.1), HorizontalAlignment.Center);
            lstvwInvoices.Columns.Add("Supplier Name", Convert.ToInt32(lstvwInvoices.Width * 0.3), HorizontalAlignment.Center);
            lstvwInvoices.Columns.Add("Service", Convert.ToInt32(lstvwInvoices.Width * 0.15), HorizontalAlignment.Center);
            lstvwInvoices.Columns.Add("Invoice Date", Convert.ToInt32(lstvwInvoices.Width * 0.1), HorizontalAlignment.Center);
            lstvwInvoices.Columns.Add("Amount", Convert.ToInt32(lstvwInvoices.Width * 0.15), HorizontalAlignment.Center);

            lstvwLateInvoice.Columns.Clear();
            lstvwLateInvoice.Items.Clear();

            lstvwLateInvoice.Columns.Add("Invoice No.");//,lstvwLateInvoice.Width, HorizontalAlignment.Center);
            lstvwLateInvoice.Columns[0].Width = 100;
            lstvwLateInvoice.Columns.Add("Supplier Name", Convert.ToInt32(lstvwLateInvoice.Width * 0.3), HorizontalAlignment.Center);
            lstvwLateInvoice.Columns.Add("Service", Convert.ToInt32(lstvwLateInvoice.Width * 0.15), HorizontalAlignment.Center);
            lstvwLateInvoice.Columns.Add("Invoice Date", Convert.ToInt32(lstvwLateInvoice.Width * 0.1), HorizontalAlignment.Center);
            lstvwLateInvoice.Columns[3].Width = 100;
            lstvwLateInvoice.Columns.Add("Amount", Convert.ToInt32(lstvwLateInvoice.Width * 0.15), HorizontalAlignment.Center);
            lstvwLateInvoice.Columns[4].Width = 150;
            lstvwLateInvoice.Columns.Add("Late Invoice Sent", Convert.ToInt32(lstvwLateInvoice.Width * 0.15), HorizontalAlignment.Center);
            lstvwLateInvoice.Columns[5].Width = 100;
            lstvwLateInvoice.Columns.Add("Late Invoice Date Sent", Convert.ToInt32(lstvwLateInvoice.Width * 0.15), HorizontalAlignment.Center);
            lstvwLateInvoice.Columns.Add("Invoice Tracking Waybill No", Convert.ToInt32(lstvwLateInvoice.Width * 0.15), HorizontalAlignment.Center);

            lstvwDoctorOwing.Columns.Clear();
            lstvwDoctorOwing.Items.Clear();
            lstvwDoctorOwing.Columns.Add("Invoice No.", Convert.ToInt32(lstvwLateInvoice.Width * 0.1), HorizontalAlignment.Center);
            lstvwDoctorOwing.Columns.Add("Supplier Name", Convert.ToInt32(lstvwLateInvoice.Width * 0.3), HorizontalAlignment.Center);
            lstvwDoctorOwing.Columns.Add("Service", Convert.ToInt32(lstvwLateInvoice.Width * 0.15), HorizontalAlignment.Center);
            lstvwDoctorOwing.Columns.Add("Invoice Date", Convert.ToInt32(lstvwLateInvoice.Width * 0.1), HorizontalAlignment.Center);
            lstvwDoctorOwing.Columns.Add("Amount", Convert.ToInt32(lstvwLateInvoice.Width * 0.15), HorizontalAlignment.Center);
        }

        private void NotesSetup(string NoteType)
        {
            try
            {
                switch (NoteType.ToUpper())
                {
                    case "EXITNOTE":
                        lstlvwNotes.Columns.Clear();
                        lstlvwNotes.Items.Clear();
                        lstlvwNotes.Columns.Add("Date", Convert.ToInt32(lstlvwNotes.Width * 0.15), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("Note Description", Convert.ToInt32(lstlvwNotes.Width * 0.1), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("User Name", Convert.ToInt32(lstlvwNotes.Width * 0.2), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("Note Type", 0);
                        lstlvwNotes.Columns.Add("Note ID", 0);
                        lstlvwNotes.Columns.Add("Note Type ID", 0);

                        if (UserAllowed("40"))
                        {
                            btnEditPatientNote.Enabled = true;
                        }
                        else
                        {
                            btnEditPatientNote.Enabled = false;
                        }

                        break;
                    case "PATIENTLATESTUPDATE":
                        lstlvwNotes.Columns.Clear();
                        lstlvwNotes.Items.Clear();
                        lstlvwNotes.Columns.Add("Date", Convert.ToInt32(lstlvwNotes.Width * 0.15), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("Note Description", Convert.ToInt32(lstlvwNotes.Width * 0.1), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("User Name", Convert.ToInt32(lstlvwNotes.Width * 0.2), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("Note Type", 0);
                        lstlvwNotes.Columns.Add("Note ID", 0 );
                        lstlvwNotes.Columns.Add("Note Type ID", 0);

                        if (UserAllowed("40"))
                        {
                            btnEditPatientNote.Enabled = true;
                        }
                        else
                        {
                            btnEditPatientNote.Enabled = false;
                        }

                        break;
                    case "PATIENTCOMMENT":
                        lstlvwNotes.Columns.Clear();
                        lstlvwNotes.Items.Clear();
                        lstlvwNotes.Columns.Add("Date", Convert.ToInt32(lstlvwNotes.Width * 0.15), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("Note Description", Convert.ToInt32(lstlvwNotes.Width * 0.1), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("User Name", Convert.ToInt32(lstlvwNotes.Width * 0.2), HorizontalAlignment.Left);
                        lstlvwNotes.Columns.Add("Note Type", 0);
                        lstlvwNotes.Columns.Add("Note ID",0);
                        lstlvwNotes.Columns.Add("Note Type ID",0);
                        
                        if (UserAllowed("40"))
                        {
                            btnEditPatientNote.Enabled = true;
                        }
                        else
                        {
                            btnEditPatientNote.Enabled = false;
                        }

                        break;
                    case "PATIENTMEDICALHISTORY":
                        lstlvwMedNotes.Columns.Clear();
                        lstlvwMedNotes.Items.Clear();
                        lstlvwMedNotes.Columns.Add("Date", Convert.ToInt32(lstlvwNotes.Width * 0.15), HorizontalAlignment.Left);
                        lstlvwMedNotes.Columns.Add("Note Description", Convert.ToInt32(lstlvwNotes.Width * 0.66), HorizontalAlignment.Left);
                        lstlvwMedNotes.Columns.Add("User Name", Convert.ToInt32(lstlvwNotes.Width * 0.2), HorizontalAlignment.Left);
                        lstlvwMedNotes.Columns.Add("Note Type", 0);
                        lstlvwMedNotes.Columns.Add("Note ID", 0);
                        lstlvwMedNotes.Columns.Add("Note Type ID", 0);

                        if (UserAllowed("41"))
                        {
                            btnEditMedPatientNote.Enabled = true;
                        }
                        else
                        {
                            btnEditMedPatientNote.Enabled = false ;
                        }
                        break;
                    case "PATIENTFINANCENOTES":
                        lstlvwFinanceNotes.Columns.Clear();
                        lstlvwFinanceNotes.Items.Clear();
                        lstlvwFinanceNotes.Columns.Add("Date", Convert.ToInt32(lstlvwFinanceNotes.Width * 0.15), HorizontalAlignment.Left);
                        lstlvwFinanceNotes.Columns.Add("Note Description", Convert.ToInt32(lstlvwFinanceNotes.Width * 0.66), HorizontalAlignment.Left);
                        lstlvwFinanceNotes.Columns.Add("User Name", Convert.ToInt32(lstlvwFinanceNotes.Width * 0.2), HorizontalAlignment.Left);
                        lstlvwFinanceNotes.Columns.Add("Note Type", 0);
                        lstlvwFinanceNotes.Columns.Add("Note ID", 0);
                        lstlvwFinanceNotes.Columns.Add("Note Type ID", 0);

                        if (UserAllowed("91"))
                        {
                            btnEditFinanceNote.Enabled = true;
                        }
                        else
                        {
                            btnEditFinanceNote.Enabled = false;
                        }
                        break;
                    case "PATIENTADMINNOTES":
                        lstlvwAdminNotes.Columns.Clear();
                        lstlvwAdminNotes.Items.Clear();
                        lstlvwAdminNotes.Columns.Add("Date", Convert.ToInt32(lstlvwAdminNotes.Width * 0.15), HorizontalAlignment.Left);
                        lstlvwAdminNotes.Columns.Add("Note Description", Convert.ToInt32(lstlvwAdminNotes.Width * 0.66), HorizontalAlignment.Left);
                        lstlvwAdminNotes.Columns.Add("User Name", Convert.ToInt32(lstlvwAdminNotes.Width * 0.2), HorizontalAlignment.Left);
                        lstlvwAdminNotes.Columns.Add("Note Type", 0);
                        lstlvwAdminNotes.Columns.Add("Note ID", 0);
                        lstlvwAdminNotes.Columns.Add("Note Type ID", 0);

                        if (UserAllowed("90"))
                        {
                            btnEditAdminNote.Enabled = true;
                        }
                        else
                        {
                            btnEditAdminNote.Enabled = false;
                        }
                        break;
                    case "PATIENTINTERIMNOTES":
                        lstlvwInterimNotes.Columns.Clear();
                        lstlvwInterimNotes.Items.Clear();
                        lstlvwInterimNotes.Columns.Add("Date", Convert.ToInt32(lstlvwInterimNotes.Width * 0.15), HorizontalAlignment.Left);
                        lstlvwInterimNotes.Columns.Add("Note Description", Convert.ToInt32(lstlvwInterimNotes.Width * 0.66), HorizontalAlignment.Left);
                        lstlvwInterimNotes.Columns.Add("User Name", Convert.ToInt32(lstlvwInterimNotes.Width * 0.2), HorizontalAlignment.Left);
                        lstlvwInterimNotes.Columns.Add("Note Type", 0);
                        lstlvwInterimNotes.Columns.Add("Note ID", 0);
                        lstlvwInterimNotes.Columns.Add("Note Type ID", 0);

                        if (UserAllowed("92"))
                        {
                            btnEditInterimNote.Enabled = true;
                        }
                        else
                        {
                            btnEditInterimNote.Enabled = false;
                        }
                        break;
                }
                ListViewsResize();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error setting up notes: " + ex.Message);
            }
        }

        private void ListViewsResize()
        {
            foreach (ColumnHeader ch in this.lstlvwNotes.Columns)
            {
                if (ch.Text.Equals("Note ID") || ch.Text.Equals("Note Type ID") || ch.Text == "Note Type")
                {
                    ch.Width = 0;
                }
                else
                {
                    ch.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }

            foreach (ColumnHeader ch in this.lstlvwMedNotes.Columns)
            {
                if (ch.Text.Equals("Note ID") || ch.Text.Equals("Note Type ID") || ch.Text == "Note Type")
                {
                    ch.Width = 0;
                }
                else
                {
                    ch.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }

            foreach (ColumnHeader ch in this.lstlvwAdminNotes.Columns)
            {
                if (ch.Text.Equals("Note ID") || ch.Text.Equals("Note Type ID") || ch.Text == "Note Type")
                {
                    ch.Width = 0;
                }
                else
                {
                    ch.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }

            foreach (ColumnHeader ch in this.lstlvwFinanceNotes.Columns)
            {
                if (ch.Text.Equals("Note ID") || ch.Text.Equals("Note Type ID") || ch.Text == "Note Type")
                {
                    ch.Width = 0;
                }
                else
                {
                    ch.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }

            foreach (ColumnHeader ch in this.lstlvwInterimNotes.Columns)
            {
                if (ch.Text.Equals("Note ID") || ch.Text.Equals("Note Type ID") || ch.Text == "Note Type")
                {
                    ch.Width = 0;
                }
                else
                {
                    ch.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }

        }
        private void ServiceProvidersSetup()
        {
            try
            {
                lstvwServiceProviders.Columns.Clear();
                lstvwServiceProviders.Items.Clear();
                lstvwServiceProviders.Columns.Add("Service Provider", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstvwServiceProviders.Columns.Add("Name", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstvwServiceProviders.Columns.Add("Telephone", 100, HorizontalAlignment.Left);
                lstvwServiceProviders.Columns.Add("Fax", 100, HorizontalAlignment.Left);
                lstvwServiceProviders.Columns.Add("Email", 200, HorizontalAlignment.Left);
                lstvwServiceProviders.Columns.Add("Service Provider ID", 0, HorizontalAlignment.Right);
                lstvwServiceProviders.Columns.Add("Loaded By", 150, HorizontalAlignment.Right);
                lstvwServiceProviders.Columns.Add("Loaded On", 150, HorizontalAlignment.Right);

                //lstvwServiceProviders.Columns.Add("Added By", 130, HorizontalAlignment.Left);

                gvServiceProviders.AutoSize = true;
                gvServiceProviders.Columns.Add("", "Service Provider");
                gvServiceProviders.Columns.Add("", "Name");
                gvServiceProviders.Columns.Add("", "Telephone");
                gvServiceProviders.Columns.Add("", "Fax");
                gvServiceProviders.Columns.Add("", "Email");

                //gvServiceProviders.Columns.Add("", "Added");  
            }
            catch (System.Exception ex)
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Loading Service Providers: " + ex.Message);
            }
        }

        /// <summary>
        /// method to reset audit records setup
        /// </summary>
        private void AuditSetup()
        {
            try
            {
                //lstvwAuditing.Columns.Clear();
                //lstvwAuditing.Items.Clear();
                //lstvwAuditing.Columns.Add("Date", Convert.ToInt32(lstvwInvoices.Width * 0.15), HorizontalAlignment.Center);
                //lstvwAuditing.Columns.Add("Action Performed", Convert.ToInt32(lstvwInvoices.Width * 0.66), HorizontalAlignment.Center);
                //lstvwAuditing.Columns.Add("User", Convert.ToInt32(lstvwInvoices.Width * 0.2), HorizontalAlignment.Center);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// This method adds all the columns being displayed in the Invoices listview control
        /// </summary>
        private void MedicalTreatmentSetup()
        {
            lstvwMedicalTreatment.Columns.Clear();
            lstvwMedicalTreatment.Items.Clear();
            lstvwMedicalTreatment.Columns.Add("Invoice No.", Convert.ToInt32(lstvwMedicalTreatment.Width * 0.1), HorizontalAlignment.Center);
            lstvwMedicalTreatment.Columns.Add("Supplier Name", Convert.ToInt32(lstvwMedicalTreatment.Width * 0.3), HorizontalAlignment.Center);
            lstvwMedicalTreatment.Columns.Add("Treatment Details", Convert.ToInt32(lstvwMedicalTreatment.Width * 0.4), HorizontalAlignment.Center);
            lstvwMedicalTreatment.Columns.Add("Treatment Date", Convert.ToInt32(lstvwMedicalTreatment.Width * 0.1), HorizontalAlignment.Center);
        }

        /// <summary>
        /// This method saves/updates patient details 
        /// </summary>
        private bool SavePatientDetails()
        {
            Patient clsPatient = new Patient();
            string patientFileNo = string.Empty;
            bool returnValue = false;
            _PatientDAL = new PatientDAL();
            if (commonFuncs == null)
            {
                commonFuncs = new AIMS.Common.CommonFunctions();                
            }

            try
            {
                _PatientDAL.PatientFirstName = txtFirstName.Text.Trim();
                _PatientDAL.PatientLastName = txtSurname.Text.Trim();
                _PatientDAL.PatientInitials = txtInitials.Text.Trim();
                _PatientDAL.PostalCode = txtPostalCode.Text;
                _PatientDAL.PatientFaxNo = txtFaxNum.Text;
                _PatientDAL.MobileNumber = txtMobileNumber.Text;
                _PatientDAL.WorkTelNumber = txtWorkTelNum.Text;
                _PatientDAL.PatientFileNo = txtPatientFileNo.Text;
                _PatientDAL.PatientEmailAddr = txtEmailAddr.Text;
                _PatientDAL.IDNumber = txtPassport.Text;
                _PatientDAL.DateOfBirth = txtDateOfBirth.Text;
                _PatientDAL.GuarantorRefNo = txtGuarantorRefNum.Text;
                _PatientDAL.Nationality = txtNationality.Text;
                _PatientDAL.AddressLine1 = txtAddr1.Text;
                _PatientDAL.AddressLine2 = txtAddr2.Text;
                _PatientDAL.AddressLine3 = txtAddr3.Text;
                _PatientDAL.AddressLine4 = txtAddr4.Text;
                _PatientDAL.AddressLine5 = txtAddr5.Text;
                _PatientDAL.CompanyName = txtCompanyName.Text;
                _PatientDAL.CourierWaybillNo = txtWayBillNo.Text.Trim();
                _PatientDAL.LabListDate = txtLabListDate.Text.Trim();
                
                _PatientDAL.FileCourierDate = txtFileCourierDate.Text.Trim();

                if (chkCouried.Checked == true)
                {
                    _PatientDAL.Couriered = "Y";
                }
                else
                {
                    _PatientDAL.Couriered = "N";
                }

                if (chkSentToAdmin.Checked == true)
                {
                    _PatientDAL.SentToAdmin = "Y";
                }
                else
                {
                    _PatientDAL.SentToAdmin = "N";
                }

                if (chkHighCostFile.Checked == true)
                {
                    _PatientDAL.HighCost = "Y";
                }
                else
                {
                    _PatientDAL.HighCost = "N";
                }

                if (cboGuarantors.SelectedItem != null)
                {
                    _PatientDAL.GuarantorID = Convert.ToInt32(cboGuarantors.SelectedValue.ToString());
                }

                if (cboFlightGuarantors.SelectedItem != null)
                {
                    _PatientDAL.FlightGuarantorID = Convert.ToInt32(cboFlightGuarantors.SelectedValue.ToString());
                }
                
                _PatientDAL.GuarantorRefNo = txtGuarantorRefNum.Text;
                _PatientDAL.GuaranteeAmt = txtGuaranteeAmount.Text;
                _PatientDAL.HomeTelNumber = txtHomePhone.Text;
                _PatientDAL.Nationality = txtNationality.Text;
                _PatientDAL.Diagnosis = txtDiagnosis.Text;
                //if (!txtDateAdmitted.Text.Trim().Equals(""))
                //{
                //    DateTime admissionDt = System.Convert.ToDateTime(txtDateAdmitted.Text);
                //    txtDateAdmitted.Text = admissionDt.ToString("dd/MM/yyyy");
                //}
                _PatientDAL.DateAdmitted = txtDateAdmitted.Text;

                //if (!txtDateDischarged.Text.Trim().Equals(""))
                //{
                //    DateTime dischargeDt = System.Convert.ToDateTime(txtDateDischarged.Text);
                //    txtDateDischarged.Text = dischargeDt.ToString("dd/MM/yyyy");
                //}
                _PatientDAL.DateDischarged = txtDateDischarged.Text;
                _PatientDAL.PatientFaxNo = txtFaxNum.Text;
                _PatientDAL.PatientFileNo = txtPatientFileNo.Text;
                _PatientDAL.PostalCode = txtPostalCode.Text;
                _PatientDAL.EmergencyContactName = txtEmergencyContact.Text;
                _PatientDAL.EmergencyContactNo = txtEmergencyContactNo.Text;

                if (cboTitle.SelectedIndex != 1)
                {
                    if (cboTitle.SelectedValue != null)
                    {
                        _PatientDAL.TitleID = Convert.ToInt32(cboTitle.SelectedValue.ToString());
                    }
                }

                if (cboAddressType.SelectedIndex != null)
                {
                    if (cboAddressType.Text != "")
                    {
                        _PatientDAL.AddressTypeID = Convert.ToInt32(cboAddressType.SelectedValue.ToString());
                    }
                }

                if (cboHospitals.SelectedIndex != -1)
                {
                    if (cboHospitals.SelectedValue != null)
                    {
                        _PatientDAL.SupplierID = Convert.ToInt32(cboHospitals.SelectedValue.ToString());
                    }
                }

                if (cboCountry.SelectedIndex != -1)
                {
                    if (cboCountry.SelectedValue != null)
                    {
                        _PatientDAL.CountryID = Convert.ToInt32(cboCountry.SelectedValue.ToString());
                    }
                }
                _PatientDAL.FileOperator = cboOPSFileOwner.Text;

                if (cboOPSFileOwner.Enabled == false)
                {
                    if (cboOPSFileOwner.Text =="")
                    {
                        _PatientDAL.AfterHoursFile = AfterHoursFile();
                    }
                    else
                    {
                        _PatientDAL.AfterHoursFile = "N";
                    }
                }
                else
                {
                    _PatientDAL.AfterHoursFile = "N";
                }
                
                if (chkFileClosed.Checked)
                {
                    _PatientDAL.PatientFileActiveYN = "N";
                    //_PatientDAL.FileOperator = cboOPSFileOwner.Text;
                }
                else
                {
                    _PatientDAL.PatientFileActiveYN = "Y";
                }

                if (chkCancelled.Checked)
                {
                    _PatientDAL.Cancellation = "Y";
                    _PatientDAL.FileOperator = cboOPSFileOwner.Text;
                }
                else
                {
                    _PatientDAL.Cancellation = "N";
                }

                if (rdInPatient.Checked)
                {
                    _PatientDAL.INPatient = "Y";
                }
                else
                {
                    _PatientDAL.INPatient = "N";
                }

                if (rdOutPatient.Checked)
                {
                    _PatientDAL.OUTPatient = "Y";
                }
                else
                {
                    _PatientDAL.OUTPatient = "N";
                }

                if (rdAssist.Checked)
                {
                    _PatientDAL.Assist = "Y";
                    _PatientDAL.AssistType = cboAssistType.SelectedValue.ToString();
                }
                else
                {
                    _PatientDAL.Assist = "N";
                }

                if (rdRepat.Checked)
                {
                    _PatientDAL.Repat = "Y";
                    _PatientDAL.RepatType = cboRepatType.SelectedValue.ToString();
                }
                else
                {
                    _PatientDAL.Repat = "N";
                }

                if (rdFlight.Checked)
                {
                    _PatientDAL.Flight = "Y";
                    _PatientDAL.EvacuationType = cboEvacuationType.SelectedValue.ToString();
                }
                else
                {
                    _PatientDAL.Flight = "N";
                }

                if (rdRMR.Checked)
                {
                    _PatientDAL.RMR = "Y";
                    _PatientDAL.RMRType = cboRMRType.SelectedValue.ToString();
                }
                else
                {
                    _PatientDAL.RMR = "N";
                }

                if (chkCancelled.Checked)
                {
                    _PatientDAL.Cancellation = "Y";
                }
                else
                {
                    _PatientDAL.Cancellation = "N";
                }

                if (rdTransport.Checked)
                {
                    _PatientDAL.Transport = "Y";
                    _PatientDAL.TransportType = cboTransportType.SelectedValue.ToString();
                }
                else
                {
                    _PatientDAL.Transport = "N";
                }

                if (chkLateLog.Checked)
                {
                    _PatientDAL.LateLogYN = "Y";
                    _PatientDAL.LateLogDate = LateLogDate;
                }
                else
                {
                    _PatientDAL.LateLogYN = "N";
                }

                if (chkFilePending.Checked)
                {
                    _PatientDAL.Pending = "Y";
                }
                else
                {
                    _PatientDAL.Pending = "N";
                }

                _PatientDAL.Guarantor247Email = txtGuarantee247Email.Text.Trim();
                _PatientDAL.Guarantor247No = txtGuarantee247No.Text.Trim();
                _PatientDAL.CourierReceiptDate = txtCourierReceitDate.Text;
                _PatientDAL.CourierWaybillNo = txtWayBillNo.Text.Trim();
                _PatientDAL.FileAssignedUser = cboFileAssignedTo.Text;
                
                if (txtPatientFileNo.Text.Length == 0)
                {
                    patientFileNo = clsPatient.SavePatientDetails(_PatientDAL, UserID);

                    if (patientFileNo.Length > 0)
                    {
                        txtPatientFileNo.Text = patientFileNo;
                        returnValue = true;
                    }
                    else
                    {
                        returnValue = false;
                    }
                }
                else
                {
                    if (lblPatientID.Text.Trim().Length > 0)
                    {
                        _PatientDAL.PatientID = Convert.ToInt32(lblPatientID.Text);
                    }

                    patientFileNo = clsPatient.SavePatientDetails(_PatientDAL, UserID);
                    if (patientFileNo.Length > 0)
                    {
                        LoadPatientDetails();
                        LoadPatients();
                        LoadGuarantorSearch();
                        returnValue = true;
                    }
                    else
                    {
                        returnValue = false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Saving Patient failed, Please contact System Administrator, Error: " + ex.Message);

            }
            finally
            {
                clsPatient = null;
                _PatientDAL = null;
            }
            return returnValue;
        }

        /// <summary>
        /// This method resets all the controls
        /// </summary>
        private void ClearControls()
        {
            rdAssist.Checked = false;
            rdInPatient.Checked = false;
            rdOutPatient.Checked = false;
            txtFileLoadDate.Text = "";
            txtPatientFileNo.Text = "";
            txtSurname.Text = "";
            txtFirstName.Text = "";
            txtFaxNum.Text = "";
            //txtGuarantor.Text = "";
            txtAddr1.Text = "";
            txtAddr2.Text = "";
            txtAddr3.Text = "";
            txtAddr4.Text = "";
            txtAddr5.Text = "";
            txtInitials.Text = "";
            txtPostalCode.Text = "";
            txtGuarantorRefNum.Text = "";
            txtCompanyName.Text = "";
            txtEmailAddr.Text = "";
            infoText.Text = "";
            txtEmergencyContact.Text = "";
            //txtStatus.BackColor = System.Drawing.Color.White;
            txtMobileNumber.Text = "";
            txtWorkTelNum.Text = "";
            txtNationality.Text = "";
            txtPassport.Text = "";
            txtDateOfBirth.Text = "";
            txtHomePhone.Text = "";
            _patient = new Patient();
            aimsComboLookup1.lstItems.SelectedIndex = -1;
            aimsComboLookup2.lstItems.SelectedIndex = -1;
            txtFirstName.Focus();
            aimsComboLookup1.txtSearch.Text = "";
            aimsComboLookup2.txtSearch.Text = "";
            txtDiagnosis.Text = "";
            txtGuaranteeAmount.Text = "";
            txtDateDischarged.Text = "";
            txtDateAdmitted.Text = "";
            //chkCouried.Checked = false;
            chkFileClosed.Checked = false;
            chkCancelled.Checked = false;
            InvoiceSetup();
            MedicalTreatmentSetup();
            AuditSetup();
            tabControl1.SelectTab(0);
            cboGuarantors.SelectedValue = -1;
            cboFlightGuarantors.SelectedValue = -1;
            cboTitle.SelectedValue = -1;
            cboCountry.SelectedValue = -1;
            cboGuarantors.SelectedValue = -1;
            cboFlightGuarantors.SelectedValue = -1;
            cboHospitals.SelectedValue = -1;
            txtEmergencyContactNo.Text = "";
            cboAddressType.SelectedValue = -1;
            rdOutPatient.Checked = false;
            rdInPatient.Checked = false;
            NotesSetup("EXITNOTE");
            NotesSetup("PATIENTCOMMENT");
            NotesSetup("PATIENTLATESTUPDATE");
            NotesSetup("PATIENTMEDICALHISTORY");
            NotesSetup("PATIENTADMINNOTES");
            NotesSetup("PATIENTFINANCENOTES");
            NotesSetup("PATIENTINTERIMNOTES");
            ServiceProvidersSetup();
            rdAssist.Checked = false;
            rdRepat.Checked = false;
            rdFlight.Checked = false;
            txtGuaranteeAmount.Text = "";
            lblGuarantoredAmount.Text = "";
            //txtGuaranteedAmount.Text = "";

            rdTransport.Checked = false;
            txtCourierReceitDate.Text = "";
            txtFileDueDate.Text = "";
            cboAssistType.SelectedValue = -1;
            cboTransportType.SelectedValue = -1;
            cboRepatType.SelectedValue = -1;
            cboEvacuationType.SelectedValue = -1;
            txtWayBillNo.Text = "";
            txtGuarantee247No.Text = "";
            txtGuarantee247Email.Text = "";
            cboFileAssignedTo.SelectedValue = -1;
            cboOPSFileOwner.SelectedValue = -1;

            chkFilePending.Checked = false;
            chkLateLog.Checked = false;
            txtLateLogdate.Text = "";
            txtFileCourierDate.Text = "";
            LoadSupplierInfo = false;
            lstEmailAttachments.Items.Clear();
            lstPatientFileEmails.Items.Clear();
            lstPatientFileEmails.SelectedItems[0].Selected = true;
            txtLabListDate.Text = "";
            lstvwTasks.Items.Clear();
            chkSentToAdmin.Checked = false;
            chkHighCostFile.Checked = false;
        }

        private void DisableControls(bool enableStatus)
        {
            txtSurname.ReadOnly = enableStatus;
            txtFirstName.ReadOnly = enableStatus;
            txtInitials.ReadOnly = enableStatus;
            txtFaxNum.ReadOnly = enableStatus;
            txtAddr1.ReadOnly = enableStatus;
            txtAddr2.ReadOnly = enableStatus;
            txtAddr3.ReadOnly = enableStatus;
            txtAddr4.ReadOnly = enableStatus;
            txtAddr5.ReadOnly = enableStatus;
            txtPostalCode.ReadOnly = enableStatus;
            txtGuarantorRefNum.ReadOnly = enableStatus;
            txtCompanyName.ReadOnly = enableStatus;
            txtEmailAddr.ReadOnly = enableStatus;
            txtEmergencyContact.ReadOnly = enableStatus;
            txtMobileNumber.ReadOnly = enableStatus;
            txtWorkTelNum.ReadOnly = enableStatus;
            txtNationality.ReadOnly = enableStatus;
            txtPassport.ReadOnly = enableStatus;
            txtDateOfBirth.ReadOnly = enableStatus;
            txtHomePhone.ReadOnly = enableStatus;
            txtDiagnosis.ReadOnly = enableStatus;
            txtGuaranteeAmount.ReadOnly = enableStatus;
            //txtDateDischarged.ReadOnly = enableStatus;
            //txtDateAdmitted.ReadOnly = enableStatus;
            //chkCouried.Enabled = !enableStatus;
            chkSentToAdmin.Enabled = !enableStatus;
            chkHighCostFile.Enabled = !enableStatus;
            //chkFileClosed.Enabled = !enableStatus;
            //chkCancelled.Enabled = !enableStatus; 
            lnklblAdmitted.Enabled = !enableStatus;
            lnklblDischarged.Enabled = !enableStatus;

            cboTitle.Enabled = !enableStatus;
            cboAddressType.Enabled = !enableStatus;
            cboHospitals.Enabled = !enableStatus;
            cboGuarantors.Enabled = !enableStatus;
            //cboFlightGuarantors.Enabled = !enableStatus;
            cboCountry.Enabled = !enableStatus;
            btnAddComment.Enabled = !enableStatus;
            //btnSave.Enabled = !enableStatus;
            //txtDateAdmitted.ReadOnly = enableStatus;
            //txtDateDischarged.ReadOnly = enableStatus;
            txtEmergencyContactNo.ReadOnly = enableStatus;
            btnHospitalLookUp.Enabled = !enableStatus;
            panel1.Enabled = !enableStatus;
            chkLateLog.Enabled = !enableStatus;
            //txtWayBillNo.Enabled =!enableStatus;
            //cboFileAssignedTo.Enabled = !enableStatus;

            if (UserAllowed("28"))
            {
                cboFileAssignedTo.Enabled = !enableStatus;
            }
            else
            {
                cboFileAssignedTo.Enabled = false;
            }

            if (UserAllowed("37"))
            {
                cboOPSFileOwner.Enabled = !enableStatus;
            }
            else
            {
                cboOPSFileOwner.Enabled = false;
            }

            txtFileCourierDate.Enabled = UserAllowed("36");
            txtCourierReceitDate.Enabled = UserAllowed("93");

            lnklblCourierReceiptDate.Enabled = UserAllowed("93");
            lnklblCourierDate.Enabled = UserAllowed("36");

            if (UserAllowed("36"))
            {
                txtWayBillNo.ReadOnly = false;
            }
            else
            {
                txtWayBillNo.ReadOnly = true;
            }
            txtDateDischarged.Enabled = UserAllowed("42");
            lnklblDischarged.Enabled = UserAllowed("42");
            txtGuarantee247Email.Enabled = !enableStatus;
            txtGuarantee247No.Enabled = !enableStatus;
            //txtDateOfBirth.ReadOnly = !enableStatus;
            //txtLabListDate.ReadOnly = !enableStatus;
        }

        /// <summary>
        ///     Manual Input validation on patients form
        /// </summary>
        /// <returns></returns>
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
                return returnVal;
            }

            if (cboHospitals.SelectedItem != null && cboHospitals.Text == "<Add New Hospital>")
            {
                errPatients.SetError(cboHospitals, "Please specify a valid hospital");
                cboHospitals.Focus();
                btnAddPatient.Enabled = true;
                returnVal = false;
                return returnVal;
            }

            if (cboGuarantors.SelectedItem == null)
            {
                errPatients.SetError(cboGuarantors, "Please select a guarantor");
                cboGuarantors.Focus();
                btnAddPatient.Enabled = true;
                returnVal = false;
                return returnVal;
            }

            if (cboGuarantors.SelectedItem != null && (cboGuarantors.Text == "" | cboGuarantors.Text == "<Add New Guarantor>"))
            {
                errPatients.SetError(cboGuarantors, "Please select a guarantor");
                cboGuarantors.Focus();
                btnAddPatient.Enabled = true;
                returnVal = false;
                return returnVal;
            }

            if (cboGuarantors.SelectedItem != null && cboGuarantors.Text == "FLIGHTS" && (cboFlightGuarantors.SelectedItem == null || cboFlightGuarantors.Text == ""))
            {
                errPatients.SetError(cboFlightGuarantors, "Flight files require a Flight Guarantor.");
                cboFlightGuarantors.Focus();
                btnAddPatient.Enabled = true;
                returnVal = false;
                return returnVal;
            }

            if (!txtDateOfBirth.Text.Trim().Equals(""))
            {
                DateTime dtDateOfBirth;

                if (!DateTime.TryParse(txtDateOfBirth.Text, out dtDateOfBirth))
                {
                    errPatients.SetError(txtDateOfBirth, "Patient DOB Invalid");
                    txtDateOfBirth.Focus();
                    btnAddPatient.Enabled = true;
                    returnVal = false;
                    return returnVal;
                }
            }


            //if (!txtDateAdmitted.Text.Trim().Equals(""))
            //{
            //    DateTime dtAdmissionDate;

            //    if (!DateTime.TryParse(txtDateAdmitted.Text, out dtAdmissionDate))
            //    {
            //        errPatients.SetError(txtDateAdmitted, "Patient Admission date Invalid");
            //        txtDateAdmitted.Focus();
            //        btnAddPatient.Enabled = true;
            //        returnVal = false;
            //        return returnVal;
            //    }
            //    txtDateAdmitted.Text = System.Convert.ToDateTime(txtDateAdmitted.Text).ToString("dd/MM/yyyy");
            //}

            //if (!txtDateDischarged.Text.Trim().Equals(""))
            //{
            //    DateTime dtDischargeDate;
            //    if (!DateTime.TryParse(txtDateDischarged.Text, out dtDischargeDate))
            //    {
            //        errPatients.SetError(txtDateDischarged, "Patient Discharged date Invalid");
            //        txtDateDischarged.Focus();
            //        btnAddPatient.Enabled = true;
            //        returnVal = false;
            //        return returnVal;
            //    }
            //    txtDateDischarged.Text = System.Convert.ToDateTime(txtDateDischarged.Text).ToString("dd/MM/yyyy");
            //}

            if (!txtDateDischarged.Text.Trim().Equals("") && !txtDateAdmitted.Text.Trim().Equals(""))
            {

                string sDischargeDate = DateTime.ParseExact(txtDateDischarged.Text, "dd/MM/yyyy", null).ToShortDateString();
                string sAdmissionDate = DateTime.ParseExact(txtDateAdmitted.Text, "dd/MM/yyyy", null).ToShortDateString();

                System.TimeSpan diffResult = System.Convert.ToDateTime(sDischargeDate) - System.Convert.ToDateTime(sAdmissionDate);
                if (diffResult.Days < 0)
                {
                    errPatients.SetError(txtDateDischarged, "Patient discharged date must be in the future.");
                    txtDateDischarged.Focus();
                    btnAddPatient.Enabled = true;
                    returnVal = false;
                    return returnVal;
                }
            }

            if (txtEmailAddr.Text.Trim().Length > 0)
            {
                if (!ValidEmailAddress(txtEmailAddr.Text.Trim()))
                {
                    errPatients.SetError(txtEmailAddr, "Please enter valid email address");
                    txtEmailAddr.Focus();
                    btnAddPatient.Enabled = true;
                    returnVal = false;
                    return returnVal;
                }
            }

            if (txtFileCourierDate.Text.Trim() != "" & !chkFileClosed.Checked)
	        {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please Close File before Capturing the Courier");
                errPatients.SetError(chkFileClosed , "Please Close File before Capturing the Courier");
                chkFileClosed.Focus();
                btnAddPatient.Enabled = true;
                returnVal = false;
                return returnVal;        		 
	        }

            if (cboFileAssignedTo.SelectedItem != null & txtCourierReceitDate.Text == "")
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture Courier Receipt Date");
                errPatients.SetError(txtCourierReceitDate, "Please capture Courier Receipt Date");
                txtCourierReceitDate.Focus();
                btnAddPatient.Enabled = true;
                returnVal = false;
                return returnVal;
            }

            if (chkFileClosed.Checked & (cboFileAssignedTo.SelectedItem == null || cboFileAssignedTo.Text == ""))
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture Admin Co-Ordinator before closing file.");
                errPatients.SetError(cboFileAssignedTo, "Please capture Admin Co-Ordinator before closing file");
                cboFileAssignedTo.Focus();
                btnAddPatient.Enabled = true;
                returnVal = false;
                return returnVal;
            }

            if (this.txtGuaranteeAmount.Text.Trim().Length > 0)
            {
                try
                {
                    Int32 tmp1;
                    string strLoop = "";
                    for (int i = 0; i < this.txtGuaranteeAmount.Text.Trim().Length; i++)
                    {
                        strLoop = this.txtGuaranteeAmount.Text.Trim().Substring(i, 1).Trim();
                        if (strLoop.Length > 0)
                        {
                            if (!Int32.TryParse(strLoop, out tmp1) & strLoop != ".")
                            {
                                errPatients.SetError(txtGuaranteeAmount, "Guarantor Amount not valid, This field can only contain valid currency.");
                                txtGuaranteeAmount.Focus();
                                returnVal = false;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }


            if (!rdInPatient.Checked & !rdOutPatient.Checked
                 & !rdAssist.Checked
                 & !rdTransport.Checked
                 & !rdRepat.Checked
                 & !rdFlight.Checked 
                 & !rdRMR.Checked )
            {
                errPatients.SetError(panel1, "Please capture file type category"); 
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture file type category.");
                btnAddPatient.Enabled = true;
                returnVal = false;
                return returnVal;
            }

            if (rdAssist.Checked && cboAssistType.SelectedItem == null)
            {
                errPatients.SetError(cboAssistType, "Please select assistance category");
                cboAssistType.Focus();
                returnVal = false;
            }

            if (rdAssist.Checked && cboAssistType.Text == "")
            {
                errPatients.SetError(cboAssistType, "Please select assistance category");
                cboAssistType.Focus();
                returnVal = false;
            }

            if (rdTransport.Checked && cboTransportType.SelectedItem == null)
            {
                errPatients.SetError(cboTransportType, "Please select transport category");
                cboTransportType.Focus();
                returnVal = false;
            }

            if (rdTransport.Checked && cboTransportType.Text == "")
            {
                errPatients.SetError(cboTransportType, "Please select transport category");
                cboTransportType.Focus();
                returnVal = false;
            }

            if (rdFlight.Checked && cboEvacuationType.SelectedItem == null)
            {
                errPatients.SetError(cboEvacuationType, "Please select Evacuation category");
                cboEvacuationType.Focus();
                returnVal = false;
            }

            if (rdFlight.Checked && cboEvacuationType.Text == "")
            {
                errPatients.SetError(cboEvacuationType, "Please select Evacuation category");
                cboEvacuationType.Focus();
                returnVal = false;
            }

            if (rdRepat.Checked && cboRepatType.SelectedItem == null)
            {
                errPatients.SetError(cboRepatType, "Please select repatriation category");
                cboRepatType.Focus();
                returnVal = false;
            }

            if (rdRepat.Checked && cboRepatType.Text == "")
            {
                errPatients.SetError(cboRepatType, "Please select repatriation category");
                cboRepatType.Focus();
                returnVal = false;
            }

            if (rdRMR.Checked && cboRMRType.SelectedItem == null)
            {
                errPatients.SetError(cboRMRType, "Please select RMR category");
                cboRMRType.Focus();
                returnVal = false;
            }

            if (rdRMR.Checked && cboRMRType.Text == "")
            {
                errPatients.SetError(cboRMRType, "Please select RMR category");
                cboRMRType.Focus();
                returnVal = false;
            }
            return returnVal;
        }

        #endregion

        #region Combo Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aimsComboLookup1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method fires when the users double clicks the combo listbox
        /// </summary>
        protected void aimsComboLookup1_DblClicked()
        {
            PatientSearch = "PATIENT";
            btnSelect_Click(null, null);
        }

        protected void aimsComboLookup1_BtnChange()
        {
            ClearControls();
        }

        protected void aimsComboLookup2_DblClicked()
        {
            PatientSearch = "GUARANTOR";
            btnSelect_Click(null, null);
        }
        #endregion

        private void txtDateAdmitted_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);

            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtDateAdmitted.Text = frmCal.StartDate.ToString("dd/MM/yyyy");
            }

            txtDateAdmitted.Focus();
        }

        private void txtDateDischarged_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtDateDischarged.Text = frmCal.StartDate.ToString("dd/MM/yyyy");
            }

            txtDateDischarged.Focus();
        }

        private void lnklblDischarged_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDateDischarged_DoubleClick(null, null);
        }

        private void lnklblCourierReceiptDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtCourierReceitDate_DoubleClick(null, null);
        }

        private void lnklblAdmitted_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDateAdmitted_DoubleClick(null, null);
        }

        private void txtFaxNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGuaranteeAmount_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;
            string NewInvoiceAmt = "";

            try
            {
                if (txtGuaranteeAmount.Text.Trim().Length > 0)
                {
                    if (!double.TryParse(txtGuaranteeAmount.Text, out tmp))
                    {
                        if (txtGuaranteeAmount.Text.Substring(txtGuaranteeAmount.Text.Trim().Length - 1, 1) != ".")
                        {
                            if (!double.TryParse(txtGuaranteeAmount.Text.Trim(), out tmp1))
                            {
                            }
                        }
                    }

                    if (Int32.TryParse(txtGuaranteeAmount.Text, out tmp3))
                    {
                        decimal txtGuarantAmount = System.Convert.ToDecimal(txtGuaranteeAmount.Text.Replace(" ", ""));
                        lblGuarantoredAmount.Text = txtGuarantAmount.ToString("C");
                    }
                    else
                    {
                        lblGuarantoredAmount.Text = "";
                        txtGuaranteeAmount.Text = "";
                    }
                }
                else
                {
                    lblGuarantoredAmount.Text = "";
                    txtGuaranteeAmount.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void txtGuaranteeAmount_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    // allows only numbers, decimals and control characters
            //    if (System.Convert.ToInt32(e.KeyCode) < 48 | System.Convert.ToInt32(e.KeyCode) > 57)
            //    {
            //        if (System.Convert.ToInt32(e.KeyCode) != 190 & System.Convert.ToInt32(e.KeyCode) != 8 & System.Convert.ToInt32(e.KeyValue) != 36 & System.Convert.ToInt32(e.KeyValue) != 35 & System.Convert.ToInt32(e.KeyValue) != 39 & System.Convert.ToInt32(e.KeyValue) != 37 & System.Convert.ToInt32(e.KeyValue) != 18)
            //        {
            //            MessageBox.Show("This field can contain only numbers.", "Numbers Only", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }   
            //}
            //catch (System.Exception )
            //{                
            //    throw;
            //}         
        }

        private void txtGuaranteeAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (System.Exception)
            {
                throw;
            }
        }

        private void txtDateAdmitted_TextChanged(object sender, EventArgs e)
        {
            //double tmp;
            //double tmp1;
            //if (txtDateAdmitted.Text.Trim().Length > 0)
            //{
            //    tmp = 0;
            //}
        }

        private void btnUnlockFile_Click(object sender, EventArgs e)
        {
            AIMS.BLL.Patient clsPatient = new Patient();
            try
            {
                bool bSaved = false;
                _patient = new Patient();

                if (lblPatientFileNumber.Text.Trim().Length > 0)
                {
                    _patient.PatientFileNo = lblPatientFileNumber.Text;
                }

                _patient.LoggedOnUser = UserID;
                bSaved = _patient.PatientFileUnlock();

                if (bSaved)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Patient File Unlocked successfully");
                    DisableControls(false);
                    btnUnlockFile.Enabled = false;
                    chkFileClosed.Enabled = true;
                    chkFileClosed.Checked = false;
                    btnSave.Enabled = UserAllowed("5");
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File NOT Unlocked successfully");
                    chkFileClosed.Checked = true;
                    chkFileClosed.Enabled = true;
                    DisableControls(true);
                    btnUnlockFile.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File unlocking failed, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Unlocking Files failed: " + ex.ToString());
            }
            finally
            {
                clsPatient = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                InvoiceSetup();
                MedicalTreatmentSetup();
                NotesSetup("PATIENTMEDICALHISTORY");
                NotesSetup("PATIENTCOMMENT");
                NotesSetup("PATIENTINTERIMNOTES");
                NotesSetup("PATIENTFINANCENOTES");
                NotesSetup("PATIENTADMINNOTES");
                ServiceProvidersSetup();
                LoadSuppliers();
                AuditSetup();

                LoadInvoices();
                LoadLateInvoices();
                LoadDoctorOwingInvoices();
                LoadMedicalTreatment();
                LoadAssistTypes();

                LoadTransportTypes();
                LoadRepatriationTypes();
                LoadEvacuationTypes();
                LoadRMRTypes();
                LoadNotes("'PATIENTCOMMENT','PATIENTLATESTUPDATE'");
                LoadNotes("'PATIENTMEDICALHISTORY'");
                LoadNotes("'PATIENTADMINNOTES'");
                LoadNotes("'PATIENTINTERIMNOTES'");
                LoadNotes("'PATIENTFINANCENOTES'");
                LoadGuarantors();
                LoadFlightGuarantors();
                LoadTemplates("");
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Refreshing AIMS Recorder Failed, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Patient form refreshing failed, Error - " + ex.ToString());
            }
        }

        private void lstvwInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHospitalLookUp_Click(object sender, EventArgs e)
        {
            frmSuppliers frmSupp = new frmSuppliers();
            frmSupp.Text = "Hospital Supplier Look-Up";
            try
            {
                if (MessageBox.Show("Continue with adding a new hospital supplier?", "New Hospital", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cboHospitals.SelectedIndex > 0)
                    {
                        if (cboHospitals.SelectedValue != null)
                        {
                            frmSupp.AddNewSupplier = true;
                            frmSupp.SupplierID = System.Convert.ToInt32(cboHospitals.SelectedValue);
                        }
                    }
                    else
                    {
                        frmSupp.AddNewSupplier = true;
                        frmSupp.NewHospitalSupplier = cboHospitals.Text;
                        frmSupp.SupplierID = 0;
                    }

                    frmSupp.ShowDialog();
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Refreshing AIMS Recorder Failed, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Patient form refreshing failed, Error - " + ex.ToString());
            }
        }

        private void cboHospitals_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmSuppliers frmSupp = new frmSuppliers();
            frmSupp.Text = "Hospital Supplier Look-Up";

            if (cboHospitals.SelectedItem != null && cboHospitals.Text == "<Add New Supplier>" && cboHospitals.SelectedValue != "")
            {
                if (MessageBox.Show("Continue with adding a new hospital supplier?", "New Hospital", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cboHospitals.SelectedIndex > 0)
                    {
                        if (cboHospitals.SelectedValue != null)
                        {
                            frmSupp.AddNewSupplier = true;
                            frmSupp.SupplierID = System.Convert.ToInt32(cboHospitals.SelectedValue);
                        }
                    }
                    else
                    {
                        frmSupp.AddNewSupplier = true;
                        frmSupp.NewHospitalSupplier = "";
                        frmSupp.SupplierID = 0;
                    }
                    frmSupp.Restrictions = Restrictions;
                    frmSupp.StartPosition = FormStartPosition.CenterScreen;
                    frmSupp.FormBorderStyle = FormBorderStyle.FixedSingle;
                    frmSupp.StartPosition = FormStartPosition.CenterScreen;
                    frmSupp.MaximizeBox = false;
                    frmSupp.MinimizeBox = false;
                    frmSupp.ShowDialog();
                    LoadSuppliers();
                }
                else
                {
                    cboHospitals.SelectedValue = -1;
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

        private void btnViewLateInvoices_Click(object sender, EventArgs e)
        {
            frmReportViewer frmRep = new frmReportViewer(txtPatientFileNo.Text, "Consolidation Report - Patient No: " + txtPatientFileNo.Text);
            //commonFuncs = new AIMS.Common.CommonFunctions();

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.LateInvoiceYN = "Y";
                if (chkIncludeSentLateInv.Checked)
                {
                    frmRep.LateInvoiceSentYN = "";
                }
                else
                {
                    frmRep.LateInvoiceSentYN = "N";
                }
                frmRep.DoctorOwing = "N";
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
            finally
            {
                ////commonFuncs = null;
            }
        }

        public bool ValidEmailAddress(string emailAddress)
        {
            bool isValid = false;
            try
            {
                //create Regular Expression Match pattern object
                System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$");

                //boolean variable to hold the status                
                if (string.IsNullOrEmpty(emailAddress.ToLower()))
                {
                    isValid = false;
                }
                else
                {
                    isValid = myRegex.IsMatch(emailAddress.ToLower());
                }
            }
            catch (Exception)
            {
                throw;
            }
            //return the results
            return isValid;
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
                        this.btnRefresh.Left = btnSelect.Width + 20;
                        this.btnRefresh.Top = btnSelect.Top;
                        this.btnRefresh.Width = btnSelect.Width;
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
                }else if(cboGuarantors.SelectedItem != null && cboGuarantors.Text == "FLIGHTS"){
                    cboFlightGuarantors.Enabled = true ;
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
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Guarantor selection error: " + ex.ToString());
            }
            finally
            {
                frmGuarantors = null;
            }
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
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading Guarantor Details");
                clsGuarantor = null;
            }
            finally
            {
                clsGuarantor = null;
            }
        }

        private void btnAddMedicalNote_Click(object sender, EventArgs e)
        {
            try
            {
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Medical Note";
                frmNotes.UserID = UserID;
                frmNotes.NoteID = 0;
                frmNotes.NoteTypeCode = "PATIENTMEDICALHISTORY";

                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTMEDICALHISTORY");
                    LoadNotes("'PATIENTMEDICALHISTORY'");
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void lstlvwMedNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstlvwMedNotes_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string MedicalNoteText = lstGet.Items[i].SubItems[1].Text.ToString();
                        MessageBox.Show(MedicalNoteText, "Medical Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                lstGet = null;
            }
        }

        private void lstlvwNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void ModifyPatientNote() 
        {
            //ListView lstGet = (ListView)sender;
            //try
            //{
            //    for (int i = 0; i < lstGet.Items.Count; i++)
            //    {
            //        if (lstGet.Items[i].Selected)
            //        {
            //            string ServiceProviderID = lstGet.Items[i].SubItems[5].Text.ToString();
            //            if (ServiceProviderID.Trim().Length > 0)
            //            {
            //                DataTable dsPatientServiceProvider = new DataTable(); ;
            //                ListViewItem lvwItem;
            //                AIMS.BLL.Supplier supplierBLL = new Supplier();
            //                dsPatientServiceProvider = supplierBLL.GetServiceProvider(ServiceProviderID);
            //                if (dsPatientServiceProvider.Rows.Count > 0)
            //                {
            //                    frmServiceProviders frmServProviders;
            //                    frmServProviders = new frmServiceProviders(txtPatientFileNo.Text);
            //                    frmServProviders.ShowInTaskbar = false;
            //                    frmServProviders.StartPosition = FormStartPosition.CenterScreen;
            //                    frmServProviders.Text = "Service Providers";
            //                    frmServProviders.UserID = UserID;
            //                    frmServProviders.ServiceProviderEmail = dsPatientServiceProvider.Rows[0]["service_provider_email"].ToString();
            //                    frmServProviders.ServiceProviderFax = dsPatientServiceProvider.Rows[0]["service_provider_fax_no"].ToString();
            //                    frmServProviders.ServiceProviderName = dsPatientServiceProvider.Rows[0]["service_provider_name"].ToString();
            //                    frmServProviders.ServiceProviderPhone = dsPatientServiceProvider.Rows[0]["service_provider_phone"].ToString();
            //                    frmServProviders.SupplierTypeID = System.Convert.ToInt32(dsPatientServiceProvider.Rows[0]["SUPPLIER_TYPE_ID"]);
            //                    frmServProviders.ServiceProviderID = System.Convert.ToInt64(dsPatientServiceProvider.Rows[0]["service_provider_id"]);

            //                    if (frmServProviders.ShowDialog() == DialogResult.OK)
            //                    {
            //                        frmServProviders.Close();
            //                        ServiceProvidersSetup();
            //                        LoadPatientServiceProviders();
            //                    }
            //                }
            //                lstGet.Items[i].Checked = false;
            //            }
            //        }
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    lstGet = null;
            //}
        }

        private void lstlvwNotes_ItemClick(object sender, EventArgs e) 
        {
           
        }

        private void lstlvwNotes_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string cccc = lstGet.Items[i].SubItems[1].Text.ToString();
                        MessageBox.Show(cccc, "Patient File Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (System.Exception ex)
            {
                lstGet = null;
            }
        }

        private void txtFileCourierDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFileCourierDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                ///txtFileCourierDate.Text = frmCal.StartDate.ToShortDateString();
                DateTime dobDate = System.Convert.ToDateTime(frmCal.StartDate);
                txtFileCourierDate.Text = dobDate.ToString("dd/MM/yyyy");
            }

            txtFileCourierDate.Focus();
        }

        private void btnServiceProvider_Click(object sender, EventArgs e)
        {
            try
            {
                frmServiceProviders frmServProviders;
                frmServProviders = new frmServiceProviders(txtPatientFileNo.Text);
                frmServProviders.ShowInTaskbar = false;
                frmServProviders.Restrictions = Restrictions;
                frmServProviders.StartPosition = FormStartPosition.CenterScreen;
                frmServProviders.Text = "Add New Service Providers";
                frmServProviders.UserID = UserID;

                if (frmServProviders.ShowDialog() == DialogResult.OK)
                {
                    frmServProviders.Close();
                    ServiceProvidersSetup();
                    LoadPatientServiceProviders();
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Service Provider could not load, Error: " + ex.Message);
            }
        }

        private void txtCourierReceitDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCourierReceitDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtCourierReceitDate.Text = frmCal.StartDate.ToShortDateString();
                DateTime dtFileDueDate = Convert.ToDateTime(txtCourierReceitDate.Text);
                FileDueDate(dtFileDueDate);
            }

            txtCourierReceitDate.Focus();
        }

        private void rdAssist_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAssist.Checked)
            {
                cboTransportType.SelectedValue = -1;
                cboRepatType.SelectedValue = -1;
                cboEvacuationType.SelectedValue = -1;
                cboRMRType.SelectedValue = -1;
            }
        }

        private void rdTransport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTransport.Checked)
            {
                cboAssistType.SelectedValue = -1;
                cboRepatType.SelectedValue = -1;
                cboEvacuationType.SelectedValue = -1;
                cboRMRType.SelectedValue = -1;
            }
        }

        private void LoadFileAdministrators()
        {
            try
            {
                DataTable dtFileAdministrators = new DataTable();
                dtFileAdministrators = commonFuncs.GetFileAdministrators();

                if (dtFileAdministrators.Rows.Count > 0)
                {
                    cboFileAssignedTo.DataSource = dtFileAdministrators;
                    cboFileAssignedTo.DisplayMember = "USER_NAME_FULL";
                    cboFileAssignedTo.ValueMember = "USER_NAME";
                    cboFileAssignedTo.SelectedValue = -1;
                }
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading File Administrator list.");
            }
        }


        private void LoadFileOperators()
        {
            try
            {
                DataTable dtFileOperators = new DataTable();
                dtFileOperators = commonFuncs.GetFileOperators();

                if (dtFileOperators.Rows.Count > 0)
                {
                    cboOPSFileOwner.DataSource = dtFileOperators;
                    cboOPSFileOwner.DisplayMember = "USER_NAME_FULL";
                    cboOPSFileOwner.ValueMember = "USER_NAME";

                    cboOPSFileOwner.SelectedValue = -1;
                }
            }
            catch (Exception ex)
            {
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "An error occured while loading File operators list.");
            }
        }

        private void LoadPatientServiceProviders()
        {
            DataTable dsPatientServiceProviders = new DataTable(); ;
            ListViewItem lvwItem;
            AIMS.BLL.Supplier supplierBLL = new Supplier();

            dsPatientServiceProviders.Clear();
            if (lblPatientID.Text.ToString().Trim().Length > 0)
            {
                dsPatientServiceProviders = supplierBLL.GetPatientServiceProviders(lblPatientID.Text.ToString());

                try
                {
                    System.Drawing.FontFamily ffr1 = new FontFamily("Tahoma");

                    for (int i = 0; i < dsPatientServiceProviders.Rows.Count; i++)
                    {
                        lvwItem = new ListViewItem(dsPatientServiceProviders.Rows[i]["supplier_type_desc"].ToString());
                        lvwItem.SubItems.Add(dsPatientServiceProviders.Rows[i]["service_provider_name"].ToString());
                        lvwItem.SubItems.Add(dsPatientServiceProviders.Rows[i]["service_provider_phone"].ToString());
                        lvwItem.SubItems.Add(dsPatientServiceProviders.Rows[i]["service_provider_fax_no"].ToString());
                        lvwItem.SubItems.Add(dsPatientServiceProviders.Rows[i]["service_provider_email"].ToString());
                        lvwItem.SubItems.Add(dsPatientServiceProviders.Rows[i]["service_provider_id"].ToString());
                        lvwItem.SubItems.Add(dsPatientServiceProviders.Rows[i]["User_Full_Name"].ToString());
                        lvwItem.SubItems.Add(dsPatientServiceProviders.Rows[i]["MODIFIED_DATE"].ToString());

                        lstvwServiceProviders.Items.Add(lvwItem);
                    }

                    gvServiceProviders.DataSource = dsPatientServiceProviders;
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading patient service providers Failed : Error - " + ex.Message);
                    throw;
                }
                finally
                {
                    lvwItem = null;
                    supplierBLL = null;
                    dsPatientServiceProviders.Dispose();
                }
            }
        }

        private void lstvwServiceProviders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstvwServiceProviders_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string ServiceProviderID = lstGet.Items[i].SubItems[5].Text.ToString();
                        if (ServiceProviderID.Trim().Length > 0)
                        {
                            DataTable dsPatientServiceProvider = new DataTable(); ;
                            ListViewItem lvwItem;
                            AIMS.BLL.Supplier supplierBLL = new Supplier();
                            dsPatientServiceProvider = supplierBLL.GetServiceProvider(ServiceProviderID);
                            if (dsPatientServiceProvider.Rows.Count > 0)
                            {
                                frmServiceProviders frmServProviders;
                                frmServProviders = new frmServiceProviders(txtPatientFileNo.Text);
                                frmServProviders.ShowInTaskbar = false;
                                frmServProviders.StartPosition = FormStartPosition.CenterScreen;
                                frmServProviders.Text = "Service Providers";
                                frmServProviders.UserID = UserID;
                                frmServProviders.Restrictions = Restrictions;
                                frmServProviders.ServiceProviderEmail = dsPatientServiceProvider.Rows[0]["service_provider_email"].ToString();
                                frmServProviders.ServiceProviderFax = dsPatientServiceProvider.Rows[0]["service_provider_fax_no"].ToString();
                                frmServProviders.ServiceProviderName = dsPatientServiceProvider.Rows[0]["service_provider_name"].ToString();
                                frmServProviders.ServiceProviderPhone = dsPatientServiceProvider.Rows[0]["service_provider_phone"].ToString();
                                frmServProviders.SupplierTypeID = System.Convert.ToInt32(dsPatientServiceProvider.Rows[0]["SUPPLIER_TYPE_ID"]);
                                frmServProviders.ServiceProviderID = System.Convert.ToInt64(dsPatientServiceProvider.Rows[0]["service_provider_id"]);

                                frmServProviders.ServiceProviderAdmin = dsPatientServiceProvider.Rows[0]["ADMIN_NAME"].ToString();
                                frmServProviders.ServiceProviderAdminTel = dsPatientServiceProvider.Rows[0]["ADMIN_TEL_PHONE"].ToString();
                                frmServProviders.ServiceProviderAdminFax = dsPatientServiceProvider.Rows[0]["ADMIN_FAX_NO"].ToString();
                                frmServProviders.ServiceProviderAdminEmail = dsPatientServiceProvider.Rows[0]["ADMIN_EMAIL"].ToString();

                                if (frmServProviders.ShowDialog() == DialogResult.OK)
                                {
                                    frmServProviders.Close();
                                    ServiceProvidersSetup();
                                    LoadPatientServiceProviders();
                                }
                            }
                            lstGet.Items[i].Checked = false;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                lstGet = null;
            }
        }

        private void btnRemoveServiceProvider_Click(object sender, EventArgs e)
        {
            bool entryDeleted = false;
            try
            {
                if (MessageBox.Show("Continue deleting selected service providers?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < lstvwServiceProviders.Items.Count; i++)
                    {
                        if (lstvwServiceProviders.Items[i].Checked)
                        {
                            AIMS.BLL.Supplier supplierBLL = new Supplier();
                            string ServiceProviderID = lstvwServiceProviders.Items[i].SubItems[5].Text.ToString();
                            bool RemoveProvider = supplierBLL.ServiceProvider_Delete(ServiceProviderID);
                            if (RemoveProvider)
                            {
                                entryDeleted = true;
                            }
                            supplierBLL = null;
                        }
                    }
                }

                ServiceProvidersSetup();
                LoadPatientServiceProviders();

                if (!entryDeleted)
                {
                    MessageBox.Show("No service provider was removed", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error removing service provider: " + ex.Message);
            }
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = "";
            AIMS.BLL.Invoice _invoiceNew = new Invoice();
            try
            {
                if (cboCountry.SelectedItem != null && cboCountry.Text == "<Add New Country>")
                {
                    if (InputBox("New Country", "Country Name", ref value) == DialogResult.OK)
                    {
                        if (value.Trim().Length > 0)
                        {
                            bool bSaved = false;

                            AIMS.BLL.Invoice clsInvoice = new Invoice();

                            DataTable dtCountryCheck = _invoiceNew.CheckIfCountryExist(value.Trim());

                            if (dtCountryCheck.Rows.Count > 0)
                            {
                                MessageBox.Show("Country already exists", "Country Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cboCountry.SelectedIndex = -1;
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
                                        cboCountry.DataSource = dtCountries;
                                        cboCountry.DisplayMember = "COUNTRY_NAME";
                                        cboCountry.ValueMember = "COUNTRY_ID";
                                        cboCountry.SelectedIndex = -1;
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
                            cboCountry.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        cboCountry.SelectedIndex = -1;
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

        private void btnViewDoctorOwingReport_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportViewer frmRep = new frmReportViewer(txtPatientFileNo.Text, "Consolidation Report - Patient No: " + txtPatientFileNo.Text);
                //commonFuncs = new AIMS.Common.CommonFunctions();

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                StringBuilder sbHTML = new StringBuilder();

                try
                {
                    frmRep.LateInvoiceYN = "N";
                    frmRep.DoctorOwing = "Y";
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

        private void lstvwLateInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkLateLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLateLog.Checked)
            {
                if (!LoadSupplierInfo)
                {
                    LateLogDate = "";
                    LateLogInputBox("Late Log", "Late Log date(dd/mm/yyyy)", ref LateLogDate);

                    if (LateLogDate.Trim().Length == 0)
                    {
                        chkLateLog.Checked = false;
                        txtLateLogdate.Text = "";
                    }
                    else
                    {
                        DateTime dtLateLog;
                        if (!DateTime.TryParse(LateLogDate, out dtLateLog))
                        {
                            MessageBox.Show("Late Log Date Invalid, Please re-capture", "Late Log Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkLateLog.Checked = false;
                            txtLateLogdate.Text = "";
                        }
                        else
                        {
                            txtLateLogdate.Text = LateLogDate.Trim();
                        }
                    }
                }
                LoadSupplierInfo = false;
            }
            else
            {
                LateLogDate = "";
                txtLateLogdate.Text = "";
            }
        }

        public static DialogResult LateLogInputBox(string title, string promptText1, ref string value1)
        {
            try
            {
                Form form = new Form();
                Label label1 = new Label();
                TextBox textBox1 = new TextBox();
                //MaskedTextBox textBox1 = new MaskedTextBox("##/##/####"); 
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
                buttonOk.Top = textBox1.Bottom + 10;
                buttonCancel.Top = textBox1.Bottom + 10;

                form.ClientSize = new Size(420, 120);
                form.Controls.AddRange(new Control[] { label1, textBox1, buttonOk, buttonCancel });
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

        private void cboFileAssignedTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEmailLateInvoices_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            //commonFuncs = new AIMS.Common.CommonFunctions();
            bool bEmailSent = false;
            AIMS.BLL.Reports AIMSReport = new Reports();
            btnEmailLateInvoices.Enabled = false;
            try
            {
                string InvoiceStatementFiles = "";
                AIMSReport.BuildConsolidationCoverReport(txtPatientFileNo.Text, "Y", "N", "N", true, ref InvoiceStatementFiles);

                bEmailSent = commonFuncs.SendEmail("", "admin@aims.org.za", "AIMS Admin", "ATT: " + UserName + " - " + txtPatientFileNo.Text + " - System Late Invoices Printing", UserEmailAddress, InvoiceStatementFiles);
                if (bEmailSent)
                {
                    MessageBox.Show("Late Invoice Email Sent Successfully", "Late Invoice Statements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Late Invoice Email NOT Sent Successfully", "Late Invoice Statements", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Email Late Invoice Consolidation, Please try again");
                commonFuncs.ErrorLogger("Error Email Late Invoice Consolidation: " + ex.ToString());
            }
            finally
            {
                AIMSReport = null;
                btnEmailLateInvoices.Enabled = true;
            }

            this.UseWaitCursor = false;
        }

        private void btnEmailInvoices_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            Application.DoEvents();
            bool bEmailSent = false;
            AIMS.BLL.Reports AIMSReport = new Reports();
            //commonFuncs = new AIMS.Common.CommonFunctions();
            btnEmailInvoices.Enabled = false;
            try
            {
                string InvoiceStatementFiles = "";
                AIMSReport.BuildConsolidationCoverReport(txtPatientFileNo.Text, "N", "N", "N", true, ref InvoiceStatementFiles);

                bEmailSent = commonFuncs.SendEmail("", "admin@aims.org.za", "AIMS Admin", "ATT: " + UserName + " - " + txtPatientFileNo.Text + " - System Invoices Printing", UserEmailAddress, InvoiceStatementFiles);
                if (bEmailSent)
                {
                    MessageBox.Show("Invoice Email Sent Successfully", "Invoice Statements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invoice Email NOT Sent Successfully", "Invoice Statements", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Application.DoEvents();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Email Invoice Consolidation, Please try again");
                commonFuncs.ErrorLogger("Error Email Invoice Consolidation: " + ex.ToString());
            }
            finally
            {
                AIMSReport = null;
                btnEmailInvoices.Enabled = true;
            }
            this.UseWaitCursor = false;
        }

        private void rdFlight_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFlight.Checked)
            {
                cboRepatType.SelectedValue = -1;
                cboTransportType.SelectedValue = -1;
                cboAssistType.SelectedValue = -1;
                cboRMRType.SelectedValue = -1;
            }
        }

        private void rdRepat_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRepat.Checked)
            {
                cboEvacuationType.SelectedValue = -1;
                cboTransportType.SelectedValue = -1;
                cboAssistType.SelectedValue = -1;
                cboRMRType.SelectedValue = -1;
            }
        }

        private void btnPatientTranscript_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportViewer frmRep = new frmReportViewer(txtPatientFileNo.Text, "AIMS Patient File History - Patient No: " + txtPatientFileNo.Text);
                //commonFuncs = new AIMS.Common.CommonFunctions();

                frmRep.PatientFileNo = txtPatientFileNo.Text;

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                StringBuilder sbHTML = new StringBuilder();
                DataTable tbl = new DataTable("HTMLPages");
                DataSet ds = new DataSet();

                frmRep.ShowDialog();

            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Transcript failed, Please try again.");
                commonFuncs.ErrorLogger("");
            }
        }

        private string createPDFReport(string worksheetType)
        {
            string fileHeader = string.Empty;

            // Save the document...
            string filename = "";

            try
            {

                // Create a new PDF document
                PdfDocument document = new PdfDocument();

                // Create an empty page
                PdfPage page = document.AddPage();
                //page.Contents.CreateSingleContent().Stream.UnfilteredValue;


                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create a font
                XFont fontHeader = new XFont("Verdana", 14, XFontStyle.Bold);
                XFont fontText = new XFont("Verdana", 10, XFontStyle.Regular);
                XFont fontTextBold = new XFont("Verdana", 10, XFontStyle.Bold);

                int w = 30;
                int h = 100;

                fileHeader = "AIMS - Patient File Transcript";
                filename = fileHeader.Replace(" ", "_") + "_" + Convert.ToString(txtPatientFileNo.Text.Replace("/", "")) + ".pdf";

                // Draw the text
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(10, h, page.Width, page.Height), XStringFormat.TopCenter);

                h += 120;

                createPatientCaseHistoryCoverPage(ref gfx, ref page, ref h, ref w);

                h += 80;

                gfx.DrawString("1 Please see attached patient file history of all comments/notes captured from when the file was created.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 100;

                gfx.DrawString("2 Please see attached patient file history of all comments/notes captured from when the file was created.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 100;

                gfx.DrawString("3 Please see attached patient file history of all comments/notes captured from when the file was created.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 100;

                gfx.DrawString("4 Please see attached patient file history of all comments/notes captured from when the file was created.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 100;

                gfx.DrawString("5 Please see attached patient file history of all comments/notes captured from when the file was created.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 100;

                gfx.DrawString("Please see attached patient file history of all comments/notes captured from when the file was created.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 100;

                XImage image = XImage.FromFile(@"c:\AIMSLOGO.gif");

                double dx = 1100, dy = 70;

                double width = image.Width * 20 / image.HorizontalResolution;
                double height = image.Height * 20 / image.HorizontalResolution;

                gfx.DrawImage(image, (dx - width) / 2, (dy - height) / 2, width, height);

                filename = @"c:\AIMS Recorder" + filename;
                document.Save(filename);
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Generating Patient File History Failed, Please try again.");
                commonFuncs.ErrorLogger("Generating Patient File History Failed: " + ex.ToString());
            }

            // ...and start a viewer.
            return (filename);
        }

        private void createPatientCaseHistoryCoverPage(ref XGraphics gfx, ref PdfPage page, ref int yTop, ref int wLeft)
        {
            try
            {
                string CaseManager = "";

                if (cboOPSFileOwner.SelectedValue != null && cboOPSFileOwner.Text != "")
                {
                    CaseManager = cboOPSFileOwner.Text;
                }
                else
                {
                    CaseManager = "Eric Prinsloo";
                }
                // Create a font
                XFont fontHeader = new XFont("Verdana", 14, XFontStyle.Bold);
                XFont fontText = new XFont("Verdana", 10, XFontStyle.Regular);
                XFont fontTextBold = new XFont("Verdana", 10, XFontStyle.Bold);

                gfx.DrawString("Patient File No", fontText, XBrushes.Black, new XRect(wLeft, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(txtPatientFileNo.Text, fontTextBold, XBrushes.Black, new XRect(240, yTop, page.Width, page.Height), XStringFormat.TopLeft);

                yTop += 20;

                gfx.DrawString("Patient Full Name", fontText, XBrushes.Black, new XRect(wLeft, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(txtFirstName.Text + " " + txtSurname.Text, fontTextBold, XBrushes.Black, new XRect(240, yTop, page.Width, page.Height), XStringFormat.TopLeft);

                yTop += 20;

                gfx.DrawString("Guarantor", fontText, XBrushes.Black, new XRect(wLeft, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(cboGuarantors.Text, fontTextBold, XBrushes.Black, new XRect(240, yTop, page.Width, page.Height), XStringFormat.TopLeft);

                yTop += 20;

                gfx.DrawString("Guarantor Reference No", fontText, XBrushes.Black, new XRect(wLeft, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(txtGuarantorRefNum.Text, fontTextBold, XBrushes.Black, new XRect(240, yTop, page.Width, page.Height), XStringFormat.TopLeft);

                yTop += 20;

                gfx.DrawString("Patient File Creation Date", fontText, XBrushes.Black, new XRect(wLeft, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(txtPatientFileCreationDTTM.Text + " CAT", fontTextBold, XBrushes.Black, new XRect(240, yTop, page.Width, page.Height), XStringFormat.TopLeft);

                yTop += 20;

                gfx.DrawString("AIMS Operations Case Manager", fontText, XBrushes.Black, new XRect(wLeft, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(CaseManager, fontTextBold, XBrushes.Black, new XRect(240, yTop, page.Width, page.Height), XStringFormat.TopLeft);

                yTop += 20;

                //gfx.DrawString("Hospital Supplier", fontText, XBrushes.Black, new XRect(wLeft, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                //gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                //gfx.DrawString(cboHospitals.Text, fontTextBold, XBrushes.Black, new XRect(240, yTop, page.Width, page.Height), XStringFormat.TopLeft);
                //yTop += 20;
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Creating Patient Case History Cover Page Failed, Please contact System Administrator");
                commonFuncs.ErrorLogger("Creating Patient Case History Cover Page Failed: " + ex.ToString());
            }
        }

        private void createPatientCaseHistoryPage(ref XGraphics gfx, ref PdfPage page, ref int yTop, ref int wLeft, string PatientFileNo, string CaseManager, string CaseNoteText, string NoteDTTM)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Creating Patient Case History Failed, Please contact system administrator");
                commonFuncs.ErrorLogger("Creating Patient Case History Failed: " + ex.ToString());
            }
        }

        private void cboEvacuationType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdRMR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRMR.Checked)
            {
                cboRepatType.SelectedValue = -1;
                cboTransportType.SelectedValue = -1;
                cboAssistType.SelectedValue = -1;
                cboEvacuationType.SelectedValue = -1;
            }
        }

        private void txtFileLoadDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstlvwNotes_ColumnClick(object sender, EventArgs e)
        {

        }

        private void btnEditPatientNote_Click(object sender, EventArgs e)
        {
            if (lstlvwNotes.SelectedItems.Count == 0)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient File Comment not selected.");
            }
            else
            {
                string NoteID = lstlvwNotes.Items[lstlvwNotes.SelectedItems[0].Index].SubItems[4].Text.ToString();
                string NotesText = lstlvwNotes.Items[lstlvwNotes.SelectedItems[0].Index].SubItems[1].Text.ToString();
                if (NotesText == "New File for Patient")
                {
                    MessageBox.Show("This comment cannot be changed.","Comment Change",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Int32 selectItem = lstlvwNotes.SelectedItems[0].Index;
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.NoteID = System.Convert.ToInt64(NoteID);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteTypeCode = "PATIENTCOMMENT";
                //frmNotes.Show();
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTCOMMENT");
                    LoadNotes("'PATIENTCOMMENT'");
                }
                if (!lstlvwNotes.Items.Count.Equals(0) )
                {
                    lstlvwNotes.Items[selectItem].Selected = true;
                }
                
                Application.DoEvents();
            }
        }

        private void chkCancelled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEditMedPatientNote_Click(object sender, EventArgs e)
        {
            if (lstlvwMedNotes.SelectedItems.Count == 0)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient Medical Comment not selected.");
            }
            else
            {
                string NoteID = lstlvwMedNotes.Items[lstlvwMedNotes.SelectedItems[0].Index].SubItems[4].Text.ToString();

                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.NoteID = System.Convert.ToInt64(NoteID);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteTypeCode = "PATIENTCOMMENT";
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTMEDICALHISTORY");
                    LoadNotes("'PATIENTMEDICALHISTORY'");
                }
            }
        }

        private void btnEmailCaseSummary_Click(object sender, EventArgs e)
        {

        }

        private void btnViewMedicalReport_Click(object sender, EventArgs e)
        {

        }

        private void txtPatientFileNo_TextChanged(object sender, EventArgs e)
        {

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
                DateTime dobDate = System.Convert.ToDateTime(frmCal.StartDate);
                txtDateOfBirth.Text = dobDate.ToString("dd/MM/yyyy");
            }
            txtDateOfBirth.ReadOnly = true; 
            txtDateOfBirth.Focus();
        }

        private void lstvwAuditing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PatientEmailsSetup()
        {
            try
            {
                lstPatientFileEmails.Columns.Clear();
                lstPatientFileEmails.Items.Clear();
                lstPatientFileEmails.Columns.Add("Email Subject", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstPatientFileEmails.Columns.Add("Email Received Date Time", 100, HorizontalAlignment.Left);
                lstPatientFileEmails.Columns.Add("Email From", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstPatientFileEmails.Columns.Add("Email Indexed", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstPatientFileEmails.Columns.Add("Email CC", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstPatientFileEmails.Columns.Add("PatientEnquiryID", 100, HorizontalAlignment.Left);
                lstPatientFileEmails.Columns.Add("Email Indexed By", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstPatientFileEmails.Columns.Add("Email To", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                foreach (ColumnHeader colHead in lstPatientFileEmails.Columns)
                {
                    if (colHead.Text == "PatientEnquiryID")
                    {
                        colHead.Width = 0;
                    }
                    if (colHead.Text == "Email Indexed By")
                    {
                        colHead.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
                
                lstEmailAttachments.Columns.Clear();
                lstEmailAttachments.Items.Clear();
                lstEmailAttachments.Columns.Add("Email Attachment", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstEmailAttachments.Columns.Add("EmailAttachmentLocation", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                lstEmailAttachments.Columns.Add("EmailAttachmentID", Convert.ToInt32(lstvwServiceProviders.Width * 0.2), HorizontalAlignment.Left);
                
                foreach (ColumnHeader colHead in lstEmailAttachments.Columns)
                {
                    if (colHead.Text == "EmailAttachmentID" || colHead.Text == "EmailAttachmentLocation")
                    {
                        colHead.Width = 0;
                    }
                }

                btnReply.Enabled = false;
                btnForward.Enabled = false;

                lstOperatorMailBox.Columns.Clear();
                lstOperatorMailBox.Items.Clear();
                lstOperatorMailBox.Columns.Add("Patient File No", Convert.ToInt32(lstOperatorMailBox.Width * 0.2), HorizontalAlignment.Left);
                lstOperatorMailBox.Columns.Add("Mail Subject", Convert.ToInt32(lstOperatorMailBox.Width * 0.5), HorizontalAlignment.Left);
                lstOperatorMailBox.Columns.Add("Mail From", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
                lstOperatorMailBox.Columns.Add("Mail Received", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
                lstOperatorMailBox.Columns.Add("PATIENTENQUIRYID", 0, HorizontalAlignment.Left);
                foreach (ColumnHeader colHead1 in lstOperatorMailBox.Columns)
                {
                    if (colHead1.Text == "PATIENTENQUIRYID")
                    {
                        colHead1.Width = 0;
                    }
                    else
                    {
                        //colHead1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
            }
            catch (System.Exception ex)
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Loading Service Providers: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnNewEmail_Click(object sender, EventArgs e)
        {
            //if (txtDateOfBirth.Text.Trim() == "")
            //{
            //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture Date-Of-Birth before attaching documents to email.");
            //    return;
            //}

            DateTime dtOfBirth;
            string dateofbirth = "";
            if (DateTime.TryParse(txtDateOfBirth.Text, out dtOfBirth))
            {
                dateofbirth = dtOfBirth.ToString("dd/MM/yyyy");
            }
            else
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient Date-Of-Birth is Invalid. Correct Format: DD/MM/YYYY");
                //return;
            }

            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                frmNewEmail frmNewMail = new frmNewEmail();

                frmNewMail.EmailSubject = PatientEmailSubject;
                frmNewMail.EmailFrom = PatientEmailFrom;
                frmNewMail.PatientFileNo = txtPatientFileNo.Text;
                frmNewMail.PatientDOB = dateofbirth;
                frmNewMail.LoggedOnUser = UserID;
                frmNewMail.BccEmailAddress = BccEmailAddress;
                
                frmNewMail.PatientFileEnquiryID = PatientEmailEnquiryID;
                frmNewMail.Show();
                
                LoadPatientSentEmails();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading New Email Form error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading New Email Form error: \n" + ex.ToString());
            }
            finally
            {
                //commonFuncs = null;
            }
        }

        private string Email_Header_Info(string sEmail_Addr_From_Name, string sEmail_Addr_From_Address, string sEmail_Date, string sEmail_Addr_To, string EmailToCC, string sEmail_Subject)
        {
            string sEmailDetail = "";
            sEmailDetail = "<hr size=2/><STYLE type=text/css> SPAN.text {FONT-SIZE: 9pt; FONT_COLOR: Black; FONT-FAMILY: Arial; text-align: justify} </STYLE>";
            sEmailDetail += "<span class=text> ";
            sEmailDetail += "<br><b>From Name: </b>" + sEmail_Addr_From_Name + " [" + sEmail_Addr_From_Address + "]";
            sEmailDetail += "<br><b>Sent: </b>" + sEmail_Date;
            sEmailDetail += "<br><b>To: </b>" + sEmail_Addr_To;
            if (!EmailToCC.Equals(""))
            {
                sEmailDetail += "<br><b>CC: </b>" + EmailToCC;
            }
            sEmailDetail += "<br><b>Subject: </b>" + sEmail_Subject;
            sEmailDetail += "<br><br><br></span>";
            return sEmailDetail;
        }
        private void btnReply_Click(object sender, EventArgs e)
        {
            //if (txtDateOfBirth.Text.Trim() == "")
            //{
            //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture Date-Of-Birth before attaching documents to email.");
            //    return;
            //}

            DateTime dtOfBirth;
            string dateofbirth = "";
            if (DateTime.TryParse(txtDateOfBirth.Text, out dtOfBirth))
            {
                dateofbirth = dtOfBirth.ToString("dd/MM/yyyy");
            }
            else
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient Date-Of-Birth is Invalid. Correct Format: DD/MM/YYYY");
                //return;
            }

            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (!SentOrReceivedEmails.Trim().Equals(""))
                {
                    frmEmailReply frmMailReply = new frmEmailReply();
                    string EmailDocTypeFile = "";
                    string sEmailHeader = "";
                    string EmailAttachment = "";
                    switch (SentOrReceivedEmails)
                    {
                        case "RECEIVED_MAILS":
                            PatientEmailTo = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[7].Text.ToString();
                            foreach (ListViewItem lstVwItm in lstEmailAttachments.Items)
                            {
                                EmailAttachment = lstVwItm.SubItems[1].Text;
                                if (lstVwItm.SubItems[0].Text == "Email Correspondence" && EmailAttachment.ToUpper().Contains(".HTM"))
                                {
                                    EmailDocTypeFile = lstVwItm.SubItems[1].Text;
                                    break;
                                }
                            }
                            break;
                        case "SENT_MAILS":
                            foreach (ListViewItem lstVwItm in lstSentEmailAttachments.Items)
                            {
                                EmailAttachment = lstVwItm.SubItems[1].Text;
                                if (lstVwItm.SubItems[0].Text.Contains("Email Correspondence Sent") && EmailAttachment.ToUpper().Contains(".HTM"))
                                {
                                    EmailDocTypeFile = lstVwItm.SubItems[1].Text;
                                    break;
                                }
                            }
                            sEmailHeader = Email_Header_Info(PatientEmailFrom, PatientEmailFrom, "", PatientEmailTo, PatientEmailFromCC, PatientEmailSubject);
                            break;
                    }
                    
                    frmMailReply.EmailHeader = sEmailHeader;
                    frmMailReply.EmailSubject = PatientEmailSubject;
                    //frmMailReply.EmailFrom = PatientEmailFrom;
                    frmMailReply.PatientDOB = dateofbirth;
                    frmMailReply.EmailFrom = PatientEmailFrom + ";" + PatientEmailTo;
                    frmMailReply.EmailFromCC = PatientEmailFromCC;
                    frmMailReply.PatientFileNo = txtPatientFileNo.Text;

                    frmMailReply.OriginalEmailCorrespondence = EmailDocTypeFile;
                    frmMailReply.LoggedOnUser = UserID;
                    frmMailReply.BccEmailAddress = BccEmailAddress;

                    frmMailReply.Show();
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please select to reply to"); 
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Reply-To Email Form error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading Reply-To Email Form error: \n" + ex.ToString());
            }
            finally
            {
                //commonFuncs = null;
            }
        }

        private void btnReplayAll_Click(object sender, EventArgs e)
        {
            //if (txtDateOfBirth.Text.Trim() == "")
            //{
            //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture Date-Of-Birth before attaching documents to email.");
            //    return;
            //}

            DateTime dtOfBirth;
            string dateofbirth = "";
            if (DateTime.TryParse(txtDateOfBirth.Text, out dtOfBirth))
            {
                dateofbirth = dtOfBirth.ToString("dd/MM/yyyy");
            }
            else
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient Date-Of-Birth is Invalid. Correct Format: DD/MM/YYYY");
                //return;
            }

            //commonFuncs = new AIMS.Common.CommonFunctions();
            string sEmailHeader = "";
            try
            {
                if (!SentOrReceivedEmails.Trim().Equals(""))
                {
                    frmEmailReply frmMailReply = new frmEmailReply();
                    string EmailDocTypeFile = "";

                    switch (SentOrReceivedEmails)
                    {
                        case "RECEIVED_MAILS":
                            PatientEmailTo = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[7].Text.ToString();
                            foreach (ListViewItem lstVwItm in lstEmailAttachments.Items)
                            {
                                if (lstVwItm.SubItems[0].Text == "Email Correspondence")
                                {
                                    EmailDocTypeFile = lstVwItm.SubItems[1].Text;
                                }
                                break;
                            }
                            break;
                        case "SENT_MAILS":
                            foreach (ListViewItem lstVwItm in lstSentEmailAttachments.Items)
                            {
                                if (lstVwItm.SubItems[0].Text.Contains("Email Correspondence Sent"))
                                {
                                    EmailDocTypeFile = lstVwItm.SubItems[1].Text;
                                    break;
                                }
                            }
                            sEmailHeader = Email_Header_Info(PatientEmailFrom, PatientEmailFrom, "", PatientEmailTo, PatientEmailFromCC, PatientEmailSubject);
                            break;
                        default:
                            break;
                    }
                    frmMailReply.EmailHeader = sEmailHeader;
                    frmMailReply.EmailSubject = PatientEmailSubject;
                    frmMailReply.EmailFrom = PatientEmailFrom + ";" + PatientEmailTo;

                    frmMailReply.EmailFromCC = PatientEmailFromCC;
                    frmMailReply.PatientDOB = dateofbirth;
                    frmMailReply.PatientFileNo = txtPatientFileNo.Text;

                    //frmMailReply.EmailID = 
                    frmMailReply.OriginalEmailCorrespondence = EmailDocTypeFile;
                    frmMailReply.LoggedOnUser = UserID;
                    frmMailReply.BccEmailAddress = BccEmailAddress;
                    frmMailReply.Show();
                    //LoadPatientSentEmails();
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Reply-To Email Form error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading Reply-To Email Form error: \n" + ex.ToString());
            }
            finally
            {
                //commonFuncs = null;
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            //if (txtDateOfBirth.Text.Trim() == "")
            //{
            //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture Date-Of-Birth before attaching documents to email.");
            //    return;
            //}

            DateTime dtOfBirth;
            string dateofbirth = "";
            if (DateTime.TryParse(txtDateOfBirth.Text, out dtOfBirth))
            {
                dateofbirth = dtOfBirth.ToString("dd/MM/yyyy");
            }
            else
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient Date-Of-Birth is Invalid. Correct Format: DD/MM/YYYY");
                //return;
            }

            //commonFuncs = new AIMS.Common.CommonFunctions();
            frmEmailForward frmMailForward = new frmEmailForward();
            string sEmailHeader = "";
            try
            {
                if (!SentOrReceivedEmails.Trim().Equals (""))
                {
                    string EmailDocTypeFile = "";

                    switch (SentOrReceivedEmails)
                    {
                        case "RECEIVED_MAILS":
                            PatientEmailTo = "";
                            foreach (ListViewItem lstVwItm in lstEmailAttachments.Items)
                            {
                                if (lstVwItm.SubItems[0].Text == "Email Correspondence")
                                {
                                    EmailDocTypeFile = lstVwItm.SubItems[1].Text;
                                }
                                break;
                            }
                            break;
                        case "SENT_MAILS":
                            foreach (ListViewItem lstVwItm in lstSentEmailAttachments.Items)
                            {
                                if (lstVwItm.SubItems[0].Text.Contains("Email Correspondence Sent"))
                                {
                                    EmailDocTypeFile = lstVwItm.SubItems[1].Text;
                                }
                                break;
                            }
                            sEmailHeader = Email_Header_Info(PatientEmailFrom, PatientEmailFrom, "", PatientEmailTo, PatientEmailFromCC, PatientEmailSubject);
                            break;
                        default:
                            break;
                    }
                    frmMailForward.EmailHeader = sEmailHeader;
                    frmMailForward.SentOrReceivedEmails = SentOrReceivedEmails;
                    frmMailForward.EmailSubject = PatientEmailSubject;
                    frmMailForward.EmailFrom = PatientEmailFrom;
                    frmMailForward.PatientFileNo = txtPatientFileNo.Text;
                    frmMailForward.PatientDOB = dateofbirth; 
                    //frmMailForward.EmailID =
                    frmMailForward.OriginalEmailCorrespondence = EmailDocTypeFile;
                    frmMailForward.LoggedOnUser = UserID;
                    frmMailForward.PatientFileEnquiryID = PatientEmailEnquiryID;
                    frmMailForward.PatientFileSentEmailID = PatientSentEmailID;
                    frmMailForward.PatienSentEmailID = PatientSentEmailID;
                    frmMailForward.BccEmailAddress = BccEmailAddress;

                    DialogResult dg = frmMailForward.ShowDialog();
                    if (dg == DialogResult.Cancel )
                    {
                        frmMailForward.Close();
                    }
                    //LoadPatientSentEmails();   
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Reply-To Email Form error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading Reply-To Email Form error: \n" + ex.ToString());
            }
            finally
            {
                //frmMailForward.Dispose();
                //commonFuncs = null;
            }
        }

        private void lstPatientFileEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            DataTable dtPatientEmailAttachments = new DataTable();
            ListViewItem lvwItm;
            try
            {
                PatientEmailTo = "";
                if (!PatientEmailEnquiryID.Equals(lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[5].Text.ToString()))
                {
                    SentOrReceivedEmails = "RECEIVED_MAILS";
                    PatientEmailTo = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[7].Text.ToString(); ;
                    PatientEmailEnquiryID = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[5].Text.ToString();
                    PatientEmailSubject = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[0].Text.ToString();
                    PatientEmailFrom = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[2].Text.ToString();
                    PatientEmailFromCC = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[4].Text.ToString();
                    PatientEmailListIdx = lstPatientFileEmails.SelectedItems[0].Index;
                    
                    if (!PatientEmailEnquiryID.Equals(""))
                    {
                        LoadEmailAttachments();
                        if (EmailReadYN == "" || EmailReadYN == "N")
                        {
                            bool EmailRead = commonFuncs.AIMS_Email_Read(PatientEmailEnquiryID);
                            if (!EmailRead)
                            {
                                commonFuncs.ErrorLogger("Email could not be marked as being read");
                            }                            
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                dtPatientEmailAttachments.Dispose();
                //commonFuncs = null;
            }
        }

        private void LoadPatientFileEmails(string EmailKeyword)
        {
            dsPatientEmails = new DataSet(); ;
            ListViewItem lvwItem;
            AIMS.BLL.Patient patientBLL = new Patient();
            //commonFuncs = new AIMS.Common.CommonFunctions();
            Application.DoEvents();
            try
            {
                lstPatientFileEmails.Items.Clear();
                lstEmailAttachments.Items.Clear();
                if (!txtPatientFileNo.Text.Trim().Equals(""))
                {
                    dsPatientEmails = patientBLL.GetPatientEmails(txtPatientFileNo.Text, EmailKeyword);
                }
                else
                {
                    return;
                }
                
                string EmailReadYN = "";
                grpBxReceivedEmails.Text = "Patient File Received Emails [" + dsPatientEmails.Tables[0].Rows.Count + "]";
                if (dsPatientEmails.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsPatientEmails.Tables[0].Rows.Count; i++)
                    {
                        EmailReadYN = dsPatientEmails.Tables[0].Rows[i]["MAIL_READ_YN"].ToString();
                        if (EmailReadYN.Equals("N") || EmailReadYN.Equals(""))
                        {
                            lvwItem = new ListViewItem(dsPatientEmails.Tables[0].Rows[i]["EMAIL_SUBJECT"].ToString(), 0);
                        }
                        else
                        {
                            lvwItem = new ListViewItem(dsPatientEmails.Tables[0].Rows[i]["EMAIL_SUBJECT"].ToString(), 1);
                        }   
                        
                        lvwItem.SubItems.Add(dsPatientEmails.Tables[0].Rows[i]["EMAIL_RECEIVED_DTTM"].ToString());
                        lvwItem.SubItems.Add(dsPatientEmails.Tables[0].Rows[i]["EMAIL_SENT_FROM_ADDRESS"].ToString());
                        //lvwItem.SubItems.Add(dsPatientEmails.Tables[0].Rows[i]["EMAIL_SENT_FROM_NAME"].ToString() + " [ " + dsPatientEmails.Tables[0].Rows[i]["EMAIL_SENT_FROM_ADDRESS"].ToString() + " ]");
                        lvwItem.SubItems.Add(dsPatientEmails.Tables[0].Rows[i]["CREATION_DTTM"].ToString());
                        lvwItem.SubItems.Add(dsPatientEmails.Tables[0].Rows[i]["EMAIL_SENT_TO_CC"].ToString());
                        lvwItem.SubItems.Add(dsPatientEmails.Tables[0].Rows[i]["PATIENT_ENQUIRY_ID"].ToString());
                        lvwItem.SubItems.Add(dsPatientEmails.Tables[0].Rows[i]["USER_FULL_NAME"].ToString());
                        lvwItem.SubItems.Add(dsPatientEmails.Tables[0].Rows[i]["EMAIL_SENT_TO"].ToString());
                        if ((dsPatientEmails.Tables[0].Rows[i]["PRIORITY_ID"].ToString() == "1" || dsPatientEmails.Tables[0].Rows[i]["EMAIL_SUBJECT"].ToString().ToUpper().Contains("URGENT")) && EmailReadYN.Equals("N"))
                        {
                            lvwItem.ForeColor = Color.White;
                            lstPatientFileEmails.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else
                        {
                            lstPatientFileEmails.Items.Add(lvwItem);
                        }
                        Application.DoEvents();
                    }
                    btnReply.Enabled = true;
                    btnForward.Enabled = true;
                    Application.DoEvents();

                    foreach (ColumnHeader ch in lstPatientFileEmails.Columns)
                    {
                        if (ch.Text.Equals("PatientEnquiryID"))
                        {
                            ch.Width = 0;
                        }
                        else
                        {
                            if (ch.Text == "Email Indexed By")
                            {
                                ch.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                            }
                            else
                            {
                                ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);   
                            }
                        }
                    }
                }
                else
                {
                    lstPatientFileEmails.Items.Clear();
                    lstEmailAttachments.Items.Clear();
                    //btnReply.Enabled = false;
                    //btnForward.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading Patient Emails, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error loading Patient Emails \n" + ex.ToString());
            }
            finally
            {
                patientBLL = null;
                lvwItem = null;
                dsPatientEmails.Dispose();
                //commonFuncs = null;
            }
        }

        private void lstEmailAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PatientEmailAttachmentID = "";
                PatientEmailAttachmentID = lstEmailAttachments.SelectedItems[0].SubItems[2].Text;
                PatientEmailAttachmentDesc = lstEmailAttachments.SelectedItems[0].SubItems[0].Text;
            }
            catch (Exception)
            {
            }
        }

        private void lstEmailAttachments_DoubleClick(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            frmImageViewer frmImgViewer = new frmImageViewer();
            try
            {
                string EmailDocTypeFile = lstEmailAttachments.SelectedItems[0].SubItems[1].Text;
                string EmailDocType = lstEmailAttachments.SelectedItems[0].SubItems[0].Text;

                frmImgViewer.EmailDocument = EmailDocTypeFile;
                frmImgViewer.Text = EmailDocType;

                frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                
                frmImgViewer.ShowDialog(this);
                //frmImgViewer.Show();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error displaying Patient Email Document, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error displaying Patient Email Document \n" + ex.ToString());
            }
            finally 
            {
                frmImgViewer.Dispose();
                //commonFuncs = null;
            }
        }

        private void txtWayBillNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmrEmailsPoll_Tick(object sender, EventArgs e)
        {
            //LoadMyMailbox();
        }

        private void LoadPatientSentEmails() 
        {
            dsPatientSentEmails = new DataSet(); ;
            ListViewItem lvwItem;
            AIMS.BLL.Patient patientBLL = new Patient();
            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                lstPatientSentEmails.Items.Clear();
                lstSentEmailAttachments.Items.Clear();
                dsPatientSentEmails = commonFuncs.GetPatientSentEmails(txtPatientFileNo.Text);
                grpBxSentEmails.Text = "Patient File Sent Emails [" + dsPatientSentEmails.Tables[0].Rows.Count + "]";
                if (dsPatientSentEmails.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsPatientSentEmails.Tables[0].Rows.Count; i++)
                    {
                        lvwItem = new ListViewItem(dsPatientSentEmails.Tables[0].Rows[i]["SENT_TO"].ToString());
                        lvwItem.SubItems.Add(dsPatientSentEmails.Tables[0].Rows[i]["SENT_TO_CC"].ToString());
                        lvwItem.SubItems.Add(dsPatientSentEmails.Tables[0].Rows[i]["EMAIL_FROM_NAME"].ToString());
                        lvwItem.SubItems.Add(dsPatientSentEmails.Tables[0].Rows[i]["EMAIL_SUBJECT"].ToString());
                        lvwItem.SubItems.Add(dsPatientSentEmails.Tables[0].Rows[i]["SENT_DTTM"].ToString());
                        lvwItem.SubItems.Add(dsPatientSentEmails.Tables[0].Rows[i]["USER_FULL_NAME"].ToString());
                        lvwItem.SubItems.Add(dsPatientSentEmails.Tables[0].Rows[i]["SENT_EMAIL_ID"].ToString());
                        lstPatientSentEmails.Items.Add(lvwItem);
                    }

                    foreach (ColumnHeader ch in lstPatientSentEmails.Columns)
                    {
                        if (ch.Text.Equals("SENT_EMAIL_ID"))
                        {
                            ch.Width = 0;
                        }
                        else
                        {
                            ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }

                }
                else
                {
                    lstPatientSentEmails.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading Patient Emails, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error loading Patient Emails \n" + ex.ToString());
            }
            finally
            {
                patientBLL = null;
                lvwItem = null;
                dsPatientEmails.Dispose();
                //commonFuncs = null;
            }
        }

        private void PatientSentEmailsListSetup()
        {
            lstPatientSentEmails.Columns.Clear();
            lstPatientSentEmails.Items.Clear();
            lstPatientSentEmails.Columns.Add("Sent To", Convert.ToInt32(lstPatientSentEmails.Width * 0.4), HorizontalAlignment.Left);
            lstPatientSentEmails.Columns.Add("Sent To CC", Convert.ToInt32(lstPatientSentEmails.Width * 0.4), HorizontalAlignment.Left);
            lstPatientSentEmails.Columns.Add("Email From", Convert.ToInt32(lstPatientSentEmails.Width * 0.4), HorizontalAlignment.Left);
            lstPatientSentEmails.Columns.Add("Subject", Convert.ToInt32(lstPatientSentEmails.Width * 0.4), HorizontalAlignment.Left);
            lstPatientSentEmails.Columns.Add("Sent Date", Convert.ToInt32(lstPatientSentEmails.Width * 0.4), HorizontalAlignment.Left);
            lstPatientSentEmails.Columns.Add("Sent By",  Convert.ToInt32(lstPatientSentEmails.Width * 0.4), HorizontalAlignment.Left);
            lstPatientSentEmails.Columns.Add("SENT_EMAIL_ID", Convert.ToInt32(lstPatientSentEmails.Width * 0.4), HorizontalAlignment.Left);
        }

        /// <summary>
        ///     This method retrieves all emails sent operators to files tagged to operator
        /// </summary>
        private void LoadMyMailbox()
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItem;
            DataTable dtMyMails = new DataTable();
            DataTable dtInstantMessages = new DataTable();
            string sNotifyStr = "";
            string LastFileNo = "";

            lstOperatorMailBox.View = View.Details;
            lstOperatorMailBox.Items.Clear();
            try
            {
                dtMyMails = commonFuncs.Get_AIMS_Operator_Work(UserID);
                gpbxOperatorMails.Text = "My Work Basket [" + dtMyMails.Rows.Count.ToString() + "]";
                if (dtMyMails.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMyMails.Rows.Count; i++)
                    {
                        Application.DoEvents();
                        lvwItem = new ListViewItem(dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString());

                        if (LastFileNo != dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString())
                        {
                            sNotifyStr += dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString() + "\n";
                            LastFileNo = dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString();       
                        }

                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SUBJECT"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SENT_FROM_NAME"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_RECEIVED_DTTM"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["PATIENT_ENQUIRY_ID"].ToString());

                        if (dtMyMails.Rows[i]["PRIORITY_ID"].ToString() == "1")
                        {
                            lvwItem.ForeColor = Color.White;
                            lstOperatorMailBox.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else
                        {
                            lstOperatorMailBox.Items.Add(lvwItem);
                        }
                        Application.DoEvents();
                    }
                }
                else
                {

                }

                dtInstantMessages = commonFuncs.Get_My_Instant_Messages(UserID);
                string sInstantMessage = "";
                if (dtInstantMessages.Rows.Count > 0 )
                {
                    foreach (DataRow  drRow in dtInstantMessages.Rows)
                    {
                        sInstantMessage += drRow["INSTANT_MESSAGE_FROM"].ToString() + " [" + drRow["PATIENT_FILE_NO"].ToString() + "]  " + drRow["INSTANT_MESSAGE_TEXT"].ToString() + "\n";

                        lvwItem = new ListViewItem(drRow["PATIENT_FILE_NO"].ToString());

                        lvwItem.SubItems.Add("IM - " + drRow["INSTANT_MESSAGE_TEXT"].ToString());
                        lvwItem.SubItems.Add(drRow["USER_FULL_NAME"].ToString());
                        lvwItem.SubItems.Add(drRow["INSTANT_MESSAGE_DTTM"].ToString());
                        lvwItem.SubItems.Add("");
                        lstOperatorMailBox.Items.Add(lvwItem);
                    }
                }

                if (!sInstantMessage.Equals(""))
                {
                    notifyIcon1.Visible = true;
                    notifyIcon1.Text = "My AIMS Instant Messages";
                    notifyIcon1.BalloonTipText = sInstantMessage;
                    notifyIcon1.BalloonTipTitle = "Instant Messages";
                    notifyIcon1.ShowBalloonTip(180000);
                }
                else
                {
                    notifyIcon1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Loading your Work Basket, Please contact System Administror");
                commonFuncs.ErrorLogger("Error Loading your Work Basket: \n" + ex.ToString());
            }
            finally
            {
                dtMyMails.Dispose();
                dtMyMails = null;
                lvwItem = null;
            }
        }

        private void LoadMyMailbox(string CoOrdinator, string CoOrdinatorFullName)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItem;
            DataTable dtMyMails = new DataTable();
            DataTable dtInstantMessages = new DataTable();
            string sNotifyStr = "";
            string LastFileNo = "";

            lstOperatorMailBox.View = View.Details;
            lstOperatorMailBox.Items.Clear();
            try
            {
                dtMyMails = commonFuncs.Get_AIMS_Operator_Work(CoOrdinator);
             
                gpbxOperatorMails.Text = CoOrdinatorFullName + " [" + dtMyMails.Rows.Count.ToString() + "]";
                if (dtMyMails.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMyMails.Rows.Count; i++)
                    {
                        Application.DoEvents();
                        lvwItem = new ListViewItem(dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString());

                        if (LastFileNo != dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString())
                        {
                            sNotifyStr += dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString() + "\n";
                            LastFileNo = dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString();
                        }

                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SUBJECT"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SENT_FROM_NAME"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_RECEIVED_DTTM"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["PATIENT_ENQUIRY_ID"].ToString());

                        if (dtMyMails.Rows[i]["PRIORITY_ID"].ToString() == "1")
                        {
                            lvwItem.ForeColor = Color.White;
                            lstOperatorMailBox.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else
                        {
                            lstOperatorMailBox.Items.Add(lvwItem);
                        }
                        
                        Application.DoEvents();
                    }
                }
                else
                {

                }

                dtInstantMessages = commonFuncs.Get_My_Instant_Messages(CoOrdinator);
                string sInstantMessage = "";
                if (dtInstantMessages.Rows.Count > 0)
                {
                    foreach (DataRow drRow in dtInstantMessages.Rows)
                    {
                        sInstantMessage += drRow["INSTANT_MESSAGE_FROM"].ToString() + " [" + drRow["PATIENT_FILE_NO"].ToString() + "]  " + drRow["INSTANT_MESSAGE_TEXT"].ToString() + "\n";

                        lvwItem = new ListViewItem(drRow["PATIENT_FILE_NO"].ToString());

                        lvwItem.SubItems.Add("IM - " + drRow["INSTANT_MESSAGE_TEXT"].ToString());
                        lvwItem.SubItems.Add(drRow["USER_FULL_NAME"].ToString());
                        lvwItem.SubItems.Add(drRow["INSTANT_MESSAGE_DTTM"].ToString());
                        lvwItem.SubItems.Add("");
                        lstOperatorMailBox.Items.Add(lvwItem);
                    }
                }

                if (!sInstantMessage.Equals(""))
                {
                    notifyIcon1.Visible = true;
                    notifyIcon1.Text = "My AIMS Instant Messages";
                    notifyIcon1.BalloonTipText = sInstantMessage;
                    notifyIcon1.BalloonTipTitle = "Instant Messages";
                    notifyIcon1.ShowBalloonTip(180000);
                }
                else
                {
                    notifyIcon1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Loading your Work Basket, Please contact System Administror");
                commonFuncs.ErrorLogger("Error Loading your Work Basket: \n" + ex.ToString());
            }
            finally
            {
                lvwItem = null;
            }
        }

        private void lstOperatorMailBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WorkBasketEmailEnquiryID = lstOperatorMailBox.Items[lstOperatorMailBox.SelectedItems[0].Index].SubItems[4].Text.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void lstOperatorMailBox_DoubleClick(object sender, EventArgs e)
        {
            //aimsComboLookup1.DataField1 == "PATIENT_FILE_NO";
            //aimsComboLookup1.lstItems.Text
            //btnSelect_Click(null, null);
        }

        private void btnWorkClose_Click(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions(); 
            try
            {
                if (lstOperatorMailBox.CheckedItems.Count >0)
                {
                    if (MessageBox.Show("Work Item(s) Processed?","Work Item Processed",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ListView.CheckedListViewItemCollection vc = lstOperatorMailBox.CheckedItems;
                        bool EmailProcessed = false;
                        int checkItem = 0;

                        string[] strValues = new string[lstOperatorMailBox.CheckedItems.Count];

                        for (int i = 0; i < vc.Count; i++)
                        {
                            WorkBasketEmailEnquiryID = lstOperatorMailBox.Items[vc[i].Index].SubItems[4].Text;
                            EmailProcessed = commonFuncs.AIMS_Email_Processed(WorkBasketEmailEnquiryID, UserID);
                            if (!EmailProcessed)
                            {
                                commonFuncs.ErrorLogger("Work Basket item could not be processed, Please contact System Administrator.");
                            }
                        }

                        LoadMyMailbox();
                    }
                }
                else
                {
                    MessageBox.Show("Please select Work Item Processed", "Work Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                }
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
        }

        private void lstPatientSentEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItm;
            try
            {
                if (!PatientSentEmailID.Equals(lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[6].Text.ToString()))
                {
                    PatientSentEmailID = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[6].Text.ToString();
                    PatientEmailTo = "";
                    if (!PatientSentEmailID.Equals(""))
                    {
                        SentOrReceivedEmails = "SENT_MAILS";
                        DataTable dtPatientEmailAttachments = commonFuncs.Get_AIMS_Patient_Sent_Email_Docs(PatientSentEmailID);
                        lstSentEmailAttachments.Items.Clear();

                        PatientEmailSubject = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[3].Text.ToString();
                        PatientEmailFrom = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[2].Text.ToString();
                        PatientEmailFromCC = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[1].Text.ToString();
                        PatientEmailTo = lstPatientSentEmails.Items[lstPatientSentEmails.SelectedItems[0].Index].SubItems[0].Text.ToString();
                        if (dtPatientEmailAttachments.Rows.Count > 0)
                        {
                            string EmailAttachmentLoc = "";
                            string EmailAttachType = "";
                            lstSentEmailAttachments.Columns.Clear();

                            lstSentEmailAttachments.Columns.Add("Attachment", Convert.ToInt32(lstSentEmailAttachments.Width * 2), HorizontalAlignment.Left);
                            lstSentEmailAttachments.Columns.Add("Attachment_File_Location", Convert.ToInt32(lstSentEmailAttachments.Width * 0.4), HorizontalAlignment.Left);

                            foreach (DataRow dtRow in dtPatientEmailAttachments.Rows)
                            {
                                EmailAttachType = dtRow["SENT_EMAIL_ATTACHMENT"].ToString();

                                lvwItm = new ListViewItem(Path.GetFileName(EmailAttachType), 2);
                                lvwItm.SubItems.Add(EmailAttachType);

                                lstSentEmailAttachments.Items.Add(lvwItm);
                            }
                            foreach (ColumnHeader ch2 in lstSentEmailAttachments.Columns)
                            {
                                if (ch2.Text.Equals("Attachment_File_Location"))
                                {
                                    ch2.Width = 0;
                                }
                                else
                                {
                                    ch2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                                }
                            }

                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                //PatientSentEmailID = "";
            }
        }


        private void lstPatientFileEmails_DoubleClick(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            
            try
            {
                PatientEmailEnquiryID = "";
                if (!PatientEmailEnquiryID.Equals(lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[5].Text.ToString()))
                {
                    PatientEmailEnquiryID = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[5].Text.ToString();
                    PatientEmailSubject = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[0].Text.ToString();
                    PatientEmailFrom = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[2].Text.ToString();
                    PatientEmailFromCC = lstPatientFileEmails.Items[lstPatientFileEmails.SelectedItems[0].Index].SubItems[4].Text.ToString();
                    PatientEmailListIdx = lstPatientFileEmails.SelectedItems[0].Index;

                    if (!PatientEmailEnquiryID.Equals(""))
                    {
                        LoadEmailAttachments();
                        if (EmailReadYN == "" || EmailReadYN == "N")
                        {
                            if (commonFuncs == null )
                            {
                                commonFuncs = new AIMS.Common.CommonFunctions();
                            }
                            bool EmailRead = commonFuncs.AIMS_Email_Read(PatientEmailEnquiryID);
                            if (!EmailRead)
                            {
                                commonFuncs.ErrorLogger("Email could not be marked as being read");
                            }
                        }
                    }
                }
            }
            finally 
            {
                //commonFuncs = null;
            }
        }

        private void lstSentEmailAttachments_DoubleClick(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            frmSentImageViewer frmImgViewer = new frmSentImageViewer();
            try
            {
                string EmailDocTypeFile = lstSentEmailAttachments.SelectedItems[0].SubItems[1].Text;
                
                frmImgViewer.EmailDocument = EmailDocTypeFile;
                frmImgViewer.EmailTo = lstPatientSentEmails.SelectedItems[0].SubItems[0].Text;
                frmImgViewer.EmailToCC = lstPatientSentEmails.SelectedItems[0].SubItems[1].Text;
                frmImgViewer.EmailFrom = lstPatientSentEmails.SelectedItems[0].SubItems[2].Text;
                frmImgViewer.EmailSubject = lstPatientSentEmails.SelectedItems[0].SubItems[3].Text;
                frmImgViewer.EmailSentDTTM = lstPatientSentEmails.SelectedItems[0].SubItems[4].Text;
                
                frmImgViewer.Text = EmailDocTypeFile;

                frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                frmImgViewer.ShowDialog();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error displaying Patient Email Document, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error displaying Patient Email Document \n" + ex.ToString());
            }
            finally
            {
                frmImgViewer.Dispose();
                //commonFuncs = null;
            }
        }

        private void lstSentEmailAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtLabListDate_DoubleClick_1(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtLabListDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtLabListDate.Focus();
        }

        private void txtLabListDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLabListDate_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLabListDate_DoubleClick_1(null, null);
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private string AfterHoursFile() 
        {
            if ((DateTime.Now.DayOfWeek == DayOfWeek.Sunday | DateTime.Now.DayOfWeek == DayOfWeek.Saturday) || (DateTime.Now.Hour >= 17 && DateTime.Now.ToString("tt") == "PM"))
            {
                return "Y";
            }	 
	        
            return "N";
        }

        private void btnEmailReIndex_Click(object sender, EventArgs e)
        {
            DataTable dtFileDetails = new DataTable();
            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (lstPatientFileEmails.Items.Count > 0 )
                {
                    if (!PatientEmailEnquiryID.Equals(""))
                    {
                        if (MessageBox.Show("Continue re-indexing email to another file. . ?", "Patient File Email Re-Index", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            string NewPatientFileNo = "";

                            PatientFileNoInputBox("Re-Indexing Patient File Email", "New Patient File No", ref NewPatientFileNo);
                            if (NewPatientFileNo.Trim().Length == 0)
                            {
                                NewPatientFileNo = "";
                            }
                            else
                            {
                                dtFileDetails = commonFuncs.PatientValidate(NewPatientFileNo);
                                if (dtFileDetails.Rows.Count == 0)
                                {
                                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Re-Indexing Patient File Invalid.");
                                }
                                else
                                {
                                    bool bFileReIndex = commonFuncs.ReIndexPatientFile(PatientEmailEnquiryID, NewPatientFileNo);
                                    if (bFileReIndex)
                                    {
                                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Patient File successfully Re-Indexing.");
                                        LoadPatientFileEmails("");
                                    }
                                    else
                                    {
                                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File Re-Indexing Error, Please try again.");
                                    }
                                }
                            }
                        }
                    }   
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File Re-Indexing Error, Please try again.");
                commonFuncs.ErrorLogger("Patient File Re-Indexing Error: /n" + ex.ToString());
            }
            finally
            {
                dtFileDetails.Dispose();
                dtFileDetails = null;
                //commonFuncs = null;
            }
        }

        public static DialogResult PatientFileNoInputBox(string title, string promptText1, ref string value1)
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
                buttonOk.Top = textBox1.Bottom + 10;
                buttonCancel.Top = textBox1.Bottom + 10;

                form.ClientSize = new Size(420, 120);
                form.Controls.AddRange(new Control[] { label1, textBox1, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value1 = textBox1.Text;
                if (dialogResult == DialogResult.Cancel)
                {
                    value1 = "";
                }
                return dialogResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEmailDelete_Click(object sender, EventArgs e)
        {
            DataTable dtFileDetails = new DataTable();
            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (lstPatientFileEmails.Items.Count > 0)
                {
                    if (!PatientEmailEnquiryID.Equals(""))
                    {
                        if (MessageBox.Show("Continue removing email from file. . ?", "Patient File Email Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            bool bFileReIndex = commonFuncs.RemovePatientFileEmail(PatientEmailEnquiryID);
                            if (bFileReIndex)
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Patient File successfully Removed.");
                                LoadPatientFileEmails("");
                            }
                            else
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File Removal Error, Please try again.");
                            }  
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File Removal Error, Please try again.");
                commonFuncs.ErrorLogger("Patient File Removal Error: /n" + ex.ToString());
            }
            finally
            {
                dtFileDetails.Dispose();
                dtFileDetails = null;
                //commonFuncs = null;
            }
        }

        private void btnReclassifyAttachment_Click(object sender, EventArgs e)
        {
            DataTable dtEmailDocTypes = new DataTable();
            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (lstEmailAttachments.Items.Count > 0)
                {
                    if (!PatientEmailAttachmentID.Equals(""))
                    {
                        if (MessageBox.Show("Continue re-classifying email attachment. . .?", "Email Attachment Re-Classification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            string DocTypeDesc = "";
                            int DocTypeID = 0;

                            dtEmailDocTypes = commonFuncs.Get_AIMS_Email_Attachment_Mailbox(PatientEmailAttachmentID);
                            string MailBoxName = "";
                            if (dtEmailDocTypes.Rows.Count >0)
                            {
                                MailBoxName = dtEmailDocTypes.Rows[0]["MAILBOX_NAME"].ToString(); 
                            }

                            dtEmailDocTypes = commonFuncs.Get_AIMS_Email_DocTypes(MailBoxName.ToUpper());
                            DialogResult dgWindow = DocumentTypeInputBox("Re-classify Email Attachment", "New Document Classification", ref DocTypeDesc, ref DocTypeID, dtEmailDocTypes);
                            if (dgWindow == DialogResult.OK)
                            {
                                if (DocTypeDesc.Trim().Equals(""))
                                {
                                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Document Type Not Selected");
                                }
                                else
                                {
                                    if (!PatientEmailAttachmentDesc.Equals(DocTypeDesc))
                                    {
                                        bool bEmailAttachmentReclassify = commonFuncs.EmailAttachmentReclassify(DocTypeID.ToString(), PatientEmailAttachmentID);
                                        if (bEmailAttachmentReclassify)
                                        {
                                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Email attachment reclassified successfully.");
                                            LoadEmailAttachments();
                                        }
                                        else
                                        {
                                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email attachment NOT reclassified, please try again.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email Attachment Reclassification Error, Please try again.");
                commonFuncs.ErrorLogger("Email Attachment Reclassification Error: /n" + ex.ToString());
            }
            finally
            {
                dtEmailDocTypes.Dispose();
                dtEmailDocTypes = null;
                //commonFuncs = null;
            }
        }

        private void txtGuarantorRefNum_TextChanged(object sender, EventArgs e)
        {

        }

        public static DialogResult DocumentTypeInputBox(string title, string promptText, ref string value, ref int value2, DataTable dtEmailDocTypes)
        {
            Form form = new Form();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Text = title;
            Int32 labelyBound = 22;
            //TextBox textBox;
            ComboBox cboDocType;
            Label label;

            ComboBox cboDocTypes;
            cboDocTypes = new ComboBox();

            label = new Label();
            cboDocType = new ComboBox();
            cboDocType.DataSource = dtEmailDocTypes;
            cboDocType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDocType.DisplayMember = "DOC_TYPE";
            cboDocType.ValueMember = "DOC_TYPE_ID";
            cboDocType.SelectedValue = -1;
            cboDocType.Name = "cboDocType";

            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            //label.SetBounds(9, labelyBound -2, 372, 13);
            //labelyBound += 38;

            //cboDocType.SetBounds(12, 36 , 372, 20);
            label.SetBounds(9, 20, 372, 13);
            cboDocType.SetBounds(12, 36, 399, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            //textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            cboDocType.Anchor = cboDocType.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            cboDocTypes = cboDocType;
            form.ClientSize = new Size(420, 107);
            form.Controls.AddRange(new Control[] { label, cboDocType, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            //form.ClientSize = new Size(396, 207);
            //form.Controls.AddRange(new Control[] { label, cboDocType, buttonOk, buttonCancel });
            //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);


            //buttonOk.SetBounds(9, 200, 75, 23);
            //buttonCancel.SetBounds(100, 200, 75, 23);

            //form.FormBorderStyle = FormBorderStyle.Sizable;
            //form.StartPosition = FormStartPosition.CenterScreen;
            //form.MinimizeBox = false;
            //form.MaximizeBox = false;
            //form.AcceptButton = buttonOk;
            //form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = cboDocType.Text;
            value2 = System.Convert.ToInt16(cboDocType.SelectedValue);
            return dialogResult;
        }

        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (lstPatientFileEmails.Items.Count > 0)
                {
                    //if (!PatientEmailEnquiryID.Equals(""))
                    if (!PatientEmailAttachmentID.Equals(""))
                    {
                        if (MessageBox.Show("Continue removing email attachment. . ?", "Email Attachment Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            bool bFileDelete = commonFuncs.EmailAttachmentDelete(PatientEmailAttachmentID);
                            if (bFileDelete)
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Email Attachment successfully Removed.");
                                LoadEmailAttachments();
                            }
                            else
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email Attachment Removal Error, Please try again.");
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File Removal Error, Please try again.");
                commonFuncs.ErrorLogger("Patient File Removal Error: /n" + ex.ToString());
            }
            finally
            {
                //commonFuncs = null;
            }
        }

        private void LoadEmailAttachments() 
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItm;
            DataTable dtPatientEmailAttachments = commonFuncs.Get_AIMS_Patient_Email_Docs(PatientEmailEnquiryID);
            lstEmailAttachments.Items.Clear();
            try
            {
                if (dtPatientEmailAttachments.Rows.Count > 0)
                {
                    string EmailAttachmentLoc = "";
                    string EmailAttachType = "";
                    string EmailAttachmentID = "";

                    foreach (DataRow dtRow in dtPatientEmailAttachments.Rows)
                    {
                        EmailAttachType = dtRow["DOC_TYPE"].ToString();
                        EmailAttachmentLoc = dtRow["FILE_NAME"].ToString();
                        EmailReadYN = dtRow["MAIL_READ_YN"].ToString();
                        EmailAttachmentID = dtRow["EMAIL_DOCUMENT_ID"].ToString();

                        lvwItm = new ListViewItem(EmailAttachType, 2);
                        lvwItm.SubItems.Add(EmailAttachmentLoc);
                        lvwItm.SubItems.Add(EmailAttachmentID);

                        lstEmailAttachments.Items.Add(lvwItm);
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                dtPatientEmailAttachments.Dispose();
                //commonFuncs = null;
            }
        }

        private void btnSearchEmails_Click(object sender, EventArgs e)
        {
            try
            {
                string EmailSubjectKeyword = "";
                EmailSearchInputBox("Email Search", "Email Subject Keyword", ref EmailSubjectKeyword);
                if (!EmailSubjectKeyword.Trim().Equals(""))
                {
                    LoadPatientFileEmails(EmailSubjectKeyword);
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        public static DialogResult EmailSearchInputBox(string title, string promptText1, ref string value1)
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
                buttonOk.Top = textBox1.Bottom + 10;
                buttonCancel.Top = textBox1.Bottom + 10;

                form.ClientSize = new Size(420, 120);
                form.Controls.AddRange(new Control[] { label1, textBox1, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value1 = textBox1.Text;
                if (dialogResult == DialogResult.Cancel)
                {
                    value1 = "";
                }
                return dialogResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnFileEmailsRefresh_Click(object sender, EventArgs e)
        {
            LoadPatientFileEmails("");
            LoadPatientSentEmails();
            LoadPatientProcessedEmailAudit(txtPatientFileNo.Text);
        }

        private void tmrPatientFileEmails_Tick(object sender, EventArgs e)
        {
            //LoadPatientFileEmails("");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("New Email Received");
        }

        private void btnNotesIM_Click(object sender, EventArgs e)
        {
            try
            {
                frmInstantMessage frmInstantMessage = new frmInstantMessage(txtPatientFileNo.Text);
                frmInstantMessage.StartPosition = FormStartPosition.CenterParent;
                frmInstantMessage.UserID = UserID;

                frmInstantMessage.ShowDialog();
                
                frmInstantMessage.Close();
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
        }

        private void cboTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void clearMyInstantMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //commonFuncs = new AIMS.Common.CommonFunctions();
                bool bClearIM =  commonFuncs.Clear_My_Instant_Messages(UserID);
                if (!bClearIM)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Problem with clearing your Instant Messages, Please try again");
                }
                else
                {
                    notifyIcon1.Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                
            }
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                    mi.Invoke(notifyIcon1, null);
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void btnMailsRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                if (!txtPatientFileNo.Text.Trim().Equals(""))
                {
                    LoadPatientFileEmails("");
                    LoadPatientSentEmails();
                }
                LoadMyMailbox();
                Application.DoEvents();
            }
            catch (System.Exception ex)
            {
                
            }
        }

        private void gpbxPatientSearch_Enter(object sender, EventArgs e)
        {
        } 

        private void btnWorkBasketView_Click(object sender, EventArgs e)
        {
            DataTable dtOpsCoOrdinators = new DataTable();
            string coOrdinatorName = "";
            string coOrdinatorUserName = "";
            try
            {
                //commonFuncs = new AIMS.Common.CommonFunctions();
                if (MessageBox.Show("Continue changing workbasket View?", "Workbasket View Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtOpsCoOrdinators = commonFuncs.GetFileOperators();
                    DialogResult dgWindow = CoOrdinatorInputBox("Co-Ordinator Workbasket View", "Co-Odinator", ref coOrdinatorName, ref coOrdinatorUserName, dtOpsCoOrdinators);
                    if (dgWindow == DialogResult.OK)
                    {
                        if (!coOrdinatorUserName.Trim().Equals(""))
                        {
                            LoadMyMailbox(coOrdinatorUserName, coOrdinatorName);
                        }
                    }
                }
            }
            finally 
            {
                dtOpsCoOrdinators.Dispose();
                dtOpsCoOrdinators = null;
            }
        }

        public static DialogResult CoOrdinatorInputBox(string title, string promptText, ref string value, ref string value2, DataTable dtEmailDocTypes)
        {
            Form form = new Form();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Text = title;
            Int32 labelyBound = 22;
            //TextBox textBox;
            ComboBox cboDocType;
            Label label;

            ComboBox cboDocTypes;
            cboDocTypes = new ComboBox();

            label = new Label();
            cboDocType = new ComboBox();
            cboDocType.DataSource = dtEmailDocTypes;
            cboDocType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDocType.DisplayMember = "USER_FULL_NAME";
            cboDocType.ValueMember = "USER_NAME";
            cboDocType.SelectedValue = -1;
            cboDocType.Name = "cboDocType";

            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            //label.SetBounds(9, labelyBound -2, 372, 13);
            //labelyBound += 38;

            //cboDocType.SetBounds(12, 36 , 372, 20);
            label.SetBounds(9, 20, 372, 13);
            cboDocType.SetBounds(12, 36, 399, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            //textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            cboDocType.Anchor = cboDocType.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            cboDocTypes = cboDocType;
            form.ClientSize = new Size(420, 107);
            form.Controls.AddRange(new Control[] { label, cboDocType, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            //form.ClientSize = new Size(396, 207);
            //form.Controls.AddRange(new Control[] { label, cboDocType, buttonOk, buttonCancel });
            //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);


            //buttonOk.SetBounds(9, 200, 75, 23);
            //buttonCancel.SetBounds(100, 200, 75, 23);

            //form.FormBorderStyle = FormBorderStyle.Sizable;
            //form.StartPosition = FormStartPosition.CenterScreen;
            //form.MinimizeBox = false;
            //form.MaximizeBox = false;
            //form.AcceptButton = buttonOk;
            //form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = cboDocType.Text;
            value2 = System.Convert.ToString(cboDocType.SelectedValue);
            return dialogResult;
        }

        private void GetBccEmailAddress()
        {
            DataTable dtBccEmail = new DataTable();
            try
            {
                //commonFuncs = new AIMS.Common.CommonFunctions();
                dtBccEmail = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_BCC_ADDRESS");
                BccEmailAddress = dtBccEmail.Rows[0]["LIMITATION_VALUE"].ToString();
            }
            finally
            {
                dtBccEmail.Dispose();
                dtBccEmail = null;
            }
        }

        private void aimsComboLookup2_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuaranteeAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnGuaranteeSend_Click(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                frmNewEmail frmNewMail = new frmNewEmail();

                frmNewMail.EmailSubject = PatientEmailSubject;
                frmNewMail.EmailFrom = PatientEmailFrom;
                frmNewMail.PatientFileNo = txtPatientFileNo.Text;
                frmNewMail.LoggedOnUser = UserID;
                frmNewMail.BccEmailAddress = BccEmailAddress;


                frmNewMail.PatientFileEnquiryID = PatientEmailEnquiryID;
                frmNewMail.Show();

                LoadPatientSentEmails();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading New Email Form error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading New Email Form error: \n" + ex.ToString());
            }
            finally
            {
                //commonFuncs = null;
            }
        }

        private void btnGuaranteeAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lstvwServiceProviders.Items.Count.Equals(0))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "No service providers loaded on case.");
                }
                else if (txtDateOfBirth.Text.Trim().Equals(""))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture Date Of Birth.");
                }
                else
                {
                    frmPatientGuarantee frmPatientGuarantees = new frmPatientGuarantee();
                    frmPatientGuarantees.StartPosition = FormStartPosition.CenterParent;
                    frmPatientGuarantees.Text = txtPatientFileNo.Text + " - Add Guarantee";
                    frmPatientGuarantees.PatientFileNo = txtPatientFileNo.Text;
                    frmPatientGuarantees.Hospital = System.Convert.ToInt32(cboHospitals.SelectedValue);
                    frmPatientGuarantees.Diagnosis = txtDiagnosis.Text.ToUpper();
                    frmPatientGuarantees.AdmissionDate = txtDateAdmitted.Text;
                    frmPatientGuarantees.GuaranteeAmount = lblGuarantoredAmount.Text;
                    frmPatientGuarantees.PatientName = txtFirstName.Text.ToUpper() + " " + txtSurname.Text.ToUpper();
                    frmPatientGuarantees.PatientDOB = txtDateOfBirth.Text;
                    frmPatientGuarantees.ShowDialog();
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void LoadPatientFileTasks(string PatientSubFileId)
        {
            try
            {
                lstvwTasks.Items.Clear();
                DataTable dtPatientFileTasks = commonFuncs.GetPatientFilesTasks(PatientSubFileId, "ACTIVE");
                if (dtPatientFileTasks.Rows.Count > 0)
                {
                    ListViewItem lstItm;
                    for (int i = 0; i < dtPatientFileTasks.Rows.Count; i++)
                    {
                        lstItm = new ListViewItem(dtPatientFileTasks.Rows[i]["USER_FULL_NAME"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_DESC"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["due_date"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["PRIORITY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_STATUS"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["LOADED_BY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["CREATION_DATE"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["patient_file_task_id"].ToString());

                        if (dtPatientFileTasks.Rows[i]["STATUS"].ToString() == "Y" &&
                            (dtPatientFileTasks.Rows[i]["PRIORITY"].ToString().ToUpper() == "URGENT" || dtPatientFileTasks.Rows[i]["PRIORITY"].ToString().ToUpper() == "HIGH"))
                        {
                            lstvwTasks.Items.Add(lstItm).BackColor = Color.Red;
                        }
                        else
                        {
                            lstvwTasks.Items.Add(lstItm);
                        }
                    }

                    foreach (ColumnHeader colHeader in lstvwTasks.Columns)
                    {
                        if (colHeader.Text =="TASK_ID")
	                    {
                            colHeader.Width = 0;
                        }
                        else
                        {
                            colHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }                         
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Tasks error, Please contact system Administrator." + ex.Message);
                commonFuncs.ErrorLogger("Loading Patient File Tasks, Please try again: " + ex.ToString());
            }
        }

        private void LoadPatientFileCompletedTasks(string PatientSubFileId)
        {
            try
            {
                lstvwTasksCompleted.Items.Clear();
                DataTable dtPatientFileTasks = commonFuncs.GetPatientFilesTasks(PatientSubFileId, "COMPLETED");
                if (dtPatientFileTasks.Rows.Count > 0)
                {
                    ListViewItem lstItm;
                    for (int i = 0; i < dtPatientFileTasks.Rows.Count; i++)
                    {
                        lstItm = new ListViewItem(dtPatientFileTasks.Rows[i]["USER_FULL_NAME"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_DESC"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["due_date"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["PRIORITY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_STATUS"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["LOADED_BY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["CREATION_DATE"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["patient_file_task_id"].ToString());

                        if (dtPatientFileTasks.Rows[i]["STATUS"].ToString() == "Y" && dtPatientFileTasks.Rows[i]["PRIORITY"].ToString().ToUpper() == "URGENT")
                        {
                            lstvwTasksCompleted.Items.Add(lstItm).BackColor = Color.Red;
                        }
                        else
                        {
                            lstvwTasksCompleted.Items.Add(lstItm);
                        }
                    }

                    foreach (ColumnHeader colHeader in lstvwTasksCompleted.Columns)
                    {
                        if (colHeader.Text == "TASK_ID")
                        {
                            colHeader.Width = 0;
                        }
                        else
                        {
                            colHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Completed Tasks error, Please contact system Administrator." + ex.Message);
                commonFuncs.ErrorLogger("Loading Patient File COmpleted Tasks, Please try again: " + ex.ToString());
            }
        }

        private void LoadPatientFileCancelledTasks(string PatientSubFileId)
        {
            try
            {
                lstvwTasksCancelled.Items.Clear();
                DataTable dtPatientFileTasks = commonFuncs.GetPatientFilesTasks(PatientSubFileId, "Cancelled");
                if (dtPatientFileTasks.Rows.Count > 0)
                {
                    ListViewItem lstItm;
                    for (int i = 0; i < dtPatientFileTasks.Rows.Count; i++)
                    {
                        lstItm = new ListViewItem(dtPatientFileTasks.Rows[i]["USER_FULL_NAME"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_DESC"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["due_date"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["PRIORITY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_STATUS"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["LOADED_BY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["CREATION_DATE"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["patient_file_task_id"].ToString());

                        if (dtPatientFileTasks.Rows[i]["STATUS"].ToString() == "Y" && dtPatientFileTasks.Rows[i]["PRIORITY"].ToString().ToUpper() == "URGENT")
                        {
                            lstvwTasksCancelled.Items.Add(lstItm).BackColor = Color.Red;
                        }
                        else
                        {
                            lstvwTasksCancelled.Items.Add(lstItm);
                        }
                    }

                    foreach (ColumnHeader colHeader in lstvwTasksCancelled.Columns)
                    {
                        if (colHeader.Text == "TASK_ID")
                        {
                            colHeader.Width = 0;
                        }
                        else
                        {
                            colHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Tasks error, Please contact system Administrator." + ex.Message);
                commonFuncs.ErrorLogger("Loading Patient File Tasks, Please try again: " + ex.ToString());
            }
        }

        private void LoadPatientProcessedEmailAudit(string PatientSubFileId)
        {
            try
            {
                lstPatientFileEmailAudit.Items.Clear();
                DataTable dtPatientFileProcessedEmails = commonFuncs.GetPatientFilesEmailsProcessed(PatientSubFileId);
                if (dtPatientFileProcessedEmails.Rows.Count > 0)
                {
                    ListViewItem lstItm;
                    for (int i = 0; i < dtPatientFileProcessedEmails.Rows.Count; i++)
                    {
                        lstItm = new ListViewItem(dtPatientFileProcessedEmails.Rows[i]["EMAIL_SUBJECT"].ToString());
                        lstItm.SubItems.Add(dtPatientFileProcessedEmails.Rows[i]["EMAIL_RECEIVED_DTTM"].ToString());
                        lstItm.SubItems.Add(dtPatientFileProcessedEmails.Rows[i]["USER_FULL_NAME"].ToString());
                        lstItm.SubItems.Add(dtPatientFileProcessedEmails.Rows[i]["WORK_ITEM_PROCESSED_DTTM"].ToString());
                        lstPatientFileEmailAudit.Items.Add(lstItm);
                    }

                    foreach (ColumnHeader colHeader in lstPatientFileEmailAudit.Columns)
                    {
                        if (colHeader.Text =="TASK_ID")
	                    {
                            colHeader.Width = 0;
                        }
                        else
                        {
                            colHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }                         
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Tasks error, Please contact system Administrator." + ex.Message);
                commonFuncs.ErrorLogger("Loading Patient File Tasks, Please try again: " + ex.ToString());
            }
        }

        private void TasksSetup()
        {
            lstvwTasks.Columns.Clear();
            lstvwTasks.Items.Clear();
            lstvwTasks.Columns.Add("Co-Ordinator", Convert.ToInt32(lstvwTasks.Width * 0.15), HorizontalAlignment.Left);
            lstvwTasks.Columns.Add("Task Description", Convert.ToInt32(lstvwTasks.Width * 0.66), HorizontalAlignment.Left);
            lstvwTasks.Columns.Add("Due Date", Convert.ToInt32(lstvwTasks.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasks.Columns.Add("Priority", Convert.ToInt32(lstvwTasks.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasks.Columns.Add("Status", Convert.ToInt32(lstvwTasks.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasks.Columns.Add("Created/Changed By", Convert.ToInt32(lstvwTasks.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasks.Columns.Add("Created Date", Convert.ToInt32(lstvwTasks.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasks.Columns.Add("TASK_ID", 0);

            lstvwTasksCompleted.Columns.Clear();
            lstvwTasksCompleted.Items.Clear();
            lstvwTasksCompleted.Columns.Add("Co-Ordinator", Convert.ToInt32(lstvwTasksCompleted.Width * 0.15), HorizontalAlignment.Left);
            lstvwTasksCompleted.Columns.Add("Task Description", Convert.ToInt32(lstvwTasksCompleted.Width * 0.66), HorizontalAlignment.Left);
            lstvwTasksCompleted.Columns.Add("Due Date", Convert.ToInt32(lstvwTasksCompleted.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCompleted.Columns.Add("Priority", Convert.ToInt32(lstvwTasksCompleted.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCompleted.Columns.Add("Status", Convert.ToInt32(lstvwTasksCompleted.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCompleted.Columns.Add("Created/Changed By", Convert.ToInt32(lstvwTasksCompleted.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCompleted.Columns.Add("Created Date", Convert.ToInt32(lstvwTasksCompleted.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCompleted.Columns.Add("TASK_ID", 0);

            lstvwTasksCancelled.Columns.Clear();
            lstvwTasksCancelled.Items.Clear();
            lstvwTasksCancelled.Columns.Add("Co-Ordinator", Convert.ToInt32(lstvwTasksCancelled.Width * 0.15), HorizontalAlignment.Left);
            lstvwTasksCancelled.Columns.Add("Task Description", Convert.ToInt32(lstvwTasksCancelled.Width * 0.66), HorizontalAlignment.Left);
            lstvwTasksCancelled.Columns.Add("Due Date", Convert.ToInt32(lstvwTasksCancelled.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCancelled.Columns.Add("Priority", Convert.ToInt32(lstvwTasksCancelled.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCancelled.Columns.Add("Status", Convert.ToInt32(lstvwTasksCancelled.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCancelled.Columns.Add("Created/Changed By", Convert.ToInt32(lstvwTasksCancelled.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCancelled.Columns.Add("Created Date", Convert.ToInt32(lstvwTasksCancelled.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksCancelled.Columns.Add("TASK_ID", 0);
        }

        private void ProcessedEmailsSetup()
        {
            lstPatientFileEmailAudit.Columns.Clear();
            lstPatientFileEmailAudit.Items.Clear();
            lstPatientFileEmailAudit.Columns.Add("Email Subject", Convert.ToInt32(lstPatientFileEmailAudit.Width * 0.15), HorizontalAlignment.Left);
            lstPatientFileEmailAudit.Columns.Add("Email Received Date", Convert.ToInt32(lstPatientFileEmailAudit.Width * 0.66), HorizontalAlignment.Left);
            lstPatientFileEmailAudit.Columns.Add("Email Processed By", Convert.ToInt32(lstPatientFileEmailAudit.Width * 0.2), HorizontalAlignment.Left);
            lstPatientFileEmailAudit.Columns.Add("Email Processed Date", Convert.ToInt32(lstPatientFileEmailAudit.Width * 0.2), HorizontalAlignment.Left);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            //if (lblPatientSubFileId.Text.Trim().Equals("") || lstvwPatientChildCases.Items.Count.Equals(0))
            //{
            //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "No Patient Sub-File Loaded.");
            //}
            //else
            //{
                frmTasks frmAddTasks = new frmTasks();
                frmAddTasks.ShowInTaskbar = false;
                frmAddTasks.StartPosition = FormStartPosition.CenterScreen;
                frmAddTasks.Text = "Add Task";
                frmAddTasks.PatientSubFileID = txtPatientFileNo.Text;
                frmAddTasks.UserID = UserID;
                frmAddTasks.Restrictions = Restrictions;

                if (frmAddTasks.ShowDialog() == DialogResult.OK)
                {
                    LoadPatientFileTasks(txtPatientFileNo.Text);
                    LoadPatientFileCompletedTasks(txtPatientFileNo.Text);
                    LoadPatientFileCancelledTasks(txtPatientFileNo.Text);
                }
            //}
        }

        private void lstlvwNotes_ItemClick(object sender, ItemCheckEventArgs e)
        {

        }

        private void btnAddFinanceNote_Click(object sender, EventArgs e)
        {
            try
            {        
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Finance Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteID = 0;
                frmNotes.NoteTypeCode = "PATIENTFINANCENOTES";
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTFINANCENOTES");
                    LoadNotes("'PATIENTFINANCENOTES'");
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error adding Finance Note/Comment, Please contact System Administrator");
            }
        }

        private void btnAddMedicalNote_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Medical Note";
                frmNotes.UserID = UserID;
                frmNotes.NoteID = 0;
                frmNotes.NoteTypeCode = "PATIENTMEDICALHISTORY";

                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTMEDICALHISTORY");
                    LoadNotes("'PATIENTMEDICALHISTORY'");
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void btnEditMedPatientNote_Click_1(object sender, EventArgs e)
        {
            if (lstlvwMedNotes.SelectedItems.Count == 0)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient Medical Comment not selected.");
            }
            else
            {
                string NoteID = lstlvwMedNotes.Items[lstlvwMedNotes.SelectedItems[0].Index].SubItems[4].Text.ToString();

                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.NoteID = System.Convert.ToInt64(NoteID);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Medical Note";
                frmNotes.UserID = UserID;
                frmNotes.NoteTypeCode = "PATIENTMEDICALHISTORY";
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTMEDICALHISTORY");
                    LoadNotes("'PATIENTMEDICALHISTORY'");
                }
            }
        }

        private void btnAddAdminNote_Click(object sender, EventArgs e)
        {
            try
            {       
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Admin Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteID = 0;
                frmNotes.NoteTypeCode = "PATIENTADMINNOTES";
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTADMINNOTES");
                    LoadNotes("'PATIENTADMINNOTES'");
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error adding Admin Note/Comment, Please contact System Administrator");
            }

        }

        private void btnEditAdminNote_Click(object sender, EventArgs e)
        {
            if (lstlvwAdminNotes.SelectedItems.Count == 0)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient File Admin not selected.");
            }
            else
            {
                string NoteID = lstlvwAdminNotes.Items[lstlvwAdminNotes.SelectedItems[0].Index].SubItems[4].Text.ToString();
                string NotesText = lstlvwAdminNotes.Items[lstlvwAdminNotes.SelectedItems[0].Index].SubItems[1].Text.ToString();
                if (NotesText == "New File for Patient")
                {
                    MessageBox.Show("This comment cannot be changed.", "Comment Change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Int32 selectItem = lstlvwAdminNotes.SelectedItems[0].Index;
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.NoteID = System.Convert.ToInt64(NoteID);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Admin Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteTypeCode = "PATIENTADMINNOTES";
                //frmNotes.Show();
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTADMINNOTES");
                    LoadNotes("'PATIENTADMINNOTES'");
                }
                if (!lstlvwAdminNotes.Items.Count.Equals(0))
                {
                    lstlvwAdminNotes.Items[selectItem].Selected = true;
                }

                Application.DoEvents();
            }

        }

        private void btnEditFinanceNote_Click(object sender, EventArgs e)
        {
            if (lstlvwFinanceNotes.SelectedItems.Count == 0)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient-File Finance Comment not selected.");
            }
            else
            {
                string NoteID = lstlvwFinanceNotes.Items[lstlvwFinanceNotes.SelectedItems[0].Index].SubItems[4].Text.ToString();
                string NotesText = lstlvwFinanceNotes.Items[lstlvwFinanceNotes.SelectedItems[0].Index].SubItems[1].Text.ToString();
                if (NotesText == "New File for Patient")
                {
                    MessageBox.Show("This comment cannot be changed.", "Comment Change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Int32 selectItem = lstlvwFinanceNotes.SelectedItems[0].Index;
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.NoteID = System.Convert.ToInt64(NoteID);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Finance Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteTypeCode = "PATIENTFINANCENOTES";
                //frmNotes.Show();
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTFINANCENOTES");
                    LoadNotes("'PATIENTFINANCENOTES'");
                }
                if (!lstlvwFinanceNotes.Items.Count.Equals(0))
                {
                    lstlvwFinanceNotes.Items[selectItem].Selected = true;
                }

                Application.DoEvents();
            }
        }

        private void lstlvwFinanceNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddInterimNote_Click(object sender, EventArgs e)
        {
            try
            {
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Interim Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteID = 0;
                frmNotes.NoteTypeCode = "PATIENTINTERIMNOTES";
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTINTERIMNOTES");
                    LoadNotes("'PATIENTINTERIMNOTES'");
                    frmNotes.Close();
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error adding Interim Note/Comment, Please contact System Administrator");
            }
        }

        private void btnEditInterimNote_Click(object sender, EventArgs e)
        {
            if (lstlvwInterimNotes.SelectedItems.Count == 0)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient-File Interim Comment not selected.");
            }
            else
            {
                string NoteID = lstlvwInterimNotes.Items[lstlvwInterimNotes.SelectedItems[0].Index].SubItems[4].Text.ToString();
                string NotesText = lstlvwInterimNotes.Items[lstlvwInterimNotes.SelectedItems[0].Index].SubItems[1].Text.ToString();
                if (NotesText == "New File for Patient")
                {
                    MessageBox.Show("This comment cannot be changed.", "Comment Change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Int32 selectItem = lstlvwInterimNotes.SelectedItems[0].Index;
                frmNotes = new frmComments(txtPatientFileNo.Text);
                frmNotes.NoteID = System.Convert.ToInt64(NoteID);
                frmNotes.ShowInTaskbar = false;
                frmNotes.StartPosition = FormStartPosition.CenterScreen;
                frmNotes.Text = "Patient Finance Comments/Notes";
                frmNotes.UserID = UserID;
                frmNotes.NoteTypeCode = "PATIENTINTERIMNOTES";
                //frmNotes.Show();
                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    frmNotes.Close();
                    NotesSetup("PATIENTINTERIMNOTES");
                    LoadNotes("'PATIENTINTERIMNOTES'");
                }
                if (!lstlvwInterimNotes.Items.Count.Equals(0))
                {
                    lstlvwInterimNotes.Items[selectItem].Selected = true;
                }

                Application.DoEvents();
            }
        }

        private void lstvwTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstvwTasks_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string PatientFileTaskID = lstGet.Items[i].SubItems[7].Text.ToString();
                        if (PatientFileTaskID.Trim().Length > 0)
                        {
                            DataTable dsPatientFileTask = new DataTable(); ;
                            ListViewItem lvwItem;

                            dsPatientFileTask = commonFuncs.GetTaskDetails(PatientFileTaskID);
                            if (dsPatientFileTask.Rows.Count > 0)
                            {
                                frmTasks frmTask;
                                frmTask = new frmTasks();
                                frmTask.ShowInTaskbar = false;
                                frmTask.StartPosition = FormStartPosition.CenterScreen;
                                frmTask.Text = "Edit Task";
                                frmTask.UserID = UserID;
                                frmTask.Restrictions = Restrictions;
                                frmTask.PatientFileTaskID = Convert.ToInt32(PatientFileTaskID);
                                frmTask.PatientSubFileID = txtPatientFileNo.Text;

                                if (frmTask.ShowDialog() == DialogResult.OK)
                                {
                                    LoadPatientFileTasks(txtPatientFileNo.Text);
                                    LoadPatientFileCompletedTasks(txtPatientFileNo.Text);
                                    LoadPatientFileCancelledTasks(txtPatientFileNo.Text);
                                }
                            }
                            //lstGet.Items[i].Checked = false;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Task Details error, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Loading Task Details error: " + ex.ToString());
            }
            finally
            {
                lstGet = null;
            }
        }

        private void lstvwTasksCompleted_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string PatientFileTaskID = lstGet.Items[i].SubItems[7].Text.ToString();
                        if (PatientFileTaskID.Trim().Length > 0)
                        {
                            DataTable dsPatientFileTask = new DataTable(); ;
                            ListViewItem lvwItem;

                            dsPatientFileTask = commonFuncs.GetTaskDetails(PatientFileTaskID);
                            if (dsPatientFileTask.Rows.Count > 0)
                            {
                                frmTasks frmTask;
                                frmTask = new frmTasks();
                                frmTask.ShowInTaskbar = false;
                                frmTask.StartPosition = FormStartPosition.CenterScreen;
                                frmTask.Text = "Edit Completed Task";
                                frmTask.UserID = UserID;
                                frmTask.Restrictions = Restrictions;
                                frmTask.PatientFileTaskID = Convert.ToInt32(PatientFileTaskID);
                                frmTask.PatientSubFileID = txtPatientFileNo.Text;

                                if (frmTask.ShowDialog() == DialogResult.OK)
                                {
                                    LoadPatientFileTasks(txtPatientFileNo.Text);
                                    LoadPatientFileCompletedTasks(txtPatientFileNo.Text);
                                    LoadPatientFileCancelledTasks(txtPatientFileNo.Text);
                                }
                            }
                            //lstGet.Items[i].Checked = false;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Completed Task Details error, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Loading Completed Task Details error: " + ex.ToString());
            }
            finally
            {
                lstGet = null;
            }
        }

        private void lstvwTasksCancelled_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string PatientFileTaskID = lstGet.Items[i].SubItems[7].Text.ToString();
                        if (PatientFileTaskID.Trim().Length > 0)
                        {
                            DataTable dsPatientFileTask = new DataTable(); ;
                            ListViewItem lvwItem;

                            dsPatientFileTask = commonFuncs.GetTaskDetails(PatientFileTaskID);
                            if (dsPatientFileTask.Rows.Count > 0)
                            {
                                frmTasks frmTask;
                                frmTask = new frmTasks();
                                frmTask.ShowInTaskbar = false;
                                frmTask.StartPosition = FormStartPosition.CenterScreen;
                                frmTask.Text = "Edit Cancelled Task";
                                frmTask.UserID = UserID;
                                frmTask.Restrictions = Restrictions;
                                frmTask.PatientFileTaskID = Convert.ToInt32(PatientFileTaskID);
                                frmTask.PatientSubFileID = txtPatientFileNo.Text;

                                if (frmTask.ShowDialog() == DialogResult.OK)
                                {
                                    LoadPatientFileTasks(txtPatientFileNo.Text);
                                    LoadPatientFileCompletedTasks(txtPatientFileNo.Text);
                                    LoadPatientFileCancelledTasks(txtPatientFileNo.Text);
                                }
                            }
                            //lstGet.Items[i].Checked = false;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Cancelled Task Details error, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Loading Cancelled Task Details error: " + ex.ToString());
            }
            finally
            {
                lstGet = null;
            }
        }

        private void btnPatientFIleTaskAudit_Click(object sender, EventArgs e)
        {
            frmPatientFileTasksAudit frmTaskAudit = new frmPatientFileTasksAudit();
            frmTaskAudit.ShowInTaskbar = false;
            frmTaskAudit.StartPosition = FormStartPosition.CenterScreen;
            frmTaskAudit.Text = "Patient File - " + txtPatientFileNo.Text + " : Tasks Audit";
            frmTaskAudit.PatientSubFileID = txtPatientFileNo.Text;
            

            frmTaskAudit.ShowDialog();
        }

        private void lstlvwNotes_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void LoadTemplates(string TemplateFilter)
        {
            tblGuarantors = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
            //commonFuncs = new AIMS.Common.CommonFunctions();

            try
            {
                if (TemplateFilter.Equals(""))
                {
                    tblGuarantors = lookupBLL.GetLookUpValues("TEMPLATE_ID", "TEMPLATE_NAME", "AIMS_TEMPLATES", 0, "TEMPLATE_NAME");
                }
                else
                {
                    tblGuarantors = lookupBLL.GetLookUpValues("TEMPLATE_ID", "TEMPLATE_NAME", "AIMS_TEMPLATES", 0, "TEMPLATE_NAME", "WHERE TEMPLATE_ID = " + TemplateFilter);
                }

                cboTemplates.DataSource = tblGuarantors;
                cboTemplates.DisplayMember = "TEMPLATE_NAME";
                cboTemplates.ValueMember = "TEMPLATE_ID";
                cboTemplates.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
            finally
            {
                //tblGuarantors.Dispose();
            }
        }

        private void cboTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTemplates.SelectedItem != null)
                {
                    if (cboTemplates.SelectedIndex > 0)
                    {
                        //Int32 TemplateFilterID = System.Convert.ToInt32(cboTemplates.SelectedValue);
                        //LoadTemplates(TemplateFilterID.ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error filtering document template, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Error filtering document template: " + ex.ToString());
            }
        }

        private void lstlvPatientTemplates_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string sDocFileName = lstGet.Items[i].SubItems[3].Text.ToString();
                        
                        if (!sDocFileName.Equals("") && File.Exists(sDocFileName))
                        {
                            if (File.Exists(sDocFileName))
                            {
                                //System.Diagnostics.Process.Start(sDocFileName);
                                frmImageViewer frmImgViewer = new frmImageViewer();
                                frmImgViewer.EmailDocument = sDocFileName;
                                frmImgViewer.Text = txtPatientFileNo.Text + " - " + lstGet.Items[i].SubItems[0].Text.ToString();
                                frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                                frmImgViewer.MaximizeBox = false ;
                                frmImgViewer.MinimizeBox = false;
                                frmImgViewer.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                lstGet = null;
            }
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDateOfBirth.Text.Trim().Equals(""))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture Date Of Birth.");
                    tabControl1.SelectedIndex = 0;
                    txtDateOfBirth.Focus();
                    return;
                }
                if (lstvwServiceProviders.Items.Count.Equals(0))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "No service providers loaded on case.");
                }
                else
                {
                    string TemplateName = "";
                    if (cboTemplates.SelectedItem != null && !cboTemplates.Text.Equals(""))
                    {
                        TemplateName = cboTemplates.Text;
                        if (TemplateName.Trim().Equals(""))
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select document template from list.");
                        }
                        else
                        {
                            switch (TemplateName)
                            {
                                case "Accomodation Voucher":
                                    frmAccomodation frmAccomodation = new frmAccomodation();
                                    frmAccomodation.StartPosition = FormStartPosition.CenterParent;
                                    frmAccomodation.Text = txtPatientFileNo.Text + " - Accomodation Voucher";
                                    frmAccomodation.PatientFileNo = txtPatientFileNo.Text;
                                    frmAccomodation.PatientID = lblPatientID.Text;
                                    frmAccomodation.PassportNo = txtPassport.Text.Trim();
                                    frmAccomodation.Nationality = txtNationality.Text;
                                    frmAccomodation.PatientDOB = txtDateOfBirth.Text;
                                    frmAccomodation.DateOfBirth = txtDateOfBirth.Text;
                                    frmAccomodation.Hospital = System.Convert.ToInt32(cboHospitals.SelectedValue);
                                    frmAccomodation.UserName = UserID;
                                    frmAccomodation.UserFullName = UserName;
                                    frmAccomodation.SignaturePath = SignaturePath;
                                    frmAccomodation.UserID = UserID;
                                    //frmPatientVISALetter.CountryOfTreatment = System.Convert.ToInt32(cboCountryOfTreatment.SelectedValue);
                                    frmAccomodation.PatientName = txtFirstName.Text.ToUpper() + " " + txtSurname.Text.ToUpper();
                                    frmAccomodation.ShowDialog();
                                    LoadPatientFileDocs(txtPatientFileNo.Text);
                                    break;
                                case "Air Ambulance Cost Estimate":
                                    //if (txtNationality.Text.Trim().Equals(""))
                                    //{
                                    //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture Nationality.");
                                    //    tabControl1.SelectedIndex = 0;
                                    //    txtNationality.Focus();
                                    //    return;        
                                    //}
                                    //if (txtPassport.Text.Trim().Equals(""))
                                    //{
                                    //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture Passport No.");
                                    //    tabControl1.SelectedIndex = 0;
                                    //    txtPassport.Focus();
                                    //    return;        
                                    //}

                                    frmAirAmbulanceCE frmAirAmbulance = new frmAirAmbulanceCE();
                                    frmAirAmbulance.StartPosition = FormStartPosition.CenterParent;
                                    frmAirAmbulance.Text = txtPatientFileNo.Text + " - Add Air Ambulance Cost-Estimate";
                                    frmAirAmbulance.PatientFileNo = txtPatientFileNo.Text;
                                    frmAirAmbulance.SignaturePath = SignaturePath;
                                    frmAirAmbulance.PatientID = lblPatientID.Text;
                                    frmAirAmbulance.PatientDOB = txtDateOfBirth.Text;
                                    frmAirAmbulance.PassportNo = txtPassport.Text.Trim();
                                    frmAirAmbulance.Nationality = txtNationality.Text;
                                    frmAirAmbulance.Hospital = System.Convert.ToInt32(cboHospitals.SelectedValue);
                                    frmAirAmbulance.UserName = UserID;
                                    //frmAirAmbulance.UserFullName = UserName;
                                    frmAirAmbulance.UserID = UserID;
                                    frmAirAmbulance.TemplateName = TemplateName;
                                    //frmPatientVISALetter.CountryOfTreatment = System.Convert.ToInt32(cboCountryOfTreatment.SelectedValue);
                                    frmAirAmbulance.PatientName = txtFirstName.Text.ToUpper() + " " + txtSurname.Text.ToUpper();
                                    frmAirAmbulance.ShowDialog();
                                    LoadPatientFileDocs(txtPatientFileNo.Text);
                                    break;
                                case "Visa Letter":
                                    frmVISALetter frmPatientVISALetter = new frmVISALetter();
                                    frmPatientVISALetter.StartPosition = FormStartPosition.CenterParent;
                                    frmPatientVISALetter.Text = txtPatientFileNo.Text + " - Add Visa Letter";
                                    frmPatientVISALetter.PatientFileNo = txtPatientFileNo.Text;
                                    frmPatientVISALetter.PatientID = lblPatientID.Text;
                                    frmPatientVISALetter.PatientDOB = txtDateOfBirth.Text;
                                    frmPatientVISALetter.PassportNo = txtPassport.Text.Trim();
                                    frmPatientVISALetter.Hospital = System.Convert.ToInt32(cboHospitals.SelectedValue);
                                    frmPatientVISALetter.UserName = UserID;
                                    frmPatientVISALetter.UserID  = UserID;
                                    frmPatientVISALetter.TemplateName = TemplateName;
                                    //frmPatientVISALetter.CountryOfTreatment = System.Convert.ToInt32(cboCountryOfTreatment.SelectedValue);
                                    frmPatientVISALetter.PatientName = txtFirstName.Text.ToUpper() + " " + txtSurname.Text.ToUpper();
                                    frmPatientVISALetter.ShowDialog();
                                    LoadPatientFileDocs(txtPatientFileNo.Text);
                                    break;
                                case "Guarantee of Payment":
                                case "Late Guarantee of Payment":
                                    if (lstvwServiceProviders.Items.Count.Equals(0))
                                    {
                                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "No service providers loaded on case.");
                                    }
                                    else
                                    {
                                        frmPatientGuarantee frmPatientGuarantees = new frmPatientGuarantee();
                                        frmPatientGuarantees.StartPosition = FormStartPosition.CenterParent;
                                        frmPatientGuarantees.Text = txtPatientFileNo.Text + " - Add Late / Guarantee of Payment";
                                        frmPatientGuarantees.PatientFileNo = txtPatientFileNo.Text;
                                        frmPatientGuarantees.PatientID = lblPatientID.Text;
                                        frmPatientGuarantees.TemplateName = TemplateName;
                                        frmPatientGuarantees.PatientDOB = txtDateOfBirth.Text;
                                        frmPatientGuarantees.Guarantor = cboGuarantors.Text;
                                        frmPatientGuarantees.UserID  = UserID ;
                                        
                                        if (cboHospitals.Text.Trim() != "")
                                        {
                                            frmPatientGuarantees.Hospital = System.Convert.ToInt32(cboHospitals.SelectedValue);
                                        }
                                        else
                                        {
                                            frmPatientGuarantees.Hospital = 0;
                                        }
                                        
                                        frmPatientGuarantees.Diagnosis = txtDiagnosis.Text.ToUpper();
                                        frmPatientGuarantees.AdmissionDate = txtDateAdmitted.Text;

                                        if (txtDateAdmitted.Text.Trim().Equals(""))
                                        {
                                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient Admission Date Not Captured");
                                            return;
                                        }
                                        
                                        if (frmPatientGuarantees.Hospital.ToString().Trim().Equals(""))
                                        {
                                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Hospital Not Captured");
                                            return;
                                        }

                                        if (txtGuaranteeAmount.Text.Trim().Equals(""))
                                        {
                                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Guarantee Amount Not Captured");
                                            return; 
                                        }
                                        frmPatientGuarantees.GuaranteeAmount = txtGuaranteeAmount.Text;
                                        frmPatientGuarantees.GuarantorID = System.Convert.ToInt32(cboGuarantors.SelectedValue);
                                        frmPatientGuarantees.SignaturePath = SignaturePath;
                                        frmPatientGuarantees.UserFullName = UserName;
                                        frmPatientGuarantees.PatientName = txtFirstName.Text.ToUpper() + " " + txtSurname.Text.ToUpper();
                                        frmPatientGuarantees.ShowDialog();
                                        LoadPatientFileDocs(txtPatientFileNo.Text);
                                    }
                                    break;
                                case "Patient Guarantee":
                                    if (lstvwServiceProviders.Items.Count.Equals(0))
                                    {
                                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "No service providers loaded on case.");
                                    }
                                    else if (txtGuaranteeAmount.Text.Trim().Equals("")  )
                                    {
                                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please capture Gaurantee Amount.");
                                    }
                                    else
                                    {
                                        frmPatientGuarantee frmPatientGuarantees = new frmPatientGuarantee();
                                        frmPatientGuarantees.StartPosition = FormStartPosition.CenterParent;
                                        frmPatientGuarantees.Text = txtPatientFileNo.Text + " - Add Guarantee of Payment";
                                        frmPatientGuarantees.PatientFileNo = txtPatientFileNo.Text;
                                        frmPatientGuarantees.PatientID = lblPatientID.Text;
                                        frmPatientGuarantees.Guarantor = cboGuarantors.Text;
                                        frmPatientGuarantees.UserID = UserID;
                                        frmPatientGuarantees.PatientDOB = txtDateOfBirth.Text;

                                        if (cboHospitals.Text.Trim() != "")
                                        {
                                            frmPatientGuarantees.Hospital = System.Convert.ToInt32(cboHospitals.SelectedValue);
                                        }
                                        else
                                        {
                                            frmPatientGuarantees.Hospital = 0;
                                        }

                                        frmPatientGuarantees.Diagnosis = txtDiagnosis.Text.ToUpper();
                                        frmPatientGuarantees.AdmissionDate = txtDateAdmitted.Text;

                                        if (txtDateAdmitted.Text.Trim().Equals(""))
                                        {
                                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient Admission Date Not Captured");
                                            return;
                                        }

                                        if (frmPatientGuarantees.Hospital.ToString().Trim().Equals(""))
                                        {
                                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Hospital Not Captured");
                                            return;
                                        }

                                        frmPatientGuarantees.GuaranteeAmount = txtGuaranteeAmount.Text;
                                        frmPatientGuarantees.GuarantorID = System.Convert.ToInt32(cboGuarantors.SelectedValue);
                                        frmPatientGuarantees.UserFullName = UserName;
                                        frmPatientGuarantees.PatientName = txtFirstName.Text.ToUpper() + " " + txtSurname.Text.ToUpper();
                                        frmPatientGuarantees.ShowDialog();
                                        LoadPatientFileDocs(txtPatientFileNo.Text);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select document template from list.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Adding patient document template error, please contact system administrator");
                commonFuncs.ErrorLogger("Adding patient document template error, \n" + ex.ToString());
            }
        }

        private void btnViewTemplate_Click(object sender, EventArgs e)
        {
            if (lstlvPatientTemplates.SelectedItems.Count > 0)
            {
                string PatientTemplateView = lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[3].Text.ToString();
                if (!PatientTemplateView.Equals(""))
                {
                    string sDocFileName = lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[3].Text.ToString();
                    if (!sDocFileName.Equals("") && File.Exists(sDocFileName))
                    {
                        frmImageViewer frmImgViewer = new frmImageViewer();
                        frmImgViewer.EmailDocument = sDocFileName;
                        frmImgViewer.Text = txtPatientFileNo.Text + " - " + lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[0].Text.ToString();
                        frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                        frmImgViewer.MinimizeBox = false;
                        frmImgViewer.MaximizeBox = false;
                        frmImgViewer.ShowDialog();
                    }
                }
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select document to view.");
            }
        }

        private void btnEmailTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstlvPatientTemplates.Items.Count > 0)
                {
                    string PatientTemplateName = "";
                    string PatientTemplateFile = "";
                    string PatientTemplateDocId = "";

                    if (lstlvPatientTemplates.SelectedItems.Count > 0)
                    {
                        PatientTemplateName = lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[0].Text.ToString();
                        PatientTemplateFile = lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[3].Text.ToString();
                        
                        if (PatientTemplateName.Contains("Guarantee"))
                        {
                            PatientTemplateDocId = lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[4].Text.ToString();
                            bool bGOPApproved = IsGOPApproved(PatientTemplateDocId);
                            if (!bGOPApproved)
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "GOP IS NOT APPROVED, Please finalise first before sending email.");
                                return;
                            }
                        }
                        frmNewEmail frmNewMail = new frmNewEmail();

                        frmNewMail.EmailFrom = PatientEmailFrom;
                        frmNewMail.PatientFileNo = txtPatientFileNo.Text;
                        frmNewMail.LoggedOnUser = UserID;
                        frmNewMail.PatientDOB = txtDateOfBirth.Text;
                        frmNewMail.UserName = UserName;
                        frmNewMail.PatientName = cboTitle.Text + " " + txtFirstName.Text.Trim().ToUpper() + " " + txtSurname.Text.Trim().ToUpper();
                        frmNewMail.BccEmailAddress = BccEmailAddress;
                        frmNewMail.EMailAttachmentName = PatientTemplateName;
                        frmNewMail.EMailAttachmentList = PatientTemplateFile;
                        frmNewMail.PatientFileEnquiryID = PatientEmailEnquiryID;
                        frmNewMail.EmailSubject = PatientTemplateName + " - " + cboTitle.Text + " " + txtFirstName.Text.Trim().ToUpper() + " " + txtSurname.Text.Trim().ToUpper(); ;                        
                        frmNewMail.Show();

                        //LoadPatientSentEmails();
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select documentation to email.");
                    }
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please add document to email.");
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading New Email Form error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading New Email Form error: \n" + ex.ToString());
            }
            finally
            {
                //commonFuncs = null;
            }
        }

        private void LoadPatientFileDocs(string PatientFileNo)
        {
            DataTable dtPatientDocs = commonFuncs.GetPatientFilesDocs(PatientFileNo);
            try
            {
                lstlvPatientTemplates.Items.Clear();
                lstlvPatientTemplates.Columns.Clear();
                string sDocumentName = "";
                string sDocumentFolder = "";
                string sDocumentDate = "";
                string sDocumentCreatedBy = "";
                string sDocumentID = "";
                ListViewItem lstvwItem = new ListViewItem();

                if (dtPatientDocs.Rows.Count > 0)
                {
                    foreach (DataRow drRow in dtPatientDocs.Rows)
                    {
                        sDocumentName = drRow["DOC_NAME"].ToString();
                        sDocumentFolder = drRow["DOC_POD_FOLDER"].ToString();
                        sDocumentDate = drRow["CREATION_DTTM"].ToString();
                        sDocumentCreatedBy = drRow["CREATED_BY"].ToString();
                        sDocumentID = drRow["DOCUMENT_ID"].ToString();

                        lstvwItem = new ListViewItem(sDocumentName);
                        lstvwItem.SubItems.Add(sDocumentDate);
                        lstvwItem.SubItems.Add(sDocumentCreatedBy);
                        lstvwItem.SubItems.Add(sDocumentFolder);
                        lstvwItem.SubItems.Add(sDocumentID);
                        lstlvPatientTemplates.Items.Add(lstvwItem);
                    }
                }
                PatientDocsListSetup();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Documentation error, Please contact system administrator");
                commonFuncs.ErrorLogger("Loading Patient File Documentation error: " + ex.ToString());
            }
            finally
            {
                dtPatientDocs = null;
            }
        }

        private void PatientDocsListSetup()
        {
            lstlvPatientTemplates.View = View.Details;
            lstlvPatientTemplates.Columns.Add("Document Name");
            lstlvPatientTemplates.Columns.Add("Document Date");
            lstlvPatientTemplates.Columns.Add("Document Created By");
            lstlvPatientTemplates.Columns.Add("Document Location");
            lstlvPatientTemplates.Columns.Add("Document ID");

            foreach (ColumnHeader ColHeader in lstlvPatientTemplates.Columns)
            {
                if (ColHeader.Text == "Document Location" || ColHeader.Text == "Document ID")
                {
                    ColHeader.Width = 0;
                }
                else
                {
                    ColHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            frmAppointments frmAppointment = new frmAppointments();
            frmAppointment.ShowInTaskbar = false;
            frmAppointment.StartPosition = FormStartPosition.CenterScreen;
            frmAppointment.Text = "New Appointment";
            frmAppointment.PatientFileNo = txtPatientFileNo.Text;
            frmAppointment.PatientName = txtFirstName.Text.ToUpper() + " " + txtSurname.Text.ToUpper() ;
            if (cboGuarantors.SelectedItem !=null )
            {
                frmAppointment.Guarantor = cboGuarantors.Text;     
            }
            
            frmAppointment.UserID = UserID;

            frmAppointment.Restrictions = Restrictions;

            frmAppointment.ShowDialog();
            
            LoadPatientFileAppointments(txtPatientFileNo.Text);
        }

        private void LoadPatientFileAppointments(string PatientFileNo)
        {
            lstvwAppointments.Items.Clear();
            lstvwAppointments.Columns.Clear();
            DataTable dtPatientDocs = commonFuncs.GetPatientFilesAppointments(PatientFileNo);
            try
            {
                if (dtPatientDocs.Rows.Count > 0)
                {
                    lstvwAppointments.Columns.Clear();
                    string sAppointmentSubject = "";
                    string sAppointmentDate = "";
                    string sAppointmentAddress = "";
                    string sAppointmentTimeHour = "";
                    string sTransportYN = "";
                    string sTransportType = "";
                    string sPickTimeHour = "";
                    string sCreatedDttm = "";
                    string sUserNameFull = "";
                    string sAppointmentID = "";
                    string sCalenderAppointmentID = "";
                    DateTime dtAppointmentTime = System.DateTime.Now;
                    DateTime dtPickUpTime = System.DateTime.Now;
                    DateTime dtDropOffTime = System.DateTime.Now;
                    string sCancelledYN = "";
                    string sAppointmentStatus = "";

                    ListViewItem lstvwItem = new ListViewItem();

                    foreach (DataRow drRow in dtPatientDocs.Rows)
                    {
                        sAppointmentSubject = drRow["APPOINTMENT_SUBJECT"].ToString();
                        sAppointmentDate = drRow["APPOINTMENT_DATE"].ToString();
                        sAppointmentAddress = drRow["APPOINTMENT_ADDRESS"].ToString();
                        sAppointmentTimeHour = drRow["APPOINTMENT_TIME_HOUR"].ToString();
                        sTransportYN = drRow["TRANSPORT_YN"].ToString();
                        sTransportType = drRow["TRANSPORT_TYPE_DESC"].ToString();
                        sPickTimeHour = drRow["PICK_UP_TIME_HOUR"].ToString();
                        sCreatedDttm = drRow["CREATED_DTTM"].ToString();
                        sUserNameFull = drRow["USER_FULL_NAME"].ToString();
                        sAppointmentID = drRow["APPOINTMENT_ID"].ToString();
                        sCalenderAppointmentID = drRow["CALENDER_APPOINTMENT_ID"].ToString();
                        sCancelledYN = drRow["CANCELLED_YN"].ToString();
                        sAppointmentStatus = drRow["APPOINTMENT_STATUS"].ToString();

                        //System.DateTime dtAppointToday = Convert.ToDateTime(sAppointmentDate);

                        if (drRow["APPOINTMENT_TIME"] != System.DBNull.Value)
                        {
                            dtAppointmentTime = Convert.ToDateTime(drRow["APPOINTMENT_TIME"]);
                        }

                        if (drRow["PICK_UP_TIME"] != System.DBNull.Value)
                        {
                            dtPickUpTime = Convert.ToDateTime(drRow["PICK_UP_TIME"]);
                        }

                        if (drRow["DROP_OFF_TIME"] != System.DBNull.Value)
                        {
                            dtDropOffTime = Convert.ToDateTime(drRow["DROP_OFF_TIME"]);
                        }

                        if (!sAppointmentSubject.Trim().Equals(""))
                        {
                            sAppointmentSubject = sAppointmentSubject.Replace("[-" + txtPatientFileNo.Text + "-]", "");
                        }

                        lstvwItem = new ListViewItem(sAppointmentSubject);
                        lstvwItem.SubItems.Add(sAppointmentDate);
                        lstvwItem.SubItems.Add(dtAppointmentTime.TimeOfDay.ToString());
                        lstvwItem.SubItems.Add(sAppointmentAddress);
                        lstvwItem.SubItems.Add(sTransportYN);
                        
                        if (sTransportYN.Equals("Y"))
                        {
                            lstvwItem.SubItems.Add(sTransportType);
                            lstvwItem.SubItems.Add(dtPickUpTime.TimeOfDay.ToString());
                            lstvwItem.SubItems.Add(dtDropOffTime.TimeOfDay.ToString());
                        }
                        else
                        {
                            lstvwItem.SubItems.Add(" - ");
                            lstvwItem.SubItems.Add(" - ");
                            lstvwItem.SubItems.Add(" - ");
                        }
                        lstvwItem.SubItems.Add(sCreatedDttm);
                        lstvwItem.SubItems.Add(sUserNameFull);
                        
                        if (sCancelledYN.Equals("Y"))
                        {
                            lstvwItem.SubItems.Add("CANCELLED");
                            lstvwItem.ForeColor = Color.White;
                            lstvwAppointments.Items.Add(lstvwItem).BackColor = Color.Magenta;
                        }
                        else if (sAppointmentStatus.Equals("COMPLETED"))
                        {
                            lstvwItem.SubItems.Add("COMPLETED");
                            lstvwItem.ForeColor = Color.White;
                            lstvwAppointments.Items.Add(lstvwItem).BackColor = Color.Green;
                            
                        }
                        else
                        {
                            lstvwItem.SubItems.Add("ACTIVE");
                            System.TimeSpan diffResult = System.Convert.ToDateTime(sAppointmentDate) - DateTime.Today.Date;
                            if (diffResult.Days == 0)
                            {
                                lstvwAppointments.Items.Add(lstvwItem).BackColor = Color.OrangeRed;
                            }
                            else
                            {
                                lstvwAppointments.Items.Add(lstvwItem);
                            }
                        }
                        lstvwItem.SubItems.Add(sAppointmentID);
                        lstvwItem.SubItems.Add(sCalenderAppointmentID);
                    }
                }
                PatientAppointmentListSetup();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient Appointments error, Please contact system administrator");
                commonFuncs.ErrorLogger("Loading Patient Appointments error: " + ex.ToString());
            }
            finally
            {
                dtPatientDocs = null;
            }
        }
        private void PatientAppointmentListSetup()
        {
            lstvwAppointments.View = View.Details;
            lstvwAppointments.Columns.Add("Appointment Subject");
            lstvwAppointments.Columns.Add("Appointment Date");
            lstvwAppointments.Columns.Add("Appointment Time");
            lstvwAppointments.Columns.Add("Appointment Address");
            lstvwAppointments.Columns.Add("Transport Required");
            lstvwAppointments.Columns.Add("Transport Type");
            lstvwAppointments.Columns.Add("Transport Pick-Up Time");
            lstvwAppointments.Columns.Add("Transport Drop-Off Time");
            lstvwAppointments.Columns.Add("Created Date");
            lstvwAppointments.Columns.Add("Created By");
            lstvwAppointments.Columns.Add("Appointment Status");
            lstvwAppointments.Columns.Add("APPOINTMENTID");
            lstvwAppointments.Columns.Add("CALENDERAPPOINTMENTID");

            foreach (ColumnHeader ColHeader in lstvwAppointments.Columns)
            {
                if (ColHeader.Text.Equals("APPOINTMENTID") || ColHeader.Text.Equals("CALENDERAPPOINTMENTID"))
                {
                    ColHeader.Width = 0;
                }
                else
                {
                    ColHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }

        private void lstvwAppointments_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string AppointmentID = lstGet.Items[i].SubItems[11].Text.ToString();
                        string CalenderAppointmentID = lstGet.Items[i].SubItems[12].Text.ToString();
                        if (AppointmentID.Trim().Length > 0)
                        {
                            DataTable dsAppointment = new DataTable(); ;
                            ListViewItem lvwItem;

                            dsAppointment = commonFuncs.GetAppointmentDetails(AppointmentID);
                            if (dsAppointment.Rows.Count > 0)
                            {
                                frmAppointments frmAppointment;
                                frmAppointment = new frmAppointments();
                                frmAppointment.ShowInTaskbar = false;
                                frmAppointment.StartPosition = FormStartPosition.CenterScreen;
                                frmAppointment.Text = "Edit Appointment";
                                frmAppointment.UserID = UserID;
                                frmAppointment.Restrictions = Restrictions;
                                frmAppointment.AppointmentID = Convert.ToInt32(AppointmentID);
                                frmAppointment.CalenderAppointmentID = Convert.ToInt32(CalenderAppointmentID);
                                frmAppointment.PatientFileNo = txtPatientFileNo.Text;

                                frmAppointment.PatientFileNo = txtPatientFileNo.Text;
                                frmAppointment.PatientName = txtFirstName.Text.ToUpper() + " " + txtSurname.Text.ToUpper();
                                if (cboGuarantors.SelectedItem != null)
                                {
                                    frmAppointment.Guarantor = cboGuarantors.Text;
                                }

                                if (frmAppointment.ShowDialog() == DialogResult.OK)
                                {
                                    LoadPatientFileAppointments(txtPatientFileNo.Text);
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Appointment Details error, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Loading Appointment Details error: " + ex.ToString());
            }
            finally
            {
                lstGet = null;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lstlvPatientTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAuthoriseGuarantee_Click(object sender, EventArgs e)
        {
            if (lstlvPatientTemplates.SelectedItems.Count > 0)
            {
                string PatientTemplateView = lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[3].Text.ToString();
                if (!PatientTemplateView.Equals(""))
                {
                    string sDocName = lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[0].Text.ToString();
                    if (!sDocName.Equals("") && sDocName.Contains("Guarantee of Payment"))
                    {
                        string sDocID = lstlvPatientTemplates.Items[lstlvPatientTemplates.SelectedItems[0].Index].SubItems[3].Text.ToString();
                        bool bReturn = GOPApproved(sDocID);
                        if (bReturn)
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "GOP Approved, Please proceed processing.");
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "GOP Approval Error, Please contact System Administrator.");
                        }
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select a GOP document to approve.");
                    }
                }
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select a GOP document to approve.");
            }
        }

        private bool GOPApproved(string GOPID)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            return commonFuncs.GOPApproved(GOPID);
        }

        private bool IsGOPApproved(string GOPID)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            return commonFuncs.IsGOPApproved(GOPID);
        }

        private void txtDateDischarged_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAppointmentsAudit_Click(object sender, EventArgs e)
        {
            frmAppointmentsAudit frmAppointmentAudit = new frmAppointmentsAudit();
            frmAppointmentAudit.ShowInTaskbar = false;
            frmAppointmentAudit.StartPosition = FormStartPosition.CenterScreen;
            frmAppointmentAudit.Text = "Patient File - " + txtPatientFileNo.Text + " : Appointments Audit";
            frmAppointmentAudit.PatientSubFileID = txtPatientFileNo.Text;

            frmAppointmentAudit.ShowDialog();
        }

        private void txtFileDueDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void FileDueDate(DateTime fileReceivedDttm)
        {
            AIMS.Common.CommonFunctions cmmnFuncs1 = new AIMS.Common.CommonFunctions();
            string fileDueDate = "";
            try
            {
                DateTime fileDueDt = fileReceivedDttm;
                fileDueDate = cmmnFuncs1.GetDueDate(fileReceivedDttm);
                if (!fileDueDate.Trim().Equals(""))
                {
                    DateTime dtdueDate;
                    if (DateTime.TryParse(fileDueDate, out dtdueDate))
                    {
                        txtFileDueDate.Text = fileDueDate;
                        System.TimeSpan diffResult = System.Convert.ToDateTime(fileDueDate) - DateTime.Today.Date;
                        if (diffResult.Days >=0)
                        {
                            txtFileDueDate.ForeColor = Color.Red;
                        }
                        else
                        {
                            txtFileDueDate.ForeColor = Color.Green;
                        }
                    }
                    else
                    {
                        txtFileDueDate.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                cmmnFuncs1.ErrorLogger("File-Due Date calculation Error - " + ex.ToString());
                txtFileDueDate.Text = "";
            }
            finally
            {
                cmmnFuncs1 = null;
            }
        }

        private void lnklblDOB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDateOfBirth_DoubleClick(null, null);
        }

        private void lnklblCourierDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtFileCourierDate_DoubleClick(null, null);
        }

        private void chkSentToAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSentToAdmin.Checked )
            {
                if (txtDateDischarged.Text.Trim() =="")
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient File Not Discharged.");
                    chkSentToAdmin.Checked = false; 
                }		 
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //LoadAudit();
        }

        private void chkHighCostFile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDelTemplate_Click(object sender, EventArgs e)
        {

        }

        private void lstlvwInterimNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstlvwInterimNotes_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string cccc = lstGet.Items[i].SubItems[1].Text.ToString();
                        MessageBox.Show(cccc, "Interim Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (System.Exception ex)
            {
                lstGet = null;
            }
        }

        private void lstvwAuditing_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void chkFilePending_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdInPatient_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}