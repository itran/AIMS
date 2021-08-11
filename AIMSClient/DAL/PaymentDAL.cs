using System;
using System.Collections.Generic;
using System.Text;
using AIMS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL
{

    public class PaymentDAL : DataServiceBase
    {
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public PaymentDAL() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public PaymentDAL(IDbTransaction txn) : base(txn) { }

        public DataSet InvoiceGetAll()
        {
            return ExecuteDataSet("AIMS_INVOICE_GET_ALL", null);
        }

        public DataSet GetPaymentDetails(Int32 PaymentID, string ReceiptNo)
        {
            return ExecuteDataSet("AIMS_PAYMENT_GET",
                CreateParameter("@PaymentID", SqlDbType.Int, PaymentID), CreateParameter("@ReceiptNo", SqlDbType.VarChar, ReceiptNo));
        }

        public bool Payment_Save(ref int PaymentID, string PatientFileNo, string GuarantorName, string AmountPaid, string ReceiptNo, string DateOfReceipt, Int32 PaymentMethodID, string ChequeNo, string CreditCardNo, string BankTransferRefNo, string Notices, string InvoiceNo, string RenderDate, string PaymentLockedYN, string UserSignedOn, string ForexPymt, string InsuranceOverpymt, string InsuranceShortPymt, string DoctorOwing, string LateSubmissionPymt, string DoctorOwingInvoice, string LateSubmissionInvoice)
        {
            bool retVal = false;

            if (DoctorOwingInvoice.Trim() == "" && LateSubmissionInvoice.Trim() != "")
	        {
                DoctorOwingInvoice = LateSubmissionInvoice;
	        }

            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_PAYMENT_ADD",
            CreateParameter("@PaymentID", SqlDbType.Int, PaymentID, ParameterDirection.InputOutput),
            CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
            CreateParameter("@GuarantorName", SqlDbType.VarChar , GuarantorName),
            CreateParameter("@AmountPaid", SqlDbType.VarChar, AmountPaid),
            CreateParameter("@ReceiptNo", SqlDbType.VarChar, ReceiptNo),
            CreateParameter("@DateOfReceipt", SqlDbType.VarChar, DateOfReceipt),
            CreateParameter("@PaymentMethodID", SqlDbType.Int , PaymentMethodID),
            CreateParameter("@ChequeNo", SqlDbType.VarChar, ChequeNo),
            CreateParameter("@CreditCardNo", SqlDbType.VarChar, CreditCardNo),
            CreateParameter("@BankTransferRefNo", SqlDbType.VarChar, BankTransferRefNo),
            CreateParameter("@Notices", SqlDbType.VarChar, Notices),
            CreateParameter("@InvoiceNo", SqlDbType.VarChar, InvoiceNo),
            CreateParameter("@RenderDate", SqlDbType.VarChar, RenderDate),
            CreateParameter("@PaymentLockedYN", SqlDbType.VarChar, PaymentLockedYN),
            CreateParameter("@UserSignedOn", SqlDbType.VarChar, UserSignedOn),
            CreateParameter("@ForexPayment", SqlDbType.VarChar, ForexPymt ),
            CreateParameter("@InsuranceOverPymt", SqlDbType.VarChar, InsuranceOverpymt ),
            CreateParameter("@InsuranceShortPymt", SqlDbType.VarChar, InsuranceShortPymt),
            CreateParameter("@DoctorOwing", SqlDbType.VarChar, DoctorOwing),
            CreateParameter("@LateSubmissionPymt", SqlDbType.VarChar, LateSubmissionPymt),
            CreateParameter("@DoctorOwingInvoiceNo", SqlDbType.VarChar, DoctorOwingInvoice));

            PaymentID = (int)cmd.Parameters["@PaymentID"].Value;

            cmd.Dispose();
            return true;
        }
        
        public DataTable LoadPatientFiles()
        {
            return ExecuteDataTable("[AIMS_PATIENT_GET_ALL]");
        }

        public DataTable LoadServices()
        {
            return ExecuteDataTable("AIMS_SERVICES_GET_ALL");
        }

        public DataTable LoadMedicalTreatments()
        {
            return ExecuteDataTable("AIMS_SUPPLIER_GET_ALL");
        }

        public DataTable PatientFileNoVerify(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_VERIFY", CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }

        public DataTable InvoiceNoVerify(string InvoiceNo, string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_INVOICE_VERIFY", CreateParameter("@InvoiceNo", SqlDbType.VarChar, InvoiceNo), CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }

        public DataSet GetPatientInvoices(string patientID)
        {
            return ExecuteDataSet("AIMS_PATIENT_INVOICES_GET",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientID));
        }

        public DataSet GetPaymentDetails(string PaymentID)
        {
            return ExecuteDataSet("AIMS_PAYMENT_GET", CreateParameter("@PaymentID", SqlDbType.VarChar, PaymentID));
        }

        public DataTable VerifyPatientReceipt(string ReceiptNo)
        {
            return ExecuteDataTable("AIMS_PAYMENT_RECEIPTNO_VERIFY",
                CreateParameter("@ReceiptNo", SqlDbType.VarChar, ReceiptNo));
        }

        public int  VerifyPaymentAmount(ref int PaymentCheck, string PatientFileNo, string InvoiceNo, string PaymentAmount)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_PAYMENT_VERIFY",
                CreateParameter("@PaymentCheck", SqlDbType.Int, PaymentCheck, ParameterDirection.InputOutput),
                 CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                  CreateParameter("@InvoiceNo", SqlDbType.VarChar, InvoiceNo),
                   CreateParameter("@PaymentAmount", SqlDbType.VarChar, PaymentAmount));

            PaymentCheck = (int)cmd.Parameters["@PaymentCheck"].Value;
            return PaymentCheck;
        }

        public DataTable GetHospitalSuppliers()
        {
            return ExecuteDataTable("AIMS_HOSPITAL_SUPPLIERS_GET");
        }

        public DataSet GetPatientPaymentDetails(string patientFile, string LateSubmissionPymt, string DoctorOwing, string InvoiceID)
        {
            return ExecuteDataSet("aims_patient_payments_get", CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientFile),
                CreateParameter("@LateSubmissionPymt", SqlDbType.VarChar, LateSubmissionPymt),
                CreateParameter("@DoctorOwing", SqlDbType.VarChar, DoctorOwing),
                CreateParameter("@InvoiceID", SqlDbType.VarChar, InvoiceID));
        }
    }
}