using Core.Application.Boundary.Responses.Messages;
using Core.Application.Boundary.Responses.Shared;

namespace Core.Application.Boundary.Responses.Topics;

public class TopicResponse
{
    public  Guid TopicId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public AuthorResponse AuthorResponse { get; set; }
    public TopicStatsResponse TopicStats { get; set; }
    public string CreatedOn { get; set; }
}