using Legacy;
using Legacy.DAL;
using Legacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Legacy.Library.FilterEnum;

namespace Legacy.Library
{
    public class Tasks
    {
        public List<TaskModel> GetPatientTasks(string patientFiloNo)
        {
            TaskDAL dapper = new TaskDAL();
            List<TaskModel> patientTasks = dapper.GetPatientTasks(patientFiloNo);
            return patientTasks;
        }

        public List<TaskModel> GetAllTasks()
        {
            TaskDAL dapper = new TaskDAL();
            List<TaskModel> tasks = dapper.GetAllTasks();
            return tasks;
        }

        public TaskModel GetTaskDetails(string taskId)
        {
            TaskDAL dapper = new TaskDAL();
            TaskModel taskDetails = dapper.GetTaskDetails(taskId);
            return taskDetails;
        }
    }
}