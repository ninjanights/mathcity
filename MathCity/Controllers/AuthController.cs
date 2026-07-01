using MathCity.Application.Features.Authentication.DTOs;
using MathCity.Application.Features.Authentication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var response = await _authService.RegisterAsync(request);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);

        return Ok(response);
    }

    // POST: api/auth/refresh
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(
    RefreshTokenRequest request)
    {
        var result = await _authService.RefreshTokenAsync(request);

        return Ok(result);
    }

    // POST: api/auth/logout
    [HttpPost("logout")]
    public async Task<IActionResult> Logout(
    RefreshTokenRequest request)
    {
        await _authService.LogoutAsync(request);

        return NoContent();
    }

}