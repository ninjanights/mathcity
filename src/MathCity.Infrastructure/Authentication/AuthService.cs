using MathCity.Application.Common.Settings;
using MathCity.Application.Features.Authentication.DTOs;
using MathCity.Application.Features.Authentication.Interfaces;
using MathCity.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MathCity.Infrastructure.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenGenerator jwtTokenGenerator,
        IRefreshTokenService refreshTokenService,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _refreshTokenService = refreshTokenService;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FullName = request.FullName
        };

        var result = await _userManager.CreateAsync(
            user,
            request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(
                string.Join(", ",
                    result.Errors.Select(x => x.Description)));
        }

        await _userManager.AddToRoleAsync(user, "Student");

        var roles = await _userManager.GetRolesAsync(user);

        var accessToken = await _jwtTokenGenerator.GenerateTokenAsync(
            user.Id,
            user.Email!,
            user.FullName,
            roles);

        var refreshToken = _refreshTokenService.GenerateRefreshToken();

        await _refreshTokenService.SaveRefreshTokenAsync(
            user.Id,
            refreshToken);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(
                _jwtSettings.DurationInMinutes),
            Email = user.Email!,
            FullName = user.FullName,
            Roles = roles
        };
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new Exception("Invalid credentials.");

        var result = await _signInManager.CheckPasswordSignInAsync(
            user,
            request.Password,
            false);

        if (!result.Succeeded)
            throw new Exception("Invalid credentials.");

        var roles = await _userManager.GetRolesAsync(user);

        var accessToken = await _jwtTokenGenerator.GenerateTokenAsync(
            user.Id,
            user.Email!,
            user.FullName,
            roles);

        var refreshToken = _refreshTokenService.GenerateRefreshToken();

        await _refreshTokenService.SaveRefreshTokenAsync(
            user.Id,
            refreshToken);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(
                _jwtSettings.DurationInMinutes),
            Email = user.Email!,
            FullName = user.FullName,
            Roles = roles
        };
    }

    public async Task<AuthResponse> RefreshTokenAsync(
       RefreshTokenRequest request)
    {
        // 1. Read expired access token
        var principal = _jwtTokenGenerator
            .GetPrincipalFromExpiredToken(request.AccessToken);

        if (principal == null)
            throw new Exception("Invalid access token.");

        // 2. Get UserId from JWT
        var userId = Guid.Parse(
            principal.FindFirstValue(JwtRegisteredClaimNames.Sub)!);

        // 3. Find refresh token
        var storedRefreshToken =
            await _refreshTokenService.GetRefreshTokenAsync(
                request.RefreshToken);

        if (storedRefreshToken == null)
            throw new Exception("Refresh token not found.");

        // 4. Validate owner
        if (storedRefreshToken.UserId != userId)
            throw new Exception("Invalid refresh token.");

        // 5. Validate state
        if (!storedRefreshToken.IsActive)
            throw new Exception("Refresh token expired or revoked.");

        // 6. Load user
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new Exception("User not found.");

        // 7. Roles
        var roles = await _userManager.GetRolesAsync(user);

        // 8. Generate new access token
        var accessToken =
            await _jwtTokenGenerator.GenerateTokenAsync(
                user.Id,
                user.Email!,
                user.FullName,
                roles);

        // 9. Generate new refresh token
        var refreshToken =
            _refreshTokenService.GenerateRefreshToken();

        // 10. Revoke old refresh token
        await _refreshTokenService.RevokeRefreshTokenAsync(
            storedRefreshToken);

        // 11. Save new refresh token
        await _refreshTokenService.SaveRefreshTokenAsync(
            user.Id,
            refreshToken);

        // 12. Return response
        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(
                _jwtSettings.DurationInMinutes),
            Email = user.Email!,
            FullName = user.FullName,
            Roles = roles
        };
    }

}