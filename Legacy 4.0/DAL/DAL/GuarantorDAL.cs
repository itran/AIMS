using Legacy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Legacy.DAL
{
    public class GuarantorDAL
    {
        public List<GuarantorModel> GetAllGuarantor()
        {
            GuarantorModel allPatients = new GuarantorModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients = db.Query<GuarantorModel>("select * from AIMS_GUARANTOR_VW ORDER BY guarantor_name").ToList();
                return patients;
            }
        }

        public GuarantorModel GetPatientDetails(string guarantorId)
        {
            GuarantorModel allPatients = new GuarantorModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients = db.QueryFirst($"select * from AIMS_GUARANTOR where guarantor_id = {guarantorId} ORDER BY guarantor_name");
                return patients;
            }
        }
    }
}
