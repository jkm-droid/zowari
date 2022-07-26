using Microsoft.AspNetCore.HttpOverrides;
using Zowari.Extensions;
using Zowari.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(configuration =>
    {
        configuration.RespectBrowserAcceptHeader = true;
        configuration.ReturnHttpNotAcceptable = true;
    })
    .AddValidators();
builder.Services.AddRazorPages();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureLoggerService(builder.Configuration);
builder.Services.ConfigureSharedInfrastructure();
builder.Services.ConfigureIdentity();

builder.Services.AddAutoMapper(typeof(Program));

builder.Host.AddSerilog();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.AutoMigrateDatabase();

app.Run();