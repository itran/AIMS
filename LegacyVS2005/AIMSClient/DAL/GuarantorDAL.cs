using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL
{
    public class GuarantorDAL : DataServiceBase
    {
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public GuarantorDAL() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public GuarantorDAL(IDbTransaction txn) : base(txn) { }

        public DataSet InvoiceGetAll()
        {
            return ExecuteDataSet("AIMS_INVOICE_GET_ALL", null);
        }

        public DataTable GetInvoiceMedicalTreatment(string InvoiceID)
        {
            return ExecuteDataTable("AIMS_INVOICE_MEDICAL_TREATMENT_GET",
                CreateParameter("@InvoiceID", SqlDbType.VarChar, InvoiceID));
        }

        public DataTable VerifyGuarantor(string GuarantorName)
        {
            return ExecuteDataTable("AIMS_GUARANTOR_VERIFY",
                CreateParameter("@GuarantorName", SqlDbType.VarChar, GuarantorName));
        }
        

        public DataSet GetGuarantorDetails(string GuarantorID)
        {
            return ExecuteDataSet("AIMS_GUARANTOR_GET",
                CreateParameter("@GuarantorID", SqlDbType.VarChar, GuarantorID));
        }

        public DataSet GetPatientGuarantorAddress(string PatientFileNo)
        {
            return ExecuteDataSet("AIMS_PATIENT_GUARANTOR_ADDRESS_GET",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }

        public bool Guarantor_Save(ref int GuarantorID, string GuarantorName, string GuarantorPhoneNo, string GuarantorFaxNo,int GuarantorAddressTypeID, string GuarantorAddr1, string GuarantorAddr2,string GuarantorAddr3,string GuarantorAddr4,string GuarantorAddrCity,string GuarantorProvince, Int32 GuarantorCountryID, string GuarantorEmailAddress , string GuarantorActiveYN, string UserSignedOn, string GuarantorPostalCode, string GuarantorContactPerson)
        {
            bool retVal = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_GUARANTOR_ADD",
            CreateParameter("@GuarantorID",             SqlDbType.Int,      GuarantorID, ParameterDirection.InputOutput),
            CreateParameter("@GuarantorName",           SqlDbType.VarChar,  GuarantorName),
            CreateParameter("@GuarantorPhoneNo",        SqlDbType.VarChar,  GuarantorPhoneNo),
            CreateParameter("@GuarantorFaxNo",          SqlDbType.VarChar,  GuarantorFaxNo),
            CreateParameter("@AddressTypeID",           SqlDbType.Int,      GuarantorAddressTypeID),
            CreateParameter("@Address1",                SqlDbType.VarChar,  GuarantorAddr1),
            CreateParameter("@Address2",                SqlDbType.VarChar,  GuarantorAddr2),
            CreateParameter("@Address3",                SqlDbType.VarChar,  GuarantorAddr3),
            CreateParameter("@Address4",                SqlDbType.VarChar,  GuarantorAddr4),
            CreateParameter("@Address5",                SqlDbType.VarChar,  GuarantorAddrCity),
            CreateParameter("@PostalCode",              SqlDbType.VarChar,  GuarantorPostalCode),
            CreateParameter("@GuarantorProvince",       SqlDbType.VarChar,  GuarantorProvince),
            CreateParameter("@CountryID",               SqlDbType.Int,      GuarantorCountryID),
            CreateParameter("@GuarantorEmailAddress",   SqlDbType.VarChar,  GuarantorEmailAddress),
            CreateParameter("@GuarantorActiveYN",       SqlDbType.VarChar,  GuarantorActiveYN),
            CreateParameter("@UserSignedOn",            SqlDbType.VarChar,  UserSignedOn),
            CreateParameter("@ContactPerson",           SqlDbType.VarChar, GuarantorContactPerson));

            GuarantorID = (int)cmd.Parameters["@GuarantorID"].Value;

            cmd.Dispose();
            return true;
        }

        public bool Medical_Treatment_Save(ref Int64 MedicalTreatmentID, ref Int64 ServiceRenderedID, string MedicalTreatmentNotes, string ServiceRendered, Int64 InvoiceID, Int64 SupplierID, string MedicalTreatmentDate)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_INVOICE_MEDICAL_TREATMENT_ADD",
                CreateParameter("@InvoiceID", SqlDbType.Int, System.Convert.ToInt32(InvoiceID)),
                CreateParameter("@MedicalTreatmentID", SqlDbType.Int, System.Convert.ToInt32(MedicalTreatmentID), ParameterDirection.InputOutput),
                CreateParameter("@ServiceRenderedID", SqlDbType.Int, System.Convert.ToInt32(ServiceRenderedID), ParameterDirection.InputOutput),
                CreateParameter("@SupplierID", SqlDbType.Int, System.Convert.ToInt32(SupplierID)),
                CreateParameter("@MedicalTreatmentNotes", SqlDbType.VarChar, MedicalTreatmentNotes),
                CreateParameter("@ServiceRenderedDesc", SqlDbType.VarChar, ServiceRendered),
                CreateParameter("@DateOfTreatmenmt", SqlDbType.VarChar, MedicalTreatmentDate)
                );

            MedicalTreatmentID = (int)cmd.Parameters["@MedicalTreatmentID"].Value;
            ServiceRenderedID = (int)cmd.Parameters["@ServiceRenderedID"].Value;

            cmd.Dispose();
            return true;
        }


        public DataSet LoadTitles()
        {
            return ExecuteDataSet("AIMS_TITLES_GET");
        }

        public DataTable LoadSuppliers()
        {
            return ExecuteDataTable("AIMS_SUPPLIER_GET_ALL");
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

        public DataSet GetPatientInvoices(string patientID, string includeLateInv)
        {
            return ExecuteDataSet("AIMS_PATIENT_INVOICES_GET",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientID));
        }

    }
}