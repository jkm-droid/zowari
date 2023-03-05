using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Tag: BaseEntity
{
    public Tag()
    {
        Topics = new HashSet<Topic>();
    }
    [Column("TagId")]
    public Guid TagId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public virtual ICollection<Topic> Topics { get; set; }
}