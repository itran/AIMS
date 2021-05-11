using System;
using System.Collections.Generic;
using Legacy.Models; 

namespace Legacy.CORE
{
    public class CommonFunctions
    {

        public CommonFunctions(string connectionString)
        {

        }

        public CommonFunctions()
        {

        }
        public List<User> GetAllUsers()
        {
            
            DAL.Dapper allUsers = new DAL.Dapper();
           var users = allUsers.GetAllUsers();
           return users;
        }
        public bool SendEmail()
        {
            return true;
        }
    }
}
