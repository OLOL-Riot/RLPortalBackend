using Microsoft.AspNetCore.Identity;

namespace RLPortalBackend.Entities;

/// <summary>
/// User Entity class for IdentityFraemwork
/// </summary>
public class User : IdentityUser
{
    /// <summary>
    /// Firstname
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Lastname
    /// </summary>
    public string LastName { get; set; }
}

