using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.Library
{
    public class FilterEnum
    {
        public enum PatientFilter
        {
            Guarantor = 0,
            Supplier = 1
        }

        public enum NoteType
        {
            PATIENTADMINNOTES,
            PATIENTCOMMENT,
            PATIENTFILEENQUIRY,
            PATIENTFINANCENOTES,
            PATIENTINTERIMNOTES,
            PATIENTLATESTUPDATE,
            PATIENTMEDICALHISTORY, 
            EXITNOTE
        }
    }
}
