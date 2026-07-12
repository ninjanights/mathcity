using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/embeddings")]
public class EmbeddingsController : ControllerBase
{
    private readonly ILessonEmbeddingService _embeddingService;

    public  EmbeddingsController(ILessonEmbeddingService embeddingService)
    {
        _embeddingService = embeddingService;
    }



    [HttpPost("generate/{lessonId}")]
    public async Task<IActionResult> Generate(Guid lessonId)
    {
        var result = await _embeddingService.GenerateAsync(lessonId);
        return Ok(result);
    }
}