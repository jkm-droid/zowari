using Core.Application.Boundary.QueryParams;
using Core.Application.Boundary.Responses.Categories;
using Core.Application.Boundary.Responses.Topics;
using Core.Application.Factories;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Extensions;
using Infrastructure.Shared.Paging;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Features.Categories.Queries;

public class GetAllCategoriesQuery : IRequest<Result<PagedResponse<CategoryResponse>>>
{
    public CategoryQueryParameters QueryParameters { get; }

    public GetAllCategoriesQuery(CategoryQueryParameters queryParameters)
    {
        QueryParameters = queryParameters;
    }
}

internal sealed class
    GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<PagedResponse<CategoryResponse>>>
{
    private readonly IRepositoryManager _repository;

    public GetAllCategoriesQueryHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<PagedResponse<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository.Entity<Category>()
                .FilterCategoryRecords(request.QueryParameters.SearchTerm)
                .TrackChanges(false);

            var categoryRecords = await query
                .GetPage(request.QueryParameters.PageNumber, request.QueryParameters.PageSize)
                .ToCategoryResponse()
                .ToListAsync(cancellationToken);

            var recordsCount = await query.CountAsync(cancellationToken);
            
            var pagedList = PagedList<CategoryResponse>.ToPagedList(categoryRecords,recordsCount, request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize);
        
            var response = new PagedResponse<CategoryResponse>
            {
                PagingMetaData = pagedList.MetaData,
                Data = pagedList
            };

            return await Result<PagedResponse<CategoryResponse>>.SuccessAsync(response);
        }
        catch (Exception e)
        {
            return await Result<PagedResponse<CategoryResponse>>.FailAsync($"{e.Message}{e.InnerException?.Message}");
        }
    }
}