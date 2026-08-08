using MathCity.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MathCity.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool IsAuthenticated =>
        _httpContextAccessor.HttpContext?
            .User?
            .Identity?
            .IsAuthenticated ?? false;

    public Guid? UserId
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?
    .User?
    .FindFirstValue(ClaimTypes.NameIdentifier)
    ?? _httpContextAccessor.HttpContext?
    .User?
    .FindFirstValue(JwtRegisteredClaimNames.Sub);

            return Guid.TryParse(value, out var userId)
                ? userId
                : null;
        }
    }
}