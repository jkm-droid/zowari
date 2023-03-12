using Serilog;

namespace Zowari.Extensions;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_DEVELOPMENT") ?? Environments.Development;
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional:false,reloadOnChange: true)
            .AddJsonFile(path: $"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        hostBuilder.UseSerilog();
        
        return hostBuilder;
    }
}