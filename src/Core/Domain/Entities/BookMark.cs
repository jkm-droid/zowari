using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;
using Domain.Entities.Identity;

namespace Domain.Entities;

public class BookMark: BaseEntity
{
    [Column("BookMarkId")]
    public  Guid BookMarkId { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public Guid TopicId { get; set; }
    [ForeignKey(nameof(TopicId))]
    public Topic Topic { get; set; }
    public Guid MessageId { get; set; }
    [ForeignKey(nameof(MessageId))]
    public Message Message { get; set; }
}