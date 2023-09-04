using EmailService.DTOs;
using EmailService.Service.Interfaces;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailService.Service
{
    public class Email_Service : IEmailService
    {
        private readonly IConfiguration _configuration;

        public Email_Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailDTO emailDTO)
        {
            /*var email = new MimeMessage
            {
                From = { MailboxAddress.Parse(_configuration.GetSection("EmailUsername").Value) },
                To = { MailboxAddress.Parse(emailDTO.To) },
                Subject = emailDTO.Subject,
                Body = new TextPart(TextFormat.Html) { Text = emailDTO.Body }
            };*/
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(emailDTO.To));
            email.Subject = emailDTO.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailDTO.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUsername").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);



        }
    }
}
