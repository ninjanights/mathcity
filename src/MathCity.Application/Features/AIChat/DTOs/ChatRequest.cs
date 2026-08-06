using MathCity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.AIChat.DTOs;

public class ChatRequest
{
    public string Question { get; set; } = string.Empty;

    public SearchContext Context { get; set; } = SearchContext.Global;

    public Guid? LessonId { get; set; }

    public Guid? TopicId { get; set; }

    public Guid? ChapterId { get; set; }

    public int TopK { get; set; } = 5;
}