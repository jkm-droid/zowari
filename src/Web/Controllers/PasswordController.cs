using Application.Boundary.Requests.Identity;
using Application.Features.Identity.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

[Route("password")]
public class PasswordController : Controller
{
    private readonly IMediator _mediator;

    public PasswordController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("forgot-password")]
    [AllowAnonymous]
    public ActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost("forgot-password")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ForgotPasswordAsync([Bind("Email")] ForgotPasswordRequest passwordRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(passwordRequest);
        }

        passwordRequest.Origin = Request.Headers["origin"];
        var response = await _mediator.Send(new ForgotPasswordCommand(passwordRequest));
        if (response.Succeeded)
        {
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        ViewData["PageErrors"] = response.Messages;
        return RedirectToAction(nameof(ForgotPasswordConfirmation));
    }

    [HttpGet]
    public ActionResult ForgotPasswordConfirmation()
    {
        return View();
    }
    
    [HttpGet("reset-password")]
    [AllowAnonymous]
    public ActionResult ResetPassword(string token, string email)
    {
        var resetRequest = new ResetPasswordRequest
        {
            Password = string.Empty,
            ConfirmPassword = string.Empty,
            Email = email,
            Token = token
        };
        return View(resetRequest);
    }  
    
    [HttpPost("reset-password")]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ResetPasswordAsync(ResetPasswordRequest resetRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(resetRequest);
        }

        var response = await _mediator.Send(new ResetPasswordCommand(resetRequest));
        if (!response.Succeeded)
        {
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        ViewData["PageErrors"] = response.Messages;
        return View(resetRequest);
    }    
    
    [HttpGet("reset-password-confirmation")]
    [AllowAnonymous]
    public ActionResult ResetPasswordConfirmation()
    {
        return View();
    }
    
}