namespace EmailService.Services;

public interface IEmailSenderService
{
    void SendEmail(Message message);
}