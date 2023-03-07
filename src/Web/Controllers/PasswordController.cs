using Application.Boundary.Requests.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

[Route("password")]
public class PasswordController : Controller
{
    [HttpGet("forgot-password")]
    public ActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost("forgot-password")]
    [ValidateAntiForgeryToken]
    public ActionResult ForgotPasswordAsync([Bind("Email")] ForgotPasswordRequest passwordRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(passwordRequest);
        }

        passwordRequest.Origin = Request.Headers["origin"];

        return RedirectToAction(nameof(ForgotPasswordConfirmation));
    }

    [HttpGet]
    public ActionResult ForgotPasswordConfirmation()
    {
        return View();
    }
    
    [HttpGet("reset-password")]
    public ActionResult ResetPassword()
    {
        return View();
    }  
    
    [HttpPost("reset-password")]
    public ActionResult ResetPasswordAsync()
    {
        throw new NotImplementedException();
    }
    
}