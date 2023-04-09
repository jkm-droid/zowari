using Core.Application.Boundary.QueryParams;
using Core.Application.Boundary.Responses.Topics;
using Core.Application.Factories;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Extensions;
using Infrastructure.Shared.Paging;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Topics.Queries;

public class GetAllTopicsQuery : IRequest<Result<PagedResponse<TopicResponse>>>
{
    public TopicQueryParameters QueryParameters { get; }

    public GetAllTopicsQuery(TopicQueryParameters queryParameters)
    {
        QueryParameters = queryParameters;
    }
}

internal sealed class
    GetAllTopicsQueryHandler : IRequestHandler<GetAllTopicsQuery, Result<PagedResponse<TopicResponse>>>
{
    private readonly IRepositoryManager _repository;

    public GetAllTopicsQueryHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public async Task<Result<PagedResponse<TopicResponse>>> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository.Entity<Topic>()
                .FilterTopicRecords(request.QueryParameters.SearchTerm,request.QueryParameters.SortTerm)
                .Include(t=>t.User)
                .TrackChanges(false);

            var topicRecords = await query
                .GetPage(request.QueryParameters.PageNumber, request.QueryParameters.PageSize)
                .ToTopicResponse()
                .ToListAsync(cancellationToken);

            var recordsCount = await query.CountAsync(cancellationToken);
            
            var pagedList = PagedList<TopicResponse>.ToPagedList(topicRecords,recordsCount, request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize);
        
            var response = new PagedResponse<TopicResponse>
            {
                PagingMetaData = pagedList.MetaData,
                Data = pagedList
            };

            return await Result<PagedResponse<TopicResponse>>.SuccessAsync(response);
        }
        catch (Exception e)
        {
            return await Result<PagedResponse<TopicResponse>>.FailAsync($"{e.Message}{e.InnerException?.Message}");
        }
    }
}