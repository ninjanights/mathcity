using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.AI.Chat;

public class GeminiResponse
{
    public List<GeminiCandidate> Candidates { get; set; } = [];
    public GeminiUsageMetadata? UsageMetadata { get; set; }
}

public class GeminiCandidate
{
    public GeminiContent Content { get; set; } = new();
    public string FinishReason { get; set; } = string.Empty;
}


public class GeminiUsageMetadata
{
    public int PromptTokenCount { get; set; }

    public int CandidatesTokenCount { get; set; }

    public int TotalTokenCount { get; set; }
}