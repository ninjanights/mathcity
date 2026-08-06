using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.AIChat.DTOs;

public class ChatResponse
{
    public string Answer { get; set; } = string.Empty;

    public string SessionId { get; set; } = string.Empty;
    public IReadOnlyList<SemanticSearchResult> Sources { get; set; }
      = Array.Empty<SemanticSearchResult>();
}