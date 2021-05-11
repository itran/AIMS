USE [master]
GO
/****** Object:  Database [AIMS]    Script Date: 05/11/2021 21:45:03 ******/
CREATE DATABASE [AIMS] ON  PRIMARY 
( NAME = N'AIMS_Data', FILENAME = N'D:\Data\AIMS.mdf' , SIZE = 6608000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'AIMS_Log', FILENAME = N'D:\Data\AIMS.ldf' , SIZE = 45631808KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
GO
ALTER DATABASE [AIMS] SET COMPATIBILITY_LEVEL = 80
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AIMS].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [AIMS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [AIMS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [AIMS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [AIMS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [AIMS] SET ARITHABORT OFF
GO
ALTER DATABASE [AIMS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [AIMS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [AIMS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [AIMS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [AIMS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [AIMS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [AIMS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [AIMS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [AIMS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [AIMS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [AIMS] SET  DISABLE_BROKER
GO
ALTER DATABASE [AIMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [AIMS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [AIMS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [AIMS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [AIMS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [AIMS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [AIMS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [AIMS] SET  READ_WRITE
GO
ALTER DATABASE [AIMS] SET RECOVERY FULL
GO
ALTER DATABASE [AIMS] SET  MULTI_USER
GO
ALTER DATABASE [AIMS] SET PAGE_VERIFY TORN_PAGE_DETECTION
GO
ALTER DATABASE [AIMS] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'AIMS', N'ON'
GO
USE [AIMS]
GO
/****** Object:  User [ops2]    Script Date: 05/11/2021 21:45:03 ******/
CREATE USER [ops2] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ops1]    Script Date: 05/11/2021 21:45:03 ******/
CREATE USER [ops1] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Crystal]    Script Date: 05/11/2021 21:45:03 ******/
CREATE USER [Crystal] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [brianm]    Script Date: 05/11/2021 21:45:03 ******/
CREATE USER [brianm] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Brian]    Script Date: 05/11/2021 21:45:03 ******/
CREATE USER [Brian] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [AIMS\Dashboard02]    Script Date: 05/11/2021 21:45:03 ******/
CREATE USER [AIMS\Dashboard02] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [aims]    Script Date: 05/11/2021 21:45:03 ******/
CREATE USER [aims] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[AIMS_USERS_AUDIT]    Script Date: 05/11/2021 21:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_USERS_AUDIT](
	[AUDIT_ID] [numeric](18, 0) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[USER_NAME] [varchar](50) NULL,
	[USER_FULL_NAME] [varchar](50) NULL,
	[USER_PASSWORD] [varchar](50) NULL,
	[USER_EMAIL] [varchar](50) NULL,
	[USER_PHONE] [varchar](50) NULL,
	[USER_FAX] [varchar](50) NULL,
	[USER_ACTIVE_YN] [varchar](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_USERS]    Script Date: 05/11/2021 21:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_USERS](
	[User_Name] [varchar](50) NOT NULL,
	[User_Full_Name] [varchar](50) NOT NULL,
	[User_Password] [varchar](50) NULL,
	[User_Email] [varchar](50) NULL,
	[User_Phone] [varchar](50) NULL,
	[User_Fax] [varchar](50) NULL,
	[User_Active_YN] [varchar](50) NOT NULL,
	[DOMAIN_AUTH_YN] [varchar](1) NULL,
	[LAST_LOGIN_DTTM] [datetime] NULL,
	[PASSWORD_SETUP] [varchar](1) NULL,
	[PASSWORD_HINT] [varchar](100) NULL,
	[PASSWORD_HINT_ANSWER] [varchar](200) NULL,
	[Job_Title] [varchar](100) NULL,
	[Department] [varchar](100) NULL,
	[SIGNATURE_PATH] [varchar](500) NULL,
	[JOB_TITLE_ID] [numeric](18, 0) NULL,
	[DEPARTMENT_ID] [numeric](18, 0) NULL,
	[DATE_OF_BIRTH] [date] NULL,
 CONSTRAINT [PK_AIMS_USERS] PRIMARY KEY CLUSTERED 
(
	[User_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 05/11/2021 21:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[AllDay] [bit] NULL,
	[Subject] [nvarchar](250) NULL,
	[Location] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Label] [int] NULL,
	[ResourceID] [int] NULL,
	[ResourceIDs] [nvarchar](max) NULL,
	[ReminderInfo] [nvarchar](max) NULL,
	[RecurrenceInfo] [nvarchar](max) NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_WORKLOAD_SNAPSHOT]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_WORKLOAD_SNAPSHOT]      
 @CoOrdinator varchar(50) = ''     
AS      
BEGIN      
declare @vSQL NVARCHAR(MAX)     
     
SELECT @vSQL = 'select ('''+@CoOrdinator +''' ) file_allocated_to,(SELECT count(a.FILE_OPERATOR_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d    
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' and      
 file_operator_to_userid IS NOT NULL and FILE_OPERATOR_TO_USERID in(    
 select User_Name from AIMS_USER_ROLE where ROLE_CD = ''Operations'')    
 and SENT_TO_ADMIN = ''N''      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 ''PATIENTFILEENQUIRY''))      
 AND c.guarantor_id = a.guarantor_id     
 and in_patient = ''Y''    
 and file_operator_to_userid = '''+@CoOrdinator +'''     
 AND d.user_name = file_operator_to_userid      
 group by a.FILE_OPERATOR_TO_USERID ) IN_PATIENT,    
 (SELECT  count(a.FILE_OPERATOR_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' and      
 file_operator_to_userid IS NOT NULL and FILE_OPERATOR_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = ''Operations'')     
 and SENT_TO_ADMIN = ''N''      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 ''PATIENTFILEENQUIRY''))      
 AND c.guarantor_id = a.guarantor_id     
 and out_patient = ''Y''    
 and file_operator_to_userid = '''+@CoOrdinator +'''     
 AND d.user_name = file_operator_to_userid      
 group by a.FILE_OPERATOR_TO_USERID ) OUT_PATIENT,    
 (SELECT  count(a.FILE_OPERATOR_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' and      
 file_operator_to_userid IS NOT NULL and FILE_OPERATOR_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = ''Operations'')     
 and SENT_TO_ADMIN = ''N''      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 ''PATIENTFILEENQUIRY''))      
 AND c.guarantor_id = a.guarantor_id     
 and RMR = ''Y''    
 and file_operator_to_userid = '''+@CoOrdinator +'''     
 AND d.user_name = file_operator_to_userid      
 group by a.FILE_OPERATOR_TO_USERID ) RMR,    
 (SELECT  count(a.FILE_OPERATOR_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' and      
 file_operator_to_userid IS NOT NULL and FILE_OPERATOR_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = ''Operations'')     
 and SENT_TO_ADMIN = ''N''      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 ''PATIENTFILEENQUIRY''))      
 AND c.guarantor_id = a.guarantor_id     
 and REPAT = ''Y''    
 and file_operator_to_userid = '''+@CoOrdinator +'''     
 AND d.user_name = file_operator_to_userid      
 group by a.FILE_OPERATOR_TO_USERID ) REPATS,    
 (SELECT  count(a.FILE_OPERATOR_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' and      
 file_operator_to_userid IS NOT NULL and FILE_OPERATOR_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = ''Operations'')     
 and SENT_TO_ADMIN = ''N''      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 ''PATIENTFILEENQUIRY''))      
 AND c.guarantor_id = a.guarantor_id     
 and FLIGHT = ''Y''    
 and file_operator_to_userid = '''+@CoOrdinator +'''     
 AND d.user_name = file_operator_to_userid      
 group by a.FILE_OPERATOR_TO_USERID ) Evacuations,    
 (SELECT  count(a.FILE_OPERATOR_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' and      
 file_operator_to_userid IS NOT NULL and FILE_OPERATOR_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = ''Operations'')     
 and SENT_TO_ADMIN = ''N''      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 ''PATIENTFILEENQUIRY''))      
 AND c.guarantor_id = a.guarantor_id     
 and ASSIST = ''Y''    
 and file_operator_to_userid = '''+@CoOrdinator +'''     
 AND d.user_name = file_operator_to_userid      
 group by a.FILE_OPERATOR_TO_USERID ) Assist,    
 (SELECT  count(a.FILE_OPERATOR_TO_USERID)     
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' and      
 file_operator_to_userid IS NOT NULL and FILE_OPERATOR_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = ''Operations'')     
 and SENT_TO_ADMIN = ''N''      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 ''PATIENTFILEENQUIRY''))      
 AND c.guarantor_id = a.guarantor_id     
 and TRANSPORT = ''Y''    
 and file_operator_to_userid = '''+@CoOrdinator +'''     
 AND d.user_name = file_operator_to_userid      
 group by a.FILE_OPERATOR_TO_USERID ) Transport,    
 (SELECT  COUNt(loaded_by)     
 FROM aims_patient_file_tasks a,     
 aims_tasks b,     
 aims_priority c,     
 aims_patient d     
 WHERE due_date < getdate ()     
 AND task_status_id IN (2, 8)     
 AND user_id IN (SELECT user_name     
 FROM aims_user_role)     
 AND b.task_id = a.task_id     
 AND c.priority_id = a.priority_id     
 AND d.patient_id = a.patient_id     
 and d.CANCELLED = ''N''    
 and d.SENT_TO_ADMIN = ''N'' and LOADED_BY ='''+@CoOrdinator +'''     
 group by LOADED_BY) overdue_tasks,    
 (select COUNT(*) from AIMS_EWS_OPERATOR_MAILS a, AIMS_EWS_OPERATOR_MAILBOX b where      
 b.OPERATOR_MAILBOX_USER_NAME ='''+@CoOrdinator +''' and a.OPERATOR_MAILBOX_ID= b.OPERATOR_MAILBOX_ID and     
 WORK_ITEM_PROCESSED_YN = ''N'' group by a.OPERATOR_MAILBOX_ID) WORKBASKET_ITEMS'     
     
 
 EXECUTE sp_executesql @vSQL     
END
GO
/****** Object:  Table [dbo].[AIMS_WARD_TYPES]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_WARD_TYPES](
	[WARD_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[WARD_TYPE] [varchar](50) NULL,
	[WARD_TYPE_DESC] [varchar](250) NULL,
 CONSTRAINT [PK_AIMS_WARD_TYPES] PRIMARY KEY CLUSTERED 
(
	[WARD_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IndustryClassesServices]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IndustryClassesServices](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[INDUSTRYCLASSCD] [varchar](50) NULL,
	[INDUSTRYCLASSSERVICECD] [varchar](50) NULL,
	[INDUSTRYCLASSSERVICEDESC] [varchar](50) NULL,
 CONSTRAINT [PK_IndustryClassesServices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hbao_resty1]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hbao_resty1](
	[HBAO_WM_TJEKNR] [varchar](255) NULL,
	[HBAO_CANCELLED_TJK] [varchar](255) NULL,
	[HBAO_TJK_VAL] [varchar](255) NULL,
	[HBAO_ID] [varchar](255) NULL,
	[HBAO_MPY_NO] [varchar](255) NULL,
	[HBAO_SPECIAL_NASIEN] [varchar](255) NULL,
	[HBAO_TYPE_BAO] [varchar](255) NULL,
	[HBAO_MESSAGE_TYPE] [varchar](255) NULL,
	[HBAO_DVD] [varchar](255) NULL,
	[HBAO_BEDRAG] [varchar](255) NULL,
	[HBAO_CALC_VAL] [varchar](255) NULL,
	[HBAO_OG] [varchar](255) NULL,
	[HBAO_ADR1] [varchar](255) NULL,
	[HBAO_ADR2] [varchar](255) NULL,
	[HBAO_ADR3] [varchar](255) NULL,
	[HBAO_ADR4] [varchar](255) NULL,
	[HBAO_POSK] [varchar](255) NULL,
	[HBAO_WG_ADR1] [varchar](255) NULL,
	[HBAO_WG_ADR2] [varchar](255) NULL,
	[HBAO_WG_ADR3] [varchar](255) NULL,
	[HBAO_WG_ADR4] [varchar](255) NULL,
	[HBAO_WG_POSK] [varchar](255) NULL,
	[HBAO_VERW_NR] [varchar](255) NULL,
	[HBAO_DVG] [varchar](255) NULL,
	[HBAO_BEVESTIG] [varchar](255) NULL,
	[HBAO_GESLAG] [varchar](255) NULL,
	[HBAO_VAK] [varchar](255) NULL,
	[HBAO_HUW_STAT] [varchar](255) NULL,
	[HBAO_VERDIENSTE] [varchar](255) NULL,
	[HBAO_VERDIENSTE_PM] [varchar](255) NULL,
	[HBAO_KH] [varchar](255) NULL,
	[HBAO_KH_PM] [varchar](255) NULL,
	[HBAO_TOT_SAL] [varchar](255) NULL,
	[HBAO_URE_DAG] [varchar](255) NULL,
	[HBAO_URE_WEEK] [varchar](255) NULL,
	[HBAO_DAE_WEEK] [varchar](255) NULL,
	[HBAO_TOEK_LOON] [varchar](255) NULL,
	[HBAO_TOEK_LOON_PM] [varchar](255) NULL,
	[HBAO_FQ] [varchar](255) NULL,
	[HBAO_MIN_REEDS] [varchar](255) NULL,
	[HBAO_ARTIKEL] [varchar](255) NULL,
	[HBAO_42] [varchar](255) NULL,
	[HBAO_PERCENT] [varchar](255) NULL,
	[HBAO_GELDSOM] [varchar](255) NULL,
	[HBAO_OPM1] [varchar](255) NULL,
	[HBAO_OPM2] [varchar](255) NULL,
	[HBAO_PRINT_CALC] [varchar](255) NULL,
	[HBAO_INTER_CALC] [varchar](255) NULL,
	[HBAO_AMT_CALC] [varchar](255) NULL,
	[HBAO_MAKSIMUM] [varchar](255) NULL,
	[FK_HTAO_EIS] [varchar](255) NULL,
	[FK_HTAO_DUP] [varchar](255) NULL,
	[FIRST_NAME] [varchar](255) NULL,
	[SUR_NAME] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hbao_resty]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hbao_resty](
	[HBAO_WM_TJEKNR] [varchar](255) NULL,
	[HBAO_CANCELLED_TJK] [varchar](255) NULL,
	[HBAO_TJK_VAL] [varchar](255) NULL,
	[HBAO_ID] [varchar](255) NULL,
	[HBAO_MPY_NO] [varchar](255) NULL,
	[HBAO_SPECIAL_NASIEN] [varchar](255) NULL,
	[HBAO_TYPE_BAO] [varchar](255) NULL,
	[HBAO_MESSAGE_TYPE] [varchar](255) NULL,
	[HBAO_DVD] [varchar](255) NULL,
	[HBAO_BEDRAG] [varchar](255) NULL,
	[HBAO_CALC_VAL] [varchar](255) NULL,
	[HBAO_OG] [varchar](255) NULL,
	[HBAO_ADR1] [varchar](255) NULL,
	[HBAO_ADR2] [varchar](255) NULL,
	[HBAO_ADR3] [varchar](255) NULL,
	[HBAO_ADR4] [varchar](255) NULL,
	[HBAO_POSK] [varchar](255) NULL,
	[HBAO_WG_ADR1] [varchar](255) NULL,
	[HBAO_WG_ADR2] [varchar](255) NULL,
	[HBAO_WG_ADR3] [varchar](255) NULL,
	[HBAO_WG_ADR4] [varchar](255) NULL,
	[HBAO_WG_POSK] [varchar](255) NULL,
	[HBAO_VERW_NR] [varchar](255) NULL,
	[HBAO_DVG] [varchar](255) NULL,
	[HBAO_BEVESTIG] [varchar](255) NULL,
	[HBAO_GESLAG] [varchar](255) NULL,
	[HBAO_VAK] [varchar](255) NULL,
	[HBAO_HUW_STAT] [varchar](255) NULL,
	[HBAO_VERDIENSTE] [varchar](255) NULL,
	[HBAO_VERDIENSTE_PM] [varchar](255) NULL,
	[HBAO_KH] [varchar](255) NULL,
	[HBAO_KH_PM] [varchar](255) NULL,
	[HBAO_TOT_SAL] [varchar](255) NULL,
	[HBAO_URE_DAG] [varchar](255) NULL,
	[HBAO_URE_WEEK] [varchar](255) NULL,
	[HBAO_DAE_WEEK] [varchar](255) NULL,
	[HBAO_TOEK_LOON] [varchar](255) NULL,
	[HBAO_TOEK_LOON_PM] [varchar](255) NULL,
	[HBAO_FQ] [varchar](255) NULL,
	[HBAO_MIN_REEDS] [varchar](255) NULL,
	[HBAO_ARTIKEL] [varchar](255) NULL,
	[HBAO_42] [varchar](255) NULL,
	[HBAO_PERCENT] [varchar](255) NULL,
	[HBAO_GELDSOM] [varchar](255) NULL,
	[HBAO_OPM1] [varchar](255) NULL,
	[HBAO_OPM2] [varchar](255) NULL,
	[HBAO_PRINT_CALC] [varchar](255) NULL,
	[HBAO_INTER_CALC] [varchar](255) NULL,
	[HBAO_AMT_CALC] [varchar](255) NULL,
	[HBAO_MAKSIMUM] [varchar](255) NULL,
	[FK_HTAO_EIS] [varchar](255) NULL,
	[FK_HTAO_DUP] [varchar](255) NULL,
	[FIRST_NAME] [varchar](255) NULL,
	[SUR_NAME] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Guarantors Query2]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guarantors Query2](
	[GuarantorID] [int] NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Address1] [nvarchar](255) NULL,
	[City] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[Country/Region] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guarantors Query1]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guarantors Query1](
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Medical Aid/Guarantor] [int] NULL,
	[Guarantor Reference Number] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guarantors Combo]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guarantors Combo](
	[SupplierName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guarantors]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guarantors](
	[GuarantorID] [int] NOT NULL,
	[SupplierName] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[Address1] [nvarchar](255) NULL,
	[City] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[StateOrProvince] [nvarchar](20) NULL,
	[Country/Region] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](30) NULL,
	[FaxNumber] [nvarchar](30) NULL,
	[PaymentID] [int] NULL,
	[Render Date] [smalldatetime] NULL,
	[Today] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EDS2]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EDS2](
	[PatientListID] [int] NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[Sum Of Amount Paid] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EDS1]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EDS1](
	[PatientListID] [int] NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[Sum Of Amount Received] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eds ombo]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eds ombo](
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Supplier] [int] NULL,
	[Service] [nvarchar](20) NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[Date of Invoice] [varchar](50) NULL,
	[Invoice Number1] [nvarchar](50) NULL,
	[Amount Received] [money] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EDS Final Outstanding]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EDS Final Outstanding](
	[PatientListID] [int] NULL,
	[Sum Of Amount Received] [money] NULL,
	[Sum Of Amount Paid] [money] NULL,
	[Expr1] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[edb days rendered]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[edb days rendered](
	[SupplierName] [nvarchar](50) NULL,
	[File Number] [int] NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Date Rendered] [varchar](50) NULL,
	[Days Over] [float] NULL,
	[Expr1] [money] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ed]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ed](
	[PatientListID] [int] NULL,
	[Hospital/Clinic Name] [int] NULL,
	[Name Of Doctor] [nvarchar](50) NULL,
	[Profession] [int] NULL,
	[Treatment] [ntext] NULL,
	[Date of Treatment] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Doctors & Suppliers]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors & Suppliers](
	[DoctorID] [int] NOT NULL,
	[SupplierName] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[ContactTitle] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[City] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[StateOrProvince] [nvarchar](20) NULL,
	[Country/Region] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](30) NULL,
	[FaxNumber] [nvarchar](30) NULL,
	[Profession] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[date rendered edb]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[date rendered edb](
	[File Number] [int] NULL,
	[Date Rendered] [varchar](50) NULL,
	[Today] [varchar](50) NULL,
	[Days Over] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[date rendered]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[date rendered](
	[DateRenderID] [int] NOT NULL,
	[File Number] [int] NULL,
	[Date Rendered] [varchar](50) NULL,
	[Today] [datetime] NULL,
	[Days Over] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Date Combo]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Date Combo](
	[Date of Invoice] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_TITLES_GET]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_TITLES_GET]  
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select *  from aims_title as ap ' 

	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_TITLE]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_TITLE](
	[TITLE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TITLE_DESC] [varchar](10) NULL,
 CONSTRAINT [PK_AIMS_TITLE] PRIMARY KEY CLUSTERED 
(
	[TITLE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_TEMPLATES]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_TEMPLATES](
	[TEMPLATE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TEMPLATE_NAME] [varchar](100) NOT NULL,
	[TEMPLATE_DESC] [varchar](100) NOT NULL,
 CONSTRAINT [PK_AIMS_TEMPLATES] PRIMARY KEY CLUSTERED 
(
	[TEMPLATE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_TASKS]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_TASKS](
	[TASK_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TASK_DESC] [varchar](100) NOT NULL,
	[TASK_SLA] [numeric](18, 0) NOT NULL,
	[TASK_ACTIVE_YN] [varchar](1) NOT NULL,
 CONSTRAINT [PK_AIMS_TASKS] PRIMARY KEY CLUSTERED 
(
	[TASK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_TASK_STATUS]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_TASK_STATUS](
	[TASK_STATUS_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TASK_STATUS] [varchar](50) NOT NULL,
	[STATUS_ACTIVE_YN] [varchar](1) NOT NULL,
 CONSTRAINT [PK_AIMS_TASK_STATUS] PRIMARY KEY CLUSTERED 
(
	[TASK_STATUS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_TRANSPORT_TYPE]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_TRANSPORT_TYPE](
	[TRANSPORT_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRANSPORT_TYPE_DESC] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_TRANSPORT_TYPE] PRIMARY KEY CLUSTERED 
(
	[TRANSPORT_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX1_AIMS_TRANSPORT_TYPE] UNIQUE NONCLUSTERED 
(
	[TRANSPORT_TYPE_DESC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_USER_GET]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_USER_GET]  
    @UserName varchar(50) = ''
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select * from aims_users where user_name = ''' + cast(@UserName as varchar(50)) + ''''

	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PAYMENT_METHODS_GET]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_PAYMENT_METHODS_GET]  
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select *  from aims_payment_method as ap order by payment_method ' 

	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_PAYMENT_METHOD]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_PAYMENT_METHOD](
	[PAYMENT_METHOD_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PAYMENT_METHOD] [varchar](50) NULL,
	[PAYMENT_METHOD_NOTES] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_PAYMENT_METHOD] PRIMARY KEY CLUSTERED 
(
	[PAYMENT_METHOD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_SERVICE]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_SERVICE](
	[SERVICE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[SERVICE_DESCRIPTION] [varchar](255) NULL,
	[SERVIVE_NOTES] [varchar](1000) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SUPPLIER_GET_ALL_TYPE]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AIMS_SUPPLIER_GET_ALL_TYPE]          
	@SUPPLIER_TYPE_ID varchar(50)
as         
 declare @vSQL  nvarchar(500)        
         
 set @vSQL = 'select  supplier_id, supplier_name from AIMS_SUPPLIER where (SUPPLIER_NAME = '''' or SUPPLIER_NAME is null) union ' +
	' select supplier_id,  '+
	' case doctor_supplier_yn  When ''N'' THEN supplier_name when ''Y'' then ''Dr '' + doctor_name_initials + '' '' + doctor_surname END SUPPLIER_NAME' +        
    ' FROM aims_supplier as ass ' +
    ' WHERE ass.SUPPLIER_ACTIVE_YN = ''Y'' and '+
    ' ass.supplier_type_id = '+ @SUPPLIER_TYPE_ID +' order by supplier_name '
--   where supplier_name <> ''<Add New Hospital>'' order by supplier_name'  
print @vSQL      
 EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SUPPLIER_GET_ALL]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_SUPPLIER_GET_ALL]        
as       
 declare @vSQL  nvarchar(500)      
       
 set @vSQL = 'select * ' +      
    ' from aims_supplier as ass   WHERE ass.SUPPLIER_ACTIVE_YN = ''Y'' order by supplier_name'    
--   where supplier_name <> ''<Add New Hospital>'' order by supplier_name'      
 EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SUPPLIER_GET]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_SUPPLIER_GET]    
    @SupplierID varchar(50)  
as   
 declare @vSQL  nvarchar(500)  
   
 set @vSQL = 'select * ' +  
    ' from aims_supplier as ass ' +  
   ' left outer join aims_address   as aa on ass.address_id  = aa.address_id ' +  
   ' left outer join aims_supplier_types  as ast on ass.supplier_type_id  = ast.supplier_type_id ' +  
   ' where ' +  
   ' (ass.supplier_id  = ' + cast(@SupplierID as varchar(50)) + ') AND SUPPLIER_ACTIVE_YN = ''Y'''  
  
 EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_SESSIONS]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_SESSIONS](
	[SESSION_ID] [uniqueidentifier] NULL,
	[SESSION_VARIABLE_CD] [varchar](50) NULL,
	[SESSION_VARIABLE_VALUE] [varchar](50) NULL,
	[SESSION_DTTM] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SERVICES_GET_ALL]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_SERVICES_GET_ALL]  
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select * from AIMS_SERVICE order by service_description'

	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_SERVICE_COST_LIMIT]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AIMS_SERVICE_COST_LIMIT](
	[COST_LIMIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[SUPPLIER_TYPE_ID] [numeric](18, 0) NULL,
	[COST_LIMIT] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AIMS_SERVICE_COST_LIMIT] PRIMARY KEY CLUSTERED 
(
	[COST_LIMIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_SERVICE_COST_LIMIT] ON [dbo].[AIMS_SERVICE_COST_LIMIT] 
(
	[SUPPLIER_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IX_AIMS_SERVICE_COST_LIMIT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AIMS_SERVICE_COST_LIMIT', @level2type=N'INDEX',@level2name=N'IX_AIMS_SERVICE_COST_LIMIT'
GO
/****** Object:  Table [dbo].[AIMS_SUPPLIER_TYPES]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_SUPPLIER_TYPES](
	[SUPPLIER_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[SUPPLIER_TYPE_DESC] [varchar](255) NULL,
 CONSTRAINT [PK_AIMS_SUPPLIER_TYPES] PRIMARY KEY CLUSTERED 
(
	[SUPPLIER_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SUPPLIER_TYPE_GET]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_SUPPLIER_TYPE_GET]  
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select *  from aims_supplier_types order by SUPPLIER_TYPE_DESC'
			
	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[Years]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Years](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Year] [varchar](50) NULL,
 CONSTRAINT [PK_Years] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [INDX1_YEAR] ON [dbo].[Years] 
(
	[Year] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[W1NAMMAST]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[W1NAMMAST](
	[NA_REGNR] [varchar](255) NULL,
	[NA_SC] [varchar](255) NULL,
	[NA_TK] [varchar](255) NULL,
	[NA_BEGINDAT] [varchar](255) NULL,
	[NA_REGDAT] [varchar](255) NULL,
	[NA_KANSDAT] [varchar](255) NULL,
	[NA_SPESRDAT] [varchar](255) NULL,
	[NA_KS] [varchar](255) NULL,
	[NA_MD] [varchar](255) NULL,
	[NA_PK] [varchar](255) NULL,
	[NA_SPES] [varchar](255) NULL,
	[NA_AARD] [varchar](255) NULL,
	[NA_HANDEL] [varchar](255) NULL,
	[NA_POS_D] [varchar](255) NULL,
	[NA_POSADRES_1] [varchar](255) NULL,
	[NA_POSADRES_2] [varchar](255) NULL,
	[NA_POSADRES_3] [varchar](255) NULL,
	[NA_POSADRES_4] [varchar](255) NULL,
	[NA_POSADRES_5] [varchar](255) NULL,
	[SEQUENCE] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[get_sales_for_title]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_sales_for_title]
@title varchar(80),   -- This is the input parameter.
@ytd_sales int OUTPUT -- This is the output parameter.
AS  

-- Get the sales for the specified title and 
-- assign it to the output parameter.
SELECT @ytd_sales = ytd_sales
FROM titles
WHERE title = @title

RETURN
GO
/****** Object:  Table [dbo].[Temp]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp](
	[ID] [int] NOT NULL,
	[PatientListID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table_1](
	[PATIENT_ID] [numeric](18, 0) NULL,
	[TEST] [varchar](50) NULL,
	[test2] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IDX11] ON [dbo].[Table_1] 
(
	[PATIENT_ID] ASC,
	[TEST] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Switchboard Items]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Switchboard Items](
	[SwitchboardID] [int] NULL,
	[ItemNumber] [smallint] NULL,
	[ItemText] [nvarchar](255) NULL,
	[Command] [smallint] NULL,
	[Argument] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers Combo]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers Combo](
	[Supplier] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[summary Query]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[summary Query](
	[Sum Of Total Outstanding] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[summary]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[summary](
	[SupplierName] [nvarchar](50) NULL,
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Amount Received] [money] NULL,
	[SumOfAmount Paid] [money] NULL,
	[Total Outstanding] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[ResourceID] [int] NOT NULL,
	[ResourceName] [nvarchar](50) NULL,
	[Color] [int] NULL,
	[Image] [image] NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Render Date]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Render Date](
	[GuarantorID] [varchar](50) NULL,
	[SupplierName] [nvarchar](50) NULL,
	[Guarantor Reference Number] [nvarchar](50) NULL,
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Sum Of Amount Received] [money] NULL,
	[Sum Of Amount Paid] [money] NULL,
	[Expr1] [money] NULL,
	[Render Date] [varchar](50) NULL,
	[Today] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProfessionTypeID] [int] NOT NULL,
	[Profession Type] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRAKTISYNE]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRAKTISYNE](
	[PRAC_PRAC] [varchar](255) NULL,
	[PRAC_DISCIPLINE] [varchar](255) NULL,
	[PRAC_SUB_DISCIPLINE] [varchar](255) NULL,
	[PRAC_PROVINCE] [varchar](255) NULL,
	[PRAC_FILLER] [varchar](255) NULL,
	[PRAC_TITLE] [varchar](255) NULL,
	[PRAC_NAME] [varchar](255) NULL,
	[PRAC_ADDRESS1] [varchar](255) NULL,
	[PRAC_ADDRESS2] [varchar](255) NULL,
	[PRAC_ADDRESS3] [varchar](255) NULL,
	[PRAC_ADDRESS4] [varchar](255) NULL,
	[PRAC_POST] [varchar](255) NULL,
	[SEQUENCE] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payments Received sub form]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payments Received sub form](
	[PatientListID] [int] NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[Receipt Number] [nvarchar](50) NULL,
	[Date of Receipt] [varchar](50) NULL,
	[Amount Paid] [money] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payments Received]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payments Received](
	[PaymentID] [int] NOT NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[PatientListID] [int] NULL,
	[Guarantor] [int] NULL,
	[Amount Paid] [money] NULL,
	[Receipt Number] [nvarchar](50) NULL,
	[Date of Receipt] [varchar](50) NULL,
	[Method of Payment] [int] NULL,
	[Cheque Number] [nvarchar](50) NULL,
	[Credit Card Number] [nvarchar](50) NULL,
	[Bank Transfer Reference] [nvarchar](50) NULL,
	[Notices] [ntext] NULL,
	[Invoice Number1] [nvarchar](50) NULL,
	[Render Date] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PATIENT_FILE_COUNTER]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PATIENT_FILE_COUNTER](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_FILE_YEAR] [varchar](50) NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patient List Query]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient List Query](
	[Aims File Number] [nvarchar](50) NULL,
	[SumOfAmount Received] [money] NULL,
	[Amount Paid] [money] NULL,
	[Total Outstanding] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient List 1 Query]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patient List 1 Query](
	[GuarantorID] [varchar](50) NULL,
	[SupplierName] [nvarchar](50) NULL,
	[Guarantor Reference Number] [nvarchar](50) NULL,
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Date of Discharge] [varchar](50) NULL,
	[Sum Of Amount Paid] [money] NULL,
	[Sum Of Amount Received] [money] NULL,
	[Expr1] [money] NULL,
	[Date Admitted] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patient List 1]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient List 1](
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Company Name] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[Country] [nvarchar](50) NULL,
	[Home Phone] [nvarchar](30) NULL,
	[Work Phone] [nvarchar](30) NULL,
	[Mobile Phone] [nvarchar](30) NULL,
	[Fax Number] [nvarchar](30) NULL,
	[Email Address] [nvarchar](50) NULL,
	[Passport/ID Number] [int] NOT NULL,
	[Nationality] [nvarchar](50) NULL,
	[Emergency Contact Name] [nvarchar](50) NULL,
	[Emergency Contact Phone] [nvarchar](30) NULL,
	[Medical Aid/Guarantor] [int] NULL,
	[Guarantor Reference Number] [nvarchar](50) NULL,
	[Medical Assistance/Support] [nvarchar](255) NULL,
	[Notes] [ntext] NULL,
	[GuarantorID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient List]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient List](
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paste Errors]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paste Errors](
	[Field0] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalUpdate Query]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MedicalUpdate Query](
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[DoctorID] [int] NOT NULL,
	[Hospital/Clinic Name] [int] NULL,
	[Name Of Doctor] [nvarchar](50) NULL,
	[Profession] [int] NULL,
	[Treatment] [ntext] NULL,
	[Date of Treatment] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MedicalUpdate]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MedicalUpdate](
	[DoctorID] [int] NOT NULL,
	[Hospital/Clinic Name] [int] NULL,
	[Name Of Doctor] [nvarchar](50) NULL,
	[Profession] [int] NULL,
	[Treatment] [ntext] NULL,
	[Date of Treatment] [varchar](50) NULL,
	[PatientListID] [int] NULL,
	[Patient Name] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JJ Query]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[JJ Query](
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[Supplier] [int] NULL,
	[Amount Received] [money] NULL,
	[Guarantor] [int] NULL,
	[SumOfAmount Paid] [money] NULL,
	[Total Outstanding] [money] NULL,
	[Date of Invoice] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JJ]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[JJ](
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[Supplier] [int] NULL,
	[Amount Received] [money] NULL,
	[Guarantor] [int] NULL,
	[SumOfAmount Paid] [money] NULL,
	[Total Outstanding] [int] NULL,
	[Date of Invoice] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invoices received sub form]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoices received sub form](
	[PatientListID] [int] NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[Supplier] [int] NULL,
	[Service] [nvarchar](20) NULL,
	[Date Admitted] [varchar](50) NULL,
	[Date of Discharge] [varchar](50) NULL,
	[Invoice Number1] [nvarchar](50) NULL,
	[Date of Invoice] [varchar](50) NULL,
	[Amount Received] [money] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invoices received patient list]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoices received patient list](
	[PatientListID] [int] NOT NULL,
	[First Name] [nvarchar](50) NULL,
	[Last Name] [nvarchar](50) NULL,
	[GuarantorID] [varchar](50) NULL,
	[SupplierName] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[Address1] [nvarchar](255) NULL,
	[City] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[Country/Region] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](30) NULL,
	[Guarantor Reference Number] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invoices received Combo]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices received Combo](
	[Aims File Number] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices received]    Script Date: 05/11/2021 21:45:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices received](
	[Supplier] [int] NULL,
	[Service] [nvarchar](20) NULL,
	[Aims File Number] [nvarchar](50) NULL,
	[Date Admitted] [smalldatetime] NULL,
	[Date of Discharge] [smalldatetime] NULL,
	[Amount Received] [money] NULL,
	[PatientListID] [int] NULL,
	[Date of Invoice] [smalldatetime] NULL,
	[Total Outstanding] [int] NULL,
	[Invoice Number1] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[initcap]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[initcap] (@text varchar(4000))
returns varchar(4000)
as

begin
	declare 	@counter int, 
		@length int,
		@char char(1),
		@textnew varchar(4000)

	set @text		= rtrim(@text)
	set @text		= lower(@text)
	set @length 	= len(@text)
	set @counter 	= 1
	
	if len(rtrim(lTRIM(@text))) > 0 
	begin
		set @text = upper(left(@text, 1) ) + right(@text, @length - 1) 
	
		while @counter <> @length --+ 1
		begin
			select @char = substring(@text, @counter, 1)
	
			IF @char = space(1)  or @char =  '_' or @char = ','  or @char = '.' or @char = '\'  or @char = '/' or @char = '(' or @char = ')'
			begin
				set @textnew = left(@text, @counter)  + upper(substring(@text,  @counter+1, 1)) + right(@text, (@length - @counter) - 1)
				set @text	 = @textnew
			end
	
			set @counter = @counter + 1
		end
	END
	return @text
end
GO
/****** Object:  Table [dbo].[AIMS_A_USERS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_USERS](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[User_Name] [varchar](50) NOT NULL,
	[User_Full_Name] [varchar](50) NOT NULL,
	[User_Password] [varchar](10) NOT NULL,
	[User_Email] [varchar](50) NULL,
	[User_Phone] [varchar](50) NULL,
	[User_Fax] [varchar](50) NULL,
	[User_Active_YN] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_SUPPLIER]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_SUPPLIER](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[SUPPLIER_ID] [numeric](18, 0) NULL,
	[SUPPLIER_TYPE_ID] [numeric](18, 0) NULL,
	[TITLE_ID] [numeric](18, 0) NULL,
	[SUPPLIER_NAME] [varchar](255) NULL,
	[ADDRESS_ID] [numeric](18, 0) NULL,
	[SUPPLIER_EMAIL_ADDRESS] [varchar](50) NULL,
	[SUPPLIER_PHONE_NO] [varchar](50) NULL,
	[SUPPLIER_FAX_NO] [varchar](50) NULL,
	[SUPPLIER_MOBILE_NO] [varchar](50) NULL,
	[SUPPLIER_ACTIVE_YN] [varchar](1) NULL,
	[SUPPLIER_ACCOUNT_NO] [varchar](50) NULL,
	[SUPPLIER_CONTACT_NAME] [varchar](255) NULL,
	[DOCTOR_SUPPLIER_YN] [varchar](1) NULL,
	[DOCTOR_NAME_INITIALS] [varchar](255) NULL,
	[DOCTOR_SURNAME] [varchar](255) NULL,
	[ADMIN_NAME] [varchar](50) NULL,
	[ADMIN_TEL_PHONE] [varchar](50) NULL,
	[ADMIN_FAX] [varchar](50) NULL,
	[ADMIN_EMAIL] [varchar](50) NULL,
	[ADMIN_CELL] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_SERVICE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_SERVICE](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[SERVICE_ID] [numeric](18, 0) NULL,
	[SERVICE_DESCRIPTION] [varchar](255) NULL,
	[SERVIVE_NOTES] [varchar](1000) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_PAYMENT_METHOD]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_PAYMENT_METHOD](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[PAYMENT_METHOD_ID] [numeric](18, 0) NULL,
	[PAYMENT_METHOD] [numeric](18, 0) NULL,
	[PAYMENT_METHOD_NOTES] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_PAYMENT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_PAYMENT](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[PAYMENT_ID] [numeric](18, 0) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[GUARANTOR_ID] [numeric](18, 0) NULL,
	[AMOUNT_PAID] [varchar](50) NULL,
	[RECEIPT_NO] [varchar](50) NULL,
	[DATE_OF_RECEIPT] [varchar](50) NULL,
	[PAYMENT_METHOD_ID] [numeric](18, 0) NULL,
	[CHEQUE_NO] [varchar](50) NULL,
	[CREDIT_CARD_NO] [varchar](50) NULL,
	[BANK_TRANSFER_REF_NO] [varchar](50) NULL,
	[NOTICES] [varchar](50) NULL,
	[INVOICE_ID] [numeric](18, 0) NULL,
	[RENDER_DATE] [varchar](50) NULL,
	[PAYMENT_PROCESSED_YN] [varchar](1) NULL,
	[LOCKED_YN] [varchar](1) NULL,
	[FOREX_PAYMENT] [varchar](1) NULL,
	[INSURANCE_OVERPYMT] [varchar](1) NULL,
	[INSURANCE_SHORTPYMT] [varchar](1) NULL,
	[DOCTOR_OWING] [varchar](1) NULL,
	[LATE_SUBMISSION_PYMT] [varchar](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_PATIENT_SERVICE_PROVIDERS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_PATIENT_SERVICE_PROVIDERS](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[SERVICE_PROVIDER_ID] [int] NULL,
	[PATIENT_ID] [int] NULL,
	[SUPPLIER_TYPE_ID] [int] NULL,
	[SERVICE_PROVIDER_NAME] [varchar](500) NULL,
	[SERVICE_PROVIDER_PHONE] [varchar](500) NULL,
	[SERVICE_PROVIDER_FAX_NO] [varchar](500) NULL,
	[SERVICE_PROVIDER_EMAIL] [varchar](500) NULL,
	[USER_NAME] [varchar](50) NULL,
	[ADMIN_NAME] [varchar](255) NULL,
	[ADMIN_TEL_PHONE] [varchar](255) NULL,
	[ADMIN_FAX_NO] [varchar](255) NULL,
	[ADMIN_EMAIL] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [AIMS_A_PATIENT_SERVICE_PROVIDERS_IDX1] ON [dbo].[AIMS_A_PATIENT_SERVICE_PROVIDERS] 
(
	[SERVICE_PROVIDER_ID] ASC,
	[AUDIT_ID] ASC
)
INCLUDE ( [MODIFIED_DATE]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_A_PATIENT_FILE_TASKS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_A_PATIENT_FILE_TASKS](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NOT NULL,
	[MODIFIED_ACTION] [varchar](50) NOT NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
	[PATIENT_FILE_TASK_ID] [numeric](18, 0) NOT NULL,
	[TASK_ID] [numeric](18, 0) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NOT NULL,
	[USER_ID] [varchar](50) NOT NULL,
	[DUE_DATE] [datetime] NOT NULL,
	[COMPLETION_DATE] [datetime] NULL,
	[DETAILS] [varchar](2000) NOT NULL,
	[ACTIVE_YN] [varchar](1) NOT NULL,
	[LOADED_BY] [varchar](50) NULL,
	[CREATION_DATE] [datetime] NULL,
	[PRIORITY_ID] [numeric](18, 0) NULL,
	[TASK_STATUS_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_A_PATIENT_FILE_TASKS] PRIMARY KEY CLUSTERED 
(
	[AUDIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_PATIENT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_PATIENT](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[PATIENT_ID] [numeric](18, 0) NOT NULL,
	[PATIENT_FILE_NO] [varchar](255) NOT NULL,
	[PATIENT_INITIALS] [varchar](10) NULL,
	[PATIENT_FIRST_NAME] [varchar](50) NULL,
	[PATIENT_MIDDLE_NAME] [varchar](50) NULL,
	[PATIENT_LAST_NAME] [varchar](50) NULL,
	[PATIENT_ID_NO] [varchar](50) NULL,
	[COMPANY_ID] [numeric](18, 0) NULL,
	[TITLE_ID] [numeric](18, 0) NULL,
	[ADDRESS_ID] [numeric](18, 0) NULL,
	[PATIENT_HOME_TEL_NO] [varchar](50) NULL,
	[PATIENT_WORK_TEL_NO] [varchar](50) NULL,
	[PATIENT_FAX_NO] [varchar](50) NULL,
	[PATIENT_MOBILE_NO] [varchar](50) NULL,
	[PATIENT_EMAIL_ADDRESS] [varchar](50) NULL,
	[GUARANTOR_ID] [numeric](18, 0) NULL,
	[GUARANTOR_REF_NO] [varchar](255) NULL,
	[PATIENT_FILE_ACTIVE_YN] [varchar](1) NULL,
	[PATIENT_NATIONALITY] [varchar](50) NULL,
	[PATIENT_GUARANTOR_AMOUNT] [varchar](50) NULL,
	[SUPPLIER_ID] [int] NULL,
	[PATIENT_FILE_COURIER_YN] [varchar](50) NULL,
	[PATIENT_ADMISSION_DATE] [varchar](50) NULL,
	[PATIENT_DISCHARGE_DATE] [varchar](50) NULL,
	[PATIENT_DIAGNOSIS] [varchar](255) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[PATIENT_EMERGENCY_CONTACT_NAME] [varchar](150) NULL,
	[PATIENT_EMERGENCY_CONTACT_NO] [varchar](150) NULL,
	[IN_PATIENT] [varchar](1) NULL,
	[OUT_PATIENT] [varchar](1) NULL,
	[ASSIST] [varchar](1) NULL,
	[FILE_COURIER_DATE] [datetime] NULL,
	[FLIGHT] [varchar](1) NULL,
	[REPAT] [varchar](1) NULL,
	[CANCELLED] [varchar](1) NULL,
	[COURIER_WAYBILL_NO] [varchar](255) NULL,
	[TRANSPORT] [varchar](1) NULL,
	[GUARANTOR247NO] [varchar](255) NULL,
	[GUARANTOR247EMAIL] [varchar](255) NULL,
	[FILE_ASSIGNED_TO_USERID] [varchar](255) NULL,
	[COURIER_RECEIPT_DATE] [datetime] NULL,
	[PATIENT_ASSIST_TYPE_ID] [int] NULL,
	[PATIENT_TRANSPORT_TYPE_ID] [int] NULL,
	[LATE_LOG_YN] [varchar](1) NULL,
	[LATE_LOG_DATE] [datetime] NULL,
	[PENDING] [varchar](1) NULL,
	[PEND_DATE] [datetime] NULL,
	[PATIENT_EVACUATION_TYPE_ID] [int] NULL,
	[PATIENT_REPAT_TYPE_ID] [int] NULL,
	[FILE_OPERATOR_TO_USERID] [varchar](50) NULL,
	[RMR] [varchar](1) NULL,
	[PATIENT_RMR_TYPE_ID] [int] NULL,
	[FLIGHT_GUARANTOR_ID] [numeric](18, 0) NULL,
	[PATIENT_DATE_OF_BIRTH] [varchar](50) NULL,
	[LAB_LIST_DATE] [datetime] NULL,
	[AFTER_HOURS_FILE] [varchar](1) NULL,
	[SENT_TO_ADMIN] [varchar](1) NULL,
	[HIGH_COST] [varchar](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [AIMS_A_PATIENT_IDX11] ON [dbo].[AIMS_A_PATIENT] 
(
	[PATIENT_FILE_NO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [AIMS_A_PATIENT_IDC13] ON [dbo].[AIMS_A_PATIENT] 
(
	[PATIENT_ID] ASC
)
INCLUDE ( [AUDIT_ID],
[MODIFIED_USER],
[MODIFIED_ACTION],
[MODIFIED_DATE],
[PATIENT_FILE_NO],
[PATIENT_INITIALS],
[PATIENT_FIRST_NAME],
[PATIENT_MIDDLE_NAME],
[PATIENT_LAST_NAME],
[PATIENT_ID_NO],
[COMPANY_ID],
[TITLE_ID],
[ADDRESS_ID],
[PATIENT_HOME_TEL_NO],
[PATIENT_WORK_TEL_NO],
[PATIENT_FAX_NO],
[PATIENT_MOBILE_NO],
[PATIENT_EMAIL_ADDRESS],
[GUARANTOR_ID],
[GUARANTOR_REF_NO],
[PATIENT_FILE_ACTIVE_YN],
[PATIENT_NATIONALITY],
[PATIENT_GUARANTOR_AMOUNT],
[SUPPLIER_ID],
[PATIENT_FILE_COURIER_YN],
[PATIENT_ADMISSION_DATE],
[PATIENT_DISCHARGE_DATE],
[PATIENT_DIAGNOSIS],
[CREATION_DTTM],
[PATIENT_EMERGENCY_CONTACT_NAME],
[PATIENT_EMERGENCY_CONTACT_NO],
[IN_PATIENT],
[OUT_PATIENT],
[ASSIST],
[FILE_COURIER_DATE],
[FLIGHT],
[REPAT],
[CANCELLED],
[COURIER_WAYBILL_NO],
[TRANSPORT],
[GUARANTOR247NO],
[GUARANTOR247EMAIL],
[FILE_ASSIGNED_TO_USERID],
[COURIER_RECEIPT_DATE],
[PATIENT_ASSIST_TYPE_ID],
[PATIENT_TRANSPORT_TYPE_ID],
[LATE_LOG_YN],
[LATE_LOG_DATE],
[PENDING],
[PEND_DATE],
[PATIENT_EVACUATION_TYPE_ID],
[PATIENT_REPAT_TYPE_ID],
[FILE_OPERATOR_TO_USERID],
[RMR],
[PATIENT_RMR_TYPE_ID],
[FLIGHT_GUARANTOR_ID],
[PATIENT_DATE_OF_BIRTH],
[LAB_LIST_DATE],
[AFTER_HOURS_FILE],
[SENT_TO_ADMIN]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [AIMS_A_PATIENT_IDX10] ON [dbo].[AIMS_A_PATIENT] 
(
	[PATIENT_FILE_NO] ASC
)
INCLUDE ( [AUDIT_ID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [AIMS_A_PATIENT_IDX12] ON [dbo].[AIMS_A_PATIENT] 
(
	[PATIENT_ID] ASC,
	[PENDING] ASC,
	[AUDIT_ID] ASC,
	[MODIFIED_USER] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [AIMS_A_PATIENT_IDX13] ON [dbo].[AIMS_A_PATIENT] 
(
	[PATIENT_ID] ASC,
	[AUDIT_ID] ASC
)
INCLUDE ( [MODIFIED_USER]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_A_INVOICE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_INVOICE](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[INVOICE_ID] [numeric](18, 0) NOT NULL,
	[INVOICE_NO] [varchar](255) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[INVOICE_DATE] [varchar](50) NULL,
	[INVOICE_AMOUNT_RECEIVED] [varchar](50) NULL,
	[GENERATED_YN] [varchar](1) NULL,
	[LOCKED_YN] [varchar](1) NULL,
	[LATE_INVOICE_YN] [varchar](1) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[cancelled_yn] [varchar](1) NULL,
	[DOCTOR_OWING] [varchar](1) NULL,
	[LATE_INVOICE_SENT] [varchar](1) NULL,
	[LATE_INVOICE_SENT_DATE] [varchar](50) NULL,
	[INVOICE_SENT_WAYBILL_NO] [varchar](50) NULL,
	[GUARANTOR_ACCOUNT_ID] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_GUARANTOR]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_GUARANTOR](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[GUARANTOR_ID] [numeric](18, 0) NULL,
	[GUARANTOR_NAME] [varchar](1000) NULL,
	[GUARANTOR_PHONE_NO] [varchar](50) NULL,
	[GUARANTOR_FAX_NO] [varchar](50) NULL,
	[ADDRESS_ID] [numeric](18, 0) NULL,
	[GUARANTOR_EMAIL_ADDRESS] [char](50) NULL,
	[GUARANTOR_ACTIVE_YN] [varchar](1) NULL,
	[GUARANTOR_CONTACT_PERSON] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_EWS_INSTANT_MESSAGING]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_EWS_INSTANT_MESSAGING](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[IINSTANT_MESSAGE_ID] [numeric](18, 0) NULL,
	[INSTANT_MESSAGE_DTTM] [date] NOT NULL,
	[INSTANT_MESSAGE_TEXT] [varchar](50) NOT NULL,
	[INSTANT_MESSAGE_TO] [varchar](50) NOT NULL,
	[INSTANT_MESSAGE_FROM] [varchar](50) NOT NULL,
	[INSTANT_MESSAGE_PATIENT_ID] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_AIMS_A_EWS_INSTANT_MESSAGING] PRIMARY KEY CLUSTERED 
(
	[AUDIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_COMPANIES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_COMPANIES](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[COMPANY_ID] [numeric](18, 0) NULL,
	[COMPANY_NAME] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_APPOINTMENTS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_APPOINTMENTS](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [varchar](50) NULL,
	[APPOINTMENT_ID] [numeric](18, 0) NULL,
	[APPOINTMENT_SUBJECT] [varchar](1000) NULL,
	[APPOINTMENT_ADDRESS] [varchar](1000) NULL,
	[APPOINTMENT_DATE] [varchar](1000) NULL,
	[APPOINTMENT_TIME_HOUR] [numeric](18, 0) NULL,
	[APPOINTMENT_TIME_MINUTE] [numeric](18, 0) NULL,
	[REMINDER_YN] [varchar](1) NULL,
	[REMINDER_PERIOD] [varchar](50) NULL,
	[TRANSPORT_YN] [varchar](1) NULL,
	[TRANSPORT_TYPE_ID] [int] NULL,
	[PICK_UP_TIME_HOUR] [numeric](18, 0) NULL,
	[PICK_UP_TIME_MINUTE] [numeric](18, 0) NULL,
	[DROP_UP_TIME_HOUR] [numeric](18, 0) NULL,
	[DROP_UP_TIME_MINUTE] [numeric](18, 0) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[CREATED_DTTM] [datetime] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[APPOINTMENT_NOTE] [varchar](1000) NULL,
	[APPOINTMENT_TIME] [datetime] NULL,
	[PICK_UP_TIME] [datetime] NULL,
	[DROP_OFF_TIME] [datetime] NULL,
	[TRANSLATOR_YN] [varchar](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_A_ACCOUNTS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_A_ACCOUNTS](
	[AUDIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MODIFIED_USER] [varchar](50) NULL,
	[MODIFIED_ACTION] [varchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ACCOUNT_TYPE] [varchar](50) NULL,
	[NOTES] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountTypeID] [int] NOT NULL,
	[AccountType] [nvarchar](50) NULL,
	[Notes] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CompCare_Employee_Load]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompCare_Employee_Load] 
@MemberNo varchar(50),
@PolicyHolderID int,
@PolicyHolderPremisesID int,
@PolicyID int, 
@PolicySOIID int,
@LastErrorNo INT OUTPUT
AS
	DECLARE 
		@vSQL nvarchar(3400), 	
		@ClaimNumber varchar(50),
		@EmployeeName varchar(50),
		@EmployeeIDNo varchar(255),	
		@EmployeePDPerc	 varchar(255),
		@EmployeeDateOfBirth varchar(255),
		@EmployeeDOBDay varchar(255),
		@EmployeeDOBMonth varchar(255),
		@EmployeeDOBYear varchar(255),
		@EmployeeDateOfAccident varchar(255),
		@EmployeeInjuryDescription varchar(255),
		@EmployerRegNo varchar(255),
		@ClaimApprovalDate varchar(255),
		@ClaimApprovalRDate Datetime,
		@Remarks varchar(255),
		@ClaimStatus varchar(255),
		@ThirdPartyClaim varchar(255),
		@EmployeeNo varchar(255),
		@ClaimOffDuty varchar(255),
		@EmployerSubClass varchar(255),
		@ClaimLabourCentre varchar(255),
		@ClaimProvince varchar(255),
		@EmployeeAddress1 varchar(255),
		@EmployeeAddress2 varchar(255),
		@EmployeeAddress3 varchar(255),
		@EmployeeAddress4 varchar(255),
		@EmployeePostalCode varchar(255),
		@EmployeeBankingDetailID int,
		@EmployeeAddressID int,
		@LanguageID int,
		@Language varchar(50),
		@ClaimsSequenceNo int,
		@PersonID int,
		@EventID int,
		@PersonEventID int,
		@PersonEmploymentID int,
		@PhysicalDamageID int,
		@InjuryID int,
		@ClaimStatusID int,
		@EmployeesCount int,
		@IDNoGenderIndicator int,
		@GenderID int,
		@MedicalReportID int,
		@ClaimID int,
		@HearingAssessmentID int,
		@MedicalAssessmentID int,
		@RowCheck int,
		@EmployeeAccidentDay  varchar(255),
		@EmployeeAccidentMonth varchar(255),
		@EmployeeAccidentYear varchar(255),
		@ThisProc varchar(255),
		@MsgFmt varchar(255),
		@Error int,
		@RowCount int,
		@Msg varchar(255),
		@TotalPD varchar(255),
		@CurrentTotalPD varchar(255),
		@EstimatedPD as varchar(255)

		SELECT @ThisProc       = 'CompCare_Employee_Load'  
		          ,@MsgFmt    = '%s. %s. (Error %u, Rows %u).'  
		          ,@Error     = 0  
		          ,@RowCount  = 0  
		
		-- Loop through all employees linked to this employer			
		DECLARE PH_Employees_Events_Cursor CURSOR FOR
		/* -- CLaims/Persons/Events/Injuries COLUMNS---
		EISE_KEY		- Claim/Injury number 
		EN_WERKSMAN		- Employee.
		EN_ID			- ID no/ passport
		EN_BAO			- PD percentage.
		EN_DVG			- Date-of-birth
		EN_DVO			- Date-of-accident.
		EN_BESERING		- Description of injury.
		EN_REGNR		- Employer registration number. Key to employer master table
		EN_CASE_CLAIM		- CONFIRM ???? What is this Column for??
		EN_VOR_REGNR		- Date claim approved.
		EN_REMARKS		- Remarks.
		EN_AI_KODE		- Part „A“ of WCL2 outstanding (CONFIRM ???? What is this Column for??)
		EN_T_LEER		- Claim status: „ „ accepted, “R” Repudiated, “N” Not accepted yet, “K” Cancelled, “T” temp file, “C” send to JhB CCOD,“Q” Waiting for documents, "F" Finalised.
		EN_MPY_NR		- Employee company number.
		SEQUENCE		- Database sequence - NOT USED
		EN_GT3DAYS		- Claim more than 3 days OFFDUTY.
		EN_SUBCLASS		- Industry code.
		EN_3RD_PARTY		- 3rd party injury.
		EN_LABOUR_CENTRE	- Labour centre where claim was captured.
		EN_PROVINCE		- Province where claim was captured.
		EN_EMPLE_ADR1		- Employee address 1.
		EN_EMPLE_ADR2		- Employee address 2.
		EN_EMPLE_ADR3		- Employee address 3.
		EN_EMPLE_ADR4		- Employee address 4.
		EN_EMPLE_POST		- Employee postal code.
		*/
		select DISTINCT
			EISE_KEY,
			EN_WERKSMAN,
			EN_ID,
			EN_BAO,
			EN_DVG,
			EN_DVO,
			EN_BESERING,
			EN_REGNR,
			EN_VOR_REGNR,
			EN_REMARKS,
			EN_T_LEER,
			EN_MPY_NR,
			EN_GT3DAYS,
			EN_SUBCLASS,
			EN_3RD_PARTY,
			EN_LABOUR_CENTRE,
			EN_PROVINCE,
			EN_EMPLE_ADR1,
			EN_EMPLE_ADR2,
			EN_EMPLE_ADR3,
			EN_EMPLE_ADR4,
			EN_EMPLE_POST
		FROM EISENOM WHERE CAST(en_regnr AS INT) = @MemberNo
		--AND @MemberNo NOT IN (SELECT EMPLOYERMEMBERNO FROM CONVERTED_EMPLOYEES)
		
		PRINT 'Employers Employees Conversion Started'
		PRINT 'Policy ID - ' + CAST(@PolicyID AS VARCHAR(50))
		PRINT 'Policy SOI ID - ' + CAST(@PolicySOIID AS VARCHAR(50))

		OPEN PH_Employees_Events_Cursor
		
		FETCH NEXT FROM PH_Employees_Events_Cursor
		INTO 
		@ClaimNumber,
		@EmployeeName,
		@EmployeeIDNo,
		@EmployeePDPerc,
		@EmployeeDateOfBirth ,
		@EmployeeDateOfAccident, 
		@EmployeeInjuryDescription,
		@EmployerRegNo,
		@ClaimApprovalDate,
		@Remarks,
		@ClaimStatus,
		@EmployeeNo,
		@ClaimOffDuty, 
		@EmployerSubClass,
		@ThirdPartyClaim,
		@ClaimLabourCentre,
		@ClaimProvince,
		@EmployeeAddress1, 
		@EmployeeAddress2, 
		@EmployeeAddress3, 
		@EmployeeAddress4, 
		@EmployeePostalCode
		
		-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
		WHILE @@FETCH_STATUS = 0
		BEGIN
			BEGIN TRANSACTION
				SET @GenderID = 0
				SET @EmployeeBankingDetailID = 0
				SET @LastErrorNo = 1
				
				IF (@ClaimApprovalDate IS NOT NULL)
				BEGIN
					IF (LEN(@ClaimApprovalDate) > 0)
					BEGIN
						IF (ISDATE(@ClaimApprovalDate) = 1)
						BEGIN
							SET @ClaimApprovalRDate = CAST(@ClaimApprovalDate as datetime)
						END
						ELSE
						BEGIN
							SET @ClaimApprovalRDate = GETDATE()
						END
					END
					ELSE
					BEGIN
						SET @ClaimApprovalRDate = GETDATE()
					END
				END
				ELSE
				BEGIN
					SET @ClaimApprovalRDate = GETDATE()
				END
				
				IF (@EmployeeDateOfBirth IS NOT NULL)
				BEGIN
					-- Date-of-birth missing first 0
					IF (LEN(@EmployeeDateOfBirth) = 7)
					BEGIN
						SET @EmployeeDateOfBirth = '0' + CAST(@EmployeeDateOfBirth AS VARCHAR(50))
					END
	
					SET @EmployeeDOBDay  	= SUBSTRING(@EmployeeDateOfBirth, 1, 2)
					SET @EmployeeDOBMonth  	= SUBSTRING(@EmployeeDateOfBirth, 3, 2)
					SET @EmployeeDOBYear  	= SUBSTRING(@EmployeeDateOfBirth, 5, 4)
	
					SET @EmployeeDateOfBirth = @EmployeeDOBDay + '/' + @EmployeeDOBMonth + '/' + @EmployeeDOBYear
					
				END

				PRINT 'Employee Date Of Birth - ' + CAST(@EmployeeDateOfBirth AS VARCHAR(50))
				
				-- If Date-of-birth missing, Get the DOB from ID-NUmber
				--IF (ISDATE(@EmployeeDateOfBirth) = 0)
				--BEGIN
					IF (LEN(@EmployeeIDNo) > 0)
					BEGIN
						SET @EmployeeDOBDay  	= SUBSTRING(@EmployeeIDNo, 5, 2)
						SET @EmployeeDOBMonth  	= SUBSTRING(@EmployeeIDNo, 3, 2)
						SET @EmployeeDOBYear  	= SUBSTRING(@EmployeeIDNo, 1, 2)					
						SET @EmployeeDateOfBirth = @EmployeeDOBMonth + '/' + @EmployeeDOBDay + '/' + @EmployeeDOBYear
						SET @EmployeeDateOfBirth = CAST(CAST(@EmployeeDateOfBirth AS SMALLDATETIME) AS VARCHAR(30))
						PRINT 'Employee Date Of Birth Based on ID-Number- ' + CAST(@EmployeeDateOfBirth AS VARCHAR(50))						
					END
				--END
				
				--Get Gender based on ID Number
				IF (@EmployeeIDNo IS NOT NULL)
				BEGIN
					IF (LEN(@EmployeeIDNo) = 13)
					BEGIN
						SET @IDNoGenderIndicator = SUBSTRING(LTRIM(RTRIM(@EmployeeIDNo)), 7,1)
						SELECT @GenderID = 
							CASE @IDNoGenderIndicator
								WHEN 0 THEN 1
								WHEN 1 THEN 1
								WHEN 2 THEN 1
								WHEN 4 THEN 1
								WHEN 5 THEN 2
								WHEN 6 THEN 2
								WHEN 7 THEN 2
								WHEN 8 THEN 2
								WHEN 9 THEN 2
							ELSE 0
							END
					END
				END

				SELECT @LanguageID = CASE @Language 
					When 'A' THEN 2
					When 'E' THEN 3
					ELSE 0
				END	

				SELECT @ClaimStatusID = CASE @ClaimStatus
					WHEN '' THEN 5
					WHEN 'D' THEN  5
					WHEN 'K' THEN 0
					WHEN 'N' THEN 12
					WHEN 'Q' THEN 7
					WHEN 'R' THEN 0
					ELSE 0
				END

				-- As per Ernest default this claim status = 5 - All payments have been made OR No payments expected
				SET @ClaimStatusID = 5
				
				SET @PersonID = 0
				
				IF (@EmployeeIDNo IS NULL)
				BEGIN
					SET @EmployeeIDNo = ''
				END

				IF (@EmployeeDateOfBirth IS NULL)
				BEGIN
					SET @EmployeeDateOfBirth = ''		
				END
				
				PRINT 'Person Gender Type' 	+ CAST(@GenderID as VARCHAR(50))
				PRINT 'Person Name' 		+ CAST(@EmployeeName as VARCHAR(50))
				PRINT 'Person ID Number' 	+ CAST(@EmployeeIDNo as VARCHAR(50))
				PRINT 'Person Date Of Birth' 	+ CAST(@EmployeeDateOfBirth as VARCHAR(50))
				
				IF (@EmployeeIDNo IS NOT NULL)	
				BEGIN
					SELECT @RowCheck = COUNT(*) from person where IDNumber = @EmployeeIDNo
				END
				
				IF (@RowCheck = 0)
				BEGIN
					SELECT @RowCheck = COUNT(*) from person where dateofbirth = convert(smalldatetime,@EmployeeDateOfBirth, 103) and Surname = @EmployeeName and FirstName = @EmployeeName and GenderTypeID = @GenderID
				END
				
				IF (@EmployeePDPerc IS NULL)
				BEGIN
					SET @EmployeePDPerc = 0
				END

				PRINT 'Person Already Exists' 	+ CAST(@RowCheck as VARCHAR(50))
				PRINT '@EmployeePDPerc -- ' 	+ CAST(@EmployeePDPerc as VARCHAR(50))
				IF (@CurrentTotalPD IS NULL)
				BEGIN
					SET @CurrentTotalPD = '0'
				END

				PRINT '@CurrentTotalPD -- ' 	+ CAST(@CurrentTotalPD as VARCHAR(50))
	
				IF (@RowCheck > 0)
				BEGIN
					SELECT @CurrentTotalPD = TOTALPD FROM person where (IDNumber = @EmployeeIDNo or dateofbirth = convert(smalldatetime,@EmployeeDateOfBirth, 103)) and Surname = @EmployeeName and FirstName = @EmployeeName and GenderTypeID = @GenderID

					IF (@CurrentTotalPD IS NOT NULL)
					BEGIN
						SET  @TotalPD =  CAST(@EmployeePDPerc AS INT) + CAST(@CurrentTotalPD AS INT)
					END
					ELSE
					BEGIN
						SET  @TotalPD =  CAST(@EmployeePDPerc AS INT)						
					END
				
					SELECT @PersonID = ID from person where (IDNumber = @EmployeeIDNo or dateofbirth = convert(smalldatetime,@EmployeeDateOfBirth, 103)) and Surname = @EmployeeName and 	FirstName = @EmployeeName and GenderTypeID = @GenderID
				END
				ELSE
				BEGIN

					IF (@TotalPD IS NULL)
					BEGIN
						SET @TotalPD = 0
					END

					SELECT @TotalPD =  CAST(@EmployeePDPerc AS INT)
					SET @PersonID = 0
				END

				PRINT 'Person ID ' 	+ CAST(@PersonID as VARCHAR(50))				
				
				IF (@PersonID IS NULL OR @PersonID = 0)
				BEGIN
					INSERT INTO ADDRESS(
						Postal1,
						Postal2,
						Postal3,
						Postal4,
						PostalCode,
						Physical1,
						Physical2,
						Physical3,
						Physical4,
						PhysicalCode,
						Email,
						WebURL,
						NearestCityID,
						ContactName,
						ContactDescription,
						ContactTitleID,
						TelAreaCode,
						TelNumber,
						FaxNumber,
						FaxAreaCode,
						HomeAreaCode,
						HomeNumber,
						CellNumber,
						District,
						LanguageID,
						IsAuthorised,
						LastChangeUserID,
						tmp_ClientCode)
					VALUES(@EmployeeAddress1, 
						@EmployeeAddress2, 
						@EmployeeAddress3, 
						@EmployeeAddress4, 
						@EmployeePostalCode, 
						NULL, 
						NULL,
						NULL,
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						0, 
						NULL, 
						NULL, 
						0, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						@LanguageID, 
						0, 
						0, 
						NULL)
					
					SET @EmployeeAddressID = IDENT_CURRENT('ADDRESS')
					
					Print 'Employee Name - ' + CAST(@EmployeeName AS VARCHAR(50))

					-- Capture Person(Employee) Details
					INSERT INTO PERSON(          
						IndustryNumber,
						Surname,
						FirstName,
						OtherInitial,
						TitleID,
						IDNumber,
						OtherIDNumber,
						PassportNumber,
						CountryOfPassportID,
						DateOfBirth,
						DateOfMarriage,
						DateOfDeath,
						CauseOfDeath,
						DeathCertNumber,
						TaxRefNumber,
						PopulationGroupID,
						GenderTypeID,
						MaritalStatusTypeID,
						ProvinceOfOriginID,
						HealthStatusID,
						IsHIVPositive,
						IsHIVPositiveCC95,
						IsRedFlagCase,
						BankingDetailID,
						AddressID,
						BagNumber,
						PFNumber,
						TotalPD,
						EstimatedTotalPD,
						InjuryTotalPD,
						PenIndividualNo,
						PenCaseNumber,
						RMAPensionNumber,
						LastChangeUserID,
						IsActive,
						HoldingKey,
						FinSystemSynchStatusID,
						PenSystemSynchStatusID,
						DeathDueToPersonEventID,
						ArchiveDate,
						tmp_ClientCode,
						tmp_PrintName,
						tmp_Name,
						tmp_Initials,
						PDCalcOperands
					)
					VALUES(
						NULL, 
						@EmployeeName, 
						@EmployeeName, 
						NULL, 
						0, 
						@EmployeeIDNo, 
						NULL, 
						NULL, 
						11, 
						convert(smalldatetime,@EmployeeDateOfBirth, 103), 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						0, 
						@GenderID, 
						0, 
						0, 
						0, 
						0, 
						0, 
						0, 
						@EmployeeBankingDetailID, 
						@EmployeeAddressID, 
						NULL, 
						NULL, 
						@TotalPD, 
						'.00', 
						'.00',
						NULL, 
						NULL, 
						NULL, 
						0, 
						1, 
						NULL, 
						0, 
						0, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						NULL, 
						NULL
					)   
					SET @PersonID   =  IDENT_CURRENT('PERSON')					
				END

				SET @EmployeeDateOfBirth = ''
				
				INSERT INTO PersonEmployment(
					PersonID,
					PolicyHolderID,
					SundryServiceProviderID,
					EmployeeNumber,
					StartDate,
					EndDate,
					PatersonGradingID,
					IsSkilled,
					IsTrainingPosition,
					OccupationCodeID,
					EventOccupationCodeID,
					LengthOfServiceInOccupation,
					LengthOfServiceWithEmployer,
					LastChangeUserID,
					tmp_ClaimNumber,
					StartDateInIndustry,
					StartDateInOccupation,
					LengthOfServiceInIndustry,
					LocationCategoryID,
					NoOfShifts,
					NoiseLevel,
					HoursPerShift) 
				VALUES
				(
					@PersonID, 
					@PolicyHolderID, 
					NULL, 
					@EmployeeNo, 
					NULL, 
					NULL, 
					0, 
					1, 
					0, 
					0, 
					0, 
					NULL, 
					NULL, 
					0, 
					NULL, 
					NULL,
					NULL,				
					NULL, 
					0, 
					NULL, 
					NULL, 
					NULL)

				SET @PersonEmploymentID = IDENT_CURRENT('PersonEmployment')
				SELECT @ClaimsSequenceNo = MAX(ClaimSequenceNumber) + 1 FROM Claim
				IF (@ClaimsSequenceNo IS NULL)
				BEGIN
					SET @ClaimsSequenceNo = 1
				END
				
				IF (@EmployeeDateOfAccident IS NOT NULL)
				BEGIN
					-- Date-of-birth missing first 0
					IF (LEN(@EmployeeDateOfAccident) = 7)
					BEGIN
						SET @EmployeeDateOfAccident = '0' + CAST(@EmployeeDateOfAccident AS VARCHAR(50))
					END

					SET @EmployeeAccidentDay  	= SUBSTRING(@EmployeeDateOfAccident, 1, 2)
					SET @EmployeeAccidentMonth  	= SUBSTRING(@EmployeeDateOfAccident, 3, 2)
					SET @EmployeeAccidentYear  	= SUBSTRING(@EmployeeDateOfAccident, 5, 4)
	
					SET @EmployeeDateOfAccident = @EmployeeAccidentDay + '/' + @EmployeeAccidentMonth + '/' + @EmployeeAccidentYear
				END

				PRINT 'Employee Date Of Accident - ' + CAST(@EmployeeDateOfAccident AS VARCHAR(50))
				PRINT 'Policy SOI ID - ' + CAST(@PolicySOIID AS VARCHAR(50))

				-- Capture Event 
				INSERT INTO EVENT
				(          
					PolicyHolderPremisesID, 
					EventDateTime,
					Description,
					IsComplete,
					PHContactPerson,
					PolicyHolderRefNo,
					DateCompleted,
					EventCategoryID,
					EventCauseID,
					DateCaptured,
					CatastropheID,
					HoldingKey,
					ClaimSequenceNumber,
					LastChangeUserID,
					tmp_AccidentNumber,
					tmp_ClientCode,
					tmp_InjuredPersonNumber,
					AssurerRefNo,
					CouldEventBeAvoided,
					IsActive)
				VALUES(
					@PolicyHolderPremisesID, 
					convert(smalldatetime,@EmployeeDateOfAccident, 103), 
					@EmployeeInjuryDescription, 
					0, 
					'',  
					@MemberNo, 
					GETDATE(), 
					1, 
					0, 
					getdate(), 
					0, 
					NULL,  
					@ClaimsSequenceNo, 
					0, 
					NULL, 
					NULL, 
					NULL, 
					NULL, 
					NULL, 
					1)

				SET @EventID  =  IDENT_CURRENT('EVENT')

				INSERT INTO Accident(
					EventID,
					LocationCategoryID,
					LocationTypeID,
					AccidentTypeID,
					DeadCount,
					InjuredCount,
					AccidentDepth,
					SectionCode,
					tmp_AccidentNumber,
					tmp_ClientCode,
					TotalNoPeopleInvolved
				)
				VALUES
				(
					@EventID,
					0,
					0,
					0,
					NULL,
					1,
					NULL,
					NULL,
					NULL,
					NULL,
					1
				)

				-- Claim Type = 15 - IOD(Injury On Duty)
				INSERT INTO PERSONEVENT(          
					EventID,
					PersonID,
					EventActionID,
					EventAgentID,
					EventActivityID,
					MemberEventRefNo,
					Description,
					StabilisedDate,
					IsFatality,
					IsInjury,
					IsDeathDueToEvent,
					IsRedFlagCase,
					HoldingKey,
					PersonEmploymentID,
					LastChangeUserID,
					IsActive,
					tmp_ClaimNumber,
					tmp_AccidentNumber,
					tmp_InjuredPersonNumber,
					PEVFileRefNumber,
					IsSubmittedByMember,
					PEVSequenceNumber,
					DateReceived,
					DateSubmitted,
					DateCaptured,
					DateCMPCaptured,
					DateAssurerNotified,
					DateCMPAdvised,
					IsChangedEmploymentStatus,
					PersonEventBucketClassID,
					AdviseMethodID,
					ClaimTypeID)
				VALUES(
					@EventID, 
					@PersonID, 
					0, 
					0, 
					0, 
					@MemberNo, 
					@EmployeeInjuryDescription, 
					NULL, 
					0, 
					1, 
					0, 
					0, 
					NULL, 
					@PersonEmploymentID, 
					0, 
					1, 
					NULL, 
					NULL, 
					NULL,
					NULL,
					0, 
					1, 
					NULL, 
					GETDATE(), 
					GETDATE(), 
					NULL, 
					NULL, 
					NULL, 
					0, 
					0, 
					0, 
					15
					)
				SET @PersonEventID  =  IDENT_CURRENT('PERSONEVENT')		
				SET @EmployeeDateOfAccident = ''
				PRINT 'Person Event ID - ' + CAST(@PersonEventID AS VARCHAR(50))

				INSERT INTO PersonEventAccidentDetails(
					PersonEventID,
					IsOccurAtNormalWorkplace,
					IsRoadAccident,
					IsOnBusinessTravel,
					IsOnTrainingTravel,
					IsTravelToFromWork,
					IsOnCallout,
					IsOnStandby,
					IsPublicRoad,
					IsPrivateRoad,
					EmployeeVehicleMake,
					EmployeeVehicleRegNo,
					OtherPartyVehicleMake,
					OtherPartyVehicleRegNo,
					PoliceReferenceNo,
					PoliceStationName,
					IsAssault
				)
				VALUES
				(	
					@PersonEventID,
					1,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					NULL,
					NULL,
					NULL,
					NULL,
					NULL,
					NULL,
					0					
				)

				INSERT INTO MedicalReport
				(
					PersonEventID,
					ReportDate,
					MedicalReportTypeID,
					FirstConsultationDate,
					IsStabilised,
					StabilisedDate,
					NotStabilisedReason,
					ClinicalDescription,
					IsInjuryConsistent,
					IsContributingCauses,
					ContributingDescription,
					IsPreExistingDefect,
					PreExistingDescription,
					IsUnfitForWork,
					IsUnfitForWorkAuth,
					FirstDayOff,
					EstimatedDaysOff,
					LastDayOff,
					ReferralHistory,
					RadiologicalExaminations,
					OperationsProcedures,
					PhysiotherapyDetails,
					IsRefusedCompensation,
					DetailedImpairmentEval,
					MedicalServiceProviderID,
					LastChangeUserID,
					tmp_ClaimID,
					tmp_MedicalReportNumber,
					tmp_InjuredPersonNumber,
					PatientNumber,
					DateAssurerNotified,
					MedicalReportCategoryID,
					MedicalReportCategoryXML,
					IsActive
				)
				VALUES
				(
					@PersonEventID,
					@ClaimApprovalRDate,
					3,
					NULL,
					1,
					@ClaimApprovalRDate,
					NULL,
					@EmployeeInjuryDescription,
					0,
					0,
					0,
					0,
					NULL,
					0,
					0,
					NULL,
					0,
					NULL,
					NULL,
					NULL,
					NULL,
					NULL,
					0,
					NULL,
					0,
					0,
					NULL,
					NULL,
					NULL,
					NULL,
					NULL,
					0,
					NULL,
					1
				)
				
				SET @MedicalReportID = IDENT_CURRENT('MedicalReport')

				INSERT INTO Claim
				(
					PersonEventID,
					FileRefNumber,
					ClaimSequenceNumber,
					PolicyID,
					PolicyHolderID,
					PolicySOIID,
					ClaimTypeID,
					ClaimStatusID,
					ClaimMacroStatusID,
					LiabilityStatusID,
					ClaimClosedReasonID,
					DisabilityExtent,
					DateCaptured,
					UnderwritingYear,
					IsLiabilityDecision,
					IsNilNilClaim,
					IsPossibleSection56,
					IsPossibleSection91,
					IsPossible3rdParty,
					ResponsibleUserID,
					OldClaimNumber,
					WCCClaimNumber,
					LastChangeUserID,
					IsActive,
					ArchiveDate,
					tmp_ClaimNumber,
					tmp_AccidentNumber,
					tmp_IsAUG,
					ClaimBucketClassID,
					DateAssurerSettled
				)  
				VALUES 
				(
					@PersonEventID, 
					@ClaimNumber,
					@ClaimsSequenceNo, 
					@PolicyID, 
					@PolicyHolderID, 
					@PolicySOIID, 
					15, 
					5	, 
					0, 
					1, 
					0, 
					0, 
					NULL,
					NULL, 
					0, 
					0, 
					0, 
					0, 
					0, 
					0, 
					NULL, 
					NULL,
					0,
					1,
					NULL, 
					NULL, 
					NULL, 
					NULL, 
					0, 
					NULL
				)

				SET @ClaimID  = IDENT_CURRENT('Claim')

				INSERT INTO HearingAssessment(
					PersonID,
					AssessmentDate,
					AssessedByUserID,
					AssessedByName,
					Description,
					HearingAssessmentTypeID,
					PolicyHolderID,
					SundryServiceProviderID,
					PercentageHL,
					AwardedPHL,
					IsUsed,
					CalcOperands,
					LastChangeUserID,
					IsActive,
					AudioGramNumber) 
				VALUES
				(
					@PersonID,
					@ClaimApprovalRDate,
					0,
					null,
					null,
					4,
					@PolicyHolderID,
					0,
					'.00',
					'.00',
					0,
					null,
					0,
					0,
					null					
				)
				SET @HearingAssessmentID = IDENT_CURRENT('HearingAssessment')
				
				INSERT INTO MedicalAssessment
				(
					ClaimID,
					AssessedPD,
					MedicalReportID,
					FinalDiagnosis,
					AssessedByName,
					AssessedByUser,
					AssessmentDate,
					IsActive,
					IsAuthorised,
					AuthorisedUserID,
					LastChangeUserID,
					tmp_ClaimNumber,      
					tmp_ClaimXactionNumber,
					RawPD,
					HearingAssessmentID
				)
				VALUES
				(
					@ClaimID,
					'.00',
					@MedicalReportID,
					NULL,
					'',
					'',
					@ClaimApprovalRDate,
					1 	,
					1,
					0,
					0,
					NULL,
					NULL,
					@EmployeePDPerc,
					@HearingAssessmentID
				)

				SET @MedicalAssessmentID =  IDENT_CURRENT('MedicalAssessment')

				INSERT INTO physicaldamage(
					PersonEventID,
					Description,
					TotalExtent,
					DateOfDeath,
					DateStabilised,
					LastChangeUserID,
					HoldingKey,
					IsActive,
					tmp_ClaimNumber,
					tmp_AccidentNumber,
					ICD10DiagnosticGroupID
					) 
				VALUES
				(
					@PersonEventID,
					@EmployeeInjuryDescription,
					'.00',
					NULL,
					NULL,
					0,
					NULL,
					1,
					NULL,
					NULL,
					26
				)
				SET @PhysicalDamageID =   IDENT_CURRENT('physicaldamage')					

				INSERT INTO INJURY(
					PhysicalDamageID,
					Description,
					ICD10CodeID,
					InjurySeverityID,
					BodySideID,
					InjuryStatusID,
					IsActive,
					DateCaptured,
					CapturedUserID,
					LastChangeUserID,
					tmp_ClaimNumber,
					InjuryRank,
					PersonInjuryRank
				)
				Values
				(
					@PhysicalDamageID,
					@EmployeeInjuryDescription,
					0,
					0,
					0,
					0,
					1,
					GETDATE(),
					0,
					0,
					NULL,
					1,
					1				
				)
				SET @InjuryID =  IDENT_CURRENT('INJURY')				
			
			SET @LastErrorNo = 0
			--- Load the employees PD Details\
			PRINT 'Calling CompCare_Employee_PDClaims_Load Procedure Start. . . '
			EXEC CompCare_Employee_PDClaims_Load @MemberNo, @PolicyHolderID, @PolicyHolderPremisesID , @PolicyID,  @PolicySOIID, @ClaimID, @MedicalAssessmentID, @PersonID, @PersonEventID, @ClaimNumber, @EventID, @ClaimApprovalRDate, @LastErrorNo
			PRINT 'Calling CompCare_Employee_PDClaims_Load Procedure Complete. . . '
			
			IF (@LastErrorNo > 0)
			BEGIN
				PRINT 'Error While Loading Employee PD Lump Details' + CAST(@LastErrorNo as VARCHAR(50))
				GOTO ERROR
			END

			IF (@@ERROR = 0)				
			BEGIN
				SET @LastErrorNo = 0
				PRINT 'Person/Employee Details Loaded Successfully'
				INSERT INTO CONVERTED_EMPLOYEES
				(
					POLICYHOLDERID,
					EMPLOYERPREMISESID,
					EMPLOYERMEMBERNO,
					EMPLOYEENAME,
					EMPLOYEENO,
					EMPLOYEEINJURY,
					EMPLOYEE_LOADED
				)
				VALUES
				(
					@PolicyHolderID,
					@PolicyHolderPremisesID,
					@MemberNo,
					@EmployeeName,
					@EmployeeNo,
					@EmployeeInjuryDescription, 
					'Y'
				)
			END
			ELSE
			BEGIN
				SET @LastErrorNo = 1
				PRINT 'Person/Employee Details COULD NOT Load Successfully. Error - ' + CAST(@@ERROR AS VARCHAR(2000)) 
				INSERT INTO  CONVERTED_EMPLOYEES
				(
					POLICYHOLDERID,
					EMPLOYERPREMISESID,
					EMPLOYERMEMBERNO,
					EMPLOYEENAME,
					EMPLOYEENO,
					EMPLOYEEINJURY,
					EMPLOYEE_LOADED
				)
				VALUES
				(
					@PolicyHolderID,
					@PolicyHolderPremisesID,
					@MemberNo,
					@EmployeeName,
					@EmployeeNo,
					@EmployeeInjuryDescription, 
					'N'
				)
				CLOSE PH_Employees_Events_Cursor
				DEALLOCATE PH_Employees_Events_Cursor
				BREAK	--Exit the while loop of the cursor
			END	
			SET @EmployeesCount = @EmployeesCount + 1
			COMMIT TRANSACTION

			FETCH NEXT FROM PH_Employees_Events_Cursor
			INTO @ClaimNumber,
			@EmployeeName,
			@EmployeeIDNo,
			@EmployeePDPerc,
			@EmployeeDateOfBirth ,
			@EmployeeDateOfAccident, 
			@EmployeeInjuryDescription,
			@EmployerRegNo,
			@ClaimApprovalDate,
			@Remarks,
			@ClaimStatus,
			@ThirdPartyClaim,
			@EmployeeNo,
			@ClaimOffDuty, 
			@EmployerSubClass,
			@ClaimLabourCentre,
			@ClaimProvince,
			@EmployeeAddress1, 
			@EmployeeAddress2, 
			@EmployeeAddress3, 
			@EmployeeAddress4, 
			@EmployeePostalCode 
		END

		CLOSE PH_Employees_Events_Cursor
		DEALLOCATE PH_Employees_Events_Cursor
		PRINT 'All employees linked to this employer registration-no loaded.'
		PRINT 'Number of Employees ' + CAST(@EmployeesCount AS VARCHAR(30))

ERROR:
IF(@@trancount != 0 AND @LastErrorNo > 0) 
BEGIN
	--ROLLBACK TRANSACTION
	PRINT 'PROBLEM ENCOUNTERED - '
	
	CLOSE PH_Employees_Events_Cursor
	DEALLOCATE PH_Employees_Events_Cursor
	RAISERROR (@MsgFmt, 19, 1, @ThisProc, @Msg, @Error, @RowCount) with log
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_BANKING_DETAILS_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_BANKING_DETAILS_GET]     
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select * from aims_limitation ' 

	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_ASSIST_TYPE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ASSIST_TYPE](
	[ASSIST_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ASSIST_TYPE_DESC] [varchar](100) NULL,
 CONSTRAINT [PK_AIMS_ASSIST_TYPE] PRIMARY KEY CLUSTERED 
(
	[ASSIST_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX1_AIMS_ASSIST_TYPE] UNIQUE NONCLUSTERED 
(
	[ASSIST_TYPE_DESC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_ADMIN_SCRIPTS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ADMIN_SCRIPTS](
	[Script_Name] [varchar](50) NULL,
	[Owner_Name] [varchar](50) NULL,
	[Script_DTTM] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_ADDRESS_TYPE_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_ADDRESS_TYPE_GET]  
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select *  from aims_address_type order by address_type'
			
	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_ADDRESS_TYPE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ADDRESS_TYPE](
	[ADDR_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ADDRESS_TYPE] [varchar](50) NULL,
	[ADDRESS_ACTIVE_YN] [varchar](1) NULL,
 CONSTRAINT [PK_AIMS_ADDRESS_TYPE] PRIMARY KEY CLUSTERED 
(
	[ADDR_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_ACCOUNTS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ACCOUNTS](
	[ACCOUNT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ACCOUNT_TYPE] [varchar](255) NULL,
	[ACCOUNT_NOTES] [varchar](1000) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_EWS_ADMIN_MAILBOX]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_EWS_ADMIN_MAILBOX](
	[OPERATOR_MAILBOX_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[OPERATOR_MAILBOX_USER_NAME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AIMS_EWS_ADMIN_MAILBOX] PRIMARY KEY CLUSTERED 
(
	[OPERATOR_MAILBOX_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_EVACUATION_TYPES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EVACUATION_TYPES](
	[EVACUATION_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[EVACUATION_TYPE_DESC] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AIMS_EVACUATION_TYPES] PRIMARY KEY CLUSTERED 
(
	[EVACUATION_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AIMS_EVACUATION_TYPES] UNIQUE NONCLUSTERED 
(
	[EVACUATION_TYPE_DESC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_EWS_DOCUMENT_TYPE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_DOCUMENT_TYPE](
	[DOC_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[DOC_TYPE] [varchar](50) NOT NULL,
	[mailbox_name] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_EWS_DOCUMENT_TYPE] PRIMARY KEY CLUSTERED 
(
	[DOC_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_EWS_DOCUMENT_TYPE] ON [dbo].[AIMS_EWS_DOCUMENT_TYPE] 
(
	[DOC_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_EMBASSIES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_EMBASSIES](
	[EMBASSY_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMBASSY_NAME] [varchar](255) NOT NULL,
	[EMBASSY_TEL_NO] [varchar](50) NULL,
	[EMBASSY_FAX_NO] [varchar](50) NULL,
	[EMBASSY_ADDRESS_ID] [numeric](18, 0) NULL,
	[EMBASSY_CONTACT_PERSON] [varchar](255) NULL,
	[EMBASSY_ACTIVE_YN] [varchar](1) NULL,
	[CREATION_DTTM] [datetime] NULL,
 CONSTRAINT [PK_AIMS_EMBASSIES] PRIMARY KEY CLUSTERED 
(
	[EMBASSY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_COUNTRY]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_COUNTRY](
	[COUNTRY_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[COUNTRY_NAME] [varchar](100) NULL,
 CONSTRAINT [PK_AIMS_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[COUNTRY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX1_AIMS_COUNTRY] ON [dbo].[AIMS_COUNTRY] 
(
	[COUNTRY_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_COUNTRIES_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_COUNTRIES_GET]    
as   
 declare @vSQL  nvarchar(500)  
   
 set @vSQL = 'select distinct *  from aims_country as ap order by country_name asc'   
  
 EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_COMPANIES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_COMPANIES](
	[COMPANY_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[COMPANY_NAME] [varchar](255) NULL,
 CONSTRAINT [PK_AIMS_COMPANIES] PRIMARY KEY CLUSTERED 
(
	[COMPANY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_DOCTOROWING_LEDGER]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_DOCTOROWING_LEDGER]        
@Forex varchar(1),     
@OverPymt varchar(1),  
@ShortPymt varchar(1),
@DoctorOwing varchar(1)        
as       
 declare @vSQL nvarchar(4000)  

  
         
 set @vSQL  = ' select distinct ' +      
   ' e.title_desc +'' '' +  dbo.initcap(patient_first_name) + '' '' + dbo.initcap(patient_last_name) patient_name, ' +      
   ' guarantor_ref_no, guarantor_name ,a.patient_file_no, dbo.initcap(a.patient_first_name) patient_first_name , dbo.initcap(a.patient_last_name) patient_last_name, ' +  
   ' a.patient_discharge_date, ' +  
   ' ISNULL((Select SUM(CAST(aims_payment.amount_paid AS money)) Amount_Paid_To_Date FROM AIMS_PAYMENT , AIMS_PATIENT WHERE AIMS_PATIENT.patient_id = a.patient_id and aims_payment.patient_id = AIMS_PATIENT.patient_id and ((aims_payment.doctor_owing = ''' + @DoctorOwing +''') AND (aims_payment.forex_payment = ''' + @Forex +''') AND (aims_payment.insurance_overpymt = '''+ @OverPymt +''') AND (aims_payment.insurance_shortpymt = '''+ @ShortPymt +'''))),0) Amount_Paid_To_Date' +  
   ' ,forex_payment, ' +  
   ' insurance_overpymt, ' +  
   ' insurance_shortpymt ' +   
   ' from aims_patient a   ' +      
   ' left outer join aims_invoice b on a.patient_id = b.patient_id ' +      
   ' left outer join aims_payment c on a.patient_id = c.patient_id ' +      
   ' left outer join aims_guarantor d on a.guarantor_id = d.guarantor_id ' +      
   ' left outer join aims_title e on a.title_id = e.title_id where '       
   set @vSQL  =  @vSQL  + ' (b.cancelled_yn = ''N'' or b.cancelled_yn IS NULL) and (a.CANCELLED = ''N'' or a.cancelled is null) and '  
   SET @vSQL  =  @vSQL  + ' ((aims_payment.doctor_owing = ''' + @DoctorOwing +''') AND (c.forex_payment = '''+ @Forex +''') and (c.insurance_overpymt = '''+ @OverPymt +''') and (c.insurance_shortpymt = '''+ @ShortPymt +'''))'  
   set @vSQL  =  @vSQL  + ' GROUP BY  e.title_desc, a.patient_last_name, guarantor_ref_no, guarantor_name, a.patient_file_no, patient_first_name, patient_last_name ,patient_discharge_date, a.patient_id, doctor_owing, forex_payment, insurance_overpymt, insurance_shortpymt'  
   set @vSQL  =  @vSQL  + '  order by guarantor_name '           
      
   EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_DEPARTMENT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_DEPARTMENT](
	[DEPARTMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[DEPARTMENT_NAME] [varchar](50) NULL,
	[DEPARTMENT_SUPERVISOR_USER_NAME] [varchar](50) NULL,
	[DEPARTMENT_MANAGER_USER_NAME] [varchar](50) NULL,
	[DEPARTMENT_EMAIL_ADDRESS] [varchar](150) NULL,
 CONSTRAINT [PK_AIMS_DEPARTMENT] PRIMARY KEY CLUSTERED 
(
	[DEPARTMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_DEPARTMENT] ON [dbo].[AIMS_DEPARTMENT] 
(
	[DEPARTMENT_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_DELIVERY_METHOD]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_DELIVERY_METHOD](
	[DELIVERY_METHOD_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[DELIVERY_METHOD] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AIMS_DELIVERY_METHOD] PRIMARY KEY CLUSTERED 
(
	[DELIVERY_METHOD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_DEBUGGING]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_DEBUGGING](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[DEBUG_MSG] [varchar](5000) NULL,
	[DEBUG_VALUE] [varchar](5000) NULL,
	[DEBUG_DTTM] [datetime] NULL,
 CONSTRAINT [PK_AIMS_DEBUGGING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_DB_BACKUP]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_DB_BACKUP]
as
begin
declare @BackupName varchar(50)
set @BackupName = 'D:\DATA\AIMS_DB_'+replace(GETDATE() ,':','')+'.Bak'
BACKUP DATABASE AIMS
TO DISK = @BackupName
   WITH FORMAT,
      MEDIANAME = 'AIMS_DATABASE',
      NAME = 'Full Backup of AIMS_DB';
end
GO
/****** Object:  Table [dbo].[AIMS_CURRENCY]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_CURRENCY](
	[COUNTRY_NAME] [varchar](100) NOT NULL,
	[CURRENCY] [varchar](100) NULL,
	[CODE] [varchar](10) NULL,
	[NUMBER] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_EWS_PRIORITY]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_PRIORITY](
	[PRIORITY_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PRIORITY_DESC] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AIMS_EWS_PRIORITY] PRIMARY KEY CLUSTERED 
(
	[PRIORITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_ALL_ACTIVE_USERS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AIMS_GET_ALL_ACTIVE_USERS]    
as   
 declare @vSQL  nvarchar(500)  
   
 set @vSQL = 'select * from AIMS_USERS where User_Active_YN = ''Y'' ORDER BY USER_FULL_NAME'  
  
 EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_EWS_MAILBOXES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_MAILBOXES](
	[MAILBOX_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MAILBOX_NAME] [varchar](50) NULL,
	[MAILBOX_AD_DOMAIN] [varchar](50) NULL,
	[MAILBOX_EXCHANGE_USER] [varchar](50) NULL,
	[MAILBOX_EXCHANGE_PASSWORD] [varchar](50) NULL,
	[MAILBOX_EWS_URL] [varchar](2000) NULL,
	[MAILBOX_ITEMS_PICK] [int] NULL,
	[MAILBOX_ACTIVE_YN] [varchar](1) NULL,
	[MAILBOX_PROCESSING_SEQ] [int] NULL,
	[MAILBOX_EMAILS_STORE_FOLDER] [varchar](500) NULL,
	[MAILBOX_ARCHIVE_FOLDER_NAME] [varchar](200) NULL,
	[MAILBOX_POD_DISK_LETTER] [varchar](50) NULL,
	[MAILBOX_POD_COUNTER] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_EWS_MAILBOXES] PRIMARY KEY CLUSTERED 
(
	[MAILBOX_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_EWS_MAILBOXES] ON [dbo].[AIMS_EWS_MAILBOXES] 
(
	[MAILBOX_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_EWS_EMAIL_SENDER]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_EMAIL_SENDER](
	[EMAIL_FROM_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[EMAIL_FROM_NAME] [varchar](50) NOT NULL,
	[EMAIL_FROM_ADDRESS] [varchar](50) NOT NULL,
	[ROLES] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_EWS_EMAIL_SENDER] PRIMARY KEY CLUSTERED 
(
	[EMAIL_FROM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_TYPES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_TYPES](
	[ATTACHMENT_FILE_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ATTACHMENT_FILE_TYPE] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AIMS_EWS_EMAIL_ATTACHMENT_TYPES] PRIMARY KEY CLUSTERED 
(
	[ATTACHMENT_FILE_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_JOURNAL]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_JOURNAL](
	[JOURNAL_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_NO] [varchar](255) NULL,
	[SUPPLIER_ID] [numeric](18, 0) NULL,
	[INVOICE_ID] [numeric](18, 0) NULL,
	[GUARANTOR_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_JOURNAL] PRIMARY KEY CLUSTERED 
(
	[JOURNAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_JOB_TITLE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_JOB_TITLE](
	[JOB_TITLE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[JOB_TITLE_DESC] [varchar](150) NULL,
 CONSTRAINT [PK_AIMS_JOB_TITLE] PRIMARY KEY CLUSTERED 
(
	[JOB_TITLE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_JOB_TITLE] ON [dbo].[AIMS_JOB_TITLE] 
(
	[JOB_TITLE_DESC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOIVE_GET_ALL]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*-- GET ALL INVOICES -- */

CREATE PROCEDURE [dbo].[AIMS_INVOIVE_GET_ALL]  
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select 	  ' +
		 ' invoice_id,      ' +
		 '  ap.patient_file_no,     ' +
		  ' asp.supplier_name,     ' +
		  ' aps.service_description,     ' +
		  ' ai.date_admitted,     ' +
		  ' ai.date_discharged,     ' +
		  ' ai.invoice_no,     ' +
		  ' ai.invoice_date ,     ' +
		  ' ai.INVOICE_AMOUNT_RECEIVED    ' +
	 ' from     ' +
	 ' aims_invoice as ai     ' +
	 ' left outer join aims_patient 		as ap 	on ap.patient_id 		= ai.patient_id    ' +
	 ' left outer join aims_medical_treatment 	as amt	on amt.medical_treatment_id 	= ai.medical_treatment_id	     ' +
	 ' left outer join aims_supplier		as asp	on asp.supplier_id		= amt.supplier_id   ' +
	 ' left outer join aims_prof_service	as aps	on aps.service_id 		= amt.service_id  '


	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GUARANTOR_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*  Get Patient (Details, Address, Guarantor, Company)*/
CREATE PROCEDURE [dbo].[AIMS_GUARANTOR_GET]  
    @GuarantorID int
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select * ' +
	 		' from aims_guarantor as ag ' +
			' left outer join aims_address 	as aa on ag.address_id 	= aa.address_id ' +
			' where ' +
			' (ag.guarantor_id  = ' + cast(@GuarantorID as varchar(50)) + ') '

	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_MEDICAL_REPORT_TYPES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_MEDICAL_REPORT_TYPES](
	[MEDICAL_REPORT_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MEDICAL_REPORT_TYPE_DESC] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_MEAL_TYPE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_MEAL_TYPE](
	[MEAL_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[MAIL_TYPE] [varchar](50) NULL,
	[MEAL_TYPE_DESC] [varchar](250) NULL,
 CONSTRAINT [PK_AIMS_MEAL_TYPE] PRIMARY KEY CLUSTERED 
(
	[MEAL_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_LOGIN_HISTORY]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_LOGIN_HISTORY](
	[LOGIN_HISTORY_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[USER_NAME] [varchar](50) NULL,
	[DATE_TIME] [datetime] NULL,
 CONSTRAINT [PK_AIMS_LOGIN_HISTORY] PRIMARY KEY CLUSTERED 
(
	[LOGIN_HISTORY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_LIMITATION]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_LIMITATION](
	[LIMITATION_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[LIMITATION_CD] [varchar](50) NULL,
	[LIMITATION_DESCR] [varchar](255) NULL,
	[LIMITATION_VALUE] [varchar](1000) NULL,
 CONSTRAINT [PK_AIMS_LIMITATION] PRIMARY KEY CLUSTERED 
(
	[LIMITATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_LIMITATION] ON [dbo].[AIMS_LIMITATION] 
(
	[LIMITATION_CD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_RMR_TYPES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_RMR_TYPES](
	[RMR_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[RMR_TYPE_DESC] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AIMS_RMR_TYPES] PRIMARY KEY CLUSTERED 
(
	[RMR_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AIMS_RMRTYPES] UNIQUE NONCLUSTERED 
(
	[RMR_TYPE_DESC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_RESTRICTIONS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_RESTRICTIONS](
	[RESTRICTION_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[RESTRICTION_DESC] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_RESTRICTIONS] PRIMARY KEY CLUSTERED 
(
	[RESTRICTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_RESTRICTIONS] ON [dbo].[AIMS_RESTRICTIONS] 
(
	[RESTRICTION_DESC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_ROOM_TYPES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ROOM_TYPES](
	[ROOM_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ROOM_TYPE_CD] [varchar](50) NULL,
	[ROOM_TYPE_DESC] [varchar](250) NULL,
 CONSTRAINT [PK_AIMS_ROOM_TYPES] PRIMARY KEY CLUSTERED 
(
	[ROOM_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_ROLES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ROLES](
	[ROLE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ROLE_CD] [varchar](50) NOT NULL,
	[ROLE_CD_ACTIVE_YN] [varchar](1) NULL,
 CONSTRAINT [PK_AIMS_ROLES] PRIMARY KEY CLUSTERED 
(
	[ROLE_CD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_REPORTS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_REPORTS](
	[REPORT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[REPORT_NAME] [varchar](50) NOT NULL,
	[REPORT_DESC] [varchar](255) NOT NULL,
	[REPORT_PROC_TYPE] [varchar](20) NULL,
	[REPORT_PROC_NAME] [varchar](50) NOT NULL,
	[REPORT_LAST_RUN_DTTM] [datetime] NOT NULL,
	[REPORT_FIELDS_DEFINITION] [varchar](4000) NULL,
	[REPORT_EXEC_SEQ] [numeric](18, 0) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_REPAT_TYPE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_REPAT_TYPE](
	[REPAT_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[REPAT_TYPE_DESC] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_REPAT_TYPE] PRIMARY KEY CLUSTERED 
(
	[REPAT_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AIMS_REPAT_TYPE] UNIQUE NONCLUSTERED 
(
	[REPAT_TYPE_DESC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_RELATIONS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_RELATIONS](
	[RELATION_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[RELATION_DESC] [varchar](100) NULL,
 CONSTRAINT [PK_AIMS_RELATIONS] PRIMARY KEY CLUSTERED 
(
	[RELATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_PROF_SERVICE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_PROF_SERVICE](
	[SERVICE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[SERVICE_DESCRIPTION] [varchar](255) NULL,
	[SERVIVE_NOTES] [varchar](1000) NULL,
 CONSTRAINT [PK_AIMS_SERVICE] PRIMARY KEY CLUSTERED 
(
	[SERVICE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_PRIORITY]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_PRIORITY](
	[PRIORITY_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PRIORITY] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_PRIORITY] PRIMARY KEY CLUSTERED 
(
	[PRIORITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_PATIENT_SERVICE_PROVIDERS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_PATIENT_SERVICE_PROVIDERS](
	[SERVICE_PROVIDER_ID] [int] IDENTITY(1,1) NOT NULL,
	[PATIENT_ID] [int] NULL,
	[SUPPLIER_TYPE_ID] [int] NULL,
	[SERVICE_PROVIDER_NAME] [varchar](500) NULL,
	[SERVICE_PROVIDER_PHONE] [varchar](500) NULL,
	[SERVICE_PROVIDER_FAX_NO] [varchar](500) NULL,
	[SERVICE_PROVIDER_EMAIL] [varchar](500) NULL,
	[USER_NAME] [varchar](50) NULL,
	[ADMIN_NAME] [varchar](255) NULL,
	[ADMIN_TEL_PHONE] [varchar](255) NULL,
	[ADMIN_FAX_NO] [varchar](255) NULL,
	[ADMIN_EMAIL] [varchar](255) NULL,
 CONSTRAINT [PK_AIMS_PATIENT_SERVICE_PROVIDERS] PRIMARY KEY CLUSTERED 
(
	[SERVICE_PROVIDER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_INVOICE_GET]  
    @PatientID int,
    @InvoiceID int
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select * ' +
	 		' from aims_guarantor as ag ' +
			' left outer join aims_address 	as aa on ag.address_id 	= aa.address_id ' +
			' where ' +
			' (ag.guarantor_id  = ' + cast(@PatientID as varchar(50)) + ') '

	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_NON_WORKING_DAYS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_NON_WORKING_DAYS](
	[NWD_ID] [numeric](18, 0) NULL,
	[NWD_DESC] [varchar](50) NULL,
	[NWD_DATE] [date] NULL,
	[NWD_TYPE] [varchar](50) NULL,
	[MODIFIED_DTTM] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_NOTE_TYPES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_NOTE_TYPES](
	[NOTE_TYPE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[NOTE_TYPE_CD] [varchar](50) NULL,
	[NOTE_TYPE_DESC] [varchar](255) NULL,
 CONSTRAINT [PK_AIMS_NOTE_TYPES] PRIMARY KEY CLUSTERED 
(
	[NOTE_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_NOTE_TYPE_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_NOTE_TYPE_GET]      
AS     
 declare @vSQL  nvarchar(500)    
     
 set @vSQL = 'SELECT * from AIMS_NOTE_TYPES order by Note_Type_Desc'    
       
 EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GUARANTOR_ADDRESS_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_GUARANTOR_ADDRESS_GET]  
    @PatientFileNo varchar(50)
as 
declare @vSQL nvarchar(4000)
set @vSQL = 'select * from aims_patient  ' +
	' left outer join aims_guarantor on aims_guarantor.guarantor_id  = aims_patient.guarantor_id ' +
	' left outer join aims_address on aims_address.address_id  = aims_guarantor.address_id ' +
	' left outer join aims_country on aims_country.country_id = aims_address.country_id ' +
	' where  aims_patient.patient_file_no = '+  '''' + CONVERT(varchar(255), @PatientFileNo) + ''''
	print @vSQL
	EXECUTE  sp_executesql  @vSQL
	
	/*select * from aims_patient 
	left outer join aims_guarantor on aims_guarantor.guarantor_id  = aims_patient.guarantor_id
	left outer join aims_address on aims_address.address_id  = aims_guarantor.address_id
	left outer join aims_country on aims_country.country_id = aims_address.country_id
	where  aims_patient.patient_file_no =  CAST(@PatientFileNo AS VARCHAR(50)) */
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GET_ALL]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/*  Return Values of the procedure 	*/
------------------------------------------
/*  Get Patient (Details, Address, Guarantor, Company)*/
CREATE PROCEDURE [dbo].[AIMS_PATIENT_GET_ALL]  
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'select * ' +
	 		' from aims_patient as ap ' +
			' left outer join aims_companies 	as ac 	on ap.company_id 	= ac.company_id ' +
			' left outer join aims_address 	as aa	on ap.address_id 	= aa.address_id ' +
			' left outer join aims_guarantor  	as ag	on ap.guarantor_id 	= ag.guarantor_id ' +
			' left outer join aims_title  	 	as atl	on ap.title_id 		= atl.title_id   order by ap.patient_last_name'

	EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_PAYMENTS_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_PAYMENTS_GET]              
    @PatientFileNo varchar(50),          
    @LateSubmissionPymt varchar(1),        
    @DoctorOwing  varchar(1),      
    @InvoiceID varchar(50)       
as             
          
 declare @vSQL  nvarchar(4000)             
 SET @vSQL = ' SELECT *  ' +          
    ' FROM aims_patient apt, aims_payment app  ' +          
    ' WHERE apt.patient_file_no = '''+ @PatientFileNo  + ''' AND app.patient_id = apt.patient_id '          
        
	IF @LateSubmissionPymt = 'Y'           
	BEGIN          
		SET @vSQL = @vSQL + ' AND app.late_submission_pymt = ''Y'' '
		SET @vSQL = @vSQL + ' AND app.invoice_id = ' + @InvoiceID		
	END          
	ELSE          
	BEGIN          
		SET @vSQL = @vSQL + ' AND app.late_submission_pymt = ''N'' '          
	END         
	IF @DoctorOwing = 'Y'         
	BEGIN        
		SET @vSQL = @vSQL + ' AND app.doctor_owing = ''Y'' '          
		SET @vSQL = @vSQL + ' AND app.invoice_id = ' + @InvoiceID
	END        
	ELSE        
	BEGIN
		SET @vSQL = @vSQL + ' AND app.doctor_owing = ''N'' '          
	END        
	insert into AIMS_DEBUGGING  values('[AIMS_PATIENT_PAYMENTS_GET] - Loading Payments for Consolidation',@vSQL, GETDATE())          
 EXECUTE  sp_executesql @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_INVOICES_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_INVOICES_GET]                        
 @PatientFileNo varchar(50) = '',                      
 @IncludeLateSubmission varchar(1) = '',              
 @DoctorOwing varchar(1) = '',        
 @ShowSentLateInvoices varchar(1) = ''         
as                       
 declare @vSQL  nvarchar(4000)                      
                       
 set @vSQL = 'select   DISTINCT ' +                      
    ' ai.invoice_id,     ' +                      
    ' ap.patient_file_no,    ' +                      
 'CASE asp.doctor_supplier_yn ' +          
    '      WHEN ''N''' +          
 ' THEN asp.supplier_name  WHEN ''Y''' +          
 ' THEN ''Dr '' + asp.doctor_name_initials + '' '' + asp.doctor_surname ' +          
 ' WHEN NULL THEN asp.doctor_surname ' +          
 'END  SUPPLIER_NAME  , ' +          
    ' aps.supplier_type_desc service_description,  ' +                        
    ' ai.invoice_no,    ' +                      
    ' ai.invoice_date ,    ' +                      
    ' ai.INVOICE_AMOUNT_RECEIVED, ' +                      
    ' ai.LATE_INVOICE_YN, ' +                      
    ' ai.locked_yn,  ' +                      
    ' ai.Generated_yn, ' +                      
    ' aimt.MEDICAL_TREATMENT_ID, ' +                      
    ' ai.creation_dttm, ' +                          
    ' ai.late_invoice_sent, ' +      
    ' ai.late_invoice_sent_DATE, ' +      
    ' ai.INVOICE_SENT_WAYBILL_NO ' +  
   ' from  ' +                      
   ' aims_invoice as ai ' +                         
   ' left outer join aims_patient as ap  on ap.patient_id = ai.patient_id  ' +                      
   ' left outer join AIMS_INVOICE_MEDICAL_TREATMENTS as aimt on aimt.invoice_id = ai.invoice_id  ' +                      
   ' left outer join aims_medical_treatment as amt on amt.medical_treatment_id  = aimt.medical_treatment_id ' +                      
   ' left outer join aims_supplier as asp on asp.supplier_id = amt.supplier_id ' +                      
   ' left outer join aims_supplier_types as aps on aps.supplier_type_id = aimt.service_id ' +                      
   ' where   ap.patient_file_no =  ''' + cast(@PatientFileNo  as varchar(50)) + ''' and (ai.cancelled_yn = ''N'' or ai.cancelled_yn IS NULL)'                      
                       
 if @IncludeLateSubmission = 'Y'                      
 begin                      
  set @vSQL = @vSQL  + '  and (ai.LATE_INVOICE_YN  = ''Y'')'              
  if @ShowSentLateInvoices is NOT Null or @ShowSentLateInvoices != ''        
  BEGIN        
 set @vSQL = @vSQL  + '  and (ai.LATE_INVOICE_SENT  = '''+ @ShowSentLateInvoices +''')'              
  END        
        
 end                      
 else                      
 begin                      
  if @IncludeLateSubmission = 'N'                      
  begin                      
   set @vSQL = @vSQL  + '  and (ai.LATE_INVOICE_YN  = ''N'')'                      
  end                        
 end                
 IF @DoctorOwing = 'Y'              
 BEGIN              
 set @vSQL = @vSQL  + '  and (ai.doctor_owing  = ''Y'')'                     
 END                    
 else              
 BEGIN              
 set @vSQL = @vSQL  + '  and (ai.doctor_owing  = ''N'')'                     
 END                 
   set @vSQL = @vSQL  + ' order by ai.invoice_id ASC'                
   insert into AIMS_DEBUGGING  values('[AIMS_PATIENT_INVOICES_GET] - CONSOLIDATION INVOICES',@vSQL, GETDATE())            
 
 EXECUTE  sp_executesql @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GET_NOTES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_GET_NOTES]        
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
  
  insert into aims_debugging values ('3333',@vSQL, GETDATE())
    EXECUTE  sp_executesql @vSQL  
    
    
    
    
    
    select * from AIMS_DEBUGGING
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_SERVICE_PROVIDER_DEL]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_SERVICE_PROVIDER_DEL]    
	@ServiceProviderID VARCHAR(50)
as   

delete from AIMS_PATIENT_SERVICE_PROVIDERS where service_provider_id = @ServiceProviderID
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_ANALYSIS_REPORT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_ANALYSIS_REPORT]          
@StartDate  varchar(20) = '',       
@EndDate  varchar(20) = '',       
@Guarantor  varchar(30) = '',       
@Supplier  varchar(30) = '',       
@Patient_In  varchar(30) = '',       
@Patient_Out varchar(30) = '',       
@Assist   varchar(30) = '',       
@AssistType  varchar(30) = '',       
@Transport  varchar(30) = '',       
@TransportType varchar(30) = '',       
@Repat   varchar(30) = '',       
@Flight   varchar(30) = '',       
@FileCancelled varchar(30) = '',       
@FileActive  varchar(30) = ''  
as         
 declare   
 @vSQL nvarchar(4000)   
  
 set @vSQL  = 'SELECT DISTINCT   
 a.patient_file_no,   
 a.patient_first_name,   
 a.patient_last_name,   
 b.guarantor_name,   
 a.PATIENT_DISCHARGE_DATE,   
 PATIENT_ADMISSION_DATE,   
 c.supplier_name, '  
   
 INSERT INTO AIMS_DEBUGGING  values (@vSQL , 'in here 1'  , GETDATE())  
   
 IF  @Patient_In = 'Y' OR @Patient_Out = 'Y'  
 BEGIN  
  IF @Patient_In = 'Y'  
  BEGIN  
   SET @vSQL  =  @vSQL  + ' case(IN_PATIENT) when ''Y'' THEN ''In-Patient'' WHEN NULL THEN '''' end  PATIENT_STATUS, '  
  END  
  
  INSERT INTO AIMS_DEBUGGING  values (@vSQL , 'in here 2 PATIENT STATUS SETUP'  , GETDATE())    
  IF @Patient_Out = 'Y'  
  BEGIN  
   set @vSQL  =  @vSQL  + ' case(OUT_PATIENT) when ''Y'' THEN ''Out-Patient'' WHEN NULL THEN '''' end  PATIENT_STATUS, '  
  END   
 END  
 ELSE  
 BEGIN  
  --set @vSQL  =  @vSQL  + ''''' PATIENT_STATUS, '  
  set @vSQL  =  @vSQL  + 'case (OUT_PATIENT) when ''Y'' THEN ''Out-Patient'' WHEN NULL THEN '''' ELSE ''In-Patient'' end  PATIENT_STATUS, '  
 END  
   
 insert into AIMS_DEBUGGING  values (@vSQL , 'in here 2'  , GETDATE())  
   
 IF @Transport = 'Y' OR @Assist = 'Y'   
 BEGIN  
  IF @Transport = 'Y'  
  BEGIN  
   set @vSQL  =  @vSQL  + 'case(TRANSPORT) when ''Y'' Then ''Transport''  end AIMS_SERVICE ,'  
  END  
  IF @Assist = 'Y'  
  BEGIN  
   set @vSQL  =  @vSQL  + 'case(ASSIST) when ''Y'' Then ''Assist''  end AIMS_SERVICE ,'  
  END   
 END  
 ELSE  
 BEGIN  
  set @vSQL  =  @vSQL  + ''''' AIMS_SERVICE , '    
 END  
 insert into AIMS_DEBUGGING  values (@vSQL , 'in here 3'  , GETDATE())   
 IF @TransportType <> '' OR @AssistType  <> ''  
 BEGIN  
  IF @TransportType <> ''  
  BEGIN  
   set @vSQL  =  @vSQL  + ' h.TRANSPORT_TYPE_DESC  AIMS_SERVICE_TYPE '  
  END  
    
  IF @AssistType  <> ''  
  BEGIN  
   set @vSQL  =  @vSQL  + ' g.ASSIST_TYPE_DESC  AIMS_SERVICE_TYPE '  
  END   
 END  
 ELSE  
 BEGIN  
	 --IF @Transport = 'Y' OR @Assist = 'Y'
	 --BEGIN
	 
	 --END
	 --ELSE
	 --BEGIN
		set @vSQL  =  @vSQL  + ''''' AIMS_SERVICE_TYPE '  
	 --END
  
 END  
   
 insert into AIMS_DEBUGGING  values (@vSQL , 'in here 4'  , GETDATE())   
  
    SET @vSQL  =  @vSQL  + ' FROM aims_patient a LEFT OUTER JOIN aims_guarantor b  
                ON a.guarantor_id = b.guarantor_id  
                left outer join AIMS_SUPPLIER c on a.SUPPLIER_ID = c.SUPPLIER_ID   
                left outer join AIMS_ASSIST_TYPE d on a.PATIENT_ASSIST_TYPE_ID = d.ASSIST_TYPE_ID   
                 left outer join AIMS_TRANSPORT_TYPE e on a.PATIENT_TRANSPORT_TYPE_ID = e.TRANSPORT_TYPE_ID   
                 inner join AIMS_SUPPLIER_TYPES f on c.SUPPLIER_TYPE_ID = f.SUPPLIER_TYPE_ID   
                 left outer join AIMS_ASSIST_TYPE g on a.PATIENT_ASSIST_TYPE_ID = g.assist_type_id  
                 left outer join AIMS_TRANSPORT_TYPE h on a.PATIENT_TRANSPORT_TYPE_ID = h.transport_type_id  
          WHERE a.creation_dttm BETWEEN CONVERT (datetime, '''+ @StartDate +''', 103 )  
                                    AND CONVERT (datetime, '''+ @EndDate + ''', 103 )'  
insert into AIMS_DEBUGGING  values (@vSQL , 'in here 5'  , GETDATE())    
insert into AIMS_DEBUGGING  values (@Supplier , 'in here @Supplier'  , GETDATE())    
--IF @Guarantor is null and @Supplier is null and @Patient_Out ='N' and @Patient_In ='N' and @Assist ='N' and  @Transport = 'N'  and @Repat = 'N' and @Flight ='N'  
--BEGIN  
-- insert into AIMS_DEBUGGING  values (@vSQL , 'in here 6'  , GETDATE())    
-- insert into AIMS_DEBUGGING  values (@vSQL , 'FINALLLLL1'  , GETDATE())   
-- EXECUTE  sp_executesql  @vSQL   
--END  --ELSE  
--BEGIN  
 insert into AIMS_DEBUGGING  values (@vSQL , 'in here 7'  , GETDATE())    
   
 if  @Guarantor IS NOT NULL  
 BEGIN  
  IF @Guarantor <> ''  
  BEGIN  
   set @vSQL  =  @vSQL  + ' AND a.guarantor_id = ' + @Guarantor  
  END    
 END  
 if @Supplier IS NOT NULL  
 BEGIN  
  IF @Supplier <> ''  
  BEGIN  
   set @vSQL  =  @vSQL  + ' and a.SUPPLIER_ID  = ' + @Supplier  
  END    
 END  
   
 IF @Patient_In <> 'N'  
 BEGIN  
  set @vSQL  =  @vSQL  + ' and IN_PATIENT = ''' + @Patient_In + ''''   
 END  
   
 IF @Patient_Out <> 'N'  
 BEGIN  
  set @vSQL  =  @vSQL  + ' and OUT_PATIENT = ''' + @Patient_Out + ''''   
 END  
   
 if @Assist <> 'N'  
 BEGIN  
  set @vSQL  =  @vSQL  + ' and ASSIST= ''' + @Assist + ''''  
  IF @AssistType <> ''  
  BEGIN  
   set @vSQL  =  @vSQL  + ' and PATIENT_ASSIST_TYPE_ID = ' + @AssistType  
  END   
 END  
 
   
 IF @Transport <> 'N'  
 BEGIN  
  set @vSQL  =  @vSQL  + ' and TRANSPORT= ''' + @Transport + ''''  
  
  IF @TransportType <> ''  
  BEGIN  
   set @vSQL  =  @vSQL  + ' and PATIENT_TRANSPORT_TYPE_ID = ' + @TransportType  
  END   
 END  
   
 IF @Repat <> 'N'  
 BEGIN  
  set @vSQL  =  @vSQL  + ' and REPAT= ''' + @Repat + ''''   
 END  
   
 IF @Flight<> 'N'  
 BEGIN  
  set @vSQL  =  @vSQL  + ' and FLIGHT= ''' + @Flight + ''''   
 END  
   
 IF @FileCancelled <> 'N'  
 BEGIN  
  set @vSQL  =  @vSQL  + ' and CANCELLED= ''' + @FileCancelled + ''''   
 END  
 IF  @FileActive <> ''  
 BEGIN  
  set @vSQL  =  @vSQL  + ' and PATIENT_FILE_ACTIVE_YN= ''' + @FileActive + ''''  
 END   
 set @vSQL  =  @vSQL  + ' ORDER BY a.patient_file_no, a.patient_First_name, a.patient_last_name'  
 insert into AIMS_DEBUGGING  values (@vSQL , 'FINALLLLL2'  , GETDATE())   
 EXECUTE  sp_executesql  @vSQL  
--END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_DOCTOR_OWING_NAME]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_DOCTOR_OWING_NAME]      
    @PatientFileNo varchar(50) ='',
    @InvoiceID varchar(50) =''   
as     
declare @vSQL nvarchar(4000)    
set @vSQL = 'SELECT d.SUPPLIER_NAME ' +  
  ' FROM aims_invoice a, ' +  
  '      aims_invoice_medical_treatments b, ' +  
    '    aims_medical_treatment c, ' +  
      '  aims_supplier d, ' +  
       ' AIMS_PATIENT e ' +  
 ' WHERE  e.PATIENT_FILE_NO = ''' + @PatientFileNo + ''' and ' +  
 ' a.patient_id = e.patient_id ' +  
   ' AND a.doctor_owing = ''Y'' ' +  
   ' and a.invoice_id = ' + @InvoiceID  +
   ' AND b.invoice_id = a.invoice_id ' +
   ' AND c.medical_treatment_id = b.medical_treatment_id ' +  
   ' AND d.supplier_id = c.supplier_id '  
insert into AIMS_DEBUGGING values('[[AIMS_PATIENT_DOCTOR_OWING_NAME]]', @vSQL, GETDATE())  
 EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_FILES_ALLOCATED]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENTS_FILES_ALLOCATED]                  
 @CoOrdinator varchar(50) = ''                  
AS                          
BEGIN                          
declare @vSQL nvarchar(4000)                  
                      
SELECT @vSQL = ' SELECT   
    A.SENT_TO_ADMIN,   
    d.user_full_name file_allocated_to,   
    a.patient_file_no, ' +                  
       ' dbo.INITCAP (a.patient_last_name + '' '' + a.patient_first_name) patient_name, ' +                  
       ' c.guarantor_name,   
       a.patient_admission_date,   
       a.patient_discharge_date, ' +                   
       ' RTRIM (LTRIM (b.notes)) last_note_captured,   
       b.notes_dttm, ' +                  
       ' datediff (D, CONVERT (smalldatetime, b.notes_dttm, 103), getdate()) "COMMENT_SLA",   
       a.OUT_PATIENT,   
       a.IN_PATIENT,   
       a.REPAT,   
       a.FLIGHT,   
       a.ASSIST,   
       a.TRANSPORT, e.ASSIST_TYPE_DESC  ' +                  
       ' FROM aims_patient a inner join aims_notes b on b.patient_id = a.patient_id inner join aims_guarantor c on c.guarantor_id = a.guarantor_id inner join aims_users d on d.user_name = file_operator_to_userid left outer join AIMS_ASSIST_TYPE e on e.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID ' +                  
       ' WHERE ' +                  
       ' CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y'' and sent_to_admin = ''N'' and a.CREATION_DTTM > GETDATE() - 360 '             
       IF(@CoOrdinator = '')                  
       BEGIN                  
  SET @vSQL = @vSQL + ' and (a.PATIENT_ADMISSION_DATE is not null and a.PATIENT_ADMISSION_DATE <>'''')  and convert(SMALLDATETIME,a.PATIENT_ADMISSION_DATE, 103) <= GETDATE() '            
  SET @vSQL = @vSQL +      'AND A.PENDING = ''N'''             
       END            
    SET @vSQL = @vSQL + ' AND file_operator_to_userid IS NOT NULL ' +                  
       ' AND b.note_id = (SELECT MAX (note_id) ' +                  
       ' FROM aims_notes ' +                  
       ' WHERE aims_notes.patient_id = a.patient_id and aims_notes.note_type_id not in (Select x.note_type_id from '+                 
    ' aims_note_types x where x.note_type_cd = ''PATIENTFILEENQUIRY'')) '
       IF(@CoOrdinator <> '')                  
       BEGIN                  
  SET @vSQL = @vSQL + ' AND sent_to_admin = ''N'' and file_operator_to_userid = ''' + @CoOrdinator + ''''                  
       END                    
                         
       SET @vSQL = @vSQL + ' ' +                  
    ' ORDER BY a.patient_discharge_date desc,10 desc, file_operator_to_userid, c.guarantor_name, ' +                   
       ' CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC)'                  
                         
      insert into AIMS_DEBUGGING               
      values('SQL  - AIMS_PATIENTS_FILES_ALLOCATED ', @vSQL, GETDATE())              
                    
  EXECUTE  sp_executesql  @vSQL                  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_ADMIN_FILES_ALLOCATED]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENTS_ADMIN_FILES_ALLOCATED]                  
 @AdminStaff varchar(50) = ''                  
AS                          
BEGIN                          
declare @vSQL nvarchar(4000)                  
                      
SELECT @vSQL = ' select  a.sent_to_admin,a.high_cost, a.FILE_ASSIGNED_TO_USERID ,           
a.patient_file_no FILE_NO,          
a.COURIER_RECEIPT_DATE,
d.supplier_name HOSPITAL,
dbo.getduedate(a.COURIER_RECEIPT_DATE) DUE_DATE    ,      
a.patient_file_no,      
a.patient_LAST_NAME PATIENT_NAME ,      
c.guarantor_name guarantor_name,      
a.patient_ADMISSION_DATE  patient_ADMISSION_DATE,      
a.OUT_PATIENT,      
a.IN_PATIENT,      
a.REPAT,      
a.FLIGHT,      
a.ASSIST,      
a.TRANSPORT,      
a.RMR,      
b.MODIFIED_DATE Sent_To_Admin_DATE        
from           
aims_patient a,AIMS_A_PATIENT b, aims_guarantor c, aims_supplier d where a.SENT_TO_ADMIN = ''Y'' and a.CANCELLED = ''N'' and a.PATIENT_FILE_ACTIVE_YN = ''Y''           
and (a.COURIER_RECEIPT_DATE is not null or a.COURIER_RECEIPT_DATE <>'''')          
and b.PATIENT_ID = a.PATIENT_ID          
and b.AUDIT_ID = (select MIN(xx.AUDIT_ID) from AIMS_A_PATIENT xx where           
xx.PATIENT_ID = b.PATIENT_ID and xx.SENT_TO_ADMIN = ''Y'')  and       
a.FILE_ASSIGNED_TO_USERID = ''' + @AdminStaff + ''' and c.guarantor_id = a.guarantor_id and 
d.supplier_id = a.SUPPLIER_ID
order by 3 '          
          
    insert into AIMS_DEBUGGING values ('SQL+ ' ,@vSQL, GETDATE())            
EXECUTE  sp_executesql  @vSQL                  
END
GO
/****** Object:  Table [dbo].[AIMS_ROLE_RESTRICTION]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ROLE_RESTRICTION](
	[ROLE_CD] [varchar](50) NULL,
	[RESTRICTION_ID] [numeric](18, 0) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX1_ROLE_RESTRICTION] ON [dbo].[AIMS_ROLE_RESTRICTION] 
(
	[ROLE_CD] ASC,
	[RESTRICTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_REPORTS_ACCESS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_REPORTS_ACCESS](
	[REPORT_ID] [numeric](18, 0) NULL,
	[REPORT_NAME] [varchar](255) NULL,
	[REPORT_ACCESS_ROLE] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_LEDGER_NEW]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_LEDGER_NEW]                                      
@GuarantorID int,                                 
@LedgerType varchar(50),      
@startdate varchar(20) =null,      
@enddate varchar(20) =null,    
@AgeAnalysisPeriod varchar(5) = null                                    
as                                     
DECLARE @vSQL varchar (5000)  , @aging varchar(20)                              
              
if (@AgeAnalysisPeriod = '')  
begin  
set @aging= '-'  
end  
else  
begin  
set @aging= @AgeAnalysisPeriod  
end  
  
SET @vSQL = 'SELECT DISTINCT  invoice_amount_received invoice_amount,  
   invoice_no, ''' + @aging + ''' PAYMENT_TERM ' +    
 ' ,a.FILE_COURIER_DATE, a.COURIER_RECEIPT_DATE,b.INVOICE_DATE, ' + 
    ' case '+
		' when datediff("D", a.file_courier_date, GETDATE()) - 120 > 120 then ''120+''' +
		' else cast(datediff("D", a.file_courier_date, GETDATE())   as varchar(50))'+
   ' end AGING, '+   
 ' datediff("D", a.COURIER_RECEIPT_DATE, getdate()) "DAY_OVERDUE", ' +    
'e.title_desc+''''+dbo.Initcap(patient_first_name)+''''+dbo.Initcap(patient_last_name) patient_name,patient_last_name,guarantor_ref_no,guarantor_name,a.patient_file_no,dbo.Initcap(a.patient_first_name) patient_first_name,dbo.Initcap(a.patient_last_name),a.patient_discharge_date,Isnull((SELECT SUM(CAST(invoice_amount_received AS MONEY)) invoice_amount_received FROM aims_invoice,aims_patient WHERE aims_patient.patient_id=a.patient_id AND aims_invoice.patient_id=aims_patient.patient_id AND (aims_invoice.cancelled_yn=''N'' OR aims_invoice.cancelled_yn IS NULL) AND (aims_invoice.doctor_owing=''N'' OR aims_invoice.doctor_owing IS NULL) AND (aims_invoice.LATE_INVOICE_YN=''N'' OR aims_invoice.LATE_INVOICE_YN IS NULL)),0) invoice_amount_received,Isnull((SELECT SUM
(CAST(invoice_amount_received AS MONEY)) invoice_amount_received FROM aims_invoice,aims_patient WHERE aims_patient.patient_id=a.patient_id AND aims_invoice.patient_id=aims_patient.patient_id AND (aims_invoice.cancelled_yn=''N'' OR aims_invoice.cancelled_yn IS NULL) AND (aims_invoice.doctor_owing = ''N'' OR aims_invoice.doctor_owing IS NULL) AND (aims_invoice.LATE_INVOICE_YN=''Y'' OR aims_invoice.LATE_INVOICE_YN IS NULL)),0) late_invoice_amount_received,Isnull((SELECT SUM(CAST(    
aims_payment.amount_paid AS MONEY)) amount_paid_to_date FROM aims_payment,aims_patient WHERE aims_patient.patient_id=a.patient_id AND aims_payment.patient_id=aims_patient.patient_id AND ((aims_payment.doctor_owing IS NULL OR aims_payment.doctor_owing=''N'')      
 AND (aims_payment.forex_payment IS NULL OR aims_payment.forex_payment=''N'') AND (aims_payment.insurance_overpymt IS NULL OR aims_payment.insurance_overpymt=''N'') AND (aims_payment.insurance_shortpymt IS NULL OR aims_payment.insurance_shortpymt=''N'')))
, 0) amount_paid_to_date,((SELECT SUM(CAST(invoice_amount_received AS MONEY)) invoice_amount_received FROM aims_invoice, aims_patient WHERE aims_patient.patient_id=a.PATIENT_ID AND aims_invoice.patient_id=aims_patient.patient_id AND (aims_invoice.cancelled_yn=''N'' OR aims_invoice.cancelled_yn IS NULL) AND (aims_invoice.doctor_owing=''N'' OR aims_invoice.doctor_owing IS NULL))-ISNULL((SELECT SUM(CAST(aims_payment.amount_paid AS MONEY)) FROM aims_payment WHERE patient_id=a.PATIENT_ID AND (forex_payment=''Y'' OR insurance_overpymt=''Y'' OR insurance_shortpymt=''Y'' OR doctor_owing=''Y'')),0)) - Isnull((SELECT SUM(CAST(aims_payment.amount_paid AS MONEY)) amount_paid_to_date FROM aims_payment,aims_patient WHERE aims_patient.patient_id=a.PATIENT_ID AND aims_payment.patient_id=aims_patient.patient_id AND ((aims_payment.doctor_owing IS NULL OR aims_payment.doctor_owing=''N'') AND (aims_payment.forex_payment IS NULL OR  aims_payment.forex_payment=''N'') AND (aims_payment.insurance_overpymt IS NULL OR aims_payment.insurance_overpymt=''N'') AND (aims_payment.insurance_shortpymt IS NULL OR aims_payment.insurance_shortpymt=''N''))), 0) amount_outstanding,a.file_courier_date FROM aims_patient a LEFT OUTER JOIN aims_invoice b ON a.patient_id=b.patient_id LEFT OUTER JOIN aims_payment c ON a.patient_id=c.patient_id LEFT OUTER JOIN aims_guarantor d ON a.guarantor_id=d.guarantor_id LEFT OUTER JOIN aims_title e ON a.title_id=e.title_id WHERE '   
 if (@AgeAnalysisPeriod !='')  
 begin  
 SET @vSQL = @vSQL + ' (a.FILE_COURIER_DATE is not null or a.FILE_COURIER_DATE !='''') '   
 SET @vSQL = @vSQL +  ' and datediff("D", a.FILE_COURIER_DATE, getdate()) > ' + @AgeAnalysisPeriod + ' and '  
 end  
 SET @vSQL = @vSQL +  ' (b.INVOICE_DATE is not null or b.invoice_date !='''') and ' +    
 ' convert(smalldatetime,b.INVOICE_DATE , 103) between ' +    
 ' convert(datetime,'''+@StartDate+''',103) and ' +    
 ' convert(datetime,'''+@EndDate+''',103) and '           
IF @GuarantorID > 0                                
BEGIN                                    
SET @vSQL = @vSQL  + ' d.guarantor_id='   + cast(@GuarantorID  as varchar(50)) + ' And'                                
END                 
SET @vSQL = @vSQL  + ' (b.cancelled_yn=''N'' OR b.cancelled_yn IS NULL) AND (b.doctor_owing=''N'' OR b.doctor_owing IS NULL) AND (a.cancelled=''N'' OR a.cancelled IS NULL) AND ((c.doctor_owing IS NULL OR c.doctor_owing=''N'') AND (c.forex_payment IS NULL OR c.forex_payment=''N'') AND (c.insurance_overpymt IS NULL OR c.insurance_overpymt=''N'') AND (c.insurance_shortpymt IS NULL OR c.insurance_shortpymt=''N'')) GROUP BY e.title_desc,a.patient_last_name,guarantor_ref_no,guarantor_name,a.patient_file_no,patient_first_name,patient_last_name,patient_discharge_date,a.patient_id,invoice_amount_received,a.file_courier_date,b.INVOICE_DATE, a.COURIER_RECEIPT_DATE, invoice_no '              
                    
IF @GuarantorID > 0                                     
BEGIN                      
 SET @vSQL = @vSQL  + ' order by a.file_courier_date desc'                                    
END                                    
ELSE                                    
BEGIN                                   
 SET @vSQL = @vSQL  + ' order by guarantor_name, a.file_courier_date desc'                                     
END               
              
              
              
/*                                       
SET @vSQL ='SELECT DISTINCT e.title_desc + '''' + dbo.Initcap(patient_first_name) + '''' + dbo.Initcap(patient_last_name) patient_name,patient_last_name,guarantor_ref_no,guarantor_name,a.patient_file_no,dbo.Initcap(a.patient_first_name) patient_first_name
  
    
      
        
          
              
                  
  ,dbo.Initcap(a.patient_last_name),a.patient_discharge_date,Isnull((SELECT SUM(CAST(invoice_amount_received AS MONEY)) invoice_amount_received FROM   aims_invoice, aims_patient WHERE  aims_patient.patient_id=a.patient_id AND aims_invoice.patient_id=     
  
    
      
        
          
           
  aims_patient.patient_id AND (aims_invoice.cancelled_yn= ''N'' OR aims_invoice.cancelled_yn IS NULL) AND                     
(aims_invoice.doctor_owing=''N'' OR aims_invoice.doctor_owing IS NULL ) AND ( aims_invoice.LATE_INVOICE_YN  = ''N''                     
                               OR aims_invoice.LATE_INVOICE_YN IS NULL )),0) invoice_amount_received,                       
                Isnull(                    
(SELECT SUM(CAST(invoice_amount_received AS MONEY))                     
invoice_amount_received                     
FROM   aims_invoice,                     
aims_patient                     
WHERE  aims_patient.patient_id = a.patient_id                     
AND aims_invoice.patient_id = aims_patient.patient_id                     
AND ( aims_invoice.cancelled_yn = ''N''                     
OR aims_invoice.cancelled_yn IS NULL )                     
AND ( aims_invoice.doctor_owing = ''N''                     
OR aims_invoice.doctor_owing IS NULL )                    
AND ( aims_invoice.LATE_INVOICE_YN  = ''Y''                     
OR aims_invoice.LATE_INVOICE_YN IS NULL )), 0   ) late_invoice_amount_received,                      
Isnull((SELECT SUM(CAST(aims_payment.amount_paid AS MONEY)) amount_paid_to_date FROM aims_payment,aims_patient WHERE aims_patient.patient_id=a.patient_id                       
AND aims_payment.patient_id=aims_patient.patient_id AND ((aims_payment.doctor_owing IS NULL OR aims_payment.doctor_owing=''N'') AND (aims_payment.forex_payment IS NULL OR aims_payment.forex_payment=''N'') AND (aims_payment.insurance_overpymt IS NULL OR   
  
    
      
        
          
            
              
               
aims_payment.insurance_overpymt=''N'') AND ( aims_payment.insurance_shortpymt IS NULL OR aims_payment.insurance_shortpymt=''N''))), 0)                       
amount_paid_to_date,((SELECT SUM(CAST(invoice_amount_received AS MONEY)) invoice_amount_received FROM aims_invoice, aims_patient WHERE  aims_patient.patient_id=a.PATIENT_ID                      
AND aims_invoice.patient_id=aims_patient.patient_id AND (aims_invoice.cancelled_yn=''N'' OR aims_invoice.cancelled_yn IS NULL) AND (aims_invoice.doctor_owing=''N'' OR aims_invoice.doctor_owing IS NULL )) - ISNULL((SELECT SUM(CAST(aims_payment.amount_paid 
  
    
      
        
          
            
              
                
AS MONEY)) FROM aims_payment WHERE patient_id=a.PATIENT_ID AND (forex_payment=''Y'' OR insurance_overpymt=''Y'' OR insurance_shortpymt=''Y'' OR doctor_owing=''Y'' )),0)) - Isnull( '                      
print 'Was here 1'                    
SET @vSQL = @vSQL  + '(SELECT SUM(CAST(aims_payment.amount_paid AS MONEY)) amount_paid_to_date FROM aims_payment,aims_patient WHERE '                      
SET @vSQL = @vSQL  + 'aims_patient.patient_id=a.PATIENT_ID AND aims_payment.patient_id=aims_patient.patient_id AND ((aims_payment.doctor_owing IS NULL OR aims_payment.doctor_owing=''N'' ) AND (aims_payment.forex_payment IS NULL OR  aims_payment.forex_paym
  
    
      
        
          
            
              
ent=''N'') AND (aims_payment.insurance_overpymt IS NULL OR aims_payment.insurance_overpymt=''N'') AND (aims_payment.insurance_shortpymt IS NULL OR aims_payment.insurance_shortpymt=''N''))), 0) amount_outstanding,a.file_courier_date'                      
SET @vSQL = @vSQL  + ' FROM aims_patient a INNER JOIN aims_invoice b ON a.patient_id=b.patient_id LEFT OUTER JOIN aims_payment c ON a.patient_id=c.patient_id LEFT OUTER JOIN aims_guarantor d ON a.guarantor_id=d.guarantor_id LEFT OUTER JOIN aims_title e ON
  
    
      
        
          
            
              
 a.title_id=e.title_id WHERE '                      
print 'Was here 2'                    
IF @GuarantorID > 0                                
BEGIN                                    
SET @vSQL = @vSQL  + 'd.guarantor_id=  '   + cast(@GuarantorID  as varchar(50)) + ' And'                                
END                      
  print 'Was here 3'                    
SET @vSQL =@vSQL + ' (b.cancelled_yn=''N'' OR b.cancelled_yn IS NULL)                       
AND (b.doctor_owing=''N'' OR b.doctor_owing IS NULL ) AND ( a.cancelled=''N'' OR a.cancelled IS NULL)                       
AND ((c.doctor_owing IS NULL OR c.doctor_owing=''N'' ) AND ( c.forex_payment IS NULL OR c.forex_payment=''N'')                       
AND (c.insurance_overpymt IS NULL OR c.insurance_overpymt=''N'')                       
AND (c.insurance_shortpymt IS NULL OR c.insurance_shortpymt=''N''))                       
GROUP BY e.title_desc,a.patient_last_name,guarantor_ref_no,guarantor_name,a.patient_file_no,patient_first_name,patient_last_name,patient_discharge_date,a.patient_id,invoice_amount_received,a.file_courier_date '                      
  print 'Was here 4'                    
IF (@LedgerType='BALANCES')                                
BEGIN                                
set @vSQL =@vSQL  + ' HAVING (CAST(invoice_amount_received AS MONEY) - (ISNULL((SELECT SUM(CAST(aims_payment.amount_paid AS MONEY)) FROM aims_payment WHERE patient_id = a.PATIENT_ID AND (forex_payment=''Y'' OR insurance_overpymt=''Y'' OR insurance_shortpy
  
    
      
mt=''Y'' OR doctor_owing=''Y'' )),0))) > (SELECT Isnull(SUM(CAST(aims_payment.amount_paid AS MONEY)), 0) amount_paid_to_date FROM aims_payment, aims_patient WHERE aims_patient.patient_id=a.patient_id                     
AND aims_payment.patient_id=aims_patient.patient_id AND ((aims_payment.doctor_owing IS NULL OR aims_payment.doctor_owing=''N'') AND (aims_payment.forex_payment IS NULL OR aims_payment.forex_payment=''N'') AND (aims_payment.insurance_overpymt IS NULL OR ai
  
    
      
ms_payment.insurance_overpymt=''N'') AND (aims_payment.insurance_shortpymt IS NULL OR aims_payment.insurance_shortpymt=''N'')))'                    
END                      
                      
IF @GuarantorID > 0                                     
BEGIN                      
 SET @vSQL = @vSQL  + ' order by patient_file_no '                                  
END                                    
ELSE                                    
BEGIN                                   
 SET @vSQL = @vSQL  + ' order by guarantor_name '                                     
END                     
*/              
                                
INSERT INTO AIMS_DEBUGGING  values ('AIMS Ledger - NEW LEDGER', @vSQL, GETDATE())                            
                                
--EXECUTE  sp_executesql @vSQL                      
EXEC (@vSQL)
GO
/****** Object:  StoredProcedure [dbo].[AIMS_LEDGER]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_LEDGER]              
@GuarantorID int,         
@LedgerType varchar(50)            
as             
 declare @vSQL nvarchar(4000)        
               
 set @vSQL  = ' select distinct ' +            
   ' e.title_desc +'' '' +  dbo.initcap(patient_first_name) + '' '' + dbo.initcap(patient_last_name) patient_name, ' +            
   ' guarantor_ref_no, guarantor_name ,a.patient_file_no, dbo.initcap(a.patient_first_name) patient_first_name , dbo.initcap(a.patient_last_name) patient_last_name, ' +        
   ' a.patient_discharge_date, ' +        
   ' (select SUM(CAST(invoice_amount_received as MONEY)) invoice_amount_received from aims_invoice, aims_patient where aims_patient.patient_id = a.patient_id and aims_invoice.patient_id = aims_patient.patient_id and (aims_invoice.cancelled_yn = ''N'' OR aims_invoice.cancelled_yn IS NULL) and (aims_invoice.doctor_owing = ''N'' OR aims_invoice.doctor_owing IS NULL)) invoice_amount_received,' +        
   ' ISNULL((Select SUM(CAST(aims_payment.amount_paid AS money)) Amount_Paid_To_Date FROM AIMS_PAYMENT , AIMS_PATIENT WHERE AIMS_PATIENT.patient_id = a.patient_id and aims_payment.patient_id = AIMS_PATIENT.patient_id and ((aims_payment.doctor_owing is null or aims_payment.doctor_owing = ''N'') AND (aims_payment.forex_payment is null or aims_payment.forex_payment = ''N'') AND (aims_payment.insurance_overpymt is null or aims_payment.insurance_overpymt = ''N'') AND (aims_payment.insurance_shortpymt is null or aims_payment.insurance_shortpymt = ''N''))),0) Amount_Paid_To_Date,' +        
   ' (select SUM(CAST(invoice_amount_received as MONEY)) invoice_amount_received from aims_invoice, aims_patient where aims_patient.patient_id = a.patient_id and aims_invoice.patient_id = aims_patient.patient_id  and (aims_invoice.cancelled_yn = ''N'' OR aims_invoice.cancelled_yn IS NULL) and (aims_invoice.doctor_owing = ''N'' OR aims_invoice.doctor_owing IS NULL)) - ISNULL((Select SUM(CAST(aims_payment.amount_paid AS money)) Amount_Paid_To_Date FROM AIMS_PAYMENT , AIMS_PATIENT WHERE AIMS_PATIENT.patient_id = a.patient_id and aims_payment.patient_id = AIMS_PATIENT.patient_id and (  (aims_payment.doctor_owing is null or aims_payment.doctor_owing = ''N'') AND    (aims_payment.forex_payment is null or aims_payment.forex_payment = ''N'') AND (aims_payment.insurance_overpymt is null or aims_payment.insurance_overpymt = ''N'') AND (aims_payment.insurance_shortpymt is null or aims_payment.insurance_shortpymt = ''N''))),0) Amount_OutStanding, a.file_courier_date ' +        
   ' from aims_patient a   ' +            
   ' inner join aims_invoice b on a.patient_id = b.patient_id ' +            
   ' left outer join aims_payment c on a.patient_id = c.patient_id ' +            
   ' left outer join aims_guarantor d on a.guarantor_id = d.guarantor_id ' +            
   ' left outer join aims_title e on a.title_id = e.title_id where '             
           
   if @GuarantorID > 0        
   begin            
    set @vSQL  =  @vSQL  + ' d.guarantor_id    =  '   + cast(@GuarantorID  as varchar(50)) + ' and '        
   end            
           
   set @vSQL  =  @vSQL  + ' (b.cancelled_yn = ''N'' or b.cancelled_yn IS NULL)  and (b.doctor_owing = ''N'' or b.doctor_owing is null) and (a.CANCELLED = ''N'' or a.cancelled is null) and '        
   SET @vSQL  =  @vSQL  + ' ((c.doctor_owing is null or c.doctor_owing = ''N'') AND (c.forex_payment is null or c.forex_payment = ''N'') AND (c.insurance_overpymt is null or c.insurance_overpymt = ''N'') AND (c.insurance_shortpymt is null or c.insurance_shortpymt = ''N''))'        


   set @vSQL  =  @vSQL  + ' GROUP BY  e.title_desc, a.patient_last_name, guarantor_ref_no, guarantor_name, a.patient_file_no, patient_first_name, patient_last_name ,patient_discharge_date, a.patient_id,  invoice_amount_received, a.file_courier_date '      
  
           
   if (@LedgerType = 'BALANCES')        
   begin        
   set @vSQL  =  @vSQL  + ' HAVING  CAST(invoice_amount_received  AS MONEY)  > (Select ISNULL(SUM(CAST(aims_payment.amount_paid AS money)),0) Amount_Paid_To_Date FROM AIMS_PAYMENT , AIMS_PATIENT WHERE AIMS_PATIENT.patient_id = a.patient_id and aims_payment.patient_id = AIMS_PATIENT.patient_id and ((aims_payment.doctor_owing is null or aims_payment.doctor_owing = ''N'') AND (aims_payment.forex_payment is null or aims_payment.forex_payment = ''N'') AND (aims_payment.insurance_overpymt is null or aims_payment.insurance_overpymt = ''N'') AND (aims_payment.insurance_shortpymt is null or aims_payment.insurance_shortpymt = ''N'')))'                
   end        
           
   if @GuarantorID > 0             
    begin            
     set @vSQL  =  @vSQL  + ' order by patient_name, guarantor_ref_no '            
    end             
   ELSE            
    BEGIN           
     set @vSQL  =  @vSQL  + '  order by guarantor_name '             
    END          
        
    insert into AIMS_DEBUGGING  values ('AIMS Ledger', @vSQL, GETDATE())    
        
   EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  Table [dbo].[AIMS_GOP_USER_LIMIT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_GOP_USER_LIMIT](
	[LIMIT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[USER_NAME] [varchar](50) NOT NULL,
	[LIMIT] [money] NULL,
 CONSTRAINT [PK_AIMS_AUTH_MATRIX_1] PRIMARY KEY CLUSTERED 
(
	[LIMIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_EWS_EMAILS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_EMAILS](
	[EMAIL_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[EMAIL_UNIQUE_ID] [varchar](500) NULL,
	[EMAIL_GUID] [varchar](100) NULL,
	[EMAIL_SUBJECT] [varchar](4000) NULL,
	[EMAIL_RECEIVED_DTTM] [datetime] NULL,
	[EMAIL_SENT_FROM_NAME] [varchar](500) NULL,
	[EMAIL_SENT_FROM_ADDRESS] [varchar](500) NULL,
	[EMAIL_SENT_TO] [varchar](4000) NULL,
	[EMAIL_SENT_TO_CC] [varchar](500) NULL,
	[EMAIL_SENT_TO_BCC] [varchar](500) NULL,
	[MAILBOX_ID] [numeric](18, 0) NULL,
	[PROCESSED_DTTM] [datetime] NULL,
	[EMAIL_UNREAD_YN] [varchar](1) NULL,
	[EMAIL_INDEXED_YN] [varchar](1) NOT NULL,
	[EMAIL_LOCKED_BY] [varchar](50) NULL,
	[EMAIL_DELETED_YN] [varchar](1) NOT NULL,
	[EMAIL_PENDED_YN] [varchar](1) NOT NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[AIMS_EWS_EMAILS] ADD [EMAIL_INDEXED_BY] [varchar](50) NULL
ALTER TABLE [dbo].[AIMS_EWS_EMAILS] ADD  CONSTRAINT [PK_AIMS_EMAILS] PRIMARY KEY CLUSTERED 
(
	[EMAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_EWS_EMAILS] ON [dbo].[AIMS_EWS_EMAILS] 
(
	[EMAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AIMS_EWS_EMAILS_1] ON [dbo].[AIMS_EWS_EMAILS] 
(
	[MAILBOX_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_ADMINISTRATOR_WORK]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_GET_ADMINISTRATOR_WORK]                  
 @USER_ID VARCHAR(50)                  
AS                   
BEGIN                
DECLARE @vSQL NVARCHAR(3000)            
              
 SET @vSQL = 'SELECT C.PATIENT_ID , PATIENT_FILE_NO,        
EMAIL_SUBJECT,        
EMAIL_SUBJECT,        
EMAIL_SENT_FROM_NAME,        
EMAIL_RECEIVED_DTTM,        
C.PATIENT_ENQUIRY_ID,        
PRIORITY_ID, a.OPERATOR_MAILBOX_USER_NAME FROM ' +            
  ' AIMS_EWS_ADMIN_MAILBOX A ' +            
   ' inner  JOIN AIMS_EWS_ADMIN_MAILS B ON B.OPERATOR_MAILBOX_ID = A.OPERATOR_MAILBOX_ID ' +            
   ' INNER JOIN AIMS_EWS_PATIENT_ENQUIRY C ON C.PATIENT_ENQUIRY_ID = B.PATIENT_ENQUIRY_ID ' +             
   ' INNER JOIN AIMS_EWS_EMAILS D ON D.EMAIL_ID = C.EMAIL_ID ' +            
   ' INNER JOIN AIMS_PATIENT E ON E.PATIENT_ID = C.PATIENT_ID ' +               
 ' WHERE '            
 IF(@USER_ID <> '<All Workbaskets>')            
 BEGIN            
 SET @vSQL = @vSQL + ' A.OPERATOR_MAILBOX_USER_NAME = ''' + @USER_ID + ''' AND '            
 END            
 ELSE            
 BEGIN            
 SET @vSQL = @vSQL + ' A.OPERATOR_MAILBOX_USER_NAME in ( ' +            
  ' Select au.USER_NAME from AIMS_ROLES AR ' +            
  ' inner join AIMS_USER_ROLE AUR on AR.ROLE_CD = AUR.ROLE_CD ' +            
     ' inner join AIMS_USERS AU on AUR.USER_NAME = AU.User_Name ' +            
  ' where AR.ROLE_CD = ''Admin'') AND '            
 END            
 SET @vSQL = @vSQL + ' (B.WORK_ITEM_PROCESSED_YN = ''N'' OR WORK_ITEM_PROCESSED_YN = '''') '        
 IF(@USER_ID = '<All Workbaskets>')                
 begin        
   set @vSQL = @vSQL + ' UNION         
SELECT         
	C.PATIENT_ID , PATIENT_FILE_NO,        
	EMAIL_SUBJECT,        
	EMAIL_SUBJECT,        
	EMAIL_SENT_FROM_NAME,        
	EMAIL_RECEIVED_DTTM,        
	C.PATIENT_ENQUIRY_ID,        
	PRIORITY_ID ,f.OPERATOR_MAILBOX_USER_NAME    
   FROM AIMS_EWS_ADMIN_MAILS B 
		inner join AIMS_EWS_PATIENT_ENQUIRY C on C.PATIENT_ENQUIRY_ID = B.PATIENT_ENQUIRY_ID        
		inner join AIMS_EWS_EMAILS D on D.EMAIL_ID  = C.EMAIL_ID
		inner join AIMS_PATIENT E on E.PATIENT_ID = C.PATIENT_ID and E.PATIENT_ID not IN (34728) 
		left outer join AIMS_EWS_ADMIN_MAILBOX f on f.OPERATOR_MAILBOX_ID = b.OPERATOR_MAILBOX_ID
       WHERE         
       B.OPERATOR_MAILBOX_ID IS NULL AND         
       ((B.WORK_ITEM_PROCESSED_YN = ''N'' OR WORK_ITEM_PROCESSED_YN = '''')) '         
   set @vSQL = @vSQL + ' ORDER BY C.PRIORITY_ID ASC ,C.PATIENT_ID '            
     end        
   insert into AIMS_DEBUGGING (DEBUG_MSG,DEBUG_VALUE,DEBUG_DTTM) values ('ADMIN - WORKBASKET FETCH', @vSQL, GETDATE())          
 EXECUTE  sp_executesql  @vSQL             
             
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_ADMIN_WORKBASKET_AUDIT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_GET_ADMIN_WORKBASKET_AUDIT]                     
 @USER_ID VARCHAR(50)                      
AS                       
BEGIN                    
DECLARE @vSQL NVARCHAR(3000)                
                  
 SET @vSQL = 'SELECT         
 e.patient_file_no,           
 d.EMAIL_SUBJECT,           
 d.EMAIL_SENT_FROM_NAME,          
 d.EMAIL_RECEIVED_DTTM,          
 WORK_ITEM_PROCESSED_DTTM,          
 USER_FULL_NAME,          
 C.PATIENT_ID FROM ' +                
  ' AIMS_EWS_ADMIN_MAILBOX A ' +                
   ' INNER JOIN AIMS_EWS_ADMIN_MAILS B ON B.OPERATOR_MAILBOX_ID = A.OPERATOR_MAILBOX_ID ' +                
   ' INNER JOIN AIMS_EWS_PATIENT_ENQUIRY C ON C.PATIENT_ENQUIRY_ID = B.PATIENT_ENQUIRY_ID ' +                 
   ' INNER JOIN AIMS_EWS_EMAILS D ON D.EMAIL_ID = C.EMAIL_ID ' +                
   ' INNER JOIN AIMS_PATIENT E ON E.PATIENT_ID = C.PATIENT_ID ' +                   
   ' left outer JOIN AIMS_USERS F ON F.USER_NAME = b.WORK_ITEM_PROCESSED_BY ' +               
 ' WHERE '                
 IF(@USER_ID <> '<All Workbaskets>')                
 BEGIN                
 SET @vSQL = @vSQL + ' A.OPERATOR_MAILBOX_USER_NAME = ''' + @USER_ID + ''' AND '                
 END                
 ELSE                
 BEGIN                
 SET @vSQL = @vSQL + ' A.OPERATOR_MAILBOX_USER_NAME in ( ' +                
  ' Select au.USER_NAME from AIMS_ROLES AR ' +                
  ' inner join AIMS_USER_ROLE AUR on AR.ROLE_CD = AUR.ROLE_CD ' +                
     ' inner join AIMS_USERS AU on AUR.USER_NAME = AU.User_Name ' +                
  ' where AR.ROLE_CD = ''Admin'') AND '                
 END                
 SET @vSQL = @vSQL + ' (B.WORK_ITEM_PROCESSED_YN = ''Y'') and B.WORK_ITEM_PROCESSED_DTTM >= GETDATE()-31 ' +                
 ' ORDER BY WORK_ITEM_PROCESSED_DTTM desc ,C.PATIENT_ID '                
           
 EXECUTE  sp_executesql  @vSQL                 
 
 insert into AIMS_DEBUGGING  values ('ADMIN_WB_BASKET',@vSQL,GETDATE())
 
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_DOCTYPES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[AIMS_EWS_GET_DOCTYPES]   
   @MailBoxName varchar(50) = ''                                                 
AS      
BEGIN      
 SELECT * FROM AIMS_EWS_DOCUMENT_TYPE a where mailbox_name = @MailBoxName   
 union  
 SELECT * FROM AIMS_EWS_DOCUMENT_TYPE a where (mailbox_name is null or mailbox_name ='')  
 ORDER BY a.DOC_TYPE      
END   


select * from AIMS_EWS_MAILBOXES
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_OPERATOR_WORK]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_GET_OPERATOR_WORK]          
 @USER_ID VARCHAR(50)          
AS           
BEGIN        
DECLARE @vSQL NVARCHAR(3000)    
      
 SET @vSQL = 'SELECT C.PATIENT_ID , PATIENT_FILE_NO,
EMAIL_SUBJECT,
EMAIL_SUBJECT,
EMAIL_SENT_FROM_NAME,
EMAIL_RECEIVED_DTTM,
C.PATIENT_ENQUIRY_ID,
PRIORITY_ID FROM ' +    
  ' AIMS_EWS_OPERATOR_MAILBOX A ' +    
   ' inner  JOIN AIMS_EWS_OPERATOR_MAILS B ON B.OPERATOR_MAILBOX_ID = A.OPERATOR_MAILBOX_ID ' +    
   ' INNER JOIN AIMS_EWS_PATIENT_ENQUIRY C ON C.PATIENT_ENQUIRY_ID = B.PATIENT_ENQUIRY_ID ' +     
   ' INNER JOIN AIMS_EWS_EMAILS D ON D.EMAIL_ID = C.EMAIL_ID ' +    
   ' INNER JOIN AIMS_PATIENT E ON E.PATIENT_ID = C.PATIENT_ID ' +       
 ' WHERE '    
 IF(@USER_ID <> '<All Workbaskets>')    
 BEGIN    
 SET @vSQL = @vSQL + ' A.OPERATOR_MAILBOX_USER_NAME = ''' + @USER_ID + ''' AND '    
 END    
 ELSE    
 BEGIN    
 SET @vSQL = @vSQL + ' A.OPERATOR_MAILBOX_USER_NAME in ( ' +    
  ' Select au.USER_NAME from AIMS_ROLES AR ' +    
  ' inner join AIMS_USER_ROLE AUR on AR.ROLE_CD = AUR.ROLE_CD ' +    
     ' inner join AIMS_USERS AU on AUR.USER_NAME = AU.User_Name ' +    
  ' where AR.ROLE_CD = ''Operations'') AND '    
 END    
 SET @vSQL = @vSQL + ' (B.WORK_ITEM_PROCESSED_YN = ''N'' OR WORK_ITEM_PROCESSED_YN = '''') '
 IF(@USER_ID = '<All Workbaskets>')        
 begin
		 set @vSQL = @vSQL + ' UNION 
 							SELECT 
							C.PATIENT_ID , PATIENT_FILE_NO,
		EMAIL_SUBJECT,
		EMAIL_SUBJECT,
		EMAIL_SENT_FROM_NAME,
		EMAIL_RECEIVED_DTTM,
		C.PATIENT_ENQUIRY_ID,
		PRIORITY_ID
		 FROM AIMS_EWS_OPERATOR_MAILS B, AIMS_EWS_PATIENT_ENQUIRY C,
							AIMS_EWS_EMAILS D, AIMS_PATIENT E  WHERE 
							B.OPERATOR_MAILBOX_ID IS NULL AND 
							((B.WORK_ITEM_PROCESSED_YN = ''N'' OR WORK_ITEM_PROCESSED_YN = ''''))
							AND C.PATIENT_ENQUIRY_ID = B.PATIENT_ENQUIRY_ID
							AND D.EMAIL_ID  = C.EMAIL_ID
							AND E.PATIENT_ID = C.PATIENT_ID AND E.PATIENT_ID not IN (14041) ' 
     end
     set @vSQL = @vSQL + ' ORDER BY C.PRIORITY_ID ASC ,C.PATIENT_ID '    
   insert into AIMS_DEBUGGING (DEBUG_MSG,DEBUG_VALUE,DEBUG_DTTM) values ('WORKSSS', @vSQL, GETDATE())  
 EXECUTE  sp_executesql  @vSQL     
     
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_MAILBOX_UPDATE_POD_COUNTER]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_MAILBOX_UPDATE_POD_COUNTER]    
  @MailboxID VARCHAR(30),  
  @Counter VARCHAR(30)  
 AS    
 BEGIN    
  UPDATE aims_ews_mailboxes  
     SET mailbox_pod_counter = @Counter  
   WHERE mailbox_id = @MailboxID  
 END
GO
/****** Object:  Table [dbo].[AIMS_EWS_OPERATOR_MAILBOX]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_OPERATOR_MAILBOX](
	[OPERATOR_MAILBOX_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[OPERATOR_MAILBOX_USER_NAME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AIMS_EWS_OPERATOR_MAILBOX] PRIMARY KEY CLUSTERED 
(
	[OPERATOR_MAILBOX_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_EWS_OPERATOR_MAILBOX] ON [dbo].[AIMS_EWS_OPERATOR_MAILBOX] 
(
	[OPERATOR_MAILBOX_USER_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_FOREX_LEDGER]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--using aims_updates

CREATE PROCEDURE [dbo].[AIMS_FOREX_LEDGER]                          
@Forex varchar(1),                       
@OverPymt varchar(1),                    
@ShortPymt varchar(1),                    
@DoctorOwing varchar(1),          
@OverPymtLateInvoice varchar(1),                        
@StartDate varchar(20) = null,    
@EndDate varchar(20) = null,  
@AgeAnalysisPeriod varchar(20) = null    
as                         
 declare @vSQL nvarchar(4000), @Aging varchar (50)                     

if (@AgeAnalysisPeriod = '')
begin
set @Aging = ' - '
end
else
begin
set @Aging = @AgeAnalysisPeriod
end
                    
 set @vSQL  = ' select distinct invoice_no, ''' + @Aging + ''' PAYMENT_TERM ' +  
 ' ,a.FILE_COURIER_DATE, a.COURIER_RECEIPT_DATE,b.INVOICE_DATE, ' +  
   ' case '+
		' when datediff("D", a.file_courier_date, GETDATE()) - 120 > 120 then ''120+''' +
		' else cast(datediff("D", a.file_courier_date, GETDATE())   as varchar(50))'+
   ' end AGING, '+
 ' datediff("D", a.COURIER_RECEIPT_DATE, getdate()) "DAY_OVERDUE", ' +  
    ' e.title_desc +'' '' +  dbo.initcap(patient_first_name) + '' '' + dbo.initcap(patient_last_name) patient_name, ' +                        
    ' guarantor_ref_no, ' +              
    ' guarantor_name ,' +              
    ' a.patient_file_no, ' +              
    ' dbo.initcap(a.patient_first_name) patient_first_name , ' +              
    ' dbo.initcap(a.patient_last_name) patient_last_name, ' +                    
    ' a.patient_discharge_date, ' +              
    ' b.doctor_owing , ' +              
    ' ISNULL((Select SUM(CAST(aims_payment.amount_paid AS money)) Amount_Paid_To_Date FROM AIMS_PAYMENT , AIMS_PATIENT WHERE AIMS_PATIENT.patient_id = a.patient_id and aims_payment.patient_id = AIMS_PATIENT.patient_id AND ' +          
    ' aims_payment.doctor_owing = '''+ @DoctorOwing +''' AND ((b.doctor_owing = '''+ @DoctorOwing +''')'        
   if(@OverPymt = 'Y' and @OverPymtLateInvoice ='Y')        
   begin        
 set @vSQL = @vSQL + ' AND (aims_payment.insurance_overpymt = '''+@OverPymtLateInvoice +''' and aims_payment.LATE_SUBMISSION_PYMT = '''+ @OverPymtLateInvoice +''') '        
   end             
 set @vSQL = @vSQL + ' AND (aims_payment.forex_payment = '''+ @Forex +''') AND (aims_payment.insurance_overpymt = '''+ @OverPymt +''') AND (aims_payment.insurance_shortpymt =         
'''+ @ShortPymt +'''))),0) Amount_Paid_To_Date' +                    
   ' ,forex_payment, ' +                    
   ' insurance_overpymt, ' +                    
   ' insurance_shortpymt, ' +                     
   ' b.doctor_owing, ' +                    
   ' ISNULL((SELECT SUM(CAST(invoice_amount_received AS MONEY)) ' +              
            ' invoice_amount_received ' +              
     ' FROM   aims_invoice, ' +              
            ' aims_patient ' +              
     ' WHERE aims_invoice.invoice_id = b.invoice_id ' +                
   ' AND aims_patient.patient_id = aims_invoice.patient_id ' +              
            ' AND ( aims_invoice.cancelled_yn = ''N'' ' +              
                   ' OR aims_invoice.cancelled_yn IS NULL ) ' +              
            ' AND ( aims_invoice.doctor_owing = ''Y'' ' +              
                   ' OR aims_invoice.doctor_owing IS NULL ) ' +              
            ' AND ( aims_invoice.late_invoice_yn = ''N'' ' +              
                   ' OR aims_invoice.late_invoice_yn IS NULL )),0) ' +              
    ' invoice_amount_received, '             
 IF (@DoctorOwing = 'Y')                      
 BEGIN            
  set @vSQL  =  @vSQL  + ' (SELECT m.SUPPLIER_NAME  ' +               
    '  FROM aims_invoice j,     ' +            
    ' aims_invoice_medical_treatments k, ' +               
      ' aims_medical_treatment l, ' +            
    ' aims_supplier m, ' +            
    ' AIMS_PATIENT n ' +            
    ' WHERE  n.PATIENT_FILE_NO =  a.PATIENT_FILE_NO and ' +               
    ' j.patient_id = n.patient_id     ' +             
   ' AND j.doctor_owing = '''+@DoctorOwing+'''' +            
   ' and j.invoice_id =  b.invoice_id ' +            
   ' AND k.invoice_id = j.invoice_id ' +                
   ' AND l.medical_treatment_id = k.medical_treatment_id ' +             
   ' AND m.supplier_id = l.supplier_id) doctor_owing_name '             
 END            
 ELSE            
 BEGIN          
  SET @vSQL  =  @vSQL  + 'guarantor_name doctor_owing_name'            
 END             
               
   SET @vSQL  =  @vSQL  + ' from aims_patient a   ' +                        
   ' left outer join aims_invoice b on a.patient_id = b.patient_id ' +                        
   ' left outer join aims_payment c on a.patient_id = c.patient_id ' +                      
   ' left outer join aims_guarantor d on a.guarantor_id = d.guarantor_id ' +                        
   ' left outer join aims_title e on a.title_id = e.title_id where '   
if (@AgeAnalysisPeriod !='')
begin
SET @vSQL  =  @vSQL  + ' (a.FILE_COURIER_DATE is not null or a.FILE_COURIER_DATE !='''') '   
 SET @vSQL  =  @vSQL  + ' and datediff("D", a.FILE_COURIER_DATE, getdate()) > ' + @AgeAnalysisPeriod  + ' and ' 
end

 SET @vSQL  =  @vSQL  + ' (b.INVOICE_DATE is not null or b.invoice_date !='''') and ' +  
 ' convert(smalldatetime,b.INVOICE_DATE , 103) between ' +  
 ' convert(datetime,'''+@StartDate+''',103) and ' +  
 ' convert(datetime,'''+@EndDate+''',103) and '       
   set @vSQL  =  @vSQL  + ' (b.cancelled_yn = ''N'' or b.cancelled_yn IS NULL) and (a.CANCELLED = ''N'' or a.cancelled is null) and '                    
   SET @vSQL  =  @vSQL  + ' ((b.doctor_owing = '''+ @DoctorOwing +''') AND ( '       
   --c.doctor_owing = '''+ @DoctorOwing  +'''AND       
   SET @vSQL  =  @vSQL  + ' c.forex_payment = '''+ @Forex +''') '        
           
   if(@OverPymt = 'Y' and @OverPymtLateInvoice ='Y')        
   begin        
  set @vSQL = @vSQL + ' AND (c.insurance_overpymt = '''+@OverPymtLateInvoice +''' and c.LATE_SUBMISSION_PYMT = '''+ @OverPymtLateInvoice +''') '        
   end            
   set @vSQL = @vSQL + ' and (c.insurance_overpymt = '''+ @OverPymt +''') and (c.insurance_shortpymt = '''+ @ShortPymt +'''))'                    
   set @vSQL  =  @vSQL  + ' GROUP BY  e.title_desc, a.patient_last_name, guarantor_ref_no, guarantor_name, a.patient_file_no, patient_first_name, patient_last_name ,patient_discharge_date, a.patient_id, forex_payment, insurance_overpymt, insurance_shortpymt, b.doctor_owing , b.invoice_id ,         b.INVOICE_DATE, a.COURIER_RECEIPT_DATE, a.FILE_COURIER_DATE, invoice_no'                    
   set @vSQL  =  @vSQL  + '  order by guarantor_name, patient_file_no '                             
   insert into AIMS_DEBUGGING values('[AIMS_FOREX_LEDGER]', @vSQL, GETDATE())                
   EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_WORKBASKET_ADMINISTRATORS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_GET_WORKBASKET_ADMINISTRATORS]                
AS               
select '' USER_NAME, '' User_Full_Name      
 union      
 Select au.USER_NAME, AU.User_Full_Name from   
 AIMS_EWS_ADMIN_MAILBOX aur    
 inner join AIMS_USERS AU on  AU.User_Name = aur.OPERATOR_MAILBOX_USER_NAME  
 union      
 select '<All Workbaskets>' USER_NAME, '<All Workbaskets>' User_Full_Name      
 order by 1
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_LIMITATION_CODE_VALUE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_GET_LIMITATION_CODE_VALUE]  
 @LIMITATION_CODE VARCHAR(50) 
AS  
BEGIN  
 SELECT * FROM AIMS_LIMITATION WHERE LIMITATION_CD = @LIMITATION_CODE  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_UNREAD_MAILS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_GET_UNREAD_MAILS]                 
 @MailBoxID VARCHAR(30) = '',              
 @UserCurrentlyLoggedOn Varchar(50) = '',      
 @MailSearchKeyword varchar(50)             
       
AS                 
BEGIN              
 DECLARE @vSQL nvarchar(4000), @sOrderBy varchar(255)         
       
 SET @vSQL = 'SELECT   * ' +        
  ' FROM AIMS_EWS_EMAILS ' +                 
    ' WHERE        ' +      
  ' MAILBOX_ID = '+ @MailBoxID +' AND ' +      
  ' EMAIL_INDEXED_YN = ''N'' AND ' +      
  ' EMAIL_DELETED_YN = ''N'' AND ' +      
  ' EMAIL_PENDED_YN = ''N'' AND ' +      
  ' (EMAIL_LOCKED_BY is null or EMAIL_LOCKED_BY = '''' or EMAIL_LOCKED_BY = '''+@UserCurrentlyLoggedOn+''') '      
  IF(@MailSearchKeyword is not null)      
  BEGIN      
 IF (@MailSearchKeyword <> '')      
 BEGIN      
  SET @vSQL = @vSQL + ' AND EMAIL_SUBJECT LIKE ''%'+ @MailSearchKeyword +'%'''      
 END      
  END      
 Set @sOrderBy = ' ORDER BY email_received_dttm DESC'      
       
 SET @vSQL = @vSQL + @sOrderBy      
 
 set @vSQL = 'SELECT  top 10   *  FROM AIMS_EWS_EMAILS  WHERE          MAILBOX_ID = 2 AND  (EMAIL_INDEXED_YN = ''N'')'

insert into aims_debugging values('Mailbox Emails' , @vSQL, GETDATE())  
  
  
EXECUTE  sp_executesql  @vSQL      
       
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_WORKBASKET_AUDIT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_GET_WORKBASKET_AUDIT]               
 @USER_ID VARCHAR(50)                
AS                 
BEGIN              
DECLARE @vSQL NVARCHAR(3000)          
            
 SET @vSQL = 'SELECT   
 e.patient_file_no,     
 d.EMAIL_SUBJECT,     
 d.EMAIL_SENT_FROM_NAME,    
 d.EMAIL_RECEIVED_DTTM,    
 WORK_ITEM_PROCESSED_DTTM,    
 USER_FULL_NAME,    
 C.PATIENT_ID FROM ' +          
  ' AIMS_EWS_OPERATOR_MAILBOX A ' +          
   ' INNER JOIN AIMS_EWS_OPERATOR_MAILS B ON B.OPERATOR_MAILBOX_ID = A.OPERATOR_MAILBOX_ID ' +          
   ' INNER JOIN AIMS_EWS_PATIENT_ENQUIRY C ON C.PATIENT_ENQUIRY_ID = B.PATIENT_ENQUIRY_ID ' +           
   ' INNER JOIN AIMS_EWS_EMAILS D ON D.EMAIL_ID = C.EMAIL_ID ' +          
   ' INNER JOIN AIMS_PATIENT E ON E.PATIENT_ID = C.PATIENT_ID ' +             
   ' left outer JOIN AIMS_USERS F ON F.USER_NAME = b.WORK_ITEM_PROCESSED_BY ' +         
 ' WHERE '          
 IF(@USER_ID <> '<All Workbaskets>')          
 BEGIN          
 SET @vSQL = @vSQL + ' A.OPERATOR_MAILBOX_USER_NAME = ''' + @USER_ID + ''' AND '          
 END          
 ELSE          
 BEGIN          
 SET @vSQL = @vSQL + ' A.OPERATOR_MAILBOX_USER_NAME in ( ' +          
  ' Select au.USER_NAME from AIMS_ROLES AR ' +          
  ' inner join AIMS_USER_ROLE AUR on AR.ROLE_CD = AUR.ROLE_CD ' +          
     ' inner join AIMS_USERS AU on AUR.USER_NAME = AU.User_Name ' +          
  ' where AR.ROLE_CD = ''Operations'') AND '          
 END          
 SET @vSQL = @vSQL + ' (B.WORK_ITEM_PROCESSED_YN = ''Y'') and B.WORK_ITEM_PROCESSED_DTTM >= GETDATE()-31 ' +          
 ' ORDER BY WORK_ITEM_PROCESSED_DTTM desc ,C.PATIENT_ID '          
     insert into AIMS_DEBUGGING values('OPS Audit Workbasket Fetch',@vSQL,GETDATE())
 EXECUTE  sp_executesql  @vSQL           
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_COUNTRY_CHECK]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_COUNTRY_CHECK]      
 @CountryDesc varchar(50) = ''  
as     
 Select * from AIMS_COUNTRY WHERE COUNTRY_NAME = @CountryDesc
GO
/****** Object:  StoredProcedure [dbo].[AIMS_CALENDER_APPOINTMENT_ADD]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_CALENDER_APPOINTMENT_ADD]           
 @CalenderAppointmentId varchar(250) output,            
 @AppointmentSubject  varchar(1050),          
 @AppointmentAddress varchar(250),          
 @AppointmentDate varchar(250),          
 @AppointmentTimeHour varchar(250),          
 @AppointmentTimeMinute varchar(250),          
 @AppointmentReminderYN varchar(250),          
 @AppointmentReminderPeriod varchar(250),          
 @AppointmentTransportRequiredYN varchar(250),          
 @AppointmentNote  varchar(300),          
 @AppointmentTime  datetime     
 AS          
BEGIN          
 DECLARE @ACTION VARCHAR(50), @AppointmentLabel int    
           
 if @AppointmentTransportRequiredYN = 'Y'          
 begin           
 SET @AppointmentLabel = 6    
 end          
           
 if @AppointmentReminderYN ='Y'    
 begin    
 SET @AppointmentReminderPeriod = '<Reminders>  <Reminder AlertTime="08/14/2016 23:55:00" TimeBeforeStart="00:05:00" />  </Reminders>'    
 end    
 else    
 begin    
 SET @AppointmentReminderPeriod = ''    
 end    
 IF (@CalenderAppointmentId IS NULL or @CalenderAppointmentId = '')                
  BEGIN            
   SET @ACTION = 'ADD'            
 INSERT INTO appointments     
    (type,     
     startdate,     
     enddate,     
     allday,     
     subject,     
     location,     
     description,     
     status,     
     label,     
     reminderinfo)     
 VALUES      ( 0,     
      @AppointmentTime,     
      @AppointmentTime,     
      0,     
      @AppointmentSubject ,     
      @AppointmentAddress,     
      @AppointmentNote ,     
      7,     
      @AppointmentLabel,     
      @AppointmentReminderPeriod)         
              
  SET @CalenderAppointmentId = IDENT_CURRENT('Appointments')                
  END          
 ELSE          
  BEGIN          
  SET @ACTION = 'UPDATE'            
  UPDATE appointments SET           
        startdate = @AppointmentTime,     
     enddate =@AppointmentTime,     
     subject=@AppointmentSubject,     
     location=@AppointmentAddress,     
     description=@AppointmentNote,     
     label = @AppointmentLabel,     
     reminderinfo = @AppointmentReminderPeriod    
   WHERE uniqueid = @CalenderAppointmentId          
  END          
END
GO
/****** Object:  Table [dbo].[AIMS_ADDRESS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ADDRESS](
	[ADDRESS_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ADDRESS_TYPE_ID] [numeric](18, 0) NULL,
	[ADDRESS1] [varchar](50) NULL,
	[ADDRESS2] [varchar](50) NULL,
	[ADDRESS3] [varchar](50) NULL,
	[ADDRESS4] [varchar](50) NULL,
	[ADDRESS5] [varchar](50) NULL,
	[POSTAL_CODE] [varchar](50) NULL,
	[COUNTRY_ID] [numeric](18, 0) NULL,
	[DEFAULT_YN] [varchar](1) NULL,
	[ACTIVE_YN] [varchar](50) NULL,
	[PROVINCE] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[ADDRESS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_ADD_SERVICE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_ADD_SERVICE]    
	@NewServiceDesc varchar(50) = ''
as   
 
 	DECLARE @LastError INT, @PatientID int, @NoteTypeID int 
 	SET @LastError = 0  

	INSERT INTO AIMS_SUPPLIER_TYPES
	VALUES(@NewServiceDesc)
GO
/****** Object:  StoredProcedure [dbo].[AIMS_ADD_COUNTRY]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_ADD_COUNTRY]      
 @NewCountryDesc varchar(50) = ''  
as     
   
  DECLARE @LastError INT, @PatientID int, @NoteTypeID int   
  SET @LastError = 0    
  
 INSERT INTO AIMS_COUNTRY  
 VALUES(@NewCountryDesc)
GO
/****** Object:  Table [dbo].[INDUSTRYRATES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INDUSTRYRATES](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[IndustryClassesServicesID] [varchar](50) NULL,
	[RATE] [varchar](50) NULL,
	[YEARID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_INDUSTRYRATES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SUPPLIER_TYPE_COST]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_SUPPLIER_TYPE_COST]        
 @SupplierTypeID numeric
as       
 Select * from AIMS_SERVICE_COST_LIMIT WHERE SUPPLIER_TYPE_ID =  @SupplierTypeID
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SERVICE_CHECK]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_SERVICE_CHECK]    
	@ServiceDesc varchar(50) = ''
as   
	Select * from AIMS_SUPPLIER_TYPES WHERE SUPPLIER_TYPE_DESC = @ServiceDesc
GO
/****** Object:  StoredProcedure [dbo].[AIMS_USER_ADD]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*  Return Values of the procedure 	*/
------------------------------------------
/*  -1 : Error 				*/
/*  0  : Successful		        */

CREATE PROCEDURE [dbo].[AIMS_USER_ADD]  
	@UserName varchar(50) = '',
	@UserFullName varchar(50) = '',
	@UserPassword varchar(50) = '',
	@UserEmail varchar(50) = '',
	@UserPhone varchar(50),
	@UserFax varchar(50),
	@UserActiveYN varchar(1),
	@SignedOnUser varchar(50)

as 
	BEGIN TRANSACTION addUsers

	DECLARE @LastError INT
	SET @LastError = 0

	insert into aims_users(
		USER_NAME, USER_FULL_NAME, 
		USER_PASSWORD, USER_EMAIL, 
		USER_PHONE, USER_FAX, USER_ACTIVE_YN) values(
		@UserName, @UserFullName, @UserPassword, @UserEmail, @UserPhone, @UserFax, @UserActiveYN)

	if (@@ERROR <> 0) 
	begin
		SET @LastError = @@ERROR
		insert into aims_debugging values ('Step 1','AIMS Users Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION
		Return (-1)
	end
	else
	begin	
	insert into aims_a_users (
		MODIFIED_USER, 	MODIFIED_ACTION,
		MODIFIED_DATE, 	User_Name,
		User_Full_Name,	User_Password	,
		User_Email, User_Phone,
		User_Fax, User_Active_YN) values(
		@SignedOnUser, 'ADD', 
		GETDATE(), @UserName,
		@UserFullName, @UserPassword,
		@UserEmail, @UserPhone, 
		@UserFax,@UserActiveYN)
	end		

	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','AIMS Users audit Saving Completed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addUsers
	end
	else
	begin	
		COMMIT TRANSACTION addUsers
	end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_USER_PASSWORD_SAVE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_USER_PASSWORD_SAVE]
	@UserName  varchar(20),
	@PassWord  varchar(50),
	@PasswordHint  varchar(250),
	@PasswordHintAnswer  varchar(250)
AS
BEGIN
	update aims_users set 
		user_password = @PassWord, 	
		password_setup = 'Y',
		password_hint = @PasswordHint,
		password_hint_answer = @PasswordHintAnswer
	where USER_NAME = @UserName
END
GO
/****** Object:  UserDefinedFunction [dbo].[chk_nwd]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[chk_nwd]   
(  
 @p_date date  
)  
RETURNS numeric  
AS  
BEGIN  
 DECLARE @v_ret numeric  
 select @v_ret = (count(distinct nwd_date)) from    aims_non_working_days where  nwd_date = @p_date;  
   
 IF (@@ERROR <> 0)                                                
 BEGIN              
  SET @v_ret = 0                           
 END                                                                      
 RETURN @v_ret  
END
GO
/****** Object:  StoredProcedure [dbo].[CC_PRAKTISYNE_IMPORT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CC_PRAKTISYNE_IMPORT] 
	@vSQL 			varchar(2000),
	@PracticeNo			varchar(50),
	@PracticeTypeCD		varchar(50),
	@PracticeTypeSubCD		varchar(50),
	@PractitionerTitle		varchar(50),
	@PracticeName			varchar(50),
	@Address1			varchar(50),
	@Address2			varchar(50),
	@Address3			varchar(50),
	@Address4			varchar(50),
	@PostalCode			varchar(50),
	@PracticeProvince		varchar(50)	
AS	
	DECLARE 
		@TitleID 			int,
		@PracticeAddressID 		int,
		@PracticeBankDetailID		int,
		@rowCountCheck		int

	DECLARE Practice_Cursor CURSOR FOR
	select prac_prac, prac_discipline, prac_province, prac_title from PRAKTISYNE order by 1

	OPEN Practice_Cursor
	FETCH NEXT FROM Practice_Cursor into @PracticeNo, @PracticeTypeCD, @PracticeProvince, @PractitionerTitle, @Address1, @Address2, @Address3, @Address4, @PostalCode
	WHILE @@FETCH_STATUS = 0
		BEGIN
			-- Process the practise within a transaction
			BEGIN TRANSACTION addPractice
	
			-- Check if this practice-no already in the table
			select @rowCountCheck = count(*) from medicalserviceproviders where practice_no = @PracticeNo;

			-- If the practice-no is not in the MedicalServiceProviders table then insert 
			if @rowCountCheck <= 0 
			begin
				-- save the title
				set @TitleID  = IDENT_CURRENT('TITLE')

				-- save the address
				set @PracticeAddressID  = IDENT_CURRENT('ADDRESS')

				-- save the banking details
				set @PracticeBankDetailID  = IDENT_CURRENT('BANK')

				select @rowCountCheck = count(*) from medicalserviceproviders where practice_no = @PracticeNo;									
			end
			else
			begin
				FETCH NEXT FROM Practice_Cursor into @PracticeNo, @PracticeTypeCD, @PracticeProvince, @PractitionerTitle, @Address1, @Address2, @Address3, @Address4, @PostalCode
			end

			if (@@ERROR <> 0)
			begin
				ROLLBACK TRANSACTION addPractice
			end
			else
			begin	
				COMMIT TRANSACTION addPractice
			end

		END
	CLOSE Practice_Cursor
	DEALLOCATE Practice_Cursor
GO
/****** Object:  Table [dbo].[AIMS_USER_ROLE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_USER_ROLE](
	[USER_NAME] [varchar](50) NULL,
	[ROLE_CD] [varchar](50) NULL,
 CONSTRAINT [IX_AIMS_USER_ROLE] UNIQUE NONCLUSTERED 
(
	[USER_NAME] ASC,
	[ROLE_CD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_USER_RESTRICTIONS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_USER_RESTRICTIONS]  
    @UserName varchar(50) = ''
as 	
	select * 
	from 
		aims_user_role 
		inner join aims_roles			ON aims_user_role.role_cd = aims_roles.role_cd 
		inner join aims_role_restriction 		ON aims_role_restriction.role_cd = aims_user_role.role_cd
		inner join AIMS_RESTRICTIONS		ON AIMS_RESTRICTIONS.restriction_id = aims_role_restriction.restriction_id
	where 
		aims_user_role.user_name = @UserName
GO
/****** Object:  UserDefinedFunction [dbo].[getduedate]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getduedate]   
(  
 @p_filereceiveddate date  
)  
RETURNS date  
AS  
BEGIN  
 DECLARE @v_ret date

 Declare @checknwd numeric, @NextDay datetime, @3DaysLoop numeric , @dueDateCheck datetime   
 SET @dueDateCheck = @p_filereceiveddate    
     
 SET @3DaysLoop = 1;    
 while @3DaysLoop < 6   
 begin    
  SELECT  @dueDateCheck = DATEADD(day,1,@dueDateCheck)     
  SET @checknwd = dbo.chk_nwd(@dueDateCheck)    
  set @checknwd =0
  if @checknwd  > 0     
  begin    
   SELECT  @dueDateCheck = DATEADD(day,1,@dueDateCheck)     
  end    
  else    
  begin    
   SET @3DaysLoop = @3DaysLoop + 1    
  end      
 end  
                        
 RETURN @dueDateCheck  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_USER_MENU_RESTRICTIONS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_USER_MENU_RESTRICTIONS]    
    @UserName varchar(50) = ''  
as    
 SELECT *   
 FROM  
  aims_user_role   
  inner join aims_roles   ON aims_user_role.role_cd = aims_roles.role_cd   
  inner join aims_role_restriction   ON aims_role_restriction.role_cd = aims_user_role.role_cd  
  inner join AIMS_RESTRICTIONS  ON AIMS_RESTRICTIONS.restriction_id = aims_role_restriction.restriction_id  
 WHERE  
  aims_user_role.user_name = @UserName AND  
  AIMS_RESTRICTIONS.restriction_desc IN   
  ('View User Maintenance',  
  'View Patients Files',  
  'View Guarantors',  
  'View Suppliers',  
  'View Payments',  
  'View Reports',  
  'View Invoices', 
  'View Dashboard')
GO
/****** Object:  StoredProcedure [dbo].[AIMS_USER_GOP_LIMIT_CHECK]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_USER_GOP_LIMIT_CHECK]  
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
GO
/****** Object:  StoredProcedure [dbo].[AIMS_ADDRESS_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_ADDRESS_GET]  
@AddressID varchar(50)
as 
	Select * from aims_address where address_id = @AddressID
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EMAIL_FROM_ADDRESSES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[AIMS_EMAIL_FROM_ADDRESSES]   
AS  
BEGIN  
 SELECT DISTINCT   
  EMAIL_SENT_FROM_ADDRESS FROM   
   AIMS_EWS_EMAILS   
 WHERE EMAIL_RECEIVED_DTTM > = GETDATE() - 90 order by 1 desc  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EMBASSY_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE pROCEDURE [dbo].[AIMS_EMBASSY_GET]            
    @EmbassyID varchar(50)          
as           
SELECT * FROM AIMS_EMBASSies A      
left outer join aims_address B on b.address_id = a.embassy_address_id      
where a.embassy_id = @EmbassyID
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EMBASSY_ADD]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[AIMS_EMBASSY_ADD]      
 @EmbassyID varchar(50) output,      
 @EmbassyName varchar(50),      
 @EmbassyTelNo varchar(50),      
 @EmbassyFaxNo varchar(50),      
 @EmbassyAdd1 varchar(50),      
 @EmbassyAdd2 varchar(50),      
 @EmbassyAdd3 varchar(50),      
 @EmbassyAdd4 varchar(50),      
 @EmbassyAdd5 varchar(50),      
 @EmbassyAddressCountry varchar(50),    
 @EmbassyContactPerson varchar(50),    
 @EMBASSY_ACTIVE_YN varchar(22)    
AS      
BEGIN      
 DECLARE @AddressID INT     
       
 IF (@EmbassyID IS NULL or @EmbassyID = '')      
 BEGIN      
  INSERT INTO AIMS_ADDRESS (      
   ADDRESS_TYPE_ID,      
   ADDRESS1,      
   ADDRESS2,      
   ADDRESS3,      
   ADDRESS4,      
   ADDRESS5,      
   COUNTRY_ID,      
   ACTIVE_YN      
  )VALUES(      
   1,      
   @EmbassyAdd1,      
   @EmbassyAdd2,      
   @EmbassyAdd3,      
   @EmbassyAdd4,      
   @EmbassyAdd5,      
   @EmbassyAddressCountry,      
   'Y'    
  )      
        
  SET @AddressID  = IDENT_CURRENT('AIMS_ADDRESS');      
        
  INSERT INTO AIMS_EMBASSIES(      
 EMBASSY_NAME,                                                                                                                                                                                                                                                 
  
       
 EMBASSY_TEL_NO,                                         
 EMBASSY_FAX_NO ,                                        
 EMBASSY_ADDRESS_ID,    
 EMBASSY_CONTACT_PERSON,    
 EMBASSY_ACTIVE_YN    
  )VALUES(      
 @EmbassyName,      
 @EmbassyTelNo,    
 @EmbassyFaxNo,    
 @AddressID,    
 @EmbassyContactPerson,    
 @EMBASSY_ACTIVE_YN    
  )      
        
  SET @EmbassyID = IDENT_CURRENT('AIMS_EMBASSIES')      
 END      
 ELSE      
 BEGIN      
  SELECT @AddressID = EMBASSY_ADDRESS_ID from AIMS_EMBASSIES where embassy_id    = @EmbassyID    
        
  UPDATE AIMS_ADDRESS SET       
   ADDRESS1 = @EmbassyAdd1,      
   ADDRESS2 = @EmbassyAdd2,      
   ADDRESS3 = @EmbassyAdd3,      
   ADDRESS4 = @EmbassyAdd4,    
   ADDRESS5 = @EmbassyAdd5,    
   COUNTRY_ID = @EmbassyAddressCountry    
  WHERE ADDRESS_ID = @AddressID      
        
  UPDATE AIMS_EMBASSIES SET       
   EMBASSY_NAME     = @EmbassyName,      
   EMBASSY_TEL_NO = @EmbassyTelNo ,    
   EMBASSY_FAX_NO = @EmbassyFaxNo,                                        
   EMBASSY_CONTACT_PERSON = @EmbassyContactPerson,    
   EMBASSY_ACTIVE_YN = @EMBASSY_ACTIVE_YN    
  WHERE embassy_id = @EmbassyID      
 END      
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_ALL_RESTRICTIONS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_ALL_RESTRICTIONS]    
    @UserName varchar(50) = ''  
as    
/*
 SELECT *   
 FROM   
   aims_role_restriction     
  inner join AIMS_RESTRICTIONS  ON AIMS_RESTRICTIONS.restriction_id = aims_role_restriction.restriction_id  
  inner join aims_user_role  ON aims_user_role.role_cd = aims_role_restriction.role_cd  
  WHERE aims_role_restriction.role_cd ='SysAdmin'  and   
  aims_user_role.USER_NAME = @UserName
  */
  SELECT *
  FROM aims_user_role a, aims_role_restriction b, aims_restrictions c
 WHERE a.user_name = @UserName
   AND b.role_cd = a.role_cd
   AND c.restriction_id = b.restriction_id;
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_DELATE_EMAIL_INFO]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_DELATE_EMAIL_INFO]  
 @EMAIL_ID VARCHAR(50)  
AS  
BEGIN  
 --DELETE FROM AIMS_EWS_EMAIL_ATTACHMENT WHERE EMAIL_ID = @EMAIL_ID  
-- DELETE FROM AIMS_EWS_EMAILS WHERE EMAIL_ID = @EMAIL_ID  
update aims_ews_emails set email_deleted_yn = 'Y'  WHERE EMAIL_ID = @EMAIL_ID 
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_PATIENT_EMAIL_INDEXED]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_PATIENT_EMAIL_INDEXED]    
  @EMAIL_ID VARCHAR(50)    
AS    
BEGIN    
  
Update AIMS_EWS_EMAILS set EMAIL_INDEXED_YN = 'Y' , EMAIL_LOCKED_BY = '' where EMAIL_ID = @EMAIL_ID  
     
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_FILE_OPERATORS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_GET_FILE_OPERATORS]            
AS           
select '' USER_NAME, '' User_Full_Name  
 union  
 Select au.USER_NAME, AU.User_Full_Name from AIMS_ROLES   AR        
 inner join AIMS_USER_ROLE AUR on AR.ROLE_CD = AUR.ROLE_CD        
 inner join AIMS_USERS AU on AUR.USER_NAME = AU.User_Name         
 where AR.ROLE_CD = 'Operations' 
 union  
 select '<All Workbaskets>' USER_NAME, '<All Workbaskets>' User_Full_Name  
 order by 1
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_FILE_ADMINISTRATORS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_GET_FILE_ADMINISTRATORS]    
as   
 Select * from AIMS_ROLES   AR
 inner join AIMS_USER_ROLE AUR on AR.ROLE_CD = AUR.ROLE_CD
 inner join AIMS_USERS AU on AUR.USER_NAME = AU.User_Name 
 where AR.ROLE_CD = 'ADMIN'
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_EMAIL_SENDERS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_GET_EMAIL_SENDERS]  
@CoOrdinator varchar(50) = null      
AS      
BEGIN    
DECLARE @vSQL NVARCHAR(4000)  ,@Mailboxes VARCHAR(50), @UserRole VARCHAR(50), @FIRSTTIME int  
if @CoOrdinator is null  
BEGIN  
 SELECT * FROM       
  AIMS_EWS_EMAIL_SENDER ORDER BY 2      
END  
ELSE  
BEGIN  
 SET @FIRSTTIME = 0  
 DECLARE contact_cursor CURSOR FOR    
  select A.ROLE_CD from AIMS_USER_ROLE a   
  where a.User_Name = @CoOrdinator  
    
 OPEN contact_cursor;    
      
 FETCH NEXT FROM contact_cursor into @UserRole;    
 SET  @Mailboxes = ''  
 set @vSQL = ''  
 WHILE @@FETCH_STATUS = 0    
 BEGIN  
 if @FIRSTTIME = 0  
 begin  
 SET @vSQL = @vSQL + 'select * from AIMS_EWS_EMAIL_SENDER where roles like ''%'+@UserRole+'%'''  
 set @FIRSTTIME = 1  
 end    
 else  
 begin  
 SET @vSQL = @vSQL + 'union select * from AIMS_EWS_EMAIL_SENDER where roles like ''%'+@UserRole+'%'''  
 end  
     
   FETCH NEXT FROM contact_cursor into @UserRole;    
 END    
     
 CLOSE contact_cursor;    
 DEALLOCATE contact_cursor;   
   
 if  (@vSQL != '')  
 begin  
  insert into AIMS_DEBUGGING values ('FROM EMAIL ADDRESS',@vSQL, GETDATE())  
  EXECUTE  sp_executesql  @vSQL      
 END  
END  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_DUE_DATE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_GET_DUE_DATE]        
@FileReceivedDate datetime  ,      
@dueDateCheck datetime output      
as        
begin        
 Declare @checknwd numeric, @NextDay datetime, @3DaysLoop numeric        
 SET @dueDateCheck = @FileReceivedDate        
         
 SET @3DaysLoop = 1;        
 while @3DaysLoop < 6        
 begin        
  SELECT  @dueDateCheck = DATEADD(day,1,@dueDateCheck)         
  SET @checknwd = dbo.chk_nwd(@dueDateCheck)        
  SET @checknwd = 0 
  --If next-day falls into non-working-day        
  -- Action:        
  -- 1. Add an additional date to the due Date        
  if @checknwd  > 0         
  begin        
   SELECT  @dueDateCheck = DATEADD(day,1,@dueDateCheck)         
  end        
  else        
  begin        
   SET @3DaysLoop = @3DaysLoop + 1        
  end          
 end         
         
 /*        
 while @3DaysLoop <=3        
 begin        
  SET @checknwd = dbo.chk_nwd(@dueDateCheck)        
  insert into AIMS_DEBUGGING values(@checknwd, @dueDateCheck, getdate())        
  if @checknwd  > 0         
  begin        
   SELECT  @dueDateCheck = DATEADD(day,1,@dueDateCheck)         
   --SET @3DaysLoop = @3DaysLoop + 1        
  end        
  else        
  begin        
   SET @dueDateCheck = DATEADD(day,1,@dueDateCheck)         
   SET @3DaysLoop = @3DaysLoop + 1        
  end        
  --insert into AIMS_DEBUGGING values(@3DaysLoop, @dueDateCheck, getdate())        
 end        
 */        
 SELECT @dueDateCheck "DUE_DATE"        
end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_MAILBOX_POD_INFO]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[AIMS_EWS_MAILBOX_POD_INFO]    
  @EMAIL_ID VARCHAR(30)    
 AS    
 BEGIN    
 SELECT *  
   FROM aims_ews_emails a INNER JOIN aims_ews_mailboxes b  
     ON b.mailbox_id = a.mailbox_id  
  WHERE a.email_id = @EMAIL_ID  
  ORDER by 1    
 END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_LOCK_EMAIL]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_LOCK_EMAIL]      
 @EMAIL_ID INT,      
 @UserLoggedOn VARCHAR(50),  
 @LockEmailYN varchar(1) = 'Y',
 @EmailReadYN varchar(1) = 'N'
AS      
BEGIN      
 IF(@LockEmailYN = 'Y')  
 BEGIN  
  UPDATE AIMS_EWS_EMAILS SET EMAIL_LOCKED_BY = @UserLoggedOn WHERE EMAIL_ID= @EMAIL_ID      
 END  
 ELSE  
 BEGIN  
  UPDATE AIMS_EWS_EMAILS SET EMAIL_LOCKED_BY = '' WHERE EMAIL_ID= @EMAIL_ID      
 END
 
 IF(@EmailReadYN = 'Y')
 BEGIN
	UPDATE AIMS_EWS_EMAILS SET EMAIL_UNREAD_YN = 'Y' WHERE EMAIL_ID = @EMAIL_ID
 END
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_EMAIL_DELETE]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_EMAIL_DELETE]    
 @EMAIL_ID varchar(50)    
as    
begin    
 --DELETE FROM AIMS_EWS_EMAIL_ATTACHMENT WHERE EMAIL_ID = @EMAIL_ID    
 --DELETE FROM AIMS_EWS_EMAILS WHERE EMAIL_ID = @EMAIL_ID    
 UPDATE AIMS_EWS_EMAILS SET EMAIL_DELETED_YN = 'Y' WHERE EMAIL_ID = @EMAIL_ID    
end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_MAILBOXES]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_EWS_GET_MAILBOXES]      
@LoggedInUser varchar(50) = null     
AS  
BEGIN   
declare @vSQL nvarchar(4000), @AccessId numeric, @Mailboxes varchar(50)  

  insert into AIMS_DEBUGGING values ('MAILBOXES USERs333',@LoggedInUser, GETDATE())  
if @LoggedInUser is null   or  @LoggedInUser = ''
begin  
  insert into AIMS_DEBUGGING values ('MAILBOXES USERs','1111111', GETDATE())  
	SET @vSQL = 'SELECT * FROM AIMS_EWS_MAILBOXES WHERE MAILBOX_ACTIVE_YN = ''Y''  ORDER BY MAILBOX_PROCESSING_SEQ'
	  EXECUTE  sp_executesql  @vSQL    
end  
else  
begin 
  insert into AIMS_DEBUGGING values ('MAILBOXES USERs','222222', GETDATE())   
 SET @vSQL = 'SELECT * FROM AIMS_EWS_MAILBOXES WHERE MAILBOX_ACTIVE_YN = ''Y'' AND MAILBOX_NAME IN( '  
 DECLARE contact_cursor CURSOR FOR    
  select c.RESTRICTION_ID from AIMS_USERS a   
  inner join AIMS_USER_ROLE b on b.USER_NAME = a.User_Name  
  inner join AIMS_ROLE_RESTRICTION c on c.ROLE_CD = b.ROLE_CD and c.RESTRICTION_ID in (97, 98)  
  where a.User_Name = @LoggedInUser  
    
 OPEN contact_cursor;    
      
 FETCH NEXT FROM contact_cursor into @AccessId;    
 SET  @Mailboxes = ''  
 WHILE @@FETCH_STATUS = 0    
 BEGIN    
    if (@AccessId = 97)  
    begin  
  SET @Mailboxes = cast(@Mailboxes as varchar(50)) + '''Admin'','  
    end  
    if (@AccessId = 98)  
    begin  
  SET @Mailboxes = cast(@Mailboxes as varchar(50)) + '''Operations'','  
    end  
    FETCH NEXT FROM contact_cursor into @AccessId;    
 END    
     
 CLOSE contact_cursor;    
 DEALLOCATE contact_cursor;   
   
 if  (@Mailboxes != '')  
 begin  
  SET @Mailboxes = SUBSTRING(@Mailboxes,1,len(@Mailboxes)-1)  
  SET @vSQL = @vSQL + @Mailboxes + ')'  
  insert into AIMS_DEBUGGING values ('MAILBOXES USERs',@vSQL, GETDATE())  
  
 END  
end  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_EMAIL_INFO]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_EWS_GET_EMAIL_INFO]  
 @EMAIL_ID Int  
AS  
BEGIN  
 SET NOCOUNT ON;  
 Select A.*, B.User_Full_Name from AIMS_EWS_EMAILS A  
 left outer join AIMS_USERS B on B.User_Name = A.EMAIL_LOCKED_BY  
 where EMAIL_ID = @EMAIL_ID  
END
GO
/****** Object:  Table [dbo].[AIMS_EWS_EMAIL_ATTACHMENT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_EMAIL_ATTACHMENT](
	[ATTACHMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[EMAIL_ID] [numeric](18, 0) NOT NULL,
	[ATTACHMENT_LOCATION] [varchar](4000) NOT NULL,
	[ATTACHMENT_FILE_TYPE_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_EMAIL_ATTACHMENT] PRIMARY KEY CLUSTERED 
(
	[ATTACHMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_EWS_EMAIL_ATTACHMENT] ON [dbo].[AIMS_EWS_EMAIL_ATTACHMENT] 
(
	[ATTACHMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_EWS_EMAIL_ATTACHMENT_1] ON [dbo].[AIMS_EWS_EMAIL_ATTACHMENT] 
(
	[ATTACHMENT_ID] ASC,
	[EMAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_ADD_EMAIL_INFO]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_EWS_ADD_EMAIL_INFO]        
 @EMAIL_ID     int output,        
 @EMAIL_UNIQUE_ID   varchar(4000),        
 @EMAIL_SUBJECT    varchar(500),        
 @EMAIL_RECEIVED_DTTM  varchar(500),        
 @EMAIL_SENT_FROM_NAME  varchar(500),        
 @EMAIL_SENT_FROM_ADDRESS varchar(500),        
 @EMAIL_SENT_TO    varchar(500),        
 @MAILBOX_ID     int,        
 @EMAIL_GUID     varchar(500),        
 @EMAIL_SENT_TO_CC     varchar(500)    
AS        
BEGIN        
        
 INSERT INTO AIMS_EWS_EMAILS(EMAIL_UNIQUE_ID,        
   EMAIL_GUID,        
   EMAIL_SUBJECT,        
   EMAIL_RECEIVED_DTTM,        
   EMAIL_SENT_FROM_NAME,        
   EMAIL_SENT_FROM_ADDRESS,        
   EMAIL_SENT_TO,        
   MAILBOX_ID, EMAIL_UNREAD_YN, EMAIL_SENT_TO_CC) VALUES(        
     @EMAIL_UNIQUE_ID ,        
     @EMAIL_GUID,        
     @EMAIL_SUBJECT ,        
     @EMAIL_RECEIVED_DTTM ,
     @EMAIL_SENT_FROM_NAME ,        
     @EMAIL_SENT_FROM_ADDRESS ,        
     @EMAIL_SENT_TO ,        
     @MAILBOX_ID,'N',  @EMAIL_SENT_TO_CC)        
             
 SET @EMAIL_ID = IDENT_CURRENT('AIMS_EWS_EMAILS')        
END
GO
/****** Object:  Table [dbo].[AIMS_GUARANTOR]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_GUARANTOR](
	[GUARANTOR_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[GUARANTOR_NAME] [varchar](1000) NULL,
	[GUARANTOR_PHONE_NO] [varchar](50) NULL,
	[GUARANTOR_FAX_NO] [varchar](50) NULL,
	[ADDRESS_ID] [numeric](18, 0) NULL,
	[GUARANTOR_EMAIL_ADDRESS] [char](50) NULL,
	[GUARANTOR_ACTIVE_YN] [varchar](1) NULL,
	[GUARANTOR_CONTACT_PERSON] [varchar](50) NULL,
	[CREATION_DTTM] [datetime] NULL,
 CONSTRAINT [PK_AIMS_GUARANTOR] PRIMARY KEY CLUSTERED 
(
	[GUARANTOR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX1_AIMS_GUARANTOR] ON [dbo].[AIMS_GUARANTOR] 
(
	[GUARANTOR_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_WORKBASKET_OPERATORS]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_GET_WORKBASKET_OPERATORS]                
AS               
select '' USER_NAME, '' User_Full_Name      
 union      
 Select au.USER_NAME, AU.User_Full_Name from   
 AIMS_EWS_OPERATOR_MAILBOX aur    
 inner join AIMS_USERS AU on  AU.User_Name       = aur.OPERATOR_MAILBOX_USER_NAME  
 union      
 select '<All Workbaskets>' USER_NAME, '<All Workbaskets>' User_Full_Name      
 order by 1
GO
/****** Object:  Table [dbo].[AIMS_SUPPLIER]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_SUPPLIER](
	[SUPPLIER_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[SUPPLIER_TYPE_ID] [numeric](18, 0) NULL,
	[TITLE_ID] [numeric](18, 0) NULL,
	[SUPPLIER_NAME] [varchar](255) NULL,
	[ADDRESS_ID] [numeric](18, 0) NULL,
	[SUPPLIER_EMAIL_ADDRESS] [varchar](50) NULL,
	[SUPPLIER_PHONE_NO] [varchar](50) NULL,
	[SUPPLIER_FAX_NO] [varchar](50) NULL,
	[SUPPLIER_MOBILE_NO] [varchar](50) NULL,
	[SUPPLIER_ACTIVE_YN] [varchar](1) NULL,
	[SUPPLIER_ACCOUNT_NO] [varchar](50) NULL,
	[SUPPLIER_CONTACT_NAME] [varchar](255) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[DOCTOR_SUPPLIER_YN] [varchar](1) NULL,
	[DOCTOR_NAME_INITIALS] [varchar](50) NULL,
	[DOCTOR_SURNAME] [varchar](50) NULL,
	[ADMIN_NAME] [varchar](50) NULL,
	[ADMIN_TEL_PHONE] [varchar](50) NULL,
	[ADMIN_FAX] [varchar](50) NULL,
	[ADMIN_EMAIL] [varchar](50) NULL,
	[ADMIN_CELL] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_SUPPLIER] PRIMARY KEY CLUSTERED 
(
	[SUPPLIER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_MEDICAL_TREATMENT]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_MEDICAL_TREATMENT](
	[MEDICAL_TREATMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[SUPPLIER_ID] [numeric](18, 0) NULL,
	[SERVICE_ID] [numeric](18, 0) NULL,
	[TREATMENT_NOTES] [varchar](2000) NULL,
	[DATE_OF_TREATMENT] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_MEDICAL_TREATMENT] PRIMARY KEY CLUSTERED 
(
	[MEDICAL_TREATMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_HOSPITAL_SUPPLIERS_GET]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_HOSPITAL_SUPPLIERS_GET]  
as 
              Select supplier_id, supplier_name from aims_supplier
              where supplier_type_id in(select supplier_type_id from aims_supplier_types where supplier_type_desc in('Private Clinic','Hospital','Private Hospital')) order by supplier_name
GO
/****** Object:  StoredProcedure [dbo].[AIMS_HOSPITAL_SUPPLIER_GET_ALL]    Script Date: 05/11/2021 21:45:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_HOSPITAL_SUPPLIER_GET_ALL]  
as 
	SELECT   supplier_id, supplier_name
	    FROM aims_supplier
	   WHERE supplier_type_id IN (
	            SELECT supplier_type_id
	              FROM aims_supplier_types
	             WHERE supplier_type_desc IN
	                           ('Private Clinic', 'Hospital', 'Private Hospital'))
	ORDER BY supplier_name
GO
/****** Object:  View [dbo].[AIMS_GUARANTOR_VW]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AIMS_GUARANTOR_VW]
AS 
SELECT GUARANTOR_NAME,GUARANTOR_ID
FROM AIMS_GUARANTOR where GUARANTOR_NAME not in ('','<Add New Guarantor>')
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GUARANTOR_VERIFY]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_GUARANTOR_VERIFY]  
    @GuarantorName varchar(50) = ''
as 
	select * from aims_guarantor where guarantor_name = @GuarantorName
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GUARANTOR_UPDATE]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_GUARANTOR_UPDATE] 
	@GuarantorID int, 
	@GuarantorName    	varchar(50) = '',
	@GuarantorPhoneNo 	varchar(50) = '',
	@GuarantorFaxNo   	varchar(50) = '',
	@AddressTypeID		int,
	@Address1		varchar(50) = '',
	@Address2 		varchar(50) = '',
	@Address3 		varchar(50) = '',
	@Address4 		varchar(50) = '',
	@Address5 		varchar(50) = '',
	@PostalCode 		varchar(50) = '',
	@CountryID 		int,
	@GuarantorEmailAddress 	varchar(50) = '',
	@GuarantorActiveYN 	varchar(50),
	@UserSignedOn 		varchar(50)
as 
	BEGIN TRANSACTION updateGuarantor

	
	DECLARE @LastError INT, @GuarantorAddressID varchar(50), @sSQL nvarchar(4000), @AddressUpdate varchar(255)

	SET @LastError = 0
	select 	 @GuarantorAddressID  = address_id from aims_guarantor where guarantor_id = @GuarantorID

	SELECT @GuarantorAddressID = 
	CASE address_id
	WHEN NULL THEN  ' address_id is null'
	else 'address_id = ' + cast(address_id as varchar(50))
	END
	from aims_guarantor where guarantor_id = cast(@GuarantorID as varchar(40))

	insert into aims_debugging values ('Guarantor ID ',cast(@GuarantorID as varchar(30)), getdate())
	insert into aims_debugging values ('GuarantorAddressID ',cast(@GuarantorAddressID as varchar(30)), getdate())
	
	/* UPDATE ADDRESS INFORMATION */
	set @sSQL	= 'update aims_address ' +
			' set ADDRESS_TYPE_ID =  ' + CAST(@AddressTypeID as varchar(2)) + ', ' +
			' ADDRESS1 = ''' + @Address1 + ''', ADDRESS2 	= '''+ @Address2 + ''', ' +
			' ADDRESS3 = ''' + @Address3 + ''', ADDRESS4 	= '''+ @Address4 + ''', ' +
			' ADDRESS5 = ''' + @Address5 + ''', POSTAL_CODE 	= '''+ @PostalCode + ''', ' +
			' COUNTRY_ID = '+ CAST(@CountryID as varchar(2)) + ', DEFAULT_YN =''Y'', ACTIVE_YN = ''Y''' +
			' where address_id = (Select address_id from aims_guarantor where guarantor_id  = ' + cast(@GuarantorID as varchar(50)) + ')'
	
	insert into aims_debugging values ('Guarantor Address Update',@sSQL, getdate())
	EXECUTE  sp_executesql @sSQL

	if (@@ERROR <> 0) 
	begin
		insert into aims_debugging values ('Step 1','Address Table update Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())		
		SET @LastError = @@ERROR
		ROLLBACK TRANSACTION
		Return (-1)   
	end

	set @sSQL	= ' update aims_guarantor ' +
			' set 	GUARANTOR_NAME = ''' + @GuarantorName 	+ ''','  +
			' GUARANTOR_PHONE_NO = ''' + @GuarantorPhoneNo  + ''', GUARANTOR_FAX_NO = ''' + @GuarantorFaxNo + ''''+-- + @GuarantorAddressID + 
			',' +  'GUARANTOR_EMAIL_ADDRESS = ''' + @GuarantorEmailAddress + ''',' +
			' GUARANTOR_ACTIVE_YN = ''' + @GuarantorActiveYN + '''' + 
			' where guarantor_id   = ' + CAST(@GuarantorID  as varchar(50))

	EXECUTE  sp_executesql  @sSQL

	if (@@ERROR <> 0) 
	begin
		SET @LastError = @@ERROR
		insert into aims_debugging values ('Step 1','Patient Table update Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION
		Return (-1)
	end

	insert into AIMS_A_GUARANTOR(
			MODIFIED_USER,
			MODIFIED_ACTION,
			MODIFIED_DATE,
			GUARANTOR_ID,
			GUARANTOR_NAME,
			ADDRESS_ID,
			GUARANTOR_PHONE_NO,
			GUARANTOR_FAX_NO,
			GUARANTOR_EMAIL_ADDRESS,
			GUARANTOR_ACTIVE_YN) 
		Values(
			@UserSignedOn,
			'UPDATE',
			GETDATE(),
			CAST(IDENT_CURRENT('AIMS_GUARANTOR') as varchar(50)),
			@GuarantorName , CAST(@GuarantorAddressID as varchar(50)), 
			@GuarantorPhoneNo , @GuarantorFaxNo  ,
			@GuarantorEmailAddress , @GuarantorActiveYN)
		
	if (@@ERROR <> 0)
	begin	
		COMMIT TRANSACTION updateGuarantor
	end
	else	
	begin
		COMMIT TRANSACTION updateGuarantor
	end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_FILE_AUDIT_GET_NEW]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[AIMS_PATIENT_FILE_AUDIT_GET_NEW]                     
 @PATIENT_FILE_NO varchar(50)                   
AS                        
BEGIN                        
    
     select     
a.MODIFIED_DATE ,    
MODIFIED_USER,    
MODIFIED_ACTION,    
PATIENT_FILE_NO ,    
PATIENT_INITIALS ,    
PATIENT_FIRST_NAME ,    
PATIENT_MIDDLE_NAME ,    
PATIENT_LAST_NAME ,    
PATIENT_ID_NO ,    
PATIENT_HOME_TEL_NO ,    
PATIENT_WORK_TEL_NO ,    
PATIENT_FAX_NO ,    
PATIENT_MOBILE_NO ,    
PATIENT_EMAIL_ADDRESS ,    
GUARANTOR_REF_NO ,    
PATIENT_FILE_ACTIVE_YN ,    
PATIENT_NATIONALITY ,    
PATIENT_GUARANTOR_AMOUNT ,    
PATIENT_FILE_COURIER_YN ,    
PATIENT_ADMISSION_DATE ,    
PATIENT_DISCHARGE_DATE ,    
PATIENT_DIAGNOSIS ,    
a.CREATION_DTTM ,    
b.ADDRESS1,b.ADDRESS2,b.ADDRESS3, b.ADDRESS4,b.ADDRESS5, b.PROVINCE,    
PATIENT_EMERGENCY_CONTACT_NAME ,    
PATIENT_EMERGENCY_CONTACT_NO ,    
IN_PATIENT ,    
OUT_PATIENT ,    
FILE_COURIER_DATE ,    
CANCELLED ,    
COURIER_WAYBILL_NO ,    
GUARANTOR247NO ,    
GUARANTOR247EMAIL ,    
FILE_ASSIGNED_TO_USERID ,    
COURIER_RECEIPT_DATE ,    
LATE_LOG_YN ,    
LATE_LOG_DATE ,    
PENDING ,    
PEND_DATE ,    
FILE_OPERATOR_TO_USERID ,    
PATIENT_DATE_OF_BIRTH ,    
LAB_LIST_DATE ,    
AFTER_HOURS_FILE ,    
SENT_TO_ADMIN ,    
c.TITLE_DESC,    
d.GUARANTOR_NAME,    
e.SUPPLIER_NAME,     
j.GUARANTOR_NAME FLIGHT_GUARANTOR_NAME,    
f.EVACUATION_TYPE_DESC,     
g.RMR_TYPE_DESC,    
h.TRANSPORT_TYPE_DESC,    
i.REPAT_TYPE_DESC,    
k.ASSIST_TYPE_DESC,  
a.HIGH_COST  
from AIMS_a_PATIENT a    
left outer join AIMS_ADDRESS b on b.ADDRESS_ID = a.ADDRESS_ID    
left outer join AIMS_TITLE c on c.TITLE_ID = a.TITLE_ID    
left outer join AIMS_GUARANTOR d on d.GUARANTOR_ID = a.GUARANTOR_ID    
left outer join AIMS_SUPPLIER e on e.SUPPLIER_ID = a.SUPPLIER_ID    
left outer join AIMS_EVACUATION_TYPES f on f.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID    
left outer join AIMS_RMR_TYPES g on g.RMR_TYPE_ID = a.PATIENT_RMR_TYPE_ID    
left outer join AIMS_TRANSPORT_TYPE h on h.TRANSPORT_TYPE_ID = a.PATIENT_TRANSPORT_TYPE_ID    
left outer join AIMS_REPAT_TYPE i on i.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID    
left outer join AIMS_GUARANTOR j on j.GUARANTOR_ID = a.FLIGHT_GUARANTOR_ID    
left outer join AIMS_ASSIST_TYPE k on k.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID    
where a.PATIENT_FILE_NO = @PATIENT_FILE_NO    
order by 1 desc    
              
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_FILE_AUDIT_GET]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_FILE_AUDIT_GET]                      
 @PATIENT_FILE_NO varchar(50)                 
AS                      
BEGIN                      
  
     select   
a.MODIFIED_DATE ,  
MODIFIED_USER,  
MODIFIED_ACTION,  
PATIENT_FILE_NO ,  
PATIENT_INITIALS ,  
PATIENT_FIRST_NAME ,  
PATIENT_MIDDLE_NAME ,  
PATIENT_LAST_NAME ,  
PATIENT_ID_NO ,  
PATIENT_HOME_TEL_NO ,  
PATIENT_WORK_TEL_NO ,  
PATIENT_FAX_NO ,  
PATIENT_MOBILE_NO ,  
PATIENT_EMAIL_ADDRESS ,  
GUARANTOR_REF_NO ,  
PATIENT_FILE_ACTIVE_YN ,  
PATIENT_NATIONALITY ,  
PATIENT_GUARANTOR_AMOUNT ,  
PATIENT_FILE_COURIER_YN ,  
PATIENT_ADMISSION_DATE ,  
PATIENT_DISCHARGE_DATE ,  
PATIENT_DIAGNOSIS ,  
a.CREATION_DTTM ,  
b.ADDRESS1,b.ADDRESS2,b.ADDRESS3, b.ADDRESS4,b.ADDRESS5, b.PROVINCE,  
PATIENT_EMERGENCY_CONTACT_NAME ,  
PATIENT_EMERGENCY_CONTACT_NO ,  
IN_PATIENT ,  
OUT_PATIENT ,  
FILE_COURIER_DATE ,  
CANCELLED ,  
COURIER_WAYBILL_NO ,  
GUARANTOR247NO ,  
GUARANTOR247EMAIL ,  
FILE_ASSIGNED_TO_USERID ,  
COURIER_RECEIPT_DATE ,  
LATE_LOG_YN ,  
LATE_LOG_DATE ,  
PENDING ,  
PEND_DATE ,  
FILE_OPERATOR_TO_USERID ,  
PATIENT_DATE_OF_BIRTH ,  
LAB_LIST_DATE ,  
AFTER_HOURS_FILE ,  
SENT_TO_ADMIN ,  
c.TITLE_DESC,  
d.GUARANTOR_NAME,  
e.SUPPLIER_NAME,   
j.GUARANTOR_NAME "Flight Guarantor",  
f.EVACUATION_TYPE_DESC "Evacuation - Type",   
g.RMR_TYPE_DESC "RMR - Type",  
h.TRANSPORT_TYPE_DESC "Transport - Type",  
i.REPAT_TYPE_DESC "Repat - Type",  
k.ASSIST_TYPE_DESC "Assist - Type" ,
a.HIGH_COST  "High Cost File"
from AIMS_a_PATIENT a  
left outer join AIMS_ADDRESS b on b.ADDRESS_ID = a.ADDRESS_ID  
left outer join AIMS_TITLE c on c.TITLE_ID = a.TITLE_ID  
left outer join AIMS_GUARANTOR d on d.GUARANTOR_ID = a.GUARANTOR_ID  
left outer join AIMS_SUPPLIER e on e.SUPPLIER_ID = a.SUPPLIER_ID  
left outer join AIMS_EVACUATION_TYPES f on f.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID  
left outer join AIMS_RMR_TYPES g on g.RMR_TYPE_ID = a.PATIENT_RMR_TYPE_ID  
left outer join AIMS_TRANSPORT_TYPE h on h.TRANSPORT_TYPE_ID = a.PATIENT_TRANSPORT_TYPE_ID  
left outer join AIMS_REPAT_TYPE i on i.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID  
left outer join AIMS_GUARANTOR j on j.GUARANTOR_ID = a.FLIGHT_GUARANTOR_ID  
left outer join AIMS_ASSIST_TYPE k on k.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID  
where a.PATIENT_FILE_NO = @PATIENT_FILE_NO  
order by 1 desc  
            
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GUARANTOR_ADD]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_GUARANTOR_ADD]  
	@GuarantorID    		int output,
	@GuarantorName		varchar(50) = '',
	@GuarantorPhoneNo 		varchar(50) = '',
	@GuarantorFaxNo   		varchar(50) = '',
	@AddressTypeID		int,
	@Address1			varchar(50) = '',
	@Address2 			varchar(50) = '',
	@Address3 			varchar(50) = '',
	@Address4 			varchar(50) = '',
	@Address5 			varchar(50) = '',
	@PostalCode 			varchar(50) = '',
	@GuarantorProvince 		varchar(50) = '',
	@CountryID 			int,
	@GuarantorEmailAddress 	varchar(50) = '',
	@GuarantorActiveYN 		varchar(50) = '',
	@UserSignedOn 		varchar(50) ,
	@ContactPerson 		varchar(50)=''
as 
	BEGIN TRANSACTION addGuarantor

	DECLARE @LastError INT, @GuarantorAddressID int, @AddressID int
	SET @LastError = 0
	
	if @GuarantorID > 0
	begin
		insert into aims_debugging values ('Step 1','Guarantor ID' + cast(@GuarantorID as varchar(50)), getdate())
		select @AddressID  = address_id from aims_guarantor where guarantor_id = @GuarantorID	
		
		if  @AddressID is NULL
		begin
			insert into aims_address
				(ADDRESS_TYPE_ID,
				ADDRESS1, ADDRESS2,
				ADDRESS3, ADDRESS4,
				ADDRESS5, POSTAL_CODE,
				COUNTRY_ID, DEFAULT_YN , ACTIVE_YN, PROVINCE) Values 
								(@AddressTypeID, @Address1 , 
								 @Address2 , @Address3 ,
								 @Address4 , @Address5, 
								 @PostalCode,@CountryID, 'Y', 'Y', @GuarantorProvince)

			insert into aims_debugging values ('Step 2','Guarantor Contact Person' + cast(@ContactPerson as varchar(50)), getdate())

			update aims_guarantor set 
					address_id =  IDENT_CURRENT('AIMS_ADDRESS'),
					GUARANTOR_NAME = @GuarantorName,
					GUARANTOR_PHONE_NO =@GuarantorPhoneNo ,
					GUARANTOR_FAX_NO = @GuarantorFaxNo,
					GUARANTOR_EMAIL_ADDRESS = @GuarantorEmailAddress ,
					GUARANTOR_ACTIVE_YN =@GuarantorActiveYN,
					GUARANTOR_CONTACT_PERSON = @ContactPerson
					where guarantor_id = @GuarantorID		
		end
		else
		begin
			insert into aims_debugging values ('Step 4','Guarantor Contact Person' + @ContactPerson , getdate())
			update aims_address set ADDRESS_TYPE_ID = @AddressTypeID,
					ADDRESS1 = @Address1, 
					ADDRESS2 = @Address2,
					ADDRESS3 = @Address3, 
					ADDRESS4 = @Address4,
					ADDRESS5 = @Address5, 
					POSTAL_CODE = @PostalCode,
					COUNTRY_ID = @CountryID, 
					DEFAULT_YN = 'Y', 
					ACTIVE_YN = 'Y', 
					PROVINCE = @GuarantorProvince where address_id = @AddressID
	
			update aims_guarantor set 
					GUARANTOR_NAME = @GuarantorName,
					GUARANTOR_PHONE_NO =@GuarantorPhoneNo ,
					GUARANTOR_FAX_NO = @GuarantorFaxNo,
					GUARANTOR_EMAIL_ADDRESS = @GuarantorEmailAddress ,
					GUARANTOR_ACTIVE_YN =@GuarantorActiveYN,
					GUARANTOR_CONTACT_PERSON = @ContactPerson where guarantor_id = @GuarantorID		
		end
		insert into AIMS_A_GUARANTOR(
				MODIFIED_USER,
				MODIFIED_ACTION,
				MODIFIED_DATE,
				GUARANTOR_ID,
				GUARANTOR_NAME,
				ADDRESS_ID,
				GUARANTOR_PHONE_NO,
				GUARANTOR_FAX_NO,
				GUARANTOR_EMAIL_ADDRESS,
				GUARANTOR_ACTIVE_YN,
				GUARANTOR_CONTACT_PERSON) 
			Values(
				@UserSignedOn,

				'UPDATE',
				GETDATE(),
				@GuarantorID,
				@GuarantorName , CAST(@GuarantorAddressID as varchar(50)), 
				@GuarantorPhoneNo , @GuarantorFaxNo  ,
				@GuarantorEmailAddress , @GuarantorActiveYN, @ContactPerson)
	end
	else
	begin

		insert into aims_address
			(ADDRESS_TYPE_ID,
			ADDRESS1, ADDRESS2,
			ADDRESS3, ADDRESS4,
			ADDRESS5, POSTAL_CODE,
			COUNTRY_ID, DEFAULT_YN , 
			ACTIVE_YN, PROVINCE) Values 
							(@AddressTypeID, @Address1 , 
							 @Address2 , @Address3 ,
							 @Address4 , @Address5, 
							 @PostalCode,@CountryID, 'Y', 'Y', 
							@GuarantorProvince)
	
		if (@@ERROR <> 0) 
		begin
			insert into aims_debugging values ('Step 1','Guarantor Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
			SET @LastError = @@ERROR
			ROLLBACK TRANSACTION
			Return (-1)   
		end			

	
		set @GuarantorAddressID = IDENT_CURRENT('AIMS_ADDRESS')	
	
		insert into aims_guarantor(
		GUARANTOR_NAME, GUARANTOR_PHONE_NO,
		GUARANTOR_FAX_NO, ADDRESS_ID,
		GUARANTOR_EMAIL_ADDRESS, GUARANTOR_ACTIVE_YN, GUARANTOR_CONTACT_PERSON) values
		(
			@GuarantorName , @GuarantorPhoneNo ,
			@GuarantorFaxNo , CAST(@GuarantorAddressID as varchar(50)) ,
			@GuarantorEmailAddress , @GuarantorActiveYN, @ContactPerson)

		set @GuarantorID = IDENT_CURRENT('AIMS_GUARANTOR')

		if (@@ERROR <> 0) 
		begin
			SET @LastError = @@ERROR
			insert into aims_debugging values ('Step 1','Guarantor Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
			ROLLBACK TRANSACTION
			Return (-1)
		end
		
		begin
			insert into AIMS_A_GUARANTOR(
					MODIFIED_USER,
					MODIFIED_ACTION,
					MODIFIED_DATE,
					GUARANTOR_ID,
					GUARANTOR_NAME,
					ADDRESS_ID,
					GUARANTOR_PHONE_NO,
					GUARANTOR_FAX_NO,
					GUARANTOR_EMAIL_ADDRESS,
					GUARANTOR_ACTIVE_YN,
					GUARANTOR_CONTACT_PERSON) 
				Values(
					@UserSignedOn,

					'ADD',
					GETDATE(),
					CAST(IDENT_CURRENT('AIMS_GUARANTOR') as varchar(50)),
					@GuarantorName , CAST(@GuarantorAddressID as varchar(50)), 
					@GuarantorPhoneNo , @GuarantorFaxNo  ,
					@GuarantorEmailAddress , @GuarantorActiveYN, @ContactPerson)
		end
		
	end	
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Guarantor audit Saving Completed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addGuarantor
	end
	else
	begin	
		COMMIT TRANSACTION addGuarantor
	end
GO
/****** Object:  Table [dbo].[AIMS_GUARANTOR_ACCOUNT]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_GUARANTOR_ACCOUNT](
	[GUARANTOR_ACCOUNT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[GUARANTOR_ID] [numeric](18, 0) NULL,
	[ACCOUNT_NO] [varchar](50) NULL,
	[ACCOUNT_NAME] [varchar](250) NULL,
	[ACTIVE_YN] [varchar](1) NULL,
	[CURRENCY_CODE] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_GUARANTOR_ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[GUARANTOR_ACCOUNT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AIMS_GUARANTOR_ACCOUNT] UNIQUE NONCLUSTERED 
(
	[ACCOUNT_NO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_PATIENT](
	[PATIENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_FILE_NO] [varchar](255) NOT NULL,
	[PATIENT_INITIALS] [varchar](10) NULL,
	[PATIENT_FIRST_NAME] [varchar](50) NULL,
	[PATIENT_MIDDLE_NAME] [varchar](50) NULL,
	[PATIENT_LAST_NAME] [varchar](50) NULL,
	[PATIENT_ID_NO] [varchar](50) NULL,
	[COMPANY_ID] [numeric](18, 0) NULL,
	[TITLE_ID] [numeric](18, 0) NULL,
	[ADDRESS_ID] [numeric](18, 0) NULL,
	[PATIENT_HOME_TEL_NO] [varchar](50) NULL,
	[PATIENT_WORK_TEL_NO] [varchar](50) NULL,
	[PATIENT_FAX_NO] [varchar](50) NULL,
	[PATIENT_MOBILE_NO] [varchar](50) NULL,
	[PATIENT_EMAIL_ADDRESS] [varchar](50) NULL,
	[GUARANTOR_ID] [numeric](18, 0) NULL,
	[GUARANTOR_REF_NO] [varchar](255) NULL,
	[PATIENT_FILE_ACTIVE_YN] [varchar](1) NULL,
	[PATIENT_NATIONALITY] [varchar](50) NULL,
	[PATIENT_GUARANTOR_AMOUNT] [varchar](50) NULL,
	[SUPPLIER_ID] [int] NULL,
	[PATIENT_FILE_COURIER_YN] [varchar](50) NULL,
	[PATIENT_ADMISSION_DATE] [varchar](50) NULL,
	[PATIENT_DISCHARGE_DATE] [varchar](50) NULL,
	[PATIENT_DIAGNOSIS] [varchar](255) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[PATIENT_EMERGENCY_CONTACT_NAME] [varchar](150) NULL,
	[PATIENT_EMERGENCY_CONTACT_NO] [varchar](150) NULL,
	[IN_PATIENT] [varchar](1) NULL,
	[OUT_PATIENT] [varchar](1) NULL,
	[ASSIST] [varchar](1) NULL,
	[FILE_COURIER_DATE] [datetime] NULL,
	[FLIGHT] [varchar](1) NULL,
	[REPAT] [varchar](1) NULL,
	[CANCELLED] [varchar](1) NULL,
	[COURIER_WAYBILL_NO] [varchar](255) NULL,
	[TRANSPORT] [varchar](1) NULL,
	[GUARANTOR247NO] [varchar](255) NULL,
	[GUARANTOR247EMAIL] [varchar](255) NULL,
	[FILE_ASSIGNED_TO_USERID] [varchar](255) NULL,
	[COURIER_RECEIPT_DATE] [datetime] NULL,
	[PATIENT_ASSIST_TYPE_ID] [int] NULL,
	[PATIENT_TRANSPORT_TYPE_ID] [int] NULL,
	[LATE_LOG_YN] [varchar](1) NULL,
	[LATE_LOG_DATE] [datetime] NULL,
	[PENDING] [varchar](1) NULL,
	[PEND_DATE] [datetime] NULL,
	[PATIENT_EVACUATION_TYPE_ID] [int] NULL,
	[PATIENT_REPAT_TYPE_ID] [int] NULL,
	[FILE_OPERATOR_TO_USERID] [varchar](50) NULL,
	[RMR] [varchar](1) NULL,
	[PATIENT_RMR_TYPE_ID] [int] NULL,
	[FLIGHT_GUARANTOR_ID] [numeric](18, 0) NULL,
	[PATIENT_DATE_OF_BIRTH] [varchar](50) NULL,
	[LAB_LIST_DATE] [datetime] NULL,
	[AFTER_HOURS_FILE] [varchar](1) NULL,
	[SENT_TO_ADMIN] [varchar](1) NULL,
	[HIGH_COST] [varchar](1) NULL,
 CONSTRAINT [PK_AIMS_PATIENT] PRIMARY KEY CLUSTERED 
(
	[PATIENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_PATIENT] ON [dbo].[AIMS_PATIENT] 
(
	[PATIENT_FILE_NO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AIMS_PATIENT_1] ON [dbo].[AIMS_PATIENT] 
(
	[PATIENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_ADD_EMAIL_ATTACHMENT]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_EWS_ADD_EMAIL_ATTACHMENT]         
 @EMAIL_ID VARCHAR(500),         
 @ATTACHMENT_LOCATION VARCHAR(500),    
 @EmailAttachmentID int = 0 output
AS        
BEGIN        
     
  INSERT INTO AIMS_EWS_EMAIL_ATTACHMENT (        
    EMAIL_ID,        
    ATTACHMENT_LOCATION        
  )    VALUES(        
   @EMAIL_ID,        
   @ATTACHMENT_LOCATION        
  )        
     
 SET  @EmailAttachmentID = cast(IDENT_CURRENT('AIMS_EWS_EMAIL_ATTACHMENT') AS VARCHAR)    
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_INFO]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_INFO]  
 @EMAIL_ATTACHMENT_ID varchar(50)  
 AS  
 BEGIN  
  SELECT * FROM   
   AIMS_EWS_EMAIL_ATTACHMENT WHERE   
     ATTACHMENT_ID = @EMAIL_ATTACHMENT_ID  
 END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_EMAIL_ATTACHMENT]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_GET_EMAIL_ATTACHMENT]    
 @EMAIL_ID varchar(50)    
AS    
BEGIN    
 SELECT * FROM  
   AIMS_EWS_EMAILS a  
   inner join AIMS_EWS_EMAIL_ATTACHMENT b on b.EMAIL_ID  = a.EMAIL_ID   
   left outer join AIMS_EWS_EMAIL_ATTACHMENT_TYPES c on c.ATTACHMENT_FILE_TYPE_ID = b.ATTACHMENT_FILE_TYPE_ID  
 WHERE a.EMAIL_ID = @EMAIL_ID  
END
GO
/****** Object:  View [dbo].[AIMS_SUPPLIERS_VW]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AIMS_SUPPLIERS_VW]  
AS  
--SELECT     * from aims_supplier where (supplier_name <> null and supplier_name <> '' and supplier_name <> '<Add New Hospital>')  
SELECT     * from aims_supplier where supplier_name not in ('','<Add New Hospital>', '<Add New Supplier>')  
and supplier_active_yn = 'Y'
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SUPPLIER_VERIFY]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_SUPPLIER_VERIFY]  
    @SupplierName varchar(50)
as 
	declare @vSQL  nvarchar(500)
 
	--set @vSQL = 'select *  from aims_supplier where supplier_name = ' + CAST(@SupplierName AS VARCHAR(255)) 

	select *  from aims_supplier where supplier_name = @SupplierName

	--EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SUPPLIER_ADD]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc  [dbo].[AIMS_SUPPLIER_ADD]            
 @SupplierID  int output,          
 @SupplierName     varchar(50) = '',          
 @SupplierAccount varchar(50) = '',          
 @SupplierTypeID  int,          
 @SupplierContactName varchar(50) = '',          
 @SupplierEmailAddress  varchar(50) = '',          
 @SupplierPhoneNo  varchar(50) = '',          
 @SupplierFaxNo   varchar(50) = '',          
 @SupplierMobileNo  varchar(50) = '',          
 @SupplierActiveYN  varchar(50) = '',          
 @Address1  varchar(50) = '',          
 @Address2   varchar(50) = '',          
 @Address3   varchar(50) = '',          
 @Address4   varchar(50) = '',          
 @Address5   varchar(50) = '',          
 @PostalCode   varchar(50) = '',          
 @CountryID   int,          
 @UserSignedOn   varchar(50),          
 @Province  varchar(50),      
 @DoctorSupplier varchar(1),    
 @DoctorNameInitials  varchar(50),     
 @DoctorSurname     varchar(50),  
 @AdminName     varchar(50),  
 @AdminTelNo     varchar(50),  
 @AdminFax     varchar(50),  
 @AdminEmail     varchar(50),  
 @AdminCellNo     varchar(50)  
as           
 BEGIN TRANSACTION addGuarantor          
          
 DECLARE @LastError INT, @SupplierAddressID int, @SupplierTitleID int, @AddressTypeID int          
           
          
 SET @LastError = 0          
         
 IF (@CountryID <= 0 )           
 BEGIN        
 SELECT @CountryID = Country_ID  from aims_country where (country_name ='' or country_name is null)        
 END        
        
 if @SupplierID > 0          
 begin          
  select  @SupplierAddressID = ADDRESS_ID from aims_supplier where supplier_id = @SupplierID          
          
  if  @SupplierAddressID is NULL          
  begin          
         
   ----------          
   /* ADDRESS_ID  - Indentity Column */          
   insert into aims_address          
    (ADDRESS_TYPE_ID,          
    ADDRESS1, ADDRESS2,          
    ADDRESS3, ADDRESS4,          
    ADDRESS5, POSTAL_CODE,          
    COUNTRY_ID, DEFAULT_YN , ACTIVE_YN, PROVINCE) Values           
    (CAST(@AddressTypeID as varchar(50)),           
    @Address1 , @Address2 , @Address3 , @Address4 , @Address5, @PostalCode, CAST(@CountryID as varchar(50)), 'Y', 'Y', @Province)          
            
   if (@@ERROR <> 0)           
   begin          
          
    SET @LastError = @@ERROR          
    ROLLBACK TRANSACTION          
    Return (-1)             
   end           
           
   set @SupplierAddressID = IDENT_CURRENT('AIMS_ADDRESS')           
   update aims_supplier set address_id  = @SupplierAddressID where supplier_id = @SupplierID          
          
   update aims_supplier set          
     SUPPLIER_TYPE_ID = @SupplierTypeID,           
     SUPPLIER_NAME = @SupplierName,           
     SUPPLIER_EMAIL_ADDRESS = @SupplierEmailAddress,           
     SUPPLIER_PHONE_NO = @SupplierPhoneNo,          
     SUPPLIER_FAX_NO = @SupplierFaxNo,           
     SUPPLIER_ACTIVE_YN = @SupplierActiveYN,           
     SUPPLIER_MOBILE_NO = @SupplierMobileNo,          
     SUPPLIER_ACCOUNT_NO = @SupplierAccount,           
     SUPPLIER_CONTACT_NAME = @SupplierContactName,      
     DOCTOR_SUPPLIER_YN = @DoctorSupplier,    
     DOCTOR_NAME_INITIALS = @DoctorNameInitials,    
     DOCTOR_SURNAME = @DoctorSurname,  
  ADMIN_NAME = @AdminName,  
     ADMIN_TEL_PHONE = @AdminTelNo,  
     ADMIN_FAX = @AdminFax,  
     ADMIN_EMAIL = @AdminEmail,  
     ADMIN_CELL = @AdminCellNo  
      where supplier_id = @SupplierID          
  end          
  else          
  begin          
   insert into aims_debugging values ('Step 4','Update address Table ' +cast(@SupplierAddressID as varchar(50)) , getdate())          
   update aims_address set           
     ADDRESS1 = @Address1,           
     ADDRESS2 = @Address2,          
     ADDRESS3 = @Address3,           
     ADDRESS4 = @Address4,          
     ADDRESS5 = @Address5,           
     POSTAL_CODE = @PostalCode,          
     COUNTRY_ID = @CountryID,           
     DEFAULT_YN = 'Y',           
     ACTIVE_YN = 'Y',           
     PROVINCE = @Province where address_id = @SupplierAddressID          
           
   update aims_supplier set          
     SUPPLIER_TYPE_ID = @SupplierTypeID,           
     SUPPLIER_NAME = @SupplierName,           
     SUPPLIER_EMAIL_ADDRESS = @SupplierEmailAddress,           
     SUPPLIER_PHONE_NO = @SupplierPhoneNo,          
     SUPPLIER_FAX_NO = @SupplierFaxNo,           
     SUPPLIER_ACTIVE_YN = @SupplierActiveYN,           
     SUPPLIER_MOBILE_NO = @SupplierMobileNo,          
     SUPPLIER_ACCOUNT_NO = @SupplierAccount,           
     SUPPLIER_CONTACT_NAME = @SupplierContactName,      
     DOCTOR_SUPPLIER_YN = @DoctorSupplier,    
     DOCTOR_NAME_INITIALS = @DoctorNameInitials,    
     DOCTOR_SURNAME = @DoctorSurname,  
  ADMIN_NAME = @AdminName,  
     ADMIN_TEL_PHONE = @AdminTelNo,  
     ADMIN_FAX = @AdminFax,  
     ADMIN_EMAIL = @AdminEmail,  
     ADMIN_CELL = @AdminCellNo             
      where supplier_id = @SupplierID          
  end            
          
  insert into aims_a_supplier(MODIFIED_USER,          
    MODIFIED_ACTION,          
    MODIFIED_DATE,          
    SUPPLIER_ID,                    
    SUPPLIER_TYPE_ID,               
    TITLE_ID,                       
    SUPPLIER_NAME,                                                                                                                                                                
    ADDRESS_ID,                     
    SUPPLIER_EMAIL_ADDRESS,                                       
    SUPPLIER_PHONE_NO,                                            
    SUPPLIER_FAX_NO,                                              
    SUPPLIER_MOBILE_NO,                                           
    SUPPLIER_ACTIVE_YN,      
    DOCTOR_SUPPLIER_YN,    
 DOCTOR_NAME_INITIALS ,    
 DOCTOR_SURNAME,  
 ADMIN_NAME,  
 ADMIN_TEL_PHONE,  
 ADMIN_FAX ,  
 ADMIN_EMAIL,  
 ADMIN_CELL)           
   Values(@UserSignedOn,          
    'UPDATE',          
    GETDATE(),          
    @SupplierID,          
    @SupplierTypeID , CAST(@SupplierTitleID as varchar(50)), @SupplierName,          
    CAST(@SupplierAddressID as varchar(50)), @SupplierEmailAddress ,           
    @SupplierPhoneNo, @SupplierFaxNo, @SupplierMobileNo, @SupplierActiveYN, @DoctorSupplier, @DoctorNameInitials ,   
    @DoctorSurname, @AdminName, @AdminTelNo, @AdminFax, @AdminEmail, @AdminCellNo)          
 end          
 else          
 begin          
  insert into aims_debugging values ('Step 5','Update address Table ' +cast(@SupplierAddressID as varchar(50)) , getdate())          
  /* ADDRESS_ID  - Indentity Column */          
  insert into aims_address          
   (ADDRESS_TYPE_ID,          
   ADDRESS1, ADDRESS2,          
   ADDRESS3, ADDRESS4,          
   ADDRESS5, POSTAL_CODE,          
   COUNTRY_ID, DEFAULT_YN , ACTIVE_YN, PROVINCE) Values           
   (CAST(@AddressTypeID as varchar(50)),           
   @Address1 , @Address2 , @Address3 , @Address4 , @Address5, @PostalCode, CAST(@CountryID as varchar(50)), 'Y', 'Y', @Province)          
           
  if (@@ERROR <> 0)           
  begin          
   insert into aims_debugging values ('Step 1','Supplier Address Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())            
   SET @LastError = @@ERROR          
   ROLLBACK TRANSACTION          
   Return (-1)             
  end           
          
  set @SupplierAddressID = IDENT_CURRENT('AIMS_ADDRESS')           
           
  insert into aims_supplier(          
   SUPPLIER_TYPE_ID, TITLE_ID,          
   SUPPLIER_NAME, ADDRESS_ID,          
   SUPPLIER_EMAIL_ADDRESS, SUPPLIER_PHONE_NO,          
   SUPPLIER_FAX_NO, SUPPLIER_ACTIVE_YN, SUPPLIER_MOBILE_NO,          
   SUPPLIER_ACCOUNT_NO, SUPPLIER_CONTACT_NAME, DOCTOR_SUPPLIER_YN,    
   DOCTOR_NAME_INITIALS,    
   DOCTOR_SURNAME,  
    ADMIN_NAME,  
 ADMIN_TEL_PHONE,  
 ADMIN_FAX ,  
 ADMIN_EMAIL,  
 ADMIN_CELL  
   ) values          
  (          
   @SupplierTypeID , @SupplierTitleID ,          
   @SupplierName , CAST(@SupplierAddressID as varchar(50)) ,             @SupplierEmailAddress ,  @SupplierPhoneNo,           
   @SupplierFaxNo, @SupplierActiveYN, @SupplierMobileNo,@SupplierAccount ,  
   @SupplierContactName, @DoctorSupplier,@DoctorNameInitials, @DoctorSurname,  
   @AdminName, @AdminTelNo, @AdminFax, @AdminEmail, @AdminCellNo)          
           
  if (@@ERROR <> 0)           
  begin          
   SET @LastError = @@ERROR          
   insert into aims_debugging values ('Step 1','Supplier Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())          
   ROLLBACK TRANSACTION          
   Return (-1)          
  end          
           
         set @SupplierID  = IDENT_CURRENT('aims_supplier')          
           
  begin          
   insert into aims_a_supplier(MODIFIED_USER,          
     MODIFIED_ACTION,          
     MODIFIED_DATE,          
     SUPPLIER_ID,                    
     SUPPLIER_TYPE_ID,               
     TITLE_ID,                       
     SUPPLIER_NAME,                                                                               
     ADDRESS_ID,                     
     SUPPLIER_EMAIL_ADDRESS,                                       
     SUPPLIER_PHONE_NO,                                            
     SUPPLIER_FAX_NO,                                              
     SUPPLIER_MOBILE_NO,                                           
     SUPPLIER_ACTIVE_YN,      
     DOCTOR_SUPPLIER_YN,    
     DOCTOR_NAME_INITIALS ,    
     DOCTOR_SURNAME,  
  ADMIN_NAME,  
  ADMIN_TEL_PHONE,  
  ADMIN_FAX ,  
  ADMIN_EMAIL,  
  ADMIN_CELL)           
    Values(@UserSignedOn,          
     'ADD',          
     GETDATE(),          
     CAST(IDENT_CURRENT('AIMS_SUPPLIER') as varchar(50)),          
     @SupplierTypeID , CAST(@SupplierTitleID as varchar(50)), @SupplierName,          
     CAST(@SupplierAddressID as varchar(50)), @SupplierEmailAddress ,           
     @SupplierPhoneNo, @SupplierFaxNo, @SupplierMobileNo, @SupplierActiveYN, @DoctorSupplier, @DoctorNameInitials , @DoctorSurname,  
     @AdminName, @AdminTelNo, @AdminFax, @AdminEmail, @AdminCellNo )          
  end          
 end          
          
           
 if (@@ERROR <> 0)          
 begin          
  insert into aims_debugging values ('Step 1','Supplier audit Saving Completed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())          
  ROLLBACK TRANSACTION addGuarantor          
 end          
 else          
 begin           
  COMMIT TRANSACTION addGuarantor          
 end
GO
/****** Object:  Table [dbo].[AIMS_VISA_LETTERS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_VISA_LETTERS](
	[VISA_LETTER_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[EMBASSY_NAME] [varchar](100) NULL,
	[ADDRESS_ID] [numeric](18, 0) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[PATIENT_PASSPORT_ISSUE_DATE] [date] NULL,
	[PATIENT_PASSPORT_EXPIRY_DATE] [date] NULL,
	[TREATMENT_HOSPITAL_ID] [numeric](18, 0) NULL,
	[TREATMENT_DOCTOR_PROVIDER_ID] [int] NOT NULL,
	[TREATMENT_APPOINTMENT_DATE] [date] NULL,
	[ESCORT_NAME] [varchar](100) NULL,
	[ESCORT_RELATION_ID] [numeric](18, 0) NULL,
	[ESCORT_HIS_HER] [numeric](18, 0) NULL,
	[ESCORT_PASSPORT_NO] [varchar](50) NULL,
	[ESCORT_PASSPORT_ISSUE_DATE] [date] NULL,
	[ESCORT_PASSPORT_EXPIRY_DATE] [date] NULL,
	[VISA_LETTER_POD] [varchar](2000) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[ACTIVE_YN] [varchar](1) NULL,
	[EMBASSY_ID] [int] NULL,
	[LOADED_BY] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_VISA_LETTERS] PRIMARY KEY CLUSTERED 
(
	[VISA_LETTER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_SEND_EMAIL_REQUESTS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_SEND_EMAIL_REQUESTS](
	[EMAIL_REQ_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NOT NULL,
	[USER_NAME] [varchar](50) NOT NULL,
	[DELIVERY_METHOD_ID] [numeric](18, 0) NOT NULL,
	[EMAIL_TO] [varchar](100) NULL,
	[EMAIL_FROM_ID] [numeric](18, 0) NOT NULL,
	[EMAIL_BODY] [nchar](10) NULL,
	[REQ_SENT_YN] [varchar](1) NOT NULL,
	[REQ_ERRONEOUS_YN] [varchar](1) NOT NULL,
 CONSTRAINT [PK_AIMS_SEND_EMAIL_REQUESTS] PRIMARY KEY CLUSTERED 
(
	[EMAIL_REQ_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_TRACE]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_TRACE](
	[TRACE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_FILE_NO] [varchar](50) NULL,
	[DATE_TIME] [datetime] NULL,
	[USER_NAME] [varchar](50) NULL,
	[DESCRIPTION] [varchar](50) NULL,
	[COMMENTS] [varchar](50) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_TRACE] PRIMARY KEY CLUSTERED 
(
	[TRACE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_UNALLOCATED_FILES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENTS_UNALLOCATED_FILES]    
AS    
BEGIN    
select b.GUARANTOR_NAME , c.MODIFIED_USER ,a.*, d.SUPPLIER_NAME from AIMS_PATIENT a 
left outer join AIMS_GUARANTOR b on b.GUARANTOR_ID = a.GUARANTOR_ID
inner join AIMS_A_PATIENT c on c.PATIENT_ID = a.PATIENT_ID  
left outer join AIMS_SUPPLIER d on d.SUPPLIER_ID = a.SUPPLIER_ID
where (a.FILE_OPERATOR_TO_USERID  is null or a.FILE_OPERATOR_TO_USERID = '') and a.SENT_TO_ADMIN  = 'N'
and a.CREATION_DTTM >= '01 January 2017' and a.CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y'
and c.AUDIT_ID = (select MIN(AUDIT_ID) from  AIMS_A_PATIENT where PATIENT_ID = a.PATIENT_ID)
order by  b.GUARANTOR_NAME, a.PATIENT_FILE_NO
END
GO
/****** Object:  StoredProcedure [dbo].[FIXDATES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FIXDATES]  
AS  
BEGIN  
 declare   
  @Current_Year varchar(10),  
  @Current_Day varchar(10),  
  @Current_Month varchar(10),  
  @Current_Date varchar(100),  
  @New_DateFormat varchar(100),  
  @AdmissionDate varchar(100),  
  @DischargeDate varchar(100),  
  @PatientID int  
     
 --SET @Current_Date = '2014/08/24'  
 --SET @Current_Date = '2014-08-25'  
 --SET @Current_Date = '2014.08.26'  
 --SET @Current_Date = '20140827'    
   
 DECLARE Admission_Dates_Curs1 CURSOR FOR   
  SELECT patient_id, patient_admission_date FROM   
   aims_patient WHERE   
    patient_admission_date LIKE '2015%'  
union
  SELECT patient_id, patient_admission_date FROM   
   aims_patient WHERE   
    patient_admission_date LIKE '2014%'  
       
 OPEN Admission_Dates_Curs1   
  FETCH NEXT FROM Admission_Dates_Curs1 INTO @PatientID, @AdmissionDate  
   
 WHILE @@FETCH_STATUS = 0  
 BEGIN  
  SET @Current_Date = @AdmissionDate  
  PRINT 'STARTED'  
  IF (SUBSTRING(@Current_Date,1,4) = '2013' or SUBSTRING(@Current_Date,1,4) = '2014' or SUBSTRING(@Current_Date,1,4) = '2015' or SUBSTRING(@Current_Date,1,4) = '2016' or SUBSTRING(@Current_Date,1,4) = '2017' )  
  BEGIN  
   PRINT 'DEBUG1'  
   SET @Current_Year = SUBSTRING(@Current_Date,1,4)  
   PRINT 'YEAR:' + cast(@Current_Year as varchar(100))  
     
   SET @Current_Month = SUBSTRING(@Current_Date,6,2)  
   PRINT 'Month:' + cast(@Current_Month as varchar(100))  
     
   SET @Current_Date = SUBSTRING(@Current_Date,9,2)  
   PRINT 'Date:' + cast(@Current_Date as varchar(100))  
     
   SET @New_DateFormat = cast(@Current_Date as varchar(100)) + '/' + cast(@Current_Month as VARCHAR(100)) + '/' + CAST(@Current_Year as varchar(100))  
   Print 'New Date: ' + cast(@New_DateFormat as varchar(100))  
   UPDATE AIMS_PATIENT SET patient_admission_date = @New_DateFormat where PATIENT_ID = @PatientID  
     
  END   
  ELSE  
  BEGIN  
   PRINT 'DEBUG3'  
   Print 'Year: ' + SUBSTRING(@Current_Date,1,4)  
  END  
  FETCH NEXT FROM Admission_Dates_Curs1 INTO @PatientID, @AdmissionDate  
 END  
 CLOSE Admission_Dates_Curs1  
 DEALLOCATE Admission_Dates_Curs1  
END
GO
/****** Object:  StoredProcedure [dbo].[GET_PATIENT_FILE_TASKS_AUDIT]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_PATIENT_FILE_TASKS_AUDIT]  
 @PatientSubFileID Varchar(50)  
AS              
BEGIN        
declare @iPatientID int ,     
  @vSQL nvarchar(4000)  
  
select @iPatientID = PATIENT_ID  from AIMS_PATIENT where PATIENT_FILE_NO = @PatientSubFileID        
        
 SELECT   
 a.patient_file_task_id,                 
 a.details "DETAILS",  
 a.user_id,            
 g.user_full_name "MODIFIED_BY",  
 a.MODIFIED_DATE "MODIFIED_DTTM",  
 a.modified_action "MODIFIED_ACTION",  
 c.task_id ,                
 c.TASK_DESC,                 
 b.User_Full_Name,                 
 c.*,                 
 a.due_date,                
 d.priority_id,                 
 d.priority,                 
 a.ACTIVE_YN STATUS,                 
 a.PATIENT_ID,                
 e.TASK_STATUS,          
 f.User_Full_Name "LOADED_BY",           
 a.CREATION_DATE "CREATION_DATE"             
FROM AIMS_A_PATIENT_FILE_TASKS a                  
 inner join AIMS_TASKS c on c.TASK_ID = a.task_id                  
 LEFT outer JOIN AIMS_USERS b on b.user_name = a.user_id                  
 left outer join aims_priority d on d.priority_id = a.priority_id                 
 left outer join AIMS_TASK_STATUS e on e.TASK_STATUS_ID = a.TASK_STATUS_ID                 
 inner join AIMS_USERS f on f.User_Name = a.LOADED_BY   
 inner join aims_users g on g.user_name = a.MODIFIED_USER        
WHERE a.PATIENT_ID = @iPatientID ORDER BY modified_dttm desc  
  
  EXECUTE  sp_executesql  @vSQL         
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_Error_DATES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec AIMS_Error_DATES        

CREATE proc [dbo].[AIMS_Error_DATES]        
AS        
begin        
         
 declare         
  @AdmissionDt varchar(15),         
  @DischargeDt varchar(15)   

 DECLARE db_cursor1 CURSOR FOR          
 SELECT distinct patient_admission_date from aims_patient where
 (patient_admission_date is not null and patient_admission_date <>'') and patient_id >= (select max(patient_id) from aims_patient)-600
 order by 1
        
 OPEN db_cursor1           
 FETCH NEXT FROM db_cursor1 INTO @AdmissionDt
 
 WHILE @@FETCH_STATUS = 0           
 BEGIN        
	begin try
		PRINT 'Admission : ' + CAST(@AdmissionDt as VARCHAR(10))     
		select  convert(SMALLDATETIME,@AdmissionDt, 103) 
	end try
	begin catch
		insert into AIMS_DEBUGGING
		values ('DATE FORMAT ERROR - ADMISSION', @AdmissionDt, GETDATE())
	end catch;
  FETCH NEXT FROM db_cursor1 INTO  @AdmissionDt 
 END           
         
 CLOSE db_cursor1           
 DEALLOCATE db_cursor1      
     
 DECLARE db_cursor1 CURSOR FOR          
 SELECT distinct patient_discharge_date from aims_patient where
 (patient_discharge_date is not null and patient_discharge_date <>'') and patient_id >= (select max(patient_id) from aims_patient)-600
 order by 1
        
 OPEN db_cursor1           
 FETCH NEXT FROM db_cursor1 INTO @AdmissionDt
 
 WHILE @@FETCH_STATUS = 0           
 BEGIN        
	begin try
		PRINT 'Admission : ' + CAST(@AdmissionDt as VARCHAR(10))     
		select  convert(SMALLDATETIME,@AdmissionDt, 103) 
	end try
	begin catch
		insert into AIMS_DEBUGGING
		values ('DATE FORMAT ERROR - DISCHARGE', @AdmissionDt, GETDATE())
	end catch;
  
  FETCH NEXT FROM db_cursor1 INTO  @AdmissionDt 
 END           
         
 CLOSE db_cursor1           
 DEALLOCATE db_cursor1      


END
GO
/****** Object:  Table [dbo].[AIMS_AA_OPTIONS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_AA_OPTIONS](
	[AAOPTION_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[AIRCRAFT] [varchar](50) NULL,
	[AVAILIBITY] [varchar](50) NULL,
	[COST] [varchar](50) NULL,
	[LEVELOFCARE] [varchar](50) NULL,
	[ROUTING] [varchar](50) NULL,
	[CREATED_BY] [varchar](50) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[ADMIN_FEE] [varchar](50) NULL,
	[AMBULANCE_REFERRING] [varchar](150) NULL,
	[AMBULANCE_RECEIVING] [varchar](150) NULL,
	[AIRPORT_OPERATING_HOURS] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_AA_OPTIONS] PRIMARY KEY CLUSTERED 
(
	[AAOPTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_AA_DETAILS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_AA_DETAILS](
	[AAID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[YELLOW_FEVER_CERTIFICATE] [varchar](250) NULL,
	[WEIGHTHEIGHTESTIMATE] [varchar](250) NULL,
	[REFERRING_HOSPITAL_NAME_LOCATION] [varchar](250) NULL,
	[REFERRING_HOSPITAL_TEL_NO] [varchar](250) NULL,
	[REFERRING_HOSPITAL_EMAIL] [varchar](250) NULL,
	[REFERRING_DOCTOR_NAME] [varchar](250) NULL,
	[REFERRING_DOCTOR_TEL_NO] [varchar](250) NULL,
	[REFERRING_DOCTOR_EMAIL] [varchar](250) NULL,
	[COMPANY_MEM_NAME] [varchar](250) NULL,
	[COMPANY_MEM_NATIONALITY] [varchar](250) NULL,
	[COMPANY_MEM_PASSPORT_NO] [varchar](250) NULL,
	[COMPANY_MEM_YELLOW_FEVER_CERT] [varchar](250) NULL,
	[VHFFORMREQUIREDYN] [varchar](1) NULL,
	[LOADED_BY] [varchar](50) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[AA_POD] [varchar](500) NULL,
	[ACTIVE_YN] [varchar](1) NULL,
	[PATIENT_PASSPORT_NUMBER] [varchar](50) NULL,
	[COMPANY_MEM_WEIGHT_HEIGHT] [varchar](50) NULL,
	[AA_ADDRESS_TO] [varchar](250) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_ACCOMODATION]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_ACCOMODATION](
	[ACCOMODATION_BOOKING_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[SUPPLIER_ID] [numeric](18, 0) NULL,
	[GUEST_NAME] [varchar](250) NULL,
	[GUEST_REF_NO] [varchar](50) NULL,
	[GUEST_NO_OF_ROOMS] [varchar](50) NULL,
	[GUEST_ARRIVAL_DATE] [varchar](50) NULL,
	[GUEST_FLIGHT_ARRIVAL_DATE] [varchar](50) NULL,
	[GUEST_DEPART_DATE] [varchar](50) NULL,
	[GUEST_AIMS_SETTLE] [varchar](50) NULL,
	[GUEST_COUNTRY_OF_ORIGIN] [numeric](18, 0) NULL,
	[GUEST_RELIGION] [numeric](18, 0) NULL,
	[GUEST_DIABETIC_MEALS] [varchar](250) NULL,
	[GUEST_BED_AND_BREAKFAST] [varchar](250) NULL,
	[GUEST_MEALS] [varchar](50) NULL,
	[GUEST_LAUNDRY] [varchar](50) NULL,
	[GUEST_TELEPHONE] [varchar](50) NULL,
	[GUEST_MINIBAR] [varchar](50) NULL,
	[GUEST_SPECIAL_REQUEST] [varchar](250) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[CREATED_BY] [varchar](50) NULL,
	[ACCOMODATION_LETTER] [varchar](1000) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[ContactTelMobileNo] [varchar](50) NULL,
	[ContactEmailAddress] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[NoOfGuests] [varchar](50) NULL,
	[RoomRatePerNight] [varchar](50) NULL,
	[RoomType] [numeric](18, 0) NULL,
	[MealBreakFast] [varchar](50) NULL,
	[MealBreakLunch] [varchar](50) NULL,
	[MealBreakDinner] [varchar](50) NULL,
	[MealBreakFullBoard] [varchar](50) NULL,
	[SocialTransport] [varchar](50) NULL,
	[AdditionalNotes] [varchar](250) NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[AIMS_ACCOMODATION] ADD [Currency] [varchar](50) NULL
ALTER TABLE [dbo].[AIMS_ACCOMODATION] ADD  CONSTRAINT [PK_AIMS_ACCOMODATION] PRIMARY KEY CLUSTERED 
(
	[ACCOMODATION_BOOKING_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_ADMIN_WORK_ALLOCATED]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_ADMIN_WORK_ALLOCATED]       
AS          
BEGIN          
declare @vSQL NVARCHAR(MAX)         
         
SELECT @vSQL = ''        
         
 SELECT count(a.file_assigned_to_userid) FILE_COUNT,       
  a.file_assigned_to_userid file_assigned_to_userid      
  FROM aims_patient a      
 WHERE a.sent_to_admin = 'Y'
   AND a.cancelled = 'N'
   AND a.patient_file_active_yn = 'Y'
   AND (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '')
   AND a.creation_dttm > = '01 January 2018'
   --and a.FILE_ASSIGNED_TO_USERID = 'CHARLAINE'
 --a.CREATION_DTTM >= '01 January 2018' and  a.sent_to_admin = 'Y'      
 --  AND a.cancelled = 'N'      
 --  AND a.patient_file_active_yn = 'Y'
 --  and a.FILE_ASSIGNED_TO_USERID = 'CHARLAINE'      
 --  AND (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '')
group by a.file_assigned_to_userid       
order by file_assigned_to_userid      
      
 EXECUTE sp_executesql @vSQL         
END
GO
/****** Object:  Table [dbo].[AIMS_APPOINTMENTS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_APPOINTMENTS](
	[APPOINTMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[APPOINTMENT_SUBJECT] [varchar](1000) NULL,
	[APPOINTMENT_ADDRESS] [varchar](1000) NULL,
	[APPOINTMENT_DATE] [varchar](1000) NULL,
	[APPOINTMENT_TIME_HOUR] [numeric](18, 0) NULL,
	[APPOINTMENT_TIME_MINUTE] [numeric](18, 0) NULL,
	[REMINDER_YN] [varchar](1) NULL,
	[REMINDER_PERIOD] [varchar](500) NULL,
	[TRANSPORT_YN] [varchar](1) NULL,
	[TRANSPORT_TYPE_ID] [int] NULL,
	[PICK_UP_TIME_HOUR] [numeric](18, 0) NULL,
	[PICK_UP_TIME_MINUTE] [numeric](18, 0) NULL,
	[DROP_UP_TIME_HOUR] [numeric](18, 0) NULL,
	[DROP_UP_TIME_MINUTE] [numeric](18, 0) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[CREATED_DTTM] [datetime] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[APPOINTMENT_NOTE] [varchar](1000) NULL,
	[CANCELLED_YN] [varchar](1) NULL,
	[APPOINTMENT_TIME] [datetime] NULL,
	[PICK_UP_TIME] [datetime] NULL,
	[DROP_OFF_TIME] [datetime] NULL,
	[TRANSLATOR_YN] [varchar](1) NULL,
	[EMAIL_SMS_SENT_YN] [varchar](1) NULL,
	[CALENDER_APPOINTMENT_ID] [numeric](18, 0) NULL,
	[APPOINTMENT_STATUS] [varchar](1000) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_EWS_INSTANT_MESSAGING]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_INSTANT_MESSAGING](
	[IINSTANT_MESSAGE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[INSTANT_MESSAGE_DTTM] [datetime] NOT NULL,
	[INSTANT_MESSAGE_TEXT] [varchar](500) NOT NULL,
	[INSTANT_MESSAGE_TO] [varchar](50) NOT NULL,
	[INSTANT_MESSAGE_FROM] [varchar](50) NOT NULL,
	[INSTANT_MESSAGE_PATIENT_ID] [numeric](18, 0) NOT NULL,
	[PROCESSED_DTTM] [datetime] NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[AIMS_EWS_INSTANT_MESSAGING] ADD [PROCESSED_BY] [varchar](50) NULL
ALTER TABLE [dbo].[AIMS_EWS_INSTANT_MESSAGING] ADD  CONSTRAINT [PK_AIMS_EWS_INSTANT_MESSAGING] PRIMARY KEY CLUSTERED 
(
	[IINSTANT_MESSAGE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_PATIENT_FILE_OPERATOR]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_GET_PATIENT_FILE_OPERATOR]     
 @PATIENT_FILE_NO varchar(50)  
AS      
BEGIN      
 SELECT *   
  FROM   
 AIMS_PATIENT WHERE PATIENT_FILE_NO = @PATIENT_FILE_NO  
END
GO
/****** Object:  Table [dbo].[AIMS_EWS_PATIENT_ENQUIRY]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_PATIENT_ENQUIRY](
	[PATIENT_ENQUIRY_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NOT NULL,
	[EMAIL_ID] [numeric](18, 0) NOT NULL,
	[CREATION_DTTM] [datetime] NOT NULL,
	[ACTIVE_YN] [varchar](1) NULL,
	[PRIORITY_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_EWS_PATIENT_ENQUIRY] PRIMARY KEY CLUSTERED 
(
	[PATIENT_ENQUIRY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AIMS_EWS_PATIENT_ENQUIRY] ON [dbo].[AIMS_EWS_PATIENT_ENQUIRY] 
(
	[PATIENT_ID] ASC,
	[EMAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_FIX_DATES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec AIMS_FIX_DATES        
        
CREATE proc [dbo].[AIMS_FIX_DATES]        
AS        
begin        
         
 declare         
  @AdmissionDt varchar(15),         
  @DischargeDt varchar(15),        
  @PatientID int,        
  @Date_D varchar(15),        
  @Date_M varchar(15),        
  @Date_Y varchar(15)        
  
     
 DECLARE db_cursor1 CURSOR FOR          
 SELECT patient_admission_date, patient_id from aims_patient where       
 (patient_admission_date like '%\\%' or patient_admission_date like '%//%')        
        
 OPEN db_cursor1           
 FETCH NEXT FROM db_cursor1 INTO @AdmissionDt, @PatientID          
 PRINT 'PATIENT-ID: ' + CAST(@PatientID as VARCHAR(10))        
 WHILE @@FETCH_STATUS = 0           
 BEGIN        
  UPDATE aims_patient set patient_admission_date ='' where PATIENT_ID = @PatientID    
  FETCH NEXT FROM db_cursor1 INTO  @AdmissionDt , @PatientID          
 END           
         
 CLOSE db_cursor1           
 DEALLOCATE db_cursor1      
     
 DECLARE db_cursor2 CURSOR FOR          
 SELECT patient_discharge_date, patient_id from aims_patient where       
 (patient_discharge_date like '%\\%' or patient_discharge_date like '%//%')        
        
 OPEN db_cursor2           
 FETCH NEXT FROM db_cursor2 INTO @DischargeDt, @PatientID          
 PRINT 'PATIENT-ID: ' + CAST(@PatientID as VARCHAR(10))        
 WHILE @@FETCH_STATUS = 0           
 BEGIN        
  UPDATE aims_patient set patient_discharge_date ='' where PATIENT_ID = @PatientID    
  FETCH NEXT FROM db_cursor2 INTO  @DischargeDt , @PatientID          
 END           
         
 CLOSE db_cursor2           
 DEALLOCATE db_cursor2      
  
         
 DECLARE db_cursor CURSOR FOR          
 SELECT patient_admission_date, patient_id from aims_patient where       
 (patient_admission_date like '2014%' or patient_discharge_date like '2014%' )        
        
 OPEN db_cursor           
 FETCH NEXT FROM db_cursor INTO @AdmissionDt, @PatientID          
 PRINT 'PATIENT-ID: ' + CAST(@PatientID as VARCHAR(10))        
 WHILE @@FETCH_STATUS = 0           
 BEGIN        
          
  PRINT 'Admission Date: ' + CAST(@AdmissionDt as VARCHAR(15))        
  SET @Date_D = ''        
  SET @Date_M = ''        
  SET @Date_Y = ''        
          
  SET @Date_D = DATEPART(DAY,convert(smalldatetime,@AdmissionDt,111))        
  if LEN(@Date_D) = 1        
  begin        
   SET @Date_D = '0' + cast(@Date_D as varchar(3))        
  end        
  SET @Date_M = DATEPART(MONTH,convert(smalldatetime,@AdmissionDt,111))        
  if LEN(@Date_M) = 1        
  begin        
   SET @Date_M = '0' + cast(@Date_M as varchar(3))        
  end        
  SET @Date_Y = DATEPART(YEAR ,convert(smalldatetime,@AdmissionDt,111))        
          
  update aims_patient set patient_admission_date = @Date_D + '/' + @Date_M + '/' + @Date_Y where patient_id = @PatientID        
          
  FETCH NEXT FROM db_cursor INTO @AdmissionDt , @PatientID          
 END           
        
 CLOSE db_cursor           
 DEALLOCATE db_cursor        
         
         
 DECLARE db_cursor CURSOR FOR          
 SELECT patient_admission_date, patient_id from aims_patient where       
 (patient_admission_date like '2016%'  )        
        
 OPEN db_cursor           
 FETCH NEXT FROM db_cursor INTO @AdmissionDt, @PatientID          
 PRINT 'PATIENT-ID: ' + CAST(@PatientID as VARCHAR(10))        
 WHILE @@FETCH_STATUS = 0           
 BEGIN        
          
  PRINT 'Admission Date: ' + CAST(@AdmissionDt as VARCHAR(15))        
  SET @Date_D = ''        
  SET @Date_M = ''        
  SET @Date_Y = ''        
          
  SET @Date_D = DATEPART(DAY,convert(smalldatetime,@AdmissionDt,111))        
  if LEN(@Date_D) = 1        
  begin        
   SET @Date_D = '0' + cast(@Date_D as varchar(3))        
  end        
  SET @Date_M = DATEPART(MONTH,convert(smalldatetime,@AdmissionDt,111))        
  if LEN(@Date_M) = 1        
  begin        
   SET @Date_M = '0' + cast(@Date_M as varchar(3))        
  end        
  SET @Date_Y = DATEPART(YEAR ,convert(smalldatetime,@AdmissionDt,111))        
          
  update aims_patient set patient_admission_date = @Date_D + '/' + @Date_M + '/' + @Date_Y where patient_id = @PatientID        
          
  FETCH NEXT FROM db_cursor INTO @AdmissionDt , @PatientID          
 END           
        
 CLOSE db_cursor           
 DEALLOCATE db_cursor     
 
 DECLARE db_cursor CURSOR FOR          
 SELECT patient_discharge_date, patient_id from aims_patient where (patient_discharge_date like '2013%' )        
        
 OPEN db_cursor           
 FETCH NEXT FROM db_cursor INTO @DischargeDt, @PatientID          
 PRINT 'PATIENT-ID: ' + CAST(@PatientID as VARCHAR(10))        
 WHILE @@FETCH_STATUS = 0           
 BEGIN        
          
  SET @Date_D = ''        
  SET @Date_M = ''        
  SET @Date_Y = ''        
          
  Print 'Discharge Date: ' + cast(@DischargeDt as varchar(30))        
  SET @Date_D = DATEPART(DAY,convert(smalldatetime,@DischargeDt,111))        
  if LEN(@Date_D) = 1        
  begin        
   SET @Date_D = '0' + cast(@Date_D as varchar(3))        
  end        
  SET @Date_M = DATEPART(MONTH,convert(smalldatetime,@DischargeDt,111))        
  if LEN(@Date_M) = 1        
  begin        
   SET @Date_M = '0' + cast(@Date_M as varchar(3))        
  end        
        
  SET @Date_Y = DATEPART(YEAR ,convert(smalldatetime,@DischargeDt,111))        
          
  update aims_patient set patient_discharge_date = @Date_D + '/' + @Date_M + '/' + @Date_Y  where patient_id = @PatientID        
          
  FETCH NEXT FROM db_cursor INTO  @DischargeDt , @PatientID          
 END           
        
 CLOSE db_cursor           
 DEALLOCATE db_cursor    
 
DECLARE db_cursor CURSOR FOR          
 SELECT patient_discharge_date, patient_id from aims_patient where (patient_discharge_date like '2016%' )        
        
 OPEN db_cursor           
 FETCH NEXT FROM db_cursor INTO @DischargeDt, @PatientID          
 PRINT 'PATIENT-ID: ' + CAST(@PatientID as VARCHAR(10))        
 WHILE @@FETCH_STATUS = 0           
 BEGIN        
          
  SET @Date_D = ''        
  SET @Date_M = ''        
  SET @Date_Y = ''        
          
  Print 'Discharge Date: ' + cast(@DischargeDt as varchar(30))        
  SET @Date_D = DATEPART(DAY,convert(smalldatetime,@DischargeDt,111))        
  if LEN(@Date_D) = 1        
  begin        
   SET @Date_D = '0' + cast(@Date_D as varchar(3))        
  end        
  SET @Date_M = DATEPART(MONTH,convert(smalldatetime,@DischargeDt,111))        
  if LEN(@Date_M) = 1        
  begin        
   SET @Date_M = '0' + cast(@Date_M as varchar(3))        
  end        
        
  SET @Date_Y = DATEPART(YEAR ,convert(smalldatetime,@DischargeDt,111))        
          
  update aims_patient set patient_discharge_date = @Date_D + '/' + @Date_M + '/' + @Date_Y  where patient_id = @PatientID        
          
  FETCH NEXT FROM db_cursor INTO  @DischargeDt , @PatientID          
 END           
        
 CLOSE db_cursor           
 DEALLOCATE db_cursor      
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_PATIENT_FILE_TASKS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_GET_PATIENT_FILE_TASKS]            
 @PatientSubFileID Varchar(50),       
 @TaskStatus Varchar(50)  
AS            
BEGIN      
declare @iPatientID int ,   
  @vSQL nvarchar(4000),  
  @TaskStatusId int           
      
select @iPatientID = PATIENT_ID  from AIMS_PATIENT where PATIENT_FILE_NO = @PatientSubFileID      
      
 SELECT @vSQL  = 'SELECT a.patient_file_task_id,           
  a.user_id,           
  c.task_id ,          
  c.TASK_DESC,           
  b.User_Full_Name,           
  c.*,           
  a.due_date,          
  d.priority_id,           
  d.priority,           
  a.ACTIVE_YN STATUS,           
  a.PATIENT_ID,          
  e.TASK_STATUS,    
  f.User_Full_Name "LOADED_BY",     
  a.CREATION_DATE "CREATION_DATE"        
 FROM AIMS_PATIENT_FILE_TASKS a            
  inner join AIMS_TASKS c on c.TASK_ID = a.task_id            
  LEFT outer JOIN AIMS_USERS b on b.user_name = a.user_id            
  left outer join aims_priority d on d.priority_id = a.priority_id           
  left outer join AIMS_TASK_STATUS e on e.TASK_STATUS_ID = a.TASK_STATUS_ID           
  inner join AIMS_USERS f on f.User_Name = a.LOADED_BY    
 WHERE   a.PATIENT_ID = ' + cast(@iPatientID as varchar(10))  
  IF @TaskStatus != ''  
  BEGIN  
 select @TaskStatusId = task_status_id from AIMS_TASK_STATUS where task_status = @TaskStatus  
 SET @vSQL = @vSQL + ' and e.task_status_id = ' + cast(@TaskStatusId as varchar(50))  
  END  
  insert into aims_debugging values('1', @vSQL, GETDATE())  
  EXECUTE  sp_executesql  @vSQL       
END
GO
/****** Object:  Table [dbo].[AIMS_NOTES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_NOTES](
	[NOTE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[USER_NAME] [varchar](50) NULL,
	[NOTES] [varchar](2000) NULL,
	[NOTES_DTTM] [datetime] NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[NOTE_TYPE_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_NOTES] PRIMARY KEY CLUSTERED 
(
	[NOTE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [AIMS_NOTES_IDX1] ON [dbo].[AIMS_NOTES] 
(
	[PATIENT_ID] ASC
)
INCLUDE ( [NOTE_ID],
[NOTE_TYPE_ID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AIMS_INVOICE]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_INVOICE](
	[INVOICE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[INVOICE_NO] [varchar](255) NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[INVOICE_DATE] [varchar](50) NULL,
	[INVOICE_AMOUNT_RECEIVED] [varchar](50) NULL,
	[GENERATED_YN] [varchar](1) NULL,
	[LOCKED_YN] [varchar](1) NULL,
	[LATE_INVOICE_YN] [varchar](1) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[CANCELLED_YN] [varchar](1) NULL,
	[DOCTOR_OWING] [varchar](1) NULL,
	[LATE_INVOICE_SENT] [varchar](1) NULL,
	[LATE_INVOICE_SENT_DATE] [varchar](50) NULL,
	[INVOICE_SENT_WAYBILL_NO] [varchar](50) NULL,
	[GUARANTOR_ACCOUNT_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_INVOICE] PRIMARY KEY CLUSTERED 
(
	[INVOICE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX1_AIMS_INVOICE] ON [dbo].[AIMS_INVOICE] 
(
	[INVOICE_NO] ASC,
	[PATIENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
ALTER INDEX [IDX1_AIMS_INVOICE] ON [dbo].[AIMS_INVOICE] DISABLE
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX1_AIMS_INVOICE_old] ON [dbo].[AIMS_INVOICE] 
(
	[INVOICE_NO] ASC,
	[PATIENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
ALTER INDEX [IDX1_AIMS_INVOICE_old] ON [dbo].[AIMS_INVOICE] DISABLE
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_SERVICE_PROVIDER_GET]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_SERVICE_PROVIDER_GET]        
    @ServiceProviderID varchar(255)    
as       
 declare @vSQL  nvarchar(500)      
    
SELECT       
  b.supplier_type_desc,     
  b.SUPPLIER_TYPE_ID,     
  c.service_provider_id,     
  c.service_provider_name,    
  c.service_provider_phone,     
  c.service_provider_fax_no,     
  c.service_provider_email,  
  d.User_Full_Name,
  c.ADMIN_NAME,
  c.ADMIN_TEL_PHONE,
  c.ADMIN_FAX_NO,
  c.ADMIN_EMAIL     
    FROM aims_patient a,    
   aims_supplier_types b,    
         AIMS_PATIENT_SERVICE_PROVIDERS c,   
         AIMS_USERS d   
   WHERE     
    c.service_provider_id = @ServiceProviderID    
    and a.patient_id = c.patient_id    
  AND c.patient_id = a.patient_id    
     AND b.SUPPLIER_TYPE_ID = c.SUPPLIER_TYPE_ID  
     AND d.User_Name = c.user_name       
ORDER BY 1, 2, 3, 4
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_ADMIN_CLOSED_FILES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENTS_ADMIN_CLOSED_FILES]                
AS                        
BEGIN                        
              select  a.FILE_ASSIGNED_TO_USERID ,         
a.patient_file_no FILE_NO,        
dbo.getduedate(b.MODIFIED_DATE) COURIER_DUE_DATE  ,      
--dbo.getduedate(a.FILE_COURIER_DATE) COURIER_DUE_DATE  ,      
a.IN_PATIENT,      
a.OUT_PATIENT,      
a.RMR,      
a.FLIGHT,      
a.TRANSPORT,      
a.ASSIST,      
a.REPAT,
a.HIGH_COST
from         
aims_patient a,AIMS_A_PATIENT b where a.CREATION_DTTM >='01 January 2018' and       
a.SENT_TO_ADMIN = 'Y' and a.CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'N'         
and (a.FILE_COURIER_DATE is null or a.FILE_COURIER_DATE ='')     
and b.PATIENT_ID = a.PATIENT_ID     
and b.AUDIT_ID = (select MIN(AUDIT_ID) from     
AIMS_A_PATIENT xx where xx.PATIENT_ID = b.PATIENT_ID and xx.PATIENT_FILE_ACTIVE_YN = 'N')    
order by a.HIGH_COST desc,3  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_ACTIVE_FILES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENTS_ACTIVE_FILES]   
AS  
begin  
SELECT   a.*  
    FROM aims_patient a  
   WHERE cancelled = 'N'  
     AND a.patient_file_active_yn = 'Y'  
     AND (patient_discharge_date IS NULL OR patient_discharge_date = '')  
     AND a.pending = 'N'  
     AND file_operator_to_userid IS NOT NULL       
ORDER BY CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC)  
END
GO
/****** Object:  View [dbo].[AIMS_PATIENT_VW]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[AIMS_PATIENT_VW]                                          
AS                 
SELECT   top 45300 -- ap.PATIENT_FILE_NO,                  
 UPPER(AP.Patient_Last_Name)+ ' ' + UPPER(PATIENT_FIRST_NAME) +  ' (' + UPPER(AP.PATIENT_INITIALS) + ') (' +  UPPER(ATT.Title_desc) + ')' AS PATIENT_NAME,                                          
 ap.*                                          
FROM AIMS_PATIENT AS ap                                          
LEFT OUTER JOIN AIMS_COMPANIES AS acc ON  AP.COMPANY_ID = ACC.COMPANY_ID                                          
LEFT OUTER JOIN AIMS_TITLE  AS att ON  att.title_id  = ap.title_id                                          
WHERE ap.PATIENT_FIRST_NAME IS NOT NULL and ap.PATIENT_ID not in (44859, 44860, 46246)    
--and (ap.patient_file_no  is not null or ap.patient_file_no <>'')                         
and (patient_file_no in ('99/9999','88/8888') or CREATION_DTTM >='01 January 2014')  
ORDER BY  PATIENT_NAME                  
,  (CAST (RTRIM(LTRIM(substring (patient_file_no, 1, 2))) AS NUMERIC) + 0) desc,                       
(CAST (RTRIM(LTRIM(substring (patient_file_no, 4, 5))) AS NUMERIC) + 0) desc
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_VERIFY]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_VERIFY]        
    @PatientFileNo varchar(50) = ''      
as       
 SELECT  patient_first_name      
        + ' '      
        + patient_last_name "Patient_Name", Guarantor_Name, PATIENT_FILE_ACTIVE_YN , PATIENT_ID,  
        ap.GUARANTOR_ID      
   FROM aims_patient as ap LEFT OUTER JOIN aims_title as att ON att.title_id = ap.title_id      
 left outer join aims_guarantor as ag on ag.guarantor_id = ap.guarantor_id       
  WHERE ap.patient_file_no = @PatientFileNo
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_FILES_PENDED]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENTS_FILES_PENDED]  
AS  
BEGIN  
SELECT   a.patient_file_no, a.patient_admission_date,f.User_Full_Name,  
         LTRIM (  dbo.INITCAP (e.title_desc)  
                + ' '  
                + dbo.INITCAP (a.patient_first_name)  
                + ' '  
                + dbo.INITCAP (a.patient_last_name)  
               ) patient_name,  
         a.pend_date,  
         datediff (d,  
                   CONVERT (smalldatetime, a.pend_date, 103),  
                   getdate ()  
                  ) "PendDays",  
         g.guarantor_name  
    FROM aims_patient a,  
         aims_title e,  
         aims_a_patient d,  
         aims_users f,  
         aims_guarantor g  
   WHERE a.cancelled = 'N'  
     AND a.pend_date IS NOT NULL  
     --AND datediff (d, CONVERT (smalldatetime, a.pend_date, 103), getdate ()) >= 10  
     AND e.title_id = a.title_id  
     AND d.patient_id = a.patient_id  
     AND d.audit_id = (SELECT MAX (e.audit_id)  
                         FROM aims_a_patient e  
                        WHERE e.patient_id = a.patient_id AND e.pending = 'Y')  
     AND f.user_name = d.modified_user  
     AND g.guarantor_id = a.guarantor_id  
ORDER BY 5,6 desc
-- CAST (substring (a.patient_file_no, 1, 2) AS NUMERIC)  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_SERVICE_PROVIDERS_GET]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_PATIENT_SERVICE_PROVIDERS_GET]              
    @PatientID int          
as             
 declare @vSQL  nvarchar(500)            
          
SELECT             
  b.supplier_type_desc, 
  c.service_provider_name,
  c.service_provider_id,          
  c.service_provider_phone, 
  c.service_provider_fax_no,           
  c.service_provider_email ,        
  d.User_Full_Name,      
  e.MODIFIED_DATE,  
  c.ADMIN_EMAIL,  
  c.ADMIN_FAX_NO,  
  c.ADMIN_NAME,  
  c.ADMIN_TEL_PHONE  
    FROM aims_patient a,          
   aims_supplier_types b,          
         AIMS_PATIENT_SERVICE_PROVIDERS c  ,        
         AIMS_USERS d,      
         AIMS_A_PATIENT_SERVICE_PROVIDERS e      
   WHERE           
  a.patient_id = @PatientID           
  AND c.patient_id = a.patient_id          
     AND b.SUPPLIER_TYPE_ID = c.SUPPLIER_TYPE_ID      
     AND e.SERVICE_PROVIDER_ID = c.SERVICE_PROVIDER_ID      
     AND e.AUDIT_ID = (SELECT MIN(AUDIT_ID) FROM AIMS_A_PATIENT_SERVICE_PROVIDERS F where F.SERVICE_PROVIDER_ID = c.SERVICE_PROVIDER_ID)      
     AND d.User_Name = c.user_name         
ORDER BY 1, 2, 3, 4
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_ADMIN_UNAssigned_FILES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENTS_ADMIN_UNAssigned_FILES]            
AS            
BEGIN            
SELECT b.GUARANTOR_NAME , 
c.MODIFIED_USER ,
d.SUPPLIER_NAME  , 
c.MODIFIED_DATE  ,
a.*
from AIMS_PATIENT a     
left outer join aims_title e on e.TITLE_ID = a.TITLE_ID    
left outer join aims_guarantor b on b.guarantor_id = a.guarantor_id    
inner join AIMS_A_PATIENT c on c.PATIENT_ID = a.PATIENT_ID and  c.AUDIT_ID = (select MIN(AUDIT_ID) from  AIMS_A_PATIENT xx where xx.PATIENT_ID = a.PATIENT_ID and SENT_TO_ADMIN = 'Y') 
left outer join AIMS_SUPPLIER d on d.SUPPLIER_ID = a.SUPPLIER_ID             
where a.cancelled = 'N' and a.SENT_TO_ADMIN = 'Y' and     
(a.FILE_ASSIGNED_TO_USERID is null or a.FILE_ASSIGNED_TO_USERID = '') and     
(a.PATIENT_DISCHARGE_DATE is not  null or a.PATIENT_DISCHARGE_DATE  <> '')     
AND (a.pending = 'N' OR a.pending IS NULL)   and a.PATIENT_FILE_COURIER_YN = 'N'          
ORDER BY 1 desc    
                                
--select b.GUARANTOR_NAME , c.MODIFIED_USER ,a.*, d.SUPPLIER_NAME from AIMS_PATIENT a         
--left outer join AIMS_GUARANTOR b on b.GUARANTOR_ID = a.GUARANTOR_ID        
--inner join AIMS_A_PATIENT c on c.PATIENT_ID = a.PATIENT_ID          
--left outer join AIMS_SUPPLIER d on d.SUPPLIER_ID = a.SUPPLIER_ID        
--where (a.FILE_ASSIGNED_TO_USERID is null or a.FILE_ASSIGNED_TO_USERID = '') and a.SENT_TO_ADMIN  = 'Y'        
--and a.CREATION_DTTM >= '01 January 2018' and a.CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y'        
--and c.AUDIT_ID = (select MIN(AUDIT_ID) from  AIMS_A_PATIENT where PATIENT_ID = a.PATIENT_ID)     
--and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '')       
END     
    
    
--SELECT a.patient_id, a.patient_file_no, a.patient_admission_date,a.patient_discharge_date,    
--                            LTRIM (      
--                            dbo.INITCAP (e.title_desc)+ ' '+      
--                            dbo.INITCAP (patient_first_name) + ' '+     
--                            dbo.INITCAP (patient_last_name) ) patient_name,B.GUARANTOR_NAME,    
--                            a.late_log_yn, a.late_log_date, a.out_patient, a.in_patient      
--                            from AIMS_PATIENT a     
--                            left outer join aims_title e on e.TITLE_ID = a.TITLE_ID    
--                            left outer join aims_guarantor b on b.guarantor_id = a.guarantor_id    
--                            where cancelled = 'N' and SENT_TO_ADMIN = 'Y' and     
--                            (FILE_ASSIGNED_TO_USERID is null or FILE_ASSIGNED_TO_USERID = '') and     
--                            (PATIENT_DISCHARGE_DATE is not  null or PATIENT_DISCHARGE_DATE  <> '')     
--                            AND (a.pending = 'N' OR a.pending IS NULL)   and a.PATIENT_FILE_COURIER_YN = 'N'     
--                            ORDER BY 1 desc
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_SERVICE_PROVIDER_ADD]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_SERVICE_PROVIDER_ADD]          
 @ServiceProviderID INT output,                
    @ServiceProviderType int,      
    @PatientFileNo varchar(500),      
    @ServiceProviderName varchar(500),      
    @ServiceProviderPhone varchar(500),      
    @ServiceProviderFax varchar(500),      
    @ServiceProviderEmail varchar(500),      
    @LoggedInUser varchar(50),
    @ServiceProviderAdminName varchar(500),
    @ServiceProviderAdminTel varchar(500),
    @ServiceProviderAdminFax varchar(500),
    @ServiceProviderAdminEmail varchar(500)
as         
declare @PatientID int      
      
select @PatientID = patient_id from AIMS_PATIENT where PATIENT_FILE_NO = @PatientFileNo;      
      
IF (@ServiceProviderID > 0)      
 BEGIN      
  update AIMS_PATIENT_SERVICE_PROVIDERS set       
   supplier_type_id = @ServiceProviderType,      
   service_provider_name = @ServiceProviderName ,      
   service_provider_phone = @ServiceProviderPhone,       
   service_provider_fax_no = @ServiceProviderFax,       
   service_provider_email = @ServiceProviderEmail,
   ADMIN_NAME = @ServiceProviderAdminName,
   ADMIN_TEL_PHONE = @ServiceProviderAdminTel,
   ADMIN_FAX_NO = @ServiceProviderAdminFax,
   ADMIN_EMAIL = @ServiceProviderAdminEmail   
   Where  Service_Provider_id = @ServiceProviderID      
       
   INSERT INTO AIMS_A_PATIENT_SERVICE_PROVIDERS (    
     MODIFIED_USER ,    
  MODIFIED_ACTION,    
  MODIFIED_DATE ,    
  SERVICE_PROVIDER_ID,    
  PATIENT_ID,    
  SUPPLIER_TYPE_ID ,    
  SERVICE_PROVIDER_NAME,    
  SERVICE_PROVIDER_PHONE,    
  SERVICE_PROVIDER_FAX_NO,    
  SERVICE_PROVIDER_EMAIL, ADMIN_NAME, ADMIN_TEL_PHONE, ADMIN_FAX_NO, ADMIN_EMAIL)     
   values (    
    @LoggedInUser,    
    'UPDATE',    
    GETDATE(),    
    @ServiceProviderID,    
    @PatientID,    
    @ServiceProviderType,    
    @ServiceProviderName,    
    @ServiceProviderPhone,    
    @ServiceProviderFax,    
    @ServiceProviderEmail, @ServiceProviderAdminName, @ServiceProviderAdminTel,@ServiceProviderAdminFax, @ServiceProviderAdminEmail )    
       
 END        
ELSE      
 BEGIN      
  insert into AIMS_PATIENT_SERVICE_PROVIDERS (      
      patient_id,       
      supplier_type_id,      
      service_provider_name,       
      service_provider_phone,      
      service_provider_fax_no,      
      service_provider_email,   
      user_name,  
      ADMIN_NAME, 
      ADMIN_TEL_PHONE, 
      ADMIN_FAX_NO, 
      ADMIN_EMAIL 
      )      
   values      
    ( @PatientID,       
     @ServiceProviderType,       
     @ServiceProviderName,      
     @ServiceProviderPhone,      
     @ServiceProviderFax,      
     @ServiceProviderEmail,  
     @LoggedInUser,
     @ServiceProviderAdminName, 
     @ServiceProviderAdminTel,
     @ServiceProviderAdminFax, 
     @ServiceProviderAdminEmail)      
           
   SELECT @ServiceProviderID = IDENT_CURRENT('AIMS_PATIENT_SERVICE_PROVIDERS')      
       
       
 INSERT INTO AIMS_A_PATIENT_SERVICE_PROVIDERS (    
      MODIFIED_USER ,    
   MODIFIED_ACTION,    
   MODIFIED_DATE ,    
   SERVICE_PROVIDER_ID,    
   PATIENT_ID,    
   SUPPLIER_TYPE_ID ,    
   SERVICE_PROVIDER_NAME,    
   SERVICE_PROVIDER_PHONE,    
   SERVICE_PROVIDER_FAX_NO,    
   SERVICE_PROVIDER_EMAIL,  ADMIN_NAME, ADMIN_TEL_PHONE, ADMIN_FAX_NO, ADMIN_EMAIL)     
    values (    
     @LoggedInUser,    
     'ADD',    
     GETDATE(),    
     @ServiceProviderID,    
     @PatientID,    
     @ServiceProviderType,    
     @ServiceProviderName,    
     @ServiceProviderPhone,    
     @ServiceProviderFax,    
     @ServiceProviderEmail, @ServiceProviderAdminName, @ServiceProviderAdminTel,@ServiceProviderAdminFax, @ServiceProviderAdminEmail)       
 END
GO
/****** Object:  View [dbo].[AIMS_PATIENT_INFO_VW]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
create view [dbo].[AIMS_PATIENT_INFO_VW] as (
	select * from aims_Patient
)
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_EMAILS_GET]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[AIMS_PATIENT_EMAILS_GET]                    
 @PATIENT_FILE_NO varchar(50),            
 @EMAIL_KEYWORD   varchar(255) = ''                
AS                    
BEGIN                    
 DECLARE @PATIENT_ID INT, @vSQL nvarchar(4000)                    
                     
 SELECT @PATIENT_ID = PATIENT_ID FROM AIMS_PATIENT WHERE PATIENT_FILE_NO = @PATIENT_FILE_NO                    
                     
 SET @vSQL = ' SELECT DISTINCT ' +            
   ' B.EMAIL_SUBJECT, ' +                    
   ' B.EMAIL_RECEIVED_DTTM, ' +                    
   ' B.EMAIL_SENT_FROM_NAME, ' +                 
   ' B.EMAIL_SENT_FROM_ADDRESS, ' +                    
   ' A.CREATION_DTTM, ' +            
   ' A.PATIENT_ENQUIRY_ID, ' +           
   ' A.PRIORITY_ID, ' +                 
   ' C.MAIL_READ_YN, ' +            
   ' B.EMAIL_SENT_TO_CC, ' +            
   ' B.EMAIL_INDEXED_BY, ' +            
   ' D.USER_FULL_NAME,  ' +            
   ' B.EMAIL_SENT_TO ' +   
' FROM ' +            
   ' AIMS_EWS_PATIENT_ENQUIRY A ' +            
   ' INNER JOIN AIMS_EWS_EMAILS B on B.EMAIL_ID = A.EMAIL_ID ' +            
   ' LEFT OUTER JOIN AIMS_EWS_OPERATOR_MAILS C on C.PATIENT_ENQUIRY_ID = a.PATIENT_ENQUIRY_ID ' +            
   ' LEFT OUTER JOIN AIMS_USERS D on D.USER_NAME = b.EMAIL_INDEXED_BY ' +            
   ' WHERE A.PATIENT_ID = ' + cast(@PATIENT_ID as varchar(50))            
   IF(@EMAIL_KEYWORD IS NOT NULL)            
   BEGIN            
 IF(@EMAIL_KEYWORD <> '')            
 BEGIN            
  SET @vSQL = @vSQL + ' AND B.EMAIL_SUBJECT LIKE ''%'+ @EMAIL_KEYWORD +'%'''              
 END            
   END            
   SET @vSQL = @vSQL + ' and a.active_yn  =''Y'' ORDER BY B.EMAIL_RECEIVED_DTTM DESC, A.PRIORITY_ID ASC'             
               
   EXECUTE  sp_executesql  @vSQL                     
END
GO
/****** Object:  Table [dbo].[AIMS_PATIENT_GUARANTEES]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_PATIENT_GUARANTEES](
	[GUARANTEE_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NOT NULL,
	[SUPPLIER_ID] [numeric](18, 0) NOT NULL,
	[SERVICE_PROVIDER_ID] [numeric](18, 0) NOT NULL,
	[EXPIRY_DTTM] [datetime] NULL,
	[DIAGNOSIS_PROCEDURE] [varchar](255) NULL,
	[ADMISSION_CODE] [varchar](50) NULL,
	[ATTENTION] [varchar](50) NULL,
	[EXCLUSIONS] [varchar](500) NULL,
	[COMMENTS] [varchar](50) NULL,
	[GUARANTEE_POD] [varchar](1000) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[ACTIVE_YN] [varchar](1) NOT NULL,
	[WARD_TYPE_ID] [numeric](18, 0) NULL,
	[ADMISSION_CODE_OTHER] [varchar](250) NULL,
	[LOADED_BY] [varchar](50) NULL,
	[GOP_AMOUNT] [varchar](50) NULL,
	[GOP_APPROVED_YN] [varchar](1) NULL,
	[GOP_START_DATE] [varchar](50) NULL,
	[GOP_END_DATE] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_PATIENT_GUARANTEES] PRIMARY KEY CLUSTERED 
(
	[GUARANTEE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_FILE_UNLOCK]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_FILE_UNLOCK]    
 @PatientFileNo varchar(50) = '',   
 @UserSignedOn varchar(50) = ''  
as   
 declare @vSQL  nvarchar(500)  
   
 set @vSQL = 'Update aims_Patient set patient_file_active_yn = ''Y'' where patient_file_no = ''' + cast(@PatientFileNo as varchar(50)) + ''''  
 EXECUTE  sp_executesql  @vSQL  
  
 insert into aims_a_patient  
 select   
    @UserSignedOn,  
    'PATIENT FILE UNLOCKED',  
    getdate(),  
    PATIENT_ID,  
    PATIENT_FILE_NO,  
    PATIENT_INITIALS,  
    PATIENT_FIRST_NAME,  
    PATIENT_MIDDLE_NAME,  
    PATIENT_LAST_NAME,  
    PATIENT_ID_NO,  
    COMPANY_ID,  
    TITLE_ID,  
    ADDRESS_ID,  
    PATIENT_HOME_TEL_NO,  
    PATIENT_WORK_TEL_NO,  
    PATIENT_FAX_NO,  
    PATIENT_MOBILE_NO,  
    PATIENT_EMAIL_ADDRESS,  
    GUARANTOR_ID,  
    GUARANTOR_REF_NO,  
    PATIENT_FILE_ACTIVE_YN,  
    PATIENT_NATIONALITY,  
    PATIENT_GUARANTOR_AMOUNT,  
    SUPPLIER_ID,  
    PATIENT_FILE_COURIER_YN,  
    PATIENT_ADMISSION_DATE,  
    PATIENT_DISCHARGE_DATE,  
    PATIENT_DIAGNOSIS,  
    CREATION_DTTM,  
    PATIENT_EMERGENCY_CONTACT_NAME,  
    PATIENT_EMERGENCY_CONTACT_NO,  
     IN_PATIENT,  
    OUT_PATIENT,   
    ASSIST,
	FILE_COURIER_DATE       ,
	FLIGHT ,
	REPAT ,
	CANCELLED ,
	COURIER_WAYBILL_NO                                                                                                                                                                                                                                              ,
	TRANSPORT ,
	GUARANTOR247NO,                                                                                                                                                                                                                                                  
	GUARANTOR247EMAIL,                                                                                                                                                                                                                                               
	FILE_ASSIGNED_TO_USERID,                                                                                                                                                                                                                                         
	COURIER_RECEIPT_DATE    ,
	PATIENT_ASSIST_TYPE_ID ,
	PATIENT_TRANSPORT_TYPE_ID, 
	LATE_LOG_YN ,
	LATE_LOG_DATE       
     from aims_patient where patient_file_no = @PatientFileNo
GO
/****** Object:  Table [dbo].[AIMS_PATIENT_FILE_TASKS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_PATIENT_FILE_TASKS](
	[PATIENT_FILE_TASK_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TASK_ID] [numeric](18, 0) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NOT NULL,
	[USER_ID] [varchar](50) NOT NULL,
	[DUE_DATE] [datetime] NOT NULL,
	[COMPLETION_DATE] [datetime] NULL,
	[DETAILS] [varchar](2000) NOT NULL,
	[ACTIVE_YN] [varchar](1) NOT NULL,
	[LOADED_BY] [varchar](50) NULL,
	[CREATION_DATE] [datetime] NULL,
	[PRIORITY_ID] [numeric](18, 0) NULL,
	[TASK_STATUS_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_PATIENT_FILE_TASKS] PRIMARY KEY CLUSTERED 
(
	[PATIENT_FILE_TASK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AIMS_PATIENT_GOP]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_PATIENT_GOP](
	[GOP_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[CONTACT_NAME] [varchar](150) NULL,
	[EMAIL_ADDRESS] [varchar](100) NULL,
	[GOP_CONSOLIDATED_AMOUNT] [varchar](50) NULL,
	[GOP_START_DATE] [varchar](50) NULL,
	[GOP_END_DATE] [varchar](50) NULL,
	[ROOM_TYPE_ID] [numeric](18, 0) NULL,
	[GOP_NOTES] [varchar](500) NULL,
	[GUARANTEE_POD] [varchar](500) NULL,
	[CREATED_BY] [varchar](50) NULL,
	[GOP_APPROVED_YN] [varchar](10) NULL,
	[CREATION_DTTM] [date] NULL,
	[ACTIVE_YN] [varchar](50) NULL,
	[currency] [varchar](10) NULL,
 CONSTRAINT [PK_AIMS_PATIENT_GOP] PRIMARY KEY CLUSTERED 
(
	[GOP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[AIMS_GUARANTOR_REFS_VW]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AIMS_GUARANTOR_REFS_VW]            
AS            
select top 8000
  UPPER(AP.GUARANTOR_REF_NO) AS GUARANTOR_REF_NO,            
 PATIENT_FILE_NO  
  from AIMS_PATIENT AP
INNER JOIN AIMS_GUARANTOR AG on AG.GUARANTOR_ID = AP.GUARANTOR_ID
WHERE AP.GUARANTOR_REF_NO IS NOT NULL AND AP.GUARANTOR_REF_NO  <> ''
ORDER BY ap.GUARANTOR_REF_NO
GO
/****** Object:  StoredProcedure [dbo].[AIMS_NOTE_GET]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_NOTE_GET]        
@NoteID varchar(50)
AS
 declare @vSQL  nvarchar(500)      
       
 SELECT * from AIMS_NOTES a, AIMS_NOTE_TYPES b where a.NOTE_ID = @NoteID and b.NOTE_TYPE_ID = a.NOTE_TYPE_ID
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_COMPLETE_APPOINTMENTS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_COMPLETE_APPOINTMENTS]        
@AppointmentID VARCHAR(50),        
@UserName VARCHAR(50)        
AS        
BEGIN        
 delete from Appointments where uniqueid = (select CALENDER_APPOINTMENT_ID from AIMS_APPOINTMENTS where APPOINTMENT_ID = @AppointmentID)       
 UPDATE AIMS_APPOINTMENTS SET APPOINTMENT_STATUS = 'COMPLETED', CANCELLED_YN='N' where APPOINTMENT_ID = @AppointmentID        

 insert AIMS_A_APPOINTMENTS (
MODIFIED_USER,
MODIFIED_ACTION,
MODIFIED_DATE,
APPOINTMENT_ID,
APPOINTMENT_SUBJECT,
APPOINTMENT_ADDRESS,
APPOINTMENT_DATE,
APPOINTMENT_TIME_HOUR,
APPOINTMENT_TIME_MINUTE,
REMINDER_YN,
REMINDER_PERIOD,
TRANSPORT_YN,
TRANSPORT_TYPE_ID,
PICK_UP_TIME_HOUR,
PICK_UP_TIME_MINUTE,
DROP_UP_TIME_HOUR,
DROP_UP_TIME_MINUTE,
PATIENT_ID,
CREATED_DTTM,
CREATED_BY,
APPOINTMENT_NOTE,
APPOINTMENT_TIME,
PICK_UP_TIME,
DROP_OFF_TIME,
TRANSLATOR_YN)
 select 
@UserName,
'COMPLETED',
GETDATE(),
APPOINTMENT_ID,
APPOINTMENT_SUBJECT,
APPOINTMENT_ADDRESS,
APPOINTMENT_DATE,
APPOINTMENT_TIME_HOUR,
APPOINTMENT_TIME_MINUTE,
REMINDER_YN,
REMINDER_PERIOD,
TRANSPORT_YN,
TRANSPORT_TYPE_ID,
PICK_UP_TIME_HOUR,
PICK_UP_TIME_MINUTE,
DROP_UP_TIME_HOUR,
DROP_UP_TIME_MINUTE,
PATIENT_ID,
CREATED_DTTM,
CREATED_BY,
APPOINTMENT_NOTE,
APPOINTMENT_TIME,
PICK_UP_TIME,
DROP_OFF_TIME,
TRANSLATOR_YN
  from AIMS_APPOINTMENTS where APPOINTMENT_ID = @AppointmentID
 
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_CANCEL_APPOINTMENTS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[AIMS_PATIENT_CANCEL_APPOINTMENTS]        
@AppointmentID VARCHAR(50),        
@UserName VARCHAR(50)        
AS        
BEGIN        
 delete from Appointments where uniqueid = (select CALENDER_APPOINTMENT_ID from AIMS_APPOINTMENTS where APPOINTMENT_ID = @AppointmentID)       
 UPDATE AIMS_APPOINTMENTS SET APPOINTMENT_STATUS ='CANCELLED', CANCELLED_YN = 'Y' where APPOINTMENT_ID = @AppointmentID        
 

 insert AIMS_A_APPOINTMENTS (
MODIFIED_USER,
MODIFIED_ACTION,
MODIFIED_DATE,
APPOINTMENT_ID,
APPOINTMENT_SUBJECT,
APPOINTMENT_ADDRESS,
APPOINTMENT_DATE,
APPOINTMENT_TIME_HOUR,
APPOINTMENT_TIME_MINUTE,
REMINDER_YN,
REMINDER_PERIOD,
TRANSPORT_YN,
TRANSPORT_TYPE_ID,
PICK_UP_TIME_HOUR,
PICK_UP_TIME_MINUTE,
DROP_UP_TIME_HOUR,
DROP_UP_TIME_MINUTE,
PATIENT_ID,
CREATED_DTTM,
CREATED_BY,
APPOINTMENT_NOTE,
APPOINTMENT_TIME,
PICK_UP_TIME,
DROP_OFF_TIME,
TRANSLATOR_YN)
 select 
@UserName,
'CANCELLED',
GETDATE(),
APPOINTMENT_ID,
APPOINTMENT_SUBJECT,
APPOINTMENT_ADDRESS,
APPOINTMENT_DATE,
APPOINTMENT_TIME_HOUR,
APPOINTMENT_TIME_MINUTE,
REMINDER_YN,
REMINDER_PERIOD,
TRANSPORT_YN,
TRANSPORT_TYPE_ID,
PICK_UP_TIME_HOUR,
PICK_UP_TIME_MINUTE,
DROP_UP_TIME_HOUR,
DROP_UP_TIME_MINUTE,
PATIENT_ID,
CREATED_DTTM,
CREATED_BY,
APPOINTMENT_NOTE,
APPOINTMENT_TIME,
PICK_UP_TIME,
DROP_OFF_TIME,
TRANSLATOR_YN
  from AIMS_APPOINTMENTS where APPOINTMENT_ID = @AppointmentID
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_ATTACH_VISA_LETTER]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_ATTACH_VISA_LETTER]    
 @VisaLetterID  varchar(25),    
 @VisaLetterFileName varchar(1000)    
AS    
BEGIN    
 DECLARE @AimsVisaLettersPOD varchar(2000),@DateMonth varchar(20), @DateYear varchar(30)    
     
 SELECT @AimsVisaLettersPOD = LIMITATION_VALUE FROM AIMS_LIMITATION WHERE LIMITATION_CD = 'AIMS_EMAIL_POD_VISA_LETTERS'    
     
 SET  @DateMonth =  datename(mm,getdate())    
 SET @DateYear =  datename(yy,getdate())    
     
 UPDATE AIMS_VISA_LETTERS    
  SET VISA_LETTER_POD = @VisaLetterFileName    
 WHERE VISA_LETTER_ID = @VisaLetterID    
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_ADD_VISA_LETTER]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_ADD_VISA_LETTER]        
 @VisaLetterID varchar(50) output,        
 @LoggedOnUser varchar(50),        
 @VISALetterFile varchar(50),        
 @EmbassyName varchar(50),        
 @EmbassyAdd1 varchar(50),        
 @EmbassyAdd2 varchar(50),        
 @EmbassyAdd3 varchar(50),        
 @EmbassyAdd4 varchar(50),        
 @EmbassyAdd5 varchar(50),        
 @Country varchar(50),        
 @PatientName varchar(50),        
 @PatientPassportNo varchar(50),        
 @PatientPassportIssueDt varchar(50),        
 @PatientPassportExpiryDt varchar(50),        
 @EscortName varchar(50),        
 @EscortRelationToPatient varchar(50),        
 @EscortPassportNo varchar(50),        
 @EscortPassportIssueDt varchar(50),        
 @EscortPassportExpiryDt varchar(50),        
 @EscortHisHer varchar(50),        
 @CountryOfTreatment varchar(50),        
 @TreatingDoctor varchar(50),        
 @TreatingDoctorProfession varchar(50),        
 @TreatingHospital varchar(50),        
 @AimsCoOrdinator varchar(50),        
 @TreatmentDate varchar(50),        
 @PatientResidingAddress varchar(200),        
 @AddressType varchar(30),        
 @PatientFileNo varchar(30),       
 @EmbassyID varchar(30) ,  
 @LoadedBy   varchar(50)  
AS        
BEGIN        
 DECLARE @AddressID INT, @PatientID INT        
         
 SELECT @PatientID = PATIENT_ID FROM AIMS_PATIENT  WHERE PATIENT_FILE_NO = @PatientFileNo        
         
 IF (@VisaLetterID IS NULL)        
 BEGIN        
  INSERT INTO AIMS_ADDRESS (        
   ADDRESS_TYPE_ID,        
   ADDRESS1,        
   ADDRESS2,        
   ADDRESS3,        
   ADDRESS4,        
   ADDRESS5,        
   COUNTRY_ID,        
   ACTIVE_YN        
  )VALUES(        
   @AddressType,        
   @EmbassyAdd1,        
   @EmbassyAdd2,        
   @EmbassyAdd3,        
   @EmbassyAdd4,        
   @EmbassyAdd5,        
   @Country,        
   'Y'        
  )        
          
  SET @AddressID  = IDENT_CURRENT('AIMS_ADDRESS');        
          
  INSERT INTO AIMS_VISA_LETTERS(        
   EMBASSY_NAME,        
   ADDRESS_ID,        
   PATIENT_ID,        
   PATIENT_PASSPORT_ISSUE_DATE,        
   PATIENT_PASSPORT_EXPIRY_DATE,        
   TREATMENT_HOSPITAL_ID,        
   TREATMENT_DOCTOR_PROVIDER_ID,        
   TREATMENT_APPOINTMENT_DATE,        
   ESCORT_NAME,        
   ESCORT_RELATION_ID,        
   ESCORT_HIS_HER,        
   ESCORT_PASSPORT_NO,        
   ESCORT_PASSPORT_ISSUE_DATE,        
   ESCORT_PASSPORT_EXPIRY_DATE,      
   EMBASSY_ID,  
   LOADED_BY  
  )VALUES(        
   @EmbassyName,        
   @AddressID,        
   @PatientID,        
   CONVERT (datetime, @PatientPassportIssueDt ,103),        
   CONVERT (datetime, @PatientPassportExpiryDt ,103),        
   @TreatingHospital,         
   @TreatingDoctor,         
   CONVERT (datetime, @TreatmentDate ,103),        
   @EscortName,        
   @EscortRelationToPatient,         
   @EscortHisHer,        
   @EscortPassportNo,         
   CONVERT (datetime, @EscortPassportIssueDt ,103),         
   CONVERT (datetime, @EscortPassportExpiryDt ,103),      
   @EmbassyID  , @LoadedBy    
  )        
          
  SET @VisaLetterID = IDENT_CURRENT('AIMS_VISA_LETTERS')        
 END        
 ELSE        
 BEGIN        
  SELECT @AddressID = ADDRESS_ID from AIMS_VISA_LETTERS        
          
  UPDATE AIMS_ADDRESS SET         
   ADDRESS_TYPE_ID = @AddressType,        
   ADDRESS1 = @EmbassyAdd1,        
   ADDRESS2 = @EmbassyAdd2,        
   ADDRESS3 = @EmbassyAdd3,        
   ADDRESS4 = @EmbassyAdd4,        
   ADDRESS5 = @EmbassyAdd5,       
   COUNTRY_ID = @Country        
  WHERE ADDRESS_ID = @AddressID        
          
  UPDATE AIMS_VISA_LETTERS SET         
   EMBASSY_NAME     = @EmbassyName,        
   PATIENT_PASSPORT_ISSUE_DATE  = CONVERT (datetime, @PatientPassportIssueDt,103),        
   PATIENT_PASSPORT_EXPIRY_DATE = CONVERT (datetime, @PatientPassportExpiryDt,103),        
   TREATMENT_HOSPITAL_ID   = @TreatingHospital,        
   TREATMENT_DOCTOR_PROVIDER_ID = @TreatingDoctor,        
   TREATMENT_APPOINTMENT_DATE  = CONVERT (datetime, @TreatmentDate,103),        
   ESCORT_NAME      = @EscortName,        
   ESCORT_RELATION_ID    = @EscortRelationToPatient,        
   ESCORT_HIS_HER     = @EscortHisHer,        
   ESCORT_PASSPORT_NO    = @EscortPassportNo,        
   ESCORT_PASSPORT_ISSUE_DATE  = CONVERT (datetime, @EscortPassportIssueDt ,103),        
   ESCORT_PASSPORT_EXPIRY_DATE  = CONVERT (datetime, @EscortPassportExpiryDt  ,103) ,      
   EMBASSY_ID = @EmbassyID      
  WHERE VISA_LETTER_ID    = @VisaLetterID        
 END        
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_ADD_SINGLE]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_ADD_SINGLE]
	@PatientFileNo varchar(50) = '' output,
	@UserLoggedOn varchar(50) = '',
	@PendDate varchar(50) = ''
AS
BEGIN
	BEGIN TRANSACTION addPatient  
	DECLARE @LastError INT, 
	@PatientAddressID INT, 
	@PatientID INT
  
	INSERT INTO AIMS_PATIENT (PATIENT_FILE_NO) values ('')
	
	SELECT @PatientFileNo = CAST(Substring(CONVERT(varchar(30),(YEAR(getdate()))),3,2) AS VARCHAR(50)) + '/' + CAST(IDENT_CURRENT('AIMS_PATIENT')  AS VARCHAR(10))                                
    
    SELECT @PatientID = IDENT_CURRENT('AIMS_PATIENT')
    
	INSERT INTO AIMS_NOTES(                                
		USER_NAME,                                
		NOTES,                                
		NOTES_DTTM,                                
		PATIENT_ID, NOTE_TYPE_ID) values(                                
					@UserLoggedOn,                                
					'New File for Patient',                                
					GETDATE(),                                
					@PatientID, 7)

   UPDATE AIMS_PATIENT
		SET 
			PATIENT_FILE_NO = @PatientFileNo,
			TITLE_ID = 10, 
			PATIENT_FIRST_NAME = '', 
			PATIENT_INITIALS = '', 
			PATIENT_LAST_NAME = '',
			PENDING = 'Y',
			PEND_DATE = CONVERT(datetime,@PendDate,103)
			WHERE 
	PATIENT_ID = @PatientID

	INSERT INTO AIMS_A_PATIENT(
		MODIFIED_USER, 
		MODIFIED_ACTION,
		MODIFIED_DATE,
		PATIENT_FILE_NO,
		PATIENT_ID
	)                               
	Values(                         
		@UserLoggedOn,                                
		'ADD',                                
		GETDATE(),                                
		@PatientFileNo,
		@PatientID)
     
	IF (@@ERROR <> 0)                                
	BEGIN     
		ROLLBACK TRANSACTION addPatient                                
	END            
	ELSE                                
	BEGIN
		COMMIT TRANSACTION addPatient                                
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GET_PATIENT_DOCS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_GET_PATIENT_DOCS]                    
 @PatientFileNo varchar(50)                    
AS                    
BEGIN                    
DECLARE @PatientID INT                    
                     
SELECT @PatientID = PATIENT_ID FROM AIMS_PATIENT  WHERE PATIENT_FILE_NO = @PatientFileNo                    
                     
SELECT 'VISA Letter'  DOC_NAME, VISA_LETTER_POD DOC_POD_FOLDER, CREATION_DTTM, VISA_LETTER_ID 'DOCUMENT_ID', vl.LOADED_BY 'CREATED_BY' FROM AIMS_VISA_LETTERS vl where ACTIVE_YN = 'Y' and PATIENT_ID = @PatientID                  
 UNION                  
 SELECT 'Patient Guarantee' DOC_NAME, GUARANTEE_POD  DOC_POD_FOLDER, CREATION_DTTM, GOP_ID 'DOCUMENT_ID', pg.CREATED_BY 'CREATED_BY' FROM AIMS_PATIENT_GOP pg  
 WHERE PATIENT_ID = @PatientID  and ACTIVE_YN = 'Y'              
 UNION                  
 SELECT 'Air-Ambulance Cost Estimate' DOC_NAME, AA_POD  DOC_POD_FOLDER, CREATION_DTTM, AAID 'DOCUMENT_ID', aa.LOADED_BY 'CREATED_Y' FROM AIMS_AA_DETAILS aa                    
 WHERE PATIENT_ID = @PatientID  and ACTIVE_YN = 'Y'                  
 UNION                  
 SELECT 'Accomodation Voucher' DOC_NAME, ACCOMODATION_LETTER  DOC_POD_FOLDER, CREATION_DTTM, ACCOMODATION_BOOKING_ID 'DOCUMENT_ID', av.CREATED_BY 'CREATED_BY' FROM aims_accomodation av                    
 WHERE PATIENT_ID = @PatientID                 
 ORDER BY 3, 1                    
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GET_PATIENT_APPOINTMENTS]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_GET_PATIENT_APPOINTMENTS]  
@PatientFileNo VARCHAR(50)  
AS  
BEGIN  
 DECLARE @PatientID int  
   
 SELECT @PatientID = PATIENT_ID  from aims_patient where patient_file_no = @PatientFileNo  
  
 SELECT   a.*, b.*, c.*  
  FROM aims_appointments a  
  left outer join aims_transport_type b on b.transport_type_id = a.transport_type_id  
  inner join aims_users c on c.user_name = a.created_by  
    WHERE patient_id = @PatientID  
 ORDER BY a.created_dttm DESC  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_FILE_TASK_ADD]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_FILE_TASK_ADD]                  
 @PatientFileTaskID varchar(50) output,                  
 @TaskID varchar(50),                  
 @PatientSubFileID varchar(50),                  
 @TaskUser varchar(50),                  
 @TaskDueDate varchar(50),                  
 @TaskCompletionDate varchar(50),                  
 @TaskDetails varchar(250),                  
 @TaskActiveYN varchar(50),              
 @LoadedBy varchar(50),              
 @PRIORITY_ID  varchar(50),            
 @TASK_STATUS_ID varchar(50)            
AS                  
BEGIN                  
 DECLARE @AddressID INT, @iPatient int , @TaskAction varchar(50)     
                   
 select @iPatient = PATIENT_ID  from AIMS_PATIENT where PATIENT_FILE_NO = @PatientSubFileID       
       
 IF (@PatientFileTaskID IS NULL or @PatientFileTaskID = '')                  
 BEGIN                  
 SET @TaskAction = 'ADD'    
  INSERT INTO AIMS_PATIENT_FILE_TASKS(                  
   TASK_ID,              
   PATIENT_ID,                                                     
   USER_ID ,                                                    
   DUE_DATE,                
   COMPLETION_DATE,                
   DETAILS,              
   ACTIVE_YN,              
   LOADED_BY,              
   PRIORITY_ID,            
   TASK_STATUS_ID             
  )VALUES(              
  @TaskID,              
  @iPatient,              
  @TaskUser,              
  convert(smalldatetime,@TaskDueDate,103),              
  convert(smalldatetime,@TaskCompletionDate, 103),              
  @TaskDetails,              
  @TaskActiveYN,              
  @LoadedBy,              
  @PRIORITY_ID,            
  @TASK_STATUS_ID            
  )                  
                    
  SET @PatientFileTaskID = IDENT_CURRENT('AIMS_PATIENT_FILE_TASKS')                  
 END                  
 ELSE                  
 BEGIN                     
 SET @TaskAction = 'UPDATE'    
  UPDATE AIMS_PATIENT_FILE_TASKS SET                   
   TASK_ID = @TaskID,              
   PATIENT_ID = @iPatient,                                                     
   USER_ID = @TaskUser,                                                    
   DUE_DATE = convert(smalldatetime,@TaskDueDate,103),                
   COMPLETION_DATE = convert(smalldatetime,@TaskCompletionDate, 103),                
   DETAILS = @TaskDetails,              
   ACTIVE_YN = @TaskActiveYN ,              
   LOADED_BY = @LoadedBy,              
   PRIORITY_ID = @PRIORITY_ID,            
   TASK_STATUS_ID = @TASK_STATUS_ID             
  WHERE Patient_File_Task_ID = @PatientFileTaskID                  
 END    
     
INSERT INTO AIMS_A_PATIENT_FILE_TASKS(    
  MODIFIED_USER, MODIFIED_ACTION,    
  MODIFIED_DATE, PATIENT_FILE_TASK_ID, TASK_ID,    
  PATIENT_ID, USER_ID,    
  DUE_DATE, COMPLETION_DATE,    
  DETAILS,     
  LOADED_BY, CREATION_DATE,    
  PRIORITY_ID, TASK_STATUS_ID, ACTIVE_YN) VALUES(    
     @LoadedBy, @TaskAction,    
     GETDATE(), @PatientFileTaskID,    
     @TaskID, @iPatient,                                                     
     @TaskUser,     
     convert(smalldatetime,@TaskDueDate,103),                
     convert(smalldatetime,@TaskCompletionDate, 103), @TaskDetails,              
     (select LOADED_BY from AIMS_PATIENT_FILE_TASKS where PATIENT_FILE_TASK_ID = @PatientFileTaskID),     
     (select CREATION_DATE from AIMS_PATIENT_FILE_TASKS where PATIENT_FILE_TASK_ID = @PatientFileTaskID),    
     @PRIORITY_ID, @TASK_STATUS_ID , 'Y'       
  )    
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GUARANTEE_CALC]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[AIMS_PATIENT_GUARANTEE_CALC]  
 @PatientId varchar(50),  
 @GOP_AMOUNT varchar(50),  
 @GOP_OVER_LIMIT varchar(50) output  
AS  
BEGIN  
 DECLARE @totalAmt MONEY, @patientfileGOP MONEY  
  select 
  @totalAmt =  SUM (CAST (gop_consolidated_amount AS MONEY)) + cast(@GOP_AMOUNT as money)  
   FROM aims_patient_gop  
     WHERE patient_id = @PatientId  
  ORDER BY 1 DESC  
    
  SELECT   @patientfileGOP = cast(patient_guarantor_amount AS MONEY)    
   FROM aims_patient  
     WHERE patient_id = @PatientId  
  ORDER BY 1 DESC  
    
 IF @totalAmt > @patientfileGOP  
 BEGIN  
  SET @GOP_OVER_LIMIT = 'Y'  
 END  
 ELSE  
 BEGIN  
  SET @GOP_OVER_LIMIT = 'N'  
 END  
END


insert into AIMS_LIMITATION 
values('AIMS_EMAIL_POD_ACCOMODATION','3333','C:\aims recorder\GOP Archive')
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GUARANTEE_APPROVED_YN]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROC [dbo].[AIMS_PATIENT_GUARANTEE_APPROVED_YN]      
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
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GUARANTEE_APPROVE]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AIMS_PATIENT_GUARANTEE_APPROVE]  
 @GOP_ID varchar(50)  
as  
begin  
 update AIMS_PATIENT_GOP set GOP_APPROVED_YN = 'Y' where GOP_ID = @GOP_ID  
end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GOP_ADD]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_PATIENT_GOP_ADD]                     
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
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_GET]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_GET]      
    @PatientFileNo varchar(50) = '',  
    @EnquiryYN varchar(50) = 'N',  
    @UserSignedOn varchar(50) = ''  
        
as     
 declare @vSQL  nvarchar(500) , @PatientID numeric , @NoteTypeID numeric  
     
 set @vSQL = 'select *  ' +    
    ' from aims_patient as ap ' +    
   ' left outer join aims_companies  as ac  on ap.company_id  = ac.company_id ' +    
   ' left outer join aims_address  as aa on ap.address_id  = aa.address_id ' +    
   ' left outer join aims_country  as acc on aa.country_id  = acc.country_id ' +    
   ' left outer join aims_guarantor   as ag on ap.guarantor_id  = ag.guarantor_id ' +    
   ' left outer join aims_title     as atl on ap.title_id   = atl.title_id ' +   
   ' where ' +    
   '(ap.patient_file_no = ''' + @PatientFileNo + ''')  '    
    
 EXECUTE  sp_executesql  @vSQL  
   
IF(@EnquiryYN = 'Y')  
BEGIN  
   Select @PatientID = PATIENT_ID from AIMS_PATIENT where PATIENT_FILE_NO =@PatientFileNo   
   SELECT @NoteTypeID = NOTE_TYPE_ID from AIMS_NOTE_TYPES where NOTE_TYPE_CD = 'PATIENTFILEENQUIRY'  
     
 Insert into AIMS_NOTES   
  VALUES(@UserSignedOn, 'Patient File Enquiry',GETDATE(),@PatientID,@NoteTypeID)  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_INVOICE_VERIFY]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_INVOICE_VERIFY]      
    @PatientFileNo VARCHAR(50),    
    @PatientInvoiceNo varchar(50),
    @LateInvoiceYN varchar(1) = "N"    
as     
 declare @vSQL  nvarchar(500)    
     
 select * from AIMS_PATIENT ap, AIMS_INVOICE ai    
 where ap.PATIENT_FILE_NO = @PatientFileNo    
 and ai.PATIENT_ID = ap.PATIENT_ID     
 and ai.INVOICE_NO = @PatientInvoiceNo    
 and ai.CANCELLED_YN = 'N'
 and ai.LATE_INVOICE_YN = @LateInvoiceYN
GO
/****** Object:  Table [dbo].[AIMS_PAYMENT]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_PAYMENT](
	[PAYMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NULL,
	[GUARANTOR_ID] [numeric](18, 0) NULL,
	[AMOUNT_PAID] [varchar](50) NULL,
	[RECEIPT_NO] [varchar](50) NULL,
	[DATE_OF_RECEIPT] [varchar](50) NULL,
	[PAYMENT_METHOD_ID] [numeric](18, 0) NULL,
	[CHEQUE_NO] [varchar](50) NULL,
	[CREDIT_CARD_NO] [varchar](50) NULL,
	[BANK_TRANSFER_REF_NO] [varchar](50) NULL,
	[NOTICES] [varchar](50) NULL,
	[INVOICE_ID] [numeric](18, 0) NULL,
	[RENDER_DATE] [varchar](50) NULL,
	[PAYMENT_PROCESSED_YN] [varchar](1) NULL,
	[LOCKED_YN] [varchar](1) NULL,
	[CREATION_DTTM] [datetime] NULL,
	[AMOUNT_PAID_TO_DATE] [varchar](50) NULL,
	[AMOUNT_OUTSTANDING] [varchar](50) NULL,
	[FOREX_PAYMENT] [varchar](1) NULL,
	[INSURANCE_OVERPYMT] [varchar](1) NULL,
	[INSURANCE_SHORTPYMT] [varchar](1) NULL,
	[DOCTOR_OWING] [varchar](1) NULL,
	[LATE_SUBMISSION_PYMT] [varchar](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_WORK_ALLOCATED]    Script Date: 05/11/2021 21:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENTS_WORK_ALLOCATED]            
AS            
BEGIN            
SELECT   d.user_full_name file_allocated_to, count(d.user_full_name) "Work_Allocated"  , a.FILE_OPERATOR_TO_USERID          
    FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d              
   WHERE               
   --(a.PATIENT_FILE_NO not like '12%' or a.PATIENT_FILE_NO not like '10%' 
   --and a.PATIENT_FILE_NO not like '11%' or a.PATIENT_FILE_NO not like '13%' and
   a.CREATION_DTTM > GETDATE() - 360 and    
   CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and              
   file_operator_to_userid IS NOT NULL  and FILE_OPERATOR_TO_USERID in (
   select User_Name from AIMS_USER_ROLE where ROLE_CD = 'Operations')
   and SENT_TO_ADMIN = 'N' 
   --and (PATIENT_DISCHARGE_DATE is null or PATIENT_DISCHARGE_DATE = '')          
     AND b.patient_id = a.patient_id     
     --and b.NOTES_DTTM > GETDATE()- 30              
     AND b.note_id = (SELECT MAX (note_id)              
                        FROM aims_notes              
                       WHERE --aims_notes.NOTES_DTTM> getdate() - 30 and 
                       aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
                                   SELECT x.note_type_id      
                                     FROM aims_note_types x      
                                    WHERE x.note_type_cd =      
                                                          'PATIENTFILEENQUIRY'))              
     AND c.guarantor_id = a.guarantor_id              
     AND d.user_name = file_operator_to_userid              
     group by d.user_full_name    , a.FILE_OPERATOR_TO_USERID        
     order by 2 desc                          
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_UPDATE]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*  Return Values of the procedure 	*/
------------------------------------------
/*  -1 : Error 				*/
/*  0  : Successful		        */

CREATE PROCEDURE [dbo].[AIMS_PATIENT_UPDATE]  
	@PatientFileNo varchar(50),
	@PatientInitials varchar(50) = '',
	@PatientFirstName varchar(50) = '',
	@PatientMiddleName varchar(50) = '',
	@PatientLastName varchar(50) = '',
	@PatientIDNo varchar(50) = '',
	@PatientCompanyID int,
	@PatientTitleID int,
	@PatientAddressID int,
	@PatientHomeTelNo varchar(50) = '',
	@PatientWorkTelNo varchar(50) = '',
	@PatientFaxNo varchar(50) = '',
	@PatientMobileNo varchar(50) = '',
	@PatientEmailAddress varchar(50) = '',
	@PatientGuarantorID int,
	@PatientGuarantorRefNo  varchar(50) = '',
	@PatientFileActiveYN varchar(50) = '',
	@AddressTypeID int,
	@Address1 varchar(50), 
	@Address2 varchar(50), 
	@Address3 varchar(50),
	@Address4 varchar(50),
	@Address5 varchar(50), 
	@PostalCode varchar(30), 
	@CountryID int,
	@UserSignedOn varchar(50),
	@PatientNationality varchar(50)
as 
	BEGIN TRANSACTION addPatient

	DECLARE @LastError INT, @PatientID numeric, @sSQL nvarchar(4000)

	SET @LastError = 0
	
	select @PatientID = patient_id from aims_patient where patient_file_no = @PatientFileNo
 
	/* UPDATE ADDRESS INFORMATION */
	set @sSQL	= 'update aims_address ' +
			' set ADDRESS_TYPE_ID =  ' + CAST(@AddressTypeID as varchar(2)) + ', ' +
			' ADDRESS1 = ''' + @Address1 + ''', ADDRESS2 	= '''+ @Address2 + ''', ' +
			' ADDRESS3 = ''' + @Address3 + ''', ADDRESS4 	= '''+ @Address4 + ''', ' +
			' ADDRESS5 = ''' + @Address5 + ''', POSTAL_CODE 	= '''+ @PostalCode + ''', ' +
			' COUNTRY_ID = '+ CAST(@CountryID as varchar(2)) + ', DEFAULT_YN =''Y'', ACTIVE_YN = ''Y''' +
			' where address_id = (Select address_id from aims_patient where patient_file_no = ''' + @PatientFileNo +''')'

	EXECUTE  sp_executesql @sSQL

	if (@@ERROR <> 0) 
	begin
		insert into aims_debugging values ('Step 1','Address Table update Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())		
		SET @LastError = @@ERROR
		ROLLBACK TRANSACTION
		Return (-1)   
	end
	
	set @sSQL	= 'update aims_patient ' +
			' set PATIENT_INITIALS 	= ''' + @PatientInitials 	+ '''  ,' + 
			' PATIENT_FIRST_NAME    = ''' + @PatientFirstName 	+ '''  , PATIENT_MIDDLE_NAME 	= ''' + @PatientMiddleName + ''',' +
			' PATIENT_LAST_NAME     = ''' + @PatientLastName 	+ '''  , COMPANY_ID 		= '   + CAST(@PatientCompanyID as varchar(2)) + ',' + 
			' PATIENT_HOME_TEL_NO   = ''' + @PatientHomeTelNo 	+ '''  , PATIENT_WORK_TEL_NO	= ''' + @PatientWorkTelNo + ''',' + 
			' ADDRESS_ID            = '+ CAST(@PatientAddressID as varchar(2)) + '   , TITLE_ID               = '   + CAST(@PatientTitleID as varchar(2))   + ',' +
			' PATIENT_FAX_NO        = ''' + @PatientFaxNo 			+ '''  , PATIENT_MOBILE_NO 	= ''' + @PatientMobileNo + ''',' +
			' PATIENT_EMAIL_ADDRESS = ''' + @PatientEmailAddress 	+ '''  , GUARANTOR_ID 		= '   + CAST(@PatientGuarantorID as varchar(2)) + ',' +
			' GUARANTOR_REF_NO      = ''' + @PatientGuarantorRefNo  +  ''' , PATIENT_FILE_ACTIVE_YN = ''' + @PatientFileActiveYN + ''',' +
			' PATIENT_NATIONALITY   = ''' + @PatientNationality     + ''' , PATIENT_ID_NO 		= ''' + @PatientIDNo +'''' +
			' where patient_file_no = ''' + @PatientFileNo + ''''

	EXECUTE  sp_executesql  @sSQL

	if (@@ERROR <> 0) 
	begin
		SET @LastError = @@ERROR
		insert into aims_debugging values ('Step 1','Patient Table update Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION
		Return (-1)
	end
	
	/* PATIENT INFORMATION AUDIT */
	insert into AIMS_A_PATIENT
		Values( @UserSignedOn,
		'UPDATE',
		GETDATE(),
		IDENT_CURRENT('AIMS_PATIENT'),
		@PatientFileNo,
		@PatientInitials, 	
		@PatientFirstName,  @PatientMiddleName, 
		@PatientLastName, @PatientIDNo, @PatientCompanyID,
		@PatientTitleID, @PatientAddressID, @PatientHomeTelNo, @PatientWorkTelNo ,
		@PatientFaxNo, @PatientMobileNo,
		@PatientEmailAddress, @PatientGuarantorID,
		@PatientGuarantorRefNo, @PatientFileActiveYN,@PatientNationality)

	EXECUTE  sp_executesql  @sSQL

	/* TRACE_ID - Identity Column */
	insert into AIMS_TRACE(
		PATIENT_FILE_NO,
		DATE_TIME,
		USER_NAME,
		DESCRIPTION,
		COMMENTS,
		PATIENT_ID) values(
				@PatientFileNo, 
				GETDATE(),
				@UserSignedOn,
				'Patient Details Update',
				'Patient Details Updated Successfully',
				@PatientID)
	
	/* If Insert to the trace table failed then exit*/				
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Trace Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
		RETURN -1
	end

	/* If Insert to the NOTES table failed then exit*/

	/* NOTE_ID - Identity Column */
	insert into AIMS_NOTES(
		USER_NAME,
		NOTES,
		NOTES_DTTM,
		PATIENT_ID) values(
				   @UserSignedOn,
				   'New File for Patient',
				   GETDATE(),
				   @PatientID)

	/* If Insert to the trace table failed then exit*/				
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Notes Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
		RETURN -1
	end		
		
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Patient Saving Completed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
	end
	else
	begin	
		COMMIT TRANSACTION addPatient
	end
GO
/****** Object:  View [dbo].[AIMS_INVOICES_VW]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AIMS_INVOICES_VW]  
AS  
SELECT     ai.INVOICE_ID, ap.PATIENT_FILE_NO,    ai.INVOICE_NO, ai.INVOICE_DATE, ai.INVOICE_AMOUNT_RECEIVED  
FROM         dbo.AIMS_INVOICE ai   
 LEFT OUTER JOIN dbo.AIMS_PATIENT ap ON ap.PATIENT_ID = ai.PATIENT_ID 
 WHERE AI.CANCELLED_YN = 'N'
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_VERIFY]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_INVOICE_VERIFY]  
    @InvoiceNo varchar(50) = '',
    @PatientFileNo varchar(50) = ''
as 
	declare @PatientID int
	
	select @PatientID = patient_id from aims_patient where patient_file_no = @PatientFileNo
	SELECT  * from aims_invoice where invoice_no = @InvoiceNo and patient_id = @PatientID
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_UPDATE]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*  Return Values of the procedure 	*/
------------------------------------------
/*  -1 : Error 				*/
/*  0  : Successful		        */

CREATE PROCEDURE [dbo].[AIMS_INVOICE_UPDATE]  
	@InvoiceID			int,
	@InvoiceNo    			varchar(50) = '',
	@PatientFileNo			varchar(50) = '',
	@InvoiceDate    		varchar(50) = '',
	@ProfServiceID 			int 		,
	@InvoiceAmountReceived		varchar(50) = '',
	@DateAdmitted			varchar(50) = '',
	@DateDischarged			varchar(50) = '',
	@MedicalTreatmentID		int		,
	@InvoiceGeneratedYN		varchar(1)  = '',
	@InvoiceLockedYN		varchar(1)  = '',  	
	@DateOfCourier			varchar(50) = '',
	@InvoiveLateYN			varchar(1)  = '',	
	@UserSignedOn 			varchar(50) = ''
as 
	BEGIN TRANSACTION addPatient

	DECLARE @LastError INT, @PatientID numeric, @sSQL nvarchar(4000)

	select @PatientID = patient_id from aims_patient where patient_file_no = @PatientFileNo
	
	set @sSQL	= ' update aims_invoice set ' +
	' INVOICE_NO = '''+ @InvoiceNo + ''', ' +
	' PATIENT_ID = ' + cast(@PatientID as varchar(2)) + ' , ' +
	' INVOICE_DATE = ''' + @InvoiceDate + ''', ' +
	' PROF_SERVICE_ID = ' + CAST(@ProfServiceID as varchar(2)) + ', ' +
	' INVOICE_AMOUNT_RECEIVED = ''' + @InvoiceAmountReceived + ''', ' +
	' DATE_ADMITTED = ''' + @DateAdmitted + ''', ' +
	' DATE_DISCHARGED = ''' + @DateDischarged + ''', ' +
	' MEDICAL_TREATMENT_ID = ' + CAST(@MedicalTreatmentID as varchar(2)) + ', ' +
	' GENERATED_YN = ''' + @InvoiceGeneratedYN + ''', ' +
	' LOCKED_YN = ''' + @InvoiceLockedYN + ''', ' +
	' DATE_OF_COURIER = ''' + @DateOfCourier + ''', ' +
	' LATE_INVOICE_YN = ''' + @InvoiveLateYN + '''' +
	' where patient_id = ' + CAST(@PatientID as varchar(2)) + ' and invoice_id = ' + CAST(@InvoiceID as varchar(2)) +''
	
	EXECUTE  sp_executesql  @sSQL

	if (@@ERROR <> 0) 
	begin
		SET @LastError = @@ERROR
		insert into aims_debugging values ('Step 1','Patient Table update Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION
		Return (-1)
	end

	/* TRACE_ID - Identity Column */
	insert into AIMS_TRACE(
		PATIENT_FILE_NO,
		DATE_TIME,
		USER_NAME,
		DESCRIPTION,
		COMMENTS,
		PATIENT_ID) values(
				@PatientFileNo, 
				GETDATE(),
				@UserSignedOn,
				'Patient Details Update',
				'Patient Details Updated Successfully',
				@PatientID)
	
	/* If Insert to the trace table failed then exit*/				
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Trace Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
		RETURN -1
	end

	/* If Insert to the NOTES table failed then exit*/

	/* NOTE_ID - Identity Column */
	insert into AIMS_NOTES(
		USER_NAME,
		NOTES,
		NOTES_DTTM,
		PATIENT_ID) values(
				   @UserSignedOn,
				   'Invoice Details amended to Patient File' ,
				   GETDATE(),
				   @PatientID)

	/* If Insert to the trace table failed then exit*/				
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Notes Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
		RETURN -1
	end		

		insert into aims_A_invoice
			(
			MODIFIED_USER,
			MODIFIED_ACTION,
			MODIFIED_DATE,
			invoice_id,
			INVOICE_NO,
			PATIENT_ID,
			INVOICE_DATE,
			INVOICE_AMOUNT_RECEIVED,
			DATE_ADMITTED,
			DATE_DISCHARGED,
			MEDICAL_TREATMENT_ID,
			GENERATED_YN,
			LOCKED_YN,
			DATE_OF_COURIER,
			LATE_INVOICE_YN) Values
					(@UserSignedOn, 'ADD' , GETDATE(), @InvoiceID,
						@InvoiceNo, CAST(@PatientID as varchar(50)),
						@InvoiceDate,
						@InvoiceAmountReceived, @DateAdmitted,
						@DateDischarged, CAST(@MedicalTreatmentID as varchar(50)),
						@InvoiceGeneratedYN, @InvoiceLockedYN,
						@DateOfCourier, @InvoiveLateYN
					)
		
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Patient Saving Completed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
	end
	else
	begin	
		COMMIT TRANSACTION addPatient
	end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_UNLOCK]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_INVOICE_UNLOCK]  
	@InvoiceID int, 
	@UserSignedOn varchar(50)
as 
	declare @vSQL  nvarchar(500)
 
	set @vSQL = 'Update aims_invoice set locked_yn = ''N'' where invoice_id = '+ cast(@InvoiceID as varchar(50))
	EXECUTE  sp_executesql  @vSQL
	
	insert into aims_a_invoice
	select 
				@UserSignedOn,
				'INVOICE UNLOCKED',
				getdate(),
				invoice_id,
				invoice_no,
				patient_id,
				invoice_date,
				INVOICE_AMOUNT_RECEIVED,
				GENERATED_YN,
				LOCKED_YN,
				LATE_INVOICE_YN, creation_dttm from aims_invoice where invoice_id = @InvoiceID
GO
/****** Object:  Table [dbo].[AIMS_INVOICE_MEDICAL_TREATMENTS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENTS](
	[INVOICE_TREATMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[INVOICE_ID] [numeric](18, 0) NULL,
	[MEDICAL_TREATMENT_ID] [numeric](18, 0) NULL,
	[SERVICE_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_INVOICE_MEDICAL_TREATMENTS] PRIMARY KEY CLUSTERED 
(
	[INVOICE_TREATMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GUARANTOR_ANALYSIS_DRILL]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AIMS_GUARANTOR_ANALYSIS_DRILL]   
 @GuarantorID INT,  
 @StartDate varchar(50),  
 @EndDate varchar(50)  
as  
begin  

 DECLARE @FlightGuarantorID INT  
   
 SELECT @FlightGuarantorID = GUARANTOR_ID FROM AIMS_GUARANTOR where GUARANTOR_NAME like '%FLIGHT%'  
 
select 
	a.PATIENT_FILE_NO, 
	a.PATIENT_ADMISSION_DATE "ADMISSION_DATE", 
	a.PATIENT_LAST_NAME, 
	sum(cast(b.INVOICE_AMOUNT_RECEIVED as money)) "CONSOLIDATION_VALUE"  
 from AIMS_PATIENT a , aims_invoice b, AIMS_GUARANTOR c   
where   
    (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and  
 a.CANCELLED = 'N' and   
 a.PATIENT_FILE_ACTIVE_YN = 'Y' and  
 a.GUARANTOR_ID = @GuarantorID and   
 b.PATIENT_ID = a.PATIENT_ID and   
 b.CANCELLED_YN = 'N' and  
 c.GUARANTOR_ID = a.GUARANTOR_ID  
  group by a.PATIENT_FILE_NO, a.PATIENT_ADMISSION_DATE, a.PATIENT_LAST_NAME
 UNION
select   
 a.PATIENT_FILE_NO,   
 a.PATIENT_ADMISSION_DATE "ADMISSION_DATE",   
 a.PATIENT_LAST_NAME,   
 sum(cast(b.INVOICE_AMOUNT_RECEIVED as money)) "CONSOLIDATION_VALUE"  
 FROM AIMS_PATIENT a   
 inner join aims_invoice b on b.PATIENT_ID = a.PATIENT_ID  
 inner join AIMS_GUARANTOR c  on c.GUARANTOR_ID = a.GUARANTOR_ID  
 left outer join AIMS_PATIENT d on d.PATIENT_ID = a.PATIENT_ID  
WHERE   
    (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and   
    convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and   
    convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and  
 a.CANCELLED = 'N' and   
 a.PATIENT_FILE_ACTIVE_YN = 'Y' and  
 a.GUARANTOR_ID = @FlightGuarantorID and   
 b.CANCELLED_YN = 'N' and  
 d.FLIGHT_GUARANTOR_ID = @GuarantorID  
 group by a.PATIENT_FILE_NO, a.PATIENT_ADMISSION_DATE, a.PATIENT_LAST_NAME 
 order by a.PATIENT_ADMISSION_DATE, a.PATIENT_LAST_NAME  
end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_OVERDUE_TASKS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_GET_OVERDUE_TASKS]    
AS    
begin    
 select b.TASK_DESC,c.PRIORITY, a.*,d.PATIENT_FILE_NO from AIMS_PATIENT_FILE_TASKS a, AIMS_TASKS b, AIMS_PRIORITY c , AIMS_PATIENT d   
  where DUE_DATE < GETDATE() and TASK_STATUS_ID in (2, 8, 2) and 
  b.TASK_ID = a.TASK_ID and c.PRIORITY_ID = a.PRIORITY_ID   
  and d.PATIENT_ID = a.PATIENT_ID and a.USER_ID in (select USER_NAME from AIMS_USER_ROLE ) order by USER_ID  , PATIENT_FILE_NO  
end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_TRANSPORT_CASES]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_GET_TRANSPORT_CASES]        
AS        
begin        
SELECT   b.transport_type_desc, a.patient_file_no,        
         a.patient_last_name + ' ' + a.patient_first_name "PATIENT_NAME",        
         e.APPOINTMENT_ADDRESS,        
         d.guarantor_name, c.user_full_name "CO_ORDINATOR",      
         e.APPOINTMENT_DATE,      
         e.CANCELLED_YN  ,    
         e.CREATED_DTTM     
    FROM aims_patient a       
    left outer join AIMS_APPOINTMENTS e  on e.PATIENT_ID = a.PATIENT_ID       
    left outer join aims_transport_type b  on b.transport_type_id = e.TRANSPORT_TYPE_ID      
    left outer join aims_users c on c.user_name = a.file_operator_to_userid       
    left outer join aims_guarantor d on d.guarantor_id = a.guarantor_id        
   WHERE e.TRANSPORT_YN = 'Y'        
     AND a.cancelled = 'N'        
     AND a.patient_file_active_yn = 'Y'        
     AND a.pending = 'N'   
     and (e.APPOINTMENT_STATUS is null or  e.APPOINTMENT_STATUS = '')
ORDER BY b.transport_type_desc, c.user_name        
end
GO
/****** Object:  Table [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS](
	[SENT_EMAIL_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PATIENT_ID] [numeric](18, 0) NOT NULL,
	[SENT_TO] [varchar](255) NOT NULL,
	[SENT_DTTM] [datetime] NOT NULL,
	[EMAIL_FROM_ID] [numeric](18, 0) NOT NULL,
	[PATIENT_ENQUIRY_ID] [numeric](18, 0) NULL,
	[EMAIL_SUBJECT] [varchar](1000) NULL,
	[EMAIL_SENT_BY] [varchar](50) NOT NULL,
	[SENT_TO_CC] [varchar](255) NULL,
 CONSTRAINT [PK_AIMS_EWS_PATIENT_SENT_EMAILS] PRIMARY KEY CLUSTERED 
(
	[SENT_EMAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_PATIENT_EMAIL_REMOVE]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_PATIENT_EMAIL_REMOVE]  
  @PatientFileEmailEnquiryID varchar(50) = ''
 AS  
 BEGIN  
	UPDATE AIMS_EWS_PATIENT_ENQUIRY SET
		ACTIVE_YN = 'N' 
	WHERE PATIENT_ENQUIRY_ID = @PatientFileEmailEnquiryID
 END
GO
/****** Object:  Table [dbo].[AIMS_EWS_OPERATOR_MAILS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_OPERATOR_MAILS](
	[OPERATOR_MAIL_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[OPERATOR_MAILBOX_ID] [numeric](18, 0) NULL,
	[PATIENT_ENQUIRY_ID] [numeric](18, 0) NOT NULL,
	[MAIL_READ_YN] [varchar](1) NOT NULL,
	[MAIL_READ_DTTM] [datetime] NULL,
	[WORK_ITEM_PROCESSED_YN] [varchar](1) NULL,
	[WORK_ITEM_PROCESSED_DTTM] [datetime] NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[AIMS_EWS_OPERATOR_MAILS] ADD [WORK_ITEM_PROCESSED_BY] [varchar](50) NULL
ALTER TABLE [dbo].[AIMS_EWS_OPERATOR_MAILS] ADD  CONSTRAINT [PK_AIMS_EWS_OPERATOR_MAILS] PRIMARY KEY CLUSTERED 
(
	[OPERATOR_MAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [AIMS_EWS_OPERATOR_MAILS_IDX2] ON [dbo].[AIMS_EWS_OPERATOR_MAILS] 
(
	[PATIENT_ENQUIRY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_MY_TASKS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[AIMS_EWS_MY_TASKS]      
 @IM_USER VARCHAR(50)      
AS      
BEGIN      
 SELECT * FROM      
  AIMS_PATIENT_FILE_TASKS a    
  inner join aims_patient b on  b.PATIENT_ID = a.PATIENT_ID  
  inner join aims_users c on c.user_name = a.user_id  
  left outer join aims_users e  on e.user_name = a.loaded_by  
  left outer join aims_priority f on f.priority_id = a.priority_id  
  inner join aims_tasks g on g.task_id = a.task_id  
 WHERE  
 a.user_id = @IM_USER  and   
 a.active_yn = 'Y'  
 order by a.active_yn, f.priority  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_MY_INSTANT_MESSAGES_AUDIT]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[AIMS_EWS_MY_INSTANT_MESSAGES_AUDIT]      
 @IM_USER VARCHAR(50)      
AS      
BEGIN      
     
SELECT * FROM      
   AIMS_EWS_INSTANT_MESSAGING a, AIMS_PATIENT b, aims_users c, AIMS_USERS d    
 WHERE INSTANT_MESSAGE_TO = @IM_USER    
  and b.PATIENT_ID = a.INSTANT_MESSAGE_PATIENT_ID      
  and c.user_name =  a.INSTANT_MESSAGE_FROM      
  AND A.PROCESSED_DTTM IS NOT NULL     
  and a.PROCESSED_DTTM >= GETDATE() - 31  
  and (a.processed_by = A.INSTANT_MESSAGE_TO or a.processed_by is null)     
  and d.User_Name =+ a.processed_by    
  END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_MY_INSTANT_MESSAGES]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_MY_INSTANT_MESSAGES]  
 @IM_USER VARCHAR(50)  
AS  
BEGIN  
 SELECT * FROM  
   AIMS_EWS_INSTANT_MESSAGING a, AIMS_PATIENT b, aims_users c  
 WHERE INSTANT_MESSAGE_TO = @IM_USER  
  and b.PATIENT_ID = a.INSTANT_MESSAGE_PATIENT_ID  
  and c.user_name =  a.INSTANT_MESSAGE_FROM 
  and (a.PROCESSED_BY is null  or a.PROCESSED_BY = '')
END
GO
/****** Object:  Table [dbo].[AIMS_EWS_EMAIL_DOCUMENTS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_EMAIL_DOCUMENTS](
	[EMAIL_DOCUMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[FILE_NAME] [varchar](4000) NOT NULL,
	[DOC_TYPE_ID] [numeric](18, 0) NOT NULL,
	[PATIENT_ENQUIRY_ID] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_AIMS_EWS_EMAIL_DOCUMENTS] PRIMARY KEY CLUSTERED 
(
	[EMAIL_DOCUMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [AIMS_EWS_EMAIL_DOCUMENTS_ID2] ON [dbo].[AIMS_EWS_EMAIL_DOCUMENTS] 
(
	[PATIENT_ENQUIRY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AIMS_APPOINTMENT_GET]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   
PROCEDURE [dbo].[AIMS_APPOINTMENT_GET]                  
    @AppointmentID varchar(50)                
AS          
BEGIN               
     SELECT   a.*,b.*, c.*  
  FROM aims_appointments a  
  left outer join aims_transport_type b on b.transport_type_id = a.transport_type_id  
  inner join aims_users c on c.user_name = a.created_by  
    WHERE a.appointment_id = @AppointmentID  
 ORDER BY a.created_dttm DESC  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_APPOINTMENT_ADD]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_APPOINTMENT_ADD]         
 @AppointmentID varchar(50) output,          
 @AppointmentSubject  varchar(50),        
 @AppointmentAddress varchar(250),        
 @AppointmentDate varchar(50),        
 @AppointmentTimeHour varchar(50),        
 @AppointmentTimeMinute varchar(50),        
 @AppointmentReminderYN varchar(50),        
 @AppointmentReminderPeriod varchar(50),        
 @AppointmentTransportRequiredYN varchar(50),        
 @AppointmentTransportType varchar(50),        
 @AppointmentPickUpTimeHour varchar(50),        
 @AppointmentPickUpTimeMinute varchar(50),        
 @AppointmentDropOffTimeHour varchar(50),        
 @AppointmentDropOffTimeMinute varchar(50),        
 @PatientFileNo  varchar(50),        
 @CreatedBy  varchar(50),        
 @AppointmentNote  varchar(300),        
 @AppointmentTime  datetime,        
 @PickUpTime  datetime,        
 @DropOffTime  datetime,    
 @TranslatorYN varchar(1) ,  
 @CalenderAppointmentLoadId varchar(50)  
AS        
BEGIN        
 DECLARE @ACTION VARCHAR(50), @PatientID int        
         
 if @AppointmentTransportRequiredYN = 'N'        
 begin         
  SET @PickUpTime = null        
  SET @DropOffTime = null        
 end        
         
 select @PatientID = Patient_ID from aims_patient where patient_file_no = @PatientFileNo        
         
 IF (@AppointmentID IS NULL or @AppointmentID = '')              
  BEGIN          
   SET @ACTION = 'ADD'          
   INSERT INTO[dbo].[AIMS_APPOINTMENTS]        
   ([APPOINTMENT_SUBJECT]        
   ,[APPOINTMENT_ADDRESS]        
   ,[APPOINTMENT_DATE]        
   ,[APPOINTMENT_TIME_HOUR]        
   ,[APPOINTMENT_TIME_MINUTE]        
   ,[REMINDER_YN]        
   ,[REMINDER_PERIOD]        
   ,[TRANSPORT_YN]        
   ,[TRANSPORT_TYPE_ID]        
   ,[PICK_UP_TIME_HOUR]        
   ,[PICK_UP_TIME_MINUTE]        
   ,[DROP_UP_TIME_HOUR]        
   ,[DROP_UP_TIME_MINUTE]        
   ,[PATIENT_ID]        
   ,[CREATED_DTTM]        
   ,[CREATED_BY],         
   APPOINTMENT_NOTE,        
   APPOINTMENT_TIME,        
   PICK_UP_TIME,        
   DROP_OFF_TIME,    
   TRANSLATOR_YN,  
   CALENDER_APPOINTMENT_ID   
   )        
   VALUES        
    (@AppointmentSubject,        
    @AppointmentAddress ,        
    @AppointmentDate ,        
    @AppointmentTimeHour ,        
    @AppointmentTimeMinute ,        
    @AppointmentReminderYN ,        
    @AppointmentReminderPeriod ,        
    @AppointmentTransportRequiredYN,        
    @AppointmentTransportType ,        
    @AppointmentPickUpTimeHour ,        
    @AppointmentPickUpTimeMinute ,        
    @AppointmentDropOffTimeHour,        
    @AppointmentDropOffTimeMinute ,        
    @PatientID,        
    GETDATE()        
    ,@CreatedBy,        
    @AppointmentNote,        
    @AppointmentTime,        
    @PickUpTime,        
    @DropOffTime,    
    @TranslatorYN,  
    @CalenderAppointmentLoadId)        
            
  SET @AppointmentID = IDENT_CURRENT('AIMS_APPOINTMENTS')              
  END        
 ELSE        
  BEGIN        
  SET @ACTION = 'UPDATE'          
  UPDATE [AIMS_APPOINTMENTS] SET         
   [APPOINTMENT_SUBJECT] = @AppointmentSubject        
   ,[APPOINTMENT_ADDRESS] =@AppointmentAddress        
   ,[APPOINTMENT_DATE]=@AppointmentDate        
   ,[APPOINTMENT_TIME_HOUR]=@AppointmentTimeHour        
   ,[APPOINTMENT_TIME_MINUTE]=@AppointmentTimeMinute        
   ,[REMINDER_YN]=@AppointmentReminderYN        
   ,[REMINDER_PERIOD]=@AppointmentReminderPeriod        
   ,[TRANSPORT_YN]=@AppointmentTransportRequiredYN        
   ,[TRANSPORT_TYPE_ID]=@AppointmentTransportType        
   ,[PICK_UP_TIME_HOUR]=@AppointmentPickUpTimeHour        
   ,[PICK_UP_TIME_MINUTE]=@AppointmentPickUpTimeMinute        
   ,[DROP_UP_TIME_HOUR]=@AppointmentDropOffTimeHour        
   ,[DROP_UP_TIME_MINUTE]=@AppointmentDropOffTimeMinute        
   ,APPOINTMENT_NOTE = @AppointmentNote        
   ,APPOINTMENT_TIME = @AppointmentTime        
   ,PICK_UP_TIME =@PickUpTime        
   ,DROP_OFF_TIME =@DropOffTime        
   ,PATIENT_ID =@PatientID    
   ,TRANSLATOR_YN =@TranslatorYN    
   WHERE appointment_id = @AppointmentID        
  END        
          
 INSERT INTO[dbo].[AIMS_A_APPOINTMENTS]        
   ([MODIFIED_USER]        
   ,[MODIFIED_ACTION]        
   ,[MODIFIED_DATE]        
   ,[APPOINTMENT_ID]        
   ,[APPOINTMENT_SUBJECT]        
   ,[APPOINTMENT_ADDRESS]        
   ,[APPOINTMENT_DATE]        
   ,[APPOINTMENT_TIME_HOUR]        
   ,[APPOINTMENT_TIME_MINUTE]        
   ,[REMINDER_YN]        
   ,[REMINDER_PERIOD]        
   ,[TRANSPORT_YN]        
   ,[TRANSPORT_TYPE_ID]        
   ,[PICK_UP_TIME_HOUR]        
   ,[PICK_UP_TIME_MINUTE]        
   ,[DROP_UP_TIME_HOUR]        
   ,[DROP_UP_TIME_MINUTE]        
   ,[CREATED_BY],        
   APPOINTMENT_NOTE,        
   APPOINTMENT_TIME,         
   PICK_UP_TIME,         
   DROP_OFF_TIME, TRANSLATOR_YN)        
  VALUES        
  (@CreatedBy        
  ,@ACTION        
  ,GETDATE(),        
  @AppointmentID,          
  @AppointmentSubject  ,        
  @AppointmentAddress,        
  @AppointmentDate ,        
  @AppointmentTimeHour ,        
  @AppointmentTimeMinute ,        
  @AppointmentReminderYN ,        
  @AppointmentReminderPeriod ,        
  @AppointmentTransportRequiredYN ,        
  @AppointmentTransportType,        
  @AppointmentPickUpTimeHour ,        
  @AppointmentPickUpTimeMinute ,        
  @AppointmentDropOffTimeHour ,        
  @AppointmentDropOffTimeMinute  ,        
  @CreatedBy,        
  @AppointmentNote,            
  @AppointmentTime,        
  @PickUpTime,        
  @DropOffTime, @TranslatorYN)        
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_ACCOMODATION_ADD]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_ACCOMODATION_ADD]      
@Accomodation varchar(50),      
@GuestName varchar(50),      
@GuestRefNo varchar(50),      
@GuestNoOfRooms varchar(50),      
@GuestArrivalDate varchar(50),     
@GuestFlightArrivalTime varchar(50),    
@GuestDepartDate varchar(50),    
@GuestAimsSettle varchar(50),      
@GuestCountryOfRegion varchar(50),      
@Religion varchar(50),      
@DiabeticMeals varchar(50),      
@BedAndBreakFast varchar(50),      
@Meals varchar(50),      
@Laundry varchar(50),      
@Telephone varchar(50),      
@MiniBar varchar(50),      
@SpecialRequest varchar(50),      
@PatientID varchar(50),      
@UserID varchar(50),      
@AccomodationLetter varchar(1000),  
@ContactTelMobileNo varchar(50),      
@ContactEmailAddress varchar(50),      
@DOB varchar(50),      
@NoOfGuests varchar(50),      
@RoomRatePerNight varchar(50),      
@RoomType varchar(50),      
@MealBreakFast varchar(50),      
@MealBreakLunch varchar(50),      
@MealBreakDinner varchar(50),      
@MealBreakFullBoard varchar(50),      
@SocialTransport varchar(50),      
@AdditionalNotes varchar(250),
      @currency varchar(250)
as       
begin      
insert into aims_accomodation (      
SUPPLIER_ID,      
GUEST_NAME,      
GUEST_REF_NO,      
GUEST_NO_OF_ROOMS,      
GUEST_ARRIVAL_DATE,      
GUEST_FLIGHT_ARRIVAL_DATE,      
GUEST_DEPART_DATE,      
GUEST_AIMS_SETTLE,      
GUEST_COUNTRY_OF_ORIGIN,      
GUEST_RELIGION,      
GUEST_DIABETIC_MEALS,      
GUEST_BED_AND_BREAKFAST,      
GUEST_MEALS,      
GUEST_LAUNDRY,      
GUEST_TELEPHONE,      
GUEST_MINIBAR,      
GUEST_SPECIAL_REQUEST,      
PATIENT_ID,      
CREATED_BY,      
ACCOMODATION_LETTER,  
ContactTelMobileNo,  
ContactEmailAddress,  
DOB,  
NoOfGuests,  
RoomRatePerNight,  
RoomType,  
MealBreakFast,  
MealBreakLunch,  
MealBreakDinner,  
MealBreakFullBoard,  
SocialTransport,  
AdditionalNotes,currency  
) VALUES(      
@Accomodation  ,      
@GuestName  ,      
@GuestRefNo  ,      
@GuestNoOfRooms  ,      
@GuestArrivalDate ,      
@GuestFlightArrivalTime ,      
@GuestDepartDate ,      
@GuestAimsSettle  ,      
@GuestCountryOfRegion  ,      
@Religion  ,      
@DiabeticMeals  ,      
@BedAndBreakFast  ,      
@Meals  ,      
@Laundry  ,      
@Telephone  ,      
@MiniBar  ,      
@SpecialRequest  ,      
@PatientID  ,      
@UserID  ,      
@AccomodationLetter,  
@ContactTelMobileNo,  
@ContactEmailAddress,  
@DOB,  
@NoOfGuests,  
@RoomRatePerNight,  
@RoomType,  
@MealBreakFast,  
@MealBreakLunch,  
@MealBreakDinner,  
@MealBreakFullBoard,  
@SocialTransport,  
@AdditionalNotes,@Currency        
)        
end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_ADD_NOTE]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_ADD_NOTE]      
  @PatientFileNo varchar(50) = '',    
  @UserName varchar(50) = '',    
  @Notes varchar(2000) = '',  
  @NoteTypeID int,
  @NoteID varchar(50)
as     
  DECLARE @LastError INT, @PatientID int  
  SET @LastError = 0    
   
 SELECT @PatientID = PATIENT_ID FROM AIMS_PATIENT WHERE PATIENT_FILE_NO = @PatientFileNo  
 
 insert into AIMS_DEBUGGING values('notes update ',@NoteID , GETDATE())
 insert into AIMS_DEBUGGING values('notes Type ID ',@NoteTypeID , GETDATE())
 
 
 IF (@NoteID = 0)
 BEGIN
 insert into AIMS_DEBUGGING values('notes update ','NOTE IS ZERO' , GETDATE())
 
 INSERT INTO AIMS_NOTES(    
    USER_NAME,    
    NOTES,    
    NOTES_DTTM,    
    PATIENT_ID,   
    NOTE_TYPE_ID)   
   VALUES   
    (  
    @UserName,   
    @Notes,   
    getdate(),   
    @PatientID,  
    @NoteTypeID)
END
ELSE
BEGIN
	insert into AIMS_DEBUGGING values('notes update ','NOTE UPDATE' , GETDATE())
	UPDATE AIMS_NOTES SET NOTES = @Notes, NOTE_TYPE_ID = @NoteTypeID where NOTE_ID = @NoteID and PATIENT_ID = @PatientID
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_AAOPTION_ADD]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AIMS_AAOPTION_ADD]  
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
GO
/****** Object:  StoredProcedure [dbo].[AIMS_AADETAILS_ADD]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AIMS_AADETAILS_ADD]    
	@PatientID varchar(50),    
	@PatientYellowFeverCert varchar(50),    
	@PatientWeightHeight varchar(50),    
	@RefHosNameLocation varchar(50),    
	@RefHosTel varchar(50),    
	@RefHosEmail varchar(50),    
	@RefHosDrName varchar(50),    
	@RefHosDrNameTel varchar(50),    
	@RefHosDrNameEmail varchar(50),    
	@AccomMemNameSur varchar(50),    
	@AccomMemNationality varchar(50),    
	@AccomMemPassportNo varchar(50),    
	@AccomMemYelFeverCert varchar(50),    
	@AccomMemWeightHeight  varchar(50),    
	@VHFFormRequiredYN varchar(1),    
	@UserId varchar(50),  
	@AirAmbulanceCELetter varchar(500),
	@PatientPassportNo varchar(50),
	@AAAddressToName  varchar(250)
	as     
	begin    
	 insert into AIMS_AA_DETAILS(    
		PATIENT_ID,    
		YELLOW_FEVER_CERTIFICATE,    
		WEIGHTHEIGHTESTIMATE,    
		REFERRING_HOSPITAL_NAME_LOCATION,    
		REFERRING_HOSPITAL_TEL_NO,    
		REFERRING_HOSPITAL_EMAIL,    
		REFERRING_DOCTOR_NAME,    
		REFERRING_DOCTOR_TEL_NO,    
		REFERRING_DOCTOR_EMAIL,    
		COMPANY_MEM_NAME,    
		COMPANY_MEM_NATIONALITY,    
		COMPANY_MEM_PASSPORT_NO,    
		COMPANY_MEM_YELLOW_FEVER_CERT,    
		COMPANY_MEM_WEIGHT_HEIGHT,
		VHFFORMREQUIREDYN,    
		LOADED_BY , AA_POD  ,
		PATIENT_PASSPORT_NUMBER,
		AA_ADDRESS_TO
	 ) values(    
	 @PatientID ,    
	 @PatientYellowFeverCert ,    
	 @PatientWeightHeight ,    
	 @RefHosNameLocation ,    
	 @RefHosTel ,    
	 @RefHosEmail ,    
	 @RefHosDrName ,    
	 @RefHosDrNameTel ,    
	 @RefHosDrNameEmail ,    
	 @AccomMemNameSur ,    
	 @AccomMemNationality ,    
	 @AccomMemPassportNo ,    
	 @AccomMemYelFeverCert ,
	 @AccomMemWeightHeight,    
	 @VHFFormRequiredYN ,    
	 @UserId   , @AirAmbulanceCELetter  , @PatientPassportNo,
	 @AAAddressToName
	 )    
	end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_CLEAR_IM]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[AIMS_EWS_CLEAR_IM]
	@IM_USER VARCHAR(50)
AS
BEGIN
	DELETE FROM 
			AIMS_EWS_INSTANT_MESSAGING 
	WHERE 
		INSTANT_MESSAGE_TO = @IM_USER
END
GO
/****** Object:  Table [dbo].[AIMS_EWS_ADMIN_MAILS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[AIMS_EWS_ADMIN_MAILS](
	[OPERATOR_MAIL_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[OPERATOR_MAILBOX_ID] [numeric](18, 0) NULL,
	[PATIENT_ENQUIRY_ID] [numeric](18, 0) NOT NULL,
	[MAIL_READ_YN] [varchar](1) NOT NULL,
	[MAIL_READ_DTTM] [datetime] NULL,
	[WORK_ITEM_PROCESSED_YN] [varchar](1) NULL,
	[WORK_ITEM_PROCESSED_DTTM] [datetime] NULL,
	[WORK_ITEM_PROCESSED_BY] [varchar](50) NULL,
 CONSTRAINT [PK_AIMS_EWS_ADMIN_MAILS] PRIMARY KEY CLUSTERED 
(
	[OPERATOR_MAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_ADD_IM]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_ADD_IM]  
 @IM_TEXT VARCHAR(500),  
 @IM_FROM VARCHAR(50),  
 @IM_TO VARCHAR(50),  
 @IM_PATIENT_FILE_NO VARCHAR(50)  
AS  
BEGIN  
 DECLARE @PatientID int  
   
 SELECT @PatientID = Patient_id FROM aims_patient WHERE patient_file_no = @IM_PATIENT_FILE_NO  
   
 INSERT INTO AIMS_EWS_INSTANT_MESSAGING(  
  INSTANT_MESSAGE_DTTM,  
  INSTANT_MESSAGE_TEXT,  
  INSTANT_MESSAGE_TO,  
  INSTANT_MESSAGE_FROM,  
  INSTANT_MESSAGE_PATIENT_ID)  
  VALUES( GETDATE(),   
    @IM_TEXT,   
    @IM_TO,  
    @IM_FROM,  
    @PatientID)  
END
GO
/****** Object:  StoredProcedure [dbo].[GET_PATIENT_APPOINTMENTS_AUDIT]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_PATIENT_APPOINTMENTS_AUDIT]    
 @PatientSubFileID Varchar(50)    
AS                
BEGIN          
declare @iPatientID int ,       
  @vSQL nvarchar(4000)    
    
 select @iPatientID = PATIENT_ID  from AIMS_PATIENT where PATIENT_FILE_NO = @PatientSubFileID          
           
 select  d.user_full_name  
,b.MODIFIED_ACTION                                      
,b.MODIFIED_DATE              
,b.MODIFIED_USER                            
,b.APPOINTMENT_SUBJECT                                  
,b.APPOINTMENT_ADDRESS                                  
,b.APPOINTMENT_DATE                                     
,b.REMINDER_YN   
,b.REMINDER_PERIOD                                      
,b.TRANSPORT_YN   
,b.TRANSLATOR_YN  
,b.TRANSPORT_TYPE_ID   
,e.TRANSPORT_TYPE_DESC  
,a.CREATED_DTTM              
,a.CREATED_BY                                           
,b.APPOINTMENT_NOTE                                                                                                                                                                                                                                            
 
,b.APPOINTMENT_TIME          
,b.PICK_UP_TIME              
,b.DROP_OFF_TIME      from AIMS_APPOINTMENTS a  
 inner join  AIMS_A_APPOINTMENTS b on b.APPOINTMENT_ID = a.APPOINTMENT_ID  
 inner join AIMS_USERS c on c.User_Name = b.MODIFIED_USER  
 inner join AIMS_USERS d on d.User_Name = b.CREATED_BY  
 left outer join AIMS_TRANSPORT_TYPE e on e.TRANSPORT_TYPE_ID = b.TRANSPORT_TYPE_ID  
 where a.PATIENT_ID = @iPatientID  
 ORDER BY b.MODIFIED_DATE desc     
    
  EXECUTE  sp_executesql  @vSQL           
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SUPPLIER_UPDATE]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*  Return Values of the procedure 	*/
------------------------------------------
/*  -1 : Error 				*/
/*  0  : Successful		        */

CREATE PROCEDURE [dbo].[AIMS_SUPPLIER_UPDATE]  
	@PatientFileNo varchar(50),
	@PatientInitials varchar(50) = '',
	@PatientFirstName varchar(50) = '',
	@PatientMiddleName varchar(50) = '',
	@PatientLastName varchar(50) = '',
	@PatientCompanyID int,
	@PatientTitleID int,
	@PatientAddressID int,
	@PatientFaxNo varchar(50) = '',
	@PatientMobileNo varchar(50) = '',
	@PatientEmailAddress varchar(50) = '',
	@PatientGuarantorID int,
	@PatientGuarantorRefNo  varchar(50) = '',
	@PatientFileActiveYN varchar(50) = '',
	@AddressTypeID int,
	@Address1 varchar(50), 
	@Address2 varchar(50), 
	@Address3 varchar(50),
	@Address4 varchar(50),
	@Address5 varchar(50), 
	@PostalCode varchar(30), 
	@CountryID int,
	@UserSignedOn varchar(50)
as 
	BEGIN TRANSACTION addPatient

	DECLARE @LastError INT, @PatientID numeric, @sSQL nvarchar(4000)

	SET @LastError = 0
	
	select @PatientID = patient_id from aims_patient where patient_file_no = @PatientFileNo
 
	/* UPDATE ADDRESS INFORMATION */
	set @sSQL	= 'update aims_address ' +
			' set ADDRESS_TYPE_ID =  ' + CAST(@AddressTypeID as varchar(2)) + ', ' +
			' ADDRESS1 = ''' + @Address1 + ''', ADDRESS2 	= '''+ @Address2 + ''', ' +
			' ADDRESS3 = ''' + @Address3 + ''', ADDRESS4 	= '''+ @Address4 + ''', ' +
			' ADDRESS5 = ''' + @Address5 + ''', POSTAL_CODE 	= '''+ @PostalCode + ''', ' +
			' COUNTRY_ID = '+ CAST(@CountryID as varchar(2)) + ', DEFAULT_YN =''Y'', ACTIVE_YN = ''Y''' +
			' where address_id = (Select address_id from aims_patient where patient_file_no = ''' + @PatientFileNo +''')'

	EXECUTE  sp_executesql @sSQL

	if (@@ERROR <> 0) 
	begin
		insert into aims_debugging values ('Step 1','Address Table update Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())		
		SET @LastError = @@ERROR
		ROLLBACK TRANSACTION
		Return (-1)   
	end
	
	set @sSQL	= ' update aims_patient ' +
			' set 	PATIENT_INITIALS = ''' + @PatientInitials 	+ ''',' + 
			' PATIENT_FIRST_NAME      = ''' + @PatientFirstName 	+ ''', PATIENT_MIDDLE_NAME = ''' + @PatientMiddleName + ''',' +
			' PATIENT_LAST_NAME       = ''' + @PatientLastName 	+ ''',' +  'COMPANY_ID = ' + CAST(@PatientCompanyID as varchar(2)) + ',' + 
			' ADDRESS_ID = ' + CAST(@PatientAddressID as varchar(2)) + ' , TITLE_ID                = '   + CAST(@PatientTitleID as varchar(2))   + ',' ++
			' PATIENT_FAX_NO          = '''   + @PatientFaxNo 	+ '''  , PATIENT_MOBILE_NO = ''' + @PatientMobileNo + ''',' +
			' PATIENT_EMAIL_ADDRESS   = ''' + @PatientEmailAddress 	+ ''' ,GUARANTOR_ID = ' + CAST(@PatientGuarantorID as varchar(2)) + ',' +
			' GUARANTOR_REF_NO        = ''' + @PatientGuarantorRefNo + ''' , PATIENT_FILE_ACTIVE_YN = ''' + @PatientFileActiveYN + '''' +
			' where patient_file_no   = ''' + @PatientFileNo + ''''

	EXECUTE  sp_executesql  @sSQL

	if (@@ERROR <> 0) 
	begin
		SET @LastError = @@ERROR
		insert into aims_debugging values ('Step 1','Patient Table update Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION
		Return (-1)
	end

	/* TRACE_ID - Identity Column */
	insert into AIMS_TRACE(
		PATIENT_FILE_NO,
		DATE_TIME,
		USER_NAME,
		DESCRIPTION,
		COMMENTS,
		PATIENT_ID) values(
				@PatientFileNo, 
				GETDATE(),
				@UserSignedOn,
				'Patient Details Update',
				'Patient Details Updated Successfully',
				@PatientID)
	
	/* If Insert to the trace table failed then exit*/				
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Trace Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
		RETURN -1
	end

	/* If Insert to the NOTES table failed then exit*/

	/* NOTE_ID - Identity Column */
	insert into AIMS_NOTES(
		USER_NAME,
		NOTES,
		NOTES_DTTM,
		PATIENT_ID) values(
				   @UserSignedOn,
				   'New File for Patient',
				   GETDATE(),
				   @PatientID)

	/* If Insert to the trace table failed then exit*/				
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Notes Table Insert Failed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
		RETURN -1
	end		
		
	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','Patient Saving Completed with an error number[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addPatient
	end
	else
	begin	
		COMMIT TRANSACTION addPatient
	end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENTS_HIGH_COST_FILES]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENTS_HIGH_COST_FILES]        
AS        
BEGIN        
    
SELECT     
a.patient_file_no,        
         LTRIM (          
                + dbo.INITCAP (a.patient_first_name)        
                + ' '        
                + dbo.INITCAP (a.patient_last_name)        
               ) patient_name,    
               D.SUPPLIER_NAME 'hospital',    
               A.PATIENT_GUARANTOR_AMOUNT,    
               C.NOTES 'interim_note'                   
                FROM AIMS_PATIENT A    
INNER JOIN AIMS_GUARANTOR B ON B.GUARANTOR_ID = A.GUARANTOR_ID      
LEFT OUTER JOIN AIMS_NOTES C ON C.PATIENT_ID = A.PATIENT_ID AND C.NOTE_TYPE_ID = (SELECT NOTE_TYPE_ID FROM AIMS_NOTE_TYPES  WHERE NOTE_TYPE_CD = 'PATIENTINTERIMNOTES')    
AND C.NOTE_ID = (SELECT MAX(XX.NOTE_ID) FROM AIMS_NOTES XX WHERE XX.PATIENT_ID = A.PATIENT_ID and     
NOTE_TYPE_ID = 18)    
LEFT OUTER JOIN AIMS_SUPPLIER D ON D.SUPPLIER_ID = A.SUPPLIER_ID    
WHERE A.CANCELLED = 'N' AND A.PATIENT_FILE_ACTIVE_YN='Y' and A.HIGH_COST = 'Y'   
and SENT_TO_ADMIN = 'N' 
order by a.patient_file_no 
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_TASK_GET]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_TASK_GET]              
    @PatientFileTaskID varchar(50)            
AS      
BEGIN           
SELECT * FROM   
 AIMS_TASKS a  
 left outer join aims_patient_file_tasks b on b.task_id = a.TASK_ID   
 left outer join AIMS_TASK_STATUS c  on c.task_status_id = b.task_status_id    
WHERE     
 b.patient_file_task_id = @PatientFileTaskID  
END
GO
/****** Object:  Table [dbo].[AIMS_SEND_EMAIL_ATTACHMENTS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_SEND_EMAIL_ATTACHMENTS](
	[EMAIL_ATTACHMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[EMAIL_ATTACHMENT_LIST] [varchar](4000) NOT NULL,
	[EMAIL_REQ_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_SEND_EMAIL_ATTACHMENTS] PRIMARY KEY CLUSTERED 
(
	[EMAIL_ATTACHMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PAYMENT_GET]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PAYMENT_GET]    
    @PaymentID int  
  
as   
 declare @vSQL  nvarchar(500)  
   
 Select * from aims_payment  app  
 LEFT outer join aims_guarantor as agg on agg.guarantor_id  =  app.guarantor_id  
 LEFT outer join aims_patient as apt on apt.patient_id  = app.patient_id  
 left outer join AIMS_INVOICE as aii on app.INVOICE_ID = aii.INVOICE_ID 
 where app.payment_id =  @PaymentID   
  
  
 /* Select * from aims_payment  app  
 LEFT outer join aims_guarantor as agg on agg.guarantor_id  =  app.guarantor_id  
 LEFT outer join aims_invoice as aii on aii.invoice_id = app.invoice_id  
 LEFT outer join aims_patient as apt on apt.patient_id  = app.patient_id  
 where app.payment_id =  @PaymentID  */  
  
 --EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PAYMENT_ADD]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PAYMENT_ADD]          
 @PaymentID   int output,        
 @PatientFileNo      varchar(4000)  = '',        
 @GuarantorName      varchar(4000) = '',                   
 @AmountPaid      varchar(4000)  = '',        
 @ReceiptNo   varchar(4000)  = '',        
 @DateOfReceipt  varchar(4000)   = '',        
 @PaymentMethodID  int,        
 @ChequeNo   varchar(4000)   = '',         
 @CreditCardNo   varchar(4000)   = '',         
 @BankTransferRefNo  varchar(4000)   = '',         
 @Notices   varchar(1000)   = '',         
 @InvoiceNo   varchar(4000),        
 @RenderDate   varchar(4000)   = '',         
 @PaymentLockedYN  varchar(4000)   = '',         
 @UserSignedOn   varchar(4000)  = '',    
 @ForexPayment  varchar(1)  = '',        
 @InsuranceOverPymt  varchar(1)  = '',    
 @InsuranceShortPymt  varchar(1)  = '',    
 @DoctorOwing   varchar(1),  
 @LateSubmissionPymt varchar(1),
 @DoctorOwingInvoiceNo   varchar(50)
as         
 BEGIN TRANSACTION addPayment        
        
 DECLARE @LastError INT, @vSQL varchar(4000), @PatientID int, @InvoiceID int, @GuarantorID int, @AmountPaidToDate varchar(4000), @AmountStillOutstanding varchar(4000), @DoctorOwingInvoiceID int
      
insert into AIMS_DEBUGGING(DEBUG_MSG, DEBUG_VALUE, DEBUG_DTTM) values('TEST - START UPDATE 1 ', @PaymentID , GETDATE())           
 if @DoctorOwingInvoiceNo IS NULL AND @DoctorOwingInvoiceNo = ''
 BEGIN
	SET @DoctorOwingInvoiceID = 0 
 END
 ELSE
 BEGIN
	SET @DoctorOwingInvoiceID = CAST(@DoctorOwingInvoiceNo AS NUMERIC)
 END 
 select @PatientID = patient_id from aims_patient where patient_file_no = @PatientFileNo        
 select @InvoiceID = invoice_id from aims_invoice where invoice_no = @InvoiceNo and patient_id = @PatientID        
 select @GuarantorID = guarantor_id from aims_guarantor where guarantor_name = @GuarantorName        
  insert into AIMS_DEBUGGING(DEBUG_MSG, DEBUG_VALUE, DEBUG_DTTM) values('TEST - START UPDATE 2', @PaymentID , GETDATE())        
 if @PaymentID is null        
 begin        
  SET   @AmountPaidToDate = @AmountPaid        
  --SELECT  @AmountStillOutstanding = CAST(CAST (aims_invoice.invoice_amount_received AS money) - SUM (CAST (aims_payment.amount_paid AS money)) AS VARCHAR(4000))  FROM  AIMS_INVOICE INNER JOIN AIMS_PAYMENT ON  AIMS_PAYMENT.PATIENT_ID = AIMS_INVOICE.PATIENT_ID group by invoice_amount_received        
        
  SELECT  @AmountStillOutstanding = '0.0'      
   insert into AIMS_DEBUGGING(DEBUG_MSG, DEBUG_VALUE, DEBUG_DTTM) values('TEST - START UPDATE 3', @PaymentID , GETDATE())        
  insert into aims_payment(        
   PATIENT_ID,        
   GUARANTOR_ID,        
   AMOUNT_PAID,        
   RECEIPT_NO,        
   DATE_OF_RECEIPT,        
   PAYMENT_METHOD_ID,        
   CHEQUE_NO,        
   CREDIT_CARD_NO,        
   BANK_TRANSFER_REF_NO,        
   NOTICES,        
   RENDER_DATE,        
   PAYMENT_PROCESSED_YN,        
   LOCKED_YN,        
   AMOUNT_PAID_TO_DATE,        
   AMOUNT_OUTSTANDING,     
   FOREX_PAYMENT,     
   INSURANCE_OVERPYMT,     
   INSURANCE_SHORTPYMT,    
   DOCTOR_OWING,  
   LATE_SUBMISSION_PYMT,
   INVOICE_ID)          
  Values (        
     @PatientID,         
     @GuarantorID,         
     @AmountPaid,         
     @ReceiptNo,         
     @DateOfReceipt,         
     @PaymentMethodID,         
     @ChequeNo,         
     @CreditCardNo,         
     @BankTransferRefNo,         
     @Notices,         
     @RenderDate,         
     'Y',        
     @PaymentLockedYN,      
     @AmountPaidToDate,     
     @AmountStillOutstanding,    
     @ForexPayment,    
     @InsuranceOverPymt,    
     @InsuranceShortPymt,    
     @DoctorOwing,  
     @LateSubmissionPymt,
     @DoctorOwingInvoiceNo)        
    
  set @PaymentID = IDENT_CURRENT('aims_payment')        
        
  insert into aims_A_payment(        
   MODIFIED_USER ,        
   MODIFIED_ACTION ,        
   MODIFIED_DATE ,        
   PAYMENT_ID,        
   PATIENT_ID,        
   GUARANTOR_ID,        
   AMOUNT_PAID,        
   RECEIPT_NO,        
   DATE_OF_RECEIPT,        
   PAYMENT_METHOD_ID,        
   CHEQUE_NO,        
   CREDIT_CARD_NO,        
   BANK_TRANSFER_REF_NO,        
   NOTICES,        
   RENDER_DATE,        
   PAYMENT_PROCESSED_YN,        
   LOCKED_YN,    
   FOREX_PAYMENT,     
   INSURANCE_OVERPYMT,     
   INSURANCE_SHORTPYMT,   
   DOCTOR_OWING,  
   LATE_SUBMISSION_PYMT,
   INVOICE_ID)  Values (        
     @UserSignedOn,        
     'ADD',        
     getdate(),        
     @PaymentID,        
     @PatientID,         
     @GuarantorID,         
     @AmountPaid,         
     @ReceiptNo,         
     @DateOfReceipt,         
     @PaymentMethodID,         
     @ChequeNo,         
     @CreditCardNo,         
     @BankTransferRefNo,         
     @Notices,         
     @RenderDate,         
     'Y',        
     @PaymentLockedYN,    
          @ForexPayment,    
     @InsuranceOverPymt,    
     @InsuranceShortPymt,    
     @DoctorOwing,  
     @LateSubmissionPymt,
     @DoctorOwingInvoiceNo)                  
 end        
 else        
 begin        
    
  SELECT  @AmountPaidToDate = SUM (cast(aims_payment.amount_paid as numeric(19,2))) FROM AIMS_PAYMENT WHERE PAYMENT_ID = @PaymentID        
  SELECT  @AmountStillOutstanding = CAST(CAST (aims_invoice.invoice_amount_received AS money) - SUM (CAST (aims_payment.amount_paid AS money)) AS VARCHAR(50))  FROM  AIMS_INVOICE INNER JOIN AIMS_PAYMENT ON  
  AIMS_PAYMENT.PATIENT_ID = AIMS_INVOICE.PATIENT_ID group by invoice_amount_received        
    
   update aims_payment        
  set         
    PATIENT_ID    = @PatientID,        
    GUARANTOR_ID   = @GuarantorID,        
    AMOUNT_PAID   = @AmountPaid,        
    RECEIPT_NO    = @ReceiptNo,        
    DATE_OF_RECEIPT   = @DateOfReceipt,        
    PAYMENT_METHOD_ID  = @PaymentMethodID,        
    CHEQUE_NO    = @ChequeNo,        
    CREDIT_CARD_NO   = @CreditCardNo,        
    BANK_TRANSFER_REF_NO  = @BankTransferRefNo,        
    NOTICES    = @Notices,         
    RENDER_DATE   = @RenderDate,        
    PAYMENT_PROCESSED_YN  = 'Y',        
    LOCKED_YN    = @PaymentLockedYN,        
  AMOUNT_PAID_TO_DATE = @AmountPaidToDate ,         
    AMOUNT_OUTSTANDING  = @AmountStillOutstanding,    
    FOREX_PAYMENT = @ForexPayment,    
    INSURANCE_OVERPYMT  = @InsuranceOverPymt,    
    INSURANCE_SHORTPYMT = @InsuranceShortPymt,    
    DOCTOR_OWING = @DoctorOwing,  
    LATE_SUBMISSION_PYMT = @LateSubmissionPymt,
    INVOICE_ID = @DoctorOwingInvoiceNo          
   where        
   payment_id   = @PaymentID        
    
  insert into aims_A_payment(        
  MODIFIED_USER ,        
  MODIFIED_ACTION ,        
  MODIFIED_DATE ,        
  PAYMENT_ID,        
  PATIENT_ID,        
  GUARANTOR_ID,        
  AMOUNT_PAID,        
  RECEIPT_NO,        
  DATE_OF_RECEIPT,        
  PAYMENT_METHOD_ID,        
  CHEQUE_NO,        
  CREDIT_CARD_NO,        
  BANK_TRANSFER_REF_NO,        
  NOTICES,        
  RENDER_DATE,        
  PAYMENT_PROCESSED_YN,        
  LOCKED_YN,     
  FOREX_PAYMENT,     
  INSURANCE_OVERPYMT,     
  INSURANCE_SHORTPYMT,    
  DOCTOR_OWING,  
  LATE_SUBMISSION_PYMT,
  INVOICE_ID    
  )  Values (        
     @UserSignedOn,        
     'UPDATE',        
     getdate(),        
     @PaymentID,        
     @PatientID,         
     @GuarantorID,         
     @AmountPaid,         
     @ReceiptNo,         
     @DateOfReceipt,         
     @PaymentMethodID,         
     @ChequeNo,         
     @CreditCardNo,         
     @BankTransferRefNo,         
     @Notices,         
     @RenderDate,         
     'Y',        
     @PaymentLockedYN,    
     @ForexPayment,    
     @InsuranceOverPymt,    
     @InsuranceShortPymt,    
     @DoctorOwing,  
     @LateSubmissionPymt,
     @DoctorOwingInvoiceNo)       
 end        
    
 if (@@ERROR <> 0)        
 begin        
  ROLLBACK TRANSACTION addPayment        
 end        
 else        
 begin         
  COMMIT TRANSACTION addPayment        
 end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_admin_workload_snapshot]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_admin_workload_snapshot]      
 @AdminStaff varchar(50) = ''     
AS      
BEGIN      
declare @vSQL NVARCHAR(MAX)     
insert into AIMS_DEBUGGING values ('-----444 stats 1111-----', @vSQL, GETDATE())   
      
select (@AdminStaff ) file_allocated_to,(SELECT count(a.FILE_ASSIGNED_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d    
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') and      
 FILE_ASSIGNED_TO_USERID IS NOT NULL and FILE_ASSIGNED_TO_USERID in(    
 select User_Name from AIMS_USER_ROLE where ROLE_CD = 'Admin')    
 and SENT_TO_ADMIN = 'Y'      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 'PATIENTFILEENQUIRY'))      
 AND c.guarantor_id = a.guarantor_id     
 and in_patient = 'Y'    
 and FILE_ASSIGNED_TO_USERID = @AdminStaff     
 AND d.user_name = FILE_ASSIGNED_TO_USERID      
 group by a.FILE_ASSIGNED_TO_USERID ) IN_PATIENT,    
 (SELECT  count(a.FILE_ASSIGNED_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and  SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') and
 FILE_ASSIGNED_TO_USERID IS NOT NULL and FILE_ASSIGNED_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = 'Admin')     
 and SENT_TO_ADMIN = 'Y'      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 'PATIENTFILEENQUIRY'))      
 AND c.guarantor_id = a.guarantor_id     
 and out_patient = 'Y'    
 and FILE_ASSIGNED_TO_USERID = @AdminStaff    and  SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') 
 AND d.user_name = FILE_ASSIGNED_TO_USERID      
 group by a.FILE_ASSIGNED_TO_USERID ) OUT_PATIENT,    
 (SELECT  count(a.FILE_ASSIGNED_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and     SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') and
 FILE_ASSIGNED_TO_USERID IS NOT NULL and FILE_ASSIGNED_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = 'Admin')     
 and SENT_TO_ADMIN = 'Y'      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 'PATIENTFILEENQUIRY'))      
 AND c.guarantor_id = a.guarantor_id     
 and RMR = 'Y'    
 and FILE_ASSIGNED_TO_USERID = @AdminStaff       and  SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') 
 AND d.user_name = FILE_ASSIGNED_TO_USERID      
 group by a.FILE_ASSIGNED_TO_USERID ) RMR,    
 (SELECT  count(a.FILE_ASSIGNED_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and      
 FILE_ASSIGNED_TO_USERID IS NOT NULL and FILE_ASSIGNED_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = 'Admin')     
 and SENT_TO_ADMIN = 'Y'      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 'PATIENTFILEENQUIRY'))      
 AND c.guarantor_id = a.guarantor_id     
 and REPAT = 'Y'    
 and FILE_ASSIGNED_TO_USERID = @AdminStaff      and  SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') 
 AND d.user_name = FILE_ASSIGNED_TO_USERID      
 group by a.FILE_ASSIGNED_TO_USERID ) REPATS,    
 (SELECT  count(a.FILE_ASSIGNED_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and      
 FILE_ASSIGNED_TO_USERID IS NOT NULL and FILE_ASSIGNED_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = 'Admin')     
 and SENT_TO_ADMIN = 'Y'      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 'PATIENTFILEENQUIRY'))      
 AND c.guarantor_id = a.guarantor_id     
 and FLIGHT = 'Y'    
 and FILE_ASSIGNED_TO_USERID = @AdminStaff      and  SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') 
 AND d.user_name = FILE_ASSIGNED_TO_USERID      
 group by a.FILE_ASSIGNED_TO_USERID ) Evacuations,    
 (SELECT  count(a.FILE_ASSIGNED_TO_USERID)    
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and      
 FILE_ASSIGNED_TO_USERID IS NOT NULL and FILE_ASSIGNED_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = 'Admin')     
 and SENT_TO_ADMIN = 'Y'      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 'PATIENTFILEENQUIRY'))      
 AND c.guarantor_id = a.guarantor_id     
 and ASSIST = 'Y'    
 and FILE_ASSIGNED_TO_USERID = @AdminStaff      and  SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') 
 AND d.user_name = FILE_ASSIGNED_TO_USERID      
 group by a.FILE_ASSIGNED_TO_USERID ) Assist,    
 (SELECT  count(a.FILE_ASSIGNED_TO_USERID)     
 FROM aims_patient a, aims_notes b, aims_guarantor c, aims_users d      
 WHERE     
 a.CREATION_DTTM > GETDATE() - 360 and     
 CANCELLED = 'N' and a.PATIENT_FILE_ACTIVE_YN = 'Y' and      
 FILE_ASSIGNED_TO_USERID IS NOT NULL and FILE_ASSIGNED_TO_USERID in (     
 select User_Name from AIMS_USER_ROLE where ROLE_CD = 'Admin')     
 and SENT_TO_ADMIN = 'Y'      
 AND b.patient_id = a.patient_id      
 AND b.note_id = (SELECT MAX (note_id)      
 FROM aims_notes      
 WHERE     
 aims_notes.patient_id = a.patient_id AND aims_notes.note_type_id NOT IN (      
 SELECT x.note_type_id      
 FROM aims_note_types x      
 WHERE x.note_type_cd =      
 'PATIENTFILEENQUIRY'))      
 AND c.guarantor_id = a.guarantor_id     
 and TRANSPORT = 'Y'    
 and FILE_ASSIGNED_TO_USERID = @AdminStaff      and  SENT_TO_ADMIN = 'Y' and (a.courier_receipt_date IS NOT NULL OR a.courier_receipt_date <> '') 
 AND d.user_name = FILE_ASSIGNED_TO_USERID      
 group by a.FILE_ASSIGNED_TO_USERID ) Transport,    
 (SELECT  COUNt(loaded_by)     
 FROM aims_patient_file_tasks a,     
 aims_tasks b,     
 aims_priority c,     
 aims_patient d     
 WHERE due_date < getdate ()     
 AND task_status_id IN (2, 8)     
 AND user_id IN (SELECT user_name     
 FROM aims_user_role)     
 AND b.task_id = a.task_id     
 AND c.priority_id = a.priority_id     
 AND d.patient_id = a.patient_id     
 and d.CANCELLED = 'N'    
 and LOADED_BY =@AdminStaff     
  and  d.SENT_TO_ADMIN = 'Y' and (d.courier_receipt_date IS NOT NULL OR d.courier_receipt_date <> '')
 group by LOADED_BY) overdue_tasks,    
 (select COUNT(*) from AIMS_EWS_ADMIN_MAILS a, AIMS_EWS_ADMIN_MAILBOX b where      
 b.OPERATOR_MAILBOX_USER_NAME =@AdminStaff and a.OPERATOR_MAILBOX_ID= b.OPERATOR_MAILBOX_ID and     
 WORK_ITEM_PROCESSED_YN = 'N' group by a.OPERATOR_MAILBOX_ID) WORKBASKET_ITEMS  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_PATIENT_SENT_EMAIL]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_GET_PATIENT_SENT_EMAIL]          
  @PatientFileNo VARCHAR(30)      
 AS          
 BEGIN          
 DECLARE @PatientID INT      
       
 SELECT @PatientID = PATIENT_ID FROM AIMS_PATIENT WHERE PATIENT_FILE_NO = @PatientFileNo      
       
 SELECT *       
  FROM AIMS_EWS_PATIENT_SENT_EMAILS a      
  INNER JOIN AIMS_EWS_EMAIL_SENDER B ON B.EMAIL_FROM_ID = A.EMAIL_FROM_ID      
  left outer JOIN AIMS_EWS_PATIENT_ENQUIRY C ON C.PATIENT_ENQUIRY_ID = A.PATIENT_ENQUIRY_ID      
  left outer join AIMS_EWS_EMAILS d on d.EMAIL_ID = C.EMAIL_ID      
  inner join AIMS_USERS e on e.User_Name = a.EMAIL_SENT_BY      
 WHERE A.PATIENT_ID = @PatientID      
 ORDER BY A.SENT_DTTM DESC       
 END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_PATIENT_EMAIL_DOCS_ATTACHED]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_GET_PATIENT_EMAIL_DOCS_ATTACHED]  
 @PatientEmailEnquiryID VARCHAR(50)  
AS  
BEGIN  
 SELECT * FROM   
  AIMS_EWS_EMAIL_DOCUMENTS a, AIMS_EWS_DOCUMENT_TYPE b  
 WHERE a.PATIENT_ENQUIRY_ID = @PatientEmailEnquiryID AND
	b.DOC_TYPE_ID = a.DOC_TYPE_ID
	ORDER BY 1  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_PATIENT_EMAIL_DOCS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_GET_PATIENT_EMAIL_DOCS]    
 @PATIENT_EMAIL_ENQUIRY_ID varchar(50)    
AS    
BEGIN    
 SELECT *      
  FROM     
   AIMS_EWS_PATIENT_ENQUIRY A    
   INNER JOIN AIMS_EWS_EMAIL_DOCUMENTS B on B.PATIENT_ENQUIRY_ID = a.PATIENT_ENQUIRY_ID    
   INNER JOIN AIMS_EWS_DOCUMENT_TYPE C on C.DOC_TYPE_ID = B.DOC_TYPE_ID  
   LEFT OUTER JOIN AIMS_EWS_OPERATOR_MAILS D ON D.PATIENT_ENQUIRY_ID = A.PATIENT_ENQUIRY_ID  
 WHERE     
  A.PATIENT_ENQUIRY_ID = @PATIENT_EMAIL_ENQUIRY_ID    
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_ATTACHMENT_MAILBOX]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_GET_ATTACHMENT_MAILBOX]    
@AttachmentId varchar(50)    
as    
begin    
SELECT D.* FROM AIMS_EWS_EMAIL_DOCUMENTS A  
INNER JOIN AIMS_EWS_PATIENT_ENQUIRY  B ON B.PATIENT_ENQUIRY_ID = A.PATIENT_ENQUIRY_ID  
INNER JOIN AIMS_EWS_EMAILS C ON C.EMAIL_ID = B.EMAIL_ID  
INNER JOIN AIMS_EWS_MAILBOXES D ON D.MAILBOX_ID = C.MAILBOX_ID  
WHERE EMAIL_DOCUMENT_ID =  @AttachmentId     
end
GO
/****** Object:  StoredProcedure [dbo].[aims_ews_emails_processed]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[aims_ews_emails_processed]    
  @PatientFileNo Varchar(50)            
AS            
BEGIN       
 Declare @PatientId int    
 select @PatientId = patient_id from aims_patient where patient_file_no = @PatientFileNo    
 select * from     
  AIMS_EWS_PATIENT_ENQUIRY a    
  inner  join  AIMS_EWS_OPERATOR_MAILS b on b.PATIENT_ENQUIRY_ID = a.PATIENT_ENQUIRY_ID    
  inner  join aims_users c on c.User_Name = b.WORK_ITEM_PROCESSED_BY    
  inner  join AIMS_EWS_EMAILS d on d.EMAIL_ID = a.EMAIL_ID    
 where a.PATIENT_ID = @PatientId   
 union  
  select * from     
  AIMS_EWS_PATIENT_ENQUIRY a    
  inner join  AIMS_EWS_ADMIN_MAILS b on b.PATIENT_ENQUIRY_ID = a.PATIENT_ENQUIRY_ID    
  inner join aims_users c on c.User_Name = b.WORK_ITEM_PROCESSED_BY    
  inner join AIMS_EWS_EMAILS d on d.EMAIL_ID = a.EMAIL_ID    
 where a.PATIENT_ID = @PatientId order by b.WORK_ITEM_PROCESSED_DTTM   
   
 end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_RECLASSIFY]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_RECLASSIFY]
	@NEW_DOC_TYPE_ID varchar(50),
	@EMAIL_ATTACHMENT_ID varchar(50)
AS
BEGIN
	UPDATE AIMS_EWS_EMAIL_DOCUMENTS 
		SET DOC_TYPE_ID = @NEW_DOC_TYPE_ID
	WHERE EMAIL_DOCUMENT_ID = @EMAIL_ATTACHMENT_ID
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_EMAIL_READ]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[AIMS_EWS_EMAIL_READ]  
 @PatientEmailEnquiryID varchar(50)  
AS  
BEGIN  
 UPDATE AIMS_EWS_OPERATOR_MAILS   
  SET   
   MAIL_READ_YN = 'Y',   
   MAIL_READ_DTTM = GETDATE()  
  WHERE PATIENT_ENQUIRY_ID =  @PatientEmailEnquiryID  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_EMAIL_PROCESSED]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_EMAIL_PROCESSED]            
 @PatientEmailEnquiryID varchar(50),      
 @LoggedInUser  varchar(50)             
AS              
BEGIN        
 UPDATE AIMS_EWS_OPERATOR_MAILS               
  SET               
   WORK_ITEM_PROCESSED_YN = 'Y',               
   WORK_ITEM_PROCESSED_DTTM = GETDATE(),      
   WORK_ITEM_PROCESSED_BY =   @LoggedInUser            
  WHERE PATIENT_ENQUIRY_ID =  @PatientEmailEnquiryID          
  
 UPDATE AIMS_EWS_ADMIN_MAILS               
  SET               
   WORK_ITEM_PROCESSED_YN = 'Y',               
   WORK_ITEM_PROCESSED_DTTM = GETDATE(),      
   WORK_ITEM_PROCESSED_BY =   @LoggedInUser            
  WHERE PATIENT_ENQUIRY_ID =  @PatientEmailEnquiryID          
          
                  
  update     
 AIMS_EWS_INSTANT_MESSAGING  set PROCESSED_DTTM = GETDATE(),    
 PROCESSED_BY =  @LoggedInUser       
 WHERE IINSTANT_MESSAGE_ID = @PatientEmailEnquiryID        
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_EMAIL_POD_DELIVERY]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery3.sql|0|0|C:\Users\HP\AppData\Local\Temp\~vsF175.sql  
CREATE PROC [dbo].[AIMS_EWS_EMAIL_POD_DELIVERY]  
 @FILE_NAME varchar(2000),  
 @DOC_TYPE_ID varchar(10),  
 @PATIENT_ENQUIRY_ID VARCHAR(50)  
AS  
BEGIN  
 INSERT INTO   
  AIMS_EWS_EMAIL_DOCUMENTS   
 VALUES(@FILE_NAME, @DOC_TYPE_ID, @PATIENT_ENQUIRY_ID)  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_DELETE]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_DELETE]  
@EMAIL_ATTACHMENT_ID VARCHAR(50)  
AS  
BEGIN  
 DELETE FROM AIMS_EWS_EMAIL_DOCUMENTS where EMAIL_DOCUMENT_ID = @EMAIL_ATTACHMENT_ID  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_PATIENT_EMAIL_SAVE]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_PATIENT_EMAIL_SAVE]                          
 @PatientEnquiryID VARCHAR(50) output,                          
 @PatientFileNo VARCHAR(50),                          
 @EMAIL_ID VARCHAR(50),        
 @URGENT_EMAIL varchar(1),        
 @QUERY_EMAIL varchar(1),    
 @INDEXED_BY  varchar(50),  
 @MAILBOX_NAME  varchar(50)  
AS                          
BEGIN                          
 DECLARE         
 @RowCheck INT,         
 @PatientID INT,         
 @FileOperator VARCHAR(50),        
 @OperatorMailBoxID INT,        
 @UrgentEmail INT,        
 @QueryFilePatientID INT        
       
 SELECT @PatientID = Patient_id from AIMS_PATIENT A WHERE A.PATIENT_FILE_NO = @PatientFileNo      
 SELECT @RowCheck = COUNT(*) FROM AIMS_EWS_PATIENT_ENQUIRY WHERE PATIENT_ID = @PatientID and EMAIL_ID = @EMAIL_ID and active_yn = 'Y'        
      
 IF(@URGENT_EMAIL = 'Y')        
 BEGIN        
 SELECT @UrgentEmail = PRIORITY_ID FROM AIMS_EWS_PRIORITY WHERE PRIORITY_DESC = 'URGENT'        
 END         
 ELSE        
 BEGIN        
 SELECT @UrgentEmail = PRIORITY_ID FROM AIMS_EWS_PRIORITY WHERE PRIORITY_DESC = 'NORMAL'        
 END        
      
 IF(@RowCheck = 0)                    
 BEGIN                          
  INSERT INTO AIMS_EWS_PATIENT_ENQUIRY Values(@PatientID, @EMAIL_ID, GETDATE(), 'Y', @UrgentEmail)                          
  SET @PatientEnquiryID = IDENT_CURRENT('AIMS_EWS_PATIENT_ENQUIRY')                    
 END                    
 ELSE                    
 BEGIN                    
  SELECT @PatientEnquiryID = PATIENT_ENQUIRY_ID FROM AIMS_EWS_PATIENT_ENQUIRY WHERE PATIENT_ID = @PatientID and EMAIL_ID = @EMAIL_ID  and active_yn = 'Y'                   
 END                     
 if (@MAILBOX_NAME = 'OPERATIONS')  
 begin                   
 SELECT @FileOperator = FILE_OPERATOR_TO_USERID FROM AIMS_PATIENT WHERE PATIENT_ID  = @PatientID                      
 end  
   
  if (@MAILBOX_NAME = 'ADMIN' )  
 begin                   
 SELECT @FileOperator = FILE_ASSIGNED_TO_USERID FROM AIMS_PATIENT WHERE PATIENT_ID  = @PatientID                      
 end  
  
  if (@MAILBOX_NAME = 'TEST' )  
 begin                   
 SELECT @FileOperator = FILE_ASSIGNED_TO_USERID FROM AIMS_PATIENT WHERE PATIENT_ID  = @PatientID                      
 end   
   
 IF(@FileOperator IS NOT NULL)            
 BEGIN            
  IF(@FileOperator != '')                      
  BEGIN                      
 IF (@MAILBOX_NAME = 'OPERATIONS')  
 begin                   
  SELECT @OperatorMailBoxID = OPERATOR_MAILBOX_ID FROM AIMS_EWS_OPERATOR_MAILBOX WHERE OPERATOR_MAILBOX_USER_NAME = @FileOperator                      
  INSERT INTO AIMS_EWS_OPERATOR_MAILS Values(@OperatorMailBoxID,@PatientEnquiryID,'N',NULL,'N', null, null)                     
 end  
 IF (@MAILBOX_NAME = 'ADMIN' )  
 begin                   
  SELECT @OperatorMailBoxID = OPERATOR_MAILBOX_ID FROM AIMS_EWS_ADMIN_MAILBOX WHERE OPERATOR_MAILBOX_USER_NAME = @FileOperator                      
  INSERT INTO AIMS_EWS_ADMIN_MAILS Values(@OperatorMailBoxID,@PatientEnquiryID,'N',NULL,'N', null, null)                     
 end  
   
 if(@MAILBOX_NAME = 'TEST')  
 begin                   
  SELECT @OperatorMailBoxID = OPERATOR_MAILBOX_ID FROM AIMS_EWS_ADMIN_MAILBOX WHERE OPERATOR_MAILBOX_USER_NAME = @FileOperator                      
  INSERT INTO AIMS_EWS_ADMIN_MAILS Values(@OperatorMailBoxID,@PatientEnquiryID,'N',NULL,'N', null, null)                     
 end  
   END               
 END            
 ELSE            
 BEGIN            
  IF (@MAILBOX_NAME = 'OPERATIONS')  
 begin  
  INSERT INTO AIMS_EWS_OPERATOR_MAILS Values(NULL,@PatientEnquiryID,'N',NULL,'N', null, null)                     
 end  
   
  IF (@MAILBOX_NAME = 'ADMIN')  
 begin  
  INSERT INTO AIMS_EWS_ADMIN_MAILS Values(NULL,@PatientEnquiryID,'N',NULL,'N', null, null)                     
 end  
  
  IF (@MAILBOX_NAME = 'TEST')  
 begin  
  INSERT INTO AIMS_EWS_ADMIN_MAILS Values(NULL,@PatientEnquiryID,'N',NULL,'N', null, null)                     
 end   
   
 END            
update AIMS_EWS_EMAILS set EMAIL_INDEXED_BY = @INDEXED_BY where EMAIL_ID = @EMAIL_ID                        
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_PATIENT_EMAIL_REINDEX]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_PATIENT_EMAIL_REINDEX]    
  @PatientFileNo varchar(50) = '',    
  @PatientFileEmailEnquiryID varchar(50) = '',    
  @UserLoggedOn varchar(50) = ''    
 AS    
 BEGIN    
  DECLARE @FileOperator varchar(50), @PatientID int    
      
  SELECT @FileOperator = FILE_OPERATOR_TO_USERID from aims_patient where patient_file_no = @PatientFileNo    
  SELECT @PatientID = Patient_id from aims_patient where patient_file_no = @PatientFileNo    
      
     update AIMS_EWS_PATIENT_ENQUIRY set PATIENT_ID = @PatientID    
  where PATIENT_ENQUIRY_ID = @PatientFileEmailEnquiryID    
      
  IF (@FileOperator is not null)         
   BEGIN          
    IF (@FileOperator <> '')        
    BEGIN        
   UPDATE AIMS_EWS_OPERATOR_MAILS SET OPERATOR_MAILBOX_ID = (    
    SELECT a.OPERATOR_MAILBOX_ID FROM AIMS_EWS_OPERATOR_MAILBOX a WHERE a.OPERATOR_MAILBOX_USER_NAME = @FileOperator)    
   WHERE PATIENT_ENQUIRY_ID = @PatientFileEmailEnquiryID   
   
   insert into AIMS_NOTES    values (@UserLoggedOn, 'File Re-Indexing Request Successful: ' + @PatientFileNo, GETDATE(),@PatientID, 7)
   
    END        
   END     
 END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_PATIENT_EMAIL_ENQUIRY_DOCS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_PATIENT_EMAIL_ENQUIRY_DOCS]      
 @PatientEnquiryID VARCHAR(50) ,      
 @EmailIndexingDoc VARCHAR(255),   
 @FileName varchar(4000)  
AS      
BEGIN      
 DECLARE @RowCheck INT , @DocTypeID INT     
       
 SELECT @DocTypeID = DOC_TYPE_ID from AIMS_EWS_DOCUMENT_TYPE A WHERE A.DOC_TYPE = @EmailIndexingDoc      
   
 INSERT INTO AIMS_EWS_EMAIL_DOCUMENTS(  
  FILE_NAME,  
  DOC_TYPE_ID,  
  PATIENT_ENQUIRY_ID) Values(  
    @FileName,  
    @DocTypeID,  
    @EmailIndexingDoc)  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_URGENT_EMAILS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_GET_URGENT_EMAILS]
AS
BEGIN
		SELECT e.patient_file_no, f.email_received_dttm, d.user_full_name
	  FROM aims_ews_patient_enquiry a LEFT OUTER JOIN aims_ews_operator_mails b
		   ON b.patient_enquiry_id = a.patient_enquiry_id
		   LEFT OUTER JOIN aims_ews_operator_mailbox c
		   ON c.operator_mailbox_id = b.operator_mailbox_id
		   LEFT OUTER JOIN aims_users d ON d.user_name =
													  c.operator_mailbox_user_name
		   LEFT OUTER JOIN aims_patient e ON e.patient_id = a.patient_id
		   LEFT OUTER JOIN aims_ews_emails f ON f.email_id = a.email_id
	 WHERE a.priority_id = 1 AND b.work_item_processed_yn = 'N'
	ORDER BY 3, 2
	END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GET_PATIENT_LOG]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_GET_PATIENT_LOG]  
@Patient_ID varchar(50)  
as  
begin  
SELECT *  
  FROM aims_ews_email_documents a, aims_ews_patient_enquiry b  
 WHERE a.doc_type_id = 12 AND b.patient_enquiry_id = a.patient_enquiry_id   
 AND b.patient_id=  @Patient_ID and b.active_yn = 'Y'  
 order by a.email_document_id desc  
end
GO
/****** Object:  Table [dbo].[AIMS_EWS_SENT_EMAIL_ATTACHMENTS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AIMS_EWS_SENT_EMAIL_ATTACHMENTS](
	[SENT_EMAIL_ATTACHMENT_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[SENT_EMAIL_ID] [numeric](18, 0) NOT NULL,
	[SENT_EMAIL_ATTACHMENT] [varchar](1000) NOT NULL,
	[SENT_EMAIL_ATTACHMENT_TYPE] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AIMS_EWS_SENT_EMAIL_ATTACHMENTS] PRIMARY KEY CLUSTERED 
(
	[SENT_EMAIL_ATTACHMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_SAVE_SENT_EMAIL]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AIMS_EWS_SAVE_SENT_EMAIL]   
  @PatientSentEmailID VARCHAR(50) output,                       
  @PatientFileNo VARCHAR(30),  
  @SentTo VARCHAR(255),        
  @EmailFromID VARCHAR(30),      
  @PatientEnquiryID VARCHAR(30),    
  @EmailSubject varchar(255),    
  @EmailSentBy varchar(255),
  @SentToCC varchar(255)
 AS          
BEGIN          
 DECLARE @PatientID INT      
        
 SELECT @PatientID = PATIENT_ID FROM AIMS_PATIENT WHERE PATIENT_FILE_NO = @PatientFileNo      
        
 INSERT INTO       
  AIMS_EWS_PATIENT_SENT_EMAILS        
 VALUES(@PatientID, @SentTo, GETDATE(), @EmailFromID, @PatientEnquiryID, @EmailSubject, @EmailSentBy, @SentToCC)      
        
 SET @PatientSentEmailID = IDENT_CURRENT('AIMS_EWS_PATIENT_SENT_EMAILS')          
 END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_GUARANTOR_ANALYSIS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_GUARANTOR_ANALYSIS]    
 @GuarantorID INT,    
 @StartDate varchar(50),    
 @EndDate varchar(50)    
AS    
BEGIN    
 DECLARE @FlightGuarantorID INT    
     
 SELECT @FlightGuarantorID = GUARANTOR_ID FROM AIMS_GUARANTOR where GUARANTOR_NAME like '%FLIGHT%'    
     
 SELECT    
  (select COUNT(*) from AIMS_PATIENT a where (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.TRANSPORT  = 'Y')"<span style=""font-family:Calibri;font-size:medium;font-weight:bo;background-color:#FFCC00;width:100%"">Tranportation XXXXX</span>",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_TRANSPORT_TYPE b where (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.TRANSPORT  = 'Y' and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and  b.TRANSPORT_TYPE_ID = a.PATIENT_TRANSPORT_TYPE_ID and b.TRANSPORT_TYPE_DESC = 'AIMS') "Tranportation - AIMS",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_TRANSPORT_TYPE b where (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.TRANSPORT  = 'Y' and b.TRANSPORT_TYPE_ID = a.PATIENT_TRANSPORT_TYPE_ID and b.TRANSPORT_TYPE_DESC = 'Ambulance') "Tranportation - Ambulance",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_TRANSPORT_TYPE b where (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.TRANSPORT  = 'Y' and b.TRANSPORT_TYPE_ID = a.PATIENT_TRANSPORT_TYPE_ID and b.TRANSPORT_TYPE_DESC = 'Car Hire') "Tranportation - Car Hire",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_TRANSPORT_TYPE b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.TRANSPORT  = 'Y' and b.TRANSPORT_TYPE_ID = a.PATIENT_TRANSPORT_TYPE_ID and b.TRANSPORT_TYPE_DESC = 'Private') "Tranportation - Private",    
  (SELECT GETDATE() "BREAK") "break",    
  (select COUNT(*) from AIMS_PATIENT a where a.CANCELLED = 'N' and    (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.IN_PATIENT  = 'Y') "IN-Patient",    
  (select COUNT(*) from AIMS_PATIENT a where a.CANCELLED = 'N' and   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE,103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.OUT_PATIENT = 'Y') "OUT-Patient",    
  (SELECT GETDATE() "BREAK") "break",    
  (select COUNT(*) from AIMS_PATIENT a where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT  = 'Y') "<span style=""font-family:Calibri;font-size:medium;background-color:#FFCC00;width:100%"">Repatriation XXXXX</span>",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Air Ambulance') "Repatriation - Air Ambulance",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight') "Repatriation - Commercial Flight",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - DR Escort') "Repatriation - Commercial Flight - DR Escort",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Non Med Escort') "Repatriation - Commercial Flight - Non Med Escort",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Nurse Escort') "Repatriation - Commercial Flight - Nurse Escort",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Unaccompanied') "Repatriation - Commercial Flight - Unaccompanied",    
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Ground Ambulance') "Repatriation - Ground Ambulance",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - DR Escort') "Commercial Flight - DR Escort",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - DR Escort(AIMS)') "Commercial Flight - DR Escort(AIMS)",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - DR Escort(Insured)') "Commercial Flight - DR Escort(Insured)",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Non Med Escort') "Commercial Flight - Non Med Escort",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Non Med Escort(AIMS)') "Commercial Flight - Non Med Escort(AIMS)",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Non Med Escort(Insured)') "Commercial Flight - Non Med Escort(Insured)",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Nurse Escort') "Commercial Flight - Nurse Escort",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Nurse Escort(AIMS)') "Commercial Flight - Nurse Escort(AIMS)",   
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Nurse Escort(Insured)') "Commercial Flight - Nurse Escort(Insured)",  
  (select COUNT(*) from AIMS_PATIENT a, AIMS_REPAT_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.REPAT = 'Y' and b.REPAT_TYPE_ID = a.PATIENT_REPAT_TYPE_ID and b.REPAT_TYPE_DESC = 'Commercial Flight - Unaccompanied') "Commercial Flight - Unaccompanied",   
  (SELECT GETDATE() "BREAK") "break",    
  (select COUNT(*)  from AIMS_PATIENT a where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.ASSIST   = 'Y') "<span style=""font-family:Calibri;font-size:medium;background-color:#FFCC00;width:100%"">Assistance XXXXX</span>",    
  (select COUNT(*)  from AIMS_PATIENT a, AIMS_ASSIST_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.ASSIST = 'Y' and b.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID and b.ASSIST_TYPE_DESC = 'Accomodation') "Assistance - Accomodation",    
  (select COUNT(*)  from AIMS_PATIENT a, AIMS_ASSIST_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.ASSIST = 'Y' and b.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID and b.ASSIST_TYPE_DESC = 'Accomodation & Transport') "Assistance - Accomodation & Transport",    
  (select COUNT(*)  from AIMS_PATIENT a, AIMS_ASSIST_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.ASSIST = 'Y' and b.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID and b.ASSIST_TYPE_DESC = 'Admin Fee') "Assistance - Admin Fee",    
  (select COUNT(*)  from AIMS_PATIENT a, AIMS_ASSIST_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.ASSIST = 'Y' and b.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID and b.ASSIST_TYPE_DESC = 'Cash Advance') "Assistance - Cash Advance",    
  (select COUNT(*)  from AIMS_PATIENT a, AIMS_ASSIST_TYPE  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.ASSIST = 'Y' and b.ASSIST_TYPE_ID = a.PATIENT_ASSIST_TYPE_ID and b.ASSIST_TYPE_DESC = 'Sundries') "Assistance - Sundries",    
  (SELECT GETDATE() "BREAK") "break",    
  ((select COUNT(*) from AIMS_PATIENT a where (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.FLIGHT = 'Y')+(select COUNT(*)  from AIMS_PATIENT a , AIMS_PATIENT b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = @FlightGuarantorID and a.FLIGHT = 'Y' and b.PATIENT_ID  = a.PATIENT_ID and b.FLIGHT_GUARANTOR_ID = X.GUARANTOR_ID)) "<span style=""font-family:Calibri;font-size:medium;background-color:#FFCC00;width:100%"">Evacuation XXXXX</span>",    
  ((select COUNT(*) from AIMS_PATIENT a, AIMS_EVACUATION_TYPES  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.FLIGHT = 'Y' and b.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID and b.EVACUATION_TYPE_DESC = 'Air Ambulance')+(SELECT COUNT(*) FROM aims_patient a inner join aims_evacuation_types b on b.evacuation_type_id = a.patient_evacuation_type_id left outer join AIMS_PATIENT c on c.PATIENT_ID = a.PATIENT_ID WHERE (a.patient_admission_date IS NOT NULL OR a.patient_admission_date != '') AND CONVERT (datetime, a.patient_admission_date, 103) >= @StartDate AND CONVERT (datetime, a.patient_admission_date, 103) <= @EndDate AND a.guarantor_id = @FlightGuarantorID AND a.flight = 'Y' AND b.evacuation_type_desc = 'Air Ambulance' and c.FLIGHT_GUARANTOR_ID = X.GUARANTOR_ID)) "Evacuation - Air Ambulance",    
  ((select COUNT(*) from AIMS_PATIENT a, AIMS_EVACUATION_TYPES  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.FLIGHT = 'Y' and b.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID and b.EVACUATION_TYPE_DESC = 'Commercial Flight')+(SELECT COUNT(*) FROM aims_patient a inner join aims_evacuation_types b on b.evacuation_type_id = a.patient_evacuation_type_id left outer join AIMS_PATIENT c on c.PATIENT_ID = a.PATIENT_ID WHERE (a.patient_admission_date IS NOT NULL OR a.patient_admission_date != '') AND CONVERT (datetime, a.patient_admission_date, 103) >= @StartDate AND CONVERT (datetime, a.patient_admission_date, 103) <= @EndDate AND a.guarantor_id = @FlightGuarantorID AND a.flight = 'Y' AND b.evacuation_type_desc = 'Commercial Flight' and c.FLIGHT_GUARANTOR_ID = X.GUARANTOR_ID)) "Evacuation - Commercial Flight",    
  ((select COUNT(*) from AIMS_PATIENT a, AIMS_EVACUATION_TYPES  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.FLIGHT = 'Y' and b.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID and b.EVACUATION_TYPE_DESC = 'Commercial Flight - DR/RW Escort')+(SELECT COUNT(*) FROM aims_patient a inner join aims_evacuation_types b on b.evacuation_type_id = a.patient_evacuation_type_id left outer join AIMS_PATIENT c on c.PATIENT_ID = a.PATIENT_ID WHERE (a.patient_admission_date IS NOT NULL OR a.patient_admission_date != '') AND CONVERT (datetime, a.patient_admission_date, 103) >= @StartDate AND CONVERT (datetime, a.patient_admission_date, 103) <= @EndDate AND a.guarantor_id = @FlightGuarantorID AND a.flight = 'Y' AND b.evacuation_type_desc = 'Commercial Flight - DR/RW Escort' and c.FLIGHT_GUARANTOR_ID = X.GUARANTOR_ID)) "Evacuation - Commercial Flight - DR/RW Escort",    
  ((select COUNT(*) from AIMS_PATIENT a, AIMS_EVACUATION_TYPES  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.FLIGHT = 'Y' and b.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID and b.EVACUATION_TYPE_DESC = 'Commercial Flight - Non Medical')+(SELECT COUNT(*) FROM aims_patient a inner join aims_evacuation_types b on b.evacuation_type_id = a.patient_evacuation_type_id left outer join AIMS_PATIENT c on c.PATIENT_ID = a.PATIENT_ID WHERE (a.patient_admission_date IS NOT NULL OR a.patient_admission_date != '') AND CONVERT (datetime, a.patient_admission_date, 103) >= @StartDate AND CONVERT (datetime, a.patient_admission_date, 103) <= @EndDate AND a.guarantor_id = @FlightGuarantorID AND a.flight = 'Y' AND b.evacuation_type_desc = 'Commercial Flight - Non Medical' and c.FLIGHT_GUARANTOR_ID = X.GUARANTOR_ID)) "Evacuation - Commercial Flight - Non Medical",    
  ((select COUNT(*) from AIMS_PATIENT a, AIMS_EVACUATION_TYPES  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.FLIGHT = 'Y' and b.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID and b.EVACUATION_TYPE_DESC = 'Ground Ambulance')+(SELECT COUNT(*) FROM aims_patient a inner join aims_evacuation_types b on b.evacuation_type_id = a.patient_evacuation_type_id left outer join AIMS_PATIENT c on c.PATIENT_ID = a.PATIENT_ID WHERE (a.patient_admission_date IS NOT NULL OR a.patient_admission_date != '') AND CONVERT (datetime, a.patient_admission_date, 103) >= @StartDate AND CONVERT (datetime, a.patient_admission_date, 103) <= @EndDate AND a.guarantor_id = @FlightGuarantorID AND a.flight = 'Y' AND b.evacuation_type_desc = 'Ground Ambulance' and c.FLIGHT_GUARANTOR_ID = X.GUARANTOR_ID)) "Evacuation - Ground Ambulance",    
  ((select COUNT(*) from AIMS_PATIENT a, AIMS_EVACUATION_TYPES  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.FLIGHT = 'Y' and b.EVACUATION_TYPE_ID = a.PATIENT_EVACUATION_TYPE_ID and b.EVACUATION_TYPE_DESC = 'Mortal Remains')+(SELECT COUNT(*) FROM aims_patient a inner join aims_evacuation_types b on b.evacuation_type_id = a.patient_evacuation_type_id left outer join AIMS_PATIENT c on c.PATIENT_ID = a.PATIENT_ID WHERE (a.patient_admission_date IS NOT NULL OR a.patient_admission_date != '') AND CONVERT (datetime, a.patient_admission_date, 103) >= @StartDate AND CONVERT (datetime, a.patient_admission_date, 103) <= @EndDate AND a.guarantor_id = @FlightGuarantorID AND a.flight = 'Y' AND b.evacuation_type_desc = 'Mortal Remains' and c.FLIGHT_GUARANTOR_ID = X.GUARANTOR_ID)) "Evacuation - Mortal Remains",    
  (SELECT GETDATE() "BREAK") "break",    
  (select COUNT(*)  from AIMS_PATIENT a where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.RMR   = 'Y') "<span style=""font-family:Calibri;font-size:medium;background-color:#FFCC00;width:100%"">Repatriation Mortal Remains</span>",    
  (select COUNT(*)  from AIMS_PATIENT a, AIMS_RMR_TYPES  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.RMR = 'Y' and b.RMR_TYPE_ID = a.PATIENT_RMR_TYPE_ID and b.RMR_TYPE_DESC = 'RMR - Unaccompanied') "RMR - Unaccompanied",    
  (select COUNT(*)  from AIMS_PATIENT a, AIMS_RMR_TYPES  b where   (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and a.GUARANTOR_ID = X.GUARANTOR_ID and a.RMR = 'Y' and b.RMR_TYPE_ID = a.PATIENT_RMR_TYPE_ID and b.RMR_TYPE_DESC = 'RMR - Accompanied') "RMR - Accompanied",    
  (SELECT GETDATE() "BREAK") "break",    
  (select sum(cast(b.INVOICE_AMOUNT_RECEIVED as money) ) from     
     AIMS_PATIENT a ,     
     AIMS_INVOICE b ,    
     AIMS_INVOICE_MEDICAL_TREATMENTS c    
     , AIMS_MEDICAL_TREATMENT d    
    where     
       (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and    
      a.GUARANTOR_ID = X.GUARANTOR_ID and     
      a.CANCELLED = 'N' and     
      b.PATIENT_ID = a.PATIENT_ID and     
      b.CANCELLED_YN = 'N' and    
      c.INVOICE_ID = b.INVOICE_ID and    
      d.MEDICAL_TREATMENT_ID = c.MEDICAL_TREATMENT_ID)+    
      ( select ISNULL(sum(cast(b.INVOICE_AMOUNT_RECEIVED as money)),0) from     
            AIMS_PATIENT a     
            inner join AIMS_INVOICE b on b.PATIENT_ID = a.PATIENT_ID      
            inner join AIMS_INVOICE_MEDICAL_TREATMENTS c on c.INVOICE_ID = b.INVOICE_ID     
            inner join AIMS_MEDICAL_TREATMENT d on d.MEDICAL_TREATMENT_ID = c.MEDICAL_TREATMENT_ID    
            left outer join AIMS_PATIENT e on a.PATIENT_ID = e.PATIENT_ID    
           where     
              (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate and    
             a.GUARANTOR_ID = @FlightGuarantorID and     
             a.CANCELLED = 'N' and     
             b.CANCELLED_YN = 'N' and    
             e.FLIGHT_GUARANTOR_ID = X.GUARANTOR_ID    
      ) "<font color=red face=Calibri size=Small>Business Transaction Costing</font>",    
  (SELECT GETDATE() "BREAK") "break",    
  (select sum(cast(b.INVOICE_AMOUNT_RECEIVED as money) ) from     
     AIMS_PATIENT a,  
     AIMS_INVOICE b,  
     AIMS_INVOICE_MEDICAL_TREATMENTS c    
     , AIMS_MEDICAL_TREATMENT d    
    where     
      (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate  and    
      a.GUARANTOR_ID = X.GUARANTOR_ID and     
      a.CANCELLED = 'N' and     
      b.PATIENT_ID = a.PATIENT_ID and     
      b.CANCELLED_YN = 'N' and    
      c.INVOICE_ID = b.INVOICE_ID and    
      d.MEDICAL_TREATMENT_ID = c.MEDICAL_TREATMENT_ID and    
      d.SERVICE_ID = 13)+     
      (    
    select ISNULL(sum(cast(b.INVOICE_AMOUNT_RECEIVED as money)),0) from     
     AIMS_PATIENT a     
     inner join AIMS_INVOICE b on b.PATIENT_ID = a.PATIENT_ID    
     inner join AIMS_INVOICE_MEDICAL_TREATMENTS c on c.INVOICE_ID = b.INVOICE_ID    
     inner join AIMS_MEDICAL_TREATMENT d on d.MEDICAL_TREATMENT_ID = c.MEDICAL_TREATMENT_ID    
     left outer join AIMS_PATIENT e on e.PATIENT_ID = a.PATIENT_ID    
    where     
      (a.PATIENT_ADMISSION_DATE is not null or a.PATIENT_ADMISSION_DATE != '') and convert(datetime,a.PATIENT_ADMISSION_DATE, 103) >= @StartDate and convert(datetime,a.PATIENT_ADMISSION_DATE, 103)<= @EndDate  and    
      a.GUARANTOR_ID = @FlightGuarantorID and     
      a.CANCELLED = 'N' and     
      b.CANCELLED_YN = 'N' and    
      d.SERVICE_ID = 13 and    
      e.FLIGHT_GUARANTOR_ID =X.GUARANTOR_ID     
      ) "<font color=red face=Calibri size=Small>Administration Costing</font>"    
 FROM AIMS_GUARANTOR X where GUARANTOR_ID = @GuarantorID    
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_MEDICAL_TREATMENT_ITEM_DEL]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENT_ITEM_DEL]  
	@InvoiceID 			varchar(50),
	@InvoiceTreatmentID		varchar(50)
as 
	BEGIN TRANSACTION DeleteMedicalTreatment

	DECLARE @MedicalTreatmentID int
	
	select @MedicalTreatmentID  =medical_treatment_id from AIMS_INVOICE_MEDICAL_TREATMENTS where  invoice_treatment_id = @InvoiceTreatmentID
	
	insert into aims_debugging values ('Step 1','@MedicalTreatmentID + ' + cast(@MedicalTreatmentID as varchar(50)), getdate())
	delete from AIMS_INVOICE_MEDICAL_TREATMENTS where  invoice_treatment_id = @InvoiceTreatmentID and invoice_id = @InvoiceID
	insert into aims_debugging values ('Step 1','@InvoiceTreatmentID + ' + cast(@InvoiceTreatmentID as varchar(50)), getdate())
	insert into aims_debugging values ('Step 1','@InvoiceID + ' + cast(@InvoiceID as varchar(50)), getdate())
	delete from aims_medical_treatment where medical_treatment_id = @MedicalTreatmentID

	if (@@ERROR <> 0)
	begin
		ROLLBACK TRANSACTION DeleteMedicalTreatment
	end
	else
	begin	
		COMMIT TRANSACTION DeleteMedicalTreatment
	end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_MEDICAL_TREATMENT_GET]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENT_GET]  
    @InvoiceID int
as 
	
	SELECT invoice_treatment_id, treatment_notes, service_description, d.supplier_name
	  FROM aims_invoice_medical_treatments a,
	       aims_medical_treatment b,
	       aims_service c,
	       aims_supplier d
	 WHERE a.invoice_id = @InvoiceID
	   AND b.medical_treatment_id = a.medical_treatment_id
	   AND c.service_id = b.service_id 
	  AND d.supplier_id = b.supplier_id
	
	--EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_MEDICAL_TREATMENT_DEL]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENT_DEL]  
	@InvoiceID 			int
as 
	BEGIN TRANSACTION addNotes

	DECLARE @LastError INT, @PatientID int, @RowCheck int
	SET @LastError = 0

	delete from  aims_medical_treatment where medical_treatment_id in (select medical_treatment_id from AIMS_INVOICE_MEDICAL_TREATMENTS where invoice_id = @InvoiceID)

	delete from AIMS_INVOICE_MEDICAL_TREATMENTS where invoice_id = @InvoiceID

	if (@@ERROR <> 0)
	begin
		insert into aims_debugging values ('Step 1','AIMS Note saving failed[' + CAST(@@ERROR as varchar(50)) + ']', getdate())
		ROLLBACK TRANSACTION addNotes
	end
	else
	begin	
		COMMIT TRANSACTION addNotes
	end
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_MEDICAL_TREATMENT_ADD]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENT_ADD]      
	@InvoiceID    int,    
	@MedicalTreatmentID   int output,    
	@ServiceRenderedID   int output,    
	@SupplierID    int output,     
	@MedicalTreatmentNotes  varchar(255),    
	@ServiceRenderedDesc  varchar(255),    
	@DateOfTreatmenmt  varchar(50)    
AS     
 BEGIN TRANSACTION addNotes    
    
	DECLARE @LastError INT, @PatientID int, @RowCheck int    
	SET @LastError = 0   
	 
	SELECT  @RowCheck = count(*)  from aims_supplier_types where supplier_type_desc = @ServiceRenderedDesc    
     
	IF @RowCheck > 0     
	BEGIN
		SELECT @ServiceRenderedID = supplier_type_id FROM aims_supplier_types WHERE supplier_type_desc = @ServiceRenderedDesc    
	END
	ELSE
	BEGIN
		insert into aims_supplier_types (supplier_type_desc) values (@ServiceRenderedDesc)    
		set @ServiceRenderedID = IDENT_CURRENT('aims_supplier_types')      
	END

	INSERT INTO aims_medical_treatment(    
		SUPPLIER_ID, SERVICE_ID, TREATMENT_NOTES, DATE_OF_TREATMENT)    
	Values( @SupplierID, @ServiceRenderedID, @MedicalTreatmentNotes, @DateOfTreatmenmt)      
        
	SET @MedicalTreatmentID = IDENT_CURRENT('aims_medical_treatment')    
     
	INSERT INTO AIMS_INVOICE_MEDICAL_TREATMENTS(    
		INVOICE_ID, MEDICAL_TREATMENT_ID,  SERVICE_ID ) 
	values( @InvoiceID,  @MedicalTreatmentID, @ServiceRenderedID)    
    
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION addNotes
END  
ELSE
BEGIN
	COMMIT TRANSACTION addNotes
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_SP_COST_LIMIT_INFO]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_SP_COST_LIMIT_INFO]  
    @PatientFileNo varchar(50) = '',  
    @InvoiceID varchar(50) = '',  
    @UserName varchar(50) = ''  
as     
 declare @vSQL  nvarchar(500)    
     
SELECT patient_file_no,  
 UPPER(a.Patient_Last_Name)+ ' ' + UPPER(PATIENT_FIRST_NAME) + ' '+ UPPER(a.PATIENT_INITIALS) + ' ' + UPPER(c.Title_desc)  AS PATIENT_NAME,      
       guarantor_name, patient_guarantor_amount, d.invoice_no, d.invoice_date,  
       d.invoice_amount_received,  
 (select user_full_name from aims_users where user_name = @UserName) CAPTURE_USER, g.SUPPLIER_TYPE_DESC ,  
 g.SUPPLIER_TYPE_ID,  
 h.cost_limit  
  FROM aims_patient a LEFT OUTER JOIN aims_guarantor b  
       ON a.guarantor_id = b.guarantor_id  
       LEFT OUTER JOIN aims_title c ON a.title_id = c.title_id  
       LEFT OUTER JOIN aims_invoice d ON a.patient_id = d.patient_id  
       left outer join AIMS_INVOICE_MEDICAL_TREATMENTS e on d.INVOICE_ID = e.INVOICE_ID   
       left outer join AIMS_MEDICAL_TREATMENT i on e.MEDICAL_TREATMENT_ID = i.MEDICAL_TREATMENT_ID 
       left outer join AIMS_SUPPLIER_TYPES g on i.SERVICE_ID  = g.SUPPLIER_TYPE_ID           
       left outer join AIMS_SERVICE_COST_LIMIT h on g.SUPPLIER_TYPE_ID = h.supplier_type_id  
 WHERE a.patient_file_no =  @PatientFileNo   
 and  d.invoice_id = @InvoiceID
GO
/****** Object:  View [dbo].[AIMS_PAYMENTS_VW]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AIMS_PAYMENTS_VW]
AS
select * from aims_payment
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PAYMENT_VERIFY]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PAYMENT_VERIFY]    
    @PaymentCheck   int output,  
    @PatientFileNo   varchar(50) = '',  
    @InvoiceNo    varchar(50)  ='',  
    @PaymentAmount   varchar(50) = ''  
as   
 declare @InvoiceReceivedAmount money,     @AmountPaidToDate   money  
   
 select  @InvoiceReceivedAmount =cast( invoice_amount_received as money) from aims_invoice where patient_id = (Select patient_id from aims_patient where patient_file_no = @PatientFileNo)  
insert into aims_debugging select 'Invoice Received Amount', @InvoiceReceivedAmount, getdate()
 --print 'DONE  11' + cast(@InvoiceReceivedAmount as varchar(500))    
  
 /*SELECT  @AmountPaidToDate = SUM (CAST (aims_payment.amount_paid AS money))   
             FROM aims_patient, aims_guarantor, aims_payment, aims_invoice  
           WHERE  aims_patient.patient_file_no = @PatientFileNo  
  and aims_patient.guarantor_id = aims_guarantor.guarantor_id  
              AND aims_payment.patient_id = aims_patient.patient_id  
              AND aims_invoice.patient_id = aims_payment.patient_id  
      and aims_invoice.invoice_no = @InvoiceNo  
              AND aims_payment.invoice_id = aims_invoice.invoice_id  */

 SELECT   @AmountPaidToDate = SUM (CAST (aims_payment.amount_paid AS money))   
             FROM aims_patient, aims_guarantor, aims_payment
           WHERE  aims_patient.patient_file_no =  @PatientFileNo
  and aims_patient.guarantor_id = aims_guarantor.guarantor_id  
              AND aims_payment.patient_id = aims_patient.patient_id  
            
  insert into aims_debugging select 'Amount Paid to date', @AmountPaidToDate, getdate()

 if @AmountPaidToDate + cast(@PaymentAmount as money) > @InvoiceReceivedAmount  
 begin  
  set @PaymentCheck = 1  
  print 'DONE  1'   + cast(@PaymentCheck as varchar(500))  
 end  
  
 if @AmountPaidToDate > @InvoiceReceivedAmount  
 begin  
  set @PaymentCheck = 1  
  print 'DONE  1'   + cast(@PaymentCheck as varchar(500))  
 end   
   
 print 'DONE  2'
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PAYMENT_RECEIPTNO_VERIFY]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_PAYMENT_RECEIPTNO_VERIFY]  
    @ReceiptNo 		varchar(50) = ''
as 
	SELECT *
	  FROM aims_payment a
	 WHERE a.receipt_no = @ReceiptNo
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_INVOICE_GET]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_INVOICE_GET]                  
 @InvoiceID varchar(50)                
as                 
 declare @vSQL  nvarchar(500)                
                 
 select                  
    ai.invoice_id,                   
    Patient_First_Name + ' ' + PAtient_last_name "Patient_Name",                 
    ap.patient_file_no,                   
    ap.PATIENT_ID,                
    asp.supplier_id,                
    asp.supplier_name,                   
    aps.service_description,                   
    ai.invoice_no,                   
    ai.invoice_date ,                   
    ai.INVOICE_AMOUNT_RECEIVED,                
    ai.LATE_INVOICE_YN,                
    ai.locked_yn,                 
    ai.Generated_yn,                
    amt.MEDICAL_TREATMENT_ID,                
    ap.PATIENT_FILE_ACTIVE_YN,                
    ass.supplier_type_id service_id,                
    ass.supplier_type_Desc service_description,            
    ai.CANCELLED_YN,          
    ai.doctor_owing,        
    ai.LATE_INVOICE_SENT,      
    asp.SUPPLIER_NAME ,    
    ai.LATE_INVOICE_SENT_DATE,    
    ai.INVOICE_SENT_WAYBILL_NO,  
    AIMS_GUARANTOR_ACCOUNT.ACCOUNT_NO,  
    AIMS_GUARANTOR_ACCOUNT.GUARANTOR_ACCOUNT_ID  
   from                   
   aims_invoice as ai                   
   left outer join aims_patient     as ap  on ap.patient_id   = ai.patient_id                  
   left outer join AIMS_INVOICE_MEDICAL_TREATMENTS  as aimt on aimt.invoice_id   = ai.invoice_id                
   left outer join aims_medical_treatment   as amt on amt.medical_treatment_id  = aimt.medical_treatment_id                    
   left outer join aims_supplier    as asp on asp.supplier_id  = amt.supplier_id                  
   left outer join aims_prof_service   as aps on aps.service_id   = amt.service_id                  
   left outer join aims_title    as att on att.title_id   = ap.title_id                
   --left outer join aims_service    as ass  on ass.service_id   = amt.service_id                
   left outer join aims_supplier_types    as ass  on ass.supplier_type_id   = amt.service_id                
   left outer join AIMS_GUARANTOR_ACCOUNT  on AIMS_GUARANTOR_ACCOUNT.GUARANTOR_ACCOUNT_ID   = ai.GUARANTOR_ACCOUNT_ID  
   where  ai.invoice_id =  cast(@InvoiceID as varchar(50))     
       
       
   ----------------------------------------------------------    
   ----------------------------------------------------------
GO
/****** Object:  StoredProcedure [dbo].[AIMS_PATIENT_ADD]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_PATIENT_ADD]                                                
   @PatientFileNo varchar(50) = '' output,                                              
   @PatientInitials varchar(50) = '',                                              
   @PatientFirstName varchar(50) = '',                                              
   @PatientMiddleName varchar(50) = '',                                              
   @PatientLastName varchar(50) = '',                                              
   @PatientIDNo varchar(50) = '',                                              
   @PatientCompanyID int  = null,                                              
   @PatientTitleID int = null,                                              
   @PatientHomeTelNo varchar(50) = '',                                              
   @PatientWorkTelNo varchar(50) = '',                                              
   @PatientFaxNo varchar(50) = '',                                              
   @PatientMobileNo varchar(50) = '',                                              
   @PatientEmailAddress varchar(50) = '',                                              
   @PatientGuarantorID int = null,                                              
   @PatientGuarantorRefNo  varchar(50) = '',                                              
   @PatientFileActiveYN varchar(50) = '',                                              
   @AddressTypeID int = null,                                              
   @Address1 varchar(50) = '',                                               
   @Address2 varchar(50) = '',                                               
   @Address3 varchar(50) = '',                                              
   @Address4 varchar(50) = '',                                              
   @Address5 varchar(50) = '',                                               
   @PostalCode varchar(30) = '',                                               
   @CountryID int = null,                                              
   @UserSignedOn varchar(50) = '',                                              
   @PatientNationality varchar(50) = '',                                              
   @GuarantorAmount varchar(50) = '',                                              
   @SupplierID int = null,                                              
   @PatientFileCourierYN varchar(1) = '',                                              
   @PatientAdmissionDate varchar(50) = '',                                              
   @PatientDischargeDate varchar(50) = '',                                              
   @PatientDiagnosis varchar(255) = '',                                              
   @PatientEmergencyContactName varchar(255) = '',                                              
   @PatientEmergencyContactNo varchar(255) = '',                                            
   @InPatient  varchar(1) = '',                                            
   @OutPatient  varchar(1) = '',                                            
   @Assist  varchar(1) = '',                                          
   @Repat varchar(1) = '',                                          
   @Flight varchar(1) = '',                                          
   @Cancellation varchar(1) = '',                                      
   @CourierWayBillNo varchar(255) = '',                                      
   @TransportYN varchar(1) = '',                                      
   @Guarantor247No varchar(255) = '',                                      
   @Guarantor247Email varchar(255) = '',                                      
   @CourierReceiptDate varchar(50) = '',                                      
   @FileAdministrator varchar(255) = '',                                      
   @AssistanceType  varchar(255) = '',                                      
   @TransportType varchar(255) = '',                                
   @FileCourierDate varchar(255) = '',                              
   @LateLogYN varchar(1) = '',                             
   @LateLogDate varchar(10)= '',                          
@Pending  varchar(1) = '',                    
   @RepatType  varchar(255) = '',                    
   @EvacuationType  varchar(255) = '',                  
   @FileOperator varchar(255) = '',                  
   @RMR  varchar(50) = '',                  
   @RMRType varchar(50) = '',                
   @PatientFlightGuarantorID int = null,                
   @DateOfBirth varchar(50) = '',                
   @LabListDate varchar(50) = '',                                   
   @AfterHoursFile varchar(50) = '',        
   @SentToAdmin varchar(1) = '' , 
   @HighCost        varchar(1) = '' 
AS                                            
 BEGIN TRANSACTION addPatient                                        
                                              
 DECLARE @LastError INT, @PatientAddressID int, @PatientID int , @PendDate datetime, @PatientFileCounter INT, @fileID VARCHAR(50)                                      
 SET @LastError = 0                                              
 IF (@PatientInitials IS NULL)                                            
 BEGIN                                          
  SET @PatientInitials = ''                                            
 END                                            
                                            
 IF (@PatientFirstName IS NULL)                                            
 BEGIN                                            
  SET @PatientFirstName = ''                                            
 END                                            
                                            
 IF (@PatientLastName IS NULL)                                            
 BEGIN                                            
  SET @PatientLastName = ''                                            
 END                                            
                                            
 IF (@PatientTitleID IS NULL)                                            
 BEGIN                                            
  SET @PatientTitleID = 10                                         
 END                                            
                                            
 IF (@PatientTitleID <= 0)                                            
 BEGIN                                            
  SET @PatientTitleID = 10                                            
 END                                            
                                            
 IF (@PatientCompanyID IS NULL)                                            
 BEGIN                                       
  SET @PatientCompanyID = 5                                            
 END                                            
                                            
 IF (@PatientCompanyID <= 0)                                            
 BEGIN                                            
  SET @PatientCompanyID = 5                                
 END                                            
                                   
 IF (@SupplierID IS NULL)                                  
 BEGIN                                  
 SELECT @SupplierID = Supplier_ID from AIMS_SUPPLIER where SUPPLIER_NAME = ''                                  
 END                                  
                  
 if (@Pending = 'Y')                                            
 begin                                            
  SET @PendDate  = GETDATE()                                            
 end                                            
 else                                            
 begin                                            
  SET @PendDate = NULL                                            
 end                                               
                                             
 if @PatientFileNo is null                                              
 begin                                              
  --if @Address1 <> '' and  @Address2 <> '' and @Address3 <> '' -- and @Address4 <> '' and @CountryID <> ''                                              
  --begin                                              
                                               
   /* ADDRESS_ID  - Indentity Column */                                               insert into aims_address                                              
    (ADDRESS_TYPE_ID,                                              
    ADDRESS1, ADDRESS2,                                              
    ADDRESS3, ADDRESS4,                      
    ADDRESS5, POSTAL_CODE,                                              
    COUNTRY_ID, DEFAULT_YN , ACTIVE_YN) Values                                               
        (@AddressTypeID, @Address1 ,                                               
   @Address2 , @Address3 ,                   
         @Address4 , @Address5,                                               
         @PostalCode,@CountryID, 'Y', 'Y')                                              
                                                
   if (@@ERROR <> 0)                                               
   begin                        
                            
    SET @LastError = @@ERROR                                              
    ROLLBACK TRANSACTION                                              
    Return (-1)                                                 
   end                                                 
   set @PatientAddressID = IDENT_CURRENT('AIMS_ADDRESS')                                              
  --end                                               
                                                 
 IF  @PatientLastName <> '' and @PatientGuarantorID <> 0                                              
 BEGIN                                             
  /* PATIENT_ID  - Indentity Column */                                              
  insert into aims_patient                                              
  (                                    
  PATIENT_FILE_NO,                                       
  PATIENT_INITIALS,                                              
  PATIENT_FIRST_NAME,                                       
  PATIENT_MIDDLE_NAME,                                              
  PATIENT_LAST_NAME,                                       
  PATIENT_ID_NO,                                       
  COMPANY_ID,                                              
  TITLE_ID, ADDRESS_ID, PATIENT_HOME_TEL_NO, PATIENT_WORK_TEL_NO,                                              
  PATIENT_FAX_NO, PATIENT_MOBILE_NO,                                              
  PATIENT_EMAIL_ADDRESS, GUARANTOR_ID,                                              
  GUARANTOR_REF_NO, PATIENT_FILE_ACTIVE_YN, PATIENT_NATIONALITY,                                               
  PATIENT_GUARANTOR_AMOUNT,                                              
  SUPPLIER_ID,                                                
  PATIENT_FILE_COURIER_YN,                                               
  PATIENT_ADMISSION_DATE,                                              
  PATIENT_DISCHARGE_DATE,                                               
  PATIENT_DIAGNOSIS,                                     
  CREATION_DTTM,                                     
  PATIENT_EMERGENCY_CONTACT_NAME,                                     
  PATIENT_EMERGENCY_CONTACT_NO,                                     
  IN_PATIENT,                                     
  OUT_PATIENT,                                     
  ASSIST,                                     
  FILE_COURIER_DATE,                                     
  FLIGHT ,                                     
  REPAT ,                                     
  CANCELLED,                                    
  COURIER_WAYBILL_NO,                                      
  TRANSPORT,                                      
  GUARANTOR247NO,                                      
  GUARANTOR247EMAIL,                                      
  FILE_ASSIGNED_TO_USERID,                                      
  COURIER_RECEIPT_DATE,                                      
  PATIENT_ASSIST_TYPE_ID,                                      
  PATIENT_TRANSPORT_TYPE_ID,                              
  LATE_LOG_YN,                              
  LATE_LOG_DATE,                          
  PENDING,                        
  PEND_DATE,                    
  PATIENT_REPAT_TYPE_ID,                    
  PATIENT_EVACUATION_TYPE_ID,                  
  FILE_OPERATOR_TO_USERID,RMR, PATIENT_RMR_TYPE_ID, FLIGHT_GUARANTOR_ID, PATIENT_DATE_OF_BIRTH, LAB_LIST_DATE, AFTER_HOURS_FILE, SENT_TO_ADMIN, HIGH_COST)                                     
  Values(                                              
   '',                                  
   @PatientInitials,             
   @PatientFirstName,                                      
   @PatientMiddleName,                                               
   @PatientLastName,                                     
   @PatientIDNo,                                     
   @PatientCompanyID,                                              
   @PatientTitleID,                                     
   @PatientAddressID,                                              
   @PatientHomeTelNo,                                     
   @PatientWorkTelNo ,                                              
   @PatientFaxNo,                                     
   @PatientMobileNo,                                              
   @PatientEmailAddress,                                     
   @PatientGuarantorID,                                              
   cast(@PatientGuarantorRefNo as varchar(50)),                                     
   @PatientFileActiveYN,                           
   @PatientNationality,                                               
   @GuarantorAmount,                                              
   @SupplierID,                                               
   @PatientFileCourierYN ,                                               
   @PatientAdmissionDate ,                                              
   @PatientDischargeDate ,                                               
   @PatientDiagnosis,                                     
   GETDATE(),                                     
   @PatientEmergencyContactName ,                                    
   @PatientEmergencyContactNo,                                     
   @InPatient,                                     
   @OutPatient,                                     
   @Assist,                                     
   CONVERT (datetime,@FileCourierDate,103),                              
   @Repat,                              
   @Flight,                                     
   @Cancellation,                                     
   @CourierWayBillNo ,                                   
   @TransportYN ,                                    
   @Guarantor247No ,                                    
   @Guarantor247Email ,                                    
   @FileAdministrator ,                                      
   convert(smalldatetime,@CourierReceiptDate, 103),                                     
   @AssistanceType ,                                    
   @TransportType,                              
   @LateLogYN,                              
   CONVERT (datetime,@LateLogDate,103),                          
   @PENDING,                        
   @PendDate, @RepatType, @EvacuationType,                  
   @FileOperator, @RMR, @RMRType, @PatientFlightGuarantorID, @DateOfBirth, CONVERT (datetime,@LabListDate,103), @AfterHoursFile, @SentToAdmin, @HighCost)                                   
 /**/                                              
 IF (@@ERROR <> 0)                                               
 BEGIN                                    
  SET @LastError = @@ERROR                                              
                          
  ROLLBACK TRANSACTION                                              
  Return (-1)                                              
   END                                              
   ELSE                                 
   BEGIN                                          
  --select @PatientFileNo =  CAST(YEAR(GETDATE()) AS VARCHAR(10)) + '/' + CAST(IDENT_CURRENT('AIMS_PATIENT')  AS VARCHAR(10))                                          
  --2013/12/31 select @PatientFileNo =  CAST(Substring(CONVERT(varchar(30),(YEAR(getdate()))),3,2) AS VARCHAR(50)) + '/' + CAST(IDENT_CURRENT('AIMS_PATIENT')  AS VARCHAR(10))                                              
 INSERT INTO PATIENT_FILE_COUNTER VALUES(CAST(Substring(CONVERT(varchar(30),(YEAR(getdate()))),3,2) AS VARCHAR(50)))      
       
 SET @PatientFileCounter  = IDENT_CURRENT('PATIENT_FILE_COUNTER')      
       
 IF LEN(@PatientFileCounter) = 1 begin set @fileID = '000' + cast(@PatientFileCounter as varchar) end      
 IF LEN(@PatientFileCounter) = 2 begin set @fileID = '00' + cast(@PatientFileCounter as varchar) end       
 IF LEN(@PatientFileCounter) = 3 begin set @fileID = '0' + cast(@PatientFileCounter as varchar) end       
 IF LEN(@PatientFileCounter) = 4 begin set @fileID = cast(@PatientFileCounter as varchar) end         
 IF LEN(@PatientFileCounter) = 5 begin set @fileID = cast(@PatientFileCounter as varchar) end        
      
 SET @PatientFileNo = CAST(Substring(CONVERT(varchar(30),(YEAR(getdate()))),3,2) AS VARCHAR(50)) +'/'+cast(@fileID as varchar)      
                                 
  update AIMS_PATIENT set PATIENT_FILE_NO = @PatientFileNo                                              
  where PATIENT_ID = IDENT_CURRENT('AIMS_PATIENT')                                              
                                                  
  /* PATIENT INFORMATION AUDIT */                                              
  insert into AIMS_A_PATIENT                                              
  Values(                                       
     @UserSignedOn,                                              
     'ADD',                                              
     GETDATE(),                                              
     IDENT_CURRENT('AIMS_PATIENT'),                                              
     @PatientFileNo,                                              
     @PatientInitials,                                                
     @PatientFirstName,                                        
     @PatientMiddleName,                                               
     @PatientLastName,                                       
     @PatientIDNo,                                       
     @PatientCompanyID,                                              
     @PatientTitleID,                                       
     @PatientAddressID,                                       
     @PatientHomeTelNo,                                       
     @PatientWorkTelNo ,                                              
     @PatientFaxNo,                                       
     @PatientMobileNo,                                              
     @PatientEmailAddress,                                       
     @PatientGuarantorID,                                              
     cast(@PatientGuarantorRefNo as varchar(50)),                                       
     @PatientFileActiveYN,                                      
     @PatientNationality,                                              
     @GuarantorAmount,                                              
     @SupplierID,                                               
     @PatientFileCourierYN ,                                               
     @PatientAdmissionDate ,                                              
     @PatientDischargeDate ,                                               
     @PatientDiagnosis,                                       
     getdate(),                                       
     @PatientEmergencyContactName ,                                      
     @PatientEmergencyContactNo,                                       
     @InPatient,@OutPatient,                                       
     @Assist,                 
     cONVERT (datetime,@FileCourierDate,103),                                        
     @Flight,                                       
     @Repat ,                                       
     @Cancellation,                                      
     @CourierWayBillNo ,                                     
     @TransportYN ,                                    
     @Guarantor247No ,                                    
     @Guarantor247Email ,                             
     @FileAdministrator ,                                    
     convert(smalldatetime,@CourierReceiptDate, 103) ,                          
     @AssistanceType ,                                    
     @TransportType,                              
     @LateLogYN,                              
     CONVERT (datetime,@LateLogDate,103),                          
     @Pending,                        
     @PendDate,@EvacuationType, @RepatType, @FileOperator, @RMR, @RMRType,                 
     @PatientFlightGuarantorID,                
     @DateOfBirth,  CONVERT (datetime,@LabListDate,103), @AfterHoursFile, @SentToAdmin, @HighCost)                                              
                                                  
  /* Start populating the aims_notes and aims_trace tables */             
                                             
  /* TRACE_ID - Identity Column */                                              
  insert into AIMS_TRACE(                                              
  PATIENT_FILE_NO,                                              
  DATE_TIME,                                              
  USER_NAME,                                              
  DESCRIPTION,                                              
  COMMENTS,                                              
  PATIENT_ID) values(                                              
          @PatientFileNo,                                               
          GETDATE(),                                              
          @UserSignedOn,                                              
          'Load Patient',                                              
          'New File for Patient',                                
          IDENT_CURRENT('AIMS_PATIENT'))                                              
                                                  
    /* If Insert to the trace table failed then exit*/                                                  
    if (@@ERROR <> 0)                            
    begin                                              
     ROLLBACK TRANSACTION addPatient                                              
     RETURN -1                                              
    end                                              
                                               
    /* If Insert to the NOTES table failed then exit*/                                              
                                               
    /* NOTE_ID - Identity Column */                                              
    insert into AIMS_NOTES(                                              
  USER_NAME,                                              
  NOTES,                                              
  NOTES_DTTM,                                              
  PATIENT_ID) values(                                              
          @UserSignedOn,                                              
          'New File for Patient',                                              
          GETDATE(),                                              
          IDENT_CURRENT('AIMS_PATIENT'))                                    
                                       
    /* If Insert to the trace table failed then exit*/                                                  
    if (@@ERROR <> 0)                                              
    begin                                              
                          
     ROLLBACK TRANSACTION addPatient                                              
     RETURN -1                                       
    end                                                 
   end                                              
  end                                              
                                                
  if (@@ERROR <> 0)                                              
  begin                                              
   ROLLBACK TRANSACTION addPatient                                              
  end                                              
  else                                         
  begin                                               
   COMMIT TRANSACTION addPatient                                              
  end                                              
 end                                       
 else                                              
 begin                                              
                                    
 SELECT @PatientID = patient_id from aims_patient where patient_file_no = @PatientFileNo                                              
 SELECT  @PatientAddressID = ADDRESS_ID from aims_patient where Patient_File_no = @PatientFileNo                                              
                                     
                        
    IF @PatientAddressID IS NULL                                    
 BEGIN                                        
 INSERT INTO aims_address                                              
  (ADDRESS_TYPE_ID,                                              
  ADDRESS1, ADDRESS2,                           
  ADDRESS3, ADDRESS4,                                              
  ADDRESS5, POSTAL_CODE,                                              
  COUNTRY_ID, DEFAULT_YN , ACTIVE_YN) Values                                               
   (@AddressTypeID, @Address1 ,                                               
    @Address2 , @Address3 ,                                              
    @Address4 , @Address5,                                               
    @PostalCode,@CountryID, 'Y', 'Y')                                      
                                    
  SET @PatientAddressID = IDENT_CURRENT('AIMS_ADDRESS')                                              
    END                                    
    ELSE                                    
    BEGIN                                            
  UPDATE aims_address                                              
  SET                                    
    ADDRESS_TYPE_ID = @AddressTypeID,                                                
    ADDRESS1 = @Address1 ,                                              
    ADDRESS2 = @Address2 ,                                              
    ADDRESS3 = @Address3 ,                                              
    ADDRESS4 = @Address4 ,                                              
    ADDRESS5 = @Address5 ,                                              
    POSTAL_CODE = @PostalCode ,                                              
    COUNTRY_ID = @CountryID ,                                              
    DEFAULT_YN = 'Y' ,                                              
    ACTIVE_YN = 'Y'                
  WHERE                                     
  ADDRESS_ID  = @PatientAddressID                                              
 END                                    
                                                     
                                     
 UPDATE aims_patient                                              
 SET                                    
  PATIENT_INITIALS = @PatientInitials,                                              
  PATIENT_FIRST_NAME = @PatientFirstName,                                              
  PATIENT_MIDDLE_NAME = @PatientMiddleName,                                              
  PATIENT_LAST_NAME =  @PatientLastName,                                              
  PATIENT_ID_NO =  @PatientIDNo,                                              
  COMPANY_ID = @PatientCompanyID,                
  TITLE_ID =  @PatientTitleID,                                              
  ADDRESS_ID = @PatientAddressID,                                              
  PATIENT_HOME_TEL_NO = @PatientHomeTelNo,                                              
  PATIENT_WORK_TEL_NO = @PatientWorkTelNo,                                              
  PATIENT_FAX_NO = @PatientFaxNo,                                              
  PATIENT_MOBILE_NO = @PatientMobileNo,                                              
  PATIENT_EMAIL_ADDRESS = @PatientEmailAddress,                                              
  GUARANTOR_ID = @PatientGuarantorID,                                              
  GUARANTOR_REF_NO = @PatientGuarantorRefNo,                                              
  PATIENT_FILE_ACTIVE_YN = @PatientFileActiveYN,                        
  PATIENT_NATIONALITY = @PatientNationality,                                              
  PATIENT_GUARANTOR_AMOUNT = @GuarantorAmount ,                                              
  SUPPLIER_ID  = @SupplierID ,                
  PATIENT_FILE_COURIER_YN  = @PatientFileCourierYN,                                              
  PATIENT_ADMISSION_DATE = @PatientAdmissionDate,                                              
  PATIENT_DISCHARGE_DATE = @PatientDischargeDate,                                              
  PATIENT_DIAGNOSIS = @PatientDiagnosis,                                              
  PATIENT_EMERGENCY_CONTACT_NAME= @PatientEmergencyContactName,                                              
  PATIENT_EMERGENCY_CONTACT_NO = @PatientEmergencyContactNo,                                            
  IN_PATIENT = @InPatient,              
  OUT_PATIENT = @OutPatient,                                            
  ASSIST = @Assist,                                            
  FILE_COURIER_DATE = cONVERT (datetime,@FileCourierDate,103),                                        
  REPAT = @Repat,                                CANCELLED = @Cancellation,                                          
  FLIGHT = @Flight,                                      
  COURIER_WAYBILL_NO = @CourierWayBillNo ,                                      
  TRANSPORT = @TransportYN ,                                      
  GUARANTOR247NO = @Guarantor247No ,                                      
  GUARANTOR247EMAIL = @Guarantor247Email ,                                      
  FILE_ASSIGNED_TO_USERID = @FileAdministrator ,                                  
  COURIER_RECEIPT_DATE = convert(smalldatetime,@CourierReceiptDate, 103),                                      
  PATIENT_ASSIST_TYPE_ID = @AssistanceType ,                                      
  PATIENT_TRANSPORT_TYPE_ID = @TransportType,                              
  LATE_LOG_YN = @LateLogYN ,                              
  LATE_LOG_DATE = CONVERT (datetime,@LateLogDate,103),                          
  PENDING = @Pending ,                        
  PEND_DATE = @PendDate,                    
  PATIENT_REPAT_TYPE_ID = @RepatType,                    
  PATIENT_EVACUATION_TYPE_ID = @EvacuationType ,                  
  FILE_OPERATOR_TO_USERID = @FileOperator ,                  
  RMR = @RMR, PATIENT_RMR_TYPE_ID = @RMRType,                 
  FLIGHT_GUARANTOR_ID = @PatientFlightGuarantorID,                
  PATIENT_DATE_OF_BIRTH = @DateOfBirth,                
  LAB_LIST_DATE = CONVERT(datetime,@LabListDate,103),          
  AFTER_HOURS_FILE = @AfterHoursFile,        
  SENT_TO_ADMIN = @SentToAdmin,
  HIGH_COST = @HighCost                                     
 where                                     
  PATIENT_ID =  @PatientID                                                
                                              
 /* PATIENT INFORMATION AUDIT */                                              
 INSERT INTO AIMS_A_PATIENT                                              
 VALUES(                                       
   @UserSignedOn,                                              
   'UPDATE',        
   GETDATE(),                                              
   @PatientID,                                              
   @PatientFileNo,                                              
   @PatientInitials,                                                
   @PatientFirstName,                                        
   @PatientMiddleName,                                               
   @PatientLastName,                                       
   @PatientIDNo,                                       
   @PatientCompanyID,             
   @PatientTitleID,                                       
   @PatientAddressID,                                       
   @PatientHomeTelNo,                                       
   @PatientWorkTelNo ,                                              
   @PatientFaxNo,                                       
   @PatientMobileNo,                                              
   @PatientEmailAddress,                       
   @PatientGuarantorID,                                              
   cast(@PatientGuarantorRefNo as varchar(50)),                                       
   @PatientFileActiveYN,                                      
   @PatientNationality,                                              
   @GuarantorAmount,                                              
   @SupplierID,                                               
   @PatientFileCourierYN ,                                               
   @PatientAdmissionDate ,                                              
   @PatientDischargeDate ,                                               
   @PatientDiagnosis,getdate(),                                               
   @PatientEmergencyContactName,                                              
   @PatientEmergencyContactNo,                                       
   @InPatient,                                       
   @OutPatient,                                      
   @Assist,                              
   CONVERT (datetime,@FileCourierDate,103),                                 
   @Flight,                                      
   @Repat,                                      
   @Cancellation, '', '', '', '', '', '', '', '',                   
   @LateLogYN, CONVERT (datetime,@LateLogDate,103), @Pending, @PendDate, @EvacuationType, @RepatType,                   
   @FileOperator, @RMR, @RMRType, @PatientFlightGuarantorID, @DateOfBirth, CONVERT(datetime,@LabListDate,103), @AfterHoursFile, @SentToAdmin, @HighCost)                                              
            
             
 IF (@FileOperator is not null)             
 BEGIN              
  IF (@FileOperator <> '')            
  BEGIN            
   DECLARE Operator_Mail Cursor            
   FOR             
    SELECT b.PATIENT_ENQUIRY_ID FROM AIMS_EWS_PATIENT_ENQUIRY a             
     INNER JOIN AIMS_EWS_OPERATOR_MAILS b ON b.PATIENT_ENQUIRY_ID = a.PATIENT_ENQUIRY_ID            
    WHERE a.PATIENT_ID = @PatientID AND b.WORK_ITEM_PROCESSED_YN = 'N'            
            
    Open Operator_Mail            
     DECLARE @PatientMailEnquiryID varchar(30)            
            
     Fetch NEXT FROM Operator_Mail INTO @PatientMailEnquiryID            
     While (@@FETCH_STATUS <> -1)            
     BEGIN            
      IF (@@FETCH_STATUS <> -2)            
      BEGIN            
       IF(@PatientMailEnquiryID <> '')            
       BEGIN            
        UPDATE AIMS_EWS_OPERATOR_MAILS SET            
         OPERATOR_MAILBOX_ID =             
          (SELECT a.OPERATOR_MAILBOX_ID FROM AIMS_EWS_OPERATOR_MAILBOX a             
           WHERE a.OPERATOR_MAILBOX_USER_NAME = @FileOperator)            
         WHERE PATIENT_ENQUIRY_ID = @PatientMailEnquiryID            
       END            
      END            
     FETCH NEXT FROM Operator_Mail INTO @PatientMailEnquiryID            
     END            
    CLOSE Operator_Mail            
    DEALLOCATE Operator_Mail            
  END            
 END            
  
SET @PatientMailEnquiryID = ''  
  
IF (@FileAdministrator is not null)             
 BEGIN              
  IF (@FileAdministrator <> '')            
  BEGIN            
   DECLARE Admin_Mail Cursor            
   FOR             
    SELECT b.PATIENT_ENQUIRY_ID FROM AIMS_EWS_PATIENT_ENQUIRY a             
     INNER JOIN AIMS_EWS_ADMIN_MAILS b ON b.PATIENT_ENQUIRY_ID = a.PATIENT_ENQUIRY_ID            
    WHERE a.PATIENT_ID = @PatientID AND b.WORK_ITEM_PROCESSED_YN = 'N'            
            
    Open Admin_Mail            
     --DECLARE @PatientMailEnquiryID varchar(30)            
            
     Fetch NEXT FROM Admin_Mail INTO @PatientMailEnquiryID            
     While (@@FETCH_STATUS <> -1)            
     BEGIN            
      IF (@@FETCH_STATUS <> -2)            
      BEGIN            
       IF(@PatientMailEnquiryID <> '')            
       BEGIN            
        UPDATE AIMS_EWS_ADMIN_MAILS SET            
         OPERATOR_MAILBOX_ID =             
          (SELECT a.OPERATOR_MAILBOX_ID FROM AIMS_EWS_ADMIN_MAILBOX a             
           WHERE a.OPERATOR_MAILBOX_USER_NAME = @FileAdministrator)            
         WHERE PATIENT_ENQUIRY_ID = @PatientMailEnquiryID            
       END            
      END            
     FETCH NEXT FROM Admin_Mail INTO @PatientMailEnquiryID            
     END            
    CLOSE Admin_Mail            
    DEALLOCATE Admin_Mail            
  END            
 END         
    
                                 
 IF (@@ERROR <> 0)                                              
 BEGIN            
  ROLLBACK TRANSACTION addPatient            
  BEGIN  TRANSACTION addPatient1            
   INSERT INTO AIMS_DEBUGGING            
   VALUES('Patient File Email Failure','Patient File Rolled Back', GETDATE())              
  COMMIT TRANSACTION addPatient1                                           
 END                        
 ELSE            
 BEGIN            
  COMMIT TRANSACTION addPatient                                              
 END                                            
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_MEDICAL_TREATMENT_GET_ALL]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AIMS_MEDICAL_TREATMENT_GET_ALL]  
	@PatientFileNo  varchar(50)
as 
	declare @vSQL  nvarchar(500)
 
	/*set @vSQL = 'SELECT * ' +
			  ' FROM aims_medical_treatment a, aims_invoice b  ' +
			 ' WHERE b.invoice_id = '+ cast(@InvoiceID as varchar(50)) +' AND a.medical_treatment_id = b.medical_treatment_id '*/


	/* SELECT b.invoice_no, a.treatment_notes, c.supplier_name, a.date_of_treatment
	FROM aims_medical_treatment a, aims_invoice b, aims_supplier c , aims_patient d
	WHERE 	d.patient_file_no = cast(@PatientFileNo as varchar(50)) and  b.patient_id = d.patient_id AND a.medical_treatment_id = b.medical_treatment_id
		and c.supplier_id = a.supplier_id */
	
	SELECT b.invoice_no, a.treatment_notes, c.supplier_name, a.date_of_treatment
	  FROM aims_medical_treatment a,
	       aims_invoice b,
	       aims_supplier c,
	       aims_patient d,
	       AIMS_INVOICE_MEDICAL_TREATMENTS e
	 WHERE d.patient_file_no = @PatientFileNo
	   and b.patient_id = d.patient_id
	   and e.invoice_id = b.invoice_id
	   and a.medical_treatment_id = e.medical_treatment_id
	   and c.supplier_id = a.supplier_id


	-- EXECUTE  sp_executesql  @vSQL
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_ADD1]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from AIMS_DEBUGGING order by 1 desc

--delete from AIMS_DEBUGGING 

--sp_helptext [AIMS_INVOICE_ADD]

CREATE procedure  [dbo].[AIMS_INVOICE_ADD1]                        
  @InvoiceID    int output,        
  @InvoiceNo    varchar(50) = '',        
  @PatientFileNo   varchar(50) = '',        
  @InvoiceDate   varchar(50) = '',        
  @InvoiceAmountReceived varchar(50) = '',        
  @InvoiceGeneratedYN varchar(1)  = '',        
  @InvoiceLockedYN  varchar(1)  = '',        
  @InvoiceLateYN   varchar(1)  = '',        
  @UserSignedOn   varchar(50) = '',        
  @SupplierID   varchar(50) = '',        
  @ServiceID    varchar(50) = '',        
  @InvoiceCancelledYN varchar(1)  = '',        
  @DoctorOwing   varchar(1)  = '',        
  @LateInvoiceSent  varchar(1)  = '' ,      
  @LateInvoiceSentDate varchar(50) = '',      
  @InvoiceSentWaybillNo varchar(50) = '',    
  @GuarantorAccountId varchar(50) = ''    
AS        
BEGIN TRANSACTION addInvoice              
        
 DECLARE         
  @LastError INT,             
  @vSQL varchar(4000),             
  @PatientID int,             
  @ServiceDesc varchar(255),             
  @MedicalTreatmentID int,             
  @TreatmentDate varchar(50),             
  @InvoiceCreationDTTM DateTime,          
  @RowCheck int,        
  @OldInvoiceID int         

insert into aims_debugging   values ('3333','4444',GETDATE())

if (@GuarantorAccountId is null)
begin
	set @GuarantorAccountId = 0
end

if (@GuarantorAccountId = '')
begin
	set @GuarantorAccountId = 0
end
        
 -- Get Patient ID from patient file          
 SELECT @PatientID = PATIENT_ID  FROM aims_patient WHERE patient_file_no = @PatientFileNo                      
         
 -- Get Supplier Type Description from service-id              
 SELECT @ServiceDesc = supplier_type_desc FROM aims_supplier_types WHERE supplier_type_id = @ServiceID                      
         
 -- Get Treatment date        
 SET @TreatmentDate = CAST(GETDATE() AS VARCHAR(50))                      
        
 -- If invoice no not passed, i.e. adding a new invoice, set the invoice to NULL, for simplying evaluation on condition check        
 IF ( @InvoiceID = 0)                      
 BEGIN                      
  SET @InvoiceID = NULL                      
 END                      
        
 PRINT 'INVOICE CANCELLED - xxxx' + @InvoiceCancelledYN         
 PRINT 'UPDATE INVOICE DETAILS [PATIENT-DETAILS :'+ CAST(@patientid AS VARCHAR(50))+'] INVOICE NO: ' + CAST(@InvoiceNo AS VARCHAR(50))        
         
 -- If we are cancelling this invoice, Delete all medical invoices linked to and treatments linked to this invoice and patient        
 IF (@InvoiceCancelledYN = 'Y')        
 BEGIN        
  PRINT 'CANCELLING MEDICAL TREATMENT LINKED TO ' + CAST(@MedicalTreatmentID AS VARCHAR(50))         
  SELECT @MedicalTreatmentID = Medical_Treatment_ID        
    FROM aims_invoice_medical_treatments        
   WHERE invoice_id = (SELECT invoice_id        
          FROM aims_invoice        
         WHERE invoice_no = @InvoiceNo AND patient_id = @PatientID)          
        
  DELETE FROM AIMS_INVOICE_MEDICAL_TREATMENTS WHERE MEDICAL_TREATMENT_ID  = @MedicalTreatmentID        
  DELETE FROM aims_medical_treatment WHERE MEDICAL_TREATMENT_ID = @MedicalTreatmentID          
 END        
         
 IF @InvoiceID is null                       
 BEGIN        
  -- check if this invoice number is not linked to another file and also active in the file        
  -- if this is already linked to another, INSERT a new etry into INVOICE for the this file        
  SELECT @RowCheck = COUNT(*) FROM AIMS_INVOICE WHERE INVOICE_NO = @InvoiceNo and CANCELLED_YN ='N' and PATIENT_ID != @patientid        
          
  PRINT 'Adding new invoice, is this invoice already linked to another active file: ' + CAST(@RowCheck AS VARCHAR(50))        
          
  IF @RowCheck > 0        
  BEGIN        
   PRINT 'Just to double-check, Check if this invoice was not already linked to another file in a cancelled state'        
   SELECT @RowCheck = COUNT(*) FROM AIMS_INVOICE WHERE INVOICE_NO = @InvoiceNo and PATIENT_ID = @patientid        
   IF(@RowCheck > 0)        
   BEGIN        
    -- Get the Old Invoice-ID Linked to this Invoice-No        
    SELECT @OldInvoiceID = INVOICE_ID FROM AIMS_INVOICE WHERE INVOICE_NO = @InvoiceNo AND PATIENT_ID = @patientid        
          
    PRINT 'Invoice-No was already linked to this file but in a cancelled state - ' + cast(@OldInvoiceID as varchar(50))        
            
    UPDATE aims_invoice        
       SET invoice_no = @invoiceno,        
        patient_id = @patientid,        
        invoice_date = @invoicedate,        
        invoice_amount_received = @invoiceamountreceived,        
        generated_yn = @invoicegeneratedyn,        
        locked_yn = @invoicelockedyn,        
        late_invoice_yn = @invoicelateyn,        
        cancelled_yn = @invoicecancelledyn,        
        doctor_owing = @doctorowing,        
        late_invoice_sent = @lateinvoicesent,      
        late_invoice_sent_date = @LateInvoiceSentDate,      
        INVOICE_SENT_WAYBILL_NO = @InvoiceSentWaybillNo,    
        GUARANTOR_ACCOUNT_ID = @GuarantorAccountId      
    WHERE invoice_id = @OldInvoiceID        
            
    SELECT @InvoiceID = @OldInvoiceID        
    PRINT 'Invoice Details Updated: ' + cast(@@ROWCOUNT as varchar(50))            
   END        
   ELSE        
   BEGIN        
    PRINT 'Adding new invoice, This invoice-no is still active and belongs to another file so add a new invoice'        
            
    -- Okay, so this invoice-no already belongs to another file,we just need to insert into invoice table for this file        
    -- also linked to this invoice-no        
    INSERT INTO aims_invoice        
      (invoice_no, patient_id, invoice_date, invoice_amount_received,        
       generated_yn, locked_yn, late_invoice_yn,        
       cancelled_yn, doctor_owing, late_invoice_sent,late_invoice_sent_date,INVOICE_SENT_WAYBILL_NO,     
       GUARANTOR_ACCOUNT_ID    
      )        
     VALUES (@invoiceno, @patientid, @invoicedate, @invoiceamountreceived,        
       @invoicegeneratedyn, @invoicelockedyn, @invoicelateyn,        
       @invoicecancelledyn, @doctorowing, @lateinvoicesent,      
       @LateInvoiceSentDate, @InvoiceSentWaybillNo  ,@GuarantorAccountId    
      )        
              
     SET @InvoiceID = IDENT_CURRENT('AIMS_INVOICE')           
              
     INSERT INTO aims_a_invoice        
       (modified_user, modified_action, modified_date, invoice_id,        
        invoice_no, patient_id, invoice_date, invoice_amount_received,        
        generated_yn, locked_yn, late_invoice_yn,        
        creation_dttm, cancelled_yn, doctor_owing,        
        late_invoice_sent ,  late_invoice_sent_date, INVOICE_SENT_WAYBILL_NO, GUARANTOR_ACCOUNT_ID      
       )        
      VALUES (@usersignedon, 'UPDATE', getdate (), @invoiceid,        
        @invoiceno, @patientid, @invoicedate, @invoiceamountreceived,        
        @invoicegeneratedyn, @invoicelockedyn, @invoicelateyn,        
        @invoicecreationdttm, @invoicecancelledyn, @doctorowing,        
        @lateinvoicesent , @LateInvoiceSentDate, @InvoiceSentWaybillNo,    
        @GuarantorAccountId    
       )           
   END                           
  END        
  ELSE        
  BEGIN        
   PRINT 'Invoice-No already exist and invoice-no is NOT active, Update existing Invoice-No entry with this details'        
           
   PRINT 'Check if this invoice-no was not previously linked to this file, If Yes, do an update with the PATIENT_ID'        
           
   SELECT @RowCheck = COUNT(*) FROM AIMS_INVOICE WHERE INVOICE_NO = @InvoiceNo AND PATIENT_ID = @patientid        
   IF (@RowCheck > 0)        
   BEGIN        
    PRINT 'This invoice-no was previously linked to this file, do an update with the PATIENT_ID'        
    -- Get the Old Invoice-ID Linked to this Invoice-No        
    SELECT @OldInvoiceID = INVOICE_ID FROM AIMS_INVOICE WHERE INVOICE_NO = @InvoiceNo AND PATIENT_ID = @patientid        
            
    PRINT 'Updating Old Invoice with Invoice Details - ' + cast(@OldInvoiceID as varchar(50))        
            
    UPDATE aims_invoice        
       SET invoice_no = @invoiceno,        
        patient_id = @patientid,        
        invoice_date = @invoicedate,     
        invoice_amount_received = @invoiceamountreceived,        
        generated_yn = @invoicegeneratedyn,        
        locked_yn = @invoicelockedyn,        
        late_invoice_yn = @invoicelateyn,        
        cancelled_yn = @invoicecancelledyn,        
        doctor_owing = @doctorowing,        
        late_invoice_sent = @lateinvoicesent ,      
        late_invoice_sent_date  = @LateInvoiceSentDate,      
        INVOICE_SENT_WAYBILL_NO = @InvoiceSentWaybillNo ,    
        GUARANTOR_ACCOUNT_ID = @GuarantorAccountId    
    WHERE invoice_id = @OldInvoiceID        
            
    SELECT @InvoiceID = @OldInvoiceID        
    PRINT 'Invoice Details Updated: ' + cast(@@ROWCOUNT as varchar(50))            
   END        
   ELSE        
   BEGIN        
    PRINT 'This invoice-no was NOT previously linked to this file, do an update without the PATIENT_ID'        
    PRINT 'Now check if this Invoice-No is not linked to any other patient other this patient file and cancelled, ELSE do an Insert'        
    SELECT @RowCheck = COUNT(*)  FROM AIMS_INVOICE WHERE INVOICE_NO = INVOICE_NO and patient_id != @patientid and CANCELLED_YN = 'Y'        
    IF(@RowCheck > 0)        
    BEGIN        
     PRINT 'This invoice-no is currently linked to another patient and in a cancelled state, Re-activate and move this patient file'        
     -- Get the Old Invoice-ID Linked to this Invoice-No        
     SELECT @OldInvoiceID = INVOICE_ID  FROM AIMS_INVOICE WHERE INVOICE_NO = INVOICE_NO and patient_id != @patientid and CANCELLED_YN = 'Y'        
     PRINT 'Updating Old Invoice with Invoice Details - ' + cast(@OldInvoiceID as varchar(50))        
             
     UPDATE aims_invoice        
        SET invoice_no = @invoiceno,        
         patient_id = @patientid,        
         invoice_date = @invoicedate,        
        invoice_amount_received = @invoiceamountreceived,        
         generated_yn = @invoicegeneratedyn,        
         locked_yn = @invoicelockedyn,        
         late_invoice_yn = @invoicelateyn,        
         cancelled_yn = @invoicecancelledyn,        
         doctor_owing = @doctorowing,        
         late_invoice_sent = @lateinvoicesent ,      
         late_invoice_sent_date = @LateInvoiceSentDate,      
         INVOICE_SENT_WAYBILL_NO = @InvoiceSentWaybillNo,    
         GUARANTOR_ACCOUNT_ID = @GuarantorAccountId      
     WHERE invoice_id = @OldInvoiceID        
             
     SELECT @InvoiceID = @OldInvoiceID        
     PRINT 'Invoice Details Updated: ' + cast(@@ROWCOUNT as varchar(50))              
    END        
    ELSE        
    BEGIN        
     PRINT 'Adding new invoice, This invoice-no already exist already exist in another file so we just another entry.'        
             
     -- Okay, so this invoice-no already belongs to another file,we just need to insert into invoice table for this file        
     -- also linked to this invoice-no        
     INSERT INTO aims_invoice        
       (invoice_no, patient_id, invoice_date, invoice_amount_received,        
        generated_yn, locked_yn, late_invoice_yn,        
        cancelled_yn, doctor_owing, late_invoice_sent  , late_invoice_sent_date,      
        INVOICE_SENT_WAYBILL_NO, GUARANTOR_ACCOUNT_ID       
       )        
      VALUES (@invoiceno, @patientid, @invoicedate, @invoiceamountreceived,        
        @invoicegeneratedyn, @invoicelockedyn, @invoicelateyn,        
        @invoicecancelledyn, @doctorowing, @lateinvoicesent  , @LateInvoiceSentDate,      
        @InvoiceSentWaybillNo,@GuarantorAccountId        
       )        
               
      SET @InvoiceID = IDENT_CURRENT('AIMS_INVOICE')              
      INSERT INTO aims_a_invoice        
        (modified_user, modified_action, modified_date, invoice_id,        
         invoice_no, patient_id, invoice_date, invoice_amount_received,        
         generated_yn, locked_yn, late_invoice_yn,        
         creation_dttm, cancelled_yn, doctor_owing,        
         late_invoice_sent  , late_invoice_sent_date,      
         INVOICE_SENT_WAYBILL_NO  , GUARANTOR_ACCOUNT_ID     
        )        
       VALUES (@usersignedon, 'UPDATE', getdate (), @invoiceid,        
         @invoiceno, @patientid, @invoicedate, @invoiceamountreceived,        
         @invoicegeneratedyn, @invoicelockedyn, @invoicelateyn,        
         @invoicecreationdttm, @invoicecancelledyn, @doctorowing,        
         @lateinvoicesent  , @LateInvoiceSentDate, @InvoiceSentWaybillNo ,           @GuarantorAccountId    
        )               
    END            
   END        
  END                  
 END        
 ELSE        
 BEGIN          
  PRINT 'UPDATE INVOICE DETAILS [INVOICE ID- :'+ CAST(@invoiceid AS VARCHAR(50))        
  SELECT @InvoiceID = INVOICE_ID FROM AIMS_INVOICE WHERE INVOICE_NO = @InvoiceNo and patient_id = @patientid        
          
  IF (@InvoiceCancelledYN = 'Y')        
  BEGIN        
   PRINT 'CANCELLING INVOICE ONLY'        
   UPDATE aims_invoice        
      SET         
       cancelled_yn = 'Y'               
    WHERE invoice_id = @invoiceid         
        
   SELECT @MedicalTreatmentID = Medical_Treatment_ID        
     FROM aims_invoice_medical_treatments        
    WHERE invoice_id in (SELECT invoice_id        
           FROM aims_invoice        
          WHERE invoice_no = @InvoiceNo AND patient_id = @PatientID)          
        
   PRINT 'CANCELLING MEDICAL TREATMENT LINKED TO ' + CAST(@MedicalTreatmentID AS VARCHAR(50))        
        
   DELETE FROM AIMS_INVOICE_MEDICAL_TREATMENTS WHERE MEDICAL_TREATMENT_ID  = @MedicalTreatmentID        
   PRINT  'Deleted Medical InvoicesInvoices - ' + CAST(@@ROWCOUNT AS VARCHAR(50))        
   DELETE FROM aims_medical_treatment WHERE MEDICAL_TREATMENT_ID = @MedicalTreatmentID                  
   PRINT 'Deleted Medical Treatments - ' + CAST(@@ROWCOUNT AS VARCHAR(50))        
  END        
  ELSE        
  BEGIN        
   PRINT  'Invoice de-activated, Re-activate and update accordingly'        
   UPDATE aims_invoice        
      SET invoice_no = @invoiceno,        
       patient_id = @patientid,        
       invoice_date = @invoicedate,        
       invoice_amount_received = @invoiceamountreceived,        
       generated_yn = @invoicegeneratedyn,        
       locked_yn = @invoicelockedyn,        
       late_invoice_yn = @invoicelateyn,        
       cancelled_yn = @invoicecancelledyn,        
       doctor_owing = @doctorowing,        
       late_invoice_sent = @lateinvoicesent  ,      
       late_invoice_sent_date = @LateInvoiceSentDate,      
       INVOICE_SENT_WAYBILL_NO= @InvoiceSentWaybillNo
       --,GUARANTOR_ACCOUNT_ID = @GuarantorAccountId    
    WHERE invoice_id = @invoiceid          
  END        
           
  INSERT INTO aims_a_invoice        
     (modified_user, modified_action, modified_date, invoice_id,        
      invoice_no, patient_id, invoice_date, invoice_amount_received,        
      generated_yn, locked_yn, late_invoice_yn,        
      creation_dttm, cancelled_yn, doctor_owing,        
      late_invoice_sent  , late_invoice_sent_date,INVOICE_SENT_WAYBILL_NO
      , GUARANTOR_ACCOUNT_ID      
     )        
    VALUES (@usersignedon, 'UPDATE', getdate (), @invoiceid,        
      @invoiceno, @patientid, @invoicedate, @invoiceamountreceived,        
      @invoicegeneratedyn, @invoicelockedyn, @invoicelateyn,        
      @invoicecreationdttm, @invoicecancelledyn, @doctorowing,        
      @lateinvoicesent  , @LateInvoiceSentDate, @InvoiceSentWaybillNo
      ,@GuarantorAccountId    
     )          
 END         
         
 IF (@InvoiceCancelledYN != 'Y')            
 BEGIN        
  SELECT @MedicalTreatmentID = Medical_Treatment_ID        
    FROM aims_invoice_medical_treatments        
   WHERE invoice_id in (SELECT invoice_id        
          FROM aims_invoice        
         WHERE invoice_no = @InvoiceNo AND patient_id = @PatientID)          
        
  PRINT 'CANCELLING MEDICAL TREATMENT LINKED TO ' + CAST(@MedicalTreatmentID AS VARCHAR(50))        
          
  DELETE FROM AIMS_INVOICE_MEDICAL_TREATMENTS WHERE MEDICAL_TREATMENT_ID  = @MedicalTreatmentID        
  DELETE FROM aims_medical_treatment WHERE MEDICAL_TREATMENT_ID = @MedicalTreatmentID         
           
  PRINT 'Adding the Medical Treatment Details'        
  EXEC AIMS_INVOICE_MEDICAL_TREATMENT_ADD @InvoiceID, @MedicalTreatmentID, @ServiceID, @SupplierID, @ServiceDesc, @ServiceDesc, @TreatmentDate                          
    END           
            
IF (@@ERROR <> 0)                      
BEGIN        
ROLLBACK TRANSACTION addInvoice                      
END                    
ELSE        
BEGIN        
COMMIT TRANSACTION addInvoice                      
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_INVOICE_ADD]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AIMS_INVOICE_ADD]                      
 @InvoiceID    int output,                    
 @InvoiceNo    varchar(50) = '',      
 @PatientFileNo   varchar(50) = '',      
 @InvoiceDate   varchar(50) = '',      
 @InvoiceAmountReceived  varchar(50) = '',      
 @InvoiceGeneratedYN  varchar(1)  = '',      
 @InvoiceLockedYN  varchar(1)  = '',      
 @InvoiceLateYN   varchar(1)  = '',      
 @UserSignedOn   varchar(50) = '',      
 @SupplierID    varchar(50) = '',      
 @ServiceID    varchar(50) = '',      
 @InvoiceCancelledYN  varchar(1)  = '',      
 @DoctorOwing   varchar(1)  = '',      
 @LateInvoiceSent  varchar(1)  = ''                        
as                     
 BEGIN TRANSACTION addInvoice                    
INSERT INTO AIMS_DEBUGGING  values('[Invoice Add Update - @InvoiceCancelledYN ] - ' + @UserSignedOn,@InvoiceCancelledYN, GETDATE())            
  
 DECLARE @LastError INT,           
   @vSQL varchar(4000),           
   @PatientID int,           
   @ServiceDesc varchar(255),           
   @MedicalTreatmentID int,           
   @TreatmentDate varchar(50),           
   @InvoiceCreationDTTM DateTime,        
   @RowCheck int                    
      
insert into aims_debugging   values ('8888','6666',GETDATE())
              
 SELECT @PatientID = patient_id from aims_patient where patient_file_no = @PatientFileNo                    
    SELECT @ServiceDesc = supplier_type_desc FROM aims_supplier_types WHERE supplier_type_id = @ServiceID                    
           
 SET @TreatmentDate = CAST(GETDATE() AS VARCHAR(50))                    
        
 IF ( @InvoiceID = 0)                    
 BEGIN                    
  SET @InvoiceID = NULL                    
 END                  
   
 INSERT INTO AIMS_DEBUGGING  values('[Invoice Add Update - @InvoiceCancelledYN ]- ' + @UserSignedOn,@InvoiceCancelledYN, GETDATE())  
   
 IF (@InvoiceCancelledYN = 'Y')      
 BEGIN  
    
  SELECT @MedicalTreatmentID = Medical_Treatment_ID FROM AIMS_INVOICE_MEDICAL_TREATMENTS WHERE INVOICE_ID = (Select INVOICE_ID from AIMS_INVOICE where INVOICE_NO = @InvoiceNo and PATIENT_ID = @PatientID)  
    
  INSERT INTO AIMS_DEBUGGING  values('[Invoice Add Update - deleting existing Invoice No ]- ' + @UserSignedOn,@MedicalTreatmentID, GETDATE())  
    
  INSERT INTO AIMS_DEBUGGING  values('[Invoice Add Update - deleting existing @Invoice No ]- ' + @UserSignedOn,@InvoiceNo, GETDATE())  
    
  DELETE FROM AIMS_INVOICE_MEDICAL_TREATMENTS WHERE MEDICAL_TREATMENT_ID  = @MedicalTreatmentID  
        DELETE FROM aims_medical_treatment WHERE MEDICAL_TREATMENT_ID = @MedicalTreatmentID      
    
  --delete from aims_invoice_medical_treatments where INVOICE_ID = (Select INVOICE_ID from AIMS_INVOICE where INVOICE_NO = @InvoiceNo)   
  --delete from AIMS_MEDICAL_TREATMENT where MEDICAL_TREATMENT_ID in (select MEDICAL_TREATMENT_ID from aims_invoice_medical_treatments where INVOICE_ID = (Select INVOICE_ID from AIMS_INVOICE where INVOICE_NO = @InvoiceNo))    
 END  
  
INSERT INTO AIMS_DEBUGGING  values('[Invoice Add Update - @InvoiceID ] - ' + cast(@InvoiceID as VARCHAR(50)), cast(@InvoiceID as VARCHAR(50)) , GETDATE())  
  
 IF @InvoiceID is null                     
  BEGIN          
   SELECT @RowCheck = COUNT(*) from AIMS_INVOICE WHERE INVOICE_NO = @InvoiceNo and PATIENT_ID = @PatientID  
     
   IF @RowCheck > 0        
    BEGIN        
     INSERT INTO AIMS_DEBUGGING  values('[Invoice Adding , invoice already linked to another file ]- ' + @UserSignedOn,@PatientID, GETDATE())  
       
     UPDATE aims_invoice SET                     
       INVOICE_NO = @InvoiceNo,                     
       PATIENT_ID = @PatientID,                     
       INVOICE_DATE = @InvoiceDate,                    
       INVOICE_AMOUNT_RECEIVED =@InvoiceAmountReceived ,                    
       GENERATED_YN =@InvoiceGeneratedYN ,                    
       LOCKED_YN =@InvoiceLockedYN,                    
       LATE_INVOICE_YN =@InvoiceLateYN,                
       cancelled_yn =  'N',              
       doctor_owing = @DoctorOwing,            
       LATE_INVOICE_SENT = @LateInvoiceSent                           
     WHERE invoice_no = @InvoiceNo  
     and PATIENT_ID =  @PatientID   
           
     SELECT @InvoiceID = INVOICE_ID FROM AIMS_INVOICE WHERE INVOICE_NO = @InvoiceNo             
    END        
   ELSE        
    BEGIN     
       
     INSERT INTO AIMS_DEBUGGING  values('[Invoice Adding , invoice NOT already linked to another file ]- ' + @UserSignedOn,@InvoiceNo, GETDATE())  
       
     INSERT INTO aims_invoice(                    
        INVOICE_NO,                    
        PATIENT_ID,                    
        INVOICE_DATE,                    
        INVOICE_AMOUNT_RECEIVED,                    
        GENERATED_YN,                    
        LOCKED_YN,                    
        LATE_INVOICE_YN,                
        cancelled_yn,              
        doctor_owing,            
        LATE_INVOICE_SENT)           
       values(                    
      @InvoiceNo,                    
      @PatientID,                    
      @InvoiceDate,                    
      @InvoiceAmountReceived,                    
      @InvoiceGeneratedYN,                    
      @InvoiceLockedYN,                    
      @InvoiceLateYN,                
      @InvoiceCancelledYN,              
      @DoctorOwing,            
      @LateInvoiceSent)                    
                     
     SET @InvoiceID = IDENT_CURRENT('aims_invoice')                    
    END      
          
    INSERT INTO aims_a_invoice(                    
       MODIFIED_USER ,                    
       MODIFIED_ACTION,                    
       MODIFIED_DATE,                    
       INVOICE_ID,                     
       INVOICE_NO,                    
       PATIENT_ID,                    
       INVOICE_DATE,                    
       INVOICE_AMOUNT_RECEIVED,                    
       GENERATED_YN,                    
       LOCKED_YN,                
       LATE_INVOICE_YN,               
       cancelled_yn,              
       DOCTOR_OWING,            
       LATE_INVOICE_SENT) values(                    
      @UserSignedOn,                    
      'UPDATE',                    
      getdate(),                    
      @InvoiceID,                    
      @InvoiceNo,                    
      @PatientID,                    
      @InvoiceDate,                    
      @InvoiceAmountReceived,                    
      @InvoiceGeneratedYN,                    
      @InvoiceLockedYN,                    
      @InvoiceLateYN,                
      @InvoiceCancelledYN,              
      @DoctorOwing,            
      @LateInvoiceSent)                    
  END                    
 ELSE                    
  BEGIN       
   INSERT INTO AIMS_DEBUGGING  values('[Invoice Updating - existing Invoice No ]- ' + @UserSignedOn,@InvoiceNo, GETDATE())                             
     
   UPDATE aims_invoice SET                     
     INVOICE_NO = @InvoiceNo,                     
     PATIENT_ID = @PatientID,                     
     INVOICE_DATE = @InvoiceDate,                    
     INVOICE_AMOUNT_RECEIVED =@InvoiceAmountReceived ,                    
     GENERATED_YN =@InvoiceGeneratedYN ,                    
     LOCKED_YN =@InvoiceLockedYN,                    
     LATE_INVOICE_YN =@InvoiceLateYN,                
     cancelled_yn =  @InvoiceCancelledYN,              
     doctor_owing = @DoctorOwing,            
     LATE_INVOICE_SENT = @LateInvoiceSent                       
   WHERE invoice_id = @InvoiceID   
   and PATIENT_ID = @PatientID                     
  
 IF (@InvoiceCancelledYN != 'Y')      
 BEGIN  
    SET @InvoiceID = @InvoiceID                    
                        
    SELECT @MedicalTreatmentID = Medical_Treatment_ID FROM AIMS_INVOICE_MEDICAL_TREATMENTS WHERE INVOICE_ID = @InvoiceID and Service_id = @ServiceID                    
                      
    DELETE FROM AIMS_INVOICE_MEDICAL_TREATMENTS WHERE invoice_id = @InvoiceID  
                      
    DELETE FROM aims_medical_treatment WHERE MEDICAL_TREATMENT_ID = @MedicalTreatmentID  
                       
    SELECT @InvoiceCreationDTTM = CREATION_DTTM FROM AIMS_INVOICE WHERE INVOICE_ID = @InvoiceID  
 END                       
      
 INSERT INTO aims_a_Invoice(                    
  MODIFIED_USER ,                    
  MODIFIED_ACTION,                    
  MODIFIED_DATE,                    
  INVOICE_ID,                     
  INVOICE_NO,                    
  PATIENT_ID,                    
  INVOICE_DATE,                    
  INVOICE_AMOUNT_RECEIVED,                    
  GENERATED_YN,                    
  LOCKED_YN,                    
  LATE_INVOICE_YN,   
  CREATION_DTTM,   
  cancelled_yn,   
  DOCTOR_OWING,   
  LATE_INVOICE_SENT)VALUES(                    
        @UserSignedOn,                    
        'UPDATE',                    
        getdate(),                    
        @InvoiceID,                    
        @InvoiceNo,                    
        @PatientID,                    
        @InvoiceDate,                    
        @InvoiceAmountReceived,                    
        @InvoiceGeneratedYN,                    
        @InvoiceLockedYN,                    
        @InvoiceLateYN,                    
        @InvoiceCreationDTTM,                
        @InvoiceCancelledYN,             
        @DoctorOwing,            
        @LateInvoiceSent)                                             
  END                    
 IF (@InvoiceCancelledYN != 'Y')      
 BEGIN                            
  EXEC AIMS_INVOICE_MEDICAL_TREATMENT_ADD @InvoiceID, @MedicalTreatmentID, @ServiceID, @SupplierID, @ServiceDesc, @ServiceDesc, @TreatmentDate                    
    END           
 IF (@@ERROR <> 0)                    
  BEGIN      
   ROLLBACK TRANSACTION addInvoice                    
  END      
 ELSE                    
  BEGIN                     
   COMMIT TRANSACTION addInvoice                    
  END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_SENT_EMAIL_POD_DELIVERY]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[AIMS_EWS_SENT_EMAIL_POD_DELIVERY]
 @FILE_NAME varchar(2000),  
 @PATIENT_SENT_EMAIL_ID VARCHAR(50)  
AS  
BEGIN  
 INSERT INTO   
  AIMS_EWS_SENT_EMAIL_ATTACHMENTS   
 VALUES(@PATIENT_SENT_EMAIL_ID, @FILE_NAME, null)  
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_PATIENT_SENT_EMAIL_DOCS_ATTACHED]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc  [dbo].[AIMS_EWS_GET_PATIENT_SENT_EMAIL_DOCS_ATTACHED]    
 @PatientSentEmailID VARCHAR(50)    
AS    
BEGIN   
 SELECT
	SENT_EMAIL_ATTACHMENT "FILE_NAME",
	SENT_EMAIL_ATTACHMENT "DOC_TYPE"
  FROM
		AIMS_EWS_PATIENT_SENT_EMAILS a,
		AIMS_EWS_SENT_EMAIL_ATTACHMENTS b
	WHERE a.SENT_EMAIL_ID =@PatientSentEmailID and
		  b.SENT_EMAIL_ID = a.SENT_EMAIL_ID
	ORDER BY SENT_EMAIL_ATTACHMENT
END
GO
/****** Object:  StoredProcedure [dbo].[AIMS_EWS_GET_PATIENT_SENT_EMAIL_DOCS]    Script Date: 05/11/2021 21:45:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AIMS_EWS_GET_PATIENT_SENT_EMAIL_DOCS]        
 @PATIENT_SENT_EMAIL_ID varchar(50)        
AS        
BEGIN        
 SELECT * FROM AIMS_EWS_PATIENT_SENT_EMAILS A    
 inner JOIN AIMS_EWS_SENT_EMAIL_ATTACHMENTS B ON B.SENT_EMAIL_ID = A.SENT_EMAIL_ID    
 WHERE A.SENT_EMAIL_ID = @PATIENT_SENT_EMAIL_ID    
 ORDER BY A.SENT_DTTM DESC       
END
GO
/****** Object:  Default [DF__AIMS_A_PA__MODIF__2C1F508E]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_A_PATIENT_FILE_TASKS] ADD  DEFAULT (getdate()) FOR [MODIFIED_DATE]
GO
/****** Object:  Default [DF_AIMS_A_PATIENT_CREATION_DTTM]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_A_PATIENT] ADD  CONSTRAINT [DF_AIMS_A_PATIENT_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_A_INVOICE_CREATION_DTTM]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_A_INVOICE] ADD  CONSTRAINT [DF_AIMS_A_INVOICE_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_EMBASSIES_CREATION_DTTM]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EMBASSIES] ADD  CONSTRAINT [DF_AIMS_EMBASSIES_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_EWS_MAILBOXES_MAILBOX_ACTIVE_YN]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_MAILBOXES] ADD  CONSTRAINT [DF_AIMS_EWS_MAILBOXES_MAILBOX_ACTIVE_YN]  DEFAULT ('Y') FOR [MAILBOX_ACTIVE_YN]
GO
/****** Object:  Default [DF_AIMS_NON_WORKING_DAYS_MODIFIED_DTTM]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_NON_WORKING_DAYS] ADD  CONSTRAINT [DF_AIMS_NON_WORKING_DAYS_MODIFIED_DTTM]  DEFAULT (getdate()) FOR [MODIFIED_DTTM]
GO
/****** Object:  Default [DF_AIMS_EWS_EMAILS_PROCESSED_DTTM]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAILS] ADD  CONSTRAINT [DF_AIMS_EWS_EMAILS_PROCESSED_DTTM]  DEFAULT (getdate()) FOR [PROCESSED_DTTM]
GO
/****** Object:  Default [DF_AIMS_EWS_EMAILS_EMAIL_INDEXED_YN]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAILS] ADD  CONSTRAINT [DF_AIMS_EWS_EMAILS_EMAIL_INDEXED_YN]  DEFAULT ('N') FOR [EMAIL_INDEXED_YN]
GO
/****** Object:  Default [DF_AIMS_EWS_EMAILS_EMAIL_DELETED_YN]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAILS] ADD  CONSTRAINT [DF_AIMS_EWS_EMAILS_EMAIL_DELETED_YN]  DEFAULT ('N') FOR [EMAIL_DELETED_YN]
GO
/****** Object:  Default [DF_AIMS_EWS_EMAILS_EMAIL_PENDED_YN]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAILS] ADD  CONSTRAINT [DF_AIMS_EWS_EMAILS_EMAIL_PENDED_YN]  DEFAULT ('N') FOR [EMAIL_PENDED_YN]
GO
/****** Object:  Default [DF_AIMS_GUARANTOR_CREATION_DTTM]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_GUARANTOR] ADD  CONSTRAINT [DF_AIMS_GUARANTOR_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_SUPPLIER_CREATION_DTTM]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_SUPPLIER] ADD  CONSTRAINT [DF_AIMS_SUPPLIER_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_GUARANTOR_ACCOUNT_ACTIVE_YN]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_GUARANTOR_ACCOUNT] ADD  CONSTRAINT [DF_AIMS_GUARANTOR_ACCOUNT_ACTIVE_YN]  DEFAULT ('Y') FOR [ACTIVE_YN]
GO
/****** Object:  Default [DF_AIMS_GUARANTOR_ACCOUNT_CURRENCY_CODE]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_GUARANTOR_ACCOUNT] ADD  CONSTRAINT [DF_AIMS_GUARANTOR_ACCOUNT_CURRENCY_CODE]  DEFAULT ('USD') FOR [CURRENCY_CODE]
GO
/****** Object:  Default [DF_AIMS_PATIENT_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT] ADD  CONSTRAINT [DF_AIMS_PATIENT_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_VISA_LETTERS_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_VISA_LETTERS] ADD  CONSTRAINT [DF_AIMS_VISA_LETTERS_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_VISA_LETTERS_ACTIVE_YN]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_VISA_LETTERS] ADD  CONSTRAINT [DF_AIMS_VISA_LETTERS_ACTIVE_YN]  DEFAULT ('Y') FOR [ACTIVE_YN]
GO
/****** Object:  Default [DF_AIMS_AA_OPTIONS_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_AA_OPTIONS] ADD  CONSTRAINT [DF_AIMS_AA_OPTIONS_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_AA_DETAILS_CREATIN_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_AA_DETAILS] ADD  CONSTRAINT [DF_AIMS_AA_DETAILS_CREATIN_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_AA_DETAILS_ACTIVE_YN]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_AA_DETAILS] ADD  CONSTRAINT [DF_AIMS_AA_DETAILS_ACTIVE_YN]  DEFAULT ('Y') FOR [ACTIVE_YN]
GO
/****** Object:  Default [DF_AIMS_ACCOMODATION_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_ACCOMODATION] ADD  CONSTRAINT [DF_AIMS_ACCOMODATION_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_APPOINTMENTS_CANCELLED_YN]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_APPOINTMENTS] ADD  CONSTRAINT [DF_AIMS_APPOINTMENTS_CANCELLED_YN]  DEFAULT ('N') FOR [CANCELLED_YN]
GO
/****** Object:  Default [DF_AIMS_APPOINTMENTS_EMAIL_SMS_SENT_YN]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_APPOINTMENTS] ADD  CONSTRAINT [DF_AIMS_APPOINTMENTS_EMAIL_SMS_SENT_YN]  DEFAULT ('N') FOR [EMAIL_SMS_SENT_YN]
GO
/****** Object:  Default [DF_AIMS_EWS_PATIENT_ENQUIRY_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_ENQUIRY] ADD  CONSTRAINT [DF_AIMS_EWS_PATIENT_ENQUIRY_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_INVOICE_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_INVOICE] ADD  CONSTRAINT [DF_AIMS_INVOICE_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_PATIENT_GUARANTEES_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GUARANTEES] ADD  CONSTRAINT [DF_AIMS_PATIENT_GUARANTEES_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_PATIENT_GUARANTEES_ACTIVE_YN]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GUARANTEES] ADD  CONSTRAINT [DF_AIMS_PATIENT_GUARANTEES_ACTIVE_YN]  DEFAULT ('Y') FOR [ACTIVE_YN]
GO
/****** Object:  Default [DF_AIMS_PATIENT_GUARANTEES_GOP_APPROVED_YN]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GUARANTEES] ADD  CONSTRAINT [DF_AIMS_PATIENT_GUARANTEES_GOP_APPROVED_YN]  DEFAULT ('N') FOR [GOP_APPROVED_YN]
GO
/****** Object:  Default [DF_AIMS_PATIENT_FILE_TASKS_CREATION_DATE]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS] ADD  CONSTRAINT [DF_AIMS_PATIENT_FILE_TASKS_CREATION_DATE]  DEFAULT (getdate()) FOR [CREATION_DATE]
GO
/****** Object:  Default [DF_AIMS_PATIENT_GOP_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GOP] ADD  CONSTRAINT [DF_AIMS_PATIENT_GOP_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  Default [DF_AIMS_PATIENT_GOP_ACTIVE_YN]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GOP] ADD  CONSTRAINT [DF_AIMS_PATIENT_GOP_ACTIVE_YN]  DEFAULT ('Y') FOR [ACTIVE_YN]
GO
/****** Object:  Default [DF_AIMS_PAYMENT_CREATION_DTTM]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PAYMENT] ADD  CONSTRAINT [DF_AIMS_PAYMENT_CREATION_DTTM]  DEFAULT (getdate()) FOR [CREATION_DTTM]
GO
/****** Object:  ForeignKey [FK_AIMS_ROLE_RESTRICTION_AIMS_RESTRICTIONS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_ROLE_RESTRICTION]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_ROLE_RESTRICTION_AIMS_RESTRICTIONS] FOREIGN KEY([RESTRICTION_ID])
REFERENCES [dbo].[AIMS_RESTRICTIONS] ([RESTRICTION_ID])
GO
ALTER TABLE [dbo].[AIMS_ROLE_RESTRICTION] CHECK CONSTRAINT [FK_AIMS_ROLE_RESTRICTION_AIMS_RESTRICTIONS]
GO
/****** Object:  ForeignKey [FK_AIMS_ROLE_RESTRICTION_AIMS_ROLES]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_ROLE_RESTRICTION]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_ROLE_RESTRICTION_AIMS_ROLES] FOREIGN KEY([ROLE_CD])
REFERENCES [dbo].[AIMS_ROLES] ([ROLE_CD])
GO
ALTER TABLE [dbo].[AIMS_ROLE_RESTRICTION] CHECK CONSTRAINT [FK_AIMS_ROLE_RESTRICTION_AIMS_ROLES]
GO
/****** Object:  ForeignKey [FK_AIMS_REPORTS_ACCESS_AIMS_ROLES]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_REPORTS_ACCESS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_REPORTS_ACCESS_AIMS_ROLES] FOREIGN KEY([REPORT_ACCESS_ROLE])
REFERENCES [dbo].[AIMS_ROLES] ([ROLE_CD])
GO
ALTER TABLE [dbo].[AIMS_REPORTS_ACCESS] CHECK CONSTRAINT [FK_AIMS_REPORTS_ACCESS_AIMS_ROLES]
GO
/****** Object:  ForeignKey [FK_AIMS_GOP_USER_LIMIT_AIMS_USERS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_GOP_USER_LIMIT]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_GOP_USER_LIMIT_AIMS_USERS] FOREIGN KEY([USER_NAME])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_GOP_USER_LIMIT] CHECK CONSTRAINT [FK_AIMS_GOP_USER_LIMIT_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_EMAILS_AIMS_EWS_MAILBOXES]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EMAILS_AIMS_EWS_MAILBOXES] FOREIGN KEY([MAILBOX_ID])
REFERENCES [dbo].[AIMS_EWS_MAILBOXES] ([MAILBOX_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_EMAILS] CHECK CONSTRAINT [FK_AIMS_EMAILS_AIMS_EWS_MAILBOXES]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_EMAILS_AIMS_USERS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAILS]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_EWS_EMAILS_AIMS_USERS] FOREIGN KEY([EMAIL_LOCKED_BY])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_EWS_EMAILS] NOCHECK CONSTRAINT [FK_AIMS_EWS_EMAILS_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_OPERATOR_MAILBOX_AIMS_USERS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_OPERATOR_MAILBOX]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_OPERATOR_MAILBOX_AIMS_USERS] FOREIGN KEY([OPERATOR_MAILBOX_USER_NAME])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_EWS_OPERATOR_MAILBOX] CHECK CONSTRAINT [FK_AIMS_EWS_OPERATOR_MAILBOX_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_ADDRESS_AIMS_ADDRESS_TYPE]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_ADDRESS]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_ADDRESS_AIMS_ADDRESS_TYPE] FOREIGN KEY([ADDRESS_TYPE_ID])
REFERENCES [dbo].[AIMS_ADDRESS_TYPE] ([ADDR_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_ADDRESS] CHECK CONSTRAINT [FK_AIMS_ADDRESS_AIMS_ADDRESS_TYPE]
GO
/****** Object:  ForeignKey [FK_AIMS_ADDRESS_AIMS_COUNTRY]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_ADDRESS]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_ADDRESS_AIMS_COUNTRY] FOREIGN KEY([COUNTRY_ID])
REFERENCES [dbo].[AIMS_COUNTRY] ([COUNTRY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AIMS_ADDRESS] CHECK CONSTRAINT [FK_AIMS_ADDRESS_AIMS_COUNTRY]
GO
/****** Object:  ForeignKey [FK_INDUSTRYRATES_Years]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[INDUSTRYRATES]  WITH CHECK ADD  CONSTRAINT [FK_INDUSTRYRATES_Years] FOREIGN KEY([YEARID])
REFERENCES [dbo].[Years] ([ID])
GO
ALTER TABLE [dbo].[INDUSTRYRATES] CHECK CONSTRAINT [FK_INDUSTRYRATES_Years]
GO
/****** Object:  ForeignKey [FK_AIMS_USER_ROLE_AIMS_ROLES]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_USER_ROLE]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_USER_ROLE_AIMS_ROLES] FOREIGN KEY([ROLE_CD])
REFERENCES [dbo].[AIMS_ROLES] ([ROLE_CD])
GO
ALTER TABLE [dbo].[AIMS_USER_ROLE] CHECK CONSTRAINT [FK_AIMS_USER_ROLE_AIMS_ROLES]
GO
/****** Object:  ForeignKey [FK_AIMS_USER_ROLE_AIMS_USERS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_USER_ROLE]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_USER_ROLE_AIMS_USERS] FOREIGN KEY([USER_NAME])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_USER_ROLE] CHECK CONSTRAINT [FK_AIMS_USER_ROLE_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_EMAIL_ATTACHMENT_AIMS_EMAILS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAIL_ATTACHMENT]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EMAIL_ATTACHMENT_AIMS_EMAILS] FOREIGN KEY([ATTACHMENT_FILE_TYPE_ID])
REFERENCES [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_TYPES] ([ATTACHMENT_FILE_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_EMAIL_ATTACHMENT] CHECK CONSTRAINT [FK_AIMS_EMAIL_ATTACHMENT_AIMS_EMAILS]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_EMAIL_ATTACHMENT_AIMS_EWS_EMAILS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAIL_ATTACHMENT]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_EMAIL_ATTACHMENT_AIMS_EWS_EMAILS] FOREIGN KEY([EMAIL_ID])
REFERENCES [dbo].[AIMS_EWS_EMAILS] ([EMAIL_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_EMAIL_ATTACHMENT] CHECK CONSTRAINT [FK_AIMS_EWS_EMAIL_ATTACHMENT_AIMS_EWS_EMAILS]
GO
/****** Object:  ForeignKey [FK_AIMS_GUARANTOR_AIMS_ADDRESS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_GUARANTOR]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_GUARANTOR_AIMS_ADDRESS] FOREIGN KEY([ADDRESS_ID])
REFERENCES [dbo].[AIMS_ADDRESS] ([ADDRESS_ID])
GO
ALTER TABLE [dbo].[AIMS_GUARANTOR] CHECK CONSTRAINT [FK_AIMS_GUARANTOR_AIMS_ADDRESS]
GO
/****** Object:  ForeignKey [FK_AIMS_SUPPLIER_AIMS_ADDRESS]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_SUPPLIER]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_SUPPLIER_AIMS_ADDRESS] FOREIGN KEY([ADDRESS_ID])
REFERENCES [dbo].[AIMS_ADDRESS] ([ADDRESS_ID])
GO
ALTER TABLE [dbo].[AIMS_SUPPLIER] CHECK CONSTRAINT [FK_AIMS_SUPPLIER_AIMS_ADDRESS]
GO
/****** Object:  ForeignKey [FK_AIMS_SUPPLIER_AIMS_SUPPLIER_TYPES]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_SUPPLIER]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_SUPPLIER_AIMS_SUPPLIER_TYPES] FOREIGN KEY([SUPPLIER_TYPE_ID])
REFERENCES [dbo].[AIMS_SUPPLIER_TYPES] ([SUPPLIER_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_SUPPLIER] CHECK CONSTRAINT [FK_AIMS_SUPPLIER_AIMS_SUPPLIER_TYPES]
GO
/****** Object:  ForeignKey [FK_AIMS_MEDICAL_TREATMENT_AIMS_SUPPLIER]    Script Date: 05/11/2021 21:45:10 ******/
ALTER TABLE [dbo].[AIMS_MEDICAL_TREATMENT]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_MEDICAL_TREATMENT_AIMS_SUPPLIER] FOREIGN KEY([SUPPLIER_ID])
REFERENCES [dbo].[AIMS_SUPPLIER] ([SUPPLIER_ID])
GO
ALTER TABLE [dbo].[AIMS_MEDICAL_TREATMENT] CHECK CONSTRAINT [FK_AIMS_MEDICAL_TREATMENT_AIMS_SUPPLIER]
GO
/****** Object:  ForeignKey [FK_AIMS_GUARANTOR_ACCOUNT_AIMS_GUARANTOR]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_GUARANTOR_ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_GUARANTOR_ACCOUNT_AIMS_GUARANTOR] FOREIGN KEY([GUARANTOR_ID])
REFERENCES [dbo].[AIMS_GUARANTOR] ([GUARANTOR_ID])
GO
ALTER TABLE [dbo].[AIMS_GUARANTOR_ACCOUNT] CHECK CONSTRAINT [FK_AIMS_GUARANTOR_ACCOUNT_AIMS_GUARANTOR]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_AIMS_COMPANIES]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_AIMS_COMPANIES] FOREIGN KEY([COMPANY_ID])
REFERENCES [dbo].[AIMS_COMPANIES] ([COMPANY_ID])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[AIMS_PATIENT] NOCHECK CONSTRAINT [FK_AIMS_PATIENT_AIMS_COMPANIES]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_AIMS_GUARANTOR]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_AIMS_GUARANTOR] FOREIGN KEY([GUARANTOR_ID])
REFERENCES [dbo].[AIMS_GUARANTOR] ([GUARANTOR_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AIMS_PATIENT] CHECK CONSTRAINT [FK_AIMS_PATIENT_AIMS_GUARANTOR]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_AIMS_TITLE]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_AIMS_TITLE] FOREIGN KEY([TITLE_ID])
REFERENCES [dbo].[AIMS_TITLE] ([TITLE_ID])
GO
ALTER TABLE [dbo].[AIMS_PATIENT] CHECK CONSTRAINT [FK_AIMS_PATIENT_AIMS_TITLE]
GO
/****** Object:  ForeignKey [FK_AIMS_VISA_LETTERS_AIMS_ADDRESS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_VISA_LETTERS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_ADDRESS] FOREIGN KEY([ADDRESS_ID])
REFERENCES [dbo].[AIMS_ADDRESS] ([ADDRESS_ID])
GO
ALTER TABLE [dbo].[AIMS_VISA_LETTERS] CHECK CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_ADDRESS]
GO
/****** Object:  ForeignKey [FK_AIMS_VISA_LETTERS_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_VISA_LETTERS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_VISA_LETTERS] CHECK CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_VISA_LETTERS_AIMS_RELATIONS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_VISA_LETTERS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_RELATIONS] FOREIGN KEY([ESCORT_RELATION_ID])
REFERENCES [dbo].[AIMS_RELATIONS] ([RELATION_ID])
GO
ALTER TABLE [dbo].[AIMS_VISA_LETTERS] CHECK CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_RELATIONS]
GO
/****** Object:  ForeignKey [FK_AIMS_VISA_LETTERS_AIMS_SUPPLIER]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_VISA_LETTERS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_SUPPLIER] FOREIGN KEY([TREATMENT_HOSPITAL_ID])
REFERENCES [dbo].[AIMS_SUPPLIER] ([SUPPLIER_ID])
GO
ALTER TABLE [dbo].[AIMS_VISA_LETTERS] CHECK CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_SUPPLIER]
GO
/****** Object:  ForeignKey [FK_AIMS_VISA_LETTERS_AIMS_VISA_LETTERS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_VISA_LETTERS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_VISA_LETTERS] FOREIGN KEY([TREATMENT_DOCTOR_PROVIDER_ID])
REFERENCES [dbo].[AIMS_PATIENT_SERVICE_PROVIDERS] ([SERVICE_PROVIDER_ID])
GO
ALTER TABLE [dbo].[AIMS_VISA_LETTERS] CHECK CONSTRAINT [FK_AIMS_VISA_LETTERS_AIMS_VISA_LETTERS]
GO
/****** Object:  ForeignKey [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_DELIVERY_METHOD]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_SEND_EMAIL_REQUESTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_DELIVERY_METHOD] FOREIGN KEY([DELIVERY_METHOD_ID])
REFERENCES [dbo].[AIMS_DELIVERY_METHOD] ([DELIVERY_METHOD_ID])
GO
ALTER TABLE [dbo].[AIMS_SEND_EMAIL_REQUESTS] CHECK CONSTRAINT [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_DELIVERY_METHOD]
GO
/****** Object:  ForeignKey [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_EWS_EMAIL_SENDER]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_SEND_EMAIL_REQUESTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_EWS_EMAIL_SENDER] FOREIGN KEY([EMAIL_FROM_ID])
REFERENCES [dbo].[AIMS_EWS_EMAIL_SENDER] ([EMAIL_FROM_ID])
GO
ALTER TABLE [dbo].[AIMS_SEND_EMAIL_REQUESTS] CHECK CONSTRAINT [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_EWS_EMAIL_SENDER]
GO
/****** Object:  ForeignKey [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_SEND_EMAIL_REQUESTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_SEND_EMAIL_REQUESTS] CHECK CONSTRAINT [FK_AIMS_SEND_EMAIL_REQUESTS_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_TRACE_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_TRACE]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_TRACE_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_TRACE] CHECK CONSTRAINT [FK_AIMS_TRACE_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_TRACE_AIMS_USERS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_TRACE]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_TRACE_AIMS_USERS] FOREIGN KEY([USER_NAME])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_TRACE] CHECK CONSTRAINT [FK_AIMS_TRACE_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_AA_OPTIONS_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_AA_OPTIONS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_AA_OPTIONS_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_AA_OPTIONS] CHECK CONSTRAINT [FK_AIMS_AA_OPTIONS_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_AA_DETAILS_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_AA_DETAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_AA_DETAILS_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_AA_DETAILS] CHECK CONSTRAINT [FK_AIMS_AA_DETAILS_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_ACCOMODATION_AIMS_ACCOMODATION]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_ACCOMODATION]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_ACCOMODATION_AIMS_ACCOMODATION] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_ACCOMODATION] CHECK CONSTRAINT [FK_AIMS_ACCOMODATION_AIMS_ACCOMODATION]
GO
/****** Object:  ForeignKey [FK_AIMS_ACCOMODATION_AIMS_SUPPLIER]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_ACCOMODATION]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_ACCOMODATION_AIMS_SUPPLIER] FOREIGN KEY([SUPPLIER_ID])
REFERENCES [dbo].[AIMS_SUPPLIER] ([SUPPLIER_ID])
GO
ALTER TABLE [dbo].[AIMS_ACCOMODATION] CHECK CONSTRAINT [FK_AIMS_ACCOMODATION_AIMS_SUPPLIER]
GO
/****** Object:  ForeignKey [FK_AIMS_APPOINTMENTS_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_APPOINTMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_APPOINTMENTS_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_APPOINTMENTS] CHECK CONSTRAINT [FK_AIMS_APPOINTMENTS_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_APPOINTMENTS_AIMS_TRANSPORT_TYPE]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_APPOINTMENTS]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_APPOINTMENTS_AIMS_TRANSPORT_TYPE] FOREIGN KEY([TRANSPORT_TYPE_ID])
REFERENCES [dbo].[AIMS_TRANSPORT_TYPE] ([TRANSPORT_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_APPOINTMENTS] NOCHECK CONSTRAINT [FK_AIMS_APPOINTMENTS_AIMS_TRANSPORT_TYPE]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_INSTANT_MESSAGING_AIMS_EWS_INSTANT_MESSAGING]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_EWS_INSTANT_MESSAGING]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_INSTANT_MESSAGING_AIMS_EWS_INSTANT_MESSAGING] FOREIGN KEY([INSTANT_MESSAGE_PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_INSTANT_MESSAGING] CHECK CONSTRAINT [FK_AIMS_EWS_INSTANT_MESSAGING_AIMS_EWS_INSTANT_MESSAGING]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_INSTANT_MESSAGING_AIMS_USERS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_EWS_INSTANT_MESSAGING]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_INSTANT_MESSAGING_AIMS_USERS] FOREIGN KEY([INSTANT_MESSAGE_TO])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_EWS_INSTANT_MESSAGING] CHECK CONSTRAINT [FK_AIMS_EWS_INSTANT_MESSAGING_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_EWS_EMAILS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_ENQUIRY]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_EWS_EMAILS] FOREIGN KEY([EMAIL_ID])
REFERENCES [dbo].[AIMS_EWS_EMAILS] ([EMAIL_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_ENQUIRY] CHECK CONSTRAINT [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_EWS_EMAILS]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_EWS_PRIORITY]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_ENQUIRY]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_EWS_PRIORITY] FOREIGN KEY([PRIORITY_ID])
REFERENCES [dbo].[AIMS_EWS_PRIORITY] ([PRIORITY_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_ENQUIRY] CHECK CONSTRAINT [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_EWS_PRIORITY]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_ENQUIRY]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_ENQUIRY] CHECK CONSTRAINT [FK_AIMS_EWS_PATIENT_ENQUIRY_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_NOTES_AIMS_NOTE_TYPES]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_NOTES]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_NOTES_AIMS_NOTE_TYPES] FOREIGN KEY([NOTE_TYPE_ID])
REFERENCES [dbo].[AIMS_NOTE_TYPES] ([NOTE_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_NOTES] CHECK CONSTRAINT [FK_AIMS_NOTES_AIMS_NOTE_TYPES]
GO
/****** Object:  ForeignKey [FK_AIMS_NOTES_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_NOTES]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_NOTES_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AIMS_NOTES] CHECK CONSTRAINT [FK_AIMS_NOTES_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_NOTES_AIMS_USERS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_NOTES]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_NOTES_AIMS_USERS] FOREIGN KEY([USER_NAME])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_NOTES] CHECK CONSTRAINT [FK_AIMS_NOTES_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_INVOICE_AIMS_GUARANTOR_ACCOUNT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_INVOICE]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_INVOICE_AIMS_GUARANTOR_ACCOUNT] FOREIGN KEY([GUARANTOR_ACCOUNT_ID])
REFERENCES [dbo].[AIMS_GUARANTOR_ACCOUNT] ([GUARANTOR_ACCOUNT_ID])
GO
ALTER TABLE [dbo].[AIMS_INVOICE] NOCHECK CONSTRAINT [FK_AIMS_INVOICE_AIMS_GUARANTOR_ACCOUNT]
GO
/****** Object:  ForeignKey [FK_AIMS_INVOICE_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_INVOICE]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_INVOICE_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AIMS_INVOICE] CHECK CONSTRAINT [FK_AIMS_INVOICE_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_GUARANTEES_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GUARANTEES]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_GUARANTEES_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_GUARANTEES] CHECK CONSTRAINT [FK_AIMS_PATIENT_GUARANTEES_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_GUARANTEES_AIMS_WARD_TYPES]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GUARANTEES]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_GUARANTEES_AIMS_WARD_TYPES] FOREIGN KEY([WARD_TYPE_ID])
REFERENCES [dbo].[AIMS_WARD_TYPES] ([WARD_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_GUARANTEES] CHECK CONSTRAINT [FK_AIMS_PATIENT_GUARANTEES_AIMS_WARD_TYPES]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_FILE_TASKS_AIMS_PATIENT_FILE_TASKS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_FILE_TASKS_AIMS_PATIENT_FILE_TASKS] FOREIGN KEY([PRIORITY_ID])
REFERENCES [dbo].[AIMS_PRIORITY] ([PRIORITY_ID])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS] CHECK CONSTRAINT [FK_AIMS_PATIENT_FILE_TASKS_AIMS_PATIENT_FILE_TASKS]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_FILE_TASKS_AIMS_PATIENT_SUB_FILES]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_FILE_TASKS_AIMS_PATIENT_SUB_FILES] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS] CHECK CONSTRAINT [FK_AIMS_PATIENT_FILE_TASKS_AIMS_PATIENT_SUB_FILES]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_FILE_TASKS_AIMS_TASKS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_FILE_TASKS_AIMS_TASKS] FOREIGN KEY([TASK_ID])
REFERENCES [dbo].[AIMS_TASKS] ([TASK_ID])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS] CHECK CONSTRAINT [FK_AIMS_PATIENT_FILE_TASKS_AIMS_TASKS]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_FILE_TASKS_AIMS_USERS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_FILE_TASKS_AIMS_USERS] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_FILE_TASKS] CHECK CONSTRAINT [FK_AIMS_PATIENT_FILE_TASKS_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_GOP_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GOP]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_GOP_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_GOP] CHECK CONSTRAINT [FK_AIMS_PATIENT_GOP_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_GOP_AIMS_ROOM_TYPES]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GOP]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_GOP_AIMS_ROOM_TYPES] FOREIGN KEY([ROOM_TYPE_ID])
REFERENCES [dbo].[AIMS_ROOM_TYPES] ([ROOM_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_GOP] CHECK CONSTRAINT [FK_AIMS_PATIENT_GOP_AIMS_ROOM_TYPES]
GO
/****** Object:  ForeignKey [FK_AIMS_PATIENT_GOP_AIMS_USERS]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PATIENT_GOP]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PATIENT_GOP_AIMS_USERS] FOREIGN KEY([CREATED_BY])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_PATIENT_GOP] CHECK CONSTRAINT [FK_AIMS_PATIENT_GOP_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_PAYMENT_AIMS_GUARANTOR]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PAYMENT_AIMS_GUARANTOR] FOREIGN KEY([GUARANTOR_ID])
REFERENCES [dbo].[AIMS_GUARANTOR] ([GUARANTOR_ID])
GO
ALTER TABLE [dbo].[AIMS_PAYMENT] CHECK CONSTRAINT [FK_AIMS_PAYMENT_AIMS_GUARANTOR]
GO
/****** Object:  ForeignKey [FK_AIMS_PAYMENT_AIMS_INVOICE]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PAYMENT_AIMS_INVOICE] FOREIGN KEY([INVOICE_ID])
REFERENCES [dbo].[AIMS_INVOICE] ([INVOICE_ID])
GO
ALTER TABLE [dbo].[AIMS_PAYMENT] CHECK CONSTRAINT [FK_AIMS_PAYMENT_AIMS_INVOICE]
GO
/****** Object:  ForeignKey [FK_AIMS_PAYMENT_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PAYMENT]  WITH NOCHECK ADD  CONSTRAINT [FK_AIMS_PAYMENT_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_PAYMENT] CHECK CONSTRAINT [FK_AIMS_PAYMENT_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_PAYMENT_AIMS_PAYMENT_METHOD]    Script Date: 05/11/2021 21:45:11 ******/
ALTER TABLE [dbo].[AIMS_PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_PAYMENT_AIMS_PAYMENT_METHOD] FOREIGN KEY([PAYMENT_METHOD_ID])
REFERENCES [dbo].[AIMS_PAYMENT_METHOD] ([PAYMENT_METHOD_ID])
GO
ALTER TABLE [dbo].[AIMS_PAYMENT] CHECK CONSTRAINT [FK_AIMS_PAYMENT_AIMS_PAYMENT_METHOD]
GO
/****** Object:  ForeignKey [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_INVOICE]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_INVOICE] FOREIGN KEY([INVOICE_ID])
REFERENCES [dbo].[AIMS_INVOICE] ([INVOICE_ID])
GO
ALTER TABLE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENTS] CHECK CONSTRAINT [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_INVOICE]
GO
/****** Object:  ForeignKey [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_MEDICAL_TREATMENT]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_MEDICAL_TREATMENT] FOREIGN KEY([MEDICAL_TREATMENT_ID])
REFERENCES [dbo].[AIMS_MEDICAL_TREATMENT] ([MEDICAL_TREATMENT_ID])
GO
ALTER TABLE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENTS] CHECK CONSTRAINT [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_MEDICAL_TREATMENT]
GO
/****** Object:  ForeignKey [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_SUPPLIER_TYPES]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_SUPPLIER_TYPES] FOREIGN KEY([SERVICE_ID])
REFERENCES [dbo].[AIMS_SUPPLIER_TYPES] ([SUPPLIER_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_INVOICE_MEDICAL_TREATMENTS] CHECK CONSTRAINT [FK_AIMS_INVOICE_MEDICAL_TREATMENTS_AIMS_SUPPLIER_TYPES]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_EWS_EMAIL_SENDER]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_EWS_EMAIL_SENDER] FOREIGN KEY([EMAIL_FROM_ID])
REFERENCES [dbo].[AIMS_EWS_EMAIL_SENDER] ([EMAIL_FROM_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS] CHECK CONSTRAINT [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_EWS_EMAIL_SENDER]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_EWS_PATIENT_ENQUIRY]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_EWS_PATIENT_ENQUIRY] FOREIGN KEY([PATIENT_ENQUIRY_ID])
REFERENCES [dbo].[AIMS_EWS_PATIENT_ENQUIRY] ([PATIENT_ENQUIRY_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS] CHECK CONSTRAINT [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_EWS_PATIENT_ENQUIRY]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_PATIENT]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_PATIENT] FOREIGN KEY([PATIENT_ID])
REFERENCES [dbo].[AIMS_PATIENT] ([PATIENT_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS] CHECK CONSTRAINT [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_PATIENT]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_USERS]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_USERS] FOREIGN KEY([EMAIL_SENT_BY])
REFERENCES [dbo].[AIMS_USERS] ([User_Name])
GO
ALTER TABLE [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS] CHECK CONSTRAINT [FK_AIMS_EWS_PATIENT_SENT_EMAILS_AIMS_USERS]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_OPERATOR_MAILS_AIMS_EWS_OPERATOR_MAILBOX]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_OPERATOR_MAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_OPERATOR_MAILS_AIMS_EWS_OPERATOR_MAILBOX] FOREIGN KEY([OPERATOR_MAILBOX_ID])
REFERENCES [dbo].[AIMS_EWS_OPERATOR_MAILBOX] ([OPERATOR_MAILBOX_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_OPERATOR_MAILS] CHECK CONSTRAINT [FK_AIMS_EWS_OPERATOR_MAILS_AIMS_EWS_OPERATOR_MAILBOX]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_OPERATOR_MAILS_AIMS_EWS_PATIENT_ENQUIRY]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_OPERATOR_MAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_OPERATOR_MAILS_AIMS_EWS_PATIENT_ENQUIRY] FOREIGN KEY([PATIENT_ENQUIRY_ID])
REFERENCES [dbo].[AIMS_EWS_PATIENT_ENQUIRY] ([PATIENT_ENQUIRY_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_OPERATOR_MAILS] CHECK CONSTRAINT [FK_AIMS_EWS_OPERATOR_MAILS_AIMS_EWS_PATIENT_ENQUIRY]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_EMAIL_DOCUMENTS_AIMS_EWS_DOCUMENT_TYPE]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAIL_DOCUMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_EMAIL_DOCUMENTS_AIMS_EWS_DOCUMENT_TYPE] FOREIGN KEY([DOC_TYPE_ID])
REFERENCES [dbo].[AIMS_EWS_DOCUMENT_TYPE] ([DOC_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_EMAIL_DOCUMENTS] CHECK CONSTRAINT [FK_AIMS_EWS_EMAIL_DOCUMENTS_AIMS_EWS_DOCUMENT_TYPE]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_EMAIL_DOCUMENTS_AIMS_EWS_PATIENT_ENQUIRY]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_EMAIL_DOCUMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_EMAIL_DOCUMENTS_AIMS_EWS_PATIENT_ENQUIRY] FOREIGN KEY([PATIENT_ENQUIRY_ID])
REFERENCES [dbo].[AIMS_EWS_PATIENT_ENQUIRY] ([PATIENT_ENQUIRY_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_EMAIL_DOCUMENTS] CHECK CONSTRAINT [FK_AIMS_EWS_EMAIL_DOCUMENTS_AIMS_EWS_PATIENT_ENQUIRY]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_ADMIN_MAILS_AIMS_EWS_OPERATOR_MAILBOX]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_ADMIN_MAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_ADMIN_MAILS_AIMS_EWS_OPERATOR_MAILBOX] FOREIGN KEY([OPERATOR_MAILBOX_ID])
REFERENCES [dbo].[AIMS_EWS_ADMIN_MAILBOX] ([OPERATOR_MAILBOX_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_ADMIN_MAILS] CHECK CONSTRAINT [FK_AIMS_EWS_ADMIN_MAILS_AIMS_EWS_OPERATOR_MAILBOX]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_ADMIN_MAILS_AIMS_EWS_PATIENT_ENQUIRY]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_ADMIN_MAILS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_ADMIN_MAILS_AIMS_EWS_PATIENT_ENQUIRY] FOREIGN KEY([PATIENT_ENQUIRY_ID])
REFERENCES [dbo].[AIMS_EWS_PATIENT_ENQUIRY] ([PATIENT_ENQUIRY_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_ADMIN_MAILS] CHECK CONSTRAINT [FK_AIMS_EWS_ADMIN_MAILS_AIMS_EWS_PATIENT_ENQUIRY]
GO
/****** Object:  ForeignKey [FK_AIMS_SEND_EMAIL_ATTACHMENTS_AIMS_SEND_EMAIL_REQUESTS]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_SEND_EMAIL_ATTACHMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_SEND_EMAIL_ATTACHMENTS_AIMS_SEND_EMAIL_REQUESTS] FOREIGN KEY([EMAIL_REQ_ID])
REFERENCES [dbo].[AIMS_SEND_EMAIL_REQUESTS] ([EMAIL_REQ_ID])
GO
ALTER TABLE [dbo].[AIMS_SEND_EMAIL_ATTACHMENTS] CHECK CONSTRAINT [FK_AIMS_SEND_EMAIL_ATTACHMENTS_AIMS_SEND_EMAIL_REQUESTS]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_SENT_EMAIL_ATTACHMENTS_AIMS_EWS_EMAIL_ATTACHMENT_TYPES]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_SENT_EMAIL_ATTACHMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_SENT_EMAIL_ATTACHMENTS_AIMS_EWS_EMAIL_ATTACHMENT_TYPES] FOREIGN KEY([SENT_EMAIL_ID])
REFERENCES [dbo].[AIMS_EWS_PATIENT_SENT_EMAILS] ([SENT_EMAIL_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_SENT_EMAIL_ATTACHMENTS] CHECK CONSTRAINT [FK_AIMS_EWS_SENT_EMAIL_ATTACHMENTS_AIMS_EWS_EMAIL_ATTACHMENT_TYPES]
GO
/****** Object:  ForeignKey [FK_AIMS_EWS_SENT_EMAIL_ATTACHMENTS_AIMS_EWS_EMAIL_ATTACHMENT_TYPES1]    Script Date: 05/11/2021 21:45:12 ******/
ALTER TABLE [dbo].[AIMS_EWS_SENT_EMAIL_ATTACHMENTS]  WITH CHECK ADD  CONSTRAINT [FK_AIMS_EWS_SENT_EMAIL_ATTACHMENTS_AIMS_EWS_EMAIL_ATTACHMENT_TYPES1] FOREIGN KEY([SENT_EMAIL_ATTACHMENT_TYPE])
REFERENCES [dbo].[AIMS_EWS_EMAIL_ATTACHMENT_TYPES] ([ATTACHMENT_FILE_TYPE_ID])
GO
ALTER TABLE [dbo].[AIMS_EWS_SENT_EMAIL_ATTACHMENTS] CHECK CONSTRAINT [FK_AIMS_EWS_SENT_EMAIL_ATTACHMENTS_AIMS_EWS_EMAIL_ATTACHMENT_TYPES1]
GO
