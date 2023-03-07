using System.Security.Policy;
using Application.Boundary.Requests.Identity;
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

    public ForgotPasswordCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
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
        
        throw new NotImplementedException();
    }
}