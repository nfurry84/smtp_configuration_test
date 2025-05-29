using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace MyLib
{
    public class EmailSender
    {
        public void SendEmail(string subject, string body)
        {
            // Get the CSV list from AppSettings
            var emailList = ConfigurationManager.AppSettings["EmailTo"];
            if (string.IsNullOrWhiteSpace(emailList))
                throw new InvalidOperationException("No email addresses found in AppSettings[\"EmailTo\"].");

            var recipients = emailList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(e => e.Trim())
                                      .ToList();

            using (var message = new MailMessage())
            {
                foreach (var recipient in recipients)
                {
                    message.To.Add(recipient);
                }

                message.Subject = subject;
                message.Body = body;

                // Configure SMTP client (update with your SMTP settings)
                using (var smtp = new SmtpClient())
                {
                    // Optionally set smtp.Host, smtp.Port, smtp.Credentials, etc.
                    smtp.Send(message);
                }
            }
        }
    }
}
