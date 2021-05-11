using System;
using System.Collections.Generic;
using System.Text;
using AIMS.Common;
using AIMS.DAL;
using System.Data;

namespace AIMS.BLL
{
    public class Supplier : BaseObject
    {
        #region Fields

        private Int64 _ServiceProviderID = 0;
        private int _SupplierID = 0;
        private int  _SupplierTypeID = 0;
        private int _SupplierTitleID = 0;
        private string _SupplierName = Constants.NullString;
        private string _SupplierAddressTypeID = "0";
        private string _SupplierEmailAddress = Constants.NullString;
        private string _SupplierPhoneNo = Constants.NullString;
        private string _SupplierFaxNo = Constants.NullString;
        private string _SupplierMobileNo = "";
        private string _SupplierActiveYN = Constants.NullString;
        private string _DoctorSupplierYN = Constants.NullString;        
        private string _SupplierAccountNo = Constants.NullString;
        private string _SupplierContactName = Constants.NullString;

        private string _SupplierAddress1 = Constants.NullString;
        private string _SupplierAddress2 = Constants.NullString;
        private string _SupplierAddress3 = Constants.NullString;
        private string _SupplierAddress4 = Constants.NullString;
        private string _SupplierCity = Constants.NullString;
        private string _SupplierPostalCode = Constants.NullString;
        private string _SupplierProvince = Constants.NullString;
        private int _SupplierCountryID = 0;
        private string _LoggedOnUser = Constants.NullString;
        private int _SupplierAddressID = 0;
        private string _patientfileno = Constants.NullString;

        #endregion

        #region Public Properties
        public int  SupplierTypeID
        {
            get { return _SupplierTypeID; }
            set { _SupplierTypeID = value; }
        }

        public int SupplierTitleID
        {
            get { return _SupplierTitleID; }
            set { _SupplierTitleID = value; }
        }

        public string SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }

        public string SupplierAddressTypeID
        {
            get { return _SupplierAddressTypeID; }
            set { _SupplierAddressTypeID = value; }
        }

        public string SupplierEmailAddress
        {
            get { return _SupplierEmailAddress; }
            set { _SupplierEmailAddress = value; }
        }

        public string SupplierPhoneNo
        {
            get { return _SupplierPhoneNo; }
            set { _SupplierPhoneNo = value; }
        }

        public string SupplierFaxNo
        {
            get { return _SupplierFaxNo; }
            set { _SupplierFaxNo = value; }
        }

        public string  SupplierMobileNo
        {
            get { return _SupplierMobileNo; }
            set { _SupplierMobileNo = value; }
        }

        public string SupplierActiveYN
        {
            get { return _SupplierActiveYN; }
            set { _SupplierActiveYN = value; }
        }

        public string DoctorSupplierYN
        {
            get { return _DoctorSupplierYN; }
            set { _DoctorSupplierYN = value; }
        }
        string _DoctorNameInitials = "";
        public string DoctorNameInitials
        {
            get { return _DoctorNameInitials; }
            set { _DoctorNameInitials = value; }
        }

        string _DoctorSurname = "";
        public string DoctorSurname
        {
            get { return _DoctorSurname; }
            set { _DoctorSurname = value; }
        }

        public string SupplierAccountNo
        {
            get { return _SupplierAccountNo; }
            set { _SupplierAccountNo = value; }
        }

        public string SupplierContactName
        {
            get { return _SupplierContactName; }
            set { _SupplierContactName = value; }
        }

