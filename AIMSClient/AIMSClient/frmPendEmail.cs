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
    public partial class frmPendEmail : Form
    {
        #region "Private Properties"
        string _userName = "";
        string _userID = "";
        static string AddedPatientFiles = "";
        #endregion

        #region "Public Properties"
        AIMS.Common.CommonFunctions commonFuncs;
        string _MailBoxName = "";
        public string MailBoxName
        {
            get { return _MailBoxName; }
            set
            {
                _MailBoxName = value;
            }
        }

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

        public frmPendEmail()
        {
            InitializeComponent();
        }

        private void lblPendDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPendDate_DoubleClick(null, null);
             
        }

        private void txtPendDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtPendDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtPendDate.Focus();
        }

        private void txtPendDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPendEmail_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            bool FileLoad = false;
            try
            {
                if (txtPendDate.Text.Trim().Equals(""))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Pend date required.");
                    txtPendReasonComment.Focus();
                    return;
                }

                if (txtPendReasonComment.Text.Trim().Equals(""))
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Pend reason or comment required.");
                    txtPendReasonComment.Focus();
                    return;
                }

                commonFuncs = new AIMS.Common.CommonFunctions();
                bool bPatientEmailSaved = false;
                string PatientFileNo = "";

                if (MessageBox.Show("Continue pending email. . .This will create a new file?", "Email Pend Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string EmailStorageFolder = "";
                    bool EmailPODConstruction = AIMSEWSPODConstruct(ref EmailStorageFolder);

                    if (!EmailPODConstruction)
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "AIMS Email POD Error, Please Contact System Administrator.");
                        return;
                    }

                    string PatientEmailEnquiryID = "";

                    FileLoad = commonFuncs.CreatePendedNewFile(ref PatientFileNo, UserID, txtPendDate.Text);
                    if (FileLoad)
                    {
                        //link em   ail to specific patient file
                        bPatientEmailSaved = commonFuncs.AddPatientFileEmail(PatientFileNo, EmailID, ref PatientEmailEnquiryID,"N" ,"N", UserID, MailBoxName.ToUpper());
                        if (!bPatientEmailSaved || PatientEmailEnquiryID.Equals(""))
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Adding Patient Email Failed. Please try again.");
                            return;
                        }
                        else
                        {
                            bool EmailAttachment = ExtractEmailAttachmentToPOD(EmailStorageFolder, PatientEmailEnquiryID);
                            if (EmailAttachment)
                            {
                                bPatientEmailSaved = commonFuncs.EmailIndexedFlag(EmailID);
                                if (bPatientEmailSaved)
                                {
                                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Email Pending successfully.");
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Indexing Email Failed1. Please try again.");
                                }
                            }
                            else
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Indexing Email Failed2. Please try again.");
                            }
                        } 
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Error pending email, Please contact system Administrator.");
                commonFuncs.ErrorLogger("Error pending email: " + ex.ToString());
            }
            finally
            {
                commonFuncs = null;
            }
        }

        private bool AIMSEWSPODConstruct(ref string EmailStorageFolder)
        {
            DataTable dtPODData = commonFuncs.GetPODData(EmailID);
            commonFuncs = new AIMS.Common.CommonFunctions();
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

                //create the POD Directory 
                if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                double PodByteSize = commonFuncs.GetPODDirectorySize(PODFolder, ref PODSizeCheckError);

                if (!PODSizeCheckError.Equals(""))
                {
                    commonFuncs.ErrorLogger("AIMSEWSPODConstruct - Calculating POD Size Structure ERROR: \n" + PODSizeCheckError);
                    return false;
                }
                //POD Folder must be greater than 4 Gigs, 
                if (PodByteSize >= 3999999999)
                {
                    PodCounter++;
                    commonFuncs.UpdateMailBoxPODCounter(EmailMailBoxID, PodCounter.ToString());
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
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("AIMSEWSPODConstruct Function Error: \n" + ex.ToString());
                ReturnValue = false;
            }
            finally
            {
                dtPODData.Dispose();
            }
            return ReturnValue;
        }

        private bool ExtractEmailAttachmentToPOD(string PODFileStructure, string PatientEnquiryID)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
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

                        dtEmailAttachFile = commonFuncs.GetEmailIndexFileLocation(arrIndexDocIndex[1].ToString());
                        DocumentTypeID = arrIndexDocIndex[0].ToString();
                        EmailIndexingFile = dtEmailAttachFile.Rows[0]["ATTACHMENT_LOCATION"].ToString();
                        AttachmentFileName = Path.GetFileName(EmailIndexingFile);
                        if (File.Exists(EmailIndexingFile))
                        {
                            if (!PODFileStructure.EndsWith(@"\"))
                            {
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

        private void btnIndexCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}