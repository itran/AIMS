alter  PROC AIMS_PATIENT_GUARANTEE_APPROVED_YN      
 @GOP_ID varchar(50),      
 @GOP_APPROVED_YN varchar(50) output      
AS      
BEGIN      
 DECLARE @gopApproved varchar(1)    
    
  SELECT   @gopApproved = GOP_APPROVED_YN        
   FROM AIMS_PATIENT_GOP      
     WHERE GOP_ID =  @GOP_ID      
  ORDER BY 1 DESC      
  
 IF rtrim(ltrim(@gopApproved)) = 'Y'     
 BEGIN      
  SET @GOP_APPROVED_YN = 'Y'      
 END     
ELSE  
 BEGIN      
  SET @GOP_APPROVED_YN = 'N'      
 END     
END