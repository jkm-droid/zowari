using Application.Boundary.Responses.Forums;
using Application.Boundary.Responses.Topics;
using Infrastructure.Shared.Paging;

namespace Zowari.Models.ViewModels;

public class LatestTopicsForumsViewModel
{
    public PagedResponse<TopicResponse> TopicResponse { get; set; }
    public List<ForumResponse> ForumResponse { get; set; }
}