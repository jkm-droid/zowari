using Core.Application.Boundary.Responses.Bookmarks;
using Core.Application.Boundary.Responses.Comments;
using Core.Application.Boundary.Responses.Likes;

namespace Core.Application.Boundary.Responses.Messages;

public class MessageResponse
{
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    
    public IList<CommentResponse> CommentsResponses { get; set; }
    public IList<BookmarkResponse> BookmarksResponses { get; set; }
    public IList<LikeResponse> LikesResponses { get; set; }
}