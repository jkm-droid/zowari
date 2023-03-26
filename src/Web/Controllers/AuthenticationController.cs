using System.Security.Claims;
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

public class AuthenticationController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILoggerManager _logger;
    private readonly SignInManager<User> _signInManager;

    public AuthenticationController(IMediator mediator, ILoggerManager logger, SignInManager<User> signInManager)
    {
        _mediator = mediator;
        _logger = logger;
        _signInManager = signInManager;
    }
    
    /// <summary>
    /// Show registration form
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet]
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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterAsync(UserRegistrationRequest userRegistrationRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(userRegistrationRequest);
        }

        var response = await _mediator.Send(new UserRegistrationCommand(userRegistrationRequest));
        if (response.Succeeded) return RedirectToAction("Login");
        
        _logger.LogError($"Errors: {response.Messages}");
        ViewData["PageErrors"] = response.Messages;
        return View();
    }

    /// <summary>
    /// Show login form
    /// </summary>
    /// <param name="returnUrl"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet]
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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginAsync([Bind("Username","Password")] UserLoginRequest userLoginRequest,string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(userLoginRequest);
        }

        var response = await _mediator.Send(new UserLoginCommand(userLoginRequest));
        if (!response.Succeeded)
        {
            ViewData["PageErrors"] = response.Messages;
            return View();
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
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    private IActionResult RedirectToLocalUrl(string? returnUrl)
    {
        return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : RedirectToAction("Index", "Home");
    }
}