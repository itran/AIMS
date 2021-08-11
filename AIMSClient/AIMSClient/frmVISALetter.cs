using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIMS.BLL;
using AIMS.Common;
using System.Reflection;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Forms;
using System.IO;

namespace AIMSClient
{
    public partial class frmVISALetter : Form
    {
        AIMS.Common.CommonFunctions commonFuncs;
        DataTable tblSuppliers = new DataTable();

        bool StillLoading = true;
        string VISALetterFileName = "";
        string GuaranteeFileName = "";
        string HospitalAdd1 = "";
        string HospitalAdd2 = "";
        string HospitalAdd3 = "";
        string HospitalAdd4 = "";
        string HospitalAdd5 = "";

        string PatientResidingAddress = "";
        private string _restrictions = string.Empty;

        public string Restrictions
        {
            get { return _restrictions; }
            set
            {
                _restrictions = value;
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
        string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
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

        string _PatientFileNo = "";
        public string PatientFileNo
        {
            get { return _PatientFileNo; }
            set
            {
                _PatientFileNo = value;
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

        public frmVISALetter()
        {
            InitializeComponent();
        }

        private void frmVISALetter_Load(object sender, EventArgs e)
        {
            commonFuncs = new CommonFunctions();
            if (PassportNo.Trim().Equals(""))
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Patient Passport-No not captured");
                this.Close();
            }

            LoadSuppliers();
            LoadCountries();
            LoadAddressTypes();
            LoadRelations();
            LoadEmbassies();

            txtPatientName.Text = PatientName;
            txtPatientPassportNo.Text = PassportNo;
            cboTreatingHospital.SelectedValue = System.Convert.ToInt32(Hospital);
            if (CountryOfTreatment > 0 )
            {
                cboEmbassyCountry.SelectedValue = System.Convert.ToInt32(CountryOfTreatment);    
            }
            LoadPatientServiceProviders();
        }

        private void createAIMSVisaLetter(ref string VISALetterFile, string EmbassyName, string EmbassyAdd1, string EmbassyAdd2, string EmbassyAdd3, string EmbassyAdd4, string EmbassyAdd5, string Country,
                                            string PatientName, string PatientPassportNo, string PatientPassportIssueDt, string PatientPassportExpiryDt,
                                           string EscortName, string EscortRelationToPatient, string EscortPassportNo, string EscortPassportIssueDt, string EscortPassportExpiryDt,
                                            string EscortHisHer, string CountryOfTreatment, string TreatingDoctor, string TreatingDoctorProfession,string TreatingHospital,
                                            string AimsCoOrdinator, string TreatmentDate, string PatientResidingAddress, string PatientFileNo)
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
                fontHeader = new XFont("Verdana", 10, XFontStyle.Regular);
                XFont fontText = new XFont("Verdana", 8, XFontStyle.Regular);
                XFont PatientSummaryfontText = new XFont("Verdana", 8, XFontStyle.Bold);
                XFont PatientSummaryAdminQueries = new XFont("Verdana", 7, XFontStyle.Italic);
                XFont GuaranteeTermsAndConditions = new XFont("Verdana", 7, XFontStyle.Regular);
                XFont fontTextBold = new XFont("Verdana", 8, XFontStyle.Bold);

                int w = 30;
                int h = 30;

                string fileHeader = string.Empty;

                XImage image = XImage.FromFile(@"c:\AIMSLOGO.png");

                double dx = 555, dy = 35;

                double width = image.Width * 40 / image.HorizontalResolution;

                double height = image.Height * 30 / image.HorizontalResolution;

                gfx.DrawImage(image, (dx - width) - 250 / 2, (dy - height) + 50 / 2, width, height);
                fileHeader = "VISA Letter";

                XPen pen10 = new XPen(XColors.Black, 1);
                //gfx.DrawLine(pen10, 210, h, 170, 20);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 1), 0, 85, page.Width, 85);

                // Draw the text
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 2, page.Width, 150), XStringFormat.Center);

                h += 70;
                gfx.DrawString(EmbassyName, PatientSummaryfontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(EmbassyAdd1, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(EmbassyAdd2, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(EmbassyAdd3, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(EmbassyAdd4, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(EmbassyAdd5, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("Dear Sirs,", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 20;
                gfx.DrawString("RE", PatientSummaryfontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(PatientName, fontText, XBrushes.Black, new XRect(240, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Passport No", PatientSummaryfontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(PatientPassportNo, fontText, XBrushes.Black, new XRect(240, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Passport Date of Issue", PatientSummaryfontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(PatientPassportIssueDt, fontText, XBrushes.Black, new XRect(240, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Passport Expiry Date", PatientSummaryfontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(":", fontText, XBrushes.Black, new XRect(200, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(PatientPassportExpiryDt, fontText, XBrushes.Black, new XRect(240, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 30;

                gfx.DrawString("Alliance International Medical Services (PTY) Ltd is the management company that has been appointed to arrange and co-ordinate ", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("medical treatment for the above named patient", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("The patient will be admitted to "+ TreatingHospital +" on arrival in "+CountryOfTreatment+" under the care of a "+TreatingDoctorProfession+", "+ TreatingDoctor+"", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("The patient has a confirmed appointment with " + TreatingDoctor + " on " + TreatmentDate + " at " + TreatingHospital + ".", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("The patient will be accompanied by "+ EscortHisHer +" "+ EscortRelationToPatient+" "+ EscortName +" (Passport No: "+EscortPassportNo+"; Date of Issue: "+EscortPassportIssueDt+";", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Expiry Date:"+EscortPassportExpiryDt+")", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;
                gfx.DrawString("The patient and " + EscortName + " will be residing at " + PatientResidingAddress + "", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;
                gfx.DrawString("The financial costs of "+PatientName+" treatment are guaranteed by Alliance International Medical Services (PTY) Ltd.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;
                gfx.DrawString("We respectfully request your assistance in the issue of a 10 Days medical visa for Mrs. Suzanne Terry visit to South Africa.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;
                gfx.DrawString("Your assistance in this regard is greatly appreciated.", fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;


                gfx.DrawString("Yours faithfully", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString(""+AimsCoOrdinator+"", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 10;
                gfx.DrawString("Operations Co-Ordinator", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);


                h += 280;

                gfx.DrawString("Alliance International Medical Services Pty Ltd.", PatientSummaryfontText, XBrushes.Black, new XRect((page.Width / 2) - 100, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("66 Wierda Road East, Wierda Valley, Blue Strata House Private Bag X5 Benmore 2010.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 150, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("tel: 0027 11 783 0135 fax: 0027 11 783 0950 mobile: 0027 82 323 7553 e-mail: operations@aims.org.za", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 200, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("reg. no: 2001/025937/07 directors: D. Kuper (Estate Late) B.A. Breton (Managing Director)", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 160, h, page.Width, page.Height), XStringFormat.TopLeft);

                string filename = @"c:\AIMS Recorder\" + System.Guid.NewGuid() + ".pdf";

                document.Save(filename);
                VISALetterFile = filename;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        private void LoadSuppliers()
        {
            tblSuppliers = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                tblSuppliers = lookupBLL.GetHospitalsLookUpValues("SUPPLIER_ID", "SUPPLIER_NAME", "AIMS_SUPPLIER", 0);
                cboTreatingHospital.DataSource = tblSuppliers;
                cboTreatingHospital.DisplayMember = "SUPPLIER_NAME";
                cboTreatingHospital.ValueMember = "SUPPLIER_ID";
                cboTreatingHospital.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadPatientServiceProviders()
        {
            DataTable dsPatientServiceProviders = new DataTable(); ;

            AIMS.BLL.Supplier supplierBLL = new Supplier();

            dsPatientServiceProviders = supplierBLL.GetPatientServiceProviders(PatientID);

            try
            {
                //cboTreatingDoctor.Items.Insert(0, new ListItem("", "0"));
                cboTreatingDoctor.DataSource = dsPatientServiceProviders;
                cboTreatingDoctor.DisplayMember = "SERVICE_PROVIDER_NAME";
                cboTreatingDoctor.ValueMember = "SERVICE_PROVIDER_ID";
                cboTreatingDoctor.SelectedValue = -1;
                
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading patient service providers Failed : Error - " + ex.Message);
                
            }
            finally
            {
                supplierBLL = null;
            }
        }

        private bool ValidateControl()
        {
            bool ReturnValue = true;
            try
            {
                errProvider.Clear();

                if (txtPatientPassportNo.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtPatientPassportNo.Focus();
                    errProvider.SetError(txtPatientPassportNo, "Patient Passport-No not captured");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtVisaExipryDate.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtVisaExipryDate.Focus();
                    errProvider.SetError(txtVisaExipryDate, "Patient Visa Expiry Date not captured");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboEmbassies.SelectedItem == null)
                {
                    errProvider.SetError(cboEmbassies, "Please select Embassy.");
                    cboEmbassies.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboEmbassies.SelectedItem != null && (cboEmbassies.Text == ""))
                {
                    errProvider.SetError(cboEmbassies, "Please select Embassy.");
                    cboEmbassies.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTreatingHospital.SelectedItem == null)
                {
                    errProvider.SetError(cboTreatingHospital, "Please select Treatment Hospital");
                    cboTreatingHospital.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTreatingHospital.SelectedItem != null && (cboTreatingHospital.Text == ""))
                {
                    errProvider.SetError(cboTreatingHospital, "Please select Treatment Hospital");
                    cboTreatingHospital.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtPatientPassportExpiryDt.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtPatientPassportExpiryDt.Focus();
                    errProvider.SetError(txtPatientPassportExpiryDt, "Expiry Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }
                System.TimeSpan diffResult = System.Convert.ToDateTime(txtPatientPassportExpiryDt.Text) - DateTime.Today.Date;
                if (diffResult.Days <= 0)
                {
                    ReturnValue = false;
                    txtPatientPassportExpiryDt.Focus();
                    errProvider.SetError(txtPatientPassportExpiryDt, "Expiry Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtEscortPassportExpiryDt.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtEscortPassportExpiryDt.Focus();
                    errProvider.SetError(txtEscortPassportExpiryDt, "Expiry Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }
                diffResult = System.Convert.ToDateTime(txtEscortPassportExpiryDt.Text) - DateTime.Today.Date;
                if (diffResult.Days <= 0)
                {
                    ReturnValue = false;
                    txtEscortPassportExpiryDt.Focus();
                    errProvider.SetError(txtEscortPassportExpiryDt, "Expiry Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtAppointmentDate.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtEscortPassportExpiryDt.Focus();
                    errProvider.SetError(txtAppointmentDate, "Appointment Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }
                diffResult = System.Convert.ToDateTime(txtAppointmentDate.Text) - DateTime.Today.Date;
                if (diffResult.Days <= 0)
                {
                    ReturnValue = false;
                    txtAppointmentDate.Focus();
                    errProvider.SetError(txtAppointmentDate, "Appointment Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtEscortPassportIssueDt.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtEscortPassportExpiryDt.Focus();
                    errProvider.SetError(txtEscortPassportIssueDt, "Issue Date must be a past date");
                    ReturnValue = false;
                    return ReturnValue;
                }
                diffResult = System.Convert.ToDateTime(txtEscortPassportIssueDt.Text) - DateTime.Today.Date;
                if (diffResult.Days >= 0)
                {
                    ReturnValue = false;
                    txtEscortPassportIssueDt.Focus();
                    errProvider.SetError(txtEscortPassportIssueDt, "Issue Date must be a past date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtPatientPassportIssueDt.Text.Trim().Equals(""))
                {
                    ReturnValue = false;
                    txtEscortPassportExpiryDt.Focus();
                    errProvider.SetError(txtPatientPassportIssueDt, "Issue Date must be a past date");
                    ReturnValue = false;
                    return ReturnValue;
                }
                diffResult = System.Convert.ToDateTime(txtPatientPassportIssueDt.Text) - DateTime.Today.Date;
                if (diffResult.Days >= 0)
                {
                    ReturnValue = false;
                    txtPatientPassportIssueDt.Focus();
                    errProvider.SetError(txtPatientPassportIssueDt, "Issue Date must be a past date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTreatingDoctor.SelectedItem == null)
                {
                    errProvider.SetError(cboTreatingDoctor, "Please select a Treatment Doctor");
                    cboTreatingDoctor.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboTreatingDoctor.SelectedItem != null && (cboTreatingDoctor.Text == ""))
                {
                    errProvider.SetError(cboTreatingDoctor, "Please select a Treatment Doctor");
                    cboTreatingDoctor.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboHisHer.SelectedItem == null)
                {
                    errProvider.SetError(cboHisHer, "Missing");
                    cboHisHer.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                if (cboHisHer.SelectedItem != null && (cboHisHer.Text == ""))
                {
                    errProvider.SetError(cboHisHer, "Missing");
                    cboHisHer.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboEscortRelation.SelectedItem == null)
                {
                    errProvider.SetError(cboEscortRelation, "Missing Relation");
                    cboEscortRelation.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboEscortRelation.SelectedItem != null && (cboEscortRelation.Text == ""))
                {
                    errProvider.SetError(cboEscortRelation, "Missing Relation");
                    cboEscortRelation.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtTreatingDrProfession.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtTreatingDrProfession, "Please select a Treatment Doctor Profession");
                    txtTreatingDrProfession.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                if (txtPatientResidingAdd1.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtPatientResidingAdd1, "Please capture Patient Residing Address");
                    txtPatientResidingAdd1.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                if (txtPatientResidingAdd2.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtPatientResidingAdd2, "Please capture Patient Residing Address");
                    txtPatientResidingAdd2.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                if (txtPatientResidingAdd3.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtPatientResidingAdd3, "Please capture Patient Residing Address");
                    txtPatientResidingAdd3.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
            }
            finally
            {

            }
            return ReturnValue;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void lnklblPatientPassportIssueDt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPatientPassportIssueDt_DoubleClick(null, null);
        }

        private void btnGuaranteeCreate_Click(object sender, EventArgs e)
        {
            try
            {
                bool bVisaLetterCreated = false;
                bool bDataCaptureValid = ValidateControl();
                if (bDataCaptureValid)
                {
                    if (VISALetterFileName.Equals(""))
                    {
                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Warning, "Please preview the VISA Letter before saving");
                        return;
                    }
                    else
                    {
                        string VisaLetterID = "";
                        bVisaLetterCreated = commonFuncs.SaveVisaLetter(ref VisaLetterID, UserID, VISALetterFileName,
                                txtEmbassyName.Text, txtEmbassyAddress1.Text, txtEmbassyAddress2.Text, txtEmbassyAddress3.Text, txtEmbassyAddress4.Text,
                                txtEmbassyAddress5.Text, cboEmbassyCountry.SelectedValue.ToString(), txtPatientName.Text, txtPatientPassportNo.Text, txtPatientPassportIssueDt.Text,
                                txtPatientPassportExpiryDt.Text, txtEscortName.Text, cboEscortRelation.SelectedValue.ToString(), txtEscortPassportNo.Text, txtEscortPassportIssueDt.Text,
                                txtPatientPassportExpiryDt.Text, cboHisHer.SelectedIndex.ToString(), cboEmbassyCountry.SelectedValue.ToString(), cboTreatingDoctor.SelectedValue.ToString(), txtTreatingDrProfession.Text,
                                cboTreatingHospital.SelectedValue.ToString(), UserName, txtAppointmentDate.Text, PatientResidingAddress, "1", PatientFileNo, cboEmbassies.SelectedValue.ToString(),UserID);
                        if (bVisaLetterCreated)
                        {
                            DataTable dtLimitation = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_POD_VISA_LETTERS");
                            if (!dtLimitation.Rows.Count.Equals(0))
                            {
                                string VisaLetterPOD = dtLimitation.Rows[0]["LIMITATION_VALUE"].ToString();
                                
                                string VisaLetterMonth = System.DateTime.Now.ToString("MMMM");
                                string VisaLetterYear = System.DateTime.Now.Year.ToString();
                                string VisaLetterFile = @VisaLetterPOD + VisaLetterYear + @"\" + VisaLetterMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy") + @"\" + Path.GetFileName(VISALetterFileName);

                                if (!Directory.Exists(@VisaLetterPOD + VisaLetterYear)) { Directory.CreateDirectory(@VisaLetterPOD + VisaLetterYear);}
                                if (!Directory.Exists(@VisaLetterPOD + VisaLetterYear + @"\" + VisaLetterMonth)) { Directory.CreateDirectory(@VisaLetterPOD + VisaLetterYear + @"\" + VisaLetterMonth); }
                                if (!Directory.Exists(@VisaLetterPOD + VisaLetterYear + @"\" + VisaLetterMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy"))) { Directory.CreateDirectory(@VisaLetterPOD + VisaLetterYear + @"\" + VisaLetterMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy")); }

                                if (!File.Exists(VisaLetterFile))
                                {
                                    File.Copy(@VISALetterFileName, VisaLetterFile);
                                }
                                
                                if (File.Exists(VisaLetterFile))
                                {
                                    bVisaLetterCreated = commonFuncs.SaveVisaLetterPOD(VisaLetterID, VISALetterFileName, VisaLetterFile);
                                    if (bVisaLetterCreated)
                                    {
                                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Success, "Patient VISA Letter created successfully.");
                                        File.SetAttributes(@VISALetterFileName, FileAttributes.Normal);
                                        File.Delete(@VISALetterFileName);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Patient VISA Letter NOT successfully.");
                                        File.SetAttributes(@VisaLetterFile, FileAttributes.Normal);
                                        File.Delete(@VisaLetterFile);
                                    }
                                }
                                else
                                {
                                    commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error generating VISA Letter, Please review the VISA Letter Form and try again.");
                                    File.SetAttributes(@VISALetterFileName, FileAttributes.Normal);
                                    File.Delete(@VISALetterFileName);
                                }  
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error creating VISA Letter, Please contact System Administrator");
                commonFuncs.ErrorLogger("CREATING VISA LETTER ERROR: " + ex.ToString());
            }
        }

        private void txtPatientPassportIssueDt_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtPatientPassportIssueDt.Text = frmCal.StartDate.ToShortDateString();
            }
            txtPatientPassportIssueDt.Focus();
        }

        private void txtPatientPassportExpiryDt_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtPatientPassportExpiryDt.Text = frmCal.StartDate.ToShortDateString();
            }
            txtPatientPassportExpiryDt.Focus();
        }

        private void txtEscortPassportIssueDt_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtEscortPassportIssueDt.Text = frmCal.StartDate.ToShortDateString();
            }

            txtEscortPassportIssueDt.Focus();
        }

        private void txtEscortPassportExpiryDt_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtEscortPassportExpiryDt.Text = frmCal.StartDate.ToShortDateString();
            }

            txtEscortPassportExpiryDt.Focus();
        }

        private void lnklblPatientPassportExpiryDt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPatientPassportExpiryDt_DoubleClick(null, null);
        }

        private void lnklblEscortPassportIssueDt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtEscortPassportIssueDt_DoubleClick(null, null);
        }

        private void lnklblEscortPassportExpiryDt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtEscortPassportExpiryDt_DoubleClick(null, null);
        }

        private void LoadAddressTypes()
        {
            DataTable tblTitles = new DataTable();
            try
            {
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblTitles = lookupBLL.GetLookUpValues("ADDR_TYPE_ID", "ADDRESS_TYPE", "AIMS_ADDRESS_TYPE", 0, "ADDRESS_TYPE");
                cboAddressType.DataSource = tblTitles;
                cboAddressType.DisplayMember = "ADDRESS_TYPE";
                cboAddressType.ValueMember = "ADDR_TYPE_ID";
                cboAddressType.SelectedValue = -1;
            }
            finally
            {
                //tblTitles.Dispose();
            }
        }

        private void LoadRelations()
        {
            DataTable tblTitles = new DataTable();
            try
            {
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblTitles = lookupBLL.GetLookUpValues("RELATION_ID", "RELATION_DESC", "AIMS_RELATIONS", 0, "RELATION_DESC");
                cboEscortRelation.DataSource = tblTitles;
                cboEscortRelation.DisplayMember = "RELATION_DESC";
                cboEscortRelation.ValueMember = "RELATION_ID";
                cboEscortRelation.SelectedValue = -1;
            }
            finally
            {
                //tblTitles.Dispose();
            }
        }

        private void LoadEmbassies()
        {
            DataTable tblEmbassies = new DataTable();
            try
            {
                AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
                tblEmbassies = lookupBLL.GetLookUpValues("EMBASSY_ID", "EMBASSY_NAME", "AIMS_EMBASSIES", 0, "EMBASSY_NAME");
                StillLoading = true;
                cboEmbassies.DataSource = tblEmbassies;
                cboEmbassies.DisplayMember = "EMBASSY_NAME";
                cboEmbassies.ValueMember = "EMBASSY_ID";
                cboEmbassies.SelectedValue = -1;
                StillLoading = false;

            }
            finally
            {
                //tblTitles.Dispose();
            }
        }

        private void LoadCountries()
        {
            DataTable tblCountries = new DataTable();
            DataTable tblCountries2 = new DataTable();

            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();
            AIMS.BLL.LookUpTableCollections lookupBLL2 = new LookUpTableCollections();

            try
            {
                tblCountries = lookupBLL.GetLookUpValues("COUNTRY_ID", "COUNTRY_NAME", "AIMS_COUNTRY", 0, "COUNTRY_NAME");
                cboEmbassyCountry.DataSource = tblCountries;
                cboEmbassyCountry.DisplayMember = "COUNTRY_NAME";
                cboEmbassyCountry.ValueMember = "COUNTRY_ID";
                cboEmbassyCountry.SelectedValue = -1;

                tblCountries2 = lookupBLL2.GetLookUpValues("COUNTRY_ID", "COUNTRY_NAME", "AIMS_COUNTRY", 0, "COUNTRY_NAME");
                cboCountryOfTreatment.DataSource = tblCountries2;
                cboCountryOfTreatment.DisplayMember = "COUNTRY_NAME";
                cboCountryOfTreatment.ValueMember = "COUNTRY_ID";
                cboCountryOfTreatment.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void txtEscortPassportExpiryDt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEscortPassportIssueDt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuaranteePreview_Click(object sender, EventArgs e)
        {   
            try
            {
                bool bDataCapturedValid = ValidateControl();
                
                if (bDataCapturedValid)
                {
                    
                    if (!txtPatientResidingAdd1.Text.Trim().Equals("")) { PatientResidingAddress += txtPatientResidingAdd1.Text + ", "; }
                    if (!txtPatientResidingAdd2.Text.Trim().Equals("")) { PatientResidingAddress += txtPatientResidingAdd2.Text + ", "; }
                    if (!txtPatientResidingAdd3.Text.Trim().Equals("")) { PatientResidingAddress += txtPatientResidingAdd3.Text + ", "; }
                    if (!PatientResidingAddress.Equals(""))
                    {
                        PatientResidingAddress = PatientResidingAddress.Trim().Substring(0, PatientResidingAddress.Trim().Length - 1);
                    }
                    else
                    {
                        errProvider.SetError(txtPatientResidingAdd1, "Escort/Patient Residing Address");
                        errProvider.SetError(txtPatientResidingAdd2, "Escort/Patient Residing Address");
                        errProvider.SetError(txtPatientResidingAdd3, "Escort/Patient Residing Address");
                        txtPatientResidingAdd1.Focus();
                        return;
                    }
                }
                else
                {
                    return;
                }

                if (bDataCapturedValid)
                {
                    FormatHospital(ref HospitalAdd1, ref HospitalAdd2, ref HospitalAdd3, ref HospitalAdd4, ref HospitalAdd5);

                    createAIMSVisaLetter(ref VISALetterFileName, txtEmbassyName.Text, HospitalAdd1, HospitalAdd2, HospitalAdd3, HospitalAdd4,
                        HospitalAdd5, cboEmbassyCountry.Text, txtPatientName.Text, txtPatientPassportNo.Text, txtPatientPassportIssueDt.Text, txtPatientPassportExpiryDt.Text,
                        txtEscortName.Text, cboEscortRelation.Text, txtEscortPassportNo.Text, txtEscortPassportIssueDt.Text, txtPatientPassportExpiryDt.Text, cboHisHer.Text,
                        cboEmbassyCountry.Text, cboTreatingDoctor.Text, txtTreatingDrProfession.Text, cboTreatingHospital.Text, UserName, txtAppointmentDate.Text, PatientResidingAddress,PatientFileNo);
                    if (!VISALetterFileName.Equals("") && File.Exists(VISALetterFileName))
                    {
                        System.Diagnostics.Process.Start(VISALetterFileName);
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Visa Letter preview error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Visa Letter preview error: " + ex.ToString());
            }
        }

        private void txtAppointmentDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTreatingDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTreatingDoctor.SelectedItem != null)
            {
                if (cboTreatingDoctor.SelectedIndex > 0)
                {
                    if (cboTreatingDoctor.SelectedValue != null)
                    {
                        string ProviderID = cboTreatingDoctor.SelectedValue.ToString();
                        DataTable dtServiceProvider = commonFuncs.GetServiceProvider(ProviderID.ToString());
                        if (dtServiceProvider.Rows.Count > 0)
                        {
                            string ServiceProviderType = dtServiceProvider.Rows[0]["SUPPLIER_TYPE_DESC"].ToString();
                            txtTreatingDrProfession.Text = ServiceProviderType;
                        }
                    }
                }   
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtAppointmentDate_DoubleClick(null, null);
        }

        private void txtAppointmentDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtAppointmentDate.Text = frmCal.StartDate.ToShortDateString();
            }
            txtAppointmentDate.Focus();
        }

        private void txtPatientPassportIssueDt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEmbassyEdit_Click(object sender, EventArgs e)
        {
            if (cboEmbassies.SelectedItem == null || cboEmbassies.SelectedIndex == -1)
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Select Embassy to modify");
            }
            else
            {
                frmEmbassies frmEmbassy = new frmEmbassies();

                if (cboEmbassies.SelectedItem != null && cboEmbassies.SelectedIndex >= 0)
                {
                    frmEmbassy.EmbassyID = Convert.ToInt32(cboEmbassies.SelectedValue.ToString());
                }

                frmEmbassy.StartPosition = FormStartPosition.CenterParent;
                frmEmbassy.Text = "Add/Edit Embassy";

                if (frmEmbassy.ShowDialog() == DialogResult.OK)
                {
                    LoadEmbassies();
                }
            }
        }

        private void btnAddEmbassy_Click(object sender, EventArgs e)
        {
            frmEmbassies frmEmbassy = new frmEmbassies();

            frmEmbassy.StartPosition = FormStartPosition.CenterParent;
            frmEmbassy.Text = "Add/Edit Embassy";

            if (frmEmbassy.ShowDialog() == DialogResult.OK)
            {
                LoadEmbassies();
            }
        }

        private void cboEmbassies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmbassies.SelectedItem != null && cboEmbassies.SelectedIndex >=0 )
            {
                if (!StillLoading)
                {
                    string EmbassyID = cboEmbassies.SelectedValue.ToString();

                    DataTable dtEmbassyDetails = commonFuncs.GetEmbassyDetails(EmbassyID);

                    if (dtEmbassyDetails.Rows.Count > 0)
                    {
                        txtEmbassyAddress1.Text = dtEmbassyDetails.Rows[0]["Address1"].ToString();
                        HospitalAdd1 = txtEmbassyAddress1.Text;
                        txtEmbassyAddress2.Text = dtEmbassyDetails.Rows[0]["Address2"].ToString();
                        HospitalAdd2 = txtEmbassyAddress2.Text;
                        txtEmbassyAddress3.Text = dtEmbassyDetails.Rows[0]["Address3"].ToString();
                        HospitalAdd3 = txtEmbassyAddress3.Text;
                        txtEmbassyAddress4.Text = dtEmbassyDetails.Rows[0]["Address4"].ToString();
                        HospitalAdd4 = txtEmbassyAddress4.Text;
                        txtEmbassyAddress5.Text = dtEmbassyDetails.Rows[0]["Address5"].ToString();
                        HospitalAdd5 = txtEmbassyAddress5.Text;
                        txtEmbassyName.Text = dtEmbassyDetails.Rows[0]["EMBASSY_NAME"].ToString();

                        if (!dtEmbassyDetails.Rows[0]["COUNTRY_ID"].ToString().Equals(""))
                        {
                            cboEmbassyCountry.SelectedValue = Convert.ToInt32(dtEmbassyDetails.Rows[0]["COUNTRY_ID"].ToString());
                        }
                    }   
                }
            }
        }

        private void FormatHospital(ref string HospAddr1, ref string HospAddr2, ref string HospAddr3, ref string HospAddr4, ref string HospAddr5)
        {
            ArrayList list = new ArrayList();

            if (!HospAddr1.Equals("")) { list.Add(HospAddr1); }
            if (!HospAddr2.Equals("")) { list.Add(HospAddr2); }
            if (!HospAddr3.Equals("")) { list.Add(HospAddr3); }
            if (!HospAddr4.Equals("")) { list.Add(HospAddr4); }
            if (!HospAddr5.Equals("")) { list.Add(HospAddr5); }

            int xCount = 0;

            HospAddr1 = "";
            HospAddr2 = "";
            HospAddr3 = "";
            HospAddr4 = "";
            HospAddr5 = "";

            foreach (string lstVal in list)
            {
                switch (xCount)
                {
                    case 0:
                        HospAddr1 = lstVal;
                        break;
                    case 1:
                        HospAddr2 = lstVal;
                        break;
                    case 2:
                        HospAddr3 = lstVal;
                        break;
                    case 3:
                        HospAddr4 = lstVal;
                        break;
                    case 4:
                        HospAddr5 = lstVal;
                        break;
                }

                xCount++;
            }
        }

        private void txtVisaExipryDate_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtVisaExipryDate.Text = frmCal.StartDate.ToShortDateString();
            }
            txtVisaExipryDate.Focus();
        }

        private void lnklblVisaExpiryDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtVisaExipryDate_DoubleClick(null, null);
        }

        private void txtVisaExipryDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}