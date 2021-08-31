using System;
using System.Collections.Generic;
using System.Text;
using AIMS.DAL;
using System.Data;

namespace AIMS.BLL
{
    public class Notes : BaseObject
    {
        private string _patientID;
        private string _note;
        private string _noteType;
        private string _username;

        public string PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public string NoteType
        {
            get { return _noteType; }
            set { _noteType = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public DataSet GetPatientNotes(string patientFileNo, string NoteType)
        {
            NotesDAL notes = new NotesDAL();
            DataSet ds = new DataSet();
            ds = notes.GetPatientNotes(patientFileNo, NoteType);
            return ds;
        }

        public void SavePatientNotes(string patientFileNo,string userName,string userNote, Int32 NoteType, Int64 NoteID)
        {
            NotesDAL notesDAL = new NotesDAL();
            notesDAL.NotesSave(patientFileNo, userName, userNote, NoteType, NoteID);     
        }

        public DataTable GetNoteTypes()
        {
            NotesDAL notesDAL = new NotesDAL();
            DataTable dtNoteTypes = new DataTable();

            try
            {
                dtNoteTypes = notesDAL.GetNoteTypes();
            }
            finally
            {
                notesDAL = null;
            }
            return dtNoteTypes;
        }

        public DataTable GetNote(Int64 NoteID)
        {
            NotesDAL notesDAL = new NotesDAL();
            DataTable dtNoteTypes = new DataTable();

            try
            {
                dtNoteTypes = notesDAL.GetNote(NoteID);
            }
            finally
            {
                notesDAL = null;
            }
            return dtNoteTypes;
        }

        public Int32 GetNoteTypeID(string NoteTypeCD) 
        {
            NotesDAL notesDAL = new NotesDAL();
            Int32 NoteTypeID;

            try
            {
                NoteTypeID = notesDAL.GetNoteTypeID(NoteTypeCD);
            }
            finally
            {
                notesDAL = null;
            }
            return NoteTypeID;
        }
    }
}
