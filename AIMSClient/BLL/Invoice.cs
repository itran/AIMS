using System;
using System.Collections.Generic;
using System.Text;
using AIMS.Common;
using AIMS.DAL;
using System.Data;

namespace AIMS.BLL
{
    public class Invoice :BaseObject
    {
        #region Fields
        private Int32  _InvoiceID = Constants.NullInt;
        private string _InvoiceNo = Constants.NullString;
        private Int64  _InvoicePatientID = 0;
        private string _PatientFileNo = Constants.NullString;
        private string _invoiceDate = Constants.NullString;
        private Int64 _SupplierID = 0;
        private string _SupplierName = Constants.NullString;
        private string _invoiceAmountReceived = Constants.NullString;
        private string _invoiceDateAdmitted = Constants.NullString;
        private string _invoiceDateDischarged = Constants.NullString;
        private Int64  _invoiceMedicalTreatmentID = 0;
        private string _invoiceGeneratedYN = Constants.NullString;
        private string _invoiceLockedYN = Constants.NullString;
        private string _invoiceDateOfCourier = Constants.NullString;
        private string _invoiceLateYN = Constants.NullString;
        private string _PatientFullName = Constants.NullString;
        private string _InvoiceDate = "";
        private string _MedicalTreatmentNotes = "";
        private string _ServiceRendered = "";
        private Int64 _MedicalTreatmentID = 0; 
        private Int64 _ServiceRenderedID = 0;
        private string _MedicalTreatmentDate = "";
        private string _LoggedOnUser = Constants.NullString;
        private string _patientActive = "";
        private Int64 _supplierId = 0;
        private Int64 _serviceID = 0;
        private Int64 _patientID = 0;
        private string _invoiceCancelledYN = Constants.NullString;        
        #endregion

        #region Public Properties

        public Int64 InvoicePatientID
        {
            get { return _InvoicePatientID; }
            set { _InvoicePatientID = value; }
        }

        public Int32  InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

        public Int64 SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }

