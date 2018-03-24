using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Models.Security;

namespace Services
{
    public class EmailService
    {
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPortNumber = 587;
        private const string Administration = "Administration";

        public readonly IConfiguration Configuration;

        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmailAsync(IEnumerable<User> users, string subject, string message)
        {
            var emailMessage = GetEmailMessage(users, subject, message);

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(SmtpServer, SmtpPortNumber, false);
                await client.AuthenticateAsync(Configuration["Credentials:Email"], Configuration["Credentials:Password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        private MimeMessage GetEmailMessage(IEnumerable<User> users, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(Administration, Configuration["Credentials:Email"]));
            emailMessage.To.AddRange(GetAllMailboxAddresses(users));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            
            return emailMessage;
        }

        private IEnumerable<MailboxAddress> GetAllMailboxAddresses(IEnumerable<User> users)
        {
            return users.Select(user => new MailboxAddress($"{user.FirstName} {user.LastName}", user.EmailAddress));
        }
    }
}
