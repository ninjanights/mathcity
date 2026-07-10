
using Pgvector;

namespace MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;

public interface IEmbeddingGenerator
{
   
    Task<Vector> GenerateAsync(
        string text,
        CancellationToken cancellationToken = default);
}