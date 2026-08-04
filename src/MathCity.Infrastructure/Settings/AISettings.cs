using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.Settings;

public class AISettings
{
    public const string SectionName = "AI";

    // Jina
    public string JinaBaseUrl { get; set; } = string.Empty;
    public string JinaApiKey { get; set; } = string.Empty;
    public string JinaModel { get; set; } = string.Empty;
    public int Dimension { get; set; }

    // Gemini
    public string GeminiBaseUrl { get; set; } = string.Empty;
    public string GeminiApiKey { get; set; } = string.Empty;
    public string GeminiModel { get; set; } = string.Empty;
}
