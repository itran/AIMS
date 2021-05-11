alter proc AIMS_PATIENT_GUARANTEE_APPROVE  
 @GOP_ID varchar(50)  
as  
begin  
 update AIMS_PATIENT_GOP set GOP_APPROVED_YN = 'Y' where GOP_ID = @GOP_ID  
end