using Core.Application.Boundary.Responses.Topics;
using Core.Application.Factories;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Topics.Queries;

public class GetSingleTopicQuery : IRequest<Result<TopicResponse>>
{
    public Guid TopicId { get; }
    public string Slug { get; }

    public GetSingleTopicQuery(Guid topicId, string slug)
    {
        TopicId = topicId;
        Slug = slug;
    }
}

internal sealed class GetSingleTopicQueryHandler : IRequestHandler<GetSingleTopicQuery, Result<TopicResponse>>
{
    private readonly IRepositoryManager _repository;

    public GetSingleTopicQueryHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public async Task<Result<TopicResponse>> Handle(GetSingleTopicQuery request, CancellationToken cancellationToken)
    {
        var topic = await _repository.Entity<Topic>()
            .Where(t => t.Id == request.TopicId && t.Slug == request.Slug)
            .Include(t=>t.User)
            .ToTopicResponse()
            .FirstOrDefaultAsync(cancellationToken);
        
        return await Result<TopicResponse>.SuccessAsync(topic, "Success");
    }
}