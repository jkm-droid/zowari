using Domain.Entities.Identity;

namespace Domain.Boundary.Responses;

public class UserLoginResponse
{
    public string Message { get; set; }
    public string Token { get; set; }
    public string RefreshTokem { get; set; }
    
}