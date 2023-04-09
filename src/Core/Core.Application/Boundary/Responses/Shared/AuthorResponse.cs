namespace Core.Application.Boundary.Responses;

public class AuthorResponse
{
    public  Guid UserId { get; set; }
    public string AuthorName { get; set; }
    public string ProfileUrl { get; set; }
    public int Score { get; set; }
    public int Rating { get; set; }
    public string Level { get; set; }
}