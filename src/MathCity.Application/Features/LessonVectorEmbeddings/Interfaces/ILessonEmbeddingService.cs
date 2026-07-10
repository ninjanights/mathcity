using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;

public interface ILessonEmbeddingService
{
    Task<LessonEmbeddingResponse> GenerateAsync(
        Guid lessonId);

    Task<IReadOnlyList<SemanticSearchResult>> SearchAsync(
        SemanticSearchRequest request);
}