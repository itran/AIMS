create PROCEDURE AIMS_PATIENTS_ADMIN_CLOSED_FILES          
AS                  
BEGIN                  
              select  a.FILE_ASSIGNED_TO_USERID ,   
a.patient_file_no FILE_NO,  
dbo.getduedate(a.FILE_COURIER_DATE) COURIER_DUE_DATE  ,
a.IN_PATIENT,
a.OUT_PATIENT,
a.RMR,
a.FLIGHT,
a.TRANSPORT,
a.ASSIST,
a.REPAT
from   
aims_patient a where a.CREATION_DTTM >='01 January 2018' and 
a.SENT_TO_ADMIN = 'Y' and a.CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'N'   
and (a.FILE_COURIER_DATE is not null or a.FILE_COURIER_DATE <>'')  
END  
