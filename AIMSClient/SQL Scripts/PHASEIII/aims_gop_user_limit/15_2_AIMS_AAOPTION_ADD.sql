ALTER proc AIMS_AAOPTION_ADD  
 @AAOptionId varchar(50) output,  
 @AAAIRCRAFT varchar(50),   
 @AAAVAILIBITY varchar(50),   
 @AACOST varchar(50) ,  
 @AALEVELOFCARE varchar(50) ,  
 @AAROUTING varchar(50),  
 @CreatedBy varchar(50),  
 @PatientId varchar(50),
 @ADMIN_FEE	varchar(50),
 @AMBULANCE_REFERRING	varchar(50),
 @AMBULANCE_RECEIVING	varchar(50),
 @AIRPORT_OPERATING_HOURS  varchar(50)
AS  
BEGIN  
 IF (@AAOptionId IS NULL or @AAOptionId = '')              
  begin  
  INSERT INTO [dbo].[AIMS_AA_OPTIONS]  
      ([AIRCRAFT]  
      ,[AVAILIBITY]  
      ,[COST]  
      ,[LEVELOFCARE]  
      ,[ROUTING]  
      ,CREATED_BY  
      ,PATIENT_ID
      ,ADMIN_FEE	
      ,AMBULANCE_REFERRING	
	  ,AMBULANCE_RECEIVING	
	  ,AIRPORT_OPERATING_HOURS)  
   VALUES(  
    @AAAIRCRAFT ,   
    @AAAVAILIBITY,   
    @AACOST  ,  
    @AALEVELOFCARE ,  
    @AAROUTING,    
    @CreatedBy,   
    @PatientId,
	@ADMIN_FEE,
	@AMBULANCE_REFERRING,
	@AMBULANCE_RECEIVING,
	@AIRPORT_OPERATING_HOURS)   
  SET @AAOptionId = IDENT_CURRENT('[AIMS_AA_OPTIONS]')  
 end  
else  
 begin  
  update [AIMS_AA_OPTIONS] set   
     [AIRCRAFT] = @AAAIRCRAFT  
      ,[AVAILIBITY] = @AAAVAILIBITY  
      ,[COST] = @AACOST  
      ,[LEVELOFCARE] = @AALEVELOFCARE  
      ,[ROUTING] = @AAROUTING  
      ,ADMIN_FEE = @ADMIN_FEE	
      ,AMBULANCE_REFERRING	 = @AMBULANCE_REFERRING
	  ,AMBULANCE_RECEIVING	 = @AMBULANCE_RECEIVING
	  ,AIRPORT_OPERATING_HOURS  = @AIRPORT_OPERATING_HOURS
      where AAOPTION_ID = @AAOptionId  
 END  
END