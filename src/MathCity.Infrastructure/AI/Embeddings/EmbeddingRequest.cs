using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.AI.Embeddings;

public class EmbeddingRequest
{
    public string Model { get; set; } = string.Empty;

    public string Prompt { get; set; } = string.Empty;
}