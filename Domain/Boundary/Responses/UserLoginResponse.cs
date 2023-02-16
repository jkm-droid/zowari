using System.Security.Claims;
using Domain.Entities.Identity;

namespace Domain.Boundary.Responses;

public class UserLoginResponse
{
    public ClaimsIdentity Identity { get; set; }
    public string Message { get; set; }
}