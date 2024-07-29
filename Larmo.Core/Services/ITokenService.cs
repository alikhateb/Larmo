namespace Larmo.Core.Services;

public interface ITokenService
{
    Task<TokenResult> GenerateToken(TokenResult model);
    Task<TokenResult> RefreshToken(TokenResult model);
}