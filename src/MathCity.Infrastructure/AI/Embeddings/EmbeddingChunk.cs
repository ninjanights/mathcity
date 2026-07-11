using MathCity.Domain.Enums;

namespace MathCity.Infrastructure.AI.Embeddings;

public class EmbeddingChunk
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public EmbeddingChunkType Type { get; set; }

    public Guid? SourceId { get; set; }
}