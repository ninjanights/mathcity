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
        SemanticSearchRequest request)
    {
        var result = await _service.SearchAsync(request);

        return Ok(result);
   
    }
    



}