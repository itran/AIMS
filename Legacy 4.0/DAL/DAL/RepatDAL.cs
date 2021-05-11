using Legacy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Legacy.DAL
{
    public class RepatDAL
    {
        public List<RepatModel> GetAllRepats()
        {
            RepatModel allPatients = new RepatModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var rmrs = db.Query<RepatModel>("select * from AIMS_REPAT_TYPE ORDER BY REPAT_TYPE_DESC").ToList();
                return rmrs;
            }
        }

        public RepatModel GetRetatDetails(int repatId)
        {
            RepatModel allPatients = new RepatModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var rmrs = db.QueryFirst($"select * from AIMS_REPAT_TYPE where REPAT_TYPE_ID = {repatId} ORDER BY REPAT_TYPE_DESC");
                return rmrs;
            }
        }
    }
}
