using Domain.Entities.Identity;

namespace Domain.Boundary.Responses;

public class UserLoginResponse
{
    public User User { get; set; }
    public string Message { get; set; }
}