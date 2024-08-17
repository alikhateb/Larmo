using Microsoft.AspNetCore.Identity;

namespace Larmo.Domain.Domain.Identity;

public class UserRole : IdentityUserRole<string>
{
    private UserRole()
    {
    }

    public string Id { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }

    public static UserRole Create(string userId, string roleId)
    {
        var userRole = new UserRole
        {
            Id = Guid.NewGuid().ToString("N"),
            UserId = userId,
            RoleId = roleId
        };

        return userRole;
    }
}