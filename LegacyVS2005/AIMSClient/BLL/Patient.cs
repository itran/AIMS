using System;
using System.Collections.Generic;
using System.Text;
using AIMS.Common;
using AIMS.DAL;
using System.Data;

namespace AIMS.BLL
{
    public class Patient :BaseObject
    {
        #region Fields

        private int _patientID = Constants.NullInt;
        private string _patientInitials = Constants.NullString;
        private string _patientFileNo = Constants.NullString;
        private string _patientFirstName = Constants.NullString;
        private string _patientMiddleName = Constants.NullString;
        private string _patientLastName = Constants.NullString;
        private int _companyID = Constants.NullInt;
        private string _companyName = Constants.NullString;
        private int _titleID = Constants.NullInt;
        private int _addressTypeID = Constants.NullInt;        
        private int _addressID = Constants.NullInt;
        private string _patientFaxNo = Constants.NullString;
        private string _patientMobileNo = Constants.NullString;
        private string _patientEmailAddress = Constants.NullString;
        private string _patientIDNumber = Constants.NullString;
        private string _patientDateOfBirth = Constants.NullString;
        private int _guarantorID = Constants.NullInt;
        private int _flightGuarantorID = Constants.NullInt;
        private string _guarantorName = Constants.NullString;
        private string _guarantorRefNo = Constants.NullString;
        private string _patientFileActiveYN = Constants.NullString;
        private string _addressLine1 = Constants.NullString;
        private string _addressLine2 = Constants.NullString;
        private string _addressLine3 = Constants.NullString;
        private string _addressLine4 = Constants.NullString;
        private string _addressLine5 = Constants.NullString;
        private string _postalCode = Constants.NullString;
        private string _title = Constants.NullString;
        private string _nationality = Constants.NullString;
        private string _homeTelNumber = Constants.NullString;
        private string _workTelNumber = Constants.NullString;
        private string _guaranteeAmt = Constants.NullString;
        private string _dateAdmitted = Constants.NullString;
        private string _dateDischarged = Constants.NullString;
        private int _supplierID = Constants.NullInt;
        private string _couriered = Constants.NullString;
        private string _diagnosis = Constants.NullString;
        private int _countryID = Constants.NullInt;
        private string _LoggedOnUser;
        private string _EmergencyContactNo = Constants.NullString;
        private string _EmergencyContactName = Constants.NullString;
        private string _patientFileLoadDate = Constants.NullString;
        private string _inPatient = Constants.NullString;
        private string _outPatient = Constants.NullString;
        private string _assist = Constants.NullString;
        private string _assisttype = Constants.NullString;        
        private string _repat = Constants.NullString;
        private string _repattype = Constants.NullString;
        private string _flight = Constants.NullString;
        private string _evacuationtype = Constants.NullString;
        private string _rmrtype = Constants.NullString;
        private string _rmr = Constants.NullString;
        private string _cancelled = Constants.NullString;
        private string _pending = Constants.NullString;    
        private string _fileCourierDate = Constants.NullString;
        private string _transport = Constants.NullString;
        private string _transporttype = Constants.NullString;
        private string _courierwaybillno = Constants.NullString;
        private string _courierreceiptdate = Constants.NullString;
        private string _fileassigneduser = Constants.NullString;
        private string _fileOperator = Constants.NullString;        
        private string _guarantor247email = Constants.NullString;
        private string _guarantor247no = Constants.NullString;   
        private string _LateLogYN= Constants.NullString;
        private string _LateLogDate = Constants.NullString;   
#endregion

        #region Public Properties

        public string  LoggedOnUser
        {
            get { return _LoggedOnUser; }
            set { _LoggedOnUser = value; }
        }
	
