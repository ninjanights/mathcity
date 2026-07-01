using System.Security.Claims;

namespace MathCity.Application.Features.Authentication.Interfaces;

public interface IJwtTokenGenerator
{
    Task<string> GenerateTokenAsync(
        Guid userId,
        string email,
        string fullName,
        IList<string> roles);

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}