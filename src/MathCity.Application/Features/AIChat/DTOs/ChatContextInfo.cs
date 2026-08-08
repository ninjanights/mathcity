using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.AIChat.DTOs;

public class ChatContextInfo
{
    public SearchContext Context { get; set; }

    public Guid? SubjectId { get; set; }
    public string? SubjectName { get; set; }

    public Guid? ChapterId { get; set; }
    public string? ChapterName { get; set; }

    public Guid? TopicId { get; set; }
    public string? TopicName { get; set; }

    public Guid? LessonId { get; set; }
    public string? LessonTitle { get; set; }
}