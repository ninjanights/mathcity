using MathCity.Application.Features.PracticeQuestions.DTOs;
using MathCity.Application.Features.PracticeQuestions.Interfaces;
using MathCity.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PracticeQuestionsController : ControllerBase
{
    private readonly IPracticeQuestionService _practiceQuestionService;

    public PracticeQuestionsController(
        IPracticeQuestionService practiceQuestionService)
    {
        _practiceQuestionService = practiceQuestionService;
    }

    // POST: api/practicequestions
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreatePracticeQuestionRequest request)
    {
        var result = await _practiceQuestionService.CreateAsync(request);

        return Ok(ApiResponse<object?>.Ok(result));
    }

    // GET: api/practicequestions
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _practiceQuestionService.GetAllAsync();

        return Ok(ApiResponse<object?>.Ok(result));
    }

    // GET: api/practicequestions/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        // If admin, return full response including correct answer & explanation
        if (User.Identity?.IsAuthenticated == true && User.IsInRole("Admin"))
        {
            var result = await _practiceQuestionService.GetByIdAsync(id);
            return Ok(ApiResponse<PracticeQuestionResponse>.Ok(result));
        }

        // Student or anonymous: hide correct answer & explanation
        var studentResult = await _practiceQuestionService.GetByIdForStudentAsync(id);
        return Ok(ApiResponse<StudentPracticeQuestionResponse>.Ok(studentResult));
    }

    // PUT: api/practicequestions/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdatePracticeQuestionRequest request)
    {
        var result = await _practiceQuestionService.UpdateAsync(id, request);

        return Ok(ApiResponse<object?>.Ok(result));
    }

    // DELETE: api/practicequestions/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _practiceQuestionService.DeleteAsync(id);

        return NoContent();
    }

    // POST: api/practicequestions/submit
    [HttpPost("submit")]
    public async Task<IActionResult> Submit(
        SubmitPracticeQuestionsRequest request)
    {
        Guid? userId = null;

        if (User.Identity?.IsAuthenticated == true)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(userIdClaim))
            {
                userId = Guid.Parse(userIdClaim);
            }
        }

        var result = await _practiceQuestionService.SubmitAsync(
            userId,
            request);

        return Ok(ApiResponse<PracticeQuestionSubmissionResponse>.Ok(result));
    }

    // GET: api/practicequestions/lesson/{lessonId}
    [HttpGet("lesson/{lessonId:guid}")]
    public async Task<IActionResult> GetByLesson(Guid lessonId)
    {
        // If admin, return full list response
        if (User.Identity?.IsAuthenticated == true && User.IsInRole("Admin"))
        {
            var result = await _practiceQuestionService.GetByLessonAsync(lessonId);
            return Ok(ApiResponse<object?>.Ok(result));
        }

        // Student / anonymous: return student-facing DTOs
        var studentResult = await _practiceQuestionService.GetByLessonForStudentAsync(lessonId);
        return Ok(ApiResponse<object?>.Ok(studentResult));
    }


}

