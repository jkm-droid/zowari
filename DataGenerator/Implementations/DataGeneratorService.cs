using Bogus;
using DataGenerator.Abstractions;
using Domain.Entities;
using Domain.Entities.Identity;

namespace DataGenerator.Implementations;

public class DataGeneratorService : IDataGeneratorService
{
    public List<ForumList> GenerateFakeForums()
    {
        var fakeForums = new Faker<ForumList>()
            .RuleFor(fl => fl.Id, f => Guid.NewGuid())
            .RuleFor(fl => fl.Title, f => f.Random.Words(4))
            .RuleFor(fl => fl.Description, f => f.Random.Words(10))
            .Generate(30);

        return fakeForums;
    }
}