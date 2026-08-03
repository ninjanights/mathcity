using MathCity.Application.Features.LessonResources.DTOs;
using MathCity.Application.Features.LessonResources.Interfaces;
using MathCity.Application.Features.Lessons.Interfaces;
using MathCity.Application.Features.Storage.Interfaces;
using MathCity.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonResourcesController : ControllerBase
{
    private readonly ILessonResourceService _lessonResourceService;
    private readonly IFileStorageService _fileStorageService;
    private readonly ILessonService _lessonService;
    public LessonResourcesController(
        ILessonResourceService lessonResourceService,
        IFileStorageService fileStorageService,
        ILessonService lessonService)
    {
        _lessonResourceService = lessonResourceService;
        _fileStorageService = fileStorageService; 
        _lessonService = lessonService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(
    [FromForm] CreateLessonResourceRequest request,
    IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file selected.");
        var lesson = await _lessonService.GetByIdAsync(request.LessonId);

        var upload = await _fileStorageService.UploadDocumentAsync(
     lesson.Slug,
     request.ResourceType,
     file.OpenReadStream(),
     file.ContentType);

        var result =
     await _lessonResourceService.CreateAsync(
         request,
         upload);

        return Ok(ApiResponse<object?>.Ok(result));
    }

    // GET: api/lessonresources
    [HttpGet]
    public async Task<IActionResult> GetAll(
     [FromQuery] LessonResourceQuery query)
    {
        var result = await _lessonResourceService.GetAllAsync(query);

        return Ok(ApiResponse<object?>.Ok(result));
    }

    // GET: api/lessonresources/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _lessonResourceService.GetByIdAsync(id);

        return Ok(ApiResponse<object?>.Ok(result));

    }

    // PUT: api/lessonresources/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
    Guid id,
    [FromForm] UpdateLessonResourceRequest request,
    IFormFile? file)
    {
        var result = await _lessonResourceService.UpdateAsync(id, request);

        return Ok(ApiResponse<object?>.Ok(result));
    }

    // DELETE: api/lessonresources/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _lessonResourceService.DeleteAsync(id);

        return NoContent();
    }
    [HttpPatch("{id:guid}/move")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Move(
        Guid id,
        [FromBody] MoveLessonResourceRequest request)
    {
        await _lessonResourceService.MoveAsync(id, request);

        return NoContent();
    }
}