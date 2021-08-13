using System;
using System.Collections.Generic;
using System.Text;
using AIMS.DAL;
using System.Data;
using System.Data.SqlClient;


namespace AIMS.DAL
{

    public class PatientDAL : DataServiceBase
    {
      
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public PatientDAL() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public PatientDAL(IDbTransaction txn) : base(txn) { }

        #region Global Params
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
        private string _patientDateOfBirth = Constants.NullString;
        
        private string _dateAdmitted = Constants.NullString;
        private string _EmergencyContactNo = Constants.NullString;
        private string _EmergencyContactName = Constants.NullString;
        private string _dateDischarged = Constants.NullString;
        private int _supplierID = Constants.NullInt;
        private string _couriered = Constants.NullString;
        private string _diagnosis = Constants.NullString;
        private int _countryID = Constants.NullInt;
        private string _inPatient = Constants.NullString;
        private string _outPatient = Constants.NullString;
        private string _assist = Constants.NullString;
        private string _assisttype = Constants.NullString;
        private string _repattype= Constants.NullString;
        private string _evacuationtype = Constants.NullString;
        private string _rmrtype = Constants.NullString;
        private string _rmr = Constants.NullString;
        private string _repat = Constants.NullString;
        private string _flight = Constants.NullString;
        private string _cancellation = Constants.NullString;
        private string _transport = Constants.NullString;
        private string _transporttype = Constants.NullString;
        private string _courierwaybillno = Constants.NullString;
        private string _courierreceiptdate = Constants.NullString;   
        private string _fileassigneduser = Constants.NullString;
        private string _fileOperator = Constants.NullString;  
        private string _guarantor247email = Constants.NullString;   
        private string _guarantor247no = Constants.NullString;   
        private string _LateLogDate = Constants.NullString;
        private string _LateLogYN = Constants.NullString;
        private string _Pending = Constants.NullString;   
        #endregion

        #region Public Properties

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

