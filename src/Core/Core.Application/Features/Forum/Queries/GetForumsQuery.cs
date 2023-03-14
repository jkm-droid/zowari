using Application.Boundary.Responses.Forums;
using Infrastructure.Shared.Wrapper;
using MediatR;

namespace Application.Features.Forum.Queries;

public class GetForumsQuery : IRequest<Result<ForumResponse>>
{
    public GetForumsQuery()
    {
        
    }
}

internal sealed class GetForumsQueryHandler : IRequestHandler<GetForumsQuery, Result<ForumResponse>>
{
    public Task<Result<ForumResponse>> Handle(GetForumsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}