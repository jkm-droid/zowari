using Application.Features.Identity.Commands;
using Domain.Boundary.Requests;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

public class AccountController : Controller
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
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
            ViewData["PageErrors"] = response.Messages;
            return View();
        }

        return RedirectToAction("Login");
    }

    public IActionResult Login()
    {
        return View();
    }
}