using MathCity.Application.Features.Lessons.DTOs;
using MathCity.Application.Features.Lessons.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    // POST: api/lessons
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateLessonRequest request)
    {
        var result = await _lessonService.CreateAsync(request);

        return Ok(result);
    }

    // GET: api/lessons
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _lessonService.GetAllAsync();

        return Ok(result);
    }

    // GET: api/lessons/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _lessonService.GetByIdAsync(id);

        return Ok(result);
    }

    // PUT: api/lessons/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateLessonRequest request)
    {
        var result = await _lessonService.UpdateAsync(id, request);

        return Ok(result);
    }

    // DELETE: api/lessons/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _lessonService.DeleteAsync(id);

        return NoContent();
    }
}