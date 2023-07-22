
using Ticketback.Models;

using MimeKit;
using MailKit.Net.Smtp;
using Ticketback.Helpers;
using Microsoft.Extensions.Options;
using MailKit.Security;

namespace Ticketback.UtilityService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly EmailSettings emailSettings;
        public EmailService(IConfiguration configuration, IOptions<EmailSettings> options)
        {
            _config = configuration;
            emailSettings = options.Value;
        }
        public void SendEmail(EmailModel emailModel)
        {
            var emailMessage = new MimeMessage();
            var from = _config["EmailSettings:From"];
            emailMessage.From.Add(new MailboxAddress("Telnet Holding", from));
            emailMessage.To.Add(new MailboxAddress(emailModel.To, emailModel.To));
            emailMessage.Subject = emailModel.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(emailModel.Content)
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config["EmailSettings:SmtpServer"], 465, true);
                    client.Authenticate(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
                    client.Send(emailMessage);

                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }

            }
        }

        public async Task SendEmailAsync(Mailrequest mailrequest)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Telnet Holding", emailSettings.Email));

            email.To.Add(MailboxAddress.Parse(mailrequest.ToEmail));
            email.Subject = mailrequest.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailrequest.Body;
            email.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(emailSettings.SmtpServer, emailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(emailSettings.Email, emailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }



        public async Task SendEmail1Async(Mailrequest mailrequest)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Telnet Holding", emailSettings.Email));


            try
            {
                foreach (var recipientEmail in mailrequest.ToEmail.Split(','))
                {
                    email.To.Add(MailboxAddress.Parse(recipientEmail.Trim()));
                }
            }
            catch (ParseException ex)
            {
                // Handle the parse exception here
                Console.WriteLine($"Failed to parse email address: {ex.Message}");
                throw;
            }

            email.Subject = mailrequest.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailrequest.Body;
            email.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(emailSettings.SmtpServer, emailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(emailSettings.Email, emailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }

    }
}