        public string SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }

        public Int64 PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }
        }

        public string LoggedOnUser
        {
            get { return _LoggedOnUser; }
            set { _LoggedOnUser = value; }
        }

        public string InvoiceNumber
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }

        public string PatientFileNo
        {
            get { return _PatientFileNo; }
            set { _PatientFileNo = value; }
        }

        public string PatientFullName
        {
            get { return _PatientFullName; }
            set { _PatientFullName = value; }
        }

        public string InvoiceDate
        {
            get { return _invoiceDate; }
            set { _invoiceDate = value; }
        }

        public string InvoiceAmoutReceived
        {
            get { return _invoiceAmountReceived; }
            set { _invoiceAmountReceived = value; }
        }

        public string InvoiceDateAdmitted
        {
            get { return _invoiceDateAdmitted ; }
            set { _invoiceDateAdmitted = value; }
        }

        public string InvoiceDateDischarged
        {
            get { return _invoiceDateDischarged; }
            set { _invoiceDateDischarged = value; }
        }

        public Int64 InvoiceMedicalTreatmentID
        {
            get { return _invoiceMedicalTreatmentID ; }
            set { _invoiceMedicalTreatmentID = value; }
        }

        public string InvoiceGeneratedYN
        {
            get { return _invoiceGeneratedYN ; }
            set { _invoiceGeneratedYN = value; }
        }

        public string InvoiceLockedYN
        {
            get { return _invoiceLockedYN ; }
            set { _invoiceLockedYN = value; }
        }

        public string InvoiceDateOfCourier
        {
            get { return _invoiceDateOfCourier ; }
            set { _invoiceDateOfCourier = value; }
        }

        public string InvoiceLateYN
        {
            get { return _invoiceLateYN ; }
            set { _invoiceLateYN = value; }
        }

        string _DoctorOwingYN = "";
        public string DoctorOwingYN
        {
            get { return _DoctorOwingYN; }
            set { _DoctorOwingYN = value; }
        }
        
        public string InvoiceCancelledYN
        {
            get { return _invoiceCancelledYN ; }
            set { _invoiceCancelledYN = value; }
        }

        public string MedicalTreatmentNotes
        {
            get { return _MedicalTreatmentNotes; }
            set { _MedicalTreatmentNotes = value; }
        }

        public string MedicalTreatmentDate
        {
            get { return _MedicalTreatmentDate; }
            set { _MedicalTreatmentDate = value; }
        }

        public string ServiceRendered
        {
            get { return _ServiceRendered; }
            set { _ServiceRendered = value; }
        }

        public Int64 MedicalTreatmentID
        {
            get { return _MedicalTreatmentID; }
            set { _MedicalTreatmentID = value; }
        }

        public Int64 ServiceRenderedID
        {
            get { return _ServiceRenderedID; }
            set { _ServiceRenderedID = value; }
        }

        public string PatientActiveYN
        {
            get { return _patientActive; }
            set { _patientActive = value; }
        }

        //public Int64 SupplierID
        //{
        //    get { return _supplierId ; }
        //    set { _supplierId = value; }
        //}

        public Int64 ServiceID
        {
            get { return _serviceID ; }
            set { _serviceID = value; }
        }

        private string _LateInvoiceSent = Constants.NullString;
        public string LateInvoiceSent
        {
            get { return _LateInvoiceSent; }
            set { _LateInvoiceSent = value; }
        }
        
        private string _LateInvoiceSentDate = Constants.NullString;
        public string LateInvoiceSentDate
        {
            get { return _LateInvoiceSentDate; }
            set { _LateInvoiceSentDate = value; }
        }

        private string _InvoiceSentWaybillNo = Constants.NullString;
        public string InvoiceSentWaybillNo
        {
            get { return _InvoiceSentWaybillNo; }
            set { _InvoiceSentWaybillNo = value; }
        }
        #endregion

        #region Public Functions

        public override bool MapData(DataRow row)
        {
            InvoiceID = GetInt(row, "invoice_id");
            InvoiceNumber= GetString(row, "invoice_no");
            InvoiceDate= GetString(row, "invoice_date");
            InvoiceAmoutReceived= GetString(row, "invoice_amount_received");

            InvoiceGeneratedYN= GetString(row, "Generated_yn");
            InvoiceLockedYN= GetString(row, "locked_yn");
            InvoiceLateYN = GetString(row, "LATE_INVOICE_YN");
            PatientFileNo = GetString(row, "patient_file_no");
            PatientFullName = GetString(row, "Patient_Name");
            SupplierID = GetInt(row, "supplier_id");
            ServiceID = GetInt(row, "service_id");
            PatientID = GetInt(row, "patient_id");
            PatientActiveYN = GetString(row, "patient_file_active_yn");
            InvoiceCancelledYN = GetString(row, "cancelled_yn");
            DoctorOwingYN = GetString(row, "doctor_owing");
            LateInvoiceSent = GetString(row, "late_invoice_sent");
            LateInvoiceSentDate = GetString(row, "late_invoice_sent_date");
            SupplierName = GetString(row, "supplier_name");
            InvoiceSentWaybillNo = GetString(row, "invoice_sent_waybill_no");
            return base.MapData(row);
        }

        public Invoice GetInvoiceDetails(string InvoiceID)
        {
            Invoice oInvoice = new Invoice();
            DataSet ds = new DataSet();
            InvoiceDAL invoiceDAL = new InvoiceDAL();

            ds = invoiceDAL.GetInvoiceDetails(InvoiceID);
            if (!oInvoice.MapData(ds)) oInvoice = null;
            return oInvoice;
        }

        public DataTable GetInvoiceMedicalTreatment(string InvoiceID)
        {
            Invoice oInvoice = new Invoice();
            DataTable dtInvoiceMedicalTreatment = new DataTable();
            InvoiceDAL invoiceDAL = new InvoiceDAL();

            dtInvoiceMedicalTreatment = invoiceDAL.GetInvoiceMedicalTreatment(InvoiceID);
            return dtInvoiceMedicalTreatment;
        }

        public bool DelInvoiceMedicalTreatment(string InvoiceMedicalTreatmentID, string InvoiceID)
        {
            Invoice oInvoice = new Invoice();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            bool  bSaved = false;
            bSaved = invoiceDAL.DelInvoiceMedicalTreatment(InvoiceMedicalTreatmentID, InvoiceID);
            invoiceDAL = null;
            return bSaved;
        }

        public bool SaveInvoiceDetails(Invoice InvoiceDAL)
        {
            Invoice oInvoice = new Invoice();
            DataSet ds = new DataSet();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            bool  bSaved = false;
            int _invID = InvoiceID;

            bSaved = invoiceDAL.Invoice_Save(ref _invID, InvoiceNumber.ToString(), PatientFileNo, InvoiceDate.ToString(), InvoiceAmoutReceived.ToString(), InvoiceGeneratedYN.ToString(), InvoiceLockedYN.ToString(), InvoiceLateYN.ToString(), LoggedOnUser.ToString(), SupplierID.ToString(), ServiceID.ToString(), InvoiceCancelledYN, DoctorOwingYN, LateInvoiceSent, LateInvoiceSentDate,InvoiceSentWaybillNo);
            InvoiceID = _invID;

            return bSaved;
        }

        public bool SaveNewService(string ServiceDesc, string userSignedOn)
        {            
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            bool bSaved = false;
            
            bSaved = invoiceDAL.SaveNewService(ServiceDesc, userSignedOn);
            
            return bSaved;
        }

        public bool SaveNewCountry(string CountryDesc, string UserSignedOn)
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            bool bSaved = false;

            bSaved = invoiceDAL.SaveNewCountry(CountryDesc, UserSignedOn);

            return bSaved;
        }

        public DataTable CheckIfServiceExist(string ServiceDesc)
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            DataTable dtServiceCheck = invoiceDAL.CheckIfServiceExist(ServiceDesc);
            invoiceDAL = null;
            return dtServiceCheck;
        }

        public DataTable CheckIfCountryExist(string CountryDesc)
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            DataTable dtServiceCheck = invoiceDAL.CheckIfCountryExist(CountryDesc);
            invoiceDAL = null;
            return dtServiceCheck;
        }

        public bool UnlockInvoice()
        {
            Invoice oInvoice = new Invoice();            
            InvoiceDAL invoiceDAL = new InvoiceDAL();

            bool bSaved = false;         
            bSaved = invoiceDAL.Invoice_Unlock(InvoiceID, LoggedOnUser.ToString());
            oInvoice = null;
            invoiceDAL = null;
            return bSaved;
        }

        public DataSet LoadTitles()
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            return invoiceDAL.LoadTitles();
        }

        public DataTable LoadSuppliers()
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            return invoiceDAL.LoadSuppliers();
        }

        public DataTable LoadServices()
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            return invoiceDAL.LoadServices();
        }

        public DataTable LoadPatientFiles()
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            return invoiceDAL.LoadPatientFiles();
        }

        public DataTable LoadMedicalTreatments()
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            return invoiceDAL.LoadSuppliers();
        }

        public DataTable PatientValidate(string PatientFileNo)
        {
            DataTable dtPatientFileNoCheck = new DataTable();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            dtPatientFileNoCheck =  invoiceDAL.PatientFileNoVerify(PatientFileNo);
            return dtPatientFileNoCheck;
        }

        public DataTable PatientInvoiceNoVerify(string PatientFileNo, string PatientInvoiceNo)
        {
            DataTable dtPatientInvoiceNoCheck = new DataTable();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            dtPatientInvoiceNoCheck =  invoiceDAL.PatientInvoiceNoVerify (PatientFileNo, PatientInvoiceNo, "N" );
            return dtPatientInvoiceNoCheck;
        }

        public DataTable PatientInvoiceNoVerify(string PatientFileNo, string PatientInvoiceNo, string LateInvoiceYN)
        {
            DataTable dtPatientInvoiceNoCheck = new DataTable();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            dtPatientInvoiceNoCheck = invoiceDAL.PatientInvoiceNoVerify(PatientFileNo, PatientInvoiceNo, LateInvoiceYN);
            return dtPatientInvoiceNoCheck;
        }

        public DataSet GetPatientInvoices(string patientFileNo, string includeLateInv, string DoctorOwing, string ShowSentLateInvoices)
        {
            Invoice oInvoice = new Invoice();
            DataSet ds = new DataSet();
            InvoiceDAL invoiceDAL = new InvoiceDAL();

            ds = invoiceDAL.GetPatientInvoices(patientFileNo, includeLateInv, DoctorOwing, ShowSentLateInvoices);

            return ds;
        }

        public bool Medical_Treatment_Save()
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            Int64 _TreatmentID = 0;
            Int64 _ServID = 0;
            bool bSaved = false;

            bSaved =  invoiceDAL.Medical_Treatment_Save(ref _TreatmentID, ref _ServID, MedicalTreatmentNotes, ServiceRendered, InvoiceID, SupplierID, MedicalTreatmentDate );

            MedicalTreatmentID = _TreatmentID;
            ServiceRenderedID = _ServID;
            return bSaved;
        }

        public DataTable GetSupplierCostLimit(Int64 SupplierTypeID)
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            DataTable dtSupplierCostLimit = new DataTable();
            dtSupplierCostLimit = invoiceDAL.GetSupplierCostLimit(SupplierTypeID);
            return dtSupplierCostLimit;
        }

        public DataTable GetSupplierDetails(string SupplierName)
        {
            DataTable dtSupplierDetails = new DataTable();
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            dtSupplierDetails = invoiceDAL.GetSupplierDetails(SupplierName);
            return dtSupplierDetails;
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
