using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIMS.BLL;

namespace AIMSClient
{
    public partial class frmTasks : Form
    {
        AIMS.Common.CommonFunctions CommonFuncs;
        AIMS.BLL.Patient _patient;
        AIMS.DAL.PatientDAL _PatientDAL;

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

        public frmTasks()
        {
            InitializeComponent();
        }

        private void frmTasks_Load(object sender, EventArgs e)
        {
            CommonFuncs = new AIMS.Common.CommonFunctions();
            LoadTasks();
            LoadTaskStatus();
            LoadUsers();
            LoadPriorities();

            if (!PatientFileTaskID.Equals(""))
            {
                lblTaskID.Text = PatientFileTaskID.ToString();
                if (lblTaskID.Text.Equals("0"))
                {
                    lblTaskID.Text = "";
                    return;
                }
                LoadTaskDetails();
            }
            else
            {
                ClearControls();
            }

            if (this.Text.Contains("Edit"))
            {
                chkSendTaskIM.Checked = false;
            }
        }

        private void ClearControls()
        {
            txtCompletionDate.Text = "";
            txtTaskDueDate.Text = "";
            txtTaskDetails.Text = "";
            cboTasks.SelectedIndex = -1;
            cboTaskUser.SelectedIndex = -1;
            cboTaskStatus.SelectedIndex = -1;
            lblTaskID.Text = "";
        }

        public void LoadTasks()
        {
            try
            {
                DataTable tblTasks = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblTasks = lookupBLL.GetLookUpValues("TASK_ID", "TASK_DESC", "AIMS_TASKS", 0, "TASK_DESC", " where task_active_yn = 'Y'");
                cboTasks.DataSource = tblTasks;
                cboTasks.DisplayMember = "TASK_DESC";
                cboTasks.ValueMember = "TASK_ID";
                cboTasks.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                //throw;
            }
        }

        public void LoadTaskStatus()
        {
            try
            {
                DataTable tblTaskStatus = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblTaskStatus = lookupBLL.GetLookUpValues("TASK_STATUS_ID", "TASK_STATUS", "AIMS_TASK_STATUS", 0, "TASK_STATUS", " where status_active_yn = 'Y'");
                cboTaskStatus.DataSource = tblTaskStatus;
                cboTaskStatus.DisplayMember = "TASK_STATUS";
                cboTaskStatus.ValueMember = "TASK_STATUS_ID";
                cboTaskStatus.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                //throw;
            }
        }

        public void LoadPriorities()
        {
            try
            {
                DataTable tblPriorities = new DataTable();
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblPriorities = lookupBLL.GetLookUpValues("PRIORITY_ID", "PRIORITY", "AIMS_PRIORITY", 0, "PRIORITY", " WHERE PRIORITY in ('Normal', 'High') ");
                cboPriority.DataSource = tblPriorities;
                cboPriority.DisplayMember = "PRIORITY";
                cboPriority.ValueMember = "PRIORITY_ID";
                cboPriority.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                //throw;
            }
        }

        public void LoadUsers()
        {
            DataTable tblTasksUsers = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
            tblTasksUsers = lookupBLL.GetLookUpValues("USER_NAME", "USER_FULL_NAME", "AIMS_USERS", 0, "USER_FULL_NAME", " where user_active_yn = 'Y' and user_name in ( select user_name from aims_user_role where role_cd in ('Admin','Operations')) ");
            cboTaskUser.DataSource = tblTasksUsers;
            cboTaskUser.DisplayMember = "USER_FULL_NAME";
            cboTaskUser.ValueMember = "USER_NAME";
            cboTaskUser.SelectedValue = -1;
        }

        private void txtTaskDueDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaskDueDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtTaskDueDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtTaskDueDate.Focus();
        }

        private void lnklblTaskDueDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtTaskDueDate_DoubleClick(null, null);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            bool bContinue = ValidateControl();
          
            if (bContinue)
            {
                bContinue = SavePatientTask();
                if (bContinue)
                {
                    string taskPriority = "";
                    taskPriority = " [" + cboPriority.Text  + " Priority Task] ";

                    if (!chkSendTaskIM.Checked)
                    {
                        CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Patient File Task added successfully");
                    }
                    else
                    {
                        bContinue = CommonFuncs.SendInstantMessage(PatientSubFileID, UserID, cboTaskUser.SelectedValue.ToString(), taskPriority + " " + cboTasks.Text.ToString());
                        if (bContinue)
                        {
                            CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Patient File Task added and notification(IM) sent successfully");
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear Task Details...?" ,"Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtCompletionDate.Text = "";
                txtTaskDueDate.Text = "";
                txtTaskDetails.Text = "";
                cboTasks.SelectedIndex = -1;
                cboTaskUser.SelectedIndex = -1;
                chkTaskActiveYN.Checked = false;
                cboPriority.SelectedIndex = -1;
                cboTaskStatus.SelectedIndex = -1;
                lblTaskID.Text = "";   
            }
        }

        private void txtCompletionDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCompletionDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtCompletionDate.Text = frmCal.StartDate.ToShortDateString();
            }

            txtCompletionDate.Focus();
        }

