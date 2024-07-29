namespace Larmo.Core.Services;

public class TokenResult
{
    public string? AccessToken { get; set; }
    public RefreshTokenResult RefreshToken { get; set; }
}