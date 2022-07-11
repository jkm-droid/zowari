using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class BookMark
{
    [Column("BookMarkId")]
    public  Guid BookMarkId { get; set; }
    
    public Guid TopicId { get; set; }
    [ForeignKey(nameof(TopicId))]
    public Topic Topic { get; set; }
    
    public Guid MessageId { get; set; }
    [ForeignKey(nameof(MessageId))]
    public Message Message { get; set; }
}