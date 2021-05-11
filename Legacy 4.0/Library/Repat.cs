using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.Library
{
    public class Repat
    {
        public List<RepatModel> GetRepats()
        {
            RepatDAL dapper = new RepatDAL();
            List<RepatModel> allUsers = dapper.GetAllRepats();
            return allUsers;
        }
    }
}
