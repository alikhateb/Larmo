namespace Larmo.Domain.Domain.Identity;

public class Permission
{
    private Permission()
    {
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string DependOn { get; set; }
    public string ModuleName { get; set; }
    public Permission Parent { get; set; }

    public static Permission Create(string id, string name, string moduleName, string dependOn)
    {
        var permission = new Permission
        {
            Id = id,
            Name = name,
            ModuleName = moduleName,
            DependOn = dependOn
        };

        return permission;
    }
}