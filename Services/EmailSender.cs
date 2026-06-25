using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MyStore.Options;
using System.Net.Mail;
using MailKit.Net.Smtp;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace MyStore.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpOptions smtpoption;

        public EmailSender(IOptions<SmtpOptions> smtpoption)
        {
            this.smtpoption = smtpoption.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                // to make email body in html format
                var body = new TextPart(MimeKit.Text.TextFormat.Html);
                body.Text = htmlMessage;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(smtpoption.SenderName, smtpoption.Sender));
                message.Subject = subject;
                message.To.Add(new MailboxAddress(null, email));
                message.Body = body;

                var client = new SmtpClient();
                await client.ConnectAsync(smtpoption.Host, smtpoption.Port);
                await client.AuthenticateAsync(smtpoption.Sender, smtpoption.Password);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        }
}
