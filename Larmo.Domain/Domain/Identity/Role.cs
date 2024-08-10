namespace Larmo.Domain.Domain.Identity;

public class Role
{
    private readonly List<GroupRole> _groupRoles = [];

    private Role()
    {
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string DependOn { get; set; }
    public string ModuleName { get; set; }
    public IReadOnlyCollection<GroupRole> GroupRoles => _groupRoles;

    public static Role Create(string name, string moduleName, string dependOn)
    {
        var role = new Role
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = name,
            ModuleName = moduleName,
            DependOn = dependOn
        };

        return role;
    }

    public void AddGroupRole(GroupRole groupRole)
    {
        _groupRoles.Add(groupRole);
    }
}