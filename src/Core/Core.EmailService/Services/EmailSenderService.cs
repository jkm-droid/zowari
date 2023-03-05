using EmailService.Configurations;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailService.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly EmailConfiguration _emailConfiguration;

    public EmailSenderService(IOptions<EmailConfiguration> emailConfiguration)
    {
        _emailConfiguration = emailConfiguration.Value;
    }
    
    public void SendEmail(Message message)
    {
        var email = CreateEmailMessage(message);
        SendAsync(email);
    }

    private void SendAsync(object email)
    {
        throw new NotImplementedException();
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        throw new NotImplementedException();
    }
}