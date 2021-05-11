using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AIMS.DAL;
using System.IO;

namespace AIMS.BLL
{
    public class Reports
    {
        public DataSet BuildConsolidationCoverReport(string patientFileNo, string includeLateInv, string DoctorOwing, string LateInvoiceSent, bool SaveInvoiceStatement, ref string InvoiceStatementFiles)
        {
            DataSet dsHTML = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet dsPatientDetails = new DataSet();
            DataSet dsInvoices = new DataSet();
            DataSet dsPayments = new DataSet();
            DataSet dsGuarantorAddress = new DataSet();
            DataTable tblBankingDetails = new DataTable();
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            StringBuilder stbInvoiceColumns = new StringBuilder();
            StringBuilder stbInvoiceData = new StringBuilder();
            PatientDAL patientDAL = new PatientDAL();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            PaymentDAL paymentDAL = new PaymentDAL();
            GuarantorDAL guarantorDAL = new GuarantorDAL();
            string bankName = string.Empty;
            string bankAddress = string.Empty;
            string branchCode = string.Empty;
            string branchName = string.Empty;
            string accNum = string.Empty;
            string swiftCode = string.Empty;
            string accountName = string.Empty;
            string faxNum = string.Empty;
            string faxUser = string.Empty;
            string logopath = string.Empty;
            string aimsheadofficeno = string.Empty;
            string aimsheadofficefax = string.Empty;
            double dblPaymentAmt = 0;
            double dblInvoice = 0;
            double dblTotal = 0;
            int lineCount = 0;
            Int32 invoiceSuppliers = 0;
            string InvoiceID = "";
            bool HeaderIndentation = false;
            Int32 invoicePageCount = 0;
            
            StringBuilder AIMSConsolidationHeader = new StringBuilder();
            StringBuilder AIMSConsolidationPayments = new StringBuilder();
            StringBuilder AIMSConsolidationBankDetails = new StringBuilder();

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            dsPatientDetails = patientDAL.GetPatientDetails(patientFileNo,"N","");
            dsInvoices = invoiceDAL.GetPatientInvoices(patientFileNo, includeLateInv, DoctorOwing, LateInvoiceSent);
            
            // If no rows found for invoices
            if (dsInvoices.Tables[0].Rows.Count == 0)
            {
                string NoRecordsFound = "Patient File: " + patientFileNo  + " - No Active Invoices Found";
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                if (includeLateInv == "Y") { NoRecordsFound = "Patient File: " + patientFileNo  + " - No Active Late Invoices Found or All Late Submissions Sent."; }
                stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>"+ NoRecordsFound +"</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");

                dsHTML.Tables.Add(tbl);
                dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
                drow = dsHTML.Tables["HTMLPages"].NewRow();
                drow["HTMLBody"] = stbHTML.ToString();
                dsHTML.Tables["HTMLPages"].Rows.Add(drow);

                return dsHTML;                
            }
            tblBankingDetails = commonDAL.GetBankingDetails();

            if (DoctorOwing == "N" && includeLateInv == "N")
            {
                dsPayments = paymentDAL.GetPatientPaymentDetails(patientFileNo, includeLateInv, DoctorOwing, "");    
            }
                     
            dsGuarantorAddress = guarantorDAL.GetPatientGuarantorAddress(patientFileNo);
         
            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
            drow = dsHTML.Tables["HTMLPages"].NewRow();

            for (int x = 0; x < tblBankingDetails.Rows.Count; x++)
            {
                switch (tblBankingDetails.Rows[x]["LIMITATION_CD"].ToString())
                {
                    case "AIMS_BANK_NAME": bankName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ACCOUNT": accNum = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BRANCH_CODE": branchCode = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_SWIFT_CODE": swiftCode = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_BRANCH": branchName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ACCOUNT_NAME": accountName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMD_DEPOSIT_FAX_NO": faxNum = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_DEPOSIT_ATT_PERSON": faxUser = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_LOGO_PATH": logopath = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ADDRESS": bankAddress = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_HEAD_OFFICE_NO": aimsheadofficeno = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_HEAD_OFFICE_FAX": aimsheadofficefax = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    default:
                        break;
                }
            }

            string PatientDoctorOwingSupplierName = "";
            if (DoctorOwing == "N" && includeLateInv == "N")
            {
                // AIMS Invoice Header
                AIMSConsolidationHeader.Append(AIMSInvoiceHeader(logopath,
                                                        patientFileNo,
                                                        dsPatientDetails.Tables[0].Rows[0]["PATIENT_FIRST_NAME"].ToString(),
                                                        dsPatientDetails.Tables[0].Rows[0]["PATIENT_LAST_NAME"].ToString(), dsPatientDetails.Tables[0].Rows[0]["GUARANTOR_NAME"].ToString(),
                                                        dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS1"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS2"].ToString().Trim(),
                                                        dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS3"].ToString().Trim(), dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS4"].ToString().Trim(),
                                                        dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS5"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["POSTAL_CODE"].ToString(),
                                                        dsGuarantorAddress.Tables[0].Rows[0]["COUNTRY_NAME"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["GUARANTOR_PHONE_NO"].ToString(),
                                                        dsPatientDetails.Tables[0].Rows[0]["GUARANTOR_REF_NO"].ToString(), aimsheadofficeno, aimsheadofficefax, DoctorOwing, PatientDoctorOwingSupplierName));
            }

            // If loadind doctor-owing, bypass
            if (DoctorOwing == "N" && includeLateInv == "N")
            {
                // Patient File Payments
                AIMSConsolidationPayments.Append(AIMSPatientPayments(dsPayments, patientFileNo, ref dblPaymentAmt, DoctorOwing));

                // Get the invoice total amount first
                GetInvoiceAmount(dsInvoices, ref dblInvoice, "N", "", "N");

                // AIMS Banking Details
                AIMSConsolidationBankDetails.Append(AIMSBankingDetails(bankName, bankAddress, branchCode, accNum, swiftCode, accountName, faxNum, faxUser, dblTotal, dblInvoice, dblPaymentAmt));                
            }

            // Check how many invoices for patient
            invoiceSuppliers = dsInvoices.Tables[0].Rows.Count;

            //Invoice header columns build
            stbInvoiceColumns = GetInvoiceSummaryHeaderColumns();

            // If invoice is more 1 page, add this line 
            bool invoiceHeaderLineBreak = false;

            for (int i = 0; i < dsInvoices.Tables[0].Rows.Count; i++)
            {
                InvoiceID = dsInvoices.Tables[0].Rows[i]["INVOICE_ID"].ToString().Trim();

                if (DoctorOwing == "Y" | includeLateInv == "Y")
                {
                    AIMSConsolidationHeader.Length = 0;
                    DataTable dtDoctorOwing = commonDAL.GetDoctorOwingName(patientFileNo, InvoiceID);
                    if (dtDoctorOwing.Rows.Count > 0) { PatientDoctorOwingSupplierName = dtDoctorOwing.Rows[0][0].ToString(); }

                    AIMSConsolidationHeader.Append(AIMSInvoiceHeader(logopath,
                                                            patientFileNo,
                                                            dsPatientDetails.Tables[0].Rows[0]["PATIENT_FIRST_NAME"].ToString(),
                                                            dsPatientDetails.Tables[0].Rows[0]["PATIENT_LAST_NAME"].ToString(), dsPatientDetails.Tables[0].Rows[0]["GUARANTOR_NAME"].ToString(),
                                                            dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS1"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS2"].ToString().Trim(),
                                                            dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS3"].ToString().Trim(), dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS4"].ToString().Trim(),
                                                            dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS5"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["POSTAL_CODE"].ToString(),
                                                            dsGuarantorAddress.Tables[0].Rows[0]["COUNTRY_NAME"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["GUARANTOR_PHONE_NO"].ToString(),
                                                            dsPatientDetails.Tables[0].Rows[0]["GUARANTOR_REF_NO"].ToString(), aimsheadofficeno, aimsheadofficefax, DoctorOwing, PatientDoctorOwingSupplierName));
                    dtDoctorOwing.Dispose();
                }

                stbInvoiceData.Append(@"<tr><td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               dsInvoices.Tables[0].Rows[i]["PATIENT_FILE_NO"].ToString().Trim() + "</td>");

                string PatientSupplierName =
                    dsInvoices.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString().Trim().Length > 0
                        ? dsInvoices.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString().Trim()
                        : "<font color=white>-</font>";

                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               PatientSupplierName + "</td>");

                string PatientSupplierService =
                    dsInvoices.Tables[0].Rows[i]["SERVICE_DESCRIPTION"].ToString().Trim().Length > 0
                        ? dsInvoices.Tables[0].Rows[i]["SERVICE_DESCRIPTION"].ToString().Trim()
                        : "<font color=white>-</font>";
                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               PatientSupplierService + "</td>");

