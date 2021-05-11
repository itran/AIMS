using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AIMS.Common;
using AIMS.DAL;

namespace AIMSClient
{
    public partial class frmLogin : Form
    {
        [DllImport("advapi32.dll")]
        private static extern bool LogonUser(String lpszUsername,
            String lpszDomain, String lpszPassword, int dwLogonType,
            int dwLogonProvider, out int phToken);

        [DllImport("Kernel32.dll")]
        private static extern int GetLastError();

        AIMS.Client.CommonFuncs clsFuncs;
        DataTable _tblUser;
        frmMDIBackGround frmMDI;
        frmMain _frmParent;
        string RestrictionsList = "";
        string userPasswordSetup = "Y";
        string userPasswordHint = "";
        string userPasswordHintAnswer = "";
        string userSignature = "";
        bool SysAdminRole = false;
        public delegate void DblClickHandler();
        
        #region Constructor
        
        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(frmMain frmParent)
        {
            InitializeComponent();
            _frmParent = frmParent;
            txtName.Focus();
        }

        #endregion

        #region Control Events

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                clsFuncs = new AIMS.Client.CommonFuncs();
                
                //this.picLogo.Left = Convert.ToInt32(this.ClientSize.Width * 0.5) - 200;
                gpbxLogon.Width = this.ClientSize.Width;
                gpbxLogon.Top = Convert.ToInt32(this.ClientSize.Height * 0.5) - 120;
                pnlMain.Left = Convert.ToInt32(this.ClientSize.Width * 0.5) - 200;
                this.gpbxLogon.Left = 0;
                this.txtName.Focus();
            }
            catch (Exception ex)
            {
                clsFuncs.DisplayMessage(ex.Message,AIMS.Common.CommonTypes.MessagType.Error) ;
            }
        }

        private void frmLogin_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                //if ((this.ClientRectangle.Height > 0) && (this.ClientRectangle.Width > 0))
                //{
                       //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 180);
                       //e.Graphics.FillRectangle(lb, this.ClientRectangle);
                //}
            }
            catch (Exception)
            {
                
                throw;
            }                  
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            try
            {
                //this.picLogo.Top = this.Top + 120;
                //this.picLogo.Left = Convert.ToInt32(this.ClientSize.Width * 0.5) - 200;
                //this.gpbxLogon.Top = picLogo.Bottom + 20;
                this.gpbxLogon.Width = this.ClientSize.Width;
                picLogo.Top = this.gpbxLogon.Top - picLogo.Height;
                //this.gpbxLogon.Left = picLogo.Left + 20;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsFuncs = new AIMS.Client.CommonFuncs();
            
            try
            {
                if (ValidateControls())
                {
                    if (Login())
                    {
                        OnDblClicked();
                        clsFuncs.CurrentUserLoggedUser = txtName.Text.Trim().ToUpper();
                        frmMDIBackGround frmBack = new frmMDIBackGround();
                        frmBack.MdiParent = this.MdiParent;
                        frmBack.SignaturePath = userSignature;
                        frmBack.Height = this.ClientSize.Height - 10000;
                        frmBack.Width = this.ClientSize.Width;
                        frmBack.Dock = DockStyle.Fill;
                        frmBack.StartPosition = FormStartPosition.CenterParent;
                        frmBack.FormBorderStyle = FormBorderStyle.None;
                        frmBack.Show();                        
                    }
                    else
                    {
                        //MessageBox.Show("The username or password you entered is incorrect, Please try again?",  "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                       
                    }

                }
            }
            catch (Exception ex )
            {
                clsFuncs.DisplayMessage(ex.Message, AIMS.Common.CommonTypes.MessagType.Error);
                clsFuncs.ErrorLogger(ex.ToString());
            }
        }

        //private void txtName_TextChanged(object sender, EventArgs e)
        //{
        //    //if (txtName.Text.Length > 0)
        //    //{
        //    //    errProv.SetError(txtName, "");
        //    //}
        //}

        //private void txtPassword_TextChanged(object sender, EventArgs e)
        //{
        //    //if (txtPassword.Text.Length > 0)
        //    //{
        //    //    errProv.SetError(txtPassword, "");
        //    //}
        //}
        
        #endregion

        #region Helper Methods
        
        public bool ValidateControls()
        {
            bool returnVal = true;

            errProv.Clear();

            if (this.txtName.Text.Length == 0)
            {
                errProv.SetError(txtName, "Please enter your user name");
                txtName.Focus();
                returnVal = false;
            }


            if ((txtPassword.Text.Length == 0) && (returnVal == true))
            {
                errProv.SetError(txtPassword, "Please enter your password");
                txtPassword.Focus();
                returnVal = false;
            }

            if (returnVal == true)
            {
                errProv.Clear();
            }

            return returnVal;
        }
        #endregion

        #region BLL Methods
        
        private bool Login()
        {
            AIMS.BLL.User clsUser = new AIMS.BLL.User();
            
            DataTable dtRestrictions  = new DataTable();
            DataTable dtMenuRestrictions = new DataTable();
            bool ReturnValue = true;
            
            if (ReturnValue)
            {
                try
                {
                    clsUser = clsUser.GetUserDetails(txtName.Text.Trim().ToUpper());

                    if (clsUser != null)
                    {
                        userPasswordSetup = clsUser.PasswordWordSetupYN;
                        userPasswordHintAnswer = clsUser.PasswordWordHintAnswer;
                        userPasswordHint = clsUser.PasswordWordHint;
                        userSignature = clsUser.SignaturePath;
                        if (clsUser.PasswordWordSetupYN.Equals("N"))
                        {
                            AIMS.Common.CommonFunctions cmmnFuncs = new AIMS.Common.CommonFunctions();
                            cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Password not setup/created yet, Please create a password");
                            cmmnFuncs = null;
                            return false;
                        }
                        if (!clsUser.UserPassword.Equals(txtPassword.Text))
                        {
                            AIMS.Common.CommonFunctions cmmnFuncs = new AIMS.Common.CommonFunctions();
                            cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Invalid user-name or password, please try again");
                            cmmnFuncs = null;
                            return false;
                        }
                        if (clsUser.DomainAuthYN == "Y")
                        {
                            ReturnValue = DomainAuth();
                            if (!ReturnValue)
                            {
                                return false;
                            }
                        }

                        _frmParent.UserName = clsUser.UserFullName.ToString();
                        _frmParent.UserID = txtName.Text.Trim().ToUpper();
                        _frmParent.UserEmailAddress = clsUser.UserEmailAddress.ToString(); 
                        _frmParent.EnableToolBar = true;
                        
                        DataTable dtAllAccess = clsUser.GetAllRestrictions(_frmParent.UserID);
                        if (dtAllAccess.Rows.Count > 0)
                        {
                            RestrictionsList = "";
                            for (int k = 0; k < dtAllAccess.Rows.Count; k++)
                            {
                                RestrictionsList += dtAllAccess.Rows[k]["RESTRICTION_ID"].ToString() + ",";
                            }
                            RestrictionsList = RestrictionsList.Substring(0, RestrictionsList.Length - 1);
                            
                            _frmParent.Restrictions = RestrictionsList;
                            _frmParent.ViewReports = true;
                            _frmParent.ViewPatientFiles = true;
                            _frmParent.ViewGuarantors = true;
                            _frmParent.ViewPayments = true;
                            _frmParent.ViewSuppliers = true;
                            _frmParent.ViewInvoices = true;
                            _frmParent.ViewUserMaintenance = true;
                            _frmParent.ViewDashboard = true;
                            _frmParent.SignaturePath = userSignature;
                            SysAdminRole = true;
                            dtAllAccess.Dispose();
                        }
                        _frmParent.Restrictions = RestrictionsList;

                        if (!SysAdminRole)
                        {
                            dtRestrictions = clsUser.GetUserRestrictions(_frmParent.UserID);
                            if (dtRestrictions.Rows.Count > 0)
                            {
                                string UserRoleCD = "";
                                for (int i = 0; i < dtRestrictions.Rows.Count; i++)
                                {
                                    RestrictionsList += dtRestrictions.Rows[i]["RESTRICTION_ID"].ToString() + ",";
                                }

                                //Remove the last comma
                                RestrictionsList = RestrictionsList.Substring(0, RestrictionsList.Length - 1);
                                dtRestrictions.Dispose();
                            }

                            _frmParent.Restrictions = RestrictionsList;

                            dtMenuRestrictions = clsUser.GetUserMenuAccess(_frmParent.UserID);
                            if (dtMenuRestrictions.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtMenuRestrictions.Rows.Count; i++)
                                {
                                    switch (dtMenuRestrictions.Rows[i]["RESTRICTION_DESC"].ToString())
                                    {
                                        case "View Reports":
                                            _frmParent.ViewReports = true;
                                            break;
                                        case "View Patients Files":
                                            _frmParent.ViewPatientFiles = true;
                                            break;
                                        case "View Guarantors":
                                            _frmParent.ViewGuarantors = true;
                                            break;
                                        case "View Payments":
                                            _frmParent.ViewPayments = true;
                                            break;
                                        case "View Suppliers":
                                            _frmParent.ViewSuppliers = true;
                                            break;
                                        case "View Invoices":
                                            _frmParent.ViewInvoices = true;
                                            break;
                                        case "View User Maintenance":
                                            _frmParent.ViewUserMaintenance = true;
                                            break;
                                        case "View Dashboard":
                                            _frmParent.ViewDashboard = true;
                                            break;                                        
                                    }
                                }
                            }
                            dtMenuRestrictions.Dispose();
                        }

                        ReturnValue = true;
                        //MessageBox.Show("ReturnValue 2: " + ReturnValue);
                        ContinueLogin();
                    }
                    else
                    {
                        ReturnValue = false;
                        clsFuncs.DisplayMessage("Invalid User Name.", AIMS.Common.CommonTypes.MessagType.Error);
                        txtName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    clsFuncs.DisplayMessage(ex.ToString(), AIMS.Common.CommonTypes.MessagType.Error);
                }
                finally
                {
                    clsUser = null;
                }
            }
            else
            {
                ReturnValue = false;
                //MessageBox.Show("ReturnValue 4: " + ReturnValue);
            }

            return ReturnValue;
        }

        private bool UserIdValid()
        {
            AIMS.BLL.User clsUser = new AIMS.BLL.User();
            
            DataTable dtRestrictions  = new DataTable();
            bool ReturnValue = true;
                
            clsUser = clsUser.GetUserDetails(txtName.Text.Trim().ToUpper());

            if (clsUser != null)
            {
                userPasswordSetup = clsUser.PasswordWordSetupYN;
                userPasswordHintAnswer = clsUser.PasswordWordHintAnswer;
                userPasswordHint = clsUser.PasswordWordHint;
                ReturnValue = true;
            }
            else
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }

        private bool UserPasswordExist()
        {
            AIMS.BLL.User clsUser = new AIMS.BLL.User();

            DataTable dtRestrictions = new DataTable();
            bool ReturnValue = false;

            clsUser = clsUser.GetUserDetails(txtName.Text.Trim().ToUpper());

            if (clsUser.PasswordWordSetupYN.Equals("Y") )
            {
                ReturnValue = true;    
            }
            
            return ReturnValue;
        }

        //Get User Permissions and Enable/Disable certain toolbar items
        private void ContinueLogin()
        {
            //frmMDI = new frmMDIBackGround();
            //frmMDI.Show();
            //this.Close();
        }
        #endregion
        
        public event DblClickHandler DblClicked;

        protected virtual void OnDblClicked()
        {
            if (DblClicked != null)
            {
                DblClicked(); //Notify Subscribers
            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void gpbxLogon_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?","AIMS",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private bool UserAllowed(string RestrictionID)
        {
            bool bAllowedFunction = false;
            if (RestrictionsList.Trim().Length > 0)
            {
                string[] arrPermissions = RestrictionsList.Split(new Char[] { ',' });

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
        
        private bool DomainAuth()
        {
            bool ReturnValue = false;

            string LoginUser = txtName.Text.Trim().ToUpper();

            ReturnValue = LogOnXP("DC1", LoginUser, txtPassword.Text);
            return ReturnValue;
        }

        #region NTLogonUser
        #region Direct OS LogonUser Code

        public static bool LogOnXP(String sDomain, String sUser, String sPassword)
        {
            int token1, ret;
            int attmpts = 0;

            bool LoggedOn = false;

            while (!LoggedOn && attmpts < 2)
            {
                LoggedOn = LogonUser(sUser, sDomain, sPassword, 3, 0, out token1);
                if (LoggedOn) return (true);
                else
                {
                    switch (ret = GetLastError())
                    {
                        case (126): ;
                            //if (attmpts++ > 2)
                            //    throw new LogonException(
                            //        "Specified module could not be found. error code: " +
                            //        ret.ToString());
                            return false;
                            break;

                        case (1314):
                            //throw new LogonException(
                            //    "Specified module could not be found. error code: " +
                            //    ret.ToString());
                            return false;
                            break;
                        case (1326):
                            // edited out based on comment
                            //  throw new LogonException(
                            //	"Unknown user name or bad password.");
                            return false;

                        default:
                            return false;
                            //throw new LogonException(
                            //    "Unexpected Logon Failure. Contact Administrator");
                    }
                }
            }
            return (false);
        }
        #endregion Direct Logon Code

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion NTLogonUser

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clsFuncs = new AIMS.Client.CommonFuncs();

                if (ValidateControls())
                {
                    if (Login())
                    {
                        OnDblClicked();
                        clsFuncs.CurrentUserLoggedUser = txtName.Text.Trim().ToUpper();
                        frmMDIBackGround frmBack = new frmMDIBackGround();
                        frmBack.MdiParent = this.MdiParent;
                        frmBack.Height = this.ClientSize.Height - 10000;
                        frmBack.Width = this.ClientSize.Width;
                        frmBack.Dock = DockStyle.Fill;
                        frmBack.StartPosition = FormStartPosition.CenterParent;
                        frmBack.FormBorderStyle = FormBorderStyle.None;
                        frmBack.Show();    
                    }
                }
            }
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {

        }

        private void lnkCreatePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AIMS.Common.CommonFunctions comm = new AIMS.Common.CommonFunctions();

            if (!txtName.Text.Trim().Equals(""))
            {
                if (UserIdValid())
                {
                    if (userPasswordSetup.Equals("N") || userPasswordSetup.Equals(""))
                    {
                        frmPasswordSetup frmPass;
                        frmPass = new frmPasswordSetup();
                        frmPass.ShowInTaskbar = false;
                        frmPass.StartPosition = FormStartPosition.CenterParent;
                        frmPass.Text = "Password Setup";
                        frmPass.UserID = txtName.Text;

                        if (frmPass.ShowDialog() == DialogResult.OK)
                        {
                            comm.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Password Setup, Continue login system");
                            txtPassword.Focus();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        comm.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Password previously setup, please recover your password");
                    }
                }
                else
                {
                    comm.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Invalid user name.");
                }
            }
            else
            {
                comm.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture your user-id.");
            }
        }

        private void lnkForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AIMS.Common.CommonFunctions comm = new AIMS.Common.CommonFunctions();

            if (!txtName.Text.Trim().Equals(""))
            {
                if (UserIdValid())
                {
                    frmPasswordSetup frmPass;
                    frmPass = new frmPasswordSetup();
                    frmPass.ShowInTaskbar = false;
                    frmPass.StartPosition = FormStartPosition.CenterParent;
                    frmPass.Text = "Password Recovery";
                    frmPass.UserID = txtName.Text;
                    frmPass.PasswordHint = userPasswordHint;
                    frmPass.PasswordHintAnswer = userPasswordHintAnswer; 

                    if (frmPass.ShowDialog() == DialogResult.OK)
                    {
                        comm.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Password Setup, Continue Signing to System");
                        txtPassword.Focus();
                    }
                    else
                    {

                    }
                }
                else
                {
                    comm.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Invalid user name.");
                }
            }
            else
            {
                comm.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture your user-id.");
            }
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }   
    }
}