using System;
using System.Collections.Generic;
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
using ConvertHTMLToPDF;
using System.Diagnostics;
using System.Threading;

namespace AIMSClient
{
    public partial class frmAirAmbulanceCE : Form
    {

        AIMS.Common.CommonFunctions commonFuncs;
        bool filePreviewed = false;
        DataTable tblSuppliers = new DataTable();
        string _UserFullName = "";
        public string UserFullName
        {
            get { return _UserFullName; }
            set
            {
                _UserFullName = value;
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

        string AirAmbulanceCELetter = "";
        System.Diagnostics.Process FilePreview;

        string opsManagerName = "";
        string opsManagerSignature = "";

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

        string _PassPortNo = "";
        public string PassPortNo
        {
            get { return _PassPortNo; }
            set
            {
                _PassPortNo = value;
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

        public frmAirAmbulanceCE()
        {
            InitializeComponent();
        }

        private void frmAirAmbulanceCE_Load(object sender, EventArgs e)
        {
            commonFuncs = new CommonFunctions();
            LoadCurrencies();
            //txtPatientName.Text = PatientName;
            //txtPatientNationality.Text = Nationality;
            //txtPatientPassportNo.Text = PassportNo;
        }

        private void createAIMSNewGuarantee(ref string AccomodationVoucher, string cboGuaranteeHospital,
                                            string txtContactNumber, string txtEmailAddress,
                                            string txtGuaranteePatientName, string txtDOB,
                                            string txtGuaranteePatientFileNo, string txtConsolidatedAmt,
                                            string dtGOPStartDate, string dtGOPEndDate,
                                            string txtGuaranteeDiagnosis, string txtCoPaymentDue,
                                            string cboRoomType, string txtAdditionalNotes)
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

                h = +20;
                //Accommodation Name
                XPen pen1 = new XPen(XColors.Black, 1);

                int TblY = 180;

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Hospital / Facility / Provider", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                XPen pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);

                gfx.DrawString(cboGuaranteeHospital, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Contact number", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtContactNumber, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("E-Mail Address", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtEmailAddress, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Patient Name", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtGuaranteePatientName, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Date Of Birth", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtDOB, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("AIMS Case Number", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtGuaranteePatientFileNo, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 40;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Consolidated Amount", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                //lblConsolidatedAmt.Text
                gfx.DrawString("", fontCurrency, XBrushes.Red, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 40;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Guaranteed valid from", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(dtGOPStartDate, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Guarantee valid to", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(dtGOPEndDate, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Diagnosis / Treatment /Surgical Procedure", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtGuaranteeDiagnosis, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Co-Payment due", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(txtCoPaymentDue, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 230, 15);
                gfx.DrawString("Room Type", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 270, TblY - 2, 300, 15);
                gfx.DrawString(cboRoomType, fontText, XBrushes.Black, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

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
                XFont disclaimer = new XFont("Verdana", 7, XFontStyle.BoldItalic);
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

                fileHeader = "This Guarantee of Payment is Subject to the following conditions:";

                // Draw the text
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 2, page.Width, 200), XStringFormat.Center);

                XFont secondPage = new XFont("Verdana", 7, XFontStyle.Regular);
                XFont secondPageUnderline = new XFont("Verdana", 7, XFontStyle.Bold);

                h += 100;
                gfx.DrawString("•	Alliance International Medical Services (AIMS) do hereby guarantee the documented consolidated amount herein.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	If the treatment is delayed or exceeded beyond the dates provided within this guarantee please contact us.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	Cost related to guest charges, and items of personal nature such as telephone calls, newspapers, television, wireless", secondPageUnderline, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   charges, minibar, admission fees are not covered and the member to settle this directly with the hospital on discharge.", secondPageUnderline, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	The Patient or Family shall remain liable for all co-payments, deductibles, ward fee excesses and will need to be collected on admission", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   or upon discharge.", secondPageUnderline, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	The guarantee of payment is subject to the member’s policy being active at the time of treatment.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	Cover provided within this document relates only to the diagnosis as described above. All additional surgical intervention,", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   Treatment and the provision prosthetic aids must be communicated to Alliance International Medical Services (AIMS) in", secondPageUnderline, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   advance in order to obtain approval thereof.", secondPageUnderline, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	We reserve the right not to settle invoices in the event we become aware of any information which may invalidate the", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   patient’s eligibility to policy benefits, this may include, but not limited to information regarding the patients past medical", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   history", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	All admissions require a copy of the admission form, patient’s passport or ID, completed consent form and all medical", secondPageUnderline, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   radiology / pathology reports to be sent to operations@aims.org.za", secondPageUnderline, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);


                h += 50;
                fileHeader = "Invoicing Terms:";

                // Draw the text
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 250, page.Width, 200), XStringFormat.Center);

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
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 380, page.Width, 200), XStringFormat.Center);

                h += 20;
                gfx.DrawString("•	Payment will be issued 30 days (thirty) from the date of receipt of this Guarantee falling into the relevant cheque run pertinent to the ", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("   guarantee receipt date.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);


                h += 12;

                gfx.DrawString("•	Payment cannot be made on faxed invoices.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	Alliance International Medical Services (AIMS) will not be held liable for invoices received 60 days post date of receipt of this Guarantee.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 40;
                gfx.DrawString("Your Sincerely,", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;

                /// Start Operations Co-Ordinator /////
                image = XImage.FromFile(@SignaturePath);
                gfx.DrawImage(image, 50, h, (image.Width / 2), (image.Height / 2));
                image = XImage.FromFile(opsManagerSignature);
                gfx.DrawImage(image, 300, h + 10, (image.Width / 2), (image.Height / 2));

                h += 60;
                gfx.DrawString(UserFullName, secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(opsManagerName, secondPage, XBrushes.Black, new XRect((page.Width / 2) - 5, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Operations Specialist", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString("Operations Manager", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 5, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(DateTime.Now.ToString("dd MMMM yyyy"), secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 55;
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






                ///////////////////////////////////////// END - OF - PAGE 2 ////////////////////////////////////////////////////


                string filename = @"c:\AIMS Recorder\" + System.Guid.NewGuid() + ".pdf";

                document.Save(filename);
                AirAmbulanceCELetter = filename;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        private void txtAACost_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;
            
            try
            {
                if (txtAACost.Text.Trim().Length > 0)
                {
                    if (!double.TryParse(txtAACost.Text, out tmp))
                    {
                        if (txtAACost.Text.Substring(txtAACost.Text.Trim().Length - 1, 1) != ".")
                        {
                            if (!double.TryParse(txtAACost.Text.Trim(), out tmp1))
                            {
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void txtAACost_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // allows only numbers, decimals and control characters
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && this.Text.Contains("."))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && this.Text.Length < 1)
                {
                    e.Handled = true;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void btnGuaranteePreview_Click(object sender, EventArgs e)
        {
            try
            {
                bool bValidated = ValidateControl();
                if (bValidated)
                {
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
                    btnGuaranteePreview.Enabled = false;
                    btnGuaranteeCreate.Enabled = false;
                    createAirAmbulanceCE(ref AirAmbulanceCELetter);
                    //AAPreview();
                    //createAIMSNewGuarantee(txtAAAddressTo.Text, txtAAFrom.Text , txtAATo.Text ,lstvwAAOptions.list);
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Air-Ambulance preview error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Air-Ambulance preview error: " + ex.ToString());
            }
            finally
            {
                btnGuaranteePreview.Enabled = true;
                btnGuaranteeCreate.Enabled = true;
            }
        }

        private bool ValidateControl()
        {
            bool ReturnValue = true;
            try
            {
                errProvider.Clear();

                if (txtAAAddressTo.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtAAAddressTo, "Please AA Address To (Person/Individual/Company)");
                    txtAAAddressTo.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtAAFrom.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtAAFrom, "Please Capture FROM Location");
                    txtAAFrom.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtAATo.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtAATo, "Please Capture TO Location");
                    txtAATo.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                if (lstvwAAOptions.Items.Count<= 0 )
                {
                    commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "AA Options Not Captured");
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtRefHosEmail.Text.Trim().Length > 0)
                {
                    if (!commonFuncs.ValidEmailAddress(txtRefHosEmail.Text.Trim()))
                    {
                        errProvider.SetError(txtRefHosEmail, "Please enter valid email address");
                        tabControl1.SelectedIndex = 1;
                        txtRefHosEmail.Focus();
                        ReturnValue = false;
                    }
                }

                if (txtRefDrNameEmail.Text.Trim().Length > 0)
                {
                    if (!commonFuncs.ValidEmailAddress(txtRefDrNameEmail.Text.Trim()))
                    {
                        errProvider.SetError(txtRefDrNameEmail, "Please enter valid email address");
                        txtRefDrNameEmail.Focus();
                        tabControl1.SelectedIndex = 1;
                        ReturnValue = false;
                    }
                }
                //if (!vhfFormRequiredYes.Checked & !vhfFormRequiredNo.Checked)
	            //{
                //     errProvider.SetError(grpBxVHFForm, "VHF Form requirement not selected");
                //    grpBxVHFForm.Focus();
                //    tabControl1.SelectedIndex = 3;
                //    ReturnValue = false;
	            //}
                //if (!MedicalRepFormRequiredYes.Checked & !MedicalRepFormRequiredNo.Checked)
	            //{
                //    errProvider.SetError(grpBxMedicalReport, "Medical Requirement not selected");
                //    grpBxMedicalReport.Focus();
                //    tabControl1.SelectedIndex = 3;
                //    ReturnValue = false;
	            //}
            }
            finally
            {

            }
            return ReturnValue;
        }

        private void btnAddAAEntry_Click(object sender, EventArgs e)
        {
            try
            {
                bool bContinue = AAOptionsValidate();
                if (bContinue)
                {
                    AddAAOption();
                }
            }
            catch (System.Exception ex )
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Air-Ambulance option capture Error. Please contact System Administrator.");
                commonFuncs.ErrorLogger("Air-Ambulance option capture Error: " + ex.ToString());
            }
        }

        private void LoadAAOptions()
        {
            DataTable dtAAOptionsDetails = commonFuncs.GetAAOptions(PatientID);
            ListViewItem lvwItem;
            try
            {
                if (dtAAOptionsDetails.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAAOptionsDetails.Rows.Count; i++)
                    {
                        lvwItem = new ListViewItem(dtAAOptionsDetails.Rows[i]["AIRCRAFT"].ToString());
                        lvwItem.SubItems.Add(dtAAOptionsDetails.Rows[i]["AVAILIBITY"].ToString());
                        lvwItem.SubItems.Add(dtAAOptionsDetails.Rows[i]["COST"].ToString());
                        lvwItem.SubItems.Add(dtAAOptionsDetails.Rows[i]["LEVELOFCARE"].ToString());
                        lvwItem.SubItems.Add(dtAAOptionsDetails.Rows[i]["ROUTING"].ToString());
                        lvwItem.SubItems.Add(dtAAOptionsDetails.Rows[i]["User_Full_Name"].ToString());
                        lvwItem.SubItems.Add(dtAAOptionsDetails.Rows[i]["CREATION_DTTM"].ToString());
                        lvwItem.SubItems.Add(dtAAOptionsDetails.Rows[i]["AAOPTION_ID"].ToString());
                        lstvwAAOptions.Items.Add(lvwItem);
                    }

                    foreach (ColumnHeader ch in lstvwAAOptions.Columns)
                    {
                        if (ch.Text.Equals("AAOPTION_ID"))
                        {
                            ch.Width = 0;
                        }
                        else
                        {
                            ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
                else
                {
                    lstvwAAOptions.Items.Clear();
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.ErrorLogger("Error loading Appointment Information: " + ex.ToString());
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Error loading appointment details, Please contact System Administrator.");
            }
            finally
            {
                dtAAOptionsDetails.Dispose();
            }
        }

        private void AddAAOption()
        {
            ListViewItem lvwItem;
            lvwItem = new ListViewItem(txtAAAirCraft.Text);
            lvwItem.SubItems.Add(txtAAAvailibity.Text);
            lvwItem.SubItems.Add(txtAACost.Text + " " + cboFlightCostCurrencies.Text);
            lvwItem.SubItems.Add(txtAALevelOfCare.Text);

            lvwItem.SubItems.Add(txtAAAdminFee.Text + " " + cboAdminFeeCurrencies.Text);
            lvwItem.SubItems.Add(txtAAAmbulanceReceive.Text);
            lvwItem.SubItems.Add(txtAAAmbulanceRefer.Text);
            lvwItem.SubItems.Add(txtAARouting.Text);
            lvwItem.SubItems.Add(txtAAAirportOpsHours.Text);
            
            lstvwAAOptions.Items.Add(lvwItem);
            ClearAAOptions();
        }

        private void ClearAAOptions() {
            txtAAAirCraft.Text = "";
            txtAAAvailibity.Text = "";
            txtAACost.Text = "";
            txtAALevelOfCare.Text = "";
            txtAARouting.Text = "";

            txtAALevelOfCare.Text = "";
            txtAAAdminFee.Text = "";
            txtAAAmbulanceReceive.Text = "";
            txtAAAmbulanceRefer.Text = "";
            txtAARouting.Text = "";
            txtAAAirportOpsHours.Text = "";
            cboAdminFeeCurrencies.SelectedIndex = -1;
            cboFlightCostCurrencies.SelectedIndex = -1;
        }

        private void ClearAADetails() { 
            txtPatientName.Text = "";
            txtPatientNationality.Text = "";
            txtPatientPassportNo.Text = "";
            txtPatientYellowFeverCert.Text = "";
            txtPatientWeightHeight.Text = "";

            txtRefHosNameLocation.Text = "";
            txtRefHosTelNo.Text = "";
            txtRefHosEmail.Text = "";

            txtRefDrName.Text = "";
            txtRefDrNameEmail.Text = "";
            txtRefDrNameTel.Text = "";

            txtAccomMemNameSur.Text = "";
            txtAccomMemNationality.Text = "";
            txtAccomMemPassportNo.Text = "";
            txtAccomMemYelFeverCert.Text = "";
            txtMemberWeightHeight.Text = "";

            vhfFormRequiredYes.Checked = false;
            vhfFormRequiredNo.Checked = false;
        }

        private bool SaveAAOptions()
        {
            bool bContinue = true;

            string AAOptionLoadId = "";
            foreach (ListViewItem lstItm in lstvwAAOptions.Items)
            {
                bContinue = commonFuncs.SaveAAOption(ref AAOptionLoadId,
                               lstItm.Text ,
                                lstItm.SubItems[1].Text ,
                                lstItm.SubItems[2].Text,
                                lstItm.SubItems[3].Text,
                                lstItm.SubItems[7].Text,
                                UserName,
                                PatientID,
                                lstItm.SubItems[4].Text,
                                lstItm.SubItems[6].Text,
                                lstItm.SubItems[5].Text,
                                lstItm.SubItems[8].Text);
                AAOptionLoadId = "";
            }

            return bContinue;
        }

        private bool SaveAADetails()
        {
            string vhfFormrequiredYN = "N";
            if (vhfFormRequiredYes.Checked)
            {
                vhfFormrequiredYN = "Y";
            }
            return commonFuncs.SaveAADetails(
                    PatientID ,
                    txtPatientYellowFeverCert.Text,
                    txtPatientWeightHeight.Text,
                    txtRefHosNameLocation.Text,
                    txtRefHosTelNo.Text,
                    txtRefHosEmail.Text,
                    txtRefDrName.Text,
                    txtRefDrNameTel.Text,
                    txtRefDrNameEmail.Text,
                    txtAccomMemNameSur.Text,
                    txtAccomMemNationality.Text,
                    txtAccomMemPassportNo.Text,
                    txtAccomMemYelFeverCert.Text,
                    txtMemberWeightHeight.Text,
                    vhfFormrequiredYN,
                    UserID, AirAmbulanceCELetter, txtPatientPassportNo.Text, txtAAAddressTo.Text);
        }
        
        private bool SaveAAOption() 
        {
            //save All AA Options
            bool bContinue = SaveAAOptions();
            if (bContinue)
            {
                if (lstvwAAOptions.Items.Count > 0)
                {
                    bContinue = SaveAADetails();
                }
            }
            return bContinue;
        }

        private bool SaveAAArchiveDoc() {
            bool bReturn = false;
            DataTable dtLimitation = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_POD_AA");
            if (!dtLimitation.Rows.Count.Equals(0))
            {
                string GuaranteePOD = dtLimitation.Rows[0]["LIMITATION_VALUE"].ToString();
                string GuaranteeMonth = System.DateTime.Now.ToString("MMMM");
                string GuaranteeYear = System.DateTime.Now.Year.ToString();
                string GuaranteeFile = Path.Combine(@GuaranteePOD , GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy") + @"\" + Path.GetFileName(@AirAmbulanceCELetter));
                
                if (!Directory.Exists(@GuaranteePOD + GuaranteeYear)) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear); }
                if (!Directory.Exists(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth)) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth); }
                if (!Directory.Exists(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy"))) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy")); }

                if (File.Exists(@AirAmbulanceCELetter))
                {
                    File.Copy(@AirAmbulanceCELetter, GuaranteeFile);
                    AirAmbulanceCELetter = GuaranteeFile;

                    return true;
                }
            }
            return bReturn;
        }

        private bool AAOptionsValidate()
        {
            string sMissingFields = "";
            if (txtAAAirCraft.Text.Trim().Equals("")) { sMissingFields += "Air Craft Missing \n"; }
            if (txtAAAvailibity.Text.Trim().Equals("")) { sMissingFields += "Availability Missing \n"; }
            if (txtAACost.Text.Trim().Equals("")) { sMissingFields += "Cost Missing \n"; }
            if (txtAALevelOfCare.Text.Trim().Equals("")) { sMissingFields += "Level-Of-Care Missing \n"; }
            if (txtAARouting.Text.Trim().Equals("")) { sMissingFields += "Routing Missing \n"; }


            if (cboFlightCostCurrencies.SelectedItem == null || (cboFlightCostCurrencies.SelectedItem != null && (cboFlightCostCurrencies.Text == "")))
            {
                sMissingFields += "Please select Flight-Cost Currency  \n";
            }

            if (cboAdminFeeCurrencies.SelectedItem == null || (cboAdminFeeCurrencies.SelectedItem != null && (cboAdminFeeCurrencies.Text == "")))
            {
                sMissingFields += "Please select Admin-Fee Currency  \n";
            }

            if (txtAAAirportOpsHours.Text.Trim().Equals("")) { sMissingFields += "Airport Operations Hours \n"; }
            if (txtAAAmbulanceReceive.Text.Trim().Equals("")) { sMissingFields += "Ambulance Receiving Missing \n"; }
            if (txtAAAmbulanceRefer.Text.Trim().Equals("")) { sMissingFields += "Ambulance Referring Missing \n"; }
            if (txtAAAdminFee.Text.Trim().Equals("")) { sMissingFields += "Administration Fee Missing \n"; }

            if (!sMissingFields.Trim().Equals(""))
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, sMissingFields);
                return false;
            }

            if (lstvwAAOptions.Items.Count.Equals(3))
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Only 3 Air-Ambulance options allowed.");
                return false; 
            }
            return true ;
        }

        private void lstvwAAOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuaranteeCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!filePreviewed)
                {
                    commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Please preview Cost-Estimate before saving");
                    return;
                }

                DialogResult dbDialog = MessageBox.Show("Continue creating the Air-Ambulance Cost Estimate request", "Confirm AA Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dbDialog == DialogResult.Yes)
                {
                    if (lstvwAAOptions.Items.Count > 0)
                    {
                        if (AirAmbulanceCELetter.Equals(""))
                        {
                            commonFuncs.DisplayMessage(CommonTypes.MessagType.Warning, "Please preview the Air-Ambulance Cost-Estimate before saving");
                            return;
                        }
                        else
                        {
                            if (ValidateControl())
                            {
                                bool bSaved = SaveAAArchiveDoc();
                                if (bSaved)
                                {
                                    bSaved = SaveAAOption();
                                    if (bSaved)
                                    {
                                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Success, "Air-Ambulance Request Captured successfully.");
                                        //LoadAAOptions();
                                        //Thread.Sleep(5000);
                                        //File.SetAttributes(@AirAmbulanceCELetter, FileAttributes.Normal);
                                        //File.Delete(@AirAmbulanceCELetter);
                                        Notes notesBLL = new Notes();
                                        notesBLL.SavePatientNotes(PatientFileNo, UserID, "Air-Ambulance Request Captured successfully", 7, 0);

                                        this.Close();
                                    }
                                    else
                                    {
                                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Air-Ambulance option capture Error. Please contact System Administrator.");
                                    }
                                }
                                else
                                {
                                    commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Air-Ambulance Cost-Estimate archiving error. Please contact System Administrator.");
                                }
                            }
                        }
                    }
                    else
                    {
                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Warning, "AA options not captured");
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Air-Ambulance Capture Error. Please contact System Administrator.");
                commonFuncs.ErrorLogger("Air-Ambulance Capture Error - Exception : " + ex.ToString());
            }
        }

        private void lstvwAAOptions_DoubleClick(object sender, EventArgs e)
        {
            ListView lstGet = (ListView)sender;
            try
            {
                for (int i = 0; i < lstGet.Items.Count; i++)
                {
                    if (lstGet.Items[i].Selected)
                    {
                        ClearAAOptions();
                        txtAAAirCraft.Text = lstGet.Items[i].SubItems[0].Text.ToString();
                        txtAAAvailibity.Text = lstGet.Items[i].SubItems[1].Text.ToString();
                        txtAACost.Text = lstGet.Items[i].SubItems[2].Text.ToString();
                        txtAALevelOfCare.Text = lstGet.Items[i].SubItems[3].Text.ToString();
                        txtAARouting.Text = lstGet.Items[i].SubItems[4].Text.ToString();
                        
                    }
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading AA Options Details error, Please contact System Administrator.");
                commonFuncs.ErrorLogger("Loading AA Options Details error: " + ex.ToString());
            }
            finally
            {
                lstGet = null;
            }
        }

        private void btnDelAAEntry_Click(object sender, EventArgs e)
        {
            commonFuncs = new CommonFunctions();
            bool bDeleted = false;
            if (lstvwAAOptions.Items.Count >0)
            {
                foreach (ListViewItem  lstItw in lstvwAAOptions.Items )
                {
                    if (lstItw.Checked)
                    {
                        lstItw.Remove();
                        bDeleted = true;
                    }
                }
                if (!bDeleted)
                {
                    commonFuncs.DisplayMessage(CommonTypes.MessagType.Warning, "Please select option to delete");
                }
            }
            else
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Warning, "AA options not captured.");
            }
        }

        private void AAPreview()
        {
            //DataTable dtAAOptions = commonFuncs.GetAAOptions(PatientID);
            string AAOption = "";
            int?  optionCnt = 1; 

            foreach (ListViewItem  itmVw in lstvwAAOptions.Items)
            {
                AAOption += "<tr><td bgcolor=lightgrey valign=bottom colspan=4 align=center><b>Option " + optionCnt.ToString() + "</b></td></tr>" +
                " <tr><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Aircraft:</td><td valign=bottom bgcolor=#efefef width=40% align='left'><font size=1><b>" + itmVw.Text + "</b></font></td><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Availability:</td><td valign=bottom bgcolor=#efefef width=40% align='left'><font size=1><b>" + itmVw.SubItems[1].Text + "</b></font></td></tr>" +
                " <tr><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Cost:</td><td valign=bottom bgcolor=#efefef width=40% align='left'><font size=1 color=red><b>" + itmVw.SubItems[2].Text + "</b></font></td><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Level Of care:</td><td valign=bottom bgcolor=#efefef width=40% align='left'><font size=1><b>" + itmVw.SubItems[3].Text + "</b></font></td></tr>" +
                " <tr><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Routing:</td><td valign=bottom bgcolor=#efefef width=40% align='left' colspan=3><font size=1><b>" + itmVw.SubItems[4].Text + "</b></font></td></tr>";
                optionCnt++;
                if (optionCnt.Equals(4))
                {
                    break;
                }
            }
            optionCnt += -1;
            if (optionCnt < 3)
            {
                int? _blanks = 3 - optionCnt;
                for (int i = 0; i < _blanks; i++)
                {
                    optionCnt++;
                    AAOption += "<tr><td bgcolor=lightgrey valign=bottom colspan=4 align=center><b>Option " + optionCnt.ToString() + "</b></td></tr>" +
                    " <tr><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Aircraft:</td><td valign=bottom bgcolor=#efefef width=40% align='left'><font size=1 color=#efefef><b>-</b></font></td><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Availability:</td><td valign=bottom bgcolor=#efefef width=40% align='left'><font size=1 color=#efefef><b>-</b></font></td></tr>" +
                    " <tr><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Cost:</td><td valign=bottom bgcolor=#efefef width=40% align='left'><font size=1 color=#efefef><b>-</b></font></td><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Level Of care:</td><td valign=bottom bgcolor=#efefef width=40% align='left'><font size=1 color=#efefef><b>-</b></font></td></tr>" +
                    " <tr><td valign=bottom bgcolor=#ffffff width=10% style='TEXT-TRANSFORM: capitalize'>Routing:</td><td valign=bottom bgcolor=#efefef width=40% align='left' colspan=3><font size=1 color=#efefef><b>-</b></font></td></tr>";                    
                }
            }

            string pdfFile = @"c:\AIMS Recorder\AA_CE_" + System.Guid.NewGuid() + ".pdf";
            string htmlBody = "<html>" +
            "<table width=100% cellpadding=2 cellspacing=1 align=center style='FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left' >" +
            "<tr> " +
            @"<td bgcolor=#ffffff colspan=4 align=center><img width=500px height=90px src='c:\AIMSLOGONEW.png'/></td> " +
            "</tr> " +
            "</table>" +
            " <p align=center style='text-align:center;FONT-SIZE: 9pt;COLOR: #666666;LINE-HEIGHT:10pt;FONT-FAMILY: Verdana, Arial;'><b><span style='font-size:14.0pt'>AIR AMBULANCE COST ESTIMATE</span></b></p>" +
            " <p><span style='text-align:left;FONT-SIZE: 8pt;COLOR: #000000;LINE-HEIGHT: 15pt;FONT-FAMILY: Verdana, Arial;'><br/>Dear " + txtPatientName.Text  + ", </span></p>" +
            " <p><span style='text-align:left;FONT-SIZE: 8pt;COLOR: #000000;LINE-HEIGHT: 15pt;FONT-FAMILY: Verdana, Arial;'>It gives us great pleasure to present the below cost estimates for an evacuation from <b>"+ txtAAFrom.Text +"</b> [to] <b>"+ txtAATo.Text +"</b> to you:</span></p><br/>" +
            " <table width=100% cellpadding=1 cellspacing=1 align=center style='FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left'>";
            htmlBody += AAOption;
            htmlBody += " <tr><td valign=bottom bgcolor=#efefef width=40% align='left' colspan=4 style='LINE-HEIGHT: 8pt'><font color=#efefef>&nbsp;!!</font></td></tr>";
            string vhfFormRequired = "NO";
            if (vhfFormRequiredYes.Checked)
            {
                vhfFormRequired = "YES";
            }
            htmlBody += " </table>" +
            " <p><span style='text-align:left;FONT-SIZE: 9pt;COLOR: #000000;LINE-HEIGHT: 17pt;FONT-FAMILY: Verdana, Arial;'>Should you wish to proceed with this activation, please provide us with the following:</span></p><br/>" +
            " <table width=100% cellpadding=1 cellspacing=1 align=center style='FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 8pt;TEXT-ALIGN: left'>" +
            " <tr><td bgcolor=lightgrey valign=bottom colspan=4 align=center><b>Patient Details</b></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient’s Name and Surname</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtPatientName.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Nationality</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtPatientNationality.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Passport Number</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtPatientPassportNo.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Current Yellow Fever Certificate</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtPatientYellowFeverCert.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Estimated Patient’s Weight and Height</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtPatientWeightHeight.Text + "</b></font></td></tr>" +
            " <tr><td bgcolor=lightgrey valign=bottom colspan=4 align=center><b>Hospital Details</b></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Name and Location of Referring Hospital</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtRefHosNameLocation.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Referring Hospital Telephone Number</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtRefHosTelNo.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Referring Doctor’s Name and Contact Details</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtRefDrName.Text + " - [Tel: " + txtRefDrNameTel.Text + "][E-Mail:" + txtRefDrNameEmail.Text + "] </b></font></td></tr>" +
            " <tr><td bgcolor=lightgrey valign=bottom colspan=4 align=center><b>Accompanying Member Details</b></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Member Name and Surname</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtAccomMemNameSur.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Nationality</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtAccomMemNationality.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Passport Number</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtAccomMemPassportNo.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Current Yellow Fever Certificate</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtAccomMemYelFeverCert.Text + "</b></font></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Estimated Patient’s Weight and Height</td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + txtMemberWeightHeight.Text + "</b></font></td></tr>" +
            " <tr><td bgcolor=lightgrey valign=bottom colspan=4 align=center><b>Further Information Required</b></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize><font color=red>VHF Form Required*</font></td><td colspan=2 bgcolor=#efefef width=50% align=left><font size=1><b>" + vhfFormRequired + "</b></font></td></tr>" +
            " <tr><td valign=bottom bgcolor=#efefef width=40% align='left' colspan=4 style='LINE-HEIGHT: 8pt'><font color=#efefef>&nbsp;!!</font></td></tr>" +
            " </table>" +
            "<br/><p><span style='text-align:left;FONT-SIZE: 8pt;COLOR: #000000;LINE-HEIGHT: 8t;FONT-FAMILY: Verdana, Arial;'>Kind Regards, <br/>" + UserName + "<br/>AIMS Operations<br/>" + System.DateTime.Today.ToString("dd MMMM yyyy") + "<br/></span></p><br/>" +
            "<p><i><span style='text-align:left;FONT-SIZE: 7pt;COLOR: #000000;LINE-HEIGHT: 6pt;FONT-FAMILY: Verdana, Arial;'>Please see next page for terms and conditions and return signed after acceptance of cost estimate:</span></i><b><span style='font-size:8pt'><br clear=all style='page-break-before:always'></span></b></p><br/>" +
            "<div style='position: absolute;bottom: 0;'>" +
            "<p align=center><span style='text-align:center;FONT-SIZE: 5pt;COLOR: =#ffffff;LINE-HEIGHT:10pt;FONT-FAMILY: Verdana, Arial;LINE-HEIGHT: 7pt'>Alliance International Medical Services Pty Ltd.<br/>" +
            " 3 West Street, Bryanston, 2191 | Private Bag X5 Benmore 2010 | Tel: +27 11 783 0135 | Fax: +27 11 463 3583 | E-mail: operations@aims.org.za<br/>" +
            " <b>Directors:  B.A. Breton (Managing)</b><br/>Reg. No: 2001/025937/07 <br/>" +
            " </span></p></div>";
            htmlBody += TermsAndConditionPage();
            htmlBody += "</html>";
            HTMLtoPDF.createPDF(htmlBody, ref pdfFile);
            AirAmbulanceCELetter = pdfFile;
            ViewFile();
        }

        private void ViewFile()
        {
            frmImageViewer frmImgViewer = new frmImageViewer();
            try
            {
                frmImgViewer.EmailDocument = AirAmbulanceCELetter;
                frmImgViewer.Text = PatientFileNo + " - Air Ambulance Cost-Estimate File";

                frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                frmImgViewer.MaximizeBox = false;
                frmImgViewer.MinimizeBox = false;
                frmImgViewer.ShowDialog();
                DialogResult dialogRes = MessageBox.Show("Continue with the Previewed " + TemplateName + "...?", "Proceed with Previewed Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogRes == DialogResult.Yes)
                {
                    filePreviewed = true;
                }
                else
                {
                    filePreviewed = false;
                    try
                    {
                        File.Delete(AirAmbulanceCELetter);
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

        private string TermsAndConditionPage()
        {
            string htmlBody = "<table width=100% cellpadding=2 cellspacing=1 align=center style='FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left' >" +
           "<tr> " +
           @"<td bgcolor=#ffffff colspan=4 align=center><img width=500px height=90px src='c:\AIMS_logo_White1.png'/></td> " +
           "</tr> " +
           "</table>" +
            " <br/><br/><table width=100% cellpadding=1 cellspacing=1 align=center style='FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left' >" +
            " <tr><td bgcolor=lightgrey valign=bottom colspan=4 align=center><b>Terms and Conditions:</b></td></tr></table>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>1)</b>&nbsp;&nbsp;This cost estimate is valid for 48 hours.</span><span style='font-size:8pt'></span></p>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>2)</b>&nbsp;&nbsp;This cost estimate is inclusive of local taxes, medical crew, equipment, accommodation costs and fuel surcharges, unless otherwise stated.</span><span style='font-size:8pt'></span></p>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>3)</b>&nbsp;&nbsp;AIMS cannot be held liable for any delays caused by weather, political unrest, non-issuance of clearances, delays caused by applications for clearances, security threats or any circumstances out of the companies’ control that may adversely affect the mission.</span></p>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>4)</b>&nbsp;&nbsp;Cancellation charges may be applicable if the flight is cancelled after being activated, but before the aircraft has taken off from the point of origin.</span></p>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>5)</b>&nbsp;&nbsp;The client will be liable for the full amount of the cost estimate if the mission is cancelled post takeoff. </span></p>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>6)</b>&nbsp;&nbsp;*Due to the Viral Heamorrhagic Fever Risks in Africa, to obtain clearances from the South African Department of Health, South African Port Health and National Institute of Communicable Diseases, we will require a completed Ebola Matrix Form (attached).</span></p>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>7)</b>&nbsp;&nbsp;In the event that a patient may be too unstable for air transportation, the client will still be liable for the full cost of the mission. The decision will be made by the FMO (Flight Medical Officer) and the Medical Director of AIMS.</span></p>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>8)</b>&nbsp;&nbsp;Please note that this cost estimate excludes the costs of the admission, treatment, assessment, accommodation and transportation of the patient and any companions, and any other costs not related to the Air Ambulance Mission.</span></p>" +
            "<p><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'><b>9)</b>&nbsp;&nbsp;This Document does not serve to replace an official Letter of Guarantee from your organization, we will require a Letter of Guarantee clearly stating:</span>" +
            "</p>" +
            "<p><b><span style='text-align:left;FONT-SIZE: 6.5pt;COLOR: #000000;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a.&nbsp;&nbsp;&nbsp;Patient Name" +
            "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.&nbsp;&nbsp;&nbsp;Your Reference Number" +
            "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.&nbsp;&nbsp;&nbsp;Routing of Mission" +
            "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.&nbsp;&nbsp;&nbsp;Cost of the Air Ambulance Mission" +
            "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.&nbsp;&nbsp;&nbsp;Dates of Service</span></b></p>" +
            "<br/>" +
            "<br/>" +
            "<table width=100% cellpadding=1 cellspacing=1 align=center style='FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left'>" +
            "<tr><td bgcolor=lightgrey valign=center colspan=4 align=center><b>I, the undersigned, confirm that:</b></td></tr>" +
            "<tr><td valign=center>•	I have read the above terms and conditions;</td></tr>" +
            "</table>" +
            "<br/>" +
            "<br/>" +
            "<table width=100% cellpadding=1 cellspacing=1 align=center style='FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left'>" +
            "<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•&nbsp;&nbsp;&nbsp;I have read the above terms and conditions;</td></tr>" +
            "<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•&nbsp;&nbsp;&nbsp;I accept them as stated above;</td></tr>" +
            "<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•&nbsp;&nbsp;&nbsp;I am duly authorized to accept the terms and conditions.</td></tr>" +
            "</table>" +
            "<br/>" +
            "<br/>" +
            "<table border=0.5 width=100% cellpadding=1 cellspacing=1 align=center style='FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left'>" +
            "<tr><td bgcolor=lightgrey valign=bottom colspan=4 align=center>&nbsp;</td></tr>" +
            "<tr><td colspan=2 bgcolor=#ffffff width=50% style='TEXT-TRANSFORM:capitalize'>Full Name:</td><td colspan=2 bgcolor=#efefef width=50% align=left></td></tr>" +
            "<tr><td colspan=2 bgcolor=#ffffff width=50% style='TEXT-TRANSFORM:capitalize'>Position:</td><td colspan=2 bgcolor=#efefef width=50% align=left></td></tr>" +
            "<tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM:capitalize>Date:</td><td colspan=2 bgcolor=#efefef width=50% align=left></td></tr>" +
            "<tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM:capitalize>Option Accepted:	</td><td colspan=2 bgcolor=#efefef width=50% align=left></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM:capitalize>Amount Accepted:	</td><td colspan=2 bgcolor=#efefef width=50% align=left></td></tr>" +
            " <tr><td colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM:capitalize>Signature: </td><td colspan=2 bgcolor=#efefef width=50% align=left></td></tr>" +
            "</table>" +
            "<br/>" +
            "<br/>" +
            "<br/>" +
            "<br/>" +
            "<div style='position: absolute;bottom: 0;'>" +
            "<p align=center><span style='text-align:center;FONT-SIZE: 5pt;COLOR: =#ffffff;LINE-HEIGHT:10pt;FONT-FAMILY: Verdana, Arial;LINE-HEIGHT: 7pt'>Alliance International Medical Services Pty Ltd.<br/>" +
            " 3 West Street, Bryanston, 2191 | Private Bag X5 Benmore 2010 | Tel: +27 11 783 0135 | Fax: +27 11 463 3583 | E-mail: operations@aims.org.za<br/>" +
            " <b>Directors:  B.A. Breton (Managing)</b><br/>Reg. No: 2001/025937/07 <br/>" +
            " </span></p></div>";


            return htmlBody;
        }

        private void createAirAmbulanceCE(ref string AACostEstimatePDF)
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

                int TblY = 150;

                XPen pen1 = new XPen(XColors.Black, 1);
                XPen pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("ATTENTION:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawRectangle(pen2, 185, TblY-2, 400, 15);
                gfx.DrawString(txtAAAddressTo.Text.ToUpper() , fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 40;
                h = +20;
                string salutation = "It gives us great pleasure to present the below cost estimates for an evacuation:";
                gfx.DrawString(salutation, fontText, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
             
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("FROM:", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(txtAAFrom.Text.ToUpper(), fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("TO:", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(txtAATo.Text.ToUpper(), fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                h = +20;
                
                TblY = 240;

                string airCraftType = "";
                string availability = "";
                string FlightCost = "";
                string levelOfCare = "";
                string adminFee = "";
                string ambulanceReferring = "";
                string ambulanceReceiving = "";
                string routing = "";
                string airportOperatingHours = "";

                airCraftType = lstvwAAOptions.Items[0].SubItems[0].Text;
                availability = lstvwAAOptions.Items[0].SubItems[1].Text;
                FlightCost = lstvwAAOptions.Items[0].SubItems[2].Text;
                levelOfCare = lstvwAAOptions.Items[0].SubItems[3].Text;
                adminFee = lstvwAAOptions.Items[0].SubItems[4].Text;
                ambulanceReferring = lstvwAAOptions.Items[0].SubItems[5].Text;
                ambulanceReceiving = lstvwAAOptions.Items[0].SubItems[6].Text;
                routing = lstvwAAOptions.Items[0].SubItems[7].Text;
                airportOperatingHours = lstvwAAOptions.Items[0].SubItems[8].Text;
 
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("OPTION 1", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Aircraft Type", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(airCraftType, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Availability", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(availability, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Flight Cost", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(FlightCost, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Level Of Care", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(levelOfCare, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Administration Fee", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 115, 15);
                gfx.DrawString(adminFee, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("NOTES", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Ambulance Referring", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(ambulanceReferring, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Ambulance Receiving", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(ambulanceReceiving, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Routing", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(routing, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Airport Operating Hours", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(airportOperatingHours, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);
                ///////////////////  OPTION 2  ///////////////

                airCraftType = "";
                availability = "";
                FlightCost = "";
                levelOfCare = "";
                adminFee = "";
                ambulanceReferring = "";
                ambulanceReceiving = "";
                routing = "";
                airportOperatingHours = "";
                if (lstvwAAOptions.Items.Count >1)
                {
                    airCraftType = lstvwAAOptions.Items[1].SubItems[0].Text;
                    availability = lstvwAAOptions.Items[1].SubItems[1].Text;
                    FlightCost = lstvwAAOptions.Items[1].SubItems[2].Text;
                    levelOfCare = lstvwAAOptions.Items[1].SubItems[3].Text;
                    adminFee = lstvwAAOptions.Items[1].SubItems[4].Text;
                    ambulanceReferring = lstvwAAOptions.Items[1].SubItems[5].Text;
                    ambulanceReceiving = lstvwAAOptions.Items[1].SubItems[6].Text;
                    routing = lstvwAAOptions.Items[1].SubItems[7].Text;
                    airportOperatingHours = lstvwAAOptions.Items[1].SubItems[8].Text;                    
                }

                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("OPTION 2", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Aircraft Type", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(airCraftType, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Availability", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(availability, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Flight Cost", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(FlightCost, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Level Of Care", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(levelOfCare, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Administration Fee", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 115, 15);
                gfx.DrawString(adminFee, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("NOTES", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Ambulance Referring", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(ambulanceReferring, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Ambulance Receiving", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(ambulanceReceiving, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Routing", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(routing, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Airport Operating Hours", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(airportOperatingHours, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);

                // OPTION 3

                airCraftType = "";
                availability = "";
                FlightCost = "";
                levelOfCare = "";
                adminFee = "";
                ambulanceReferring = "";
                ambulanceReceiving = "";
                routing = "";
                airportOperatingHours = "";
                
                if (lstvwAAOptions.Items.Count > 2)
                {
                    airCraftType = lstvwAAOptions.Items[2].SubItems[0].Text;
                    availability = lstvwAAOptions.Items[2].SubItems[1].Text;
                    FlightCost = lstvwAAOptions.Items[2].SubItems[2].Text;
                    levelOfCare = lstvwAAOptions.Items[2].SubItems[3].Text;
                    adminFee = lstvwAAOptions.Items[2].SubItems[4].Text;
                    ambulanceReferring = lstvwAAOptions.Items[2].SubItems[5].Text;
                    ambulanceReceiving = lstvwAAOptions.Items[2].SubItems[6].Text;
                    routing = lstvwAAOptions.Items[2].SubItems[7].Text;
                    airportOperatingHours = lstvwAAOptions.Items[2].SubItems[8].Text;
                }
                TblY = TblY + 30;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("OPTION 3", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Aircraft Type", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(airCraftType, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Availability", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(availability, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Flight Cost", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(FlightCost, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Level Of Care", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(levelOfCare, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Administration Fee", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 115, 15);
                gfx.DrawString(adminFee, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("NOTES", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Ambulance Referring", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(ambulanceReferring, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Ambulance Receiving", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(ambulanceReceiving, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("Routing", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString(routing, fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Airport Operating Hours", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString(airportOperatingHours, fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);


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

                fileHeader = "Should you wish to proceed with this activation, please provide us with the following:";

                TblY = 120;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("South African Port Health  Authorities Evacuation approval application requirements", fontTextBold, XBrushes.Black, new XRect(w + 80, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 150, 15);
                gfx.DrawString("VHF Form Required*", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 185, TblY - 2, 130, 15);
                gfx.DrawString("YES         |           NO", fontText, XBrushes.Black, new XRect(190, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), 300, TblY - 2, 150, 15);
                gfx.DrawString("Medical report Required*", fontTextBold, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                gfx.DrawRectangle(pen2, 450, TblY - 2, 135, 15);
                gfx.DrawString("YES         |           NO", fontText, XBrushes.Black, new XRect(453, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);
                
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("Patient Details", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Patient's Name and Surname", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtPatientName.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Nationality", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtPatientNationality.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Passport Number", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtPatientPassportNo.Text , fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Current Yellow Fever Certificate", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtPatientYellowFeverCert.Text , fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Estimated Patient's Weight", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtPatientWeightHeight.Text , fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);
                
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("Hospital Details", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Name and Location of Referring Hospital", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtRefHosNameLocation.Text , fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                
                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Referring Hospital Telephone Number", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtRefHosTelNo.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Referring Hospital Doctor's Name and Contact Details", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtRefDrName.Text + "  " + txtRefDrNameTel.Text + "  " + txtRefDrNameEmail.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 550, 15);
                gfx.DrawString("Accompanying Member Details", fontTextBold, XBrushes.Black, new XRect(w + 250, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Member Name and Surname", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtAccomMemNameSur.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Nationality", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtAccomMemNationality.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Passport Number", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtAccomMemPassportNo.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Current Yellow Fever Certificate", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtAccomMemYelFeverCert.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightBlue)), w + 5, TblY - 2, 265, 15);
                gfx.DrawString("Estimated Patient's Weight", fontTextBold, XBrushes.Black, new XRect(w + 8, TblY, page.Width, page.Height), XStringFormat.TopLeft);
                pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, 300, TblY - 2, 285, 15);
                gfx.DrawString(txtMemberWeightHeight.Text, fontText, XBrushes.Black, new XRect(305, TblY, page.Width, page.Height), XStringFormat.TopLeft);

                TblY = TblY + 15;
                gfx.DrawRectangle(pen1, new XSolidBrush(XColor.FromKnownColor(KnownColor.LightGray)), w + 5, TblY - 2, 550, 15);

                h += 650;

                gfx.DrawString("Alliance International Medical Services Pty Ltd.", PatientSummaryfontText, XBrushes.Black, new XRect((page.Width / 2) - 100, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("AIMS House, 3 West Street, Bryanston. Private Bag X5 Benmore 2010.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 120, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Tel: +27 11 783 0135 Fax: +27 11 463 3583 E-mail: operations@aims.org.za", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 130, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Reg. No: 2001/025937/07", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 50, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Directors: B.A. Breton (Managing)", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 60, h, page.Width, page.Height), XStringFormat.TopLeft);

                //Draw the text
                gfx.DrawString(fileHeader, fontText , XBrushes.Black, new XRect(1, 2, page.Width, 200), XStringFormat.Center);

                ///////////////////////////////////////// START - OF - PAGE 3 ////////////////////////////////////////////////////

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

                fileHeader = "Terms and Conditions:";

                // Draw the text
                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 2, page.Width, 200), XStringFormat.Center);

                XFont secondPage = new XFont("Verdana", 7, XFontStyle.Regular);
                XFont secondPageUnderline = new XFont("Verdana", 7, XFontStyle.Bold);

                h += 100;
                gfx.DrawString("1.	This cost estimate is valid for 48 hours.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("2.	This cost estimate is inclusive of local taxes, medical crew, equipment, accommodation costs and fuel surcharges, unless otherwise stated.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("3.	AIMS cannot be held liable for any delays caused by weather, political unrest, non-issuance of clearances, delays caused by applications", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("      for clearances, security threats or any circumstances out of the companies’ control that may adversely affect the mission.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                
                h += 12;
                gfx.DrawString("4.	Cancellation charges may be applicable if the flight is cancelled after being activated, but before the aircraft has taken off from the point of origin.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("5.	The client will be liable for the full amount of the cost estimate if the mission is cancelled post takeoff.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("6.	On arrival at the destination should the patient be found unfit to fly. It will be at the sole discretion of the Chief Medical Officer", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("      representing the Air Ambulance Company to decide whether they will remain at the location for an extended period of Time to reassess", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("      with medical intervention the possibility of improving the medical condition to a point where it is safe to continue with the evacuation.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("7.	In the event that the patient is deemed unfit to continue with the evacuation the running costs of the Evacuation shall remain applicable.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("8.	Final activation of the Medical Evacuation is subject to approval of all documentation including South African Port Health Authorities.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("9.	Please note that this cost estimate excludes the costs of the admission, treatment, assessment, accommodation and transportation of the", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("      patient and any companions, and any other costs not related to the Air Ambulance Mission.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("10.	This Document does not serve to replace an official Letter of Guarantee from your organization, we will require a Letter of Guarantee", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("      clearly stating:", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 30;
                gfx.DrawString("I, the undersigned, confirm that:", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 15;
                gfx.DrawString("•	I have read the above terms and conditions;", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	I accept them as stated above;", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 12;
                gfx.DrawString("•	I am duly authorized to accept the terms and conditions.", secondPage, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);

                h += 50;
                gfx.DrawString("Full Name:", fontText, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 1), 150, h, 400, h);

                h += 20;
                gfx.DrawString("Position:", fontText, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 1), 150, h, 400, h);

                h += 20;
                gfx.DrawString("Date:", fontText, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 1), 150, h, 400, h);

                h += 20;
                gfx.DrawString("Option Accepted:", fontText, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 1), 150, h, 400, h);

                h += 20;
                gfx.DrawString("Amount Accepted:", fontText, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 1), 150, h, 400, h);

                h += 20;
                gfx.DrawString("Signature:", fontText, XBrushes.Black, new XRect((page.Width / 2) - 250, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.Black), 1), 150, h, 400, h);

                h += 100;

                gfx.DrawString("Alliance International Medical Services Pty Ltd.", PatientSummaryfontText, XBrushes.Black, new XRect((page.Width / 2) - 100, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("AIMS House, 3 West Street, Bryanston. Private Bag X5 Benmore 2010.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 120, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Tel: +27 11 783 0135 Fax: +27 11 463 3583 E-mail: operations@aims.org.za", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 130, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Reg. No: 2001/025937/07", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 50, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("Directors: B.A. Breton (Managing)", GuaranteeTermsAndConditions, XBrushes.Black, new XRect((page.Width / 2) - 60, h, page.Width, page.Height), XStringFormat.TopLeft);

                string filename = @"c:\AIMS Recorder\" + System.Guid.NewGuid() + ".pdf";

                document.Save(filename);
                AirAmbulanceCELetter = filename;
                AirAmbulanceCELetter = filename;
                ViewFile();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        private void txtAAAdminFee_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;

            try
            {
                if (txtAAAdminFee.Text.Trim().Length > 0)
                {
                    if (!double.TryParse(txtAAAdminFee.Text, out tmp))
                    {
                        if (txtAAAdminFee.Text.Substring(txtAAAdminFee.Text.Trim().Length - 1, 1) != ".")
                        {
                            if (!double.TryParse(txtAAAdminFee.Text.Trim(), out tmp1))
                            {
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void txtAAAdminFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // allows only numbers, decimals and control characters
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && this.Text.Contains("."))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && this.Text.Length < 1)
                {
                    e.Handled = true;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void cboFlightCostCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadCurrencies()
        {
            DataTable tblCurrencies = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblCurrencies = lookupBLL.GetLookUpValues("code", "currency", "aims_currency", 0, "code");
                cboAdminFeeCurrencies.DataSource = tblCurrencies;
                cboAdminFeeCurrencies.DisplayMember = "code";
                cboAdminFeeCurrencies.ValueMember = "code";
                cboAdminFeeCurrencies.SelectedValue = -1;

                cboFlightCostCurrencies.DataSource = tblCurrencies;
                cboFlightCostCurrencies.DisplayMember = "code";
                cboFlightCostCurrencies.ValueMember = "code";
                cboFlightCostCurrencies.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void cboAdminFeeCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}