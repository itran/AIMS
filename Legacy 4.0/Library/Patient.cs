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
    public class Patient
    {
        public PatientModel GetPatientDetails(string patientFileNo)
        {
            DAL.PatientDAL dapper = new PatientDAL();
            PatientModel patientDetails = dapper.GetPatientDetails(patientFileNo);
            return patientDetails;
        }

        public List<PatientModel> GetPatientDetailsBySurname(string patientFullName)
        {
            DAL.PatientDAL dapper = new PatientDAL();
            List<PatientModel> patientDetails = dapper.GetPatientDetailsBySurname(patientFullName);
            return patientDetails;
        }

        public List<PatientModel> GetPatientFileNo(string patientFileNo)
        {
            DAL.PatientDAL dapper = new PatientDAL();
            List<PatientModel> patientDetails = dapper.GetPatientFileNo(patientFileNo);
            return patientDetails;
        }

        public List<PatientModel> GetPatientFileByReferenceNo(string referenceNo)
        {
            DAL.PatientDAL dapper = new PatientDAL();
            List<PatientModel> patientDetails = dapper.GetPatientFileByReferenceNo(referenceNo);
            return patientDetails;
        }

        public List<PatientModel> GetPatientDetails(int filterId, string filterName, string cancelled, string sentToAdmin, string pending, string closed)
        {
            DAL.PatientDAL dapper = new PatientDAL();
            List<PatientModel> patientDetails = dapper.GetPatientDetails(filterId, filterName, cancelled, sentToAdmin, pending, closed);
            return patientDetails;
        }

        public List<PatientModel> GetPatientDetails(int filterId, string filterName)
        {
            DAL.PatientDAL dapper = new PatientDAL();
            List<PatientModel> patientDetails = dapper.GetPatientDetails(filterId, filterName);
            return patientDetails;
        }

        public List<PatientFileAudit> GetPatientDetailsAudit(string patientFileNo)
        {
            DAL.PatientDAL dapper = new PatientDAL();
            List<PatientFileAudit> patientDetails = dapper.GetPatientDetailsAudit(patientFileNo);
            return patientDetails;
        }

        public List<Notes> GetPatientNotes(string patientFileNo, NoteType noteType)
        {
            DAL.PatientDAL dapper = new PatientDAL();
            List<Notes> patientDetails = dapper.GetPatientNotes(patientFileNo, noteType.ToString());
            return patientDetails;
        }
    }
}
