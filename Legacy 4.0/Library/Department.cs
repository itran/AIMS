using System.Collections.Generic;
using Legacy.Models;
using Legacy.DAL;
namespace Legacy.Library
{
    public class Department
    {
        public IEnumerable<DepartmentModel> GetAllDepartments()
        {
            DepartmentDAL dapper = new DepartmentDAL();
            IEnumerable<DepartmentModel> allUsers = dapper.GetAllDepartments();
            return allUsers;
        }
    }
}
