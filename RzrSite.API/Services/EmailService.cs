using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace RzrSite.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceConfig _config;

        public EmailService(IOptions<EmailServiceConfig> config)
        {
            _config = config.Value;
        }

        public async Task SendEmailAsync(string subject, string message, string email = null)
        {
            var emailMessage = CreateMessage(subject, message, email);
            using var client = new SmtpClient();
            await client.ConnectAsync(_config.Host, _config.Port, true);
            await client.AuthenticateAsync(_config.From, _config.Password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }

        private MimeMessage CreateMessage(string subject, string message, string email = null)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_config.Name, _config.From));
            emailMessage.To.Add(new MailboxAddress(string.Empty, email ?? _config.Receiver));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };
            return emailMessage;
        }
    }

    public class EmailServiceConfig
    {
        public string Name { get; set; }
        public string From { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string Receiver { get; set; }
    }
}
