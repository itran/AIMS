using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL
{
    public class MedicalTreatmentDAL : DataServiceBase
    {
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public MedicalTreatmentDAL() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public MedicalTreatmentDAL(IDbTransaction txn) : base(txn) { }


        public DataSet GetMedicalTreatmentDetails(string patientFileNo)
        {
            return ExecuteDataSet("AIMS_MEDICAL_TREATMENT_GET_ALL",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientFileNo));
        }
    }

      
      
}
