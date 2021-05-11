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
    public class TaskDAL
    {
        public List<TaskModel> GetAllServiceProviders()
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients = db.Query<TaskModel>("select top 20 *  from AIMS_PATIENT_VW ORDER BY PATIENT_FILE_NO").ToList();
                return patients;
            }
        }

        public List<TaskModel> GetPatientTasks(string patientFileNo)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();

                var procedure = "[AIMS_GET_PATIENT_FILE_TASKS]";
                var values = new { @PatientSubFileID = patientFileNo, @TaskStatus = "Cancelled" };

                var results = db.Query<TaskModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                return results;
            }
        }

        public List<TaskModel> GetPatientTasks(string patientFileNo, string taskStatus)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();

                var procedure = "[AIMS_GET_PATIENT_FILE_TASKS]";
                var values = new { @PatientSubFileID = patientFileNo, @TaskStatus = taskStatus };
                var results = db.Query<TaskModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                return results;
            }
        }

        public TaskModel GetTaskDetails(string taskId)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "[AIMS_TASK_GET]";
                var values = new { @PatientFileTaskID = taskId };
                var results = db.QueryFirstOrDefault<TaskModel>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
        }

        public List<TaskModel> GetAllTasks()
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();

                var procedure = "Select TASK_ID, TASK_DESC from AIMS_TASKS where task_active_yn = 'Y'";
                var values = new { };

                var results = db.Query<TaskModel>(procedure, values, commandType: CommandType.Text).ToList();
                return results;
            }
        }
    }
}
