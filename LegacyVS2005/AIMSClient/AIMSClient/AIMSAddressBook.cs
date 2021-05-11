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
    public partial class frmAIMSAddressBook : Form
    {
        AIMS.Common.CommonFunctions commonFuncs;
        public frmAIMSAddressBook()
        {
            InitializeComponent();
        }

        private void frmAIMSAddressBook_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
        }

        private bool ValidateControl()
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            bool returnVal = true;
            errProvider.Clear();
            try
            {
                if (txtContactFirstName.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtContactFirstName, "Please enter Contact Name");
                    txtContactFirstName.Focus();
                    returnVal = false;
                }

                if (txtContactEmailAddress.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtContactEmailAddress, "Please enter Contact Email Address");
                    txtContactEmailAddress.Focus();
                    returnVal = false;
                }

                if (!txtContactEmailAddress.Text.Trim().Equals(""))
                {
                    if (!commonFuncs.ValidEmailAddress(txtContactEmailAddress.Text.Trim()))
                    {
                        errProvider.SetError(txtContactEmailAddress, "Please enter valid email address");
                        txtContactEmailAddress.Focus();
                        returnVal = false;
                    }
                }
            }
            finally
            {
                //commonFuncs = null;
            }

            if (returnVal == true)
            {
                errProvider.Clear();
            }
            return returnVal;
        }

        private void btnAddToContacts_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error Adding new contact, Please try again");
                commonFuncs.ErrorLogger("Error Adding new contact " + ex.ToString());
            }
        }
    }
}