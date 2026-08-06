using MathCity.Application.Features.AIChat.DTOs;
using MathCity.Application.Features.AIChat.Interfaces;
using MathCity.Shared.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost]
    public async Task<IActionResult> Chat(
        [FromBody] ChatRequest request)
    {
        var response = await _chatService.ChatAsync(request);

        return Ok(ApiResponse<object?>.Ok(response));
    }
}