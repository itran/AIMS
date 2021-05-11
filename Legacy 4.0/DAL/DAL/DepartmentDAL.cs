using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Legacy.Models;
using System.Linq;

namespace Legacy.DAL
{
    public class DepartmentDAL
    {
        public List<DepartmentModel> GetAllDepartments()
        {
            IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True");
            db.Open();
            return db.Query<DepartmentModel>("select * from aims_department").ToList();
        }

        public IEnumerable<DepartmentModel> GetDepartmentsDetails(int departmentId)
        {
            IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True");
            db.Open();
            return db.Query<DepartmentModel>($"select * from aims_department where department_id = { departmentId }");
        }        
        public List<UserModel> GetDepartmentUsers(int departmentId)
        {
            string sqlString = $"select a.*, b.DEPARTMENT_NAME, c.JOB_TITLE_DESC from AIMS_USERS a left outer join AIMS_DEPARTMENT b on b.DEPARTMENT_ID = a.DEPARTMENT_ID left outer join AIMS_JOB_TITLE c on c.JOB_TITLE_ID = a.JOB_TITLE_ID where a.DEPARTMENT_ID = { departmentId }";
            IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True");
            db.Open();
            return db.Query<UserModel>(sqlString).ToList();
        }
    }
}
