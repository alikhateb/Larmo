using Microsoft.AspNetCore.Identity;

namespace Larmo.Domain.Domain.Identity;

public class User : IdentityUser<string>
{
    private readonly List<UserRole> _userRoles = [];
    private readonly List<UserPermission> _userPermissions = [];

    private User()
    {
    }

    public RefreshToken RefreshToken { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public IReadOnlyCollection<UserRole> UserRoles => _userRoles;
    public IReadOnlyCollection<UserPermission> UserPermissions => _userPermissions;

    public static User Create(string email, string userName, string phoneNumber)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString("N"),
            PhoneNumber = phoneNumber,
            Email = email,
            NormalizedEmail = email.ToUpper(),
            UserName = userName,
            CreatedOn = DateTime.UtcNow
        };

        return user;
    }

    public void SetRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken = refreshToken;
    }

    public void AddToRole(Role role)
    {
        var userRole = UserRole.Create(Id, role.Id);
        _userRoles.Add(userRole);
    }

    public void AddToPermission(Permission permission)
    {
        var userPermission = UserPermission.Create(Id, Id);
        _userPermissions.Add(userPermission);
    }
}