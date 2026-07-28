using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.AI.Embeddings;

public class JinaEmbeddingResponse
{
    public List<JinaEmbeddingData> Data { get; set; } = [];
}


public class JinaEmbeddingData
{
    public float[] Embedding { get; set; } = [];
}