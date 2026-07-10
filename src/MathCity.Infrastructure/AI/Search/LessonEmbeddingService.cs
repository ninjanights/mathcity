using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.AI.Search;
public class LessonEmbeddingService : ILessonEmbeddingService
{
    public async Task<LessonEmbeddingResponse> GenerateAsync(Guid lessonId)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<SemanticSearchResult>> SearchAsync(
        SemanticSearchRequest request)
    {
        throw new NotImplementedException();
    }
}