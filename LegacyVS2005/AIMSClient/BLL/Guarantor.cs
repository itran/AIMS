using System;
using System.Collections.Generic;
using System.Text;
using AIMS.Common;
using AIMS.DAL;
using System.Data;

namespace AIMS.BLL
{
    public class Guarantor : BaseObject
    {
        #region Fields
        private Int32  _GuarantorID             = Constants.NullInt;
        private Int32  _GuarantorAddressTypeID  = Constants.NullInt;
        private Int32  _GuarantorAddressID      = Constants.NullInt;
        private Int32 _GuarantorCountryID       = Constants.NullInt;
        private string _GuarantorName           = Constants.NullString;
        private string _GuarantorPhoneNo        = Constants.NullString;
        private string _GuarantorFaxNo          = Constants.NullString;
        private string _GuarantorEmailAddress   = Constants.NullString;
        private string _GuarantorActiveYN       = Constants.NullString;
        private string _GuarantorAddr1          = Constants.NullString;
        private string _GuarantorAddr2          = Constants.NullString;
        private string _GuarantorAddr3          = Constants.NullString;
        private string _GuarantorAddr4          = Constants.NullString;
        private string _GuarantorAddrCity       = Constants.NullString;
        private string _GuarantorProvince       = Constants.NullString;
        private string _GuarantorAddrPostalCode = Constants.NullString;        
        private string _LoggedOnUser            = Constants.NullString;
        private string _GuarantorContactPerson  = Constants.NullString;        
        #endregion

        #region Public Properties
        public string GuarantorProvince
        {
            get { return _GuarantorProvince; }
            set { _GuarantorProvince = value; }
        }

        public string GuarantorAddrPostalCode
        {
            get { return _GuarantorAddrPostalCode; }
            set { _GuarantorAddrPostalCode = value; }
        }

        public string GuarantorAddrCity
        {
            get { return _GuarantorAddrCity; }
            set { _GuarantorAddrCity = value; }
        }

        public string GuarantorAddr4
        {
            get { return _GuarantorAddr4; }
            set { _GuarantorAddr4 = value; }
        }

        public string GuarantorAddr3
        {
            get { return _GuarantorAddr3; }
            set { _GuarantorAddr3 = value; }
        }

        public string GuarantorAddr2
        {
            get { return _GuarantorAddr2; }
            set { _GuarantorAddr2 = value; }
        }

        public string GuarantorAddr1
        {
            get { return _GuarantorAddr1; }
            set { _GuarantorAddr1 = value; }
        }

        public Int32 GuarantorCountryID
        {
            get { return _GuarantorCountryID; }
            set { _GuarantorCountryID = value; }
        }

        public Int32 GuarantorAddressTypeID
        {
            get { return _GuarantorAddressTypeID; }
            set { _GuarantorAddressTypeID = value; }
        }

        public Int32 GuarantorID
        {
            get { return _GuarantorID; }
            set { _GuarantorID = value; }
        }

        public Int32 GuarantorAddressID
        {
            get { return _GuarantorAddressID; }
            set { _GuarantorAddressID = value; }
        }

        public string LoggedOnUser
        {
            get { return _LoggedOnUser; }
            set { _LoggedOnUser = value; }
        }

        public string GuarantorActiveYN
        {
            get { return _GuarantorActiveYN; }
            set { _GuarantorActiveYN = value; }
        }

        public string GuarantorEmailAddress
        {
            get { return _GuarantorEmailAddress; }
            set { _GuarantorEmailAddress = value; }
        }

        public string GuarantorName
        {
            get { return _GuarantorName; }
            set { _GuarantorName = value; }
        }

        public string GuarantorPhoneNo
        {
            get { return _GuarantorPhoneNo; }
            set { _GuarantorPhoneNo = value; }
        }

        public string GuarantorFaxNo
        {
            get { return _GuarantorFaxNo; }
            set { _GuarantorFaxNo = value; }
        }

        public string GuarantorContactPerson
        {
            get { return _GuarantorContactPerson; }
            set { _GuarantorContactPerson = value; }
        }

        
        #endregion

        #region Public Functions

        public override bool MapData(DataRow row)
        {
            GuarantorID = GetInt(row, "GUARANTOR_ID");
            GuarantorName = GetString(row, "GUARANTOR_NAME");
            GuarantorPhoneNo = GetString(row, "GUARANTOR_PHONE_NO");
            GuarantorFaxNo = GetString(row, "GUARANTOR_FAX_NO");
            GuarantorAddressID = GetInt(row, "ADDRESS_ID");
            GuarantorEmailAddress = GetString(row, "GUARANTOR_EMAIL_ADDRESS");
            GuarantorActiveYN = GetString(row, "GUARANTOR_ACTIVE_YN");
            GuarantorContactPerson  = GetString(row, "GUARANTOR_CONTACT_PERSON"); 
            return base.MapData(row);
        }

        public Guarantor GetGuarantorDetails(string GuarantorID)
        {
            Guarantor oGuarantor = new Guarantor();
            DataSet ds = new DataSet();
            GuarantorDAL guarantorDAL = new GuarantorDAL();

            ds = guarantorDAL.GetGuarantorDetails(GuarantorID);
            if (!oGuarantor.MapData(ds)) oGuarantor = null;
            return oGuarantor;
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
            bool bSaved = false;
            bSaved = invoiceDAL.DelInvoiceMedicalTreatment(InvoiceMedicalTreatmentID, InvoiceID);
            invoiceDAL = null;
            return bSaved;
        }


        public bool SaveGuarantorDetails()
        {
            Guarantor  oInvoice = new Guarantor();
            DataSet ds = new DataSet();
            GuarantorDAL guarantorDAL = new GuarantorDAL();
            bool bSaved = false;
            int _guaID = GuarantorID ;

            bSaved = guarantorDAL.Guarantor_Save(ref _guaID, GuarantorName, GuarantorPhoneNo, GuarantorFaxNo, GuarantorAddressTypeID, GuarantorAddr1, GuarantorAddr2, GuarantorAddr3, GuarantorAddr4, GuarantorAddrCity, GuarantorProvince, GuarantorCountryID ,GuarantorEmailAddress , GuarantorActiveYN, LoggedOnUser, GuarantorAddrPostalCode, GuarantorContactPerson );
            GuarantorID = _guaID;

            return bSaved;
        }

        public DataTable VerifyGuarantor()
        {
            GuarantorDAL guarantorDAL = new GuarantorDAL ();
            return guarantorDAL.VerifyGuarantor(GuarantorName);
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
