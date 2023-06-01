using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ForumConfiguration : IEntityTypeConfiguration<ForumList>
{
    private readonly DateTimeOffset _defaultCreateOn = new(2023, 01, 01, 00, 00, 00, TimeSpan.Zero);
    public void Configure(EntityTypeBuilder<ForumList> builder)
    {
        builder.HasData(
            new ForumList
            {
                Id = Guid.Parse("627f0415-285b-4ad7-9bd7-a0f004094cab"),
                Title = "Hello",
                Description =  "Software Development",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            },
            new ForumList
            {
                Id = Guid.Parse("618f0db7-64b1-4c8a-8ebb-23f687be3776"),
                Title = "World Politics",
                Description =  "World politics forum",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            },
            new ForumList
            {
                Id = Guid.Parse("2e48d11f-102d-45e0-8c93-a0b87426d0fa"),
                Title = "Nature",
                Description =  "Nature forum",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            }
        );
    }
}