using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Claims;
using MathCity.Application.Features.Users.DTOs;
using MathCity.Application.Features.Users.Interfaces;
using MathCity.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace MathCity.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserProfileResponse> GetCurrentUserAsync(
    ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirstValue(JwtRegisteredClaimNames.Sub);

        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            throw new Exception("Invalid user id.");
        }

        var applicationUser = await _userManager.FindByIdAsync(userId.ToString());

        if (applicationUser == null)
        {
            throw new Exception("User not found.");
        }

        var roles = await _userManager.GetRolesAsync(applicationUser);

        return new UserProfileResponse
        {
            Id = applicationUser.Id,
            FullName = applicationUser.FullName,
            Email = applicationUser.Email!,
            Roles = roles
        };
    }
}
