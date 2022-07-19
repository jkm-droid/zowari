using Application.Features.Identity.Commands;
using Domain.Boundary.Requests;
using Domain.Entities.Identity;
using LoggerService.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

public class AccountController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILoggerManager _logger;

    public AccountController(IMediator mediator, ILoggerManager logger, IAuthenticationManager authManager)
    {
        _mediator = mediator;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegistrationRequest userRegistrationRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(userRegistrationRequest);
        }

        var response = await _mediator.Send(new UserRegistrationCommand(userRegistrationRequest));
        if (!response.Succeeded)
        {
            _logger.LogError($"Errors: {response.Messages}");
            ViewData["PageErrors"] = response.Messages;
            return View();
        }

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Username","Password")] UserLoginRequest userLoginRequest)
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

        return RedirectToAction("Index","Home");
    }
}