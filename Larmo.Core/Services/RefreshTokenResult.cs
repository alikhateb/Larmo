namespace Larmo.Core.Services;

public class RefreshTokenResult
{
    public Guid UserId { get; set; }
    public string RefreshToken { get; set; }
}