        public string DateOfBirth
        {
            get { return _patientDateOfBirth; }
            set { _patientDateOfBirth = value; }
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
        public string Repat
        {
            get { return _repat; }
            set { _repat = value; }
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

        public string RMRType
        {
            get { return _rmrtype; }
            set { _rmrtype = value; }
        }

        public string Cancellation
        {
            get { return _cancellation; }
            set { _cancellation = value; }
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

        string _FileCourierDate = "";
        public string FileCourierDate
        {
            get { return _FileCourierDate; }
            set { _FileCourierDate = value; }
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

        public string Pending
        {
            get { return _Pending; }
            set { _Pending = value; }
        }

        Int32 _GuaranteeID;
        public Int32 GuaranteeID
        {
            get { return _GuaranteeID; }
            set { _GuaranteeID = value; }
        }

        Int32 _GuaranteeHospitalID;
        public Int32 GuaranteeHospitalID
        {
            get { return _GuaranteeHospitalID; }
            set { _GuaranteeHospitalID = value; }
        }

        Int32 _GuaranteeServiceProviderID;
        public Int32 GuaranteeServiceProviderID
        {
            get { return _GuaranteeServiceProviderID; }
            set { _GuaranteeServiceProviderID = value; }
        }

        Int32 _GuaranteeWardTypeID;
        public Int32 GuaranteeWardTypeID
        {
            get { return _GuaranteeWardTypeID; }
            set { _GuaranteeWardTypeID = value; }
        }

        Int32 _GuaranteeRoomTypeID;
        public Int32 GuaranteeRoomTypeID
        {
            get { return _GuaranteeRoomTypeID; }
            set { _GuaranteeRoomTypeID = value; }
        }

        string _GuaranteePatientFileNo;
        public string GuaranteePatientFileNo
        {
            get { return _GuaranteePatientFileNo; }
            set { _GuaranteePatientFileNo = value; }
        }

        string _GuaranteePatientName;
        public string GuaranteePatientName
        {
            get { return _GuaranteePatientName; }
            set { _GuaranteePatientName = value; }
        }

        string _GuaranteeAdmissinDate;
        public string GuaranteeAdmissinDate
        {
            get { return _GuaranteeAdmissinDate; }
            set { _GuaranteeAdmissinDate = value; }
        }

        string _GuaranteeDiagnosis;
        public string GuaranteeDiagnosis
        {
            get { return _GuaranteeDiagnosis; }
            set { _GuaranteeDiagnosis = value; }
        }

        string _GuaranteeAdmissionCodeOther;
        public string GuaranteeAdmissionCodeOther
        {
            get { return _GuaranteeAdmissionCodeOther; }
            set { _GuaranteeAdmissionCodeOther = value; }
        }

        string _GuaranteeAmount;
        public string GuaranteeAmount
        {
            get { return _GuaranteeAmount; }
            set { _GuaranteeAmount = value; }
        }

        string _GuaranteeNotes;
        public string GuaranteeNotes
        {
            get { return _GuaranteeNotes; }
            set { _GuaranteeNotes = value; }
        }

        string _GuaranteeConsolidateAmount;
        public string GuaranteeConsolidateAmount
        {
            get { return _GuaranteeConsolidateAmount; }
            set { _GuaranteeConsolidateAmount = value; }
        }


        string _GOPApprovedYN;
        public string GOPApprovedYN
        {
            get { return _GOPApprovedYN;}
            set { _GOPApprovedYN = value; }
        }

        string _GuaranteeStartDate;
        public string GuaranteeStartDate
        {
            get { return _GuaranteeStartDate; }
            set { _GuaranteeStartDate = value; }
        }

        string _GuaranteeEndDate;
        public string GuaranteeEndDate
        {
            get { return _GuaranteeEndDate; }
            set { _GuaranteeEndDate = value; }
        }

        Int32 _GuaranteeAdmissionCode;
        public Int32 GuaranteeAdmissionCode
        {
            get { return _GuaranteeAdmissionCode; }
            set { _GuaranteeAdmissionCode = value; }
        }

        string _GuaranteeCoOrdinator;
        public string GuaranteeCoOrdinator
        {
            get { return _GuaranteeCoOrdinator; }
            set { _GuaranteeCoOrdinator = value; }
        }

        string _GuaranteeAttention;
        public string GuaranteeAttention
        {
            get { return _GuaranteeAttention; }
            set { _GuaranteeAttention = value; }
        }

        string _GuaranteeContactName;
        public string GuaranteeContactName
        {
            get { return _GuaranteeContactName; }
            set { _GuaranteeContactName = value; }
        }

        string _GuaranteeEmailAddress;
        public string GuaranteeEmailAddress
        {
            get { return _GuaranteeEmailAddress; }
            set { _GuaranteeEmailAddress = value; }
        }
        #endregion

        public DataSet PatientGetAll()
        {
            return ExecuteDataSet("AIMS_PATIENT_GET_ALL", null);
        }

        public DataSet GetPatientDetails(string patientID, string EnquiryYN, string UserSignedOn)
        {
            return ExecuteDataSet("AIMS_PATIENT_GET", 
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientID),
                CreateParameter("@EnquiryYN", SqlDbType.VarChar, EnquiryYN),
                CreateParameter("@UserSignedOn", SqlDbType.VarChar, UserSignedOn));
        }

        public string GetLastFilePatient()
        {
            SqlCommand cmd;
            string personID = "";
             ExecuteNonQuery(out cmd, "AIMS_LAST_PATIENT_NO",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar,"" ,50 , ParameterDirection.InputOutput));
            personID = cmd.Parameters["@PatientFileNo"].Value.ToString();
            return personID;

        }
        public DataSet GetPatientHeaderDetails(string patientID, string EnquiryYN, string UserSignedOn)
        {
            return ExecuteDataSet("AIMS_PATIENT_HEADER_GET",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientID),
                CreateParameter("@EnquiryYN", SqlDbType.VarChar, EnquiryYN),
                CreateParameter("@UserSignedOn", SqlDbType.VarChar, UserSignedOn));
        }

        public string SavePatient(ref string personID, PatientDAL patientDAL,string userName)
        {
            SqlCommand cmd;

             ExecuteNonQuery(out cmd, "AIMS_PATIENT_ADD",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientDAL.PatientFileNo, 50, ParameterDirection.InputOutput),
                CreateParameter("@PatientInitials", SqlDbType.VarChar , patientDAL.PatientInitials),
                CreateParameter("@PatientFirstName", SqlDbType.VarChar, patientDAL.PatientFirstName),
                CreateParameter("@PatientMiddleName", SqlDbType.VarChar, patientDAL.PatientMiddleName),
                CreateParameter("@PatientLastName", SqlDbType.VarChar, patientDAL.PatientLastName),
                CreateParameter("@PatientIDNo", SqlDbType.VarChar, patientDAL.IDNumber),
                CreateParameter("@PatientCompanyID", SqlDbType.Int, patientDAL.CompanyID),
                CreateParameter("@PatientTitleID", SqlDbType.Int, patientDAL.TitleID),
                CreateParameter("@PatientHomeTelNo", SqlDbType.VarChar, patientDAL.HomeTelNumber),
                CreateParameter("@PatientWorkTelNo", SqlDbType.VarChar, patientDAL.WorkTelNumber),
                CreateParameter("@PatientFaxNo", SqlDbType.VarChar, patientDAL.PatientFaxNo),
                CreateParameter("@PatientMobileNo", SqlDbType.VarChar, patientDAL.MobileNumber),
                CreateParameter("@PatientEmailAddress", SqlDbType.VarChar, patientDAL.PatientEmailAddr),
                CreateParameter("@PatientGuarantorID", SqlDbType.Int, patientDAL.GuarantorID),
                CreateParameter("@PatientGuarantorRefNo", SqlDbType.VarChar, patientDAL.GuarantorRefNo),
                CreateParameter("@PatientFileActiveYN", SqlDbType.VarChar, patientDAL.PatientFileActiveYN),
                CreateParameter("@AddressTypeID", SqlDbType.Int, patientDAL.AddressTypeID),
                CreateParameter("@Address1", SqlDbType.VarChar, patientDAL.AddressLine1),
                CreateParameter("@Address2", SqlDbType.VarChar, patientDAL.AddressLine2),
                CreateParameter("@Address3", SqlDbType.VarChar, patientDAL.AddressLine3),
                CreateParameter("@Address4", SqlDbType.VarChar, patientDAL.AddressLine4),
                CreateParameter("@Address5", SqlDbType.VarChar, patientDAL.AddressLine5),
                CreateParameter("@PostalCode", SqlDbType.VarChar, patientDAL.PostalCode),
                CreateParameter("@CountryID", SqlDbType.Int, patientDAL.CountryID),
                CreateParameter("@UserSignedOn", SqlDbType.VarChar, userName),
                CreateParameter("@PatientNationality", SqlDbType.VarChar, patientDAL.Nationality),
                CreateParameter("@GuarantorAmount", SqlDbType.VarChar, patientDAL.GuaranteeAmt),
                CreateParameter("@SupplierID", SqlDbType.Int, patientDAL.SupplierID),
                CreateParameter("@PatientFileCourierYN", SqlDbType.VarChar, patientDAL.Couriered),
                CreateParameter("@PatientAdmissionDate", SqlDbType.VarChar, patientDAL.DateAdmitted),
                CreateParameter("@PatientDischargeDate", SqlDbType.VarChar, patientDAL.DateDischarged),
                CreateParameter("@PatientDiagnosis", SqlDbType.VarChar, patientDAL.Diagnosis),
                CreateParameter("@PatientEmergencyContactName", SqlDbType.VarChar, patientDAL.EmergencyContactName),
                CreateParameter("@PatientEmergencyContactNo", SqlDbType.VarChar, patientDAL.EmergencyContactNo),
                CreateParameter("@InPatient", SqlDbType.VarChar, patientDAL.INPatient),
                CreateParameter("@OutPatient", SqlDbType.VarChar, patientDAL.OUTPatient),
                CreateParameter("@Assist", SqlDbType.VarChar, patientDAL.Assist),
                CreateParameter("@Repat", SqlDbType.VarChar, patientDAL.Repat),
                CreateParameter("@Flight", SqlDbType.VarChar, patientDAL.Flight),
                CreateParameter("@Cancellation", SqlDbType.VarChar, patientDAL.Cancellation),
                CreateParameter("@CourierWayBillNo", SqlDbType.VarChar, patientDAL.CourierWaybillNo),
                CreateParameter("@TransportYN", SqlDbType.VarChar, patientDAL.Transport),
                CreateParameter("@Guarantor247No", SqlDbType.VarChar, patientDAL.Guarantor247No),
                CreateParameter("@Guarantor247Email", SqlDbType.VarChar, patientDAL.Guarantor247Email),
                CreateParameter("@CourierReceiptDate", SqlDbType.VarChar , patientDAL.CourierReceiptDate ),
                CreateParameter("@FileAdministrator", SqlDbType.VarChar, patientDAL.FileAssignedUser),
                CreateParameter("@AssistanceType", SqlDbType.VarChar , patientDAL.AssistType),
                CreateParameter("@TransportType", SqlDbType.VarChar, patientDAL.TransportType),
                CreateParameter("@FileCourierDate", SqlDbType.VarChar, patientDAL.FileCourierDate),
                CreateParameter("@LateLogYN", SqlDbType.VarChar, patientDAL.LateLogYN),
                CreateParameter("@LateLogDate", SqlDbType.VarChar, patientDAL.LateLogDate),
                CreateParameter("@Pending", SqlDbType.VarChar, patientDAL.Pending),
                CreateParameter("@RepatType", SqlDbType.VarChar, patientDAL.RepatType),
                CreateParameter("@EvacuationType", SqlDbType.VarChar, patientDAL.EvacuationType),
                CreateParameter("@FileOperator", SqlDbType.VarChar, patientDAL.FileOperator),
                CreateParameter("@RMR", SqlDbType.VarChar, patientDAL.RMR),
                CreateParameter("@RMRType", SqlDbType.VarChar, patientDAL.RMRType),
                CreateParameter("@PatientFlightGuarantorID", SqlDbType.Int, patientDAL.FlightGuarantorID),
                CreateParameter("@DateOfBirth", SqlDbType.VarChar, patientDAL.DateOfBirth),
                CreateParameter("@LabListDate", SqlDbType.VarChar, patientDAL.LabListDate),
                CreateParameter("@AfterHoursFile", SqlDbType.VarChar, patientDAL.AfterHoursFile),
                CreateParameter("@SentToAdmin", SqlDbType.VarChar, patientDAL.SentToAdmin),
                CreateParameter("@HighCost", SqlDbType.VarChar, patientDAL.HighCost));

                personID = cmd.Parameters["@PatientFileNo"].Value.ToString();

                cmd.Dispose();

                return personID;
        }

