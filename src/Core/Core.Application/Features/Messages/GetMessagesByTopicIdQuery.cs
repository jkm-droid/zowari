using Core.Application.Boundary.QueryParams;
using Core.Application.Boundary.Responses.Messages;
using Core.Application.Boundary.Responses.Topics;
using Core.Application.Factories;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Extensions;
using Infrastructure.Shared.Paging;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Messages;

public class GetMessagesByTopicIdQuery : IRequest<Result<PagedResponse<MessageResponse>>>
{
    public Guid TopicId { get; }
    public MessageQueryParameters Parameters { get; }

    public GetMessagesByTopicIdQuery(Guid topicId, MessageQueryParameters parameters)
    {
        TopicId = topicId;
        Parameters = parameters;
    }
}

internal sealed class
    GetMessagesByTopicIdQueryHandler : IRequestHandler<GetMessagesByTopicIdQuery, Result<PagedResponse<MessageResponse>>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetMessagesByTopicIdQueryHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Result<PagedResponse<MessageResponse>>> Handle(GetMessagesByTopicIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repositoryManager.Entity<Message>()
                .FilterMessageRecords(request.Parameters.SearchTerm)
                .Include(t=>t.User)
                .TrackChanges(false);
            
            var messageRecords = await query
                .GetPage(request.Parameters.PageNumber, request.Parameters.PageSize)
                .ToMessageResponse()
                .ToListAsync(cancellationToken);

            var recordsCount = await query.CountAsync(cancellationToken);
            
            var pagedList = PagedList<MessageResponse>.ToPagedList(messageRecords,recordsCount, request.Parameters.PageNumber,
                request.Parameters.PageSize);
        
            var response = new PagedResponse<MessageResponse>
            {
                PagingMetaData = pagedList.MetaData,
                Data = pagedList
            };

            return await Result<PagedResponse<MessageResponse>>.SuccessAsync(response);
        }
        catch (Exception e)
        {
            return await Result<PagedResponse<MessageResponse>>.FailAsync($"{e.Message}{e.InnerException?.Message}");
        }
    }
}