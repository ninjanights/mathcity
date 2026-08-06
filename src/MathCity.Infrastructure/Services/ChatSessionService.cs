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

    public ChatSessionService(
        ApplicationDbContext context,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> GetOrCreateSessionIdAsync()
    {
        const string cookieName = "mc_session";

        var httpContext = _httpContextAccessor.HttpContext
          ?? throw new InvalidOperationException("HttpContext is unavailable.");

        // Cookie already exists
        if (httpContext.Request.Cookies.TryGetValue(cookieName, out var sessionId))
        {
            return sessionId;
        }
        // Else : Create new session id
        sessionId = Guid.NewGuid().ToString("N");

        httpContext.Response.Cookies.Append(
            cookieName,
            sessionId,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true in production
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });

        return sessionId;
    }


    public async Task TouchSessionAsync()
    {
       const string cookieName = "mc_session";
        var httpContext = _httpContextAccessor.HttpContext
      ?? throw new InvalidOperationException("HttpContext is unavailable.");

        if (!httpContext.Request.Cookies.TryGetValue(cookieName, out var sessionId))
            return;

        var session = await _context.ChatSessions
      .FirstOrDefaultAsync(x => x.SessionId == sessionId);

        if (session == null)
            return;
        session.LastAccessedAt = DateTime.UtcNow;
        session.ExpiresAt = DateTime.UtcNow.AddDays(7);

        await _context.SaveChangesAsync();

        httpContext.Response.Cookies.Append(
            cookieName,
            sessionId,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true in production
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
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
            LastAccessedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        _context.ChatSessions.Add(session);
        await _context.SaveChangesAsync();

        return session.Id;

    }

}