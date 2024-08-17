namespace Larmo.Domain.Domain.Identity;

public class UserPermission
{
    private UserPermission()
    {
    }

    public string Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public string PermissionId { get; set; }
    public Permission Permission { get; set; }

    public static UserPermission Create(string userId, string permissionId)
    {
        var userPermission = new UserPermission
        {
            Id = Guid.NewGuid().ToString("N"),
            UserId = userId,
            PermissionId = permissionId
        };

        return userPermission;
    }
}