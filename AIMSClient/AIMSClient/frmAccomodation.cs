using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConvertHTMLToPDF;
using System.Diagnostics;
using AIMS.BLL;
using AIMS.Common;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Forms;
using System.IO;

namespace AIMSClient
{
    public partial class frmAccomodation : Form
    {
        AIMS.Common.CommonFunctions commonFuncs;
        DataTable tblSuppliers = new DataTable();
        bool filePreviewed = false;
        string AccomodationLetter = "";
        System.Diagnostics.Process FilePreview;
        string AccomodationLetterFile = "";
        private string _restrictions = string.Empty;
        string opsManagerName = "";
        string opsManagerSignature = "";
        public string Restrictions
        {
            get { return _restrictions; }
            set
            {
                _restrictions = value;
            }
        }
        string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        string _UserFullName = "";
        public string UserFullName
        {
            get { return _UserFullName; }
            set
            {
                _UserFullName = value;
            }
        }

        string _dateOfBirth = "";
        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
            }
        }

        string _GuaranteeAmount = "";
        public string GuaranteeAmount
        {
            get { return _GuaranteeAmount; }
            set
            {
                _GuaranteeAmount = value;
            }
        }

        string _PassPortNo = "";
        public string PassPortNo
        {
            get { return _PassPortNo; }
            set
            {
                _PassPortNo = value;
            }
        }

        string _templateName = "";
        public string TemplateName
        {
            get { return _templateName; }
            set
            {
                _templateName = value;
            }
        }

        string _signaturePath = "";
        public string SignaturePath
        {
            get { return _signaturePath; }
            set
            {
                _signaturePath = value;
            }
        }

        string _PatientDOB = "";
        public string PatientDOB
        {
            get { return _PatientDOB; }
            set
            {
                _PatientDOB = value;
            }
        }

        string _Nationality = "";
        public string Nationality
        {
            get { return _Nationality; }
            set
            {
                _Nationality = value;
            }
        }

        string _PatientFileNo = "";
        public string PatientFileNo
        {
            get { return _PatientFileNo; }
            set
            {
                _PatientFileNo = value;
            }
        }

        string _PatientId = "";
        public string PatientID
        {
            get { return _PatientId; }
            set
            {
                _PatientId = value;
            }
        }

        Int32 _Hospital;
        public Int32 Hospital
        {
            get { return _Hospital; }
            set
            {
                _Hospital = value;
            }
        }

        Int32 _CountryOfTreatment;
        public Int32 CountryOfTreatment
        {
            get { return _CountryOfTreatment; }
            set
            {
                _CountryOfTreatment = value;
            }
        }

        string _PatientName = "";
        public string PatientName
        {
            get { return _PatientName; }
            set
            {
                _PatientName = value;
            }
        }

        string _UserID = "";
        public string UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
            }
        }

        string _SupplierID = "";
        public string SupplierID
        {
            get { return _SupplierID; }
            set
            {
                _SupplierID = value;
            }
        }

        string _PassportNo = "";
        public string PassportNo
        {
            get { return _PassportNo; }
            set
            {
                _PassportNo = value;
            }
        }

        public frmAccomodation()
        {
            InitializeComponent();
        }

        private void frmAccomodation_Load(object sender, EventArgs e)
        {
            AccomodationLetter = "";
            LoadSuppliers();
            //LoadReligions();
            LoadCountries();
            LoadRoomTypes();
            LoadCurrencies();
            string dtDateOfBirth = DateOfBirth;
            DateTime dtDOB;
            DateTime dtdueDate;
            if (DateTime.TryParse(dtDateOfBirth, out dtDOB))
            {
                this.dtGuestDOB.Text = dtDOB.ToString("dd/MM/yyyy");
            }
        }

        private void LoadRoomTypes()
        {
            DataTable tblRoomTypes = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblRoomTypes = lookupBLL.GetLookUpValues("ROOM_TYPE_ID", "ROOM_TYPE_CD", "AIMS_ROOM_TYPES", 0, "ROOM_TYPE_CD");
                cboRoomType.DataSource = tblRoomTypes;
                cboRoomType.DisplayMember = "ROOM_TYPE_CD";
                cboRoomType.ValueMember = "ROOM_TYPE_ID";
                cboRoomType.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadCurrencies()
        {
            DataTable tblCurrencies = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblCurrencies = lookupBLL.GetLookUpValues("code", "currency", "aims_currency", 0, "code");
                cboCurrencies.DataSource = tblCurrencies;
                cboCurrencies.DisplayMember = "code";
                cboCurrencies.ValueMember = "code";
                cboCurrencies.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadSuppliers()
        {
            DataTable tblSuppliers = new DataTable();
            String where_Clause = @"where SUPPLIER_TYPE_ID in (
            select SUPPLIER_TYPE_ID from AIMS_SUPPLIER_TYPES where SUPPLIER_TYPE_DESC like '%Guest%'
            union 
            select SUPPLIER_TYPE_ID from AIMS_SUPPLIER_TYPES where SUPPLIER_TYPE_DESC like '%Hotel%'
            union 
            select SUPPLIER_TYPE_ID from AIMS_SUPPLIER_TYPES where SUPPLIER_TYPE_DESC like '%Accomodation%')";

            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
            try
            {
                tblSuppliers = lookupBLL.GetLookUpValues("SUPPLIER_ID", "SUPPLIER_NAME", "AIMS_SUPPLIER", 0, "supplier_name", where_Clause);
                cboAccomodation.DataSource = tblSuppliers;
                cboAccomodation.DisplayMember = "SUPPLIER_NAME";
                cboAccomodation.ValueMember = "SUPPLIER_ID";
                cboAccomodation.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadReligions()
        {
            DataTable tblReligions = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblReligions = lookupBLL.GetLookUpValues("RELIGION_ID", "RELIGION", "AIMS_RELIGION", 0,"RELIGION");
                cboReligion.DataSource = tblReligions;
                cboReligion.DisplayMember = "RELIGION";
                cboReligion.ValueMember = "RELIGION_ID";
                cboReligion.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadCountries()
        {
            DataTable tblCountries = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblCountries = lookupBLL.GetLookUpValues("COUNTRY_ID", "COUNTRY_NAME", "AIMS_COUNTRY", 0, "COUNTRY_NAME");
                cboCountryOfOrigin.DataSource = tblCountries;
                cboCountryOfOrigin.DisplayMember = "COUNTRY_NAME";
                cboCountryOfOrigin.ValueMember = "COUNTRY_ID";
                cboCountryOfOrigin.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void AccomodationPreview()
        {
            if (!ValidateControl())
                return;

            //createAIMSAccomodation();
            string pdfFile = @"c:\AIMS Recorder\Accomodation_CE_" + System.Guid.NewGuid() + ".pdf";

            string meals = "";
            if (chkMealBreakFast.Checked  )
                meals += "BreakFast /";
            if (chkMealBreakFast.Checked)
                meals += "Lunch /";
            if (chkMealBreakFast.Checked)
                meals += "Dinner /";
            if (chkMealBreakFast.Checked)
                meals += "Full board /";

            if (meals.EndsWith("/"))
                meals = meals.Substring(0,meals.Length -1);
            commonFuncs = new CommonFunctions();
            DataTable dtParamVal = commonFuncs.GetLimitationCodeValue("OPS_MANAGER_DETAILS");
            string sOpsManagerDetails = "";
            if (dtParamVal.Rows.Count > 0)
            {
                sOpsManagerDetails = dtParamVal.Rows[0]["LIMITATION_VALUE"].ToString();
            }
            else
            {
                sOpsManagerDetails = @"Stanley Nkosi|C:\AIMS Recorder\stanley_nkosi.png";
            }

            string[] arropsManager = sOpsManagerDetails.Split(new Char[] { '|' });
            opsManagerName = arropsManager[0].ToString();
            opsManagerSignature = arropsManager[1].ToString();

            if (File.Exists(AccomodationLetter))
            {
                File.Delete(AccomodationLetter);
            }
            pdfFile = "";
            createAccomodationVoucher(ref pdfFile,
                                        cboAccomodation.Text,
                                        txtGuestMobileTelNo.Text,
                                        txtGuestEmailAddress.Text,
                                        txtGuestName.Text,
                                        dtGuestDOB.Text,
                                        numNoOfGuests.Value.ToString(),
                                        PatientFileNo,
                                        txtGuaranteedRatePerNight.Text,
                                        dtCheckInDate.Text,
                                        dtCheckOutDate.Text,
                                        cboRoomType.Text,
                                        meals,
                                        cboLaundry.Text,
                                        cboSocialTransportCover.Text,
                                        txtAdditionalNotes.Text, lblCurrency.Text);

            AccomodationLetter = pdfFile;
            ViewFile();
        }

        private bool ValidateControl()
        {
            bool ReturnValue = true;
            try
            {
                errProvider.Clear();
                if (cboAccomodation.SelectedItem == null)
                {
                    errProvider.SetError(cboAccomodation, "Please select Accomodation Name");
                    cboAccomodation.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboAccomodation.SelectedItem != null && (cboAccomodation.Text == ""))
                {
                    errProvider.SetError(cboAccomodation, "Please select Accomodation Name");
                    cboAccomodation.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtGuestMobileTelNo.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtGuestMobileTelNo, "Please capture Guest Tel No / Cell No");
                    txtGuestMobileTelNo.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtGuestEmailAddress.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtGuestEmailAddress, "Please capture Guest Email Address");
                    txtGuestEmailAddress.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                CommonFunctions cmmFuncs = new CommonFunctions();
                if (!cmmFuncs.ValidEmailAddress(txtGuestEmailAddress.Text))
                {
                    errProvider.SetError(txtGuestEmailAddress, "Please capture Valid Email Address");
                    txtGuestEmailAddress.Focus();
                    ReturnValue = false;
                    return ReturnValue;                    
                }

                if (txtGuestName.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtGuestName, "Please capture Guest name");
                    txtGuestName.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (numNoOfGuests.Value  <=0)
                {
                    errProvider.SetError(numNoOfGuests, "Please capture Number of Guests");
                    numNoOfGuests.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtGuaranteedRatePerNight.Text.Trim().Equals("")  )
                {
                    errProvider.SetError(txtGuaranteedRatePerNight, "Please capture Guarantee Room-Rate");
                    txtGuaranteedRatePerNight.Focus();
                    ReturnValue = false;
                    return ReturnValue;                    
                }

                if (cboCurrencies.SelectedItem == null)
                {
                    errProvider.SetError(cboCurrencies, "Please select Currency");
                    cboCurrencies.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboCurrencies.SelectedItem != null && (cboCurrencies.Text == ""))
                {
                    errProvider.SetError(cboCurrencies, "Please select Currency");
                    cboCurrencies.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboRoomType.SelectedItem == null)
                {
                    errProvider.SetError(cboRoomType, "Please select Room Type");
                    cboRoomType.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboRoomType.SelectedItem != null && (cboRoomType.Text == ""))
                {
                    errProvider.SetError(cboRoomType, "Please select Room Type");
                    cboRoomType.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                if (cboMeals.SelectedItem == null)
                {
                    errProvider.SetError(cboMeals, "Please select Meals Option");
                    cboMeals.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboMeals.SelectedItem != null && (cboRoomType.Text == ""))
                {
                    errProvider.SetError(cboMeals, "Please select Meals");
                    cboRoomType.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboMeals.Text == "Yes")
                {
                    if (!chkMealBreakFast.Checked & !chkMealDinner.Checked & !chkMealFullboard.Checked & !chkMealLunch.Checked )
                    {
                        errProvider.SetError(cboMeals, "Please select Meals Type(s)");
                        cboRoomType.Focus();
                        ReturnValue = false;
                        return ReturnValue;   
                    }
                }

                if (cboLaundry.SelectedItem == null)
                {
                    errProvider.SetError(cboLaundry, "Please select Laundry");
                    cboLaundry.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboLaundry.SelectedItem != null && (cboLaundry.Text == ""))
                {
                    errProvider.SetError(cboMeals, "Please select Laundry");
                    cboLaundry.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboSocialTransportCover.SelectedItem == null)
                {
                    errProvider.SetError(cboSocialTransportCover, "Please select Social Transport");
                    cboSocialTransportCover.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboSocialTransportCover.SelectedItem != null && (cboSocialTransportCover.Text == ""))
                {
                    errProvider.SetError(cboSocialTransportCover, "Please select Social Transport");
                    cboSocialTransportCover.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtAdditionalNotes.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtAdditionalNotes, "Please capture Additional notes");
                    txtAdditionalNotes.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
            }
            finally
            {

            }
            return ReturnValue;
        }

        private void btnGuaranteePreview_Click(object sender, EventArgs e)
        {
            AccomodationPreview();
        }

        private void ViewFile()
        {
            frmImageViewer frmImgViewer = new frmImageViewer();
            try
            {
                frmImgViewer.EmailDocument = AccomodationLetter;
                frmImgViewer.Text = PatientFileNo +  " - Accomodation Voucher" ;
                frmImgViewer.MaximizeBox = false;
                frmImgViewer.MinimizeBox = false;
                frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                
                frmImgViewer.ShowDialog();
                DialogResult dialogRes = MessageBox.Show("Continue with the Previewed Accommodation Letter...?", "Proceed with Previewed Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogRes == DialogResult.Yes )
                {
                    filePreviewed = true;
                }
                else
                {
                    filePreviewed = false;
                    try
                    {
                        File.Delete(AccomodationLetter);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error displaying Preview File, Please contact System Administrator");
                commonFuncs.ErrorLogger("Error displaying Preview File \n" + ex.ToString());
            }
            finally
            {
                frmImgViewer.Dispose(); 
            }
        }

        private void btnGuaranteeCreate_Click(object sender, EventArgs e)
        {
            try
            {
                commonFuncs = new CommonFunctions();
                DialogResult dbDialog = MessageBox.Show("Continue creating Accomodation Voucher", "Confirm Accomodation Voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dbDialog == DialogResult.Yes)
                {
                    if (ValidateControl())
                    {
                        if (filePreviewed)
                        {
                            ArchiveFile();
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Please preview Accomodation-Voucher");
                        }
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Please capture Accomodation-Voucher missing details");
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Problem creating Accomodation-Booking");
                commonFuncs.ErrorLogger("Problem creating Accomodation-Booking: \n" + ex.ToString());

                File.SetAttributes(AccomodationLetterFile, FileAttributes.Normal);
                File.Delete(AccomodationLetterFile);
            }
        }

        private void ArchiveFile() {
            commonFuncs = new CommonFunctions();
            DataTable dtLimitation = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_POD_ACCOMODATION");
            try
            {
                if (!dtLimitation.Rows.Count.Equals(0))
                {
                    string GuaranteePOD = dtLimitation.Rows[0]["LIMITATION_VALUE"].ToString();
                    string GuaranteeMonth = System.DateTime.Now.ToString("MMMM");
                    string GuaranteeYear = System.DateTime.Now.Year.ToString();
                    AccomodationLetterFile = Path.Combine(@GuaranteePOD, GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy") + @"\" + PatientFileNo.Substring(3) + Path.GetFileName(AccomodationLetter));

                    if (!Directory.Exists(@GuaranteePOD + GuaranteeYear)) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear); }
                    if (!Directory.Exists(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth)) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth); }
                    if (!Directory.Exists(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy"))) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy")); }

                    if (!File.Exists(AccomodationLetterFile))
                    {
                        File.Copy(@AccomodationLetter, AccomodationLetterFile);
                    }

                    if (File.Exists(AccomodationLetterFile))
                    {
                        bool bGuaranteeCreated = SaveAccomodationDoc();
                        if (bGuaranteeCreated)
                        {
                            commonFuncs.DisplayMessage(CommonTypes.MessagType.Success, "Accomodation Voucher created successfully.");
                            File.SetAttributes(@AccomodationLetter, FileAttributes.Normal);
                            File.Delete(@AccomodationLetter);
                            AccomodationLetter = "";
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Accomodation-Booking NOT successfully created, please contact system administrator.");
                            commonFuncs.ErrorLogger("Accomodation-Booking NOT successfully created, please contact system administrator: " + @AccomodationLetter);
                            try
                            {
                                File.SetAttributes(@AccomodationLetter, FileAttributes.Normal);
                                File.Delete(@AccomodationLetter);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error generating Accomodation-Booking, Please review the Accomodation-Booking Form and try again.");
                        commonFuncs.ErrorLogger("Accomodation-Booking NOT successfully created, please contact system administrator: " + @AccomodationLetter);
                        try
                        {
                            File.SetAttributes(@AccomodationLetter, FileAttributes.Normal);
                            File.Delete(@AccomodationLetter);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            finally
            {
                dtLimitation.Dispose();
            }            
        }

        private bool SaveAccomodationDoc()
        {
            return commonFuncs.SaveAccomodationDoc(
                    cboAccomodation.SelectedValue.ToString() ,
                    txtGuestName.Text,
                    txtGuestRefNo.Text,
                    txtGuestNoOfRooms.Text,
                    dtCheckInDate.Text ,
                    txtGuestFlightArrivalTime.Text,
                    dtCheckOutDate.Text,
                    txtGuestAimsSettle.Text,
                    "",
                    "",
                    txtDiabeticMeals.Text,
                    "",
                    cboMeals.Text,
                    cboLaundry.Text,
                    "",
                    "",
                    "", 
                    PatientID,
                    UserID,
                    AccomodationLetterFile,
                    txtGuestMobileTelNo.Text,
                    txtGuestEmailAddress.Text,
                    dtGuestDOB.Text,
                    numNoOfGuests.Value.ToString(),
                    txtGuaranteedRatePerNight.Text,
                    cboRoomType.SelectedValue.ToString(),
                    chkMealBreakFast.Checked.ToString(),
                    chkMealLunch.Checked.ToString(),
                    chkMealDinner.Checked.ToString(),
                    chkMealFullboard.Checked.ToString(),
                    cboSocialTransportCover.Text ,
                    txtAdditionalNotes.Text,
                    cboCurrencies.SelectedValue.ToString());
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult dgResult = MessageBox.Show("Continue clearing all captured details...?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgResult== DialogResult.Yes)
            {
                cboAccomodation.SelectedIndex = -1;
                txtGuestName.Text = "";
                txtGuestRefNo.Text = "";
                txtGuestNoOfRooms.Text = "";
                txtGuestArrivalDate1.Text = "";
                txtGuestFlightArrivalTime1.Text = "";
                txtGuestDepartDate1.Text = "";
                txtGuestAimsSettle.Text = "";
                cboCountryOfOrigin.SelectedIndex = -1;
                cboReligion.SelectedIndex = -1;
                txtDiabeticMeals.Text = "";
                //cboBedAndBreakFast.SelectedIndex = -1;
                cboMeals.SelectedIndex = -1;
                cboLaundry.SelectedIndex = -1;
                //cboTelephone.SelectedIndex = -1;
                //cboMiniBar.SelectedIndex = -1;
                //txtSpeciallRequest.Text = "";
                AccomodationLetter = "";
                chkMealBreakFast.Checked = false;
                chkMealDinner.Checked = false;
                chkMealFullboard.Checked = false;
                chkMealLunch.Checked = false;
                cboRoomType.SelectedIndex = -1;
                cboSocialTransportCover.SelectedIndex = -1;
                txtGuestEmailAddress.Text = "";
                txtGuestMobileTelNo.Text = "";
                txtGuaranteedRatePerNight.Text = "";
                txtAdditionalNotes.Text = "";
                txtGuaranteedRatePerNight.Text = "";
                numNoOfGuests.Value = 0;
                dtGuestDOB.Text = "";
                txtGuestEmailAddress.Text = "";
                txtGuestMobileTelNo.Text = "";
            }
        }

        private void txtGuestFlightArrivalTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboSocialTransportCover_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createAccomodationVoucher(ref string AccomodationVoucher, string Accomodation,
                string txtGuestMobileTelNo, string txtGuestEmailAddress, string txtGuestName, string dtGuestDOB, string numNoOfGuests,
            string PatientFileNo, string txtGuaranteedRatePerNight, string dtCheckInDate, string dtCheckOutDate, string cboRoomType,
            string meals, string cboLaundry, string cboSocialTransportCover, string txtAdditionalNotes, string currency)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            
            // Create an empty page
            PdfPage page = document.AddPage();
            XGraphics gfx;
            XFont fontHeader;
            try
            {
                // Get an XGraphics object for drawing
                gfx = XGraphics.FromPdfPage(page);

                // Create a font
                fontHeader = new XFont("Verdana", 10, XFontStyle.Bold);
                XFont fontText = new XFont("Verdana", 8, XFontStyle.Regular);
                XFont fontCurrency = new XFont("Verdana", 8, XFontStyle.Bold);
                XFont PatientSummaryfontText = new XFont("Verdana", 8, XFontStyle.Bold);
                XFont PatientSummaryAdminQueries = new XFont("Verdana", 7, XFontStyle.Italic);
                XFont GuaranteeTermsAndConditions = new XFont("Verdana", 7, XFontStyle.Regular);
                XFont fontTextBold = new XFont("Verdana", 8, XFontStyle.Bold);

                int w = 30;
                int h = 60;

                string fileHeader = string.Empty;

                XImage image = XImage.FromFile(@"C:\AIMS Recorder\aims_header.png");

                double dx = 555, dy = 35;

                double width = image.Width * 40 / image.HorizontalResolution;

                double height = image.Height * 30 / image.HorizontalResolution;

                gfx.DrawImage(image, (dx - width) - 90 / 2, (dy - height) + 100 / 2, width, height);
                
                fileHeader = TemplateName.ToUpper();
                
                XPen pen10 = new XPen(XColors.Black, 0.5);
                //gfx.DrawLine(pen10, 210, h, 170, 20);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.LightBlue), 1), 20, 85, page.Width, 85);

                // Draw the text
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 2, page.Width, 200), XStringFormat.Center);

                h = 120;

                XPen pen13 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen13, w + 130, h, 350, 40);

                int h2 = h;
                gfx.DrawString("NB: Please notes all invoices must be sent to admin@aims.org.za. Should", PatientSummaryfontText, XBrushes.Red, new XRect((w + 130) + 5, h2 + 2, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString("you fail to send your invoices to the above mentioned email the system", PatientSummaryfontText, XBrushes.Red, new XRect((w + 130) + 5, h2 + 14, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString("will reject your invoices resulting in delayed payment. ", PatientSummaryfontText, XBrushes.Red, new XRect((w + 130) + 5, h2 + 26, page.Width, page.Height), XStringFormat.TopLeft);

                h =+ 20;
                //Accommodation Name
                XPen pen1 = new XPen(XColors.Black, 1);

                int TblY = 180;

                gfx.DrawRectangle(pen1,new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY-2, 230, 15);
                gfx.DrawString("Accommodation Name:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                XPen pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                
                gfx.DrawString(Accomodation, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Contact number:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(  pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtGuestMobileTelNo, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("E-Mail Address:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtGuestEmailAddress, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Guest Name:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtGuestName, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Date Of Birth:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(dtGuestDOB, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Number Of Guests:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(numNoOfGuests, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("AIMS Case Number:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(PatientFileNo, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Guaranteed room rate per night:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(currency, fontCurrency, XBrushes.Red, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Guaranteed check in date:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(dtCheckInDate, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Guarantee check out date:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(dtCheckOutDate, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 40;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("ROOM TYPE:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(cboRoomType, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("MEALS:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(meals, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("LAUNDRY:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(cboLaundry, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("SOCIAL TRANSPORT COVER:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(cboSocialTransportCover, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 50;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 535, 15);
                gfx.DrawString("ADDITIONAL NOTES:", fontTextBold, XBrushes.Black, new XRect(w + 210, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                
                pen13 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen13, w + 5, TblY + 15, 535, 60);
                TblY = TblY + 15;
                gfx.DrawString(txtAdditionalNotes, fontText, XBrushes.Black, new XRect(w + 10, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 5;

                pen10 = new XPen(XColors.Black, 1);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 1), 0, 85, page.Width, 85);
                string disclosure = "(Please refer to the second page of this document for additional information.)";
                XFont  disclaimer = new XFont("Verdana", 7, XFontStyle.BoldItalic);
                gfx.DrawString(disclosure, disclaimer, XBrushes.Black, new XRect(1, TblY, page.Width, 200), XStringFormat.Center);

                /*
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(cboRoomType, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                */

                h += 700;

                gfx.DrawString("Alliance International Medical Services Pty Ltd.", PatientSummaryfontText, XBrushes.Black, new XRect((page.Width / 2) - 100, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("AIMS House, 3 West Street, Bryanston. Private Bag X5 Benmore 2010.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 120, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Tel: +27 11 783 0135 Fax: +27 11 463 3583 E-mail: operations@aims.org.za", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 130, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Reg. No: 2001/025937/07", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 50, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Directors: B.A. Breton (Managing)", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 60, h, page.Width, page.Height), XStringFormat.TopLeft);


                ///////////////////////////////////////// START - OF - PAGE 2 ////////////////////////////////////////////////////

                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);

                w = 30;
                h = 60;

                fileHeader = string.Empty;

                image = XImage.FromFile(@"C:\AIMS Recorder\aims_header.png");

                dx = 555;
                dy = 35;

                width = image.Width * 40 / image.HorizontalResolution;

                height = image.Height * 30 / image.HorizontalResolution;

                gfx.DrawImage(image, (dx - width) - 90 / 2, (dy - height) + 100 / 2, width, height);

                XFont secondPage = new XFont("Verdana", 7, XFontStyle.Regular);
                XFont secondPageUnderline = new XFont("Verdana", 7, XFontStyle.Bold);

                h += 50;
                gfx.DrawString("Alliance International Medical Services (AIMS) do hereby guarantee the above amount of all reasonable, customary costs.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 20;
                gfx.DrawString("Cost related to guest charges, and items of personal nature such as telephone calls, newspapers, television, wireless ", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 10;
                gfx.DrawString("charges, minibar, admission fees are not covered and the member to settle this directly with the hospital on discharge.", secondPageUnderline, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 30;
                fileHeader = "Invoicing Terms:";

                // Draw the text
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 70, page.Width, 200), XStringFormat.Center);

                h += 20;
                gfx.DrawString("•	All invoices will be subject to auditing.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 12;
                gfx.DrawString("•	Invoices must be submitted to admin@aims.org.za in their original format within 5 Days from receipt of this Guarantee.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	Invoices posted to AIMS must be submitted to; AIMS House, 3 West Street, Bryanston or Private Bag X5 Benmore 2010.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	Invoices received later than 5 working days following the receipt of this Guarantee are considered as late submissions and", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   payment will be made once received from the medical insurer and are subject to their approval.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	Alliance International Medical Services (AIMS) File numbers must be quoted on all invoices along with banking details and", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   any payments made by the patient or representative clearly reflected onto the invoice.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 50;
                fileHeader = "Payment Terms:";

                // Draw the text
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 200, page.Width, 200), XStringFormat.Center);

                h += 20;
                gfx.DrawString("•	Payment will be issued 30 days (thirty) from the date of receipt of this Guarantee falling into the relevant cheque run pertinent ", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   to the guarantee receipt date.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	Payment cannot be made on faxed invoices. (Submission of original invoices after five day period will not be", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   processed for payment within the period of 30 days from the date of receiving this guarantee.)", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	Alliance International Medical Services (AIMS) will not be held liable for invoices received 60 days post date of receipt of this Guarantee.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 40;
                gfx.DrawString("Your Sincerely,", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;

                /// Start Operations Co-Ordinator /////
                image = XImage.FromFile(@SignaturePath);
                gfx.DrawImage(image, 50, h, (image.Width / 2), (image.Height / 2));
                image = XImage.FromFile(@opsManagerSignature);
                gfx.DrawImage(image, 300, h + 10, (image.Width / 2), (image.Height / 2));

                h += 40;
                gfx.DrawString(UserFullName, secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(opsManagerName, secondPage, XBrushes.Black, new XRect((page.Width / 2) - 5, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Operations Specialist", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString("Operations Manager", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 5, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(DateTime.Now.ToString("dd MMMM yyyy"), secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 220;
                gfx.DrawString("Alliance International Medical Services Pty Ltd.", PatientSummaryfontText, XBrushes.Black, new XRect((page.Width / 2) - 100, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("AIMS House, 3 West Street, Bryanston. Private Bag X5 Benmore 2010.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 120, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Tel: +27 11 783 0135 Fax: +27 11 463 3583 E-mail: operations@aims.org.za", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 130, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Reg. No: 2001/025937/07", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 50, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Directors: B.A. Breton (Managing)", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 60, h, page.Width, page.Height), XStringFormat.TopLeft);
                //////////////End Operations Co-Ordinator//////////

                string filename = @"c:\AIMS Recorder\" + System.Guid.NewGuid() + ".pdf";

                document.Save(filename);
                AccomodationVoucher = filename;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 tmp3;
            if (Int32.TryParse(txtGuaranteedRatePerNight.Text, out tmp3))
            {
                decimal txtGuarantAmount = System.Convert.ToDecimal(txtGuaranteedRatePerNight.Text.Replace(" ", ""));
                lblCurrency.Text = txtGuarantAmount.ToString("C").Replace("R", "") + " " + cboCurrencies.Text;
            }
            else
            {
                lblCurrency.Text = "";
            }
        }

        private void txtGuaranteedRatePerNight_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;
            string NewInvoiceAmt = "";
            errProvider.Clear();
            try
            {
                if (txtGuaranteedRatePerNight.Text.Trim().Length > 0)
                {
                    if (!double.TryParse(txtGuaranteedRatePerNight.Text, out tmp))
                    {
                        if (txtGuaranteedRatePerNight.Text.Substring(txtGuaranteedRatePerNight.Text.Trim().Length - 1, 1) != ".")
                        {
                            if (!double.TryParse(txtGuaranteedRatePerNight.Text.Trim(), out tmp1))
                            {
                            }
                        }
                    }
                    if (Int32.TryParse(txtGuaranteedRatePerNight.Text, out tmp3))
                    {
                        decimal txtGuarantAmount = System.Convert.ToDecimal(txtGuaranteedRatePerNight.Text.Replace(" ", ""));
                        lblCurrency.Text = txtGuarantAmount.ToString("C").Replace("R", "") + " " + cboCurrencies.Text;
                    }
                    else
                    {
                        lblCurrency.Text = "";
                        txtGuaranteedRatePerNight.Text = "";
                    }
                }
                else
                {
                    lblCurrency.Text = "";
                    txtGuaranteedRatePerNight.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}