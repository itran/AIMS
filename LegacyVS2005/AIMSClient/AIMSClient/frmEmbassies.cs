using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using AIMS.BLL;
using System.Windows.Forms;
using AIMS.Common;

namespace AIMSClient
{
    public partial class frmEmbassies : Form
    {
        AIMS.Common.CommonFunctions CommonFuncs;

        public frmEmbassies()
        {
            InitializeComponent();
        }

        Int32 _EmbassyID;
        public Int32 EmbassyID
        {
            get { return _EmbassyID; }
            set
            {
                _EmbassyID = value;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();

        }
        private void ClearControls()
        {
            txtEmbassyAddress1.Text = "";
            txtEmbassyAddress2.Text = "";
            txtEmbassyAddress3.Text = "";
            txtEmbassyAddress4.Text = "";
            txtEmbassyAddress5.Text = "";
            txtEmbassyContactFaxNo.Text = "";
            txtEmbassyContactPerson.Text = "";
            txtEmbassyContactTelNo.Text = "";
            cboEmbassyCountry.SelectedIndex = -1;
            lblEmbassyID.Text = "";
        }

        private void btnAddEmbassy_Click(object sender, EventArgs e)
        {
            try 
	        {	        
                if (ValidateControl())
                {
                    bool bSaved = SaveEmbassy();
                    if (bSaved)
                    {
                        CommonFuncs.DisplayMessage(CommonTypes.MessagType.Success, "Embassy successfully added.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        CommonFuncs.ErrorLogger("Embassy details save error(SaveEmbassy Function error)");
                        CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error saving embassy details, Please contact System Administrator.");
                    }
                }	
	        }
	        catch (System.Exception ex)
	        {
                CommonFuncs.ErrorLogger("Embassy details save error: \n " + ex.ToString());
                CommonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error saving embassy details, Please contact System Administrator.");
	        }
        }

        private void frmEmbassies_Load(object sender, EventArgs e)
        {
            CommonFuncs = new CommonFunctions();
            LoadCountries();
            if (!EmbassyID.Equals("") )
            {
                lblEmbassyID.Text = EmbassyID.ToString();
                if (lblEmbassyID.Text.Equals("0"))
                {
                    lblEmbassyID.Text = "";
                    return;
                }
                LoadEmbassyDetails();
            }
            else
            {
                ClearControls();
            }
        }

        private void LoadEmbassyDetails()
        {
            DataTable dtEmbassyDetails= CommonFuncs.GetEmbassyDetails(lblEmbassyID.Text);
            if (dtEmbassyDetails.Rows.Count >0)
            {
                
                txtEmbassyAddress1.Text = dtEmbassyDetails.Rows[0]["Address1"].ToString();
                txtEmbassyAddress2.Text = dtEmbassyDetails.Rows[0]["Address2"].ToString();
                txtEmbassyAddress3.Text = dtEmbassyDetails.Rows[0]["Address3"].ToString();
                txtEmbassyAddress4.Text = dtEmbassyDetails.Rows[0]["Address4"].ToString();
                txtEmbassyAddress5.Text = dtEmbassyDetails.Rows[0]["Address5"].ToString();
                if (!dtEmbassyDetails.Rows[0]["COUNTRY_ID"].ToString().Equals(""))
                {
                    cboEmbassyCountry.SelectedValue = Convert.ToInt32(dtEmbassyDetails.Rows[0]["COUNTRY_ID"].ToString());
                }
                txtEmbassyContactFaxNo.Text = dtEmbassyDetails.Rows[0]["EMBASSY_FAX_NO"].ToString();
                txtEmbassyContactPerson.Text = dtEmbassyDetails.Rows[0]["EMBASSY_CONTACT_PERSON"].ToString();
                txtEmbassyContactTelNo.Text = dtEmbassyDetails.Rows[0]["EMBASSY_TEL_NO"].ToString();
                txtEmbassyName.Text = dtEmbassyDetails.Rows[0]["EMBASSY_NAME"].ToString();
                lblEmbassyID.Text = dtEmbassyDetails.Rows[0]["EMBASSY_ID"].ToString();
                if (dtEmbassyDetails.Rows[0]["EMBASSY_ACTIVE_YN"].ToString() == "")
                {
                    chkArchiveFile.Checked = true;
                }
                else
                {
                    chkArchiveFile.Checked = false;
                }
            }
        }

        private bool SaveEmbassy() 
        {
            string EmbassyLoadID = "";
            if (!lblEmbassyID.Text.Equals(""))
            {
                EmbassyLoadID = lblEmbassyID.Text.ToString();    
            }

            string EmbassyActiveYN = "";
            if (chkArchiveFile.Checked )
            {
                EmbassyActiveYN = "Y";
            }
            else
            {
                EmbassyActiveYN = "N";
            }

            string AddressCounty = "";

            if (cboEmbassyCountry.SelectedItem != null && cboEmbassyCountry.SelectedIndex > 0 )
            {
	             AddressCounty = cboEmbassyCountry.SelectedValue.ToString();
            }
            bool ReturnVal = CommonFuncs.SaveEmbassy(ref EmbassyLoadID, txtEmbassyName.Text, txtEmbassyContactTelNo.Text, txtEmbassyContactFaxNo.Text, txtEmbassyAddress1.Text, txtEmbassyAddress2.Text, txtEmbassyAddress3.Text, txtEmbassyAddress4.Text, txtEmbassyAddress5.Text, AddressCounty , txtEmbassyContactPerson.Text, EmbassyActiveYN);
            lblEmbassyID.Text = EmbassyLoadID.ToString();
            return ReturnVal;
        }

        private bool ValidateControl()
        {
            bool ReturnValue = true;
            try
            {
                errProvider.Clear();

                if (txtEmbassyName.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtEmbassyName, "Please Capture Embassy Name");
                    txtEmbassyName.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtEmbassyAddress1.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtEmbassyAddress1, "Please Capture Embassy Address1");
                    txtEmbassyAddress1.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtEmbassyAddress2.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtEmbassyAddress2, "Please Capture Embassy Address2");
                    txtEmbassyAddress2.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtEmbassyAddress3.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtEmbassyAddress3, "Please Capture Embassy Address3");
                    txtEmbassyAddress3.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                
            }finally 
            { 
            }

            return true;
        }

        private void LoadCountries()
        {
            DataTable tblCountries = new DataTable();

            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblCountries = lookupBLL.GetLookUpValues("COUNTRY_ID", "COUNTRY_NAME", "AIMS_COUNTRY", 0, "COUNTRY_NAME");
                cboEmbassyCountry.DataSource = tblCountries;
                cboEmbassyCountry.DisplayMember = "COUNTRY_NAME";
                cboEmbassyCountry.ValueMember = "COUNTRY_ID";
                cboEmbassyCountry.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                CommonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }
    }
}