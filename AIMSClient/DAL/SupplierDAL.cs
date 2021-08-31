using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL
{

    public class SupplierDAL : DataServiceBase
    {
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public SupplierDAL() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public SupplierDAL(IDbTransaction txn) : base(txn) { }

        public DataSet InvoiceGetAll()
        {
            return ExecuteDataSet("AIMS_INVOICE_GET_ALL", null);
        }

        public DataSet GetSupplierDetails(string SupplierID)
        {
            return ExecuteDataSet("AIMS_SUPPLIER_GET",
                CreateParameter("@SupplierID", SqlDbType.VarChar , SupplierID));
        }

        public bool SupplierSave_Save(ref int SupplierID, string SupplierName, string SupplierAccountNo, int SupplierTypeID, string SupplierContactName, string SupplierEmailAddress, string SupplierPhoneNo, string SupplierFaxNo, string SupplierMobileNo, string SupplierActiveYN, string SupplierAddr1, string SupplierAddr2, string SupplierAddr3, string SupplierAddr4, string SupplierCity, string SupplierPostalCode, int SupplierCountryID, string LoggedOnUser, string SupplierProvince, string DoctorSupplier, string DoctorNameInitials, string DoctorSurname, string AdminName, string AdminTelNo, string AdminFax,  string AdminEmail, string AdminCellNo)
        {
            bool retVal = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_SUPPLIER_ADD",
            CreateParameter("@SupplierID",          SqlDbType.Int,      SupplierID , ParameterDirection.InputOutput),
            CreateParameter("@SupplierName",        SqlDbType.VarChar,  SupplierName),
            CreateParameter("@SupplierAccount",     SqlDbType.VarChar,  SupplierAccountNo),
            CreateParameter("@SupplierTypeID",      SqlDbType.Int,      SupplierTypeID),
            CreateParameter("@SupplierContactName", SqlDbType.VarChar,  SupplierContactName),
            CreateParameter("@SupplierEmailAddress",SqlDbType.VarChar,  SupplierEmailAddress),
            CreateParameter("@SupplierPhoneNo",     SqlDbType.VarChar,  SupplierPhoneNo),
            CreateParameter("@SupplierFaxNo",       SqlDbType.VarChar,  SupplierFaxNo),
            CreateParameter("@SupplierMobileNo",    SqlDbType.VarChar,  SupplierMobileNo),
            CreateParameter("@SupplierActiveYN",    SqlDbType.VarChar,  SupplierActiveYN),
            CreateParameter("@Address1",            SqlDbType.VarChar,  SupplierAddr1),
            CreateParameter("@Address2",            SqlDbType.VarChar,  SupplierAddr2),
            CreateParameter("@Address3",            SqlDbType.VarChar,  SupplierAddr3),
            CreateParameter("@Address4",            SqlDbType.VarChar,  SupplierAddr4),
            CreateParameter("@Address5",            SqlDbType.VarChar,  SupplierCity),
            CreateParameter("@PostalCode",          SqlDbType.VarChar,  SupplierPostalCode),
            CreateParameter("@CountryID",           SqlDbType.Int,      SupplierCountryID),
            CreateParameter("@UserSignedOn",        SqlDbType.VarChar,  LoggedOnUser),
            CreateParameter("@Province",            SqlDbType.VarChar,  SupplierProvince),
            CreateParameter("@DoctorSupplier",      SqlDbType.VarChar,  DoctorSupplier),
            CreateParameter("@DoctorNameInitials",  SqlDbType.VarChar,  DoctorNameInitials),
            CreateParameter("@DoctorSurname",       SqlDbType.VarChar,  DoctorSurname),
            CreateParameter("@AdminName",           SqlDbType.VarChar,  AdminName),
            CreateParameter("@AdminTelNo",          SqlDbType.VarChar,  AdminTelNo),
            CreateParameter("@AdminFax",            SqlDbType.VarChar,  AdminFax ),
            CreateParameter("@AdminEmail",          SqlDbType.VarChar,  AdminEmail),
            CreateParameter("@AdminCellNo",         SqlDbType.VarChar,  AdminCellNo));

            SupplierID = (int)cmd.Parameters["@SupplierID"].Value;

            cmd.Dispose();
            return true; 
        }

        public void Invoice_Delete(int personID)
        {
            ExecuteNonQuery("Invoice_Disable",
                CreateParameter("@PersonID", SqlDbType.Int, personID));
        }

        public DataSet LoadTitles()
        {
            return ExecuteDataSet("AIMS_TITLES_GET");
        }

        public DataTable LoadSuppliers()
        {
            return ExecuteDataTable("AIMS_SUPPLIER_GET_ALL");
        }

        public DataTable LoadMedicalTreatments()
        {
            return ExecuteDataTable("AIMS_SUPPLIER_GET_ALL");
        }

        public DataTable PatientFileNoVerify(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_VERIFY", CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }
        
        public DataTable VerifySupplier(string SupplierName)
        {
            return ExecuteDataTable("AIMS_SUPPLIER_VERIFY", CreateParameter("@SupplierName", SqlDbType.VarChar, SupplierName));
        }
        
        public DataSet GetPatientInvoices(string patientID)
        {
            return ExecuteDataSet("AIMS_PATIENT_INVOICES_GET",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientID));
        }

        public bool ServiceProvider_Save(ref Int64 ServiceProviderID, string SupplierName,  int SupplierTypeID, string SupplierEmailAddress, string SupplierPhoneNo, string SupplierFaxNo, string LoggedOnUser, string PatientFileNo, string SupplierAdminName, string SupplierAdminTel, string SupplierAdminFax, string SupplierAdminEmail)
        {
            bool retVal = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_PATIENT_SERVICE_PROVIDER_ADD",
            CreateParameter("@ServiceProviderID",       SqlDbType.BigInt, ServiceProviderID, ParameterDirection.InputOutput),
            CreateParameter("@ServiceProviderType",     SqlDbType.Int, SupplierTypeID),
            CreateParameter("@PatientFileNo",           SqlDbType.VarChar, PatientFileNo),
            CreateParameter("@ServiceProviderName",     SqlDbType.VarChar, SupplierName),
            CreateParameter("@ServiceProviderPhone",    SqlDbType.VarChar, SupplierPhoneNo),
            CreateParameter("@ServiceProviderFax",      SqlDbType.VarChar, SupplierFaxNo),
            CreateParameter("@ServiceProviderEmail",    SqlDbType.VarChar, SupplierEmailAddress),
            CreateParameter("@LoggedInUser",            SqlDbType.VarChar, LoggedOnUser),
            CreateParameter("@ServiceProviderAdminName", SqlDbType.VarChar, SupplierAdminName),
            CreateParameter("@ServiceProviderAdminTel",         SqlDbType.VarChar, SupplierAdminTel),
            CreateParameter("@ServiceProviderAdminFax",         SqlDbType.VarChar, SupplierAdminFax),
            CreateParameter("@ServiceProviderAdminEmail",       SqlDbType.VarChar, SupplierAdminEmail));

            ServiceProviderID = (Int64)cmd.Parameters["@ServiceProviderID"].Value;

            cmd.Dispose();
            return true;
        }

        public bool ServiceProvider_Delete(string  ServiceProviderID)
        {
            bool retVal = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_PATIENT_SERVICE_PROVIDER_DEL",
            CreateParameter("@ServiceProviderID",       SqlDbType.VarChar, ServiceProviderID));

            cmd.Dispose();
            return true;
        }


    }
}