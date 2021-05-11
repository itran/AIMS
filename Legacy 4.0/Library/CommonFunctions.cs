using System.Collections.Generic;
using Legacy.Models;
using Legacy.DAL;
namespace Legacy.Library
{
    public class CommonFunctions
    {
        public List<UserModel> GetAllUsers()
        {
            DAL.UserDAL dapper = new UserDAL();
            List<UserModel> allUsers = dapper.GetAllUsers();
            return allUsers; 
        }
        public UserModel GetUserDetails(string userName)
        {
            UserDAL dapper = new UserDAL();
            return dapper.GetUserDetails(userName);
        }

        public List<PatientModel> GetAllPatients()
        {
            DAL.PatientDAL dapper = new PatientDAL();
            List<PatientModel> allUsers = dapper.GetAllPatients();
            return allUsers;
        }
        public List<DepartmentModel> GetAllDepartments()
        {
            DAL.DepartmentDAL dapper = new DepartmentDAL();
            List<DepartmentModel> allUsers = dapper.GetAllDepartments();
            return allUsers;
        }

        public List<UserModel> GetDepartmentUsers(int departmentId)
        {
            DAL.DepartmentDAL dapper = new DepartmentDAL();
            List<UserModel> allUsers = dapper.GetDepartmentUsers(departmentId);
            return allUsers;
        }
        public List<JobTitleModel> GetAllJobTitles()
        {
            DAL.JobTitleDAL dapper = new JobTitleDAL();
            List<JobTitleModel> allJobTitles = dapper.GetAllJobTitles();
            return allJobTitles;
        }
        public List<RoleModel> GetAllRoles()
        {
            DAL.RoleDAL dapper = new RoleDAL();
            List<RoleModel> allRoles = dapper.GetAllRoles();
            return allRoles;
        }

        public List<FilterModel> PatientFiltering(string FilterType)
        {
            DAL.PatientFilterDAL dapper = new PatientFilterDAL();
            List<FilterModel> filter = dapper.PatientFiltering(FilterType);
            return filter;
        }
    }
}
