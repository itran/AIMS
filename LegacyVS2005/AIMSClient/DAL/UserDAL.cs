using System;
using System.Collections.Generic;
using System.Text;
using AIMS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL
{
    public class UserDAL : DataServiceBase
    {
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public UserDAL() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public UserDAL(IDbTransaction txn) : base(txn) { }

        public DataTable GetUserRights(string userName, string passWord)
        {
            DALBaseMethods clsBase = new DALBaseMethods();
            DataTable tbl = new DataTable();
            string sql = string.Empty;

            try
            {
                sql = "select * from aims_users where first_name = '" + userName + "' and last_name = '" + passWord + "'";
                tbl = clsBase.FillDataTable(sql);
            }
            catch (Exception ex)
            {
             
                throw ex;
            }

            return tbl;
        }

        public DataSet GetUserDetails(string UserName)
        {
            return ExecuteDataSet("[AIMS_USER_GET]",
                CreateParameter("@UserName", SqlDbType.VarChar, UserName));
        }

        public DataTable GetUserDetail(string UserName)
        {
            return ExecuteDataTable("[AIMS_USER_GET]",
                CreateParameter("@UserName", SqlDbType.VarChar, UserName));
        }
        public DataTable GetUserRestrictions(string UserName)
        {
            return ExecuteDataTable("[AIMS_USER_RESTRICTIONS]",
                CreateParameter("@UserName", SqlDbType.VarChar, UserName));
        }

        public DataTable GetUserMenuAccess(string UserName)
        {
            return ExecuteDataTable("[AIMS_USER_MENU_RESTRICTIONS]",
                CreateParameter("@UserName", SqlDbType.VarChar, UserName));
        }

        public DataTable GetAllRestrictions(string UserName)
        {
            return ExecuteDataTable("[AIMS_ALL_RESTRICTIONS]",
                CreateParameter("@UserName", SqlDbType.VarChar, UserName));
        }

        public bool SaveUserPassword(string userName, string Password, string PasswordHint, string PasswordHintAnswer)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "AIMS_USER_PASSWORD_SAVE",
            CreateParameter("@UserName", SqlDbType.VarChar, userName),
            CreateParameter("@PassWord", SqlDbType.VarChar, Password),
            CreateParameter("@PasswordHint", SqlDbType.VarChar, PasswordHint),
            CreateParameter("@PasswordHintAnswer", SqlDbType.VarChar, PasswordHintAnswer));

            cmd.Dispose();
            return true;
        }
        
    }
}
