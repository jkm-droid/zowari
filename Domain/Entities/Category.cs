using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Category
{
    [Column("CategoryId")]
    public  Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    //has many topics
    public ICollection<Topic> Topics { get; set; }
    
    public Guid ForumId { get; set; }
    [ForeignKey(nameof(ForumId))]
    public ForumList ForumList { get; set; }
}