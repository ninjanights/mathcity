using MathCity.Domain.Common;
using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pgvector;

namespace MathCity.Domain.Entities;

public class LessonVectorEmbedding : BaseEntity
{
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;


    public Guid SubjectId { get; set; }
    public Guid ChapterId { get; set; }
    public Guid TopicId { get; set; }

    public string SubjectName { get; set; } = "";
    public string ChapterName { get; set; } = "";
    public string TopicName { get; set; } = "";


    public string LessonTitle { get; set; } = "";
    public Guid? SourceId { get; set; }
    public EmbeddingChunkType ChunkType { get; set; }
    public int ChunkIndex { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Dimensions { get; set; }
    public string[] Tags { get; set; } = Array.Empty<string>();
    public Vector Embedding { get; set; } = null!;
    public int TokenCount { get; set; }
}
