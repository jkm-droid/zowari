using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Topic: BaseEntity
{
    public Topic()
    {
        Tags = new HashSet<Tag>();
    }
    [Column("TopicId")]
    public  Guid Id { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    public string Slug { get; set; }
    
    public ICollection<Message> Messages { get; set; }
    public ICollection<BookMark> BookMarks { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
    public Guid CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
}