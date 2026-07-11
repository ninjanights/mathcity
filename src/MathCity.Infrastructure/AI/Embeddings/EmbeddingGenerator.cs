using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using MathCity.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Pgvector;
using System.Net.Http.Json;

namespace MathCity.Infrastructure.AI.Embeddings;

public class EmbeddingGenerator : IEmbeddingGenerator
{
    private readonly HttpClient _httpClient;
    private readonly AISettings _settings;


    public EmbeddingGenerator(
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

        var request = new EmbeddingRequest
        {
            Model = _settings.Model,
            Prompt = text
        };


        var response = await _httpClient.PostAsJsonAsync(
            "/api/embeddings",
            request,
            cancellationToken
        );


        response.EnsureSuccessStatusCode();


        var result =
            await response.Content
                .ReadFromJsonAsync<EmbeddingResponse>(
                    cancellationToken: cancellationToken
                );


        if (result?.Embedding == null)
            throw new Exception(
                "Embedding generation failed"
            );


        return new Vector(result.Embedding);
    }




}