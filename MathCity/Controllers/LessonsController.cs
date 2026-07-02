using MathCity.Application.Features.LessonResources.Interfaces;
using MathCity.Application.Features.Lessons.DTOs;
using MathCity.Application.Features.Lessons.Interfaces;
using MathCity.Application.Features.Lessons.Queries;
using MathCity.Application.Features.LessonTags.DTOs;
using MathCity.Application.Features.LessonTags.Interfaces;
using MathCity.Application.Features.PracticeQuestions.Interfaces;
using MathCity.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MathCity.Shared.Responses;
using System.Security.Claims;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly ILessonService _lessonService;
    private readonly ILessonResourceService _lessonResourceService;
    private readonly IPracticeQuestionService _practiceQuestionService;
    private readonly ILessonTagService _lessonTagService;

    public LessonsController(ILessonService lessonService,
         ILessonResourceService lessonResourceService,
             IPracticeQuestionService practiceQuestionService,
              ILessonTagService lessonTagService)
    {
        _lessonService = lessonService;
        _lessonResourceService = lessonResourceService;
        _practiceQuestionService = practiceQuestionService;
        _lessonTagService = lessonTagService;
    }

    // POST: api/lessons
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateLessonRequest request)
    {
        var result = await _lessonService.CreateAsync(request);

        return Ok(ApiResponse<object?>.Ok(result));
    }

    // GET: api/lessons
    [HttpGet]
    public async Task<IActionResult> GetAll(
    [FromQuery] LessonQuery query)
    {
        var result = await _lessonService.GetAllAsync(query);

        return Ok(result);
    }

    // GET: api/lessons/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Guid? userId = null;

        if (User.Identity?.IsAuthenticated == true)
        {
            userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        var result = await _lessonService.GetByIdAsync(id, userId);

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

        return Ok(ApiResponse<object?>.Ok(result));
    }

    // DELETE: api/lessons/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _lessonService.DeleteAsync(id);

        return NoContent();
    }

    // GET: api/lessons/{lessonId}/resources
    [HttpGet("{lessonId:guid}/resources")]
    public async Task<IActionResult> GetResources(Guid lessonId)
    {
        var result = await _lessonResourceService.GetByLessonAsync(lessonId);

        return Ok(result);
    }

    // GET: api/lessons/{lessonId}/practicequestions
    [HttpGet("{lessonId:guid}/practicequestions")]
    public async Task<IActionResult> GetPracticeQuestions(Guid lessonId)
    {
        // If the user is authenticated and in the Admin role, return full question DTOs
        if (User.Identity?.IsAuthenticated == true && User.IsInRole("Admin"))
        {
            var result = await _practiceQuestionService.GetByLessonAsync(lessonId);
            return Ok(result);
        }

        // For students (unauthenticated or non-admin), return student-facing DTOs
        var studentResult = await _practiceQuestionService.GetByLessonForStudentAsync(lessonId);
        return Ok(studentResult);
    }

    // POST: api/lessons/{lessonId}/tags
    [HttpPost("{lessonId:guid}/tags")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddTag(
    Guid lessonId,
    CreateLessonTagRequest request)
    {
        var result = await _lessonTagService.CreateAsync(
            lessonId,
            request);

        return Ok(result);
    }

    // GET: api/lessons/{lessonId}/tags
    [HttpGet("{lessonId:guid}/tags")]
    public async Task<IActionResult> GetTags(Guid lessonId)
    {
        var result = await _lessonTagService.GetByLessonAsync(
            lessonId);

        return Ok(result);
    }


    // DELETE: api/lessons/{lessonId}/tags/{tagId}
    [HttpDelete("{lessonId:guid}/tags/{tagId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveTag(
    Guid lessonId,
    Guid tagId)
    {
        await _lessonTagService.DeleteAsync(
            lessonId,
            tagId);

        return NoContent();
    }

}