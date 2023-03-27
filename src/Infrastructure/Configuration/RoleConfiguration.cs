using Domain.Constants;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    private readonly DateTimeOffset _defaultCreateOn = new(2023, 01, 01, 00, 00, 00, TimeSpan.Zero);

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = Guid.Parse(RoleIdConstants.VisitorId),
                Name = "Visitor",
                NormalizedName = "VISITOR",
                Description = "Visitor role description",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            },
            new Role
            {
                Id = Guid.Parse(RoleIdConstants.SuperAdministratorId),
                Name = "SuperAdministrator",
                NormalizedName = "SUPER_ADMINISTRATOR",
                Description = "Administrator role description",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            },
            new Role
            {
                Id = Guid.Parse(RoleIdConstants.BasicUserId),
                Name = "BasicUser",
                NormalizedName = "BASIC_USER",
                Description = "Basic role description",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            },
            new Role
            {
                Id = Guid.Parse(RoleIdConstants.AdministratorId),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Description = "Administrator role description",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            }
            );
    }
}