using MathCity.Application.Features.AIChat.DTOs;
using MathCity.Application.Features.AIChat.Interfaces;
using MathCity.Shared.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/chat")]
public class AIChatController : ControllerBase
{
    private readonly IChatOrchestrator _chatOrchestrator;

    public AIChatController(
        IChatOrchestrator chatOrchestrator)
    {
        _chatOrchestrator = chatOrchestrator;
    }

    [HttpPost]
    public async Task<IActionResult> Chat(
        ChatRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _chatOrchestrator.ChatAsync(
            request,
            cancellationToken);

        return Ok(ApiResponse<object?>.Ok(response));
    }
}