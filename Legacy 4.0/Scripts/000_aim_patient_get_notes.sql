USE [AIMS]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GET_NOTES]    Script Date: 09/12/2020 19:46:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AIMS_PATIENT_GET_NOTES]        
    @PatientFileNo varchar(50) = '',      
    @NoteTypeCD varchar(50) = ''    
as       
 DECLARE @vSQL  nvarchar(4000) , @NoteTypeID int, @FileNoteType varchar(50)    
    
    
 SET @vSQL = 'SELECT b.user_full_name, a.notes_dttm, c.patient_id, a.notes  , d.NOTE_TYPE_DESC, a.note_id, d.note_type_id ' +    
    ' FROM aims_notes a, aims_users b, aims_patient c ,aims_note_types d ' +    
    ' WHERE c.patient_file_no =  ''' + @PatientFileNo + '''' +    
  ' AND a.patient_id = c.patient_id ' +    
  ' AND b.user_name = a.user_name ' +    
  ' AND d.NOTE_TYPE_CD in ('+  CAST(@NoteTypeCD as VARCHAR(50))  +')' +    
  ' AND a.note_type_id = d.note_type_id ' +    
  ' order by a.notes_dttm desc'    
  