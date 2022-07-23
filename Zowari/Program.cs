using Application.Auth.Abstractions;
using Application.Auth.Implementations;
using Domain.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.JsonWebTokens;
using Zowari.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureLoggerService(builder.Configuration);
builder.Services.ConfigureSharedInfrastructure();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwtService(builder.Configuration);
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

//session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(240);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews(configuration =>
    {
        configuration.RespectBrowserAcceptHeader = true;
        configuration.ReturnHttpNotAcceptable = true;
    })
    .AddValidators();

builder.Host.AddSerilog();
builder.Services.AddConfigurationSections(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.AutoMigrateDatabase();

app.Run();