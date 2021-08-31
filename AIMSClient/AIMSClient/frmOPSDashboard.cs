using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmOPSDashboard : Form
    {
        public frmOPSDashboard()
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

        private void frmOPSDashboard_Resize(object sender, EventArgs e)
        {
            this.panel2.Location = new Point(0, 0); 
            this.panel2.Height = 150;
            this.panel2.Width = this.ClientSize.Width;

            this.panel1.Top = this.panel2.Bottom + 5;
            this.panel1.Left  = this.panel2.Left;
            this.panel1.Height = this.Bottom - 150;
            this.panel1.Width = this.ClientSize.Width;
        }

        private void frmOPSDashboard_Load(object sender, EventArgs e)
        {
            dashTimer.Enabled = false;
            dashTimer.Stop();
            
            try
            {
                HistCostFiles();
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                GC.Collect();
            }
        }

        private GroupBox gbDynamicGroupBox;
        private GroupBox gbHighCostGroupBox;


        private void  createCoOrdGroupBox(string controlName)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            DataTable dtCoOrdWorkLoad = new DataTable();
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
                dtCoOrdWorkLoad = commonDAL.GetAllocatedFilesOpsDashboard(controlName);
                //dtCoOrdWorkLoad.DefaultView.Sort = "COMMENT_SLA ASC, sent_to_admin ASC";
                string patientFileNo;
                string admissionDate;
                string dischargeDt;
                string category;
                string CommentSLA = "";
                string SentToAdmin = "";

                Int32 workTodo = 0;
                workTodo = dtCoOrdWorkLoad.Rows.Count;

                if (dtCoOrdWorkLoad.Rows.Count == 0)
                    return;

                for (int i = 0; i < dtCoOrdWorkLoad.Rows.Count; i++)
                {
                    patientFileNo = dtCoOrdWorkLoad.Rows[i]["PATIENT_FILE_NO"].ToString().Trim();
                    admissionDate = dtCoOrdWorkLoad.Rows[i]["patient_ADMISSION_DATE"].ToString().Trim();
                    dischargeDt = dtCoOrdWorkLoad.Rows[i]["patient_discharge_DATE"].ToString().Trim();
                    SentToAdmin = dtCoOrdWorkLoad.Rows[i]["sent_to_admin"].ToString().Trim();
                    category = "In-Patient";

                    if (dtCoOrdWorkLoad.Rows[i]["OUT_PATIENT"].ToString().Trim() == "Y")
                        category = "Out-Patient";

                    if (dtCoOrdWorkLoad.Rows[i]["IN_PATIENT"].ToString().Trim() == "Y")
                    {
                        category = "In-Patient";
                    }
                    else if (dtCoOrdWorkLoad.Rows[i]["REPAT"].ToString().Trim() == "Y")
                    {
                        category = "Repat";
                    }
                    else if (dtCoOrdWorkLoad.Rows[i]["FLIGHT"].ToString().Trim() == "Y")
                    {
                        category = "Flight";
                    }
                    else if (dtCoOrdWorkLoad.Rows[i]["ASSIST"].ToString().Trim() == "Y")
                    {
                        category = "Assist";
                    }
                    else if (dtCoOrdWorkLoad.Rows[i]["TRANSPORT"].ToString().Trim() == "Y")
                    {
                        category = "Transport";
                    }

                    CommentSLA = dtCoOrdWorkLoad.Rows[i]["COMMENT_SLA"].ToString();

                    ListViewItem lstItm = new ListViewItem(patientFileNo);
                    lstItm.SubItems.Add(admissionDate);
                    lstItm.SubItems.Add(dischargeDt);
                    lstItm.SubItems.Add(category);

                    if (!dischargeDt.Trim().Equals("") && SentToAdmin == "N")
                    {
                        DateTime dtdischargedt;
                        if (DateTime.TryParse(dischargeDt.Trim(), out dtdischargedt))
                        {
                            System.TimeSpan diffResult = DateTime.Today.Date - System.Convert.ToDateTime(dischargeDt);
                            if (diffResult.Days > 3)
                            {
                                lstCoOrd.Items.Add(lstItm).BackColor = Color.Red;
                                continue;
                            }
                        }
                    }

                    if (System.Convert.ToInt32(CommentSLA) > 2)
                    {
                        lstCoOrd.Items.Add(lstItm).BackColor = Color.Yellow;
                        continue;
                    }

                    lstCoOrd.Items.Add(lstItm);
                }

                gbDynamicGroupBox = new GroupBox();
                this.gbDynamicGroupBox.Location = new Point(100, 14);
                this.gbDynamicGroupBox.Size = new Size(400, 250);
                //this.gbDynamicGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                //this.gbDynamicGroupBox.AutoSize = true;
                this.gbDynamicGroupBox.Font = new Font("Arial", 10, FontStyle.Bold);
                this.gbDynamicGroupBox.ForeColor = Color.OrangeRed;
                lstCoOrd.Font = new Font("Arial", 10, FontStyle.Regular);
                lstCoOrd.Height = this.gbDynamicGroupBox.ClientSize.Height - 30;
                lstCoOrd.Width = this.gbDynamicGroupBox.ClientSize.Width - 15;
                this.gbDynamicGroupBox.Text = controlName + " [" + workTodo + "]";
                this.gbDynamicGroupBox.Name = controlName;
                this.gbDynamicGroupBox.Click += new System.EventHandler(questionGroupBox_Click);

                //lstCoOrd.MouseDown += new System.Windows.Forms.MouseEventHandler(lstCoOrd_MouseDown);

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
                dtCoOrdWorkLoad.Dispose();
                GC.Collect();
            }
        }

        private void questionGroupBox_Click(object sender, EventArgs e)
        {
            string  coOrdinator = ((GroupBox)sender).Name;
            
            string CoOrdinatorName = coOrdinator;

            try
            {
                frmReportViewer frmRep = new frmReportViewer(coOrdinator, "CoOrdinator Cases");
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

        private void HistCostFiles()
        {
            try
            {
                ListView lstCoOrd = new ListView();

                lstCoOrd.Location = new Point(10, 20);
                lstCoOrd.Size = new Size(300, 100);
                lstCoOrd.View = View.Details;
                lstCoOrd.Dock = DockStyle.Fill;
                lstCoOrd.FullRowSelect = true;

                lstCoOrd.Columns.Add("Case Number", 100);
                lstCoOrd.Columns.Add("Patient Name", 200);
                lstCoOrd.Columns.Add("Hospital", 100);
                lstCoOrd.Columns.Add("Guaranteed Amount", 80);
                lstCoOrd.Columns.Add("Last Interim Note", 500);

                string PatientFileNo = "";
                string PatientName = "";
                string Hospital = "";
                string GuaranteeAmt = "";
                string LastInterimNotes = "";

                commonFuncs = new AIMS.Common.CommonFunctions();
                DataTable tblAllocatedFiles = commonFuncs.GetHighCostFiles();
                ListViewItem lvwItem = null;
                decimal guarenteeAmt = 0;
                string guaranteeAmt = "";
                Int32 tmp3;
                int highCostFilesCnt = tblAllocatedFiles.Rows.Count;

                if (tblAllocatedFiles.Rows.Count > 0)
                {
                    for (int i = 0; i < tblAllocatedFiles.Rows.Count; i++)
                    {
                        PatientFileNo = tblAllocatedFiles.Rows[i]["patient_file_no"].ToString();
                        PatientName = tblAllocatedFiles.Rows[i]["patient_name"].ToString();
                        Hospital = tblAllocatedFiles.Rows[i]["hospital"].ToString();
                        GuaranteeAmt = tblAllocatedFiles.Rows[i]["PATIENT_GUARANTOR_AMOUNT"].ToString();
                        if (!GuaranteeAmt.Trim().Equals(""))
                        {
                            if (Int32.TryParse(GuaranteeAmt, out tmp3))
                            {
                                decimal txtGuarantAmount = System.Convert.ToDecimal(GuaranteeAmt.Replace(" ", ""));
                                guaranteeAmt = txtGuarantAmount.ToString("C");
                            }
                            else
                            {
                                guaranteeAmt = GuaranteeAmt;
                            }
                        }

                        LastInterimNotes = tblAllocatedFiles.Rows[i]["interim_note"].ToString();

                        lvwItem = new ListViewItem(PatientFileNo);
                        lvwItem.SubItems.Add(PatientName);
                        lvwItem.SubItems.Add(Hospital);
                        lvwItem.SubItems.Add(guaranteeAmt);
                        lvwItem.SubItems.Add(LastInterimNotes);
                        guaranteeAmt = "";
                        lstCoOrd.Items.Add(lvwItem);
                    }
                }

                gbHighCostGroupBox = new GroupBox();
                this.gbHighCostGroupBox.Location = new Point(0, 0);
                this.gbHighCostGroupBox.Height = panel2.ClientSize.Height;
                this.gbHighCostGroupBox.Width = panel2.ClientSize.Width / 2;

                this.gbHighCostGroupBox.Text = "High-Cost-Files [" + highCostFilesCnt + "]";
                this.gbHighCostGroupBox.Controls.Add(lstCoOrd);
                this.gbHighCostGroupBox.ForeColor = Color.Magenta;
                this.gbHighCostGroupBox.Font = new Font("Arial", 11, FontStyle.Bold);
                this.gbHighCostGroupBox.Click += new System.EventHandler(HighCostGroupBox_Click);
                
                this.btnRefresh.Left = gbHighCostGroupBox.ClientSize.Width + 10;
                this.btnRefresh.Top = gbHighCostGroupBox.Top + 10;

                lblUnallocateFiles.Left = btnRefresh.Left;
                lblUnallocateFiles.Top = btnRefresh.Bottom + 5;
                lblLinkUnallocatedFiles.Left = lblUnallocateFiles.Left;
                lblLinkUnallocatedFiles.Top = lblUnallocateFiles.Bottom + 1;

                lblAllWorkbaskets.Left = lblUnallocateFiles.Width + lblUnallocateFiles.Left;
                lblAllWorkbaskets.Top = btnRefresh.Bottom + 5;

                lblLinkAllWorkbaskets.Left = lblAllWorkbaskets.Left;
                lblLinkAllWorkbaskets.Top = lblLinkUnallocatedFiles.Top;

                lblCountDown.Left = gbHighCostGroupBox.Width + 5;
                lblCountDown.Top = gbHighCostGroupBox.ClientSize.Height - 20;

                lineSep.Left = lblAllWorkbaskets.Left - 2;
                lineSep.Top = lblAllWorkbaskets.Top;

                lstCoOrd.Font = new Font("Arial", 10, FontStyle.Regular);
                this.Controls.Add(gbHighCostGroupBox);

                this.panel2.Controls.Add(gbHighCostGroupBox);
            }
            catch (System.Exception ex)
            {
                commonFuncs = new AIMS.Common.CommonFunctions();
                commonFuncs.ErrorLogger("Loading HisCost File:" + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void showCoOrdinatorWorkLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView lstWorkAllocated = ((ListView)sender);
            string CoOrdinator =  lstWorkAllocated.SelectedItems[0].SubItems[2].Text.ToString();
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
                DataTable tblAllocatedFiles = commonFuncs.GetUnallocatedFiles();
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
                DataTable tblAllocatedFiles = commonFuncs.GetAllWorkbasketFiles();
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

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            try
            {
                panel1.Controls.Clear();
                panel2.Controls.Clear();
                HistCostFiles();
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
                    panel2.Controls.Clear();
                    panel1.Controls.Clear();
                    HistCostFiles();
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

        private void lblLinkAllWorkbaskets_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void HighCostGroupBox_Click(object sender, EventArgs e)
        {
            string coOrdinator = ((GroupBox)sender).Name;

            string CoOrdinatorName = coOrdinator;

            try
            {
                frmReportViewer frmRep = new frmReportViewer(coOrdinator, "High Cost Filesss");
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

        private void lblCountDown_Click(object sender, EventArgs e)
        {

        }
    }
}