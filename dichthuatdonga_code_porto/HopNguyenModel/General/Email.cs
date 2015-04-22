using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HopNguyenModel.General
{
    public static class Email
    {
        public static bool CheckEmail(string email)
        {
            var checkEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return checkEmail.IsMatch(email);
        }

        public static bool SendMail(string[] to, string subject, string body)
        {
            try
            {
                var smtpServer = new SmtpClient
                                     {
                                         Credentials = new System.Net.NetworkCredential(
                                             "emailnhanh91@gmail.com", "qq101991"),
                                         Port = 587,
                                         Host = "smtp.gmail.com",
                                         EnableSsl = true
                                     };
                var message = new MailMessage
                                  {
                                      From = new MailAddress("emailnhanh91@gmail.com", "Hệ thống email tự động")
                                  };
                foreach (var item in to)
                {
                    if (CheckEmail(item))
                    {
                        message.To.Add(new MailAddress(item));
                    }
                    else
                    {
                        return false;
                    }
                }
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                smtpServer.Send(message);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool SendMail(string subject, string body)
        {
            try
            {
                var to = new HopNguyenEntities().Admins.Where(a => a.Id != 1).Select(a => a.Email).ToArray();
                return SendMail(to, subject, body);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
