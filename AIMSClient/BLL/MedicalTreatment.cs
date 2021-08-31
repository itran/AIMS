using System;
using System.Collections.Generic;
using System.Text;
using AIMS.Common;
using AIMS.DAL;
using System.Data;

namespace AIMS.BLL
{
    public class MedicalTreatment
    {
        public DataSet GetPatientMedicalTreatment(string patientFileNo)
        {
            MedicalTreatmentDAL treatment = new MedicalTreatmentDAL();
            DataSet ds = new DataSet();
            ds = treatment.GetMedicalTreatmentDetails(patientFileNo);

            return ds;
        }


    }
}
