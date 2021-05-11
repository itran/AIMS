using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Legacy.Models;
using System.Linq;

namespace Legacy.DAL
{
    public class PatientFilterDAL
    {
        public List<FilterModel> PatientFiltering(string FilterType)
        {
            IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True");
            db.Open();

            switch (FilterType)
            {
                case "Guarantor":
                    return db.Query<FilterModel>($"select GUARANTOR_ID FILTER_ID, GUARANTOR_NAME FILTER_NAME from aims_guarantor where GUARANTOR_ACTIVE_YN = 'Y' order by GUARANTOR_NAME").ToList();
                    break;
                case "Hospital":
                    return db.Query<FilterModel>($"select SUPPLIER_ID FILTER_ID , SUPPLIER_NAME FILTER_NAME from AIMS_SUPPLIER where SUPPLIER_TYPE_ID =1 and SUPPLIER_ACTIVE_YN = 'Y' order by SUPPLIER_NAME").ToList();
                    break;
                default:
                    return db.Query<FilterModel>($"select * from AIMS_PATIENT_VW").ToList();
                    break;
            }
        }
    }
}
