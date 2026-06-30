using MathCity.Application.Features.Chapters.Interfaces;
using MathCity.Application.Features.Subjects.DTOs;
using MathCity.Application.Features.Subjects.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectsController : ControllerBase
{
    private readonly ISubjectService _subjectService;
    private readonly IChapterService _chapterService;

    public SubjectsController(
        ISubjectService subjectService,
        IChapterService chapterService)
    {
        _subjectService = subjectService;
        _chapterService = chapterService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateSubjectRequest request)
    {
        var subject = await _subjectService.CreateAsync(request);

        return Ok(subject);
    }

    // GET: /api/subjects/{subjectId}/chapters
    [HttpGet("{subjectId:guid}/chapters")]
    public async Task<IActionResult> GetChapters(Guid subjectId)
    {
        var result = await _chapterService.GetBySubjectAsync(subjectId);

        return Ok(result);
    }

    // GET: /api/subjects
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subjects = await _subjectService.GetAllAsync();

        return Ok(subjects);
    }

    // GET: /api/subjects/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var subject = await _subjectService.GetByIdAsync(id);

        return Ok(subject);
    }

    // PUT: /api/subjects/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateSubjectRequest request)
    {
        var subject = await _subjectService.UpdateAsync(id, request);

        return Ok(subject);
    }

    // DELETE: /api/subjects/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _subjectService.DeleteAsync(id);

        return NoContent();
    }
}