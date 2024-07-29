namespace Larmo.Domain.Domain;

public interface IEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}