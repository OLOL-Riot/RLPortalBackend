using Microsoft.AspNetCore.Identity;

namespace RLPortalBackend.Entities;

/// <summary>
/// UserEntity Entity class for IdentityFraemwork
/// </summary>
public class UserEntity : IdentityUser
{
    /// <summary>
    /// Firstname
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Lastname
    /// </summary>
    public string LastName { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}