        public string SavePatientHeaderDetails(ref string personID, PatientDAL patientDAL, string userName)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_PATIENT_HEADER_SAVE",
            CreateParameter("@PATIENT_FILE_NO", SqlDbType.VarChar, patientDAL.PatientFileNo, 50, ParameterDirection.InputOutput),
            CreateParameter("@PATIENT_INITIALS", SqlDbType.VarChar, patientDAL.PatientInitials),
            CreateParameter("@PATIENT_FIRST_NAME", SqlDbType.VarChar, patientDAL.PatientFirstName),
            CreateParameter("@PATIENT_MIDDLE_NAME", SqlDbType.VarChar, patientDAL.PatientMiddleName),
            CreateParameter("@PATIENT_LAST_NAME", SqlDbType.VarChar, patientDAL.PatientLastName),
            CreateParameter("@PATIENT_ID_NO", SqlDbType.VarChar, patientDAL.IDNumber),
            CreateParameter("@TITLE_ID", SqlDbType.Int, patientDAL.TitleID),
            CreateParameter("@ADDRESS_ID", SqlDbType.Int, patientDAL.AddressID),
            CreateParameter("@PATIENT_HOME_TEL_NO", SqlDbType.VarChar, patientDAL.HomeTelNumber),
            CreateParameter("@PATIENT_WORK_TEL_NO", SqlDbType.VarChar, patientDAL.WorkTelNumber),
            CreateParameter("@PATIENT_FAX_NO", SqlDbType.VarChar, patientDAL.PatientFaxNo),
            CreateParameter("@PATIENT_MOBILE_NO", SqlDbType.VarChar, patientDAL.MobileNumber),
            CreateParameter("@PATIENT_EMAIL_ADDRESS", SqlDbType.VarChar, patientDAL.PatientEmailAddr),
            CreateParameter("@PATIENT_NATIONALITY", SqlDbType.VarChar, patientDAL.Nationality),
            CreateParameter("@PATIENT_COUNTRY_ID", SqlDbType.Int, patientDAL.CountryID),
            CreateParameter("@Address1", SqlDbType.VarChar, patientDAL.AddressLine1),
            CreateParameter("@Address2", SqlDbType.VarChar, patientDAL.AddressLine2),
            CreateParameter("@Address3", SqlDbType.VarChar, patientDAL.AddressLine3),
            CreateParameter("@Address4", SqlDbType.VarChar, patientDAL.AddressLine4),
            CreateParameter("@Address5", SqlDbType.VarChar, patientDAL.AddressLine5),
            CreateParameter("@PostalCode", SqlDbType.VarChar, patientDAL.PostalCode),
            //CreateParameter("@RELIGION_ID", SqlDbType.Int, patientDAL.Religion),
            CreateParameter("@MODIFIED_BY", SqlDbType.VarChar, userName),
            CreateParameter("@PATIENT_DATE_OF_BIRTH", SqlDbType.VarChar, patientDAL.DateOfBirth),
            //CreateParameter("@VISA_EXPIRY_DATE", SqlDbType.VarChar, patientDAL.VisaExpiryDate),
            CreateParameter("@GUARANTOR_ID", SqlDbType.Int, patientDAL.GuaranteeID),
            CreateParameter("@GUARANTOR247NO", SqlDbType.VarChar, patientDAL.Guarantor247No),
            CreateParameter("@GUARANTOR247EMAIL", SqlDbType.VarChar, patientDAL.Guarantor247Email),
            //CreateParameter("@FILE_ARCHIVED", SqlDbType.VarChar, patientDAL.FileArchived),
            CreateParameter("@FLIGHT_GUARANTOR_ID", SqlDbType.Int, patientDAL.FlightGuarantorID));

