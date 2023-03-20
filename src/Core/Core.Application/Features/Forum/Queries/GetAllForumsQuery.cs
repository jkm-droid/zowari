using Application.Boundary.Responses.Forums;
using Application.Factories;
using Infrastructure.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Forum.Queries;

public class GetAllForumsQuery : IRequest<Result<List<ForumResponse>>>
{
    public GetAllForumsQuery()
    {
        
    }
}

internal sealed class GetAllForumsQueryHandler : IRequestHandler<GetAllForumsQuery, Result<List<ForumResponse>>>
{
    private readonly IRepositoryManager _repository;

    public GetAllForumsQueryHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public async Task<Result<List<ForumResponse>>> Handle(GetAllForumsQuery request, CancellationToken cancellationToken)
    {
        var forums = await _repository.DbContext().ForumLists.OrderBy(f => f.CreatedOn)
            .ToForumLists()
            .ToListAsync(cancellationToken);
        return await Result<List<ForumResponse>>.SuccessAsync(forums);
    }
}