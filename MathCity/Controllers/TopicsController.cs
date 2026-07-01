using MathCity.Application.Features.Lessons.Interfaces;
using MathCity.Application.Features.Topics.DTOs;
using MathCity.Application.Features.Topics.Interfaces;
using MathCity.Infrastructure.Services;
using MathCity.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopicsController : ControllerBase
{
    private readonly ITopicService _topicService;
    private readonly ILessonService _lessonService;

    public TopicsController(ITopicService topicService,
         ILessonService lessonService)

    {
        _topicService = topicService;
        _lessonService = lessonService;
    }

    // POST: api/topics
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateTopicRequest request)
    {
        var topic = await _topicService.CreateAsync(request);

        return Ok(ApiResponse<object?>.Ok(topic));
    }

    // GET: api/topics
    [HttpGet]
    public async Task<IActionResult> GetAll(
    [FromQuery] string? search)
    {
        var result = await _topicService.GetAllAsync(search);

        return Ok(result);
    }

    // GET: api/topics/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var topic = await _topicService.GetByIdAsync(id);

        return Ok(topic);
    }

    // PUT: api/topics/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateTopicRequest request)
    {
        var topic = await _topicService.UpdateAsync(id, request);

        return Ok(topic);
    }

    // DELETE: api/topics/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _topicService.DeleteAsync(id);

        return NoContent();
    }

    // GET: api/topics/{topicId}/lessons
    [HttpGet("{topicId:guid}/lessons")]
    public async Task<IActionResult> GetLessons(Guid topicId)
    {
        var result = await _lessonService.GetByTopicAsync(topicId);

        return Ok(ApiResponse<object?>.Ok(result));
    }
}