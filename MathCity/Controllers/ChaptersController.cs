using MathCity.Application.Features.Chapters.DTOs;
using MathCity.Application.Features.Chapters.Interfaces;
using MathCity.Application.Features.Topics.Interfaces;
using MathCity.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChaptersController : ControllerBase
{
    private readonly IChapterService _chapterService;
    private readonly ITopicService _topicService;

    public ChaptersController(IChapterService chapterService,
         ITopicService topicService)
    {
        _chapterService = chapterService;
        _topicService = topicService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateChapterRequest request)
    {
        var result = await _chapterService.CreateAsync(request);

        return Ok(result);
    }



    [HttpGet]
    public async Task<IActionResult> GetAll(
     [FromQuery] string? search)
    {
        var result = await _chapterService.GetAllAsync(search);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _chapterService.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateChapterRequest request)
    {
        var result = await _chapterService.UpdateAsync(id, request);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _chapterService.DeleteAsync(id);

        return NoContent();
    }

    // GET: api/chapters/{chapterId}/topics
    [HttpGet("{chapterId:guid}/topics")]
    public async Task<IActionResult> GetTopics(Guid chapterId)
    {
        var result = await _topicService.GetByChapterAsync(chapterId);

        return Ok(result);
    }


}