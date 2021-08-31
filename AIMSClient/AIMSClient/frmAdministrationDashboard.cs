using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmAdministrationDashboard : Form
    {
        public frmAdministrationDashboard()
        {
            InitializeComponent();
        }

        public AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
        Int32 iCountDown = 60;

        Int32 Minutes = 4;
        Int32 Seconds = 0;   

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

        private void frmAdministrationDashboard_Resize(object sender, EventArgs e)
        {
            //this.panel1.Location = new Point(0, 0);            
            //this.panel1.Height = this.Bottom - 100;
            //this.panel1.Width = this.ClientSize.Width;

            //lblAllWorkbaskets.Top = this.panel1.Bottom;
            //lblAllWorkbaskets.Left = this.panel1.Left;

            //lblUnallocateFiles.Top = this.panel1.Bottom;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Height = 200;
            this.panel2.Width = this.ClientSize.Width;

            this.panel1.Top = this.panel2.Bottom + 5;
            this.panel1.Left = this.panel2.Left;
            this.panel1.Height = this.Bottom - 150;
            this.panel1.Width = this.ClientSize.Width;
        }

        public void LoadAdminClosedFiles()
        {
            try
            {
                lstFilesClosed.Items.Clear();
                ListViewItem lvwItem;
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetAdminClosedFiles();

                string PatientFileNo = "";
                string CourierDueDate = "";
                string AdminStaff = "";
                string sendToAdmin = "";
                string Category = "";
                string HighCost = "";

                try
                {
                    for (int i = 0; i < tblAllocatedFiles.Rows.Count; i++)
                    {
                        PatientFileNo = tblAllocatedFiles.Rows[i]["FILE_NO"].ToString();
                        CourierDueDate = tblAllocatedFiles.Rows[i]["COURIER_DUE_DATE"].ToString();
                        AdminStaff = tblAllocatedFiles.Rows[i]["FILE_ASSIGNED_TO_USERID"].ToString();
                        HighCost = tblAllocatedFiles.Rows[i]["HIGH_COST"].ToString();

                        if (tblAllocatedFiles.Rows[i]["IN_PATIENT"].ToString() == "Y") Category = "IN-Patient";
                        if (tblAllocatedFiles.Rows[i]["OUT_PATIENT"].ToString() == "Y") Category = "OUT-Patient";
                        if (tblAllocatedFiles.Rows[i]["RMR"].ToString() == "Y") Category = "RMR";
                        if (tblAllocatedFiles.Rows[i]["FLIGHT"].ToString() == "Y") Category = "Flight";
                        if (tblAllocatedFiles.Rows[i]["TRANSPORT"].ToString() == "Y") Category = "Transport";
                        if (tblAllocatedFiles.Rows[i]["ASSIST"].ToString() == "Y") Category = "Assistance";
                        if (tblAllocatedFiles.Rows[i]["REPAT"].ToString() == "Y") Category = "Repat";

                        DateTime dtDueDate = System.Convert.ToDateTime(CourierDueDate);

                        lvwItem = new ListViewItem(PatientFileNo);
                        lvwItem.SubItems.Add(AdminStaff);
                        CourierDueDate = dtDueDate.ToString("dd/MMM/yyyy");
                        lvwItem.SubItems.Add(CourierDueDate);
                        lvwItem.SubItems.Add(Category);

                        System.TimeSpan diffResult = DateTime.Today.Date - dtDueDate;

                        if (HighCost == "Y")
                        {
                            lstFilesClosed.Items.Add(lvwItem).BackColor = Color.Red;
                        }
                        else if (diffResult.Days > 2)
                        {
                            lstFilesClosed.Items.Add(lvwItem).BackColor = Color.Yellow;
                        }
                        else
                        {
                            lstFilesClosed.Items.Add(lvwItem);
                        }
                    }
                    grpbxClosedCouried.Text = "Files Closed and Not Couriered [" + tblAllocatedFiles.Rows.Count.ToString() + "]";
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Admin Dashboard, Please contact System Administrator");
                    commonFuncs.ErrorLogger("Loading Admin Dashboard: " + ex.ToString());
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

        private void SetLists() {

            lstWorkAllocated.Columns.Clear();
            lstWorkAllocated.Items.Clear();

            lstWorkAllocated.Columns.Add("Case Administrator");
            lstWorkAllocated.Columns[0].Width = 90;

            lstWorkAllocated.Columns.Add("Cases Assigned");
            lstWorkAllocated.Columns[1].Width = 90;

            lstFilesClosed.Columns.Clear();
            lstFilesClosed.Items.Clear();

            lstFilesClosed.Columns.Add("File No");
            lstFilesClosed.Columns[0].Width = 150;

            lstFilesClosed.Columns.Add("Name");
            lstFilesClosed.Columns[1].Width = 300;

            lstFilesClosed.Columns.Add("Courier Due Date");
            lstFilesClosed.Columns[1].Width = 250;

            lstFilesClosed.Columns.Add("Category");
            lstFilesClosed.Columns[1].Width = 300;
            lstFilesClosed.View = View.Details;
        }
        private void frmAdministrationDashboard_Load(object sender, EventArgs e)
        {
            LoadAdministrationDashboard();
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

        private GroupBox gbDynamicGroupBox;
        private GroupBox gbHighCostGroupBox;

        public void LoadAdministratorFiles(string adminStaff, ListView adminStaffList)
        {
            try
            {
                adminStaffList.Items.Clear();
                ListViewItem lvwItem;
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetAdminAllocatedFiles(adminStaff);

                string PatientFileNo = "";
                string highCostFile = "";
                string DueDate = "";
                GroupBox grpBx = new GroupBox();

                try
                {
                    for (int i = 0; i < tblAllocatedFiles.Rows.Count; i++)
                    {
                        PatientFileNo = tblAllocatedFiles.Rows[i]["FILE_NO"].ToString();
                        highCostFile = tblAllocatedFiles.Rows[i]["HIGH_COST"].ToString();
                        DueDate = tblAllocatedFiles.Rows[i]["DUE_DATE"].ToString();

                        DateTime dtDueDate = System.Convert.ToDateTime(DueDate);

                        lvwItem = new ListViewItem(PatientFileNo);
                        DueDate = dtDueDate.ToString("dd/MMM/yyyy");

                        lvwItem.SubItems.Add(DueDate);

                        System.TimeSpan diffResult = DateTime.Today.Date - dtDueDate;

                        if (highCostFile == "Y")
                        {
                            adminStaffList.Items.Add(lvwItem).BackColor = Color.Red;
                            continue;
                        }

                        if (diffResult.Days > 2)
                        {
                            adminStaffList.Items.Add(lvwItem).BackColor = Color.Yellow;
                        }
                        else
                        {
                            adminStaffList.Items.Add(lvwItem);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Admin Dashboard, Please contact System Administrator");
                    commonFuncs.ErrorLogger("Loading Admin Dashboard: " + ex.ToString());
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

        private void createCoOrdGroupBox(string controlName)
        {
            ListViewItem lvwItem;
            commonFuncs = new AIMS.Common.CommonFunctions();
            DataTable tblAllocatedFiles = commonFuncs.GetAdminAllocatedFiles(controlName);

            string PatientFileNo = "";
            string highCostFile = "";
            string DueDate = "";
            GroupBox grpBx = new GroupBox();

            commonFuncs = new AIMS.Common.CommonFunctions();
            
            try
            {
                ListView lstCoOrd = new ListView();

                lstCoOrd.Location = new Point(10, 20);
                lstCoOrd.Size = new Size(250, 100);
                lstCoOrd.View = View.Details;

                lstCoOrd.FullRowSelect = true;
                lstCoOrd.Columns.Add("Case Number", 80);
                lstCoOrd.Columns.Add("Admission Date", 100);
                lstCoOrd.Columns.Add("Discharge Date", 100);
                lstCoOrd.Columns.Add("Category", 80);

                AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
                tblAllocatedFiles = commonDAL.GetAdminAllocatedFiles(controlName);

                string patientFileNo;
                string admissionDate;
                string dischargeDt;
                string category;
                string CommentSLA = "";
                string SentToAdmin = "";

                Int32 workTodo = 0;
                workTodo = tblAllocatedFiles.Rows.Count;

                if (tblAllocatedFiles.Rows.Count == 0)
                    return;

                for (int i = 0; i < tblAllocatedFiles.Rows.Count; i++)
                {
                    PatientFileNo = tblAllocatedFiles.Rows[i]["FILE_NO"].ToString();
                    highCostFile = tblAllocatedFiles.Rows[i]["HIGH_COST"].ToString();
                    DueDate = tblAllocatedFiles.Rows[i]["DUE_DATE"].ToString();

                    DateTime dtDueDate = System.Convert.ToDateTime(DueDate);

                    lvwItem = new ListViewItem(PatientFileNo);
                    DueDate = dtDueDate.ToString("dd/MMM/yyyy");

                    lvwItem.SubItems.Add(DueDate);

                    System.TimeSpan diffResult = DateTime.Today.Date - dtDueDate;

                    if (highCostFile == "Y")
                    {
                        lstCoOrd.Items.Add(lvwItem).BackColor = Color.Red;
                        continue;
                    }

                    if (diffResult.Days > 2)
                    {
                        lstCoOrd.Items.Add(lvwItem).BackColor = Color.Yellow;
                    }
                    else
                    {
                        lstCoOrd.Items.Add(lvwItem);
                    }
                }

                gbDynamicGroupBox = new GroupBox();
                this.gbDynamicGroupBox.Location = new Point(100, 14);
                this.gbDynamicGroupBox.Size = new Size(400, 250);
                this.gbDynamicGroupBox.Font = new Font("Arial", 10, FontStyle.Bold);
                this.gbDynamicGroupBox.ForeColor = Color.OrangeRed;
                lstCoOrd.Font = new Font("Arial", 10, FontStyle.Regular);
                lstCoOrd.Height = this.gbDynamicGroupBox.ClientSize.Height - 30;
                lstCoOrd.Width = this.gbDynamicGroupBox.ClientSize.Width - 15;
                this.gbDynamicGroupBox.Text = controlName + " [" + workTodo + "]";
                this.gbDynamicGroupBox.Name = controlName;
                this.gbDynamicGroupBox.Click += new System.EventHandler(questionGroupBox_Click);

                this.gbDynamicGroupBox.Controls.Add(lstCoOrd);

                this.Controls.Add(gbDynamicGroupBox);

                this.panel1.Controls.Add(gbDynamicGroupBox);
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Loading Group Box for Operators:" + ex.ToString());
            }
            finally
            {
                tblAllocatedFiles.Dispose();
                GC.Collect();
            }
        }

        private void questionGroupBox_Click(object sender, EventArgs e)
        {
            string  coOrdinator = ((GroupBox)sender).Name;
            
            string CoOrdinatorName = coOrdinator;

            try
            {
                frmReportViewer frmRep = new frmReportViewer(coOrdinator, "ADMINISTRATOR CAS");
                commonFuncs = new AIMS.Common.CommonFunctions();

                frmRep.StartPosition = FormStartPosition.CenterScreen;
                frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
                frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

                try
                {
                    frmRep.CaseCoOrdinator = coOrdinator;
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

        private void lstCoOrd_MouseDown(object sender, MouseEventArgs e)
        {
            ListView lstWorkAllocated = ((ListView)sender);
            ListViewHitTestInfo HI = lstWorkAllocated.HitTest(e.Location);
            if (e.Button == MouseButtons.Right && lstWorkAllocated.SelectedItems.Count > 0)
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

        private void showCoOrdinatorWorkLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView lstWorkAllocated = ((ListView)sender);
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
                GC.Collect();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        public void LoadUnallocatedFiles()
        {
            try
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetAdminUnallocatedFiles();
                lblLinkUnallocatedFiles.Text = tblAllocatedFiles.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                commonFuncs.ErrorLogger("OPS Dashboard - LoadUnallocatedFiles Error: " + ex.ToString());
            }
        }

        public void LoadAllWorkBasket()
        {
            try
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetAllAdminWorkbasketFiles();
                lblLinkAllWorkbaskets.Text = tblAllocatedFiles.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                commonFuncs.ErrorLogger("OPS Dashboard - LoadAllWorkBasket Error: " + ex.ToString());
            }
        }

        private void lblLinkAllWorkbaskets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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

        public void LoadAdminWorkAllocationList()
        {
            try
            {
                lstWorkAllocated.Items.Clear();
                ListViewItem lvwItem;
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetAdminWorkAllocations();

                string CaseManager = "";
                string FilesCount = "";
                string FilesOperator = "";

                try
                {
                    for (int i = 0; i < tblAllocatedFiles.Rows.Count; i++)
                    {
                        CaseManager = tblAllocatedFiles.Rows[i]["file_assigned_to_userid"].ToString();
                        FilesCount = tblAllocatedFiles.Rows[i]["file_count"].ToString();

                        lvwItem = new ListViewItem(CaseManager);
                        lvwItem.SubItems.Add(FilesCount);

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

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            try
            {
                panel1.Controls.Clear();
                LoadAllWorkBasket();
                LoadUnallocatedFiles();
                DataTable dtFileOperators = new DataTable();
                dtFileOperators = commonFuncs.GetFileOperators();
                string CoOrdinator = "";

                for (int i = 0; i < dtFileOperators.Rows.Count; i++)
                {
                    CoOrdinator = dtFileOperators.Rows[i]["USER_NAME"].ToString();
                    if (!CoOrdinator.Trim().Equals("") && !CoOrdinator.Contains("All Workbaskets"))
                    {
                        createCoOrdGroupBox(CoOrdinator);
                    }
                }
                LoadAdminClosedFiles();
                LoadAdminWorkAllocationList();
            }
            finally
            {
                btnRefresh.Enabled = true;
                GC.Collect();
            }
        }

        private void dashTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (UserAllowed("99"))
                {
                    LoadAdministrationDashboard();
                }
            }
            finally
            {
                dashTimer.Stop();
                btnRefresh.Enabled = true;
                GC.Collect();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iCountDown -= 1;
            

            if (iCountDown.ToString().Length == 1)
            {
                lblCountDown.Text = "0" + Minutes + ":" + "0" + iCountDown.ToString();
            }
            else
            {
                lblCountDown.Text = "0" + Minutes + ":" + iCountDown.ToString();
            }

            if (iCountDown == 0 && Minutes == 0)
            {
                dashTimer.Enabled = true;
                dashTimer.Start();
                Minutes = 4;
                iCountDown = 60;
            }
            else
            {
                if (iCountDown == 0)
                {
                    Minutes -= 1;
                    iCountDown = 60;
                }
            }
            Application.DoEvents();
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

        private void lblLinkUnallocatedFiles_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void lblUnallocateFiles_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click_2(object sender, EventArgs e)
        {
            LoadAdministrationDashboard();
        }

        private void LoadAdministrationDashboard()
        {
            dashTimer.Enabled = false;
            dashTimer.Stop();
            panel1.Controls.Clear();
            try
            {
                SetLists();
                LoadAllWorkBasket();
                LoadUnallocatedFiles();

                LoadAdminWorkAllocationList();
                LoadAdminClosedFiles();

                DataTable dtFileOperators = new DataTable();
                dtFileOperators = commonFuncs.GetFileAdministrators();
                string CoOrdinator = "";

                for (int i = 0; i < dtFileOperators.Rows.Count; i++)
                {
                    CoOrdinator = dtFileOperators.Rows[i]["USER_NAME"].ToString();
                    if (!CoOrdinator.Trim().Equals("") && !CoOrdinator.Contains("All Workbaskets"))
                    {
                        createCoOrdGroupBox(CoOrdinator);
                    }
                }

                this.grpbxClosedCouried.Location = new Point(0, 0);
                this.grpbxClosedCouried.Height = panel3.ClientSize.Height;
                this.grpbxClosedCouried.ForeColor = Color.Magenta;
                this.grpbxClosedCouried.Font = new Font("Arial", 11, FontStyle.Bold);

                this.grpbxAssignedFiles.Top = this.grpbxClosedCouried.Top;
                this.grpbxAssignedFiles.Left = this.grpbxClosedCouried.ClientSize.Width + 5;
                this.grpbxAssignedFiles.Height = panel3.ClientSize.Height;
                this.grpbxAssignedFiles.ForeColor = Color.Magenta;
                this.grpbxAssignedFiles.Font = new Font("Arial", 11, FontStyle.Bold);

                this.btnRefresh.Left = panel3.ClientSize.Width + 10;
                this.btnRefresh.Top = panel3.Top + 10;

                lblUnallocateFiles.Left = btnRefresh.Left;
                lblUnallocateFiles.Top = btnRefresh.Bottom + 5;
                lblLinkUnallocatedFiles.Left = lblUnallocateFiles.Left;
                lblLinkUnallocatedFiles.Top = lblUnallocateFiles.Bottom + 1;

                lblAllWorkbaskets.Left = lblUnallocateFiles.Width + lblUnallocateFiles.Left;
                lblAllWorkbaskets.Top = btnRefresh.Bottom + 5;

                lblLinkAllWorkbaskets.Left = lblAllWorkbaskets.Left;
                lblLinkAllWorkbaskets.Top = lblLinkUnallocatedFiles.Top;

                lblCountDown.Left = btnRefresh.Left;
                lblCountDown.Top = grpbxClosedCouried.ClientSize.Height - 20;

                lineSep.Left = lblAllWorkbaskets.Left - 2;
                lineSep.Top = lblAllWorkbaskets.Top;
            }
            finally
            {
                btnRefresh.Enabled = true;
                dashTimer.Enabled = true;
                dashTimer.Start();
                GC.Collect();
            }
        }

        private void lblLinkUnallocatedFiles_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmReportViewer frmRep = new frmReportViewer("", "UNALLOCATED ADMIN FILES");
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

        private void lblLinkAllWorkbaskets_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmReportViewer frmRep = new frmReportViewer("", "UNALLOCATED ADMIN FILES");
            //commonFuncs = new AIMS.Common.CommonFunctions();

            //frmRep.StartPosition = FormStartPosition.CenterScreen;
            //frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            //frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            //StringBuilder sbHTML = new StringBuilder();

            //try
            //{
            //    frmRep.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            //}
        }

        private void lstWorkAllocated_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                        string CoOrdinator = lstGet.Items[i].SubItems[0].Text.ToString();
                        string CoOrdinatorName = lstGet.Items[i].SubItems[0].Text.ToString();

                        try
                        {
                            frmReportViewer frmRep = new frmReportViewer(CoOrdinator, "ADMINISTRATOR CASES");
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

        private void lstWorkAllocated_MouseDown(object sender, MouseEventArgs e)
        {
            //ListViewHitTestInfo HI = lstWorkAllocated.HitTest(e.Location);
            //if (e.Button == MouseButtons.Right && lstWorkAllocated.SelectedItems.Count > 0)
            //{
            //    cntxMenuWork.Show(Cursor.Position);
            //    if (HI.Location == ListViewHitTestLocations.None)
            //    {
            //        cntxMenuWork.Items[0].Visible = false;
            //    }
            //    else
            //    {
            //        cntxMenuWork.Items[0].Visible = true;
            //    }
            //}
        }

        private void cntxMenuWork_Opening(object sender, CancelEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void showCoOrdinatorWorkLoadToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (lstWorkAllocated.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        string CoOrdinator = lstWorkAllocated.SelectedItems[0].SubItems[0].Text.ToString();
        //        string CoOrdinatorName = lstWorkAllocated.SelectedItems[0].SubItems[0].Text.ToString(); ;

        //        try
        //        {
        //            frmReportViewer frmRep = new frmReportViewer(CoOrdinator, "Administrator Snapshot");
        //            commonFuncs = new AIMS.Common.CommonFunctions();

        //            frmRep.StartPosition = FormStartPosition.CenterScreen;
        //            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
        //            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

        //            StringBuilder sbHTML = new StringBuilder();

        //            try
        //            {
        //                frmRep.CaseCoOrdinator = CoOrdinator;
        //                frmRep.CoOrdinatorName = CoOrdinatorName;
        //                frmRep.ShowDialog();
        //            }
        //            catch (Exception ex)
        //            {
        //                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //        }
        //    }
        //}
    }
}