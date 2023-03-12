using Application.Boundary.Requests.Identity;
using Core.EmailService;
using Core.EmailService.Services;
using Domain.Entities.Identity;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Identity.Commands;

public class ResetPasswordCommand : IRequest<Result<string>>
{
    public ResetPasswordRequest ResetRequest { get; }

    public ResetPasswordCommand(ResetPasswordRequest resetRequest)
    {
        ResetRequest = resetRequest;
    }
}

internal sealed class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result<string>>
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailSenderService _emailSenderService;

    public ResetPasswordCommandHandler(UserManager<User> userManager, IEmailSenderService emailSenderService)
    {
        _userManager = userManager;
        _emailSenderService = emailSenderService;
    }
    public async Task<Result<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.ResetRequest.Email);
        if (user == null)
        {
            return await Result<string>.FailAsync("Email not found");
        }

        var resetResponse =
            await _userManager.ResetPasswordAsync(user, request.ResetRequest.Token, request.ResetRequest.Password);
        if (resetResponse.Succeeded)
        {
            var email = new EmailMessageRequest(
                new string[]{ user.Email},
                "Password reset notification",
                ""
            );
            //Todo send email in the background
            await _emailSenderService.SendEmailAsync(email);
            
            return await Result<string>.SuccessAsync("Password reset was successful");
        }
        
        return await Result<string>.FailAsync("An error has occurred when resetting password");
    }
}