using System.Security.Claims;
using MathCity.Application.Features.Bookmarks.DTOs;
using MathCity.Application.Features.Bookmarks.Interfaces;
using MathCity.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookmarksController : ControllerBase
{
    private readonly IBookmarkService _bookmarkService;

    public BookmarksController(IBookmarkService bookmarkService)
    {
        _bookmarkService = bookmarkService;
    }

    private Guid UserId =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    // POST: api/bookmarks
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookmarkRequest request)
    {
        var result = await _bookmarkService.CreateAsync(UserId, request);

        return Ok(result);
    }

    // GET: api/bookmarks
    [HttpGet]
    public async Task<IActionResult> GetMyBookmarks()
    {
        var result = await _bookmarkService.GetByUserAsync(UserId);

        return Ok(result);
    }

    // DELETE: api/bookmarks/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookmarkService.DeleteAsync(UserId, id);

        return NoContent();
    }
}