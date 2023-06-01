using Core.Application.Boundary.Requests.Identity;
using Domain.Entities.Identity;
using Infrastructure.Repositories.Abstractions;
using Infrastructure.Shared.Wrapper;
using LoggerService.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Identity.Commands;

public class UserRegistrationCommand : IRequest<Result<string>>
{
    public UserRegistrationRequest UserRegistrationRequest { get; set; }

    public UserRegistrationCommand(UserRegistrationRequest userRegistrationRequest)
    {
        UserRegistrationRequest = userRegistrationRequest;
    }  
}

internal sealed class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, Result<string>>
{
    private readonly UserManager<User> _userManager;
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;

    public UserRegistrationCommandHandler(UserManager<User> userManager, IRepositoryManager repositoryManager,ILoggerManager logger)
    {
        _userManager = userManager;
        _repositoryManager = repositoryManager;
        _logger = logger;
    }
    public async Task<Result<string>> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInfo($"inside command{request.UserRegistrationRequest.Username},{request.UserRegistrationRequest.Email}");
        var checkSameEmail = await _userManager.FindByEmailAsync(request.UserRegistrationRequest.Email);
        if (checkSameEmail != null)
        {
            return await Result<string>.FailAsync($"Email {request.UserRegistrationRequest.Email} is already registered.");
        }

        var user = new User
        {
            UserName = request.UserRegistrationRequest.Username.Trim(),
            NormalizedUserName = request.UserRegistrationRequest.Username.Trim().ToUpper(),
            Email = request.UserRegistrationRequest.Email.Trim(),
            IsActive = false,
        };
        //register the user
        var response = await _userManager.CreateAsync(user, request.UserRegistrationRequest.Password);
        if (!response.Succeeded)
        {
            return await Result<string>.FailAsync(response.Errors
                .Select(a => a.Description.ToString()).ToList());
        }
        
        //add role to the user
        var role = await _repositoryManager.Entity<Role>()
            .Where(r => r.Name == "visitor")
            .FirstOrDefaultAsync(cancellationToken);
        if (role != null)
        {
            var userRole = new UserRole {UserId = user.Id, RoleId = role.Id};
            _repositoryManager.DbContext().UserRoles.Add(userRole);
            await _repositoryManager.SaveAsync();
        }
        else
        {
            await _userManager.AddToRoleAsync(user, "visitor");
        }
        _logger.LogInfo($"user created{response.Succeeded}");
        return await Result<string>.SuccessAsync($"{request.UserRegistrationRequest.Username}'s account created successfully");
    }
}