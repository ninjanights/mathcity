using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using MathCity.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCity.Infrastructure.AI.Search;
public class LessonEmbeddingService : ILessonEmbeddingService
{

    private readonly ApplicationDbContext _context;
    private readonly IEmbeddingGenerator _embeddingGenerator;


    public LessonEmbeddingService(
        ApplicationDbContext context,
        IEmbeddingGenerator embeddingGenerator)
    {
        _context = context;
        _embeddingGenerator = embeddingGenerator;
    }

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