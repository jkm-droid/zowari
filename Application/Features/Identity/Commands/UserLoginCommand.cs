using Application.Auth.Abstractions;
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
    private readonly IAuthenticationManager _authenticationManager;

    public UserLoginCommandHandler(UserManager<User> userManager, IRepositoryManager repositoryManager, IAuthenticationManager authenticationManager)
    {
        _userManager = userManager;
        _repositoryManager = repositoryManager;
        _authenticationManager = authenticationManager;
    }
    public async Task<Result<UserLoginResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _repositoryManager.DbContext().Users
            .Where(u => u.UserName == request.LoginRequest.Username.Trim() || u.Email == request.LoginRequest.Username.Trim())
            .SingleOrDefaultAsync(cancellationToken);
        
        if (user == null)
        {
            return await Result<UserLoginResponse>.FailAsync("Oops..It seems you don't have an account with us");
        }

        // if (!user.IsActive)
        // {
        //     return await Result<UserLoginResponse>.FailAsync("Oops..It seems your account is not active");
        // }

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.LoginRequest.Password);
        if (!passwordValid)
        {
            return await Result<UserLoginResponse>.FailAsync("Invalid credentials.");
        }

        var jwtToken = await _authenticationManager.CreateAuthJwtToken(user);
        var response = new UserLoginResponse
        {
            User = user,
            Message = "Logged in successfully",
            Token = jwtToken,
            RefreshTokem = "ComingSoon"
        };
  
        return await Result<UserLoginResponse>.SuccessAsync(response);
    }
}