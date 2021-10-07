using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMReports
{
    public class CommonFunctions
    {
        public void ErrorLogger(string ErrorMessage)
        {
            string fLogName = "";
            try
            {
                if (!Directory.Exists(@"C:\AIMS Recorder"))
                {
                    Directory.CreateDirectory(@"C:\AIMS Recorder");
                }

                fLogName = @"C:\AIMS Recorder\AIMS Recorder - Reports - " + System.DateTime.Today.ToString("dd-MMM-yyyy") + ".log";

                StreamWriter sw;
                sw = File.AppendText(fLogName);
                sw.WriteLine("AIMS Recorder Error Time    - " + System.DateTime.Now.TimeOfDay);
                sw.WriteLine("AIMS Recorder Error Message - " + ErrorMessage);
                sw.WriteLine("---------------------------------------");
                sw.Flush();
                sw.Close();
            }
            finally
            {
            }
        }
    }
}
