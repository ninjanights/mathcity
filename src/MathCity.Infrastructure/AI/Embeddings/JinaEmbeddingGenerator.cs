using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using MathCity.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Pgvector;
using System.Net.Http.Json;

namespace MathCity.Infrastructure.AI.Embeddings;

public class JinaEmbeddingGenerator : IEmbeddingGenerator
{
    private readonly HttpClient _httpClient;
    private readonly AISettings _settings;


    public JinaEmbeddingGenerator(
        HttpClient httpClient,
        IOptions<AISettings> options)
    {
        _httpClient = httpClient;
        _settings = options.Value;
    }



    public async Task<Vector> GenerateAsync(
        string text,
        CancellationToken cancellationToken = default)
    {
        var request = new
        {
            model = _settings.Model,
            input = new[]
        {
            text
        }
        };


        _httpClient.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Bearer",
            _settings.ApiKey
        );


        var response = await _httpClient.PostAsJsonAsync(
            "https://api.jina.ai/v1/embeddings",
            request,
            cancellationToken
        );


        response.EnsureSuccessStatusCode();


        var result =
            await response.Content
                .ReadFromJsonAsync<JinaEmbeddingResponse>(
                    cancellationToken: cancellationToken
                );


        if (result?.Data == null || result.Data.Count == 0)
            throw new Exception(
                "Jina embedding generation failed"
            );


        return new Vector(
            result.Data[0].Embedding
        );
    }




}