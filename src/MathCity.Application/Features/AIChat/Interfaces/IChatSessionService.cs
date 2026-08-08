namespace MathCity.Application.Features.AIChat.Interfaces;

public interface IChatSessionService
{
    Task<string> GetOrCreateSessionIdAsync();

    Task TouchSessionAsync(string sessionId);

    Task<Guid> GetSessionDatabaseIdAsync(string sessionId);
}