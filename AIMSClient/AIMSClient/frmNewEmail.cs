using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraRichEdit.SpellChecker;
using DevExpress.XtraSpellChecker.Native;
using DevExpress.XtraSpellChecker;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace AIMSClient
{
    public partial class frmNewEmail : Form
    {
        private NetSpell.SpellChecker.Spelling spelling;
        private NetSpell.SpellChecker.Dictionary.WordDictionary wordDictionary;

        AIMS.Common.CommonFunctions commonFuncs;
        public frmNewEmail()
        {
            InitializeComponent();
            AIMSEmailFromAutoComplete();
        }

        public string PatienSentEmailID = "";
        
        private string _restrictions = string.Empty;
        public string Restrictions
        {
            get { return _restrictions; }
            set
            {
                _restrictions = value;
            }
        }

        string _PatientSubFileID = "";
        public string PatientSubFileID
        {
            get { return _PatientSubFileID; }
            set { _PatientSubFileID = value; }
        }

        string _emailSubject = "";
        public string EmailSubject
        {
            get { return _emailSubject; }
            set
            {
                _emailSubject = value;
            }
        }

        string _SentEmailCorrespondence = "";
        public string SentEmailCorrespondence
        {
            get { return _SentEmailCorrespondence; }
            set
            {
                _SentEmailCorrespondence = value;
            }
        }

        string _EMailAttachmentList = "";
        public string EMailAttachmentList
        {
            get { return _EMailAttachmentList; }
            set
            {
                _EMailAttachmentList = value;
            }
        }

        string _EMailAttachmentName = "";
        public string EMailAttachmentName
        {
            get { return _EMailAttachmentName; }
            set
            {
                _EMailAttachmentName = value;
            }
        }

        string _UserName = "";
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
            }
        }

        string _loggedOnUser = "";
        public string LoggedOnUser
        {
            get { return _loggedOnUser; }
            set
            {
                _loggedOnUser = value;
            }
        }

        string _BccEmailAddress = "";
        public string BccEmailAddress
        {
            get { return _BccEmailAddress; }
            set
            {
                _BccEmailAddress = value;
            }
        }

        string _patientFileNo = "";
        public string PatientFileNo
        {
            get { return _patientFileNo; }
            set
            {
                _patientFileNo = value;
            }
        }

        string _patientDOB = "";
        public string PatientDOB
        {
            get { return _patientDOB; }
            set
            {
                _patientDOB = value;
            }
        }

        string _patientName = "";
        public string PatientName
        {
            get { return _patientName; }
            set
            {
                _patientName = value;
            }
        }

        string _patientFileEnquiryID = "";
        public string PatientFileEnquiryID
        {
            get { return _patientFileEnquiryID; }
            set
            {
                _patientFileEnquiryID = value;
            }
        }

        string _emailFrom = "";
        public string EmailFrom
        {
            get { return _emailFrom; }
            set
            {
                _emailFrom = value;
            }
        }

        private void frmNewEmail_Load(object sender, EventArgs e)
        {
            AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
            DataTable dtLimitationInfo = new DataTable();
            string defaultMailboxId = "";
            Int32 mailboxId = 0;
            try
            {
                //dtLimitationInfo = commonFuncs.GetLimitationCodeValue("USER_ADMIN_DEFAULT_MAILBOX");
                //if (dtLimitationInfo.Rows.Count >0)
                //{
                //    defaultMailboxId = dtLimitationInfo.Rows[0]["LIMITATION_VALUE"].ToString();
                //    if (defaultMailboxId.Equals("") )
                //    {
                //        if (defaultMailboxId.Contains(UserName))
                //        {
                //            string[] arrSaveDocs = defaultMailboxId.Split(new Char[] { ';' });
                //                foreach (string IndexFile in arrSaveDocs)
                //                {
                //                    if (!IndexFile.Trim().Equals(""))
                //                    {
                //                        mailboxId = System.Convert.ToInt32(IndexFile);
                //                        cboNewEmailFrom.SelectedValue = mailboxId;
                //                    }
                //                }
                //        }
                //    }
                //}
                //dtLimitationInfo = commonFuncs.GetLimitationCodeValue("USER_OPS_DEFAULT_MAILBOX");

                txtPatientFileNo.Text = "[-" + PatientFileNo + "-]";
                emailBody.HtmlText = @"<br/><br/>#EMAIL_SIGNATURE#";
                LoadEmailSenders();
                LoadEmailDetails();
                EmailAttachListSetup();
                
                if (!EMailAttachmentList.Equals(""))
                {
                    commonFuncs = new AIMS.Common.CommonFunctions();
                    string EmailBody = commonFuncs.AIMSDocumentationEmailBody(PatientFileNo, PatientName, UserName, EMailAttachmentName);
                    if (!EmailBody.Trim().Equals(""))
                    {
                        emailBody.HtmlText = @EmailBody;
                    }
                    EmailAttachmentsAdd(EMailAttachmentName, EMailAttachmentList);
                }
                txtNewEmailTo.Focus();
                try
                {
                    cboNewEmailFrom.SelectedIndex = 0;
                }
                catch (Exception)
                {
                }
                txtNewEmailSubject.Text = EmailSubject;
                chkCCOPS.Checked = true;
            }
            catch (System.Exception ex)
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading New Email Form error, Please contact System Administrator: " + "\n" + ex.ToString());
                commonFuncs.ErrorLogger("Loading New Email Form error: \n" + ex.ToString());
            }
            finally 
            {
                dtLimitationInfo.Dispose();
                commonFuncs = null;
                this.Text = "[-" + PatientFileNo + "-]";
            }
        }

        private void EmailAttachListSetup()
        {
            lstEmailAttachment.Columns.Clear();
            lstEmailAttachment.Items.Clear();
            lstEmailAttachment.Columns.Add("Attachment", Convert.ToInt32(lstEmailAttachment.Width * 0.4), HorizontalAlignment.Left);
            lstEmailAttachment.Columns.Add("AttachmentPATH", 0, HorizontalAlignment.Left);
        }

        private void EmailAttachmentsAdd(string EmailAttachmentName, string AttachmnentFileName)
        {
            try
            {
                ListViewItem lstVwItem = new ListViewItem(EmailAttachmentName);
                lstVwItem.SubItems.Add(AttachmnentFileName);
                lstEmailAttachment.Items.Add(lstVwItem);
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
        }

        private void LoadEmailSenders()
        {
            try
            {
                DataTable dtEmailSenders = new DataTable();
                commonFuncs = new AIMS.Common.CommonFunctions();
                dtEmailSenders = commonFuncs.GetEmailSenders(LoggedOnUser);

                if (dtEmailSenders.Rows.Count > 0)
                {
                    cboNewEmailFrom.DataSource = dtEmailSenders;
                    cboNewEmailFrom.DisplayMember = "EMAIL_FROM_NAME";
                    cboNewEmailFrom.ValueMember = "EMAIL_FROM_ID";
                    //cboNewEmailFrom.SelectedValue = 1;
                }
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading Email From List, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Error loading Email From List \n" + ex.ToString());
            }
            finally
            {
                commonFuncs = null;
            }
        }

        private void txtNewEmailTo_TextChanged(object sender, EventArgs e)
        {
        }

        private void LoadEmailDetails()
        {
            try
            {
                this.Text = "";
                //txtNewEmailSubject.Text = EmailSubject;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        private void btnNewEmailSend_Click(object sender, EventArgs e)
        {
            bool bEmailSent = false;
            commonFuncs = new AIMS.Common.CommonFunctions();
            if (!chkEmailSignatue.Checked )
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select Email Signature");
                return;
            }
            if (ValidateControl())
            {
                SendEmailNow();
            }
        }

        private bool SendEmailNow()
        {
            string EmailToCC = "";
            DataTable dtLimitationInfo = new DataTable();
            bool bEmailSent = false;
            string EmailAttachments = "";
            btnNewEmailSend.Enabled = false;
            
            string PodEmailGUID = System.Guid.NewGuid().ToString();
            string PODTargetFolder = "";
            bool bPODPass = false;
            commonFuncs = new AIMS.Common.CommonFunctions();
            string InstrumentationStep = "";
            BccEmailAddress = "";
            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 1";
            commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
            try
            {
                dtLimitationInfo = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_POD_SENT_EMAIL");
                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2";
                commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

                if (dtLimitationInfo.Rows.Count > 0)
                {
                    string SentEmailsPODFolder = dtLimitationInfo.Rows[0]["LIMITATION_VALUE"].ToString();

                    string sDir1 = PodEmailGUID.Substring(0, 1);
                    string sDir2 = PodEmailGUID.Substring(1, 1);
                    if (!System.IO.Directory.Exists(SentEmailsPODFolder + @"POD" + @"\" + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID))
                    {
                        System.IO.Directory.CreateDirectory(SentEmailsPODFolder + @"POD" + @"\" + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID);
                    }

                    PODTargetFolder = SentEmailsPODFolder + @"POD" + @"\" + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID + @"\";
                }

                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 3";
                commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                
                //if (ValidateControl())
                //{
                    if (chkSpellCheck.Checked)
                    {
                        //SpellCheck();
                    }
                    txtNewEmailTo.Text = txtNewEmailTo.Text.Replace(" ", "");

                    InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 4";
                    commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

                    EmailAttachments = GetEmailAttachments();

                    InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 5";
                    commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

                    txtNewEmailSubject.Text = txtNewEmailSubject.Text.Replace("[-" + PatientFileNo + "-]", "");
                    txtNewEmailSubject.Text = "[-" + PatientFileNo + "-]" + " " + txtNewEmailSubject.Text.Trim();
                    //txtNewEmailSubject.Text = txtPatientFileNo.Text + " " + txtNewEmailSubject.Text;
                    BccEmailAddress = "";
                    //If you need to copy OPS team
                    if (chkCCOPS.Checked)
                    {
                        InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 6";
                        commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                        
                        if (cboNewEmailFrom.SelectedItem != null)
                        {
                            switch (cboNewEmailFrom.Text)
                            {
                                case "Test@AIMS.org.za":
                                    dtLimitationInfo = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_ADMIN_TEAM_EMAIL_ADDRESS");
                                    break;
                                case "Admin@AIMS.org.za":
                                    dtLimitationInfo = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_ADMIN_TEAM_EMAIL_ADDRESS");
                                    break;
                                case "Operations@AIMS.org.za":
                                    dtLimitationInfo = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_OPS_TEAM_EMAIL_ADDRESS");
                                    break;
                                default:
                                    dtLimitationInfo = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_OPS_TEAM_EMAIL_ADDRESS");
                                    //chkCCOPS.Checked = false;
                                    break;
                            }
                        }

                        InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 7";
                        commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

                        if (dtLimitationInfo.Rows.Count > 0)
                        {
                            EmailToCC = dtLimitationInfo.Rows[0]["LIMITATION_VALUE"].ToString();
                            BccEmailAddress = EmailToCC;
                            //EmailToCC = "";
                        }
                    }

                    if (EmailToCC.Trim().Equals(""))
                    {
                        EmailToCC = txtEmailToCC.Text;
                    }
                    else
                    {
                        EmailToCC = EmailToCC + ";" + txtEmailToCC.Text.Replace(EmailToCC,"");
                    }

                    string emailTo = txtNewEmailTo.Text;
                    commonFuncs.cleanEmailRecipient(ref emailTo, ref EmailToCC, BccEmailAddress);

                    if (!EmailAttachments.Trim().Equals("") && PatientDOB.Trim().Equals(""))
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient Date-Of-Birth missing. Correct Format: DD/MM/YYYY");
                        return false;
                    }

                    if (chkEmailSignatue.Checked)
                    {
                        bool addPassNote = !EmailAttachments.Trim().Equals("") ? true : false;
                        string emailSignature = commonFuncs.EmailSignature(LoggedOnUser, addPassNote);
                        if (!emailSignature.Equals(""))
                        {
                            emailBody.HtmlText = emailBody.HtmlText.Replace("#EMAIL_SIGNATURE#", "<br/><br/>" + emailSignature).Replace("font-family:Times New Roman", "font-family:Calibri");
                        }
                    }

                    //emailBody.HtmlText = emailBody.HtmlText.Replace("font-family:Times New Roman", "font-family:Calibri");
                    //emailBody.HtmlText = emailBody.HtmlText.Replace("font-family:Arial", "font-family:Calibri");
                    //emailBody.HtmlText = emailBody.HtmlText.Replace("font-family:Verdana", "font-family:Calibri");

                    InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 8";
                    commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

                    bEmailSent = commonFuncs.SendEmail(emailBody.HtmlText, cboNewEmailFrom.Text, cboNewEmailFrom.Text, txtNewEmailSubject.Text, emailTo, EmailAttachments, false, EmailToCC, BccEmailAddress, PatientFileNo, PatientDOB, true );
                    
                    InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 9";
                    commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

                    if(bEmailSent)
                    {
                        InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 10";
                        commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                        bEmailSent = SaveSentEmail();
                        InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 11";
                        commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                        if (bEmailSent)
                        {
                            if (!EmailAttachments.Equals(""))
                            {
                                string[] arrSaveDocs = EmailAttachments.Split(new Char[] { ';' });
                                foreach (string IndexFile in arrSaveDocs)
                                {
                                    if (!IndexFile.Trim().Equals(""))
                                    {
                                        try
                                        {
                                            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 12";
                                            commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                                            File.SetAttributes(IndexFile, FileAttributes.Normal);
                                            File.Copy(IndexFile, PODTargetFolder + Path.GetFileName(IndexFile));
                                            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 13";
                                            commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

                                            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 14";
                                            commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                                            bPODPass = commonFuncs.EmailSentAttachmentPODDelivery(PODTargetFolder + Path.GetFileName(IndexFile), PatienSentEmailID);
                                            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 15";
                                            commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                                            if (!bPODPass)
                                            {
                                                commonFuncs.ErrorLogger("Sent EMAIL Attachment could not POD: FROM: " + IndexFile + " ### TO: " + PODTargetFolder + Path.GetFileName(IndexFile));
                                            }
                                        }
                                        catch (IOException ex )
                                        {
                                            commonFuncs.ErrorLogger("IO: File COPY EXCEPTION: FROM: " + IndexFile + " ### TO: " + PODTargetFolder + Path.GetFileName(IndexFile));
                                            commonFuncs.ErrorLogger(ex.ToString());
                                        }
                                    }
                                }
                            }
                            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 16";
                            commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                            string SentEmailDttm = System.DateTime.Today.ToString("dd-MMM-yyyy");
                            string SentEmailSubject = commonFuncs.ReplaceMultiple(txtNewEmailSubject.Text, @"/", @"\n", ";", ",", "*", "(", ")", ",", "~", "!", "@", "#", "$", "%", "^", "&", "?", "<", ">", "_", "|", ":", "/");
                            SentEmailSubject = SentEmailSubject.Replace("/", " ");
                            string EmailFile = @PODTargetFolder + "Email Correspondence Sent - " + SentEmailSubject + ".html";

                            commonFuncs.CreateEmailCorrespondence(ref EmailFile, emailBody.HtmlText, @PODTargetFolder, "Email Correspondence Sent - " + SentEmailSubject + ".html");
                            bPODPass = commonFuncs.EmailSentAttachmentPODDelivery(EmailFile, PatienSentEmailID);

                            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 17";
                            commonFuncs.ErrorLogger("Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                            
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Email Sent successfully.");
                            SentEmailCorrespondence = emailBody.HtmlText;
                            this.Close();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email transmission error, Please contact System Administrator.");
                            //this.DialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email transmission error, Please contact System Administrator.");
                        //this.DialogResult = DialogResult.Cancel;
                    }
                //}
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email could not be sent, Please try again");
                commonFuncs.ErrorLogger("Email could not be sent: \n" + ex.ToString());
                this.DialogResult = DialogResult.Cancel;
            }
            finally 
            {
                btnNewEmailSend.Enabled = true;
                dtLimitationInfo.Dispose();
            }
            return bEmailSent;
        }

        private bool SaveSentEmail()
        {
            bool bEmailSaved = false;
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                bEmailSaved = commonFuncs.SaveSentEmail(ref PatienSentEmailID, PatientFileNo, txtNewEmailTo.Text.Trim(), cboNewEmailFrom.SelectedValue.ToString(), PatientFileEnquiryID, txtNewEmailSubject.Text.Trim(), LoggedOnUser, "");
            }
            catch (System.Exception ex)
            {
                bEmailSaved = false;
            }
            return bEmailSaved;
        }

        private void lnkAttachFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            if (PatientDOB.Trim().Equals(""))
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture Date-Of-Birth before attaching documents to email.");
                return;
            }

            string strFileName = "";
            string strFileFullPath = "";
            ListViewItem lstIvw = new ListViewItem();
            try
            {
                //First, declare a variable to hold the user’s file selection.
                String input = string.Empty;

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All files (*.*)|*.*|Word Documents files (*.doc)|*.doc|Excel Documents files (*.xls)|*.xls|Excel 2010 (*.xlsx)|*.xlsx|PDF File (*.pdf)|*.pdf";

                //Set the starting directory and the title. 
                dialog.InitialDirectory = @"c:\AIMS Recorder"; dialog.Title = "Select an attachment";
                //Present to the user. 

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    strFileName = Path.GetFileName(dialog.FileName);
                    strFileFullPath = dialog.FileName;
                }

                AIMS.Common.CommonFunctions cmmnFuncs = new AIMS.Common.CommonFunctions();
                cmmnFuncs.killProtectedFiles(Path.GetDirectoryName(strFileFullPath), true);

                if (!strFileName.Trim().Equals(""))
                {
                    lstIvw = lstEmailAttachment.Items.Add(strFileName);
                    lstIvw.SubItems.Add(strFileFullPath);
                    lstIvw.Checked = true;

                    foreach (ColumnHeader ch in lstEmailAttachment.Columns)
                    {
                        if (ch.Text.Equals("AttachmentPATH"))
                        {
                            ch.Width = 0;
                        }
                        else
                        {
                            ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email attachment failed, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Email attachment failed: \n" + ex.ToString());
            }
        }

        private bool ValidateControl()
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            bool returnVal = true;
            errProv.Clear();
            try
            {
                if (cboNewEmailFrom.SelectedIndex < 0)
                {
                    errProv.SetError(cboNewEmailFrom, "Please select mail Sender");
                    cboNewEmailFrom.Focus();
                    returnVal = false;
                    return false;
                }
                if (cboNewEmailFrom.Text.Equals("") )
                {
                    errProv.SetError(cboNewEmailFrom, "Please select mail Sender");
                    cboNewEmailFrom.Focus();
                    returnVal = false;
                    return false ;                    
                }
                if (txtNewEmailTo.Text.Trim().Equals(""))
                {
                    errProv.SetError(txtNewEmailTo, "Please enter recipient email address");
                    txtNewEmailTo.Focus();
                    returnVal = false;
                }

                if (!txtNewEmailTo.Text.Trim().Equals(""))
                {
                    if (!txtNewEmailTo.Text.Contains(";"))
                    {
                        if (!commonFuncs.ValidEmailAddress(txtNewEmailTo.Text.Trim()))
                        {
                            errProv.SetError(txtNewEmailTo, "Please enter valid email address");
                            txtNewEmailTo.Focus();
                            returnVal = false;
                        }
                    }
                    else
                    {
                        string[] arrToAddresses = txtNewEmailTo.Text.Trim().Split(new Char[] { ';' });

                        foreach (string EmailAddress in arrToAddresses)
                        {
                            if (!EmailAddress.Trim().Equals(""))
                            {
                                if (!commonFuncs.ValidEmailAddress(EmailAddress.Trim()))
                                {
                                    errProv.SetError(txtNewEmailTo, "Please enter valid email address");
                                    txtNewEmailTo.Focus();
                                    returnVal = false;
                                }
                            }
                        }
                    }
                }

                if (emailBody.Text.Trim().Equals("") & lstEmailAttachment.Items.Count == 0)
                {
                    MessageBox.Show("Email cannot be sent without message-text and attachments.", "Email transmission error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    returnVal = false;
                }
            }
            finally
            {
                //commonFuncs = null;
            }

            if (returnVal == true)
            {
                errProv.Clear();
            }
            return returnVal;
        }

        private void richEditControl1_Click(object sender, EventArgs e)
        {

        }

        private string GetEmailAttachments()
        {
            string strAttachmentFile = "";
            try
            {
                foreach (ListViewItem lstItm in lstEmailAttachment.Items)
                {
                    if (lstItm.Checked)
                    {
                        strAttachmentFile += lstItm.SubItems[1].Text + ";";
                    }
                }
            }
            finally
            {
            }
            return strAttachmentFile;
        }

        private void SpellCheck()
        {
            try
            {
               // this.demoRichText.Text = emailBody.Text;

                //this.spelling.Text = this.demoRichText.Text;
                //this.spelling.SpellCheck();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtNewEmailSubject_TextChanged(object sender, EventArgs e)
        {
            this.Text = "[-" + PatientFileNo + "-] " + txtNewEmailSubject.Text;
        }

        private void chkSpellCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lstEmailAttachment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstEmailAttachment_DoubleClick(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            frmImageViewer frmImgViewer = new frmImageViewer();
            try
            {
                string EmailDocTypeFile = lstEmailAttachment.SelectedItems[0].SubItems[1].Text;
                string EmailDocType = lstEmailAttachment.SelectedItems[0].SubItems[0].Text;

                frmImgViewer.EmailDocument = EmailDocTypeFile;
                frmImgViewer.Text = EmailDocType;

                frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                frmImgViewer.ShowDialog();
                lstEmailAttachment.SelectedItems[0].Checked = true;
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error displaying Patient Email Document, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error displaying Patient Email Document \n" + ex.ToString());
            }
            finally
            {
                frmImgViewer.Dispose();
                commonFuncs = null;
            }
        }

        private bool UserAllowed(string RestrictionID)
        {
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

        private void spelling_DeletedWord(object sender, NetSpell.SpellChecker.SpellingEventArgs e)
        {
            int start = this.demoRichText.SelectionStart;
            int length = this.demoRichText.SelectionLength;

            this.demoRichText.Select(e.TextIndex, e.Word.Length);
            this.demoRichText.SelectedText = "";

            if (start > this.demoRichText.Text.Length)
                start = this.demoRichText.Text.Length;

            if ((start + length) > this.demoRichText.Text.Length)
                length = 0;

            this.demoRichText.Select(start, length);
        }

        private void SpellChecker_MisspelledWord(object sender, NetSpell.SpellChecker.SpellingEventArgs e)
        {
            Console.WriteLine(e.Word.ToString());
        }

        private void spelling_ReplacedWord(object sender, NetSpell.SpellChecker.ReplaceWordEventArgs e)
        {
            int start = this.demoRichText.SelectionStart;
            int length = this.demoRichText.SelectionLength;

            this.demoRichText.Select(e.TextIndex, e.Word.Length);
            this.demoRichText.SelectedText = e.ReplacementWord;

            if (start > this.demoRichText.Text.Length)
                start = this.demoRichText.Text.Length;

            if ((start + length) > this.demoRichText.Text.Length)
                length = 0;

            this.demoRichText.Select(start, length);
        }

        private void spelling_EndOfText(object sender, System.EventArgs e)
        {
            Console.WriteLine("EndOfText");
            //this.richTxt.Text = this.demoRichText.Text;
            emailBody.Text = this.demoRichText.Text;
            SendEmailNow();
        }

        private void btnAddressBookLookUp_Click(object sender, EventArgs e)
        {

        }

        private DataTable GetFiles()
        {
            DataTable dtFiles = new DataTable();
            try
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                dtFiles = commonFuncs.GetSentFromAddressList();
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Populating Files failed: " + ex.ToString());
            }
            return dtFiles;
        }

        void SetTextBoxProps()
        {
            txtEmailToCC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtEmailToCC.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtNewEmailTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNewEmailTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
         
        }
        void AIMSEmailFromAutoComplete()
        {
            try
            {
                //SetTextBoxProps();

                //AutoCompleteStringCollection files = new AutoCompleteStringCollection();
                //DataTable dtFiles = GetFiles();

                //int count = dtFiles.Rows.Count;
                //for (int i = 0; i < count; i++)
                //{
                //    DataRow row = dtFiles.Rows[i];
                //    files.Add((string)row["EMAIL_SENT_FROM_ADDRESS"]);
                //}
                //txtEmailToCC.AutoCompleteCustomSource = files;
                //txtNewEmailTo.AutoCompleteCustomSource = files;
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Populating Files failed: " + ex.ToString());
            }
        }

        private void txtNewEmailTo_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtNewEmailTo_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        //commonFuncs = new AIMS.Common.CommonFunctions();
            //        if (!txtPatientFileNo.Text.Trim().Equals("") && !AddedPatientFiles.Contains(txtPatientFileNo.Text.Trim()))
            //        {
            //            AddedPatientFiles += txtPatientFileNo.Text.Trim();
            //            if (commonFuncs.ValidPatientFileNo(txtPatientFileNo.Text.Trim()))
            //            {
            //                lstIndexFile.Items.Add(txtPatientFileNo.Text.Trim());
            //                txtPatientFileNo.Text = "";
            //            }
            //            else
            //            {
            //                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient File No does not exist.");
            //                AddedPatientFiles = AddedPatientFiles.Replace(txtPatientFileNo.Text.Trim(), "");
            //            }
            //        }
            //        else
            //        {
            //            if (!txtPatientFileNo.Text.Trim().Equals("") && AddedPatientFiles.Contains(txtPatientFileNo.Text.Trim()))
            //            {
            //                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Patient File No already added");
            //            }
            //            else
            //            {
            //                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Capture Patient File No");
            //            }
            //        }
            //        txtPatientFileNo.Text = txtPatientFileNo.Text.Trim();
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Adding Patient File error, Please contact System Administrator.");
            //    commonFuncs.ErrorLogger("Adding Patient File error: \n" + ex.ToString());
            //}
        }

        private void cboNewEmailFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNewEmailFrom.SelectedItem !=null)
            {
                switch (cboNewEmailFrom.Text) 
                {
                    case "Test@AIMS.org.za":
                        chkCCOPS.Text = "CC Admin Team (Charlaine)";
                        break;
                    case "Admin@AIMS.org.za":
                        chkCCOPS.Text = "CC Admin Team (Charlaine)";
                        break;
                    case "Operations@AIMS.org.za":
                        chkCCOPS.Text = "CC OPS Team (Bernadette, Case Managers and Eric)";
                        break;
                    default:
                        chkCCOPS.Text = "CC Team Leads";
                        //chkCCOPS.Checked = false;
                        break;
                }
            }
        }

        private void chkCCOPS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCCOPS.Checked)
            {
                if (cboNewEmailFrom.SelectedItem != null)
                {
                    switch (cboNewEmailFrom.Text)
                    {
                        case "Test@AIMS.org.za":
                            chkCCOPS.Text = "CC Admin Team (Charlaine)";
                            //txtEmailToCC.Text = txtEmailToCC.Text + ";Charlaine@aims.org.za";
                            break;
                        case "Admin@AIMS.org.za":
                            chkCCOPS.Text = "CC Admin Team (Charlaine)";
                            //txtEmailToCC.Text = txtEmailToCC.Text + ";Charlaine@aims.org.za";
                            break;
                        case "Operations@AIMS.org.za":
                            chkCCOPS.Text = "CC OPS Team (Bernadette, Case Managers and Eric)";
                            //txtEmailToCC.Text = txtEmailToCC.Text + ";Bernadette@aims.org.za;Eric@aims.org.za;Stanley@aims.org.za;Hendrikj@aims.org.za;jade@aims.org.za;dominicb@aims.org.za";

                            break;
                        default:
                            chkCCOPS.Text = "CC Team Leads";
                            //chkCCOPS.Checked = false;
                            break;
                    }
                }
            }
            else
            {
                if (cboNewEmailFrom.SelectedItem != null)
                {
                    switch (cboNewEmailFrom.Text)
                    {
                        case "Test@AIMS.org.za":
                            //chkCCOPS.Text = "";
                            //txtEmailToCC.Text = txtEmailToCC.Text.Replace(";Charlaine@aims.org.za", "");
                            break;
                        case "Admin@AIMS.org.za":
                            //chkCCOPS.Text = "";
                            //txtEmailToCC.Text = txtEmailToCC.Text.Replace(";Charlaine@aims.org.za","");
                            break;
                        case "Operations@AIMS.org.za":
                            //chkCCOPS.Text = "";
                            //txtEmailToCC.Text = txtEmailToCC.Text.Replace(";Bernadette@aims.org.za;Eric@aims.org.za;Stanley@aims.org.za;Hendrikj@aims.org.za;jade@aims.org.za;dominicb@aims.org.za","");

                            break;
                        default:
                            //chkCCOPS.Text = "";
                            //chkCCOPS.Checked = false;
                            break;
                    }
                }
            }
        }

        private void chkEmailSignatue_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}