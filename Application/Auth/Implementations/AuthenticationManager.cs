using Application.Auth.Abstractions;
using Domain.Entities.Identity;

namespace Application.Auth.Implementations;

public class AuthenticationManager : IAuthenticationManager
{
    public Task<string> CreateAuthJwtToken(User user)
    {
        throw new NotImplementedException();
    }

    public bool ValidateJwtToken(string token)
    {
        throw new NotImplementedException();
    }

    public bool IsUserAuthenticated()
    {
        throw new NotImplementedException();
    }
}