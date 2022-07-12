using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Activity : BaseEntity
{
    [Column("ActivityId")]
    public Guid Id { get; set; }
    public string ActivityBody { get; set; }
}