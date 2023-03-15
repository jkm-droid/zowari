using System.Security.Claims;

namespace Application.Boundary.Responses.Identity;

public class UserLoginResponse
{
    public ClaimsIdentity Identity { get; set; }
    public string Message { get; set; }
}