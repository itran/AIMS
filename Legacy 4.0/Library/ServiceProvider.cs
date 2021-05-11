using Legacy;
using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Legacy.Library.FilterEnum;

namespace Legacy.Library
{
    public class ServiceProvider
    {
        public List<ServiceProviderModel> GetPatientServiceProviders(string patientId)
        {
            ServiceProviderDAL dapper = new ServiceProviderDAL();
            List<ServiceProviderModel> patientEmail = dapper.GetPatientServiceProviders(patientId);
            return patientEmail;
        }

        public List<ServiceProviderModel> GetAllServiceProviders()
        {
            ServiceProviderDAL dapper = new ServiceProviderDAL();
            List<ServiceProviderModel> patientEmail = dapper.GetAllServiceProviders();
            return patientEmail;
        }

        public ServiceProviderModel GetServiceProvider(string serviceProviderId)
        {
            ServiceProviderDAL dapper = new ServiceProviderDAL();
            ServiceProviderModel patientEmail = dapper.GetServiceProvider(serviceProviderId);
            return patientEmail;
        }
    }
}