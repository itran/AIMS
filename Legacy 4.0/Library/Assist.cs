using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.Library
{
    public class Assist
    {
        public List<AssistModel> GetAssistTypes()
        {
            AssistDAL dapper = new AssistDAL();
            List<AssistModel> allUsers = dapper.GetAllAssists();
            return allUsers;
        }
    }
}