        private void lnklblCompletionDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtCompletionDate_DoubleClick(null, null);
        }

        private bool ValidateControl()
        {
            bool ReturnValue = true;
            try
            {
                errProvider.Clear();

                if (cboTaskUser.SelectedItem == null)
                {
                    errProvider.SetError(cboTaskUser, "Please select user.");
                    cboTaskUser.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTaskUser.SelectedItem != null && (cboTaskUser.Text == ""))
                {
                    errProvider.SetError(cboTaskUser, "Please select user.");
                    cboTaskUser.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTasks.SelectedItem == null)
                {
                    errProvider.SetError(cboTasks, "Please select Task");
                    cboTasks.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTasks.SelectedItem != null && (cboTasks.Text == ""))
                {
                    errProvider.SetError(cboTasks, "Please select Task");
                    cboTasks.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtTaskDueDate.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtTaskDueDate.Focus();
                    errProvider.SetError(txtTaskDueDate, "Please capture Task Due Date.");
                    ReturnValue = false;
                    return ReturnValue;
                }

                System.TimeSpan diffResult = System.Convert.ToDateTime(txtTaskDueDate.Text) - DateTime.Today.Date;
                if (diffResult.Days < 0)
                {
                    ReturnValue = false;
                    txtTaskDueDate.Focus();
                    errProvider.SetError(txtTaskDueDate, "Task Due Expiry Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboPriority.SelectedItem == null)
                {
                    errProvider.SetError(cboPriority, "Please select Task Priority.");
                    cboTasks.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboPriority.SelectedIndex < 0 && (cboPriority.Text == ""))
                {
                    errProvider.SetError(cboPriority, "Please select Task Priority.");
                    cboPriority.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if ((cboTasks.Text == "Other") && txtTaskDetails.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtTaskDetails, "Please capture addition Task Details");
                    txtTaskDetails.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTaskStatus.SelectedItem == null)
                {
                    errProvider.SetError(cboTaskStatus, "Please select task status.");
                    cboTaskStatus.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTaskStatus.SelectedItem != null && (cboTaskStatus.Text == ""))
                {
                    errProvider.SetError(cboTaskStatus, "Please select task status.");
                    cboTaskStatus.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
            }
            finally
            {

            }
            return ReturnValue;
        }

        private bool SavePatientTask() 
        {
            bool bReturn = false;
            try
            {
                string TaskActiveYN = "";
                string PatientTaskID = "";

                if (chkTaskActiveYN.Checked)
                {
                    TaskActiveYN = "Y";
                }else
                {
                    TaskActiveYN = "N";
                }
                PatientTaskID = lblTaskID.Text;

                if (!PatientSubFileID.Equals(""))
                {
                    DateTime taskDate = System.Convert.ToDateTime(txtTaskDueDate.Text);
                    txtTaskDueDate.Text = taskDate.ToString("dd/MM/yyyy");
                    bReturn = CommonFuncs.SavePatientFileTask(ref PatientTaskID, cboTasks.SelectedValue.ToString(), PatientSubFileID, cboTaskUser.SelectedValue.ToString(), txtTaskDueDate.Text, txtCompletionDate.Text, txtTaskDetails.Text, TaskActiveYN, cboPriority.SelectedValue.ToString(), UserID, cboTaskStatus.SelectedValue.ToString());
                }
                else
                {
                    CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning,"Patient File not selected.");
                }
                lblTaskID.Text = PatientTaskID;
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error adding Patient File Task, Please contact System Administrator");
                CommonFuncs.ErrorLogger("Error adding Patient File : " + ex.ToString());
                bReturn = false;
            }
            return bReturn; 
        }

        private void LoadTaskDetails()
        {
            DataTable dtTaskDetails = CommonFuncs.GetTaskDetails(lblTaskID.Text);
            if (dtTaskDetails.Rows.Count > 0)
            {
                txtTaskDueDate.Text = dtTaskDetails.Rows[0]["due_date"].ToString();
                txtTaskDetails.Text = dtTaskDetails.Rows[0]["details"].ToString();

                if (!dtTaskDetails.Rows[0]["USER_ID"].ToString().Equals(""))
                {
                    cboTaskUser.SelectedValue = dtTaskDetails.Rows[0]["USER_ID"].ToString();
                }

                if (!dtTaskDetails.Rows[0]["TASK_ID"].ToString().Equals(""))
                {
                    cboTasks.SelectedValue = Convert.ToInt32(dtTaskDetails.Rows[0]["TASK_ID"].ToString());
                }

                if (!dtTaskDetails.Rows[0]["PRIORITY_ID"].ToString().Equals(""))
                {
                    cboPriority.SelectedValue = Convert.ToInt32(dtTaskDetails.Rows[0]["PRIORITY_ID"].ToString());
                }

                if (!dtTaskDetails.Rows[0]["TASK_STATUS_ID"].ToString().Equals(""))
                {
                    cboTaskStatus.SelectedValue = Convert.ToInt32(dtTaskDetails.Rows[0]["TASK_STATUS_ID"].ToString());
                }

                lblTaskID.Text = dtTaskDetails.Rows[0]["PATIENT_FILE_TASK_ID"].ToString();

                if (dtTaskDetails.Rows[0]["ACTIVE_YN"].ToString() == "Y")
                {
                    chkTaskActiveYN.Checked = true;
                }
                else
                {
                    chkTaskActiveYN.Checked = false;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}