        public int PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }
        }

        public string PatientFileNo
        {
            get { return _patientFileNo; }
            set { _patientFileNo = value; }
        }

        public string PatientInitials
        {
            get { return _patientInitials; }
            set { _patientInitials = value; }
        }

        public string PatientFirstName
        {
            get { return _patientFirstName; }
            set { _patientFirstName = value; }
        }

        public string PatientMiddleName
        {
            get { return _patientMiddleName; }
            set { _patientMiddleName = value; }
        }

        public string PatientLastName
        {
            get { return _patientLastName; }
            set { _patientLastName = value; }
        }

        public string PatientFaxNo
        {
            get { return _patientFaxNo; }
            set { _patientFaxNo = value; }
        }

        public string PatientFileLoadDate
        {
            get { return _patientFileLoadDate; }
            set { _patientFileLoadDate = value; }
        }

        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        public int TitleID
        {
            get { return _titleID; }
            set { _titleID = value; }
        }

        public int AddressTypeID
        {
            get { return _addressTypeID; }
            set { _addressTypeID = value; }
        }

        public int AddressID
        {
            get { return _addressID; }
            set { _addressID = value; }
        }

        public string AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }

        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }

        public string AddressLine3
        {
            get { return _addressLine3; }
            set { _addressLine3 = value; }
        }

        public string AddressLine4
        {
            get { return _addressLine4; }
            set { _addressLine4 = value; }
        }

        public string AddressLine5
        {
            get { return _addressLine5; }
            set { _addressLine5 = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public string GuarantorName
        {
            get { return _guarantorName; }
            set { _guarantorName = value; }
        }

        public int GuarantorID
        {
            get { return _guarantorID; }
            set { _guarantorID = value; }
        }

        public int FlightGuarantorID
        {
            get { return _flightGuarantorID; }
            set { _flightGuarantorID = value; }
        }
        
        public string PatientFileActiveYN
        {
            get { return _patientFileActiveYN; }
            set { _patientFileActiveYN = value; }
        }

        public string GuarantorRefNo
        {
            get { return _guarantorRefNo; }
            set { _guarantorRefNo = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public string MobileNumber
        {
            get { return _patientMobileNo; }
            set { _patientMobileNo = value; }
        }
        
         public string PatientEmailAddr
        {
            get { return _patientEmailAddress; }
            set { _patientEmailAddress = value; }
        }
        
        public string IDNumber
        {
            get { return _patientIDNumber; }
            set { _patientIDNumber = value; }
        }
        
        public string DateOfBirth
        {
            get { return _patientDateOfBirth; }
            set { _patientDateOfBirth = value; }
        }

        string _LabListDate = "";
        public string LabListDate
        {
            get { return _LabListDate; }
            set { _LabListDate = value; }
        }

        string _AfterHoursFile = "";
        public string AfterHoursFile
        {
            get { return _AfterHoursFile; }
            set { _AfterHoursFile = value; }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        public string WorkTelNumber
        {
            get { return _workTelNumber; }
            set { _workTelNumber = value; }
        }

        public string HomeTelNumber
        {
            get { return _homeTelNumber; }
            set { _homeTelNumber = value; }
        }

        public string GuaranteeAmt
        {
            get { return _guaranteeAmt; }
            set { _guaranteeAmt = value; }
        }

        public string DateAdmitted
        {
            get { return _dateAdmitted; }
            set { _dateAdmitted = value; }
        }

        public string DateDischarged
        {
            get { return _dateDischarged; }
            set { _dateDischarged = value; }
        }

        public int SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }

        public string Couriered
        {
            get { return _couriered; }
            set { _couriered = value; }
        }

        string _SentToAdmin = "";
        public string SentToAdmin
        {
            get { return _SentToAdmin; }
            set { _SentToAdmin = value; }
        }

        string _HighCost = "";
        public string HighCost
        {
            get { return _HighCost; }
            set { _HighCost = value; }
        }

        public string Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

         public int CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }

        public string EmergencyContactName
        {
            get { return _EmergencyContactName; }
            set { _EmergencyContactName = value; }
        }

        public string EmergencyContactNo
        {
            get { return _EmergencyContactNo; }
            set { _EmergencyContactNo = value; }
        }

        public string OUTPatient
        {
            get { return _outPatient; }
            set { _outPatient = value; }
        }

        public string INPatient
        {
            get { return _inPatient; }
            set { _inPatient = value; }
        }

        public string Assist
        {
            get { return _assist; }
            set { _assist = value; }
        }

        public string  AssistType
        {
            get { return _assisttype; }
            set { _assisttype = value; }
        }

        public string Repat
        {
            get { return _repat; }
            set { _repat = value; }
        }

        public string RepatType
        {
            get { return _repattype; }
            set { _repattype = value; }
        }

        public string EvacuationType
        {
            get { return _evacuationtype; }
            set { _evacuationtype = value; }
        }
      
        public string RMRType
        {
            get { return _rmrtype; }
            set { _rmrtype = value; }
        }

        public string RMR
        {
            get { return _rmr; }
            set { _rmr = value; }
        } 
        public string Flight
        {
            get { return _flight; }
            set { _flight = value; }
        }

        public string Cancelled
        {
            get { return _cancelled; }
            set { _cancelled = value; }
        }

        public string Pending
        {
            get { return _pending; }
            set { _pending = value; }
        }

        public string Transport
        {
            get { return _transport; }
            set { _transport = value; }
        }

        public string TransportType
        {
            get { return _transporttype; }
            set { _transporttype = value; }
        }

        public string CourierWaybillNo
        {
            get { return _courierwaybillno; }
            set { _courierwaybillno = value; }
        }

        public string CourierReceiptDate
        {
            get { return _courierreceiptdate; }
            set { _courierreceiptdate = value; }
        }

        public string Guarantor247No
        {
            get { return _guarantor247no; }
            set { _guarantor247no = value; }
        }

        public string Guarantor247Email
        {
            get { return _guarantor247email; }
            set { _guarantor247email = value; }
        }

        public string FileAssignedUser
        {
            get { return _fileassigneduser; }
            set { _fileassigneduser = value; }
        }

        public string FileOperator
        {
            get { return _fileOperator; }
            set { _fileOperator = value; }
        }    
        
        public string FileCourierDate
        {
            get { return _fileCourierDate; }
            set { _fileCourierDate = value; }
        }

        public string LateLogYN
        {
            get { return _LateLogYN; }
            set { _LateLogYN = value; }
        }

        public string LateLogDate
        {
            get { return _LateLogDate; }
            set { _LateLogDate = value; }
        }

        Int32 _GuaranteeID;
        public Int32 GuaranteeID
        {
            get { return _GuaranteeID; }
            set { _GuaranteeID = value; }
        }

        Int32 _GuaranteeServiceProviderID;
        public Int32 GuaranteeServiceProviderID
        {
            get { return _GuaranteeServiceProviderID; }
            set { _GuaranteeServiceProviderID = value; }
        }

        string _GuaranteeExpiryDttm;
        public string GuaranteeExpiryDttm
        {
            get { return _GuaranteeExpiryDttm; }
            set { _GuaranteeExpiryDttm = value; }
        }

        string _GuaranteeDiagnosisProcedure;
        public string GuaranteeDiagnosisProcedure
        {
            get { return _GuaranteeDiagnosisProcedure; }
            set { _GuaranteeDiagnosisProcedure = value; }
        }

        string _GuaranteeAdmissionCode;
        public string GuaranteeAdmissionCode
        {
            get { return _GuaranteeAdmissionCode; }
            set { _GuaranteeAdmissionCode = value; }
        }

        string _GuaranteeAttention;
        public string GuaranteeAttention
        {
            get { return _GuaranteeAttention; }
            set { _GuaranteeAttention = value; }
        }

        string _GuaranteeExclusion;
        public string GuaranteeExclusion
        {
            get { return _GuaranteeExclusion; }
            set { _GuaranteeExclusion = value; }
        }

        string _GuaranteeComment;
        public string GuaranteeComment
        {
            get { return _GuaranteeComment; }
            set { _GuaranteeComment = value; }
        }
     #endregion

        #region Public Functions

        /// <summary>
        /// This fucntion Maps the data in the datatable to the Patient Object
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public override bool MapData(DataRow row)
        {           
            PatientFileNo = GetString(row, "Patient_File_No");
            PatientFirstName = GetString(row, "Patient_First_Name");
            PatientLastName = GetString(row, "Patient_Last_Name");
            PatientID = GetInt(row, "Patient_ID");
            PatientFaxNo = GetString(row,"Patient_Fax_No");
            AddressLine1 = GetString(row,"Address1");
            AddressLine2 = GetString(row, "Address2");
            AddressLine3 = GetString(row, "Address3");
            AddressLine4 = GetString(row, "Address4");
            AddressLine5 = GetString(row, "Address5");
            PostalCode = GetString(row,"Postal_Code");
            GuarantorID = GetInt(row, "Guarantor_ID");
            GuarantorName = GetString(row,"Guarantor_Name");
            PatientFileActiveYN = GetString(row,"Patient_File_Active_YN");
            Title = GetString(row,"Title_Desc");
            GuarantorRefNo = GetString(row,"Guarantor_Ref_No");
            CompanyName = GetString(row,"Company_Name");
            MobileNumber = GetString(row, "Patient_Mobile_No");
            PatientEmailAddr = GetString(row, "Patient_Email_Address");
            IDNumber = GetString(row,"Patient_ID_No");
            Nationality = GetString(row,"Patient_Nationality");
            HomeTelNumber = GetString(row,"Patient_Home_Tel_No");
            WorkTelNumber = GetString(row,"Patient_Work_Tel_No");
            TitleID = GetInt(row, "TITLE_ID");
            Diagnosis = GetString(row, "PATIENT_DIAGNOSIS");
            DateAdmitted = GetString(row,"PATIENT_ADMISSION_DATE");
            DateDischarged = GetString(row, "PATIENT_DISCHARGE_DATE");
            Couriered = GetString(row,"PATIENT_FILE_COURIER_YN");
            GuaranteeAmt = GetString(row,"PATIENT_GUARANTOR_AMOUNT");
            PatientInitials = GetString(row,"PATIENT_INITIALS");
            SupplierID = GetInt(row, "SUPPLIER_ID");
            CountryID = GetInt(row, "COUNTRY_ID");
            EmergencyContactName = GetString(row, "PATIENT_EMERGENCY_CONTACT_NAME");
            EmergencyContactNo = GetString(row, "PATIENT_EMERGENCY_CONTACT_NO");
            OUTPatient = GetString(row, "OUT_PATIENT");
            INPatient = GetString(row, "IN_PATIENT");
            AddressTypeID = GetInt(row, "ADDRESS_TYPE_ID");
            PatientFileLoadDate = GetString(row, "Creation_Dttm").ToString();
            Assist = GetString(row, "ASSIST");
            Repat = GetString(row, "REPAT");
            Flight = GetString(row, "FLIGHT");
            FileCourierDate = GetString(row, "FILE_COURIER_DATE");
            Cancelled = GetString(row, "CANCELLED");
            Transport = GetString(row, "TRANSPORT");
            TransportType = GetString(row, "PATIENT_TRANSPORT_TYPE_ID");
            CourierWaybillNo  = GetString(row, "COURIER_WAYBILL_NO");
            Guarantor247Email = GetString(row, "GUARANTOR247EMAIL");
            Guarantor247No = GetString(row, "GUARANTOR247NO");
            CourierReceiptDate  = GetString(row, "COURIER_RECEIPT_DATE");
            FileAssignedUser = GetString(row, "FILE_ASSIGNED_TO_USERID");
            FileOperator = GetString(row, "FILE_OPERATOR_TO_USERID");
            AssistType = GetString(row, "PATIENT_ASSIST_TYPE_ID");
            EvacuationType = GetString(row, "PATIENT_EVACUATION_TYPE_ID");
            RMRType = GetString(row, "PATIENT_RMR_TYPE_ID");
            RepatType = GetString(row, "PATIENT_REPAT_TYPE_ID");            
            LateLogYN = GetString(row, "LATE_LOG_YN");
            Pending = GetString(row, "PENDING");
            FlightGuarantorID = GetInt(row, "FLIGHT_GUARANTOR_ID");
            DateOfBirth = GetString(row, "PATIENT_DATE_OF_BIRTH");
            LabListDate = GetString(row, "LAB_LIST_DATE");
            AfterHoursFile = GetString(row, "AFTER_HOURS_FILE");
            SentToAdmin = GetString(row, "SENT_TO_ADMIN");
            HighCost = GetString(row, "HIGH_COST");
            if (LateLogYN =="Y") { LateLogDate = GetDateTime(row, "LATE_LOG_DATE").ToString(); }

            return base.MapData(row);
        }

        /// <summary>
        /// This method returns a Patient object populated with patient details
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public Patient GetPatientDetails(string patientID, string EnquiryYN, string UserSignedOn)
        {
            Patient oPatient = new Patient();
            DataSet ds = new DataSet();
            PatientDAL patientDAL = new PatientDAL();

            //This populates a dataset with Patient Details
            ds = patientDAL.GetPatientDetails(patientID, EnquiryYN, UserSignedOn);
            
            if (!oPatient.MapData(ds)) oPatient = null;
            return oPatient;
        }

        public Patient GetPatientHeaderDetails(string patientID, string EnquiryYN, string UserSignedOn)
        {
            Patient oPatient = new Patient();
            DataSet ds = new DataSet();
            PatientDAL patientDAL = new PatientDAL();

            //This populates a dataset with Patient Details
            ds = patientDAL.GetPatientHeaderDetails(patientID, EnquiryYN, UserSignedOn);

            if (!oPatient.MapData(ds)) oPatient = null;
            return oPatient;
        }
        
        /// <summary>
        /// This method adds and updates patient details
        /// </summary>
        /// <param name="patientDAL"></param>
        /// <returns></returns>
        public string SavePatientDetails(PatientDAL patientDAL,string userName)
        {

            string patientFileNo = string.Empty;
            PatientDAL clsDAL = new PatientDAL();
            patientFileNo = clsDAL.SavePatient(ref patientFileNo, patientDAL, userName);
            return patientFileNo;
        }

        public string SavePatientHeaderDetails(PatientDAL patientDAL, string userName)
        {

            string patientFileNo = string.Empty;
            PatientDAL clsDAL = new PatientDAL();
            patientFileNo = clsDAL.SavePatientHeaderDetails(ref patientFileNo, patientDAL, userName);
            return patientFileNo;
        }

        public string SavePatientGuarantee(PatientDAL patientDAL, string userName, string GuaranteePOD, string currency)
        {
            string GuarantorID = string.Empty;
            PatientDAL clsDAL = new PatientDAL();
            GuarantorID = clsDAL.SavePatientGuarantee(ref GuarantorID, patientDAL, userName, GuaranteePOD, userName, currency);
            return GuarantorID;
        }

        public bool UpdatePatientDetails(PatientDAL patientDAL, string userName)
        {
            PatientDAL clsDAL = new PatientDAL();
            return clsDAL.UpdatePatient(patientDAL, userName);
            
        }

        public bool PatientFileUnlock()
        {
            Patient oPatient = new Patient();
            PatientDAL PatientDAL = new PatientDAL();
            bool bSaved = false;
            bSaved = PatientDAL.PatientFileUnlock (PatientFileNo, LoggedOnUser.ToString());
            oPatient = null;
            PatientDAL = null;
            return bSaved;
        }

        public DataSet GetPatientEmails(string patientFileNo, string EmailKeyWord)
        {
            Patient oPatient = new Patient();
            DataSet ds = new DataSet();
            PatientDAL PatientDAL = new PatientDAL();

            ds = PatientDAL.GetPatientEmails(patientFileNo, EmailKeyWord);
            
            oPatient = null;
            PatientDAL = null;
            return ds;
        }

        public DataSet GetPatientFileAudit(string patientFileNo)
        {
            Patient oPatient = new Patient();
            DataSet ds = new DataSet();
            PatientDAL PatientDAL = new PatientDAL();

            ds = PatientDAL.GetPatientFileAudit(patientFileNo);

            oPatient = null;
            PatientDAL = null;
            return ds;
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
