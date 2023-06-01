using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Contracts;

public class BaseEntity : IBaseEntity
{
    public BaseEntity()
    {
        CreatedOn = DateTimeOffset.Now;
        LastModifiedOn = DateTimeOffset.Now;
    }

    public DateTimeOffset CreatedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }

}