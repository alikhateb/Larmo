namespace Larmo.Domain.Domain.Identity;

public class UserGroup
{
    private UserGroup()
    {
    }

    public string Id { get; set; }
    public string GroupId { get; set; }
    public Group Group { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }

    public static UserGroup Create(string groupId, string userId)
    {
        var group = new UserGroup
        {
            Id = Guid.NewGuid().ToString("N"),
            GroupId = groupId,
            UserId = userId
        };

        return group;
    }
}