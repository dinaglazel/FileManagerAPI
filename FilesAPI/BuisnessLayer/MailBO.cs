using BuisnessLayer.Interfaces;
using DataEntities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class MailBO: IMailBO
    {
        private readonly IOptions<MailSettings> _mailSettings;

        public MailBO(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Value.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
       
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Value.Host, _mailSettings.Value.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Value.Mail, _mailSettings.Value.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
