using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Legacy.Models;

namespace Legacy.DAL
{
    public class PatientDAL
    {
        public List<PatientModel> GetAllPatients()
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients =  db.Query<PatientModel>("select top 20 *  from AIMS_PATIENT_VW ORDER BY PATIENT_FILE_NO").ToList();
                return patients;
            }
        }

        public PatientModel GetPatientDetails(string patientFileNo)
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();

                //var procedure = "[AIMS_PATIENT_GET]";
                //var values = new { @PatientFileNo = patientFileNo, @EnquiryYN = "N", @UserSignedOn =""};

                //var results = db.QueryFirstOrDefault<PatientModel>(procedure, values, commandType: CommandType.StoredProcedure);
                //return results;

                string sqlString = @"select *      
                                         from aims_patient as ap
                                        left outer join aims_companies  as ac  on ap.company_id = ac.company_id
                                        left outer join aims_address  as aa on ap.address_id = aa.address_id
                                        left outer join aims_country  as acc on aa.country_id = acc.country_id
                                        left outer join aims_guarantor   as ag on ap.guarantor_id = ag.guarantor_id
                                        left outer join aims_title     as atl on ap.title_id = atl.title_id
                                        left outer join aims_supplier  as supp on ap.SUPPLIER_ID = supp.SUPPLIER_ID 
                                        where
                                       (ap.patient_file_no = @PatientFileNo ) ";

                var procedure = sqlString;
                var values = new { @PatientFileNo = patientFileNo };
                var results = db.QueryFirstOrDefault<PatientModel>(procedure, values, commandType: CommandType.Text);
                return results;
            }
        }

        public List<PatientModel> GetPatientDetailsBySurname(string patientSurname)
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = $"select a.*, b.guarantor_name from aims_patient a inner join aims_guarantor b on b.guarantor_id = a.guarantor_id and PATIENT_LAST_NAME like '%{patientSurname}%' order by a.CREATION_DTTM desc";
                var values = new {  };

                var results = db.Query<PatientModel>(procedure, values, commandType: CommandType.Text).ToList();
                return results;
            }
        }

        public List<PatientModel> GetPatientFileNo(string patientFileNo)
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "select * from aims_patient where  PATIENT_FILE_NO = @PatientFileNo";
                var values = new { @PatientFileNo = patientFileNo };

                var results = db.Query<PatientModel>(procedure, values, commandType: CommandType.Text).ToList();
                return results;
            }
        }

        public List<PatientModel> GetPatientFileByReferenceNo(string referenceNo)
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = $"select * from aims_patient a where guarantor_ref_no like '%{referenceNo}%'";
                var values = new { @PatientFileNo = referenceNo };

                var results = db.Query<PatientModel>(procedure, values, commandType: CommandType.Text).ToList();
                return results;
            }
        }

        public List<PatientModel> GetPatientDetails(int filterId, string filterName, string cancelled, string sentToAdmin, string pending, string closed)
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();

                switch (filterName)
                {
                    case "Guarantor":
                        return db.Query<PatientModel>($"select * from AIMS_PATIENT_VW a where a.GUARANTOR_ID = {filterId} and a.SENT_TO_ADMIN = '{sentToAdmin}' and a.CANCELLED = '{cancelled}' and a.PATIENT_FILE_ACTIVE_YN='{closed}' and a.PENDING='{pending}'  order by PATIENT_NAME,(CAST (RTRIM(LTRIM(substring (patient_file_no, 1, 2))) AS NUMERIC) + 0) desc,(CAST (RTRIM(LTRIM(substring (patient_file_no, 4, 5))) AS NUMERIC) + 0) desc").ToList();
                        break;
                    case "Hospital":
                        return db.Query<PatientModel>($"select * from AIMS_PATIENT_VW a where a.SUPPLIER_ID = {filterId}  and a.SENT_TO_ADMIN = '{sentToAdmin}' and a.CANCELLED = '{cancelled}' and a.PATIENT_FILE_ACTIVE_YN='{closed}' and a.PENDING='{pending}' order by PATIENT_NAME,(CAST (RTRIM(LTRIM(substring (patient_file_no, 1, 2))) AS NUMERIC) + 0) desc,(CAST (RTRIM(LTRIM(substring (patient_file_no, 4, 5))) AS NUMERIC) + 0) desc").ToList();
                        break;
                    default:
                        return db.Query<PatientModel>($"select * from AIMS_PATIENT_VW a where a.SENT_TO_ADMIN = '{sentToAdmin}' and a.CANCELLED = '{cancelled}' and a.PATIENT_FILE_ACTIVE_YN='{closed}' and a.PENDING='{pending}'  order by PATIENT_NAME,(CAST (RTRIM(LTRIM(substring (patient_file_no, 1, 2))) AS NUMERIC) + 0) desc,(CAST (RTRIM(LTRIM(substring (patient_file_no, 4, 5))) AS NUMERIC) + 0) desc").ToList();
                        break;
                }

                //var patients = db.QueryFirst<PatientModel>($"select * from aims_patient where patient_file_no = '{filterName}'  order BY PATIENT_FILE_NO");
                //return patients;
            }
        }


        public List<PatientModel> GetPatientDetails(int filterId, string filterName)
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();

                switch (filterName)
                {
                    case "Guarantor":
                        return db.Query<PatientModel>($"select * from AIMS_PATIENT_VW a where a.GUARANTOR_ID = {filterId}  order by PATIENT_NAME,(CAST (RTRIM(LTRIM(substring (patient_file_no, 1, 2))) AS NUMERIC) + 0) desc,(CAST (RTRIM(LTRIM(substring (patient_file_no, 4, 5))) AS NUMERIC) + 0) desc").ToList();
                        break;
                    case "Hospital":
                        return db.Query<PatientModel>($"select * from AIMS_PATIENT_VW a where a.SUPPLIER_ID = {filterId}  order by PATIENT_NAME,(CAST (RTRIM(LTRIM(substring (patient_file_no, 1, 2))) AS NUMERIC) + 0) desc,(CAST (RTRIM(LTRIM(substring (patient_file_no, 4, 5))) AS NUMERIC) + 0) desc").ToList();
                        break;
                    default:
                        return db.Query<PatientModel>($"select * from AIMS_PATIENT_VW a  order by PATIENT_NAME,(CAST (RTRIM(LTRIM(substring (patient_file_no, 1, 2))) AS NUMERIC) + 0) desc,(CAST (RTRIM(LTRIM(substring (patient_file_no, 4, 5))) AS NUMERIC) + 0) desc").ToList();
                        break;
                }

                //var patients = db.QueryFirst<PatientModel>($"select * from aims_patient where patient_file_no = '{filterName}'  order BY PATIENT_FILE_NO");
                //return patients;
            }
        }

        public List<PatientFileAudit> GetPatientDetailsAudit(string patientFileNo)
        {
            PatientFileAudit allPatients = new PatientFileAudit();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();

                var procedure = "[AIMS_PATIENT_FILE_AUDIT_GET_NEW]";
                var values = new { @PATIENT_FILE_NO = patientFileNo };

                var results = db.Query<PatientFileAudit>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                return results;
                // var patients = db.QueryFirst<PatientModel>($"select * from aims_patient where patient_file_no = '{patientFileNo}'  order BY PATIENT_FILE_NO");
            }
        }

        public List<Notes> GetPatientNotes(string patientFileNo, string noteType)
        {
            Notes allPatients = new Notes();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "[AIMS_PATIENT_GET_NOTES]";
                var values = new { @PatientFileNo = patientFileNo, @NoteTypeCD = "'" + noteType + "'"};
                var results = db.Query<Notes>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                return results;
            }
        }
    }
}
