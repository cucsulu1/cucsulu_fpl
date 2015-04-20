using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

namespace FPlus
{
    public class Mails
    {
        private static string MailServer = "smtp.gmail.com";
        private static string MailServer_Password = "tienganh2015";
        private static string MailServer_Username = "mail.tienganh247@gmail.com";
        private static bool MailServer_IsEnableSSL = true;
        public static Exception Send(string to, string from, string subject, string message)
        {
            return Send(to, from, subject, message, false, MailPriority.Normal);
        }

        public static Exception Send(string to, string from, string subject, string message,
            string orderRef, string info, string action)
        {
            return Send(to, from, subject, message, false, MailPriority.Normal, orderRef, info, action);
        }

        public static Exception Send(string to, string from, string subject, string message, bool isHtml)
        {
            return Send(to, from, subject, message, isHtml, MailPriority.Normal);
        }

        public static Exception Send(string to, string from, string subject, string message, bool isHtml, MailPriority priority)
        {
            return Send(to, from, subject, message, isHtml, priority, null, null, null);
        }

        public static Exception Send(string to, string from, string subject, string message, bool isHtml, string fileLocation, string cc = "", string bcc = "")
        {
            return Send(to, from, subject, message, isHtml, MailPriority.Normal, null, null, null, fileLocation, cc, bcc);
        }

        public static Exception Send(string to, string from, string subject, string message, bool isHtml, MailPriority priority,
            string orderRef, string info, string action)
        {
            try
            {
                SmtpClient smtpClient;
                MailMessage Mailer;
                Mailer = new MailMessage(from, to.Replace(";", ","), subject, message);
                Mailer.Priority = priority;
                Mailer.IsBodyHtml = isHtml;
                Mailer.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                Mailer.Headers.Add("Return-Path", from);
                    smtpClient = new SmtpClient(MailServer);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential(MailServer_Username, MailServer_Password);
                    smtpClient.EnableSsl = MailServer_IsEnableSSL;
                    ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                
                smtpClient.Send(Mailer);

                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }


        public static Exception Send(string to, string from, string subject, string message, bool isHtml, MailPriority priority,
            string orderRef, string info, string action, string fileLocation, string cc = "", string bcc = "")
        {
            try
            {
                SmtpClient smtpClient;
                MailMessage Mailer;
                Mailer = new MailMessage(from, to.Replace(";", ","), subject, message);
                Mailer.Priority = priority;
                Mailer.IsBodyHtml = isHtml;
                Mailer.Headers.Add("Return-Path", from);
                Mailer.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                if (!string.IsNullOrEmpty(cc))
                {
                    Mailer.CC.Add(cc);
                }
                if (!string.IsNullOrEmpty(bcc))
                {
                    Mailer.Bcc.Add(bcc);
                }

                    //Using mail server KyboTech with login information
                    smtpClient = new SmtpClient(MailServer);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential(MailServer_Username, MailServer_Password);
                    smtpClient.EnableSsl = MailServer_IsEnableSSL;
                    ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                


                if (fileLocation != null && fileLocation != "")
                {
                    // Add multiple attachments
                    string[] AttachmentsList = fileLocation.Split(';');
                    for (int i = 0; i < AttachmentsList.Length; i++)
                    {
                        if (AttachmentsList[i].Trim() != "")
                        {
                            Attachment ma = new Attachment(AttachmentsList[i]);
                            Mailer.Attachments.Add(ma);
                        }
                    }
                }

                smtpClient.Send(Mailer);

                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public static Exception Send(string to, string from, string subject, string message, string fileLocation)
        {
            return Send(to, from, subject, message, false, MailPriority.Normal, null, null, null, fileLocation);
        }

        public static void SendExeptionMail(Exception exeption)
        {
            string exeptionString = "Error Details:" + "<br>";
            exeptionString += exeption.Message + "<br>";
            exeptionString += exeption.InnerException + "<br>";
            string subject = "Unhandled Exception: " + exeption.GetType().Name;

            StackTrace st = new StackTrace(exeption, true);
            StackFrame[] frames = st.GetFrames();

            // Iterate over the frames extracting the information you need
            foreach (StackFrame frame in frames)
            {
                if (!string.IsNullOrEmpty(frame.GetFileName()))
                {
                    exeptionString += "File name: " + frame.GetFileName() + " - Method: " + frame.GetMethod().Name + " - Line: " + frame.GetFileLineNumber() + "<br>";
                }
            }
            Send("nghia.nv.bn91@gmail.com","error@FPlus.com",subject, exeptionString,true);
        }

        public static void UnhandledExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            SendError(e.Exception);
        }
        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // All exceptions thrown by additional threads are handled in this method
            SendError(e.ExceptionObject as Exception);
            // Suspend the current thread for now to stop the exception from throwing.
            Thread.CurrentThread.Suspend();
        }
        static void SendError(Exception e){
            var th = new Thread(() =>
            {
                Mails.SendExeptionMail(e);
            });
            th.Start();


            //MessageBox.Show(
            //    "Có lỗi xảy ra!\nLưu kết quả làm việc của bạn lại\nvà liên hệ với IT để được giải quyết sớm nhất!",
            //    "Thông báo", MessageBoxButtons.OK);
        }
        public static void bwSendMailError_DoWork(object sender, DoWorkEventArgs e)
        {
            var ex = e.Argument as Exception;
        }
    }
}
