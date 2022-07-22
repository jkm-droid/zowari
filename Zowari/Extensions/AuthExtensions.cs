using System.Text;
using Domain.Entities.Identity;
using Domain.Configurations;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Zowari.Extensions;

public static class AuthExtensions
{
    public static void ConfigureIdentity(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddIdentity<User, Role>(
                options =>
                {
                    //password 
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    // options.Password.RequireUppercase = true;
                    // options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;
                    //user
                    // options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                })
            .AddEntityFrameworkStores<DatabaseContext>();
    }
    
    public static void ConfigureJwtService(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection(IdentityConfiguration.SectionName);
        var secretKey = jwtSettings.GetSection("Secret").Value; // Keep secret in environment for production apps (Environment.GetEnvironmentVariable("SECRET");)
        var validIssuer = configuration.GetValue<string>("IdentityConfiguration:ValidIssuer");
        var validAudience = configuration.GetValue<string>("IdentityConfiguration:ValidAudience");
        
        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = validAudience,
                ValidIssuer = validIssuer,
                ClockSkew = TimeSpan.Zero,// It forces tokens to expire exactly at token expiration time instead of 5 minutes later
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });
    }
}