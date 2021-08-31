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
    public partial class frmIndexEmail : Form
    {
        #region "Private Properties"
        string _userName = "";
        string _userID = "";
        static string AddedPatientFiles = "";
        bool bEmailAckowledged = false;
        #endregion

        #region "Public Properties"
        AIMS.Common.CommonFunctions commonFuncs;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        string _QueryFileNo = "";
        public string QueryFileNo
        {
            get { return _QueryFileNo; }
            set
            {
                _QueryFileNo = value;
            }
        }

        string _MailBoxName = "";
        public string MailBoxName
        {
            get { return _MailBoxName; }
            set
            {
                _MailBoxName = value;
            }
        }

        string _OPSQueryFileNo = "";
        public string OPSQueryFileNo
        {
            get { return _OPSQueryFileNo; }
            set
            {
                _OPSQueryFileNo = value;
            }
        }

        string _ADMINQueryFileNo = "";
        public string AdminQueryFileNo
        {
            get { return _ADMINQueryFileNo; }
            set
            {
                _ADMINQueryFileNo = value;
            }
        }

        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        string _EmailID = "";
        public string EmailID
        {
            get { return _EmailID; }
            set { _EmailID = value; }
        }

        string _IndexingDocuments = "";
        public string IndexingDocuments
        {
            get { return _IndexingDocuments; }
            set { _IndexingDocuments = value; }
        }

        string _EmailAttachments = "";
        public string EmailAttachments
        {
            get { return _EmailAttachments; }
            set { _EmailAttachments = value; }
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
        public frmIndexEmail()
        {
            InitializeComponent();
            AIMSFileAutoComplete();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                //commonFuncs = new AIMS.Common.CommonFunctions();
                if (!txtPatientFileNo.Text.Trim().Equals("") && !AddedPatientFiles.Contains(txtPatientFileNo.Text.Trim()))
                {
                    AddedPatientFiles += txtPatientFileNo.Text.Trim();
                    if (commonFuncs.ValidPatientFileNo(txtPatientFileNo.Text.Trim()))
                    {
                        lstIndexFile.Items.Add(txtPatientFileNo.Text.Trim());
                        txtPatientFileNo.Text = "";
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File No does not exist.");
                        AddedPatientFiles = AddedPatientFiles.Replace(txtPatientFileNo.Text.Trim(), "");
                    }
                }
                else
                {
                    if (!txtPatientFileNo.Text.Trim().Equals("") && AddedPatientFiles.Contains(txtPatientFileNo.Text.Trim()))
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient File No already added");
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Capture Patient File No");
                    }
                }
                txtPatientFileNo.Text = txtPatientFileNo.Text.Trim();
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Adding Patient File error, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Adding Patient File error: \n" + ex.ToString());
            }
            finally
            {
            }
        }

        private DataTable GetFiles()
        {
            DataTable dtFiles = new DataTable();
            try
            {
               commonFuncs = new AIMS.Common.CommonFunctions();
               dtFiles = commonFuncs.GetActiveFiles();
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Populating Files failed: " + ex.ToString());
            }
            return dtFiles;
        }

        void AIMSFileAutoComplete() {
            try
            {
                txtPatientFileNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPatientFileNo.AutoCompleteSource = AutoCompleteSource.CustomSource ;
                AutoCompleteStringCollection files = new AutoCompleteStringCollection();
                DataTable dtFiles = GetFiles();

                int count = dtFiles.Rows.Count;
                for(int i = 0 ; i <count; i ++)
                {
                    DataRow row = dtFiles.Rows[i];
                    files.Add((string)row["PATIENT_FILE_NO"]);
                }
                txtPatientFileNo.AutoCompleteCustomSource = files;
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Populating Files failed: " + ex.ToString());
            }
        }
        private void frmIndexEmail_Load(object sender, EventArgs e)
        {
            DataTable dtFile13 = new DataTable();
            try
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                switch (MailBoxName)
                {
                    case "OPERATIONS":
                        dtFile13 = commonFuncs.GetLimitationCodeValue("AIMS_FILE_13_QUERIES");
                        break;
                    case "ADMIN":
                        dtFile13 = commonFuncs.GetLimitationCodeValue("AIMS_ADMIN_QUERIES_FILE");
                        break;
                    case "TEST":
                        dtFile13 = commonFuncs.GetLimitationCodeValue("AIMS_ADMIN_QUERIES_FILE");
                        break;
                }
                
                QueryFileNo =  dtFile13.Rows[0]["LIMITATION_VALUE"].ToString();
                AddedPatientFiles = "";
            }
            catch (System.Exception ex)
            {
            }
            finally 
            {
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            DataTable dtFileOperatorDetails = new DataTable();
            string InstrumentationStep = "";
            string ErrorousFiles = "";
            if (commonFuncs == null)
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
            }
            try
            {
                bool bPatientEmailSaved = false;
                string PatientFileNo = "";

                InstrumentationStep =  DateTime.Now.TimeOfDay.ToString() + @" - STEP 1";
                if (lstIndexFile.Items.Count.Equals(0))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File(s) not captured.");
                    return;
                } 
                else
                {
                    if (MessageBox.Show("Continue saving email for the Patient File ?","Patient Email Save Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dtFileOperatorDetails = new DataTable();
                        string FilesNotAllocated = "";
                        string AfterHoursFile = "";

                        for (int i = 0; i < lstIndexFile.Items.Count; i++)
                        {
                            PatientFileNo = lstIndexFile.Items[i].ToString();
                            dtFileOperatorDetails = commonFuncs.Get_Patient_File_Operator(PatientFileNo);
                            if (dtFileOperatorDetails.Rows[0]["FILE_OPERATOR_TO_USERID"].ToString().Equals(""))
                            {
                                if (!PatientFileNo.Equals(QueryFileNo))
                                {
                                    FilesNotAllocated += PatientFileNo + "\n";    
                                }
                            }
                            AfterHoursFile += dtFileOperatorDetails.Rows[0]["AFTER_HOURS_FILE"].ToString();
                        }

                        InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2";

                        string EmailStorageFolder ="";
                        bool EmailPODConstruction = AIMSEWSPODConstruct(ref EmailStorageFolder, EmailID, commonFuncs);
                        InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 3";
                        //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());

                        if (!EmailPODConstruction)
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "AIMS Email POD Error, Please Contact System Administrator.");
                            return;
                        }

                        string UrgentEmail = chkUrgentEmail.Checked ? "Y":"N";
                        string File13Query = chkQueryFile.Checked ? "Y" : "N";

                        string PatientEmailEnquiryID = "";
                        //loop through files that are captured for indexing
                        for (int i = 0; i < lstIndexFile.Items.Count; i++)
                        {
                            PatientFileNo = lstIndexFile.Items[i].ToString();
                            //link em   ail to specific patient file
                            bPatientEmailSaved = commonFuncs.AddPatientFileEmail(PatientFileNo, EmailID, ref PatientEmailEnquiryID, UrgentEmail, File13Query, UserID, MailBoxName.ToUpper());
                            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 4";
                            //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());
                            if (!bPatientEmailSaved || PatientEmailEnquiryID.Equals(""))
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Adding Patient Email Failed. Please try again.");
                                break;
                            }
                            else
                            {
                                bool EmailAttachment = ExtractEmailAttachmentToPOD(EmailStorageFolder, PatientEmailEnquiryID);
                                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 5";
                                //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());
                                if (EmailAttachment)
                                {
                                    bPatientEmailSaved = commonFuncs.EmailIndexedFlag(EmailID);
                                    InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 6";
                                    //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());
                                    if (!bPatientEmailSaved)
                                    {
                                        ErrorousFiles += PatientFileNo + "\n"; 
                                        //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Indexing Email Failed1. Please try again.");
                                    }
                                }
                                else
                                {
                                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Indexing Email Failed2. Please try again.");
                                }
                            }
                        }

                        if (ErrorousFiles == "")
                        {
                            if (bEmailAckowledged)
                            {
                                
                            }
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Email indexed successfully.");
                            this.DialogResult = DialogResult.OK;
                            commonFuncs = null;
                            this.Close();
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Indexing Email Failed for " + ErrorousFiles  + "\n. Please try again.");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Indexing Email Failed3. Please try again.");
                commonFuncs.ErrorLogger("Indexing Email Failed: " + ex.ToString());
            }
            finally
            {
                btnConfirm.Enabled = true;
                dtFileOperatorDetails.Dispose();
                //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());
                //commonFuncs = null;
            }
        }

        private void lstIndexFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIndexCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            commonFuncs = null;
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string StrFileNo = "";
                //commonFuncs = new AIMS.Common.CommonFunctions();
                if (!lstIndexFile.SelectedItems.Count.Equals(0))
                {
                    for (int i = 0; i < lstIndexFile.SelectedItems.Count; i++)
                    {
                        StrFileNo = lstIndexFile.SelectedItems[i].ToString();
                        lstIndexFile.Items.Remove(lstIndexFile.SelectedItems[i].ToString());
                        AddedPatientFiles = AddedPatientFiles.Replace(StrFileNo, "");
                    }
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "No Patient File Selected");
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error removing the Patient File, Please try again.");
                commonFuncs.ErrorLogger("Error removing the Patient File: " + ex.ToString());
            }
        }

        private string IndexDocumentsConfirm(string IndexingDocument, string PatientEnquiryID)
        {
            string DocTypesList = "";
            try
            {
                string[] arrIndexDocs = IndexingDocument.Split(new Char[1] { '+' });
                string[] arrIndexDocIndex = new string[0];
                bool FirstTime = true;

                Int16 docCount = 1;
                foreach (string IndexFile in arrIndexDocs)
                {
                    if (!IndexFile.Trim().Equals(""))
                    {

                    }
                }
            }
            finally
            {

            }
            return DocTypesList;
        }

        private void txtPatientFileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatientFileNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //commonFuncs = new AIMS.Common.CommonFunctions();
                    if (!txtPatientFileNo.Text.Trim().Equals("") && !AddedPatientFiles.Contains(txtPatientFileNo.Text.Trim()))
                    {
                        AddedPatientFiles += txtPatientFileNo.Text.Trim();
                        if (commonFuncs.ValidPatientFileNo(txtPatientFileNo.Text.Trim()))
                        {
                            lstIndexFile.Items.Add(txtPatientFileNo.Text.Trim());
                            txtPatientFileNo.Text = "";
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File No does not exist.");
                            AddedPatientFiles = AddedPatientFiles.Replace(txtPatientFileNo.Text.Trim(), "");
                        }
                    }
                    else
                    {
                        if (!txtPatientFileNo.Text.Trim().Equals("") && AddedPatientFiles.Contains(txtPatientFileNo.Text.Trim()))
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient File No already added");
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Capture Patient File No");
                        }
                    }
                    txtPatientFileNo.Text = txtPatientFileNo.Text.Trim();
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Adding Patient File error, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Adding Patient File error: \n" + ex.ToString());
            }
        }

        private bool ExtractEmailAttachmentToPOD(string PODFileStructure, string PatientEnquiryID) {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            bool ReturnValue = false;
            string EmailIndexingFile = "";
            string AttachmentFileName = "";
            string DocumentTypeID = "";
            try
            {
                string[] arrIndexDocs = EmailAttachments.Split(new Char[] { ',' });
                string[] arrIndexDocIndex = new string[0];
                
                foreach (string IndexFile in arrIndexDocs)
                {
                    if (!IndexFile.Trim().Equals(""))
                    {
                        arrIndexDocIndex = IndexFile.Split(new Char[] { '|' });
                        DataTable dtEmailAttachFile = new DataTable();
                        
                        dtEmailAttachFile  = commonFuncs.GetEmailIndexFileLocation(arrIndexDocIndex[1].ToString());
                        //DataTable dtLimitationCode = commonFuncs.GetLimitationCodeValue("EMAIL_ATTACHMENT_DOC_TYPE");
                        //if (dtLimitationCode.Rows.Count > 0)
                        //{
                        //    DocumentTypeID = dtLimitationCode.Rows[0]["LIMITATION_VALUE"].ToString();
                        //}
                        //if (DocumentTypeID.Equals(""))
                        //{
                        //    DocumentTypeID = arrIndexDocIndex[0].ToString();
                        //}
						DocumentTypeID = arrIndexDocIndex[0].ToString();
                        EmailIndexingFile = dtEmailAttachFile.Rows[0]["ATTACHMENT_LOCATION"].ToString();
                        AttachmentFileName = Path.GetFileName(EmailIndexingFile);
                        if (File.Exists(EmailIndexingFile))
                        {
                            if (!PODFileStructure.EndsWith(@"\")){
                                PODFileStructure += @"\";
                            }
                            try
                            {
                                File.Copy(EmailIndexingFile, PODFileStructure + AttachmentFileName, true);
                                File.SetAttributes(PODFileStructure + AttachmentFileName, FileAttributes.Normal);
                            }
                            catch (System.IO.IOException ioEX)
                            {
                                ReturnValue = false;
                                commonFuncs.ErrorLogger("ExtractEmailAttachmentToPOD FILE COPY FAILED - \n" + ioEX.ToString());
                                return false;
                            }

                            bool EmailPODDelivered = commonFuncs.EmailAttachmentPODDelivery(PODFileStructure + AttachmentFileName, DocumentTypeID, PatientEnquiryID);
                            if (EmailPODDelivered)
                            {
                                ReturnValue = true;
                            }
                            else
                            {
                                ReturnValue = false;
                                commonFuncs.ErrorLogger("ExtractEmailAttachmentToPOD Method Error - Saving the Email Documents"); 
                            }
                        }
                        
                        dtEmailAttachFile.Dispose();
                    }
                } 
            }
            catch (System.Exception ex)
            {
                ReturnValue = false;
                commonFuncs.ErrorLogger("ExtractEmailAttachmentToPOD Method Error - \n" + ex.ToString()); 
            }
            return ReturnValue;
        }

        public bool AIMSEWSPODConstruct(ref string EmailStorageFolder, string EmailID, AIMS.Common.CommonFunctions commonFuncs)
        {
            string InstrumentationStep = "";
            
            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2 - a";
            //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());

            DataTable dtPODData = GetPODData(EmailID);
            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2 - b";
            //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());
            bool ReturnValue = false;
            try
            {
                string PODSizeCheckError = "";
                string PodDiskLetter = "";
                string PodEmailGUID = "";
                long PodCounter = 0;
                string PODFolder = "";
                string EmailMailBoxID = "";

                PodCounter = System.Convert.ToInt64(dtPODData.Rows[0]["MAILBOX_POD_COUNTER"]);
                PodDiskLetter = dtPODData.Rows[0]["MAILBOX_POD_DISK_LETTER"].ToString().ToUpper();
                PodEmailGUID = dtPODData.Rows[0]["EMAIL_GUID"].ToString().ToUpper();
                EmailMailBoxID = dtPODData.Rows[0]["MAILBOX_ID"].ToString();

                PODFolder = PodDiskLetter + @":\POD" + PodCounter.ToString() + @"\";
                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2 - c";
                //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());

                //create the POD Directory 
                if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                //double PodByteSize = commonFuncs.GetPODDirectorySize(PODFolder, ref PODSizeCheckError);
                double PodByteSize = 0;

                if (!PODSizeCheckError.Equals(""))
                {
                    //ErrorLogger("AIMSEWSPODConstruct - Calculating POD Size Structure ERROR: \n" + PODSizeCheckError);
                    return false;
                }
                //POD Folder must be greater than 4 Gigs, 
                if (PodByteSize >= 3999999999)
                {
                    PodCounter++;
                    //UpdateMailBoxPODCounter(EmailMailBoxID, PodCounter.ToString());
                    PODFolder = PodDiskLetter + @":\POD" + PodCounter.ToString() + @"\";

                    //create the POD Directory 
                    if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                }

                string sDir1 = PodEmailGUID.Substring(0, 1);
                string sDir2 = PodEmailGUID.Substring(1, 1);
                if (!System.IO.Directory.Exists(PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID))
                {
                    System.IO.Directory.CreateDirectory(PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID);
                }
                EmailStorageFolder = PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID;
                ReturnValue = true;
                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2 - d";
                //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());
            }
            catch (System.Exception ex)
            {
                //ErrorLogger("AIMSEWSPODConstruct Function Error: \n" + ex.ToString());
                ReturnValue = false;
            }
            finally
            {
                dtPODData.Dispose();
            }
            return ReturnValue;
        }

        public DataTable GetPODData(string emailID)
        {
            DataTable dtPODDetails = new DataTable();
            try
            {
                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonFuncsDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                dtPODDetails = commonFuncsDAL.GetPODData(emailID);
            }
            finally
            {
            }
            return dtPODDetails;
        }

        private void chkUrgentEmail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkQueryFile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQueryFile.Checked)
            {
                lstIndexFile.Items.Add(QueryFileNo);
            }
            else
            {
                for (int i = 0; i < lstIndexFile.Items.Count; i++)
                {
                    if (lstIndexFile.Items[i].ToString() == QueryFileNo)
                    {
                        lstIndexFile.Items.Remove(lstIndexFile.Items[i].ToString());
                    }
                }
            }
        }

        private void chkAcknowledgeEmail_CheckedChanged(object sender, EventArgs e)
        {
            bEmailAckowledged = chkAcknowledgeEmail.Checked ? true : false;
        }
    }
}