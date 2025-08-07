using MailKit.Net.Smtp;
using MimeKit;
namespace CustomIdentity.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // For demo, just log it to console or store in file
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("YourApp", _config["EmailSettings:FromEmail"]));
            emailMessage.To.Add(new MailboxAddress("", "shazaly.se@gmail.com"));
            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = message
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_config["EmailSettings:SmtpServer"], 587, false);
                await client.AuthenticateAsync(_config["EmailSettings:FromEmail"], _config["EmailSettings:Password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
    }

