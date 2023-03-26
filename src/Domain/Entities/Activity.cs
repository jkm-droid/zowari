using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;
using Domain.Entities.Identity;

namespace Domain.Entities;

public class Activity : BaseEntity
{
    [Column("ActivityId")]
    public Guid Id { get; set; }
    public string ActivityBody { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}