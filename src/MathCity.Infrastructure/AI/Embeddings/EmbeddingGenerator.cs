using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using MathCity.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Pgvector;



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
        throw new NotImplementedException();
    }
}