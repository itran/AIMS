create  PROCEDURE AIMS_PATIENTS_ADMIN_FILES_ALLOCATED        
 @AdminStaff varchar(50) = ''        
AS                
BEGIN                
declare @vSQL nvarchar(4000)        
            
SELECT @vSQL = ' select  a.FILE_ASSIGNED_TO_USERID , 
a.patient_file_no FILE_NO,
dbo.getduedate(a.COURIER_RECEIPT_DATE) DUE_DATE
from 
aims_patient a,AIMS_A_PATIENT b where a.SENT_TO_ADMIN = ''Y'' and a.CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' 
and (a.COURIER_RECEIPT_DATE is not null or a.COURIER_RECEIPT_DATE <>'''')
and b.PATIENT_ID = a.PATIENT_ID
and b.AUDIT_ID = (select MIN(xx.AUDIT_ID) from AIMS_A_PATIENT xx where 
xx.PATIENT_ID = b.PATIENT_ID and xx.SENT_TO_ADMIN = ''Y'') and a.FILE_ASSIGNED_TO_USERID = ''' + @AdminStaff + ''''
      
  EXECUTE  sp_executesql  @vSQL        
END
