using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EWS.AIMS.DAL
{
    public class DataServiceBase
    {

        ////////////////////////////////////////////////////////////////////////
        // Fields
        ////////////////////////////////////////////////////////////////////////
        private bool _isOwner = false;   //True if service owns the transaction        
        private SqlTransaction _txn;     //Reference to the current transaction


        ////////////////////////////////////////////////////////////////////////
        // Properties 
        ////////////////////////////////////////////////////////////////////////
        public IDbTransaction Txn
        {
            get { return (IDbTransaction)_txn; }
            set { _txn = (SqlTransaction)value; }
        }


        ////////////////////////////////////////////////////////////////////////
        // Constructors
        ////////////////////////////////////////////////////////////////////////

        public DataServiceBase() : this(null) { }

        public DataServiceBase(IDbTransaction txn)
        {
            if (txn == null)
            {
                _isOwner = true;
            }
            else
            {
                _txn = (SqlTransaction)txn;
                _isOwner = false;
            }
        }
        ////////////////////////////////////////////////////////////////////////
        //                Connection and Transaction Methods                  //
        ////////////////////////////////////////////////////////////////////////
        protected static string GetConnectionString()
        {
            //return @"Server=208.101.43.58, 1444;Database=chumani;User ID=chumani;Password=chumani";            
            //return _connectionString;

            //return @"Data Source=ITQ-BRIAN\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=AIMS";
            //return @"Data Source=ITQ-BRIAN\BRIAN;Integrated Security=SSPI;Initial Catalog=AIMS_UPDATES";
            //return @"Data Source=JADE-PC\SQLEXPRESS;Database=AIMS_UAT;Data Source=JADE-PC\SQLEXPRESS;Integrated Security=SSPI";
            //return @"Data Source=10.0.0.15;Database=AIMS;User ID=aims;Password=aims1**";
            //return @"Data Source=AIMS-SYSTEMS02\JUPITER;Database=AIMS;User ID=aims;Password=Aims2016";
            //_connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectString"].ToString();
            //_connectionString = @"Server=LAPTOP-VM3C2I5J\WIGANPIER;Database=AIMS;Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Integrated Security=SSPI";
            _connectionString = ConfigurationSettings.AppSettings.Get("ConnectString");
            return _connectionString;
            //return @"Server =AIMS-SYSTEMS\JUPITER;Database=AIMS;Data Source=AIMS-SYSTEMS\JUPITER;Integrated Security=SSPI";
        }

        private static string _connectionString = "";
        public static string DBServiceConnectionString { get { return _connectionString; } set { _connectionString = value; } }

        public static IDbTransaction BeginTransaction()
        {
            SqlConnection txnConnection = new SqlConnection(GetConnectionString());
            txnConnection.Open();
            return txnConnection.BeginTransaction();
        }

        ////////////////////////////////////////////////////////////////////////
        // ExecuteDataSet Methods
        ////////////////////////////////////////////////////////////////////////
        public DataSet ExecuteDataSet(string procName,
            params IDataParameter[] procParams)
        {
            SqlCommand cmd;
            return ExecuteDataSet(out cmd, procName, procParams);
        }
        ////////////////////////////////////////////////////////////////////////
        // ExecuteDataTable Methods
        ////////////////////////////////////////////////////////////////////////
        public DataTable ExecuteDataTable(string procName,
            params IDataParameter[] procParams)
        {
            SqlCommand cmd;
            return ExecuteDataTable(out cmd, procName, procParams);
        }
        public DataSet ExecuteDataSet(out SqlCommand cmd, string procName,
            params IDataParameter[] procParams)
        {
            SqlConnection cnx = null;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = null;

            try
            {
                //Setup command object
                cmd = new SqlCommand(procName);
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        cmd.Parameters.Add(procParams[index]);
                    }
                }
                da.SelectCommand = (SqlCommand)cmd;

                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new SqlConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }

                //Fill the dataset
                da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                //if (_isOwner)
                //{
                if (cnx.State == ConnectionState.Open )
                {
                    cnx.Close();
                }
                cnx.Dispose(); //Implicitly calls cnx.Close()
                //}
            }
            return ds;
        }

        ////////////////////////////////////////////////////////////////////////
        // ExecuteNonQuery Methods
        ////////////////////////////////////////////////////////////////////////
        protected void ExecuteNonQuery(string procName,
            params IDataParameter[] procParams)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, procName, procParams);
        }

        ////////////////////////////////////////////////////////////////////////
        // Execute Data Reader
        ////////////////////////////////////////////////////////////////////////
        protected SqlDataReader ReturnReader(string StrProc, string[] Parameter)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(GetConnectionString());
                cnx.Open();

                SqlCommand cmd = new SqlCommand();
                int tmpCounter;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StrProc;
                cmd.Connection = cnx;

                SqlCommandBuilder.DeriveParameters(cmd);


                if (Parameter != null)
                {

                    tmpCounter = 1;
                    foreach (string items in Parameter)
                    {
                        if (items != null)
                        {
                            cmd.Parameters[tmpCounter].Value = items;
                            tmpCounter = tmpCounter + 1;
                        }
                    }
                }

                return cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ExecuteNonQuery(out SqlCommand cmd, string procName,
            params IDataParameter[] procParams)
        {
            //Method variables
            SqlConnection cnx = null;
            cmd = null;  //Avoids "Use of unassigned variable" compiler error

            try
            {
                //Setup command object
                cmd = new SqlCommand(procName);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int index = 0; index < procParams.Length; index++)
                {
                    cmd.Parameters.Add(procParams[index]);
                }

                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new SqlConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }

                //Execute the command
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEX)
            {
                throw sqlEX;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //if (_isOwner)
                //{
                if (cnx.State == ConnectionState.Open)
                cnx.Close();
		 
                cnx.Dispose(); //Implicitly calls cnx.Close()
                //}
                if (cmd != null) cmd.Dispose();
            }
        }
        ////////////////////////////////////////////////////////////////////////
        // CreateParameter Methods
        ////////////////////////////////////////////////////////////////////////
        protected SqlParameter CreateParameter(string paramName,
            SqlDbType paramType, object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramType);

            if (paramValue != DBNull.Value)
            {
                switch (paramType)
                {
                    case SqlDbType.VarChar:
                    case SqlDbType.NVarChar:
                    case SqlDbType.Char:
                    case SqlDbType.NChar:
                    case SqlDbType.Text:
                        paramValue = CheckParamValue((string)paramValue);
                        break;
                    case SqlDbType.DateTime:
                        paramValue = CheckParamValue((DateTime)paramValue);
                        break;
                    case SqlDbType.Int:
                        paramValue = CheckParamValue((int)paramValue);
                        break;
                    case SqlDbType.UniqueIdentifier:
                        paramValue = CheckParamValue(GetGuid(paramValue));
                        break;
                    case SqlDbType.Bit:
                        if (paramValue is bool) paramValue = (int)((bool)paramValue ? 1 : 0);
                        if ((int)paramValue < 0 || (int)paramValue > 1) paramValue = Constants.NullInt;
                        paramValue = CheckParamValue((int)paramValue);
                        break;
                    case SqlDbType.Float:
                        paramValue = CheckParamValue(Convert.ToSingle(paramValue));
                        break;
                    case SqlDbType.Decimal:
                        paramValue = CheckParamValue((decimal)paramValue);
                        break;
                }
            }
            param.Value = paramValue;
            return param;
        }

        public SqlParameter CreateParameter(string paramName, SqlDbType paramType, ParameterDirection direction)
        {
            SqlParameter returnVal = CreateParameter(paramName, paramType, DBNull.Value);
            returnVal.Direction = direction;
            return returnVal;
        }
        public SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, ParameterDirection direction)
        {
            SqlParameter returnVal = CreateParameter(paramName, paramType, paramValue);
            returnVal.Direction = direction;
            return returnVal;
        }
        public SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, int size)
        {
            SqlParameter returnVal = CreateParameter(paramName, paramType, paramValue);
            returnVal.Size = size;
            return returnVal;
        }
        public SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, int size, ParameterDirection direction)
        {
            SqlParameter returnVal = CreateParameter(paramName, paramType, paramValue);
            returnVal.Direction = direction;
            returnVal.Size = size;
            return returnVal;
        }

        public SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, int size, byte precision)
        {
            SqlParameter returnVal = CreateParameter(paramName, paramType, paramValue);
            returnVal.Size = size;
            ((SqlParameter)returnVal).Precision = precision;
            return returnVal;
        }

        public SqlParameter CreateParameter(string paramName, SqlDbType paramType, object paramValue, int size, byte precision, ParameterDirection direction)
        {
            SqlParameter returnVal = CreateParameter(paramName, paramType, paramValue);
            returnVal.Direction = direction;
            returnVal.Size = size;
            returnVal.Precision = precision;
            return returnVal;
        }

        ////////////////////////////////////////////////////////////////////////
        // CheckParamValue Methods
        ////////////////////////////////////////////////////////////////////////
        protected Guid GetGuid(object value)
        {
            Guid returnVal = Constants.NullGuid;
            if (value is string)
            {
                returnVal = new Guid((string)value);
            }
            else if (value is Guid)
            {
                returnVal = (Guid)value;
            }
            return returnVal;
        }
        protected object CheckParamValue(string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
        protected object CheckParamValue(Guid paramValue)
        {
            if (paramValue.Equals(Constants.NullGuid))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
        protected object CheckParamValue(DateTime paramValue)
        {
            if (paramValue.Equals(Constants.NullDateTime))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
        protected object CheckParamValue(double paramValue)
        {
            if (paramValue.Equals(Constants.NullDouble))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
        protected object CheckParamValue(float paramValue)
        {
            if (paramValue.Equals(Constants.NullFloat))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
        protected object CheckParamValue(Decimal paramValue)
        {
            if (paramValue.Equals(Constants.NullDecimal))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
        protected object CheckParamValue(int paramValue)
        {
            if (paramValue.Equals(Constants.NullInt))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
        public DataTable ExecuteDataTable(out SqlCommand cmd, string procName, params IDataParameter[] procParams)
        {
            SqlConnection cnx = null;
            DataSet ds = new DataSet();
            DataTable dtTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = null;

            try
            {
                //Setup command object
                cmd = new SqlCommand(procName);
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        cmd.Parameters.Add(procParams[index]);
                    }
                }
                da.SelectCommand = (SqlCommand)cmd;

                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    string connStr = GetConnectionString();
                    //string connStr = @"Server=LAPTOP-VM3C2I5J\WIGANPIER;Database=AIMS;Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Integrated Security=SSPI";
                    cnx = new SqlConnection();
                    //cnx.ConnectionString = @"Server=LAPTOP-VM3C2I5J\WIGANPIER;Database=AIMS;Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Integrated Security=SSPI"; //connStr;
                    cnx.ConnectionString = connStr;
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }

                //Fill the dataset
                da.Fill(dtTable);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                //if (_isOwner)
                //{
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                
                cnx.Dispose(); //Implicitly calls cnx.Close()
                //}
            }
            return dtTable;
        }

    } //class 
}
