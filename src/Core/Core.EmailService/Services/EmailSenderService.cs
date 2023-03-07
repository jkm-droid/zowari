using Core.EmailService.Configurations;
using LoggerService.Abstractions;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Core.EmailService.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly ILoggerManager _logger;
    private readonly EmailConfiguration _emailConfiguration;

    public EmailSenderService(IOptions<EmailConfiguration> emailConfiguration, ILoggerManager logger)
    {
        _logger = logger;
        _emailConfiguration = emailConfiguration.Value;
    }
    
    public async Task SendEmailAsync(Message message)
    {
        var email = CreateEmailMessage(message);
        await SendAsync(email);
    }

    private async Task SendAsync(MimeMessage email)
    {
        using (var client = new SmtpClient())
        {
            try
            {
               await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

                await client.SendAsync(email);
            }
            catch (Exception e)
            {
                _logger.LogError("Sending email failed with error : {msg}", e);
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(string.Empty,_emailConfiguration.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = message.Content
        };

        return emailMessage;
    }
}