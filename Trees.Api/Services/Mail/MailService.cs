using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Trees.Api.Services.Mail
{
    public class MailService : IMailService
    {
        public MailService(IOptions<AppSettings> options)
        {
            _settings = options.Value;
        }

        public async Task Send(string subject, string message) // exception
        {
            MimeMessage emailMessage = new();

            emailMessage.From.Add(new MailboxAddress(_settings.EmailSettings.SenderName, _settings.EmailSettings.EmailFrom));
            emailMessage.To.Add(new MailboxAddress(string.Empty, _settings.EmailSettings.EmailTo));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_settings.EmailSettings.SmtpClient, _settings.EmailSettings.Port, true);
                await client.AuthenticateAsync(_settings.EmailSettings.EmailFrom, _settings.EmailSettings.PasswordFrom);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        private AppSettings _settings;
    }
}
