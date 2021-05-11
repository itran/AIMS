using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.Library
{
    public class RMR
    {
        public List<RMRModel> GetRMRs()
        {
            RMRDAL dapper = new RMRDAL();
            List<RMRModel> allUsers = dapper.GetAllRMRTypes();
            return allUsers;
        }
    }
}
