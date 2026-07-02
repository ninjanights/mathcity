using MathCity.Application.Features.Storage.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/upload")]
public class UploadController : ControllerBase
{
    private readonly IFileStorageService _storage;

    public UploadController(IFileStorageService storage)
    {
        _storage = storage;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(
        IFormFile file,
        [FromQuery] string folder = "uploads")
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file selected.");

        var result = await _storage.UploadAsync(
            file.OpenReadStream(),
            file.FileName,
            file.ContentType,
            folder);

        return Ok(result);
    }
}