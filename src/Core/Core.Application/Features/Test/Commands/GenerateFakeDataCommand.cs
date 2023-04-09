using Bogus;
using Domain.Entities;
using Domain.Entities.Identity;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Test.Commands;

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
            .Select(c => c.Id)
            .ToListAsync(cancellationToken);

        // var fakeUsers = new Faker<User>()
        //     .RuleFor(u => u.Id, f => Guid.NewGuid())
        //     .RuleFor(u => u.UserName, f => f.Person.UserName)
        //     .RuleFor(u => u.Email, f => f.Person.Email)
        //     .RuleFor(u => u.PasswordHash, f => f.Internet.Password())
        //     .Generate(30);
        //
        // await _repository.DbContext().Users.AddRangeAsync(fakeUsers, cancellationToken);
        var fakeUsers = await _repository.DbContext().Users.ToListAsync(cancellationToken);
        var userIds = fakeUsers.Select(u => u.Id).ToList();

        // var fakeCategories = new Faker<Category>()
        //     .RuleFor(c => c.Id, f => f.Random.AlphaNumeric(15).ToUpper())
        //     .RuleFor(c => c.ForumId, f => f.PickRandom(forumIds))
        //     .RuleFor(c => c.Title, f => f.Random.Word())
        //     .RuleFor(c => c.Slug, f => f.Random.Words(5).Replace(" ", "-").ToLower())
        //     .RuleFor(c => c.Description, f => f.Lorem.Sentence(20))
        //     .Generate(30);
        //
        // await _repository.DbContext().Categories.AddRangeAsync(fakeCategories, cancellationToken);

        var fakeCategories = await _repository.DbContext().Categories
            .Select(c => c.Id)
            .ToListAsync(cancellationToken);
       
        var userId = new Faker().PickRandom(userIds);
        var username = fakeUsers
            .Where(u => u.Id == userId)
            .Select(u => u.UserName)
            .FirstOrDefault();
            
        var fakeTopics = new Faker<Topic>()
            .RuleFor(t => t.CategoryId, f => f.PickRandom(fakeCategories))
            .RuleFor(t => t.Title, f => f.Lorem.Sentence())
            .RuleFor(t => t.Body, f => f.Lorem.Sentences(5))
            .RuleFor(t => t.Views, f => f.Random.Number(1000, 10000))
            .RuleFor(t => t.Author, f => username)
            .RuleFor(t => t.UserId, f => userId)
            .RuleFor(t => t.Slug, f => f.Random.Words(10).Replace(" ", "-").ToLower())
            .Generate(3000);

        await _repository.DbContext().Topics.AddRangeAsync(fakeTopics, cancellationToken);
        
        var mUserId = new Faker().PickRandom(userIds);
        var mUsername = fakeUsers
            .Where(u => u.Id == userId)
            .Select(u => u.UserName)
            .FirstOrDefault();

        var fakeMessages = new Faker<Message>()
            .RuleFor(m => m.Body, f => f.Lorem.Paragraphs(2,3))
            .RuleFor(m => m.Author, f => mUsername)
            .RuleFor(m => m.UserId, f => mUserId)
            .RuleFor(m => m.TopicId, f => f.PickRandom(fakeTopics.Select(ft => ft.Id)))
            .Generate(4000);
        
        await _repository.DbContext().Messages.AddRangeAsync(fakeMessages, cancellationToken);
        
        await _repository.SaveAsync("Failed to save data");

        return await Result<string>.SuccessAsync("Success");
    }
}