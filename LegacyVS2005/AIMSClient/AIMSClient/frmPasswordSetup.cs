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
    public partial class frmPasswordSetup : Form
    {
        public frmPasswordSetup()
        {
            InitializeComponent();
        }
        AIMS.Common.CommonFunctions cmmnFuncs = new AIMS.Common.CommonFunctions();
        string _userID = "";
        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }

        string _passwordHint = "";
        public string PasswordHint
        {
            get { return _passwordHint; }
            set
            {
                _passwordHint = value;
            }
        }

        string _passwordHintAnswer = "";
        public string PasswordHintAnswer
        {
            get { return _passwordHintAnswer; }
            set
            {
                _passwordHintAnswer = value;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmPasswordSetup_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
            if (this.Text == "Password Recovery")
            {
                tabControl1.SelectedIndex = 1;
                tabControl1.TabPages[0].Hide();
                groupBox1.Enabled = false;
                cmbRecoveryPasswordHint.Items.Clear();
                cmbRecoveryPasswordHint.Items.Add(PasswordHint);
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }

        private void btnPassConfirm_Click_1(object sender, EventArgs e)
        {
            AIMS.BLL.User clsUser = new AIMS.BLL.User();
            try
            {
                if (this.Text == "Password Recovery")
                {

                }
                else
                {
                    if (ValidateControls())
                    {
                        bool PasswordSaved = clsUser.SaveUserPassword(UserID, txtPassword.Text, cmbPasswordHint.Text, txtPasswordHintAnswer.Text);
                        if (PasswordSaved)
                        {
                            cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Password Created Successfully.\n Please keep your password and hint safe -;)");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error saving your password, Please try again. \n If problem persists, contact System Administrator.");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Problem saving your password, Please try again.");
                cmmnFuncs.ErrorLogger("Problem saving your password: " + ex.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); 
        }

        public bool ValidateControls()
        {
            bool returnVal = true;

            errProv.Clear();

            if (this.txtPassword.Text.Length == 0)
            {
                errProv.SetError(txtPassword, "Please enter your user password");
                txtPassword.Focus();
                returnVal = false;
            }

            if ((txtPassword.Text.Length == 0) && (returnVal == true))
            {
                errProv.SetError(txtPassword, "Please enter your password");
                
                txtPassword.Focus();
                returnVal = false;
            }

            if (!txtPasswordConfirm.Text.Equals(txtPassword.Text))
            {
                errProv.SetError(txtPasswordConfirm, "Passwords are not the same");
                errProv.SetError(txtPassword, "Passwords are not the same");
                txtPasswordConfirm.Focus();
                returnVal = false;
            }

            if (cmbPasswordHint.SelectedIndex < 0 )
            {                
                errProv.SetError(cmbPasswordHint, "Select Password Hint to help you remember your password");
                cmbPasswordHint.Focus();
                returnVal = false;
            }

            if (txtPasswordHintAnswer.Text.Trim().Equals(""))
            {
                errProv.SetError(txtPasswordHintAnswer, "Passwords hint answer not captured.");
                txtPasswordHintAnswer.Focus();
                returnVal = false;
            }
            if (returnVal == true)
            {
                errProv.Clear();
            }
            return returnVal;
        }

        private void btnGetPassword_Click(object sender, EventArgs e)
        {
            AIMS.BLL.User clsUser = new AIMS.BLL.User();

            if (cmbRecoveryPasswordHint.SelectedIndex <0)
            {
                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Select your password hint");
                return;
            }

            if (txtRecoveryPasswordHintAnswer.Text.Equals("") )
            {
                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Please capture your password hint to help recover your password.");
                return;
            }

            clsUser = clsUser.GetUserDetails(UserID);

            string userPassword = clsUser.UserPassword;

            if (!PasswordHintAnswer.Equals(txtRecoveryPasswordHintAnswer.Text))
            {
                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Warning,"Password Hint Answer is Incorrect, please try again");
            }
            else
            {
                cmmnFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Your password is: \n\n" + clsUser.UserPassword);
            }
        }

        private void txtPasswordHintAnswer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}