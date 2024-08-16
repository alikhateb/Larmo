using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Larmo.Core.Services;

public class TokenService(IOptions<TokenConfiguration> options)
    : ITokenService
{
    private readonly TokenConfiguration _tokenConfiguration = options.Value;

    public AccessTokenResult GenerateToken(string userId, Claim[] claims)
    {
        var accessToken = CreateToken(claims);
        var refreshToken = GenerateRefreshToken();

        var result = new AccessTokenResult
        {
            AccessToken = accessToken,
            ExpireOn = DateTime.UtcNow.AddMinutes(_tokenConfiguration.AccessTokenLifeTimeInMinutes),
            RefreshToken = new RefreshTokenResult
            {
                UserId = userId,
                RefreshToken = refreshToken,
                ExpireOn = DateTime.UtcNow.AddMinutes(_tokenConfiguration.RefreshTokenLifeTimeInMinutes)
            }
        };

        return result;
    }

    public AccessTokenResult RefreshToken(AccessTokenResult model)
    {
        throw new NotImplementedException();
    }

    private string CreateToken(Claim[] claims)
    {
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
        var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _tokenConfiguration.ValidIssuer,
            audience: _tokenConfiguration.ValidAudience,
            expires: DateTime.UtcNow.AddMinutes(_tokenConfiguration.AccessTokenLifeTimeInMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = symmetricKey,
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }
}