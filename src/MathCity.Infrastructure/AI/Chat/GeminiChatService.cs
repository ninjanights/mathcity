using MathCity.Application.Features.AIChat.Interfaces;
using MathCity.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace MathCity.Infrastructure.AI.Chat;

public class GeminiChatService : IAIChatService
{
    private readonly HttpClient _httpClient;
    private readonly AISettings _settings;

    public GeminiChatService(
        HttpClient httpClient,
        IOptions<AISettings> options)
    {
        _httpClient = httpClient;
        _settings = options.Value;
    }

    public async Task<string> GenerateAnswerAsync(
        string question,
        string context,
        CancellationToken cancellationToken = default)
    {
        var prompt = BuildPrompt(question, context);

        var request = new GeminiRequest
        {
            Contents =
            [
                new GeminiContent
                {
                    Parts =
                    [
                        new GeminiPart
                        {
                            Text = prompt
                        }
                    ]
                }
            ]
        };

        var response = await _httpClient.PostAsJsonAsync(
    $"v1beta/models/{_settings.GeminiModel}:generateContent?key={_settings.GeminiApiKey}",
    request,
    cancellationToken);

        response.EnsureSuccessStatusCode();

        var result =
            await response.Content.ReadFromJsonAsync<GeminiResponse>(
                cancellationToken: cancellationToken);

        var answer = result?
            .Candidates?
            .FirstOrDefault()?
            .Content?
            .Parts?
            .FirstOrDefault()?
            .Text;

        if (string.IsNullOrWhiteSpace(answer))
            throw new Exception("Gemini returned an empty response.");

        return answer;
    }

    private static string BuildPrompt(
        string question,
        string context)
    {
        return
$"""
You are MathCity AI, an educational assistant.

Answer ONLY using the provided context.

If the answer cannot be found in the context, say:

"I couldn't find that information in the available lesson content."

-----------------------
Context

{context}

-----------------------
Question

{question}
""";
    }
}