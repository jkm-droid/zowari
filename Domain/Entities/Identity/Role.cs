using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class Role: IdentityRole<Guid>,IBaseEntity
{
    public Role()
    {
        UserRoles = new HashSet<UserRole>();
        CreatedOn = DateTimeOffset.UtcNow;
        LastModifiedOn = DateTimeOffset.UtcNow;
    }
    [Column("RoleId")]
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    
    public virtual ICollection<UserRole> UserRoles { get; set; }
}