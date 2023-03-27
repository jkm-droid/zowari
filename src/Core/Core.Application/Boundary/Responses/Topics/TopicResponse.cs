namespace Core.Application.Boundary.Responses.Topics;

public class TopicResponse
{
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public AuthorResponse AuthorResponse { get; set; }
    public TopicStatsResponse TopicStats { get; set; }
    public string Slug { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}