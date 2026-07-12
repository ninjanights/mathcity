using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/test-embedding")]
public class TestEmbeddingController : ControllerBase
{
    private readonly IEmbeddingGenerator _embeddingGenerator;
    private readonly ILessonEmbeddingService _lessonEmbeddingService;


    public TestEmbeddingController(
        IEmbeddingGenerator embeddingGenerator, ILessonEmbeddingService lessonEmbeddingService)
    {
        _embeddingGenerator = embeddingGenerator;
        _lessonEmbeddingService = lessonEmbeddingService;
    }



    [HttpGet]
    public async Task<IActionResult> Test()
    {
        var vector = await _embeddingGenerator.GenerateAsync(
            "A quadratic equation is an equation of degree two."
        );
        return Ok(new
        {
            Dimension = vector.ToArray().Length,
            FirstValues = vector.ToArray().Take(5)
        });
    }

}