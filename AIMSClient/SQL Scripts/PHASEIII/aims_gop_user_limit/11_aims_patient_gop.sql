alter table AIMS_PATIENT_GOP add currency varchar(10)

alter PROC AIMS_PATIENT_GOP_ADD                     
 @GUARANTEE_ID varchar(20) ='' output,                        
@PATIENT_ID varchar(50) = '',    
@CONTACT_NAME varchar(50) = '',    
@EMAIL_ADDRESS varchar(50) = '',    
@GOP_CONSOLIDATED_AMT varchar(50) = '',    
@GOP_START_DATE varchar(50) = '',    
@GOP_END_DATE varchar(50) = '',    
@ROOM_TYPE varchar(50) = '',    
@GOP_NOTES varchar(50) = '',    
@GUARANTEE_POD varchar(500) = '',    
@UserSignedOn varchar(50) = '',    
@GOP_APPROVED_YN varchar(5) = '',
@CURRENCY varchar(5) = ''        
AS                        
BEGIN                        
                         
INSERT INTO AIMS_PATIENT_GOP(                        
PATIENT_ID,    
CONTACT_NAME,    
EMAIL_ADDRESS,    
GOP_CONSOLIDATED_AMOUNT,    
GOP_START_DATE,    
GOP_END_DATE,    
ROOM_TYPE_ID,    
GOP_NOTES,    
GUARANTEE_POD,    
CREATED_BY,    
GOP_APPROVED_YN, CURRENCY    
) VALUES(          
@PATIENT_ID ,    
@CONTACT_NAME,     
@EMAIL_ADDRESS,     
@GOP_CONSOLIDATED_AMT ,    
@GOP_START_DATE ,    
@GOP_END_DATE ,  @ROOM_TYPE ,    
@GOP_NOTES ,    
@GUARANTEE_POD,     
@UserSignedOn,     
@GOP_APPROVED_YN, 
@CURRENCY)                        
SET @GUARANTEE_ID = cast(IDENT_CURRENT('AIMS_PATIENT_GOP') as varchar(20))                        
END