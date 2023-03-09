using Domain.Entities.Identity;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

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
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();

        serviceCollection.Configure<DataProtectionTokenProviderOptions>(options =>
            options.TokenLifespan = TimeSpan.FromHours(1));
    }
}