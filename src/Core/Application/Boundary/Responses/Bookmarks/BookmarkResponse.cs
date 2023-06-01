namespace Core.Application.Boundary.Responses.Bookmarks;

public class BookmarkResponse
{
    public  Guid BookMarkId { get; set; }
    public Guid UserId { get; set; }
    public Guid TopicId { get; set; }
    public Guid MessageId { get; set; }
}