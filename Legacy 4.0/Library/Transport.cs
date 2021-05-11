using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.Library
{
    public class Transport
    {
        public List<TransportModel> GetTransports()
        {
            TransportDAL dapper = new TransportDAL();
            List<TransportModel> allUsers = dapper.GetAllTransports ();
            return allUsers;
        }
    }
}
