using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmPatientFileTasksAudit : Form
    {
        public frmPatientFileTasksAudit()
        {
            InitializeComponent();
        }

        string _PatientSubFileID = "";
        public string PatientSubFileID
        {
            get { return _PatientSubFileID; }
            set { _PatientSubFileID = value; }
        }

        private void frmPatientFileTasksAudit_Load(object sender, EventArgs e)
        {
            TasksSetup();
            LoadPatientFileTasks(PatientSubFileID);
        }

        private void LoadPatientFileTasks(string PatientSubFileId)
        {
            AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                lstvwTasksAudit.Items.Clear();
                DataTable dtPatientFileTasks = commonFuncs.GetPatientFilesTaskAudit(PatientSubFileId);
                if (dtPatientFileTasks.Rows.Count > 0)
                {
                    ListViewItem lstItm;
                    for (int i = 0; i < dtPatientFileTasks.Rows.Count; i++)
                    {
                        lstItm = new ListViewItem(dtPatientFileTasks.Rows[i]["USER_FULL_NAME"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_DESC"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["due_date"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["PRIORITY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TASK_STATUS"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["LOADED_BY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["CREATION_DATE"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["DETAILS"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["MODIFIED_ACTION"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["MODIFIED_BY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["MODIFIED_DTTM"].ToString());

                        if (dtPatientFileTasks.Rows[i]["STATUS"].ToString() == "Y" &&
                            (dtPatientFileTasks.Rows[i]["PRIORITY"].ToString().ToUpper() == "URGENT" || dtPatientFileTasks.Rows[i]["PRIORITY"].ToString().ToUpper() == "HIGH"))
                        {
                            lstvwTasksAudit.Items.Add(lstItm).BackColor = Color.Red;
                        }
                        else
                        {
                            lstvwTasksAudit.Items.Add(lstItm);
                        }
                    }

                    if (lstvwTasksAudit.Items.Count > 0 )
                    {
                        foreach (ColumnHeader colHeader in lstvwTasksAudit.Columns)
                        {
                            colHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                    else
                    {
                        foreach (ColumnHeader colHeader in lstvwTasksAudit.Columns)
                        {
                            colHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Tasks error, Please contact system Administrator." + ex.Message);
                commonFuncs.ErrorLogger("Loading Patient File Tasks, Please try again: " + ex.ToString());
            }
            finally
            {
                commonFuncs = null;
            }
        }

        private void TasksSetup()
        {
            lstvwTasksAudit.Columns.Clear();
            lstvwTasksAudit.Items.Clear();
            lstvwTasksAudit.Columns.Add("Co-Ordinator", Convert.ToInt32(lstvwTasksAudit.Width * 0.15), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Task Description", Convert.ToInt32(lstvwTasksAudit.Width * 0.66), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Due Date", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Priority", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Status", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Created/Changed By", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Created Date", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Task Details", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Last Modified Action", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Last Modified By", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.Columns.Add("Last Modified Date", Convert.ToInt32(lstvwTasksAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwTasksAudit.View = View.Details;
        }
    }
}