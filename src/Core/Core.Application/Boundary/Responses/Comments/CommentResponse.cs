namespace Application.Boundary.Responses.Comments;

public class CommentResponse
{
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    public int Likes { get; set; }
    public Guid MessageId { get; set; }
}