        public int SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }

        public Int64 ServiceProviderID
        {
            get { return _ServiceProviderID ; }
            set { _ServiceProviderID = value; }
        }

        
        public string SupplierAddress1
        {
            get { return _SupplierAddress1; }
            set { _SupplierAddress1 = value; }
        }

        public string SupplierAddress2
        {
            get { return _SupplierAddress2; }
            set { _SupplierAddress2 = value; }
        }

        public string SupplierAddress3
        {
            get { return _SupplierAddress3; }
            set { _SupplierAddress3 = value; }
        }        

        public string SupplierAddress4
        {
            get { return _SupplierAddress4; }
            set { _SupplierAddress4 = value; }
        }

        public string SupplierCity
        {
            get { return _SupplierCity; }
            set { _SupplierCity = value; }
        }

        public string SupplierPostalCode
        {
            get { return _SupplierPostalCode; }
            set { _SupplierPostalCode = value; }
        }

        public string SupplierProvince
        {
            get { return _SupplierProvince; }
            set { _SupplierProvince = value; }
        }

        public string LoggedOnUser
        {
            get { return _LoggedOnUser; }
            set { _LoggedOnUser = value; }
        }         
        
        public int SupplierCountryID
        {
            get { return _SupplierCountryID; }
            set { _SupplierCountryID = value; }
        }

        public int SupplierAddressID
        {
            get { return _SupplierAddressID; }
            set { _SupplierAddressID = value; }
        }

        public string PatientFileNo
        {
            get { return _patientfileno; }
            set { _patientfileno = value; }
        }

        string _supplierAdminName = "";
        public string SupplierAdminName
        {
            get { return _supplierAdminName; }
            set { _supplierAdminName = value; }
        }

        string _supplierAdminTel = "";
        public string SupplierAdminTel
        {
            get { return _supplierAdminTel; }
            set { _supplierAdminTel = value; }
        }

        string _supplierAdminFax = "";
        public string SupplierAdminFax
        {
            get { return _supplierAdminFax; }
            set { _supplierAdminFax = value; }
        }

        string _supplierAdminEmail = "";
        public string SupplierAdminEmail
        {
            get { return _supplierAdminEmail; }
            set { _supplierAdminEmail = value; }
        }

        string _supplierAdminCellNo= "";
        public string SupplierAdminCellNo
        {
            get { return _supplierAdminCellNo; }
            set { _supplierAdminCellNo = value; }
        }
        #endregion

        #region Public Functions

        /// <summary>
        /// This fucntion Maps the data in the datatable to the Invoice Object
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public override bool MapData(DataRow row)
        {
            SupplierID = GetInt(row, "SUPPLIER_ID");
            SupplierTypeID = GetInt(row, "SUPPLIER_TYPE_ID");
            SupplierTitleID = GetInt(row, "TITLE_ID");
            SupplierName = GetString(row, "SUPPLIER_NAME");
            SupplierAddressID = GetInt(row, "ADDRESS_ID");
            SupplierEmailAddress = GetString(row, "SUPPLIER_EMAIL_ADDRESS");
            SupplierPhoneNo = GetString(row, "SUPPLIER_PHONE_NO");
            SupplierFaxNo = GetString(row, "SUPPLIER_FAX_NO");
            SupplierMobileNo = GetString(row, "SUPPLIER_MOBILE_NO");
            SupplierActiveYN = GetString(row, "SUPPLIER_ACTIVE_YN");
            SupplierAccountNo = GetString(row, "SUPPLIER_ACCOUNT_NO");
            SupplierContactName = GetString(row, "SUPPLIER_CONTACT_NAME");
            SupplierActiveYN = GetString(row, "SUPPLIER_ACTIVE_YN");
            DoctorSupplierYN = GetString(row, "DOCTOR_SUPPLIER_YN");

            try
            {
                SupplierAdminName = GetString(row, "ADMIN_NAME");
                SupplierAdminTel = GetString(row, "ADMIN_TEL_PHONE");
                SupplierAdminFax = GetString(row, "ADMIN_FAX");
                SupplierAdminEmail = GetString(row, "ADMIN_EMAIL");
                SupplierAdminCellNo = GetString(row, "ADMIN_CELL"); 
            }
            catch (Exception)
            {
            }

            return base.MapData(row);
        }

        /// <summary>
        /// This method returns a Patient object populated with patient details
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public Supplier GetSupplierDetails(string SupplierID)
        {
            Supplier oSupplier = new Supplier();
            DataSet ds = new DataSet();
            SupplierDAL supplierDAL = new SupplierDAL();

            ds = supplierDAL.GetSupplierDetails(SupplierID);
            if (!oSupplier.MapData(ds)) oSupplier = null;
            return oSupplier;
        }

        /// <summary>
        /// This method adds and updates invoice details
        /// </summary>
        /// <param name="patientDAL"></param>
        /// <returns></returns>
        public bool SaveInvoiceDetails()
        {
            SupplierDAL supplierDAL = new SupplierDAL();
            int _SupplierID = SupplierID;
            return supplierDAL.SupplierSave_Save(ref _SupplierID, SupplierName, SupplierAccountNo, SupplierTypeID, SupplierContactName, SupplierEmailAddress, SupplierPhoneNo, SupplierFaxNo, SupplierMobileNo, SupplierActiveYN, SupplierAddress1, SupplierAddress2, SupplierAddress3, SupplierAddress4, SupplierCity, SupplierPostalCode, SupplierCountryID, LoggedOnUser, SupplierProvince, DoctorSupplierYN, DoctorNameInitials, DoctorSurname, SupplierAdminName, SupplierAdminTel, SupplierAdminFax, SupplierAdminEmail, SupplierAdminCellNo);
            SupplierID = _SupplierID;
        }

        public DataTable VerifySupplier(string SupplierName)
        {
            SupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.VerifySupplier(SupplierName);
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

        public DataTable GetPatientServiceProviders(string PatientID)
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            return invoiceDAL.GetPatientServiceProviders(PatientID);
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
            dtPatientFileNoCheck = invoiceDAL.PatientFileNoVerify(PatientFileNo);
            return dtPatientFileNoCheck;
        }

        /// <summary>
        /// This method returns a Patient object populated with patient details
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        //public Invoice GetInvoiceDetails(string InvoiceID)
        //{
        //    Invoice oInvoice = new Invoice();
        //    DataSet ds = new DataSet();
        //    InvoiceDAL invoiceDAL = new InvoiceDAL();

        //    ds = invoiceDAL.GetInvoiceDetails(InvoiceID);
        //    if (!oInvoice.MapData(ds)) oInvoice = null;
        //    return oInvoice;
        //}

        public DataSet GetPatientInvoices(string patientFileNo,string includeInv, string DoctorOwing, string LateInvoiceSentYN)
        {
            Invoice oInvoice = new Invoice();
            DataSet ds = new DataSet();
            InvoiceDAL invoiceDAL = new InvoiceDAL();

            ds = invoiceDAL.GetPatientInvoices(patientFileNo, includeInv, DoctorOwing, "Y");

            return ds;
        }

        public DataTable CheckIfServiceExist(string ServiceDesc)
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            DataTable dtServiceCheck = invoiceDAL.CheckIfServiceExist(ServiceDesc);
            invoiceDAL = null;
            return dtServiceCheck;
        }

        public bool SaveNewService(string ServiceDesc, string UserSignedOn)
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            bool bSaved = false;

            bSaved = invoiceDAL.SaveNewService(ServiceDesc, UserSignedOn);

            return bSaved;
        }

        /// <summary>
        /// This method adds and updates invoice details
        /// </summary>
        /// <param name="patientDAL"></param>
        /// <returns></returns>
        public bool SaveServiceProvider()
        {
            SupplierDAL supplierDAL = new SupplierDAL();
            Int64 _serviceProviderID = ServiceProviderID;
            return supplierDAL.ServiceProvider_Save(ref _serviceProviderID, SupplierName, SupplierTypeID, SupplierEmailAddress, SupplierPhoneNo, SupplierFaxNo, LoggedOnUser, PatientFileNo, SupplierAdminName, SupplierAdminTel, SupplierAdminFax, SupplierAdminEmail);
            ServiceProviderID = _serviceProviderID;
        }

        public DataTable GetServiceProvider(string ServiceProviderID)
        {
            InvoiceDAL invoiceDAL = new InvoiceDAL();
            DataTable dtServiceProvider = invoiceDAL.GetServiceProvider(ServiceProviderID);
            invoiceDAL = null;
            return dtServiceProvider;
        }

        public bool ServiceProvider_Delete(string ServiceProviderID)
        {
            SupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.ServiceProvider_Delete(ServiceProviderID);
            
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
