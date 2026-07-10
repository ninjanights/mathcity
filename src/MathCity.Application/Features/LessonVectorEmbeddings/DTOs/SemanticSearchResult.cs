using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.LessonVectorEmbeddings.DTOs;


public class SemanticSearchResult
{
    public Guid LessonId { get; set; }

    public Guid? SourceId { get; set; }

    public string LessonTitle { get; set; } = string.Empty;

    public string ChunkTitle { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public EmbeddingChunkType ChunkType { get; set; }

    public int ChunkIndex { get; set; }

    public double Score { get; set; }
}