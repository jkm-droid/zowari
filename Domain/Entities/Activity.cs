using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Activity
{
    [Column("ActivityId")]
    public Guid Id { get; set; }
    public string ActivityBody { get; set; }
}