            personID = cmd.Parameters["@PATIENT_FILE_NO"].Value.ToString();
            cmd.Dispose();
            return personID;
        }

        public string SavePatientGuarantee(ref string GuaranteeID, PatientDAL patientDAL, string userName, string GuaranteePOD, string userID, string currency)
        {
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_PATIENT_GOP_ADD",
            CreateParameter("@GUARANTEE_ID", SqlDbType.VarChar, System.Convert.ToString(patientDAL.GuaranteeID), 50, ParameterDirection.InputOutput),
            CreateParameter("@PATIENT_ID", SqlDbType.VarChar, patientDAL.PatientID.ToString()),
            CreateParameter("@CONTACT_NAME", SqlDbType.VarChar, patientDAL.GuaranteeContactName),
            CreateParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, patientDAL.GuaranteeEmailAddress),
            CreateParameter("@GOP_CONSOLIDATED_AMT", SqlDbType.VarChar, patientDAL.GuaranteeConsolidateAmount),
            CreateParameter("@GOP_START_DATE", SqlDbType.VarChar, patientDAL.GuaranteeStartDate),
            CreateParameter("@GOP_END_DATE", SqlDbType.VarChar, patientDAL.GuaranteeEndDate),
            CreateParameter("@ROOM_TYPE", SqlDbType.VarChar, System.Convert.ToString(patientDAL.GuaranteeRoomTypeID)),
            CreateParameter("@GOP_NOTES", SqlDbType.VarChar, patientDAL.GuaranteeNotes),
            CreateParameter("@GUARANTEE_POD", SqlDbType.VarChar, GuaranteePOD),
            CreateParameter("@UserSignedOn", SqlDbType.VarChar, userName),
            CreateParameter("@GOP_APPROVED_YN", SqlDbType.VarChar, patientDAL.GOPApprovedYN),
            CreateParameter("@CURRENCY", SqlDbType.VarChar, currency));

            //ExecuteNonQuery(out cmd, "AIMS_PATIENT_GUARANTEE_ADD",
            //CreateParameter("@GUARANTEE_ID", SqlDbType.VarChar, System.Convert.ToString(patientDAL.GuaranteeID), 50, ParameterDirection.InputOutput),
            //CreateParameter("@PATIENT_ID", SqlDbType.VarChar, patientDAL.PatientID.ToString()),
            //CreateParameter("@PATIENT_NAME", SqlDbType.VarChar, patientDAL.GuaranteePatientName),
            //CreateParameter("@ADMISSION_DATE", SqlDbType.VarChar, patientDAL.GuaranteeAdmissinDate),
            //CreateParameter("@SUPPLIER_ID", SqlDbType.VarChar, System.Convert.ToString(patientDAL.GuaranteeHospitalID)),
            //CreateParameter("@SERVICE_PROVIDER_ID", SqlDbType.VarChar, System.Convert.ToString(patientDAL.GuaranteeServiceProviderID)),
            //CreateParameter("@DIAGNOSIS", SqlDbType.VarChar, patientDAL.GuaranteeDiagnosis),
            //CreateParameter("@ADMISSION_CODE", SqlDbType.VarChar, patientDAL.GuaranteeAdmissionCode.ToString()),
            //CreateParameter("@ATTENTION", SqlDbType.VarChar, patientDAL.GuaranteeAttention),
            //CreateParameter("@GUARANTEE_POD", SqlDbType.VarChar, GuaranteePOD),
            //CreateParameter("@UserSignedOn", SqlDbType.VarChar, userName),
            //CreateParameter("@WARD_TYPE_ID", SqlDbType.VarChar, System.Convert.ToString(patientDAL.GuaranteeWardTypeID)),
            //CreateParameter("@ADMISSION_CODE_OTHER", SqlDbType.VarChar, patientDAL.GuaranteeAdmissionCodeOther),
            //CreateParameter("@LoadedBy", SqlDbType.VarChar, userID),
            //CreateParameter("@GOP_AMOUNT", SqlDbType.VarChar, patientDAL.GuaranteeAmount),
            //CreateParameter("@GOP_APPROVED_YN", SqlDbType.VarChar, patientDAL.GOPApprovedYN),
            //CreateParameter("@GOP_START_DATE", SqlDbType.VarChar, patientDAL.GuaranteeStartDate),
            //CreateParameter("@GOP_END_DATE", SqlDbType.VarChar, patientDAL.GuaranteeEndDate));

            GuaranteeID = cmd.Parameters["@GUARANTEE_ID"].Value.ToString();

            cmd.Dispose();

            return GuaranteeID;
        }

        public bool UpdatePatient(PatientDAL patientDAL, string userName)
        {
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_PATIENT_ADD",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientDAL.PatientFileNo),
                CreateParameter("@PatientInitials", SqlDbType.VarChar, patientDAL.PatientInitials),
                CreateParameter("@PatientFirstName", SqlDbType.VarChar, patientDAL.PatientFirstName),
                CreateParameter("@PatientMiddleName", SqlDbType.VarChar, patientDAL.PatientMiddleName),
                CreateParameter("@PatientLastName", SqlDbType.VarChar, patientDAL.PatientLastName),
                CreateParameter("@PatientIDNo", SqlDbType.VarChar, patientDAL.IDNumber),
                CreateParameter("@PatientCompanyID", SqlDbType.Int, patientDAL.CompanyID),
                CreateParameter("@PatientTitleID", SqlDbType.Int, patientDAL.TitleID),
                CreateParameter("@PatientHomeTelNo", SqlDbType.VarChar, patientDAL.HomeTelNumber),
                CreateParameter("@PatientWorkTelNo", SqlDbType.VarChar, patientDAL.WorkTelNumber),
                CreateParameter("@PatientFaxNo", SqlDbType.VarChar, patientDAL.PatientFaxNo),
                CreateParameter("@PatientMobileNo", SqlDbType.VarChar, patientDAL.MobileNumber),
                CreateParameter("@PatientEmailAddress", SqlDbType.VarChar, patientDAL.PatientEmailAddr),
                CreateParameter("@PatientGuarantorID", SqlDbType.Int, patientDAL.GuarantorID),
                CreateParameter("@PatientGuarantorRefNo", SqlDbType.VarChar, patientDAL.GuarantorRefNo),
                CreateParameter("@PatientFileActiveYN", SqlDbType.VarChar, patientDAL.PatientFileActiveYN),
                CreateParameter("@AddressTypeID", SqlDbType.Int, 1),
                CreateParameter("@Address1", SqlDbType.VarChar, patientDAL.AddressLine1),
                CreateParameter("@Address2", SqlDbType.VarChar, patientDAL.AddressLine2),
                CreateParameter("@Address3", SqlDbType.VarChar, patientDAL.AddressLine3),
                CreateParameter("@Address4", SqlDbType.VarChar, patientDAL.AddressLine4),
                CreateParameter("@Address5", SqlDbType.VarChar, patientDAL.AddressLine5),
                CreateParameter("@PostalCode", SqlDbType.VarChar, patientDAL.PostalCode),
                CreateParameter("@CountryID", SqlDbType.Int, patientDAL.CompanyID),
                CreateParameter("@UserSignedOn", SqlDbType.VarChar, userName),
                CreateParameter("@PatientNationality", SqlDbType.VarChar, patientDAL.Nationality),
                CreateParameter("@GuarantorAmount", SqlDbType.VarChar, patientDAL.GuaranteeAmt),
                CreateParameter("@SupplierID", SqlDbType.Int, patientDAL.SupplierID),
                CreateParameter("@PatientFileCourierYN", SqlDbType.VarChar, patientDAL.Couriered),
                CreateParameter("@PatientAdmissionDate", SqlDbType.VarChar, patientDAL.DateAdmitted),
                CreateParameter("@PatientDischargeDate", SqlDbType.VarChar, patientDAL.DateDischarged),
                CreateParameter("@PatientDiagnosis", SqlDbType.VarChar, patientDAL.Diagnosis),
                CreateParameter("@@PatientEmergencyContactName", SqlDbType.VarChar, patientDAL.Diagnosis),
                CreateParameter("@@PatientEmergencyContactNo", SqlDbType.VarChar, patientDAL.Diagnosis),
                CreateParameter("@InPatient", SqlDbType.VarChar, patientDAL.INPatient),
                CreateParameter("@OutPatient", SqlDbType.VarChar, patientDAL.OUTPatient),
                CreateParameter("@LateLogYN", SqlDbType.VarChar, patientDAL.LateLogYN),
                CreateParameter("@LateLogDate", SqlDbType.VarChar, patientDAL.LateLogDate));

                 cmd.Dispose();

                 return true;          
        }
        
        public void Patient_Delete(int personID)
        {
            ExecuteNonQuery("Person_Delete",
                CreateParameter("@PersonID", SqlDbType.Int, personID));
        }

        public bool PatientFileUnlock(string PatientFileNo, string UserSignedOn)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_PATIENT_FILE_UNLOCK",
            CreateParameter("@PatientFileNo", SqlDbType.VarChar, PatientFileNo),
            CreateParameter("@UserSignedOn", SqlDbType.VarChar, UserSignedOn));

            cmd.Dispose();
            return true;
        }

        public DataSet GetPatientEmails(string patientFileNo, string EmailKeyWord)
        {
            return ExecuteDataSet("AIMS_PATIENT_EMAILS_GET",
                CreateParameter("@PATIENT_FILE_NO", SqlDbType.VarChar, patientFileNo),
                CreateParameter("@EMAIL_KEYWORD", SqlDbType.VarChar, EmailKeyWord));
        }


        public DataSet GetPatientFileAudit(string patientFileNo)
        {
            return ExecuteDataSet("AIMS_PATIENT_FILE_AUDIT_GET",
                CreateParameter("@PATIENT_FILE_NO", SqlDbType.VarChar, patientFileNo));
        }        
        
        public DataSet GetPatientDetails(string filterId, string filterName)
        {
            return ExecuteDataSet("AIMS_PATIENT_FILTER",
                CreateParameter("@FILTER_NAME", SqlDbType.VarChar, filterName),
                CreateParameter("@FILTER_ID", SqlDbType.VarChar, filterId.ToString()));
        }

        public DataTable LoadPatientFiles()
        {
            return ExecuteDataTable("[AIMS_PATIENT_GET_ALL]");
        }

        public DataSet GetGuarantorRef(string GuarantorRefNo)
        {
            return ExecuteDataSet("AIMS_GET_PATIENT_GUARATOR_REFERENCE",
                CreateParameter("@GUARANTOR_REF_NO", SqlDbType.VarChar, GuarantorRefNo));
        }
    }
}
