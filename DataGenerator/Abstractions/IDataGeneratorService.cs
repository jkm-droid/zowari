using Bogus;
using Domain.Entities;
using Domain.Entities.Identity;

namespace DataGenerator.Abstractions;

public interface IDataGeneratorService
{
    public List<ForumList> GenerateFakeForums();
}