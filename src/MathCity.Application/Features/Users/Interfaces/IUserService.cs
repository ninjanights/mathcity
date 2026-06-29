using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathCity.Application.Features.Users.DTOs;
using System.Security.Claims;

namespace MathCity.Application.Features.Users.Interfaces;

public interface IUserService
{
    Task<UserProfileResponse> GetCurrentUserAsync(
        ClaimsPrincipal user);
}