using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmLogin1 : Form
    {
        AIMS.Client.CommonFuncs clsFuncs;
        DataTable _tblUser;
        frmMDIBackGround frmMDI;
        frmMain _frmParent;
        AIMS.Common.CommonFunctions CommonFunc = new AIMS.Common.CommonFunctions();

        public delegate void DblClickHandler();
        
        #region Constructor
        
        public frmLogin1()
        {
            InitializeComponent();
        }

        public frmLogin1(frmMain frmParent)
        {
            InitializeComponent();
            _frmParent = frmParent;
        }

        #endregion

        #region Control Events

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                clsFuncs = new AIMS.Client.CommonFuncs();
                this.picLogo.Left = Convert.ToInt32(this.ClientSize.Width * 0.5) - 200;
                this.gpbxLogon.Left = picLogo.Left;
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
                if ((this.ClientRectangle.Height > 0) && (this.ClientRectangle.Width > 0))
                {
                       System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 180);
                       e.Graphics.FillRectangle(lb, this.ClientRectangle);
                }
                
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
                this.picLogo.Top = this.Top + 120;
                this.picLogo.Left = Convert.ToInt32(this.ClientSize.Width * 0.5) - 200;
                this.gpbxLogon.Top = picLogo.Bottom + 20;
                this.gpbxLogon.Left = picLogo.Left + 20;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsFuncs = new AIMS.Client.CommonFuncs();
            _frmParent.pnlStatus.Text = "Logging In....";
            this.Cursor = Cursors.WaitCursor;
            btnOK.Enabled = false;          
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
                        frmBack.Height = this.ClientSize.Height - 10000;
                        frmBack.Width = this.ClientSize.Width;
                        frmBack.Dock = DockStyle.Fill;
                        frmBack.StartPosition = FormStartPosition.CenterParent;
                        frmBack.FormBorderStyle = FormBorderStyle.None;
                        frmBack.Show();
                        _frmParent.pnlStatus.Text = "";
                        //_frmParent.UserName = clsFuncs.CurrentUserLoggedUser;                                                
                    }
                    else
                    {
                        clsFuncs.DisplayMessage("The username or password you entered is incorrect, Please try again.", AIMS.Common.CommonTypes.MessagType.Error);
                        this.Cursor = Cursors.Arrow;
                        btnOK.Enabled = true;
                        return;                       
                    }
                }
            }
            catch (Exception ex )
            {
                clsFuncs.DisplayMessage(ex.Message, AIMS.Common.CommonTypes.MessagType.Error);
                btnOK.Enabled = true;
            }

            _frmParent.pnlStatus.Text = "";
            this.Cursor = Cursors.Default;
        }
        
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
            bool retValue = false;
            
            try
            {
                clsUser = clsUser.GetUserDetails(txtName.Text.Trim().ToUpper());

                if (clsUser != null )
                {
                    _frmParent.UserName = clsUser.UserFullName.ToString();
                    _frmParent.UserID = txtName.Text.Trim().ToUpper();
                    _frmParent.EnableToolBar = true;
                    retValue = true;
                    ContinueLogin();
                }
                else
                {
                    retValue = false;
                }         
            }
            catch (Exception ex)
            {
                clsFuncs.DisplayMessage(ex.Message, AIMS.Common.CommonTypes.MessagType.Error);
            }
            return retValue;
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

      
    }
}