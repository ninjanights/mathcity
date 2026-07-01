using MathCity.Domain.Entities;
using System;

namespace MathCity.Application.Features.Authentication.Interfaces;

public interface IRefreshTokenService
{
    RefreshToken GenerateRefreshToken();

    Task SaveRefreshTokenAsync(
        Guid userId,
        RefreshToken refreshToken);

    Task<RefreshToken?> GetRefreshTokenAsync(string token);

    Task RevokeRefreshTokenAsync(RefreshToken refreshToken);
    Task DeleteExpiredTokensAsync(Guid userId);
}
