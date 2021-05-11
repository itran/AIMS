using System;
using AIMS.DAL;

namespace AIMS.BLL
{
    public class InvoiceCollection : BaseCollection<Patient>
    {
        public static InvoiceCollection GetALL()
        {
            InvoiceCollection obj = new InvoiceCollection();
            obj.MapObjects(new PatientDAL().PatientGetAll());
            return obj;
        }

    }
}
