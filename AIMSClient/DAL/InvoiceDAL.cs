using System;
using System.Collections.Generic;
using System.Text;
using AIMS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL
{

    public class InvoiceDAL : DataServiceBase
    {
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public InvoiceDAL() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public InvoiceDAL(IDbTransaction txn) : base(txn) { }

        public DataSet InvoiceGetAll()
        {
            return ExecuteDataSet("AIMS_INVOICE_GET_ALL", null);
        }

        public DataTable GetInvoiceMedicalTreatment(string InvoiceID)
        {
            return ExecuteDataTable("AIMS_INVOICE_MEDICAL_TREATMENT_GET",
                CreateParameter("@InvoiceID", SqlDbType.VarChar, InvoiceID));
        }

        public bool  DelInvoiceMedicalTreatment(string InvoiceMedicalTreatmentID, string InvoiceID)
        {
            bool retVal = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd,"AIMS_INVOICE_MEDICAL_TREATMENT_ITEM_DEL",
                CreateParameter("@InvoiceID", SqlDbType.VarChar, InvoiceID),
                CreateParameter("@InvoiceTreatmentID", SqlDbType.VarChar, InvoiceMedicalTreatmentID));
            cmd.Dispose();
            return true;
        }

        public DataSet GetInvoiceDetails(string InvoiceID)
        {
            return ExecuteDataSet("AIMS_PATIENT_INVOICE_GET",
                CreateParameter("@InvoiceID", SqlDbType.VarChar, InvoiceID));
        }

        public bool Invoice_Save(ref int InvoiceID, string InvoiceNo, string PatientFileNo, string InvoiceDate, string InvoiceAmountReceived, string InvoiceGeneratedYN, string InvoiceLockedYN, string InvoiceLateYN, string UserSignedOn, string SupplierID, string ServiceID, string InvoiceCancelledYN, string DoctorOwing, string LateInvoiceSent, string LateInvoiceSentDate, string InvoiceSentWaybillNo)
        {
            bool retVal = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_INVOICE_ADD1",
            CreateParameter("@InvoiceID", SqlDbType.Int, InvoiceID, ParameterDirection.InputOutput),
            CreateParameter("@InvoiceNo", SqlDbType.VarChar, InvoiceNo),
            CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
            CreateParameter("@InvoiceDate", SqlDbType.VarChar , InvoiceDate),
            CreateParameter("@InvoiceAmountReceived", SqlDbType.VarChar, InvoiceAmountReceived),
            CreateParameter("@InvoiceGeneratedYN", SqlDbType.VarChar, InvoiceGeneratedYN),
            CreateParameter("@InvoiceLockedYN", SqlDbType.VarChar, InvoiceLockedYN),
            CreateParameter("@InvoiceLateYN", SqlDbType.VarChar, InvoiceLateYN),
            CreateParameter("@UserSignedOn", SqlDbType.VarChar, UserSignedOn),
            CreateParameter("@SupplierID", SqlDbType.VarChar, SupplierID),
            CreateParameter("@ServiceID", SqlDbType.VarChar, ServiceID),
            CreateParameter("@InvoiceCancelledYN", SqlDbType.VarChar, InvoiceCancelledYN),
            CreateParameter("@DoctorOwing", SqlDbType.VarChar, DoctorOwing),
            CreateParameter("@LateInvoiceSent", SqlDbType.VarChar, LateInvoiceSent),
            CreateParameter("@LateInvoiceSentDate", SqlDbType.VarChar, LateInvoiceSentDate),
            CreateParameter("@InvoiceSentWaybillNo", SqlDbType.VarChar, InvoiceSentWaybillNo));

            InvoiceID = (int)cmd.Parameters["@InvoiceID"].Value;

            cmd.Dispose();
            return true;
        }

        public bool SaveNewService(string ServiceDesc, string UserSignedOn)
        {
            bool retVal = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_ADD_SERVICE",
            CreateParameter("@NewServiceDesc", SqlDbType.VarChar, ServiceDesc));

            cmd.Dispose();
            return true;
        }

        public bool SaveNewCountry(string CountryDesc, string UserSignedOn)
        {
            bool retVal = false;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_ADD_COUNTRY",
            CreateParameter("@NewCountryDesc", SqlDbType.VarChar, CountryDesc.ToUpper()));

            cmd.Dispose();
            return true;
        }

        public DataTable CheckIfServiceExist(string ServiceDesc)
        {
            return ExecuteDataTable("AIMS_SERVICE_CHECK",
                            CreateParameter("@ServiceDesc", SqlDbType.VarChar, ServiceDesc));
        }

        public DataTable CheckIfCountryExist(string CountryDesc)
        {
            return ExecuteDataTable("AIMS_COUNTRY_CHECK",
                            CreateParameter("@CountryDesc", SqlDbType.VarChar, CountryDesc));
        }
        
        public bool Invoice_Unlock(Int32 InvoiceID, string UserSignedOn)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_INVOICE_UNLOCK",
            CreateParameter("@InvoiceID", SqlDbType.Int, InvoiceID),
            CreateParameter("@UserSignedOn", SqlDbType.VarChar, UserSignedOn));

            cmd.Dispose();
            return true;
        }

        public bool Medical_Treatment_Save(ref Int64 MedicalTreatmentID, ref Int64 ServiceRenderedID, string MedicalTreatmentNotes, string ServiceRendered, Int64 InvoiceID, Int64 SupplierID, string MedicalTreatmentDate)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_INVOICE_MEDICAL_TREATMENT_ADD" ,
                CreateParameter("@InvoiceID", SqlDbType.Int , System.Convert.ToInt32(InvoiceID)),
                CreateParameter("@MedicalTreatmentID", SqlDbType.Int, System.Convert.ToInt32(MedicalTreatmentID), ParameterDirection.InputOutput),
                CreateParameter("@ServiceRenderedID", SqlDbType.Int, System.Convert.ToInt32(ServiceRenderedID), ParameterDirection.InputOutput),
                CreateParameter("@SupplierID", SqlDbType.Int, System.Convert.ToInt32(SupplierID)),
                CreateParameter("@MedicalTreatmentNotes", SqlDbType.VarChar , MedicalTreatmentNotes),
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

        public DataTable LoadPatientFiles()
        {
            return ExecuteDataTable("[AIMS_PATIENT_GET_ALL]");
        }

        public DataTable LoadMedicalTreatments()
        {
            return ExecuteDataTable("AIMS_SUPPLIER_GET_ALL");
        }

        public DataTable PatientFileNoVerify(string PatientFileNo)
        {
            return ExecuteDataTable("AIMS_PATIENT_VERIFY", CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo));
        }

        public DataTable GetPatientServiceProviders(string PatientID)
        {
            return ExecuteDataTable("AIMS_PATIENT_SERVICE_PROVIDERS_GET", CreateParameter("@PatientID", SqlDbType.VarChar, PatientID));
        }

        public DataSet GetPatientInvoices(string patientID, string includeLateInv, string DoctorOwing, string ShowSentLateInvoices)
        {
            return ExecuteDataSet("AIMS_PATIENT_INVOICES_GET",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientID),
                CreateParameter("@IncludeLateSubmission", SqlDbType.VarChar, includeLateInv),
                CreateParameter("@DoctorOwing", SqlDbType.VarChar, DoctorOwing),
                CreateParameter("@ShowSentLateInvoices", SqlDbType.VarChar, ShowSentLateInvoices));
        }

        public DataTable PatientInvoiceNoVerify(string PatientFileNo, string InvoiceNo, string LateInvoiceYN)
        {
            return ExecuteDataTable("AIMS_PATIENT_INVOICE_VERIFY", 
                    CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
                    CreateParameter("@PatientInvoiceNo", SqlDbType.VarChar, InvoiceNo),
                    CreateParameter("@LateInvoiceYN", SqlDbType.VarChar, LateInvoiceYN));
        }

        public DataTable GetSupplierDetails(string SupplierName)
        {
            return ExecuteDataTable("AIMS_SUPPLIER_VERIFY",
                    CreateParameter("@SupplierName", SqlDbType.VarChar, SupplierName));
        }

        public DataTable GetServiceProvider(string ServiceProviderID)
        {
            return ExecuteDataTable("AIMS_PATIENT_SERVICE_PROVIDER_GET",
                CreateParameter("@ServiceProviderID", SqlDbType.VarChar, ServiceProviderID));
        }

        public DataTable GetSupplierCostLimit(Int64 SupplierTypeID)
        {
            return ExecuteDataTable("AIMS_SUPPLIER_TYPE_COST",
                            CreateParameter("@SupplierTypeID", SqlDbType.Float, SupplierTypeID));
        }
       }
}