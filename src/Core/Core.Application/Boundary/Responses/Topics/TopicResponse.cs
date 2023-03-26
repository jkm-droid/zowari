using Core.Application.Boundary.Responses.Bookmarks;
using Core.Application.Boundary.Responses.Messages;

namespace Core.Application.Boundary.Responses.Topics;

public class TopicResponse
{
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public AuthorResponse AuthorResponse { get; set; }
    public string Slug { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    
    public ICollection<MessageResponse> MessagesResponses { get; set; }
    public ICollection<BookmarkResponse> BookmarksResponses { get; set; }
}