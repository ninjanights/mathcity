using MathCity.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Domain.Entities;

public class ChatMessageSource : BaseEntity
{
    public Guid ChatMessageId { get; set; }

    public ChatMessage ChatMessage { get; set; } = null!;

    public Guid LessonVectorEmbeddingId { get; set; }

    public LessonVectorEmbedding LessonVectorEmbedding { get; set; } = null!;

    public double Score { get; set; }
}