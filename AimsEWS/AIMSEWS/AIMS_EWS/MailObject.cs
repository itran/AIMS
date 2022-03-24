using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Dns;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.NetworkInformation;
using System.IO;
using EWS.AIMS.DAL;
using System.Configuration.Assemblies;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;

namespace AIMS.EWS
{
    public class MailObject
    {
        private string base64EncodedFile = string.Empty;
        private string fullyQualifiedFileName;
        private static ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

        string EmailAttachments = "";

        static ExchangeService GetBinding(string MailBoxUserName, string MailBoxUserPassword, string MailBoxDomain, string MailEWSURL)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            try
            {
                System.Net.NetworkCredential NetCred = new System.Net.NetworkCredential();

                NetCred.Domain = MailBoxDomain;
                NetCred.UserName = MailBoxUserName;
                NetCred.Password = MailBoxUserPassword;

                service.Credentials = NetCred;
                service.Url = new Uri(MailEWSURL);
            }
            catch (Microsoft.Exchange.WebServices.Data.ServiceLocalException ex)
            {

            }
            return service;
        }

        // Create the callback to validate the redirection URL.
        static bool RedirectionUrlValidationCallback(String redirectionUrl)
        {
            return true;
        }

        // callback used to validate the certificate in an SSL conversation 
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            bool result = false;
            //if (cert.Subject.ToUpper().Contains("DC1"))     {         
            result = true;
            //}      
            return result;
        }

        public void SendEmail(string EmailSubject)
        {
            try
            {
                WriteEventLog("Event TEST");

                //Trust all certificates
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                // trust sender 
                //System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains("DC1"));
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains("LEXMBXPD1WC2"));

                // validate cert by calling a function 
                System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

                // Create an e-mail message and identify the Exchange service.
                EmailMessage message = new EmailMessage(service);

                // Subject
                message.Subject = EmailSubject;

                //message.Attachments.AddFileAttachment(@"c:\exsol.txt");
                //message.Attachments.AddFileAttachment(@"c:\WebUI.docx");

                // Body
                message.Body = new MessageBody("<b>This is a message</b>, built using EWS and posted to an Exchange Online account<br /><hr size=3/>");
                message.Body.BodyType = BodyType.HTML;
                // Recipients
                message.ToRecipients.Add("brian.maswanganye@standardbank.co.za");

                // Send the mail. This makes a trip to the EWS server.
                message.SendAndSaveCopy();

                DownloadEmail();
            }
            catch (Exception ex)
            {
                ErrorLog("Error TEST");
            }
            finally
            {

            }
        }

        private string ExtractEmailAttachment(string EmailID)
        {
            string returnValues = string.Empty;
            try
            {

            }
            catch (System.Exception EX)
            {
                ErrorLog("ExtractEmailAttachment Method Error:- \n" + EX);
            }
            return returnValues;
        }

        private string ExtractPatientFileNoFromSubject(string EmailSubject)
        {
            string returnStr = "";
            try
            {
                if (!EmailSubject.Trim().Equals(""))
                {
                    if (EmailSubject.Contains("["))
                    {

                    }
                }
            }
            catch (Exception)
            {

            }
            return returnStr;
        }

        #region "Event\Error Logging Methods"
        private void ErrorLog(string ErrorMsg)
        {
            StreamWriter strWrite = null;
            try
            {
                strWrite = new StreamWriter(String.Format(@"c:\AIMS Recorder\AIMS_EWS_ERRORS - {0:ddMMMyyyy}.LOG", DateTime.Today), true, Encoding.ASCII);
                strWrite.WriteLine(DateTime.Now.ToString() + "\n" + ErrorMsg);
                strWrite.WriteLine("+++++++++");
                strWrite.Flush();
                strWrite.Close();
            }
            finally
            {
                if (strWrite!=null)
                strWrite.Dispose();
            }
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
            catch 
            {
                
            }
            finally
            {
                if (strWrite!= null)
                strWrite.Dispose();
            }
        }

        private void WriteEventLogDeleting(string Event)
        {
            StreamWriter strWrite = null;
            try
            {
                strWrite = new StreamWriter(String.Format(@"c:\AIMS Recorder\DELETE_AIMS_EWS_EVENTS - {0:ddMMMyyyy}.LOG", DateTime.Today), true, Encoding.ASCII);
                strWrite.WriteLine(DateTime.Now.ToString() + "\n" + Event);
                strWrite.WriteLine("+++++++++");
                strWrite.Flush();
                strWrite.Close();
            }
            catch
            {

            }
            finally
            {
                strWrite.Dispose();
            }
        }
        #endregion

        private bool WriteHTMLMailMessage(string sMailAsTextFileName, string sEmail_Addr_From_Name, string sEmail_Date, string sEmail_Addr_To, string sEmail_Subject, string sEmail_Addr_From_Address, string sEmailBody, string EmailBodyType, string EmailToCC)
        {
            StreamWriter sw = null;
            string sEmailDetail = "";
            bool ReturnValue = false; ;

            try
            {
                sw = File.CreateText(sMailAsTextFileName);

                WriteEventLog("File Created - " + sMailAsTextFileName);

                sEmailDetail = "<STYLE type=text/css> SPAN.text {FONT-SIZE: 9pt; FONT_COLOR: Black; FONT-FAMILY: Arial; text-align: justify} </STYLE>";
                sEmailDetail += "<span class=text> ";
                sEmailDetail += "<br><b>From Name: </b>" + sEmail_Addr_From_Name + " [" + sEmail_Addr_From_Address + "]";
                sEmailDetail += "<br><b>Sent: </b>" + sEmail_Date;
                sEmailDetail += "<br><b>To: </b>" + sEmail_Addr_To;
                if (!EmailToCC.Equals(""))
                {
                    sEmailDetail += "<br><b>CC: </b>" + EmailToCC;    
                }
                sEmailDetail += "<br><b>Subject: </b>" + sEmail_Subject;
                sEmailDetail += "<br><br><br></span>";

                if (EmailBodyType == "Text")
                {
                    sw.WriteLine("<HTML>" + sEmailDetail +  sEmailBody.Replace("\r", "<br>").Replace("\n", "<br>"));    
                }
                else
                {
                    sw.WriteLine("<HTML>" + sEmailDetail + sEmailBody + "</HTML>");
                }
                
                sw.Flush();
                ReturnValue = true;
                WriteEventLog("EMAIL ATTACHMENT FILE CREATED SUCCESSFULLY: " + sMailAsTextFileName);
            }
            catch (System.Exception ex)
            {
                ErrorLog("WriteHTMLMailMessage Method ERROR: \n" + ex.ToString());
            }
            finally
            {
                sw.Close();
                sw = null;
            }
            return ReturnValue;
        }

        public DataTable GetLimitationCodeValue(string LimitationCode)
        {
            DataTable dtPODDetails = new DataTable();
            try
            {
                EWSDAL commonFuncsDAL = new EWSDAL();
                dtPODDetails = commonFuncsDAL.GetLimitationCodeValue(LimitationCode);
            }
            finally
            {
            }
            return dtPODDetails;
        }

        public void DeleteOldEmails()
        {
            DataTable dtMailboxes = AIMS_EWS_Mailboxes();
            string MailBoxName = "";
            string MailBoxExchangeUser = "";
            string MailBoxExchangePassword = "";
            string MailBoxDomain = "";
            string MailBoxEWSUrl = "";
            int MailBoxItemsPick = 1;
            string MailBoxEWSEmailDownloadFolder = "";
            string EmailUniqueGUID = "";
            string EmailBodyFileName = "";
            string EmailBodyType = "";
            string MailBoxArchivingFolder = "";
            int MailBoxID = 0;
            bool bSaveEmailInfo = false;
            string sDir1 = string.Empty;
            string sDir2 = string.Empty;
            string sEmailDownLoadFolder = string.Empty;
            string EmailAttachmentsList = "";
            bool MoveMailItem = false;

            try
            {
                //Loop through all configured Email boxes
                foreach (DataRow dr in dtMailboxes.Rows)
                {
                    MailBoxID = System.Convert.ToInt16(dr["MAILBOX_ID"]);
                    MailBoxName = dr["MAILBOX_NAME"].ToString();
                    MailBoxExchangeUser = dr["MAILBOX_EXCHANGE_USER"].ToString();
                    MailBoxExchangePassword = dr["MAILBOX_EXCHANGE_PASSWORD"].ToString();
                    MailBoxDomain = dr["MAILBOX_AD_DOMAIN"].ToString();
                    MailBoxEWSUrl = dr["MAILBOX_EWS_URL"].ToString();
                    MailBoxItemsPick = (int)dr["MAILBOX_ITEMS_PICK"];
                    MailBoxEWSEmailDownloadFolder = dr["MAILBOX_EMAILS_STORE_FOLDER"].ToString();   
                    MailBoxArchivingFolder = dr["MAILBOX_ARCHIVE_FOLDER_NAME"].ToString();

                    service = GetBinding(MailBoxExchangeUser, MailBoxExchangePassword, MailBoxDomain, MailBoxEWSUrl);

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains("DC1"));

                    object obj1 = new object();

                    // validate cert by calling a function 
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

                    Int64 EmailID = 0;
                    string EmailSubject = "";
                    DateTime EmailReceivedDTTM;
                    Folder folder = Folder.Bind(service, new FolderId(WellKnownFolderName.DeletedItems));
                    
                    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.DeletedItems, new ItemView(10000));
                    try
                    {
                        string EmailUniqueID = "";
                        
                        foreach (Item item in findResults.Items)
                        {
                            EmailSubject = "";
                            EmailUniqueID = "";
                            EmailID = 0;

                            EmailUniqueID = item.Id.UniqueId;
                            Item mess = Item.Bind(service, EmailUniqueID);
                            EmailMessage message = mess as EmailMessage;

                            EmailReceivedDTTM = item.DateTimeReceived;
                            EmailSubject = item.Subject;
                            EmailUniqueGUID = System.Guid.NewGuid().ToString();
                            WriteEventLogDeleting("DELETED: " + EmailReceivedDTTM.ToString() + "---------" + EmailSubject);
                            item.Delete(DeleteMode.HardDelete);                            
                        }
                    }
                    catch (System.Exception ex)
                    {
                        ErrorLog(@"1. Download Email Error \n" + ex.ToString());
                        EmailProcessingRollback(EmailID.ToString(), EmailUniqueGUID.ToString(), EmailAttachmentsList.ToString());
                    }
                    finally
                    {
                        findResults = null;
                        service = null;
                    }
                }
            }
            catch (System.Exception downMailEx)
            {
                ErrorLog(@"2. Download Email Error \n" + downMailEx.ToString());
            }
            finally
            {
                dtMailboxes.Dispose();
            } 
        }

        private void AssignCertificates() 
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains("DC1"));

            object obj1 = new object();

            // validate cert by calling a function 
            System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);            
        }

        private void AssignCertificatesOffice365()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            
            object obj1 = new object();

            System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
        }

        public void DownloadEmail()
        {
            WriteEventLog("[DOWNLOAD EMAIL] - STARTED"); 
            DataTable dtMailboxes = AIMS_EWS_Mailboxes();
            string MailBoxName = "";
            string MailBoxExchangeUser = "";
            string MailBoxExchangePassword = "";
            string MailBoxDomain = "";
            string MailBoxEWSUrl = "";
            int MailBoxItemsPick = 1;
            string MailBoxEWSEmailDownloadFolder = "";
            string EmailUniqueGUID = "";
            string EmailBodyFileName = "";
            string EmailBodyType = "";
            string MailBoxArchivingFolder = "";
            int MailBoxID = 0;
            bool bSaveEmailInfo = false;
            string sDir1 = string.Empty;
            string sDir2 = string.Empty;
            string sEmailDownLoadFolder = string.Empty;
            string EmailAttachmentsList = "";
            bool MoveMailItem = false;

            DataTable dtFile13 = GetLimitationCodeValue("AIMS_FILE_13_QUERIES");
            DataTable dtFileAdmin13 = GetLimitationCodeValue("AIMS_ADMIN_QUERIES_FILE");
            try
            {
                string QueryFileNo = dtFile13.Rows[0]["LIMITATION_VALUE"].ToString();
                string AdminQueryFileNo = dtFileAdmin13.Rows[0]["LIMITATION_VALUE"].ToString();

                dtFile13.Dispose();
                dtFileAdmin13.Dispose();

                //Loop through all configured Email boxes
                foreach (DataRow dr in dtMailboxes.Rows)
                {
                    MailBoxID = System.Convert.ToInt16(dr["MAILBOX_ID"]);
                    MailBoxName = dr["MAILBOX_NAME"].ToString();
                    MailBoxExchangeUser = dr["MAILBOX_EXCHANGE_USER"].ToString();
                    MailBoxExchangePassword = dr["MAILBOX_EXCHANGE_PASSWORD"].ToString();
                    MailBoxDomain = dr["MAILBOX_AD_DOMAIN"].ToString();
                    MailBoxEWSUrl = dr["MAILBOX_EWS_URL"].ToString();
                    MailBoxItemsPick = (int)dr["MAILBOX_ITEMS_PICK"];
                    MailBoxEWSEmailDownloadFolder = dr["MAILBOX_EMAILS_STORE_FOLDER"].ToString();
                    MailBoxArchivingFolder = dr["MAILBOX_ARCHIVE_FOLDER_NAME"].ToString();

                    object obj1 = new object();
                    string office365EnabledYN = "";
                    DataTable dtOffice365Check = GetLimitationCodeValue("OFFICE_365_ENABLED");
                    if (dtOffice365Check.Rows.Count > 0)
                        office365EnabledYN = dtOffice365Check.Rows[0]["LIMITATION_VALUE"].ToString();
                    else
                        office365EnabledYN = "N";

                        WriteEventLog("[Office-365 Enabled] ----- " + office365EnabledYN);
                    if (office365EnabledYN == "Y")
                    {
                        WriteEventLog("[ - Office-365 Processing 1 - ]");
                        service = GetBindingOffice365(MailBoxExchangeUser, MailBoxExchangePassword, MailBoxDomain, MailBoxEWSUrl);
                        WriteEventLog("[ - Office-365 Processing 2 - ]");
                        AssignCertificatesOffice365();
                        WriteEventLog("[ - Office-365 Processing 3 - ]");
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                        WriteEventLog("[ - Office-365 Processing 4 - ]");
                    }
                    else
                    {
                        WriteEventLog("[ - EXCHANGE SERVER Processing 1 - ]");
                        service = GetBinding(MailBoxExchangeUser, MailBoxExchangePassword, MailBoxDomain, MailBoxEWSUrl);

                        AssignCertificates();
                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains("DC1"));
                        WriteEventLog("[ - EXCHANGE SERVER Processing 2 - ]");
                    }

                    // validate cert by calling a function 
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

                    Int64 EmailID = 0;
                    string EmailSubject = "";
                    string EmailBody = "";
                    string EmailFromName = "";
                    string EmailFromAddress = "";
                    DateTime EmailReceivedDTTM;
                    string EmailTo = "";
                    string EmailToCC = "";
                    bool bEmailHasAttachments = false;
                    int iEmailAttachmentCnt = 0;

                    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(MailBoxItemsPick));
                    
                    try
                    {
                        bool bMoveEmailAttachmenttoIndexFolder = false;
                        bool EmailBodyCreated = false;
                        string EmailUniqueID = "";
                        bool bEmailAttachmentDownloaded = false;

                        foreach (Item item in findResults.Items)
                        {
                            EmailSubject = "";
                            EmailBody = "";
                            EmailFromName = "";
                            EmailFromAddress = "";
                            EmailTo = "";
                            EmailToCC = "";
                            EmailUniqueID = "";
                            iEmailAttachmentCnt = 0;
                            bEmailHasAttachments = false;
                            EmailID = 0;

                            System.TimeSpan diffResultCurrent = System.Convert.ToDateTime(item.DateTimeReceived) - System.Convert.ToDateTime(DateTime.Today) ;
                            
                            EmailUniqueID = item.Id.UniqueId;
                            Item mess = Item.Bind(service, EmailUniqueID);
                            EmailMessage message = mess as EmailMessage;

                            if (MailBoxName == "Operations")
                            {
                                DataTable dtMancoAutoForwardFlag =  GetLimitationCodeValue("AUTO_FORWARD_INCOMING_OPS_EMAILS");
                                string AutoForwardOPSEmails = dtMancoAutoForwardFlag.Rows[0]["LIMITATION_VALUE"].ToString();
                                WriteEventLog("MANCO FORWARDING FLAG : " + AutoForwardOPSEmails);
                                if (AutoForwardOPSEmails == "YES")
                                {
                                    bool bForwardToManco = ForwardEmailToMANCO(message);
                                    if (bForwardToManco)
                                    {
                                        WriteEventLog("EMAIL FORWARDED SUCCESSFULLY TO MANCO");
                                    }
                                }
                            }

                            if (message.From != null)
                            {
                                EmailFromName = message.From.Name;
                                EmailFromAddress = message.From.Address;
                            }
                            else
                            {
                                EmailFromName = "UNKNOWN";
                                EmailFromAddress = "UNKNOWN";
                            }

                            if (!IsThisEmailValid(EmailFromName, EmailFromAddress))
                            {
                                for (int i = 0; i < message.ToRecipients.Count; i++)
                                {
                                    //EmailTo += message.ToRecipients[i].Name + "(" + message.ToRecipients[i].Address + ");";
                                    EmailTo += message.ToRecipients[i].Address + "; ";
                                }

                                if (!EmailTo.Trim().Equals(""))
                                {
                                    EmailTo = EmailTo.Substring(0, EmailTo.Length - 1);
                                }

                                if (message.CcRecipients != null)
                                {
                                    try
                                    {
                                        for (int i = 0; i < message.CcRecipients.Count; i++)
                                        {
                                            //EmailToCC += message.CcRecipients[i].Name + "(" + message.CcRecipients[i].Address + ");";
                                            EmailToCC += message.CcRecipients[i].Address.Trim() + "; ";
                                        }
                                    }
                                    catch (System.Exception ex)
                                    {
                                        WriteEventLog("Getting CC EMAILS Error: " + ex.ToString());
                                    }
                                }

                                if (!EmailToCC.Trim().Equals(""))
                                {
                                    EmailToCC = EmailToCC.Substring(0, EmailToCC.Length - 1);
                                }

                                EmailReceivedDTTM = item.DateTimeReceived;
                                EmailSubject = item.Subject;
                                EmailUniqueGUID = System.Guid.NewGuid().ToString();

                                sDir1 = EmailUniqueGUID.Substring(0, 1);
                                sDir2 = EmailUniqueGUID.Substring(1, 1);

                                EmailBody = message.Body;
                                EmailBodyType = message.Body.BodyType.ToString();
                                EmailID = 0;

                                WriteEventLog(" - Email Info - ");
                                WriteEventLog(" - EmailUniqueID - " + EmailUniqueID);
                                WriteEventLog(" - EmailSubject - " + EmailSubject);
                                WriteEventLog(" - EmailReceivedDTTM.ToString() - " + EmailReceivedDTTM.ToString());
                                WriteEventLog(" - EmailFromName - " + EmailFromName);
                                WriteEventLog(" - EmailFromAddress - " + EmailFromAddress);
                                WriteEventLog(" - EmailTo - " + EmailTo);
                                WriteEventLog(" - MailBoxID - " + MailBoxID);
                                WriteEventLog(" - EmailUniqueGUID - " + EmailUniqueGUID);
                                WriteEventLog(" - EmailToCC - " + EmailToCC);

                                bSaveEmailInfo = AIMS_EWS_Save_EmailInfo(ref EmailID, EmailUniqueID, EmailSubject, EmailReceivedDTTM.ToString(), EmailFromName, EmailFromAddress, EmailTo, MailBoxID, EmailUniqueGUID, EmailToCC);

                                string emailFolder = Path.Combine(MailBoxEWSEmailDownloadFolder,  sDir1 + @"\" + sDir2 + @"\" + EmailUniqueGUID);
                                if (bSaveEmailInfo)
                                {
                                    WriteEventLog("Email Info Successfully Saved.");

                                    if (!System.IO.Directory.Exists(emailFolder))
                                    {
                                        System.IO.Directory.CreateDirectory(emailFolder);
                                    }

                                    sEmailDownLoadFolder = emailFolder;

                                    EmailBodyFileName = Path.Combine(sEmailDownLoadFolder , EmailUniqueGUID + ".HTML");
                                    if (EmailBody == null)
                                    {
                                        EmailBody = "";
                                    }
                                    EmailBodyCreated = WriteHTMLMailMessage(EmailBodyFileName, EmailFromName, EmailReceivedDTTM.ToString(), EmailTo, EmailSubject, EmailFromAddress, EmailBody, EmailBodyType, EmailToCC);
                                    if (!EmailBodyCreated)
                                    {
                                        ErrorLog("[ERROR] - Email Body Creation ERROR.");
                                        EmailProcessingRollback(EmailID.ToString(), EmailUniqueGUID.ToString(), EmailAttachmentsList.ToString());
                                        MoveMailItem = false;
                                    }
                                    else
                                    {
                                        bEmailHasAttachments = item.HasAttachments;
                                        iEmailAttachmentCnt = message.Attachments.Count;
                                        bEmailAttachmentDownloaded = false;

                                        EmailAttachments = "";
                                        EmailAttachmentsList = "";
                                        EmailAttachmentsList = EmailBodyFileName + "|" + EmailAttachmentsList;
                                        AIMS_EWS_Save_Email_Attachments(EmailID, EmailAttachmentsList, ref EmailAttachments);

                                        if (bEmailHasAttachments | iEmailAttachmentCnt > 0)
                                        {
                                            EmailAttachmentsList = "";
                                            bEmailAttachmentDownloaded = DownloadAttachments(sEmailDownLoadFolder, EmailUniqueGUID, item, ref EmailAttachmentsList, message);
                                            if (bEmailAttachmentDownloaded)
                                            {
                                                if (!EmailAttachmentsList.Trim().Equals(""))
                                                {
                                                    bMoveEmailAttachmenttoIndexFolder = AIMS_EWS_Save_Email_Attachments(EmailID, EmailAttachmentsList, ref EmailAttachments);
                                                    if (!bMoveEmailAttachmenttoIndexFolder)
                                                    {
                                                        WriteEventLog("[ERROR] - Email Info NOT Successfully Saved.");
                                                        EmailProcessingRollback(EmailID.ToString(), EmailUniqueGUID.ToString(), EmailAttachmentsList.ToString());
                                                        MoveMailItem = false;
                                                    }
                                                    else
                                                    {
                                                        MoveMailItem = true;
                                                    }
                                                }
                                                else
                                                {
                                                    MoveMailItem = true;
                                                }
                                            }
                                            else
                                            {
                                                WriteEventLog("[ERROR] - NO Attachments found in EMAIL.");
                                            }
                                        }
                                        else
                                        {
                                            MoveMailItem = true;
                                        }
                                    }
                                }
                                else
                                {
                                    WriteEventLog("[ERROR] - Email Info NOT Successfully Saved.");
                                    EmailProcessingRollback(EmailID.ToString(), EmailUniqueGUID.ToString(), EmailAttachmentsList.ToString());
                                    MoveMailItem = false;
                                }
                            }
                            if (MoveMailItem)
                            {
                                try
                                {
                                    item.Delete(DeleteMode.MoveToDeletedItems);
                                }
                                catch (System.Exception ex)
                                {
                                    WriteEventLog("[ERROR] - Email Deletion Error: " + ex.ToString());
                                }
                            }

                            string AllowAutoIndexYN = GetAllowAutoIndexYN(MailBoxName);
                            
                            if (AllowAutoIndexYN.ToUpper().Equals("YES"))
                            {
                                //If email has a subject line
                                if (EmailSubject != null && EmailSubject.Trim().Length > 0)
                                {                                
                                    //string CheckPatientFile = CheckRendezvousFile(EmailSubject, "[-", "-]");
                                    string PatientFiles = CheckRendezvousFileInSubject(EmailSubject.Trim());
                                    if (!PatientFiles.Trim().Equals(""))
                                    {
                                        PatientFiles = PatientFiles.Replace("|", ";");
                                        string[] arrPatientFiles = PatientFiles.Split(new Char[] { ';' });
                                        string CheckPatientFile = "";

                                        foreach (string PatientFile in arrPatientFiles)
                                        {
                                            if (!PatientFile.Trim().Equals(""))
                                            {
                                                CheckPatientFile = PatientFile;
                                                bool ValidFile = ValidPatientFileNo(CheckPatientFile);

                                                if (ValidFile)
                                                {
                                                    bool OpsFileAllocPass = false; 
                                                    bool OpsFileAllocTest = false;
                                                    bool OpsFileAllocAdmin = false; 
                                                    switch (MailBoxName.ToUpper())
                                                    {
                                                        case "OPERATIONS":
                                                            OpsFileAllocPass = OperationsFileHandler(CheckPatientFile, QueryFileNo);
                                                            break;
                                                        case "TEST":
                                                            OpsFileAllocTest = AdminFileHandler(CheckPatientFile, AdminQueryFileNo);
                                                            break;
                                                        case "ADMIN":
                                                            OpsFileAllocAdmin = AdminFileHandler(CheckPatientFile, AdminQueryFileNo);
                                                            break;
                                                        default:
                                                            break;
                                                    }

                                                    if (OpsFileAllocPass || OpsFileAllocTest || OpsFileAllocAdmin)
                                                    {
                                                        string EmailStorageFolder = "";
                                                        bool EmailPODConstruction = AIMSEWSPODConstruct(ref EmailStorageFolder, EmailID.ToString());
                                                        if (!EmailPODConstruction)
                                                        {
                                                            ErrorLog("[ERROR] - Patient File Email Storage  [PATIENT FILE:" + CheckPatientFile + "]" + "[EMAIL ID: " + EmailID.ToString() + "]");
                                                        }
                                                        else
                                                        {
                                                            string PatientEmailEnquiryID = "";
                                                            string PatientFileNo = CheckPatientFile;

                                                            bool bPatientEmailSaved = AddPatientFileEmail(PatientFileNo, EmailID.ToString(), ref PatientEmailEnquiryID, "", "", MailBoxName.ToUpper());
                                                            if (!bPatientEmailSaved || PatientEmailEnquiryID.Equals(""))
                                                            {
                                                                ErrorLog("[ERROR] - Patient File Email Could not be attached to the case File [PATIENT FILE:" + PatientFileNo + "]" + "[EMAIL ID: " + EmailID.ToString() + "]");
                                                            }
                                                            else
                                                            {
                                                                bool EmailAttachment = ExtractEmailAttachmentToPOD(EmailStorageFolder, PatientEmailEnquiryID);
                                                                if (!EmailAttachment)
                                                                {
                                                                    ErrorLog("[ERROR] - Patient File email could not POD to the case [PATIENT FILE:" + PatientFileNo + "]" + "[EMAIL ID: " + EmailID.ToString() + "]");
                                                                }
                                                                else
                                                                {
                                                                    EmailIndexedFlag(EmailID.ToString());
                                                                }
                                                            }
                                                            //AddPatientFileTask(PatientFileNo, EmailID.ToString(), ref PatientEmailEnquiryID, "", "", MailBoxName.ToUpper());
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        ErrorLog(@"1. Download Email Error \n" + ex.ToString());
                        EmailProcessingRollback(EmailID.ToString(), EmailUniqueGUID.ToString(), EmailAttachmentsList.ToString());
                    }
                    finally
                    {
                        findResults = null;
                        service = null;
                        WriteEventLog("[DOWNLOAD EMAIL] - COMPLETED");
                    }
                }
            }
            catch (System.Exception downMailEx)
            {
                ErrorLog(@"2. Download Email Error \n" + downMailEx.ToString());
            }
            finally
            {
                dtMailboxes.Dispose();
                dtFile13.Dispose();
                dtMailboxes.Dispose();
            }
        }

        private string GetAllowAutoIndexYN(string MailBoxName)
        {
            DataTable dtParamCode = new DataTable();
            string AllowAutoIndexYN = "";
            switch (MailBoxName.ToUpper())
            {
                case "OPERATIONS":
                    dtParamCode = GetLimitationCodeValue("OPS_ENABLE_AUTO_INDEXING");
                    AllowAutoIndexYN = dtParamCode.Rows[0]["LIMITATION_VALUE"].ToString();
                    break;
                case "TEST":
                    dtParamCode = GetLimitationCodeValue("ADMIN_ENABLE_AUTO_INDEXING");
                    AllowAutoIndexYN = dtParamCode.Rows[0]["LIMITATION_VALUE"].ToString();
                    break;
                case "ADMIN":
                    dtParamCode = GetLimitationCodeValue("ADMIN_ENABLE_AUTO_INDEXING");
                    AllowAutoIndexYN = dtParamCode.Rows[0]["LIMITATION_VALUE"].ToString();
                    break;
                default:
                    break;
            }
            dtParamCode.Dispose();
            return AllowAutoIndexYN;
        }
        
        bool OperationsFileHandler(string CheckPatientFile, string QueryFileNo)
        {
            bool FileAllocated = true;
            string FileSentToAdmin = "";
            string FileDischargeDate = "";

            DataTable dtFileOperatorDetails = Get_Patient_File_Operator(CheckPatientFile);

            if (dtFileOperatorDetails.Rows.Count > 0)
            {
                if (dtFileOperatorDetails.Rows[0]["FILE_OPERATOR_TO_USERID"].ToString().Equals(""))
                {
                    if (!CheckPatientFile.Equals(QueryFileNo))
                    {
                        FileAllocated = false;
                    }
                }

                FileSentToAdmin = dtFileOperatorDetails.Rows[0]["SENT_TO_ADMIN"].ToString();
                FileDischargeDate = dtFileOperatorDetails.Rows[0]["PATIENT_DISCHARGE_DATE"].ToString();
            }

            dtFileOperatorDetails.Dispose();

            if (FileAllocated && (FileSentToAdmin.Equals("N") || FileSentToAdmin.Equals("")) && FileDischargeDate.Trim().Equals(""))
            {
                return true;
            }
            if (CheckPatientFile.Equals(QueryFileNo))
            {
                return false;
            }
            return false;
        }

        bool AdminFileHandler(string CheckPatientFile, string AdminQueryFileNo) 
        {
            bool FileAllocated = true;
            string FileSentToAdmin = "";
            string FileDischargeDate = "";

            DataTable dtFileOperatorDetails = Get_Patient_File_Operator(CheckPatientFile);

            if (dtFileOperatorDetails.Rows.Count > 0)
            {
                if (dtFileOperatorDetails.Rows[0]["FILE_ASSIGNED_TO_USERID"].ToString().Equals(""))
                {
                    if (!CheckPatientFile.Equals(AdminQueryFileNo))
                    {
                        FileAllocated = false;
                    }
                }

                FileSentToAdmin = dtFileOperatorDetails.Rows[0]["SENT_TO_ADMIN"].ToString();
                FileDischargeDate = dtFileOperatorDetails.Rows[0]["PATIENT_DISCHARGE_DATE"].ToString();
            }

            dtFileOperatorDetails.Dispose();

            if (FileAllocated && FileSentToAdmin.Equals("Y")  && !string.IsNullOrEmpty(FileDischargeDate))
            {
                return true;
            }
            if (CheckPatientFile.Equals(AdminQueryFileNo))
            {
                return false;
            }
            return false;
        }

        public bool EmailIndexedFlag(string Email_ID)
        {
            bool Returnvalue = false;
            try
            {
                EWSDAL commonFuncsDAL = new EWSDAL();
                Returnvalue = commonFuncsDAL.EmailIndexedFlag(Email_ID);
            }
            catch (System.Exception ex)
            {
                Returnvalue = false;
            }
            return Returnvalue;
        }

        private bool ExtractEmailAttachmentToPOD(string PODFileStructure, string PatientEnquiryID)
        {
            //commonFuncs = new AIMS.Common.CommonFunctions();
            bool ReturnValue = false;
            string EmailIndexingFile = "";
            string AttachmentFileName = "";
            string DocumentTypeID = "";
            try
            {
                string[] arrIndexDocs = EmailAttachments.Split(new Char[] { ',' });
                string[] arrIndexDocIndex = new string[0];

                foreach (string IndexFile in arrIndexDocs)
                {
                    if (!IndexFile.Trim().Equals(""))
                    {
                        arrIndexDocIndex = IndexFile.Split(new Char[] { '|' });
                        DataTable dtEmailAttachFile = new DataTable();

                        dtEmailAttachFile = GetEmailIndexFileLocation(arrIndexDocIndex[1].ToString());
                        DataTable dtLimitationCode = GetLimitationCodeValue("EMAIL_ATTACHMENT_DOC_TYPE");
                        if (dtLimitationCode.Rows.Count >0 )
                        {
                            DocumentTypeID = dtLimitationCode.Rows[0]["LIMITATION_VALUE"].ToString(); 
                        }
                        if (DocumentTypeID.Equals(""))
                        {
                            DocumentTypeID = arrIndexDocIndex[0].ToString();
                        }

                        EmailIndexingFile = dtEmailAttachFile.Rows[0]["ATTACHMENT_LOCATION"].ToString();
                        AttachmentFileName = Path.GetFileName(EmailIndexingFile);
                        if (File.Exists(EmailIndexingFile))
                        {
                            if (!PODFileStructure.EndsWith(@"\"))
                            {
                                PODFileStructure += @"\";
                            }
                            try
                            {
                                File.Copy(EmailIndexingFile, PODFileStructure + AttachmentFileName, true);
                                File.SetAttributes(PODFileStructure + AttachmentFileName, FileAttributes.Normal);
                            }
                            catch (System.IO.IOException ioEX)
                            {
                                ReturnValue = false;
                                //commonFuncs.ErrorLogger("ExtractEmailAttachmentToPOD FILE COPY FAILED - \n" + ioEX.ToString());
                                return false;
                            }

                            bool EmailPODDelivered = EmailAttachmentPODDelivery(PODFileStructure + AttachmentFileName, DocumentTypeID, PatientEnquiryID);
                            if (EmailPODDelivered)
                            {
                                ReturnValue = true;
                            }
                            else
                            {
                                ReturnValue = false;
                                //commonFuncs.ErrorLogger("ExtractEmailAttachmentToPOD Method Error - Saving the Email Documents");
                            }
                        }

                        dtEmailAttachFile.Dispose();
                    }
                }
            }
            catch (System.Exception ex)
            {
                ReturnValue = false;
                //commonFuncs.ErrorLogger("ExtractEmailAttachmentToPOD Method Error - \n" + ex.ToString());
            }
            return ReturnValue;
        }

        public bool EmailAttachmentPODDelivery(string EmailAttachmentFile, string DocTypeID, string PatientEnquiryID)
        {
            bool returnVal = false;
            EWSDAL oDAL = new EWSDAL();
            returnVal = oDAL.EmailAttachmentPODDelivery(EmailAttachmentFile, DocTypeID, PatientEnquiryID);
            returnVal = true;
            return returnVal;
        }

        public DataTable GetEmailIndexFileLocation(string EmailAttachmentID)
        {
            DataTable dtPODDetails = new DataTable();
            try
            {
                EWSDAL oDAL = new EWSDAL();
                dtPODDetails = oDAL.GetEmailIndexFileLocation(EmailAttachmentID);
            }
            finally
            {
            }
            return dtPODDetails;
        }

        public DataTable Get_Patient_File_Operator(string PatientFileNo)
        {
            EWSDAL DALPatientFileOperator = new EWSDAL();
            DataTable dtPatientFileOperator = new DataTable();
            try
            {
                dtPatientFileOperator = DALPatientFileOperator.Get_Patient_File_Operator(PatientFileNo);
            }
            finally
            {
                DALPatientFileOperator = null;
            }
            return dtPatientFileOperator;
        }

        public bool AIMSEWSPODConstruct(ref string EmailStorageFolder, string EmailID)
        {
            string InstrumentationStep = "";

            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2 - a";
            //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());

            DataTable dtPODData = GetPODData(EmailID);
            InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2 - b";
            //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());
            bool ReturnValue = false;
            try
            {
                string PODSizeCheckError = "";
                string PodDiskLetter = "";
                string PodEmailGUID = "";
                long PodCounter = 0;
                string PODFolder = "";
                string EmailMailBoxID = "";

                PodCounter = System.Convert.ToInt64(dtPODData.Rows[0]["MAILBOX_POD_COUNTER"]);
                PodDiskLetter = dtPODData.Rows[0]["MAILBOX_EMAILS_STORE_FOLDER"].ToString().ToUpper();
                PodEmailGUID = dtPODData.Rows[0]["EMAIL_GUID"].ToString().ToUpper();
                EmailMailBoxID = dtPODData.Rows[0]["MAILBOX_ID"].ToString();

                PODFolder = PodDiskLetter + @"POD" + PodCounter.ToString() + @"\";
                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2 - c";
                //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());

                //create the POD Directory 
                if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                //double PodByteSize = commonFuncs.GetPODDirectorySize(PODFolder, ref PODSizeCheckError);
                double PodByteSize = 0;

                if (!PODSizeCheckError.Equals(""))
                {
                    //ErrorLogger("AIMSEWSPODConstruct - Calculating POD Size Structure ERROR: \n" + PODSizeCheckError);
                    return false;
                }
                //POD Folder must be greater than 4 Gigs, 
                if (PodByteSize >= 3999999999)
                {
                    PodCounter++;
                    //UpdateMailBoxPODCounter(EmailMailBoxID, PodCounter.ToString());
                    PODFolder = PodDiskLetter + @"POD" + PodCounter.ToString() + @"\";

                    //create the POD Directory 
                    if (!Directory.Exists(PODFolder)) { Directory.CreateDirectory(PODFolder); }
                }

                string sDir1 = PodEmailGUID.Substring(0, 1);
                string sDir2 = PodEmailGUID.Substring(1, 1);
                if (!System.IO.Directory.Exists(PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID))
                {
                    System.IO.Directory.CreateDirectory(PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID);
                }
                EmailStorageFolder = PODFolder + sDir1 + @"\" + sDir2 + @"\" + PodEmailGUID;
                ReturnValue = true;
                InstrumentationStep = DateTime.Now.TimeOfDay.ToString() + @" - STEP 2 - d";
                //commonFuncs.ErrorLogger("Indexing Email Steps Instrumentation: " + InstrumentationStep.ToString());
            }
            catch (System.Exception ex)
            {
                //ErrorLogger("AIMSEWSPODConstruct Function Error: \n" + ex.ToString());
                ReturnValue = false;
            }
            finally
            {
                dtPODData.Dispose();
            }
            return ReturnValue;
        }

        private string CreateEMLMailBody(string emlBodyFileName, string emlBodyText)
        {
            try
            {
                StreamWriter sw = null;
                sw = File.CreateText(emlBodyFileName);
                sw.WriteLine(emlBodyText);
                sw.Flush();
                sw.Close();
                sw = null;
            }
            catch (System.Exception ex)
            {
                return "";
            }
            return emlBodyFileName;
        }

        public bool DownloadAttachments(string EAttachmentTempFolder, string EmailUniqueID, Item itm, ref string EmailAttachment, EmailMessage message)
        {
            int AttachCnt = 0;
            string EmailAttachName = "";
            bool ReturnValue = false;
            System.IO.FileInfo ffInfo;
            string EmailAttachmentFile = "";
            string AttachmentFileName = "";
            int AttachmentCnt = itm.Attachments.Count;
            string AttachedFileName = "";
            try
            {
                foreach (Attachment attachment in message.Attachments)
                {
                    AttachCnt++;
                    if (attachment is FileAttachment)
                    {
                        FileAttachment fileAttachment = attachment as FileAttachment;
                        fileAttachment.Load();
                        AttachmentFileName = EmailUniqueID + "_" + AttachCnt + "_" + ReplaceMultiple(fileAttachment.Name, "", ";", ",", "*", "(", ")", ",", "~", "!", "@", "#", "$", "%", "^", "&", "?", "<", ">", "_", "|");
                        // Load attachment contents into a file.
                        AttachedFileName = Path.Combine(EAttachmentTempFolder , AttachmentFileName);
                        fileAttachment.Load(AttachedFileName);
                        
                        // Stream attachment contents into a file.
                        FileStream theStream = new FileStream(EAttachmentTempFolder + AttachmentFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        fileAttachment.Load(theStream);
                        theStream.Close();
                        theStream.Dispose();
                        ffInfo = new FileInfo(Path.Combine(EAttachmentTempFolder , AttachmentFileName));
                        ffInfo.MoveTo(Path.Combine(EAttachmentTempFolder  , AttachmentFileName));
                        EmailAttachmentFile = Path.Combine(EAttachmentTempFolder , AttachmentFileName);
                    }
                    else // Attachment is an item attachment.
                    {
                        //ItemAttachment itemAttachment = attachment as ItemAttachment;
                        ItemAttachment itemAttachment = attachment as ItemAttachment;
                        EmailAttachName = EmailUniqueID + "_" + AttachCnt + "_" + ReplaceMultiple(itemAttachment.Name, "", ";", ",", "*", "(", ")", ",", "~", "!", "@", "#", "$", "%", "^", "&", "?", "<", ">", "_") + ".eml";
                        itemAttachment.Load();

                        string EMLBodyFile = "";
                        string emlEmailBody = (itemAttachment.Item).Body;
                        if (emlEmailBody != null && !emlEmailBody.Equals(""))
                        {
                            string emlBodyTypeExt = "";
                            if ((itemAttachment.Item).Body.BodyType == BodyType.HTML)
                            {
                                emlBodyTypeExt = ".HTML";
                            }
                            else
                            {
                                emlBodyTypeExt = ".TXT";
                            }

                            if (@EAttachmentTempFolder.EndsWith(@"\"))
                                EAttachmentTempFolder+= @"\";
                            
                            EMLBodyFile = CreateEMLMailBody(EAttachmentTempFolder + EmailUniqueID + "_" + AttachCnt + "_" + "EMAIL_EML" + emlBodyTypeExt, emlEmailBody); 
                        }

                        foreach (Attachment subAttachment in itemAttachment.Item.Attachments)
                        {
                            if (subAttachment is FileAttachment)
                            {
                                try
                                {
                                    AttachCnt++;
                                    FileAttachment fileAttachment = subAttachment as FileAttachment;
                                    fileAttachment.Load();
                                    AttachmentFileName = EmailUniqueID + "_" + AttachCnt + "_" + ReplaceMultiple(fileAttachment.Name, "", ";", ",", "*", "(", ")", ",", "~", "!", "@", "#", "$", "%", "^", "&", "?", "<", ">", "_", "|");
                                    // Load attachment contents into a file.
                                    fileAttachment.Load(EAttachmentTempFolder + AttachmentFileName);

                                    // Stream attachment contents into a file.
                                    FileStream theStream = new FileStream(EAttachmentTempFolder + AttachmentFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fileAttachment.Load(theStream);
                                    theStream.Close();
                                    theStream.Dispose();
                                    ffInfo = new FileInfo(EAttachmentTempFolder + AttachmentFileName);
                                    ffInfo.MoveTo(EAttachmentTempFolder + AttachmentFileName);
                                    EmailAttachmentFile = EAttachmentTempFolder + AttachmentFileName;
                                }
                                catch (System.Exception ex)
                                {
                                    if (ex.Message.Contains("The specified attachment Id is invalid"))
                                    {
                                        ErrorLog("1. Email With an Attachment could not be downloaded - Attachment Name : \n" + itemAttachment.Name);
                                    }
                                    else
                                    {
                                        ErrorLog("2. Email With an Attachment could not be downloaded - Attachment Name : \n" + itemAttachment.Name);
                                    }
                                    ErrorLog(ex.ToString());
                                }
                            }
                        }

                        if (!EMLBodyFile.Trim().Equals(""))
	                    {
		                     EmailAttachmentFile = EMLBodyFile;
	                    }
                    }
                    if (!EmailAttachmentFile.Equals(""))
                    {
                        EmailAttachment += EmailAttachmentFile + "|";    
                    }
                }

                if (!EmailAttachment.Equals(""))
                {
                    if (EmailAttachment.Trim().EndsWith("|"))
                    {
                        EmailAttachment = EmailAttachment.Substring(0, EmailAttachment.Length - 1);    
                    }
                }
                ReturnValue = true;
            }
            catch (System.Exception ex)
            {
                EmailAttachment = "";
                ErrorLog("DownloadAttachments Method Error: \n" + ex.ToString());
            }
            finally
            {
                ffInfo = null;
            }
            return ReturnValue;
        }

        public bool MoveEmailAttachments(string AllEmailAttachmentFiles)
        {
            bool ReturnValue = false;
            return ReturnValue;
        }

        #region "Database Methods"
        private static string DBConnectionString()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["ConnectString"]; ;
        }

        /// <summary>
        ///     Get the list of AIMS Mailboxes
        /// </summary>
        /// <returns></returns>
        private DataTable AIMS_EWS_Mailboxes()
        {
            DataTable dtAIMSMailboxes = new DataTable();
            try
            {
                EWSDAL oDAL = new EWSDAL();
                dtAIMSMailboxes = oDAL.Get_AIMS_Mailboxes();
            }
            catch (System.Exception ex)
            {
                ErrorLog("AIM EWS Error getting list of Mailboxes: \n" + ex.ToString());
            }
            return dtAIMSMailboxes;
        }

        private DataTable GetPODData(string EmailID)
        {
            DataTable dtPODData = new DataTable();
            try
            {
                EWSDAL oDAL = new EWSDAL();
                dtPODData = oDAL.GetPODData(EmailID);
            }
            catch (System.Exception ex)
            {
                ErrorLog("AIM EWS Error getting list of Mailboxes: \n" + ex.ToString());
            }
            return dtPODData;
        }
        

        public bool ValidPatientFileNo(string PatientFileNo)
        {
            DataTable dtPatientExist = new DataTable();
            bool Returnvalue = false;
            try
            {
                EWSDAL oDAL = new EWSDAL();
                
                if (PatientFileNo.Trim().Length > 0)
                {
                    dtPatientExist = oDAL.ValidPatientFileNo(PatientFileNo);
                    Returnvalue = dtPatientExist.Rows.Count > 0 ? true : false;
                }
                else
                {
                    Returnvalue = false;
                }
            }
            catch (System.Exception ex)
            {
                Returnvalue = false;
            }
            return Returnvalue;
        }

        private bool AIMS_EWS_Save_EmailInfo(ref Int64 EMAIL_ID, string EMAIL_UNIQUE_ID, string EMAIL_SUBJECT, string EMAIL_RECEIVED_DTTM, string EMAIL_SENT_FROM_NAME, string EMAIL_SENT_FROM_ADDRESS, string EMAIL_SENT_TO, int MailBoxID, string EMAIL_GUID, string EMAIL_TO_CC)
        {
            bool ReturnValue = false;
            try
            {
                EWSDAL oDAL = new EWSDAL();
                ReturnValue = oDAL.AIMS_EWS_Save_EmailInfo(ref EMAIL_ID, EMAIL_UNIQUE_ID, EMAIL_SUBJECT, EMAIL_RECEIVED_DTTM, EMAIL_SENT_FROM_NAME, EMAIL_SENT_FROM_ADDRESS, EMAIL_SENT_TO, MailBoxID, EMAIL_GUID, EMAIL_TO_CC);
            }
            catch (System.Exception ex)
            {
                ErrorLog("AIM EWS Error Saving Email Info: \n" + ex.ToString());
            }
            return ReturnValue;
        }

        public bool AddPatientFileEmail(string PatientFileNo, string Email_ID, ref string PatientEmailEnquiryID, string UrgentEmail, string File13Query, string MailBoxName)
        {
            bool Returnvalue = false;
            try
            {
                EWSDAL oDAL = new EWSDAL();
                Returnvalue = oDAL.AddPatientFileEmail(PatientFileNo, Email_ID, ref PatientEmailEnquiryID, UrgentEmail, File13Query, MailBoxName);
            }
            catch (System.Exception ex)
            {
                ErrorLog("AIM EWS Error Param1: " + PatientFileNo);
                ErrorLog("AIM EWS Error Param2: " + Email_ID);
                ErrorLog("AIM EWS Error Param3: " + PatientEmailEnquiryID);
                ErrorLog("AIM EWS Error Param4: " + UrgentEmail);
                ErrorLog("AIM EWS Error Param5: " + File13Query);
                ErrorLog("AIM EWS Error Param6: " + MailBoxName);
                ErrorLog("AIM EWS Error - Adding Patient File Email to a MalBox: \n" + ex.ToString());
            }
            return Returnvalue;
        }
        
        public bool AddPatientFileTask(string PatientFileNo, string Email_ID, ref string PatientEmailEnquiryID, string UrgentEmail, string File13Query, string MailBoxName)
        {
            bool Returnvalue = false;
            try
            {
                EWSDAL oDAL = new EWSDAL();
                Returnvalue = oDAL.AddPatientFileTask(PatientFileNo, Email_ID, ref PatientEmailEnquiryID, UrgentEmail, File13Query, MailBoxName);
            }
            catch (System.Exception ex)
            {
                ErrorLog("AIM EWS Error Param1: " + PatientFileNo);
                ErrorLog("AIM EWS Error Param2: " + Email_ID);
                ErrorLog("AIM EWS Error Param3: " + PatientEmailEnquiryID);
                ErrorLog("AIM EWS Error Param4: " + UrgentEmail);
                ErrorLog("AIM EWS Error Param5: " + File13Query);
                ErrorLog("AIM EWS Error Param6: " + MailBoxName);
                ErrorLog("AIM EWS Error - Adding Patient File Email to a MalBox: \n" + ex.ToString());
            }
            return Returnvalue;
        }

        private bool AIMS_EWS_Delete_EmailInfo(string EMAIL_ID)
        {
            bool ReturnValue = false;
            try
            {
                EWSDAL oDAL = new EWSDAL();
                ReturnValue = oDAL.AIMS_EWS_Delete_EmailInfo(EMAIL_ID);
            }
            catch (System.Exception ex)
            {
                ErrorLog("AIM EWS Error Saving Email Info: \n" + ex.ToString());
            }
            return ReturnValue;
        }

        private bool AIMS_EWS_Save_Email_Attachments(Int64 EMAIL_ID, string EMAIL_Attachment_List, ref string EmailAttachments)
        {
            bool ReturnValue = false;
            try
            {
                EWSDAL oDAL = new EWSDAL();
                //string[] AttachmentList  = new;
                char[] attachmentDelim = { '|' };
                string[] AttachmentList = EMAIL_Attachment_List.Split(attachmentDelim);
                Int64 EmailAttachmentID = 0;

                foreach (string EmailAttachmentFile in AttachmentList)
                {
                    //if (File.Exists(EmailAttachmentFile))
                    //{
                        if (!EmailAttachmentFile.Trim().Equals(""))
                        {
                            ReturnValue = oDAL.AIMS_EWS_Save_EmailAttachments(EMAIL_ID, EmailAttachmentFile, ref EmailAttachmentID);
                            EmailAttachments += "7|" + EmailAttachmentID.ToString() + ",";
                            if (!ReturnValue) { break; }
                        }   
                    //}
                }
            }
            catch (System.Exception ex)
            {
                ErrorLog("AIMS EWS Saving Email attachments Failed: \n" + ex.ToString());
            }
            return ReturnValue;
        }

        #endregion

        private void EmailProcessingRollback(string EmailID, string EmailUniqueGUID, string EmailAttachmentList) {
            try
            {
                if (!EmailAttachmentList.Trim().Equals(""))
                {
                    char[] attachList = { '|' };
                    string[] AttachmentList = EmailAttachmentList.Split(attachList);

                    foreach (string mailattachment in AttachmentList)
                    {
                        try
                        {
                            if (File.Exists(mailattachment))
                            {
                                File.SetAttributes(mailattachment, FileAttributes.Normal);
                                File.Delete(mailattachment);   
                            }
                        }
                        catch (System.IO.IOException ex)
                        {
                            ErrorLog("Rollback Error, Deleting temporary Files failed: " + ex.ToString());
                        }
                    }
                }

                if (!EmailID.Trim().Equals(""))
                {
                    AIMS_EWS_Delete_EmailInfo(EmailID.ToString());
                }
            }
            catch (System.Exception ex)
            {
                ErrorLog("EMAIL PROCESSING ROLLBACK FAILED: \n" + ex.ToString());
            }
        }

        /// <summary>
        ///     Validate if this email is from valid source and also not an auto-reply
        /// </summary>
        /// <param name="sEmailFromName"></param>
        /// <param name="sEmailFromAddress"></param>
        /// <returns></returns>
        private bool IsThisEmailValid(string sEmailFromName, string sEmailFromAddress)
        {
            bool ReturnValue = false;
            try
            {
                if (!sEmailFromName.Trim().Equals("") && (sEmailFromName.ToUpper().Contains("MAILMARSHAL") ||
                                                            sEmailFromName.ToUpper().Contains("MAILMARSHAL"))) //|| sEmailFromName.ToUpper().Contains("POSTMASTER")
                {
                    ReturnValue = true;
                }

                if (!sEmailFromAddress.Trim().Equals("") && (sEmailFromAddress.ToUpper().Contains("MAILMARSHAL"))) //|| sEmailFromAddress.ToUpper().Contains("POSTMASTER")
                {
                    ReturnValue = true;
                }
            }
            catch (System.Exception ex)
            {
            }
            finally 
            {
                
            }
            return ReturnValue;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEmail_Subject"></param>
        /// <returns></returns>
        private string CheckRendezvousFileInSubject(string EmailSubject)
        {
            string PatientFiles = "";
            try
            {
                EmailSubject = EmailSubject.Replace(@"[-", " ");
                EmailSubject = EmailSubject.Replace(@"-]", " ");

                //Append spaces at the beginning and the end of the string
                EmailSubject = " " + EmailSubject + " ";

                string input4 = @EmailSubject;
                Regex word4 = new Regex(@"\b\d{1,2}\/\d{1,4}\b");

                Match m4 = word4.Match(input4);
                while (!m4.ToString().Trim().Equals(""))
                {
                    if (!m4.ToString().Trim().Equals(""))
                    {
                        PatientFiles += m4.ToString() + "|";
                    }
                    input4 = input4.Replace(m4.ToString(), "");
                    word4 = new Regex(@"\b\d{1,2}\/\d{1,4}\b");
                    m4 = word4.Match(input4);
                }

                word4 = new Regex(@"\b\d{1,2}\\\d{1,4}\b");

                m4 = word4.Match(input4);
                while (!m4.ToString().Trim().Equals(""))
                {
                    if (!m4.ToString().Trim().Equals(""))
                    {
                        PatientFiles += m4.ToString().Replace(@"\", @"/") + "|";
                    }
                    input4 = input4.Replace(m4.ToString(), "");
                    word4 = new Regex(@"\b\d{1,2}\\\d{1,4}\b");
                    m4 = word4.Match(input4);
                }

                if (!PatientFiles.Equals("") && PatientFiles.EndsWith("|"))
                {
                    PatientFiles = PatientFiles.Substring(0, PatientFiles.Length - 1);
                }
            }
            catch (System.Exception)
            {
            }
            return PatientFiles;

        }


		/// <summary>
		/// Creates an encoder to create an InfoPath attachment string.
		/// </summary>
		/// <param name="fullyQualifiedFileName"></param>
		public void InfoPathAttachmentEncoder(string fullyQualifiedFileName)
		{
			if (fullyQualifiedFileName == string.Empty)
				throw new ArgumentException("Must specify file name", "fullyQualifiedFileName");

			if (!File.Exists(fullyQualifiedFileName))
				throw new FileNotFoundException("File does not exist: " + fullyQualifiedFileName, fullyQualifiedFileName);

			this.fullyQualifiedFileName = fullyQualifiedFileName;
		}

        private bool ForwardEmailToMANCO(EmailMessage emailMessage)
        {
            try
            {

                string messageBodyPrefix = "Incoming email automatically forwarded from the AIMS-Legacy System";
                
                ResponseMessage responseMessage = emailMessage.CreateForward();

                DataTable dtMancoAutoForwardFlag = GetLimitationCodeValue("AIMS_MANCO_TEAM");
                string AutoForwardOPSMANCOEmails = dtMancoAutoForwardFlag.Rows[0]["LIMITATION_VALUE"].ToString();

                WriteEventLog("MANCO Email TEAM : " + AutoForwardOPSMANCOEmails);
                string[] arrmandoEmails = AutoForwardOPSMANCOEmails.Split(new Char[] { ';' });

                foreach (string emailadd in arrmandoEmails)
                {
                    if (!emailadd.Trim().Equals(""))
                    {
                        responseMessage.ToRecipients.Add(emailadd);
                    }
                }
                
                responseMessage.BodyPrefix = messageBodyPrefix;

                responseMessage.Send();

                return true;
            }
            catch (System.Exception ex)
            {
                WriteEventLog("MANCO Email Forwarding Error: " + ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// Returns a Base64 encoded string.
        /// </summary>
        /// <returns>String</returns>
        public string ToBase64String()
        {
            if (base64EncodedFile != string.Empty)
                return base64EncodedFile;

            // This memory stream will hold the InfoPath file attachment buffer before Base64 encoding.
            MemoryStream ms = new MemoryStream();

            // Get the file information.
            using (BinaryReader br = new BinaryReader(File.Open(fullyQualifiedFileName, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                string fileName = Path.GetFileName(fullyQualifiedFileName);

                uint fileNameLength = (uint)fileName.Length + 1;

                byte[] fileNameBytes = Encoding.Unicode.GetBytes(fileName);

                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    // Write the InfoPath attachment signature. 
                    bw.Write(new byte[] { 0xC7, 0x49, 0x46, 0x41 });

                    // Write the default header information.
                    bw.Write((uint)0x14);	// size
                    bw.Write((uint)0x01);	// version
                    bw.Write((uint)0x00);	// reserved

                    // Write the file size.
                    bw.Write((uint)br.BaseStream.Length);

                    // Write the size of the file name.
                    bw.Write((uint)fileNameLength);

                    // Write the file name (Unicode encoded).
                    bw.Write(fileNameBytes);

                    // Write the file name terminator. This is two nulls in Unicode.
                    bw.Write(new byte[] { 0, 0 });

                    // Iterate through the file reading data and writing it to the outbuffer.
                    byte[] data = new byte[64 * 1024];
                    int bytesRead = 1;

                    while (bytesRead > 0)
                    {
                        bytesRead = br.Read(data, 0, data.Length);
                        bw.Write(data, 0, bytesRead);
                    }
                }
            }


            // This memorystream will hold the Base64 encoded InfoPath attachment.
            MemoryStream msOut = new MemoryStream();

            using (BinaryReader br = new BinaryReader(new MemoryStream(ms.ToArray())))
            {
                // Create a Base64 transform to do the encoding.
                ToBase64Transform tf = new ToBase64Transform();

                byte[] data = new byte[tf.InputBlockSize];
                byte[] outData = new byte[tf.OutputBlockSize];

                int bytesRead = 1;

                while (bytesRead > 0)
                {
                    bytesRead = br.Read(data, 0, data.Length);

                    if (bytesRead == data.Length)
                        tf.TransformBlock(data, 0, bytesRead, outData, 0);
                    else
                        outData = tf.TransformFinalBlock(data, 0, bytesRead);
                        msOut.Write(outData, 0, outData.Length);
                }
            }

            msOut.Close();

            return base64EncodedFile = Encoding.ASCII.GetString(msOut.ToArray());
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
                //MessageBox.Show("Message Sending Successful");
            }
            catch (Exception ex)
            {

                //MessageBox.Show("CreateAndSendMail Error: " + ex.ToString());
            }
        }

        public void DownloadFromOffice365Email()
        {
            WriteEventLog("[DOWNLOAD EMAIL] - STARTED");
            DataTable dtMailboxes = AIMS_EWS_Mailboxes();
            string MailBoxName = "";
            string MailBoxExchangeUser = "";
            string MailBoxExchangePassword = "";
            string MailBoxDomain = "";
            string MailBoxEWSUrl = "";
            int MailBoxItemsPick = 1;
            string MailBoxEWSEmailDownloadFolder = "";
            string EmailUniqueGUID = "";
            string EmailBodyFileName = "";
            string EmailBodyType = "";
            string MailBoxArchivingFolder = "";
            int MailBoxID = 0;
            bool bSaveEmailInfo = false;
            string sDir1 = string.Empty;
            string sDir2 = string.Empty;
            string sEmailDownLoadFolder = string.Empty;
            string EmailAttachmentsList = "";
            bool MoveMailItem = false;

            DataTable dtFile13 = GetLimitationCodeValue("AIMS_FILE_13_QUERIES");
            DataTable dtFileAdmin13 = GetLimitationCodeValue("AIMS_ADMIN_QUERIES_FILE");
            try
            {
                string QueryFileNo = dtFile13.Rows[0]["LIMITATION_VALUE"].ToString();
                string AdminQueryFileNo = dtFileAdmin13.Rows[0]["LIMITATION_VALUE"].ToString();

                dtFile13.Dispose();
                dtFileAdmin13.Dispose();

                //Loop through all configured Email boxes
                foreach (DataRow dr in dtMailboxes.Rows)
                {
                    MailBoxID = System.Convert.ToInt16(dr["MAILBOX_ID"]);
                    MailBoxName = dr["MAILBOX_NAME"].ToString();
                    MailBoxExchangeUser = dr["MAILBOX_EXCHANGE_USER"].ToString();
                    MailBoxExchangePassword = dr["MAILBOX_EXCHANGE_PASSWORD"].ToString();
                    MailBoxDomain = dr["MAILBOX_AD_DOMAIN"].ToString();
                    MailBoxEWSUrl = dr["MAILBOX_EWS_URL"].ToString();
                    MailBoxItemsPick = (int)dr["MAILBOX_ITEMS_PICK"];
                    MailBoxEWSEmailDownloadFolder = dr["MAILBOX_EMAILS_STORE_FOLDER"].ToString();
                    MailBoxArchivingFolder = dr["MAILBOX_ARCHIVE_FOLDER_NAME"].ToString();

                    if (!MailBoxEWSEmailDownloadFolder.EndsWith(@"\"))
                    {
                        MailBoxEWSEmailDownloadFolder += MailBoxEWSEmailDownloadFolder + @"\";
                    }
                     
                    if (!Directory.Exists(MailBoxEWSEmailDownloadFolder))
                    {
                        ErrorLog("Creating Directory: " + MailBoxEWSEmailDownloadFolder);
                        Directory.CreateDirectory(MailBoxEWSEmailDownloadFolder);
                    }

                    //Office365 -------https://outlook.office365.com/EWS/Exchange.asmx 
                    //Exchange  -------https://dc1/ews/exchange.asmx
                    DataTable dtOffice365Check = GetLimitationCodeValue("OFFICE_365_ENABLED");
                    string office365EnabledYN = dtOffice365Check.Rows[0]["LIMITATION_VALUE"].ToString();
                    if (office365EnabledYN == "Y")
                    {
                        service = GetBindingOffice365(MailBoxExchangeUser, MailBoxExchangePassword, MailBoxDomain, MailBoxEWSUrl);
                        AssignCertificatesOffice365();
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                        object obj1 = new object();

                        // validate cert by calling a function 
                        System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

                    }

                    Int64 EmailID = 0;
                    string EmailSubject = "";
                    string EmailBody = "";
                    string EmailFromName = "";
                    string EmailFromAddress = "";
                    DateTime EmailReceivedDTTM;
                    string EmailTo = "";
                    string EmailToCC = "";
                    bool bEmailHasAttachments = false;
                    int iEmailAttachmentCnt = 0;

                    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(MailBoxItemsPick));

                    try
                    {
                        bool bMoveEmailAttachmenttoIndexFolder = false;
                        bool EmailBodyCreated = false;
                        string EmailUniqueID = "";
                        bool bEmailAttachmentDownloaded = false;

                        foreach (Item item in findResults.Items)
                        {
                            EmailSubject = "";
                            EmailBody = "";
                            EmailFromName = "";
                            EmailFromAddress = "";
                            EmailTo = "";
                            EmailToCC = "";
                            EmailUniqueID = "";
                            iEmailAttachmentCnt = 0;
                            bEmailHasAttachments = false;
                            EmailID = 0;

                            System.TimeSpan diffResultCurrent = System.Convert.ToDateTime(item.DateTimeReceived) - System.Convert.ToDateTime(DateTime.Today);

                            EmailUniqueID = item.Id.UniqueId;
                            Item mess = Item.Bind(service, EmailUniqueID);
                            EmailMessage message = mess as EmailMessage;

                            if (MailBoxName == "Operations")
                            {
                                DataTable dtMancoAutoForwardFlag = GetLimitationCodeValue("AUTO_FORWARD_INCOMING_OPS_EMAILS");
                                string AutoForwardOPSEmails = dtMancoAutoForwardFlag.Rows[0]["LIMITATION_VALUE"].ToString();
                                WriteEventLog("MANCO FORWARDING FLAG : " + AutoForwardOPSEmails);
                                if (AutoForwardOPSEmails == "YES")
                                {
                                    bool bForwardToManco = ForwardEmailToMANCO(message);
                                    if (bForwardToManco)
                                    {
                                        WriteEventLog("EMAIL FORWARDED SUCCESSFULLY TO MANCO");
                                    }
                                }
                            }

                            if (message.From != null)
                            {
                                EmailFromName = message.From.Name;
                                EmailFromAddress = message.From.Address;
                            }
                            else
                            {
                                EmailFromName = "UNKNOWN";
                                EmailFromAddress = "UNKNOWN";
                            }

                            if (!IsThisEmailValid(EmailFromName, EmailFromAddress))
                            {
                                for (int i = 0; i < message.ToRecipients.Count; i++)
                                {
                                    //EmailTo += message.ToRecipients[i].Name + "(" + message.ToRecipients[i].Address + ");";
                                    EmailTo += message.ToRecipients[i].Address + "; ";
                                }

                                if (!EmailTo.Trim().Equals(""))
                                {
                                    EmailTo = EmailTo.Substring(0, EmailTo.Length - 1);
                                }

                                if (message.CcRecipients != null)
                                {
                                    try
                                    {
                                        for (int i = 0; i < message.CcRecipients.Count; i++)
                                        {
                                            //EmailToCC += message.CcRecipients[i].Name + "(" + message.CcRecipients[i].Address + ");";
                                            EmailToCC += message.CcRecipients[i].Address.Trim() + "; ";
                                        }
                                    }
                                    catch (System.Exception ex)
                                    {
                                        WriteEventLog("Getting CC EMAILS Error: " + ex.ToString());
                                    }
                                }

                                if (!EmailToCC.Trim().Equals(""))
                                {
                                    EmailToCC = EmailToCC.Substring(0, EmailToCC.Length - 1);
                                }

                                EmailReceivedDTTM = item.DateTimeReceived;
                                EmailSubject = item.Subject;
                                EmailUniqueGUID = System.Guid.NewGuid().ToString();

                                sDir1 = EmailUniqueGUID.Substring(0, 1);
                                sDir2 = EmailUniqueGUID.Substring(1, 1);

                                EmailBody = message.Body;
                                EmailBodyType = message.Body.BodyType.ToString();
                                EmailID = 0;

                                WriteEventLog(" - Email Info - ");
                                WriteEventLog(" - EmailUniqueID - " + EmailUniqueID);
                                WriteEventLog(" - EmailSubject - " + EmailSubject);
                                WriteEventLog(" - EmailReceivedDTTM.ToString() - " + EmailReceivedDTTM.ToString());
                                WriteEventLog(" - EmailFromName - " + EmailFromName);
                                WriteEventLog(" - EmailFromAddress - " + EmailFromAddress);
                                WriteEventLog(" - EmailTo - " + EmailTo);
                                WriteEventLog(" - MailBoxID - " + MailBoxID);
                                WriteEventLog(" - EmailUniqueGUID - " + EmailUniqueGUID);
                                WriteEventLog(" - EmailToCC - " + EmailToCC);
                            }
                            if (MoveMailItem)
                            {
                                item.Delete(DeleteMode.MoveToDeletedItems);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        ErrorLog(@"1. Download Email Error \n" + ex.ToString());
                        EmailProcessingRollback(EmailID.ToString(), EmailUniqueGUID.ToString(), EmailAttachmentsList.ToString());
                    }
                    finally
                    {
                        findResults = null;
                        service = null;
                        WriteEventLog("[DOWNLOAD EMAIL] - COMPLETED");
                    }
                }
            }
            catch (System.Exception downMailEx)
            {
                ErrorLog(@"2. Download Email Error \n" + downMailEx.ToString());
            }
            finally
            {
                dtMailboxes.Dispose();
                dtFile13.Dispose();
                dtMailboxes.Dispose();
            }
        }

        static ExchangeService GetBindingOffice365(string MailBoxUserName, string MailBoxUserPassword, string MailBoxDomain, string MailEWSURL)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            try
            {
                WebCredentials webCred = new WebCredentials(MailBoxUserName, MailBoxUserPassword, MailBoxDomain);
                service.Credentials = webCred;
                service.Url = new Uri(MailEWSURL);
            }
            catch (Microsoft.Exchange.WebServices.Data.ServiceLocalException ex)
            {

            }
            return service;
        }
    }
}
