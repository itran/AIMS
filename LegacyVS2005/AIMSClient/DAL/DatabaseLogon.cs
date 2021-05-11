using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AIMS.DAL
{
    public class DatabaseLogon
    {
        private string connString = System.Configuration.ConfigurationSettings.AppSettings["ConnectString"];
        
        public SqlConnection GetConnection()
        {            
            SqlConnection oConn;
            try 
	        {	        
        	   oConn = new SqlConnection(connString);               
               oConn.Open();
	        }
	        catch (Exception)
	        {
              throw new System.Exception("*Could not connect to AIMS database");
	        }
            return oConn;
        } 
    }
}
