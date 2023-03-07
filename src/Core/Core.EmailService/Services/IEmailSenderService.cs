namespace Core.EmailService.Services;

public interface IEmailSenderService
{
    Task SendEmailAsync(Message message);
}