using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Legacy.Models;
using System.Linq;

namespace Legacy.DAL
{
    public class RoleDAL
    {
        private readonly string SQL_INSERT_ROLE =
            @"INSERT INTO aims_roles
            (
            ROLE_CD,
            ROLE_CD_ACTIVE_YN,

            )
     VALUES (
            :ROLE_CD,
            :ROLE_CD_ACTIVE_YN
            )";

        public List<RoleModel> GetAllRoles()
        {
            IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True");
            db.Open();
            return db.Query<RoleModel>($"select * from aims_roles").ToList();
        }

        public bool AddRole(RoleModel userModel)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                return db.Execute(SQL_INSERT_ROLE, userModel) > 0;
            }
        }

        public bool AddUserRole(RoleModel userModel)
        {
            using (IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True"))
            {
                db.Open();
                return db.Execute(SQL_INSERT_ROLE, userModel) > 0;
            }
        }
    }
}
