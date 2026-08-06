namespace MathCity.Application.Features.AIChat.Interfaces;

public interface IChatSessionService
{
    Task<string> GetOrCreateSessionIdAsync();

    Task TouchSessionAsync();

    Task<Guid> GetSessionDatabaseIdAsync(string sessionId);
}