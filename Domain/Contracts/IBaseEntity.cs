namespace Domain.Contracts;

public interface IBaseEntity : IEntity
{
    DateTimeOffset CreatedOn { get; set; }
    Guid? CreatedBy { get; set; }
    DateTimeOffset? LastModifiedOn { get; set; }
    Guid? LastModifiedBy { get; set; }
}