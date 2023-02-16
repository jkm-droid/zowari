using Bogus;
using DataGenerator.Abstractions;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ForumConfiguration : IEntityTypeConfiguration<ForumList>
{
   
    public void Configure(EntityTypeBuilder<ForumList> builder)
    {
        builder.HasData(
            new ForumList
            {
                Id = Guid.NewGuid(),
                Title = "Hello",
                Description =  "Hello world forum"
            },
            new ForumList
            {
                Id = Guid.NewGuid(),
                Title = "World politics",
                Description =  "World politics forum"
            },
            new ForumList
            {
                Id = Guid.NewGuid(),
                Title = "Nature",
                Description =  "Nature forum"
            }
        );
    }
}