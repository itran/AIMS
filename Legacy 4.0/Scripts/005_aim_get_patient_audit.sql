create PROC AIMS_PATIENT_FILE_AUDIT_GET_NEW                     
 @PATIENT_FILE_NO varchar(50)                   
AS                        
BEGIN                        
    
     select     
a.MODIFIED_DATE ,    
MODIFIED_USER,    
MODIFIED_ACTION,    
PATIENT_FILE_NO ,    
PATIENT_INITIALS ,    
PATIENT_FIRST_NAME ,    
PATIENT_MIDDLE_NAME ,    
PATIENT_LAST_NAME ,    
PATIENT_ID_NO ,    
PATIENT_HOME_TEL_NO ,    
PATIENT_WORK_TEL_NO ,    
PATIENT_FAX_NO ,    
PATIENT_MOBILE_NO ,    
PATIENT_EMAIL_ADDRESS ,    
GUARANTOR_REF_NO ,    
PATIENT_FILE_ACTIVE_YN ,    
PATIENT_NATIONALITY ,    
PATIENT_GUARANTOR_AMOUNT ,    
PATIENT_FILE_COURIER_YN ,    
PATIENT_ADMISSION_DATE ,    
PATIENT_DISCHARGE_DATE ,    
PATIENT_DIAGNOSIS ,    
a.CREATION_DTTM ,    
b.ADDRESS1,b.ADDRESS2,b.ADDRESS3, b.ADDRESS4,b.ADDRESS5, b.PROVINCE,    
PATIENT_EMERGENCY_CONTACT_NAME ,    
PATIENT_EMERGENCY_CONTACT_NO ,    
IN_PATIENT ,    
OUT_PATIENT ,    
FILE_COURIER_DATE ,    
CANCELLED ,    
COURIER_WAYBILL_NO ,    
GUARANTOR247NO ,    
GUARANTOR247EMAIL ,    
FILE_ASSIGNED_TO_USERID ,    
COURIER_RECEIPT_DATE ,    
LATE_LOG_YN ,    
LATE_LOG_DATE ,    
PENDING ,    
PEND_DATE ,    
FILE_OPERATOR_TO_USERID ,    
PATIENT_DATE_OF_BIRTH ,    
LAB_LIST_DATE ,    
AFTER_HOURS_FILE ,    
SENT_TO_ADMIN ,    
c.TITLE_DESC,    
d.GUARANTOR_NAME,    
e.SUPPLIER_NAME,     
j.GUARANTOR_NAME FLIGHT_GUARANTOR_NAME,    
f.EVACUATION_TYPE_DESC,     
g.RMR_TYPE_DESC,    
h.TRANSPORT_TYPE_DESC,    
i.REPAT_TYPE_DESC,    
k.ASSIST_TYPE_DESC,  
a.HIGH_COST  
from AIMS_a_PATIENT a    
left outer join AIMS_ADDRESS b on b.ADDRESS_ID = a.ADDRESS_ID    
left outer join AIMS_TITLE c on c.TITLE_ID = a.TITLE_ID    
left outer join AIMS_GUARANTOR d on d.GUARANTOR_ID = a.GUARANTOR_ID    
left outer join AIMS_SUPPLIER e on e.SUPPLIER_ID = a.SUPPLIER_ID    
left outer join AIMS_EVACUATION_TYPES f on f.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID    
left outer join AIMS_RMR_TYPES g on g.RMR_TYPE_ID = a.PATIENT_RMR_TYPE_ID    
left outer join AIMS_TRANSPORT_TYPE h on h.TRANSPORT_TYPE_ID = a.PATIENT_TRANSPORT_TYPE_ID    
left outer join AIMS_REPAT_TYPE i on i.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID    
left outer join AIMS_GUARANTOR j on j.GUARANTOR_ID = a.FLIGHT_GUARANTOR_ID    
left outer join AIMS_ASSIST_TYPE k on k.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID    
where a.PATIENT_FILE_NO = @PATIENT_FILE_NO    
order by 1 desc    
              
END 