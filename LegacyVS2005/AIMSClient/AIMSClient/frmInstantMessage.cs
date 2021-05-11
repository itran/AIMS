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
    public partial class frmInstantMessage : Form
    {
        public AIMS.Common.CommonFunctions commonFuncs;
        protected string patientNo = string.Empty;

        public frmInstantMessage()
        {
            InitializeComponent();
        }

        public frmInstantMessage(string patientFileNo)
        {
            InitializeComponent();
            patientNo = patientFileNo;
        }

        private string _userID = "";
        
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private void btnSendIM_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cboIMUsers.Text.Equals("") && !txtMessage.Text.Trim().Equals(""))
                {
                    bool bSendIM = false;
                    bSendIM = commonFuncs.SendInstantMessage(patientNo, UserID, cboIMUsers.SelectedValue.ToString(), txtMessage.Text);
                    if (bSendIM)
                    {
                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Success, "Instant Message Sent to: " + cboIMUsers.Text);
                        this.Close();
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error sending Instant Message, Please try again.");
                    }
                }
                else
                {
                    commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Please capture all fields.");
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void frmInstantMessage_Load(object sender, EventArgs e)
        {
            commonFuncs = new CommonFunctions();
            DataTable dtAllUsers = commonFuncs.Get_AIMS_Active_Users();
            cboIMUsers.DataSource = dtAllUsers;
            cboIMUsers.DisplayMember = "USER_NAME_FULL";
            cboIMUsers.ValueMember = "USER_NAME";
            cboIMUsers.SelectedValue = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}