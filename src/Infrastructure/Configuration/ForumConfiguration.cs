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
                Id = Guid.NewGuid(),
                Title = "Hello",
                Description =  "Hello world forum",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            },
            new ForumList
            {
                Id = Guid.NewGuid(),
                Title = "World politics",
                Description =  "World politics forum",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            },
            new ForumList
            {
                Id = Guid.NewGuid(),
                Title = "Nature",
                Description =  "Nature forum",
                CreatedOn = _defaultCreateOn,
                LastModifiedOn = _defaultCreateOn
            }
        );
    }
}