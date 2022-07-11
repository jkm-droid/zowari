using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Like
{
    [Column("LikeId")]
    public Guid Id { get; set; }
    public Guid MessageId { get; set; }
    [ForeignKey(nameof(MessageId))]
    public Message Message { get; set; }
}