namespace Larmo.Domain.Domain.User;

public class RefreshToken : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Value { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}