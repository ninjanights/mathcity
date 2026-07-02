using MathCity.Application.Features.LessonResources.DTOs;
using MathCity.Application.Features.LessonResources.Interfaces;
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

    public LessonResourcesController(
        ILessonResourceService lessonResourceService,
        IFileStorageService fileStorageService)
    {
        _lessonResourceService = lessonResourceService;
        _fileStorageService = fileStorageService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(
    [FromForm] CreateLessonResourceRequest request,
    IFormFile file)
    {
        var upload = await _fileStorageService.UploadAsync(
            file.OpenReadStream(),
            file.FileName,
            file.ContentType,
            "resources");

        var result =
     await _lessonResourceService.CreateAsync(
         request,
         upload);

        return Ok(ApiResponse<object?>.Ok(result));
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
}