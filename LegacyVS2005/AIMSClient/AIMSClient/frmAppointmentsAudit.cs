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
    public partial class frmAppointmentsAudit : Form
    {
        CommonFunctions commonFuncs = new CommonFunctions();
        public frmAppointmentsAudit()
        {
            InitializeComponent();
        }

        string _PatientSubFileID = "";
        public string PatientSubFileID
        {
            get { return _PatientSubFileID; }
            set { _PatientSubFileID = value; }
        }

        private void frmAppointmentsAudit_Load(object sender, EventArgs e)
        {
            AppointmentsSetup();
            LoadPatientAppointments(PatientSubFileID);
        }

        private void LoadPatientAppointments(string PatientSubFileId)
        {
            AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                lstvwAppointmentsAudit.Items.Clear();
                DataTable dtPatientFileTasks = commonFuncs.GetPatientFileAppointmentsAudit(PatientSubFileId);
                if (dtPatientFileTasks.Rows.Count > 0)
                {
                    ListViewItem lstItm;
                    for (int i = 0; i < dtPatientFileTasks.Rows.Count; i++)
                    {
                        lstItm = new ListViewItem(dtPatientFileTasks.Rows[i]["USER_FULL_NAME"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["APPOINTMENT_SUBJECT"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["APPOINTMENT_ADDRESS"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["APPOINTMENT_DATE"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["APPOINTMENT_NOTE"].ToString());
                        
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TRANSPORT_YN"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TRANSPORT_TYPE_DESC"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["TRANSLATOR_YN"].ToString());

                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["CREATED_BY"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["CREATED_DTTM"].ToString());


                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["MODIFIED_ACTION"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["MODIFIED_USER"].ToString());
                        lstItm.SubItems.Add(dtPatientFileTasks.Rows[i]["MODIFIED_DATE"].ToString());

                        if (dtPatientFileTasks.Rows[i]["TRANSPORT_YN"].ToString() == "Y")
                        {
                            lstvwAppointmentsAudit.Items.Add(lstItm).BackColor = Color.Turquoise;
                        }
                        else
                        {
                            lstvwAppointmentsAudit.Items.Add(lstItm);
                        }
                    }

                    if (lstvwAppointmentsAudit.Items.Count > 0)
                    {
                        foreach (ColumnHeader colHeader in lstvwAppointmentsAudit.Columns)
                        {
                            colHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        }
                    }
                    else
                    {
                        foreach (ColumnHeader colHeader in lstvwAppointmentsAudit.Columns)
                        {
                            colHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient Appointments error, Please contact system Administrator." + ex.Message);
                commonFuncs.ErrorLogger("Loading Patient Appointments , Please try again: " + ex.ToString());
            }
            finally
            {
                commonFuncs = null;
            }
        }

        private void AppointmentsSetup()
        {
            lstvwAppointmentsAudit.Columns.Clear();
            lstvwAppointmentsAudit.Items.Clear();
            lstvwAppointmentsAudit.Columns.Add("Co-Ordinator", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.15), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Appointment Subject", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.66), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Appointment Address", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Appointment Date", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Appointment Note", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Transport", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Transport Type", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Translator", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Created/Changed By", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Created Date", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Last Modified Action", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Last Modified By", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.Columns.Add("Last Modified Date", Convert.ToInt32(lstvwAppointmentsAudit.Width * 0.2), HorizontalAlignment.Left);
            lstvwAppointmentsAudit.View = View.Details;
        }

        private void printAuditReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportViewer frmRep = new frmReportViewer(PatientSubFileID, "AppointmentsAudit - Patient No: " + PatientSubFileID);

            frmRep.StartPosition = FormStartPosition.CenterScreen;
            frmRep.Height = Convert.ToInt32(this.ClientSize.Height * 0.99);
            frmRep.Width = Convert.ToInt32(this.ClientSize.Width * 0.99);

            StringBuilder sbHTML = new StringBuilder();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet ds = new DataSet();

            try
            {
                frmRep.ShowDialog();
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
            finally
            {
                ////commonFuncs = null;
            }
        }
    }
}