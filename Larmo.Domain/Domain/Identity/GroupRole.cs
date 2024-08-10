namespace Larmo.Domain.Domain.Identity;

public class GroupRole
{
    private GroupRole()
    {
    }

    public string Id { get; set; }
    public string GroupId { get; set; }
    public Group Group { get; set; }
    public string RoleId { get; set; }
    public Role Role { get; set; }

    public static GroupRole Create(string roleId, string groupId)
    {
        var groupRole = new GroupRole
        {
            Id = Guid.NewGuid().ToString("N"),
            GroupId = groupId,
            RoleId = roleId
        };

        return groupRole;
    }
}