    
alter PROC AIMS_PATIENT_GET_PATIENT_DOCS                
 @PatientFileNo varchar(50)                
AS                
BEGIN                
DECLARE @PatientID INT                
                 
SELECT @PatientID = PATIENT_ID FROM AIMS_PATIENT  WHERE PATIENT_FILE_NO = @PatientFileNo                
                 
SELECT 'VISA Letter'  DOC_NAME, VISA_LETTER_POD DOC_POD_FOLDER, CREATION_DTTM, VISA_LETTER_ID 'DOCUMENT_ID', vl.LOADED_BY 'CREATED_BY' FROM AIMS_VISA_LETTERS vl where ACTIVE_YN = 'Y' and PATIENT_ID = @PatientID              
 UNION              
 SELECT 'Patient Guarantee' DOC_NAME, GUARANTEE_POD  DOC_POD_FOLDER, CREATION_DTTM, GUARANTEE_ID 'DOCUMENT_ID', pg.LOADED_BY 'CREATED_BY' FROM AIMS_PATIENT_GUARANTEES pg                
 WHERE PATIENT_ID = @PatientID  and ACTIVE_YN = 'Y'          
 UNION              
 SELECT 'Air-Ambulance Cost Estimate' DOC_NAME, AA_POD  DOC_POD_FOLDER, CREATION_DTTM, AAID 'DOCUMENT_ID', aa.LOADED_BY 'CREATED_Y' FROM AIMS_AA_DETAILS aa                
 WHERE PATIENT_ID = @PatientID  and ACTIVE_YN = 'Y'              
 UNION              
 SELECT 'Accomodation Voucher' DOC_NAME, ACCOMODATION_LETTER  DOC_POD_FOLDER, CREATION_DTTM, ACCOMODATION_BOOKING_ID 'DOCUMENT_ID', av.CREATED_BY 'CREATED_BY' FROM aims_accomodation av                
 WHERE PATIENT_ID = @PatientID             
 ORDER BY 3, 1                
END