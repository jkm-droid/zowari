using System.Security.Policy;
using Application.Boundary.Requests.Identity;
using Core.EmailService;
using Core.EmailService.Services;
using Domain.Entities.Identity;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace Application.Features.Identity.Commands;

public class ForgotPasswordCommand : IRequest<Result<string>>
{
    public ForgotPasswordRequest PasswordRequest { get; }

    public ForgotPasswordCommand(ForgotPasswordRequest passwordRequest)
    {
        PasswordRequest = passwordRequest;
    }
}

internal sealed class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Result<string>>
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailSenderService _emailSenderService;

    public ForgotPasswordCommandHandler(UserManager<User> userManager, IEmailSenderService emailSenderService)
    {
        _userManager = userManager;
        _emailSenderService = emailSenderService;
    }
    public async Task<Result<string>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.PasswordRequest.Email);
        if (userExists == null)
        {
            return await Result<string>.FailAsync("Email not found");
        }

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(userExists);
        var passResetUri = new Uri(string.Concat($"{request.PasswordRequest.Origin}/", "password/reset-password"));
        var resetPasswordUrl = QueryHelpers.AddQueryString(passResetUri.ToString(), "Token", resetToken);
        var email = new EmailMessageRequest(
            new string[]{ request.PasswordRequest.Email},
            "Reset password token",
            resetPasswordUrl
        );
        await _emailSenderService.SendEmailAsync(email);

        return await Result<string>.SuccessAsync("Password reset email sent");
    }
}