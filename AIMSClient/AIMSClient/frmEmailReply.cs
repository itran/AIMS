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
    public partial class frmEmailReply : Form
    {

        public string PatientEmailSentID = "";
        AIMS.Common.CommonFunctions commonFuncs;
        public frmEmailReply()
        {
            InitializeComponent();
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

        string _PatientSubFileID = "";
        public string PatientSubFileID
        {
            get { return _PatientSubFileID; }
            set { _PatientSubFileID = value; }
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

        string _emailSubject = "";
        public string EmailSubject
        {
            get { return _emailSubject; }
            set
            {
                _emailSubject = value;
            }
        }

        string _EmailHeader = "";
        public string EmailHeader
        {
            get { return _EmailHeader; }
            set
            {
                _EmailHeader = value;
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

        string _BccEmailAddress = "";
        public string BccEmailAddress
        {
            get { return _BccEmailAddress; }
            set
            {
                _BccEmailAddress = value;
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

        string _emailFromCC = "";
        public string EmailFromCC
        {
            get { return _emailFromCC; }
            set
            {
                _emailFromCC = value;
            }
        }
        
        string _EmailID = "";
        public string EmailID
        {
            get { return _EmailID; }
            set
            {
                _EmailID = value;
            }
        }

        string _OriginalEmailCorrespondence = "";
        public string OriginalEmailCorrespondence
        {
            get { return _OriginalEmailCorrespondence; }
            set
            {
                _OriginalEmailCorrespondence = value;
            }
        }

        private void frmEmailReply_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (!EmailSubject.Trim().Equals(""))
                {
                    EmailSubject = EmailSubject.Replace("[-" + PatientFileNo + "-]", "");
                    EmailSubject = EmailSubject.Replace("RE:", "");
                    EmailSubject = EmailSubject.Replace("Re:", "");
                    EmailSubject = EmailSubject.Replace("FW:", "");
                    EmailSubject = EmailSubject.Replace("Fw:", "");
                    EmailSubject = EmailSubject.Trim();
                    //EmailSubject = "[-" + PatientFileNo + "-]" + " RE: " + EmailSubject;
                    EmailSubject = " RE: " + EmailSubject;
                    
                }

                this.Text =  EmailSubject;
                txtNewEmailSubject.Text = EmailSubject;
                txtPatientFileNo.Text = "[-" + PatientFileNo + "-]";
                txtNewEmailTo.Text = EmailFrom;
                txtEmailToCC.Text = EmailFromCC;
                //btnNewEmailSend.Enabled = UserAllowed("78");
                LoadEmailSenders();
                LoadEmailDetails();
                EmailAttachListSetup();
                LoadOriginalEmailBody(OriginalEmailCorrespondence);
                emailBody.Focus();
                chkCCOPS.Checked = true;
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading the Reply-To Form, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error loading the Reply-To Form: \n" + ex.ToString());
            }
        }

        private void EmailAttachListSetup ()
        {
            lstEmailAttachment.Columns.Clear();
            lstEmailAttachment.Items.Clear();
            lstEmailAttachment.Columns.Add("Attachment", Convert.ToInt32(lstEmailAttachment.Width * 0.4), HorizontalAlignment.Left);
            lstEmailAttachment.Columns.Add("AttachmentPATH", 0, HorizontalAlignment.Left);
        }

        private void LoadEmailSenders()
        {
            try
            {
                DataTable dtEmailSenders = new DataTable();
                //commonFuncs = new AIMS.Common.CommonFunctions();
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
                //TODO RM ADD CODE TO WRITE ERROR TO SOME LOG FILE/TABLE
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading Email From List, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Error loading Email From List \n" + ex.ToString());
            }
            finally 
            {
                //commonFuncs = null;
            }
        }

        private void txtNewEmailTo_TextChanged(object sender, EventArgs e)
        {
        }

        private void LoadEmailDetails() 
        {
            try
            {
                //this.Text = "[-" + PatientFileNo + "-] RE: " + EmailSubject;
                //txtNewEmailSubject.Text = "RE: " + EmailSubject;
            }
            catch (System.Exception ex)
            {

            }
        }

        private void btnNewEmailSend_Click(object sender, EventArgs e)
        {
            bool bEmailSent = false;
            if (!chkEmailSignatue.Checked)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please include Email Signature.");
                return;
            }

            bEmailSent = SendEmailNow();
        }

        private bool SendEmailNow() 
        {
            DataTable dtLimitationInfo = new DataTable();
            bool bEmailSent = false;
            string EmailToCC = "";
            string EmailAttachments = "";
            btnNewEmailSend.Enabled = false;

            string PodEmailGUID = System.Guid.NewGuid().ToString();
            string PODTargetFolder = "";
            bool bPODPass = false;
            string EmailCC  = "";
            commonFuncs = new AIMS.Common.CommonFunctions();

            string InstrumentationStep = "";

            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 1";
            commonFuncs.ErrorLogger("Forward: Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

            try
            {
                dtLimitationInfo = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_POD_SENT_EMAIL");

                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2";
                commonFuncs.ErrorLogger("Forward: Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());

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

                    InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 3";
                    commonFuncs.ErrorLogger("Forward: Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                }
                if (ValidateControl())
                {
                    if (chkSpellCheck.Checked)
                    {
                        SpellCheck();
                    }
                    txtNewEmailTo.Text = txtNewEmailTo.Text.Replace(" ", "");
                    EmailAttachments = GetEmailAttachments();

                    //txtNewEmailSubject.Text = txtPatientFileNo.Text + " " + txtNewEmailSubject.Text;
                    txtNewEmailSubject.Text = txtNewEmailSubject.Text.Replace("[-" + PatientFileNo + "-]", "");
                    txtNewEmailSubject.Text = "[-" + PatientFileNo + "-]" + " " + txtNewEmailSubject.Text.Trim();
                    BccEmailAddress = "";
                    //If you need to copy OPS team
                    if (chkCCOPS.Checked )
                    {
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
                                    break;
                            }
                        }

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
                        EmailToCC = EmailToCC + ";" + txtEmailToCC.Text.Replace(EmailToCC, "").Replace("Jo-Ann@aims.org.za","");
                    }

                    string emailTo = txtNewEmailTo.Text;
                    commonFuncs.cleanEmailRecipient(ref emailTo, ref EmailToCC, BccEmailAddress);

                    if (chkEmailSignatue.Checked)
                    {
                        bool addPassNote = !EmailAttachments.Trim().Equals("") ? true : false;
                        string emailSignature = commonFuncs.EmailSignature(LoggedOnUser, addPassNote);
                        if (!emailSignature.Equals(""))
                        {
                            //emailBody.HtmlText = emailBody.HtmlText.Replace("#EMAIL_SIGNATURE#", "<br/><br/>" + emailSignature);
                            emailBody.HtmlText = emailBody.HtmlText.Replace("#EMAIL_SIGNATURE#", "<br/><br/>" + emailSignature).Replace("font-family:Times New Roman", "font-family:Calibri");
                        }
                    }

                    if (!EmailAttachments.Trim().Equals("") && PatientDOB.Trim().Equals(""))
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Patient Date-Of-Birth missing. Correct Format: DD/MM/YYYY");
                        return false;
                    }

                    bEmailSent = commonFuncs.SendEmail(emailBody.HtmlText, cboNewEmailFrom.Text, cboNewEmailFrom.Text, txtNewEmailSubject.Text, emailTo, EmailAttachments, false, EmailToCC, BccEmailAddress, PatientFileNo, PatientDOB, true );
                    InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 6";
                    commonFuncs.ErrorLogger("Forward: Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                    if (bEmailSent)
                    {
                        bEmailSent = SaveSentEmail();
                        InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 7";
                        commonFuncs.ErrorLogger("Forward: Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                        if (bEmailSent)
                        {
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
                                                commonFuncs.ErrorLogger("Forward: Email Transmission Email Steps Instrumentation: FILE NAME: " + PODTargetFolder + Path.GetFileName(IndexFile) + "|||| " + IndexFile);
                                                File.SetAttributes(IndexFile, FileAttributes.Normal);
                                                File.Copy(IndexFile, PODTargetFolder + Path.GetFileName(IndexFile));


                                                bPODPass = commonFuncs.EmailSentAttachmentPODDelivery(PODTargetFolder + Path.GetFileName(IndexFile), PatientEmailSentID);
                                                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 8";
                                                commonFuncs.ErrorLogger("Forward: Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                                                if (!bPODPass)
                                                {
                                                    commonFuncs.ErrorLogger("Sent EMAIL Attachment could not POD: FROM: " + IndexFile + " ### TO: " + PODTargetFolder + Path.GetFileName(IndexFile));
                                                }
                                            }
                                            catch (IOException ex)
                                            {
                                                commonFuncs.ErrorLogger("IO: File COPY EXCEPTION: FROM: " + IndexFile + " ### TO: " + PODTargetFolder + Path.GetFileName(IndexFile));
                                                commonFuncs.ErrorLogger(ex.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                            string SentEmailDttm = System.DateTime.Today.ToString("dd-MMM-yyyy");

                            string SentEmailSubject = commonFuncs.ReplaceMultiple(txtNewEmailSubject.Text, @"/", @"\", ";", ",", "*", "(", ")", ",", "~", "!", "@", "#", "$", "%", "^", "&", "?", "<", ">", "_", "|", "//", "\\", ":");
                            SentEmailSubject = SentEmailSubject.Replace("/", " ");

                            string EmailFile = @PODTargetFolder + "Email Correspondence Sent - " + SentEmailSubject + ".html";

                            commonFuncs.CreateEmailCorrespondence(ref EmailFile, emailBody.HtmlText, @PODTargetFolder, "Email Correspondence Sent - " + SentEmailSubject + ".html");
                            bPODPass = commonFuncs.EmailSentAttachmentPODDelivery(EmailFile, PatientEmailSentID);

                            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 10";
                            commonFuncs.ErrorLogger("Forward: Email Transmission Email Steps Instrumentation: " + InstrumentationStep.ToString());
                            
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Email Sent successfully.");
                            SentEmailCorrespondence = emailBody.HtmlText;
                            this.Close();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email transmission error, Please contact System Administrator.");
                            this.DialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email transmission error, Please contact System Administrator.");
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
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
            //commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                bEmailSaved = commonFuncs.SaveSentEmail(ref PatientEmailSentID, PatientFileNo, txtNewEmailTo.Text.Trim(), cboNewEmailFrom.SelectedValue.ToString(), PatientFileEnquiryID, txtNewEmailSubject.Text.Trim(), LoggedOnUser, txtEmailToCC.Text.Trim());
            }
            catch (System.Exception ex)
            {
                bEmailSaved = false;
            }
            return bEmailSaved;
        }

        private void lnkAttachFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PatientDOB.Trim().Equals(""))
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture Date-Of-Birth before attaching documents to email.");
                return;
            }

            //commonFuncs = new AIMS.Common.CommonFunctions();
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
                dialog.InitialDirectory = "C:"; dialog.Title = "Select an attachment";
                //Present to the user. 

                if (dialog.ShowDialog() == DialogResult.OK) {
                    strFileName = Path.GetFileName(dialog.FileName);
                    strFileFullPath = dialog.FileName;
                }
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
            //commonFuncs = new AIMS.Common.CommonFunctions();
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
                
                if (cboNewEmailFrom.Text.Equals(""))
                {
                    errProv.SetError(cboNewEmailFrom, "Please select mail Sender");
                    cboNewEmailFrom.Focus();
                    returnVal = false;
                    return false;
                }

                if (txtNewEmailTo.Text.Trim().Equals(""))
                {
                    errProv.SetError(txtNewEmailTo, "Please enter recipient email address");
                    txtNewEmailTo.Focus();
                    returnVal = false;
                }

                if (!txtNewEmailTo.Text.Trim().Equals("") )
                {
                    if (!txtNewEmailTo.Text.Contains(";"))
                    {
                        if (!commonFuncs.ValidEmailAddress(txtNewEmailTo.Text.Trim())) {
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
                                    errProv.SetError(txtNewEmailTo, "Please enter valid email address - " + EmailAddress.Trim());
                                    txtNewEmailTo.Focus();
                                    returnVal = false;
                                }   
                            }
                        }
                    }
                }

                if (emailBody.Text.Trim().Equals("") & lstEmailAttachment.Items.Count == 0 )
                {
                    MessageBox.Show("Email cannot be sent without message-text and attachments.","Email transmission error",MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtNewEmailSubject_TextChanged(object sender, EventArgs e)
        {
            this.Text = txtNewEmailSubject.Text;
        }

        private bool LoadOriginalEmailBody(string EmailCorrespondenceEmail)
        {
            bool bReturn = false;
            try
            {
                string EmailBodyContent = new StreamReader(@EmailCorrespondenceEmail).ReadToEnd();
                if (!EmailHeader.Equals(""))
                {
                    emailBody.HtmlText = @"<br/><br/><br/>#EMAIL_SIGNATURE#<br/><br/><br/><hr>" + EmailHeader + EmailBodyContent;
                }
                else
                {
                    emailBody.HtmlText = @"<br/><br/><br/>#EMAIL_SIGNATURE#<br/><br/><br/><hr>" + EmailBodyContent;
                }
                
                bReturn =  true;
            }
            catch (System.Exception ex)
            {
                bReturn = false;
            }
            return bReturn;
        }

        private void btnSpellCheck_Click(object sender, EventArgs e)
        {



        }

        private void SpellCheck()
        {
            Word.Application app = new Word.Application();
            try
            {

                int errors = 0;
                if (emailBody.Text.Length > 0)
                {
                    app.Visible = false;

                    // Setting these variables is comparable to passing null to the function.
                    // This is necessary because the C# null cannot be passed by reference.
                    object template = Missing.Value;
                    object newTemplate = Missing.Value;
                    object documentType = Missing.Value;
                    object visible = true;

                    Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                    
                    doc1.Words.First.InsertBefore(emailBody.Text);
                    Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
                    errors = spellErrorsColl.Count;

                    object optional = Missing.Value;

                    doc1.CheckSpelling(
                        ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,
                        ref optional, ref optional, ref optional, ref optional, ref optional, ref optional);

                    object first = 0;
                    object last = doc1.Characters.Count - 1;
                    doc1.Windows.Application.Activate();
                    emailBody.Text = doc1.Range(ref first, ref last).Text;
                }

                object saveChanges = false;
                object originalFormat = Missing.Value;
                object routeDocument = Missing.Value;

                app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);

            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                //app = null;
            }
        }

        private void lstEmailAttachment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstEmailAttachment_DoubleClick(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
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
                //commonFuncs = null;
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
                            chkCCOPS.Text = "";
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

        private void cboNewEmailFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNewEmailFrom.SelectedItem != null)
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
                        chkCCOPS.Text = "";
                        //chkCCOPS.Checked = false;
                        break;
                }
            }
        }
    }
}