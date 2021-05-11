using System.Collections.Generic;
using Legacy.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace Legacy.DAL
{
    public class UserDAL 
    {
        private readonly string SQL_INSERT_USER =
            @"INSERT INTO aims_users
            (User_Name,
            User_Full_Name,
            User_Email,
            User_Phone,
            User_Fax,
            User_Active_YN,
            SIGNATURE_PATH,
            JOB_TITLE_ID,
            DEPARTMENT_ID,
            DATE_OF_BIRTH
            ) VALUES (
            @User_Name,
            @User_Full_Name,
            @User_Email,
            @User_Phone,
            @User_Fax,
            @User_Active_YN,
            @SIGNATURE_PATH,
            @JOB_TITLE_ID,
            @DEPARTMENT_ID,
            @DATE_OF_BIRTH
            )";

        private readonly string SQL_UPDATE_USER =
            @"UPDATE aims_users set 
             User_Full_Name = @User_Full_Name,
             User_Email = @User_Email,
             User_Phone = @User_Phone,
             User_Fax = @User_Fax,
             User_Active_YN = @User_Active_YN,
             SIGNATURE_PATH = @SIGNATURE_PATH,
             JOB_TITLE_ID = @JOB_TITLE_ID,
             DEPARTMENT_ID = @DEPARTMENT_ID,
             DATE_OF_BIRTH = @DATE_OF_BIRTH
             where User_Name = @User_Name";

        private readonly string SQL_DEACTIvATE_USER = "";

        #region User-related-methods
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> allUsers = new List<UserModel>();
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                return db.Query<UserModel>("select * from aims_users").ToList();
            }
        }

        public UserModel GetUserDetails(string userName)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                return db.QueryFirst<UserModel>($"select * from aims_users where user_name = '{userName}'");
            }
        }

        public bool UpdateUser(UserModel userModel)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                return db.Execute(SQL_UPDATE_USER, userModel) > 0;
            }
        }

        public bool AddUser(UserModel userModel)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                return db.Execute(SQL_INSERT_USER, userModel) > 0;
            }
        }

        public bool DeActivateUser(string userName)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                db.Execute($"delete from aims_user_role where user_name = '{userName}'");
                db.Execute($"update AIMS_USERS set User_Active_YN = 'N' where user_name= '{userName}'");
                return true;
            }
        }
        #endregion

        #region user-role-related-methods
        public bool AddUserRole(string userName, string role)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                return db.Execute($"insert into aims_user_role values('{userName}', '{role}')") > 0;
            }
        }

        public IEnumerable<UserRole> GetUserRoles(string userName)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                return db.Query<UserRole>($"select * from aims_users where user_name = '{userName}'");
            }
        }
        #endregion
    }
}
