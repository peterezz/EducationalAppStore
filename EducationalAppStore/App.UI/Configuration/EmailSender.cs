using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace App.UI.Configuration
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var FromEmail = "Peter_20180167@fci.helwan.edu.eg";
            var FromPassword = "Sam70120";
            var message = new MailMessage();
            message.From=new MailAddress(FromEmail);
            message.Subject = subject;
            message.To.Add(email);
            message.Body = $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;
            var SmtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port= 587,
                EnableSsl=true,
                Credentials= new NetworkCredential(FromEmail, FromPassword)
        };
            SmtpClient.Send(message);
        }
    }
}
