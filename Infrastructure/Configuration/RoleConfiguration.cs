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
                Id = Guid.NewGuid(),
                Name = "Visitor",
                NormalizedName = "VISITOR",
                Description = "Visitor role description"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Description = "Administrator role description"
            });
    }
}