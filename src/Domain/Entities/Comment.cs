using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Comment : BaseEntity
{
    [Column("CommentId")]
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    public int Likes { get; set; }
    public Guid MessageId { get; set; }
    [ForeignKey(nameof(MessageId))]
    public Message Message { get; set; }
}