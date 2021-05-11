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
    
    public partial class frmOutpatientAppointments : Form
    {
        public frmOutpatientAppointments()
        {
            InitializeComponent();
        }

        AIMS.Common.CommonFunctions CommonFuncs  = new CommonFunctions();
        
        AIMS.BLL.Patient _patient;
        AIMS.DAL.PatientDAL _PatientDAL;
        string sAction = "";

        Int32 _PatientFileTaskID;
        public Int32 PatientFileTaskID
        {
            get { return _PatientFileTaskID; }
            set
            {
                _PatientFileTaskID = value;
            }
        }

        string _PatientFileNo = "";
        public string PatientFileNo
        {
            get { return _PatientFileNo; }
            set { _PatientFileNo = value; }
        }

        string _PatientSubFileID = "";
        public string PatientSubFileID
        {
            get { return _PatientSubFileID; }
            set { _PatientSubFileID = value; }
        }

        string _Restrictions = "";
        public string Restrictions
        {
            get { return _Restrictions; }
            set { _Restrictions = value; }
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
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CommonFuncs = new AIMS.Common.CommonFunctions();
                SetupChemoList();
                LoadPatientCycleDates(PatientSubFileID.ToString());
            }
            catch (System.Exception ex )
            {
                CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error loading Chemo Treatment Cycles Form");
                CommonFuncs.ErrorLogger("Error loading Chemo Treatment Cycles Form \n" + ex.ToString());
            }
        }

        private void SetupChemoList()
        {
            try
            {
                lstChemoTreatment.Columns.Clear();
                lstChemoTreatment.Items.Clear();
                lstChemoTreatment.Columns.Add("Treatment");
                lstChemoTreatment.Columns.Add("Treatment Cycle Start Date");
                lstChemoTreatment.Columns.Add("Treatment Cycle Start Date");
                lstChemoTreatment.Columns.Add("TREATMENT_CYCLE_ID", 0, HorizontalAlignment.Right);

                foreach (ColumnHeader  ColHeader in lstChemoTreatment.Columns)
                {
                    if (ColHeader.Text =="TREATMENT_CYCLE_ID")
                    {
                        ColHeader.Width = 0;
                    }
                    else
                    {
                        ColHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize); 
                    }
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.ErrorLogger("Error loading Chemo Treatment \n" + ex.ToString());
            }

        }

        private bool ValidateControls() 
        {
            bool returnVal = true;
            errPatients.Clear();

            if (txtCycleStartDate.Text.Trim().Equals(""))
            {
                errPatients.SetError(txtCycleStartDate, "Please enter the Chemo Cycle Start Date");
                txtCycleStartDate.Focus();
                returnVal = false;
                return returnVal;
            }

            if (txtCycleEndDate.Text.Trim().Equals(""))
            {
                errPatients.SetError(txtCycleEndDate, "Please enter the Chemo Cycle End Date");
                txtCycleEndDate.Focus();
                returnVal = false;
                return returnVal;
            }

            System.TimeSpan diffResult = diffResult = System.Convert.ToDateTime(txtCycleEndDate.Text) - System.Convert.ToDateTime(txtCycleStartDate.Text);
            if (diffResult.Days < 0)
            {
                returnVal = false;
                txtCycleEndDate.Focus();
                errPatients.SetError(txtCycleEndDate, "Cycle End Date must be greater than Cycle Start Date");
                returnVal = false;
                return returnVal;
            }

             diffResult = diffResult = System.Convert.ToDateTime(txtCycleEndDate.Text) - DateTime.Today.Date;
            if (diffResult.Days <= 0)
            {
                diffResult = System.Convert.ToDateTime(txtCycleStartDate.Text) - DateTime.Today.Date;
                if (diffResult.Days >0)
                {
                    returnVal = false;
                    txtCycleEndDate.Focus();
                    errPatients.SetError(txtCycleEndDate, "Cycle End Date must be a future date");
                    returnVal = false;
                    return returnVal;
                }
            }

            diffResult = System.Convert.ToDateTime(txtCycleStartDate.Text) - System.Convert.ToDateTime(txtCycleEndDate.Text);
            if (diffResult.Days > 0)
            {
                returnVal = false;
                txtCycleEndDate.Focus();
                errPatients.SetError(txtCycleStartDate, "Cycle Start Date cannot be greater than Cycle End Date");
                returnVal = false;
                return returnVal;
            }

            if (!chkRadioTherapy.Checked & !chkChemoPlanned.Checked )
            {
                CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Select Treatment Type(Chemo/Radio Therapy)");
                returnVal = false;
                return returnVal;                
            }
            return returnVal;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string ChemoPlan = "";
            string ChemoPlanned = "";
            string ChemoRadioTherapy = "";
            string ChemoStartDate = "";
            string ChemoEndDate = "";
            bool bSaved = false;
            string ChemoCycleID = lblChemoCycleID.Text;

            if (ChemoCycleID.Equals(""))
            {
                sAction = "Added";
            }

            ListViewItem lvwItem;
            try
            {
                errPatients.Clear();
                if (ValidateControls())
                {
                    if (chkChemoPlanned.Checked)
                    {
                        ChemoPlan = chkChemoPlanned.Text;
                        ChemoPlanned = "Y";
                        ChemoRadioTherapy = "N";
                    }
                    else
                    {
                        ChemoPlan = chkRadioTherapy.Text;
                        ChemoPlanned = "N";
                        ChemoRadioTherapy = "Y";
                    }

                    ChemoStartDate = txtCycleStartDate.Text;
                    ChemoEndDate = txtCycleEndDate.Text;

                    bSaved = CommonFuncs.SavePatientChemoCycles(ref ChemoCycleID, PatientSubFileID, ChemoStartDate, ChemoEndDate, ChemoPlanned, ChemoRadioTherapy, "Y", "");

                    if (bSaved)
                    {
                        CommonFuncs.DisplayMessage(CommonTypes.MessagType.Success, ChemoPlan + " Treatment cycle " + sAction + " successfully.");
                        if (sAction.Equals("Added"))
                        {
                            lvwItem = new ListViewItem(ChemoPlan);

                            lvwItem.SubItems.Add(ChemoStartDate);
                            lvwItem.SubItems.Add(ChemoEndDate);
                            lvwItem.SubItems.Add(ChemoCycleID);
                            lstChemoTreatment.Items.Add(lvwItem);
                        }
                        else
                        {
                            LoadPatientCycleDates(PatientSubFileID);
                        }

                        txtCycleStartDate.Text = "";
                        txtCycleEndDate.Text = "";
                        chkRadioTherapy.Checked = false;
                        chkChemoPlanned.Checked = false;
                        lblChemoCycleID.Text = "";
                    }
                    else
                    {
                        CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error saving Patient Chemo Cycle, Please contact system Administrator.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error saving Patient Chemo Cycle, Please contact system Administrator.");
                CommonFuncs.ErrorLogger("Error saving Patient Chemo Cycle \n" + ex.ToString());
            }
        }

        private void txtCycleStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCycleStartDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtCycleStartDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtCycleStartDate.Focus();
        }

        private void txtCycleEndDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCycleEndDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtCycleEndDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtCycleEndDate.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continue removing patient cycle date. . .?","Cycle Date Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                if (!lblChemoCycleID.Text.Trim().Equals(""))
                {
                    bool bRemoved = CommonFuncs.RemovePatientCycleDetail(lblChemoCycleID.Text);
                    if (bRemoved)
                    {
                        CommonFuncs.DisplayMessage(CommonTypes.MessagType.Success, "Cycle date removed successfully.");
                        LoadPatientCycleDates(PatientSubFileID);
                        txtCycleEndDate.Text = "";
                        lblChemoCycleID.Text = "";
                        txtCycleStartDate.Text = "";
                        chkChemoPlanned.Checked = false;
                        chkRadioTherapy.Checked = false;
                    }
                    else
                    {
                        CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Problem removing cycle date.");
                    }
                }
                else
                {
                    CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Please select chemo cycle dates.");
                }
            }
        }

        private void LoadPatientCycleDates(string PatientSubFileId)
        {
            try
            {
                lstChemoTreatment.Items.Clear();
                DataTable dtPatientFileCycles = CommonFuncs.GetPatientFileCycleDates(PatientSubFileId);
                if (dtPatientFileCycles.Rows.Count > 0)
                {
                    ListViewItem lstItm;
                    string ChemoTreatment = "";
                    for (int i = 0; i < dtPatientFileCycles.Rows.Count; i++)
                    {
                        if (dtPatientFileCycles.Rows[i]["CHEMO_CYCLE_PLANNED_YN"].ToString() == "Y")
                        {
                            ChemoTreatment = "Planned Chemo";
                        }
                        else
                        {
                            ChemoTreatment = "Radio Therapy";
                        }
                        lstItm = new ListViewItem(ChemoTreatment);

                        lstItm.SubItems.Add(dtPatientFileCycles.Rows[i]["CHEMO_CYCLE_START_DTTM"].ToString());
                        lstItm.SubItems.Add(dtPatientFileCycles.Rows[i]["CHEMO_CYCLE_END_DTTM"].ToString());
                        lstItm.SubItems.Add(dtPatientFileCycles.Rows[i]["CHEMO_CYCLE_ID"].ToString());
                        lstChemoTreatment.Items.Add(lstItm);
                    }
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Tasks error, Please contact system Administrator." + ex.ToString());
                CommonFuncs.ErrorLogger("Loading Patient File Tasks, Please try again: " + ex.ToString());
            }
        }

        private void LoadPatientFileTasks(string PatientSubFileId)
        {
            try
            {

                lstChemoTreatment.Items.Clear();
                DataTable dtPatientFileTasks = CommonFuncs.GetPatientFilesTasks(PatientSubFileId);
                if (dtPatientFileTasks.Rows.Count > 0)
                {
                    ListViewItem lstItm;
                    for (int i = 0; i < dtPatientFileTasks.Rows.Count; i++)
                    {
                        lstItm = new ListViewItem(dtPatientFileTasks.Rows[i]["USER_FULL_NAME"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_DESC"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["due_date"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["PRIORITY"].ToString());
                        if (dtPatientFileTasks.Rows[i]["STATUS"].ToString() == "Y")
                        {
                            lstItm.SubItems.Add("ACTIVE");
                        }
                        else
                        {
                            lstItm.SubItems.Add("IN-ACTIVE");
                        }

                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["patient_file_task_id"].ToString());
                        if (dtPatientFileTasks.Rows[i]["STATUS"].ToString() == "Y" && dtPatientFileTasks.Rows[i]["PRIORITY"].ToString().ToUpper() == "URGENT")
                        {
                            lstChemoTreatment.Items.Add(lstItm).BackColor = Color.Red;
                        }
                        else
                        {
                            lstChemoTreatment.Items.Add(lstItm);
                        }

                    }
                }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Tasks error, Please contact system Administrator." + ex.ToString());
                CommonFuncs.ErrorLogger("Loading Patient File Tasks, Please try again: " + ex.ToString());
            }
        }

        private void lstChemoTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstChemoTreatment_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        string ChemocycleID = lstGet.Items[i].SubItems[3].Text.ToString();
                        DataTable dtChemoCycleDetails = CommonFuncs.GetCycleDatesDetails(ChemocycleID);
                        if (dtChemoCycleDetails.Rows.Count >0)
	                    {
                            int j = 0;
                            lblChemoCycleID.Text =ChemocycleID;
                            txtCycleEndDate.Text =dtChemoCycleDetails.Rows[j]["CHEMO_CYCLE_END_DTTM"].ToString();
                            txtCycleStartDate.Text =dtChemoCycleDetails.Rows[j]["CHEMO_CYCLE_START_DTTM"].ToString();
                            sAction = "Updated";
                            if (dtChemoCycleDetails.Rows[j]["CHEMO_CYCLE_PLANNED_YN"].ToString() == "Y")
                            {
                                chkChemoPlanned.Checked = true;
                                chkRadioTherapy.Checked = false;
                            }
                            else
                            {
                                chkChemoPlanned.Checked = false;
                                chkRadioTherapy.Checked = true;
                            }
	                    }
                    }
                }
            }
            catch (System.Exception ex)
            {
                lstGet = null;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCycleEndDate.Text = "";
            lblChemoCycleID.Text = "";
            txtCycleStartDate.Text = "";
            chkChemoPlanned.Checked = false;
            chkRadioTherapy.Checked = false;
        }

        private void chkChemoPlanned_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChemoPlanned.Checked)
            {
                chkRadioTherapy.Checked = false;
            } 
        }

        private void chkRadioTherapy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRadioTherapy.Checked)
            {
                chkChemoPlanned.Checked = false;
            }
        }
    }
}