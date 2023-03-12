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

    /// <summary>
    /// Show forgot password page
    /// </summary>
    /// <returns></returns>
    [HttpGet("forgot-password")]
    [AllowAnonymous]
    public ActionResult ForgotPassword()
    {
        return View();
    }

    /// <summary>
    /// Process the forgot password request
    /// </summary>
    /// <param name="passwordRequest"></param>
    /// <returns></returns>
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
        if (response.Succeeded || response.Messages.Contains("Email not found"))
        {
            ViewBag.Email = passwordRequest.Email;
            return View("ForgotPasswordConfirmation");
        }

        ViewData["PageErrors"] = response.Messages;
        return View(passwordRequest);
    }

    /// <summary>
    /// Forgot password confirmation page
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult ForgotPasswordConfirmation()
    {
        ViewData["email"] = ViewBag.Email;
        return View();
    }

    /// <summary>
    /// Show reset password page
    /// </summary>
    /// <param name="token"></param>
    /// <param name="email"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Process reset password request
    /// </summary>
    /// <param name="resetRequest"></param>
    /// <returns></returns>
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
        if (response.Succeeded)
        {
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        ViewData["PageErrors"] = response.Messages;
        return View(resetRequest);
    }

    /// <summary>
    /// Reset password confirmation page
    /// </summary>
    /// <returns></returns>
    [HttpGet("reset-password-confirmation")]
    [AllowAnonymous]
    public ActionResult ResetPasswordConfirmation()
    {
        return View();
    }
}