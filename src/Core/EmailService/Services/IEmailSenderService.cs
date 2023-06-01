using Core.EmailService.Requests;

namespace Core.EmailService.Services;

public interface IEmailSenderService
{
    Task SendEmailAsync(EmailMessageRequest emailMessageRequest);
}