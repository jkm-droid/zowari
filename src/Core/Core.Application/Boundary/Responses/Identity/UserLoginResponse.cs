using System.Security.Claims;

namespace Application.Boundary.Responses;

public class UserLoginResponse
{
    public ClaimsIdentity Identity { get; set; }
    public string Message { get; set; }
}