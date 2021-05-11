using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmWorkBasketAdmin : Form
    {
        public frmWorkBasketAdmin()
        {
            InitializeComponent();
        }

        string WorkBasketUser = "";
        string _userName = "";
        string coOrdinatorName = "";
        string coOrdinatorUserName = "";
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
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

        string _patientFileNo = "";
        public string PatientFileNo
        {
            get { return _patientFileNo; }
            set
            {
                _patientFileNo = value;
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

        AIMS.Common.CommonFunctions commonFuncs;

        string PatientEmailEnquiryID = "";
        string PatientSentEmailID = "";
        string WorkBasketEmailEnquiryID = "";

        string PatientEmailSubject = "";
        string PatientEmailFrom = "";
        string PatientEmailFromCC = "";

        private void frmWorkBasketAdmin_Load(object sender, EventArgs e)
        {
            WorkbasketListSetup();
            WorkbasketAuditListSetup();
            
            LoadMyMailbox();
            LoadMailboxAudit(UserID);
            btnWorkBasketView.Enabled = UserAllowed("83");
        }

        private void btnWorkClose_Click(object sender, EventArgs e)
        {
            btnMailsRefresh.Enabled = true;
            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                if (lstOperatorMailBox.CheckedItems.Count > 0)
                {
                    if (MessageBox.Show("Work Item(s) Processed?", "Work Item Processed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ListView.CheckedListViewItemCollection vc = lstOperatorMailBox.CheckedItems;
                        bool EmailProcessed = false;
                        int checkItem = 0;

                        string[] strValues = new string[lstOperatorMailBox.CheckedItems.Count];

                        for (int i = 0; i < vc.Count; i++)
                        {
                            WorkBasketEmailEnquiryID = lstOperatorMailBox.Items[vc[i].Index].SubItems[5].Text;
                            EmailProcessed = commonFuncs.AIMS_Email_Processed(WorkBasketEmailEnquiryID, UserID);
                            if (!EmailProcessed)
                            {
                                commonFuncs.ErrorLogger("Work Basket item could not be processed, Please contact System Administrator.");
                            }
                        }
                        if (coOrdinatorUserName.Equals("") || coOrdinatorUserName.Equals(UserID))
                        {
                            LoadMyMailbox();
                            LoadMailboxAudit(UserID);
                        }
                        else
                        {
                            LoadMyMailbox(coOrdinatorUserName, coOrdinatorName);
                            LoadMailboxAudit(coOrdinatorUserName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select Work Item Processed", "Work Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                btnMailsRefresh.Enabled = true;
            }
        }

        /// <summary>
        ///     This method retrieves all emails sent operators to files tagged to operator
        /// </summary>
        private void LoadMyMailbox()
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItem;
            DataTable dtMyMails = new DataTable();
            DataTable dtInstantMessages = new DataTable();
            string sNotifyStr = "";
            string LastFileNo = "";
            bool RecordsFound = false;

            lstOperatorMailBox.Items.Clear();

            lstOperatorMailBox.View = View.Details;

            try
            {
                dtMyMails = commonFuncs.Get_AIMS_Administrator_Work(UserID);
                string sEmailSubject = "";
                if (dtMyMails.Rows.Count > 0)
                {
                    RecordsFound = true;
                    for (int i = 0; i < dtMyMails.Rows.Count; i++)
                    {
                        Application.DoEvents();
                        lvwItem = new ListViewItem(dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString());

                        if (LastFileNo != dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString())
                        {
                            sNotifyStr += dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString() + "\n";
                            LastFileNo = dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString();
                        }
                        sEmailSubject = dtMyMails.Rows[i]["EMAIL_SUBJECT"].ToString();
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SUBJECT"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SENT_FROM_NAME"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_RECEIVED_DTTM"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["OPERATOR_MAILBOX_USER_NAME"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["PATIENT_ENQUIRY_ID"].ToString());

                        if (dtMyMails.Rows[i]["PRIORITY_ID"].ToString() == "1" || sEmailSubject.ToUpper().Contains("URGENT") || sEmailSubject.ToUpper().Contains("HIGH"))
                        {
                            lvwItem.ForeColor = Color.White;
                            lstOperatorMailBox.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else if (dtMyMails.Rows[i]["OPERATOR_MAILBOX_USER_NAME"].ToString() == "")
                        {
                            lvwItem.ForeColor = Color.White;
                            lstOperatorMailBox.Items.Add(lvwItem).BackColor = Color.Orange;
                        }
                        else
                        {
                            lstOperatorMailBox.Items.Add(lvwItem);
                        }
                        Application.DoEvents();
                    }
                }

                dtInstantMessages = commonFuncs.Get_My_Instant_Messages(UserID);
                string sInstantMessage = "";
                if (dtInstantMessages.Rows.Count > 0)
                {
                    string sInstantMsg = "";
                    RecordsFound = true;
                    foreach (DataRow drRow in dtInstantMessages.Rows)
                    {
                        sInstantMsg = drRow["INSTANT_MESSAGE_TEXT"].ToString();

                        sInstantMessage += drRow["INSTANT_MESSAGE_FROM"].ToString() + " [" + drRow["PATIENT_FILE_NO"].ToString() + "]  " + drRow["INSTANT_MESSAGE_TEXT"].ToString() + "\n";

                        lvwItem = new ListViewItem(drRow["PATIENT_FILE_NO"].ToString());

                        lvwItem.SubItems.Add("IM - " + drRow["INSTANT_MESSAGE_TEXT"].ToString());
                        lvwItem.SubItems.Add(drRow["USER_FULL_NAME"].ToString());
                        lvwItem.SubItems.Add(drRow["INSTANT_MESSAGE_DTTM"].ToString());
                        lvwItem.SubItems.Add("");
                        lvwItem.SubItems.Add(drRow["IINSTANT_MESSAGE_ID"].ToString());

                        if (sInstantMsg.ToUpper().Contains("URGENT") || sInstantMsg.ToUpper().Contains("HIGH"))
                        {
                            lvwItem.ForeColor = Color.White;
                            lstOperatorMailBox.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else
                        {
                            lstOperatorMailBox.Items.Add(lvwItem);
                        }
                    }
                }

                Int32 sumBasket = dtMyMails.Rows.Count + dtInstantMessages.Rows.Count;
                gpbxOperatorMails.Text = "ADMIN - My Work Basket [" + sumBasket.ToString() + "]";

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

                if (RecordsFound)
                {
                    foreach (ColumnHeader colHead1 in lstOperatorMailBox.Columns)
                    {
                        if (colHead1.Text == "PATIENTENQUIRYID")
                        {
                            colHead1.Width = 0;
                        }
                        else
                        {
                            colHead1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
                else
                {
                    foreach (ColumnHeader colHead1 in lstOperatorMailBox.Columns)
                    {
                        if (colHead1.Text == "PATIENTENQUIRYID")
                        {
                            colHead1.Width = 0;
                        }
                        else
                        {
                            colHead1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        }
                    }
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

        private void LoadMyMailbox(string CoOrdinator, string CoOrdinatorFullName)
        {
            btnMailsRefresh.Enabled = false;
            commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItem;
            DataTable dtMyMails = new DataTable();
            DataTable dtInstantMessages = new DataTable();
            string sNotifyStr = "";
            string LastFileNo = "";
            bool RecordsFound = false;

            lstOperatorMailBox.View = View.Details;
            lstOperatorMailBox.Items.Clear();

            try
            {
                dtMyMails = commonFuncs.Get_AIMS_Administrator_Work(CoOrdinator);

                if (dtMyMails.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMyMails.Rows.Count; i++)
                    {
                        RecordsFound = true;
                        Application.DoEvents();
                        lvwItem = new ListViewItem(dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString());

                        if (LastFileNo != dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString())
                        {
                            sNotifyStr += dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString() + "\n";
                            LastFileNo = dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString();
                        }
                        Application.DoEvents();
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SUBJECT"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SENT_FROM_NAME"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_RECEIVED_DTTM"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["OPERATOR_MAILBOX_USER_NAME"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["PATIENT_ENQUIRY_ID"].ToString());

                        if (dtMyMails.Rows[i]["PRIORITY_ID"].ToString() == "1")
                        {
                            lvwItem.ForeColor = Color.White;
                            lstOperatorMailBox.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else if (dtMyMails.Rows[i]["OPERATOR_MAILBOX_USER_NAME"].ToString() =="")
                        {
                            lvwItem.ForeColor = Color.White;
                            lstOperatorMailBox.Items.Add(lvwItem).BackColor = Color.Orange;                            
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
                    RecordsFound = true;
                    foreach (DataRow drRow in dtInstantMessages.Rows)
                    {
                        sInstantMessage += drRow["INSTANT_MESSAGE_FROM"].ToString() + " [" + drRow["PATIENT_FILE_NO"].ToString() + "]  " + drRow["INSTANT_MESSAGE_TEXT"].ToString() + "\n";

                        lvwItem = new ListViewItem(drRow["PATIENT_FILE_NO"].ToString());

                        lvwItem.SubItems.Add("IM - " + drRow["INSTANT_MESSAGE_TEXT"].ToString());
                        lvwItem.SubItems.Add(drRow["USER_FULL_NAME"].ToString());
                        lvwItem.SubItems.Add(drRow["INSTANT_MESSAGE_DTTM"].ToString());
                        lvwItem.SubItems.Add(drRow["IINSTANT_MESSAGE_ID"].ToString());
                        lstOperatorMailBox.Items.Add(lvwItem);
                    }
                }

                Int32 sumBasket = dtMyMails.Rows.Count + dtInstantMessages.Rows.Count;
                gpbxOperatorMails.Text = CoOrdinatorFullName + " [" + sumBasket.ToString() + "]";

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

                if (RecordsFound)
                {
                    foreach (ColumnHeader colHead1 in lstOperatorMailBox.Columns)
                    {
                        if (colHead1.Text == "PATIENTENQUIRYID")
                        {
                            colHead1.Width = 0;
                        }
                        else
                        {
                            colHead1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
                else
                {
                    foreach (ColumnHeader colHead1 in lstOperatorMailBox.Columns)
                    {
                        if (colHead1.Text == "PATIENTENQUIRYID")
                        {
                            colHead1.Width = 0;
                        }
                        else
                        {
                            colHead1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        }
                    }
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
                btnMailsRefresh.Enabled = false;
            }
        }

        private void LoadMailboxAudit(string CaseCoOrdinator)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            ListViewItem lvwItem;
            DataTable dtMyMails = new DataTable();
            DataTable dtInstantMessages = new DataTable();
            string sNotifyStr = "";
            string LastFileNo = "";
            bool RecordsFound = false;

            lstWorkbasketAudit.Items.Clear();
            lstWorkbasketAudit.View = View.Details;

            try
            {
                dtInstantMessages = commonFuncs.Get_My_Instant_Messages_Audit(UserID);
                string sInstantMessage = "";
                if (dtInstantMessages.Rows.Count > 0)
                {
                    RecordsFound = true;
                    foreach (DataRow drRow in dtInstantMessages.Rows)
                    {
                        sInstantMessage += drRow["INSTANT_MESSAGE_FROM"].ToString() + " [" + drRow["PATIENT_FILE_NO"].ToString() + "]  " + drRow["INSTANT_MESSAGE_TEXT"].ToString() + "\n";

                        lvwItem = new ListViewItem(drRow["PATIENT_FILE_NO"].ToString());

                        lvwItem.SubItems.Add("IM - " + drRow["INSTANT_MESSAGE_TEXT"].ToString());
                        lvwItem.SubItems.Add(drRow["USER_FULL_NAME"].ToString());
                        lvwItem.SubItems.Add(drRow["INSTANT_MESSAGE_DTTM"].ToString());
                        lvwItem.SubItems.Add(drRow["PROCESSED_DTTM"].ToString());
                        lvwItem.SubItems.Add(drRow["PROCESSED_BY"].ToString());
                        lstWorkbasketAudit.Items.Add(lvwItem);
                    }
                }
                dtInstantMessages.Dispose();
                dtMyMails = commonFuncs.Get_AIMS_Admin_Workbasket_Audit(CaseCoOrdinator);
                if (dtMyMails.Rows.Count > 0)
                {
                    RecordsFound = true;
                    for (int i = 0; i < dtMyMails.Rows.Count; i++)
                    {
                        Application.DoEvents();
                        lvwItem = new ListViewItem(dtMyMails.Rows[i]["PATIENT_FILE_NO"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SUBJECT"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_SENT_FROM_NAME"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["EMAIL_RECEIVED_DTTM"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["WORK_ITEM_PROCESSED_DTTM"].ToString());
                        lvwItem.SubItems.Add(dtMyMails.Rows[i]["USER_FULL_NAME"].ToString());
                        lstWorkbasketAudit.Items.Add(lvwItem);
                        foreach (ColumnHeader lstCols in lstWorkbasketAudit.Columns)
                        {
                            lstCols.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                        Application.DoEvents();
                    }
                }
                if (RecordsFound)
                {
                    foreach (ColumnHeader colHead1 in lstWorkbasketAudit.Columns)
                    {
                        colHead1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
                else
                {
                    foreach (ColumnHeader colHead1 in lstWorkbasketAudit.Columns)
                    {
                        colHead1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }

                dtMyMails.Dispose();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error Loading your Work Basket Audit, Please contact System Administror");
                commonFuncs.ErrorLogger("Error Loading your Work Basket Audit: \n" + ex.ToString());
            }
            finally
            {
                lvwItem = null;
            }
        }

        public static DialogResult CoOrdinatorInputBox(string title, string promptText, ref string value, ref string value2, DataTable dtEmailDocTypes)
        {
            Form form = new Form();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Text = title;

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

            DialogResult dialogResult = form.ShowDialog();
            value = cboDocType.Text;
            value2 = System.Convert.ToString(cboDocType.SelectedValue);
            return dialogResult;
        }

        private void WorkbasketAuditListSetup()
        {
            lstWorkbasketAudit.Columns.Clear();
            lstWorkbasketAudit.Items.Clear();
            lstWorkbasketAudit.Columns.Add("File No", Convert.ToInt32(lstOperatorMailBox.Width * 0.2), HorizontalAlignment.Left);
            lstWorkbasketAudit.Columns.Add("Mail Subject", Convert.ToInt32(lstOperatorMailBox.Width * 0.5), HorizontalAlignment.Left);
            lstWorkbasketAudit.Columns.Add("Mail From", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
            lstWorkbasketAudit.Columns.Add("Mail Received", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
            lstWorkbasketAudit.Columns.Add("Processed Date", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
            lstWorkbasketAudit.Columns.Add("Processed By", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
        }

        private void WorkbasketListSetup()
        {
            lstOperatorMailBox.Columns.Clear();
            lstOperatorMailBox.Items.Clear();
            lstOperatorMailBox.Columns.Add("Patient File No", Convert.ToInt32(lstOperatorMailBox.Width * 0.2), HorizontalAlignment.Left);
            lstOperatorMailBox.Columns.Add("Mail Subject", Convert.ToInt32(lstOperatorMailBox.Width * 0.5), HorizontalAlignment.Left);
            lstOperatorMailBox.Columns.Add("Mail From", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
            lstOperatorMailBox.Columns.Add("Mail Received", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
            lstOperatorMailBox.Columns.Add("File Administrator", Convert.ToInt32(lstOperatorMailBox.Width * 0.3), HorizontalAlignment.Left);
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

        private void frmWorkbasketAdmin_Resize(object sender, EventArgs e)
        {
            gpbxOperatorMails.Height = ClientSize.Height - 50;
            lstOperatorMailBox.Height = gpbxOperatorMails.Height - 50;
        }

        private void btnWorkBasketView_Click(object sender, EventArgs e)
        {
            btnMailsRefresh.Enabled = false;
            try
            {
                DataTable dtOpsCoOrdinators = new DataTable();

                commonFuncs = new AIMS.Common.CommonFunctions();
                if (MessageBox.Show("Continue changing workbasket View?", "Workbasket View Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtOpsCoOrdinators = commonFuncs.GetWorkbasketAdministrators();
                    DialogResult dgWindow = CoOrdinatorInputBox("Administrators Workbasket View", "Administrator", ref coOrdinatorName, ref coOrdinatorUserName, dtOpsCoOrdinators);
                    if (dgWindow == DialogResult.OK)
                    {
                        if (!coOrdinatorUserName.Trim().Equals(""))
                        {
                            LoadMyMailbox(coOrdinatorUserName, coOrdinatorName);
                            LoadMailboxAudit(coOrdinatorUserName);
                            btnMailsRefresh.Enabled = true;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                btnMailsRefresh.Enabled = true;
            }
        }

        private void btnMailsRefresh_Click(object sender, EventArgs e)
        {
            btnMailsRefresh.Enabled = false;
            try
            {
                lstOperatorMailBox.Items.Clear();

                if (coOrdinatorUserName.Equals("") || coOrdinatorUserName.Equals(UserID))
                {
                    LoadMyMailbox();
                    DialogResult dgRes = MessageBox.Show("Admin Global workbasket audit records refresh will take longer, Do you want to proceed still ?", "Global Audit Refresh", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dgRes == DialogResult.Yes)
                    {
                        LoadMailboxAudit(UserID);
                    }
                }
                else
                {
                    LoadMyMailbox(coOrdinatorUserName, coOrdinatorName);
                    LoadMailboxAudit(coOrdinatorUserName);
                }
                Application.DoEvents();
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                btnMailsRefresh.Enabled = true;
            }
        }
    }
}