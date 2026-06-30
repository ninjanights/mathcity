using MathCity.Application.Features.LessonResources.DTOs;
using MathCity.Application.Features.LessonResources.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonResourcesController : ControllerBase
{
    private readonly ILessonResourceService _lessonResourceService;

    public LessonResourcesController(
        ILessonResourceService lessonResourceService)
    {
        _lessonResourceService = lessonResourceService;
    }

    // POST: api/lessonresources
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateLessonResourceRequest request)
    {
        var result = await _lessonResourceService.CreateAsync(request);

        return Ok(result);
    }

    // GET: api/lessonresources
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _lessonResourceService.GetAllAsync();

        return Ok(result);
    }

    // GET: api/lessonresources/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _lessonResourceService.GetByIdAsync(id);

        return Ok(result);
    }

    // PUT: api/lessonresources/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateLessonResourceRequest request)
    {
        var result = await _lessonResourceService.UpdateAsync(id, request);

        return Ok(result);
    }

    // DELETE: api/lessonresources/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _lessonResourceService.DeleteAsync(id);

        return NoContent();
    }
}