using Bogus;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Test.Commands;

public class GenerateFakeDataCommand : IRequest<Result<string>>
{
    
}

internal sealed class GenerateFakeDataCommandHandler : IRequestHandler<GenerateFakeDataCommand, Result<string>>
{
    private readonly IRepositoryManager _repository;

    public GenerateFakeDataCommandHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public async Task<Result<string>> Handle(GenerateFakeDataCommand request, CancellationToken cancellationToken)
    {
        var forumIds = await _repository.DbContext().ForumLists
            .Select(c=>c.Id)
            .ToListAsync(cancellationToken);

        var fakeCategories = new Faker<Category>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.ForumId, f => f.PickRandom(forumIds))
            .RuleFor(c => c.Title, f => f.Random.Words(5))
            .RuleFor(c => c.Slug, f => f.Random.Words(5).Replace(" ", "-").ToLower())
            .RuleFor(c => c.Description, f => f.Random.Words(15))
            .Generate(50);

        await _repository.DbContext().Categories.AddRangeAsync(fakeCategories, cancellationToken);

        var fakeTopics = new Faker<Topic>()
            .RuleFor(t => t.CategoryId, f => f.PickRandom(fakeCategories.Select(fc => fc.Id)))
            .RuleFor(t => t.Body, f => f.Random.Words(10))
            .RuleFor(t => t.Author, f => f.Person.FullName)
            .RuleFor(t => t.Slug, f => f.Random.Words(10).Replace(" ", "-").ToLower())
            .Generate(300);
        
        await _repository.DbContext().Topics.AddRangeAsync(fakeTopics, cancellationToken);
        await _repository.SaveAsync("Failed to save data");

        return await Result<string>.SuccessAsync("Success");
    }
}