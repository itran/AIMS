Imports System.Net.Mail
Imports System.Configuration.ConfigurationSettings
Namespace AIMS.Utility

    Public Class eMailer

        Private _smtpServer As String = ""
        Private _smtpUserName As String = ""
        Private _smtpPassword As String = ""
        Private _connectionstring As String = ""

        Property Connectionstring() As String
            Get
                Connectionstring = _connectionstring
            End Get
            Set(ByVal value As String)
                _connectionstring = value
            End Set
        End Property

        Private Function Receive() As String
            Dim oMail As New jmail.POP3
            oMail.Connect("operations@aims.org.za", "MimeOps@2021", "za-smtp-inbound-1.mimecast.co.za")
        End Function
        Private Function GetSMTPServerName() As String
            _smtpServer = Configuration.ConfigurationSettings.AppSettings.Get("SMTPServer").ToString()

            If _smtpServer Is Nothing AndAlso _smtpServer.Trim().Equals("") Then
                Return "za-smtp-outbound-1.mimecast.co.za"
            Else
                Return _smtpServer
            End If
        End Function

        Private Function GetSMTPUserName() As String
            _smtpUserName = Configuration.ConfigurationSettings.AppSettings.Get("SMTPUserName").ToString()
            If _smtpUserName Is Nothing AndAlso _smtpUserName.Trim().Equals("") Then
                Return "Operations@AIMS.Org.Za"
            Else
                Return _smtpServer
            End If
        End Function

        Private Function GetSMTPPassword() As String
            _smtpPassword = Configuration.ConfigurationSettings.AppSettings.Get("SMTPPassword").ToString()
            If _smtpPassword Is Nothing AndAlso _smtpPassword.Trim().Equals("") Then
                Return "MimeOps@2021"
            Else
                Return _smtpServer
            End If
        End Function
        Public Function SendEmailNotify(ByVal EmailBody As String) As Boolean

            'WriteLogEntryPrivate("Function Started")
            Dim bResult As Boolean = False
            'Dim oJmailer As Object = CreateObject("jmail.Message")

            Dim sNotifyEmailAddresses() As String
            Dim lCount As Long
            Dim sEmailServerName As String = ""
            Dim sFromEmailAddress As String = ""
            Dim sNotifyMessage As String = ""
            Dim nLogoContentID
            Dim sNotifyEmailAddress As String = ""
            Dim oConnection As New OleDb.OleDbConnection
            Dim cmdSource As New OleDb.OleDbCommand
            Dim rdrSource As OleDb.OleDbDataReader
            Dim sJMailLog As String

            'WriteLogEntryPrivate("Objects Loaded")
            ''create the mail message
            'Dim mail As New MailMessage()

            ''send the message
            'Dim smtp As New SmtpClient("smtp.gmail.com", 587)
            'Dim nc As New System.Net.NetworkCredential("martitian@gmail.com", "iTRan1**")

            Try

                ''set the addresses
                'mail.From = New MailAddress("admin@aims.org.za", "admin@aims.org.za")

                ''set the content
                'mail.Subject = "AIMS Recorder - Service Provider Cost Limit Exceeded"


                'Try
                '    oConnection.ConnectionString = "Provider=SQLOLEDB;Data Source=DC1;Initial Catalog=AIMS;User ID=aims;Password=aims1**"
                '    oConnection.Open()
                '    cmdSource.Connection = oConnection
                '    cmdSource.CommandText = "select limitation_value from AIMS_LIMITATION where LIMITATION_CD = 'AIMS_COST_MONITOR_EMAIL'"
                '    rdrSource = cmdSource.ExecuteReader
                'Catch Mailex As Exception
                '    sNotifyEmailAddress = "bernadette@aims.org.za; eric@aims.org.za; debbie@aims.org.za; i.tran@yahoo.co.uk"
                'End Try

                'If Not rdrSource Is Nothing Then
                '    If rdrSource.Read Then
                '        sNotifyEmailAddress = rdrSource.GetValue(0).ToString
                '    Else
                '        sNotifyEmailAddress = "bernadette@aims.org.za; eric@aims.org.za; debbie@aims.org.za; i.tran@yahoo.co.uk"
                '    End If
                'Else
                '    sNotifyEmailAddress = "bernadette@aims.org.za; eric@aims.org.za; debbie@aims.org.za; i.tran@yahoo.co.uk"
                'End If

                'sNotifyEmailAddresses = Split(sNotifyEmailAddress, ";")

                'For lCount = 0 To UBound(sNotifyEmailAddresses)
                '    mail.To.Add(sNotifyEmailAddresses(lCount).ToString())
                'Next

                'mail.Attachments.Add(System.Net.Mail.Attachment.CreateAttachmentFromString("c:\AIMSLOGO.png", "AIMSLOGO.png"))

                'EmailBody = Replace(EmailBody, "###LOGO###", "<img border=0 src=""cid:" & mail.Attachments.Item(0).ContentId & """>")
                'mail.Body = EmailBody
                'mail.IsBodyHtml = True
                'smtp.EnableSsl = True
                'smtp.UseDefaultCredentials = False
                'smtp.Credentials = nc
                'smtp.Send(mail)

                'WriteLogEntryPrivate("Start Sending Email")

                'With oJmailer

                '    .Priority = 1
                '    .ISOEncodeHeaders = False
                '    .From = "admin@aims.org.za"
                '    .Logging = True
                '    .Subject = "AIMS Recorder - Service Provider Cost Limit Exceeded"
                '    .FromName = "The AIMS Recorder"

                Try
                    Connectionstring = "Provider=SQLOLEDB;Data Source=DC1;Initial Catalog=AIMS;User ID=aims;Password=aims1**"
                    oConnection.ConnectionString = Connectionstring
                    oConnection.Open()
                    cmdSource.Connection = oConnection
                    cmdSource.CommandText = "select limitation_value from AIMS_LIMITATION where LIMITATION_CD = 'AIMS_COST_MONITOR_EMAIL'"
                    rdrSource = cmdSource.ExecuteReader
                Catch Mailex As Exception
                    sNotifyEmailAddress = "bernadette@aims.org.za; eric@aims.org.za; debbie@aims.org.za; i.tran@yahoo.co.uk"
                End Try

                If Not rdrSource Is Nothing Then
                    If rdrSource.Read Then
                        sNotifyEmailAddress = rdrSource.GetValue(0).ToString
                    Else
                        sNotifyEmailAddress = "bernadette@aims.org.za; eric@aims.org.za; debbie@aims.org.za; i.tran@yahoo.co.uk"
                    End If
                Else
                    sNotifyEmailAddress = "bernadette@aims.org.za; eric@aims.org.za; debbie@aims.org.za; i.tran@yahoo.co.uk"
                End If

                sNotifyEmailAddresses = Split(sNotifyEmailAddress, ";")


                'For lCount = 0 To UBound(sNotifyEmailAddresses)
                '.AddRecipient(sNotifyEmailAddresses(lCount))
                'Next

                'nLogoContentID = .AddAttachment("c:\AIMSLOGO.png")
                'EmailBody = Replace(EmailBody, "###LOGO###", "<img border=0 src=""cid:" & nLogoContentID & """>")
                EmailBody = Replace(EmailBody, "###LOGO###", "")
                'bResult = SendUsingGMAIL(EmailBody, "AIMS Recorder - Service Provider Cost Limit Exceeded", sNotifyEmailAddress)
                bResult = SMTPSendMail(EmailBody, "Admin@aims.org.co.za", "AIMS Recorder - Service Provider Cost Limit Exceeded", sNotifyEmailAddress, "")


                '    .HTMLBody = EmailBody
                '    .Send("mail6.mimecast.co.za")
                '    WriteLogEntryPrivate("Email Sent successfully", "", "JMAIL Log Entry: " & .Log & "| Function Result: " & bResult)
                'End With
                'bResult = True
                'WriteLogEntryPrivate("Email Sent successfully", "", "Function Result: " & bResult)
            Catch ex As Exception
                WriteLogEntryPrivate("Email NOT Sent successfully", ex.ToString(), "JMAIL Log Entry: ")
                bResult = False
            Finally
                If oConnection.State = ConnectionState.Open Then oConnection.Close()
                oConnection.Dispose()
                cmdSource.Dispose()
                'oJmailer = Nothing
            End Try

            Return bResult
        End Function

        Public Function SendEmail(ByVal EmailBody As String, _
                                    ByVal EmailFrom As String, _
                                    ByVal EmailFromName As String, _
                                    ByVal EmailSubject As String, _
                                    ByVal EmailTo As String, _
                                    ByVal EmailAttachments As String, _
                                    Optional ByVal KillFiles As Boolean = True, _
                                    Optional ByVal EmailCC As String = "", _
                                    Optional ByVal EmailBcc As String = "") As Boolean

            'WriteLogEntryPrivate("AIMS Email Component Instantiated", "", "SendEmail - ")

            WriteLogEntryPrivate("Send Email Function Instrumentation Started", "", "")
            Dim bResult As Boolean = False
            'Dim oJmailer As Object = CreateObject("jmail.Message")
            Dim sNotifyEmailAddresses() As String
            Dim arEmailAttachments() As String
            Dim lCount As Long
            Dim lAttachments As Long
            Dim sEmailServerName As String = ""
            Dim sFromEmailAddress As String = ""
            Dim sNotifyMessage As String = ""
            Dim sNotifyEmailAddress As String = ""
            Dim sJMailLog As String

            arEmailAttachments = Split(EmailAttachments, ";")

            WriteLogEntryPrivate("Send Email Function Instrumentation Step 1 - SMTP Email Start", "", "")

            'bResult = SendUsingGMAIL(EmailBody, EmailSubject, EmailTo, EmailAttachments, EmailCC)
            bResult = SMTPSendMail(EmailBody, EmailFrom, EmailSubject, EmailTo, EmailAttachments, EmailCC, EmailBcc)

            WriteLogEntryPrivate("Send Email Function Instrumentation Step 2 - SMTP Email Completed", "", "")
            Try
                If KillFiles Then
                    For lAttachments = 0 To UBound(arEmailAttachments)
                        Try
                            If Not arEmailAttachments(lAttachments).Equals("") Then
                                Kill(arEmailAttachments(lAttachments))
                            End If
                        Catch ex As Exception
                            WriteLogEntryPrivate("Kiling File Err ", ex.ToString(), "JMAIL Log Entry: " + ex.ToString())
                        End Try
                    Next
                End If

                'WriteLogEntryPrivate("Email Sent successfully", "", "Function Result: " & bResult)
            Catch ex As Exception
                WriteLogEntryPrivate("Email NOT Sent successfully", "", "JMAIL Log Entry: " + ex.ToString())
                bResult = False
            Finally
            End Try
            WriteLogEntryPrivate("Send Email Function Instrumentation Completed", "", "")
            Return bResult
        End Function

        Private Sub WriteLogEntryPrivate(ByVal eventDescription As String, Optional ByVal errorMessage As String = "", Optional ByVal JMailError As String = "")
            Try
                'Open a file for writing
                'The file log name is based on the current date and is already stored in a system parameter
                Dim fileName As String = "c:\AIMS Recorder\" + "AIMS Recorder Emailing" + Format(Date.Now, "ddMMMyyyy") + ".log"

                'Ensure the directory exists
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fileName))
                'Get a StreamReader class that can be used to read the file
                Dim objStreamWriter As System.IO.StreamWriter
                objStreamWriter = System.IO.File.AppendText(fileName)

                'Append the the end of the string
                objStreamWriter.WriteLine(eventDescription & " ++ " & System.DateTime.Now.TimeOfDay.ToString())
                objStreamWriter.WriteLine(errorMessage)
                objStreamWriter.WriteLine("------------------")
                objStreamWriter.WriteLine("JMAIL ERROR - " & JMailError)

                objStreamWriter.Close()
                objStreamWriter = Nothing

            Catch ex As Exception

            End Try

        End Sub

        Private Function SendUsingGMAIL(ByVal EmailBody As String, Optional ByVal EmailSubject As String = "", Optional ByVal EmailTo As String = "", Optional ByVal emailAttachment As String = "", Optional ByVal EmailCC As String = "")
            Dim bResult As Boolean = False
            'Dim oJmailer As Object = CreateObject("jmail.Message")
            Dim sNotifyEmailAddresses() As String
            Dim sEmailAttachments() As String

            Dim lCount As Long
            Dim sEmailServerName As String = ""
            Dim sFromEmailAddress As String = ""
            Dim sNotifyMessage As String = ""
            Dim nLogoContentID
            Dim sNotifyEmailAddress As String = ""
            Dim oConnection As New OleDb.OleDbConnection
            Dim cmdSource As New OleDb.OleDbCommand
            Dim rdrSource As OleDb.OleDbDataReader
            Dim sJMailLog As String

            Try
                'create the mail message
                Dim mail As New MailMessage()

                'set the addresses
                mail.From = New MailAddress("admin@aims.org.za", "AIMS Reporting Services")

                sNotifyEmailAddresses = Split(EmailTo, ";")

                For lCount = 0 To UBound(sNotifyEmailAddresses)
                    mail.To.Add(New System.Net.Mail.MailAddress((sNotifyEmailAddresses(lCount))))
                Next

                sEmailAttachments = Split(emailAttachment, ";")
                Dim lAttachments As Integer

                For lAttachments = 0 To UBound(sEmailAttachments)
                    If Not sEmailAttachments(lAttachments).Trim().Equals("") Then
                        mail.Attachments.Add(New Attachment(sEmailAttachments(lAttachments)))
                    End If
                Next

                'set the content
                mail.Subject = EmailSubject
                mail.Body = EmailBody
                mail.IsBodyHtml = True

                If Not EmailCC.Trim().Equals("") Then
                    mail.CC.Add(EmailCC)
                End If

                'send the message
                Dim smtp As New SmtpClient("smtp.gmail.com", 587)
                Dim nc As New System.Net.NetworkCredential("martitian@gmail.com", "iTRan1**")

                smtp.EnableSsl = True
                smtp.UseDefaultCredentials = False
                smtp.Credentials = nc
                smtp.Send(mail)
                bResult = True
            Catch ex As Exception
                WriteLogEntryPrivate("Email NOT Sent successfully", "", "JMAIL Log Entry: ")
                bResult = False
            End Try
            Return bResult
        End Function

        Private Function SMTPSendMail(ByVal EmailBody As String, Optional ByVal EmailFrom As String = "", Optional ByVal EmailSubject As String = "", Optional ByVal EmailTo As String = "", Optional ByVal emailAttachment As String = "", Optional ByVal EmailCC As String = "", Optional ByVal EmailBcc As String = "") As Boolean

            Dim bReturn As Boolean
            bReturn = True
            Try

                WriteLogEntryPrivate("SEND TEST EMAIL START", "", "")
                bReturn = TestEmail(EmailBody, EmailFrom, EmailSubject, EmailTo, emailAttachment, EmailCC, EmailBcc)
                WriteLogEntryPrivate("TEST EMAIL RETURN: " & bReturn, "", "")
                Return bReturn

            Catch ex As SmtpException

                WriteLogEntryPrivate("Email SMTP Send Mail: \n", ex.ToString(), "JMAIL Log Entry: ")

            Finally
            End Try
            Return bReturn


            'Dim mail As MailMessage = New MailMessage()
            'Dim sEmailTo() As String
            'Dim sEmailToCC() As String
            'Dim sEmailToBcc() As String
            'Dim sEmailAttachment() As String
            'Dim SmtpServer As SmtpClient = New SmtpClient(GetSMTPServerName()) ' mail6.mimecast.co.za
            'Dim netCred As Net.NetworkCredential

            'Dim bReturn As Boolean
            'Dim iRetryCount As Integer
            'Dim sErrorPoint As String = ""

            'Try
            '    netCred = New Net.NetworkCredential()
            '    netCred.UserName = GetSMTPUserName()
            '    netCred.UserName = GetSMTPPassword()
            '    SmtpServer.Credentials = netCred

            '    WriteLogEntryPrivate("Send Email Function Instrumentation Step 2- SMTP Email Processing", "", "")
            '    mail.From = New MailAddress(EmailFrom)

            '    mail.Subject = EmailSubject
            '    mail.IsBodyHtml = True
            '    mail.Body = EmailBody

            '    sEmailTo = Split(EmailTo, ";")
            '    Dim lEmailTo As Integer

            '    WriteLogEntryPrivate("Send Email Function Instrumentation Step 3a- SMTP Email Processing CC List", "", "")
            '    For lEmailTo = 0 To UBound(sEmailTo)
            '        If Not sEmailTo(lEmailTo).Trim().Equals("") Then
            '            mail.To.Add(New MailAddress(sEmailTo(lEmailTo).Trim()))
            '        End If
            '    Next

            '    sEmailToCC = Split(EmailCC, ";")

            '    Dim lEmailToCC As Integer
            '    Dim sEmailString As String = ""

            '    WriteLogEntryPrivate("CC Email: " & EmailCC, "", "")
            '    For lEmailToCC = 0 To UBound(sEmailToCC)
            '        If Not sEmailToCC(lEmailToCC).Trim().Equals("") Then
            '            If sEmailToCC(lEmailToCC).Contains("(") AndAlso sEmailToCC(lEmailToCC).Contains(")") Then
            '                sEmailString = sEmailToCC(lEmailToCC).Split("(")(1).Replace(")", "").Trim()
            '            Else
            '                sEmailString = sEmailToCC(lEmailToCC).Trim()
            '            End If
            '            mail.CC.Add(sEmailString)
            '        End If
            '    Next

            '    sEmailToBcc = Split(EmailBcc, ";")
            '    Dim lEmailToBcc As Integer
            '    sEmailString = ""

            '    WriteLogEntryPrivate("BCC Email: " & EmailBcc, "", "")
            '    For lEmailToBcc = 0 To UBound(sEmailToBcc)
            '        If Not sEmailToBcc(lEmailToBcc).Trim().Equals("") Then

            '            If sEmailToBcc(lEmailToBcc).Contains("(") AndAlso sEmailToBcc(lEmailToBcc).Contains(")") Then
            '                sEmailString = sEmailToBcc(lEmailToBcc).Split("(")(1).Replace(")", "").Trim()
            '            Else
            '                sEmailString = sEmailToBcc(lEmailToBcc).Trim()
            '            End If

            '            mail.Bcc.Add(sEmailString)
            '        End If
            '    Next

            '    WriteLogEntryPrivate("Send Email Function Instrumentation Step 3b- SMTP Email Processing CC List", "", "")
            '    sEmailAttachment = Split(emailAttachment, ";")
            '    Dim lEmailAttachment As Integer

            '    WriteLogEntryPrivate("Send Email Function Instrumentation Step 4a - SMTP Email Processing Attachment List", "", "")

            '    For lEmailAttachment = 0 To UBound(sEmailAttachment)
            '        If Not sEmailAttachment(lEmailAttachment).Trim().Equals("") Then
            '            mail.Attachments.Add(New Attachment(sEmailAttachment(lEmailAttachment)))
            '        End If
            '    Next

            '    WriteLogEntryPrivate("Send Email Function Instrumentation Step 4b - SMTP Email Processing Attachment List", "", "")

            '    sErrorPoint = "Send_Email"

            '    WriteLogEntryPrivate("Send Email Function Instrumentation Step 5a - Sending Mail. . .", "", "")
            '    WriteLogEntryPrivate("Send Email Function SMTP SERVER NAME: " + GetSMTPServerName(), "", "")
            '    SmtpServer.Send(mail)
            '    WriteLogEntryPrivate("Send Email Function Instrumentation Step 5a - Sending Mail. . .", "", "")

            '    bReturn = True
            'Catch ex As SmtpException
            '    Dim bRetrySuccess As Boolean = False
            '    If sErrorPoint = "Send_Email" Then
            '        Do
            '            If Not SmtpServer Is Nothing Then
            '                Try
            '                    SmtpServer.Send(mail)
            '                    bRetrySuccess = True
            '                    Exit Do
            '                Catch exRetry As Exception
            '                    bRetrySuccess = False
            '                End Try
            '                iRetryCount += 1
            '            End If
            '        Loop Until iRetryCount = 3
            '    End If

            '    If Not bRetrySuccess Then
            '        WriteLogEntryPrivate("Email SMTP Send Mail: \n", ex.ToString(), "JMAIL Log Entry: ")
            '        bReturn = False
            '    Else
            '        bReturn = True
            '    End If
            'Finally
            '    mail.Dispose()
            '    SmtpServer = Nothing
            'End Try
            'Return bReturn
        End Function

        Private Function TestEmail(Optional ByVal EmailBody As String = "", Optional ByVal EmailFrom As String = "", Optional ByVal EmailSubject As String = "", Optional ByVal EmailTo As String = "", Optional ByVal emailAttachment As String = "", Optional ByVal EmailCC As String = "", Optional ByVal EmailBcc As String = "") As Boolean
            WriteLogEntryPrivate("SMTP TEST APP STARTED", "", "")
            Try
                Dim sEmailTo() As String
                Dim sEmailToCC() As String
                Dim sEmailToBcc() As String
                Dim sEmailAttachment() As String
                Dim smptCl As New SmtpClient("za-smtp-outbound-1.mimecast.co.za")
                Dim netCred As New Net.NetworkCredential("operations@aims.org.za", "MimeOps@2021")

                Dim mailMsg As New MailMessage()
                Dim mailAddr As New MailAddress(EmailFrom, EmailFrom)
                smptCl.Credentials = netCred
                'mailMsg.From = New MailAddress(EmailFrom)
                mailMsg.From = mailAddr
                mailMsg.Subject = EmailSubject
                mailMsg.IsBodyHtml = True
                'mailMsg.Body = EmailBody
                mailMsg.AlternateViews.Add(getembeddedImage(EmailBody, "C:\AIMS Recorder\image001.jpg"))

                sEmailTo = Split(EmailTo, ";")
                Dim lEmailTo As Integer

                WriteLogEntryPrivate("Send Email Function Instrumentation Step 3a- SMTP Email Processing CC List", "", "")
                For lEmailTo = 0 To UBound(sEmailTo)
                    If Not sEmailTo(lEmailTo).Trim().Equals("") Then
                        mailMsg.To.Add(New MailAddress(sEmailTo(lEmailTo).Trim()))
                    End If
                Next
                sEmailToCC = Split(EmailCC, ";")

                Dim lEmailToCC As Integer
                Dim sEmailString As String = ""

                WriteLogEntryPrivate("CC Email: " & EmailCC, "", "")
                For lEmailToCC = 0 To UBound(sEmailToCC)
                    If Not sEmailToCC(lEmailToCC).Trim().Equals("") Then
                        If sEmailToCC(lEmailToCC).Contains("(") AndAlso sEmailToCC(lEmailToCC).Contains(")") Then
                            sEmailString = sEmailToCC(lEmailToCC).Split("(")(1).Replace(")", "").Trim()
                        Else
                            sEmailString = sEmailToCC(lEmailToCC).Trim()
                        End If
                        mailMsg.CC.Add(sEmailString)
                    End If
                Next

                sEmailToBcc = Split(EmailBcc, ";")
                Dim lEmailToBcc As Integer
                sEmailString = ""

                WriteLogEntryPrivate("BCC Email: " & EmailBcc, "", "")
                For lEmailToBcc = 0 To UBound(sEmailToBcc)
                    If Not sEmailToBcc(lEmailToBcc).Trim().Equals("") Then

                        If sEmailToBcc(lEmailToBcc).Contains("(") AndAlso sEmailToBcc(lEmailToBcc).Contains(")") Then
                            sEmailString = sEmailToBcc(lEmailToBcc).Split("(")(1).Replace(")", "").Trim()
                        Else
                            sEmailString = sEmailToBcc(lEmailToBcc).Trim()
                        End If

                        mailMsg.Bcc.Add(sEmailString)
                    End If
                Next

                sEmailAttachment = Split(emailAttachment, ";")
                Dim lEmailAttachment As Integer
                For lEmailAttachment = 0 To UBound(sEmailAttachment)
                    If Not sEmailAttachment(lEmailAttachment).Trim().Equals("") Then
                        mailMsg.Attachments.Add(New Attachment(sEmailAttachment(lEmailAttachment)))
                    End If
                Next

                smptCl.Send(mailMsg)

                WriteLogEntryPrivate("SMTP TEST APP COMPLETED SUCCESSFULLY", "", "")
                Return True
            Catch ex As Exception
                WriteLogEntryPrivate("SMTP TEST APP ERROR: " & ex.ToString(), "", "")
                Return False
            End Try
        End Function

        Private Function getembeddedImage(ByVal EmailBody As String, ByVal Logo As String) As AlternateView
            Dim res As LinkedResource = New LinkedResource(Logo)
            res.TransferEncoding = Net.Mime.TransferEncoding.Base64
            res.ContentId = Guid.NewGuid().ToString()
            res.ContentType.MediaType = System.Net.Mime.MediaTypeNames.Image.Jpeg


            Dim htmlBody As String = EmailBody.Replace("##SIGNATURE_LOGO##", "<img border=0 width=318 height=123 src='cid:" & res.ContentId & "'/>")

            Dim alternateView As AlternateView = alternateView.CreateAlternateViewFromString(htmlBody)
            alternateView.ContentType.MediaType = "text/html"

            alternateView.LinkedResources.Add(res)
            Return alternateView
        End Function

    End Class
End Namespace

