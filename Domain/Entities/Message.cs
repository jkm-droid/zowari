using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Message
{
    [Column("MessageId")]
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
    public ICollection<BookMark> BookMarks { get; set; }
    public ICollection<Like> Likes { get; set; }
    public Guid TopicId { get; set; }
    [ForeignKey(nameof(TopicId))]
    public Topic Topic { get; set; }
}