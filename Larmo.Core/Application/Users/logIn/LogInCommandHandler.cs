using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Larmo.Core.Repository;
using Larmo.Core.Services;
using Larmo.Domain.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Larmo.Core.Application.Users.logIn;

internal sealed class LogInCommandHandler(
    IIdentityRepository<User> identityRepository,
    ITokenService tokenService,
    UserManager<User> userManager)
    : IRequestHandler<LogInCommand, AccessTokenResult>
{
    public async Task<AccessTokenResult> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        var emailSpecification = new UserSpecification().WithGroupsAndRoles(request.Email.ToUpper());
        var user = await identityRepository.FirstOrDefaultAsync(emailSpecification, cancellationToken);
        if (user is null)
            throw new NullReferenceException(message: "user not found");

        var isValidPassword = await userManager.CheckPasswordAsync(user, request.Password);
        if (!isValidPassword)
            throw new InvalidOperationException(message: "invalid password");

        var roles = user.UserGroups.Select(x => x.Group)
            .SelectMany(g => g.GroupRoles)
            .Select(r => r.Role)
            .ToArray();

        var claim = GenerateClaims(user.Id, user.Email, user.UserName, roles);
        var token = tokenService.GenerateToken(user.Id, claim);
        return token;
    }

    private static Claim[] GenerateClaims(string userId, string email, string username, Role[] roles) =>
    [
        new Claim(JwtRegisteredClaimNames.Sid, userId),
        new Claim(JwtRegisteredClaimNames.Email, email),
        new Claim(JwtRegisteredClaimNames.Name, username),
        new Claim("roles", JsonSerializer.Serialize(roles, JsonSerializerOptions.Default))
    ];
}