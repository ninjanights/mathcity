using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/embeddings")]
public class EmbeddingsController : ControllerBase
{
    private readonly ILessonEmbeddingService _embeddingService;

    public EmbeddingsController(
        ILessonEmbeddingService embeddingService)
    {
        _embeddingService = embeddingService;
    }

    // POST: api/embeddings/generate/{lessonId}
    [HttpPost("generate/{lessonId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Generate(Guid lessonId)
    {
        var result = await _embeddingService.GenerateAsync(lessonId);

        return Ok(result);
    }
}