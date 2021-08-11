using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmAIMSDashboardAdmin : Form
    {
        public AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
        Int32 iCountDown = 60;   
        public frmAIMSDashboardAdmin()
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

        private void grpbxAllocatedFiles_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAIMSDashboardAdmin_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            WorkAllocatedFileListSetup(lstLeighAnnAllocatedCases);
            WorkAllocatedFileListSetup(lstMbaliAllocatedCases);
            WorkAllocatedFileListSetup(lstCharlaineAllocatedCases);
            WorkAllocatedFileListSetup(lstCarmelleAllocatedCases);
            WorkAllocatedFileListSetup(lstMardiaAllocatedCases);
            WorkAllocatedFileListSetup(lstNokuthulaAllocatedCases);

            LoadAdministratorFiles("Leigh-Ann", lstLeighAnnAllocatedCases);
            LoadAdministratorFiles("MBALIS", lstMbaliAllocatedCases);
            LoadAdministratorFiles("JKYRIACOS", lstCharlaineAllocatedCases);
            LoadAdministratorFiles("CARMELLED", lstCarmelleAllocatedCases);
            LoadAdministratorFiles("MARDIAJ" ,lstMardiaAllocatedCases );
            LoadAdministratorFiles("NOKUTHULAM", lstNokuthulaAllocatedCases);
            LoadAdminWorkAllocationList();
            LoadUnallocatedFiles();
            LoadAdminClosedFiles();
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

        private void WorkAllocatedFileListSetup(ListView lstVwAdminStaff)
        {
            try
            {
                lstVwAdminStaff.Columns.Clear();
                lstVwAdminStaff.Items.Clear();

                lstVwAdminStaff.Columns.Add("File Number");
                lstVwAdminStaff.Columns[0].Width = 80;

                lstVwAdminStaff.Columns.Add("Due Date");
                lstVwAdminStaff.Columns[1].Width = 80;
                lstVwAdminStaff.View = View.Details;

                lstWorkAllocated.Columns.Clear();
                lstWorkAllocated.Items.Clear();

                lstWorkAllocated.Columns.Add("Case Administrator");
                lstWorkAllocated.Columns[0].Width = 90;

                lstWorkAllocated.Columns.Add("Cases Assigned");
                lstWorkAllocated.Columns[1].Width = 90;

                lstFilesClosed.Columns.Clear();
                lstFilesClosed.Items.Clear();

                lstFilesClosed.Columns.Add("File No");
                lstFilesClosed.Columns[0].Width = 100;

                lstFilesClosed.Columns.Add("Name");
                lstFilesClosed.Columns[1].Width = 100;

                lstFilesClosed.Columns.Add("Courier Due Date");
                lstFilesClosed.Columns[1].Width = 150;

                lstFilesClosed.Columns.Add("Category");
                lstFilesClosed.Columns[1].Width = 100;
                lstFilesClosed.View = View.Details;
            }
            finally
            {
            }
        }

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAdministratorFiles("Leigh-Ann", lstLeighAnnAllocatedCases);
            LoadAdministratorFiles("MBALIS", lstMbaliAllocatedCases);
            LoadAdministratorFiles("JKYRIACOS", lstCharlaineAllocatedCases);
            LoadAdministratorFiles("CARMELLED", lstCarmelleAllocatedCases);
            LoadAdministratorFiles("MARDIAJ", lstMardiaAllocatedCases);
            LoadAdministratorFiles("NOKUTHULAM", lstNokuthulaAllocatedCases);
            LoadAdminWorkAllocationList();
            LoadUnallocatedFiles();
            LoadAllWorkBasket();
            LoadAdminClosedFiles();
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
                throw;
            }
        }

        private void lblLinkUnallocatedFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            frmReportViewer frmRep = new frmReportViewer("", "Unassigned Filess");
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

        private void lblLinkAllWorkbaskets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        public void LoadAllWorkBasket()
        {
            try
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.Get_AIMS_Administrator_Work("<All Workbaskets>");
                lblLinkAllWorkbaskets.Text = tblAllocatedFiles.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
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

                        if (HighCost =="Y")
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

        private void lstWorkAllocated_MouseDown(object sender, MouseEventArgs e)
        {
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

        private void lstWorkAllocated_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cntxMenuWork_Opening(object sender, CancelEventArgs e)
        {

        }

        private void showCoOrdinatorWorkLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstWorkAllocated.SelectedItems.Count <= 0)
            {
                return;
            }
            else
            {
                string CoOrdinator = lstWorkAllocated.SelectedItems[0].SubItems[0].Text.ToString();
                string CoOrdinatorName = lstWorkAllocated.SelectedItems[0].SubItems[0].Text.ToString(); ;

                try
                {
                    frmReportViewer frmRep = new frmReportViewer(CoOrdinator, "Administrator Snapshot");
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

        private void dashTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (UserAllowed("99"))
                {
                    btnRefresh.Enabled = false;
                    LoadAdministratorFiles("Leigh-Ann", lstLeighAnnAllocatedCases);
                    LoadAdministratorFiles("MBALIS", lstMbaliAllocatedCases);
                    LoadAdministratorFiles("JKYRIACOS", lstCharlaineAllocatedCases);
                    LoadAdministratorFiles("CARMELLED", lstCarmelleAllocatedCases);
                    LoadAdministratorFiles("MARDIAJ", lstMardiaAllocatedCases);
                    LoadAdministratorFiles("NOKUTHULAM", lstNokuthulaAllocatedCases);
                    LoadAdminWorkAllocationList();
                    LoadUnallocatedFiles();
                    LoadAllWorkBasket();
                    LoadAdminClosedFiles();
                }
            }
            catch(System.Exception ex)
            {
}
            finally
            {
                btnRefresh.Enabled = true;
                GC.Collect();
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
    }
}