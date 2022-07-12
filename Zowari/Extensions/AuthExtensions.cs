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
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;
                })
            .AddEntityFrameworkStores<DatabaseContext>();
    }
}