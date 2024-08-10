using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Larmo.Core.Repository;
using Larmo.Core.Services;
using Larmo.Domain.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Larmo.Core.Application.Users.Create;

internal sealed class CreateUserCommandHandler(
    IIdentityRepository<User> identityRepository,
    ITokenService tokenService,
    UserManager<User> userManager)
    : IRequestHandler<CreateUserCommand, AccessTokenResult>
{
    public async Task<AccessTokenResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var emailSpecification = new UserSpecification().ByEmail(request.Email.ToUpper());
        var isEmailExist = await identityRepository.AnyAsync(emailSpecification, cancellationToken);
        if (isEmailExist)
            throw new NullReferenceException(message: "email already exists");

        var phoneNumberSpecification = new UserSpecification().ByPhoneNumber(request.PhoneNumber);
        var isPhoneNumberExist = await identityRepository.AnyAsync(phoneNumberSpecification, cancellationToken);
        if (isPhoneNumberExist)
            throw new NullReferenceException(message: "phone number already exists");

        var user = User.Create(email: request.Email, userName: request.Username, phoneNumber: request.PhoneNumber);
        var identityResult = await userManager.CreateAsync(user, request.Password);
        if (!identityResult.Succeeded)
        {
            var errorMessages = new List<string>();
            foreach (var error in identityResult.Errors)
            {
                errorMessages.Add(error.Description);
            }

            var errorMessage = string.Join("\n", errorMessages);
            throw new Exception(message: errorMessage);
        }

        var claim = GenerateClaims(user.Id, user.Email, user.UserName, []);
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