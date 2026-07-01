using MathCity.Application.Features.Tags.DTOs;
using MathCity.Application.Features.Tags.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    // POST: api/tags
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateTagRequest request)
    {
        var result = await _tagService.CreateAsync(request);

        return Ok(result);
    }

    // GET: api/tags
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _tagService.GetAllAsync();

        return Ok(result);
    }

    // GET: api/tags/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _tagService.GetByIdAsync(id);

        return Ok(result);
    }

    // PUT: api/tags/{id}
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateTagRequest request)
    {
        var result = await _tagService.UpdateAsync(id, request);

        return Ok(result);
    }

    // DELETE: api/tags/{id}
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tagService.DeleteAsync(id);

        return NoContent();
    }
}