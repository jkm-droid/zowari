using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ForumList
{
    [Column("ForumId")]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //has many categories
    public ICollection<Category> Categories { get; set; }
}