using System.Collections.Generic;
using Legacy.DAL;
using Legacy.Models;

namespace Legacy.Library
{
    public class User
    {
        public List<UserModel> GetAllUsers()
        {
            UserDAL dapper = new UserDAL();
            List<UserModel> allUsers = dapper.GetAllUsers();
            return allUsers;
        }

        public bool AddUser(UserModel userModel)
        {
            UserDAL dapper = new UserDAL();
            return dapper.AddUser(userModel);
        }

        public bool UpdateUser(UserModel userModel)
        {
            UserDAL dapper = new UserDAL();
            return dapper.UpdateUser(userModel);
        }

        public bool DeActivateUser(string userName)
        {
            UserDAL dapper = new UserDAL();
            return dapper.DeActivateUser(userName);
        }

        public bool AddUserRole(string userName, string role)
        {
            UserDAL dapper = new UserDAL();
            return dapper.AddUserRole(userName, role);
        }

        public IEnumerable<UserRole> GetUserRoles(string userName)
        {
            UserDAL dapper = new UserDAL();
            return dapper.GetUserRoles(userName);
        }
    }
}