using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using AIMS.DAL;

namespace AIMS.BLL
{
    public class LookUpTableCollections
    {
         DALBaseMethods dalBase;
        
        /// <summary>
        /// This method is called to populate all comboboxes
        /// </summary>
        /// <param name="fieldOne"></param>
        /// <param name="fieldTwo"></param>
        /// <param name="tableName"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public DataTable GetLookUpValues(string fieldOne, string fieldTwo, string tableName, int rowCount, string SortByField)
        {
            string sqlStat = string.Empty;
            DataTable tbl;

            try
            {
                dalBase = new DALBaseMethods();
                if (SortByField.Trim().Length > 0)
                {
                    sqlStat = "Select distinct " + fieldOne + "," + fieldTwo + " from " + tableName + " ORDER BY " + SortByField;
                }
                else
                {
                    sqlStat = "Select  distinct " + fieldOne + "," + fieldTwo + " from " + tableName;
                }
                
                tbl = dalBase.FillDataTable(sqlStat);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tbl;
        }

        public DataTable GetLookUpValues(string fieldOne, string fieldTwo, string tableName, int rowCount, string SortByField, string sWhereClause)
        {
            string sqlStat = string.Empty;
            DataTable tbl;

            try
            {
                dalBase = new DALBaseMethods();
                if (SortByField.Trim().Length > 0)
                {
                    sqlStat = "Select " + fieldOne + "," + fieldTwo + " from " + tableName + "  " + sWhereClause  + " ORDER BY " + SortByField;
                }
                else
                {
                    sqlStat = "Select " + fieldOne + "," + fieldTwo + " from " + tableName + "  " + sWhereClause;
                }

                tbl = dalBase.FillDataTable(sqlStat);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tbl;
        }
        /// <summary>
        /// This method is called to populate all comboboxes
        /// </summary>
        /// <param name="fieldOne"></param>
        /// <param name="fieldTwo"></param>
        /// <param name="tableName"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public DataTable GetHospitalsLookUpValues(string fieldOne, string fieldTwo, string tableName, int rowCount)
        {
            string sqlStat = string.Empty;
            DataTable tbl;

            try
            {
                dalBase = new DALBaseMethods();
                sqlStat = "Select " + fieldOne + "," + fieldTwo + " from " + tableName;
                sqlStat += " where supplier_type_id in(select supplier_type_id from aims_supplier_types where supplier_type_desc in('Private Clinic','Hospital','Private Hospital','<Add New Supplier>')) order by supplier_name";
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
