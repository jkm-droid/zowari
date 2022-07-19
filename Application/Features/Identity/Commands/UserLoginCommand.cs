using Domain.Boundary.Requests;
using Domain.Boundary.Responses;
using Domain.Entities.Identity;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Identity.Commands;

public class UserLoginCommand : IRequest<Result<UserLoginResponse>>
{
    public UserLoginRequest LoginRequest { get; set; }

    public UserLoginCommand(UserLoginRequest loginRequest)
    {
        LoginRequest = loginRequest;
    }
}

internal sealed class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<UserLoginResponse>>
{
    private readonly UserManager<User> _userManager;
    private readonly IRepositoryManager _repositoryManager;

    public UserLoginCommandHandler(UserManager<User> userManager, IRepositoryManager repositoryManager)
    {
        _userManager = userManager;
        _repositoryManager = repositoryManager;
    }
    public async Task<Result<UserLoginResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        //find user by email
        var userByEmail = await _userManager.FindByEmailAsync(request.LoginRequest.Username);
        //find user by username
        var userByUserName = await _repositoryManager.DbContext().Users
            .Where(u => u.UserName == request.LoginRequest.Username)
            .SingleOrDefaultAsync(cancellationToken);
        if (userByEmail == null && userByUserName == null)
        {
            return await Result<UserLoginResponse>.FailAsync("Oops..It seems you don't have an account with us");
        }

        if (userByEmail != null)
        {
            if (!userByEmail.IsActive)
            {
                return await Result<UserLoginResponse>.FailAsync("Oops..It seems your account is not active");
            }
        }else if (userByUserName is {IsActive: false})
        {
            return await Result<UserLoginResponse>.FailAsync("Oops..It seems your account is not active");
        }

        var passwordValid = userByEmail != null
            ? await _userManager.CheckPasswordAsync(userByEmail, request.LoginRequest.Password)
            : await _userManager.CheckPasswordAsync(userByUserName, request.LoginRequest.Password);

        if (!passwordValid)
        {
            return await Result<UserLoginResponse>.FailAsync("Invalid credentials.");
        }

        var response = new UserLoginResponse
        {
            Username = request.LoginRequest.Username,
            Message = "Logged in successfully"
        };

        return await Result<UserLoginResponse>.SuccessAsync(response);
    }
}