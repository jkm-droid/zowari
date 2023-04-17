using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Core.Application.Boundary.Requests.Identity;
using Core.Application.Features.Identity.Commands;
using Domain.Entities.Identity;
using LoggerService.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

[Route("authentication")]
public class AuthenticationController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILoggerManager _logger;
    private readonly SignInManager<User> _signInManager;
    private readonly INotyfService _notyfService;

    public AuthenticationController(IMediator mediator, ILoggerManager logger, SignInManager<User> signInManager,
        INotyfService notyfService)
    {
        _mediator = mediator;
        _logger = logger;
        _signInManager = signInManager;
        _notyfService = notyfService;
    }

    /// <summary>
    /// Show registration form
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("register")]
    public IActionResult Register()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="userRegistrationRequest"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("register-user")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterUserAsync(UserRegistrationRequest userRegistrationRequest)
    {
        if (!ModelState.IsValid)
        {
            return View("Register", userRegistrationRequest);
        }

        var response = await _mediator.Send(new UserRegistrationCommand(userRegistrationRequest));

        if (response.Succeeded)
        {
            _notyfService.Success("Account created successfully, please confirm your email.");
            return RedirectToAction("Register");
        }

        ViewData["PageErrors"] = response.Messages;
        _notyfService.Error(response.Messages[0]);
        return View("Register");
    }

    /// <summary>
    /// Show login form
    /// </summary>
    /// <param name="returnUrl"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("login")]
    public IActionResult Login(string? returnUrl = null)
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Index", "Home");
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View(new UserLoginRequest
        {
            Username = string.Empty,
            Password = string.Empty
        });
    }

    /// <summary>
    /// Process login request
    /// </summary>
    /// <param name="userLoginRequest"></param>
    /// <param name="returnUrl"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("login-user")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginUserAsync([Bind("Username", "Password")] UserLoginRequest userLoginRequest,
        string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View("Login", userLoginRequest);
        }

        var response = await _mediator.Send(new UserLoginCommand(userLoginRequest));
        if (!response.Succeeded)
        {
            ViewData["PageErrors"] = response.Messages;
            return View("Login");
        }

        await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(response.Data.Identity));
        return RedirectToLocalUrl(returnUrl);
    }

    /// <summary>
    /// Log out user
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        _notyfService.Success("Logged out successfully!");
        return RedirectToAction("Index", "Home");
    }

    private IActionResult RedirectToLocalUrl(string? returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        _notyfService.Success("Logged in successfully!");
        return RedirectToAction("Index", "Home");
    }
}