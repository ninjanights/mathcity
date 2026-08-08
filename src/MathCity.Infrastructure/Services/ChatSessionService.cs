using MathCity.Application.Common.Interfaces;
using MathCity.Application.Features.AIChat.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace MathCity.Infrastructure.Services;

public class ChatSessionService : IChatSessionService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICurrentUserService _currentUserService;

    public ChatSessionService(
        ApplicationDbContext context,
        IHttpContextAccessor httpContextAccessor,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _currentUserService = currentUserService;
    }

    public async Task TouchSessionAsync(string sessionId)
    {
        const string cookieName = "mc_session";

        var httpContext = _httpContextAccessor.HttpContext
            ?? throw new InvalidOperationException("HttpContext is unavailable.");

        var session = await _context.ChatSessions
            .FirstOrDefaultAsync(x => x.SessionId == sessionId);

        if (session == null)
            return;

        session.LastAccessedAt = DateTime.UtcNow;
        session.ExpiresAt = DateTime.UtcNow.AddDays(7);

        await _context.SaveChangesAsync();

        // Refresh the browser cookie expiration.
        httpContext.Response.Cookies.Append(
            cookieName,
            sessionId,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true in production
                SameSite = SameSiteMode.Lax,
                Expires = session.ExpiresAt
            });
    }

    public async Task<Guid> GetSessionDatabaseIdAsync(string sessionId)
    {
        var session = await _context.ChatSessions
            .FirstOrDefaultAsync(x => x.SessionId == sessionId);

        if (session != null)
            return session.Id;

        session = new ChatSession
        {
            SessionId = sessionId,
            UserId = _currentUserService.UserId,
            LastAccessedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        _context.ChatSessions.Add(session);
        await _context.SaveChangesAsync();

        return session.Id;
    }
    public async Task<string> GetOrCreateSessionIdAsync()
    {
        const string cookieName = "mc_session";

        var httpContext = _httpContextAccessor.HttpContext
            ?? throw new InvalidOperationException("HttpContext is unavailable.");

        var userId = _currentUserService.UserId;

        // =========================================================
        // LOGGED-IN USER
        // =========================================================
        // If the user is authenticated, their ChatSession is tied
        // to UserId instead of depending on the browser cookie.
        // This means the same user gets the same chat in every browser.
        // =========================================================
        if (userId.HasValue)
        {
            var userSession = await _context.ChatSessions
                .FirstOrDefaultAsync(x => x.UserId == userId.Value);

            if (userSession != null)
            {
                return userSession.SessionId;
            }

            // No session exists for this user yet.
            // Create one and bind it to their UserId.
            var sessionId = Guid.NewGuid().ToString("N");

            var session = new ChatSession
            {
                SessionId = sessionId,
                UserId = userId.Value,
                LastAccessedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            _context.ChatSessions.Add(session);
            await _context.SaveChangesAsync();

            // Also give the browser the session cookie.
            httpContext.Response.Cookies.Append(
                cookieName,
                sessionId,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false, // true in production
                    SameSite = SameSiteMode.Lax,
                    Expires = session.ExpiresAt
                });

            return sessionId;
        }

        // =========================================================
        // ANONYMOUS USER
        // =========================================================
        // No UserId exists, so the browser's session cookie becomes
        // the identity of the chat session.
        // =========================================================

        if (httpContext.Request.Cookies.TryGetValue(
            cookieName,
            out var existingSessionId))
        {
            return existingSessionId;
        }

        // No cookie -> create a new anonymous session ID.
        var anonymousSessionId = Guid.NewGuid().ToString("N");

        httpContext.Response.Cookies.Append(
            cookieName,
            anonymousSessionId,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true in production
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });

        return anonymousSessionId;
    }
}