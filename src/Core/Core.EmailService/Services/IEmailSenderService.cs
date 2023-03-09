namespace Core.EmailService.Services;

public interface IEmailSenderService
{
    Task SendEmailAsync(EmailMessageRequest emailMessageRequest);
}