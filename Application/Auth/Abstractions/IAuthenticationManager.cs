using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;

namespace Application.Auth.Abstractions;

public interface IAuthenticationManager
{
    Task<string> CreateAuthJwtToken(User user);
    bool ValidateJwtToken(string token);
    bool IsUserAuthenticated();
}