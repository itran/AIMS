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
    public class ServiceProviderDAL
    {
        public List<ServiceProviderModel> GetAllServiceProviders()
        {
            PatientModel allPatients = new PatientModel();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var patients = db.Query<ServiceProviderModel>("select top 20 *  from AIMS_PATIENT_VW ORDER BY PATIENT_FILE_NO").ToList();
                return patients;
            }
        }

        public List<ServiceProviderModel> GetPatientServiceProviders(string patientId)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();

                var procedure = "[AIMS_PATIENT_SERVICE_PROVIDERS_GET]";
                var values = new { @PatientID = patientId};

                var results = db.Query<ServiceProviderModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                return results;
            }
        }

        public ServiceProviderModel GetServiceProvider(string serviceProviderId)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                var procedure = "[AIMS_PATIENT_SERVICE_PROVIDER_GET]";
                var values = new { @ServiceProviderID = serviceProviderId };
                var results = db.QueryFirstOrDefault<ServiceProviderModel>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
