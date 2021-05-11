CREATE proc AIMS_USER_GOP_LIMIT_CHECK  
 @UserID varchar(10) = '',  
 @PatientId varchar(50) = '',  
 @GOP_AMOUNT varchar(50) = '',  
 @GOP_OVER_LIMIT varchar(50) = 'N' output  
as  
begin  
 declare @UserLimit money  
   
 select @UserLimit = limit from AIMS_GOP_USER_LIMIT where user_name  = @UserID  
   
 --GOP amount greater user-limit  
 if @GOP_AMOUNT > @UserLimit  
 begin  
  SET @GOP_OVER_LIMIT = 'Y'  
  RETURN  
 end  
   
 SET @GOP_OVER_LIMIT = 'N'  
end