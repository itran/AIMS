using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace AIMSClient
{
    public partial class frmIncidents : Form
    {
        public string IndexingDocument = "";
        public string IndexingEmailAttachments = "";
        public string IndexingDocFile = "";
        ArrayList arrEmailAttachments  = new ArrayList();
        public static Control[] arr = new Control[10];
        public static Control[] arr1 = new Control[10];
        bool FormLoading = false;
        Int32 MailboxID = 0;
        Int32 iCountDown = 59;
        Int32 iMailboxEmailsCount = 0;
        AIMS.Common.CommonFunctions commonFuncs;
        private ListViewColumnSorter lvwColumnSorter;
        string EmailID = "";

        string _userName = "";
        string _userID = "";
        
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

        public frmIncidents()
        {
            InitializeComponent();
        }

        private void Incidents_Load(object sender, EventArgs e)
        {
            FormLoading = true;
            commonFuncs = new AIMS.Common.CommonFunctions();

            try
            {
                DataTable dtEmailDocTypes = commonFuncs.Get_AIMS_Email_DocTypes(cboMailBoxes.Text );
                DataTable dtMailboxes = commonFuncs.Get_AIMS_Mailboxes(UserID);
                if (dtMailboxes.Rows.Count > 0)
                {
                    cboMailBoxes.DataSource = dtMailboxes;
                    cboMailBoxes.DisplayMember = "MAILBOX_NAME";
                    cboMailBoxes.ValueMember = "MAILBOX_ID";
                    cboMailBoxes.SelectedValue = -1;
                }
                EmailListSetup();
                lvwColumnSorter = new ListViewColumnSorter();
                this.lstMailboxEmails.ListViewItemSorter = lvwColumnSorter;
                foreach (ColumnHeader ch in this.lstMailboxEmails.Columns)
                {
                    if (ch.Text.Equals("EMAILID"))
                    {
                        ch.Width = 0;
                    }
                    else
                    {
                        ch.Width = -1;
                        //ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }      
                }

                //timer1.Enabled = true;
                //MailTimer.Enabled = true;

                btnDeleteMail.Enabled = UserAllowed("73");
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading the Email Management Form, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error loading the Email Management Form: \n" + ex.ToString());
            }
            finally 
            {
                //commonFuncs = null;
                FormLoading = false;
            }
        }

        private void Incidents_Resize(object sender, EventArgs e)
        {
            imgViewer.Width = this.ClientSize.Width - 10;
            imgViewer.Height = this.ClientSize.Height - 200;
            imgViewer.Left = groupBox3.Left;

            webBrowser1.Width = this.ClientSize.Width - 10;
            webBrowser1.Height = this.ClientSize.Height - 200;
            webBrowser1.Left = groupBox3.Left;
        }

        private void cboMailBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (commonFuncs == null)
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
            }
            try
            {
                if (!FormLoading)
                {
                    MailboxID = System.Convert.ToInt32(cboMailBoxes.SelectedValue);
                    LoadMailBoxEmails(MailboxID,true,"");
                    iMailboxEmailsCount = System.Convert.ToInt32(lstMailboxEmails.Items.Count);
                    //txtMailboxEmailCnt.Text = lstMailboxEmails.Items.Count.ToString();
                    txtMailboxEmailCnt.Text = iMailboxEmailsCount.ToString();
                    txtMailboxLatestEmail.Text = lstMailboxEmails.Items[0].SubItems[2].Text;
                    txtMailboxOldestEmail.Text = lstMailboxEmails.Items[lstMailboxEmails.Items.Count -1].SubItems[2].Text;
                }
            }
            catch (System.Exception ex)
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Load Email Mailbox Failed. Please contact System Administrator");
                commonFuncs.ErrorLogger("Load Email Mailbox Failed. \n" + ex.ToString());
            }
        }

        private void LoadMailBoxEmails(Int32 MailBoxID, bool bListCheck, string MailSearchKeyword) 
        {
            
            //commonFuncs = new AIMS.Common.CommonFunctions();
            DataTable dtMailboxEmails = commonFuncs.Get_AIMS_Mailbox_Emails(MailboxID, UserID, MailSearchKeyword);
            lstMailboxEmails.Items.Clear();
            LstEmailAttachments.Items.Clear();

            if (dtMailboxEmails.Rows.Count > 0)
            {
                string sEmailSubject = "";
                string sEmailFrom = "";
                string eEmailDate = "";
                string sEmailID = "";
                string sEmailReadYN = "";
                ListViewItem lvwItem;
                lstMailboxEmails.Items.Clear();
                LstEmailAttachments.Items.Clear();
                //imgViewer.Navigate("about:blank");
                //webBrowser1.Navigate("about:blank");
                foreach (DataRow dtRow in dtMailboxEmails.Rows)
                {
                    btnEmailSearch.Enabled = true;
                    Application.DoEvents();
                    sEmailFrom = dtRow["EMAIL_SENT_FROM_NAME"].ToString();
                    sEmailSubject = dtRow["EMAIL_SUBJECT"].ToString();
                    eEmailDate = dtRow["EMAIL_RECEIVED_DTTM"].ToString();
                    sEmailID = dtRow["EMAIL_ID"].ToString();
                    sEmailReadYN = dtRow["EMAIL_UNREAD_YN"].ToString();

                    if (sEmailReadYN == "Y")
                    {
                        lvwItem = new ListViewItem(sEmailFrom,1);
                    }
                    else
                    {
                        lvwItem = new ListViewItem(sEmailFrom, 0);
                    }
                    
                    lvwItem.SubItems.Add(sEmailSubject);
                    lvwItem.SubItems.Add(eEmailDate);
                    lvwItem.SubItems.Add(sEmailID);

                    TimeSpan ts1 = DateTime.Today - System.Convert.ToDateTime(eEmailDate);
                    int days = ts1.Days;
                    if (days > 7 || sEmailSubject.ToUpper().Contains("URGENT") || sEmailSubject.ToUpper().Contains("IMPORTANT") || sEmailSubject.ToUpper().Contains("CRITICAL"))
                    {
                        lstMailboxEmails.Items.Add(lvwItem).BackColor = Color.Red;
                    }
                    else
                    {
                        lstMailboxEmails.Items.Add(lvwItem);
                    }
                    Application.DoEvents();
                }

                foreach (ColumnHeader ch in this.lstMailboxEmails.Columns)
                {
                    if (ch.Text.Equals("EMAILID"))
                    {
                        ch.Width = 0;
                    }
                    else
                    {
                        //ch.Width = -1;
                        ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
            }
            else
            {
                btnEmailSearch.Enabled = false;
                if (bListCheck)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "No new emails found in selected Mailbox");
                    LstEmailAttachments.Items.Clear();
                    //imgViewer.Navigate("about:blank");
                    //webBrowser1.Navigate("about:blank");
                }
            }
        }

        private void EmailListSetup() 
        {
            lstMailboxEmails.Columns.Clear();
            lstMailboxEmails.Items.Clear();
            lstMailboxEmails.Columns.Add("Email From");
            lstMailboxEmails.Columns.Add("Email Subject", Convert.ToInt32(lstMailboxEmails.Width * 0.4), HorizontalAlignment.Left);
            lstMailboxEmails.Columns.Add("Email Received Date", Convert.ToInt32(lstMailboxEmails.Width * 0.3), HorizontalAlignment.Left);
            lstMailboxEmails.Columns.Add("EMAILID", 0,HorizontalAlignment.Right);

            LstEmailAttachments.Columns.Clear();
            LstEmailAttachments.Items.Clear();
            LstEmailAttachments.Columns.Add("Email Attachment");
            LstEmailAttachments.Columns.Add("Attachment Full Path", 0, HorizontalAlignment.Right);
            LstEmailAttachments.Columns.Add("Attachment ID", 0, HorizontalAlignment.Right);
        }

        private void lstMailboxEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItm;
            
            try
            {
                if (lstMailboxEmails.Items.Count == 1)
                {
                    EmailID = "";
                }

                if (!EmailID.Equals(lstMailboxEmails.Items[lstMailboxEmails.SelectedItems[0].Index].SubItems[3].Text.ToString()))
                {
                    EmailID = lstMailboxEmails.Items[lstMailboxEmails.SelectedItems[0].Index].SubItems[3].Text.ToString();
                    //lstMailboxEmails.SelectedItems.Clear();
                    if (!EmailID.Equals(""))
                    {
                        IndexingDocument = "";
                        IndexingDocFile = "";
                        //imgViewer.Navigate("about:blank");
                        //webBrowser1.Navigate("about:blank");

                        imgViewer.Visible = false;
                        webBrowser1.Visible = false;

                        //commonFuncs = new AIMS.Common.CommonFunctions();
                        DataTable dtEmailAttachments = commonFuncs.Get_AIMS_Email_Attachments(EmailID);
                        bool bEmailBodyFound = false;
                        dgEmailAttachments.DataSource = dtEmailAttachments;
                         
                        if (dtEmailAttachments.Rows.Count > 0) 
                        {
                            string EmailAttachmentLoc = "";
                            string EmailAttachType = "";
                            string EmailAttachID = "";

                            LstEmailAttachments.Items.Clear();
                            foreach (DataRow dtRow in dtEmailAttachments.Rows)
                            {
                                EmailAttachmentLoc = dtRow["ATTACHMENT_LOCATION"].ToString();
                                EmailAttachType = dtRow["ATTACHMENT_FILE_TYPE"].ToString();
                                EmailAttachID =  dtRow["ATTACHMENT_ID"].ToString();

                                if (!bEmailBodyFound)
	                            {
                                    switch (EmailAttachType)
                                    {
                                        case "EMAIL_BODY":
                                            bEmailBodyFound = true;
                                            //imgViewer.Navigate("about:blank");
                                            //imgViewer.Navigate(@EmailAttachmentLoc, false);
                                            //webBrowser1.Navigate("about:blank");
                                            this.webBrowser1.Visible = false;
                                            this.imgViewer.Visible = false;
                                            //this.imgViewer.Navigate(new Uri(@EmailAttachmentLoc));
                                            //this.imgViewer.Refresh();
                                            break;
                                    }                            		 
	                            }
                                lvwItm = new ListViewItem(Path.GetFileName(EmailAttachmentLoc));
                                lvwItm.SubItems.Add(EmailAttachmentLoc);
                                lvwItm.SubItems.Add(EmailAttachID);
                                LstEmailAttachments.Items.Add(lvwItm);
                                
                            }
                            foreach (ColumnHeader ch in this.LstEmailAttachments.Columns)
                            {
                                if (ch.Text.Equals("Attachment Full Path") || ch.Text.Equals("Attachment ID"))
                                {
                                    ch.Width = 0;
                                }
                                else
                                {
                                    ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                                }
                            }
                        }else
                        {
                            LstEmailAttachments.Items.Clear();
                            //imgViewer.Navigate("about:blank");
                            //webBrowser1.Navigate("about:blank");
                            LstEmailAttachments.Items.Add("NO ATTACHMENTS");
                        }
                        commonFuncs.AIMS_Lock_Email(EmailID, UserID, "N", "Y");
                    }
                }
            }
            catch (System.Exception ex)
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Getting Email Details Problem, Please try again.");
                commonFuncs.ErrorLogger( "Getting Email Details Problem \n: " +ex.ToString());
            }
            finally
            {
                //commonFuncs = null;
            }
        }

        // ColumnClick event handler.
        private void ColumnClick(object o, ColumnClickEventArgs e)
        {
            // Set the ListViewItemSorter property to a new ListViewItemComparer 
            // object. Setting this property immediately sorts the 
            // ListView using the ListViewItemComparer object.
            this.lstMailboxEmails.ListViewItemSorter = new ListViewColumnSorter();
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            //imgViewer.Navigate(@"\\aimsdc\Software\AIMS Recorder\Incident Files\IT11173TZ0113728_SWIFT.txt", false);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            //imgViewer.Navigate(@"\\aimsdc\Software\AIMS Recorder\Incident Files\it_asset_management_basics_us_en.pdf", false);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //imgViewer.Navigate(@"\\aimsdc\Software\AIMS Recorder\Incident Files\BulkSMS - Pricing.xlsx", false);
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            //imgViewer.Navigate(@"\\aimsdc\Software\AIMS Recorder\Incident Files\Implementation_Architecture_EE_Messaging_Bridge_V0.3_SPSP002.doc", false);
        }

        private void LstEmailAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LstEmailAttachments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //string EmailAttachmentFileName = LstEmailAttachments.SelectedItems[0].SubItems[1].Text;
                //imgViewer.Navigate(@EmailAttachmentFileName);
                //if (!LstEmailAttachments.SelectedItems[0].Checked)
                //{
                //    LstEmailAttachments.SelectedItems[0].Checked = false;
                //}
                //else
                //{
                //    LstEmailAttachments.SelectedItems[0].Checked = true;
                //}

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        //private void LstEmailAttachments_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    commonFuncs = new AIMS.Common.CommonFunctions();
        //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "test");
        //}

        private void btnDeleteMail_Click(object sender, EventArgs e)
        {
            try
            {
                //commonFuncs = new AIMS.Common.CommonFunctions();
                if (!EmailID.Equals(""))
                {
                    if (MessageBox.Show("Continue deleting the selected email. . .?", "Email Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        

                        //Commented out because when we dont delete email attachments, ONLY put a flag to say email is deleted.
                        //DataTable dtEmailAttachments = commonFuncs.Get_AIMS_Email_Attachments(EmailID);
                        //bool bEmailBodyFound = false;
                        //if (dtEmailAttachments.Rows.Count > 0)
                        //{
                        //    string EmailAttachmentLoc = "";
                        //    string EmailAttachType = "";
                        //    LstEmailAttachments.Items.Clear();
                        //    foreach (DataRow dtRow in dtEmailAttachments.Rows)
                        //    {
                        //        EmailAttachmentLoc = dtRow["ATTACHMENT_LOCATION"].ToString();
                        //        try
                        //        {
                        //            File.SetAttributes(EmailAttachmentLoc, FileAttributes.Normal);
                        //            //File.Delete(EmailAttachmentLoc);
                        //        }
                        //        catch (System.Exception ex)
                        //        {
                        //            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Deleting Email Attachments Error, Please contact System Administrator.");
                        //            commonFuncs.ErrorLogger("Deleting Email Attachments Error: \n" + ex.ToString());
                        //            return;
                        //        }
                        //    }
                        //}

                        bool bDBEmailDeleted = commonFuncs.AIMS_Email_Delete(EmailID);
                        if (bDBEmailDeleted)
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Email deleted successfully");
                            LoadMailBoxEmails(MailboxID, true,"");
                            iMailboxEmailsCount = System.Convert.ToInt32(lstMailboxEmails.Items.Count);
                            txtMailboxEmailCnt.Text = iMailboxEmailsCount.ToString();
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email NOT deleted successfully, Please contact System Administrator");
                        }
                    }
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "No Email selected");
                }
            }
            catch (System.Exception ex)
            {
                //commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Deleting Email Error, Please try again.");
                commonFuncs.ErrorLogger("Deleting Email Error: \n" + ex.ToString());
            }
            finally 
            {
                //commonFuncs = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iCountDown -= 1;

            if (iCountDown.ToString().Length == 1)
            {
                lblCountDown.Text = "00:" + "0" + iCountDown.ToString();
            }
            else
            {
                lblCountDown.Text = "00:" + iCountDown.ToString();
            }

            if (iCountDown == 0)
            {
                iCountDown = 60;
            }
        }

        private void lblCountDown_Click(object sender, EventArgs e)
        {

        }

        private void MailTimer_Tick(object sender, EventArgs e)
        {
            if (MailboxID > 0)
            {
                //LoadMailBoxEmails(MailboxID, false,"" );
            }
        }

        private void btnEmailStats_Click(object sender, EventArgs e)
        {
            try
            {
                if (MailboxID > 0)
                {

                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select Mailbox to view stats");
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Displaying Mailbox Email Stats");
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

        private void btnEmailsRefresh_Click(object sender, EventArgs e)
        {
            if (MailboxID > 0)
            {
                LoadMailBoxEmails(MailboxID, false,"");
            }
        }

        private void btnEmailSave_Click(object sender, EventArgs e)
        {
            bool CheckedEmailFound = false;
            string EmailAttachmenID = "";
            //commonFuncs = new AIMS.Common.CommonFunctions();
            Int32 IndexedEmailAttachments = 0;
            arr1 = arrayOfControl();
            string strEmailAttachments = "";

            try
            {
                string ConfirmedIndexingDocuments = IndexDocumentsConfirm();

                //if (!ConfirmedIndexingDocuments.ToLower().Contains("email correspondence"))
                //{
                //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Email Correspondence not selected.");
                //    return;
                //}

                if (LstEmailAttachments.Items.Count >0)
                {
                    if (!EmailID.Equals(""))
                    {
                        DataTable dtEmailInfo = commonFuncs.Get_AIMS_Email_Info(EmailID);
                        
                        string sEmailLockedBy = "";
                        bool bEmailLocked = false;
                        foreach (DataRow  dtRow in dtEmailInfo.Rows)
                        {
                            sEmailLockedBy = dtRow["EMAIL_LOCKED_BY"].ToString();
                            if (sEmailLockedBy.Equals("") || sEmailLockedBy.Equals(UserID))
                            {
                                bEmailLocked = commonFuncs.AIMS_Lock_Email(EmailID, UserID, "Y", "Y");
                                if (bEmailLocked)
                                {
                                    foreach (ListViewItem lvItem in LstEmailAttachments.Items)
                                    {
                                        if (lvItem.Checked)
                                        {
                                            CheckedEmailFound = true;
                                            EmailAttachmenID += lvItem.SubItems[2].Text + "|";
                                            IndexedEmailAttachments++;
                                        }
                                    }

                                    if (!CheckedEmailFound)
                                    {
                                        commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select email item to save.");
                                    }
                                    else
                                    {
                                        
                                        if (MessageBox.Show("Continue Indexing following documents: " + System.Environment.NewLine + System.Environment.NewLine + ConfirmedIndexingDocuments.Replace("\n", " \n "), "Email Document(s) Indexing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)                                        
                                        {
                                            EmailAttachmenID = EmailAttachmenID.Substring(0, EmailAttachmenID.Trim().Length -1);
                                          
                                            frmIndexEmail frmIndexing = new frmIndexEmail();

                                            frmIndexing.UserID = UserID;
                                            frmIndexing.UserName = UserName;
                                            frmIndexing.MailBoxName = cboMailBoxes.Text.ToUpper();
                                            frmIndexing.Restrictions = Restrictions;
                                            frmIndexing.ShowInTaskbar = false;
                                            frmIndexing.StartPosition = FormStartPosition.CenterScreen;
                                            frmIndexing.IndexingDocuments = ConfirmedIndexingDocuments;
                                            frmIndexing.EmailAttachments = IndexingEmailAttachments;
                                            
                                            frmIndexing.EmailID = EmailID;

                                            if (frmIndexing.ShowDialog() == DialogResult.OK)
                                            {
                                                frmIndexing.Close();
                                                LoadMailBoxEmails(MailboxID,false,"");
                                                iMailboxEmailsCount = System.Convert.ToInt32(lstMailboxEmails.Items.Count);
                                                txtMailboxEmailCnt.Text = iMailboxEmailsCount.ToString();
                                            }
                                            else
                                            {
                                                commonFuncs.AIMS_Lock_Email(EmailID, UserID, "N", "Y");
                                            }
                                        }  
                                    }
                                }
                                else
                                {
                                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email not locked to you, Please contact System Administrator.");
                                }
                            }
                            else
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Email Currently Locked By: " +  dtRow["USER_FULL_NAME"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "No email attachments");
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger(ex.ToString());
            }
        }

        public static DialogResult EmailAttachmentClassification(string title, string promptText1, string promptText2, ref string value1, ref string value2, Int32 EmailDocSelected)
        {
            try
            {
                Form form = new Form();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();
                arr1 = arrayOfControl();
               
                Label lblHeader = new Label();
                ComboBox cmbDocumentTypes = new ComboBox();
                for (int i = 0; i < EmailDocSelected; i++)
                {
                    arr[i].Controls.Add(lblHeader);
                    arr[i].Controls.Add(cmbDocumentTypes);

                    form.Text = title;
                    lblHeader.Text = promptText1;

                    lblHeader.SetBounds(9, 20 * (i + 1), 372, 13 * (i + 1));
                    cmbDocumentTypes.SetBounds(12, 36 * (i + 1), 399, 20 * (i + 1));

                    lblHeader.AutoSize = true;
                    lblHeader.Anchor = lblHeader.Anchor | AnchorStyles.Right;
                    cmbDocumentTypes.Anchor = cmbDocumentTypes.Anchor | AnchorStyles.Right;

                }

                buttonCancel.SetBounds(309, 72, 75, 23);

                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonOk.Top = cmbDocumentTypes.Bottom;
                buttonCancel.Top = cmbDocumentTypes.Bottom;         

                form.ClientSize = new Size(420, 500);
                form.Controls.AddRange(new Control[] { lblHeader, cmbDocumentTypes, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, lblHeader.Right + 10), form.ClientSize.Height);

                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.SetBounds((Screen.GetBounds(form).Width / 2) - (form.Width / 2),
                    (Screen.GetBounds(form).Height / 2) - (form.Height / 2),
                    form.Width, form.Height, BoundsSpecified.Location); 

                buttonOk.Text = "Save";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value1 = cmbDocumentTypes.Text;
                //value2 = textBox2.Text;

                return dialogResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Control[] arrayOfControl()
        {
            for (int i = 0; i < 10; i++)
            {
                arr[i] = new Control();
            }

            return arr;
        }

        private static void cboDocType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static DialogResult InputBox(string title, string promptText, ref string value,ref int  value2, DataTable dtEmailDocTypes)
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
            value2 = System.Convert.ToInt16( cboDocType.SelectedValue);
            return dialogResult;
        }

        private void LstEmailAttachments_ItemChecked(object sender, ItemCheckedEventArgs e) 
        { 
            ListViewItem item = e.Item as ListViewItem;
            //commonFuncs = new AIMS.Common.CommonFunctions();
            DataTable dtEmailDocTypes = new DataTable(); 

            try
            {
                if (item != null)
                {
                    if (item.Checked)
                    {
                        string DocTypeDesc = "";
                        int DocTypeID = 0;
                        dtEmailDocTypes = commonFuncs.Get_AIMS_Email_DocTypes(cboMailBoxes.Text);
                        DialogResult dgWindow =  InputBox("Email Attachment Classification", "Document Type", ref DocTypeDesc, ref DocTypeID, dtEmailDocTypes);
                        if (dgWindow == DialogResult.OK)
                        {
                            if (DocTypeDesc.Trim().Equals(""))
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Document Type Not Selected");
                                item.Checked = false;
                            }
                            else
                            {
                                IndexingDocument += DocTypeID.ToString() + "$" + item.Index + "$" + DocTypeDesc + "#" +item .SubItems[2].Text + "|";
                                IndexingDocFile += 
                                arrEmailAttachments.Add(DocTypeID.ToString() + "$" + item.Index);
                            }
                        }
                        else
                        {
                            item.Checked = false;
                        }
                    }
                    else
                    {
                        if (!IndexingDocument.Trim().Equals(""))
                        {
                            ReCalculateDocs(System.Convert.ToInt16(item.Index));
                        }
                    }
                }
            }
            finally
            {
                dtEmailDocTypes.Dispose();
                dtEmailDocTypes = null;
            }
        }

        private void ReCalculateDocs(Int16 unCheckedItem) 
        {
            try
            {
                Int16 lstItemCheckedItm = 0;
                string[] arrIndexDocs = IndexingDocument.Split(new Char[] { '|' });
                string[] arrIndexDocIndex = new string[0];
                foreach (string IndexFile in arrIndexDocs)
                {
                    if (!IndexFile.Trim().Equals(""))
                    {
                        arrIndexDocIndex = IndexFile.Split(new Char[] { '$' });
                        foreach (string  unCheckedIdx in arrIndexDocIndex)
                        {
                            if (!unCheckedIdx.Trim().Equals(""))
                            {
                                lstItemCheckedItm = System.Convert.ToInt16(arrIndexDocIndex[1]);
                                if (lstItemCheckedItm  == unCheckedItem)
                                {
                                    if (arrEmailAttachments.Count.Equals(1))
                                    {
                                        arrEmailAttachments.RemoveAt(0);
                                    }
                                    else
                                    {
                                        arrEmailAttachments.RemoveAt(unCheckedItem - 1);
                                    }
                                    
                                   
                                    IndexingDocument = IndexingDocument.Replace(IndexFile, "");
                                    return;
                                }                                
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

        private void LstEmailAttachments_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string EmailAttachmentFileName = LstEmailAttachments.SelectedItems[0].SubItems[1].Text;
                //imgViewer.Navigate(@EmailAttachmentFileName);
                if (Path.GetExtension(@EmailAttachmentFileName).ToUpper().Equals(".PDF"))
                {
                    this.imgViewer.Visible = false;
                    this.webBrowser1.Navigate(new Uri(@EmailAttachmentFileName));
                    this.webBrowser1.Visible = true;
                }
                else
                {
                    this.webBrowser1.Visible = false;
                    this.imgViewer.Navigate(new Uri(@EmailAttachmentFileName));
                    this.imgViewer.Visible = true;
                }
            }
            catch (Exception)
            {

            }
            finally 
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private string IndexDocumentsConfirm() 
        {
            string DocTypesList = "";
            try
            {
                string[] arrIndexDocs = IndexingDocument.Split(new Char[] { '|' });
                IndexingEmailAttachments = "";
                string[] arrIndexDocIndex = new string[0];
                bool FirstTime = true;

                Int16 docCount = 1;
                foreach (string IndexFile in arrIndexDocs)
                {
                    if (!IndexFile.Trim().Equals(""))
                    {
                        arrIndexDocIndex = IndexFile.Split(new Char[] { '$' });
                        foreach (string unCheckedIdx in arrIndexDocIndex)
                        {
                            if (!unCheckedIdx.Trim().Equals(""))
                            {
                                if (FirstTime)
                                {
                                    DocTypesList += " " + "  - " + arrIndexDocIndex[2].ToString().Substring(0,arrIndexDocIndex[2].ToString().IndexOf("#"));
                                    IndexingEmailAttachments = arrIndexDocIndex[0].ToString() + "|" + arrIndexDocIndex[2].ToString().Substring(arrIndexDocIndex[2].ToString().IndexOf("#") + 1);
                                    FirstTime = false;
                                }
                                else
                                {
                                    DocTypesList += "\n" + "  - " + arrIndexDocIndex[2].ToString().Substring(0, arrIndexDocIndex[2].ToString().IndexOf("#"));
                                    IndexingEmailAttachments += "," + arrIndexDocIndex[0].ToString() + "|" + arrIndexDocIndex[2].ToString().Substring(arrIndexDocIndex[2].ToString().IndexOf("#") + 1);
                                }
                                DocTypesList = DocTypesList.Replace(@"\r","");
                                docCount++;
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                
            }

            return DocTypesList;
        }

        private void btnPendEmail_Click(object sender, EventArgs e)
        {
            bool CheckedEmailFound = false;
            string EmailAttachmenID = "";
            //commonFuncs = new AIMS.Common.CommonFunctions();
            Int32 IndexedEmailAttachments = 0;
            arr1 = arrayOfControl();
            string strEmailAttachments = "";

            try
            {
                if (!EmailID.Equals(""))
                {
                    DataTable dtEmailInfo = commonFuncs.Get_AIMS_Email_Info(EmailID);

                    string sEmailLockedBy = "";
                    bool bEmailLocked = false;
                    foreach (DataRow dtRow in dtEmailInfo.Rows)
                    {
                        foreach (ListViewItem lvItem in LstEmailAttachments.Items)
                        {
                            if (lvItem.Checked)
                            {
                                CheckedEmailFound = true;
                                EmailAttachmenID += lvItem.SubItems[2].Text + "|";
                                IndexedEmailAttachments++;
                            }
                        }

                        if (!CheckedEmailFound)
                        {
                            commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select email item to save.");
                        }
                        else 
                        {
                            sEmailLockedBy = dtRow["EMAIL_LOCKED_BY"].ToString();
                            if (sEmailLockedBy.Equals("") || sEmailLockedBy.Equals(UserID))
                            {
                                bEmailLocked = commonFuncs.AIMS_Lock_Email(EmailID, UserID, "Y", "Y");
                                if (bEmailLocked)
                                {
                                    string ConfirmedIndexingDocuments = IndexDocumentsConfirm();
                                    if (MessageBox.Show("Continue pending email. . .?", "Email Pending", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        EmailAttachmenID = EmailAttachmenID.Substring(0, EmailAttachmenID.Trim().Length - 1);
                                        
                                        frmPendEmail frmIndexing = new frmPendEmail();

                                        frmIndexing.UserID = UserID;
                                        frmIndexing.UserName = UserName;
                                        frmIndexing.Restrictions = Restrictions;
                                        frmIndexing.ShowInTaskbar = false;
                                        frmIndexing.MailBoxName = cboMailBoxes.Text.ToUpper();
                                        frmIndexing.StartPosition = FormStartPosition.CenterScreen;
                                        frmIndexing.IndexingDocuments = ConfirmedIndexingDocuments;
                                        frmIndexing.EmailAttachments = IndexingEmailAttachments;

                                        frmIndexing.EmailID = EmailID;

                                        if (frmIndexing.ShowDialog() == DialogResult.OK)
                                        {
                                            frmIndexing.Close();
                                            LoadMailBoxEmails(MailboxID, false,"");
                                            iMailboxEmailsCount = System.Convert.ToInt32(lstMailboxEmails.Items.Count);
                                            txtMailboxEmailCnt.Text = iMailboxEmailsCount.ToString();
                                        }
                                        else
                                        {
                                            commonFuncs.AIMS_Lock_Email(EmailID, UserID, "N","Y");
                                        }
                                    }

                                }
                                else
                                {
                                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Email not locked to you, Please contact System Administrator.");
                                }
                            }
                            else
                            {
                                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Email Currently Locked By: " + dtRow["USER_FULL_NAME"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "No email selected");
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger(ex.ToString());
            }
        }

        private void btnEmailSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string EmailSubjectKeyword = "";
                EmailSearchInputBox("Email Search", "Email Subject Keyword", ref EmailSubjectKeyword);
                if (!EmailSubjectKeyword.Trim().Equals(""))
                {
                    EmailID = "";
                    LoadMailBoxEmails(MailboxID,true,EmailSubjectKeyword);
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


    }
}