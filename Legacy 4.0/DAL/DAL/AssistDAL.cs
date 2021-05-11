using Legacy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Legacy.DAL
{
    public class AssistDAL
    {
        public List<AssistModel> GetAllAssists()
        {
            AssistModel allPatients = new AssistModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients = db.Query<AssistModel>("select * from AIMS_ASSIST_TYPE ORDER BY ASSIST_TYPE_DESC").ToList();
                return patients;
            }
        }

        public AssistModel GetAssistDetails(string assistTypeId)
        {
            AssistModel allPatients = new AssistModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients = db.QueryFirst($"select * from AIMS_ASSIST_TYPE where ASSIST_TYPE_ID = {assistTypeId} ORDER BY ASSIST_TYPE_DESC");
                return patients;
            }
        }
    }
}
