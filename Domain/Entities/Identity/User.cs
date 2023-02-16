using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class User : IdentityUser<Guid>,IBaseEntity
{
    public User()
    {
        UserRoles = new HashSet<UserRole>();
        CreatedOn = DateTimeOffset.UtcNow;
        LastModifiedOn = DateTimeOffset.UtcNow;
    }
    public bool IsActive { get; set; }
    
    public string? ProfileUrl { get; set; }
    public int? Score { get; set; }
    public int? Rating { get; set; }
    public string? Level { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<BookMark> BookMarks { get; set; }
  
}