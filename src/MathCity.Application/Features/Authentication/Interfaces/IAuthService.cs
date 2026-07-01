using MathCity.Application.Features.Authentication.DTOs;

namespace MathCity.Application.Features.Authentication.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);

    Task<AuthResponse> LoginAsync(LoginRequest request);

    Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request);

    Task LogoutAsync(RefreshTokenRequest request);
}