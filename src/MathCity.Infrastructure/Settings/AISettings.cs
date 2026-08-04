using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.Settings;

public class AISettings
{
    public const string SectionName = "AI";

    public string BaseUrl { get; set; }
        = "https://api.jina.ai";

    public string ApiKey { get; set; } = "";

    public string Model { get; set; }
        = "jina-embeddings-v3";

    public int Dimension { get; set; }
        = 1024;

    public string ChatModel { get; set; } = "gemini-2.5-flash-lite";
}