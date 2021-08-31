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
using ConvertHTMLToPDF;

namespace AIMSClient
{
    public partial class frmPatientGuarantee : Form
    {
        public frmPatientGuarantee()
        {
            InitializeComponent();
        }
        string opsManagerName = "";
        string opsManagerSignature = "";

        bool filePreviewed = false;
        string PatientGuaranteeFileName = "";
        string _Diagnosis = "";
        string HospitalAdd1 = "";
        string HospitalAdd2 = "";
        string HospitalAdd3 = "";
        string HospitalAdd4 = "";
        string HospitalAdd5 = "";
        string GOPApprovedYN = "N";
        public string Diagnosis
        {
            get { return _Diagnosis; }
            set
            {
                _Diagnosis = value;
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

        string _AdmissionDate = "";
        public string AdmissionDate
        {
            get { return _AdmissionDate; }
            set
            {
                _AdmissionDate = value;
            }
        }

        AIMS.Common.CommonFunctions commonFuncs;
        DataTable tblSuppliers = new DataTable();

        private string _restrictions = string.Empty;
        public string Restrictions
        {
            get { return _restrictions; }
            set
            {
                _restrictions = value;
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

        string _PatientId = "";
        public string PatientID
        {
            get { return _PatientId; }
            set
            {
                _PatientId = value;
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

        Int32 _Hospital;
        public Int32 Hospital
        {
            get { return _Hospital; }
            set
            {
                _Hospital = value;
            }
        }

        Int32 _GuarantorID;
        public Int32 GuarantorID
        {
            get { return _GuarantorID; }
            set
            {
                _GuarantorID = value;
            }
        }

        string _Guarantor = "";
        public string Guarantor
        {
            get { return _Guarantor; }
            set
            {
                _Guarantor = value;
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

        string _UserFullName = "";
        public string UserFullName
        {
            get { return _UserFullName; }
            set
            {
                _UserFullName = value;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmPatientGuarantee_Load(object sender, EventArgs e)
        {
            commonFuncs = new AIMS.Common.CommonFunctions();
            
            LoadSuppliers();
            LoadWardTypes();
            LoadRoomTypes();
            LoadCurrencies();
            //LoadAdmissionCodes();
            txtGuaranteePatientFileNo.Text = PatientFileNo;
            txtGuaranteePatientName.Text = PatientName;
            txtGuaranteeAdmissionDt.Text = AdmissionDate;
            cboGuaranteeHospital.SelectedValue = System.Convert.ToInt32(Hospital);
            txtDOB.Text = PatientDOB;

            DataTable dtHospitalDetails = commonFuncs.GetSupplierDetails(Hospital.ToString());
            if (dtHospitalDetails.Rows.Count > 0)
            {
                HospitalAdd1 = dtHospitalDetails.Rows[0]["ADDRESS1"].ToString();
                HospitalAdd2 = dtHospitalDetails.Rows[0]["ADDRESS2"].ToString();
                HospitalAdd3 = dtHospitalDetails.Rows[0]["ADDRESS3"].ToString();
                HospitalAdd4 = dtHospitalDetails.Rows[0]["ADDRESS4"].ToString();
                HospitalAdd5 = dtHospitalDetails.Rows[0]["ADDRESS5"].ToString();
            }
            txtGuaranteeDiagnosis.Text = Diagnosis;
            LoadPatientServiceProviders();
            LoadHospitals();
            PatientGuaranteeFileName = "";
            /*
            decimal txtGuarantAmount = System.Convert.ToDecimal(GuaranteeAmount.Replace(" ", ""));
            lblGOPAmnt.Text = txtGuarantAmount.ToString("C");
            this.Text = this.Text + "   [ Guarantee Amount: " + lblGOPAmnt.Text + " ]";
             */
        }

        private void LoadHospitals() 
        { 
        }

        private void LoadSuppliers()
        {
            tblSuppliers = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblSuppliers = lookupBLL.GetHospitalsLookUpValues("SUPPLIER_ID", "SUPPLIER_NAME", "AIMS_SUPPLIER", 0);
                cboGuaranteeHospital.DataSource = tblSuppliers;
                cboGuaranteeHospital.DisplayMember = "SUPPLIER_NAME";
                cboGuaranteeHospital.ValueMember = "SUPPLIER_ID";
                cboGuaranteeHospital.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadWardTypes()
        {
            tblSuppliers = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblSuppliers = lookupBLL.GetLookUpValues("WARD_TYPE_ID", "WARD_TYPE", "AIMS_WARD_TYPES", 0, "");
                cboWardType.DataSource = tblSuppliers;
                cboWardType.DisplayMember = "WARD_TYPE";
                cboWardType.ValueMember = "WARD_TYPE_ID";
                cboWardType.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void LoadAdmissionCodes()
        {
            tblSuppliers = new DataTable();
            AIMS.BLL.LookUpTableCollections lookupBLL = new LookUpTableCollections();

            try
            {
                tblSuppliers = lookupBLL.GetLookUpValues("ADMISSION_CODE_ID", "ADMISSION_CODE", "AIMS_ADMISSION_CODES", 0, "");
                cboGuaranteeAdmissionCode.DataSource = tblSuppliers;
                cboGuaranteeAdmissionCode.DisplayMember = "ADMISSION_CODE";
                cboGuaranteeAdmissionCode.ValueMember = "ADMISSION_CODE_ID";
                cboGuaranteeAdmissionCode.SelectedValue = -1;
                cboGuaranteeAdmissionCode.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, ex.Message);
            }
        }

        private void btnGuaranteePreview_Click(object sender, EventArgs e)
        {
            try
            {
                bool bDataCapturedValid = ValidateControl();

                if (!bDataCapturedValid)
                {
                   return;
                }

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

                //FormatHospital(ref HospitalAdd1, ref HospitalAdd2, ref HospitalAdd3, ref HospitalAdd4, ref HospitalAdd5);
                //GuaranteePayment("Late Guarantee");
                /*
                createAIMSNewGuarantee(ref PatientGuaranteeFileName, cboGuaranteeHospital.Text, HospitalAdd1, HospitalAdd2, HospitalAdd3, HospitalAdd4, HospitalAdd5,
                                            txtGuaranteeATT.Text, cboGuaranteeAdmissionCode.Text, txtGuaranteePatientName.Text, txtGuaranteeAdmissionDt.Text, cboGuaranteeAdmittingDoctor.Text,
                                          PatientFileNo, txtGuaranteeDiagnosis.Text, lblGuaranteeAmt.Text.Replace("R", ""), UserFullName, lblExcessAmt.Text, cboWardType.Text);

                */

                if (File.Exists(PatientGuaranteeFileName))
                {
                    File.Delete(PatientGuaranteeFileName);
                }
                createAIMSNewGuarantee(ref PatientGuaranteeFileName, cboGuaranteeHospital.Text, txtContactNumber.Text,
                                                txtEmailAddress.Text, txtGuaranteePatientName.Text,
                                                txtDOB.Text, txtGuaranteePatientFileNo.Text,
                                                txtConsolidatedAmt.Text, dtGOPStartDate.Text,
                                                dtGOPEndDate.Text, txtGuaranteeDiagnosis.Text,
                                                txtCoPaymentDue.Text, cboRoomType.Text, txtAdditionalNotes.Text);

                
                if (!PatientGuaranteeFileName.Equals("") && File.Exists(PatientGuaranteeFileName))
                {
                    ViewFile();
                } 
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Guarantee preview error, Please contact System Administrator");
                commonFuncs.ErrorLogger("Guarantee preview error: " + ex.ToString());
            }
        }

        private bool ValidateControl() 
        {
            bool ReturnValue = true;
            try
            {
                errProvider.Clear();

                if (txtGuaranteeDiagnosis.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtGuaranteeDiagnosis, "Please Capture Diagnosis");
                    txtGuaranteeDiagnosis.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtContactNumber.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtContactNumber, "Please Capture Contact Number");
                    txtContactNumber.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (GuaranteeAmount.Trim().Equals(""))
                {
                    errProvider.SetError(txtConsolidatedAmt, "Guarantee amount not updated. Please update on Patient File Details.");
                    txtConsolidatedAmt.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtDOB.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtDOB, "Please capture Date-Of-Birth.");
                    txtDOB.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtConsolidatedAmt.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtConsolidatedAmt, "Consolidated Amount not captured, Please check.");
                    txtConsolidatedAmt.Focus();
                    ReturnValue = false;
                    return ReturnValue;    
                }

                if (txtConsolidatedAmt.Text.Trim().Length > 0)
                {
                    double PatientFileGuaranteeAmt = 0.0;
                    double TreatmentGuaranteeAmt = 0.0;

                    PatientFileGuaranteeAmt = System.Convert.ToDouble(GuaranteeAmount);
                    TreatmentGuaranteeAmt = System.Convert.ToDouble(txtConsolidatedAmt.Text);
                    if (TreatmentGuaranteeAmt > PatientFileGuaranteeAmt)
                    {
                        errProvider.SetError(txtConsolidatedAmt, "Consolidated Guarantee Amount exceeds Guarantee of Payment amount.");
                        txtConsolidatedAmt.Focus();
                        ReturnValue = false;
                        return ReturnValue;
                    }
                    else
                    {
                        //DataTable dtUserAuthMatrix = commonFuncs.CheckGuaranteeAuth(UserID, txtGuaranteeAmt.Text, GuarantorID.ToString());
                        //if (dtUserAuthMatrix.Rows.Count > 0 )
                        //{
                        //    bool UserFound = false;
                        //    foreach (DataRow  dtRow in dtUserAuthMatrix.Rows)
                        //    {
                        //        if (dtRow["USER_ID"].Equals(UserID))
                        //        {
                        //            UserFound = true;
                        //            break;
                        //        }
                        //    }

                        //    if (!UserFound)
                        //    {
                        //        commonFuncs.DisplayMessage(CommonTypes.MessagType.Warning, "You are not authorised to create and send a guarantee on this Patient File.\n\n Please consult your Team-Lead.");
                        //        ReturnValue = false;
                        //        return ReturnValue;
                        //    }
                        //}
                    }
                }
                else
                {
                    errProvider.SetError(txtConsolidatedAmt, "Please Capture Consolidated Amount");
                    txtConsolidatedAmt.Focus();
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
                System.TimeSpan diffResult = DateTime.Today.Date - System.Convert.ToDateTime(dtGOPStartDate.Text);
                if (diffResult.Days < 0)
                {
                    ReturnValue = false;
                    dtGOPEndDate.Focus();
                    errProvider.SetError(dtGOPStartDate, "GOP Start Date cannot be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                diffResult = System.Convert.ToDateTime(dtGOPEndDate.Text) - DateTime.Today.Date;
                if (diffResult.Days < 0)
                {
                    ReturnValue = false;
                    dtGOPEndDate.Focus();
                    errProvider.SetError(dtGOPEndDate, "GOP End Date must be a future date");
                    ReturnValue = false;
                    return ReturnValue;
                }

                CommonFunctions cmmFuncs = new CommonFunctions();
                if (!cmmFuncs.ValidEmailAddress(txtEmailAddress.Text))
                {
                    errProvider.SetError(txtEmailAddress, "Please capture Valid Email Address");
                    txtEmailAddress.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (txtGuaranteeDiagnosis.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtGuaranteeDiagnosis, "Please Capture Diagnosis");
                    txtGuaranteeDiagnosis.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboGuaranteeHospital.SelectedItem == null)
                {
                    errProvider.SetError(cboGuaranteeHospital, "Please select a Hospital");
                    cboGuaranteeHospital.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboGuaranteeHospital.SelectedItem != null && (cboGuaranteeHospital.Text == ""))
                {
                    errProvider.SetError(cboGuaranteeHospital, "Please select a Hospital");
                    cboGuaranteeHospital.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                /*
                if (txtGuaranteeATT.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtGuaranteeATT, "Please Capture Attention");
                    txtGuaranteeATT.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }


                if (cboGuaranteeAdmittingDoctor.SelectedItem == null)
                {
                    errProvider.SetError(cboGuaranteeAdmittingDoctor, "Please select a Admitting Doctor");
                    cboGuaranteeAdmittingDoctor.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboGuaranteeAdmittingDoctor.SelectedItem != null && (cboGuaranteeAdmittingDoctor.Text == ""))
                {
                    errProvider.SetError(cboGuaranteeAdmittingDoctor, "Please select a Admitting Doctor");
                    cboGuaranteeAdmittingDoctor.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboGuaranteeAdmissionCode.SelectedItem == null)
                {
                    errProvider.SetError(cboGuaranteeAdmissionCode, "Please select Admission Code");
                    cboGuaranteeAdmissionCode.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboGuaranteeAdmissionCode.SelectedItem != null && (cboGuaranteeAdmissionCode.Text == ""))
                {
                    errProvider.SetError(cboGuaranteeAdmissionCode, "Please select Admission Code");
                    cboGuaranteeAdmissionCode.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboGuaranteeAdmissionCode.Text.Contains("Other") && txtOtherAdmissionCode.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtOtherAdmissionCode, "Please Capture Admission Code Other");
                    txtOtherAdmissionCode.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (chkPolicyExcess.Checked && txtGuaranteeExcess.Text.Trim().Equals(""))
                {
                    errProvider.SetError(txtGuaranteeExcess, "Please Capture Guarantee Excess");
                    txtGuaranteeExcess.Focus();
                    ReturnValue = false;
                    return ReturnValue;                    
                }
                

                if (cboWardType.SelectedItem == null)
                {
                    errProvider.SetError(cboWardType, "Please select a Admission Ward-Type");
                    cboWardType.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }

                if (cboWardType.SelectedItem != null && (cboWardType.Text == ""))
                {
                    errProvider.SetError(cboWardType, "Please select a Admission Ward-Type");
                    cboWardType.Focus();
                    ReturnValue = false;
                    return ReturnValue;
                }
                 */
            }
            finally
            {
                
            }
            return ReturnValue;
        }

        private void cboGuaranteeAdmittingDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool CheckAndSendForApproval()
        {
            try
            {
                string UserAuthMatrixClass = "";
                

            }
            catch (System.Exception ex)
            {
                throw;
            }
            return false;
        }

        private bool GOPRunningTotalLimit()
        {
            commonFuncs = new CommonFunctions();
            return commonFuncs.GOPRunningTotalLimit(PatientID, txtConsolidatedAmt.Text);
        }

        private bool UserGOPOverLimit()
        {
            commonFuncs = new CommonFunctions();
            return commonFuncs.UserGOPOverLimit(txtConsolidatedAmt.Text, UserID, PatientID);
        }

        private string GetLetterOfGuarantee()
        {
            frmGuarantorGOP frmGOPLetter = new frmGuarantorGOP();
            frmGOPLetter.PatientID = PatientID;
            frmGOPLetter.Text = "Select Letter-Of-Guarantee";
            frmGOPLetter.StartPosition = FormStartPosition.CenterParent;
            frmGOPLetter.ShowDialog();
            return frmGOPLetter.EmailGOPID;
        }

        private string sAuthReplyEmail(string AuthResponse)
        {
            string EmailBody = "";
            EmailBody = "<html>" +
                        "<head>" +
                        "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left}</style>" +
                        "</head>" +
                        "<body>" +
                        "    <br>" +
                        "    <br>" +
                        "    <br>" +
                        "    <br>" +
                        "    <table width=50% cellpadding=2 cellspacing=1 align=center>" +
                        "<tr>" +
                        @"<td colspan=4 bgcolor=#efefef width=50% align=center><font color=green size=4><b>" + AuthResponse.ToUpper() + "</b></font></td></tr>" +
                        "<tr>" +
                        "<td bgcolor=lightgrey valign=bottom colspan=4><b>Patient File Details</b></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient File No</td>" +
                        "<td colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + PatientFileNo + "</b></font></td> " +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Guarantee Amount</td>" +
                        "<td colspan=2 bgcolor=#efefef width=50% align=left><font size=2 color=RED><b>" + lblGuaranteeAmt.Text  + "</b></font></td> " +
                        "</tr>" +

                        "</table>" +
                        "<br>" +
                        "<br>" +
                        "</body>" +
                        "</html>";

            return EmailBody;
        }

        private string ApprovalEmailBody()
        {
            string EmailBody = "";
            EmailBody = "<html>" +
                        "<head>" +
                        "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left}</style>" +
                        "</head>" +
                        "<body>" +
                        "    <br>" +
                        "    <br>" +
                        "    <br>" +
                        "    <br>" +
                        "    <table width=50% cellpadding=2 cellspacing=1 align=center>" +
                        "<tr>" +
                        "<td colspan=4 align=left bgcolor=lightgrey>" +
                        "<center><b><font color=green size=2 >REQUEST FOR APPROVAL on GOP</font></b></center>" +
                        "</td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=lightgrey valign=bottom colspan=4><b>Patient File Details</b></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient File No</td>" +
                        "<td colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + PatientFileNo + "</b></font></td> " +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Patient Name</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + PatientName + "</b></font></td> " +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>GOP Days Covered (GOP Period)</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + dtGOPStartDate.Text + " -TO- "+ dtGOPEndDate.Text +"</b></font></td> " +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=lightgrey valign=bottom colspan=4><b>Guarantor Details</b></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Insurance</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + Guarantor + "</b></font></td> " +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Insurance Guarantee Amount (Consolidated)</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>" + GuaranteeAmount + "</b></font></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>GOP For Authorization</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red size=2><b>" + txtConsolidatedAmt.Text + "</b></font></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=lightgrey valign=bottom colspan=4><b>Service Provider Details</b></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Hospital</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + cboGuaranteeHospital.Text + "</b></font></td>" +
                        "</tr>" +

                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Admitting Doctor</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + cboGuaranteeAdmittingDoctor.Text + "</b></font></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=#ffffff width=100% style=TEXT-TRANSFORM: capitalize colspan=4>&nbsp;</td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=lightgrey valign=bottom colspan=4><b>Date and Co-Ordinator Information</b></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>GOP Captured By</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=green size=2><b>" + UserFullName + "</b></font></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>Date</td>" +
                        "<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=green size=2><b>" + System.DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss") + "</b></font></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td bgcolor=#ffffff colspan=4>&nbsp; </td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td colspan=4 align=left bgcolor=lightgrey>" +
                        "<center><b><font color=green size=2 >&nbsp;</font></b></center>" +
                        "</td>" +
                        "</tr>" +
                        "<tr>" +
                        //@"<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=green size=2><b><a href='mailto:operation@AIMS.org.za?Subject='URGENT: GOP APPROVED ["+ PatientFileNo+"]'&Body='"+ sAuthReplyEmail("GOP APPROVED") +"''>APPROVE</a></b></font></td>" +
                        //@"<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=red   size=2><b><a href='mailto:operation@AIMS.org.za'?Subject='URGENT: GOP DECLINED ["+ PatientFileNo+"]'&Body='"+ sAuthReplyEmail("GOP DECLINED") +"'>DECLINE</a></b></font></td>" +
                        @"<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=green size=2><b><a href='mailto:operation@AIMS.org.za?Subject=URGENT:GOP AUTHORICATION: APPROVED - [" + PatientFileNo + "]&Body=APPROVED - AMOUNT: "+ lblConsolidatedAmt.Text +"'>APPROVE</a></b></font></td>" +
                        @"<td  colspan=2 bgcolor=#efefef width=50% align=left><font color=green size=2><b><a href='mailto:operation@AIMS.org.za?Subject=URGENT:GOP AUTHORICATION: DECLINED - [" + PatientFileNo + "]&Body=DECLINED - AMOUNT: " + lblConsolidatedAmt.Text + "'>DECLINE</a></b></font></td>" +

                        "</table>" +
                        "<br>" +
                        "<br>" +
                        "</body>" +
                        "</html>";
            
            return EmailBody;
        }
        private string ApprovalEmailBody(string GOPAmount)
        {
            string EmailBody = "<html>"+
                        "<body>"+
                        "<p><b>REQUEST FOR APPROVAL on GOP</b><hr/></p>"+
                        "<p>Patient Name : "+ UserFullName +"</p>" +
                        "<p>Patient File : "+ PatientFileNo +"</p>"+
                        "<p>Patient Name : "+ PatientName+"</p>"+
                        "<p>Patient Name : " + PatientName + "</p>" +
                        "<p>GOP Amount : <font color=RED size=4>" + lblConsolidatedAmt.Text + "</font></p>" +
                        @"<a href=""mailto:operation@AIMS.org.za?Subject=GOP APPROVED&Body=GOP APPROVED"">APPROVED</a></td>"+
                        @"<a href=""mailto:operation@AIMS.org.za?Subject=GOP DECLINED&Body=GOP DECLINED [REASON:]"">DECLINED</a>" +
                        "</body>"+
                        "</html>";
            return EmailBody;
        }

        private void btnGuaranteeCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!filePreviewed || PatientGuaranteeFileName.Trim().Equals(""))
                {
                    MessageBox.Show("Please preview document", "Please preview: " + TemplateName, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                DialogResult dbDialog = MessageBox.Show("Continue creating the Patient-Guarantee", "Confirm Guarantee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dbDialog == DialogResult.Yes)
                {
                    if (ValidateControl())
                    {
                        bool bRunningTotalLimitReached = GOPRunningTotalLimit();
                        if (bRunningTotalLimitReached)
                        {
                            commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "GOP cannot be created, Limit reached.");
                            return;
                        }

                        bool bGOPUserLimit = UserGOPOverLimit();
                        if (!bGOPUserLimit)
                        {
                            GOPApprovedYN = "Y";
                        }

                        if (bGOPUserLimit && !chkApprovalReceived.Checked)
                        {
                            commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "GOP Amount Over your Limit, Please request Approval.");
                            return;
                        }else if (bGOPUserLimit && chkApprovalReceived.Checked)     
                        {
                            string bLetterOfGuarantorID = GetLetterOfGuarantee();
                            if (!bLetterOfGuarantorID.Trim().Equals(""))
                            {
                                string emailBody = ApprovalEmailBody();
                                string EmailAttachments = "";
                                DataTable dtParamVal = commonFuncs.GetLimitationCodeValue("ON-CALL_EMAIL_LIST");
                                string sToEmailAddress = "";
                                if (dtParamVal.Rows.Count > 0 )
                                {
                                    sToEmailAddress = dtParamVal.Rows[0]["LIMITATION_VALUE"].ToString();
                                }
                                else
	                            {
                                    sToEmailAddress = "HugoM@AIMS.org.za;DanielM@AIMS.org.za;StanleyN@AIMS.org.za";
	                            }
                                EmailAttachments = bLetterOfGuarantorID;
                                bool bEmailSent = commonFuncs.SendEmail(emailBody, "Operation@AIMS.org.za", "Operation", "REQUEST FOR APPROVAL on GOP - URGENT", sToEmailAddress, EmailAttachments, false, "", "",PatientFileNo, PatientDOB, false );
                                PatientGuaranteeFileName = "";
                                if (!bEmailSent)
                                {
                                    commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Request-For-Authorizatiion Email transmission failure, Please try again.");
                                    return;
                                }
                            }
                            else
                            {
                                //commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Letter-Of-Guarantor not found, Please Check Email Correspondence");
                                return;
                            }
                        }
                            
                        if (PatientGuaranteeFileName.Equals(""))
                        {
                            commonFuncs.DisplayMessage(CommonTypes.MessagType.Warning, "Please preview the GOP before saving");
                            return;
                        }
                        else
                        {
                            DataTable dtLimitation = commonFuncs.GetLimitationCodeValue("AIMS_EMAIL_POD_GOP");
                            if (!dtLimitation.Rows.Count.Equals(0))
                            {
                                string GuaranteePOD = dtLimitation.Rows[0]["LIMITATION_VALUE"].ToString();
                                string GuaranteeMonth = System.DateTime.Now.ToString("MMMM");
                                string GuaranteeYear = System.DateTime.Now.Year.ToString();
                                string GuaranteeFile = Path.Combine( @GuaranteePOD , GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy") + @"\" + PatientFileNo.Substring(3) + "_" + Path.GetFileName(PatientGuaranteeFileName));

                                if (!Directory.Exists(@GuaranteePOD + GuaranteeYear)) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear); }
                                if (!Directory.Exists(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth)) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth); }
                                if (!Directory.Exists(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy"))) { Directory.CreateDirectory(@GuaranteePOD + GuaranteeYear + @"\" + GuaranteeMonth + @"\" + System.DateTime.Now.ToString("ddMMMyyyy")); }

                                if (!File.Exists(GuaranteeFile))
                                {
                                    File.Copy(@PatientGuaranteeFileName, GuaranteeFile);
                                }

                                if (File.Exists(GuaranteeFile))
                                {
                                    bool bGuaranteeCreated = SaveGOPArchive(GuaranteeFile);
                                    if (bGuaranteeCreated)
                                    {
                                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Success, "GOP created successfully.");
                                        try
                                        {
                                            File.SetAttributes(@PatientGuaranteeFileName, FileAttributes.Normal);
                                            File.Delete(@PatientGuaranteeFileName);
                                        }
                                        catch (Exception)
                                        {
                                            commonFuncs.ErrorLogger("Deleting File: " + @PatientGuaranteeFileName + " failure");
                                        }
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "GOP NOT successfully created, please contact system administrator.");
                                        File.SetAttributes(@GuaranteeFile, FileAttributes.Normal);
                                        File.Delete(@GuaranteeFile);
                                    }
                                }
                                else
                                {
                                    commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Error generating GOP, Please review the GOP Form and try again.");
                                    File.SetAttributes(@PatientGuaranteeFileName, FileAttributes.Normal);
                                    File.Delete(@PatientGuaranteeFileName);
                                }
                            }
                        }
                    }   
                }
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(CommonTypes.MessagType.Error, "Problem creating Guarantee");
                commonFuncs.ErrorLogger("Problem creating Guarantee: \n" + ex.ToString());
            }
        }

        private bool SaveGOPArchive(string GuaranteeFile)
        {
            Patient clsPatient = new Patient();
            AIMS.DAL.PatientDAL _PatientDAL = new AIMS.DAL.PatientDAL();
            string GuaranteeID = "";
            bool ReturnValue = false;
            try
            {
                _PatientDAL.PatientID = System.Convert.ToInt32(PatientID);
                _PatientDAL.GuaranteeID = lblGuaranteeID.Text.Equals("") ? 0 : System.Convert.ToInt32(lblGuaranteeID.Text);
                _PatientDAL.GuaranteeHospitalID = System.Convert.ToInt32(cboGuaranteeHospital.SelectedValue);
                _PatientDAL.GuaranteeContactName = txtContactNumber.Text;
                _PatientDAL.GuaranteeEmailAddress = txtEmailAddress.Text;
                _PatientDAL.GuaranteeConsolidateAmount = txtConsolidatedAmt.Text;
                _PatientDAL.GuaranteePatientFileNo = txtGuaranteePatientFileNo.Text;
                _PatientDAL.GuaranteeDiagnosis = txtGuaranteeDiagnosis.Text;
                _PatientDAL.GuaranteeRoomTypeID = System.Convert.ToInt32(cboRoomType.SelectedValue);
                _PatientDAL.GOPApprovedYN = GOPApprovedYN;
                _PatientDAL.GuaranteeStartDate = dtGOPStartDate.Text.ToString();
                _PatientDAL.GuaranteeEndDate = dtGOPEndDate.Text.ToString();
                _PatientDAL.GuaranteeNotes = txtGuaranteeComments.Text;
                _PatientDAL.SavePatientGuarantee(ref GuaranteeID, _PatientDAL, UserID, GuaranteeFile, UserID , cboCurrencies.Text);
                
                ReturnValue = true;
            }
            catch (System.Exception ex)
            {
                ReturnValue = false;
                commonFuncs.ErrorLogger("Problem Saving Guarantee Archive: \n" + ex.ToString());
            }
            return ReturnValue;
        }

        private void CreateGuaranteeOutput() 
        {

        }

        private void LoadPatientServiceProviders()
        {
            DataTable dsPatientServiceProviders = new DataTable(); ;
            
            AIMS.BLL.Supplier supplierBLL = new Supplier();

            dsPatientServiceProviders = supplierBLL.GetPatientServiceProviders(PatientID);
            
            try
            {
                cboGuaranteeAdmittingDoctor.DataSource = dsPatientServiceProviders;
                cboGuaranteeAdmittingDoctor.DisplayMember = "SERVICE_PROVIDER_NAME";
                cboGuaranteeAdmittingDoctor.ValueMember = "SERVICE_PROVIDER_ID";
                cboGuaranteeAdmittingDoctor.SelectedValue = -1;
            }
            catch (System.Exception ex)
            {
                commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Loading patient service providers Failed : Error - " + ex.Message);
                throw;
            }
            finally
            {
                supplierBLL = null;
            }
        }

        private void createAIMSNewGuarantee(ref string AccomodationVoucher, string cboGuaranteeHospital,
                                            string txtContactNumber, string txtEmailAddress,
                                            string txtGuaranteePatientName,string txtDOB ,
                                            string txtGuaranteePatientFileNo ,string txtConsolidatedAmt, 
                                            string dtGOPStartDate ,string dtGOPEndDate, 
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
                gfx.DrawString(lblConsolidatedAmt.Text, fontCurrency, XBrushes.Red, new XRect(272, TblY, page.Width, page.Height), XStringFormat.TopLeft);

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
                gfx.DrawImage(image, 50, h, (image.Width /2), (image.Height/2));
                image = XImage.FromFile(opsManagerSignature);
                gfx.DrawImage(image, 300, h+10, (image.Width / 2), (image.Height / 2));

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
                PatientGuaranteeFileName = filename;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        private void createAIMSNewGuarantee(ref string PatientGuaranteeFile, string HospitalName, string HospitalAdd1, string HospitalAdd2, string HospitalAdd3, string HospitalAdd4, string HospitalAdd5, 
                                            string AttentionOf, string AdmissionCode, string PatientName, string AdmissionDate, string AdmittingDoctor,
                                          string AimsRefNo, string Diagnosis, string GuaranteeAmount, string CoOrdinator, string ExcessAmount, string WardType)
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
                XFont GuaranteeTermsAndConditions = new XFont("Verdana", 8, XFontStyle.Regular);
                XFont BillingInfo = new XFont("Verdana", 8, XFontStyle.Regular);
                XFont fontTextBold = new XFont("Verdana", 8, XFontStyle.Bold);

                int w = 30;
                int h = 90;

                XImage image = XImage.FromFile(@"c:\AIMSLOGO.png");

                double dx = 1110, dy = 70;

                double width = image.Width *50 / image.HorizontalResolution;
                double height = image.Height *50 / image.HorizontalResolution;

                gfx.DrawImage(image, 150, 20, width, height);

                string fileHeader = string.Empty;

                //fileHeader = "AIMS";
                //string CompanyName = "Alliance International Medical Services (PTY) Ltd";
                string CompanyName = "";
                string CompanyRegNr = "Reg No: 2001/025937/07";

                gfx.DrawString(fileHeader, fontHeader, XBrushes.Black, new XRect(1, 2, page.Width, h), XStringFormat.Center);
                h += 30;
                gfx.DrawString(CompanyName, fontHeader, XBrushes.Black, new XRect(1, 2, page.Width, h), XStringFormat.Center);

                h += 25;
                gfx.DrawString(CompanyRegNr, fontText, XBrushes.Black, new XRect(1, 2, page.Width, h), XStringFormat.Center);

                h = h - 10;
                gfx.DrawString(HospitalName, PatientSummaryfontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(HospitalAdd1, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(HospitalAdd2, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(HospitalAdd3, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(HospitalAdd4, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString(HospitalAdd5, fontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(System.DateTime.Today.ToLongDateString(), fontText, XBrushes.Black, new XRect(500, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;
                gfx.DrawString("Attention of: ", PatientSummaryfontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(AttentionOf, fontText, XBrushes.Black, new XRect(100, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                //Admission Code
                XPen pen1 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen1, w, h, 75, 15);

                gfx.DrawString("Admission Code", fontText, XBrushes.Black, new XRect(w + 5, h + 2, page.Width, page.Height), XStringFormat.TopLeft);
                

                XPen pen2 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen2, w + 75, h, 75, 15);

                gfx.DrawString(AdmissionCode , fontText, XBrushes.Black, new XRect((w + 75) + 5, h + 2, page.Width, page.Height), XStringFormat.TopLeft);

                //Patient Name
                int w1 = w;
                int h1 = h;
                w1 += 75;
                h1 += 2;

                XPen pen3 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen3, w1 + 75, h, 75, 15);
                w1 += 75;
                gfx.DrawString("Patient Name", fontText, XBrushes.Black, new XRect(w1 + 5, h1 + 2, page.Width, page.Height), XStringFormat.TopLeft);

                XPen pen4 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen4, w1 + 75, h, 300, 15);

                gfx.DrawString(PatientName , fontText, XBrushes.Black, new XRect((w + 230) + 5, h1 + 2, page.Width, page.Height), XStringFormat.TopLeft);
                h += 15;

                //Admission Date
                XPen pen5 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen5, w, h, 75, 15);

                gfx.DrawString("Admission Date", fontText, XBrushes.Black, new XRect(w + 5, h + 2, page.Width, page.Height), XStringFormat.TopLeft);
                

                XPen pen6 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen6, w + 75, h, 75, 15);

                gfx.DrawString(AdmissionDate, fontText, XBrushes.Black, new XRect((w + 75) + 5, h + 2, page.Width, page.Height), XStringFormat.TopLeft);

                //Admitting Doctor
                w1 = w;
                h1 += 14;
                w1 += 75;
                XPen pen7 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen7, w1 + 75, h, 75, 15);
                gfx.DrawString("Admitting Doctor", fontText, XBrushes.Black, new XRect((w1 + 75) + 5, h1, page.Width, page.Height), XStringFormat.TopLeft);

                w1 += 75;
                XPen pen8 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen8, w1 + 75, h, 300, 15);
                gfx.DrawString(AdmittingDoctor , fontText, XBrushes.Black, new XRect((w + 230) + 5, h1 + 2, page.Width, page.Height), XStringFormat.TopLeft);

                h += 15;

                //Diagnosis
                XPen pen9 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen9, w, h, 75, 15);
                XPen pen12 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen12, w + 75, h, 75, 15);


                gfx.DrawString("Our Reference", fontText, XBrushes.Black, new XRect(w + 5, h + 2, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString(AimsRefNo, fontText, XBrushes.Black, new XRect((w + 75) + 5, h + 2, page.Width, page.Height), XStringFormat.TopLeft);

                //Our Reference
                w1 = w;
                h1 += 14;
                w1 += 75;
                XPen pen10 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen10, w1 + 75, h, 75, 15);
                gfx.DrawString("Diagnosis", fontText, XBrushes.Black, new XRect((w1 + 75) + 5, h1, page.Width, page.Height), XStringFormat.TopLeft);

                w1 += 75;
                XPen pen11 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen11, w1 + 75, h, 300, 15);
                gfx.DrawString(Diagnosis, fontText, XBrushes.Black, new XRect((w + 230) + 5, h1 + 2, page.Width, page.Height), XStringFormat.TopLeft);

                h += 30;

                gfx.DrawString("Alliance International Medical Services (AIMS) do hereby guarantee ZAR " + GuaranteeAmount + " consolidated of all reasonable and customary costs;", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("all accounts rendered will be audited.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("Investigation and procedures relevant to the stated diagnosis is covered, any other medical intervention(s) deemed necessary must be ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("authorised  and where necessary motivational documentation supporting such procedures issued. Any costs arising from matters of a ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("personal nature to the patient such as; telephone calls, newspapers, laundry, television, mini bar and Wi-Fi connection will not be covered ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("and should be settled by the patient.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("AIMS reserves the right to retract this guarantee in the event that any information comes to light invalidating the patient’s policy and ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("therefore eligibility to the benefits as per the policy terms and conditions.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("Hospital accommodation is authorised within this guarantee on a General Ward basis, Semi and Private Wards require prior approval from ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("AIMS.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("The letter of guarantee will remain valid for all and any matters relevant to the stipulated diagnosis documented above until the named ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("patients discharge from hospital. Please note the attached instructions with regard to the patients deductable (this will only appear if a ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("deductable is relevant)", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("Payment will be issued within thirty (30) days from the patients discharge and payments will be made by us on either the 15th or 30th of ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("the month. Itemised invoices must be sent to our Administration Department within 5 working days of the patients discharge together ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("with the discharge report and your banking details. Please note we cannot accept faxed or scanned invoices, however emailed invoices are ", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 10;
                gfx.DrawString("acceptable and encouraged.", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("Invoices received late are not subject to the above payment terms.", PatientSummaryfontText, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("Should you require any further assistance please do not hesitate to contact us?", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                gfx.DrawString("Yours sincerely", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;

                //Diagnosis
                XPen pen13 = new XPen(XColors.Black, 1);
                gfx.DrawRectangle(pen13, w + 250, h, 300, 40);

                int h2 = h;
                gfx.DrawString("For all billing and payment enquiries please contact the Admin", PatientSummaryfontText, XBrushes.Red, new XRect((w + 250) + 5, h2 + 2, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString("Department on +27 11 783 0135 or email admin@aims.org.za.", PatientSummaryfontText, XBrushes.Red, new XRect((w + 250) + 5, h2 + 14, page.Width, page.Height), XStringFormat.TopLeft);
                gfx.DrawString("Our postal address is Private Bag X5 Benmore 2010 RSA", PatientSummaryfontText, XBrushes.Red, new XRect((w + 250) + 5, h2 + 26, page.Width, page.Height), XStringFormat.TopLeft);

                h += 50;
                gfx.DrawString(CoOrdinator , GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;
                gfx.DrawString("Tel + 27 11 783 0135", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);
                h += 20;
                gfx.DrawString("Email operations@aims.org.za", GuaranteeTermsAndConditions, XBrushes.Black, new XRect(w, h, page.Width, page.Height), XStringFormat.TopLeft);

                string filename = @"c:\AIMS Recorder\" + System.Guid.NewGuid() + ".pdf";

                document.Save(filename);

                PatientGuaranteeFileName = filename;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        private void cboGuaranteeHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGuaranteeHospital.SelectedItem != null && cboGuaranteeHospital.SelectedValue != "")
            {
                if (cboGuaranteeHospital.SelectedIndex > 0)
                {
                    if (cboGuaranteeHospital.SelectedValue != null)
                    {
                    }
                }
            }
        }

        private void txtGuaranteeAdmissionDt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGuaranteeAdmissionDt_DoubleClick(object sender, EventArgs e)
        {
            UserControls.frmCalendar frmCal = new UserControls.frmCalendar();
            frmCal.Width = 250;
            frmCal.ShowDialog(this);
            if (DateTime.Parse(frmCal.StartDate.ToShortDateString()).Year > 1)
            {
                txtGuaranteeAdmissionDt.Text = frmCal.StartDate.ToShortDateString();
            }
            txtGuaranteeAdmissionDt.Focus();
        }


        private void txtGuaranteeAmt_KeyDown(object sender, KeyEventArgs e)
        {       
        }

        private void txtGuaranteeExcess_KeyPress(object sender, KeyPressEventArgs e)
        {
            errProvider.Clear();
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

        private void txtGuaranteeAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            errProvider.Clear();
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


        private void txtGuaranteeExcess_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;
            string NewInvoiceAmt = "";
            errProvider.Clear();
            try
            {
                if (txtGuaranteeExcess.Text.Trim().Length > 0)
                {
                    if (!double.TryParse(txtGuaranteeExcess.Text, out tmp))
                    {
                        if (txtGuaranteeExcess.Text.Substring(txtGuaranteeExcess.Text.Trim().Length - 1, 1) != ".")
                        {
                            if (!double.TryParse(txtGuaranteeExcess.Text.Trim(), out tmp1))
                            {
                            }
                        }
                    }
                    decimal txtExcessAmount = System.Convert.ToDecimal(txtGuaranteeExcess.Text.Replace(" ", ""));
                    lblExcessAmt.Text = txtExcessAmount.ToString("C");
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        private void txtGuaranteeAmt_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;
            string NewInvoiceAmt = "";
            errProvider.Clear();
            try
            {
                if (txtGuaranteeAmt.Text.Trim().Length > 0)
                {
                    if (!double.TryParse(txtGuaranteeAmt.Text, out tmp))
                    {
                        if (txtGuaranteeAmt.Text.Substring(txtGuaranteeAmt.Text.Trim().Length - 1, 1) != ".")
                        {
                            if (!double.TryParse(txtGuaranteeAmt.Text.Trim(), out tmp1))
                            {
                            }
                        }
                    }
                    if (Int32.TryParse(txtGuaranteeAmt.Text, out tmp3) )
                    {
                        decimal txtGuarantAmount = System.Convert.ToDecimal(txtGuaranteeAmt.Text.Replace(" ", ""));
                        lblGuaranteeAmt.Text = txtGuarantAmount.ToString("C");
                    }
                    else
                    {
                        lblGuaranteeAmt.Text = "";
                        txtGuaranteeAmt.Text = "";
                    }
                }
                else
                {
                    lblGuaranteeAmt.Text = "";
                    txtGuaranteeAmt.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                throw;
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
                    case  0:
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

        private void chkPolicyExcess_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPolicyExcess.Checked)
            {
                txtGuaranteeExcess.ReadOnly = false;
            }
            else
            {
                txtGuaranteeExcess.Clear();
                lblExcessAmt.Text = "";
                txtGuaranteeExcess.ReadOnly = true;
            }
        }

        private void txtOtherAdmissionCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewFile()
        {
            frmImageViewer frmImgViewer = new frmImageViewer();
            try
            {
                frmImgViewer.EmailDocument = PatientGuaranteeFileName;
                frmImgViewer.Text = PatientFileNo + " - GOP File";

                frmImgViewer.StartPosition = FormStartPosition.CenterParent;
                frmImgViewer.MaximizeBox = false;
                frmImgViewer.MinimizeBox = false;
                frmImgViewer.ShowDialog();
                DialogResult dialogRes = MessageBox.Show("Continue with the Previewed "+ TemplateName +" Letter...?", "Proceed with Previewed Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogRes == DialogResult.Yes)
                {
                    filePreviewed = true;
                }
                else
                {
                    filePreviewed = false;
                    try
                    {
                        File.Delete(PatientGuaranteeFileName);
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

        private void GuaranteePayment(string GuaranteeType)
        {
            if (!ValidateControl())
                return;

            //createAIMSAccomodation();
            string pdfFile = @"c:\AIMS Recorder\" + GuaranteeType + "_CE_" + System.Guid.NewGuid() + ".pdf";

            string meals = "";

            string htmlBody = @"<html>
            <body>
            <table width=100% align='center'>
                <tr>
                    <td align=center colspan=4 style='padding:0in 5.4pt 0in 80pt'>
                        <img align=center src='C:\Clients\AIMS\Phase3\aims_header.png' height='100px' width='400px'/>
                    </td>
                </tr>
            </table>
            <br/>        
            <p align=center style='text-align:center;FONT-SIZE: 9pt;LINE-HEIGHT:10pt;FONT-FAMILY: Verdana, Arial;'><u><b><span style='font-size:12.0pt'>ACCOMMODATION VOUCHER</span></b></u></p>
            <br/>
            <table border=0.5 border-style='solid' width=100% cellpadding=2 cellspacing=1 align=center style='border-style:solid'>
            <tr>
            <td colspan=4 valign=top align=center>
                <p style='font-weight:bold;color:red;font-family:""Calibri"",""sans-serif"";height:17.9pt'>
                    NB: Please notes all invoices must be sent to admin@aims.org.za. Should you fail to send your invoices to the above mentioned email the system will reject your invoices resulting in delayed payment. 
                </p>
            </td>
            </tr>
            <tr>
                <td colspan=2 valign=top bgcolor=#B6DDE8 width=50%><b>Hospital / Facility / Provider</b></td>";
            htmlBody += "<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td></tr>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Contact number</b></td>";
            htmlBody += "<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td></tr>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor='#B6DDE8' width='50%'><b>E-mail address</b></td>";
            htmlBody += "<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor='#B6DDE8' width='50%'><b>Patient Name</b></td>";
            htmlBody += "<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor='#B6DDE8' width='50%'><b>Date Of Birth</b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"</tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width='50%'><b>Number of Guests</b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"</tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 'width=50%'><b>AIMS Case Number</b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left>" + PatientFileNo + "</td>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Guaranteed room-rate per night</b></td>
                <td colspan=2 bgcolor=#ffffff width=50% align=left><b><font color=red>ZAR" + txtGuaranteeComments.Text + "</font></b></td>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Guaranteed check-in Date</b></td>
                <td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"</tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Guaranteed check-out Date</b></b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"</tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Room Type</b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"</tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Meals</b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left>" + meals + "</td>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Laundry</b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Social Transport Cover</b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left>" + txtGuaranteeComments.Text + "</td>";
            htmlBody += @"<tr>
            <tr>
                <td colspan=2 bgcolor=#B6DDE8 width=50%><b>Additional Notes</b></td>";
            htmlBody += @"<td colspan=2 bgcolor=#ffffff width=50% align=left><font size=2 color=red>" + txtGuaranteeComments.Text + "</font></td>";
            htmlBody += @"<tr>
            </table>
            <p align=center style='margin-top:12.0pt;text-align:center'><b><i style='mso-bidi-font-style:normal'>
            <u><span style='font-size:10.0pt;mso-bidi-font-size:9.0pt;font-family:""Calibri"",""sans-serif""'>(Please refer to the second page of this document for additional information.)</span></u></i></b></p>
            <br/>
            <br/>
            <br/>
            <p align=center style='text-align:center;line-height:10px' >
                <span style='font-size:7.5pt;font-family:""Lucida Sans Unicode"",""sans-serif""'>
                    <b>Alliance International Medical Services (Pty) Ltd</b><br/>
                    AIMS House, 3 West Street, Bryanston. Private Bag X5 Benmore 2010. <br/>
                    Tel: +27 11 783 0135 Fax: +27 11 463 3583 E-mail: <a href=""mailto:operations@aims.org.za"">operations@aims.org.za</a><br/>
                    Reg. No: 2001/025937/07<br/>
                    Directors:B.A. Breton (Managing)
                </span>
            </p>
            <br/>
            <br/>
            <table width=100% align='center'>
                <tr>
                    <td align=center colspan=4 style='padding:0in 5.4pt 0in 80pt'>
                        <img align=center src='C:\Clients\AIMS\Phase3\aims_header.png' height='100px' width='400px'/>
                    </td>
                </tr>
            </table>
            <br/>
            <p>Alliance International Medical Services (AIMS) do hereby guarantee the above amount of all reasonable, customary costs.</p>
            <br/>
            <p>Cost related to guest charges, and items of personal nature such as telephone calls, newspapers, television, wireless charges, minibar are not covered and the member to settle this directly unless otherwise stipulated above. </p>
            <table width=100% cellpadding=2 cellspacing=1 align=center style='border-style:solid'>
                <tr>
                    <td colspan=4 valign=top align=center>
                        <p style='font-weight:bold;font-family:""Calibri"",""sans-serif"";height:17.9pt'>
                            <u>Invoicing Terms:</u>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan=4 align=left>
                        <ul>
                            <li>All invoices will be subject to auditing.</li>
                            <li>Invoices must be submitted to <a href='mailto:admin@aims.org.za'><b>admin@aims.org.za</b></a> in their original format.</li>
                            <li>Invoices posted to AIMS must be submitted to; AIMS House, 3 West Street, Bryanston or Private Bag X5 Benmore 2010</li>
                            <li>Invoices received later than 5 days following the clients check out date are considered as late submissions and payment will be made once received from the medical insurer and are subject to their approval. </li>
                            <li>Alliance International Medical Services (AIMS) File numbers must be quoted on all invoices along with banking details and any payments made by the patient or representative clearly reflected on the invoice.</li>
                        </ul>
                    <td>
                </tr>
            </table>
            <table width=100% cellpadding=2 cellspacing=1 align=center style='border-style:solid'>
                <tr>
                    <td colspan=4 valign=top align=center>
                        <p style='font-weight:bold;font-family:""Calibri"",""sans-serif"";height:17.9pt'>
                            <u>Payment Terms:</u>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan=4 align=left>
                        <ul>
                            <li>Payment will be issued 30 days (thirty) from the date of check out falling into the relevant cheque run pertinent to the check-out date.</li>
                        </ul>
                        <ul>
                            <li>Payment cannot be made on faxed invoices. (Submission of original invoices after five day period will not be processed for payment within the period of 30 days from the date of receiving this guarantee.)</li>
                        </ul>
                        <ul>
                            <li>Alliance International Medical Services will not be held liable for invoices received 60 Days post check out.</li>
                        </ul>
                    </td>
                </tr>    
            </table>    
            <table width=100% cellpadding=2 cellspacing=1 align=center style='border-style:solid'>
                <tr>    
                    <td valign=top align=left>
                        Yours Sincerely,<br/>
                        <img src='C:\Clients\AIMS\Phase3\Signatures\tebello_mbebe.png' width=100px height=50/><br/>
                        Tebello Mbembe<br/>
                        Operations Specialist<br/>
                        12/11/2018 <br/>    
                    <td>
                    <td valign=top align=right>
                        Hugo Muller<br/>
                        <img src='C:\Clients\AIMS\Phase3\Signatures\hugo_muller.png' width=100px height=50/><br/>
                        Operations Manager<br/>
                    <td>
                </tr>
            </table>
            <p align=center style='text-align:center;line-height:10px' >
                <span style='font-size:7.5pt;font-family:""Lucida Sans Unicode"",""sans-serif""'>
                    <b>Alliance International Medical Services (Pty) Ltd</b><br/>
                    AIMS House, 3 West Street, Bryanston. Private Bag X5 Benmore 2010. <br/>
                    Tel: +27 11 783 0135 Fax: +27 11 463 3583 E-mail: <a href=""mailto:operations@aims.org.za"">operations@aims.org.za</a><br/>
                    Reg. No: 2001/025937/07<br/>
                    Directors:B.A. Breton (Managing)
                </span>
            </p>
            ";

            HTMLtoPDF.createPDF(htmlBody, ref pdfFile);
            PatientGuaranteeFileName = pdfFile;
            ViewFile();
        }

        private void txtConsolidatedAmt_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            double tmp1;
            Int32 tmp3;
            string NewInvoiceAmt = "";
            errProvider.Clear();
            try
            {
                if (txtConsolidatedAmt.Text.Trim().Length > 0)
                {
                    if (!double.TryParse(txtConsolidatedAmt.Text, out tmp))
                    {
                        if (txtConsolidatedAmt.Text.Substring(txtConsolidatedAmt.Text.Trim().Length - 1, 1) != ".")
                        {
                            if (!double.TryParse(txtConsolidatedAmt.Text.Trim(), out tmp1))
                            {
                            }
                        }
                    }
                    if (Int32.TryParse(txtConsolidatedAmt.Text, out tmp3))
                    {
                        decimal txtGuarantAmount = System.Convert.ToDecimal(txtConsolidatedAmt.Text.Replace(" ", ""));
                        lblConsolidatedAmt.Text = txtGuarantAmount.ToString("C").Replace("R", "") + " " + cboCurrencies.Text;
                    }
                    else
                    {
                        lblConsolidatedAmt.Text = "";
                        txtConsolidatedAmt.Text = "";
                    }
                }
                else
                {
                    lblConsolidatedAmt.Text = "";
                    txtConsolidatedAmt.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private void txtConsolidatedAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            errProvider.Clear();
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

        private void cboCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 tmp3;
            if (Int32.TryParse(txtConsolidatedAmt.Text, out tmp3))
            {
                decimal txtGuarantAmount = System.Convert.ToDecimal(txtConsolidatedAmt.Text.Replace(" ", ""));
                lblConsolidatedAmt.Text = txtGuarantAmount.ToString("C").Replace("R", "") + " " + cboCurrencies.Text;
            }
        }
    }
}