using Domain.Constants;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = Guid.Parse(RoleIds.VisitorId),
                Name = "Visitor",
                NormalizedName = "VISITOR",
                Description = "Visitor role description"
            },
            new Role
            {
                Id = Guid.Parse(RoleIds.SuperAdministratorId),
                Name = "SuperAdministrator",
                NormalizedName = "SUPER_ADMINISTRATOR",
                Description = "Administrator role description"
            },
            new Role
            {
                Id = Guid.Parse(RoleIds.BasicUserId),
                Name = "BasicUser",
                NormalizedName = "BASIC_USER",
                Description = "Basic role description"
            },
            new Role
            {
                Id = Guid.Parse(RoleIds.AdministratorId),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Description = "Administrator role description"
            }
            );
    }
}