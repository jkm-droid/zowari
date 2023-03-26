using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;
using Domain.Entities.Identity;

namespace Domain.Entities;

public class Comment : BaseEntity
{
    [Column("CommentId")]
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    public int Likes { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public Guid MessageId { get; set; }
    [ForeignKey(nameof(MessageId))]
    public Message Message { get; set; }
}