using Application.Boundary.Responses.Bookmarks;
using Application.Boundary.Responses.Messages;

namespace Application.Boundary.Responses.Topics;

public class TopicResponse
{
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    public string Slug { get; set; }
    
    public ICollection<MessageResponse> MessagesResponses { get; set; }
    public ICollection<BookmarkResponse> BookmarksResponses { get; set; }
}