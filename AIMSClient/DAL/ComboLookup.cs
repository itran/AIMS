using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace AIMS.DAL
{
    public class ComboLookup
    {
        DALBaseMethods dalBase;

        public DataTable GetComboValues(string fieldOne,string fieldTwo,string tableName,int rowCount, string OrderByField)
        {
            string sqlStat = string.Empty;
            DataTable tbl;
            
            try
            {
                dalBase = new DALBaseMethods();
                if (OrderByField.Trim().Length > 0)
                {
                    sqlStat = "Select " + fieldOne + "," + fieldTwo + " from " + tableName + "  order by " + OrderByField;     
                }
                else
                {
                    sqlStat = "Select " + fieldOne + "," + fieldTwo + " from " + tableName;
                }
                
                tbl = dalBase.FillDataTable(sqlStat);
            }
            catch (Exception ex)
            {
                 throw ex;
            }

            return tbl;
        }
    }
}
