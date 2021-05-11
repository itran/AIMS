using Legacy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Legacy.DAL
{
    public class EvacuationDAL
    {
        public List<EvacuationModel> GetAllEvacuations()
        {
            EvacuationModel allPatients = new EvacuationModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var rmrs = db.Query<EvacuationModel>("select * from AIMS_EVACUATION_TYPES ORDER BY EVACUATION_TYPE_DESC").ToList();
                return rmrs;
            }
        }

        public EvacuationModel GetEvacuationDetails(int evacuationTypeId)
        {
            EvacuationModel allPatients = new EvacuationModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var rmrs = db.QueryFirst($"select * from AIMS_EVACUATION_TYPES where EVACUATION_TYPE_ID = {evacuationTypeId} ORDER BY EVACUATION_TYPE_DESC");
                return rmrs;
            }
        }
    }
}
