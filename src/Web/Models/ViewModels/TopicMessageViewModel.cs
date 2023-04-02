using Core.Application.Boundary.Responses.Messages;
using Core.Application.Boundary.Responses.Topics;
using Infrastructure.Shared.Paging;

namespace Zowari.Models.ViewModels;

public class TopicMessageViewModel
{
    public TopicResponse TopicResponse { get; set; }
    public PagedResponse<MessageResponse> MessageResponse { get; set; }
}