﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Legacy.Models
{
    public class PatientModel
    {
        public decimal PATIENT_ID { get; set; } //(decimal(18,0), not null)
        public string PATIENT_FILE_NO { get; set; } //(varchar(255), not null)
        public string PATIENT_NAME { get; set; } //(varchar(255), not null)
        public string PATIENT_INITIALS { get; set; } //(varchar(10), null)
        public string PATIENT_FIRST_NAME { get; set; } //(varchar(50), null)
        public string PATIENT_MIDDLE_NAME { get; set; } //(varchar(50), null)
        public string PATIENT_LAST_NAME { get; set; } //(varchar(50), null)
        public string PATIENT_ID_NO { get; set; } //(varchar(50), null)
        public decimal COMPANY_ID { get; set; } //(decimal(18,0), null)
        public decimal TITLE_ID { get; set; } //(decimal(18,0), null)
        public decimal ADDRESS_ID { get; set; } //(decimal(18,0), null)
        public string PATIENT_HOME_TEL_NO { get; set; } //(varchar(50), null)
        public string PATIENT_WORK_TEL_NO { get; set; } //(varchar(50), null)
        public string PATIENT_FAX_NO { get; set; } //(varchar(50), null)
        public string PATIENT_MOBILE_NO { get; set; } //(varchar(50), null)
        public string PATIENT_EMAIL_ADDRESS { get; set; } //(varchar(50), null)
        public decimal GUARANTOR_ID { get; set; } //(decimal(18,0), null)
        public string GUARANTOR_NAME { get; set; } //(varchar(255), null)
        public string GUARANTOR_REF_NO { get; set; } //(varchar(255), null)
        public string PATIENT_FILE_ACTIVE_YN { get; set; } //(varchar(1), null)
        public string PATIENT_NATIONALITY { get; set; } //(varchar(50), null)
        public string PATIENT_GUARANTOR_AMOUNT { get; set; } //(varchar(50), null)
        public int SUPPLIER_ID { get; set; } //(int, null)
        public string PATIENT_FILE_COURIER_YN { get; set; } //(varchar(50), null)
        public string PATIENT_ADMISSION_DATE { get; set; } //(varchar(50), null)
        public string PATIENT_DISCHARGE_DATE { get; set; } //(varchar(50), null)
        public string PATIENT_DIAGNOSIS { get; set; } //(varchar(255), null)
        
        [Column("CREATION_DTTM")]
        public DateTime CREATION_DTTM { get; set; } //(datetime, null)

        [Column("GUARANTOR_CREATION_DATE")]
        public DateTime GUARANTOR_CREATION_DATE { get; set; } //(datetime, null)

        public string PATIENT_EMERGENCY_CONTACT_NAME { get; set; } //(varchar(150), null)
        public string PATIENT_EMERGENCY_CONTACT_NO { get; set; } //(varchar(150), null)
        public string IN_PATIENT { get; set; } //(varchar(1), null)
        public string OUT_PATIENT { get; set; } //(varchar(1), null)
        public string ASSIST { get; set; } //(varchar(1), null)
        public DateTime FILE_COURIER_DATE { get; set; } //(datetime, null)
        public string FLIGHT { get; set; } //(varchar(1), null)
        public string REPAT { get; set; } //(varchar(1), null)
        public string CANCELLED { get; set; } //(varchar(1), null)
        public string COURIER_WAYBILL_NO { get; set; } //(varchar(255), null)
        public string TRANSPORT { get; set; } //(varchar(1), null)
        public string GUARANTOR247NO { get; set; } //(varchar(255), null)
        public string GUARANTOR247EMAIL { get; set; } //(varchar(255), null)
        public string FILE_ASSIGNED_TO_USERID { get; set; } //(varchar(255), null)
        public DateTime COURIER_RECEIPT_DATE { get; set; } //(datetime, null)
        public int PATIENT_ASSIST_TYPE_ID { get; set; } //(int, null)
        public int PATIENT_TRANSPORT_TYPE_ID { get; set; } //(int, null)
        public string LATE_LOG_YN { get; set; } //(varchar(1), null)
        public DateTime LATE_LOG_DATE { get; set; } //(datetime, null)
        public string PENDING { get; set; } //(varchar(1), null)
        public DateTime PEND_DATE { get; set; } //(datetime, null)
        public int PATIENT_EVACUATION_TYPE_ID { get; set; } //(int, null)
        public int PATIENT_REPAT_TYPE_ID { get; set; } //(int, null)
        public string FILE_OPERATOR_TO_USERID { get; set; } //(varchar(50), null)
        public string RMR { get; set; } //(varchar(1), null)
        public int PATIENT_RMR_TYPE_ID { get; set; } //(int, null)
        public decimal FLIGHT_GUARANTOR_ID { get; set; } //(decimal(18,0), null)
        public string PATIENT_DATE_OF_BIRTH { get; set; } //(varchar(50), null)
        public DateTime LAB_LIST_DATE { get; set; } //(datetime, null)
        public string AFTER_HOURS_FILE { get; set; } //(varchar(1), null)
        public string SENT_TO_ADMIN { get; set; } //(varchar(1), null)
        public string HIGH_COST { get; set; } //(varchar(1), null)
        public string SUPPLIER_NAME { get; set; } //(varchar(50), null)
    }
}
