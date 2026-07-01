using MathCity.Application.Features.PracticeQuestions.DTOs;
using MathCity.Application.Features.PracticeQuestions.Interfaces;
using MathCity.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        var result = await _practiceQuestionService.GetByIdAsync(id);

        return Ok(ApiResponse<object?>.Ok(result));
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
}