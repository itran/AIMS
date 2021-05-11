using Legacy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Legacy.DAL
{
    public class TransportDAL
    {
        public List<TransportModel> GetAllTransports()
        {
            TransportModel allPatients = new TransportModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients = db.Query<TransportModel>("select * from AIMS_TRANSPORT_TYPE ORDER BY TRANSPORT_TYPE_DESC").ToList();
                return patients;
            }
        }

        public TransportModel GetTransportDetails(string transportId)
        {
            TransportModel allPatients = new TransportModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients = db.QueryFirst($"select * from AIMS_TRANSPORT_TYPE where TRANSPORT_TYPE_ID = {transportId} ORDER BY TRANSPORT_TYPE_DESC");
                return patients;
            }
        }
    }
}
