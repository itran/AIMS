using System;
using System.Collections.Generic;
using System.Text;
using AIMS.Common;
using AIMS.DAL;
using System.Data;

namespace AIMS.BLL
{
    public class Payment : BaseObject
    {
        #region Fields

        private string _InvoiceNo       = Constants.NullString;
        private Int32  _PaymentID       = Constants.NullInt;
        private Int32  _PatientID       = Constants.NullInt;
        private Int32  _GuarantorID     = Constants.NullInt;
        private string _AmountPaid      = Constants.NullString;
        private string _ReceiptNo       = Constants.NullString;
        private string _DateOfReceipt       = Constants.NullString;
        private Int32  _PaymentMethodID     = Constants.NullInt;
        private string _ChequeNo            = Constants.NullString;
        private string _CreditCardNo        = Constants.NullString;
        private string _BankTransferRefNo   = Constants.NullString;
        private string _Notices = Constants.NullString;
        private Int32  _InvoiceID = Constants.NullInt;
        private string _RenderDate = Constants.NullString;
        private string _PaymentProcessedYN = Constants.NullString;
        private string _PaymentLockedYN = Constants.NullString;
        private string _LoggedOnUser = Constants.NullString;
        private string _PatientFileNo = Constants.NullString;
        private string _GuarantorName = Constants.NullString;
        private string _ForexPayment = Constants.NullString;
        private string _InsuranceOverPayment = Constants.NullString;
        private string _InsuranceShortPayment = Constants.NullString;
        #endregion

        #region Public Properties

        public Int32 PaymentID
        {
            get { return _PaymentID; }
            set { _PaymentID = value; }
        }

        public Int32 PatientID
        {
            get { return _PatientID; }
            set { _PatientID = value; }
        }

        public Int32 GuarantorID
        {
            get { return _GuarantorID; }
            set { _GuarantorID = value; }
        }

        public string GuarantorName
        {
            get { return _GuarantorName; }
            set { _GuarantorName = value; }
        }

        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }

        public String PatientFileNo
        {
            get { return _PatientFileNo; }
            set { _PatientFileNo = value; }
        }

        public String AmountPaid
        {
            get { return _AmountPaid; }
            set { _AmountPaid = value; }
        }

        public string ReceiptNo
        {
            get { return _ReceiptNo; }
            set { _ReceiptNo = value; }
        }

        public string DateOfReceipt
        {
            get { return _DateOfReceipt; }
            set { _DateOfReceipt = value; }
        }

        public Int32 PaymentMethodID
        {
            get { return _PaymentMethodID; }
            set { _PaymentMethodID = value; }
        }

        public string ChequeNo
        {
            get { return _ChequeNo; }
            set { _ChequeNo = value; }
        }

        public string CreditCardNo
        {
            get { return _CreditCardNo; }
            set { _CreditCardNo = value; }
        }

        public string BankTransferRefNo
        {
            get { return _BankTransferRefNo; }
            set { _BankTransferRefNo = value; }
        }

        public string Notices
        {
            get { return _Notices; }
            set { _Notices = value; }
        }

        public Int32 InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

        public string  RenderDate
        {
            get { return _RenderDate; }
            set { _RenderDate = value; }
        }

        public string PaymentProcessedYN
        {
            get { return _PaymentProcessedYN; }
            set { _PaymentProcessedYN = value; }
        }

        public string PaymentLockedYN
        {
            get { return _PaymentLockedYN; }
            set { _PaymentLockedYN = value; }
        }

        public string LoggedOnUser
        {
            get { return _LoggedOnUser; }
            set { _LoggedOnUser = value; }
        }

        public String ForexPayment
        {
            get { return _ForexPayment; }
            set { _ForexPayment = value; }
        }

        public String InsuranceOverPayment
        {
            get { return _InsuranceOverPayment; }
            set { _InsuranceOverPayment = value; }
        }

        public String InsuranceShortPayment
        {
            get { return _InsuranceShortPayment; }
            set { _InsuranceShortPayment = value; }
        }

        string _DoctorOwing = "";
        public String DoctorOwing
        {
            get { return _DoctorOwing; }
            set { _DoctorOwing = value; }
        }

        string _LateSubmissionPayment = "";
        public String LateSubmissionPayment
        {
            get { return _LateSubmissionPayment; }
            set { _LateSubmissionPayment = value; }
        }

        string _DoctorOwingInvoice = "";
        public String DoctorOwingInvoice
        {
            get { return _DoctorOwingInvoice; }
            set { _DoctorOwingInvoice = value; }
        }

        string _LateSubmissionInvoice = "";
        public String LateSubmissionInvoice
        {
            get { return _LateSubmissionInvoice; }
            set { _LateSubmissionInvoice = value; }
        }
        #endregion

        #region Public Functions

