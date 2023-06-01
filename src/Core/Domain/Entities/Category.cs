using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Category: BaseEntity
{
    [Column("CategoryId")]
    [Key]
    public  string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    //has many topics
    public ICollection<Topic> Topics { get; set; }
    
    public Guid ForumId { get; set; }
    [ForeignKey(nameof(ForumId))]
    public ForumList ForumList { get; set; }
}