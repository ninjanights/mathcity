using System.Security.Cryptography;
using MathCity.Application.Features.Authentication.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Authentication;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ApplicationDbContext _context;

    public RefreshTokenService(ApplicationDbContext context)
    {
        _context = context;
    }

    public RefreshToken GenerateRefreshToken()
    {
        var randomBytes = RandomNumberGenerator.GetBytes(64);

        return new RefreshToken
        {
            Token = Convert.ToBase64String(randomBytes),

            CreatedAt = DateTime.UtcNow,

            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };
    }

    public async Task SaveRefreshTokenAsync(
        Guid userId,
        RefreshToken refreshToken)
    {
        refreshToken.UserId = userId;

        _context.RefreshTokens.Add(refreshToken);

        await _context.SaveChangesAsync();
    }

    public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
    {
        return await _context.RefreshTokens
            .FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task RevokeRefreshTokenAsync(
        RefreshToken refreshToken)

    {
        if (refreshToken.IsRevoked)
            return;

        refreshToken.RevokedAt = DateTime.UtcNow;

        _context.RefreshTokens.Update(refreshToken);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteExpiredTokensAsync(Guid userId)
    {
        var now = DateTime.UtcNow;

        var tokens = await _context.RefreshTokens
            .Where(x =>
                x.UserId == userId &&
                (x.ExpiresAt <= now || x.RevokedAt != null))
            .ToListAsync();

        if (!tokens.Any())
            return;

        _context.RefreshTokens.RemoveRange(tokens);

        await _context.SaveChangesAsync();
    }

    // Revoke all active refresh tokens for a user
    public async Task RevokeAllUserTokensAsync(Guid userId)
    {
        var tokens = await _context.RefreshTokens
            .Where(x => x.UserId == userId && x.IsActive)
            .ToListAsync();

        var now = DateTime.UtcNow;

        foreach (var token in tokens)
        {
            token.RevokedAt = now;
        }

        await _context.SaveChangesAsync();
    }
}