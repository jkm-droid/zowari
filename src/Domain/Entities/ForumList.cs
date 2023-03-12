using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class ForumList : BaseEntity
{
    [Column("ForumId")]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //has many categories
    public ICollection<Category> Categories { get; set; }
}