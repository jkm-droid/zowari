using Serilog;

namespace Zowari.Extensions;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(path: "appsettings.Development.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.json")
            .AddJsonFile(path: "appsettings.Production.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        SerilogHostBuilderExtensions.UseSerilog(hostBuilder);
        
        return hostBuilder;
    }
}