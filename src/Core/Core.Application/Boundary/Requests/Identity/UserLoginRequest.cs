namespace Core.Application.Boundary.Requests.Identity;

public class UserLoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}