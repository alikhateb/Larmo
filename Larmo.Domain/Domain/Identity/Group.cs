namespace Larmo.Domain.Domain.Identity;

public class Group
{
    private readonly List<UserGroup> _userGroups = [];
    private readonly List<GroupRole> _groupRoles = [];

    private Group()
    {
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public IReadOnlyCollection<UserGroup> UserGroups => _userGroups;
    public IReadOnlyCollection<GroupRole> GroupRoles => _groupRoles;

    public static Group Create(string name)
    {
        var group = new Group
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = name
        };

        return group;
    }

    public void AddUserGroup(UserGroup userGroup)
    {
        _userGroups.Add(userGroup);
    }

    public void AddGroupRole(GroupRole groupRole)
    {
        _groupRoles.Add(groupRole);
    }
}