using Legacy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Legacy.DAL
{
    public class RMRDAL
    {
        public List<RMRModel> GetAllRMRTypes()
        {
            RMRModel allPatients = new RMRModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var rmrs = db.Query<RMRModel>("select * from AIMS_RMR_TYPES ORDER BY rmr_Type_desc").ToList();
                return rmrs;
            }
        }

        public RMRModel GetRMRDetails(int rmrTypeId)
        {
            RMRModel allPatients = new RMRModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var rmrs = db.QueryFirst($"select * from AIMS_RMR_TYPES where rmr_Type_Id = {rmrTypeId} ORDER BY rmr_Type_desc");
                return rmrs;
            }
        }
    }
}
