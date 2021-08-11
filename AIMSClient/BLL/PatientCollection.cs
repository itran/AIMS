using System;
using AIMS.DAL;

namespace AIMS.BLL
{
    public class PatientCollection : BaseCollection<Patient>
    {
        public static PatientCollection GetALL()
        {
            PatientCollection obj = new PatientCollection();
            obj.MapObjects(new PatientDAL().PatientGetAll());
            return obj;
        }

    }
}
