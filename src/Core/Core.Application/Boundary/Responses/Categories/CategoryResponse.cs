using Core.Application.Boundary.Responses.Topics;

namespace Core.Application.Boundary.Responses.Categories;

public class CategoryResponse
{
    public  string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public int TopicCount { get; set; }
    
    public IList<TopicResponse> TopicsResponses { get; set; }
    
    public Guid ForumId { get; set; }
}