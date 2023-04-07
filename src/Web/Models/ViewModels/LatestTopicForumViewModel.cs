using Core.Application.Boundary.Responses.Forums;
using Core.Application.Boundary.Responses.Topics;
using Infrastructure.Shared.Paging;

namespace Zowari.Models.ViewModels;

public class LatestTopicForumViewModel
{
    public PagedResponse<TopicResponse> TopicResponse { get; set; }
    public List<ForumResponse> ForumResponse { get; set; }
}