using System.Security.Claims;
using Application.Features.Identity.Commands;
using Domain.Boundary.Requests;
using Domain.Entities.Identity;
using LoggerService.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

public class AccountController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILoggerManager _logger;
    private readonly SignInManager<User> _signInManager;

    public AccountController(IMediator mediator, ILoggerManager logger, SignInManager<User> signInManager)
    {
        _mediator = mediator;
        _logger = logger;
        _signInManager = signInManager;
    }
    
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
    
    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegistrationRequest userRegistrationRequest)
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

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Username","Password")] UserLoginRequest userLoginRequest,string? returnUrl = null)
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