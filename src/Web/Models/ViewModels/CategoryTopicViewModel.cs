using Core.Application.Boundary.Responses.Categories;
using Core.Application.Boundary.Responses.Topics;
using Infrastructure.Shared.Paging;

namespace Zowari.Models.ViewModels;

public class CategoryTopicViewModel
{
    public CategoryResponse CategoryResponse { get; set; }
    public PagedResponse<TopicResponse> TopicResponse { get; set; }
}