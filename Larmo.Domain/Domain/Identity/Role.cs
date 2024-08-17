using Microsoft.AspNetCore.Identity;

namespace Larmo.Domain.Domain.Identity;

public class Role : IdentityRole<string>
{
    private Role()
    {
    }

    public static Role Create(string name)
    {
        var role = new Role
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = name
        };

        return role;
    }
}