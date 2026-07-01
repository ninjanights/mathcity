using MathCity.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MathCity.Infrastructure.Identity;



public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    public ICollection<RefreshToken> RefreshTokens { get; set; }
    = new List<RefreshToken>();
}