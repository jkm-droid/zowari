using Core.Application.Boundary.Responses.Categories;
using Core.Application.Factories;
using Domain.Entities;
using Infrastructure.Repositories.Abstractions;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<Result<CategoryResponse>>
{
    public string CategoryId { get; set; }
    public string Slug { get; }

    public GetCategoryByIdQuery(string categoryId,string slug)
    {
        CategoryId = categoryId;
        Slug = slug;
    }
}

internal sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryResponse>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetCategoryByIdQueryHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repositoryManager.Entity<Category>()
            .Where(c => c.Id.Equals(request.CategoryId) && c.Slug.Equals(request.Slug))
            .ToCategoryResponse()
            .FirstOrDefaultAsync(cancellationToken);

        return await Result<CategoryResponse>.SuccessAsync(category, "Success");
    }
}