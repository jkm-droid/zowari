using Domain.Boundary.Requests;
using Domain.Boundary.Responses;
using Domain.Entities.Identity;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Identity.Commands;

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

    public UserRegistrationCommandHandler(UserManager<User> userManager, IRepositoryManager repositoryManager)
    {
        _userManager = userManager;
        _repositoryManager = repositoryManager;
    }
    public async Task<Result<string>> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var checkSameEmail = await _userManager.FindByEmailAsync(request.UserRegistrationRequest.EmailAddress);
        if (checkSameEmail != null)
        {
            return await Result<string>.FailAsync($"Email {request.UserRegistrationRequest.EmailAddress} is already registered.");
        }

        var user = new User
        {
            UserName = request.UserRegistrationRequest.Username,
            EmailAddress = request.UserRegistrationRequest.EmailAddress,
            Password = request.UserRegistrationRequest.Password,
            FirstName = request.UserRegistrationRequest.FirstName,
            LastName = request.UserRegistrationRequest.LastName,
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
            .Where(r => r.Name.Equals("visitor", StringComparison.InvariantCultureIgnoreCase))
            .FirstOrDefaultAsync(cancellationToken);
        if (role != null)
        {
            var userRole = new UserRole {UserId = user.UserId, RoleId = role.RoleId};
            _repositoryManager.DbContext().UserRoles.Add(userRole);
            await _repositoryManager.SaveAsync();
        }
        
        return await Result<string>.SuccessAsync($"{request.UserRegistrationRequest.Username} created successfully");
    }
}