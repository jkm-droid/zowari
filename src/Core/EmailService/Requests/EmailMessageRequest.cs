using MimeKit;

namespace Core.EmailService.Requests;

public class EmailMessageRequest
{
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public EmailMessageRequest(IEnumerable<string> to, string subject, string content)
    {
        To = new List<MailboxAddress>();
        To.AddRange(to.Select(x => new MailboxAddress(string.Empty,x)));
        Subject = subject;
        Content = content;        
    }
}