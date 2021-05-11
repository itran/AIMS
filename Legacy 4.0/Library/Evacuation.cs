using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.Library
{
    public class Evacuation
    {
        public List<EvacuationModel> GetEvacuations()
        {
            EvacuationDAL dapper = new EvacuationDAL();
            List<EvacuationModel> allUsers = dapper.GetAllEvacuations();
            return allUsers;
        }
    }
}
