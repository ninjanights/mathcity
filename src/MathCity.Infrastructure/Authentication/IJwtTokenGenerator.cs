using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCity.Infrastructure.Identity;

namespace MathCity.Infrastructure.Authentication;

public interface IJwtTokenGenerator
{
    Task<string> GenerateTokenAsync(ApplicationUser user, IList<string> roles);
}
