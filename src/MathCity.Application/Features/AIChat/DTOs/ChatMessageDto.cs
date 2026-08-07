using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.AIChat.DTOs;

public class ChatMessageDto
{
    public Guid Id { get; set; }

    public ChatRole Role { get; set; }

    public string Message { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public SearchContext Context { get; set; }

    public Guid? SubjectId { get; set; }

    public Guid? ChapterId { get; set; }

    public Guid? TopicId { get; set; }

    public Guid? LessonId { get; set; }
}