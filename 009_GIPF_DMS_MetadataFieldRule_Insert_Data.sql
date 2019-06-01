Declare 
Cursor documentType is (select Id from GIPF_DMS_DocumentType);
BEGIN
    For docType in documentType
    Loop
        Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='MemberNumber' ), docType.Id, 0, 1, 0, 1, 150, 'SYSTEM' ); --Member Number

        Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='PayrollNumber'), docType.Id, 0, 1, 0, 2, 150, 'SYSTEM' ); --Payroll Number

        Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='IdentityNumber'), docType.Id, 0, 1, 0, 3, 150, 'SYSTEM' ); --IdentityNumber

        Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='EmployeeNumber'), docType.Id, 0, 1, 0, 4, 150, 'SYSTEM' ); --EmployeeNumber
        
        Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='Firstname'), docType.Id, 0, 0, 0, 5, 150, 'SYSTEM' ); --name

        Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='Lastname'), docType.Id, 0, 0, 0, 6, 150, 'SYSTEM' ); --surname
        
                Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='BillingGroup'), docType.Id, 0, 0, 0, 7, 150, 'SYSTEM' ); --Billing Group
        
                        Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='SalaryNumber'), docType.Id, 0, 1, 0, 8, 150, 'SYSTEM' ); --SalaryNumber
        
             Insert Into GIPF_DMS_MetadataFieldRule(Id,MetadataFieldId,DocumentTypeId,IsRequired,IsSearchable,IsReadOnly,Sequence,MaximumSize,ModifiedBy)
        Values(GIPF_DMS_MetadataFieldRule_seq.NextVal,(select id from GIPF_DMS_MetadataField where name='MemberNumber'), docType.Id, 0, 1, 0, 9, 150, 'SYSTEM' ); --Date recieved
    End Loop;
  
  commit;
END;

update GIPF_DMS_MetadataField
set displayname = 'Date Of Birth'
WHERE Name = 'DateOfBirth';
commit;






