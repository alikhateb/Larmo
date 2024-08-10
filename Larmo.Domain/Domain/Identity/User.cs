using Microsoft.AspNetCore.Identity;

namespace Larmo.Domain.Domain.Identity;

public class User : IdentityUser<string>
{
    private readonly List<UserGroup> _userGroups = [];

    private User()
    {
    }

    public RefreshToken RefreshToken { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public IReadOnlyCollection<UserGroup> UserGroups => _userGroups;

    public static User Create(string email, string userName, string phoneNumber)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString("N"),
            PhoneNumber = phoneNumber,
            Email = email,
            UserName = userName,
            CreatedOn = DateTime.UtcNow
        };

        return user;
    }

    public void AddUserGroup(UserGroup userGroup)
    {
        _userGroups.Add(userGroup);
    }

    public void SetRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken = refreshToken;
    }
}