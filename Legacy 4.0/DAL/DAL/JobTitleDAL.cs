using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Legacy.Models;
using System.Linq;

namespace Legacy.DAL
{
    public class JobTitleDAL
    {
        public List<JobTitleModel> GetAllJobTitles()
        {
            IDbConnection db = new SqlConnection(@"Data Source=LAPTOP-VM3C2I5J\WIGANPIER;Initial Catalog=AIMS;Integrated Security=True");
            db.Open();
            return db.Query<JobTitleModel>($"select * from aims_job_title").ToList();
        }
    }
}
