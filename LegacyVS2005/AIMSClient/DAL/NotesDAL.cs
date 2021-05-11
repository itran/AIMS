using System;
using System.Collections.Generic;
using System.Text;
using AIMS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace AIMS.DAL
{
    public class NotesDAL : DataServiceBase
    {

         ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public NotesDAL() : base() { }
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public NotesDAL(IDbTransaction txn) : base(txn) { }

        public DataSet GetPatientNotes(string patientID, string NotesType)
        {
            return ExecuteDataSet("AIMS_PATIENT_GET_NOTES",
                CreateParameter("@PatientFileNo", SqlDbType.VarChar, patientID),
                CreateParameter("@NoteTypeCD", SqlDbType.VarChar, NotesType));
        }

        public void NotesSave(string patientFile,string userName,string note, Int32 notetypecd, Int64 NoteID)
        {
            SqlCommand cmd;

            ExecuteNonQuery(out cmd, "AIMS_ADD_NOTE",
                CreateParameter("@PatientFileNo", SqlDbType.NVarChar, patientFile),
                CreateParameter("@UserName", SqlDbType.NVarChar, userName),
                CreateParameter("@Notes", SqlDbType.NVarChar, note),
                CreateParameter("@NoteTypeID", SqlDbType.Int, notetypecd),
                CreateParameter("@NoteID", SqlDbType.VarChar, System.Convert.ToString(NoteID))
                );
                
            cmd.Dispose();
        }

        public DataTable GetNoteTypes()
        {
            return ExecuteDataTable("AIMS_NOTE_TYPE_GET");
        }

        public DataTable GetNote(Int64 NoteID)
        {
            return ExecuteDataTable("AIMS_NOTE_GET",
                    CreateParameter("@NoteID", SqlDbType.VarChar , System.Convert.ToString(NoteID)));
        }

        public Int32 GetNoteTypeID(string NoteTypeCD)
        {
            Int32 NotypeID = 0;
            SqlCommand cmd;
            ExecuteNonQuery(out cmd,"AIMS_NOTE_GET_ID",
                    CreateParameter("@NoteTypeCD", SqlDbType.VarChar, NoteTypeCD.ToString()),
                    CreateParameter("@NoteTypeID", SqlDbType.VarChar, NotypeID.ToString(),30, ParameterDirection.Output));

            NotypeID = System.Convert.ToInt32(cmd.Parameters["@NoteTypeID"].Value.ToString());
            return NotypeID;
        }  
    }
}
