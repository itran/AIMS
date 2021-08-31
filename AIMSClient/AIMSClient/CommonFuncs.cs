using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AIMSClient;
using AIMS.Client;
using System.IO;
using System.Web;
using System.Data;
using AIMS.Common;
using AIMS.BLL;

namespace AIMS.Client
{
    public class CommonFuncs
    {
        public AIMS.BLL.Invoice clsInvoice = new Invoice();
        public AIMS.BLL.Invoice clsPayment = new Invoice();

        private string  _currentUserLogged;
        private string _userFullName;

        public string  CurrentUserLoggedUser
        {
            get { return _currentUserLogged; }
            set { _currentUserLogged = value; }
        }

        private string _signature;
        public string Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

        public string CurrentFullName
        {
            get { return _userFullName; }
            set { _userFullName = value; }
        }	

        #region Messagebox Events

        /// <summary>
        /// Generic function used througout the application to display messages
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="MsgType"></param>
        public void DisplayMessage(string Message, Common.CommonTypes.MessagType MsgType)
        {

            switch (MsgType)
            {
                case CommonTypes.MessagType.Warning:
                    MessageBox.Show(Message, "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case CommonTypes.MessagType.Success:
                    MessageBox.Show(Message, "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case CommonTypes.MessagType.Error:
                    //MessageBox.Show("The following error occured:\n\n" + Message, "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(Message, "AIMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
            
            return;

        }

        /// <summary>
        /// Generic function that displays messagebox dialogues
        /// and returns a dialogresult
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public DialogResult DisplayQuestion(string Message)
        {
            return MessageBox.Show(Message, "AIMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// This method 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int RandomNumber(int min, int max)
        {
            Random random;

            try
            {
                random = new Random();
                return random.Next(min, max);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void LoadCalendar(ref UserControls.frmCalendar frmInstDateSelect , ref TextBox returnControl, Form callingForm)
        {
            if (frmInstDateSelect == null)
	        {
        		 frmInstDateSelect = new UserControls.frmCalendar();
	        }

            frmInstDateSelect.ShowDialog(callingForm);
            returnControl.Focus();

        }
    //    If IsNothing(frmInstDateSelect) Then frmInstDateSelect = New UserControls.frmCalendar
    //    If IsDate(ReturnControl.Text) AndAlso CDate(ReturnControl.Text) > frmInstDateSelect.MinDate Then frmInstDateSelect.ShowDate = CDate(ReturnControl.Text)
    //    frmInstDateSelect.ShowDialog(CallingForm)

    //    If frmInstDateSelect.StartDate <> #12:00:00 AM# Then ReturnControl.Text = frmInstDateSelect.StartDate.ToShortDateString
    //    ReturnControl.Focus()
    //End Sub




        #endregion

        #region MDI Functions

        public void SetMDIMessage(frmMain frmMain,string Msg)
        {
            frmMain.SetMdiStatusbar(Msg);
        }

        #endregion

        #region "Error Logger"
        /// <summary>
        ///     Error Logging function to be called when errors are thrown or catched for debugging purposes
        /// </summary>
        /// <param name="ErrorMessage"></param>
        public void ErrorLogger(string ErrorMessage)
        {
            string fLogName = @"C:\aims recorder\AIMS Recorder - " + System.DateTime.Today.ToString("dd-MMM-yyyy") + ".log";
            try
            {
                StreamWriter sw;
                sw = File.AppendText(fLogName);
                sw.WriteLine("AIMS Recorder Error Time    - " + System.DateTime.Now.TimeOfDay);
                sw.WriteLine("AIMS Recorder Error Message - " + ErrorMessage);
                sw.WriteLine ("---------------------------------------");
                sw.Flush();
                sw.Close();
            }
            finally
            {
            }
        }
        #endregion

        #region "Application Close"  
        public void CloseAimsRecorder()
        {
            try 
	        {	        
        		
	        }
	        catch (System.Exception ex )
	        {
        	}
        }
        #endregion

        #region Dropdowns and Lists


        /// <summary>
        /// Loops through the items in a dropdown and sets the selected index to a matching item
        /// </summary>
        /// <param name="DropDown">Dropdown list to loop through</param>
        /// <param name="Value">Value to check for</param>
        public void SetDropDownValue(ComboBox DropDown, string Value)
        {
            try
            {
                int i = 0;

                if (DropDown.Items.Count > 0)
                {
                    foreach (ListViewItem ThisItem in DropDown.Items)
                    {
                        if (ThisItem.ListView.Items[i].Text  == Value)
                        {
                            DropDown.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
            }
            catch (System.Exception)
            { }
        }

        public enum ListSelectAction
        {
            All = 1,
            None = 2,
            Invert = 3
        }

        public DataTable LoadMedicalTreatments()
        {
            DataTable dtMedicalTreatments = new DataTable();
            try
            {
                return dtMedicalTreatments;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataSet LoadTitles()
        {
            DataSet dtTitles = new DataSet();
            try
            {
                return dtTitles;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable LoadSuppliers()
        {
            DataTable dtSuppliers = new DataTable();
            try
            {
                dtSuppliers = clsInvoice.LoadSuppliers();
                return dtSuppliers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable LoadServices()
        {
            DataTable dtServices = new DataTable();
            try
            {
                dtServices = clsInvoice.LoadServices();
                return dtServices;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable LoadPatientFiles()
        {
            DataTable dtPatientFiles = new DataTable();
            try
            {
                dtPatientFiles = clsInvoice.LoadPatientFiles();
                return dtPatientFiles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable LoadMedicalTreatment()
        {
            DataTable dtMedicalTreatments = new DataTable();
            try
            {
                dtMedicalTreatments = clsInvoice.LoadSuppliers();
                return dtMedicalTreatments;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool PatientValidate()
        {
            bool blPatientExist = false;
            return blPatientExist;
            
        }
        #endregion


    }
}
