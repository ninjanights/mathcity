using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.AI.Chat;

public class GeminiRequest
{
    public List<GeminiContent> Contents { get; set; } = [];
}

public class GeminiContent
{
    public List<GeminiPart> Parts { get; set; } = [];
}

public class GeminiPart
{
    public string Text { get; set; } = string.Empty;
}