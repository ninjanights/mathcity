using System.Security.Claims;
using MathCity.Application.Features.Progress.DTOs;
using MathCity.Application.Features.Progress.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProgressController : ControllerBase
{
    private readonly IProgressService _progressService;

    public ProgressController(IProgressService progressService)
    {
        _progressService = progressService;
    }

    // POST: api/progress
    [HttpPost]
    public async Task<IActionResult> Create(CreateProgressRequest request)
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var result = await _progressService.CreateAsync(userId, request);

        return Ok(result);
    }

    // GET: api/progress
    [HttpGet]
    public async Task<IActionResult> GetMyProgress()
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var result = await _progressService.GetByUserAsync(userId);

        return Ok(result);
    }

    // GET: api/progress/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userId = Guid.Parse(
    User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var result = await _progressService.GetByIdAsync(userId, id);

        return Ok(result);
    }

    // PUT: api/progress/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateProgressRequest request)
    {
        var userId = Guid.Parse(
    User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var result = await _progressService.UpdateAsync(
            userId,
            id,
            request);

        return Ok(result);
    }

    // DELETE: api/progress/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = Guid.Parse(
    User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        await _progressService.DeleteAsync(userId, id);

        return NoContent();
    }
}