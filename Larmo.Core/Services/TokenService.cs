//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;

//namespace Larmo.Core.Services;

//public class TokenService : ITokenService
//{
//    public Task<TokenResult> GenerateToken(TokenResult model)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<TokenResult> RefreshToken(TokenResult model)
//    {
//        throw new NotImplementedException();
//    }

//    private JwtSecurityToken CreateToken(List<Claim> authClaims)
//    {
//        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
//        _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int TokenValidityInHours);
//        var token = new JwtSecurityToken(
//                    issuer: _configuration["JWT:ValidIssuer"],
//                    audience: _configuration["JWT:ValidAudience"],
//                    expires: DateTime.Now.AddMinutes(TokenValidityInHours),
//                    claims: authClaims,
//                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
//            );
//        return token;
//    }
//    private static string GenerateRefreshToken()
//    {
//        var randomNumber = new byte[64];
//        using var rng = RandomNumberGenerator.Create();
//        rng.GetBytes(randomNumber);
//        return Convert.ToBase64String(randomNumber);
//    }

//    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
//    {
//        var tokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateAudience = false,
//            ValidateIssuer = false,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
//            ValidateLifetime = false
//        };
//        var tokenHandler = new JwtSecurityTokenHandler();
//        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
//        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
//            throw new SecurityTokenException("Invalid token");
//        return principal;
//    }
//}