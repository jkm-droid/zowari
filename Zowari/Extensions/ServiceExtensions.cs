using Domain.Configurations;
using Infrastructure.Abstractions;
using Infrastructure.Context;
using Infrastructure.Implementations;
using Infrastructure.Shared.Abstractions;
using Infrastructure.Shared.Implementations;
using LoggerService.Abstractions;
using LoggerService.Implementations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Zowari.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
        });
    }

    public static void ConfigureIISIntegration(this IServiceCollection serviceCollection)
    {
        serviceCollection.Configure<IISOptions>(options => { });
    }
    public static IServiceCollection ConfigureLoggerService(this IServiceCollection servicesCollection,
        IConfiguration configuration)
    {
        // https://weblog.west-wind.com/posts/2018/Dec/31/Dont-let-ASPNET-Core-Default-Console-Logging-Slow-your-App-down
        servicesCollection.AddLogging(config =>
        {
            // clear out default configuration
            config.ClearProviders();

            config.AddConfiguration(configuration.GetSection("Logging"));
            config.AddDebug();
            config.AddEventSourceLogger();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
            {
                config.AddConsole();
            }
            config.AddSerilog();
        });
        servicesCollection.AddScoped<ILoggerManager, LoggerManager>();
        
        return servicesCollection;
    }
    public static void ConfigureMediatr(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(Application.Assembly.AssemblyReference).Assembly);
    }
    
    public static IServiceCollection ConfigureDatabase(this IServiceCollection servicesCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("postgresqlConnection");
        var enableLogging = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        servicesCollection.AddDbContext<DatabaseContext>(dbContextOptions => dbContextOptions
            .UseNpgsql(connectionString, options =>
            {
                options.MigrationsAssembly("Infrastructure");
            })
            .EnableSensitiveDataLogging(enableLogging)
            .EnableDetailedErrors(enableLogging)
        );

        return servicesCollection;
    }
    
    public static void ConfigureRepositoryManager(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        servicesCollection.AddScoped<IRepositoryManager, RepositoryManager>();
    }
    
    public static WebApplication AutoMigrateDatabase(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        if (appContext.Database.GetPendingMigrations().Any())
        {
            appContext.Database.Migrate();
        }

        return webApplication;
    }

    public static IServiceCollection ConfigureSharedInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICurrentDateProvider, CurrentDateProvider>();

        return serviceCollection;
    }

    public static void AddConfigurationSections(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.Configure<IdentityConfiguration>(configuration.GetSection(IdentityConfiguration.SectionName));
    }
}