CREATE PROCEDURE AIMS_ADMIN_WORK_ALLOCATED 
AS    
BEGIN    
declare @vSQL NVARCHAR(MAX)   
   
SELECT @vSQL = ''  
   
 SELECT count(a.file_assigned_to_userid), 
  a.file_assigned_to_userid 
  FROM aims_patient a
 WHERE a.sent_to_admin = 'Y'
   AND a.cancelled = 'N'
   AND a.patient_file_active_yn = 'Y'
group by a.file_assigned_to_userid 
order by file_assigned_to_userid

 EXECUTE sp_executesql @vSQL   
END  
 