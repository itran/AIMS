using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIMS.Common;

namespace AIMSClient
{
    public partial class frmAIMSDashboard : Form
    {
        public AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
        Int32 iCountDown = 60;   

        public frmAIMSDashboard()
        {
            InitializeComponent();
        }

        #region "Private Properties"
        string _userName = "";
        string _userID = "";
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

        private void frmAIMSDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                WorkAllocatedFileListSetup();
                PendedFileListSetup();
                AllocatedFileListSetup();
                UrgentEmailsListSetup();
                AdminPendingFileListSetup();

                LoadActiveCallList();
                LoadPendedcaseList();
                LoadWorkAllocationList();
                LoadUrgentEmailsList();
                LoadUnallocatedFiles();
                LoadAllWorkBasket();

                if (UserAllowed("99"))
                {
                    timer1.Enabled = true;
                    dashTimer.Enabled = true;
                    lblCountDown.Visible = true; 
                }
                else
                {
                    timer1.Enabled = false;
                    dashTimer.Enabled = false;
                    lblCountDown.Visible = false;
                }
            }
            catch (System.Exception ex)
            {
            
            }
        }

        private void frmAIMSDashboard_Resize(object sender, EventArgs e)
        {
            grpbxAllocatedFiles.Height = tabDashboards.Height / 2;
            grpbxAllocatedFiles.Width = tabDashboards.Width - 30;
            
            grpbxPendedFiles.Top = grpbxAllocatedFiles.Bottom;
            grpbxPendedFiles.Left = grpbxAllocatedFiles.Left;

            grpbxWorkAllocated.Top = grpbxPendedFiles.Top;
            grpbxWorkAllocated.Left = grpbxPendedFiles.Left + grpbxPendedFiles.Width;

            btnRefresh.Top = grpbxPendedFiles.Top + 5;
            btnRefresh.Left = (grpbxWorkAllocated.Left + grpbxWorkAllocated.Width) + 5;

            grpbxUrgentEmails.Top = grpbxWorkAllocated.Bottom;
            grpbxUrgentEmails.Left = grpbxPendedFiles.Left;

            groupBox2.Top = grpbxWorkAllocated.Bottom;
            groupBox2.Left = grpbxPendedFiles.Left;
            lblCountDown.Left = groupBox2.Width + 5;
            lblCountDown.Top  = groupBox2.Top;

            lblUnallocateFiles.Left = btnRefresh.Left;
            lblUnallocateFiles.Top = btnRefresh.Bottom + 5;
            lblLinkUnallocatedFiles.Left = lblUnallocateFiles.Left;
            lblLinkUnallocatedFiles.Top = lblUnallocateFiles.Bottom + 1;


            lblAllWorkbaskets.Left = lblUnallocateFiles.Width + lblUnallocateFiles.Left;
            lblAllWorkbaskets.Top = btnRefresh.Bottom + 5;

            lblLinkAllWorkbaskets.Left = lblAllWorkbaskets.Left;
            lblLinkAllWorkbaskets.Top = lblLinkUnallocatedFiles.Top;

            lineSep.Left = lblAllWorkbaskets.Left - 2;
            lineSep.Top = lblAllWorkbaskets.Top;


        }
 

        private void AllocatedFileListSetup()
        {
            try
            {
                lstAllocatedCases.Columns.Clear();
                lstAllocatedCases.Items.Clear();
                
                lstAllocatedCases.Columns.Add("Case Manager");
                lstAllocatedCases.Columns[0].Width = 100;
                
                lstAllocatedCases.Columns.Add("Patient File No");
                lstAllocatedCases.Columns[1].Width = 100;
                
                lstAllocatedCases.Columns.Add("Patient Name");
                lstAllocatedCases.Columns[2].Width = 200;
                
                //lstAllocatedCases.Columns.Add("Guarantor");
                //lstAllocatedCases.Columns[3].Width = 250;
                
                lstAllocatedCases.Columns.Add("Admission Date");
                lstAllocatedCases.Columns[3].Width = 100;
                
                //lstAllocatedCases.Columns.Add("Discharge Date");
                //lstAllocatedCases.Columns[5].Width = 100;

                lstAllocatedCases.Columns.Add("Last Note/Comment Captured");
                lstAllocatedCases.Columns[4].Width = 550;

                lstAllocatedCases.Columns.Add("Note/Comment Date Time");
                lstAllocatedCases.Columns[5].Width = 150;
            }
            finally
            {
            }
        }

        private void UrgentEmailsListSetup()
        {
            lstVwUrgentEmails.View = View.Details;
            lstVwUrgentEmails.Columns.Add("Patient File No");
            lstVwUrgentEmails.Columns.Add("Email Received");
            lstVwUrgentEmails.Columns.Add("Case Co-Ordinator");

            foreach (ColumnHeader  colHeader in lstVwUrgentEmails.Columns)
            {
                colHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public void LoadPendedcaseList()
        {
            try
            {
                lstPendedCase.Items.Clear();
                ListViewItem lvwItem;
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetPendedFiles();

                string PatientFileNo = "";
                string AdmissionDate = "";
                string PatientName = "";
                string FileAllocatedTo = "";
                string PendDays = "", PendDate = "";
                string LastNoteCaptured = "";
                string NotesDateTime = "";
                string GuarantorName = "";

                try
                {
                    for (int i = 0; i < tblAllocatedFiles.Rows.Count; i++)
                    {
                        PatientFileNo = tblAllocatedFiles.Rows[i]["patient_file_no"].ToString();
                        AdmissionDate = tblAllocatedFiles.Rows[i]["patient_admission_date"].ToString();
                        FileAllocatedTo = tblAllocatedFiles.Rows[i]["User_Full_Name"].ToString();
                        PatientName = tblAllocatedFiles.Rows[i]["patient_name"].ToString();
                        PendDate = tblAllocatedFiles.Rows[i]["pend_date"].ToString();
                        PendDays = tblAllocatedFiles.Rows[i]["PendDays"].ToString();
                        GuarantorName = tblAllocatedFiles.Rows[i]["guarantor_name"].ToString();

                        lvwItem = new ListViewItem(FileAllocatedTo);
                        
                        lvwItem.SubItems.Add(PatientFileNo);
                        lvwItem.SubItems.Add(PatientName);
                        lvwItem.SubItems.Add(AdmissionDate);
                        lvwItem.SubItems.Add(GuarantorName);                        
                        lvwItem.SubItems.Add(PendDate);
                        lvwItem.SubItems.Add(PendDays);
                        if (System.Convert.ToInt32(PendDays) > 10)
                        {
                            lstPendedCase.Items.Add(lvwItem).BackColor = Color.Red;
                        }else
	                    {
                            lstPendedCase.Items.Add(lvwItem);
	                    }                                                
                    }
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Active Calls Dashboard, Please contact System Administrator");
                    commonFuncs.ErrorLogger("Loading Active Calls Dashboard: " + ex.ToString());
                }
                finally
                {
                    lvwItem = null;
                    tblAllocatedFiles.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void LoadUnallocatedFiles()
        {
            try
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetUnallocatedFiles();
                lblLinkUnallocatedFiles.Text = tblAllocatedFiles.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void LoadAllWorkBasket()
        {
            try
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetAllWorkbasketFiles();
                lblLinkAllWorkbaskets.Text = tblAllocatedFiles.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void LoadWorkAllocationList()
        {
            try
            {
                lstWorkAllocated.Items.Clear();
                ListViewItem lvwItem;
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetWorkAllocations();

                string CaseManager = "";
                string FilesCount = "";
                string FilesOperator = "";

                try
                {
                    for (int i = 0; i < tblAllocatedFiles.Rows.Count; i++)
                    {
                        CaseManager = tblAllocatedFiles.Rows[i][0].ToString();
                        FilesCount = tblAllocatedFiles.Rows[i][1].ToString();
                        FilesOperator = tblAllocatedFiles.Rows[i]["FILE_OPERATOR_TO_USERID"].ToString(); 

                        lvwItem = new ListViewItem(CaseManager);
                        lvwItem.SubItems.Add(FilesCount);
                        lvwItem.SubItems.Add(FilesOperator);

                        lstWorkAllocated.Items.Add(lvwItem);
                    }
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Active Calls Dashboard, Please contact System Administrator");
                    commonFuncs.ErrorLogger("Loading Active Calls Dashboard: " + ex.ToString());
                }
                finally
                {
                    lvwItem = null;
                    tblAllocatedFiles.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        private void PendedFileListSetup()
        {
            try
            {
                lstPendedCase.Columns.Clear();
                lstPendedCase.Items.Clear();

                lstPendedCase.Columns.Add("Case Manager");
                lstPendedCase.Columns[0].Width = 100;

                lstPendedCase.Columns.Add("Patient File No");
                lstPendedCase.Columns[1].Width = 100;

                lstPendedCase.Columns.Add("Patient Name");
                lstPendedCase.Columns[2].Width = 200;

                lstPendedCase.Columns.Add("Patient Admission Date");
                lstPendedCase.Columns[3].Width = 100;

                lstPendedCase.Columns.Add("Guarantor");
                lstPendedCase.Columns[4].Width = 200;

                lstPendedCase.Columns.Add("Case Pend date");
                lstPendedCase.Columns[5].Width = 150;

                lstPendedCase.Columns.Add("Days Pended");
                lstPendedCase.Columns[6].Width = 150;
            }
            finally
            {
            }
        }

        private void AdminPendingFileListSetup()
        {
            try
            {
                lstAdminPendingFiles.Columns.Clear();
                lstAdminPendingFiles.Items.Clear();
                
                lstAdminPendingFiles.Columns.Add("Case Administrator");
                lstAdminPendingFiles.Columns[0].Width = 150;

                lstAdminPendingFiles.Columns.Add("Patient File No");
                lstAdminPendingFiles.Columns[1].Width = 150;
                
                lstAdminPendingFiles.Columns.Add("Patient Name");
                lstAdminPendingFiles.Columns[2].Width = 150;

                lstAdminPendingFiles.Columns.Add("Patient Discharge Date");
                lstAdminPendingFiles.Columns[3].Width = 150;

                lstAdminPendingFiles.Columns.Add("File Received Date");
                lstAdminPendingFiles.Columns[4].Width = 150;

                lstAdminPendingFiles.Columns.Add("Patient File Creation");
                lstAdminPendingFiles.Columns[5].Width = 150;

                lstAdminPendingFiles.Columns.Add("Days Pending");
                lstAdminPendingFiles.Columns[6].Width = 100;

                lstAdminPendingFiles.View = View.Details;
            }
            finally
            {
            }
        }

        private void WorkAllocatedFileListSetup()
        {
            try
            {
                lstWorkAllocated.Columns.Clear();
                lstWorkAllocated.Items.Clear();

                lstWorkAllocated.Columns.Add("Case Manager");
                lstWorkAllocated.Columns[0].Width = 100;

                lstWorkAllocated.Columns.Add("Cases Allocated");
                lstWorkAllocated.Columns[1].Width = 100;

                lstWorkAllocated.Columns.Add("OWNER");
                lstWorkAllocated.Columns[2].Width = 0;

                foreach (ColumnHeader  colHD in lstWorkAllocated.Columns)
                {
                    if (colHD.Text == "OWNER")
                    {
                        colHD.Width = 0;
                    }
                }
            }
            finally
            {
            }
        }

        public void LoadActiveCallList()
        {
            try
            {
                lstAllocatedCases.Items.Clear();
                ListViewItem lvwItem;
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetAllocatedFiles();
                
                string PatientFileNo = "";
                string AdmissionDate = "";
                string PatientName = "";
                string FileAllocatedTo = "";
                string DischargeDate = "";
                string LastNoteCaptured = "";
                string NotesDateTime = "";
                string GuarantorName = "";
                string CommentSLA = "";
                
                try
                {                    
                    for (int i = 0; i < tblAllocatedFiles.Rows.Count; i++)
                    {
                        FileAllocatedTo = tblAllocatedFiles.Rows[i]["FILE_ALLOCATED_TO"].ToString();
                        PatientFileNo = tblAllocatedFiles.Rows[i]["PATIENT_FILE_NO"].ToString();
                        PatientName = tblAllocatedFiles.Rows[i]["PATIENT_NAME"].ToString();
                        GuarantorName = tblAllocatedFiles.Rows[i]["GUARANTOR_NAME"].ToString();
                        AdmissionDate = tblAllocatedFiles.Rows[i]["PATIENT_ADMISSION_DATE"].ToString();
                        DischargeDate = tblAllocatedFiles.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString();
                        LastNoteCaptured = tblAllocatedFiles.Rows[i]["LAST_NOTE_CAPTURED"].ToString();
                        NotesDateTime = tblAllocatedFiles.Rows[i]["NOTES_DTTM"].ToString();
                        CommentSLA = tblAllocatedFiles.Rows[i]["COMMENT_SLA"].ToString();

                        lvwItem = new ListViewItem(FileAllocatedTo);
                        lvwItem.SubItems.Add(PatientFileNo);
                        lvwItem.SubItems.Add(PatientName);
                        //lvwItem.SubItems.Add(GuarantorName);
                        lvwItem.SubItems.Add(AdmissionDate);
                        //lvwItem.SubItems.Add(DischargeDate);
                        lvwItem.SubItems.Add(LastNoteCaptured);
                        lvwItem.SubItems.Add(NotesDateTime);

                        if (System.Convert.ToInt32(CommentSLA) > 2)
                        {
                            lstAllocatedCases.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else
                        {
                            lstAllocatedCases.Items.Add(lvwItem);
                        }                         
                    }
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Active Calls Dashboard, Please contact System Administrator");
                    commonFuncs.ErrorLogger("Loading Active Calls Dashboard: " + ex.ToString());
                }
                finally
                {
                    lvwItem = null;
                    tblAllocatedFiles.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void lstAllocatedCases_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstAllocatedCases_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string LastNote = lstGet.Items[i].SubItems[4].Text.ToString();
                        MessageBox.Show(LastNote, "Last Note Capture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (System.Exception ex)
            {
                lstGet = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                btnRefresh.Enabled = false;
                LoadActiveCallList();
                LoadPendedcaseList();
                LoadWorkAllocationList();
                LoadUrgentEmailsList();
                LoadUnallocatedFiles();
                LoadAllWorkBasket();
            }
            finally 
            {
                btnRefresh.Enabled = true;
            }
        }

        private void dashTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (UserAllowed("99"))
                {
                    btnRefresh.Enabled = false;
                    LoadActiveCallList();
                    LoadPendedcaseList();
                    LoadWorkAllocationList();
                    LoadUrgentEmailsList();
                    LoadUnallocatedFiles();
                    LoadAllWorkBasket();
                }
            }
            finally
            {
                btnRefresh.Enabled = true;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void LoadPendingAdminFiles()
        {
            try
            {
                lstAdminPendingFiles.Items.Clear();
                ListViewItem lvwItem;
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblUrgentEmailsFiles = commonFuncs.GetUrgentEmails();

                string PatientFileNo = "";
                string EmailReceivedDTTM = "";
                string CaseManager = "";
                
                try
                {
                    for (int i = 0; i < tblUrgentEmailsFiles.Rows.Count; i++)
                    {
                        PatientFileNo = tblUrgentEmailsFiles.Rows[i][0].ToString();
                        EmailReceivedDTTM = tblUrgentEmailsFiles.Rows[i][1].ToString();
                        CaseManager = tblUrgentEmailsFiles.Rows[i][2].ToString();

                        lvwItem = new ListViewItem(PatientFileNo);
                        lvwItem.SubItems.Add(EmailReceivedDTTM);
                        lvwItem.SubItems.Add(CaseManager);

                        lstAdminPendingFiles.Items.Add(lvwItem).BackColor = Color.Orange;
                    }

                    foreach (ColumnHeader colHdr in lstAdminPendingFiles.Columns)
                    {
                        colHdr.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Pending Admin Files, Please contact System Administrator");
                    commonFuncs.ErrorLogger("Loading Pending Admin Files: " + ex.ToString());
                }
                finally
                {
                    lvwItem = null;
                    tblUrgentEmailsFiles.Dispose();
                }
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Urgent Emails on Dashboard, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading Urgent Emails on Dashboard: " + ex.ToString());

            }
        }

        public void LoadUrgentEmailsList()
        {
            try
            {
                lstVwUrgentEmails.Items.Clear();
                ListViewItem lvwItem;
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblUrgentEmailsFiles = commonFuncs.GetUrgentEmails();

                string PatientFileNo = "";
                string EmailReceivedDTTM = "";
                string CaseManager = "";
                
                try
                {
                    for (int i = 0; i < tblUrgentEmailsFiles.Rows.Count; i++)
                    {
                        PatientFileNo = tblUrgentEmailsFiles.Rows[i][0].ToString();
                        EmailReceivedDTTM = tblUrgentEmailsFiles.Rows[i][1].ToString();
                        CaseManager = tblUrgentEmailsFiles.Rows[i][2].ToString();

                        lvwItem = new ListViewItem(PatientFileNo);
                        lvwItem.SubItems.Add(EmailReceivedDTTM);
                        lvwItem.SubItems.Add(CaseManager);

                        lstVwUrgentEmails.Items.Add(lvwItem).BackColor = Color.Orange;
                    }

                    foreach (ColumnHeader  colHdr in lstVwUrgentEmails.Columns)
                    {
                        colHdr.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Urgent Emails Dashboard, Please contact System Administrator");
                    commonFuncs.ErrorLogger("Loading Urgent Emails Dashboard: " + ex.ToString());
                }
                finally
                {
                    lvwItem = null;
                    tblUrgentEmailsFiles.Dispose();
                }
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Urgent Emails on Dashboard, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading Urgent Emails on Dashboard: " + ex.ToString());

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void lstWorkAllocated_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstWorkAllocated_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    if (lstWorkAllocated.FocusedItem.Bounds.Contains(e.Location) == true)
            //    {
            //        cntxMenuWork.Show(Cursor.Position);
            //    }
            //}
        }

        private void lstWorkAllocated_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo HI = lstWorkAllocated.HitTest(e.Location);
            if (e.Button == MouseButtons.Right && lstWorkAllocated.SelectedItems.Count >0)
            {
                cntxMenuWork.Show(Cursor.Position);
                if (HI.Location == ListViewHitTestLocations.None)
                {
                    cntxMenuWork.Items[0].Visible = false;
                }
                else
                {
                    cntxMenuWork.Items[0].Visible = true;
                }
            }
        }

        private void lstWorkAllocated_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string CoOrdinator = lstGet.Items[i].SubItems[2].Text.ToString();
                        string CoOrdinatorName = lstGet.Items[i].SubItems[0].Text.ToString();
                        
                        try
                        {
                            frmReportViewer frmRep = new frmReportViewer(CoOrdinator, "CoOrdinator Cases");
                            commonFuncs = new AIMS.Common.CommonFunctions();

                            frmRep.StartPosition = FormStartPosition.CenterScreen;
                            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                            StringBuilder sbHTML = new StringBuilder();

                            try
                            {
                                frmRep.CaseCoOrdinator = CoOrdinator;
                                frmRep.CoOrdinatorName = CoOrdinatorName;
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

        private void lblLinkUnallocatedFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmReportViewer frmRep = new frmReportViewer("", "Unallocated Files");
            commonFuncs = new AIMS.Common.CommonFunctions();

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            StringBuilder sbHTML = new StringBuilder();

            try
            {
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void showCoOrdinatorWorkLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstWorkAllocated.SelectedItems.Count <=0)
            {
                return;
            }
            else
            {
                string CoOrdinator = lstWorkAllocated.SelectedItems[0].SubItems[2].Text.ToString();
                string CoOrdinatorName = lstWorkAllocated.SelectedItems[0].SubItems[0].Text.ToString(); ;

                try
                {
                    frmReportViewer frmRep = new frmReportViewer(CoOrdinator, "CoOrdinator Snapshot");
                    commonFuncs = new AIMS.Common.CommonFunctions();

                    frmRep.StartPosition = FormStartPosition.CenterScreen;
                    frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                    frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                    StringBuilder sbHTML = new StringBuilder();

                    try
                    {
                        frmRep.CaseCoOrdinator = CoOrdinator;
                        frmRep.CoOrdinatorName = CoOrdinatorName;
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

        private void lblLinkAllWorkbaskets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblUnallocateFiles_Click(object sender, EventArgs e)
        {

        }

        private void lineSep_Click(object sender, EventArgs e)
        {

        }

        private void lblAllWorkbaskets_Click(object sender, EventArgs e)
        {

        }

    }
}