using MathCity.Application.Common.Exceptions;
using MathCity.Application.Features.Authentication.DTOs;
using MathCity.Application.Features.Authentication.Interfaces;
using MathCity.Infrastructure.Identity;
using MathCity.Shared.Constants;
using Microsoft.AspNetCore.Identity;

namespace MathCity.Infrastructure.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        // Check if email already exists
        var existingUser = await _userManager.FindByEmailAsync(request.Email);

        if (existingUser != null)
        {
            throw new ConflictException("Email already exists.");
        }

        // Create new user
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FullName = request.FullName,
            IsActive = true
        };

        // Save user
        var result = await _userManager.CreateAsync(
            user,
            request.Password);

        if (!result.Succeeded)
        {
            throw new ValidationException(
         string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        // Assign Student role
        await _userManager.AddToRoleAsync(user, Roles.Student);

        // Fetch roles
        var roles = await _userManager.GetRolesAsync(user);

        // Generate JWT
        var token = await _jwtTokenGenerator.GenerateTokenAsync(
            user,
            roles);

        // Return response
        return new AuthResponse
        {
            Success = true,
            Message = "Registration successful.",
            Token = token,
            Email = user.Email!,
            FullName = user.FullName,
            Roles = roles,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60) // we'll improve this shortly
        };
    }
    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        // Find user by email
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new UnauthorizedException("Invalid email or password.");
        }

        // Check if account is active
        if (!user.IsActive)
        {
            throw new Exception("This account has been disabled.");
        }

        // Verify password
        var isPasswordValid = await _userManager.CheckPasswordAsync(
            user,
            request.Password);

        if (!isPasswordValid)
        {
            throw new Exception("Invalid email or password.");
        }

        // Get user roles
        var roles = await _userManager.GetRolesAsync(user);

        // Generate JWT
        var token = await _jwtTokenGenerator.GenerateTokenAsync(
            user,
            roles);

        // Return response
        return new AuthResponse
        {
            Success = true,
            Message = "Login successful.",
            Token = token,
            Email = user.Email!,
            FullName = user.FullName,
            Roles = roles,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60) // we'll improve this later
        };
    }
}