using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Auth.Abstractions;
using Domain.Configurations;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtConstants = Domain.Constants.JwtConstants;

namespace Application.Auth.Implementations;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IdentityConfiguration _identityConfiguration;

    public AuthenticationManager(
        UserManager<User> userManager, 
        IHttpContextAccessor httpContextAccessor,
        IOptions<IdentityConfiguration> configuration
    )
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _identityConfiguration = configuration.Value;
    }
    public async Task<string> CreateAuthJwtToken(User user)
    {
        var signCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConstants.SecretKey)),SecurityAlgorithms.HmacSha256);
        var userClaims = await GetUSerClaims(user);
        var tokenOptions = GenerateTokenOptions(signCredentials, userClaims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private async Task<IEnumerable<Claim>> GetUSerClaims(User user)
    {
        //get the claims
        var systemUserClaims = await _userManager.GetClaimsAsync(user);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.Email, user.Email),
        }.Union(systemUserClaims).ToList();

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken(
            issuer: JwtConstants.ValidIssuer,//_identityConfiguration.ValidIssuer,
            audience: JwtConstants.ValidAudience,// _identityConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(JwtConstants.Expires),
            signingCredentials: signingCredentials);
        
        return tokenOptions;
    }


    public bool ValidateJwtToken(string token)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConstants.SecretKey));
        var issuer = JwtConstants.ValidIssuer;
        var audience = JwtConstants.ValidAudience;

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = securityKey
            }, out SecurityToken validatedToken);
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public bool IsUserAuthenticated()
    {
        var jwtToken = _httpContextAccessor.HttpContext.Session.GetString(JwtConstants.JwtToken);
        
        return !string.IsNullOrEmpty(jwtToken);
    }
}