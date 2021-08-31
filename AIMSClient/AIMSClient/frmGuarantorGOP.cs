using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AIMSClient
{
    public partial class frmGuarantorGOP : Form
    {
        AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();

        string _PatientId = "";
        public string PatientID
        {
            get { return _PatientId; }
            set
            {
                _PatientId = value;
            }
        }

        string _EmailGOPID = "";
        public string EmailGOPID
        {
            get { return _EmailGOPID; }
            set
            {
                _EmailGOPID = value;
            }
        }

        public frmGuarantorGOP()
        {
            InitializeComponent();
        }

        private void btnAttachGOP_Click(object sender, EventArgs e)
        {
            if (lstvwInsuranceGOP.CheckedItems.Count.Equals(0) )
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "Please select a Letter-Of-Guarantee");
            }
            else
            {
                EmailGOPID = lstvwInsuranceGOP.Items[lstvwInsuranceGOP.CheckedItems[0].Index].SubItems[1].Text.ToString();
                if (File.Exists(EmailGOPID))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning, "INVALID GOP File, Please check if file exists");
                }
            }
        }

        private void lstvwInsuranceGOP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstvwInsuranceGOP_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                string sDocFileName = "";
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected || lstGet.Items[i].Checked)
                    {
                        sDocFileName = lstGet.Items[i].SubItems[1].Text.ToString();
                        if (!sDocFileName.Equals("") && File.Exists(sDocFileName))
                        {
                            if (File.Exists(sDocFileName))
                            {
                                frmImageViewer frmImgViewer = new frmImageViewer();
                                frmImgViewer.EmailDocument = sDocFileName;
                                frmImgViewer.Text = " : Letter-Of-Guarantee - Received Date: " + lstGet.Items[i].SubItems[0].Text.ToString();
                                frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                                frmImgViewer.MaximizeBox = true;
                                frmImgViewer.ShowDialog();
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

        private DataTable GetInsuranceGOP()
        {
            DataTable dtLettersOfGuarantees =  commonFuncs.GetPatientFileLetterOfGuarantees(PatientID);

            if (dtLettersOfGuarantees.Rows.Count >0)
            {
                ListViewItem lstVwItm ;
                foreach (DataRow  dtrow in dtLettersOfGuarantees.Rows)
                {
                    lstVwItm =  new ListViewItem(dtrow["CREATION_DTTM"].ToString());
                    lstVwItm.SubItems.Add(dtrow["FILE_NAME"].ToString());
                    lstVwItm.SubItems.Add(dtrow["EMAIL_DOCUMENT_ID"].ToString());
                    lstvwInsuranceGOP.Items.Add(lstVwItm);
                }
            }
            else
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "There are no Letters-of-Guarantees from Insurance, Please check Email-Correspondence(s).");
                this.Close();
            }
            return dtLettersOfGuarantees;
        }

        private void frmGuarantorGOP_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading Patient File Letters-Of-Guarantees error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Loading Patient File Letters-Of-Guarantees error: " + ex.ToString());
            }
            GetInsuranceGOP();
        }
    }
}