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

    public SubjectsController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateSubjectRequest request)
    {
        var subject = await _subjectService.CreateAsync(request);

        return Ok(subject);
    }

    // get all subjects
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subjects = await _subjectService.GetAllAsync();

        return Ok(subjects);
    }

    // get by id
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var subject = await _subjectService.GetByIdAsync(id);

        return Ok(subject);
    }

    // update subject
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
    Guid id,
    UpdateSubjectRequest request)
    {
        var subject = await _subjectService.UpdateAsync(id, request);

        return Ok(subject);
    }

    // delete subject
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _subjectService.DeleteAsync(id);

        return NoContent();
    }
}