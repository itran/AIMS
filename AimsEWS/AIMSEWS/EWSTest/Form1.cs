using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Exchange.WebServices.Autodiscover;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.NetworkInformation;
using System.IO;

namespace EWSTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string patient_File = CheckRendezvousFile("Re: [-12/1445-] RE: ***NEW CASE*** SPECIALTY ASSISTANCE REF.: 2012/7764 Richard Noden", "[-", "-]");
                //AIMS.EWS.MailObject AIMSMail = new AIMS.EWS.MailObject();
                //AIMSMail.DownloadEmail();
                MessageBox.Show("Done Downloading EMAILS");
            }
            catch (Exception)
            {

            }
            finally {
                Application.ExitThread();
            }

        }

        static ExchangeService GetBinding()
        {
            // Create the binding.
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

            // Define credentials.
            //service.Credentials = new WebCredentials("test@aims.org.za","test", "AIMS");

            System.Net.NetworkCredential NetCred = new System.Net.NetworkCredential();

            ////////////////////////////////////////////////////////////////
            //NetCred.Domain = "AIMS";
            //NetCred.UserName = "Administrator";
            //NetCred.Password = "Cher0keE";

            //service.Credentials = NetCred;

            //service.Url = new Uri("https://dc1/EWS/Exchange.asmx");
            ////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////
            NetCred.Domain = "LIBERTY";
            NetCred.UserName = "sbm1208";
            NetCred.Password = "winter8";

            service.Credentials = NetCred;

            service.Url = new Uri("https://www.libertymail.co.za/ews/exchange.asmx");
            
            

            // Use the AutodiscoverUrl method to locate the service endpoint.
            try
            {
                //service.AutodiscoverUrl("test@aims.org.za", RedirectionUrlValidationCallback);
            }
            catch (AutodiscoverRemoteException ex)
            {
                Console.WriteLine("Exception thrown: " + ex.Error.Message);
            }

            // Display the service URL.
            Console.WriteLine("AutodiscoverURL: " + service.Url);
            return service;
        }

        // Create the callback to validate the redirection URL.
        static bool RedirectionUrlValidationCallback(String redirectionUrl)
        {
            // Perform validation.
            // Validation is developer dependent to ensure a safe redirect.
            return true;
        }

        // Create and send mail.
        static void CreateAndSendMail(ExchangeService service)
        {
            try
            {
                //Trust all certificates 
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                // trust sender 
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains("DC1"));

                object obj1 = new object();

                // validate cert by calling a function 
                System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

                // Create an e-mail message and identify the Exchange service.
                EmailMessage message = new EmailMessage(service);

                // Subject
                message.Subject = "Very Interesting. EWS Message";

                // Body
                message.Body = new MessageBody("This is a message, built using EWS and posted to an Exchange Online account");

                // Recipients
                message.ToRecipients.Add("brian.maswanganye@standardbank.co.za");

                // Send the mail. This makes a trip to the EWS server.
                message.SendAndSaveCopy();
                MessageBox.Show("Message Sending Successful");
            }
            catch (Exception ex)
            {

                MessageBox.Show("CreateAndSendMail Error: " + ex.ToString());
            }
        }

        // callback used to validate the certificate in an SSL conversation 
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors) {    
            bool result = false;     
            //if (cert.Subject.ToUpper().Contains("DC1"))     {         
                result = true;     
            //}      
            return result; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //DateTime dremailDttm = DateTime.Now.AddDays(-2);
                //System.TimeSpan diffResultCurrent = System.Convert.ToDateTime(dremailDttm) - System.Convert.ToDateTime(DateTime.Today);

                //if (diffResultCurrent.Days <=0 )
                //{

                //}

                //WriteEventLog("DDDDDDDDDDDDDD");
                AIMS.EWS.MailObject AIMSMail = new AIMS.EWS.MailObject();
                //AIMSMail.SendEmail("From Brian");
                ////AIMSMail.DownloadEmail();
                //MessageBox.Show("Brian Testing".ToString());
                //string patient_File = CheckRendezvousFile("99/9999 TEST TEST TEST TEST TEST", "[-", "-]");

                //string patient_File1 = CheckRendezvousFileInSubject(@"FW: [-15/7825-] RE: TR: [-15/7311-]  ATT. Relatorio Medico do Taonga Phiri - 1040-3");
                try
                {
                    //AIMSMail.DeleteOldEmails();
                    //MessageBox.Show("Started".ToString());
                    // AIMS.EWS.MailObject AIMSMail = new AIMS.EWS.MailObject();
                    
                    //AIMSMail.DownloadFromOffice365Email();
                    AIMSMail.DownloadEmail();
                    //MessageBox.Show("Completed".ToString());
                }
                catch(System.Exception exx)
                {
                   // MessageBox.Show("Download Failed:::".ToString() + exx.ToString());
                }
                finally
                {
                    PrevInstanceKill();
                    Application.Exit();
                }
            }
            catch (System.Exception ex)
            {
                PrevInstanceKill();
                Application.Exit();
                //MessageBox.Show(ex.ToString());
            }
        }

        private string CheckRendezvousFile(string sEmail_Subject, string sLeftDelimeter, string sRightDelimeter)
        {
            try
            {
                string _leftSubjectSeperator = sLeftDelimeter; // "["
                string _rightSubjectSeperator = sRightDelimeter; // "]"

                //int startPOS = Strings.InStr(sEmail_Subject, _leftSubjectSeperator);
                int startPOS = sEmail_Subject.IndexOf(_leftSubjectSeperator);
                //Ensure that the subject line contains a left seperator
                if (!sEmail_Subject.Contains(_leftSubjectSeperator) || !sEmail_Subject.Contains(_rightSubjectSeperator))
                {
                    return "";
                }

                int endPOS = sEmail_Subject.IndexOf(_rightSubjectSeperator);

                if (endPOS == 0 | endPOS <= startPOS)
                {
                    return "";
                }

                string PatientFileNo = sEmail_Subject.Substring(startPOS + 2, endPOS - startPOS - _leftSubjectSeperator.Length);
                return PatientFileNo;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //private static string GetReferenceNos(string EmailSubject)
        //{
        //    string PatientFiles = "";
        //    try
        //    {
        //        EmailSubject = EmailSubject.Replace(@"[-", " ");
        //        EmailSubject = EmailSubject.Replace(@"-]", " ");

        //        //Append spaces at the beginning and the end of the string
        //        EmailSubject = " " + EmailSubject + " ";

        //        string input4 = @EmailSubject;
        //        Regex word4 = new Regex(@"\b\d{1,2}\/\d{1,4}\b");

        //        Match m4 = word4.Match(input4);
        //        while (!m4.ToString().Trim().Equals(""))
        //        {
        //            if (!m4.ToString().Trim().Equals(""))
        //            {
        //                PatientFiles += m4.ToString() + "|";
        //            }
        //            input4 = input4.Replace(m4.ToString(), "");
        //            word4 = new Regex(@"\b\d{1,2}\/\d{1,4}\b");
        //            m4 = word4.Match(input4);
        //        }

        //        word4 = new Regex(@"\b\d{1,2}\\\d{1,4}\b");

        //        m4 = word4.Match(input4);
        //        while (!m4.ToString().Trim().Equals(""))
        //        {
        //            if (!m4.ToString().Trim().Equals(""))
        //            {
        //                PatientFiles += m4.ToString().Replace(@"\", @"/") + "|";
        //            }
        //            input4 = input4.Replace(m4.ToString(), "");
        //            word4 = new Regex(@"\b\d{1,2}\\\d{1,4}\b");
        //            m4 = word4.Match(input4);
        //        }

        //        if (!PatientFiles.Equals("") && PatientFiles.EndsWith("|"))
        //        {
        //            PatientFiles = PatientFiles.Substring(0, PatientFiles.Length - 1);
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //    }
        //    return PatientFiles;
        //}​

        private string CheckRendezvousFileInSubject(string sEmail_Subject)
        {
            string PatientFileNo = "";
            try
            {
                string input = sEmail_Subject;
                Regex word = new Regex(@"\[-.*\-]");
                Match m = word.Match(input);
                Console.WriteLine(m.Value);
                PatientFileNo = m.Value.ToString();

                if (PatientFileNo.Equals("") )
                {
                    string EmailSubject = PatientFileNo;
                    while (!EmailSubject.Equals(""))
                    {
                        //string strPatient1 = PatientFileNo.Substring(
                        EmailSubject = "";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return PatientFileNo;
            //try
            //{
            //    if (sEmail_Subject.Contains("/"))
            //    {
            //        string FileSeparator = "/";
            //        int separatorLocation = 0;
            //        string First2Chars = "";
            //        string Last5Chars = "";
            //        string NewSubjectString = "";

            //        bool checkingProceed = true;
            //        sEmail_Subject = sEmail_Subject.Trim();
            //        separatorLocation = sEmail_Subject.IndexOf(FileSeparator);

            //        int yearDigit = 0;
            //        int patientidseq = 0;
            //        bool bfirstTime = true;
                    
            //        do
            //        {
            //            if (bfirstTime)
            //            {
            //                if (separatorLocation.Equals(0) || separatorLocation.Equals(1))
            //                {
            //                    First2Chars = sEmail_Subject.Trim().Substring(2 - 2, 2).Trim();
            //                }
            //                else
            //                {
            //                    First2Chars = sEmail_Subject.Trim().Substring(separatorLocation - 2, 2).Trim();
            //                }
            //                try
            //                {
            //                    Last5Chars = sEmail_Subject.Trim().Substring(separatorLocation + 1, 5).Trim();
            //                }
            //                catch (Exception)
            //                {
            //                    Last5Chars = sEmail_Subject.Trim().Substring(separatorLocation, 5).Trim();
            //                    if (!int.TryParse(Last5Chars, out patientidseq))
            //                    {
            //                        try
            //                        {
            //                            Last5Chars = sEmail_Subject.Trim().Substring(separatorLocation + 1, 4).Trim();
            //                        }
            //                        catch (Exception)
            //                        {
            //                            Last5Chars = sEmail_Subject.Trim().Substring(separatorLocation, 4).Trim();
            //                        }
            //                    }
            //                }
                            
            //            }
            //            else
            //            {
            //                if (separatorLocation.Equals(0) || separatorLocation.Equals(1))
            //                {
            //                    First2Chars = NewSubjectString.Trim().Substring(2 - 2, 2).Trim();
            //                }
            //                else
            //                {
            //                    First2Chars = NewSubjectString.Trim().Substring(separatorLocation - 2, 2).Trim();
            //                }

            //                Last5Chars = NewSubjectString.Trim().Substring(separatorLocation + 1, 5).Trim();
            //            }

            //            if (int.TryParse(First2Chars, out yearDigit) & int.TryParse(Last5Chars, out patientidseq))
            //            {
            //                if (!PatientFileNo.Contains(First2Chars + "/" + Last5Chars))
            //                {
            //                    PatientFileNo += First2Chars + "/" + Last5Chars + ";";   
            //                }
            //            }

            //            if (bfirstTime)
            //            {
            //                NewSubjectString = sEmail_Subject.Substring(separatorLocation + 1).Trim();
            //            }
            //            else
            //            {
            //                NewSubjectString = NewSubjectString.Substring(separatorLocation + 1).Trim();
            //            }
                        
            //            if (!NewSubjectString.Contains("/"))
            //            {
            //                checkingProceed = false;
            //            }
            //            else
            //            {
            //                separatorLocation = NewSubjectString.IndexOf("/");
            //            }

            //            bfirstTime = false;
            //        } while (checkingProceed);
            //    }
            //    if (!PatientFileNo.Trim().Equals(""))
            //    {
            //        ReplaceMultiple(PatientFileNo, "", ";", ",", "*", "(", ")", ",", "~", "!", "@", "#", "$", "%", "^", "&", "?", "<", ">", "_", "|");
            //    }
            //    return PatientFileNo;
            //}
            //catch (Exception)
            //{
            //    return "";
            //}
        }

        public string ReplaceMultiple(string OrigString, string ReplaceString, params string[] FindChars)
        {
            //Dont add the same character twice in the array as this causes the function to work incorrectly
            //and if you do, then what the hell are you doing as a software developer.


            long lLBound = 0;
            long lUBound = 0;
            long lCtr = 0;
            string sAns = string.Empty;

            lLBound = FindChars.GetLowerBound(0);
            lUBound = FindChars.GetUpperBound(0);

            sAns = OrigString;

            for (lCtr = lLBound; lCtr <= lUBound; lCtr++)
            {
                sAns = sAns.Replace(FindChars[lCtr].ToString(), ReplaceString);
            }

            if (sAns == null)
            {
                sAns = "Invalid Subject";
            }

            return sAns;


        }

        private void WriteEventLog(string Event)
        {
            StreamWriter strWrite = null;
            
            try
            {
                strWrite = new StreamWriter(String.Format(@"c:\AIMS Recorder\AIMS_EWS_EVENTS - {0:ddMMMyyyy}.LOG", DateTime.Today), true, Encoding.ASCII);
                strWrite.WriteLine(DateTime.Now.ToString() + "\n" + Event);
                strWrite.WriteLine("+++++++++");
                strWrite.Flush();
                strWrite.Close();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("PROBLEM::: " + ex.ToString());
            }
            finally
            {
                strWrite.Dispose();
            }
        }

        private void PrevInstanceKill()
        {
            System.Diagnostics.Process[] EWSProcs = System.Diagnostics.Process.GetProcessesByName("EWSTest");

            if (EWSProcs.Length > 0)
            {
                foreach (System.Diagnostics.Process p in EWSProcs)
                {
                    try
                    {
                        if (!p.HasExited )
                        {
                            p.Kill();
                            WriteEventLog("1. EWS Exchange Connector killed");
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            EWSProcs = System.Diagnostics.Process.GetProcessesByName("EWSTest.exe");

            if (EWSProcs.Length > 0)
            {
                foreach (System.Diagnostics.Process p in EWSProcs)
                {
                    try
                    {
                        if (!p.HasExited)
                        {
                            p.Kill();
                            WriteEventLog("1. EWS Exchange Connector killed");
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
