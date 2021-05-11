using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL
{
    public class DALBaseMethods
    {
        /// <summary>
        /// Generic Method used to Fill a datatable
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DBName"></param>
        /// <param name="strCommandText"></param>
        /// <returns></returns>
        public DataTable FillDataTable(string strCommandText)
        {
            //Get a connection object
            DatabaseLogon oLogon = new DatabaseLogon();
            SqlConnection oConn = oLogon.GetConnection();
           

            //DataAccess Components
            SqlCommand cmdSQL = new SqlCommand(strCommandText,oConn);
            SqlDataAdapter daTable = new SqlDataAdapter(cmdSQL);
            DataTable tbl = new DataTable();

            daTable.Fill(tbl);
            
            //Object Cleanup
            oConn.Close();

            return tbl;
        }

        /// <summary>
        /// Generic Method used to execute update/delete statements
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DBName"></param>
        /// <param name="strCommandText"></param>
        /// <returns></returns>
        public int ExcecuteNonQuery(string strCommandText)
        {
            //Get a connection object
           DatabaseLogon oLogon = new DatabaseLogon();
            SqlConnection oConn = oLogon.GetConnection();
            //DataAccess Component
            SqlCommand cmdSQL = new SqlCommand(strCommandText,oConn);
            try
            {
                return cmdSQL.ExecuteNonQuery();
            }
            finally
            {
                oConn.Close();
            }
          
        }

    }

  
}