                string PatientAdmissionDt =
                    dsPatientDetails.Tables[0].Rows[0]["PATIENT_ADMISSION_DATE"].ToString().Trim().Length > 0
                        ? dsPatientDetails.Tables[0].Rows[0]["PATIENT_ADMISSION_DATE"].ToString().Trim()
                        : "<font color=white>-</font>";
                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               PatientAdmissionDt + "</td>");

                string PatientDischargeDt =
                    dsPatientDetails.Tables[0].Rows[0]["PATIENT_DISCHARGE_DATE"].ToString().Trim().Length > 0
                        ? dsPatientDetails.Tables[0].Rows[0]["PATIENT_DISCHARGE_DATE"].ToString().Trim()
                        : "<font color=white>-</font>";

                stbInvoiceData.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               PatientDischargeDt + "</td>");

                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               dsInvoices.Tables[0].Rows[i]["INVOICE_NO"].ToString() + "</td>");

                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                                dsInvoices.Tables[0].Rows[i]["INVOICE_DATE"].ToString() + "</td>");

                stbInvoiceData.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;"">" +
                                System.Convert.ToDecimal(dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString().Trim()).ToString("C") + "</td></tr>");
                
                lineCount++;

                // If invoice has got more 8 suppliers then, we need to split into multi-pages
                if (invoiceSuppliers > 8)
                {
                    //Change the amount of invoice line items over here
                    if (lineCount == 8)
                    {
                        
                        invoiceHeaderLineBreak = true;
                        stbHTML.Append(AIMSConsolidationHeader);
                        stbHTML.Append(stbInvoiceColumns);
                        stbHTML.Append(stbInvoiceData);
                        stbHTML.Append(AIMSConsolidationBankDetails);
                        
                        drow = dsHTML.Tables["HTMLPages"].NewRow();
                        drow["HTMLBody"] = stbHTML.ToString();
                        dsHTML.Tables["HTMLPages"].Rows.Add(drow);
                        lineCount = 0;
                        invoicePageCount++;
                        if (SaveInvoiceStatement)
                        {
                            CreateInvoiceStatement(patientFileNo + "_" + invoicePageCount.ToString() + ".HTML", stbHTML.ToString());
                            if (InvoiceStatementFiles.Trim() == "")
                            {
                                InvoiceStatementFiles = @"C:\" + patientFileNo.Replace("/", "-") + "_" + invoicePageCount.ToString() + ".HTML";
                            }
                            else
                            {
                                InvoiceStatementFiles += ";" + @"C:\" + patientFileNo.Replace("/", "-") + "_" + invoicePageCount.ToString() + ".HTML";
                            }   
                            
                        }
                        stbHTML.Length = 0;
                        stbInvoiceData.Length = 0;
                    }                    
                }

                // If there more than 1 Doctor's owing invoice on the file, split each doctor-owing into a separate page
                if (DoctorOwing == "Y" | includeLateInv == "Y")
                {
                    dblInvoice = 0;
                    dblPaymentAmt = 0;
                    dblTotal=0;
                    GetInvoiceAmount(dsInvoices, ref dblInvoice, DoctorOwing, InvoiceID, includeLateInv);
                    // Get payment for this doctor-owing invoice only
                    // Doctor-Owing payment must be linked to an invoice
                    dsPayments = paymentDAL.GetPatientPaymentDetails(patientFileNo, includeLateInv, DoctorOwing, InvoiceID);
                    AIMSConsolidationPayments.Length = 0;
                    AIMSConsolidationPayments.Append(AIMSPatientPayments(dsPayments, patientFileNo, ref dblPaymentAmt, DoctorOwing));
                    
                    // AIMS Banking Details
                    AIMSConsolidationBankDetails.Length = 0;
                    AIMSConsolidationBankDetails.Append("<br/><br/><br/><br/><br/><br/>");
                    AIMSConsolidationBankDetails.Append(AIMSBankingDetails(bankName, bankAddress, branchCode, accNum, swiftCode, accountName, faxNum, faxUser, dblTotal, dblInvoice, dblPaymentAmt));
                    
                    invoiceHeaderLineBreak = true;
                    stbHTML.Append(AIMSConsolidationHeader);
                    stbHTML.Append(stbInvoiceColumns);
                    stbHTML.Append(stbInvoiceData);
                    stbHTML.Append(AIMSConsolidationPayments);
                    stbHTML.Append(AIMSConsolidationBankDetails);

                    drow = dsHTML.Tables["HTMLPages"].NewRow();
                    drow["HTMLBody"] = stbHTML.ToString();
                    dsHTML.Tables["HTMLPages"].Rows.Add(drow);
                    lineCount = 0;

                    invoicePageCount++;
                    if (SaveInvoiceStatement)
                    {
                        CreateInvoiceStatement(patientFileNo + "_" + invoicePageCount.ToString() + ".HTML", stbHTML.ToString());
                        if (InvoiceStatementFiles.Trim() == "")
                        {
                            InvoiceStatementFiles = @"C:\" + patientFileNo.Replace("/","-") + "_" + invoicePageCount.ToString() + ".HTML";
                        }
                        else
                        {
                            InvoiceStatementFiles += ";" + @"C:\" + patientFileNo.Replace("/", "-") + "_" + invoicePageCount.ToString() + ".HTML";
                        }                         
                    }
                    stbHTML.Length = 0;
                    stbInvoiceData.Length = 0;
                }
            }

            if (DoctorOwing == "N" && includeLateInv == "N")
            {
                // Identation of the invoice is more 
                if (invoiceSuppliers > 8) { stbHTML.Append("<br/><br/>"); }
                stbHTML.Append(AIMSConsolidationHeader);
                stbHTML.Append(stbInvoiceColumns);
                stbHTML.Append(stbInvoiceData);
                stbHTML.Append(AIMSConsolidationPayments);
                if (includeLateInv == "Y") { stbHTML.Append("<br /><br />"); }
                stbHTML.Append(AIMSConsolidationBankDetails);

                invoicePageCount++;
                if (SaveInvoiceStatement)
                {
                    CreateInvoiceStatement(patientFileNo + "_" + invoicePageCount.ToString() + ".HTML", stbHTML.ToString());
                    if (InvoiceStatementFiles.Trim() == "")
                    {
                        InvoiceStatementFiles = @"C:\" + patientFileNo.Replace("/", "-") + "_" + invoicePageCount.ToString() + ".HTML";
                    }
                    else
                    {
                        InvoiceStatementFiles += ";" + @"C:\" + patientFileNo.Replace("/", "-") + "_" + invoicePageCount.ToString() + ".HTML";
                    }
                }

                drow = dsHTML.Tables["HTMLPages"].NewRow();
                drow["HTMLBody"] = stbHTML.ToString();
                dsHTML.Tables["HTMLPages"].Rows.Add(drow);
            }
            return dsHTML;
        }

        private StringBuilder AIMSInvoiceHeader(string logopath, string patientFileNo, string PatientFirstname, string PatientLastName, string GuarantorName, string GuarantorAddress1, string GuarantorAddress2, string GuarantorAddress3, string GuarantorAddress4, string GuarantorAddress5, string PostalCode, string CountryName, string GuarantorPhoneNo, string GuarantorRefNo, string AimsHeadOfficeNo, string AimsHeadOfficeFax, string DoctorOwing, string PatientSupplierName)
        {
            StringBuilder strReturn = new StringBuilder();

            //if (DoctorOwing == "Y")
            //{
            //    strReturn.Append(@"<br /><br /><br /><br /><br /><br />");
            //}

            //Logo and Company Details
            strReturn.Append(@"<table width=""100%""><tr><td><table>");
            strReturn.Append(@"<tr><td><img alt="" width=""70%"" src=""" + logopath + @"""/></td></tr>");
            strReturn.Append(@"<tr><td style=""font-family:Arial;font-size:14px""><b><i>Alliance International Medical Services (Pty) Ltd.</i></b></td></tr>");
            strReturn.Append(@"<tr><td><table width=""100%""><tr><td style=""font-family:Arial;font-size:14px;font-style:italic"">AIMS House</td>");
            strReturn.Append(@"<td style=""font-family:Arial;font-size:14px;font-style:italic"">Private Bag X5</td></tr><tr><td style=""font-family:Arial;font-size:14px;font-style:italic"">3 West Street, Bryanston, South Africa</td>");
            strReturn.Append(@"<td style=""font-family:Arial;font-size:14px;font-style:italic"">Benmore, 2010</td></tr><tr><td style=""font-family:Arial;font-size:14px;font-style:italic"">Tel: " + AimsHeadOfficeNo + "</td>");
            strReturn.Append(@"<td style=""font-family:Arial;font-size:14px;font-style:italic"">Fax: " + AimsHeadOfficeFax + "</td></tr></table></td></tr></table></td>");
            strReturn.Append(@"<td><p align=left style=""font-family:Arial;font-size:12px;border:0"">Patient Number: <b>" + patientFileNo + "</b>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Date: <b>" + DateTime.Now.ToLongDateString() + "</b></p>");

            //Patient Details
            strReturn.Append(@"<table border=""1"" cellpadding=""0"" cellspacing=""0"" width=""100%"" bordercolor=""black"">");
            if (DoctorOwing == "Y")
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0""><b><i>Name</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + PatientSupplierName + "</td></tr>");
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0""><b><i>Last Name</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0""></td></tr>");
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0""><b><i>First Name</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + PatientFirstname + "</td></tr>");
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0""><b><i>Last Name</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + PatientLastName + "</td></tr>");
            }

            if (DoctorOwing == "Y")
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Guarantor</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">DOCTOR OWING(0001)</td></tr>"); 
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Guarantor</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + GuarantorName + "</td></tr>");
            }

            if (GuarantorAddress1.Trim().Length > 0)
            {
                if (DoctorOwing == "N")
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Address</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + GuarantorAddress1 + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Address</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
            }

            if (DoctorOwing == "N")
            { 
                if (GuarantorAddress2.Trim().Length > 0)
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + GuarantorAddress2 + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
            }

            if (DoctorOwing == "N")
            {
                if (GuarantorAddress3.Trim().Length > 0)
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + GuarantorAddress3 + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
            }

            if (DoctorOwing == "N")
            {
                if (GuarantorAddress4.Trim().Length > 0)
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + GuarantorAddress4 + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i></i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");                    
            }

            if (DoctorOwing == "N")
            {
                if (GuarantorAddress5.Trim().Length > 0)
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>City</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + GuarantorAddress5 + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>City</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>City</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
            }

            if (DoctorOwing == "N")
            {
                if (PostalCode.Trim().Length > 0)
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Postal Code</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + PostalCode + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Postal Code</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Postal Code</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
            }

            if (DoctorOwing == "N")
            {
                if (CountryName.Trim().Length > 0)
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Country</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + CountryName + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Country</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Country</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
            }

            if (DoctorOwing == "N")
            {
                if (GuarantorPhoneNo.Trim().Length > 0)
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Phone Number</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + GuarantorPhoneNo + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Phone Number</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Phone Number</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
            }

            if (DoctorOwing == "N")
            {
                if (GuarantorRefNo.Trim().Length > 0)
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Guarantor Reference Number</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + GuarantorRefNo + "</td></tr>");
                }
                else
                {
                    strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Guarantor Reference Number</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">&nbsp;</td></tr>");
                }
            }
            else
            {
                strReturn.Append(@"<tr><td style=""width:40%;font-family:Arial;font-size:12px;border:0"" ><b><i>Guarantor Reference Number</i></b></td><td style=""width:40%;font-family:Arial;font-size:12px;border:0"">" + PatientFirstname  + " " + PatientLastName  + " - " + patientFileNo + "</td></tr>");
            }
            strReturn.Append(@"</table></td></tr></table>");
            return strReturn;
        }

        private StringBuilder AIMSPatientPayments(DataSet dsPayments, string patientFileNo, ref double dblPaymentAmt, string DoctorOwing)
        {
            StringBuilder stbHTML = new StringBuilder();

            //Payments Received
            stbHTML.Append(@"<table width=""100%"">");
            stbHTML.Append(@"<tr><td colspan=""2"" style=""font-family:Arial;font-size:12px;""><b><u><i>");
            // If doing doctor-owing, add carriage-returns to move payments to the below.
            if (DoctorOwing == "Y")
            {
                stbHTML.Append(@"<br/><br/><br/><br/><br/><br/>");
            }
            stbHTML.Append(@"Payments Received:Thank You</u></i></b></td></tr>");
            stbHTML.Append(@"<tr><td colspan=""2"">");
            stbHTML.Append(@"<table width=""60%"" cellpadding=""1"" cellspacing=""1"" border=""1"" bordercolor=""black"">");

            stbHTML.Append(@"<tr><td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;border""><b>AIMS File No.</b></td>");
            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Receipt Number</b></td>");
            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Date of Receipt</b></td>");
            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Amount Paid</b></td></tr>");

            for (int j = 0; j < dsPayments.Tables[0].Rows.Count; j++)
            {
                stbHTML.Append(@"<tr><td align=""left"" style=""font-family:Arial;font-size:12px;"">" + patientFileNo + "</td>");
                stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" + dsPayments.Tables[0].Rows[j]["RECEIPT_NO"].ToString() + @" </td>");
                stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;""> " + dsPayments.Tables[0].Rows[j]["DATE_OF_RECEIPT"].ToString() + @" </td>");
                stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;""> " + System.Convert.ToDecimal(dsPayments.Tables[0].Rows[j]["AMOUNT_PAID"].ToString()).ToString("C") + @"</td></tr >");
                dblPaymentAmt += Convert.ToDouble(dsPayments.Tables[0].Rows[j]["AMOUNT_PAID"].ToString());
            }
            stbHTML.Append(@"</table></td></tr></table>");
            return stbHTML;
        }

        private StringBuilder AIMSBankingDetails(string bankName, string bankAddress, string branchCode, string accNum, string swiftCode, string accountName, string faxNum, string faxUser, double dblTotal, double dblInvoice, double dblPaymentAmt)
        {
            StringBuilder stbHTML = new StringBuilder();
            stbHTML.Append(@"<table>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""left"" width=""80%"">");
            stbHTML.Append(@"<table>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td >");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td  colspan=""2"" style=""font-family:Arial;font-size:12px;""><b><u><i><br/><br/><br/>Banking Details</u></i></b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td  style=""font-family:Arial;font-size:12px;""><i>Bank:</i></td>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px""><b>"+ bankName +"</b></td></tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px""><i>Address:</i></td>");
            stbHTML.Append(@"<td colspan=""2"" style=""font-family:Arial;font-size:12px""><b>"+ bankAddress +"</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td  style=""font-family:Arial;font-size:12px;""><i>Branch Code:</i></td>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;""><b>"+ branchCode +"</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td  style=""font-family:Arial;font-size:12px;""><i>Account Number:</i></td>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;""><b>"+ accNum +"</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;""><i>Swift Code:</i></td>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;""><b>"+ swiftCode +"</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;""><i>Account Name:</i></td>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;""><b>"+ accountName +"</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td width=""100%"" colspan=""2"" style=""font-family:Arial;font-size:12px;""><b><i>Kindly FAX deposit receipt to "+ faxNum +"  ATT: "+ faxUser +"</i></b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"<td align=""right"" width=""20%"">");
            stbHTML.Append(@"<table>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;"" align=""left""><i><b>Total Invoice Amount</i></b></td>");
            stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;"">" + System.Convert.ToDecimal(dblInvoice.ToString().Trim()).ToString("C")  + "</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;"" align=""left""><i><b>Total Invoice Paid</i></b></td>");
            if (dblPaymentAmt <0 | dblPaymentAmt == 0)
            {
                dblPaymentAmt = 0.00;
            }
            stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;"">" + System.Convert.ToDecimal(dblPaymentAmt.ToString()).ToString("C")  + "</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;font-color:white"" align=""left""><i><b><font color=white></font></i></b></td>");
            stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;""><u><font color=black>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></u></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;"" colspan=""2"" style=""border-bottom-style:double;border:1"" bordercolor=""black""></td>");
            stbHTML.Append(@"</tr>");

            dblTotal = Math.Round(dblInvoice - Math.Round(dblPaymentAmt, 2), 2);

            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td style=""font-family:Arial;font-size:12px;"" align=""left""><i><b>Amount Due</i></b></td>");
            stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;""><u>" + System.Convert.ToDecimal(Math.Round(dblTotal, 2)).ToString("C") +"</u></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");								
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");
            
            return stbHTML;
        }

        private void GetInvoiceAmount(DataSet dsInvoices, ref double dblInvoice, string DoctorOwing, string InvoiceID, string includeLateInv)
        {
            for (int i = 0; i < dsInvoices.Tables[0].Rows.Count ; i++)
            {
                if (dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString().Length > 0)
                {
                    // If we loading doctor-owing and current_Invoice is equal to the doctor-owing invoice
                    if ((DoctorOwing == "Y" | includeLateInv == "Y") && InvoiceID == dsInvoices.Tables[0].Rows[i]["INVOICE_ID"].ToString())
                    {
                        dblInvoice = Convert.ToDouble( dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString().Trim());
                        return;
                    }
                    else
                    {
                        dblInvoice +=
                            Convert.ToDouble(
                                dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString().Trim());
                    }
                }      
            }
        }

        private StringBuilder GetInvoiceSummaryHeaderColumns()
        {
            StringBuilder stbInvoiceColumns = new StringBuilder();

            //Invoice Header Columns
            stbInvoiceColumns.Append(@"<table><tr><td colspan=""8"" style=""font-family:Arial;font-size:12px;""><b><u><i>Invoices Received</u></i></b></td></tr></table>");
            stbInvoiceColumns.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1"" border=""1"" bordercolor=""black"">");
            stbInvoiceColumns.Append(@"<tr>");
            stbInvoiceColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>AIMS File No.</b></td>");
            stbInvoiceColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Supplier</b></td>");
            stbInvoiceColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Service</b></td>");
            stbInvoiceColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Date Admitted</b></td>");
            stbInvoiceColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Date Discharged</b></td>");
            stbInvoiceColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice No.</b></td>");
            stbInvoiceColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice Date</b></td>");
            stbInvoiceColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice Amount</b></td></tr>");
            return stbInvoiceColumns;
        }

        public StringBuilder AIMSLedgerHeaderColumns(string PreviousGuarantor) 
        { 
            StringBuilder stbLedgerColumns = new StringBuilder();

            stbLedgerColumns.Append(@"<tr>");
            if (PreviousGuarantor.ToUpper() == "PRIVATE")
            {
                stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Patient Full Name</b></td>");
            }
            else if(PreviousGuarantor.ToUpper() == "FLIGHTS"){
                stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>GUARANTOR</b></td>");
                stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Guarantor Ref No</b></td>");
            }
            else
            {
                stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Guarantor Ref No</b></td>");
            }

			stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>AIMS File No</b></td>");
			stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Patient Name</b></td>");
			stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Last Name</b></td>");
			stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Date Of Discharged</b></td>");
			stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>File Courier Date</b></td>");
            stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice #</b></td>");
            stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice Amount</b></td>");
            stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice Date</b></td>");
            stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Aging</b></td>");
            stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Total Inv. Received Amount</b></td>");
            stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Late Invoices Total Amt</b></td>");
            stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Amount Paid To Date</b></td>");
			stbLedgerColumns.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Amount Outstanding</b></td>");
		    stbLedgerColumns.Append(@"</tr>");
            return stbLedgerColumns;
        }

        public DataSet BuildAIMSLedgerReport(Int32 GuarantorID, string LedgerType, string LedgerStartDate, string LedgerEndDate, string AgeAnalysisPeriod, string userId, string guarantorName)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            string bankName = string.Empty;
            string bankAddress = string.Empty;
            string branchCode = string.Empty;
            string branchName = string.Empty;
            string accNum = string.Empty;
            string swiftCode = string.Empty;
            string accountName = string.Empty;
            string faxNum = string.Empty;
            string faxUser = string.Empty;
            string logopath = @"C:\AIMS-Ledger.PNG";
            decimal GrandTotal;
            decimal GuarantorTotal;
            Int32 LedgerRecCount = 0;
            Int32 lineCount = 0;
            double AmtOutstanding = 0;
            double AmtSingleOutstanding = 0;
            double LateAmtOuts = 0;
            double InvAmtOuts = 0;
            double GuarantorLateSubmissionTotal = 0;
            double GuarantorTotalPaidToDate = 0;
            double GuarantorConsolidationTotal = 0;
            double TotalPaidToDate = 0;
            double AMOUNTPAIDTODATE = 0;

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            string PreviousGuarantor = "";
            string PreviousGuarantorNotChanged = "";
            double BalanceAmtOutstanding = 0;
            
            DataSet dsLedger = new DataSet();

            try
            {
                dsLedger = commonDAL.GetAIMSLedger(GuarantorID, LedgerType, LedgerStartDate, LedgerEndDate, AgeAnalysisPeriod);

                string LedgerName = "";
                if (LedgerType =="BALANCES")
                {
                    LedgerName = "AIMS Balance Ledger";   
                }else if (LedgerType=="PAYMENTS")
                {
                    LedgerName = "AIMS Payment Ledger";
                }
                else
                {
                    LedgerName = "AIMS Ledger";
                }
                stbHTML.Append(@"<table width=""100%"">");
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td colspan=""11""align=""left"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>" + LedgerName + "</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td colspan=""11""align=""right"" style=""font-family:Arial;font-size:12px;background-color:#WHITE;""><b>" + DateTime.Now.ToLongDateString() + "</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");

                double GuarantorTotalAmntOuts = 0;
                double PatientTotalAmntOuts = 0;
                double PatientTotalAmntPaid = 0;

                double GrandPatientTotalAmntOuts = 0;
                double GrandPatientTotalAmntPaid = 0;
                double GrandGuarantorLateSubmissionTotal = 0;

                string patientFileCourierDt = "";

                dsHTML.Tables.Add(tbl);
                dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
                PreviousGuarantor = "";
                PreviousGuarantorNotChanged = "";
                if (dsLedger.Tables[0].Rows.Count > 0)
                {
                    LedgerRecCount = dsLedger.Tables[0].Rows.Count;
                    for (int i = 0; i < dsLedger.Tables[0].Rows.Count; i++)
                    {
                        // if Displaying a Balances Ledger
                        if (dsLedger.Tables[0].Rows[i]["Amount_OutStanding"].ToString().Trim() == "")
                        {
                            AmtSingleOutstanding = Convert.ToDouble(0);
                        }
                        else
                        {
                            AmtSingleOutstanding = Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_OutStanding"]);
                        }

                        AmtOutstanding += AmtSingleOutstanding;
                        BalanceAmtOutstanding = AmtSingleOutstanding;

                        if (LedgerType.Equals("BALANCES") & BalanceAmtOutstanding <= 0)
                        {
                            //PreviousGuarantor = dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString();
                        }
                        else
                        {

                            AMOUNTPAIDTODATE += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);
                            LateAmtOuts += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Late_invoice_amount_received"]);
                            InvAmtOuts += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]);

                            if (PreviousGuarantor != dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString() |
                                dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString().Trim().Length == 0)
                            {
                                PreviousGuarantor = dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString();

                                if (PatientTotalAmntOuts > 0)
                                {
                                    stbHTML.Append(@"<tr>");
                                    if (PreviousGuarantorNotChanged.Trim().ToUpper().Contains("FLIGHTS"))
                                    {
                                        stbHTML.Append(@"<td colspan=""7"" />");
                                    }
                                    else
                                    {
                                        stbHTML.Append(@"<td colspan=""10""/>");
                                    }
                                    PreviousGuarantorNotChanged = PreviousGuarantor;

                                    //stbHTML.Append(@"   <td align=""right"" style=""font-family:Arial;font-size:15px"">Total Amount Outstanding</td>");
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;"">");
                                    stbHTML.Append(@"<b>" + System.Convert.ToDecimal(GuarantorConsolidationTotal).ToString("C") + "</b>");
                                    stbHTML.Append(@"</td>");
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;"">");
                                    stbHTML.Append(@"<b>" + System.Convert.ToDecimal(GuarantorLateSubmissionTotal).ToString("C") + "</b>");
                                    stbHTML.Append(@"</td>");
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;"">");
                                    stbHTML.Append(@"<b>" + System.Convert.ToDecimal(GuarantorTotalPaidToDate).ToString("C") + "</b>");
                                    stbHTML.Append(@"</td>");
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;"">");
                                    stbHTML.Append(@"<b>" + System.Convert.ToDecimal(PatientTotalAmntOuts).ToString("C") + "</b>");
                                    stbHTML.Append(@"</td>");
                                    stbHTML.Append(@"</tr>");
                                    stbHTML.Append(@"</table>");
                                    GuarantorTotalAmntOuts += PatientTotalAmntOuts;
                                    GrandPatientTotalAmntOuts += PatientTotalAmntOuts;
                                    GrandPatientTotalAmntPaid += PatientTotalAmntPaid;
                                    GrandGuarantorLateSubmissionTotal += GuarantorLateSubmissionTotal;
                                    PatientTotalAmntOuts = 0;
                                }

                                PatientTotalAmntPaid = Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);
                                PatientTotalAmntOuts = AmtSingleOutstanding;
                                GuarantorLateSubmissionTotal = Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Late_invoice_amount_received"]);
                                GuarantorTotalPaidToDate = Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);
                                GuarantorConsolidationTotal = Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]);

                                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                                string TBLHDcols = "";

                                if (PreviousGuarantorNotChanged == "FLIGHTS")
                                {
                                    stbHTML.Append(@"<tr><td colspan=""11"" align=""left"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + PreviousGuarantor + "</b></td></tr>");
                                }
                                else
                                {
                                    stbHTML.Append(@"<tr><td colspan=""16"" align=""left"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + PreviousGuarantor + "</b></td></tr>");
                                }

                                stbHTML.Append(@"<tr>");

                                stbHTML.Append(AIMSLedgerHeaderColumns(PreviousGuarantor));

                                stbHTML.Append(@"<tr>");
                                if (PreviousGuarantor.ToUpper() == "PRIVATE")
                                {
                                    //stbHTML.Append(@"<tr><td align=""right"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_name"].ToString() + "</td>");
                                    string PatientName = dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim() : "<font color=white>-</font>";
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientName + "</td>");
                                }
                                else if (PreviousGuarantor.ToUpper() == "FLIGHTS")
                                {
                                    string FlightGuarantor = dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString().Trim() : "<font color=white>-</font>";
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + FlightGuarantor + "</td>");

                                    //    //stbHTML.Append(@"<tr><td align=""right"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString() + "</td>");
                                    string GuarantorRefNo = dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim() : "<font color=white>-</font>";
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + GuarantorRefNo + "</td>");
                                }
                                else
                                {
                                    //stbHTML.Append(@"<tr><td align=""right"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString() + "</td>");
                                    string GuarantorRefNo = dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim() : "<font color=white>-</font>";
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + GuarantorRefNo + "</td>");
                                }

                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_file_no"].ToString() + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_first_name"].ToString() + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_last_name"].ToString() + "</td>");

                                //stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString() + "</td>");
                                string PatientDischargeDt = dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim() : "<font color=white>-</font>";
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientDischargeDt + "</td>");
                                patientFileCourierDt = dsLedger.Tables[0].Rows[i]["file_courier_date"].ToString().Trim().Length > 0 ? System.Convert.ToDateTime(dsLedger.Tables[0].Rows[i]["file_courier_date"].ToString()).ToShortDateString() : "<font color=white>-</font>";
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + patientFileCourierDt + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_NO"] + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_amount"] + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_date"] + "</td>");

                                if (AgeAnalysisPeriod.Trim().Equals(""))
                                {
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["AGING"] + "</td>");
                                }
                                else
                                {
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["PAYMENT_TERM"] + "</td>");
                                }

                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Late_invoice_amount_received"]).ToString("C") + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]).ToString("C") + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + AmtSingleOutstanding.ToString("C") + "</td>");
                                stbHTML.Append(@"</tr>");
                            }
                            else
                            {
                                stbHTML.Append(@"<tr>");
                                if (PreviousGuarantor.ToUpper() == "PRIVATE")
                                {
                                    //stbHTML.Append(@"<tr><td align=""right"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_name"].ToString() + "</td>");
                                    string PatientName = dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim() : "<font color=white>–</font>";
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientName + "</td>");
                                }
                                else if (PreviousGuarantor.ToUpper() == "FLIGHTS")
                                {
                                    string FlightGuarantor = dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString().Trim() : "<font color=white>-</font>";
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + FlightGuarantor + "</td>");

                                    string GuarantorRefNo = dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim() : "<font color=white>-</font>";
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + GuarantorRefNo + "</td>");
                                }
                                else
                                {
                                    //stbHTML.Append(@"<tr><td align=""right"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString() + "</td>");
                                    string GuarantorRefNo = dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim() : "<font color=white>-</font>";
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + GuarantorRefNo + "</td>");
                                }
                                //stbHTML.Append(@"<tr><td align=""right"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString() + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_file_no"].ToString() + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_first_name"].ToString() + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_last_name"].ToString() + "</td>");

                                //stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString() + "</td>");
                                string PatientDischargeDt2 = dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim() : "<font color=white>-</font>";
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientDischargeDt2 + "</td>");

                                patientFileCourierDt = dsLedger.Tables[0].Rows[i]["file_courier_date"].ToString().Trim().Length > 0 ? System.Convert.ToDateTime(dsLedger.Tables[0].Rows[i]["file_courier_date"].ToString()).ToShortDateString() : "<font color=white>-</font>";
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + patientFileCourierDt + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_NO"] + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_amount"] + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_date"] + "</td>");
                                if (AgeAnalysisPeriod.Trim().Equals(""))
                                {
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["AGING"] + "</td>");
                                }
                                else
                                {
                                    stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["PAYMENT_TERM"] + "</td>");
                                }
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Late_invoice_amount_received"]).ToString("C") + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]).ToString("C") + "</td>");
                                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + AmtSingleOutstanding.ToString("C") + "</td>");
                                stbHTML.Append(@"</tr>");
                                PatientTotalAmntPaid += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);
                                PatientTotalAmntOuts += AmtSingleOutstanding;
                                GuarantorLateSubmissionTotal += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Late_invoice_amount_received"]);
                                GuarantorTotalPaidToDate += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);
                                GuarantorConsolidationTotal += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]);
                            }
                            lineCount++;
                        }
                    }

                    stbHTML.Append(@"<tr>");
                    if (PreviousGuarantorNotChanged.ToUpper() == "FLIGHTS")
                    {
                        stbHTML.Append(@"<td colspan=""7""/>");
                    }
                    else
                    {
                        stbHTML.Append(@"<td colspan=""10""/>");
                    }

                    //stbHTML.Append(@"   <td align=""right"" style=""font-family:Arial;font-size:15px"">Total Amount Outstanding</td>");
                    stbHTML.Append(@"   <td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;"">");
                    stbHTML.Append(@"       <b>" + System.Convert.ToDecimal(GuarantorConsolidationTotal).ToString("C") + "</b>");
                    stbHTML.Append(@"   </td>");
                    stbHTML.Append(@"   <td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;"">");
                    stbHTML.Append(@"       <b>" + System.Convert.ToDecimal(GuarantorLateSubmissionTotal).ToString("C") + "</b>");
                    stbHTML.Append(@"   </td>");
                    stbHTML.Append(@"   <td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;"">");
                    stbHTML.Append(@"       <b>" + System.Convert.ToDecimal(GuarantorTotalPaidToDate).ToString("C") + "</b>");
                    stbHTML.Append(@"   </td>");
                    stbHTML.Append(@"   <td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;"">");
                    stbHTML.Append(@"       <b>" + System.Convert.ToDecimal(PatientTotalAmntOuts).ToString("C") + "</b>");
                    stbHTML.Append(@"   </td>");
                    stbHTML.Append(@"</tr>");
                    //stbHTML.Append(@"</table>");

                    if (LedgerType.Equals("PAYMENTS"))
                    {
                        //stbHTML.Append(@"<tr><td colspan=""8"" /><td align=""right"" style=""font-family:Arial;font-size:15px"">Total Amount Paid</td><td align=""right"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + System.Convert.ToDecimal(PatientTotalAmntPaid).ToString("C") + "</b></td></tr>");    
                    }
                    stbHTML.Append(@"</table>");

                    GuarantorTotalAmntOuts += PatientTotalAmntOuts;
                    GrandPatientTotalAmntOuts += PatientTotalAmntOuts;
                    GrandPatientTotalAmntPaid += PatientTotalAmntPaid;
                    GrandGuarantorLateSubmissionTotal += GuarantorLateSubmissionTotal;

                    if (GuarantorID == 0)
                    {
                        stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1"" border=""1"" bordercolor=""black"">");
                        stbHTML.Append(@"<tr>");
                        stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;"" colspan=""13""><font color=""#DCDCDC"">-</font></td>");
                        stbHTML.Append(@"</tr>");

                        stbHTML.Append(@"<tr>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:20px"" colspan=""8"">Grand Total - Invoices Received</td>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;font-color:red""><b>" + System.Convert.ToDecimal(InvAmtOuts).ToString("C") + "</b></td>");
                        stbHTML.Append(@"</tr>");

                        stbHTML.Append(@"<tr>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:20px"" colspan=""8"">Grand Total - Late Invoices Received</td>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;font-color:red""><b>" + System.Convert.ToDecimal(LateAmtOuts).ToString("C") + "</b></td>");
                        stbHTML.Append(@"</tr>");
                        stbHTML.Append(@"<tr>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:20px"" colspan=""8"">Grand Total - Amount Paid To Date</td>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;font-color:red""><b>" + System.Convert.ToDecimal(AMOUNTPAIDTODATE).ToString("C") + "</b></td>");
                        stbHTML.Append(@"</tr>");
                        stbHTML.Append(@"<tr>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:20px"" colspan=""8"">Grand Total - Amount Outstanding</td>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;font-color:red""><b>" + System.Convert.ToDecimal(((InvAmtOuts + LateAmtOuts) - AMOUNTPAIDTODATE)).ToString("C") + "</b></td>");
                        stbHTML.Append(@"</tr>");
                        stbHTML.Append(@"</table>");
                    }
                }
                else
                {
                    stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td colspan=""11""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>No Outstanding Payments</b></td>");
                    stbHTML.Append(@"</tr>");
                    stbHTML.Append(@"</table>");
                }
            }
            catch (System.Exception ex)
            {
                PreviousGuarantor = ex.ToString(); 
            }
            
            stbHTML.Append(@"</table>");
            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);
            SendEmail("AIMS Ledger", LedgerType, GuarantorID, dsHTML, userId, guarantorName);
            return dsHTML;
        }

        public DataSet BuildAIMSForexLedgerReport(Int32 GuarantorID, string LedgerType, string ForexPymt, string InsuranceOverPymt, string InsuranceShortPymt, string DoctorOwing, string LateInvoiceOverPymt, string LedgerStartDate, string LedgerEndDate, string AgeAnalysisPeriod, string userId, string guarantorName)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            string bankName = string.Empty;
            string bankAddress = string.Empty;
            string branchCode = string.Empty;
            string branchName = string.Empty;
            string accNum = string.Empty;
            string swiftCode = string.Empty;
            string accountName = string.Empty;
            string faxNum = string.Empty;
            string faxUser = string.Empty;
            string logopath = @"C:\AIMS-Ledger.PNG";
            string LastLedgerType = "";

            decimal GrandTotal;
            decimal GuarantorTotal;

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            string PreviousGuarantor = "";

            DataSet dsLedger = new DataSet();

            dsLedger = commonDAL.GetAIMSForexLedger(ForexPymt, InsuranceOverPymt, InsuranceShortPymt, DoctorOwing, LateInvoiceOverPymt, LedgerStartDate, LedgerEndDate, AgeAnalysisPeriod);
         
            stbHTML.Append(@"<table width=""100%"">");
            stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td colspan=""11"" align=""left"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>AIMS Ledger</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td colspan=""11"" align=""right"" style=""font-family:Arial;font-size:12px;background-color:#WHITE;""><b>" + DateTime.Now.ToLongDateString() + "</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");

            double GuarantorTotalAmntOuts = 0;
            double PatientTotalAmntOuts = 0;
            if (dsLedger.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsLedger.Tables[0].Rows.Count; i++)
                {
                    if (PreviousGuarantor != LastLedgerType | LastLedgerType.Trim().Length == 0)
                    {
                        PreviousGuarantor = dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString();
                        if (LedgerType == "FOREX")
                        {
                            if (dsLedger.Tables[0].Rows[i]["forex_payment"].ToString() == "Y") { PreviousGuarantor = "Forex Payments".ToUpper(); }
                            if (dsLedger.Tables[0].Rows[i]["insurance_overpymt"].ToString() == "Y") { PreviousGuarantor = "Insurance Over Payments".ToUpper(); }
                            if (dsLedger.Tables[0].Rows[i]["insurance_shortpymt"].ToString() == "Y") { PreviousGuarantor = "Insurance Short Payments".ToUpper(); }
                            if (dsLedger.Tables[0].Rows[i]["doctor_owing"].ToString() == "Y") { PreviousGuarantor = "Doctor Owing".ToUpper(); }
                        }

                        LastLedgerType = PreviousGuarantor;

                        if (PatientTotalAmntOuts != 0)
                        {
                            stbHTML.Append(@"<tr><td colspan=""9"" /><td align=""center"" style=""font-family:Arial;font-size:15px"">Total Amount Paid</td><td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + System.Convert.ToDecimal(PatientTotalAmntOuts).ToString("C") + "</b></td></tr>");
                            stbHTML.Append(@"</table>");
                            GuarantorTotalAmntOuts += PatientTotalAmntOuts;
                            PatientTotalAmntOuts = 0;
                        }
                        //PatientTotalAmntOuts += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_OutStanding"]);
                        PatientTotalAmntOuts += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);
                        

                        stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                        stbHTML.Append(@"<tr><td colspan=""12"" align=""left"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + PreviousGuarantor + "</b></td></tr>");
                        stbHTML.Append(@"<tr>");
                        if (PreviousGuarantor.ToUpper() == "PRIVATE")
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Patient Full Name</b></td>");
                        }
                        else
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Guarantor Ref No</b></td>");
                        }
                        if (DoctorOwing=="Y")
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Supplier Name</b></td>");
                        }
                        else
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Guarantor Name</b></td>");
                        }
                        
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>AIMS File No</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Patient Name</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Last Name</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Date Of Discharged</b></td>");

                        //if (DoctorOwing == "Y")
                        //{
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice #</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice Date</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Aging</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice Amount</b></td>");
                        //}

                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Amount Paid To Date</b></td></tr><tr>");
                        
                        if (PreviousGuarantor.ToUpper() == "PRIVATE")
                        {
                            string PatientName = dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim() : "<font color=white>-</font>";
                            stbHTML.Append(@"<td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientName + "</td>");
                        }
                        else
                        {
                            string GuarantorRefNo = dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim() : "<font color=white>-</font>";
                            stbHTML.Append(@"<td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + GuarantorRefNo + "</td>");
                        }
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["doctor_owing_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_file_no"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_first_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_last_name"].ToString() + "</td>");

                        string PatientDischargeDt = dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientDischargeDt + "</td>");

                        
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_NO"] + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_date"]+ "</td>");
                        if (AgeAnalysisPeriod.Trim().Equals(""))
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["AGING"] + "</td>");
                        }
                        else
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["PAYMENT_TERM"] + "</td>");
                        }
                        
                        //if (DoctorOwing == "Y") { stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>"); }
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>");

                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]).ToString("C").Replace("(R","R-").Replace(")","") + "</td></tr>");
                    }
                    else
                    {
                        if (PreviousGuarantor.ToUpper() == "PRIVATE")
                        {
                            string PatientName = dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim() : "<font color=white>–</font>";
                            stbHTML.Append(@"<tr><td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientName + "</td>");
                        }
                        else
                        {
                            string GuarantorRefNo = dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim() : "<font color=white>-</font>";
                            stbHTML.Append(@"<tr><td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + GuarantorRefNo + "</td>");
                        }
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["doctor_owing_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_file_no"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_first_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_last_name"].ToString() + "</td>");

                        string PatientDischargeDt2 = dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientDischargeDt2 + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_NO"] + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["invoice_date"] + "</td>");

                        if (AgeAnalysisPeriod.Trim().Equals(""))
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["AGING"] + "</td>");
                        }
                        else
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["PAYMENT_TERM"] + "</td>");
                        }
                        //if (DoctorOwing == "Y") { stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>"); }
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>");

                        //stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]).ToString("C") + "</td></tr>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]).ToString("C").Replace("(R", "R-").Replace(")", "") + "</td></tr>");

                        PatientTotalAmntOuts += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);
                    }
                }
                stbHTML.Append(@"<tr><td colspan=""9"" /><td align=""center"" style=""font-family:Arial;font-size:15px"">Total Amount Paid</td><td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + System.Convert.ToDecimal(PatientTotalAmntOuts).ToString("C").Replace("(R","R-").Replace(")","") + "</b></td></tr>");
                stbHTML.Append(@"</table>");
                GuarantorTotalAmntOuts += PatientTotalAmntOuts;
                if (GuarantorID == 0)
                {
                    //stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1"" border=""1"" bordercolor=""black"">");
                    //stbHTML.Append(@"<tr>");
                    //stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:20px"" colspan=""7"">Grand Total Amount Outstanding</td>");
                    //stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;font-color:red""><b>" + System.Convert.ToDecimal(GuarantorTotalAmntOuts).ToString("C") + "</b></td>");
                    //stbHTML.Append(@"</tr>");
                    //stbHTML.Append(@"</table>");
                }
            }
            else
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>No Outstanding Payments</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");
            }
            stbHTML.Append(@"</table>");
            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            SendEmail("AIMS Ledger", LedgerType, GuarantorID, dsHTML, userId, guarantorName);

            return dsHTML;
        }

        public DataSet BuildPatientAnalysisReport(string StartDate, string EndDate, string File_status, string Guarantor, string Supplier, string Patient_Status_In_Out, string Aims_Service, string Aims_Service_type, string TransportType, string AssistType)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            long lPatientCount = 0;
            string InPatient = "N";
            string OutPatient = "N";
            string FileStatus = "";
            string Repat = "";
            string Flight = "";
            string Assist = "";
            string Transport = "";

            string FileActiveYN = "N";
            string FileCancelled = "N";
            
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            
            DataSet dsPatientAnalysisReport = new DataSet();

            if (Patient_Status_In_Out.Contains("In")) { InPatient = "Y"; } else { InPatient = "N"; }
            if (Patient_Status_In_Out.Contains("Out")) { OutPatient = "Y"; } else { OutPatient = "N"; }
            if (Aims_Service.Contains("Flight")) { Flight = "Y"; } else { Flight = "N"; }
            if (Aims_Service.Contains("Repat")) { Repat = "Y"; } else { Repat = "N"; }
            if (Aims_Service.Contains("Assist")) { Assist = "Y"; AssistType = Aims_Service_type; } else { Assist = "N"; AssistType = ""; }
            if (Aims_Service.Contains("Transport")) { Transport = "Y"; TransportType = Aims_Service_type; } else { Transport = "N"; TransportType = ""; }
            FileActiveYN = "";
            if (File_status.Contains("CANCELLED")) { FileCancelled = "Y"; }
            if (File_status.Contains("CLOSED")) { FileActiveYN = "N"; }
            if (File_status.Contains("OPEN")) { FileActiveYN = "Y"; }
            if (File_status == "") { FileActiveYN = ""; }
            
            dsPatientAnalysisReport = commonDAL.GetPatientsAnalysisReport(StartDate, EndDate, FileCancelled, FileActiveYN, Guarantor, Supplier, InPatient, OutPatient, Assist, Transport, Flight, Repat, TransportType, AssistType);

            stbHTML.Append(@"<table width=""100%"">");
            stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>PATIENTS ANALYSIS REPORT</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td colspan=""8""align=""right"" style=""font-family:Arial;font-size:12px;background-color:#WHITE;""><b>" + DateTime.Now.ToLongDateString() + "</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");

            if (dsPatientAnalysisReport.Tables[0].Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td align=""center"" width=""2%"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>File No</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Name</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Surame</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Guarantor</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""5%"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Discharged</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""4%"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Admitted</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Supplier</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Status</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Service</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Type</b></td></tr>");
                for (int i = 0; i < dsPatientAnalysisReport.Tables[0].Rows.Count; i++)
                {
                        stbHTML.Append(@"<tr><td align=""left"" style=""font-family:Arial;font-size:12px;"">" + dsPatientAnalysisReport.Tables[0].Rows[i]["patient_file_no"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" + dsPatientAnalysisReport.Tables[0].Rows[i]["patient_first_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" + dsPatientAnalysisReport.Tables[0].Rows[i]["patient_last_name"].ToString() + "</td>");

                        string PatientGuarantor = dsPatientAnalysisReport.Tables[0].Rows[i]["guarantor_name"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["guarantor_name"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientGuarantor + "</td>");                        
 
                        string PatientDischargeDt = dsPatientAnalysisReport.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientDischargeDt + "</td>");

                        string PatientAdmissionDt = dsPatientAnalysisReport.Tables[0].Rows[i]["PATIENT_ADMISSION_DATE"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["PATIENT_ADMISSION_DATE"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientAdmissionDt + "</td>");

                        string PatientSupplier = dsPatientAnalysisReport.Tables[0].Rows[i]["supplier_name"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["supplier_name"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientSupplier + "</td>");

                        string PatientStatus = dsPatientAnalysisReport.Tables[0].Rows[i]["PATIENT_STATUS"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["PATIENT_STATUS"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientStatus + "</td>");

                        string PatientAimsService = dsPatientAnalysisReport.Tables[0].Rows[i]["AIMS_SERVICE"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["AIMS_SERVICE"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientAimsService + "</td>");

                        string PatientAimsServiceType = dsPatientAnalysisReport.Tables[0].Rows[i]["AIMS_SERVICE_TYPE"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["AIMS_SERVICE_TYPE"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientAimsServiceType + "</td>");

                        lPatientCount++;
                }
                stbHTML.Append(@"<tr><td colspan=""8"" /><td align=""left"" style=""font-family:Arial;font-size:15px"">Patient Count</td><td align=""left"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + lPatientCount + "</b></td></tr>");
                stbHTML.Append(@"</table>");
            }
            else
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>No Records found for report criteria</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");
            }

            stbHTML.Append(@"</table>");

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet BuildInvoicesAnalysisReport(string StartDate, string EndDate, string File_status, string Guarantor, string Supplier, string Patient_Status_In_Out, string Aims_Service, string Aims_Service_type, string TransportType, string AssistType)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            long lPatientCount = 0;
            string InPatient = "N";
            string OutPatient = "N";
            string FileStatus = "";
            string Repat = "";
            string Flight = "";
            string Assist = "";
            string Transport = "";

            string FileActiveYN = "N";
            string FileCancelled = "N";

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            DataSet dsPatientAnalysisReport = new DataSet();

            if (Patient_Status_In_Out.Contains("In")) { InPatient = "Y"; } else { InPatient = "N"; }
            if (Patient_Status_In_Out.Contains("Out")) { OutPatient = "Y"; } else { OutPatient = "N"; }
            if (Aims_Service.Contains("Flight")) { Flight = "Y"; } else { Flight = "N"; }
            if (Aims_Service.Contains("Repat")) { Repat = "Y"; } else { Repat = "N"; }
            if (Aims_Service.Contains("Assist")) { Assist = "Y"; AssistType = Aims_Service_type; } else { Assist = "N"; AssistType = ""; }
            if (Aims_Service.Contains("Transport")) { Transport = "Y"; TransportType = Aims_Service_type; } else { Transport = "N"; TransportType = ""; }
            FileActiveYN = "";
            if (File_status.Contains("CANCELLED")) { FileCancelled = "Y"; }
            if (File_status.Contains("CLOSED")) { FileActiveYN = "N"; }
            if (File_status.Contains("OPEN")) { FileActiveYN = "Y"; }
            if (File_status == "") { FileActiveYN = ""; }

            dsPatientAnalysisReport = commonDAL.GetPatientsAnalysisReport(StartDate, EndDate, FileCancelled, FileActiveYN, Guarantor, Supplier, InPatient, OutPatient, Assist, Transport, Flight, Repat, TransportType, AssistType);

            stbHTML.Append(@"<table width=""100%"">");
            stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>PATIENTS ANALYSIS REPORT</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td colspan=""8""align=""right"" style=""font-family:Arial;font-size:12px;background-color:#WHITE;""><b>" + DateTime.Now.ToLongDateString() + "</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");

            if (dsPatientAnalysisReport.Tables[0].Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");

                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td align=""center"" width=""2%"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>File No</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Name</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Surame</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Guarantor</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""5%"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Discharged</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""4%"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Admitted</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Supplier</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Status</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Service</b></td>");
                stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Type</b></td></tr>");
                for (int i = 0; i < dsPatientAnalysisReport.Tables[0].Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr><td align=""left"" style=""font-family:Arial;font-size:12px;"">" + dsPatientAnalysisReport.Tables[0].Rows[i]["patient_file_no"].ToString() + "</td>");
                    stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" + dsPatientAnalysisReport.Tables[0].Rows[i]["patient_first_name"].ToString() + "</td>");
                    stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" + dsPatientAnalysisReport.Tables[0].Rows[i]["patient_last_name"].ToString() + "</td>");

                    string PatientGuarantor = dsPatientAnalysisReport.Tables[0].Rows[i]["guarantor_name"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["guarantor_name"].ToString().Trim() : "<font color=white>-</font>";
                    stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientGuarantor + "</td>");

                    string PatientDischargeDt = dsPatientAnalysisReport.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim() : "<font color=white>-</font>";
                    stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientDischargeDt + "</td>");

                    string PatientAdmissionDt = dsPatientAnalysisReport.Tables[0].Rows[i]["PATIENT_ADMISSION_DATE"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["PATIENT_ADMISSION_DATE"].ToString().Trim() : "<font color=white>-</font>";
                    stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientAdmissionDt + "</td>");

                    string PatientSupplier = dsPatientAnalysisReport.Tables[0].Rows[i]["supplier_name"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["supplier_name"].ToString().Trim() : "<font color=white>-</font>";
                    stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientSupplier + "</td>");

                    string PatientStatus = dsPatientAnalysisReport.Tables[0].Rows[i]["PATIENT_STATUS"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["PATIENT_STATUS"].ToString().Trim() : "<font color=white>-</font>";
                    stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientStatus + "</td>");

                    string PatientAimsService = dsPatientAnalysisReport.Tables[0].Rows[i]["AIMS_SERVICE"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["AIMS_SERVICE"].ToString().Trim() : "<font color=white>-</font>";
                    stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientAimsService + "</td>");

                    string PatientAimsServiceType = dsPatientAnalysisReport.Tables[0].Rows[i]["AIMS_SERVICE_TYPE"].ToString().Trim().Length > 0 ? dsPatientAnalysisReport.Tables[0].Rows[i]["AIMS_SERVICE_TYPE"].ToString().Trim() : "<font color=white>-</font>";
                    stbHTML.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" + PatientAimsServiceType + "</td>");

                    lPatientCount++;
                }
                stbHTML.Append(@"<tr><td colspan=""8"" /><td align=""left"" style=""font-family:Arial;font-size:15px"">Patient Count</td><td align=""left"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + lPatientCount + "</b></td></tr>");
                stbHTML.Append(@"</table>");
            }
            else
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>No Records found for report criteria</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");
            }

            stbHTML.Append(@"</table>");

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }
        public DataSet BuildLateConsolidationReport(string patientFileNo, string includeLateInv, string DoctorOwing, string LateInvoiceSent) 
        {
            DataSet dsHTML = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet dsPatientDetails = new DataSet();
            DataSet dsInvoices = new DataSet();
            DataSet dsPayments = new DataSet();
            DataSet dsGuarantorAddress = new DataSet();
            DataTable tblBankingDetails = new DataTable();
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            StringBuilder stbInvoiceColumns = new StringBuilder();
            StringBuilder stbInvoiceData = new StringBuilder();
            PatientDAL patientDAL = new PatientDAL();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            PaymentDAL paymentDAL = new PaymentDAL();
            GuarantorDAL guarantorDAL = new GuarantorDAL();
            string bankName = string.Empty;
            string bankAddress = string.Empty;
            string branchCode = string.Empty;
            string branchName = string.Empty;
            string accNum = string.Empty;
            string swiftCode = string.Empty;
            string accountName = string.Empty;
            string faxNum = string.Empty;
            string faxUser = string.Empty;
            string logopath = string.Empty;
            string aimsheadofficeno = string.Empty;
            string aimsheadofficefax = string.Empty;
            double dblPaymentAmt = 0;
            double dblInvoice = 0;
            double dblTotal = 0;
            int lineCount = 0;
            Int32 invoiceSuppliers = 0;
            string InvoiceID = "";

            StringBuilder AIMSConsolidationHeader = new StringBuilder();
            StringBuilder AIMSConsolidationPayments = new StringBuilder();
            StringBuilder AIMSConsolidationBankDetails = new StringBuilder();

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            dsPatientDetails = patientDAL.GetPatientDetails(patientFileNo, "N","");
            dsInvoices = invoiceDAL.GetPatientInvoices(patientFileNo, includeLateInv, DoctorOwing, LateInvoiceSent);

            // If no rows found for invoices
            if (dsInvoices.Tables[0].Rows.Count == 0)
            {
                string NoRecordsFound = "Patient File: " + patientFileNo  + " - No Active Invoices Found";
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                if (includeLateInv == "Y") { NoRecordsFound = "Patient File: " + patientFileNo + " - No Active Late Invoices Found or All Late Submissions Sent."; }
                stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>" + NoRecordsFound + "</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");

                dsHTML.Tables.Add(tbl);
                dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
                drow = dsHTML.Tables["HTMLPages"].NewRow();
                drow["HTMLBody"] = stbHTML.ToString();
                dsHTML.Tables["HTMLPages"].Rows.Add(drow);

                return dsHTML;
            }
            tblBankingDetails = commonDAL.GetBankingDetails();

            dsGuarantorAddress = guarantorDAL.GetPatientGuarantorAddress(patientFileNo);

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
            drow = dsHTML.Tables["HTMLPages"].NewRow();

            for (int x = 0; x < tblBankingDetails.Rows.Count; x++)
            {
                switch (tblBankingDetails.Rows[x]["LIMITATION_CD"].ToString())
                {
                    case "AIMS_BANK_NAME": bankName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ACCOUNT": accNum = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BRANCH_CODE": branchCode = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_SWIFT_CODE": swiftCode = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_BRANCH": branchName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ACCOUNT_NAME": accountName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMD_DEPOSIT_FAX_NO": faxNum = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_DEPOSIT_ATT_PERSON": faxUser = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_LOGO_PATH": logopath = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ADDRESS": bankAddress = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_HEAD_OFFICE_NO": aimsheadofficeno = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_HEAD_OFFICE_FAX": aimsheadofficefax = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    default:
                        break;
                }
            }

            if (DoctorOwing == "N")
            {
                dsPayments = paymentDAL.GetPatientPaymentDetails(patientFileNo, includeLateInv, DoctorOwing, "");
            }

            string PatientDoctorOwingSupplierName = "";

            if (DoctorOwing == "N")
            {
                // AIMS Invoice Header
                AIMSConsolidationHeader.Append(AIMSInvoiceHeader(logopath,
                                                        patientFileNo,
                                                        dsPatientDetails.Tables[0].Rows[0]["PATIENT_FIRST_NAME"].ToString(),
                                                        dsPatientDetails.Tables[0].Rows[0]["PATIENT_LAST_NAME"].ToString(), dsPatientDetails.Tables[0].Rows[0]["GUARANTOR_NAME"].ToString(),
                                                        dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS1"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS2"].ToString().Trim(),
                                                        dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS3"].ToString().Trim(), dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS4"].ToString().Trim(),
                                                        dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS5"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["POSTAL_CODE"].ToString(),
                                                        dsGuarantorAddress.Tables[0].Rows[0]["COUNTRY_NAME"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["GUARANTOR_PHONE_NO"].ToString(),
                                                        dsPatientDetails.Tables[0].Rows[0]["GUARANTOR_REF_NO"].ToString(), aimsheadofficeno, aimsheadofficefax, DoctorOwing, PatientDoctorOwingSupplierName));
            }

            // If loadind doctor-owing, bypass
            if (DoctorOwing == "N")
            {
                // Patient File Payments
                AIMSConsolidationPayments.Append(AIMSPatientPayments(dsPayments, patientFileNo, ref dblPaymentAmt, DoctorOwing));

                // Get the invoice total amount first
                GetInvoiceAmount(dsInvoices, ref dblInvoice, "N", "","N");

                // AIMS Banking Details
                AIMSConsolidationBankDetails.Append(AIMSBankingDetails(bankName, bankAddress, branchCode, accNum, swiftCode, accountName, faxNum, faxUser, dblTotal, dblInvoice, dblPaymentAmt));
            }

            // Check how many invoices for patient
            invoiceSuppliers = dsInvoices.Tables[0].Rows.Count;

            //Invoice header columns build
            stbInvoiceColumns = GetInvoiceSummaryHeaderColumns();

            // If invoice is more 1 page, add this line 
            bool invoiceHeaderLineBreak = false;

            for (int i = 0; i < dsInvoices.Tables[0].Rows.Count; i++)
            {
                InvoiceID = dsInvoices.Tables[0].Rows[i]["INVOICE_ID"].ToString().Trim();
                if (DoctorOwing == "Y")
                {
                    AIMSConsolidationHeader.Length = 0;
                    DataTable dtDoctorOwing = commonDAL.GetDoctorOwingName(patientFileNo, InvoiceID);
                    if (dtDoctorOwing.Rows.Count > 0) { PatientDoctorOwingSupplierName = dtDoctorOwing.Rows[0][0].ToString(); }
                    AIMSConsolidationHeader.Append(AIMSInvoiceHeader(logopath,
                                                            patientFileNo,
                                                            dsPatientDetails.Tables[0].Rows[0]["PATIENT_FIRST_NAME"].ToString(),
                                                            dsPatientDetails.Tables[0].Rows[0]["PATIENT_LAST_NAME"].ToString(), dsPatientDetails.Tables[0].Rows[0]["GUARANTOR_NAME"].ToString(),
                                                            dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS1"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS2"].ToString().Trim(),
                                                            dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS3"].ToString().Trim(), dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS4"].ToString().Trim(),
                                                            dsGuarantorAddress.Tables[0].Rows[0]["ADDRESS5"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["POSTAL_CODE"].ToString(),
                                                            dsGuarantorAddress.Tables[0].Rows[0]["COUNTRY_NAME"].ToString(), dsGuarantorAddress.Tables[0].Rows[0]["GUARANTOR_PHONE_NO"].ToString(),
                                                            dsPatientDetails.Tables[0].Rows[0]["GUARANTOR_REF_NO"].ToString(), aimsheadofficeno, aimsheadofficefax, DoctorOwing, PatientDoctorOwingSupplierName));
                    dtDoctorOwing.Dispose();
                }

                stbInvoiceData.Append(@"<tr><td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               dsInvoices.Tables[0].Rows[i]["PATIENT_FILE_NO"].ToString().Trim() + "</td>");

                string PatientSupplierName =
                    dsInvoices.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString().Trim().Length > 0
                        ? dsInvoices.Tables[0].Rows[i]["SUPPLIER_NAME"].ToString().Trim()
                        : "<font color=white>-</font>";

                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               PatientSupplierName + "</td>");

                string PatientSupplierService =
                    dsInvoices.Tables[0].Rows[i]["SERVICE_DESCRIPTION"].ToString().Trim().Length > 0
                        ? dsInvoices.Tables[0].Rows[i]["SERVICE_DESCRIPTION"].ToString().Trim()
                        : "<font color=white>-</font>";
                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               PatientSupplierService + "</td>");

                string PatientAdmissionDt =
                    dsPatientDetails.Tables[0].Rows[0]["PATIENT_ADMISSION_DATE"].ToString().Trim().Length > 0
                        ? dsPatientDetails.Tables[0].Rows[0]["PATIENT_ADMISSION_DATE"].ToString().Trim()
                        : "<font color=white>-</font>";
                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               PatientAdmissionDt + "</td>");

                string PatientDischargeDt =
                    dsPatientDetails.Tables[0].Rows[0]["PATIENT_DISCHARGE_DATE"].ToString().Trim().Length > 0
                        ? dsPatientDetails.Tables[0].Rows[0]["PATIENT_DISCHARGE_DATE"].ToString().Trim()
                        : "<font color=white>-</font>";

                stbInvoiceData.Append(@"<td  align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               PatientDischargeDt + "</td>");

                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                               dsInvoices.Tables[0].Rows[i]["INVOICE_NO"].ToString() + "</td>");

                stbInvoiceData.Append(@"<td align=""left"" style=""font-family:Arial;font-size:12px;"">" +
                                dsInvoices.Tables[0].Rows[i]["INVOICE_DATE"].ToString() + "</td>");

                stbInvoiceData.Append(@"<td align=""right"" style=""font-family:Arial;font-size:12px;"">" +
                                System.Convert.ToDecimal(dsInvoices.Tables[0].Rows[i]["INVOICE_AMOUNT_RECEIVED"].ToString().Trim()).ToString("C") + "</td></tr>");

                lineCount++;

                // If invoice has got more 8 suppliers then, we need to split into multi-pages
                if (invoiceSuppliers > 8)
                {
                    //Change the amount of invoice line items over here
                    if (lineCount == 8)
                    {
                        invoiceHeaderLineBreak = true;
                        stbHTML.Append(AIMSConsolidationHeader);
                        stbHTML.Append(stbInvoiceColumns);
                        stbHTML.Append(stbInvoiceData);
                        stbHTML.Append(AIMSConsolidationBankDetails);

                        drow = dsHTML.Tables["HTMLPages"].NewRow();
                        drow["HTMLBody"] = stbHTML.ToString();
                        dsHTML.Tables["HTMLPages"].Rows.Add(drow);
                        lineCount = 0;
                        stbHTML.Length = 0;
                        stbInvoiceData.Length = 0;
                    }
                }

                // If there more than 1 Doctor's owing invoice on the file, split each doctor-owing into a separate page
                if (DoctorOwing == "Y" | includeLateInv == "Y")
                {
                    dblInvoice = 0;
                    dblPaymentAmt = 0;
                    dblTotal = 0;
                    GetInvoiceAmount(dsInvoices, ref dblInvoice, DoctorOwing, InvoiceID, includeLateInv);
                    // Get payment for this doctor-owing invoice only
                    // Doctor-Owing payment must be linked to an invoice
                    dsPayments = paymentDAL.GetPatientPaymentDetails(patientFileNo, includeLateInv, DoctorOwing, InvoiceID);
                    AIMSConsolidationPayments.Length = 0;
                    AIMSConsolidationPayments.Append(AIMSPatientPayments(dsPayments, patientFileNo, ref dblPaymentAmt, DoctorOwing));

                    // AIMS Banking Details
                    AIMSConsolidationBankDetails.Length = 0;
                    AIMSConsolidationBankDetails.Append(AIMSBankingDetails(bankName, bankAddress, branchCode, accNum, swiftCode, accountName, faxNum, faxUser, dblTotal, dblInvoice, dblPaymentAmt));

                    invoiceHeaderLineBreak = true;
                    stbHTML.Append(AIMSConsolidationHeader);
                    stbHTML.Append(stbInvoiceColumns);
                    stbHTML.Append(stbInvoiceData);
                    stbHTML.Append(AIMSConsolidationPayments);
                    stbHTML.Append(AIMSConsolidationBankDetails);

                    drow = dsHTML.Tables["HTMLPages"].NewRow();
                    drow["HTMLBody"] = stbHTML.ToString();
                    dsHTML.Tables["HTMLPages"].Rows.Add(drow);
                    lineCount = 0;
                    stbHTML.Length = 0;
                    stbInvoiceData.Length = 0;
                }
            }

            if (DoctorOwing == "N" && includeLateInv == "N")
            {
                // Identation of the invoice is more 
                if (invoiceSuppliers > 8) { stbHTML.Append("<br/><br/>"); }
                stbHTML.Append(AIMSConsolidationHeader);
                stbHTML.Append(stbInvoiceColumns);
                stbHTML.Append(stbInvoiceData);
                stbHTML.Append(AIMSConsolidationPayments);
                if (includeLateInv == "Y") { stbHTML.Append("<br /><br />"); }
                stbHTML.Append(AIMSConsolidationBankDetails);

                drow = dsHTML.Tables["HTMLPages"].NewRow();
                drow["HTMLBody"] = stbHTML.ToString();
                dsHTML.Tables["HTMLPages"].Rows.Add(drow);
            }
            return dsHTML;
        }

        private bool CreateInvoiceStatement(string InvStatementFileName, string InvStatementContent)
        {
            string fLogName = @"C:\" + InvStatementFileName;
            bool bSaved = false;
            try
            {
                StreamWriter sw;
                sw = File.CreateText(fLogName.Replace("/","-"));
                sw.WriteLine(InvStatementContent);
                sw.Flush();
                sw.Close();
                bSaved = true;
            }
            finally
            {
            }
            return bSaved;
        }

        public DataSet BuildAIMSPatientFileTranscript(string patientFileNo)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            string bankName = string.Empty;
            string bankAddress = string.Empty;
            string branchCode = string.Empty;
            string branchName = string.Empty;
            string accNum = string.Empty;
            string swiftCode = string.Empty;
            string accountName = string.Empty;
            string faxNum = string.Empty;
            string faxUser = string.Empty;
            string logopath = @"C:\AIMS-Ledger.PNG";
            string LastLedgerType = "";

            decimal GrandTotal;
            decimal GuarantorTotal;

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            string PreviousGuarantor = "";

            DataSet dsLedger = new DataSet();

            string ForexPymt = "", LedgerType = "",InsuranceOverPymt = "", InsuranceShortPymt = "", DoctorOwing = "", LateInvoiceOverPymt = "";
            Int64 GuarantorID = 0;
            //dsLedger = commonDAL.GetAIMSForexLedger(ForexPymt, InsuranceOverPymt, InsuranceShortPymt, DoctorOwing, LateInvoiceOverPymt);

            stbHTML.Append(@"<table width=""100%"">");
            stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td colspan=""9"" align=""left"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>AIMS Ledger</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td colspan=""9"" align=""right"" style=""font-family:Arial;font-size:12px;background-color:#WHITE;""><b>" + DateTime.Now.ToLongDateString() + "</b></td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");

            double GuarantorTotalAmntOuts = 0;
            double PatientTotalAmntOuts = 0;
            if (dsLedger.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsLedger.Tables[0].Rows.Count; i++)
                {
                    if (PreviousGuarantor != LastLedgerType | LastLedgerType.Trim().Length == 0)
                    {
                        PreviousGuarantor = dsLedger.Tables[0].Rows[i]["guarantor_name"].ToString();
                        if (LedgerType == "FOREX")
                        {
                            if (dsLedger.Tables[0].Rows[i]["forex_payment"].ToString() == "Y") { PreviousGuarantor = "Forex Payments".ToUpper(); }
                            if (dsLedger.Tables[0].Rows[i]["insurance_overpymt"].ToString() == "Y") { PreviousGuarantor = "Insurance Over Payments".ToUpper(); }
                            if (dsLedger.Tables[0].Rows[i]["insurance_shortpymt"].ToString() == "Y") { PreviousGuarantor = "Insurance Short Payments".ToUpper(); }
                            if (dsLedger.Tables[0].Rows[i]["doctor_owing"].ToString() == "Y") { PreviousGuarantor = "Doctor Owing".ToUpper(); }
                        }

                        LastLedgerType = PreviousGuarantor;

                        if (PatientTotalAmntOuts != 0)
                        {
                            stbHTML.Append(@"<tr><td colspan=""7"" /><td align=""center"" style=""font-family:Arial;font-size:15px"">Total Amount Paid</td><td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + System.Convert.ToDecimal(PatientTotalAmntOuts).ToString("C") + "</b></td></tr>");
                            stbHTML.Append(@"</table>");
                            GuarantorTotalAmntOuts += PatientTotalAmntOuts;
                            PatientTotalAmntOuts = 0;
                        }
                        //PatientTotalAmntOuts += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_OutStanding"]);
                        PatientTotalAmntOuts += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);


                        stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                        stbHTML.Append(@"<tr><td colspan=""10"" align=""left"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + PreviousGuarantor + "</b></td></tr>");
                        stbHTML.Append(@"<tr>");
                        if (PreviousGuarantor.ToUpper() == "PRIVATE")
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Patient Full Name</b></td>");
                        }
                        else
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Guarantor Ref No</b></td>");
                        }
                        if (DoctorOwing == "Y")
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Supplier Name</b></td>");
                        }
                        else
                        {
                            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>Guarantor Name</b></td>");
                        }

                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC;""><b>AIMS File No</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Patient Name</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Last Name</b></td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Date Of Discharged</b></td>");

                        //if (DoctorOwing == "Y")
                        //{
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Invoice Amount</b></td>");
                        //}

                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;background-color:#DCDCDC""><b>Amount Paid To Date</b></td></tr><tr>");

                        if (PreviousGuarantor.ToUpper() == "PRIVATE")
                        {
                            string PatientName = dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim() : "<font color=white>-</font>";
                            stbHTML.Append(@"<td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientName + "</td>");
                        }
                        else
                        {
                            string GuarantorRefNo = dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim() : "<font color=white>-</font>";
                            stbHTML.Append(@"<td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + GuarantorRefNo + "</td>");
                        }
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["doctor_owing_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_file_no"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_first_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_last_name"].ToString() + "</td>");

                        string PatientDischargeDt = dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientDischargeDt + "</td>");

                        //if (DoctorOwing == "Y") { stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>"); }
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>");

                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]).ToString("C").Replace("(R", "R-").Replace(")", "") + "</td></tr>");
                    }
                    else
                    {
                        if (PreviousGuarantor.ToUpper() == "PRIVATE")
                        {
                            string PatientName = dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_name"].ToString().Trim() : "<font color=white>–</font>";
                            stbHTML.Append(@"<tr><td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientName + "</td>");
                        }
                        else
                        {
                            string GuarantorRefNo = dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["guarantor_ref_no"].ToString().Trim() : "<font color=white>-</font>";
                            stbHTML.Append(@"<tr><td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + GuarantorRefNo + "</td>");
                        }
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["doctor_owing_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_file_no"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_first_name"].ToString() + "</td>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + dsLedger.Tables[0].Rows[i]["patient_last_name"].ToString() + "</td>");

                        string PatientDischargeDt2 = dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim().Length > 0 ? dsLedger.Tables[0].Rows[i]["patient_discharge_date"].ToString().Trim() : "<font color=white>-</font>";
                        stbHTML.Append(@"<td  align=""center"" style=""font-family:Arial;font-size:12px;"">" + PatientDischargeDt2 + "</td>");

                        //if (DoctorOwing == "Y") { stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>"); }
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["invoice_amount_received"]).ToString("C") + "</td>");

                        //stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]).ToString("C") + "</td></tr>");
                        stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:12px;"">" + Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]).ToString("C").Replace("(R", "R-").Replace(")", "") + "</td></tr>");

                        PatientTotalAmntOuts += Convert.ToDouble(dsLedger.Tables[0].Rows[i]["Amount_Paid_To_Date"]);
                    }
                }
                stbHTML.Append(@"<tr><td colspan=""6"" /><td align=""center"" style=""font-family:Arial;font-size:15px"">Total Amount Paid</td><td align=""center"" style=""font-family:Arial;font-size:15px;background-color:#DCDCDC;""><b>" + System.Convert.ToDecimal(PatientTotalAmntOuts).ToString("C").Replace("(R", "R-").Replace(")", "") + "</b></td></tr>");
                stbHTML.Append(@"</table>");
                GuarantorTotalAmntOuts += PatientTotalAmntOuts;
                if (GuarantorID == 0)
                {
                    //stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1"" border=""1"" bordercolor=""black"">");
                    //stbHTML.Append(@"<tr>");
                    //stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:20px"" colspan=""7"">Grand Total Amount Outstanding</td>");
                    //stbHTML.Append(@"<td align=""right"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;font-color:red""><b>" + System.Convert.ToDecimal(GuarantorTotalAmntOuts).ToString("C") + "</b></td>");
                    //stbHTML.Append(@"</tr>");
                    //stbHTML.Append(@"</table>");
                }
            }
            else
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>No Outstanding Payments</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");
            }
            stbHTML.Append(@"</table>");
            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet BuildAIMSGuarantorAnalysisReport(Int32 GuarantorID, string GuarantorName, string sStartDate, string sEndDate)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            string bankName = string.Empty;
            string bankAddress = string.Empty;
            string branchCode = string.Empty;
            string branchName = string.Empty;
            string accNum = string.Empty;
            string swiftCode = string.Empty;
            string accountName = string.Empty;
            string faxNum = string.Empty;
            string faxUser = string.Empty;
            string logopath = @"C:\AIMSLOGO.png";
            decimal GrandTotal;
            decimal GuarantorTotal;
            Int32 LedgerRecCount = 0;
            Int32 lineCount = 0;
            double AmtOutstanding = 0;
            string EmailBody = "";
            Int32 FilesCount = 0;

            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            string PreviousGuarantor = "";

            DataSet dsLedger = new DataSet();

            dsLedger = commonDAL.GetGuarantorAnalysis(GuarantorID, sStartDate,  sEndDate);
            
            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Tables[0].Columns.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"">");
                EmailBody = "<head>" +
                             "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left}</style>" +
                             "</head>" +
                                "<table  width=100%>" +
                                   "<tr><td colspan=4 bgcolor=lightgrey align=center><b>" + GuarantorName + " - Analysis Report</b></td></tr>" +
                                   "<tr><td colspan=4 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>" +
                                   "<tr><td align=left colspan=2><b>Patients Admitted Between:  " + sStartDate + " AND " + sEndDate + "</b></td><td align=right colspan=2><b>" + DateTime.Now.ToLongDateString() + "</b></td></tr>" +
                                   "<tr><td colspan=4 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>" +
                                   "<tr><td colspan=4><table width=100%>" +
                                   "<tr><td colspan=4 bgcolor=lightgrey align=left><b>Patient Files Breakdown</b></td></tr>";

                string columnName = "";
                for (int i = 0; i < dsLedger.Tables[0].Columns.Count; i++)
                {
                    columnName = dsLedger.Tables[0].Columns[i].ColumnName.ToString();
                    if (columnName.ToUpper().Contains("BREAK"))
                    {
                        EmailBody += "<tr>" +
                        "<td colspan=4 align=left bgcolor=lightgrey>" +
                        "<center><b><font color=green size=2 >&nbsp;</font></b></center>" +
                        "</td>" +
                        "</tr>";
                    }
                    else
                    {
                        EmailBody += "<tr>" +
                            "<td  colspan=2 bgcolor=#ffffff width=50% style=TEXT-TRANSFORM: capitalize>" + dsLedger.Tables[0].Columns[i].ColumnName.Replace("XXXXX","Cases") + "</td>";
                        if (columnName.ToUpper().Contains("COST"))
                        {
                            if (dsLedger.Tables[0].Rows[0][i].ToString().Trim().Equals("")){ 
                                EmailBody += "<td colspan=2 bgcolor=#FFCC00 width=50% align=left><font size=2><b>" + System.Convert.ToDecimal("0.0").ToString("C") + "</b></font></td> ";
                            }
                            else{
                                EmailBody += "<td colspan=2 bgcolor=#FFCC00 width=50% align=left><font size=2><b>" + System.Convert.ToDecimal(dsLedger.Tables[0].Rows[0][i].ToString()).ToString("C") + "</b></font></td> ";
                            }
                        }
                        else
                        {
                            if (!columnName.ToUpper().Contains("XXXXX"))
                            {
                                FilesCount += System.Convert.ToInt32(dsLedger.Tables[0].Rows[0][i]);
                            }
                            EmailBody += "<td colspan=2 bgcolor=#efefef width=50% align=left><font size=2><b>" + dsLedger.Tables[0].Rows[0][i].ToString() + "</b></font></td> ";
                            
                        }
                        EmailBody += "</tr>";
                    }
                }
                EmailBody += "<tr>" +
                "<td colspan=4 align=left bgcolor=lightgrey>" +
                "<center><b><font color=green size=2 >&nbsp;</font></b></center>" +
                "</td>" +
                "</tr>";
                EmailBody += "<tr>" +
                               "<td colspan=2 width=50% align=left><font size=2><font color=red face=Calibri size=Small>Total Files</font></font></td> " +
                               "<td colspan=2 bgcolor=#FFCC00 width=50% align=left><font size=2><b>" + FilesCount + "</b></font></td>" +
                               "</tr>";

               EmailBody += "<tr>" +
                              "<td bgcolor=#ffffff colspan=4>&nbsp; </td>" +
                              "</tr>" +
                              "<tr>" +
                              "<td colspan=4 align=left bgcolor=lightgrey>" +
                              "<center><b><font color=green size=2 >&nbsp;</font></b></center>" +
                              "</td>" +
                              "</tr>" +
                              "</table>";

                stbHTML.Append(@EmailBody);
            }
            else
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td colspan=""8""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>No Outstanding Payments</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet BuildAIMSGuarantorAnalysisReportDrilldown(Int32 GuarantorID, string GuarantorName, string sStartDate, string sEndDate)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            string bankName = string.Empty;
            string bankAddress = string.Empty;
            string branchCode = string.Empty;
            string branchName = string.Empty;
            string accNum = string.Empty;
            string swiftCode = string.Empty;
            string accountName = string.Empty;
            string faxNum = string.Empty;
            string faxUser = string.Empty;
            string logopath = @"C:\AIMSLOGO.png";
            decimal GrandTotal = 0;
            decimal GuarantorTotal;
            Int32 LedgerRecCount = 0;
            Int32 lineCount = 0;
            double AmtOutstanding = 0;
            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
            string PreviousGuarantor = "";

            DataSet dsLedger = new DataSet();

            dsLedger = commonDAL.GetGuarantorAnalysisdDrillDown(GuarantorID, sStartDate, sEndDate);

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));


            if (dsLedger.Tables[0].Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"">");
                 EmailBody ="<head>" +
                              "<style>TABLE{FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 10pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 10pt;TEXT-ALIGN: left}</style>" +
                              "</head>" +
                 "<table  width=100%>" +
                                    "<tr><td colspan=4 bgcolor=lightgrey align=center><b>"+ GuarantorName +" - Analysis Report</b></td></tr>" +
                                    "<tr><td colspan=4 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>" +
                                    "<tr><td align=left colspan=2><b>Patients Admitted Between:  "+ sStartDate +" AND "+ sEndDate +"</b></td><td align=right colspan=2><b>"+ DateTime.Now.ToLongDateString() +"</b></td></tr>" +
                                    "<tr><td colspan=4 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>" +
                                    "<tr><td colspan=4><table width=100%>" +
                                    "<tr><td colspan=4 bgcolor=lightgrey align=left><b>Guarantor Files</b></td></tr>" +
                                    "<tr><td bgcolor=lightgrey><b>Patient File No</b></td><td bgcolor=lightgrey><b>Patient Admission Date</b></td><td bgcolor=lightgrey><b>Patient Last Name</b></td><td bgcolor=lightgrey><b>Consolidated File Value</b></td></tr>";

                stbHTML.Append(@EmailBody);
                decimal ConsolidationValue = 0;
                double FileAmount = 0;
                for (int i = 0; i < dsLedger.Tables[0].Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td>" + dsLedger.Tables[0].Rows[i]["PATIENT_FILE_NO"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td>" + dsLedger.Tables[0].Rows[i]["ADMISSION_DATE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td>" + dsLedger.Tables[0].Rows[i]["PATIENT_LAST_NAME"].ToString().Trim() + "</td>");
                    
                    if (!dsLedger.Tables[0].Rows[i]["CONSOLIDATION_VALUE"].ToString().Trim().Equals(""))
                    {
                        ConsolidationValue = System.Convert.ToDecimal(dsLedger.Tables[0].Rows[i]["CONSOLIDATION_VALUE"]);
                    }
                    else
                    {
                        ConsolidationValue = System.Convert.ToDecimal(0);
                    }

                    stbHTML.Append(@"<td>" + ConsolidationValue.ToString("C") + "</td></tr>");
                    GrandTotal += ConsolidationValue;
                }
                stbHTML.Append(@"<tr><td colspan=4 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>");
                stbHTML.Append(@"<tr><td></td><td></td><td align=right><strong>GRAND TOTAL</strong></td><td align=left style=""background-color:#FFCC00""><strong>" + GrandTotal.ToString("C") + "</strong></td></tr>");
                stbHTML.Append(@"</table></td></tr></table>");
            }
            else
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  border=""1"" bordercolor=""black"">");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td colspan=""4""align=""center"" style=""font-family:Arial;font-size:20px;background-color:#DCDCDC;""><b>No Outstanding Payments</b></td>");
                stbHTML.Append(@"</tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet CoOrdinatorCase(string sCoOrdinator, string sCoOrdinatorName)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();


            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();
           

            DataTable dsLedger = new DataTable();

            dsLedger = commonDAL.GetAllocatedFiles(sCoOrdinator);

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  bordercolor=""black"">");
                stbHTML.Append(@"<tr><td colspan=6 align=left bgcolor=lightgreystyle=""font-family:calibri;font-size:12px;""><center><b>" + sCoOrdinatorName + "</b></center></td></tr>");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td align=""center"" width=""20%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Co-Ordinator</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient File No</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""20%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Name</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""30%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Guarantor</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Admission Date</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Class</b></td>");

                stbHTML.Append(@EmailBody);
                
                
                for (int i = 0; i < dsLedger.Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["file_allocated_to"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["PATIENT_FILE_NO"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["PATIENT_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["guarantor_name"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["patient_ADMISSION_DATE"].ToString().Trim() + "</td>");

                    if (dsLedger.Rows[i]["OUT_PATIENT"].ToString().Trim() == "Y")
                    {
                        stbHTML.Append(@"<td align=""center"">Out-Patient</td></tr>");
                    }else if (dsLedger.Rows[i]["IN_PATIENT"].ToString().Trim() == "Y")
                    {
                        stbHTML.Append(@"<td align=""center"">In-Patient</td></tr>");
                    }
                    else if (dsLedger.Rows[i]["REPAT"].ToString().Trim() == "Y")
                    {
                        stbHTML.Append(@"<td align=""center"">Repatriation</td></tr>");
                    }
                    else if (dsLedger.Rows[i]["FLIGHT"].ToString().Trim() == "Y")
                    {
                        stbHTML.Append(@"<td align=""center"">Evacuation</td></tr>");
                    }
                    else if (dsLedger.Rows[i]["ASSIST"].ToString().Trim() == "Y")
                    {
                        stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["ASSIST_TYPE_DESC"].ToString().Trim() + "</td></tr>");
                    }
                    else if (dsLedger.Rows[i]["TRANSPORT"].ToString().Trim() == "Y")
                    {
                        stbHTML.Append(@"<td align=""center"">Transportation</td></tr>");
                    }
                    else
                    {
                        stbHTML.Append(@"<td align=""center"">-</td></tr>");
                    }
                }
                stbHTML.Append(@"<tr><td colspan=6 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet CoOrdinatorWorkloadSnap(string sCoOrdinator, string sCoOrdinatorName)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();

            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();


            DataTable dsLedger = new DataTable();

            dsLedger = commonDAL.GetCoOrdinatorWorkloadSnap(sCoOrdinator);

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  bordercolor=""black"">");
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgreystyle=""font-family:calibri;font-size:12px;""><center><b>" + sCoOrdinatorName + "</b></center></td></tr>");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Co-Ordinator</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>IN-Patient</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>OUT-Patient</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Overdue Tasks</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Work Basket Load</b></td>");
                
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>RMR</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Evacuations</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Repats</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Assist</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Transport</b></td>");

                stbHTML.Append(@EmailBody);


                for (int i = 0; i < dsLedger.Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["file_allocated_to"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["IN_PATIENT"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["OUT_PATIENT"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["overdue_tasks"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["workbasket_items"].ToString().Trim() + "</td>");

                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["rmr"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["evacuations"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["repats"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["Assist"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["Transport"].ToString().Trim() + "</td>");

                }
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet BuildPatientGuarantee(string patientFileNo, string Hospital, string Doctor, string AdmissionDate, string Diagnosis, string Procedure, string AdmissionCode, string Attention, string Exclusions, string Comments, string UserSignedOn, string PatientName, string GuaranteeAmount)
        {
            DataSet dsHTML = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataSet dsPatientDetails = new DataSet();
            DataSet dsInvoices = new DataSet();
            DataSet dsPayments = new DataSet();
            DataSet dsGuarantorAddress = new DataSet();
            DataTable tblBankingDetails = new DataTable();
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();
            StringBuilder stbInvoiceColumns = new StringBuilder();
            StringBuilder stbInvoiceData = new StringBuilder();
            PatientDAL patientDAL = new PatientDAL();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            PaymentDAL paymentDAL = new PaymentDAL();
            GuarantorDAL guarantorDAL = new GuarantorDAL();
            string bankName = string.Empty;
            string bankAddress = string.Empty;
            string branchCode = string.Empty;
            string branchName = string.Empty;
            string accNum = string.Empty;
            string swiftCode = string.Empty;
            string accountName = string.Empty;
            string faxNum = string.Empty;
            string faxUser = string.Empty;
            string logopath = string.Empty;
            string aimsheadofficeno = string.Empty;
            string aimsheadofficefax = string.Empty;
            double dblPaymentAmt = 0;
            double dblInvoice = 0;
            double dblTotal = 0;
            int lineCount = 0;
            Int32 invoiceSuppliers = 0;
            string InvoiceID = "";
            bool HeaderIndentation = false;
            Int32 invoicePageCount = 0;
            string NoRecordsFound = "";
            
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            tblBankingDetails = commonDAL.GetBankingDetails();

            dsGuarantorAddress = guarantorDAL.GetPatientGuarantorAddress(patientFileNo);

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));
            drow = dsHTML.Tables["HTMLPages"].NewRow();

            for (int x = 0; x < tblBankingDetails.Rows.Count; x++)
            {
                switch (tblBankingDetails.Rows[x]["LIMITATION_CD"].ToString())
                {
                    case "AIMS_BANK_NAME": bankName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ACCOUNT": accNum = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BRANCH_CODE": branchCode = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_SWIFT_CODE": swiftCode = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_BRANCH": branchName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ACCOUNT_NAME": accountName = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMD_DEPOSIT_FAX_NO": faxNum = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_DEPOSIT_ATT_PERSON": faxUser = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_LOGO_PATH": logopath = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_BANK_ADDRESS": bankAddress = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_HEAD_OFFICE_NO": aimsheadofficeno = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    case "AIMS_HEAD_OFFICE_FAX": aimsheadofficefax = tblBankingDetails.Rows[x]["LIMITATION_VALUE"].ToString();
                        break;
                    default:
                        break;
                }
            }
            
            DataTable dtSupplierDetails = commonDAL.GetSupplierDetails(Hospital);
            string SupplierAddress = "";
            if (dtSupplierDetails.Rows.Count >0)
            {
                foreach (DataRow drRow in dtSupplierDetails.Rows)
	            {
                    SupplierAddress = "<b>" + dtSupplierDetails.Rows[0]["SUPPLIER_NAME"].ToString() + "</b><br/>";
                    if (!dtSupplierDetails.Rows[0]["ADDRESS1"].ToString().Trim().Equals("")) { SupplierAddress += dtSupplierDetails.Rows[0]["ADDRESS1"].ToString() + "<br/>"; }
                    if (!dtSupplierDetails.Rows[0]["ADDRESS2"].ToString().Trim().Equals("")) { SupplierAddress += dtSupplierDetails.Rows[0]["ADDRESS2"].ToString() + "<br/>"; }
                    if (!dtSupplierDetails.Rows[0]["ADDRESS3"].ToString().Trim().Equals("")) { SupplierAddress += dtSupplierDetails.Rows[0]["ADDRESS3"].ToString() + "<br/>"; }
                    if (!dtSupplierDetails.Rows[0]["ADDRESS4"].ToString().Trim().Equals("")) { SupplierAddress += dtSupplierDetails.Rows[0]["ADDRESS4"].ToString() + "<br/>"; }
                    if (!dtSupplierDetails.Rows[0]["ADDRESS5"].ToString().Trim().Equals("")) { SupplierAddress += dtSupplierDetails.Rows[0]["ADDRESS5"].ToString() + "<br/>"; }

                    SupplierAddress += "TEL: " + dtSupplierDetails.Rows[0]["SUPPLIER_PHONE_NO"].ToString() + "<br/>";
                    SupplierAddress += "FAX: " + dtSupplierDetails.Rows[0]["SUPPLIER_FAX_NO"].ToString() + "<br/>";
                    break;
	            }	
            }

            dsPatientDetails = patientDAL.GetPatientDetails(patientFileNo, "N", "");
            
            stbHTML.Append(@"<table width=""100%"">");
            stbHTML.Append(@"<tr><td align=""center""><br /><br /><br /><br /><img width=""100%"" src=""" + logopath + @"""/></td></tr>");
            stbHTML.Append(@"<tr><td align=""center"" style=""font-family:Arial;font-size:13px""><b><u>GUARANTEE OF PAYMENT</u></b><br/><br/></td></tr>");
            stbHTML.Append(@"<tr><td align=""left"" colspan=4 style=""font-family:Arial;font-size:8px"">" + SupplierAddress + "</td></tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""left"" colspan=4 style=""font-family:Arial;font-size:5px"">");
            stbHTML.Append(@"<table width=90%>");
            stbHTML.Append(@"<br />");
            stbHTML.Append(@"<br />");
            stbHTML.Append(@"<tr><td><b>Admit Date:</b></td><td>"+AdmissionDate+"</td></tr>");
            stbHTML.Append(@"<tr><td><b>Patient Name:</b></td><td>" + PatientName + "</td></tr>");
            stbHTML.Append(@"<tr><td><b>File No:</b></td><td>"+ patientFileNo+"</td></tr>");
            stbHTML.Append(@"<tr><td align=""left""><b>Admitting Dr:</b></td><td>"+Doctor+"</td></tr>");
            stbHTML.Append(@"<tr><td align=""left""><b>Diagnosis:</b></td><td>"+Diagnosis+"</td></tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""left"" colspan=4 style=""font-family:Arial;font-size:10px"">");
            stbHTML.Append(@"<br/>");

            if (!AdmissionCode.Equals(""))
            {
                stbHTML.Append(@"<b>Please use admission Code: " + AdmissionCode + "</b>");    
            }

            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""left"" colspan=4 style=""font-family:Arial;font-size:10px"">");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<b>Attn: "+ Attention +"</b>");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:5px"">");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"Alliance International Medical Services (AIMS) do hereby guarantee <b>"+GuaranteeAmount+"</b> Consolidated of all reasonable, customary costs. All");
            stbHTML.Append(@"invoices will be audited. The diagnosis or procedure on the guarantee is authorized and all other surgery and treatment needs to be");
            stbHTML.Append(@"motivated and authorized. If the treatment is delayed or exceeded beyond the date of guarantee please contact us.<br/>");
            stbHTML.Append(@"Cost related to guest charges, and items of personal nature such as telephone calls, newspapers, television, wireless charges, minibar, ");
            stbHTML.Append(@"admission fees are not covered and the member to settle this directly with the hospital. All copayments, deductibles, ward fees excess ");
            stbHTML.Append(@"needs to be collected on admission or on discharge from the patient.");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:5px"">");
            stbHTML.Append(@"<br/>");
            if (!Comments.Equals(""))
            {
                stbHTML.Append(@Comments + "<br/>");
            }
            stbHTML.Append(@"<b>Please forward a copy of admission forms and patients passport to <u>operations@aims.org.za</u> or fax to 0027 11 783 0950</b>");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""left"" style=""font-family:Arial;font-size:10px"">");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"Guarantee cover relates only to the diagnosis as described above. All non-related treatment must be pre-authorised. The guarantee of payment");
            stbHTML.Append(@"is subject to the member's policy being active at the time of treatment. We reserve the right not to settle invoices in the event we become ");
            stbHTML.Append(@"aware of any information whuch may invalidate the patient's eligibility to policy benefits, this may include, but not limited to information ");
            stbHTML.Append(@"regarding the patients past medical history.");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<b>Payment</b> will be issued 30 days (thirty) from date of discharge on our 15th or 30th cheque run. Original invoices must be issued within 5 days"); 
            stbHTML.Append(@"of discharge. Payment cannot be made on faxed invoices. (Submission of original invoices after five day period will not be processed for payment");
            stbHTML.Append(@"within the period of 30 days from date of discharge.) Please provide the following with the invoice: discharge report;  copy of the guarantee; your");
            stbHTML.Append(@"bank details and any amount paid by patient must be clearly shownon the invoices.");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<i>For payment queries, please e-mail: admin@aims.org.za or contact the Admin Department on 0027 11 783 0135</i>");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<b>Invoices</b> received later than 5 days post-discharge are late submissions and payment will be made once received from the medical insurer. File");
            stbHTML.Append(@"numbers must be quoted on all invoices. Please fax all relevant invoices to the number supplied below and post 3X original invoices and banking details.");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"Sincerely,");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<table>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""left"" colspan=""4"">");
            stbHTML.Append(@"Stanley Nkosi<br>");
            stbHTML.Append(@"Operations<br>");
            stbHTML.Append(@"01/01/2013");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"<tr>");
            stbHTML.Append(@"<td align=""center"" style=""font-family:Arial;font-size:10px"">");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<br/>");
            stbHTML.Append(@"<b>Alliance International Medical Services Pty Ltd.</b><br/>");
            stbHTML.Append(@"66 Wierda Road East, Wierda Valley, Blue Strata House<br/>");
            stbHTML.Append(@"Private Bag X5 Benmore 2010<br/>");
            stbHTML.Append(@"Tel: 0027 11 783 0135 Fax: 0027 11 783 0950 Mobile: 0027 82 323 7553");
            stbHTML.Append(@"</td>");
            stbHTML.Append(@"</tr>");
            stbHTML.Append(@"</table>");

            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);
            return dsHTML;
        }

        public DataSet BuildPatientAppointmentsAudit(string patientFileNo)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();

            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            DataTable dsLedger = new DataTable();

            dsLedger = commonDAL.GetPatientFileAppointmentsAudit(patientFileNo);

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=100% cellpadding=2 cellspacing=1 align=center style='border-style:solid;FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left'>");
                stbHTML.Append(@"<tr><td colspan=13 align=left bgcolor=lightgrey style=""font-family:calibri;font-size:12px;""><center><b>APPOINTMENTS AUDIT - " + patientFileNo + "</b></center></td></tr>");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""20%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Co-Ordinator</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Appointment Subject</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""20%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Appointment Address</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""30%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Appointment Date</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Appointment Note</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Transport</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Transport Type</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Translator</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Created/Changed By</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Created Date</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Last Modified Action</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Last Modified By</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Last Modified Date</b></td>");

                stbHTML.Append(@EmailBody);

                for (int i = 0; i < dsLedger.Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["USER_FULL_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["APPOINTMENT_SUBJECT"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["APPOINTMENT_ADDRESS"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["APPOINTMENT_DATE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["APPOINTMENT_NOTE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["TRANSPORT_YN"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["TRANSPORT_TYPE_DESC"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["TRANSLATOR_YN"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["CREATED_BY"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["CREATED_DTTM"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["MODIFIED_ACTION"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["MODIFIED_USER"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["MODIFIED_DATE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"</tr>");
                }
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet BuildUnallocatedFiles()
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();

            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            DataTable dsLedger = new DataTable();

            dsLedger = commonDAL.GetUnallocatedFiles();

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=100% cellpadding=2 cellspacing=1 align=center style='border-style:solid;FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left'>");
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgrey style=""Font-color:red;font-family:calibri;font-size:12px;""><center><b>Operations Unallocated Files</b></center></td></tr>");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient File No</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""20%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Guarantor</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""15%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Last Name </b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""15%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Name</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""5%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Admission Date</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""5%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Discharge Date</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Diagnosis</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>File Created By</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Creation Date</b></td>");

                stbHTML.Append(@EmailBody);

                for (int i = 0; i < dsLedger.Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_FILE_NO"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["GUARANTOR_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_LAST_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_FIRST_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_ADMISSION_DATE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_DIAGNOSIS"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["MODIFIED_USER"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["CREATION_DTTM"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"</tr>");
                }
                stbHTML.Append(@"<tr><td colspan=10 align=center valign=bottom bgcolor=lightgrey style=""font-family:calibri;font-size:12px;""><center><b><font color=red>TOTAL - " + dsLedger.Rows.Count.ToString() + "</font></b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }
            else
            {
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>");
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgrey style=""font-family:calibri;font-size:12px;""><center><b>ALL FILES ARE ALLOCATED</b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet BuildUnassignedFiles()
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();

            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            DataTable dsLedger = new DataTable();

            dsLedger = commonDAL.GetAdminUnassignedFiles();

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=100% cellpadding=2 cellspacing=1 align=center style='border-style:solid;FONT-SIZE: 8pt;COLOR: #666666;LINE-HEIGHT: 9pt;FONT-FAMILY: Verdana, Arial;HEIGHT: 1pt;TEXT-ALIGN: left'>");
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgrey style=""Font-color:red;font-family:calibri;font-size:12px;""><center><b>Administration Unassigned Files</b></center></td></tr>");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient File No</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""20%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Guarantor</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""15%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Last Name </b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""15%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Name</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""15%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Sent To Admin Date</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""5%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Admission Date</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""5%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Discharge Date</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Diagnosis</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>File Created By</b></td>");
                stbHTML.Append(@"<td bgcolor=lightgrey valign=top align=center width=""10%""  style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Creation Date</b></td>");

                stbHTML.Append(@EmailBody);

                for (int i = 0; i < dsLedger.Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_FILE_NO"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["GUARANTOR_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_LAST_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_FIRST_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["MODIFIED_DATE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_ADMISSION_DATE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_DISCHARGE_DATE"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["PATIENT_DIAGNOSIS"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["MODIFIED_USER"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td valign=top bgcolor=#ffffff style='border-bottom-style:solid;border-bottom-width:1px' align=center>" + dsLedger.Rows[i]["CREATION_DTTM"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"</tr>");
                }
                stbHTML.Append(@"<tr><td colspan=10 align=center valign=bottom bgcolor=lightgrey style=""font-family:calibri;font-size:12px;""><center><b><font color=red>TOTAL - " + dsLedger.Rows.Count.ToString() + "</font></b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }
            else
            {
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>");
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgrey style=""font-family:calibri;font-size:12px;""><center><b>ALL FILES ARE ALLOCATED</b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet AdministratorCase(string sAdministrator, string ssAdministratorName)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();


            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();


            DataTable dsLedger = new DataTable();

            dsLedger = commonDAL.GetAdminAllocatedFiles(sAdministrator);

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  bordercolor=""black"">");
                stbHTML.Append(@"<tr><td colspan=5 align=left bgcolor=lightgreystyle=""font-family:calibri;font-size:12px;""><center><b>" + ssAdministratorName + "</b></center></td></tr>");
                stbHTML.Append(@"<tr>");
                //stbHTML.Append(@"<td align=""center"" width=""20%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Administrator</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""15%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient File No</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""25%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Name</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""40%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Hospital</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>File Received Date</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>File Due Date</b></td>");

                stbHTML.Append(@EmailBody);

                for (int i = 0; i < dsLedger.Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    //stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["FILE_ASSIGNED_TO_USERID"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["PATIENT_FILE_NO"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["PATIENT_NAME"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["HOSPITAL"].ToString().Trim() + "</td>");
                    if (dsLedger.Rows[i]["COURIER_RECEIPT_DATE"] !=null )
                        stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["COURIER_RECEIPT_DATE"].ToString().Trim().Substring(0,10) + "</td>");    
                    else
                        stbHTML.Append(@"<td align=""center""> - </td>");

                    if (dsLedger.Rows[i]["DUE_DATE"] !=null )
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["DUE_DATE"].ToString().Trim().Substring(0,10)  + "</td></tr>");
                    else
                    stbHTML.Append(@"<td align=""center""> - </td></tr>");
                }
                stbHTML.Append(@"<tr><td colspan=5 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet AdministratorWorkloadSnap(string sAdministrator, string sAdministratorName)
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();

            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            DataTable dsLedger = new DataTable();

            dsLedger = commonDAL.GetAdminWorkloadSnap(sAdministrator);

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  bordercolor=""black"">");
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgreystyle=""font-family:calibri;font-size:12px;""><center><b>" + sAdministratorName + "</b></center></td></tr>");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Administrator</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>IN-Patient</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>OUT-Patient</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Overdue Tasks</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Work Basket Load</b></td>");

                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>RMR</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Evacuations</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Repats</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Assist</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Transport</b></td>");

                stbHTML.Append(@EmailBody);


                for (int i = 0; i < dsLedger.Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["file_allocated_to"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["IN_PATIENT"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["OUT_PATIENT"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["overdue_tasks"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["workbasket_items"].ToString().Trim() + "</td>");

                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["rmr"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["evacuations"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["repats"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["Assist"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["Transport"].ToString().Trim() + "</td>");

                }
                stbHTML.Append(@"<tr><td colspan=10 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        public DataSet HighCostFiles()
        {
            DataSet dsHTML = new DataSet();
            DataSet dsAIMSLedger = new DataSet();
            DataTable tbl = new DataTable("HTMLPages");
            DataRow drow;
            StringBuilder stbHTML = new StringBuilder();

            string EmailBody = "";
            AIMS.DAL.CommonFunctions.CommonFunctionsDAL commonDAL = new AIMS.DAL.CommonFunctions.CommonFunctionsDAL();

            DataTable dsLedger = new DataTable();

            dsLedger = commonDAL.GetHighCostFiles();

            dsHTML.Tables.Add(tbl);
            dsHTML.Tables["HTMLPages"].Columns.Add("HTMLBody", typeof(string));

            if (dsLedger.Rows.Count > 0)
            {
                stbHTML.Append(@"<table width=""100%"" cellpadding=""1"" cellspacing=""1""  bordercolor=""black"">");
                stbHTML.Append(@"<tr><td colspan=5 align=left bgcolor=lightgreystyle=""font-family:calibri;font-size:12px;""><center><b>High Cost Files</b></center></td></tr>");
                stbHTML.Append(@"<tr>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Case Number</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""20%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Patient Name</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""30%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Hospital</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""10%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Guaranteed Amount</b></td>");
                stbHTML.Append(@"<td align=""center"" width=""30%"" style=""font-family:calibri;font-size:12px;background-color:#DCDCDC""><b>Last Interim Note</b></td></tr>");

                stbHTML.Append(@EmailBody);
                string GuaranteeAmt = "";
                string guaranteeAmt = "";
                decimal guarenteeAmt = 0;
                Int32 tmp3;
                for (int i = 0; i < dsLedger.Rows.Count; i++)
                {
                    stbHTML.Append(@"<tr>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["PATIENT_FILE_NO"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["patient_name"].ToString().Trim() + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["hospital"].ToString().Trim() + "</td>");
                    
                    GuaranteeAmt = dsLedger.Rows[i]["PATIENT_GUARANTOR_AMOUNT"].ToString();
                    if (!GuaranteeAmt.Trim().Equals(""))
                    {
                        if (Int32.TryParse(GuaranteeAmt, out tmp3))
                        {
                            decimal txtGuarantAmount = System.Convert.ToDecimal(GuaranteeAmt.Replace(" ", ""));
                            guaranteeAmt = txtGuarantAmount.ToString("C");
                        }
                        else
                        {
                            guaranteeAmt = GuaranteeAmt;
                        }
                    }
                    stbHTML.Append(@"<td align=""center"">" + guaranteeAmt + "</td>");
                    stbHTML.Append(@"<td align=""center"">" + dsLedger.Rows[i]["interim_note"].ToString().Trim() + "</td></tr>");
                }
                stbHTML.Append(@"<tr><td colspan=5 align=left bgcolor=lightgrey><center><b><font color=green size=2 >&nbsp;</font></b></center></td></tr>");
                stbHTML.Append(@"</table>");
            }

            drow = dsHTML.Tables["HTMLPages"].NewRow();
            drow["HTMLBody"] = stbHTML.ToString();
            dsHTML.Tables["HTMLPages"].Rows.Add(drow);

            return dsHTML;
        }

        private void SendEmail(string _reportName, string LedgerType, int GuarantorID, DataSet _dsHTML, string UserID, string GuarantorName)
        {
            Reports reportBLL = new Reports();

            AIMS.Common.CommonFunctions commonFuncs = new AIMS.Common.CommonFunctions();
            string StartDate = "";
            string EndDate = "";
            string AgeAnalysisPeriod = "";

            commonFuncs = new AIMS.Common.CommonFunctions();
            try
            {
                string html = "";
                foreach (DataRow drrr in _dsHTML.Tables[0].Rows)
                {
                    html = drrr[0].ToString();
                }

                AIMS.BLL.User clsUser = new AIMS.BLL.User();
                clsUser = clsUser.GetUserDetails(UserID);

                string emailaddress = clsUser.UserEmailAddress;

                bool emailsent = commonFuncs.SendEmail(html, "operations@aims.org.za", "AIMS - Ledger", "AIMS " + LedgerType + " Ledger - " + GuarantorName, emailaddress, "", false, "", "", "", "", false);
                if (emailsent)
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Success, "Ledger email sent successfully.");
                }
                else
                {
                    commonFuncs.DisplayMessage(AIMS.Common.CommonTypes.MessagType.Error, "Ledger email NOT sent successfully, Please contact system administrator");
                }                 
            }
            catch (Exception ex)
            {
                //commonFuncs.DisplayMessage("Consolidated Invoice failed to load, Please contact System Administrator.", AIMS.Common.CommonTypes.MessagType.Error);
                //commonFuncs.ErrorLogger("Consolidation Invoice failed to load, Error:- " + ex.ToString());
            }
            finally
            {
                _dsHTML.Dispose();
                reportBLL = null;
            }
        }
    }    
}
