using MathCity.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCity.Domain.Enums;

namespace MathCity.Domain.Entities;

public class ChatMessage : BaseEntity
{
    public Guid ChatSessionId { get; set; }

    public ChatSession ChatSession { get; set; } = null!;

    public ChatRole Role { get; set; }

    public string Message { get; set; } = string.Empty;

    public SearchContext Context { get; set; }

    public Guid? SubjectId { get; set; }

    public Guid? ChapterId { get; set; }

    public Guid? TopicId { get; set; }

    public Guid? LessonId { get; set; }

    // OPTIONAL (recommended)
    public ICollection<ChatMessageSource> Sources { get; set; }
        = new List<ChatMessageSource>();
}