        public override bool MapData(DataRow row)
        {
            PaymentID = GetInt(row, "PAYMENT_ID");
            PatientID = GetInt(row, "PATIENT_ID");
            GuarantorID = GetInt(row, "GUARANTOR_ID");
            AmountPaid =GetString(row, "AMOUNT_PAID"); 
            ReceiptNo = GetString(row, "RECEIPT_NO"); 
            DateOfReceipt = GetString(row, "DATE_OF_RECEIPT"); 
            PaymentMethodID = GetInt(row, "PAYMENT_METHOD_ID");
            ChequeNo = GetString(row, "CHEQUE_NO"); 
            CreditCardNo = GetString(row, "CREDIT_CARD_NO");
            BankTransferRefNo = GetString(row, "BANK_TRANSFER_REF_NO");
            Notices = GetString(row, "NOTICES");
            InvoiceID = GetInt(row, "INVOICE_ID");
            RenderDate  = GetString(row, "RENDER_DATE");
            PaymentProcessedYN = GetString(row, "PAYMENT_PROCESSED_YN");
            PaymentLockedYN = GetString(row, "LOCKED_YN");
            PatientFileNo = GetString(row, "PATIENT_FILE_NO");
            GuarantorName = GetString(row, "GUARANTOR_NAME");            
            ForexPayment = GetString(row, "FOREX_PAYMENT");
            InsuranceShortPayment = GetString(row, "INSURANCE_SHORTPYMT");
            InsuranceOverPayment = GetString(row, "INSURANCE_OVERPYMT");
            DoctorOwing = GetString(row, "DOCTOR_OWING");
            LateSubmissionPayment  = GetString(row, "LATE_SUBMISSION_PYMT");
            DoctorOwingInvoice = GetString(row, "INVOICE_ID");
            DoctorOwingInvoice = GetString(row, "INVOICE_NO");
            LateSubmissionInvoice = GetString(row, "INVOICE_ID");
            LateSubmissionInvoice = GetString(row, "INVOICE_NO");
            

            return base.MapData(row);
        }

        public bool SavePaymentDetails()
        {
            Payment oInvoice = new Payment();
            DataSet ds = new DataSet();
            PaymentDAL paymentDAL = new PaymentDAL();
            bool bSaved = false;
            int _PymtID = PaymentID;

            bSaved = paymentDAL.Payment_Save(ref _PymtID, PatientFileNo, GuarantorName, AmountPaid, ReceiptNo, DateOfReceipt, PaymentMethodID, ChequeNo, CreditCardNo, BankTransferRefNo, Notices, InvoiceNo, RenderDate, PaymentLockedYN, LoggedOnUser, ForexPayment, InsuranceOverPayment, InsuranceShortPayment, DoctorOwing, LateSubmissionPayment, DoctorOwingInvoice, LateSubmissionInvoice );
            PaymentID = _PymtID;

            return bSaved;
        }

        public DataTable PatientValidate(string PatientFileNo)
        {
            DataTable dtPatientFileNoCheck = new DataTable();
            PaymentDAL invoiceDAL = new PaymentDAL();
            dtPatientFileNoCheck = invoiceDAL.PatientFileNoVerify(PatientFileNo);
            return dtPatientFileNoCheck;
        }

        public DataTable InvoiceNoValidate(string InvoiceNo, string PatientFileNo)
        {
            DataTable dtInvoiceFileNoCheck = new DataTable();
            PaymentDAL paymentDAL = new PaymentDAL();
            dtInvoiceFileNoCheck = paymentDAL.InvoiceNoVerify(InvoiceNo, PatientFileNo);
            return dtInvoiceFileNoCheck;
        }

        public Payment GetPaymentDetails(string ReceiptNumber)
        {
            Payment oPayment = new Payment();
            DataSet ds = new DataSet();
            PaymentDAL PaymentDAL = new PaymentDAL();

            ds = PaymentDAL.GetPaymentDetails(ReceiptNumber);
            if (!oPayment.MapData(ds)) oPayment = null;
            return oPayment;
        }

        public DataTable VerifyReceipt()
        {
            PaymentDAL paymentDAL = new PaymentDAL();
            return paymentDAL.VerifyPatientReceipt(ReceiptNo);
        }

        public int VerifyPaymentAmount()
        {
            DataSet ds = new DataSet();
            PaymentDAL paymentDAL = new PaymentDAL();
            int PaymentCheck = 0;

            PaymentCheck= paymentDAL.VerifyPaymentAmount(ref  PaymentCheck, PatientFileNo, InvoiceNo, AmountPaid);
            return PaymentCheck;
        }


        public DataTable GetHospitalSuppliers()
        {
            PaymentDAL paymentDAL = new PaymentDAL();
            return paymentDAL.GetHospitalSuppliers();
        }

        public DataTable LoadPatientFiles()
        {
            PatientDAL patientDAL = new PatientDAL();
            return patientDAL.LoadPatientFiles();
        }
        #endregion

        #region Get Functions

        //////////////////////////////////////////////////////////////////////////////
        protected static int GetInt(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? Convert.ToInt32(row[columnName]) : Constants.NullInt;
        }

        //////////////////////////////////////////////////////////////////////////////
        protected static DateTime GetDateTime(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? Convert.ToDateTime(row[columnName]) : Constants.NullDateTime;
        }

        //////////////////////////////////////////////////////////////////////////////
        protected static Decimal GetDecimal(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? Convert.ToDecimal(row[columnName]) : Constants.NullDecimal;
        }

        //////////////////////////////////////////////////////////////////////////////
        protected static bool GetBool(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? Convert.ToBoolean(row[columnName]) : false;
        }

        //////////////////////////////////////////////////////////////////////////////
        protected static string GetString(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? Convert.ToString(row[columnName]) : Constants.NullString;
        }

        //////////////////////////////////////////////////////////////////////////////
        protected static double GetDouble(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? Convert.ToDouble(row[columnName]) : Constants.NullDouble;
        }

        //////////////////////////////////////////////////////////////////////////////
        protected static float GetFloat(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? Convert.ToSingle(row[columnName]) : Constants.NullFloat;
        }

        //////////////////////////////////////////////////////////////////////////////
        protected static Guid GetGuid(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? (Guid)(row[columnName]) : Constants.NullGuid;
        }

        //////////////////////////////////////////////////////////////////////////////
        protected static long GetLong(DataRow row, string columnName)
        {
            return (row[columnName] != DBNull.Value) ? (long)(row[columnName]) : Constants.NullLong;
        }

        #endregion
    }
}
