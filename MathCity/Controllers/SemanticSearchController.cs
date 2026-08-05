using MathCity.Application.Features.LessonVectorEmbeddings.DTOs;
using MathCity.Application.Features.LessonVectorEmbeddings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/search")]
public class SemanticSearchController : ControllerBase
{
    private readonly ILessonEmbeddingService _service;

    public SemanticSearchController(
        ILessonEmbeddingService service)
    {  _service = service; }

    [HttpPost]
    public async Task<IActionResult> Search(
        [FromBody] SemanticSearchRequest request)
    {
        Console.WriteLine($"Received search request: Query='{request.Query}', TopK={request.TopK}, Context={request.Context}, LessonId={request.LessonId}, TopicId={request.TopicId}, ChapterId={request.ChapterId}");
        var result = await _service.SearchAsync(request);
        return Ok(result);
    }



}