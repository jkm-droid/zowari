using System.Security.Claims;

namespace Core.Application.Boundary.Responses.Identity;

public class UserLoginResponse
{
    public ClaimsIdentity Identity { get; set; }
    public string Message { get; set; }
}